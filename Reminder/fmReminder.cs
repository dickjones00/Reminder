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
                    DataTable tbl = new DataTable();

                    tbl.TableName = "AlarmInfo";
                    tbl.ReadXml("xml.xml");
                    grdAlarms.DataSource = tbl;
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
                
            }
        }

        private void RunReminder()
        {
            foreach (DataGridViewRow row in grdAlarms.Rows)
            {
                string gridDate = "";
                if (File.Exists("xml.xml"))
                {
                    string str = row.Cells["timeAt"].Value.ToString();
                    gridDate = str.Substring(0, str.Length - 3);
                }
                else
                {
                    gridDate = ((DateTime)(row.Cells["timeAt"].Value)).ToString("g");
                }
                string realDate = DateTime.Now.ToString("g"); // "g" is for full date without seconds
                if (gridDate == realDate && (bool)row.Cells["active"].Value == true)
                {
                    SoundPlayer simpleSound = new SoundPlayer(lbFileList.SelectedValue.ToString());
                    simpleSound.Play();
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                    row.Cells["fired"].Value = true;
                    row.Cells["active"].Value = false;
                    row.Cells["note"].Value = row.Cells["note"].Value + " - alarm fired";
                    MessageBox.Show("Alarm sound playing for:\r\n"
                                  + row.Cells["note"].Value.ToString()
                                  + Environment.NewLine + "the sound:"
                                  + row.Cells["playSound"].Value.ToString()
                                    , "Alarm activated", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                var ddd = DateTime.Parse(gridDate);
                var dfffdd = DateTime.Parse(realDate);
                if (DateTime.Parse(gridDate) < DateTime.Parse(realDate) && row.Cells["active"].Value.ToString() == "True")
                {
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                    row.Cells["active"].Value = false;
                    row.Cells["note"].Value = row.Cells["note"].Value + "- alarm not fired";
                }
                //alarmInfoBindingSource = (BindingSource)grdAlarms.DataSource;
            }
        }

        private DataTable GetDataTableFromDGV(DataGridView dgv)
        {
            var dt = new DataTable();
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Visible)
                {
                    // You could potentially name the column based on the DGV column name (beware of dupes)
                    // or assign a type based on the data type of the data bound to this DGV column.
                    dt.Columns.Add();
                }
            }

            object[] cellValues = new object[dgv.Columns.Count];
            foreach (DataGridViewRow row in dgv.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    cellValues[i] = row.Cells[i].Value;
                }
                dt.Rows.Add(cellValues);
            }

            return dt;
        }
        private void btnPlay_Click(object sender, EventArgs e)
        {
            DataTable tbl = new DataTable();

            tbl.TableName = "AlarmInfo";
            tbl.ReadXml("xml.xml");
            grdAlarms.DataSource = tbl;
            grdAlarms.Refresh();
            //SoundPlayer simpleSound = new SoundPlayer(lbFileList.SelectedValue.ToString());
            //simpleSound.Play();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //List<AlarmInfo> ai = new List<AlarmInfo>();
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
                aiAdd.PlaySound = lbFileList.SelectedValue.ToString();
                aiAdd.Fired = false;

                alarmInfoBindingSource.Add(aiAdd);
                
                //ai.Add(aiAdd);
                //string json = JsonConvert.SerializeObject(aiAdd);
                //AlarmInfo myDeserializedObjList = (AlarmInfo)JsonConvert.DeserializeObject(json);
                ////AlarmInfo alarmInfo = JsonConvert.DeserializeObject<AlarmInfo>(json);
                //AlarmInfo myDeserializedObj = (AlarmInfo)JsonConvert.DeserializeObject(json, typeof(AlarmInfo));
                //JArray jsonResponse = JArray.Parse(json);


                //foreach (var item in jsonResponse)
                //{
                //    JObject jRaces = (JObject)item["AlarmInfo"];
                //    foreach (var rItem in jRaces)
                //    {
                //        string rItemKey = rItem.Key;
                //        JObject rItemValueJson = (JObject)rItem.Value;
                //        AlarmInfo rowsResult = Newtonsoft.Json.JsonConvert.DeserializeObject<AlarmInfo>(rItemValueJson.ToString());
                //    }
                //}
                grdAlarms.DataSource = alarmInfoBindingSource;
                grdAlarms.Refresh();
            }
            else
            {
                MessageBox.Show("Enter something ti remind about");
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
        public DataTable gridviewToDataTable(DataGridView gv)
        {

            DataTable dtCalculate = new DataTable("TableCalculator");

            // Create Column 1: Date
            DataColumn dateColumn = new DataColumn();
            dateColumn.DataType = Type.GetType("System.DateTime");
            dateColumn.ColumnName = "date";

            // Create Column 3: TotalSales
            DataColumn loanBalanceColumn = new DataColumn();
            loanBalanceColumn.DataType = Type.GetType("System.Double");
            loanBalanceColumn.ColumnName = "loanbalance";


            DataColumn offsetBalanceColumn = new DataColumn();
            offsetBalanceColumn.DataType = Type.GetType("System.Double");
            offsetBalanceColumn.ColumnName = "offsetbalance";


            DataColumn netloanColumn = new DataColumn();
            netloanColumn.DataType = Type.GetType("System.Double");
            netloanColumn.ColumnName = "netloan";


            DataColumn interestratecolumn = new DataColumn();
            interestratecolumn.DataType = Type.GetType("System.Double");
            interestratecolumn.ColumnName = "interestrate";

            DataColumn interestrateperdaycolumn = new DataColumn();
            interestrateperdaycolumn.DataType = Type.GetType("System.Double");
            interestrateperdaycolumn.ColumnName = "interestrateperday";

            // Add the columns to the ProductSalesData DataTable
            dtCalculate.Columns.Add(dateColumn);
            dtCalculate.Columns.Add(loanBalanceColumn);
            dtCalculate.Columns.Add(offsetBalanceColumn);
            dtCalculate.Columns.Add(netloanColumn);
            dtCalculate.Columns.Add(interestratecolumn);
            dtCalculate.Columns.Add(interestrateperdaycolumn);

            foreach (DataGridViewRow row in gv.Rows)
            {
                DataRow dr;
                dr = dtCalculate.NewRow();

                dr["id"] = DateTime.Parse(row.Cells[0].Value.ToString());
                dr["active"] = double.Parse(row.Cells[1].Value.ToString());
                dr["note"] = double.Parse(row.Cells[2].Value.ToString());
                dr["timeat"] = double.Parse(row.Cells[3].Value.ToString());
                dr["playsound"] = double.Parse(row.Cells[4].Value.ToString());
                dr["fired"] = double.Parse(row.Cells[5].Value.ToString());


                dtCalculate.Rows.Add(dr);
            }



            return dtCalculate;
        }
        private void fmReminder_FormClosing(object sender, FormClosingEventArgs e)
        {
            string fileName = @"xml.xml";
            try
            {
                DataTable tbl = grdAlarms.DataSource as DataTable;
                var dfa = GetDataTableFromDGV(grdAlarms);
                dfa.TableName = "AlarmInfo";
                dfa.WriteXml("xml.xml");
            //    DataSet dataSet =GetDataTableFromDGV(grdAlarms);
            //    dataSet.WriteXml(fileName);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            
            

            //string file = "d:\\mygrid.bin";
            //using (BinaryWriter bw = new BinaryWriter(File.Open(file, FileMode.Create)))
            //{
            //    bw.Write(grdAlarms.Columns.Count);
            //    bw.Write(grdAlarms.Rows.Count);
            //    foreach (DataGridViewRow dgvR in grdAlarms.Rows)
            //    {
            //        for (int j = 0; j < grdAlarms.Columns.Count; ++j)
            //        {
            //            object val = dgvR.Cells[j].Value;
            //            if (val == null)
            //            {
            //                bw.Write(false);
            //                bw.Write(false);
            //            }
            //            else
            //            {
            //                bw.Write(true);
            //                bw.Write(val.ToString());
            //            }
            //        }
            //    }


            //DataTable dt = new DataTable();
            //foreach (DataGridViewColumn col in grdAlarms.Columns)
            //{
            //    dt.Columns.Add(col.HeaderText);
            //}

            //foreach (DataGridViewRow frow in grdAlarms.Rows)
            //{
            //    DataRow dRow = dt.NewRow();
            //    foreach (DataGridViewCell cell in frow.Cells)
            //    {
            //        dRow[cell.ColumnIndex] = cell.Value;
            //    }
            //    dt.Rows.Add(dRow);
            //}
            ////After you have created this DataTable, create a DataSet and use WriteXml

            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            //ds.WriteXml("xml.xml");
        
        }
    }
}
