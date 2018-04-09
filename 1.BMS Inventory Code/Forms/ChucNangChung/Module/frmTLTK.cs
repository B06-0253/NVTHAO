using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BMS;
using DevExpress.XtraTreeList.Nodes;
using System.Diagnostics;
using System.Net;
using BMS.Model;
using BMS.Business;
using BMS.Utils;
using DevExpress.Utils;

namespace BMS
{
    public partial class frmTLTK : _Forms
    {        
        public string ProductCode = "";
        public string ProductName = "";
        public int Status = 0; //1: 3D ; 2: Chuan
        string _pathCkFTP = "";
        string _pathDnFTP = "";

        string _pathCkNormal = "";
        string _pathDnNormal = "";
        string _pathDtNormal = "";
        int _id = 1;
        DataTable dtFolder = new DataTable();
        ModulesModel selectedModule;
        DataTable dtDMVT_DT = new DataTable();
        DataTable dtDMVT = new DataTable();
        DataTable dtFile = new DataTable();

        #region Constructors and Loads
        public frmTLTK()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text += ": " + ProductCode + " - " + ProductName;

            DocUtils.InitFTPQLSX();

            selectedModule = (ModulesModel)ModulesBO.Instance.FindByAttribute("Code", ProductCode)[0];

            cboMaterialType.SelectedIndex = 0;
            _pathCkFTP = "Thietke.Ck/" + ProductCode.Substring(0, 6) + "/" + ProductCode + ".Ck";
            _pathDnFTP = "Thietke.Dn/" + ProductCode.Substring(0, 6) + "/" + ProductCode + ".Dn";

            _pathCkNormal = @"\\SERVER\data2\Thietke\Luutru\Thietkechuan\" + _pathCkFTP;
            _pathDnNormal = @"\\SERVER\data2\Thietke\Luutru\Thietkechuan\" + _pathDnFTP;
            _pathDtNormal = @"\\SERVER\data2\Thietke\Luutru\Thietkechuan\ThietKe.Dt\" + ProductCode.Substring(0, 5);

            dtFolder.Columns.Add("PathName");
            dtFolder.Columns.Add("FolderNumber");
            dtFolder.Columns.Add("ParentID", typeof(int));
            dtFolder.Columns.Add("FileNumber");
            dtFolder.Columns.Add("ID", typeof(int));
            dtFolder.Columns.Add("FullPathName");
            
            dtFile.Columns.Add("check", typeof(bool));
            dtFile.Columns.Add("FileName");
            dtFile.Columns.Add("Size");
            dtFile.Columns.Add("CreatedDate");
            dtFile.Columns.Add("FullPath");
            dtFile.Columns.Add("Name");

