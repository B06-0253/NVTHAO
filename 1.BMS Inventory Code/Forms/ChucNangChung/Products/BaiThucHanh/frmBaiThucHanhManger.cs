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
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraTreeList;
using BMS.Utils;
using System.Collections;
using System.IO;

namespace BMS
{
    public partial class frmBaiThucHanhManger : _Forms
    {
        int _curentNode = 0;
        int _rownIndex = 0;
        int _groupID = 0;
        public bool IsSelectedForm = false;

        public DataTable DtBaiThucHanh;
        public DataTable DtModule;

        public frmBaiThucHanhManger()
        {
            InitializeComponent();
        }

        private void frmBaiThucHanhManger_Load(object sender, EventArgs e)
        {
            btnSelect.Visible = IsSelectedForm;
            grvData.OptionsSelection.MultiSelect = IsSelectedForm;
            
            GridLocalizer.Active = new MyGridLocalizer();
            loadTree();
            DocUtils.InitFTPTK();
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
                paraName[0] = "@Code"; paraValue[0] = txtFindWord.Text.Trim();
                paraName[1] = "@Name"; paraValue[1] = txtFindWord.Text.Trim();
                paraName[2] = "@GroupID"; paraValue[2] = groupID;

                DataTable Source = MaterialBO.Instance.LoadDataFromSP("spGetFilterBaiThucHanh", "Source", paraName, paraValue);
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
                DataTable tbl = TextUtils.Select("Select * from BaiThucHanhGroup with(nolock) order by Code");
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
            frmBaiTHGroup frm = new frmBaiTHGroup();
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
                BaiThucHanhGroupModel model = (BaiThucHanhGroupModel)BaiThucHanhGroupBO.Instance.FindByPK(id);
                frmBaiTHGroup frm = new frmBaiTHGroup();
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

                if (BaiThucHanhBO.Instance.CheckExist("GroupID", id))
                {
                    MessageBox.Show("Nhóm này đang được sử dụng nên không thể xóa được.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (MessageBox.Show("Bạn có chắc muốn xóa nhóm [" + treeData.Selection[0].GetValue(colNameTree).ToString() + "] không?",
                      TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                BaiThucHanhGroupBO.Instance.Delete(id);
                loadTree();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {            
            frmBaiTHDetail frm = new frmBaiTHDetail();
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
            BaiThucHanhModel model = (BaiThucHanhModel)BaiThucHanhBO.Instance.FindByPK(id);
            _rownIndex = grvData.FocusedRowHandle;

            frmBaiTHDetail frm = new frmBaiTHDetail();
            frm.BaiThucHanh = model;
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

                if (BaiThucHanhModuleBO.Instance.CheckExist("BaiThucHanhID", id))
                {
                    MessageBox.Show("Bài thực hành này đang chứa module hoặc vật tư phụ nên không thể xóa được.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (ProductBaiThucHanhLinkBO.Instance.CheckExist("BaiThucHanhID", id))
                {
                    MessageBox.Show("Có thiết bị, sản phẩm đang chứa bài thực hành này nên không thể xóa được.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (MessageBox.Show("Bạn có chắc muốn xóa bài thực hành [" + grvData.GetFocusedRowCellValue(colName).ToString() + "] không?",
                      TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                BaiThucHanhBO.Instance.Delete(id);
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
                    txtFindWord.Text = "";
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

        private void btnShowPrice_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            BaiThucHanhModel model = (BaiThucHanhModel)BaiThucHanhBO.Instance.FindByPK(id);
            frmBaiThucHanhPrice frm = new frmBaiThucHanhPrice();
            frm.BaiThucHanh = model;
            TextUtils.OpenForm(frm);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            foreach (int i in grvData.GetSelectedRows())
            {
                int id = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                DataRow[] drs = DtBaiThucHanh.Select("BaiThucHanhID = " + id);
                if (drs.Count() == 0)
                {
                    DataRow dr = DtBaiThucHanh.NewRow();
                    dr["BaiThucHanhID"] = id;
                    dr["Code"] = grvData.GetRowCellValue(i, colCode).ToString();
                    dr["Name"] = grvData.GetRowCellValue(i, colName).ToString();
                    dr["Time"] = grvData.GetRowCellValue(i, colTime).ToString();
                    DtBaiThucHanh.Rows.Add(dr);
                }
            }
            this.DialogResult = DialogResult.OK;
        }

        void CreateVersion(BaiThucHanhModel BaiThucHanh, string reason)
        {
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();

            try
            {
                #region Tạo phiên bản bài thực hành
                BaiThucHanhVersionModel versionModel = new BaiThucHanhVersionModel();
                versionModel.BaiThucHanhID = BaiThucHanh.ID;
                versionModel.Reason = reason;
                versionModel.Version = BaiThucHanh.Version + 1;
                versionModel.ID = (int)pt.Insert(versionModel);
                #endregion

                #region Tạo các phiên bản module bài thực hành
                ArrayList lisModules = BaiThucHanhModuleBO.Instance.FindByAttribute("BaiThucHanhID", BaiThucHanh.ID);
                if (lisModules.Count > 0)
                {
                    foreach (var item in lisModules)
                    {
                        BaiThucHanhModuleModel thisModule = (BaiThucHanhModuleModel)item;

                        BaiThucHanhModuleVersionModel moduleVersion = new BaiThucHanhModuleVersionModel();
                        moduleVersion.BTHVersionID = versionModel.ID;
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
                ArrayList listFiles = BaiThucHanhFileBO.Instance.FindByExpression(new Expression("BaiThucHanhID", BaiThucHanh.ID)
                    .And(new Expression("Version", BaiThucHanh.Version)));

                string ftpFolderPath = "BieuMau\\BaiThucHanh\\" + BaiThucHanh.Code + "\\" + versionModel.Version;
                if (!DocUtils.CheckExits(Path.GetDirectoryName(ftpFolderPath)))
                {
                    DocUtils.MakeDir(Path.GetDirectoryName(ftpFolderPath));
                }
                foreach (var item in listFiles)
                {
                    BaiThucHanhFileModel thisFile = (BaiThucHanhFileModel)item;
                    string path = Path.GetTempPath();

                    DocUtils.DownloadFile(path, Path.GetFileName(thisFile.Path), thisFile.Path);

                    BaiThucHanhFileModel file = new BaiThucHanhFileModel();
                    file.BaiThucHanhID = BaiThucHanh.ID;
                    file.Name = thisFile.Name;
                    file.Length = thisFile.Length;
                    file.LocalPath = path + "\\" + Path.GetFileName(thisFile.Path);
                    file.Path = ftpFolderPath + "\\" + file.Name;
                    file.Version = versionModel.Version;

                    pt.Insert(file);

                    listFilePath.Add(path + "\\" + Path.GetFileName(thisFile.Path));
                }
                #endregion

                BaiThucHanh.Version += 1;
                pt.Update(BaiThucHanh);

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
            BaiThucHanhModel BaiThucHanh = (BaiThucHanhModel)BaiThucHanhBO.Instance.FindByPK(id);

            DialogResult result = MessageBox.Show("Bạn có chắc muốn tạo phiên bản cho bài thực hành [" + BaiThucHanh.Name + "] ?", TextUtils.Caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
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

            CreateVersion(BaiThucHanh, reason);

            loadGrid(true);
        }

        private void btnShowListVersion_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            BaiThucHanhModel model = (BaiThucHanhModel)BaiThucHanhBO.Instance.FindByPK(id);

            frmShowListVersion frm = new frmShowListVersion();
            frm.BaiThucHanh = model;
            TextUtils.OpenForm(frm);
        }
    }
}
