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
using DevExpress.Utils;
using System.Diagnostics;
using System.Drawing.Imaging;

namespace BMS
{
    public partial class frmTLTKCoCau : _Forms
    {
        public int GroupID;
        public string _moduleCode = "";
        public string _moduleName = "";
        public int Status = 2; //1: 3D ; 2: Chuan
        string _pathCkFTP = "";
        string _pathDnFTP = "";

        string _pathCkNormal = "";
        string _pathDnNormal = "";
        string _pathDtNormal = "";
        int _id = 1;
        DataTable dtFolder = new DataTable();
        ModulesModel selectedModule = new ModulesModel();
        DataTable dtDMVT_DT = new DataTable();
        DataTable dtDMVT = new DataTable();
        DataTable dtFile = new DataTable();

        DataTable _dtCoCau = new DataTable();

        public delegate void LoadDataChangeHandler(object sender, EventArgs e);
        public event LoadDataChangeHandler LoadDataChange;

        public frmTLTKCoCau()
        {
            InitializeComponent();
        }

        private void frmTLTKCoCau_Load(object sender, EventArgs e)
        {
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

            _dtCoCau.Columns.Add("MaCoCau");
            _dtCoCau.Columns.Add("TenCoCau");
            _dtCoCau.Columns.Add("LocalPath");
            _dtCoCau.Columns.Add("IsSaved", typeof(int));
            grvCoCau.DataSource = _dtCoCau;

            loadModule();
            //loadInit();
        }

        void loadModule()
        {
            DataTable tbl = TextUtils.Select("select * from Modules with(nolock) where status = 2 and Code like 'TPAD.%' order by Code");
            TextUtils.PopulateCombo(cboModule, tbl, "Name", "ID", "");
        }

        void loadInit()
        {
            DocUtils.InitFTPQLSX();

            selectedModule = (ModulesModel)ModulesBO.Instance.FindByCode(_moduleCode);

            //cboMaterialType.SelectedIndex = 0;
            _pathCkFTP = "Thietke.Ck/" + _moduleCode.Substring(0, 6) + "/" + _moduleCode + ".Ck";
            _pathDnFTP = "Thietke.Dn/" + _moduleCode.Substring(0, 6) + "/" + _moduleCode + ".Dn";

            _pathCkNormal = @"\\SERVER\data2\Thietke\Luutru\Thietkechuan\" + _pathCkFTP;
            //_pathDnNormal = @"\\SERVER\data2\Thietke\Luutru\Thietkechuan\" + _pathDnFTP;
            //_pathDtNormal = @"\\SERVER\data2\Thietke\Luutru\Thietkechuan\ThietKe.Dt\" + _moduleCode.Substring(0, 5);           

            if (Status == 2)
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
        }