            if (Status==2)
            {
                if (!DocUtils.CheckExits(_pathCkFTP))
                {
                    MessageBox.Show("Không tồn tại thiết kế cơ khí trên nguồn thiết kế!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                try
                {
                    dtDMVT = getDmvtFTP();
                    dtDMVT_DT = dtDMVT.Select("F4 like '%PCB%'").Distinct().CopyToDataTable();                    
                }
                catch
                {                   
                }

                getFolderFTP(_pathCkFTP);
            }

            if (Status == 1)
            {
                try
                {
                    dtDMVT = getDmvtNormal();
                    dtDMVT_DT = dtDMVT.Select("F4 like '%PCB%'").Distinct().CopyToDataTable();
                }
                catch
                {
                }
                getFolderNormal(_pathCkNormal);
            }
        }
        #endregion
        
        #region Methods
        DataTable getDmvtFTP()
        {
            try
            {
                DocUtils.InitFTPQLSX();
                string model = ProductCode;
                string strFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                strFilePath = strFilePath.Remove(strFilePath.LastIndexOf(@"\"));
                string strFTPFileName = @"//Thietke.Ck/" + model.Substring(0, 6) + "/" + model + ".Ck" + "/VT." + model + ".xlsm ";
                DocUtils.DownloadFile(strFilePath, model + ".xlsm", strFTPFileName);
                DataTable dt = TextUtils.ExcelToDatatable(strFilePath + "/" + model + ".xlsm", "DMVT");
                File.Delete(strFilePath + "/" + model + ".xlsm");
                return dt;
            }
            catch
            {
                return new DataTable();
            }
        }

        DataTable getDmvtNormal()
        {
            try
            {
                string strFileName = @"\\SERVER\data2\Thietke\Luutru\Thietkechuan\Thietke.Ck\" + ProductCode.Substring(0, 6) + "/" + 
                    ProductCode + ".Ck" + "/VT." + ProductCode + ".xlsm ";
                if (File.Exists(strFileName))
                {
                    return TextUtils.ExcelToDatatable(strFileName, "DMVT");
                }
                
            }
            catch 
            {
                
            }
            return new DataTable();
        }

        void downloadFolderFTP(string selectedPath, int id)
        {
            DocUtils.InitFTPQLSX();
            DataRow dr = dtFolder.Select("ID = " + id)[0];
            string path = dr["FullPathName"].ToString();
            int folderNumber = int.Parse(dr["FolderNumber"].ToString());
            int fileNumber = int.Parse(dr["FileNumber"].ToString());

            Directory.CreateDirectory(selectedPath + "/" + path);
            if (fileNumber > 0)
            {
                //DataTable fileTable = DocUtils.GetFilesTable(path);
                string[] fileTable = DocUtils.GetContentList(path);
                if(fileTable != null)
                {
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
            }
            if (folderNumber > 0)
            {
                DataRow[] listRow = dtFolder.Select("ParentID = " + id);
                if(listRow.Length > 0)
                {
                    foreach (DataRow row in listRow)
                    {
                        downloadFolderFTP(selectedPath, (int)row["ID"]);
                    }
                }
            }
        }

        void downloadFolderNormal(string selectedPath, int id, ProgressBar progressBar)
        {
            DataRow dr = dtFolder.Select("ID = " + id)[0];
            string path = dr["FullPathName"].ToString();
            int folderNumber = int.Parse(dr["FolderNumber"].ToString());
            int fileNumber = int.Parse(dr["FileNumber"].ToString());

            Directory.CreateDirectory(selectedPath + "/" + Path.GetFileName(path));
            if (fileNumber > 0)
            {
                string[] fileTable = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly);
                foreach (string item in fileTable)
                {
                    File.Copy(item, selectedPath + "/" + Path.GetFileName(path) + "/" + Path.GetFileName(item), true);
                    progressBar.Value += 1;
                }
            }
            if (folderNumber > 0)
            {
                DataRow[] listRow = dtFolder.Select("ParentID = " + id);
                foreach (DataRow row in listRow)
                {
                    downloadFolderNormal(selectedPath + "/" + Path.GetFileName(path), (int)row["ID"], progressBar);
                }
            }
        }

        DataTable getAllFolderFTP(string initPath, int parent)
        {
            try
            {
                DocUtils.InitFTPQLSX();
                //string[] listInitPath = BMS.DocUtils.GetFoldersList(initPath);
                List<string> listInitPath = BMS.DocUtils.GetContentList(initPath).ToList();//.Select(o=>DocUtils.GetFileSize(o)==0).ToList();
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

                    DataRow row = dtFolder.NewRow();
                    row[0] = item;
                    row[1] = countFolder;
                    row[2] = parent;
                    row[3] = countFile;
                    row[4] = _id;
                    row[5] = initPath + "/" + item;
                    dtFolder.Rows.Add(row);
                    _id++;
                    if (countFolder > 0)
                    {
                        getAllFolderFTP(initPath + "/" + item, Convert.ToInt16(row[4]));
                    }
                }
                return dtFolder;
            }
            catch (Exception)
            {
                return new DataTable();
            }              
        }

        void getFolderFTP(string selectedPath)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát", "Đang nạp dữ liệu"))
            {
                DocUtils.InitFTPQLSX();
                dtFolder.Rows.Clear();

                getAllFolderFTP(selectedPath, 0);

                DataRow row = dtFolder.NewRow();
                row[0] = Path.GetFileName(selectedPath);
                try
                {
                    row[1] = DocUtils.GetFoldersList(selectedPath).Length;
                }
                catch (Exception)
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
                dtFolder.Rows.InsertAt(row, 0);
                treeList1.DataSource = dtFolder;
                _id = 1;
            }
        }

        DataTable getAllFolderNormal(string initPath, int parent)
        {
            string[] listInitPath = Directory.GetDirectories(initPath);
            int count = 0;
            try
            {
                count = listInitPath.Length; 
            }
            catch { }

            if (count <= 0) return new DataTable();

            foreach (string item in listInitPath)
            {
                int countFolder = 0;
                int countFile = 0;
                try
                {
                    countFolder = Directory.GetDirectories(initPath + "/" + Path.GetFileName(item)).Length;
                }
                catch (Exception)
                {
                }
                try
                {
                    countFile = Directory.GetFiles(initPath + "/" + Path.GetFileName(item)).Length;
                }
                catch (Exception)
                {
                }

                DataRow row = dtFolder.NewRow();
                row[0] = Path.GetFileName(item);
                row[1] = countFolder;
                row[2] = parent;
                row[3] = countFile;
                row[4] = _id;
                row[5] = item;
                dtFolder.Rows.Add(row);
                _id++;
                if (countFolder > 0)
                {
                    getAllFolderNormal(initPath + "/" + Path.GetFileName(item), Convert.ToInt16(row[4]));
                }
            }
            return dtFolder;
        }

        void getFolderNormal(string selectedPath)
        {
            dtFolder.Rows.Clear();

            getAllFolderNormal(selectedPath, 0);

            DataRow row = dtFolder.NewRow();
            row[0] = Path.GetFileName(selectedPath);
            try
            {
                row[1] = Directory.GetDirectories(selectedPath).Length;
            }
            catch (Exception)
            {
                row[1] = 0;
            }            
            row[2] = -1;
            try
            {
                row[3] = Directory.GetFiles(selectedPath).Length;
            }
            catch (Exception)
            {
                row[3] = 0;
            }            
            row[4] = 0;
            row[5] = selectedPath;
            dtFolder.Rows.InsertAt(row, 0);
            treeList1.DataSource = dtFolder;
            _id = 1;   
        }
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            try
            {
                int fileNumber = TextUtils.ToInt(e.Node.GetValue(colTreeFileNumber));
                if (fileNumber == 0)
                {
                    grvData.DataSource = null;
                    return;
                }
                DocUtils.InitFTPQLSX();
                dtFile.Rows.Clear();
                string folderPath = e.Node.GetValue(colTreeFullPath).ToString();
                bool cadFolder = false;
                cadFolder = Path.GetFileName(folderPath).StartsWith("CAD");    

                if (Status == 2)//ftp server
                {
                    string[] array = DocUtils.GetContentList(folderPath);                  
                    foreach (string item in array)
                    {
                        if (dtFolder.Select("PathName = '" + item + "'").Length == 0)
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
                            if (cadFolder)
                            {
                                DataRow[] drs = dtDMVT.Select("F4 = '" + Path.GetFileNameWithoutExtension(item) + "'");
                                if (drs.Length > 0)
                                {
                                    string name = drs[0]["F2"].ToString();
                                    row[5] = name;
                                }
                            }
                            dtFile.Rows.Add(row);
                        }
                    }
                }
                if (Status == 1)//local server
                {
                    string[] array = Directory.GetFiles(folderPath);                  
                    foreach (string item in array)
                    {                        
                        DataRow row = dtFile.NewRow();
                        row[0] = false;
                        row[1] = Path.GetFileName(item);                        
                        row[2] = new FileInfo(item).Length;
                        row[3] = new FileInfo(item).LastWriteTime;
                        row[4] = item;
                        dtFile.Rows.Add(row);                       
                    }
                }
                grvData.DataSource = null;
                grvData.AutoGenerateColumns = false;
                grvData.DataSource = dtFile;
                
                colName.Visible = cadFolder;
            }
            catch (Exception)
            {                
            }            
        }

