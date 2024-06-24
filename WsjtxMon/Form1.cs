using ADIFLib;
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
        public Dictionary<string, List<QsoLogEntry>> WorkedList = new Dictionary<string, List<QsoLogEntry>>();
        public SortedList<string, string> WorkedCountryList = new SortedList<string, string>();
        public ADIF? Adif;
        public Queue<WsjtxMessage> WsjtxQueue = new Queue<WsjtxMessage>();
        public WsjtxClientEx? WClient;
        public static ListSortDirection SortDirection = ListSortDirection.Descending;
        public static int SortColumn = 6;
        const int WsjtxPort = 2237;
        IPEndPoint WsjtxAddr = new IPEndPoint(0, 0);
        public static WsjtxResource WsjtxResource = new WsjtxResource();
        public static Icon? LoggerIcon;
        public static Dictionary<int, int> BandTraffic = new Dictionary<int, int>()
        {
            {10, 0},
            {12, 0},
            {15, 0},
            {17, 0},
            {20, 0},
            {30, 0},
            {40, 0},
            {80, 0}
        };

        public int TickCount = 6;
        const int TrafficInterval = 5;
        const string Title = "W7BIK's WSJTX Monitor/Logger v";
        public Cursor OrigCursor;

        public Form1()
        {
            OrigCursor = this.Cursor;
            Cursor.Current = Cursors.WaitCursor;
            InitializeComponent();
            this.InitializeWsJtxLib();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = this.BigTitle.Text = Title + WsjtxResource.Version.ToString();
            while (string.IsNullOrWhiteSpace(WsjtxResource.Callsign))
            {
                WsjtxResource = WsjtxResource.Load();
                if (string.IsNullOrWhiteSpace(WsjtxResource.Callsign))
                {
                    var settingsDlg = new SettingsForm();
                    DialogResult res = settingsDlg.ShowDialog();
                }
            }
            this.Location = WsjtxResource.Location;
            this.Size = WsjtxResource.Size;
            this.InitializeLists();
            Timer.Enabled = true;
            if (WClient is null)
            {
                throw new ApplicationException("Wsjtx client init failure");
            }
            var type = CallerListView.GetType();
            var propertyInfo = type.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            if (propertyInfo is null)
            {
                throw new ApplicationException("No DoubleBuffered property in DataGridView");
            }
            else
            {
                propertyInfo.SetValue(CallerListView, true, null);
            }
            Conditions.LoadAsync(@"https://www.hamqsl.com/solar101pic.php");
            this.Icon = LoggerIcon = new Icon("favicon.ico");
            NetFuncs.GetBandTraffic();
            Cursor.Current = this.OrigCursor;
        }

        public void InitializeLists()
        {
            RefreshCallerList();
            this.Adif = new ADIF(WsjtxResource.AdifPath);
            foreach (ADIFQSO qso in this.Adif.TheQSOs)
            {
                QsoLogEntry entry = new QsoLogEntry(qso);
                string callsign = entry.Callsign;
                if (!WorkedList.ContainsKey(callsign))
                {
                    WorkedList.Add(callsign, new List<QsoLogEntry>());
                }
                WorkedList[callsign].Add(entry);
            }
            NetFuncs.InitWorkedDb(WorkedList, WorkedCountryList);
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
                if (calling is null)
                {
                    return;
                }
                string[] callingSub = calling.Split(' ');
                if (callingSub.Length < 2)
                {
                    return;
                }
                string callsign = string.Empty;
                if (calling.StartsWith("CQ"))
                {
                    for (int i = callingSub.Length - 1; i >= 1; i--)
                    {
                        int numDig = callingSub[i].Count(c => char.IsDigit(c));
                        if (numDig >= 2)
                        {
                            continue;
                        }
                        else if (numDig > 0)
                        {
                            callsign = callingSub[i];
                            break;
                        }
                    }
                    if (string.IsNullOrEmpty(callsign))
                    {
                        return;
                    }
                    Caller? caller = CallerList.FirstOrDefault<Caller>(c => callsign.Contains(c.CallSign));
                    if (caller is null)
                    {
                        if (!NetFuncs.CountryDict.ContainsKey(callsign))
                        {
                            string workStr = string.Empty;
                            NetFuncs.UpdateCountryDict(callsign, string.Empty, WorkedList, workStr, WorkedCountryList);
                        }
                        CallerList.Add(new Caller(callsign, (DecodeMessage)msg));
                    }
                    else
                    {
                        caller.Db = ((DecodeMessage)msg).Snr;
                        caller.Age = new TimeSpan(0);
                        caller.Calling = ((DecodeMessage)msg).Message;
                    }

                    RefreshCallerList();
                }
                else
                {
                    callsign = callingSub[1];
                    Caller? caller = CallerList.FirstOrDefault<Caller>(c => callsign.Contains(c.CallSign));
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
                    WorkedList.Add(callsign, new List<QsoLogEntry>());
                }
                WorkedList[callsign].Add(new QsoLogEntry((QsoLoggedMessage)msg));
                NetFuncs.UpdateCountryDictEntry(callsign, WorkedList, WorkedCountryList);
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
                row.Cells[0].Style.BackColor = GetCellColor(row, out Color countryColor);
                row.Cells[4].Style.BackColor = countryColor;
            }
        }

        private Color GetCellColor(DataGridViewRow row, out Color countryColor)
        {
            row.Selected = false;
            string callsign = row.Cells[0].Value.ToString() ?? string.Empty;
            string calling = row.Cells[1].Value.ToString() ?? string.Empty;
            string country = row.Cells[4].Value.ToString() ?? string.Empty;
            int callingSubCount = calling.Split(' ').Length;
            countryColor = Color.White;
            if (!WorkedList.ContainsKey(callsign))
            {
                if (!string.IsNullOrWhiteSpace(country) && !WorkedCountryList.ContainsKey(country))
                {
                    countryColor = Color.LightSeaGreen;
                }
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
            lock (NetFuncs.CountryDict)
            {
                Timer.Enabled = false;
                while (WsjtxQueue.TryDequeue(out WsjtxMessage? msg))
                {
                    this.ProcessWsjtx(msg);
                }

                List<Caller> callersToDelete = new List<Caller>();
                bool needDelete = false;
                foreach (Caller caller in CallerList)
                {
                    caller.Age = caller.Age.Add(new TimeSpan(0, 0, 1));
                    if (caller.Age.Minutes >= 5)
                    {
                        callersToDelete.Add(caller);
                        needDelete = true;
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
                NetFuncs.UpdateCountryBatch(WorkedList, WorkedCountryList);
                Timer.Enabled = true;
                if (TickCount++ > TrafficInterval)
                {
                    _ = Task.Run(() => NetFuncs.GetBandTraffic());
                    TickCount = 0;
                }
                if (this.ShowBandTraffic() == 0)
                {
                    TickCount = TrafficInterval + 1;
                }
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
                if (WClient is null)
                {
                    throw new ApplicationException("Wsjtx client init failure");
                }
                WClient.Send(replyDg, WsjtxAddr);
                CallerListView.Rows[e.RowIndex].Selected = false;
            }
        }

        private void QsoButton_Click(object sender, EventArgs e)
        {
            Form qsoForm = new QsoForm(this.WorkedList);
            qsoForm.Show();
        }

        private void SettingsBut_Click(object sender, EventArgs e)
        {
            Form settingsForm = new SettingsForm();
            DialogResult res = settingsForm.ShowDialog();
            if (res == DialogResult.OK)
            {
                this.Form1_Load(this, new EventArgs());
            }
        }

        private int ShowBandTraffic()
        {
            int maxTfx = BandTraffic.Values.Max();
            if (maxTfx > 0)
            {
                ProgressPanel10.Width = BandTraffic[10] * 100 / maxTfx;
                ProgressPanel12.Width = BandTraffic[12] * 100 / maxTfx;
                ProgressPanel15.Width = BandTraffic[15] * 100 / maxTfx;
                ProgressPanel17.Width = BandTraffic[17] * 100 / maxTfx;
                ProgressPanel20.Width = BandTraffic[20] * 100 / maxTfx;
                ProgressPanel30.Width = BandTraffic[30] * 100 / maxTfx;
                ProgressPanel40.Width = BandTraffic[40] * 100 / maxTfx;
            }
            return maxTfx;
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            WsjtxResource.Location = this.Location;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            WsjtxResource.Save();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            int newWidth = this.Size.Width - 86;
            int newHeight = this.Size.Height - 275;
            CallerListView.Size = new Size(newWidth, newHeight);
            WsjtxResource.Size = this.Size;
        }

        private void Countries_Click(object sender, EventArgs e)
        {
            string title = string.Format("{0} Countries Worked", WorkedCountryList.Count - 1);
            MessageBox.Show(string.Join('\n', WorkedCountryList.Values.Skip(1)), title);
        }
    }
}

