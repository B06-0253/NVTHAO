using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Model;
using BMS.Utils;
using DevExpress.Utils;
using System.IO;
using BMS.Business;
using System.Diagnostics;

namespace BMS
{
    public partial class frmSolution : _Forms
    {
        #region Variables
        public SolutionModel Solution = new SolutionModel();
        public long RequireID = 0;
        public string CustomerCode = "";
        DataTable _dtFile = new DataTable();
        DataTable _dtDMVT = new DataTable();
        bool _isSaved = false;
        DataTable _dtFileFTP = new DataTable();
        DataTable _dtFolder = new DataTable();
        int _id = 1;
        DataTable _dtLocal;

        public delegate void LoadDataChangeHandler(object sender, EventArgs e);
        public event LoadDataChangeHandler LoadDataChange;
        #endregion

        public frmSolution()
        {
            InitializeComponent();
        }

        private void frmSolution_Load(object sender, EventArgs e)
        {
            loadTech();
            loadArea();
            loadGroupFile();
            loadFile();
            loadDMVT();
            loadYC();
            loadNguoiPhuTrach();

            if (Solution.ID > 0)
            {
                txtCode.Text = Solution.Code;
                txtDescription.Text = Solution.Description;
                txtName.Text = Solution.Name;
                txtReasonStop.Text = Solution.StopReason;
                txtTotalCost.EditValue = Solution.TotalCost;
                txtVersion.Text = Solution.Version.ToString();
                txtWorkDescription.Text = Solution.WorkDescription;

                cboArea.EditValue = Solution.Area;
                cboNguoiPhuTrach.EditValue = Solution.NguoiPhuTrach;
                cboRequire.EditValue = Solution.RequireSolutionID;
                cboStatus.SelectedIndex = Solution.Status;
                cboTechnology.EditValue = Solution.SolutionTechnologyID;

                this.Text = "Giải pháp: " + Solution.Code + " - " + Solution.Name;
            }
            else
            {
                cboStatus.SelectedIndex = 0;
                cboRequire.EditValue = RequireID;
                txtVersion.Text = "1";

                DataTable dt = TextUtils.Select(" SELECT top 1 Code FROM Solution where Code like 'GP." + CustomerCode + "%' order by ID desc");
                //string code = "GP.000001";
                string code = "GP." + CustomerCode + ".001";
                if (dt.Rows.Count > 0)
                {
                    code = TextUtils.ToString(dt.Rows[0]["Code"]);
                    string number = code.Split('.')[2];
                    code = "GP." + CustomerCode + "." + string.Format("{0:000}", TextUtils.ToInt(number) + 1);
                }
                txtCode.Text = code;
            }

            _dtFolder.Columns.Add("PathName");
            _dtFolder.Columns.Add("FolderNumber");
            _dtFolder.Columns.Add("ParentID", typeof(int));
            _dtFolder.Columns.Add("FileNumber");
            _dtFolder.Columns.Add("ID", typeof(int));
            _dtFolder.Columns.Add("FullPathName");

            _dtFileFTP.Columns.Add("check", typeof(bool));
            _dtFileFTP.Columns.Add("FileName");
            _dtFileFTP.Columns.Add("Size");
            _dtFileFTP.Columns.Add("CreatedDate");
            _dtFileFTP.Columns.Add("FullPath");
            _dtFileFTP.Columns.Add("Name");
        }

        #region Methods
        void loadYC()
        {
            //using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load dữ liệu..."))
            //{
                try
                {
                    string[] paraName = new string[2];
                    object[] paraValue = new object[2];

                    paraName[0] = "@CustomerCode";
                    paraValue[0] = CustomerCode;
                    paraName[1] = "@TextFind"; paraValue[1] = "";
                    DataTable Source = RequireSolutionBO.Instance.LoadDataFromSP("spGetFilterRequire", "Source", paraName, paraValue);

                    cboRequire.Properties.DataSource = Source;
                    cboRequire.Properties.DisplayMember = "Code";
                    cboRequire.Properties.ValueMember = "ID";
                }
                catch (Exception ex)
                {
                    return;
                }
            //}
        }