        private void btnDownload_Click(object sender, EventArgs e)
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
                    listRow.Add(row.Cells[colFullFilePath.Index].Value.ToString());
                }
            }
            if (listRow.Count<=0)
            {
                MessageBox.Show("Bạn hãy chọn file để download!");
                return;
            }

            DocUtils.InitFTPQLSX();

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                progressBar1.Visible = true;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = listRow.Count;
                progressBar1.Value = 0;
                foreach (string item in listRow)
                {
                    if (Status==2)
                    {
                        DocUtils.DownloadFile(fbd.SelectedPath, Path.GetFileName(item), item);
                    }
                    if (Status==1)
                    {
                        File.Copy(item, fbd.SelectedPath + "/" + Path.GetFileName(item), true);
                    }
                    progressBar1.Value++;
                }
                progressBar1.Visible = false;

                MessageBox.Show("Download dữ liệu thành công!");
                Process.Start("explorer.exe", fbd.SelectedPath);
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

        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDownloadAll_Click(null, null);
        }

        private void cboMaterialType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DocUtils.InitFTPQLSX();
            if (Status==2)//Thiet ke Chuan da co tren ftp
            {
                #region FTP
                if (cboMaterialType.SelectedIndex == 0)//Co khi
                {
                    if (!DocUtils.CheckExits(_pathCkFTP))
                    {
                        MessageBox.Show("Không tồn tại thiết kế cơ khí này trên nguồn thiết kế!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    getFolderFTP(_pathCkFTP);
                }
                if (cboMaterialType.SelectedIndex == 2)//điện
                {
                    //if (selectedModule.FileElectric == 1)
                    //{
                        if (!DocUtils.CheckExits(_pathDnFTP))
                        {
                            MessageBox.Show("Sản phẩm không có thiết kế điện!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                        getFolderFTP(_pathDnFTP);
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Sản phẩm không có thiết kế điện!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    grvData.DataSource = null;
                    //    treeList1.DataSource = null;
                    //}
                }
                if (cboMaterialType.SelectedIndex == 1 )//điện tử
                {
                    //if (selectedModule.FileElectronic == 1 && dtDMVT.Rows.Count > 0)
                    if (dtDMVT_DT.Rows.Count > 0)
                    {
                        string pathDtFTP = "Thietke.Dt/PCB/";
                        _id = dtDMVT_DT.Rows.Count;
                        dtFolder.Rows.Clear();
                        for (int i = 0; i < dtDMVT_DT.Rows.Count; i++)
                        {
                            string selectedPath = pathDtFTP + dtDMVT_DT.Rows[i]["F4"].ToString();
                            DataTable dtL = getAllFolderFTP(selectedPath, i);
                            DataRow row = dtL.NewRow();
                            row[0] = Path.GetFileName(selectedPath);
                            try
                            {
                                row[1] = DocUtils.GetFoldersList(selectedPath).Length;
                            }
                            catch (Exception)
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
                           
                            row[4] = i;
                            row[5] = selectedPath;
                            dtL.Rows.InsertAt(row, 0);
                            dtFolder.Merge(dtL);
                        }
                        treeList1.DataSource = dtFolder;                        
                    }
                    else
                    {
                        MessageBox.Show("Sản phẩm không có thiết kế điện tử!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        grvData.DataSource = null;
                        treeList1.DataSource = null;
                    }
                    _id = 1;
                }
                #endregion
            }
            if (Status==1) //Thiêt kế có sẵn 3d
            {
                #region Normal
                if (cboMaterialType.SelectedIndex == 0)//Co khi
                {
                    getFolderNormal(_pathCkNormal);
                }
                if (cboMaterialType.SelectedIndex == 2)//điện
                {
                    if (selectedModule.FileElectric == 1 && Directory.Exists(_pathDnNormal))
                    {
                        getFolderNormal(_pathDnNormal);
                    }
                    else
                    {
                        MessageBox.Show("Sản phẩm không có thiết kế điện!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        grvData.DataSource = null;
                        treeList1.DataSource = null;
                    }
                }
                if (cboMaterialType.SelectedIndex == 1 )//điện tử
                {
                    if (selectedModule.FileElectronic == 1 && dtDMVT_DT.Rows.Count > 0)
                    {
                        string pathDtNormal = _pathDtNormal;
                        _id = dtDMVT_DT.Rows.Count;
                        dtFolder.Rows.Clear();
                        for (int i = 0; i < dtDMVT_DT.Rows.Count; i++)
                        {
                            string selectedPath = pathDtNormal + "/" + dtDMVT_DT.Rows[i]["F4"].ToString();
                            DataTable dtL = getAllFolderNormal(selectedPath, i);
                            DataRow row = dtL.NewRow();
                            row[0] = Path.GetFileName(selectedPath);
                            try
                            {
                                row[1] = Directory.GetDirectories(selectedPath).Length;
                            }
                            catch (Exception)
                            {
                                row[1] = 0;
                            }

                            row[2] = -1;
                            try
                            {
                                row[3] = Directory.GetFiles(selectedPath).Length;
                            }
                            catch (Exception)
                            {
                                row[3] = 0;
                            }

                            row[4] = i;
                            row[5] = selectedPath;
                            dtL.Rows.InsertAt(row, 0);
                            dtFolder.Merge(dtL);
                        }
                        treeList1.DataSource = dtFolder;                      
                    }
                    else
                    {
                        MessageBox.Show("Sản phẩm không có thiết kế điện tử!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        grvData.DataSource = null;
                        treeList1.DataSource = null;                        
                    }
                    _id = 1;
                }
                #endregion
            }

        }

        private void btnDownloadAll_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();            
            fbd.SelectedPath = "D:\\";
            DocUtils.InitFTPQLSX();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string path1 = treeList1.FocusedNode.GetValue(colTreeFullPath).ToString();
                int id = (int)treeList1.FocusedNode.GetValue(colTreeID);
                progressBar1.Visible = true;
                if (Status == 2)
                {
                    downloadFolderFTP(fbd.SelectedPath, id);
                }
                if (Status == 1)
                {
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = Directory.GetFiles(path1, "*.*", SearchOption.AllDirectories).Length;
                    progressBar1.Value = 0;
                    downloadFolderNormal(fbd.SelectedPath, id, progressBar1);
                }
                progressBar1.Visible = false;
                MessageBox.Show("Download dữ liệu thành công!");
                Process.Start("explorer.exe", fbd.SelectedPath);
            }    
        }      
    }
}
