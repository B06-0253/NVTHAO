using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace BMS
{
    public partial class frmCheckCTGP : _Forms
    {
        public DataTable _dtLocal;
        string _code = "";
        public string SelectedGPpath = "";

        public frmCheckCTGP()
        {
            InitializeComponent();
        }

        private void frmCheckCTGP_Load(object sender, EventArgs e)
        {
            if (SelectedGPpath != "")
            {
                txtCode.Text = SelectedGPpath;
                //btnChoose_Click(null, null);
                grdData.DataSource = _dtLocal;
                grvData.BestFitColumns();
            }
            else
            {
                _dtLocal = new DataTable();
                _dtLocal.Columns.Add("Name", typeof(string));
                _dtLocal.Columns.Add("Size", typeof(string));
                _dtLocal.Columns.Add("Type", typeof(string));
                _dtLocal.Columns.Add("Hang", typeof(string));
                _dtLocal.Columns.Add("PathLocal", typeof(string));
                _dtLocal.Columns.Add("Path3D", typeof(string));
                _dtLocal.Columns.Add("NameVT", typeof(string));
            }
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtCode.Text = fbd.SelectedPath;
                SelectedGPpath = fbd.SelectedPath;                
            }
        }

        private void btnCheckCT_Click(object sender, EventArgs e)
        {
            _code = Path.GetFileName(SelectedGPpath);
            _code = _code.Substring(3, 8);

            _dtLocal.Rows.Clear();

            DataTable dtCT = TextUtils.Select("Select * from DesignStructure where Type = 3");//lấy những thư mục cấu trúc cơ khí
            string[] listDirectories = Directory.GetDirectories(txtCode.Text.Trim(), "**", SearchOption.AllDirectories);

            foreach (string item in listDirectories)
            {
                string folderName = Path.GetFileName(item);
                int count = 0;
                foreach (DataRow r in dtCT.Rows)
                {
                    string formatFolder = r["Name"].ToString().Replace("code", _code);
                    if (folderName != formatFolder)
                    {
                        count = 1;
                    }
                    else
                    {
                        count = 0;
                        break;
                    }
                }
                if (count == 1)
                {
                    DataRow row = _dtLocal.NewRow();
                    row["Name"] = folderName;
                    row["PathLocal"] = item;
                    row["Type"] = "Folder THỪA";
                    _dtLocal.Rows.Add(row);
                }
            }

            foreach (DataRow itemRow in dtCT.Rows)
            {
                string nameCT = itemRow["Name"].ToString().Replace("code", _code);//OldVersions
                int iD = TextUtils.ToInt(itemRow["ID"]);

                string[] arrExtension = null;

                try
                {
                    arrExtension = itemRow["Extension"].ToString().Split(',').Where(o => o.Trim() != "").ToArray();
                }
                catch (Exception)
                {
                }

                string folderPath = Path.GetDirectoryName(txtCode.Text) + "\\" + itemRow["Path"].ToString().Replace("code", _code);
                if (!Directory.Exists(folderPath))
                {
                    DataRow row = _dtLocal.NewRow();
                    row["Name"] = nameCT;
                    row["PathLocal"] = folderPath;
                    row["Type"] = "THIẾU THƯ MỤC";
                    _dtLocal.Rows.Add(row);
                }
                else
                {
                    DataTable dtCTFile = TextUtils.Select("SELECT * FROM DesignStructureFile where DesignStructureID = " + iD);
                    string[] listFiles = Directory.GetFiles(folderPath, "*.*", SearchOption.TopDirectoryOnly);

                    if (dtCTFile.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtCTFile.Rows)
                        {
                            string fileNameCT = row["Name"].ToString().Replace("code", _code);
                            bool exist = TextUtils.ToBoolean(row["Exist"]);
                            if (exist)
                            {
                                int count = 0;
                                try
                                {
                                    count = listFiles.Count(o => Path.GetFileName(o).Contains(Path.GetFileNameWithoutExtension(fileNameCT)));
                                }
                                catch
                                {                                    
                                }
                                if (count == 0)
                                {
                                    DataRow row1 = _dtLocal.NewRow();
                                    row1["Name"] = fileNameCT;
                                    row1["PathLocal"] = folderPath;
                                    row1["Type"] = "THIẾU FILE";
                                    _dtLocal.Rows.Add(row1);
                                }                                
                            }
                        }
                    }

                    if (listFiles.Count() > 0)
                    {
                        foreach (string item in listFiles)
                        {
                            string fileName = Path.GetFileName(item);
                            string textCompare = fileName.Split('-')[0];
                            if (dtCTFile.Rows.Count > 0)
                            {
                                int count = 0;
                                try { count = dtCTFile.Select().Count(r => Path.GetFileNameWithoutExtension(r["Name"].ToString().Replace("code", _code)) == textCompare); }
                                catch { }
                                if (count == 0)
                                {
                                    DataRow row1 = _dtLocal.NewRow();
                                    row1["Name"] = fileName;
                                    row1["Size"] = new FileInfo(item).Length;
                                    row1["PathLocal"] = item;
                                    row1["Type"] = "THỪA";
                                    _dtLocal.Rows.Add(row1);
                                    continue;
                                }
                            }

                            if (arrExtension != null && arrExtension.Count() > 0 && !arrExtension.Contains(Path.GetExtension(fileName)))
                            {
                                DataRow row1 = _dtLocal.NewRow();
                                row1["Name"] = fileName;
                                row1["Size"] = new FileInfo(item).Length;
                                row1["PathLocal"] = item;
                                row1["Type"] = "THỪA";
                                _dtLocal.Rows.Add(row1);
                            }
                        }
                    }
                }
            }

            grdData.DataSource = _dtLocal;
            grvData.BestFitColumns();

            if (_dtLocal.Rows.Count == 0)
            {
                MessageBox.Show("Cấu trúc giải pháp chuẩn", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cấu trúc giải pháp chưa chuẩn", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExecl_Click(object sender, EventArgs e)
        {
            TextUtils.ExportExcel(grvData);
        }

        private void grvData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == (Keys.C))
            {
                try
                {
                    string text = TextUtils.ToString(grvData.GetFocusedRowCellValue(grvData.FocusedColumn));
                    Clipboard.SetText(text);
                }
                catch
                {
                }
            }
        }

        private void mởĐườngDẫnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = TextUtils.ToString(grvData.GetFocusedRowCellDisplayText(colPath));
            try
            {
                Process.Start("explorer.exe", "/select, " + path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
