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
using DevExpress.XtraGrid.Localization;
using BMS.Business;
using System.IO;
using System.Collections;

namespace BMS
{
    public partial class frmProduct : _Forms
    {
        public int GroupID;
        public ProductsModel Product = new ProductsModel();
        bool _isSaved = false;

        DataTable dtBaiThucHanhLink = new DataTable();
        DataTable dtModuleLink = new DataTable();

        DataTable dtModule = new DataTable();
        DataTable dtMaterial = new DataTable();
        DataTable dtFile = new DataTable();

        public bool IsShowVersion = false;
        public int Version = 0;

        public frmProduct()
        {
            InitializeComponent();
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            GridLocalizer.Active = new MyGridLocalizer();
            btnModuleHistory.Visible = false;
            DocUtils.InitFTPTK();

            loadGroup();

            loadBaiThucHanh();

            loadGridModule();
            loadGridMaterial();
            loadGridFile();

            if (Product.ID != 0)
            {
                txtName.Text = Product.Name;
                txtCode.Text = Product.Code;
                txtDescription.Text = Product.Description;
                txtTime.Text = Product.Time.ToString();
                txtThongSo.Text = Product.Specifications;

                cboGroup.EditValue = Product.ProductGroupID;
                cboPriod.SelectedText = Product.Priod;

                this.Text = "Sản phẩm: " + Product.Code + "-" + Product.Name;
            }
            else
            {
                cboGroup.EditValue = GroupID;
            }

            if (IsShowVersion)
            {
                toolStripFile.Enabled = toolStripVatTuPhu.Enabled = toolStripModule.Enabled = mnuMenu.Enabled = false;
                btnChooseBTH.Enabled = btnDeleteBTH.Enabled = false;
            }
        }

        DataTable dtResult(int type)
        {
            if (IsShowVersion)
            {
                return TextUtils.Select("Select * from vProductModuleLinkVersion with(nolock) where Type =" + type 
                    + " and ProductID = " + Product.ID 
                    + " and Version = " + Version);
            }
            else
            {
                return TextUtils.Select("Select * from vProductModuleLink with(nolock) where Type =" + type 
                    + " and ProductID = " + Product.ID);
            }
        }

        void loadGridModule()
        {
            dtModule = dtResult(0);
            grdModuleLink.DataSource = dtModule;
        }

        void loadGridMaterial()
        {
            dtMaterial = dtResult(1);
            grdVT.DataSource = dtMaterial;
        }

        void loadGroup()
        {
            DataTable tbl = TextUtils.Select(@"SELECT ID,Code,Code+'-'+Name as Name FROM ProductGroup WITH(NOLOCK) ORDER BY Code");
            if (tbl == null)
            {
                return;
            }
            TextUtils.PopulateCombo(cboGroup, tbl.Copy(), "Name", "ID", "");
        }

        List<string> listBthID = new List<string>();
        void loadBaiThucHanh()
        {
            if (IsShowVersion)
            {
                dtBaiThucHanhLink = TextUtils.Select("Select * from vProductBaiThucHanhLinkVersion where ProductID = " + Product.ID + " and Version = " + Version);
            }
            else
            {
                dtBaiThucHanhLink = TextUtils.Select("Select * from vProductBaiThucHanhLink where ProductID = " + Product.ID);
            }
            grdBTH.DataSource = dtBaiThucHanhLink;

            loadModule();
        }

        void loadModule()
        {
            listBthID.Clear();
            if (dtBaiThucHanhLink.Rows.Count > 0)
            {
                foreach (DataRow item in dtBaiThucHanhLink.Rows)
                {
                    string id = item["BaiThucHanhID"].ToString();
                    if (!listBthID.Contains(id))
                    {
                        listBthID.Add(id);
                    }
                }
                string ids = string.Join(",", listBthID.ToArray());
                dtModuleLink = TextUtils.Select("Select * from vBaiThucHanhModule where [BaiThucHanhID] in (" + ids + ")");
                grdModule.DataSource = dtModuleLink;
            }
            else
            {
                grdModule.DataSource = null;
            }
        }

        void loadGridFile()
        {
            if (IsShowVersion)
            {
                dtFile = TextUtils.Select("select * from ProductFile with(nolock) where ProductID =" + Product.ID + " and Version = " + Version);
            }
            else
            {
                dtFile = TextUtils.Select("select * from ProductFile with(nolock) where ProductID =" + Product.ID + " and Version = " + Product.Version);
            }
            grdFile.DataSource = dtFile;
        }

