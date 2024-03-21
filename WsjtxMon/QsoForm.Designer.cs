namespace WsjtxMon
{
    partial class QsoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            qsoGridView = new DataGridView();
            whenDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            callsignDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            modeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            bandDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            frequencyDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            rcvdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            sentDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            gridDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            countryDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            stateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            qsoLogEntryBindingSource = new BindingSource(components);
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)qsoGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)qsoLogEntryBindingSource).BeginInit();
            SuspendLayout();
            // 
            // qsoGridView
            // 
            qsoGridView.AutoGenerateColumns = false;
            qsoGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            qsoGridView.Columns.AddRange(new DataGridViewColumn[] { whenDataGridViewTextBoxColumn, callsignDataGridViewTextBoxColumn, modeDataGridViewTextBoxColumn, bandDataGridViewTextBoxColumn, frequencyDataGridViewTextBoxColumn, rcvdDataGridViewTextBoxColumn, sentDataGridViewTextBoxColumn, gridDataGridViewTextBoxColumn, countryDataGridViewTextBoxColumn, stateDataGridViewTextBoxColumn });
            qsoGridView.DataSource = qsoLogEntryBindingSource;
            qsoGridView.Dock = DockStyle.Fill;
            qsoGridView.Location = new Point(0, 0);
            qsoGridView.Name = "qsoGridView";
            qsoGridView.RowTemplate.Height = 16;
            qsoGridView.Size = new Size(800, 450);
            qsoGridView.TabIndex = 0;
            qsoGridView.VirtualMode = true;
            qsoGridView.CellClick += qsoGridView_CellClick;
            qsoGridView.CellValueNeeded += qsoGridView_CellValueNeeded;
            qsoGridView.Layout += qsoGridView_Layout;
            // 
            // whenDataGridViewTextBoxColumn
            // 
            whenDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            whenDataGridViewTextBoxColumn.DataPropertyName = "When";
            whenDataGridViewTextBoxColumn.HeaderText = "When";
            whenDataGridViewTextBoxColumn.Name = "whenDataGridViewTextBoxColumn";
            whenDataGridViewTextBoxColumn.ReadOnly = true;
            whenDataGridViewTextBoxColumn.Width = 63;
            // 
            // callsignDataGridViewTextBoxColumn
            // 
            callsignDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            callsignDataGridViewTextBoxColumn.DataPropertyName = "Callsign";
            callsignDataGridViewTextBoxColumn.HeaderText = "Callsign";
            callsignDataGridViewTextBoxColumn.Name = "callsignDataGridViewTextBoxColumn";
            callsignDataGridViewTextBoxColumn.Width = 74;
            // 
            // modeDataGridViewTextBoxColumn
            // 
            modeDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            modeDataGridViewTextBoxColumn.DataPropertyName = "Mode";
            modeDataGridViewTextBoxColumn.HeaderText = "Mode";
            modeDataGridViewTextBoxColumn.Name = "modeDataGridViewTextBoxColumn";
            modeDataGridViewTextBoxColumn.Width = 63;
            // 
            // bandDataGridViewTextBoxColumn
            // 
            bandDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            bandDataGridViewTextBoxColumn.DataPropertyName = "Band";
            bandDataGridViewTextBoxColumn.HeaderText = "Band";
            bandDataGridViewTextBoxColumn.Name = "bandDataGridViewTextBoxColumn";
            bandDataGridViewTextBoxColumn.Width = 59;
            // 
            // frequencyDataGridViewTextBoxColumn
            // 
            frequencyDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            frequencyDataGridViewTextBoxColumn.DataPropertyName = "Frequency";
            frequencyDataGridViewTextBoxColumn.HeaderText = "Frequency";
            frequencyDataGridViewTextBoxColumn.Name = "frequencyDataGridViewTextBoxColumn";
            frequencyDataGridViewTextBoxColumn.Width = 87;
            // 
            // rcvdDataGridViewTextBoxColumn
            // 
            rcvdDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            rcvdDataGridViewTextBoxColumn.DataPropertyName = "Rcvd";
            rcvdDataGridViewTextBoxColumn.HeaderText = "Rcvd";
            rcvdDataGridViewTextBoxColumn.Name = "rcvdDataGridViewTextBoxColumn";
            rcvdDataGridViewTextBoxColumn.Width = 58;
            // 
            // sentDataGridViewTextBoxColumn
            // 
            sentDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            sentDataGridViewTextBoxColumn.DataPropertyName = "Sent";
            sentDataGridViewTextBoxColumn.HeaderText = "Sent";
            sentDataGridViewTextBoxColumn.Name = "sentDataGridViewTextBoxColumn";
            sentDataGridViewTextBoxColumn.Width = 55;
            // 
            // gridDataGridViewTextBoxColumn
            // 
            gridDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridDataGridViewTextBoxColumn.DataPropertyName = "Grid";
            gridDataGridViewTextBoxColumn.HeaderText = "Grid";
            gridDataGridViewTextBoxColumn.Name = "gridDataGridViewTextBoxColumn";
            gridDataGridViewTextBoxColumn.Width = 54;
            // 
            // countryDataGridViewTextBoxColumn
            // 
            countryDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            countryDataGridViewTextBoxColumn.DataPropertyName = "Country";
            countryDataGridViewTextBoxColumn.HeaderText = "Country";
            countryDataGridViewTextBoxColumn.Name = "countryDataGridViewTextBoxColumn";
            countryDataGridViewTextBoxColumn.Width = 75;
            // 
            // stateDataGridViewTextBoxColumn
            // 
            stateDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            stateDataGridViewTextBoxColumn.DataPropertyName = "State";
            stateDataGridViewTextBoxColumn.HeaderText = "State";
            stateDataGridViewTextBoxColumn.Name = "stateDataGridViewTextBoxColumn";
            stateDataGridViewTextBoxColumn.Width = 58;
            // 
            // qsoLogEntryBindingSource
            // 
            qsoLogEntryBindingSource.DataSource = typeof(QsoLogEntry);
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // QsoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(qsoGridView);
            Name = "QsoForm";
            Text = "QSOs Logged Form";
            ((System.ComponentModel.ISupportInitialize)qsoGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)qsoLogEntryBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView qsoGridView;
        private BindingSource qsoLogEntryBindingSource;
        private DataGridViewTextBoxColumn whenDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn callsignDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn modeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn bandDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn frequencyDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn rcvdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sentDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn gridDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn countryDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn stateDataGridViewTextBoxColumn;
        private System.Windows.Forms.Timer timer1;
    }
}