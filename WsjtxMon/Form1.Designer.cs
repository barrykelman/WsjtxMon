namespace WSJTXMon
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            CallerListView = new DataGridView();
            callSignDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            callingDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            gridDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dXCCDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            Country = new DataGridViewTextBoxColumn();
            stateDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dbDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ageDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            callerBindingSource = new BindingSource(components);
            label1 = new Label();
            callerBindingSource1 = new BindingSource(components);
            Timer = new System.Windows.Forms.Timer(components);
            Conditions = new PictureBox();
            QsoButton = new Button();
            ((System.ComponentModel.ISupportInitialize)CallerListView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)callerBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)callerBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Conditions).BeginInit();
            SuspendLayout();
            // 
            // CallerListView
            // 
            CallerListView.AllowUserToAddRows = false;
            CallerListView.AllowUserToDeleteRows = false;
            CallerListView.AllowUserToResizeRows = false;
            CallerListView.AutoGenerateColumns = false;
            CallerListView.CausesValidation = false;
            CallerListView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CallerListView.Columns.AddRange(new DataGridViewColumn[] { callSignDataGridViewTextBoxColumn, callingDataGridViewTextBoxColumn, gridDataGridViewTextBoxColumn, dXCCDataGridViewTextBoxColumn, Country, stateDataGridViewTextBoxColumn, dbDataGridViewTextBoxColumn, ageDataGridViewTextBoxColumn });
            CallerListView.DataSource = callerBindingSource;
            CallerListView.EditMode = DataGridViewEditMode.EditProgrammatically;
            CallerListView.Location = new Point(35, 69);
            CallerListView.Name = "CallerListView";
            CallerListView.ReadOnly = true;
            CallerListView.RowTemplate.Height = 15;
            CallerListView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            CallerListView.ShowCellErrors = false;
            CallerListView.ShowCellToolTips = false;
            CallerListView.ShowEditingIcon = false;
            CallerListView.ShowRowErrors = false;
            CallerListView.Size = new Size(631, 349);
            CallerListView.TabIndex = 1;
            CallerListView.CellMouseClick += CallerListView_CellMouseClick;
            // 
            // callSignDataGridViewTextBoxColumn
            // 
            callSignDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            callSignDataGridViewTextBoxColumn.DataPropertyName = "CallSign";
            callSignDataGridViewTextBoxColumn.HeaderText = "CallSign";
            callSignDataGridViewTextBoxColumn.Name = "callSignDataGridViewTextBoxColumn";
            callSignDataGridViewTextBoxColumn.ReadOnly = true;
            callSignDataGridViewTextBoxColumn.Width = 75;
            // 
            // callingDataGridViewTextBoxColumn
            // 
            callingDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            callingDataGridViewTextBoxColumn.DataPropertyName = "Calling";
            callingDataGridViewTextBoxColumn.HeaderText = "Calling";
            callingDataGridViewTextBoxColumn.Name = "callingDataGridViewTextBoxColumn";
            callingDataGridViewTextBoxColumn.ReadOnly = true;
            callingDataGridViewTextBoxColumn.Width = 69;
            // 
            // gridDataGridViewTextBoxColumn
            // 
            gridDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridDataGridViewTextBoxColumn.DataPropertyName = "Grid";
            gridDataGridViewTextBoxColumn.HeaderText = "Grid";
            gridDataGridViewTextBoxColumn.Name = "gridDataGridViewTextBoxColumn";
            gridDataGridViewTextBoxColumn.ReadOnly = true;
            gridDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDataGridViewTextBoxColumn.Width = 54;
            // 
            // dXCCDataGridViewTextBoxColumn
            // 
            dXCCDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dXCCDataGridViewTextBoxColumn.DataPropertyName = "DXCC";
            dXCCDataGridViewTextBoxColumn.HeaderText = "DXCC";
            dXCCDataGridViewTextBoxColumn.Name = "dXCCDataGridViewTextBoxColumn";
            dXCCDataGridViewTextBoxColumn.ReadOnly = true;
            dXCCDataGridViewTextBoxColumn.Width = 63;
            // 
            // Country
            // 
            Country.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Country.DataPropertyName = "Country";
            Country.HeaderText = "Country";
            Country.Name = "Country";
            Country.ReadOnly = true;
            Country.Width = 75;
            // 
            // stateDataGridViewTextBoxColumn
            // 
            stateDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            stateDataGridViewTextBoxColumn.DataPropertyName = "State";
            stateDataGridViewTextBoxColumn.HeaderText = "State";
            stateDataGridViewTextBoxColumn.Name = "stateDataGridViewTextBoxColumn";
            stateDataGridViewTextBoxColumn.ReadOnly = true;
            stateDataGridViewTextBoxColumn.Width = 58;
            // 
            // dbDataGridViewTextBoxColumn
            // 
            dbDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dbDataGridViewTextBoxColumn.DataPropertyName = "Db";
            dbDataGridViewTextBoxColumn.HeaderText = "Db";
            dbDataGridViewTextBoxColumn.Name = "dbDataGridViewTextBoxColumn";
            dbDataGridViewTextBoxColumn.ReadOnly = true;
            dbDataGridViewTextBoxColumn.Width = 47;
            // 
            // ageDataGridViewTextBoxColumn
            // 
            ageDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ageDataGridViewTextBoxColumn.DataPropertyName = "AgeText";
            ageDataGridViewTextBoxColumn.HeaderText = "Age";
            ageDataGridViewTextBoxColumn.Name = "ageDataGridViewTextBoxColumn";
            ageDataGridViewTextBoxColumn.ReadOnly = true;
            ageDataGridViewTextBoxColumn.Width = 53;
            // 
            // callerBindingSource
            // 
            callerBindingSource.DataSource = typeof(Caller);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(199, 21);
            label1.Name = "label1";
            label1.Size = new Size(302, 25);
            label1.TabIndex = 0;
            label1.Text = "W7BIK's WSJTX Monitor/Logger";
            // 
            // callerBindingSource1
            // 
            callerBindingSource1.DataSource = typeof(Caller);
            // 
            // Timer
            // 
            Timer.Interval = 1000;
            Timer.Tick += Timer_Tick;
            // 
            // Conditions
            // 
            Conditions.Location = new Point(141, 443);
            Conditions.Name = "Conditions";
            Conditions.Size = new Size(419, 130);
            Conditions.TabIndex = 2;
            Conditions.TabStop = false;
            // 
            // QsoButton
            // 
            QsoButton.Location = new Point(618, 25);
            QsoButton.Name = "QsoButton";
            QsoButton.Size = new Size(48, 23);
            QsoButton.TabIndex = 3;
            QsoButton.Text = "QSOs";
            QsoButton.UseVisualStyleBackColor = true;
            QsoButton.Click += QsoButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(701, 585);
            Controls.Add(QsoButton);
            Controls.Add(Conditions);
            Controls.Add(CallerListView);
            Controls.Add(label1);
            Name = "Form1";
            Text = "W7BIK's WSJTX Monitor/Logger";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)CallerListView).EndInit();
            ((System.ComponentModel.ISupportInitialize)callerBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)callerBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)Conditions).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private BindingSource callerBindingSource;
        private BindingSource callerBindingSource1;
        private DataGridView CallerListView;
        private System.Windows.Forms.Timer Timer;
        private DataGridViewTextBoxColumn callSignDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn callingDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn gridDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dXCCDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn Country;
        private DataGridViewTextBoxColumn stateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dbDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ageDataGridViewTextBoxColumn;
        private PictureBox Conditions;
        private Button QsoButton;
    }
}
