using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using System.Configuration;
using WMPLib;
using System.Speech.Synthesis;

namespace Reminder
{
    public partial class fmReminder : Form
    {
        DataTable tbl = new DataTable();
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
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteRow_Click);
            dtpAlarmTime.Format = DateTimePickerFormat.Time;
            dtpAlarmTime.ShowUpDown = true;

            if ((bool)Properties.Settings.Default.ReadText)
            {
                chkSayWhat.Checked = true;
                chkSelectSound.Checked = false;
            }
            else
            {
                chkSayWhat.Checked = false;
                chkSelectSound.Checked = true;
            }
            if (Properties.Settings.Default.SoundFiles != "")
            {
                string folder = Properties.Settings.Default.SoundFiles;
                GetWavFiles(folder);
            }
            InitTimer();
            if (File.Exists("xml.xml"))
            {
                try
                {
                    tbl.TableName = "AlarmInfo";
                    tbl.ReadXml("xml.xml");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                AlarmInfo ai = new AlarmInfo();
                try
                {
                    tbl.Columns.Add("id", typeof(string));
                    tbl.Columns.Add("active", typeof(bool));
                    tbl.Columns.Add("note", typeof(string));
                    tbl.Columns.Add("timeAt", typeof(DateTime));
                    tbl.Columns.Add("playSound", typeof(string));
                    tbl.Columns.Add("fired", typeof(bool));
                }
                catch (Exception ec)
                {
                    throw new Exception(ec.Message);
                }

            }
            foreach (DataGridViewColumn column in grdAlarms.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
                if (column.DataPropertyName == "Note")
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            grdAlarms.DataSource = tbl;

            ColorDataGridView();
        }

        private void ColorDataGridView()
        {
            foreach (DataGridViewRow row in grdAlarms.Rows)
            {
                var idDG = row.Cells["idDataGridViewTextBoxColumn1"].EditedFormattedValue.ToString();
                var activeDG = (bool)row.Cells["activeDataGridViewCheckBoxColumn1"].EditedFormattedValue;
                var noteDG = row.Cells["noteDataGridViewTextBoxColumn1"].EditedFormattedValue.ToString();
                var timeAtDG = row.Cells["timeAtDataGridViewTextBoxColumn1"].EditedFormattedValue.ToString();
                var playSoundDG = row.Cells["playSoundDataGridViewTextBoxColumn1"].EditedFormattedValue.ToString();
                var firedDG = (bool)row.Cells["firedDataGridViewCheckBoxColumn1"].EditedFormattedValue;

                string gridDate = timeAtDG;

                string realDate = DateTime.Now.ToString("g"); // "g" is for full date without seconds
                if (((DateTime.Parse(timeAtDG) < DateTime.Parse(realDate)) && (bool)activeDG == true) || (bool)activeDG == false && (bool)firedDG == false)
                {
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                    row.Cells["activeDataGridViewCheckBoxColumn1"].Value = false;
                }
                if ((DateTime.Parse(timeAtDG) < DateTime.Parse(realDate)) && (bool)firedDG == true)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }
        }

        private void RunReminder()
        {
            if (grdAlarms.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in grdAlarms.Rows)
                {
                    string str = row.Cells["timeAtDataGridViewTextBoxColumn1"].Value.ToString();
                    string gridDate = str.Substring(0, str.Length - 3);

                    string realDate = DateTime.Now.ToString("g"); // "g" is for full date without seconds

                    if (gridDate == realDate && (bool)row.Cells["activeDataGridViewCheckBoxColumn1"].EditedFormattedValue == true)
                    {
                        WindowsMediaPlayer wplayer = new WindowsMediaPlayer();
                        if (!Properties.Settings.Default.ReadText)
                        {
                            if (lbFileList.SelectedIndex != -1)
                                wplayer.URL = lbFileList.SelectedValue.ToString();
                            wplayer.controls.play();
                        }
                        else
                        {
                            SpeechSynthesizer rdr = new SpeechSynthesizer();
                            rdr.SpeakAsync(row.Cells["noteDataGridViewTextBoxColumn1"].Value.ToString());
                        }

                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                        row.Cells["firedDataGridViewCheckBoxColumn1"].Value = true;
                        row.Cells["activeDataGridViewCheckBoxColumn1"].Value = false;
                        var theMessage = "Alarm sound playing for:"
                                         + Environment.NewLine + row.Cells["noteDataGridViewTextBoxColumn1"].Value.ToString()
                                         + Environment.NewLine + "and the sound is:"
                                         + Environment.NewLine + row.Cells["playSoundDataGridViewTextBoxColumn1"].Value.ToString();
                        if (Properties.Settings.Default.ReadText)
                        {
                            theMessage = "Reading the note:\"" + row.Cells["noteDataGridViewTextBoxColumn1"].Value.ToString() + "\"";
                        }

                        CustomMessageBox.MyMessageBox.ShowBox(theMessage, "Alarm activated"); // OK button returns string "1"

                        //MessageBox.Show("Alarm sound playing for:\r\n"
                        //              + row.Cells["noteDataGridViewTextBoxColumn1"].Value.ToString()
                        //              + Environment.NewLine + "the sound:"
                        //              + row.Cells["playSoundDataGridViewTextBoxColumn1"].Value.ToString()
                        //                , "Alarm activated", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        if (!Properties.Settings.Default.ReadText)
                        {
                            wplayer.controls.stop();
                        }
                    }

                    ColorDataGridView();
                    tbl = (DataTable)grdAlarms.DataSource;
                }
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            WindowsMediaPlayer wplayer = new WindowsMediaPlayer();
            wplayer.URL = lbFileList.SelectedValue.ToString();
            wplayer.controls.play();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string wav = "";
            if (chkSelectSound.Checked && lbFileList.SelectedIndex == -1)
            {
                MessageBox.Show("Sound not selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtWhat.Text != "")
            {
                if (lbFileList.SelectedItem != null)
                {
                    wav = lbFileList.SelectedItem.ToString();
                }
                AlarmInfo aiAdd = new AlarmInfo();
                aiAdd.Id = tbl.Rows.Count + 1;
                aiAdd.Active = true;
                aiAdd.Note = txtWhat.Text;
                aiAdd.TimeAt = dtpAlarmTime.Value;
                if (lbFileList.SelectedIndex != -1)
                    aiAdd.PlaySound = lbFileList.SelectedValue.ToString();
                if (Properties.Settings.Default.ReadText)
                {
                    aiAdd.PlaySound = "Reading the note text aloud.";
                }
                aiAdd.Fired = false;
                //grdAlarms.DataSource = aiAdd;
                DataRow row = tbl.NewRow();

                row["id"] = aiAdd.Id;
                row["active"] = aiAdd.Active;
                row["note"] = aiAdd.Note;
                row["timeAt"] = aiAdd.TimeAt;
                row["playSound"] = aiAdd.PlaySound;
                row["fired"] = aiAdd.Fired;
                tbl.Rows.Add(row);
                grdAlarms.DataSource = tbl;
                grdAlarms.Refresh();
            }
            else
            {
                MessageBox.Show("Enter something to remind about");
                txtWhat.Focus();
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
            string[] extensions = new[] { ".mp3", ".wav" };
            FileInfo[] files = dinfo.GetFiles("*.mp3", SearchOption.AllDirectories);
            files = dinfo.GetFiles().Where(f => extensions.Contains(f.Extension.ToLower())).ToArray();
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

        private void fmReminder_FormClosing(object sender, FormClosingEventArgs e)
        {
            var asdasd = Properties.Settings.Default.ReadText;
            string fileName = "xml.xml";
            try
            {
                Properties.Settings.Default.Save();
                tbl.TableName = "AlarmInfo";
                tbl.WriteXml(fileName, XmlWriteMode.WriteSchema, true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void chkSelectSound_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelectSound.Checked)
            {
                lbFileList.Enabled = true;
                chkSayWhat.Checked = false;
                txtWhat.Enabled = true;
                Properties.Settings.Default.ReadText = false;
            }
            else
            {
                lbFileList.Enabled = false;
                chkSayWhat.Checked = true;
                txtWhat.Enabled = true;
                Properties.Settings.Default.ReadText = true;
            }
        }

        private void chkSayWhat_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSayWhat.Checked)
            {
                lbFileList.Enabled = false;
                chkSelectSound.Checked = false;
                txtWhat.Enabled = true;
                Properties.Settings.Default.ReadText = true;
            }
            else
            {
                lbFileList.Enabled = true;
                chkSelectSound.Checked = true;
                txtWhat.Enabled = true;
                Properties.Settings.Default.ReadText = false;
            }
        }

        private void grdAlarms_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = grdAlarms.HitTest(e.X, e.Y);
                grdAlarms.ClearSelection();
                grdAlarms.Rows[hti.RowIndex].Selected = true;
            }
        }

        private void DeleteRow_Click(object sender, EventArgs e)
        {
            Int32 rowToDelete = grdAlarms.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            grdAlarms.Rows.RemoveAt(rowToDelete);
            grdAlarms.ClearSelection();
            var i = 1;
            foreach (DataGridViewRow item in grdAlarms.Rows)
            {
                item.Cells[0].Value = i.ToString();
                
                i++;
            }
        }
    }
}
