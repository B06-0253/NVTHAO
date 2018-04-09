using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BMS.Model;
using BMS.Utils;
using BMS.Business;
using System.IO;
using System.Drawing.Imaging;
using DevExpress.Utils;
using System.Diagnostics;
using Forms.Properties;

namespace BMS
{
    public partial class frmMaterial : _Forms
    {
        #region Variables
        public MaterialModel Material = new MaterialModel();
        public int GroupID = 0;
        DataTable _dt = new DataTable();
        bool _isSaved = false;

        public delegate void LoadDataChangeHandler(object sender, EventArgs e);
        public event LoadDataChangeHandler LoadDataChange;
        #endregion

        #region Contructor and Load

        public frmMaterial()
        {
            InitializeComponent();
        }

        private void frmMaterial_Load(object sender, EventArgs e)
        {
            loadCombo();
            loadHang();

            if (Material.ID != 0)
            {
                txtName.Text = Material.Name;
                txtCode.Text = Material.Code;
                txtDonVi.Text = Material.Unit;
                txtGhiChu.Text = Material.Note;
                txtPrice.Text = Material.Price.ToString("n0");
                txtPriceTemp.Text = Material.PriceTemp.ToString("n0");
                txtTGiaoHang.Text = Material.DeliveryPeriod.ToString();
                txtTGiaoHangTemp.Text = Material.DeliveryPeriodTemp;
                txtTGiaoHangCuoi.Text = Material.ThoiGianGHCuoi == null || Material.ThoiGianGHCuoi == "" 
                    ? "" : DateTime.Parse(Material.ThoiGianGHCuoi).ToString("dd/MM/yyyy");
                txtTTGiaCong.Text = Material.Properties;
                txtVatLieu.Text = Material.VL;
                txtVatTuNguon.Text = Material.MaVatLieu;
                txtWeight.Text = Material.Weight.ToString();

                cboHang.EditValue = Material.CustomerID;
                leParentCat.EditValue = Material.MaterialGroupID;

                chkTamDung.Checked = Material.StopStatus;
                chkThuongSuDung.Checked = Material.IsUse;

                //pbAnh.ImageLocation = Material.ImagePath;
                //Image img = null;
                //using (Image imgTmp = Image.FromFile(Material.ImagePath))
                //{
                //    img = new Bitmap(imgTmp.Width, imgTmp.Height, imgTmp.PixelFormat);
                //    Graphics gdi = Graphics.FromImage(img);
                //    gdi.DrawImageUnscaled(imgTmp, 0, 0);
                //    gdi.Dispose();
                //    imgTmp.Dispose(); // just to make sure

                //    pbAnh.Image = img;
                //}

                this.Text = "Vật tư: " + Material.Code + " - " + Material.Name;

                //btnSaveTS.Enabled = true;
                tabPageTaiLieu.PageEnabled = true;

                loadIpt();
                loadDatasheet();
            }
            else
            {
                leParentCat.EditValue = GroupID;
            }
            DocUtils.InitFTPTK();
        }

        #endregion

