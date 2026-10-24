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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            BigTitle = new Label();
            callerBindingSource1 = new BindingSource(components);
            Timer = new System.Windows.Forms.Timer(components);
            Conditions = new PictureBox();
            QsoButton = new Button();
            SettingsBut = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            ProgressPanel10 = new Panel();
            ProgressPanel15 = new Panel();
            ProgressPanel12 = new Panel();
            ProgressPanel17 = new Panel();
            ProgressPanel20 = new Panel();
            ProgressPanel30 = new Panel();
            ProgressPanel40 = new Panel();
            panel1 = new Panel();
            panel2 = new Panel();
            Countries = new Button();
            ((System.ComponentModel.ISupportInitialize)CallerListView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)callerBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)callerBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Conditions).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
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
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            CallerListView.DefaultCellStyle = dataGridViewCellStyle1;
            CallerListView.EditMode = DataGridViewEditMode.EditProgrammatically;
            CallerListView.Location = new Point(41, 88);
            CallerListView.Margin = new Padding(3, 4, 3, 4);
            CallerListView.Name = "CallerListView";
            CallerListView.ReadOnly = true;
            CallerListView.RowHeadersWidth = 51;
            CallerListView.RowTemplate.Height = 15;
            CallerListView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            CallerListView.ShowCellErrors = false;
            CallerListView.ShowCellToolTips = false;
            CallerListView.ShowEditingIcon = false;
            CallerListView.ShowRowErrors = false;
            CallerListView.Size = new Size(721, 465);
            CallerListView.TabIndex = 1;
            CallerListView.CellMouseClick += CallerListView_CellMouseClick;
            // 
            // callSignDataGridViewTextBoxColumn
            // 
            callSignDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            callSignDataGridViewTextBoxColumn.DataPropertyName = "CallSign";
            callSignDataGridViewTextBoxColumn.HeaderText = "CallSign";
            callSignDataGridViewTextBoxColumn.MinimumWidth = 6;
            callSignDataGridViewTextBoxColumn.Name = "callSignDataGridViewTextBoxColumn";
            callSignDataGridViewTextBoxColumn.ReadOnly = true;
            callSignDataGridViewTextBoxColumn.Width = 92;
            // 
            // callingDataGridViewTextBoxColumn
            // 
            callingDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            callingDataGridViewTextBoxColumn.DataPropertyName = "Calling";
            callingDataGridViewTextBoxColumn.HeaderText = "Calling";
            callingDataGridViewTextBoxColumn.MinimumWidth = 6;
            callingDataGridViewTextBoxColumn.Name = "callingDataGridViewTextBoxColumn";
            callingDataGridViewTextBoxColumn.ReadOnly = true;
            callingDataGridViewTextBoxColumn.Width = 84;
            // 
            // gridDataGridViewTextBoxColumn
            // 
            gridDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            gridDataGridViewTextBoxColumn.DataPropertyName = "Grid";
            gridDataGridViewTextBoxColumn.HeaderText = "Grid";
            gridDataGridViewTextBoxColumn.MinimumWidth = 6;
            gridDataGridViewTextBoxColumn.Name = "gridDataGridViewTextBoxColumn";
            gridDataGridViewTextBoxColumn.ReadOnly = true;
            gridDataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.Programmatic;
            gridDataGridViewTextBoxColumn.Width = 66;
            // 
            // dXCCDataGridViewTextBoxColumn
            // 
            dXCCDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dXCCDataGridViewTextBoxColumn.DataPropertyName = "DXCC";
            dXCCDataGridViewTextBoxColumn.HeaderText = "DXCC";
            dXCCDataGridViewTextBoxColumn.MinimumWidth = 6;
            dXCCDataGridViewTextBoxColumn.Name = "dXCCDataGridViewTextBoxColumn";
            dXCCDataGridViewTextBoxColumn.ReadOnly = true;
            dXCCDataGridViewTextBoxColumn.Width = 76;
            // 
            // Country
            // 
            Country.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Country.DataPropertyName = "Country";
            Country.HeaderText = "Country";
            Country.MinimumWidth = 6;
            Country.Name = "Country";
            Country.ReadOnly = true;
            Country.Width = 89;
            // 
            // stateDataGridViewTextBoxColumn
            // 
            stateDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            stateDataGridViewTextBoxColumn.DataPropertyName = "State";
            stateDataGridViewTextBoxColumn.HeaderText = "State";
            stateDataGridViewTextBoxColumn.MinimumWidth = 6;
            stateDataGridViewTextBoxColumn.Name = "stateDataGridViewTextBoxColumn";
            stateDataGridViewTextBoxColumn.ReadOnly = true;
            stateDataGridViewTextBoxColumn.Width = 72;
            // 
            // dbDataGridViewTextBoxColumn
            // 
            dbDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dbDataGridViewTextBoxColumn.DataPropertyName = "Db";
            dbDataGridViewTextBoxColumn.HeaderText = "Db";
            dbDataGridViewTextBoxColumn.MinimumWidth = 6;
            dbDataGridViewTextBoxColumn.Name = "dbDataGridViewTextBoxColumn";
            dbDataGridViewTextBoxColumn.ReadOnly = true;
            dbDataGridViewTextBoxColumn.Width = 58;
            // 
            // ageDataGridViewTextBoxColumn
            // 
            ageDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ageDataGridViewTextBoxColumn.DataPropertyName = "AgeText";
            ageDataGridViewTextBoxColumn.HeaderText = "Age";
            ageDataGridViewTextBoxColumn.MinimumWidth = 6;
            ageDataGridViewTextBoxColumn.Name = "ageDataGridViewTextBoxColumn";
            ageDataGridViewTextBoxColumn.ReadOnly = true;
            ageDataGridViewTextBoxColumn.Width = 65;
            // 
            // callerBindingSource
            // 
            callerBindingSource.DataSource = typeof(Caller);
            // 
            // BigTitle
            // 
            BigTitle.AutoSize = true;
            BigTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            BigTitle.Location = new Point(3, 27);
            BigTitle.Name = "BigTitle";
            BigTitle.Size = new Size(385, 32);
            BigTitle.TabIndex = 0;
            BigTitle.Text = "W7BIK's WSJTX Monitor/Logger";
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
            Conditions.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Conditions.Location = new Point(280, 20);
            Conditions.Margin = new Padding(3, 4, 3, 4);
            Conditions.Name = "Conditions";
            Conditions.Size = new Size(479, 173);
            Conditions.TabIndex = 2;
            Conditions.TabStop = false;
            // 
            // QsoButton
            // 
            QsoButton.Location = new Point(533, 27);
            QsoButton.Margin = new Padding(3, 4, 3, 4);
            QsoButton.Name = "QsoButton";
            QsoButton.Size = new Size(53, 31);
            QsoButton.TabIndex = 3;
            QsoButton.Text = "QSOs";
            QsoButton.UseVisualStyleBackColor = true;
            QsoButton.Click += QsoButton_Click;
            // 
            // SettingsBut
            // 
            SettingsBut.Image = (Image)resources.GetObject("SettingsBut.Image");
            SettingsBut.Location = new Point(493, 27);
            SettingsBut.Margin = new Padding(3, 4, 3, 4);
            SettingsBut.Name = "SettingsBut";
            SettingsBut.Size = new Size(25, 31);
            SettingsBut.TabIndex = 4;
            SettingsBut.UseVisualStyleBackColor = true;
            SettingsBut.Click += SettingsBut_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(41, 21);
            label2.Name = "label2";
            label2.Size = new Size(25, 20);
            label2.TabIndex = 6;
            label2.Text = "10";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(41, 45);
            label3.Name = "label3";
            label3.Size = new Size(25, 20);
            label3.TabIndex = 8;
            label3.Text = "12";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(41, 69);
            label4.Name = "label4";
            label4.Size = new Size(25, 20);
            label4.TabIndex = 10;
            label4.Text = "15";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(41, 93);
            label5.Name = "label5";
            label5.Size = new Size(25, 20);
            label5.TabIndex = 12;
            label5.Text = "17";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(41, 165);
            label6.Name = "label6";
            label6.Size = new Size(25, 20);
            label6.TabIndex = 18;
            label6.Text = "40";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(41, 141);
            label7.Name = "label7";
            label7.Size = new Size(25, 20);
            label7.TabIndex = 16;
            label7.Text = "30";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(41, 117);
            label8.Name = "label8";
            label8.Size = new Size(25, 20);
            label8.TabIndex = 14;
            label8.Text = "20";
            // 
            // ProgressPanel10
            // 
            ProgressPanel10.BackColor = SystemColors.Highlight;
            ProgressPanel10.BorderStyle = BorderStyle.Fixed3D;
            ProgressPanel10.ForeColor = SystemColors.Highlight;
            ProgressPanel10.Location = new Point(71, 23);
            ProgressPanel10.Margin = new Padding(3, 4, 3, 4);
            ProgressPanel10.Name = "ProgressPanel10";
            ProgressPanel10.Size = new Size(0, 16);
            ProgressPanel10.TabIndex = 19;
            // 
            // ProgressPanel15
            // 
            ProgressPanel15.BackColor = SystemColors.Highlight;
            ProgressPanel15.BorderStyle = BorderStyle.Fixed3D;
            ProgressPanel15.ForeColor = SystemColors.Highlight;
            ProgressPanel15.Location = new Point(71, 71);
            ProgressPanel15.Margin = new Padding(3, 4, 3, 4);
            ProgressPanel15.Name = "ProgressPanel15";
            ProgressPanel15.Size = new Size(0, 16);
            ProgressPanel15.TabIndex = 20;
            // 
            // ProgressPanel12
            // 
            ProgressPanel12.BackColor = SystemColors.Highlight;
            ProgressPanel12.BorderStyle = BorderStyle.Fixed3D;
            ProgressPanel12.ForeColor = SystemColors.Highlight;
            ProgressPanel12.Location = new Point(71, 47);
            ProgressPanel12.Margin = new Padding(3, 4, 3, 4);
            ProgressPanel12.Name = "ProgressPanel12";
            ProgressPanel12.Size = new Size(0, 16);
            ProgressPanel12.TabIndex = 20;
            // 
            // ProgressPanel17
            // 
            ProgressPanel17.BackColor = SystemColors.Highlight;
            ProgressPanel17.BorderStyle = BorderStyle.Fixed3D;
            ProgressPanel17.ForeColor = SystemColors.Highlight;
            ProgressPanel17.Location = new Point(71, 95);
            ProgressPanel17.Margin = new Padding(3, 4, 3, 4);
            ProgressPanel17.Name = "ProgressPanel17";
            ProgressPanel17.Size = new Size(0, 16);
            ProgressPanel17.TabIndex = 21;
            // 
            // ProgressPanel20
            // 
            ProgressPanel20.BackColor = SystemColors.Highlight;
            ProgressPanel20.BorderStyle = BorderStyle.Fixed3D;
            ProgressPanel20.ForeColor = SystemColors.Highlight;
            ProgressPanel20.Location = new Point(71, 119);
            ProgressPanel20.Margin = new Padding(3, 4, 3, 4);
            ProgressPanel20.Name = "ProgressPanel20";
            ProgressPanel20.Size = new Size(0, 16);
            ProgressPanel20.TabIndex = 22;
            // 
            // ProgressPanel30
            // 
            ProgressPanel30.BackColor = SystemColors.Highlight;
            ProgressPanel30.BorderStyle = BorderStyle.Fixed3D;
            ProgressPanel30.ForeColor = SystemColors.Highlight;
            ProgressPanel30.Location = new Point(71, 143);
            ProgressPanel30.Margin = new Padding(3, 4, 3, 4);
            ProgressPanel30.Name = "ProgressPanel30";
            ProgressPanel30.Size = new Size(0, 16);
            ProgressPanel30.TabIndex = 23;
            // 
            // ProgressPanel40
            // 
            ProgressPanel40.BackColor = SystemColors.Highlight;
            ProgressPanel40.BorderStyle = BorderStyle.Fixed3D;
            ProgressPanel40.ForeColor = SystemColors.Highlight;
            ProgressPanel40.Location = new Point(71, 167);
            ProgressPanel40.Margin = new Padding(3, 4, 3, 4);
            ProgressPanel40.Name = "ProgressPanel40";
            ProgressPanel40.Size = new Size(0, 16);
            ProgressPanel40.TabIndex = 24;
            // 
            // panel1
            // 
            panel1.Controls.Add(ProgressPanel40);
            panel1.Controls.Add(ProgressPanel30);
            panel1.Controls.Add(ProgressPanel20);
            panel1.Controls.Add(ProgressPanel17);
            panel1.Controls.Add(ProgressPanel12);
            panel1.Controls.Add(ProgressPanel15);
            panel1.Controls.Add(ProgressPanel10);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(Conditions);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 569);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(801, 211);
            panel1.TabIndex = 25;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel2.Controls.Add(Countries);
            panel2.Controls.Add(QsoButton);
            panel2.Controls.Add(SettingsBut);
            panel2.Controls.Add(BigTitle);
            panel2.Location = new Point(41, 1);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(721, 83);
            panel2.TabIndex = 26;
            // 
            // Countries
            // 
            Countries.Location = new Point(597, 27);
            Countries.Margin = new Padding(3, 4, 3, 4);
            Countries.Name = "Countries";
            Countries.Size = new Size(86, 31);
            Countries.TabIndex = 5;
            Countries.Text = "Countries";
            Countries.UseVisualStyleBackColor = true;
            Countries.Click += Countries_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(801, 780);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(CallerListView);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "W7BIK's WSJTX Monitor/Logger";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            Move += Form1_Move;
            Resize += Form1_Resize;
            ((System.ComponentModel.ISupportInitialize)CallerListView).EndInit();
            ((System.ComponentModel.ISupportInitialize)callerBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)callerBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)Conditions).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label BigTitle;
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
        private Button SettingsBut;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Panel ProgressPanel10;
        private Panel ProgressPanel15;
        private Panel ProgressPanel12;
        private Panel ProgressPanel17;
        private Panel ProgressPanel20;
        private Panel ProgressPanel30;
        private Panel ProgressPanel40;
        private Panel panel1;
        private Panel panel2;
        private Button Countries;
    }
}
