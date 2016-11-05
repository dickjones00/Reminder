namespace Reminder
{
    partial class fmReminder
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmReminder));
            this.txtWhat = new System.Windows.Forms.TextBox();
            this.lblWhen = new System.Windows.Forms.Label();
            this.lblSound = new System.Windows.Forms.Label();
            this.lbFileList = new System.Windows.Forms.ListBox();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grdAlarms = new System.Windows.Forms.DataGridView();
            this.cmsGridRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnStart = new System.Windows.Forms.Button();
            this.nfyStart = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dtpAlarmTime = new System.Windows.Forms.DateTimePicker();
            this.btnSoundFilesPath = new System.Windows.Forms.Button();
            this.lblFolder = new System.Windows.Forms.Label();
            this.lblSettings = new System.Windows.Forms.Label();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activeDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.noteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeAtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playSoundDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.chkSelectSound = new System.Windows.Forms.CheckBox();
            this.chkSayWhat = new System.Windows.Forms.CheckBox();
            this.idDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activeDataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.noteDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeAtDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playSoundDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firedDataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.alarmInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grdAlarms)).BeginInit();
            this.cmsGridRightClick.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alarmInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtWhat
            // 
            this.txtWhat.Location = new System.Drawing.Point(12, 38);
            this.txtWhat.Multiline = true;
            this.txtWhat.Name = "txtWhat";
            this.txtWhat.Size = new System.Drawing.Size(260, 64);
            this.txtWhat.TabIndex = 0;
            // 
            // lblWhen
            // 
            this.lblWhen.AutoSize = true;
            this.lblWhen.Location = new System.Drawing.Point(12, 113);
            this.lblWhen.Name = "lblWhen";
            this.lblWhen.Size = new System.Drawing.Size(42, 13);
            this.lblWhen.TabIndex = 1;
            this.lblWhen.Text = "When?";
            // 
            // lblSound
            // 
            this.lblSound.AutoSize = true;
            this.lblSound.Location = new System.Drawing.Point(12, 187);
            this.lblSound.Name = "lblSound";
            this.lblSound.Size = new System.Drawing.Size(168, 13);
            this.lblSound.TabIndex = 1;
            this.lblSound.Text = "Current folder with sounds (*.wav):";
            // 
            // lbFileList
            // 
            this.lbFileList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbFileList.FormattingEnabled = true;
            this.lbFileList.Location = new System.Drawing.Point(12, 242);
            this.lbFileList.Name = "lbFileList";
            this.lbFileList.Size = new System.Drawing.Size(260, 186);
            this.lbFileList.TabIndex = 2;
            // 
            // btnPlay
            // 
            this.btnPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPlay.Location = new System.Drawing.Point(12, 430);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(100, 23);
            this.btnPlay.TabIndex = 3;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(191, 108);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grdAlarms
            // 
            this.grdAlarms.AllowUserToAddRows = false;
            this.grdAlarms.AllowUserToDeleteRows = false;
            this.grdAlarms.AllowUserToResizeRows = false;
            this.grdAlarms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAlarms.AutoGenerateColumns = false;
            this.grdAlarms.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdAlarms.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grdAlarms.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.grdAlarms.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grdAlarms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAlarms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn1,
            this.activeDataGridViewCheckBoxColumn1,
            this.noteDataGridViewTextBoxColumn1,
            this.timeAtDataGridViewTextBoxColumn1,
            this.playSoundDataGridViewTextBoxColumn1,
            this.firedDataGridViewCheckBoxColumn1});
            this.grdAlarms.ContextMenuStrip = this.cmsGridRightClick;
            this.grdAlarms.DataSource = this.alarmInfoBindingSource;
            this.grdAlarms.Location = new System.Drawing.Point(278, 12);
            this.grdAlarms.Name = "grdAlarms";
            this.grdAlarms.RowHeadersVisible = false;
            this.grdAlarms.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.grdAlarms.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.LightGreen;
            this.grdAlarms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdAlarms.Size = new System.Drawing.Size(942, 442);
            this.grdAlarms.TabIndex = 4;
            this.grdAlarms.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdAlarms_MouseDown);
            // 
            // cmsGridRightClick
            // 
            this.cmsGridRightClick.DropShadowEnabled = false;
            this.cmsGridRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.cmsGridRightClick.Name = "cmsGridRightClick";
            this.cmsGridRightClick.ShowItemToolTips = false;
            this.cmsGridRightClick.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStart.Location = new System.Drawing.Point(172, 430);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 23);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Hide This window";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // nfyStart
            // 
            this.nfyStart.BalloonTipText = "Infotext";
            this.nfyStart.BalloonTipTitle = "Info";
            this.nfyStart.Icon = ((System.Drawing.Icon)(resources.GetObject("nfyStart.Icon")));
            this.nfyStart.Text = "Started";
            this.nfyStart.Visible = true;
            this.nfyStart.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.nfyStart_MouseDoubleClick);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dtpAlarmTime
            // 
            this.dtpAlarmTime.Location = new System.Drawing.Point(57, 109);
            this.dtpAlarmTime.Name = "dtpAlarmTime";
            this.dtpAlarmTime.Size = new System.Drawing.Size(128, 20);
            this.dtpAlarmTime.TabIndex = 6;
            // 
            // btnSoundFilesPath
            // 
            this.btnSoundFilesPath.Location = new System.Drawing.Point(191, 182);
            this.btnSoundFilesPath.Name = "btnSoundFilesPath";
            this.btnSoundFilesPath.Size = new System.Drawing.Size(81, 23);
            this.btnSoundFilesPath.TabIndex = 7;
            this.btnSoundFilesPath.Text = "Change folder";
            this.btnSoundFilesPath.UseVisualStyleBackColor = true;
            this.btnSoundFilesPath.Click += new System.EventHandler(this.btnSoundFilesPath_Click);
            // 
            // lblFolder
            // 
            this.lblFolder.AutoSize = true;
            this.lblFolder.Location = new System.Drawing.Point(12, 207);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(72, 13);
            this.lblFolder.TabIndex = 1;
            this.lblFolder.Text = "Choose folder";
            // 
            // lblSettings
            // 
            this.lblSettings.Location = new System.Drawing.Point(12, 134);
            this.lblSettings.Name = "lblSettings";
            this.lblSettings.Size = new System.Drawing.Size(260, 45);
            this.lblSettings.TabIndex = 1;
            this.lblSettings.Text = "Choose folder";
            this.lblSettings.Visible = false;
            this.lblSettings.Click += new System.EventHandler(this.lblSettings_Click);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // activeDataGridViewCheckBoxColumn
            // 
            this.activeDataGridViewCheckBoxColumn.HeaderText = "Active";
            this.activeDataGridViewCheckBoxColumn.Name = "activeDataGridViewCheckBoxColumn";
            this.activeDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // noteDataGridViewTextBoxColumn
            // 
            this.noteDataGridViewTextBoxColumn.HeaderText = "Note";
            this.noteDataGridViewTextBoxColumn.Name = "noteDataGridViewTextBoxColumn";
            this.noteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // timeAtDataGridViewTextBoxColumn
            // 
            this.timeAtDataGridViewTextBoxColumn.HeaderText = "TimeAt";
            this.timeAtDataGridViewTextBoxColumn.Name = "timeAtDataGridViewTextBoxColumn";
            this.timeAtDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // playSoundDataGridViewTextBoxColumn
            // 
            this.playSoundDataGridViewTextBoxColumn.HeaderText = "Play Sound";
            this.playSoundDataGridViewTextBoxColumn.Name = "playSoundDataGridViewTextBoxColumn";
            this.playSoundDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // firedDataGridViewCheckBoxColumn
            // 
            this.firedDataGridViewCheckBoxColumn.HeaderText = "Fired";
            this.firedDataGridViewCheckBoxColumn.Name = "firedDataGridViewCheckBoxColumn";
            this.firedDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // chkSelectSound
            // 
            this.chkSelectSound.AutoSize = true;
            this.chkSelectSound.Location = new System.Drawing.Point(12, 223);
            this.chkSelectSound.Name = "chkSelectSound";
            this.chkSelectSound.Size = new System.Drawing.Size(91, 17);
            this.chkSelectSound.TabIndex = 8;
            this.chkSelectSound.Text = "Select sound:";
            this.chkSelectSound.UseVisualStyleBackColor = true;
            this.chkSelectSound.CheckedChanged += new System.EventHandler(this.chkSelectSound_CheckedChanged);
            // 
            // chkSayWhat
            // 
            this.chkSayWhat.AutoSize = true;
            this.chkSayWhat.Checked = true;
            this.chkSayWhat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSayWhat.Location = new System.Drawing.Point(12, 15);
            this.chkSayWhat.Name = "chkSayWhat";
            this.chkSayWhat.Size = new System.Drawing.Size(163, 17);
            this.chkSayWhat.TabIndex = 8;
            this.chkSayWhat.Text = "Say what? (in english please)";
            this.chkSayWhat.UseVisualStyleBackColor = true;
            this.chkSayWhat.CheckedChanged += new System.EventHandler(this.chkSayWhat_CheckedChanged);
            // 
            // idDataGridViewTextBoxColumn1
            // 
            this.idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn1.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            this.idDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // activeDataGridViewCheckBoxColumn1
            // 
            this.activeDataGridViewCheckBoxColumn1.DataPropertyName = "Active";
            this.activeDataGridViewCheckBoxColumn1.HeaderText = "Active";
            this.activeDataGridViewCheckBoxColumn1.Name = "activeDataGridViewCheckBoxColumn1";
            this.activeDataGridViewCheckBoxColumn1.ReadOnly = true;
            // 
            // noteDataGridViewTextBoxColumn1
            // 
            this.noteDataGridViewTextBoxColumn1.DataPropertyName = "Note";
            this.noteDataGridViewTextBoxColumn1.HeaderText = "Note";
            this.noteDataGridViewTextBoxColumn1.Name = "noteDataGridViewTextBoxColumn1";
            this.noteDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // timeAtDataGridViewTextBoxColumn1
            // 
            this.timeAtDataGridViewTextBoxColumn1.DataPropertyName = "TimeAt";
            this.timeAtDataGridViewTextBoxColumn1.HeaderText = "TimeAt";
            this.timeAtDataGridViewTextBoxColumn1.Name = "timeAtDataGridViewTextBoxColumn1";
            this.timeAtDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // playSoundDataGridViewTextBoxColumn1
            // 
            this.playSoundDataGridViewTextBoxColumn1.DataPropertyName = "PlaySound";
            this.playSoundDataGridViewTextBoxColumn1.HeaderText = "PlaySound";
            this.playSoundDataGridViewTextBoxColumn1.Name = "playSoundDataGridViewTextBoxColumn1";
            this.playSoundDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // firedDataGridViewCheckBoxColumn1
            // 
            this.firedDataGridViewCheckBoxColumn1.DataPropertyName = "Fired";
            this.firedDataGridViewCheckBoxColumn1.HeaderText = "Fired";
            this.firedDataGridViewCheckBoxColumn1.Name = "firedDataGridViewCheckBoxColumn1";
            this.firedDataGridViewCheckBoxColumn1.ReadOnly = true;
            // 
            // alarmInfoBindingSource
            // 
            this.alarmInfoBindingSource.DataSource = typeof(Reminder.AlarmInfo);
            // 
            // fmReminder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 462);
            this.Controls.Add(this.chkSayWhat);
            this.Controls.Add(this.chkSelectSound);
            this.Controls.Add(this.btnSoundFilesPath);
            this.Controls.Add(this.dtpAlarmTime);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.grdAlarms);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.lbFileList);
            this.Controls.Add(this.lblSettings);
            this.Controls.Add(this.lblFolder);
            this.Controls.Add(this.lblSound);
            this.Controls.Add(this.lblWhen);
            this.Controls.Add(this.txtWhat);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fmReminder";
            this.Text = "Reminder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fmReminder_FormClosing);
            this.Load += new System.EventHandler(this.fmReminder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdAlarms)).EndInit();
            this.cmsGridRightClick.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.alarmInfoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtWhat;
        private System.Windows.Forms.Label lblWhen;
        private System.Windows.Forms.Label lblSound;
        private System.Windows.Forms.ListBox lbFileList;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView grdAlarms;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.NotifyIcon nfyStart;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DateTimePicker dtpAlarmTime;
        private System.Windows.Forms.Button btnSoundFilesPath;
        private System.Windows.Forms.Label lblFolder;
        private System.Windows.Forms.Label lblSettings;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn activeDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeAtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn playSoundDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn firedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.BindingSource alarmInfoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn activeDataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn noteDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeAtDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn playSoundDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn firedDataGridViewCheckBoxColumn1;
        private System.Windows.Forms.CheckBox chkSelectSound;
        private System.Windows.Forms.CheckBox chkSayWhat;
        private System.Windows.Forms.ContextMenuStrip cmsGridRightClick;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}

