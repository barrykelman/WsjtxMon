namespace WsjtxMon
{
    partial class SettingsForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            CallsignTxt = new TextBox();
            AdifPathTxt = new TextBox();
            QrzKeyTxt = new TextBox();
            QrzPassTxt = new TextBox();
            QrzUserTxt = new TextBox();
            TqslDirTxt = new TextBox();
            TqslPassTxt = new TextBox();
            TqslUserTxt = new TextBox();
            AdifPathBut = new Button();
            TqslDirBut = new Button();
            SaveBut = new Button();
            CancelBut = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(42, 19);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 0;
            label1.Text = "Callsign";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(42, 48);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 1;
            label2.Text = "Adif Path";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(42, 77);
            label3.Name = "label3";
            label3.Size = new Size(73, 15);
            label3.TabIndex = 2;
            label3.Text = "QRZ API Key";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(42, 106);
            label4.Name = "label4";
            label4.Size = new Size(83, 15);
            label4.TabIndex = 3;
            label4.Text = "QRZ Password";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(42, 135);
            label5.Name = "label5";
            label5.Size = new Size(56, 15);
            label5.TabIndex = 4;
            label5.Text = "QRZ User";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(42, 164);
            label6.Name = "label6";
            label6.Size = new Size(78, 15);
            label6.TabIndex = 5;
            label6.Text = "Tqsl Directory";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(42, 193);
            label7.Name = "label7";
            label7.Size = new Size(80, 15);
            label7.TabIndex = 6;
            label7.Text = "Tqsl Password";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(42, 222);
            label8.Name = "label8";
            label8.Size = new Size(53, 15);
            label8.TabIndex = 7;
            label8.Text = "Tqsl User";
            // 
            // CallsignTxt
            // 
            CallsignTxt.Location = new Point(154, 15);
            CallsignTxt.Name = "CallsignTxt";
            CallsignTxt.Size = new Size(230, 23);
            CallsignTxt.TabIndex = 8;
            CallsignTxt.TextChanged += Settings_TextChanged;
            // 
            // AdifPathTxt
            // 
            AdifPathTxt.Location = new Point(154, 44);
            AdifPathTxt.Name = "AdifPathTxt";
            AdifPathTxt.Size = new Size(230, 23);
            AdifPathTxt.TabIndex = 9;
            AdifPathTxt.TextChanged += Settings_TextChanged;
            // 
            // QrzKeyTxt
            // 
            QrzKeyTxt.Location = new Point(154, 73);
            QrzKeyTxt.Name = "QrzKeyTxt";
            QrzKeyTxt.Size = new Size(230, 23);
            QrzKeyTxt.TabIndex = 10;
            QrzKeyTxt.TextChanged += Settings_TextChanged;
            // 
            // QrzPassTxt
            // 
            QrzPassTxt.Location = new Point(154, 102);
            QrzPassTxt.Name = "QrzPassTxt";
            QrzPassTxt.Size = new Size(230, 23);
            QrzPassTxt.TabIndex = 11;
            QrzPassTxt.TextChanged += Settings_TextChanged;
            // 
            // QrzUserTxt
            // 
            QrzUserTxt.Location = new Point(154, 131);
            QrzUserTxt.Name = "QrzUserTxt";
            QrzUserTxt.Size = new Size(230, 23);
            QrzUserTxt.TabIndex = 12;
            QrzUserTxt.TextChanged += Settings_TextChanged;
            // 
            // TqslDirTxt
            // 
            TqslDirTxt.Location = new Point(154, 160);
            TqslDirTxt.Name = "TqslDirTxt";
            TqslDirTxt.Size = new Size(230, 23);
            TqslDirTxt.TabIndex = 13;
            TqslDirTxt.TextChanged += Settings_TextChanged;
            // 
            // TqslPassTxt
            // 
            TqslPassTxt.Location = new Point(154, 189);
            TqslPassTxt.Name = "TqslPassTxt";
            TqslPassTxt.Size = new Size(230, 23);
            TqslPassTxt.TabIndex = 14;
            TqslPassTxt.TextChanged += Settings_TextChanged;
            // 
            // TqslUserTxt
            // 
            TqslUserTxt.Location = new Point(154, 218);
            TqslUserTxt.Name = "TqslUserTxt";
            TqslUserTxt.Size = new Size(230, 23);
            TqslUserTxt.TabIndex = 15;
            TqslUserTxt.TextChanged += Settings_TextChanged;
            // 
            // AdifPathBut
            // 
            AdifPathBut.Location = new Point(394, 44);
            AdifPathBut.Name = "AdifPathBut";
            AdifPathBut.Size = new Size(29, 23);
            AdifPathBut.TabIndex = 16;
            AdifPathBut.Text = "...";
            AdifPathBut.UseVisualStyleBackColor = true;
            AdifPathBut.Click += AdifPathBut_Click;
            // 
            // TqslDirBut
            // 
            TqslDirBut.Location = new Point(394, 160);
            TqslDirBut.Name = "TqslDirBut";
            TqslDirBut.Size = new Size(29, 23);
            TqslDirBut.TabIndex = 17;
            TqslDirBut.Text = "...";
            TqslDirBut.UseVisualStyleBackColor = true;
            TqslDirBut.Click += TqslDirBut_Click;
            // 
            // SaveBut
            // 
            SaveBut.Enabled = false;
            SaveBut.Location = new Point(156, 260);
            SaveBut.Name = "SaveBut";
            SaveBut.Size = new Size(75, 23);
            SaveBut.TabIndex = 18;
            SaveBut.Text = "Save";
            SaveBut.UseVisualStyleBackColor = true;
            SaveBut.Click += SaveBut_Click;
            // 
            // CancelBut
            // 
            CancelBut.Location = new Point(250, 260);
            CancelBut.Name = "CancelBut";
            CancelBut.Size = new Size(75, 23);
            CancelBut.TabIndex = 19;
            CancelBut.Text = "Cancel";
            CancelBut.UseVisualStyleBackColor = true;
            CancelBut.Click += CancelBut_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(481, 292);
            Controls.Add(CancelBut);
            Controls.Add(SaveBut);
            Controls.Add(TqslDirBut);
            Controls.Add(AdifPathBut);
            Controls.Add(TqslUserTxt);
            Controls.Add(TqslPassTxt);
            Controls.Add(TqslDirTxt);
            Controls.Add(QrzUserTxt);
            Controls.Add(QrzPassTxt);
            Controls.Add(QrzKeyTxt);
            Controls.Add(AdifPathTxt);
            Controls.Add(CallsignTxt);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "SettingsForm";
            Text = "WsjtxMon Settings";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox CallsignTxt;
        private TextBox AdifPathTxt;
        private TextBox QrzKeyTxt;
        private TextBox QrzPassTxt;
        private TextBox QrzUserTxt;
        private TextBox TqslDirTxt;
        private TextBox TqslPassTxt;
        private TextBox TqslUserTxt;
        private Button AdifPathBut;
        private Button TqslDirBut;
        private Button SaveBut;
        private Button CancelBut;
    }
}