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

namespace WsjtxMon
{
    public partial class QsoForm : Form
    {
        public SortableBindingList<QsoLogEntry> QsoList = new SortableBindingList<QsoLogEntry>(new List<QsoLogEntry>());
        public QsoForm(string adifPath)
        {
            InitializeComponent();
            this.InitializeAdifList(adifPath);
        }

        public void InitializeAdifList(string adifPath)
        {
            ADIF adif = new ADIF(adifPath);
            QsoList = new SortableBindingList<QsoLogEntry>(adif.TheQSOs.Select(q => new QsoLogEntry(q)).ToList());
            this.qsoGridView.DataSource = QsoList;
        }
    }
}