        #region Methods
        private bool ValidateForm()
        {
            txtCode.Text = txtCode.Text.Trim().ToUpper().Replace(" ", "");
            
            if (txtCode.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền Mã.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
            {
                DataTable dt;
                if (Material.ID > 0)
                {
                    dt = TextUtils.Select("select Code from Material where upper(Replace(Code,' ','')) = '" 
                        + txtCode.Text.Trim().ToUpper() + "' and ID <> " + Material.ID);
                }
                else
                {
                    dt = TextUtils.Select("select Code from Material where upper(Replace(Code,' ','')) = '" 
                        + txtCode.Text.Trim().ToUpper() + "'");
                }
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Mã này đã tồn tại!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }
                }
            }

            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền Tên.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (TextUtils.ToInt(leParentCat.EditValue) == 0)
            {
                MessageBox.Show("Xin hãy chọn một nhóm!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (TextUtils.ToInt(cboHang.EditValue)==0)
            {
                MessageBox.Show("Xin hãy chọn một hãng!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            
            return true;
        }

        void loadHang()
        {
            try
            {
                DataTable dt = TextUtils.Select("Customer", new Expression("Type", 0));
                TextUtils.PopulateCombo(cboHang, dt, "Name", "ID", "");
            }
            catch (Exception)
            {
                MessageBox.Show("Không load được hãng vào combo");
            }
        }

        void loadCombo()
        {
            DataTable tbl = TextUtils.Select(@"SELECT ID,Code +'-'+ Name AS Code FROM MaterialGroup WITH(NOLOCK) ORDER BY Code");
            if (tbl == null)
            {
                return;
            }
            //TextUtils.PopulateCombo(leParentCat, tbl.Copy(), "Code", "ID", "");
            leParentCat.Properties.DataSource = tbl;
            leParentCat.Properties.DisplayMember = "Code";
            leParentCat.Properties.ValueMember = "ID";
        }

        void loadGridPara()
        {
            //DataTable dt = TextUtils.Select("SELECT * FROM vMaterialParameter with(nolock) WHERE (MaterialGroupID = " + leParentCat.EditValue + ") order by STT");
            DataTable dt = TextUtils.Select("SELECT  ID, Name, MaterialGroupID, STT FROM MaterialParameters with(nolock) WHERE (MaterialGroupID = " + leParentCat.EditValue + ") order by STT");
            grdData.DataSource = dt;
        }

        void loadTreeValue()
        {
            try
            {
                int paraID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
                if (paraID == 0) return;
                DataTable dt = TextUtils.Select(string.Format("SELECT *FROM [MaterialParameterValue] with(nolock)where MaterialParameterID = {0} order by ParaValue", paraID));
                treeValue.DataSource = dt;                

                for (int i = 0; i < treeValue.Nodes.Count; i++)
                {
                    int idValue = TextUtils.ToInt(treeValue.GetNodeByVisibleIndex(i).GetValue(colIDValue));
                    DataTable dt1 = TextUtils.Select("MaterialConnect", new Expression("MaterialID", Material.ID)
                        .And(new Expression("MaterialParameterID", paraID))
                        .And(new Expression("MaterialParameterValueID", idValue)));
                    if (dt1 != null)
                    {
                        if (dt1.Rows.Count > 0)
                        {
                            treeValue.GetNodeByVisibleIndex(i).Checked = true;
                        }
                    }
                }
            }
            catch (Exception)
            {               
            }
            
        }

        void saveGiaTri(ProcessTransaction pt)
        {
            if (treeValue.Nodes.Count == 0) return;
            int paraID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (paraID == 0) return;
            if (Material.ID <= 0) return;
            for (int i = 0; i < treeValue.Nodes.Count; i++)
            {
                int valID = TextUtils.ToInt(treeValue.GetNodeByVisibleIndex(i).GetValue(colIDValue));

                DataTable dt = TextUtils.Select("MaterialConnect", new Expression("MaterialID", Material.ID)
                        .And(new Expression("MaterialParameterID", paraID))
                        .And(new Expression("MaterialParameterValueID", valID)));
                
                if (dt.Rows.Count > 0)
                {
                    if (!treeValue.GetNodeByVisibleIndex(i).Checked)
                    {
                        pt.Delete("MaterialConnect", TextUtils.ToInt(dt.Rows[0]["ID"]));
                    }
                }
                else
                {
                    if (treeValue.GetNodeByVisibleIndex(i).Checked)
                    {
                        MaterialConnectModel modelM = new MaterialConnectModel();
                        modelM.MaterialID = Material.ID;
                        modelM.MaterialParameterID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
                        modelM.MaterialParameterValueID = valID;
                        pt.Insert(modelM);
                    }
                }                
            }
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
                string oldName = Material.Name;                
                Material.Name = txtName.Text.Trim().ToUpper();
                Material.Code = txtCode.Text.Trim();
                Material.CustomerID = TextUtils.ToInt(cboHang.EditValue);
                Material.MaterialGroupID = TextUtils.ToInt(leParentCat.EditValue);

                Material.Unit = txtDonVi.Text;
                Material.Note = txtGhiChu.Text;
                Material.Price = TextUtils.ToDecimal(txtPrice.Text);
                Material.PriceTemp = TextUtils.ToDecimal(txtPriceTemp.Text);
                Material.DeliveryPeriod = TextUtils.ToDecimal(txtTGiaoHang.Text);
                Material.DeliveryPeriodTemp = txtTGiaoHangTemp.Text.Trim();
                Material.ThoiGianGHCuoi = txtTGiaoHangCuoi.Text;
                Material.Properties = txtTTGiaCong.Text;
                Material.VL = txtVatLieu.Text;
                Material.MaVatLieu = txtVatTuNguon.Text;
                Material.Weight = TextUtils.ToDecimal(txtWeight.Text);
                Material.StopStatus = chkTamDung.Checked;
                Material.IsUse = chkThuongSuDung.Checked;

                if (Material.ID <= 0)
                {
                    Material.CreatedDate = TextUtils.GetSystemDate();
                    Material.CreatedBy = Global.AppUserName;
                    Material.UpdatedDate = Material.CreatedDate;
                    Material.UpdatedBy = Global.AppUserName;
                    Material.ID = (int)pt.Insert(Material);
                }
                else
                {
                    Material.UpdatedDate = TextUtils.GetSystemDate();
                    Material.UpdatedBy = Global.AppUserName;
                    pt.Update(Material);

                    //update tên cho file ipt
                    if (oldName != Material.Name && Material.File3D > 0)
                    {
                        using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang update tên cho file 3D..."))
                        {
                            string filePathIpt = "Materials/" + Material.Code + ".ipt";
                            string localPath = Path.GetTempPath();
                            string fileName = Material.Code + ".ipt";
                            string filePathLocal = localPath + "/" + fileName;

                            DocUtils.DownloadFile(localPath, fileName, filePathIpt);

                            IPTDetail.WriteName(filePathLocal, Material.Name);

                            DocUtils.UploadFile(filePathLocal, "Materials");
                        }
                    }
                }

                //Lưu trữ thông số
                for (int i = 0; i < grvData.RowCount; i++)
                {
                    int paraID = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                    int materialID = TextUtils.ToInt(grvData.GetRowCellValue(i, colMaterialID));
                    DataTable dt = TextUtils.Select("MaterialParameterLink", new Expression("MaterialID", materialID)
                        .And(new Expression("MaterialParameterID", paraID)));
                    if (dt.Rows.Count > 0) continue;
                    MaterialParameterLinkModel model = new MaterialParameterLinkModel();
                    model.MaterialID = Material.ID;
                    model.MaterialParameterID = paraID;
                    pt.Insert(model);
                }

                pt.CommitTransaction();
                _isSaved = true;
                loadGridPara();
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

        void loadIpt()
        {
            DataTable dt = TextUtils.Select("vMaterialFile", new Expression("MaterialID", Material.ID).And(new Expression("FileType", 0)));
            grdIPT.DataSource = dt;
        }

        void loadDatasheet()
        {
            DataTable dt = TextUtils.Select("vMaterialFile", new Expression("MaterialID", Material.ID).And(new Expression("FileType", 1)));
            grdDatasheet.DataSource = dt;
        }

        #endregion

        #region Event button

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save(false);
            if (_isSaved)
            {
                this.Text = "Vật tư: " + Material.Code + " - " + Material.Name;
            }
            btnSaveTS.Enabled = true;
            tabPageTaiLieu.PageEnabled = true;
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            save(true);
            this.Close();
        }

        #endregion

        private void leParentCat_EditValueChanged(object sender, EventArgs e)
        {
            if (leParentCat.EditValue != null)
            {
                loadGridPara();
            }            
        }        
        
        private void btnHang_Click(object sender, EventArgs e)
        {
            frmCustomer frm = new frmCustomer();
            frm.HasDialogResult = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                loadHang();
                cboHang.EditValue = Material.CustomerID;
            }
        }

        private void frmMaterial_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_isSaved)
            {
                if (this.LoadDataChange != null)
                {
                    this.LoadDataChange(null, null);
                }
                DialogResult = DialogResult.OK;
            }
        }