        DataTable getDmvtFTP()
        {
            try
            {
                DocUtils.InitFTPQLSX();
                string model = _moduleCode;
                string strFilePath = System.IO.Path.GetTempFileName();
                strFilePath = strFilePath.Remove(strFilePath.LastIndexOf(@"\"));
                string strFTPFileName = @"//Thietke.Ck/" + model.Substring(0, 6) + "/" + model + ".Ck" + "/VT." + model + ".xlsm ";
                DocUtils.DownloadFile(strFilePath, "dmvt.xlsm", strFTPFileName);
                DataTable dt = TextUtils.ExcelToDatatable(strFilePath + "/" + "dmvt.xlsm", "DMVT");
                File.Delete(strFilePath + "/" + "dmvt.xlsm");
                return dt;
            }
            catch
            {
                return new DataTable();
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
                    row["PathName"] = item;
                    row["FolderNumber"] = countFolder;
                    row["ParentID"] = parent;
                    row["FileNumber"] = countFile;
                    row["ID"] = _id;
                    row["FullPathName"] = initPath + "/" + item;
                    dtFolder.Rows.Add(row);
                    _id++;
                    if (countFolder > 0)
                    {
                        getAllFolderFTP(initPath + "/" + item, Convert.ToInt16(row["ID"]));
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
                //treeList1.ExpandAll();
                _id = 1;
            }
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
                DataRow[] listRow = dtFolder.Select("ParentID = " + id);
                foreach (DataRow row in listRow)
                {
                    downloadFolderFTP(selectedPath, (int)row["ID"]);
                }
            }
        }

        string getIamImagePath(string fptPath)
        {
            try
            {
                string localPath = "D:\\CoCau";
                Directory.CreateDirectory(localPath);
                string fileName = Path.GetFileName(fptPath);
                DocUtils.DownloadFile(localPath, fileName, fptPath);

                IPTDetail.LoadData(localPath + "/" + fileName);
                string imagePath = localPath + "\\" + Path.GetFileNameWithoutExtension(fileName) + ".png";
                Bitmap bit = new Bitmap(IPTDetail.Image, IPTDetail.Image.Width / 3, IPTDetail.Image.Height / 3);
                bit.Save(imagePath, ImageFormat.Png);

                return imagePath;
            }
            catch
            {
                return "";
            }
        }

        private void cboModule_EditValueChanged(object sender, EventArgs e)
        {
            if (cboModule.EditValue == null) return;
            
            _moduleCode = TextUtils.ToString(grvCboModule.GetFocusedRowCellValue(colCboModuleCode));
            _moduleName = TextUtils.ToString(grvCboModule.GetFocusedRowCellValue(colCboModuleName));

            loadInit();

            grvCoCau.Rows.Clear();
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load dữ liệu..."))
            {
                try
                {
                    int fileNumber = TextUtils.ToInt(e.Node.GetValue(colTreeFileNumber));
                    string folderName = TextUtils.ToString(e.Node.GetValue(colTreePath));

                    if (fileNumber == 0)
                    {
                        grvData.DataSource = null;
                        return;
                    }

                    DocUtils.InitFTPQLSX();
                    dtFile.Rows.Clear();
                    string folderPath = e.Node.GetValue(colTreeFullPath).ToString();

                    if (Status == 2)//ftp server
                    {
                        string[] array = DocUtils.GetContentList(folderPath);
                        foreach (string item in array)
                        {
                            if (dtFolder.Select("PathName = '" + item + "'").Length == 0)
                            {
                                DataRow row = dtFile.NewRow();
                                row["check"] = false;
                                row["FileName"] = item;
                                try
                                {
                                    row["Size"] = DocUtils.GetFileSize(folderPath + "/" + item);
                                }
                                catch
                                {
                                    continue;
                                }

                                row["CreatedDate"] = DocUtils.GetDateModified(folderPath + "/" + item);
                                row["FullPath"] = folderPath + "/" + item;

                                DataRow[] drs = dtDMVT.Select("F4 = '" + Path.GetFileNameWithoutExtension(item) + "'");
                                if (drs.Length > 0)
                                {
                                    string name = drs[0]["F2"].ToString();
                                    row["Name"] = name;
                                }

                                dtFile.Rows.Add(row);

                                if (Path.GetExtension(item).ToLower() == ".iam" && folderName.ToUpper() == Path.GetFileNameWithoutExtension(item).ToUpper())
                                {
                                    //getImage();
                                    pictureBox1.ImageLocation = getIamImagePath(folderPath + "/" + item);
                                }
                                else
                                {
                                    pictureBox1.Image = null;
                                }
                            }
                        }
                    }

                    colName.Visible = true;
                    grvData.DataSource = null;
                    grvData.AutoGenerateColumns = false;
                    grvData.DataSource = dtFile;

                    //colName.Visible = cadFolder;
                }
                catch (Exception)
                {
                }
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
                progressBar1.Visible = false;
                MessageBox.Show("Download dữ liệu thành công!");
                Process.Start("explorer.exe", fbd.SelectedPath);
            }
        }      

        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDownloadAll_Click(null, null);
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
                    listRow.Add(row.Cells[colFullFilePath.Index].Value.ToString());
                }
            }
            if (listRow.Count <= 0)
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
                    if (Status == 2)
                    {
                        DocUtils.DownloadFile(fbd.SelectedPath, Path.GetFileName(item), item);
                    }
                    //if (Status == 1)
                    //{
                    //    File.Copy(item, fbd.SelectedPath + "/" + Path.GetFileName(item), true);
                    //}
                    progressBar1.Value++;
                }
                progressBar1.Visible = false;