        void loadNguoiPhuTrach()
        {
            DataTable dt = TextUtils.Select("Select * from vUserInfo WITH(NOLOCK)");

            //cboNguoiYeuCau.Properties.DataSource = dt;
            //cboNguoiYeuCau.Properties.DisplayMember = "FullName";
            //cboNguoiYeuCau.Properties.ValueMember = "ID";

            cboNguoiPhuTrach.Properties.DataSource = dt;
            cboNguoiPhuTrach.Properties.DisplayMember = "FullName";
            cboNguoiPhuTrach.Properties.ValueMember = "ID";
        }

        void loadTech()
        {
            DataTable dt = TextUtils.Select("select * from SolutionTechnology with(nolock) where Type = 1");
            cboTechnology.Properties.DataSource = dt;
            cboTechnology.Properties.DisplayMember = "Name";
            cboTechnology.Properties.ValueMember = "ID";
        }

        void loadArea()
        {
            DataTable dt = TextUtils.Select("select * from SolutionTechnology with(nolock) where Type = 2");
            cboArea.Properties.DataSource = dt;
            cboArea.Properties.DisplayMember = "Name";
            cboArea.Properties.ValueMember = "ID";
        }

        void loadGroupFile()
        {
            DataTable dt = TextUtils.Select("select * from SolutionFileType with(nolock)");
            grdGroupFile.DataSource = dt;
        }

        void loadFile()
        {
            _dtFile = TextUtils.Select("select * from SolutionFile with(nolock) where SolutionID = " + Solution.ID
                + " and SolutionFileTypeID = " + TextUtils.ToInt(grvGroupFile.GetFocusedRowCellValue(colGFID)));
            _dtFile.Columns.Add("LocalPath");
            grdFile.DataSource = _dtFile;
        }

        void loadDMVT()
        {
            _dtDMVT = TextUtils.Select("select * from SolutionItem with(nolock) where SolutionID = " + Solution.ID);
            grdVT.DataSource = _dtDMVT;
        }
        
        DataTable getAllFolderFTP(string initPath, int parent)
        {
            try
            {
                //_dtFolder.Rows.Clear();

                DocUtils.InitFTPTK();
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

                    //try
                    //{
                    //    countFile = BMS.DocUtils.GetFilesList(initPath + "/" + item).Length;
                    //}
                    //catch (Exception)
                    //{
                    //}

                    DataRow row = _dtFolder.NewRow();
                    row[0] = item;
                    row[1] = countFolder;
                    row[2] = parent;
                    row[3] = countFile;
                    row[4] = _id;
                    row[5] = initPath + "/" + item;
                    _dtFolder.Rows.Add(row);
                    _id++;
                    if (countFolder > 0)
                    {
                        getAllFolderFTP(initPath + "/" + item, Convert.ToInt16(row[4]));
                    }
                }

                treeList1.DataSource = _dtFolder;
                _id = 1;
                return _dtFolder;
            }
            catch (Exception)
            {
                return new DataTable();
            }
        }

