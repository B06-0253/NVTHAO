using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Utils;
using BMS.Model;
using BMS.Business;
using BMS;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraTreeList;
using System.Collections;
using System.IO;

namespace BMS
{
    public partial class frmProductManager : _Forms
    {
        int _curentNode = 0;
        int _rownIndex = 0;

        public frmProductManager()
        {
            InitializeComponent();
        }

        private void frmProductManager_Load(object sender, EventArgs e)
        {
            GridLocalizer.Active = new MyGridLocalizer();
            loadTree();
        }

        void loadGrid(bool isFilterGroup)
        {
            try
            {
                int groupID = 0;
                if (isFilterGroup)
                {
                    groupID = TextUtils.ToInt(treeData.FocusedNode.GetValue(colIDTree));
                }

                string[] paraName = new string[3];
                object[] paraValue = new object[3];

                paraName[0] = "@Code"; paraValue[0] = txtCode.Text.Trim();
                paraName[1] = "@Name"; paraValue[1] = txtName.Text.Trim();
                paraName[2] = "@GroupID"; paraValue[2] = groupID;

                DataTable Source = ProductsBO.Instance.LoadDataFromSP("spGetFilterProduct", "Source", paraName, paraValue);
                grdData.DataSource = Source;

                if (_rownIndex >= grvData.RowCount)
                    _rownIndex = 0;
                if (_rownIndex > 0)
                    grvData.FocusedRowHandle = _rownIndex;
                grvData.SelectRow(_rownIndex);
            }
            catch (Exception ex)
            {
                TextUtils.ShowError(ex);
            }
        }

        void loadTree()
        {
            try
            {
                DataTable tbl = TextUtils.Select("Select * from ProductGroup with(nolock) order by Code");
                treeData.DataSource = tbl;
                treeData.KeyFieldName = "ID";
                treeData.PreviewFieldName = "Name";
                treeData.ExpandAll();

                DevExpress.XtraTreeList.Nodes.TreeListNode currentNode = treeData.FindNodeByFieldValue("ID", _curentNode);
                treeData.SetFocusedNode(currentNode);
            }
            catch (Exception ex)
            {
            }
        }

        private void btnNewGroup_Click(object sender, EventArgs e)
        {
            frmProductGroup frm = new frmProductGroup();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _curentNode = frm.CurentNode;
                loadTree();
            }
        }

        private void btnEditGroup_Click(object sender, EventArgs e)
        {
            try
            {
                int id = TextUtils.ToInt(treeData.FocusedNode.GetValue(colIDTree));
                if (id == 0) return;
                ProductGroupModel model = (ProductGroupModel)ProductGroupBO.Instance.FindByPK(id);
                frmProductGroup frm = new frmProductGroup();
                frm.Model = model;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _curentNode = frm.CurentNode;
                    loadTree();
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnDeleteGroup_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeData.DataSource == null) return;
                int id = (int)treeData.Selection[0].GetValue(colIDTree);
                if (id == 0) return;

                if (ProductsBO.Instance.CheckExist("ProductGroupID", id))
                {
                    MessageBox.Show("Nhóm này đang chứa thiết bị nên không thể xóa được.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (MessageBox.Show("Bạn có chắc muốn xóa nhóm [" + treeData.Selection[0].GetValue(colNameTree).ToString() + "] không?",
                      TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                ProductGroupBO.Instance.Delete(id);
                loadTree();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmProduct frm = new frmProduct();
            frm.GroupID = TextUtils.ToInt(treeData.FocusedNode.GetValue(colIDTree));
            if (frm.ShowDialog() == DialogResult.OK)
            {
                loadGrid(true);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            ProductsModel model = (ProductsModel)ProductsBO.Instance.FindByPK(id);
            _rownIndex = grvData.FocusedRowHandle;

            frmProduct frm = new frmProduct();
            frm.Product = model;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                loadGrid(true);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvData.DataSource == null) return;
                int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
                if (id == 0) return;

                if (ProductBaiThucHanhLinkBO.Instance.CheckExist("ProductID", id))
                {
                    MessageBox.Show("Thiết bị này đang chứa bài thực hành nên không thể xóa được.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (ProductModuleLinkBO.Instance.CheckExist("ProductID", id))
                {
                    MessageBox.Show("Thiết bị này đang chứa Module nên không thể xóa được.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (MessageBox.Show("Bạn có chắc muốn xóa thiết bị [" + grvData.GetFocusedRowCellValue(colName).ToString() + "] không?",
                      TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                ProductsBO.Instance.Delete(id);
                loadGrid(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void treeData_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            try
            {
                int id = TextUtils.ToInt(treeData.FocusedNode.GetValue(colIDTree));
                if (id > 0)
                {
                    txtCode.Text = txtName.Text = "";
                    loadGrid(true);
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnFindAll_Click(object sender, EventArgs e)
        {
            loadGrid(false);
        }

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void xemGiáToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            ProductsModel model = (ProductsModel)ProductsBO.Instance.FindByPK(id);

            frmProductPrice frm = new frmProductPrice();
            frm.Product = model;
            TextUtils.OpenForm(frm);
        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadGrid(false);
            }
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

                string ftpFolderPath = "Product\\BaiThucHanh\\" + product.Code + "\\" + versionModel.Version;
                if (!DocUtils.CheckExits(Path.GetDirectoryName(ftpFolderPath)))
                {
                    DocUtils.MakeDir(Path.GetDirectoryName(ftpFolderPath));
                }
                foreach (var item in listFiles)
                {
                    ProductFileModel thisFile = (ProductFileModel)item;
                    string path = Path.GetTempPath();

                    DocUtils.DownloadFile(path, Path.GetFileName(thisFile.Path), thisFile.Path);

                    ProductFileModel file = new ProductFileModel();
                    file.ProductID = product.ID;
                    file.Name = thisFile.Name;
                    file.Length = thisFile.Length;
                    file.LocalPath = path + "\\" + Path.GetFileName(thisFile.Path);
                    file.Path = ftpFolderPath + "\\" + file.Name;
                    file.Version = versionModel.Version;

                    pt.Insert(file);

                    listFilePath.Add(path + "\\" + Path.GetFileName(thisFile.Path));
                }
                #endregion

                product.Version += 1;
                pt.Update(product);

                pt.CommitTransaction();

                MessageBox.Show("Tạo phiên bản bài thực hành thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);

                foreach (string filePath in listFilePath)
                {
                    if (!DocUtils.CheckExits(ftpFolderPath))
                    {
                        DocUtils.MakeDir(ftpFolderPath);
                    }
                    DocUtils.UploadFile(filePath, ftpFolderPath);
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

        private void btnCreateVersion_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            ProductsModel product = (ProductsModel)ProductsBO.Instance.FindByPK(id);

            DialogResult result = MessageBox.Show("Bạn có chắc muốn tạo phiên bản cho sản phẩm [" + product.Name + "] ?", 
                TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;

            string reason = "";
            frmVersionReason frm = new frmVersionReason();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                reason = frm.Reason;
            }
            else
            {
                return;
            }

            createProductVersion(product, reason);

            loadGrid(true);
        }

        private void xemDanhSáchCácPhiênBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            ProductsModel product = (ProductsModel)ProductsBO.Instance.FindByPK(id);

            frmShowListVersion frm = new frmShowListVersion();
            frm.Product = product;
            TextUtils.OpenForm(frm);
        }    
    }
}
