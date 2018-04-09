using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Model;
using BMS.Business;
using System.IO;
using System.Diagnostics;
using DevExpress.Utils;

namespace BMS
{
    public partial class frmElectronicMaterial : _Forms
    {
        public string ProductCode = "PCB.A010000";
        string _pathDtFTP = "Thietke.Dt/PCB/";
        ModulesModel selectedModule;
        DataTable dt = new DataTable();

        int _id = 1;

        public frmElectronicMaterial()
        {
            InitializeComponent();
        }

        private void frmElectronicMaterial_Load(object sender, EventArgs e)
        {
            DocUtils.InitFTPQLSX();
            selectedModule = (ModulesModel)ModulesBO.Instance.FindByAttribute("Code", ProductCode)[0];
            _pathDtFTP = "Thietke.Dt/PCB/" + ProductCode;

            dt.Columns.Add("PathName");
            dt.Columns.Add("FolderNumber");
            dt.Columns.Add("ParentID", typeof(int));
            dt.Columns.Add("FileNumber");
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("FullPathName");

            getFolderFTP(_pathDtFTP);
        }

        DataTable getAllFolderFTP(string initPath, int parent)
        {
            List<string> listInitPath = BMS.DocUtils.GetContentList(initPath).ToList();
            listInitPath = listInitPath.Where(o => DocUtils.GetFileSize(initPath + "/" + o) == 0).ToList();
            int count = listInitPath.Count;

            if (count <= 0) return new DataTable();

            foreach (string item in listInitPath)
            {
                int countFolder = 0;
                int countFile = 0;
                try
                {
                    countFolder = BMS.DocUtils.GetFoldersList(initPath + "/" + item).Length;
                }
                catch (Exception)
                {
                }
                try
                {
                    countFile = BMS.DocUtils.GetFilesList(initPath + "/" + item).Length;
                }
                catch (Exception)
                {
                }

                DataRow row = dt.NewRow();
                row[0] = item;
                row[1] = countFolder;
                row[2] = parent;
                row[3] = countFile;
                row[4] = _id;
                row[5] = initPath + "/" + item;
                dt.Rows.Add(row);
                _id++;
                if (countFolder > 0)
                {
                    getAllFolderFTP(initPath + "/" + item, Convert.ToInt16(row[4]));
                }
            }
            return dt;
        }

        void getFolderFTP(string selectedPath)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát", "Đang nạp dữ liệu"))
            {
                dt.Rows.Clear();

                getAllFolderFTP(selectedPath, 0);

                DataRow row = dt.NewRow();
                row[0] = Path.GetFileName(selectedPath);
                try
                {
                    row[1] = DocUtils.GetFoldersList(selectedPath).Length;
                }
                catch
                {
                    row[1] = 0;
                }

                row[2] = -1;
                try
                {
                    row[3] = DocUtils.GetFilesList(selectedPath).Length;
                }
                catch (Exception)
                {
                    row[3] = 0;
                }

                row[4] = 0;
                row[5] = selectedPath;
                dt.Rows.InsertAt(row, 0);
                treeList1.DataSource = dt;
                _id = 1;
            }
        }

        void downloadFolderFTP(string selectedPath, int id)
        {
            DataRow dr = dt.Select("ID = " + id)[0];
            string path = dr["FullPathName"].ToString();
            int folderNumber = int.Parse(dr["FolderNumber"].ToString());
            int fileNumber = int.Parse(dr["FileNumber"].ToString());

            Directory.CreateDirectory(selectedPath + "/" + path);
            if (fileNumber > 0)
            {
                //DataTable fileTable = DocUtils.GetFilesTable(path);
                string[] fileTable = DocUtils.GetContentList(path);
                foreach (string item in fileTable)
                {
                    long size = 0;
                    try
                    {
                        size = DocUtils.GetFileSize(path + "/" + item);
                    }
                    catch
                    {
                    }
                    if (size == 0)
                    {
                        continue;
                    }
                    DocUtils.DownloadFile(selectedPath + "/" + path, item, path + "/" + item, progressBar1, null);
                }
            }
            if (folderNumber > 0)
            {
                DataRow[] listRow = dt.Select("ParentID = " + id);
                foreach (DataRow row in listRow)
                {
                    downloadFolderFTP(selectedPath, (int)row["ID"]);
                }
            }
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            try
            {
                int fileNumber = TextUtils.ToInt(e.Node.GetValue(colTreeFileNumber));
                if (fileNumber == 0)
                {
                    grvData.DataSource = null; return;
                }
                string folderPath = e.Node.GetValue(colTreeFullPath).ToString();

                DataTable dtFile = new DataTable();
                dtFile.Columns.Add("check", typeof(bool));
                dtFile.Columns.Add("FileName");
                dtFile.Columns.Add("Size");
                dtFile.Columns.Add("CreatedDate");
                dtFile.Columns.Add("FullPath");
                               
                string[] array = DocUtils.GetContentList(folderPath);
                foreach (string item in array)
                {
                    if (dt.Select("PathName = '" + item + "'").Length == 0)
                    {
                        DataRow row = dtFile.NewRow();
                        row[0] = false;
                        row[1] = item;
                        try
                        {
                            row[2] = DocUtils.GetFileSize(folderPath + "/" + item);
                        }
                        catch
                        {
                            continue;
                        }

                        row[3] = DocUtils.GetDateModified(folderPath + "/" + item);
                        row[4] = folderPath + "/" + item;
                        dtFile.Rows.Add(row);
                    }
                }              
               
                grvData.DataSource = null;
                grvData.AutoGenerateColumns = false;
                grvData.DataSource = dtFile;
            }
            catch (Exception)
            {

            }
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (grvData.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in grvData.Rows)
                {
                    row.Cells[0].Value = chkSelectAll.Checked;
                }
            }
        }

        private void btnDownloadFile_Click(object sender, EventArgs e)
        {
            if (grvData.Rows.Count <= 0)
            {
                MessageBox.Show("Bạn hãy chọn file để download!");
                return;
            }
            List<string> listRow = new List<string>();
            foreach (DataGridViewRow row in grvData.Rows)
            {
                if ((bool)row.Cells[0].Value)
                {
                    listRow.Add(row.Cells[4].Value.ToString());
                }
            }
            if (listRow.Count <= 0)
            {
                MessageBox.Show("Bạn hãy chọn file để download!");
                return;
            }
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                progressBar1.Visible = true;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = listRow.Count;
                progressBar1.Value = 0;
                foreach (string item in listRow)
                {
                    DocUtils.DownloadFile(fbd.SelectedPath, Path.GetFileName(item), item);
                    progressBar1.Value++;
                }
                progressBar1.Visible = false;

                MessageBox.Show("Download dữ liệu thành công!");
                Process.Start("explorer.exe", fbd.SelectedPath);
            }         
        }

        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnDownloadFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string path1 = treeList1.FocusedNode.GetValue(colTreeFullPath).ToString();
                int id = (int)treeList1.FocusedNode.GetValue(colTreeID);
                progressBar1.Visible = true;
               
                downloadFolderFTP(fbd.SelectedPath, id);
               
                progressBar1.Visible = false;
                MessageBox.Show("Download dữ liệu thành công!");
                Process.Start("explorer.exe", fbd.SelectedPath);
            }   
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
