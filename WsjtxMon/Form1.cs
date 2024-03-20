using M0LTE.WsjtxUdpLib.Client;
using M0LTE.WsjtxUdpLib.Messages;
using M0LTE.WsjtxUdpLib.Messages.Both;
using M0LTE.WsjtxUdpLib.Messages.Out;
using System.ComponentModel;
using System.Net;
using System.Reflection;
using WsjtxMon;

namespace WSJTXMon
{
    public partial class Form1 : Form
    {
        public List<Caller> CallerList = new List<Caller>();
        public BindingList<Caller> CallerBindList = new BindingList<Caller>(new List<Caller>());
        public SortedList<string, string> WorkedList = new SortedList<string, string>();
        public Queue<WsjtxMessage> WsjtxQueue = new Queue<WsjtxMessage>();
        public int AdifOffset = 0;
        public WsjtxClientEx? WClient;
        public static ListSortDirection SortDirection = ListSortDirection.Descending;
        public static int SortColumn = 6;
        const int WsjtxPort = 2237;
        IPEndPoint WsjtxAddr;

        public Form1()
        {
            InitializeComponent();
            this.InitializeLists();
            this.InitializeWsJtxLib();
            Timer.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var type = CallerListView.GetType();
            var propertyInfo = type.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            propertyInfo.SetValue(CallerListView, true, null);
            Conditions.LoadAsync(@"https://www.hamqsl.com/solar101pic.php");
        }

        public void InitializeLists()
        {
            RefreshCallerList();
            foreach (string line in File.ReadLines(WsjtxResource.AdifPath))
            {
                if (line.StartsWith("<call"))
                {
                    int callsignOffset = line.IndexOf('>') + 1;
                    int callsignEndOffset = line.IndexOf('<', callsignOffset);
                    string callsign = line.Substring(callsignOffset, callsignEndOffset - callsignOffset).Trim();
                    if (!WorkedList.ContainsKey(callsign))
                    {
                        WorkedList.Add(callsign, callsign);
                    }
                    AdifOffset += line.Length;
                }
            }
        }

        public void InitializeWsJtxLib()
        {
            WClient = new WsjtxClientEx((msg, from) =>
            {
                WsjtxAddr = from;
                this.WsjtxQueue.Enqueue(msg);
            }, IPAddress.Parse("127.0.0.1"));
        }

        public void ProcessWsjtx(WsjtxMessage msg)
        {
            if (msg is DecodeMessage)
            {
                string calling = ((DecodeMessage)msg).Message;
                string[] callingSub = calling.Split(' ');
                if (callingSub.Length < 2)
                {
                    return;
                }
                string callsign = callingSub.Length > 2 ? callingSub[callingSub.Length - 2] : callingSub[1];
                Caller? caller = CallerList.FirstOrDefault<Caller>(c => c.CallSign == callsign);
                if (calling.StartsWith("CQ"))
                {
                    if (caller is null)
                    {
                        CallerList.Add(new Caller(callsign, (DecodeMessage)msg));
                    }
                    else
                    {
                        caller.Db = ((DecodeMessage)msg).Snr;
                        caller.Age = new TimeSpan(0);
                    }

                    RefreshCallerList();
                }
                else
                {
                    if ((caller is not null) && !calling.Contains(WsjtxResource.Callsign))
                    {
                        CallerList.Remove(caller);
                        RefreshCallerList();
                    }
                }
            }
            else if (msg is LoggedAdifMessage)
            {
                NetFuncs.LogToQrz((LoggedAdifMessage)msg);
                NetFuncs.LogToTQsl((LoggedAdifMessage)msg);
            }
            else if (msg is QsoLoggedMessage)
            {
                string callsign = ((QsoLoggedMessage)msg).DxCall;
                Caller? cqMsg = CallerList.FirstOrDefault(c => c.CallSign == callsign);
                if (cqMsg != null)
                {
                    CallerList.Remove(cqMsg);
                }
                if (!WorkedList.ContainsKey(callsign))
                {
                    WorkedList.Add(callsign, callsign);
                }
                RefreshCallerList();
            }
            else if (msg is ClearMessage)
            {
                CallerList.Clear();
                RefreshCallerList();
            }
        }

