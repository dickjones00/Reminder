using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Reminder
{

    public partial class fmReminder : Form
    {
        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 6 * 1000;
            timer1.Start();
        }

        public fmReminder()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RunReminder();
        }
        private void fmReminder_Load(object sender, EventArgs e)
        {
            dtpAlarmTime.Format = DateTimePickerFormat.Time;
            dtpAlarmTime.ShowUpDown = true;
            if (Properties.Settings.Default.SoundFiles != "")
            {
                string folder = Properties.Settings.Default.SoundFiles;
                GetWavFiles(folder);
            }
            InitTimer();
        }

        private void RunReminder()
        {
            foreach (DataGridViewRow row in grdAlarms.Rows)
            {
                string gridDate = ((DateTime)row.Cells["timeAtDataGridViewTextBoxColumn"].Value).ToString("g");
                string realDate = DateTime.Now.ToString("g"); // "g" is for full date without seconds
                if (gridDate == realDate && (bool)row.Cells["firedDataGridViewCheckBoxColumn"].Value == false)
                {
                    SoundPlayer simpleSound = new SoundPlayer(lbFileList.SelectedItem.ToString());
                    simpleSound.Play();
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                    row.Cells["firedDataGridViewCheckBoxColumn"].Value = true;
                    row.Cells["activeDataGridViewCheckBoxColumn"].Value = false;
                    row.Cells["noteDataGridViewTextBoxColumn"].Value = row.Cells["noteDataGridViewTextBoxColumn"].Value + " - alarm fired";
                    MessageBox.Show("Alarm sound playing for:\r\n" 
                                  + row.Cells["noteDataGridViewTextBoxColumn"].Value.ToString()
                                  + Environment.NewLine + "the sound:" 
                                  + row.Cells["playSoundDataGridViewTextBoxColumn"].Value.ToString()
                                    , "Alarm activated", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                var ddd = DateTime.Parse(gridDate);
                var dfffdd = DateTime.Parse(realDate);
                if (DateTime.Parse(gridDate) < DateTime.Parse(realDate) && (bool)row.Cells["firedDataGridViewCheckBoxColumn"].Value == false)
                {
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                    row.Cells["activeDataGridViewCheckBoxColumn"].Value = false;
                    row.Cells["noteDataGridViewTextBoxColumn"].Value = row.Cells["noteDataGridViewTextBoxColumn"].Value + "- alarm not fired";
                }
                alarmInfoBindingSource = (BindingSource)grdAlarms.DataSource;
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            SoundPlayer simpleSound = new SoundPlayer(lbFileList.SelectedValue.ToString());
            simpleSound.Play();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string wav = "";
            if (txtWhat.Text != "")
            {
                if (lbFileList.SelectedItem != null)
                {
                    wav = lbFileList.SelectedItem.ToString();
                }
                AlarmInfo aiAdd = new AlarmInfo();
                aiAdd.Active = true;
                aiAdd.Note = txtWhat.Text;
                aiAdd.TimeAt = dtpAlarmTime.Value;
                aiAdd.PlaySound = lbFileList.SelectedItem.ToString();

                alarmInfoBindingSource.Add(aiAdd);
                grdAlarms.DataSource = alarmInfoBindingSource;
                grdAlarms.Refresh();
                //grdAlarms.Rows.Add(bool.TrueString, txtWhat.Text, dtpAlarmTime.Value.ToShortTimeString(), wav, bool.FalseString);
            }
            else
            {
                MessageBox.Show("Enter something");
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            nfyStart.Visible = true;
            nfyStart.ShowBalloonTip(500);
            this.Hide();
            
        }

        private void nfyStart_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            nfyStart.Visible = false;
            this.Show();
        }

        private void btnSoundFilesPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog ofd = new FolderBrowserDialog();

            //var tt = ofd.Container.Components;
            
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.SoundFiles = ofd.SelectedPath;
                Properties.Settings.Default.Save();
                string folder = Properties.Settings.Default.SoundFiles;
                GetWavFiles(folder);
                
            }
            else if (string.IsNullOrEmpty(Properties.Settings.Default.SoundFiles))
            {
                lblFolder.Text = "Folder not selected!";
                lblFolder.ForeColor = Color.LightCoral;
            }
        }

        private void GetWavFiles(string folder)
        {
            Dictionary<string, string> ff = new Dictionary<string, string>();
            lblFolder.ForeColor = Color.Blue;

            DirectoryInfo dinfo = new DirectoryInfo(folder);
            FileInfo[] files = dinfo.GetFiles("*.wav");
            foreach (FileInfo filename in files)
            {
                ff.Add(filename.Name, filename.FullName);
            }

            lbFileList.DataSource = new BindingSource(ff, null);
            lbFileList.DisplayMember = "Key";
            lbFileList.ValueMember = "Value";
            var sss = lbFileList.DataBindings;
            lbFileList.Refresh();

            if (files.Count() > 0)
            {
                lbFileList.SelectedIndex = 0;
            }
            lblFolder.Text = Properties.Settings.Default.SoundFiles;
            lblSettings.Text = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath;
        }

        private void lblSettings_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lblSettings.Text);
            MessageBox.Show("Filepath copied to clipboard.");
        }
    }
}
