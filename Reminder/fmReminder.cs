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
                string[] txtfiles = Directory.GetFiles(folder, "*.wav");
                foreach (string filename in txtfiles)
                {
                    //string[] file = filename.Split('\\');
                    lbFileList.Items.Add(filename);
                }
                lbFileList.SelectedIndex = 0;
            }
            InitTimer();
        }

        private void RunReminder()
        {
            //List<AlarmInfo> allAlaramsThatNeedToBeFired = new List<AlarmInfo>();
            foreach (DataGridViewRow row in grdAlarms.Rows)
            {

                string gridDate = ((DateTime)row.Cells["timeAtDataGridViewTextBoxColumn"].Value).ToString("g");
                string realDate = DateTime.Now.ToString("g"); // "g" is for full date without seconds
                if (gridDate == realDate && (bool)row.Cells["firedDataGridViewCheckBoxColumn"].Value == false)
                {
                    SoundPlayer simpleSound = new SoundPlayer(lbFileList.SelectedItem.ToString());
                    simpleSound.Play();
                    MessageBox.Show("Alarm sound playing for:\r\n" 
                                  + row.Cells["noteDataGridViewTextBoxColumn"].Value.ToString()
                                  + Environment.NewLine + "the sound:" 
                                  + row.Cells["playSoundDataGridViewTextBoxColumn"].Value.ToString()
                                    , "Alarm activated", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    row.Cells["firedDataGridViewCheckBoxColumn"].Value = true;

                    //bool fired = false;
                    //AlarmInfo ai = new AlarmInfo();
                    //ai.Active = Boolean.Parse(row.Cells["activeDataGridViewCheckBoxColumn"].Value.ToString());
                    //ai.Note = row.Cells["noteDataGridViewTextBoxColumn"].Value.ToString();
                    //ai.TimeAt = DateTime.Parse(row.Cells["timeAtDataGridViewTextBoxColumn"].Value.ToString());
                    //ai.PlaySound = row.Cells["playSoundDataGridViewTextBoxColumn"].Value.ToString();
                    //fired = Boolean.Parse(row.Cells["firedDataGridViewCheckBoxColumn"].Value.ToString());     //Boolean.TryParse(row.Cells["Fired"].Value.ToString(), out fired);
                    //ai.Fired = fired;
                    //allAlaramsThatNeedToBeFired.Add(ai);
                }
                var ddd = DateTime.Parse(gridDate);
                var dfffdd = DateTime.Parse(realDate);
                if (DateTime.Parse(gridDate) < DateTime.Parse(realDate) && (bool)row.Cells["firedDataGridViewCheckBoxColumn"].Value == false)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
                
            }
            //foreach (var item in allAlaramsThatNeedToBeFired)
            //{
            //    if (File.Exists(item.PlaySound))
            //    {
                    
                    
            //        item.Fired = true;
            //        grdAlarms.Refresh();
                    
            //    }
            //    else
            //    {
            //        MessageBox.Show("Alarm not activated because the file: " + item.PlaySound + " does not exist!"
            //                        , "Greška!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        item.Fired = false;
            //    }
            //}
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            SoundPlayer simpleSound = new SoundPlayer(lbFileList.SelectedItem.ToString());
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
            ofd.ShowDialog();
            Properties.Settings.Default.SoundFiles = ofd.SelectedPath;
            Properties.Settings.Default.Save();
            //Reminder.Properties.Settings.Default.SoundFiles = ofd.SelectedPath;
            string folder = Properties.Settings.Default.SoundFiles;
            string[] txtfiles = Directory.GetFiles(folder, "*.wav");
            lbFileList.Items.Clear();
            foreach (string filename in txtfiles)
            {
                //string[] file = filename.Split('\\');
                
                lbFileList.Items.Add(filename);
            }
            lbFileList.SelectedIndex = 0;
        }
    }
}