        public void MarkWorked()
        {
            foreach (DataGridViewRow row in CallerListView.Rows)
            {
                row.Cells[0].Style.BackColor = GetCellColor(row);
            }
        }

        private Color GetCellColor(DataGridViewRow row)
        {
            row.Selected = false;
            string callsign = row.Cells[0].Value.ToString() ?? string.Empty;
            string calling = row.Cells[1].Value.ToString() ?? string.Empty;
            int callingSubCount = calling.Split(' ').Length;
            if (!WorkedList.ContainsKey(callsign))
            {
                return callingSubCount > 3 ? Color.Yellow : Color.LightGreen;
            }
            else return Color.White;
        }

        private void SortCallerList()
        {
            CallerList.Sort(new ColumnComparer());
        }

        public class ColumnComparer : IComparer<Caller>
        {
            public string[] ColumnNames = { "CallSign", "Calling", "Grid", "DXCC", "Country", "State", "dB", "Age" };
            public int Compare(Caller? x, Caller? y)
            {
                string column = ColumnNames[SortColumn];
                int result = 0;
                if (x is null || y is null) { return 0; }
                switch (column)
                {
                    case "CallSign":
                    default:
                        result = x.CallSign.CompareTo(y.CallSign);
                        break;
                    case "Calling":
                        result = x.Calling.CompareTo(y.Calling);
                        break;
                    case "Grid":
                        result = x.Grid.CompareTo(y.Grid);
                        break;
                    case "Country":
                        result = x.Country.CompareTo(y.Country);
                        break;
                    case "dB":
                        result = x.Db.CompareTo(y.Db);
                        break;
                    case "Age":
                        result = x.Age.CompareTo(y.Age);
                        break;
                }

                if (SortDirection == ListSortDirection.Descending)
                {
                    result = -result;
                }

                return result;
            }
        }

        private void RefreshCallerList()
        {
            SortCallerList();
            CallerListView.SuspendLayout();
            CallerBindList = new BindingList<Caller>(CallerList);
            CallerListView.DataSource = null;
            CallerListView.DataSource = CallerBindList;
            MarkWorked();
            CallerListView.Invalidate();
            CallerListView.Update();
            CallerListView.ResumeLayout();
        }

        public void Timer_Tick(object sender, EventArgs e)
        {
            while (WsjtxQueue.TryDequeue(out WsjtxMessage? msg))
            {
                this.ProcessWsjtx(msg);
            }

            List<Caller> callersToDelete = new List<Caller>();
            bool needDelete = false;
            foreach (DataGridViewRow row in CallerListView.Rows)
            {
                string callsign = row.Cells[0].Value.ToString() ?? string.Empty;
                Caller? caller = CallerList.FirstOrDefault(c => c.CallSign == callsign);
                if (caller != null)
                {
                    caller.Age = caller.Age.Add(new TimeSpan(0, 0, 1));
                    if (caller.Age.Minutes >= 5)
                    {
                        callersToDelete.Add(caller);
                        needDelete = true;
                    }
                }
            }
            foreach (Caller caller in callersToDelete)
            {
                CallerList.Remove(caller);
            }
            if (needDelete)
            {
                RefreshCallerList();
            }
            else
            {
                CallerListView.Invalidate();
                CallerListView.Update();
            }
        }

        private void CallerListView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                SortDirection = SortDirection == ListSortDirection.Ascending ?
                    ListSortDirection.Descending : ListSortDirection.Ascending;
                SortColumn = e.ColumnIndex;
                RefreshCallerList();
            }
            else
            {
                Caller caller = CallerList[e.RowIndex];
                byte[] replyDg = NetFuncs.GenerateReply(caller.Message);
                WClient.Send(replyDg, WsjtxAddr);
                CallerListView.Rows[e.RowIndex].Selected = false;
            }
        }
    }
}

