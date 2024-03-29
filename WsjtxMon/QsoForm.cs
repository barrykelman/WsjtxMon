using ADIFLib;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WSJTXMon;

namespace WsjtxMon
{
    public partial class QsoForm : Form
    {
        public SortableBindingList<QsoLogEntry> QsoList = new SortableBindingList<QsoLogEntry>(new List<QsoLogEntry>());

        public Dictionary<string, List<QsoLogEntry>> WorkedList = new Dictionary<string, List<QsoLogEntry>>();
        const int CallsignCol = 1;

        public QsoForm(Dictionary<string, List<QsoLogEntry>> workedList)
        {
            InitializeComponent();
            List<QsoLogEntry> entries = new List<QsoLogEntry>();
            this.WorkedList = workedList;
            foreach (List<QsoLogEntry> logLists in workedList.Values)
            {
                entries.AddRange(logLists);
            }
            this.InitializeAdifList(entries);
            timer1.Interval = 1000;
            timer1.Enabled = true;
            this.Icon = Form1.LoggerIcon;
        }

        public void InitializeAdifList(List<QsoLogEntry> entryList)
        {
            QsoList = new SortableBindingList<QsoLogEntry>(entryList);
            this.qsoGridView.DataSource = QsoList;
        }

        private void qsoGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            int rowNum = e.RowIndex;
        //    string? callsign = qsoGridView.Rows[rowNum].Cells[CallsignCol].Value.ToString();
            foreach (KeyValuePair<string, List<QsoLogEntry>> pair in WorkedList)
            {
                if (string.IsNullOrWhiteSpace(pair.Value[0].Country))
                {
                    NetFuncs.LookupCallsign(pair.Key, out string state, out string dxcc, out string country);
                    foreach (QsoLogEntry log in pair.Value)
                    {
                        log.Country = country;
                        log.State = state;
                    }
                }
            }
        }

        private void qsoGridView_Layout(object sender, LayoutEventArgs e)
        {
            foreach (DataGridViewRow row in qsoGridView.Rows)
            {
                if (row.Cells[0].Displayed)
                {
                    string? callsign = row.Cells[CallsignCol].Value.ToString();
                    if ((callsign is not null) && WorkedList.ContainsKey(callsign))
                    {
                        List<QsoLogEntry> qsolist = WorkedList[callsign];
                        if (string.IsNullOrEmpty(qsolist[0].Country))
                        {
                            NetFuncs.LookupCallsign(callsign, out string state, out string dxcc, out string country); ;
                            foreach (QsoLogEntry log in qsolist)
                            {
                                log.Country = country;
                                log.State = state;
                            }
                        }
                    }
                }
            }

        }

        private void qsoGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool updated = false;
            foreach (DataGridViewRow row in qsoGridView.Rows)
            {
                if (row.Cells[0].Displayed)
                {
                    //string callsign = row.Cells[1].Value.ToString();
                    //List<QsoLogEntry> qsolist = WorkedList[callsign];
                    //if (string.IsNullOrEmpty(qsolist[0].Country))
                    //{
                    //    updated = true;
                    //    NetFuncs.LookupCallsign(callsign, out string state, out string dxcc, out string country); ;
                    //    foreach (QsoLogEntry log in qsolist)
                    //    {
                    //        log.Country = country;
                    //        log.State = state;
                    //    }
                    //}
                }
            }
            if (updated)
            {
                qsoGridView.Invalidate();
                qsoGridView.Update();
            }

        }
    }
}