                MessageBox.Show("Download dữ liệu thành công!");
                Process.Start("explorer.exe", fbd.SelectedPath);
            }
        }

        private void btnAddCoCau_Click(object sender, EventArgs e)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang add cơ cấu..."))
            {
                //for (int i = 0; i < treeList1.Nodes.Count; i++)
                for (int i = 0; i < treeList1.VisibleNodesCount; i++)
                {
                    if (treeList1.GetNodeByVisibleIndex(i).Checked)
                    {
                        string code = TextUtils.ToString(treeList1.GetNodeByVisibleIndex(i).GetValue(colTreePath));
                        DataRow[] drs1 = _dtCoCau.Select("MaCoCau = '" + code + "'");
                        if (drs1.Length > 0) continue;

                        string ftpPath = TextUtils.ToString(treeList1.GetNodeByVisibleIndex(i).GetValue(colTreeFullPath));
                        string name = "";
                        string localFilePath = "D://CoCau//" + code;
                        DataRow[] drs = dtDMVT.Select("F4 = '" + code + "'");
                        if (drs.Length > 0)
                        {
                            name = drs[0]["F2"].ToString();
                        }

                        if (!File.Exists(localFilePath))
                        {
                            localFilePath = getIamImagePath(ftpPath + "//" + code + ".iam");
                        }

                        DataRow dr = _dtCoCau.NewRow();
                        dr["MaCoCau"] = code;
                        dr["TenCoCau"] = name;
                        dr["LocalPath"] = localFilePath;
                        dr["IsSaved"] = 0;
                        _dtCoCau.Rows.Add(dr);
                    }
                }
                
            }
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grvCoCau.SelectedRows.Count > 0)
            {
                grvCoCau.Rows.RemoveAt(grvCoCau.SelectedRows[0].Index);
            }
        }

        private void btnCreateCoCau_Click(object sender, EventArgs e)
        {
            if (grvCoCau.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy cơ cấu để tạo!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            string saveImagePath = TextUtils.GetConfigValue("CoCauPath");
            int count = 0;
            foreach (DataGridViewRow row in grvCoCau.Rows)
            {
                string code = TextUtils.ToString(row.Cells["colMaCoCau"].Value);
                DataTable dt = TextUtils.Select("select top 1 Code from CoCauMau with(nolock) where Code = '" + code + "'");
                if (dt.Rows.Count > 0) continue;

                string name = TextUtils.ToString(row.Cells["colTenCoCau"].Value);
                string localPath = TextUtils.ToString(row.Cells["colImagePath"].Value);
                int isSaved = TextUtils.ToInt(row.Cells["colIsSaved"].Value);
                if (code == "") continue;
                if (isSaved == 1) continue;

                CoCauMauModel CoCau = new CoCauMauModel();
                CoCau.Name = name.ToUpper();
                CoCau.Code = code.ToUpper();
                CoCau.CoCauGroupID = GroupID;
                CoCau.Note = "";
                CoCau.Specifications = "";

                try
                {
                    File.Copy(localPath, saveImagePath + "//" + Path.GetFileName(localPath), true);
                    CoCau.ImagePath = saveImagePath + "//" + Path.GetFileName(localPath);
                    CoCau.ID = (int)CoCauMauBO.Instance.Insert(CoCau);
                    count++;

                    frmCoCauMau frm = new frmCoCauMau();
                    frm.CoCau = CoCau;
                    frm.GroupID = GroupID;
                    frm.ShowDialog();

                    _dtCoCau.Rows[row.Index]["IsSaved"] = 1;
                }
                catch
                {
                }
            }

            if (count > 0)
            {
                MessageBox.Show("Tạo cơ cấu thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                if (this.LoadDataChange != null)
                {
                    this.LoadDataChange(null, null);
                }
            }
            else
            {
                MessageBox.Show("Các cơ cấu này đã được tạo!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