        private void grvData_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            loadTreeValue();
        }

        private void btnSaveTS_Click(object sender, EventArgs e)
        {
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();
            try
            {
                //Lưu trữ giá trị thông số
                saveGiaTri(pt);
                _isSaved = true;
                pt.CommitTransaction();
                MessageBox.Show("Lưu trữ thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void btnUpIPT_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "File .ipt|*ipt|All File|*.*";
            ofd.Multiselect = false;
            ofd.InitialDirectory = Settings.Default.TK_IptPath;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Settings.Default.TK_IptPath = Path.GetDirectoryName(ofd.FileName);
                Settings.Default.Save();

                IPTDetail.LoadData(ofd.FileName);

                #region Check Validate
                if (Material.Code.Replace(")", "#").Replace("/", "#") != Path.GetFileNameWithoutExtension(ofd.FileName).Replace(")", "#").Replace("/", "#"))
                {
                    MessageBox.Show("Tên của file ipt không giống Mã vật tư!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (IPTDetail.Code != txtCode.Text.Trim())
                {
                    MessageBox.Show("Mã vật tư trong IProperties không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (IPTDetail.Hang != cboHang.Text)
                {
                    MessageBox.Show("Hãng trong IProperties không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                #endregion

                DocUtils.InitFTPTK();

                ProcessTransaction pt = new ProcessTransaction();
                pt.OpenConnection();
                pt.BeginTransaction();
                try
                {
                    using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang up file..."))
                    {
                        FileInfo fInfo = new FileInfo(ofd.FileName);

                        #region MaterialFile
                        MaterialFileModel fileModel;
                        bool isAdd = true;
                        DataTable dt = TextUtils.Select("select Path, MaterialID, MaterialCode from vMaterialFile with(nolock) where FileType = 0 and MaterialID = "
                            + Material.ID + " and MaterialCode = '" + Path.GetFileNameWithoutExtension(ofd.FileName).Replace(")", "/") + "'");
                        
                        if (dt.Rows.Count > 0)
                        {
                            fileModel = (MaterialFileModel)MaterialFileBO.Instance.FindByAttribute("Name", Path.GetFileName(ofd.FileName))[0];
                            isAdd = false;
                            fileModel.UpdatedDate = TextUtils.GetSystemDate();
                            fileModel.UpdatedBy = Global.AppUserName;
                        }
                        else
                        {
                            fileModel = new MaterialFileModel();
                            fileModel.CreatedDate = TextUtils.GetSystemDate();
                            fileModel.CreatedBy = Global.AppUserName;
                            fileModel.UpdatedDate = Material.CreatedDate;
                            fileModel.UpdatedBy = Global.AppUserName;
                        }

                        fileModel.Extension = Path.GetExtension(ofd.FileName);
                        fileModel.Datemodified = fInfo.LastWriteTime;
                        fileModel.Length = fInfo.Length;
                        fileModel.Name = Path.GetFileName(fInfo.FullName);
                        fileModel.Path = "Materials/" + Path.GetFileName(fInfo.FullName);
                        fileModel.IsDeleted = false;
                        fileModel.FileType = 0;//0 là file 3D cơ khí, 1 là datasheet
                        #endregion

                        if (isAdd)
                        {
                            fileModel.ID = (int)pt.Insert(fileModel);

                            #region Insert MaterialFileLink
                            //Thêm link giữa file với vật tư
                            MaterialFileLinkModel fileLinkModel = new MaterialFileLinkModel();
                            fileLinkModel.MaterialFileID = fileModel.ID;
                            fileLinkModel.MaterialID = Material.ID;
                            pt.Insert(fileLinkModel);
                            #endregion
                        }
                        else
                        {
                            pt.Update(fileModel);

                            #region Update material if value different
                            //if (Material.VL != IPTDetail.VL)
                            //{
                            //    frmCompareIPT frm = new frmCompareIPT();
                            //    frm.OldValue = Material.VL;
                            //    frm.IPTValue = IPTDetail.VL;
                            //    if (frm.ShowDialog() == DialogResult.OK)
                            //    {
                            //        string value = frm.RightValue;
                            //        Material.VL = value;
                            //        pt.Update(Material);

                            //        IPTDetail.GetIproperties(ofd.FileName);
                            //    }
                            //}
                            #endregion
                        }

                        #region write Title into ipt file
                        try
                        {
                            IPTDetail.WriteName(ofd.FileName, Material.Name);
                        }
                        catch (Exception)
                        {
                        }
                        #endregion

                        #region Update Material
                        //Update dữ liệu trong iproperties vào trong vật tư
                        Material.Note = IPTDetail.Note;
                        Material.Unit = IPTDetail.Unit;
                        Material.VL = IPTDetail.VL;
                        Material.MaVatLieu = IPTDetail.MaVatLieu;
                        Material.Properties = IPTDetail.Properties;
                        Material.Author = IPTDetail.Author;

                        pbAnh.InitialImage = null;
                        pbAnh.Image = null;

                        ConfigSystemModel cf = (ConfigSystemModel)ConfigSystemBO.Instance.FindByAttribute("KeyName", "MaterialImagePath")[0];//
                        string imagePath = cf.KeyValue + "\\" + Material.Code.Replace("/", ")") + ".png";
                        Bitmap bit = new Bitmap(IPTDetail.Image, IPTDetail.Image.Width / 3, IPTDetail.Image.Height / 3);
                        bit.Save(imagePath, ImageFormat.Png);

                        Material.ImagePath = imagePath;
                        Material.File3D = 1;
                        pt.Update(Material);
                        #endregion

                        DocUtils.UploadFile(ofd.FileName, "Materials");

                        pt.CommitTransaction();

                        loadIpt();

                        #region Load textbox
                        txtGhiChu.Text = Material.Note;
                        txtDonVi.Text = Material.Unit;
                        txtVatLieu.Text = Material.VL;
                        txtVatTuNguon.Text = Material.MaVatLieu;
                        txtTTGiaCong.Text = Material.Properties;
                        #endregion
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Up file không thành công!" + Environment.NewLine + ex.Message, TextUtils.Caption, 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    pt.CloseConnection();
                }
            }
        }

        private void btnDeleteIpt_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvIPT.RowCount <= 0) return;
                if (MessageBox.Show("Bạn có thật sự muốn xóa file này không?", TextUtils.Caption,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                pbAnh.InitialImage = null;
                pbAnh.Image = null;

                int linkID = TextUtils.ToInt(grvIPT.GetFocusedRowCellValue(colIDipt));
                int materialFileID = TextUtils.ToInt(grvIPT.GetFocusedRowCellValue(colMaterialFileIDipt));

                MaterialFileLinkBO.Instance.Delete(linkID);
                MaterialFileBO.Instance.Delete(materialFileID);

                Material.File3D = 0;
                MaterialBO.Instance.Update(Material);

                loadIpt();

                string filePath = TextUtils.ToString(grvIPT.GetFocusedRowCellValue(colFilePathIPT));
                if (filePath == "") return;
                DocUtils.InitFTPTK();
                DocUtils.DeleteFile(filePath);

                string path = TextUtils.GetConfigValue("MaterialImagePath");
                string imagePath = path + "\\" + TextUtils.ToString(grvIPT.GetFocusedRowCellValue(colFileNameIPT));
                File.Delete(imagePath);
            }
            catch (Exception ex)
            {
                TextUtils.ShowError(ex.Message);
            }
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            frmDatasheet frm = new frmDatasheet();
            frm.ChooseFile = true;
            frm.CustomerID = Material.CustomerID;
            frm.Text += ": " + Material.Code + " - " + Material.Name;
            bool added = false;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                foreach (int item in frm.ListMaterialFileID)
                {
                    ProcessTransaction pt = new ProcessTransaction();
                    pt.OpenConnection();
                    pt.BeginTransaction();
                    try
                    {
                        MaterialFileLinkModel model = new MaterialFileLinkModel();
                        model.MaterialID = Material.ID;
                        model.MaterialFileID = item;
                        pt.Insert(model);

                        added = true;

                        if (added)
                        {
                            //MaterialModel material = (MaterialModel)MaterialBO.Instance.FindByPK(Material.ID);
                            Material.FileDatasheet = 1;
                            pt.Update(Material);
                        }
                        pt.CommitTransaction();
                    }
                    catch (Exception)
                    {
                    }
                    finally
                    {
                        pt.CloseConnection();
                    }                   
                }                

                loadDatasheet();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvDatasheet.RowCount <= 0) return;
                if (MessageBox.Show("Bạn có thật sự muốn xóa file này không?", TextUtils.Caption,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) 
                    return;
                int linkID = TextUtils.ToInt(grvDatasheet.GetFocusedRowCellValue(colIDdatasheet));

                MaterialFileLinkBO.Instance.Delete(linkID);

                Material.FileDatasheet = 0;
                MaterialBO.Instance.Update(Material);

                loadDatasheet();
            }
            catch (Exception ex)
            {
                TextUtils.ShowError(ex.Message);
            }
        }

        private void btnDownloadDatasheet_Click(object sender, EventArgs e)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang download file..."))
            {
                try
                {
                    FolderBrowserDialog fbd = new FolderBrowserDialog();
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                            string filePath = grvDatasheet.GetFocusedRowCellValue(colFilePathDatasheet).ToString();
                            DocUtils.DownloadFile(fbd.SelectedPath, Path.GetFileName(filePath), filePath);
                            MessageBox.Show("Download file thành công!", TextUtils.Caption, MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Download file thành công!\n" + ex.Message, TextUtils.Caption, MessageBoxButtons.OK,
                           MessageBoxIcon.Error);
                }
                
            }
        }

        private void btnDownloadIPT_Click(object sender, EventArgs e)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang download file 3D..."))
            {
                try
                {
                    FolderBrowserDialog fbd = new FolderBrowserDialog();
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = grvIPT.GetFocusedRowCellValue(colFilePathIPT).ToString();
                        DocUtils.DownloadFile(fbd.SelectedPath, Path.GetFileName(filePath), filePath);

                        MessageBox.Show("Download file thành công!", TextUtils.Caption, MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Download file thành công!\n" + ex.Message, TextUtils.Caption, MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }              
            }
        }

        private void copyFileẢnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    File.Copy(Material.ImagePath, fbd.SelectedPath + "//" + Path.GetFileName(Material.ImagePath), true);
                    Process.Start(fbd.SelectedPath + "//" + Path.GetFileName(Material.ImagePath));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("File đang được mở!");
            }
        }
    }
}