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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


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
            dtpAlarmTime.Format = DateTimePickerFormat.Time;
            dtpAlarmTime.ShowUpDown = true;
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
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
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
                var idDG = row.Cells["idDataGridViewTextBoxColumn1"].Value.ToString();
                var activeDG = (bool)row.Cells["activeDataGridViewCheckBoxColumn1"].Value;
                var noteDG = row.Cells["noteDataGridViewTextBoxColumn1"].Value.ToString();
                var timeAtDG = row.Cells["timeAtDataGridViewTextBoxColumn1"].Value.ToString();
                var playSoundDG = row.Cells["playSoundDataGridViewTextBoxColumn1"].Value.ToString();
                var firedDG = (bool)row.Cells["firedDataGridViewCheckBoxColumn1"].Value;

                string str = timeAtDG;
                string gridDate = str.Substring(0, str.Length - 3);

                string realDate = DateTime.Now.ToString("g"); // "g" is for full date without seconds
                if (((DateTime.Parse(gridDate) < DateTime.Parse(realDate)) && (bool)activeDG == true) || (bool)activeDG == false && (bool)firedDG == false)
                {
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                    row.Cells["activeDataGridViewCheckBoxColumn1"].Value = false;
                }
                if ((DateTime.Parse(gridDate) < DateTime.Parse(realDate)) && (bool)firedDG == true)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                    row.Cells["activeDataGridViewCheckBoxColumn1"].Value = true;
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

                    if (gridDate == realDate && (bool)row.Cells["activeDataGridViewCheckBoxColumn1"].Value == true)
                    {
                        SoundPlayer simpleSound = new SoundPlayer(lbFileList.SelectedValue.ToString());
                        simpleSound.Play();
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                        row.Cells["firedDataGridViewCheckBoxColumn1"].Value = true;
                        row.Cells["activeDataGridViewCheckBoxColumn1"].Value = false;
                        MessageBox.Show("Alarm sound playing for:\r\n"
                                      + row.Cells["noteDataGridViewTextBoxColumn1"].Value.ToString()
                                      + Environment.NewLine + "the sound:"
                                      + row.Cells["playSoundDataGridViewTextBoxColumn1"].Value.ToString()
                                        , "Alarm activated", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        simpleSound.Stop();
                    }

                    ColorDataGridView();
                    tbl = (DataTable)grdAlarms.DataSource;
                }
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
                aiAdd.Id = tbl.Rows.Count + 1;
                aiAdd.Active = true;
                aiAdd.Note = txtWhat.Text;
                aiAdd.TimeAt = dtpAlarmTime.Value;
                aiAdd.PlaySound = lbFileList.SelectedValue.ToString();
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

        public DataTable gridviewToDataTable(DataGridView gv)
        {
            DataTable dtCalculate = new DataTable("AlarmInfo");

            // Create Column 1: Date
            DataColumn idColumn = new DataColumn();
            idColumn.DataType = Type.GetType("System.String");
            idColumn.ColumnName = "id";

            // Create Column 3: TotalSales
            DataColumn activeColumn = new DataColumn();
            activeColumn.DataType = Type.GetType("System.Boolean");
            activeColumn.ColumnName = "active";


            DataColumn noteColumn = new DataColumn();
            noteColumn.DataType = Type.GetType("System.String");
            noteColumn.ColumnName = "note";


            DataColumn timeAtColumn = new DataColumn();
            timeAtColumn.DataType = Type.GetType("System.DateTime");
            timeAtColumn.ColumnName = "timeAt";


            DataColumn playSoundColumn = new DataColumn();
            playSoundColumn.DataType = Type.GetType("System.String");
            playSoundColumn.ColumnName = "playSound";

            DataColumn firedColumn = new DataColumn();
            firedColumn.DataType = Type.GetType("System.Boolean");
            firedColumn.ColumnName = "fired";

            // Add the columns to the ProductSalesData DataTable
            dtCalculate.Columns.Add(idColumn);
            dtCalculate.Columns.Add(activeColumn);
            dtCalculate.Columns.Add(noteColumn);
            dtCalculate.Columns.Add(timeAtColumn);
            dtCalculate.Columns.Add(playSoundColumn);
            dtCalculate.Columns.Add(firedColumn);

            foreach (DataGridViewRow row in gv.Rows)
            {
                DataRow dr;
                dr = dtCalculate.NewRow();
                dr["id"] = row.Cells[0].Value.ToString();
                dr["active"] = bool.Parse(row.Cells[1].Value.ToString());
                dr["note"] = row.Cells[2].Value.ToString();
                dr["timeAt"] = DateTime.Parse(row.Cells[3].Value.ToString());
                dr["playSound"] = row.Cells[4].Value.ToString();
                dr["fired"] = bool.Parse(row.Cells[5].Value.ToString());

                dtCalculate.Rows.Add(dr);
            }
            return dtCalculate;
        }

        private void fmReminder_FormClosing(object sender, FormClosingEventArgs e)
        {
            string fileName = "xml.xml";
            try
            {
                tbl.TableName = "AlarmInfo";
                tbl.WriteXml(fileName, XmlWriteMode.WriteSchema, true);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