        bool ValidateForm()
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền tên.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (cboNguoiPhuTrach.EditValue == null)
            {
                MessageBox.Show("Xin hãy chọn người phụ trách.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            //if (cboNguoiYeuCau.EditValue == null)
            //{
            //    MessageBox.Show("Xin hãy chọn người yêu cầu.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return false;
            //}

            return true;
        }

        void save(bool close)
        {
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();
            try
            {
                if (!ValidateForm())
                    return;

                grvFile.FocusedRowHandle = -1;

                #region Save Solution
                Solution.Name = txtName.Text.Trim().ToUpper();
                Solution.Code = txtCode.Text.Trim();
                Solution.RequireSolutionID = TextUtils.ToInt64(cboRequire.EditValue);

                Solution.Description = txtDescription.Text;
                Solution.WorkDescription = txtWorkDescription.Text;
                Solution.Version = 1;
                Solution.Status = cboStatus.SelectedIndex;
                Solution.NguoiPhuTrach = TextUtils.ToInt(cboNguoiPhuTrach.EditValue);
                Solution.TotalCost = TextUtils.ToDecimal(txtTotalCost.EditValue);
                Solution.Area = TextUtils.ToInt(cboArea.EditValue);
                Solution.SolutionTechnologyID = TextUtils.ToInt(cboTechnology.EditValue);
                Solution.StopReason = txtReasonStop.Text;
                Solution.IsDeleted = false;

                Solution.UpdatedDate = TextUtils.GetSystemDate();
                Solution.UpdatedBy = Global.AppUserName;

                if (Solution.ID <= 0)
                {
                    Solution.CreatedDate = TextUtils.GetSystemDate();
                    Solution.CreatedBy = Global.AppUserName;
                    Solution.ID = (long)pt.Insert(Solution);
                }
                else
                {
                    pt.Update(Solution);
                }
                #endregion

                #region Save File
                DataRow[] drs = _dtFile.Select("ID = 0 or ID is null");
                if (drs.Length > 0)
                {
                    DocUtils.InitFTPTK();

                    using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang update tên cho file..."))
                    {
                        for (int i = 0; i < grvFile.RowCount; i++)
                        {
                            long id = TextUtils.ToInt64(grvFile.GetRowCellValue(i, colFileID));
                            if (id > 0)
                            {
                                SolutionFileModel fileModel = (SolutionFileModel)SolutionFileBO.Instance.FindByPK(id);
                                fileModel.Description = TextUtils.ToString(grvFile.GetRowCellValue(i, colFileDescription));
                                pt.Update(fileModel);
                            }
                            else
                            {
                                string name = TextUtils.ToString(grvFile.GetRowCellValue(i, colFileName));
                                string extension = Path.GetExtension(name);
                                decimal length = TextUtils.ToDecimal(grvFile.GetRowCellValue(i, colFileLenght));
                                string description = TextUtils.ToString(grvFile.GetRowCellValue(i, colFileDescription));
                                string path = "GiaiPhap/" + Solution.Code + "/" + name;
                                string createdBy = Global.AppUserName;
                                DateTime? createdDate = DateTime.Now;

                                string localPath = TextUtils.ToString(grvFile.GetRowCellValue(i, colFileLocalPath));

                                if (!DocUtils.CheckExits("GiaiPhap/" + Solution.Code))
                                {
                                    DocUtils.MakeDir("GiaiPhap/" + Solution.Code);
                                }

                                SolutionFileModel fileModel = new SolutionFileModel();
                                fileModel.CreatedBy = createdBy;
                                fileModel.CreatedDate = createdDate;
                                fileModel.Description = description;
                                fileModel.Extension = extension;
                                fileModel.Length = length;
                                fileModel.Name = name;
                                fileModel.Path = path;
                                fileModel.SolutionID = Solution.ID;
                                fileModel.SolutionFileTypeID = TextUtils.ToInt(grvGroupFile.GetFocusedRowCellValue(colGFID));
                                pt.Insert(fileModel);

                                DocUtils.UploadFile(localPath, "GiaiPhap/" + Solution.Code);
                            }
                        }
                    }
                }
                #endregion

                #region Save DMVT
                for (int i = 0; i < grvVT.RowCount; i++)
                {
                    long id = TextUtils.ToInt64(grvVT.GetRowCellValue(i, colMaID));
                    SolutionItemModel item = new SolutionItemModel();
                    if (id > 0)
                    {
                        item = (SolutionItemModel)SolutionItemBO.Instance.FindByPK(id);
                    }

                    item.Code = TextUtils.ToString(grvVT.GetRowCellValue(i, colMaCode));
                    item.Name = TextUtils.ToString(grvVT.GetRowCellValue(i, colMaName));
                    item.Hang = TextUtils.ToString(grvVT.GetRowCellValue(i, colMaHang));
                    item.Qty = TextUtils.ToDecimal(grvVT.GetRowCellValue(i, colMaQty));
                    item.Price = TextUtils.ToDecimal(grvVT.GetRowCellValue(i, colMaPrice));
                    item.TotalPrice = TextUtils.ToDecimal(grvVT.GetRowCellValue(i, colMaTotalPrice));
                    item.QtyError = TextUtils.ToInt(grvVT.GetRowCellValue(i, colMaError));
                    item.QtyKPH = TextUtils.ToInt(grvVT.GetRowCellValue(i, colMaKPH));
                    item.QtyTon = TextUtils.ToInt(grvVT.GetRowCellValue(i, colMaTonKho));

                    //item.Unit = TextUtils.ToString(grvVT.GetRowCellValue(i, colMau));
                    //item.Status = TextUtils.ToString(grvVT.GetRowCellValue(i, colMaCode));
                    //item.Type = TextUtils.ToString(grvVT.GetRowCellValue(i, colMaCode));

                    item.SolutionID = Solution.ID;
                    if (id > 0)
                    {
                        pt.Update(item);
                    }
                    else
                    {
                        pt.Insert(item);
                    }
                }
                #endregion

                pt.CommitTransaction();

                loadFile();
                loadDMVT();
                _isSaved = true;

                if (close)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Lưu trữ thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lưu trữ không thành công!" + Environment.NewLine + ex.Message, TextUtils.Caption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                pt.CloseConnection();
            }
        }

        void loadCT()
        {
            DocUtils.InitFTPTK();
            string ftpPath = "Thietke.Gp/GP." + Solution.Code;
            if (DocUtils.CheckExits(ftpPath))
            {
                _dtFolder.Rows.Clear();
                getAllFolderFTP(ftpPath, 0);
            }
        }

        void uploadFolder(string folderPath, string ftpPath)
        {
            DocUtils.InitFTPTK();
            string folderName = Path.GetFileName(folderPath);
            if (!DocUtils.CheckExits(ftpPath + "/" + folderName))
            {
                DocUtils.MakeDir(ftpPath + "/" + folderName);
            }

            DocUtils.UploadDirectory(folderPath, ftpPath + "/" + folderName);
        }

        bool checkCT(string SelectedGPpath)
        {
            _dtLocal = new DataTable();
            _dtLocal.Columns.Add("Name", typeof(string));
            _dtLocal.Columns.Add("Size", typeof(string));
            _dtLocal.Columns.Add("Type", typeof(string));
            _dtLocal.Columns.Add("Hang", typeof(string));
            _dtLocal.Columns.Add("PathLocal", typeof(string));
            _dtLocal.Columns.Add("Path3D", typeof(string));
            _dtLocal.Columns.Add("NameVT", typeof(string));

            string _code = "";
            _code = Path.GetFileName(SelectedGPpath);
            _code = _code.Substring(3, 8);

            //_dtLocal.Rows.Clear();

            DataTable dtCT = TextUtils.Select("Select * from DesignStructure where Type = 3");//lấy những thư mục cấu trúc cơ khí
            string[] listDirectories = Directory.GetDirectories(SelectedGPpath, "**", SearchOption.AllDirectories);

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

                string folderPath = Path.GetDirectoryName(SelectedGPpath) + "\\" + itemRow["Path"].ToString().Replace("code", _code);
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

            if (_dtLocal.Rows.Count == 0)
            {
                //MessageBox.Show("Cấu trúc giải pháp chuẩn", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                //MessageBox.Show("Cấu trúc giải pháp chưa chuẩn", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmBaoGiaCN frm = new frmBaoGiaCN();
            TextUtils.OpenForm(frm);
        }        

        private void btnSave_Click(object sender, EventArgs e)
        {
            save(false);
            if (_isSaved)
            {
                this.Text = "Giải pháp: " + Solution.Code + " - " + Solution.Name;
                if (this.LoadDataChange != null)
                {
                    this.LoadDataChange(null, null);
                }
            }
        }

        private void btnAddTech_Click(object sender, EventArgs e)
        {
            frmSolutionTechnology frm = new frmSolutionTechnology(1);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                loadTech();
                cboTechnology.EditValue = frm.ID;
            }
        }        

        private void btnAddArea_Click(object sender, EventArgs e)
        {
            frmSolutionTechnology frm = new frmSolutionTechnology(2);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                loadArea();
                cboArea.EditValue = frm.ID;
            }
        }

