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
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            SaveBut.Enabled = false;
            CallsignTxt.Text = Form1.WsjtxResource.Callsign;
            AdifPathTxt.Text = Form1.WsjtxResource.AdifPath;
            QrzKeyTxt.Text = Form1.WsjtxResource.QrzApiKey;
            QrzPassTxt.Text = Form1.WsjtxResource.QrzPassword;
            QrzUserTxt.Text = Form1.WsjtxResource.QrzUser;
            TqslDirTxt.Text = Form1.WsjtxResource.TqslDirectory;
            TqslPassTxt.Text = Form1.WsjtxResource.TqslPassword;
            TqslUserTxt.Text = Form1.WsjtxResource.TqslUser;
            Settings_TextChanged(this, new EventArgs());
        }

        private void Settings_TextChanged(object sender, EventArgs e)
        {
            SaveBut.Enabled = !string.IsNullOrWhiteSpace(CallsignTxt.Text) &&
                !string.IsNullOrWhiteSpace(AdifPathTxt.Text) &&
                !string.IsNullOrWhiteSpace(QrzKeyTxt.Text) &&
                !string.IsNullOrWhiteSpace(QrzPassTxt.Text) &&
                !string.IsNullOrWhiteSpace(QrzUserTxt.Text) &&
                !string.IsNullOrWhiteSpace(TqslDirTxt.Text) &&
                !string.IsNullOrWhiteSpace(TqslPassTxt.Text) &&
                !string.IsNullOrWhiteSpace(TqslUserTxt.Text);
        }

        private void AdifPathBut_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.

            if (result == DialogResult.OK)
            {
                AdifPathTxt.Text = openFileDialog1.FileName;
            }
        }

        private void TqslDirBut_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                TqslDirTxt.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void SaveBut_Click(object sender, EventArgs e)
        {
            Form1.WsjtxResource.Callsign = CallsignTxt.Text;
            Form1.WsjtxResource.AdifPath = AdifPathTxt.Text;
            Form1.WsjtxResource.QrzApiKey = QrzKeyTxt.Text;
            Form1.WsjtxResource.QrzPassword = QrzPassTxt.Text;
            Form1.WsjtxResource.QrzUser = QrzUserTxt.Text;
            Form1.WsjtxResource.TqslDirectory = TqslDirTxt.Text;
            Form1.WsjtxResource.TqslPassword = TqslPassTxt.Text;
            Form1.WsjtxResource.TqslUser = TqslUserTxt.Text;
            Form1.WsjtxResource.Save();
            this.DialogResult = DialogResult.OK;
        }

        private void CancelBut_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
