namespace Login
{
    partial class SettingsGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsGUI));
            this.buttonAccept = new System.Windows.Forms.Button();
            this.buttonAnweden = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBoxConSet = new System.Windows.Forms.GroupBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxSound = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxLieder = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBarLautstaerke = new System.Windows.Forms.TrackBar();
            this.buttonMusicSuche = new System.Windows.Forms.Button();
            this.groupBoxConSet.SuspendLayout();
            this.groupBoxSound.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLautstaerke)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAccept
            // 
            this.buttonAccept.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonAccept.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAccept.BackgroundImage")));
            this.buttonAccept.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAccept.ForeColor = System.Drawing.Color.Snow;
            this.buttonAccept.Location = new System.Drawing.Point(21, 289);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(75, 23);
            this.buttonAccept.TabIndex = 0;
            this.buttonAccept.Text = "Bestätigen";
            this.buttonAccept.UseVisualStyleBackColor = false;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            this.buttonAccept.MouseEnter += new System.EventHandler(this.buttonAccept_MouseEnter);
            this.buttonAccept.MouseLeave += new System.EventHandler(this.buttonAccept_MouseLeave);
            // 
            // buttonAnweden
            // 
            this.buttonAnweden.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonAnweden.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAnweden.BackgroundImage")));
            this.buttonAnweden.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonAnweden.ForeColor = System.Drawing.Color.Snow;
            this.buttonAnweden.Location = new System.Drawing.Point(114, 289);
            this.buttonAnweden.Name = "buttonAnweden";
            this.buttonAnweden.Size = new System.Drawing.Size(75, 23);
            this.buttonAnweden.TabIndex = 1;
            this.buttonAnweden.Text = "Anwenden";
            this.buttonAnweden.UseVisualStyleBackColor = false;
            this.buttonAnweden.Click += new System.EventHandler(this.buttonAnweden_Click);
            this.buttonAnweden.MouseEnter += new System.EventHandler(this.buttonAccept_MouseEnter);
            this.buttonAnweden.MouseLeave += new System.EventHandler(this.buttonAccept_MouseLeave);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.ForeColor = System.Drawing.Color.Snow;
            this.button1.Location = new System.Drawing.Point(204, 289);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Abbruch";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseEnter += new System.EventHandler(this.buttonAccept_MouseEnter);
            this.button1.MouseLeave += new System.EventHandler(this.buttonAccept_MouseLeave);
            // 
            // groupBoxConSet
            // 
            this.groupBoxConSet.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxConSet.Controls.Add(this.textBoxPort);
            this.groupBoxConSet.Controls.Add(this.textBoxIP);
            this.groupBoxConSet.Controls.Add(this.label2);
            this.groupBoxConSet.Controls.Add(this.label1);
            this.groupBoxConSet.ForeColor = System.Drawing.Color.Snow;
            this.groupBoxConSet.Location = new System.Drawing.Point(21, 18);
            this.groupBoxConSet.Name = "groupBoxConSet";
            this.groupBoxConSet.Size = new System.Drawing.Size(262, 88);
            this.groupBoxConSet.TabIndex = 3;
            this.groupBoxConSet.TabStop = false;
            this.groupBoxConSet.Text = "Connection";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(103, 58);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(125, 20);
            this.textBoxPort.TabIndex = 3;
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(103, 32);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(125, 20);
            this.textBoxIP.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Snow;
            this.label2.Location = new System.Drawing.Point(18, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Server-Port:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Snow;
            this.label1.Location = new System.Drawing.Point(18, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server-IP:";
            // 
            // groupBoxSound
            // 
            this.groupBoxSound.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxSound.Controls.Add(this.buttonMusicSuche);
            this.groupBoxSound.Controls.Add(this.label5);
            this.groupBoxSound.Controls.Add(this.comboBoxLieder);
            this.groupBoxSound.Controls.Add(this.label3);
            this.groupBoxSound.Controls.Add(this.trackBarLautstaerke);
            this.groupBoxSound.ForeColor = System.Drawing.Color.Snow;
            this.groupBoxSound.Location = new System.Drawing.Point(21, 112);
            this.groupBoxSound.Name = "groupBoxSound";
            this.groupBoxSound.Size = new System.Drawing.Size(262, 167);
            this.groupBoxSound.TabIndex = 4;
            this.groupBoxSound.TabStop = false;
            this.groupBoxSound.Text = "Sound";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Snow;
            this.label5.Location = new System.Drawing.Point(18, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Musik";
            // 
            // comboBoxLieder
            // 
            this.comboBoxLieder.FormattingEnabled = true;
            this.comboBoxLieder.Location = new System.Drawing.Point(21, 51);
            this.comboBoxLieder.Name = "comboBoxLieder";
            this.comboBoxLieder.Size = new System.Drawing.Size(205, 21);
            this.comboBoxLieder.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Snow;
            this.label3.Location = new System.Drawing.Point(18, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Soundlautstärke";
            // 
            // trackBarLautstaerke
            // 
            this.trackBarLautstaerke.BackColor = System.Drawing.Color.Black;
            this.trackBarLautstaerke.Location = new System.Drawing.Point(6, 110);
            this.trackBarLautstaerke.Name = "trackBarLautstaerke";
            this.trackBarLautstaerke.Size = new System.Drawing.Size(250, 45);
            this.trackBarLautstaerke.TabIndex = 0;
            // 
            // buttonMusicSuche
            // 
            this.buttonMusicSuche.ForeColor = System.Drawing.Color.Black;
            this.buttonMusicSuche.Location = new System.Drawing.Point(232, 51);
            this.buttonMusicSuche.Name = "buttonMusicSuche";
            this.buttonMusicSuche.Size = new System.Drawing.Size(24, 23);
            this.buttonMusicSuche.TabIndex = 6;
            this.buttonMusicSuche.Text = "...";
            this.buttonMusicSuche.UseVisualStyleBackColor = true;
            this.buttonMusicSuche.Click += new System.EventHandler(this.buttonMusicSuche_Click);
            // 
            // SettingsGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(300, 326);
            this.Controls.Add(this.groupBoxSound);
            this.Controls.Add(this.groupBoxConSet);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonAnweden);
            this.Controls.Add(this.buttonAccept);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsGUI";
            this.Text = "SettingsGUI";
            this.TopMost = true;
            this.groupBoxConSet.ResumeLayout(false);
            this.groupBoxConSet.PerformLayout();
            this.groupBoxSound.ResumeLayout(false);
            this.groupBoxSound.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLautstaerke)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Button buttonAnweden;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBoxConSet;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxSound;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxLieder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trackBarLautstaerke;
        private System.Windows.Forms.Button buttonMusicSuche;
    }
}