        private void btnNewGroup_Click(object sender, EventArgs e)
        {
            frmGroupFile frm = new frmGroupFile();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                loadGroupFile();
            }
        }

        private void btnDeleteGroup_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvGroupFile.GetFocusedRowCellValue(colGFID));
            if (id == 0) return;

            if (SolutionFileBO.Instance.CheckExist("SolutionFileTypeID", id))
            {
                MessageBox.Show("Nhóm file này đã chứa các file con\n Bạn không thể xóa được nhóm file này.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (MessageBox.Show("Bạn có thật sự muốn xóa nhóm file này không?", TextUtils.Caption,
                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            SolutionFileTypeBO.Instance.Delete(id);
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            //DocUtils.InitFTPTK();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (string item in ofd.FileNames)
                {
                    FileInfo fInfo = new FileInfo(item);
                    DataRow r = _dtFile.NewRow();
                    r["LocalPath"] = fInfo.FullName;
                    r["Name"] = fInfo.Name;
                    r["Extension"] = fInfo.Extension;
                    r["Length"] = fInfo.Length;
                    r["SolutionFileTypeID"] = TextUtils.ToString(grvGroupFile.GetFocusedRowCellValue(colGFID));
                    r["SolutionID"] = 0;
                    _dtFile.Rows.Add(r);
                }
            }
        }

        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            DocUtils.InitFTPTK();
            if (grvFile.RowCount <= 0) return;

            int id = TextUtils.ToInt(grvFile.GetFocusedRowCellValue(colFileID));

            string filePath = TextUtils.ToString(grvFile.GetFocusedRowCellValue(colFileLocalPath));
            string fileName = Path.GetFileName(filePath);

            if (MessageBox.Show("Bạn có thật sự muốn xóa file [" + fileName + "] này không?", TextUtils.Caption,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            if (id == 0)
            {
                grvFile.DeleteSelectedRows();
            }
            else
            {
                ProcessTransaction pt = new ProcessTransaction();
                pt.OpenConnection();
                pt.BeginTransaction();
                try
                {
                    pt.Delete("SolutionFile", id);

                    if (DocUtils.CheckExits(filePath))
                    {
                        DocUtils.DeleteFile(filePath);
                    }

                    pt.CommitTransaction();
                    grvFile.DeleteSelectedRows();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa file [" + fileName + "] không thành công!" + Environment.NewLine + ex.Message,
                        TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                    pt.CloseConnection();
                }
            }
        }

        private void btnAddVT_Click(object sender, EventArgs e)
        {
            frmListMaterial frm = new frmListMaterial();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang thêm vật tư..."))
                {
                    foreach (DataRow r in frm.dtAll.Rows)
                    {
                        string code = TextUtils.ToString(r["Code"]);
                        if (code == "") continue;
                        DataRow[] drs = _dtDMVT.Select("Code = '" + code + "'");
                        if (drs.Length > 0) continue;
                        decimal tonKho = TextUtils.ToDecimal(r["TonKho"]);

                        //string sqlM = "SELECT top 1 * FROM  vGetPriceOfPart with(nolock)"
                        //                + " WHERE Price > 1 AND replace(replace([PartsCode],'/','#'),')','#') = '"
                        //                + code.Replace(" ", "").Replace("/", "#").Replace(")", "#") + "'"
                        //                + " ORDER BY DateAboutF DESC";
                        //DataTable dtPrice = LibQLSX.Select(sqlM);

                        string sqlM = "exec spGetPriceOfPart '" + code.Replace(" ", "").Replace("/", "#").Replace(")", "#") + "'";
                        DataTable dtPrice = LibQLSX.Select(sqlM);

                        DataRow dr = _dtDMVT.NewRow();
                        dr["Code"] = r["Code"].ToString();
                        dr["Name"] = r["Name"].ToString();
                        dr["Hang"] = r["Hang"].ToString();
                        dr["Unit"] = r["Unit"].ToString();
                        dr["QtyTon"] = tonKho;
                        dr["SolutionID"] = TextUtils.ToInt(Solution.ID);
                        if (dtPrice.Rows.Count > 0)
                        {
                            dr["Price"] = TextUtils.ToDecimal(dtPrice.Rows[0]["Price"]).ToString("n0");                            
                        }
                        else
                        {
                            dr["Price"] = TextUtils.ToDecimal(r["Price"]).ToString("n0");                           
                        }
                        dr["TotalPrice"] = TextUtils.ToDecimal(dr["Price"]).ToString("n0");
                        dr["Qty"] = 1;
                        _dtDMVT.Rows.Add(dr);
                    }
                }
            }
        }

        private void btnAddModule_Click(object sender, EventArgs e)
        {
            frmListModules frm = new frmListModules();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang thêm module..."))
                {
                    foreach (DataRow r in frm.dtSeleted.Rows)
                    {
                        string code = TextUtils.ToString(r["Code"]);
                        if (code == "") continue;
                        DataRow[] drs = _dtDMVT.Select("Code = '" + code + "'");
                        if (drs.Length > 0) continue;

                        decimal price = TextUtils.GetPrice(code, true);

                        DataRow dr = _dtDMVT.NewRow();
                        dr["Code"] = TextUtils.ToString(r["Code"]);
                        dr["Name"] = TextUtils.ToString(r["Name"]);
                        dr["Hang"] = TextUtils.ToString(r["Hang"]);
                        dr["Unit"] = "Bộ";
                        dr["Price"] = price;
                        dr["TotalPrice"] = price;
                        dr["Qty"] = 1;
                        dr["SolutionID"] = TextUtils.ToInt(Solution.ID);
                        _dtDMVT.Rows.Add(dr);
                    }
                }
            }
        }

        private void btnDeleteVT_Click(object sender, EventArgs e)
        {
            if (grvVT.RowCount <= 0) return;

            int id = TextUtils.ToInt(grvVT.GetFocusedRowCellValue(colFileID));

            if (MessageBox.Show("Bạn có thật sự muốn xóa vật tư này không?", TextUtils.Caption,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            if (id == 0)
            {
                grvVT.DeleteSelectedRows();
            }
            else
            {
                try
                {
                    SolutionItemBO.Instance.Delete(id);
                    grvVT.DeleteSelectedRows();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa vật tư không thành công!" + Environment.NewLine + ex.Message,
                        TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }       

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabCTGP)
            {
                loadCT();
            }
        }

        private void treeList1_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            DocUtils.InitFTPTK();
            _dtFileFTP.Rows.Clear();
            if (e.Node == null) return;

            string folderPath = e.Node.GetValue(colTreeFullPath).ToString();

            string[] array = DocUtils.GetContentList(folderPath);
            if (array == null) return;
            foreach (string item in array)
            {
                if (_dtFolder.Select("PathName = '" + item + "'").Length == 0)
                {
                    DataRow row = _dtFileFTP.NewRow();
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

                    _dtFileFTP.Rows.Add(row);
                }
            }
            grvData.DataSource = null;
            grvData.AutoGenerateColumns = false;
            grvData.DataSource = _dtFileFTP;
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
                    listRow.Add(row.Cells[colFullFilePath.Index].Value.ToString());
                }
            }
            if (listRow.Count <= 0)
            {
                MessageBox.Show("Bạn hãy chọn file để download!");
                return;
            }

            DocUtils.InitFTPTK();

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

        private void btnDel_Click(object sender, EventArgs e)
        {
            DocUtils.InitFTPTK();
            if (!DocUtils.CheckExits("/Thietke.Gp/GP." + Solution.Code))
            {
                MessageBox.Show("Giải pháp này chưa có trên nguồn", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa cấu trúc giải pháp này ở trên nguồn?", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DocUtils.DeleteDirectory("/Thietke.Gp/GP." + Solution.Code);
                    MessageBox.Show("Giải pháp này đã được xóa thành công", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadCT();
                }
            }
        }       

        private void btnUpCTTG_Click(object sender, EventArgs e)
        {
            DocUtils.InitFTPTK();
            if (DocUtils.CheckExits("/Thietke.Gp/" + Solution.Code))
            {
                MessageBox.Show("Giải pháp này đang tồn tại dữ liệu trên nguồn", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = fbd.SelectedPath;
                    if (Path.GetFileName(selectedPath) == "GP." + Solution.Code)
                    {
                       bool kq = checkCT(fbd.SelectedPath);
                       if (kq)
                       {
                           uploadFolder(selectedPath, "Thietke.Gp");
                           MessageBox.Show("Giải pháp này đã tải lên nguồn thành công", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                           loadCT();
                       }
                       else
                       {
                           frmCheckCTGP frm = new frmCheckCTGP();
                           frm._dtLocal = _dtLocal;
                           frm.SelectedGPpath = fbd.SelectedPath;
                           frm.Show();
                       }
                    }
                    else
                    {
                        MessageBox.Show("Bạn đã chọn sai thư mục để tải lên nguồn", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
        }

        private void btnDownloadFolder_Click(object sender, EventArgs e)
        {
            string ftpPath = treeList1.FocusedNode.GetValue(colTreeFullPath).ToString();
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
	        {
                TextUtils.DownloadFtpFolder(ftpPath, fbd.SelectedPath);
                Process.Start(fbd.SelectedPath + "/" + Path.GetFileName(ftpPath));
	        }
        }

        private void btnDownloadAll_Click(object sender, EventArgs e)
        {
            string ftpPath = string.Format(@"\Thietke.Gp\GP.{0}", Solution.Code);
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                TextUtils.DownloadFtpFolder(ftpPath, fbd.SelectedPath);
                Process.Start(fbd.SelectedPath + "/" + Path.GetFileName(ftpPath));
            }
        }
    }
}