        bool ValidateForm()
        {
            if (TextUtils.ToInt(cboGroup.EditValue) == 0)
            {
                MessageBox.Show("Xin hãy chọn nhóm.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (txtCode.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền Mã.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
            {
                DataTable dt;
                if (Product.ID > 0)
                {
                    dt = TextUtils.Select("select Code from Products where Code = '" + txtCode.Text.Trim() + "' and ID <> " + Product.ID);
                }
                else
                {
                    dt = TextUtils.Select("select Code from Products where Code = '" + txtCode.Text.Trim() + "'");
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

            if (txtTime.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền thời gian sản xuất.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            //if (grvBTH.RowCount == 0)
            //{
            //    MessageBox.Show("Xin thêm bài thực hành.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return false;
            //}

            return true;
        }

        void createProductVersion(ProductsModel product, string reason)
        {
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();

            try
            {
                #region Tạo phiên bản san phẩm
                ProductVersionModel versionModel = new ProductVersionModel();
                versionModel.ProductID = product.ID;
                versionModel.Reason = reason;
                versionModel.Version = product.Version;
                versionModel.ID = (int)pt.Insert(versionModel);
                #endregion

                #region Tạo phiên bản bài thực hành của sản phẩm
                ArrayList lisBaiThucHanh = ProductBaiThucHanhLinkBO.Instance.FindByAttribute("ProductID", product.ID);
                if (lisBaiThucHanh.Count > 0)
                {
                    foreach (var item in lisBaiThucHanh)
                    {
                        ProductBaiThucHanhLinkModel thisBTH = (ProductBaiThucHanhLinkModel)item;

                        ProductBaiThucHanhLinkVersionModel bthVersion = new ProductBaiThucHanhLinkVersionModel();
                        bthVersion.ProductVersionID = versionModel.ID;
                        bthVersion.BaiThucHanhID = thisBTH.BaiThucHanhID;
                        bthVersion.ID = (int)pt.Insert(bthVersion);
                    }
                }
                #endregion

                #region Tạo các phiên bản module sản phẩm
                ArrayList lisModules = ProductModuleLinkBO.Instance.FindByAttribute("ProductID", product.ID);
                if (lisModules.Count > 0)
                {
                    foreach (var item in lisModules)
                    {
                        ProductModuleLinkModel thisModule = (ProductModuleLinkModel)item;

                        ProductModuleLinkVersionModel moduleVersion = new ProductModuleLinkVersionModel();
                        moduleVersion.ProductVersionID = versionModel.ID;
                        moduleVersion.Code = thisModule.Code;
                        moduleVersion.CVersion = thisModule.CVersion;
                        moduleVersion.Hang = thisModule.Hang;
                        moduleVersion.Name = thisModule.Name;
                        moduleVersion.Qty = thisModule.Qty;
                        moduleVersion.Type = thisModule.Type;
                        moduleVersion.ID = (int)pt.Insert(moduleVersion);
                    }
                }
                #endregion

                pt.CommitTransaction();

                MessageBox.Show("Tạo phiên bản bài thực hành thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                pt.CloseConnection();
            }
        }

        void createProductVersion1(ProductsModel product, string reason)
        {
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();

            try
            {
                #region Tạo phiên bản san phẩm
                ProductVersionModel versionModel = new ProductVersionModel();
                versionModel.ProductID = product.ID;
                versionModel.Reason = reason;
                versionModel.Version = product.Version + 1;
                versionModel.ID = (int)pt.Insert(versionModel);
                #endregion

                #region Tạo phiên bản bài thực hành của sản phẩm
                ArrayList lisBaiThucHanh = ProductBaiThucHanhLinkBO.Instance.FindByAttribute("ProductID", product.ID);
                if (lisBaiThucHanh.Count > 0)
                {
                    foreach (var item in lisBaiThucHanh)
                    {
                        ProductBaiThucHanhLinkModel thisBTH = (ProductBaiThucHanhLinkModel)item;

                        ProductBaiThucHanhLinkVersionModel bthVersion = new ProductBaiThucHanhLinkVersionModel();
                        bthVersion.ProductVersionID = versionModel.ID;
                        bthVersion.BaiThucHanhID = thisBTH.BaiThucHanhID;
                        bthVersion.ID = (int)pt.Insert(bthVersion);
                    }
                }
                #endregion

                #region Tạo các phiên bản module sản phẩm
                ArrayList lisModules = ProductModuleLinkBO.Instance.FindByAttribute("ProductID", product.ID);
                if (lisModules.Count > 0)
                {
                    foreach (var item in lisModules)
                    {
                        ProductModuleLinkModel thisModule = (ProductModuleLinkModel)item;

                        ProductModuleLinkVersionModel moduleVersion = new ProductModuleLinkVersionModel();
                        moduleVersion.ProductVersionID = versionModel.ID;
                        moduleVersion.Code = thisModule.Code;
                        moduleVersion.CVersion = thisModule.CVersion;
                        moduleVersion.Hang = thisModule.Hang;
                        moduleVersion.Name = thisModule.Name;
                        moduleVersion.Qty = thisModule.Qty;
                        moduleVersion.Type = thisModule.Type;
                        moduleVersion.ID = (int)pt.Insert(moduleVersion);
                    }
                }
                #endregion

                #region Tạo phiên bản các file
                List<string> listFilePath = new List<string>();
                ArrayList listFiles = ProductFileBO.Instance.FindByExpression(new Expression("ProductID", product.ID)
                    .And(new Expression("Version", product.Version)));

                string ftpFolderPath = "Product\\File\\" + product.Code + "\\" + versionModel.Version;
                if (!DocUtils.CheckExits(Path.GetDirectoryName(ftpFolderPath)))
                {
                    DocUtils.MakeDir(Path.GetDirectoryName(ftpFolderPath));
                }
                foreach (var item in listFiles)
                {
                    ProductFileModel thisFile = (ProductFileModel)item;
                    string path = "D:";

                    DocUtils.DownloadFile(path, Path.GetFileName(thisFile.Path), thisFile.Path);

                    ProductFileModel file = new ProductFileModel();
                    file.ProductID = product.ID;
                    file.Name = thisFile.Name;
                    file.Length = thisFile.Length;
                    file.LocalPath = path + "\\" + Path.GetFileName(thisFile.Path);
                    file.Path = ftpFolderPath + "\\" + file.Name;
                    file.Version = versionModel.Version;

                    pt.Insert(file);

                    //if (!DocUtils.CheckExits(ftpFolderPath))
                    //{
                    //    DocUtils.MakeDir(ftpFolderPath);
                    //}
                    //DocUtils.UploadFile(file.LocalPath, ftpFolderPath);
                    listFilePath.Add(file.LocalPath);
                }
                #endregion

                product.Version += 1;
                pt.Update(product);

                pt.CommitTransaction();

                foreach (string filePath in listFilePath)
                {
                    if (!DocUtils.CheckExits(ftpFolderPath))
                    {
                        DocUtils.MakeDir(ftpFolderPath);
                    }
                    DocUtils.UploadFile(filePath, ftpFolderPath);
                    File.Delete(filePath);
                }
                
                MessageBox.Show("Tạo phiên bản bài thực hành thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                pt.CloseConnection();
            }
        }

        void save(bool close)
        {
           
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();
            bool isAdd = false;
            try
            {
                if (!ValidateForm())
                    return;

                Product.ProductGroupID = TextUtils.ToInt(cboGroup.EditValue);

                Product.Name = txtName.Text.Trim().ToUpper();
                Product.Code = txtCode.Text.Trim().ToUpper();
                Product.Description = txtDescription.Text.Trim();
                Product.Time = TextUtils.ToDecimal(txtTime.Text.Trim());
                Product.Priod = cboPriod.Text;
                Product.Specifications = txtThongSo.Text.Trim();

                if (Product.ID == 0)
                {
                    isAdd = true;
                    Product.Version = 0;
                    Product.ID = (int)pt.Insert(Product);
                }
                else
                {
                    DialogResult result = MessageBox.Show("Bạn có muốn tạo phiên bản cho sản phẩm này trước khi ghi?", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        string reason = "";
                        frmVersionReason frm = new frmVersionReason();
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            reason = frm.Reason;
                            createProductVersion1(Product, reason);
                        }                        
                    }
                    pt.Update(Product);
                }

                #region Bai thực hành
                for (int i = 0; i < grvBTH.RowCount; i++)
                {
                    if (TextUtils.ToInt(grvBTH.GetRowCellValue(i, colBID)) == 0) continue;
                    try
                    {
                        int id = TextUtils.ToInt(grvBTH.GetRowCellValue(i, colID));
                        ProductBaiThucHanhLinkModel link;
                        if (id == 0)
                        {
                            link = new ProductBaiThucHanhLinkModel();
                        }
                        else
                        {
                            link = (ProductBaiThucHanhLinkModel)ProductBaiThucHanhLinkBO.Instance.FindByPK(id);
                        }

                        link.BaiThucHanhID = TextUtils.ToInt(grvBTH.GetRowCellValue(i, colBID));
                        link.ProductID = Product.ID;

                        if (id == 0)
                        {
                            pt.Insert(link);
                        }
                        else
                        {
                            pt.Update(link);
                        }
                    }
                    catch
                    {

                    }
                }
                #endregion

                #region Module
                //for (int i = 0; i < grvModule.RowCount; i++)
                //{
                //    if (TextUtils.ToInt(grvModule.GetRowCellValue(i, colModuleBTHID)) == 0) continue;
                //    try
                //    {
                //        int id = TextUtils.ToInt(grvModule.GetRowCellValue(i, colLinkID));
                //        ProductModuleLinkModel link;
                //        if (id == 0)
                //        {
                //            link = new ProductModuleLinkModel();
                //        }
                //        else
                //        {
                //            link = (ProductModuleLinkModel)ProductModuleLinkBO.Instance.FindByPK(id);
                //        }

                //        link.ProductID = Product.ID;
                //        link.BaiThucHanhID = TextUtils.ToInt(grvModule.GetRowCellValue(i, colModuleBTHID));
                //        link.ModuleCode = grvModule.GetRowCellValue(i, colModuleCode).ToString();

                //        if (id == 0)
                //        {
                //            pt.Insert(link);
                //        }
                //        else
                //        {
                //            pt.Update(link);
                //        }
                //    }
                //    catch
                //    {

                //    }                    
                //}
                #endregion

                #region Module chính
                for (int i = 0; i < grvModuleLink.RowCount; i++)
                {
                    int id = TextUtils.ToInt(grvModuleLink.GetRowCellValue(i, colMID));
                    ProductModuleLinkModel link;
                    if (id == 0)
                    {
                        link = new ProductModuleLinkModel();
                    }
                    else
                    {
                        link = (ProductModuleLinkModel)ProductModuleLinkBO.Instance.FindByPK(id);
                    }

                    link.ProductID = Product.ID;
                    link.Hang = grvModuleLink.GetRowCellValue(i, colMHang).ToString();
                    link.Code = grvModuleLink.GetRowCellValue(i, colMCode).ToString();
                    link.Name = grvModuleLink.GetRowCellValue(i, colMName).ToString();
                    link.Qty = TextUtils.ToInt(grvModuleLink.GetRowCellValue(i, colMQty));
                    link.Type = 0;
                    link.CVersion = TextUtils.ToInt(grvModuleLink.GetRowCellValue(i, colMCVersion));

                    if (id == 0)
                    {
                        link.ID = (int)pt.Insert(link);
                    }
                    else
                    {
                        pt.Update(link);
                    }
                }
                #endregion

                #region Vật tư phụ
                for (int i = 0; i < grvVT.RowCount; i++)
                {
                    int id = TextUtils.ToInt(grvVT.GetRowCellValue(i, colMaID));
                    ProductModuleLinkModel link;
                    if (id == 0)
                    {
                        link = new ProductModuleLinkModel();
                    }
                    else
                    {
                        link = (ProductModuleLinkModel)ProductModuleLinkBO.Instance.FindByPK(id);
                    }

                    link.ProductID = Product.ID;
                    link.Hang = grvVT.GetRowCellValue(i, colMaHang).ToString();
                    link.Code = grvVT.GetRowCellValue(i, colMaCode).ToString();
                    link.Name = grvVT.GetRowCellValue(i, colMaName).ToString();
                    link.Qty = TextUtils.ToInt(grvVT.GetRowCellValue(i, colMaQty));
                    link.Type = 1;
                    link.CVersion = TextUtils.ToInt(grvVT.GetRowCellValue(i, colMaCVersion));

                    if (id == 0)
                    {
                        pt.Insert(link);
                    }
                    else
                    {
                        pt.Update(link);
                    }
                }
                #endregion

                #region File
                string ftpFolderPath = "Product\\File\\" + Product.Code + "\\" + Product.Version;
                if (!DocUtils.CheckExits(Path.GetDirectoryName(ftpFolderPath)))
                {
                    DocUtils.MakeDir(Path.GetDirectoryName(ftpFolderPath));
                }
                List<string> listFilePath = new List<string>();
                for (int i = 0; i < grvFile.RowCount; i++)
                {
                    int id = TextUtils.ToInt(grvFile.GetRowCellValue(i, colFileID));
                    if (id == 0)
                    {
                        ProductFileModel file = new ProductFileModel();
                        file.ProductID = Product.ID;
                        file.Name = grvFile.GetRowCellValue(i, colFileName).ToString();
                        file.Length = TextUtils.ToDecimal(grvFile.GetRowCellValue(i, colFileSize).ToString());
                        file.LocalPath = grvFile.GetRowCellValue(i, colFileLocalPath).ToString();
                        file.Path = ftpFolderPath + "\\" + Path.GetFileName(file.LocalPath);
                        file.Version = Product.Version;

                        pt.Insert(file);

                        listFilePath.Add(file.LocalPath);
                    }
                }
                #endregion

                pt.CommitTransaction();

                if (listFilePath.Count > 0)
                {
                    foreach (string filePath in listFilePath)
                    {
                        if (!DocUtils.CheckExits(ftpFolderPath))
                        {
                            DocUtils.MakeDir(ftpFolderPath);
                        }
                        DocUtils.UploadFile(filePath, ftpFolderPath);
                    }
                }

                //if (isAdd)
                //{
                //    createProductVersion(Product, "Tạo phiên bản đầu tiên");
                //}

                _isSaved = true;

                if (close)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    loadBaiThucHanh();
                    loadGridMaterial();
                    loadGridModule();
                    loadGridFile();
                    MessageBox.Show("Lưu trữ thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                pt.CloseConnection();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save(false);
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            save(true);
        }

        private void frmProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_isSaved)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void btnChooseBTH_Click(object sender, EventArgs e)
        {
            frmBaiThucHanhManger frm = new frmBaiThucHanhManger();
            frm.IsSelectedForm = true;
            frm.DtBaiThucHanh = dtBaiThucHanhLink;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                grdBTH.DataSource = dtBaiThucHanhLink;
                loadModule();
            }
        }

        private void btnDeleteBTH_Click(object sender, EventArgs e)
        {
            if (grvBTH.DataSource == null) return;
            int id = TextUtils.ToInt(grvBTH.GetFocusedRowCellValue(colID));
            int bID = TextUtils.ToInt(grvBTH.GetFocusedRowCellValue(colBID));

            if (MessageBox.Show("Bạn có chắc muốn xóa bài thực hành [" + grvBTH.GetFocusedRowCellValue(colBName).ToString() + "] này không?", TextUtils.Caption,
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (id > 0)
                    {
                        ProductBaiThucHanhLinkBO.Instance.Delete(id);
                    }
                    grvBTH.DeleteRow(grvBTH.FocusedRowHandle);

                    loadBaiThucHanh();
                    //loadModule();
                }
                catch
                {
                    MessageBox.Show("Có lỗi xảy ra khi thực hiện thao tác, xin vui lòng thử lại sau.");
                }
            }
        }

        private void btnAddModule_Click(object sender, EventArgs e)
        {
            frmListModules frm = new frmListModules();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                foreach (DataRow row in frm.dtSeleted.Rows)
                {
                    DataRow[] rows = dtModule.Select("Code = '" + row["Code"].ToString() + "'");
                    if (rows.Count() > 0) continue;

                    DataRow dr = dtModule.NewRow();
                    dr["ID"] = 0;
                    dr["ProductID"] = Product.ID;
                    dr["Code"] = row["Code"].ToString();
                    dr["Name"] = row["Name"].ToString();
                    dr["Qty"] = 1;
                    dr["Hang"] = row["Hang"].ToString();
                    dr["Type"] = 0;
                    dr["CVersion"] = row["CVersion"].ToString();
                    dr["NVersion"] = row["NVersion"].ToString();
                    dtModule.Rows.Add(dr);
                }

                grdModule.DataSource = dtModule;
            }
        }

        private void btnDeleteModule_Click(object sender, EventArgs e)
        {
            int iD = TextUtils.ToInt(grvModuleLink.GetFocusedRowCellValue(colMID));
            //string moduleCode = grvModule.GetFocusedRowCellValue(colMCode).ToString();
            if (MessageBox.Show("Bạn có chắc muốn xóa module này không?", TextUtils.Caption,
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (iD > 0)
                    {
                        ProductModuleLinkBO.Instance.Delete(iD);
                    }
                    grvModuleLink.DeleteRow(grvModuleLink.FocusedRowHandle);
                }
                catch
                {
                    MessageBox.Show("Có lỗi xảy ra khi thực hiện thao tác, xin vui lòng thử lại sau.");
                }
            }
        }

        private void btnAddVT_Click(object sender, EventArgs e)
        {
            frmListMaterial frm = new frmListMaterial();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                foreach (DataRow row in frm.dtAll.Rows)
                {
                    DataRow[] rows = dtMaterial.Select("Code = '" + row["Code"].ToString() + "'");
                    if (rows.Count() > 0) continue;

                    DataRow dr = dtMaterial.NewRow();
                    dr["ID"] = 0;
                    dr["ProductID"] = Product.ID;
                    dr["Code"] = row["Code"].ToString();
                    dr["Name"] = row["Name"].ToString();
                    dr["Qty"] = 1;
                    dr["Hang"] = row["Hang"].ToString();
                    dr["Type"] = 1;
                    //if (row["Code"].ToString().StartsWith("TPAD"))
                    //{
                    //    DataTable dt = TextUtils.Select("SELECT ISNULL(MAX(Version), 0) FROM dbo.ModuleVersion WHERE (ModuleCode = '" + row["Code"].ToString() + "')");
                    //    dr["CVersion"] = dt.Rows.Count > 0 ? dt.Rows[0][0].ToString() : "0";
                    //    dr["NVersion"] = dr["CVersion"];
                    //}
                    //else
                    //{
                    //    dr["CVersion"] = "0";
                    //    dr["NVersion"] = "0";
                    //}
                    dr["CVersion"] = row["CVersion"].ToString();
                    dr["NVersion"] = row["NVersion"].ToString();
                    dtMaterial.Rows.Add(dr);

                    //dtMaterial.Rows.Add(0, BaiThucHanh.ID, row["Code"].ToString(), row["Name"].ToString(), 1, row["Hang"].ToString(), 1);
                }

                grdVT.DataSource = dtMaterial;
            }
        }

        private void btnDeleteVT_Click(object sender, EventArgs e)
        {
            int iD = TextUtils.ToInt(grvVT.GetFocusedRowCellValue(colMaID));
            if (MessageBox.Show("Bạn có chắc muốn xóa vật tư này không?", TextUtils.Caption,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (iD > 0)
                    {
                        ProductModuleLinkBO.Instance.Delete(iD);
                    }
                    grvVT.DeleteRow(grvVT.FocusedRowHandle);
                }
                catch
                {
                    MessageBox.Show("Có lỗi xảy ra khi thực hiện thao tác, xin vui lòng thử lại sau.");
                }
            }
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (string filePath in ofd.FileNames)
                {
                    FileInfo fInfo = new FileInfo(filePath);
                    DataRow[] rows = dtFile.Select("Name = '" + fInfo.Name + "'");
                    if (rows.Count() > 0) continue;
                    dtFile.Rows.Add(0, 0, fInfo.Name, fInfo.Length, "", fInfo.FullName);
                    grdFile.DataSource = dtFile;
                }
            }
        }

        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            int iD = TextUtils.ToInt(grvFile.GetFocusedRowCellValue(colFileID));
            
            if (MessageBox.Show("Bạn có chắc muốn xóa file này không?", TextUtils.Caption,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (iD > 0)
                    {
                        string path = grvFile.GetFocusedRowCellValue(colFilePath).ToString();
                        ProductFileBO.Instance.Delete(iD);
                        try
                        {
                            if (DocUtils.CheckExits(path))
                            {
                                DocUtils.DeleteFile(path);
                            }
                        }
                        catch
                        {
                        }
                    }

                    grvFile.DeleteRow(grvFile.FocusedRowHandle);
                }
                catch
                {
                    MessageBox.Show("Có lỗi xảy ra khi thực hiện thao tác, xin vui lòng thử lại sau.");
                }
            }
        }
    }
}
