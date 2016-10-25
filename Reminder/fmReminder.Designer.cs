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
            this.lblWhat = new System.Windows.Forms.Label();
            this.lblWhen = new System.Windows.Forms.Label();
            this.lblSound = new System.Windows.Forms.Label();
            this.lbFileList = new System.Windows.Forms.ListBox();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grdAlarms = new System.Windows.Forms.DataGridView();
            this.btnStart = new System.Windows.Forms.Button();
            this.nfyStart = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dtpAlarmTime = new System.Windows.Forms.DateTimePicker();
            this.btnSoundFilesPath = new System.Windows.Forms.Button();
            this.lblFolder = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSettings = new System.Windows.Forms.Label();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activeDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.noteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeAtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playSoundDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.alarmInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grdAlarms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alarmInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtWhat
            // 
            this.txtWhat.Location = new System.Drawing.Point(57, 12);
            this.txtWhat.Multiline = true;
            this.txtWhat.Name = "txtWhat";
            this.txtWhat.Size = new System.Drawing.Size(215, 90);
            this.txtWhat.TabIndex = 0;
            // 
            // lblWhat
            // 
            this.lblWhat.AutoSize = true;
            this.lblWhat.Location = new System.Drawing.Point(12, 15);
            this.lblWhat.Name = "lblWhat";
            this.lblWhat.Size = new System.Drawing.Size(39, 13);
            this.lblWhat.TabIndex = 1;
            this.lblWhat.Text = "What?";
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
            this.lbFileList.FormattingEnabled = true;
            this.lbFileList.Location = new System.Drawing.Point(12, 242);
            this.lbFileList.Name = "lbFileList";
            this.lbFileList.Size = new System.Drawing.Size(260, 186);
            this.lbFileList.TabIndex = 2;
            // 
            // btnPlay
            // 
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
            this.grdAlarms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAlarms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.activeDataGridViewCheckBoxColumn,
            this.noteDataGridViewTextBoxColumn,
            this.timeAtDataGridViewTextBoxColumn,
            this.playSoundDataGridViewTextBoxColumn,
            this.firedDataGridViewCheckBoxColumn});
            this.grdAlarms.DataSource = this.alarmInfoBindingSource;
            this.grdAlarms.Location = new System.Drawing.Point(278, 12);
            this.grdAlarms.Name = "grdAlarms";
            this.grdAlarms.ReadOnly = true;
            this.grdAlarms.RowHeadersVisible = false;
            this.grdAlarms.Size = new System.Drawing.Size(942, 442);
            this.grdAlarms.TabIndex = 4;
            // 
            // btnStart
            // 
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select sound:";
            // 
            // lblSettings
            // 
            this.lblSettings.Location = new System.Drawing.Point(12, 134);
            this.lblSettings.Name = "lblSettings";
            this.lblSettings.Size = new System.Drawing.Size(260, 45);
            this.lblSettings.TabIndex = 1;
            this.lblSettings.Text = "Choose folder";
            this.lblSettings.Click += new System.EventHandler(this.lblSettings_Click);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 41;
            // 
            // activeDataGridViewCheckBoxColumn
            // 
            this.activeDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.activeDataGridViewCheckBoxColumn.DataPropertyName = "Active";
            this.activeDataGridViewCheckBoxColumn.HeaderText = "Active";
            this.activeDataGridViewCheckBoxColumn.Name = "activeDataGridViewCheckBoxColumn";
            this.activeDataGridViewCheckBoxColumn.ReadOnly = true;
            this.activeDataGridViewCheckBoxColumn.Width = 43;
            // 
            // noteDataGridViewTextBoxColumn
            // 
            this.noteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.noteDataGridViewTextBoxColumn.DataPropertyName = "Note";
            this.noteDataGridViewTextBoxColumn.HeaderText = "Note";
            this.noteDataGridViewTextBoxColumn.Name = "noteDataGridViewTextBoxColumn";
            this.noteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // timeAtDataGridViewTextBoxColumn
            // 
            this.timeAtDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.timeAtDataGridViewTextBoxColumn.DataPropertyName = "TimeAt";
            this.timeAtDataGridViewTextBoxColumn.HeaderText = "TimeAt";
            this.timeAtDataGridViewTextBoxColumn.Name = "timeAtDataGridViewTextBoxColumn";
            this.timeAtDataGridViewTextBoxColumn.ReadOnly = true;
            this.timeAtDataGridViewTextBoxColumn.Width = 65;
            // 
            // playSoundDataGridViewTextBoxColumn
            // 
            this.playSoundDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.playSoundDataGridViewTextBoxColumn.DataPropertyName = "PlaySound";
            this.playSoundDataGridViewTextBoxColumn.HeaderText = "PlaySound";
            this.playSoundDataGridViewTextBoxColumn.Name = "playSoundDataGridViewTextBoxColumn";
            this.playSoundDataGridViewTextBoxColumn.ReadOnly = true;
            this.playSoundDataGridViewTextBoxColumn.Width = 83;
            // 
            // firedDataGridViewCheckBoxColumn
            // 
            this.firedDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.firedDataGridViewCheckBoxColumn.DataPropertyName = "Fired";
            this.firedDataGridViewCheckBoxColumn.HeaderText = "Fired";
            this.firedDataGridViewCheckBoxColumn.Name = "firedDataGridViewCheckBoxColumn";
            this.firedDataGridViewCheckBoxColumn.ReadOnly = true;
            this.firedDataGridViewCheckBoxColumn.Width = 36;
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
            this.Controls.Add(this.btnSoundFilesPath);
            this.Controls.Add(this.dtpAlarmTime);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.grdAlarms);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.lbFileList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblSettings);
            this.Controls.Add(this.lblFolder);
            this.Controls.Add(this.lblSound);
            this.Controls.Add(this.lblWhen);
            this.Controls.Add(this.lblWhat);
            this.Controls.Add(this.txtWhat);
            this.Name = "fmReminder";
            this.Text = "Reminder";
            this.Load += new System.EventHandler(this.fmReminder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdAlarms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alarmInfoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtWhat;
        private System.Windows.Forms.Label lblWhat;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn activeDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeAtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn playSoundDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn firedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.BindingSource alarmInfoBindingSource;
        private System.Windows.Forms.Label lblFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSettings;
    }
}

