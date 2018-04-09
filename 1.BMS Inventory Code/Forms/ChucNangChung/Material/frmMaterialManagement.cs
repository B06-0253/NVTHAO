using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Localization;
using BMS.Utils;
using BMS.Business;
using System.Threading;
using BMS.Model;
using DevExpress.XtraTreeList;
using DevExpress.Utils;
using System.Diagnostics;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections;
using DevExpress.XtraGrid.Views.Grid;

namespace BMS
{
    public partial class frmMaterialManagement : _Forms
    {
        #region Variables
        int _curentNode = 0;
        frmCshLoading frmLoad = null;
        Thread thSearch = null;
        int _rownIndex = 0;
        int _catID = 0;
        string[] paraName = new string[3];
        object[] paraValue = new object[3];
        int _nodeTree = 0;
        #endregion

        public frmMaterialManagement()
        {
            InitializeComponent();
        }

        private void frmMaterialManagement_Load(object sender, EventArgs e)
        {
            DocUtils.InitFTPQLSX();
            repositoryItemCheckEdit1.ValueChecked = 1;
            repositoryItemCheckEdit1.ValueUnchecked = 0;
            GridLocalizer.Active = new NVGridLocalizer();
            colIsUse.ColumnEdit = repositoryItemCheckEdit1;

            loadTree();
        }

        #region Methods
        void createYC(int groupId, string groupCode, string groupName)
        {
            DataTable dtThongSo = TextUtils.Select("select * from [MaterialParameters] with(nolock) where [MaterialGroupID] = " + groupId);
            string localPath = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                localPath = fbd.SelectedPath + "\\TP-TT13-BM11 - Yêu cầu tạo mã vật tư - LSD 01.xlsx";
            }
            else
            {
                return;
            }

            string filePath = Application.StartupPath + "\\Templates\\TP-TT13-BM11 - Yêu cầu tạo mã vật tư - LSD 01.xlsx";

            try
            {
                File.Copy(filePath, localPath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: File excel đang được mở.");
                return;
            }

            string materialCode = "";
            string materialName = "";
            string hang = "";

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "File .ipt|*ipt|All File|*.*";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                IPTDetail.LoadData(ofd.FileName);
                materialCode = IPTDetail.Code;
                materialName = IPTDetail.Name;
                hang = IPTDetail.Hang;
            }

            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo biểu mẫu..."))
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                Excel.Application app = default(Excel.Application);
                Excel.Workbook workBoook = default(Excel.Workbook);
                Excel.Worksheet workSheet = default(Excel.Worksheet);
                try
                {
                    app = new Excel.Application();
                    app.Workbooks.Open(localPath);
                    workBoook = app.Workbooks[1];
                    workSheet = (Excel.Worksheet)workBoook.Worksheets[1];

                    workSheet.Cells[12, 4] = "Hà Nội, Ngày " + string.Format("{0:00}", DateTime.Now.Day)
                        + " tháng " + string.Format("{0:00}", DateTime.Now.Month)
                        + " năm " + DateTime.Now.Year;

                    workSheet.Cells[5, 2] = groupName;
                    workSheet.Cells[6, 2] = groupCode;

                    int rowCountMo = dtThongSo.Rows.Count;
                    if (rowCountMo > 0)
                    {
                        for (int i = rowCountMo - 1; i >= 0; i--)
                        {
                            ((Excel.Range)workSheet.Rows[11]).Insert();
                            workSheet.Cells[11, 4] = dtThongSo.Rows[i]["Name"].ToString();
                        }
                    }

                    workSheet.Cells[11, 1] = materialName;
                    workSheet.Cells[11, 2] = materialCode;
                    workSheet.Cells[11, 3] = hang;

                    ((Excel.Range)workSheet.Rows[10]).Delete();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (app != null)
                    {
                        app.ActiveWorkbook.Save();
                        app.Workbooks.Close();
                        app.Quit();
                    }
                }
                Process.Start(localPath);
            }
        }

        void loaData(int type = 0)
        {
            grvData.ActiveFilterString = "";
            grvData.HideFindPanel();
            LoadInfoSearch(type);
            grvData.ShowFindPanel();
        }

        void LoadInfoSearch(int type = 0)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load danh sách vật tư..."))
            {
                try
                {
                    if (type == 0)
                    {
                        _catID = TextUtils.ToInt(treeData.FocusedNode.GetValue(colIDTree));
                    }
                    else
                    {
                        _catID = 0;
                    }
                    paraName[0] = "@MaterialGroupID"; paraValue[0] = _catID;
                    paraName[1] = "@Code"; paraValue[1] = txtCode.Text.Trim();
                    paraName[2] = "@Name"; paraValue[2] = txtName.Text.Trim();

                    DataTable Source = MaterialBO.Instance.LoadDataFromSP("spGetFilterMaterial", "Source", paraName, paraValue);

                    Source.Columns.Add("Image", typeof(Image));
                    foreach (DataRow item in Source.Rows)
                    {
                        try
                        {
                            string filePath = TextUtils.ToString(item["ImagePath"]);
                            //item["Image"] = Image.FromFile(filePath);

                            Image img = null;
                            using (Image imgTmp = Image.FromFile(filePath))
                            {
                                img = new Bitmap(imgTmp.Width, imgTmp.Height, imgTmp.PixelFormat);
                                Graphics gdi = Graphics.FromImage(img);
                                gdi.DrawImageUnscaled(imgTmp, 0, 0);
                                gdi.Dispose();
                                imgTmp.Dispose(); // just to make sure

                                item["Image"] = img;
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }

                    grdData.DataSource = Source;
                    if (_rownIndex >= grvData.RowCount)
                        _rownIndex = 0;
                    if (_rownIndex > 0)
                        grvData.FocusedRowHandle = _rownIndex;
                    grvData.SelectRow(_rownIndex);
                    grvData.BestFitColumns();
                }
                catch (Exception ex)
                {
                    return;
                }
            }
        }

        void loadTree()
        {
            try
            {
                DataTable tbl = new DataTable();
                if (txtGroupName.Text.Trim()=="")
                {
                    tbl = TextUtils.Select("Select * from MaterialGroup with(nolock) order by Code");
                }
                else
                {
                    tbl = TextUtils.Select("Select * from MaterialGroup with(nolock) where Name like N'%" + txtGroupName.Text.Trim() + "%' order by Code");
                }                

                //DataRow row = tbl.NewRow();
                //row["ID"] = 0;
                //row["Code"] = "All";
                //tbl.Rows.InsertAt(row, 0);

                treeData.DataSource = tbl;
                treeData.KeyFieldName = "ID";
                treeData.PreviewFieldName = "Name";
                //treeData.ExpandAll();

                DevExpress.XtraTreeList.Nodes.TreeListNode currentNode = treeData.FindNodeByFieldValue("ID", _curentNode);
                treeData.SetFocusedNode(currentNode);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        #endregion       

        #region Material Group
        private void btnNewGroup_Click(object sender, EventArgs e)
        {
            frmMaterialGroup frm = new frmMaterialGroup();
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

                //if (MaterialBO.Instance.CheckExist("MaterialGroupID", id))
                //{
                //    MessageBox.Show("Nhóm Vật tư này đang được sử dụng nên không thể sửa được.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //    return;
                //}

                MaterialGroupModel model = (MaterialGroupModel)MaterialGroupBO.Instance.FindByPK(id);
                frmMaterialGroup frm = new frmMaterialGroup();
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

                if (MaterialGroupBO.Instance.CheckExist("ParentID", id))
                {
                    MessageBox.Show("Nhóm Vật tư này đang chứa nhóm con nên không thể xóa được.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (MaterialBO.Instance.CheckExist("MaterialGroupID", id))
                {
                    MessageBox.Show("Nhóm Vật tư này đang chứa vật tư nên không thể xóa được.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (MessageBox.Show("Bạn có chắc muốn xóa nhóm [" + treeData.Selection[0].GetValue(colNameTree).ToString() + "] không?",
                      TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                MaterialGroupBO.Instance.Delete(id);
                loadTree();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion Material Group

        #region Material
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(treeData.FocusedNode.GetValue(colIDTree));
            DataTable dt = TextUtils.Select("select * from MaterialGroup where ParentID = " + id);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Không thể thêm vật tư vào nhóm chính!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            } 
            frmMaterial frm = new frmMaterial();
            frm.GroupID = id;
            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    LoadInfoSearch();
            //}
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }      

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            MaterialModel model = (MaterialModel)MaterialBO.Instance.FindByPK(id);            
            _rownIndex = grvData.FocusedRowHandle;
            frmMaterial frm = new frmMaterial();
            frm.GroupID = model.MaterialGroupID;
            frm.Material = model;
            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    LoadInfoSearch();
            //}
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();
            try
            {
                if (grvData.DataSource == null) return;
                int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
                if (id == 0) return;

                if (MaterialFileLinkBO.Instance.CheckExist("MaterialID", id))
                {
                    if (MessageBox.Show("Vật tư [" + grvData.GetFocusedRowCellValue(colName).ToString() + "] đang liên kết với các file thư viện.\n Bạn có thật sự muốn xóa nó không?", 
                        TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.No) 
                    return;
                    DataTable dt = TextUtils.Select("select Path,MaterialID,MaterialCode from vMaterialFile with(nolock) where FileType = 0 and MaterialID = " + id);
                    if (dt.Rows.Count > 0)
                    {
                        DocUtils.InitFTPTK();
                        DocUtils.DeleteFile(dt.Rows[0][0].ToString());
                    }
                    pt.Delete("Material", id);
                    pt.DeleteByAttribute("MaterialConnect", "MaterialID", id.ToString());
                    pt.DeleteByAttribute("MaterialParameterLink", "MaterialID", id.ToString());
                    pt.DeleteByAttribute("MaterialFileLink", "MaterialID", id.ToString());                    
                }
                else
                {
                    if (MessageBox.Show("Bạn có chắc muốn xóa vật tư [" + grvData.GetFocusedRowCellValue(colName).ToString() + "] không?",
                      TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;
                    pt.Delete("Material", id);
                    pt.DeleteByAttribute("MaterialConnect", "MaterialID", id.ToString());
                    pt.DeleteByAttribute("MaterialParameterLink", "MaterialID", id.ToString());
                }

                pt.CommitTransaction();
                LoadInfoSearch();
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

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvData.RowCount > 0)
                {
                    TextUtils.ExportExcel(grvData);
                }
            }
            catch (Exception)
            {

            }
        }      

        #endregion Material

        #region Events
        void main_LoadDataChange(object sender, EventArgs e)
        {
            LoadInfoSearch();
        }

        private void btnCompareTSKT_Click(object sender, EventArgs e)
        {
            frmCompareTSKT frm = new frmCompareTSKT();
            TextUtils.OpenForm(frm);
        }

        private void xemDanhSachNhaCungCâpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string code = grvData.GetFocusedRowCellValue(colCode).ToString();
            string name = grvData.GetFocusedRowCellValue(colName).ToString();

            frmSupplierMaterial frm = new frmSupplierMaterial();
            frm.MaterialCode = code;
            frm.MaterialName = name;
            TextUtils.OpenForm(frm);
        }

        private void btnTSVT_Click(object sender, EventArgs e)
        {
            frmCreateThongSoVT frm = new frmCreateThongSoVT();
            TextUtils.OpenForm(frm);
        }

        private void xemDanhSachSanPhâmChưaVâtTưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string code = TextUtils.ToString(grvData.GetFocusedRowCellValue(colCode));
            string name = TextUtils.ToString(grvData.GetFocusedRowCellValue(colName));

            frmModelContained frm = new frmModelContained();
            frm.MaterialCode = code;
            frm.MaterialName = name;
            TextUtils.OpenForm(frm);
        }

        private void xemDatasheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }       

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void btnDeleteApprove_Click(object sender, EventArgs e)
        {
            frmApprove frm = new frmApprove();
            TextUtils.OpenForm(frm);
        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loaData(1);
                ((TextBox)sender).Focus();
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
                    loaData();
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDatasheet_Click(object sender, EventArgs e)
        {
            frmDatasheet frm = new frmDatasheet();
            TextUtils.OpenForm(frm);
        }

        private void btnFindAll_Click(object sender, EventArgs e)
        {
            loaData(1);
        }

        private void txtGroupName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadTree();
            }            
        }

        private void btnExeclGroup_Click(object sender, EventArgs e)
        {
            treeData.ExpandAll();
            string filepath = System.IO.Path.GetTempFileName().Replace(".tmp", ".xls");
            treeData.ExportToXls(filepath);
            Process.Start(filepath);
        }

        private void btnShowInventory_Click(object sender, EventArgs e)
        {
            frmShowInventory frm = new frmShowInventory();
            frm.MaterialCode = grvData.GetFocusedRowCellValue(colCode).ToString();
            frm.MaterialName = grvData.GetFocusedRowCellValue(colName).ToString();
            TextUtils.OpenForm(frm);
        }        

        private void grvData_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                int stop = TextUtils.ToInt(grvData.GetRowCellValue(e.RowHandle, colStopStatus));
                if (stop > 0)
                {
                    e.Appearance.BackColor = Color.Yellow; 
                }

                //try
                //{
                //    GridView view = sender as GridView;
                //    string code = TextUtils.ToString(view.GetFocusedRowCellValue(colCode));
                //    string filePath = TextUtils.ToString(view.GetFocusedRowCellValue(colImagePath));
                //    Image img = Image.FromFile(filePath);
                //    Images.Add(code, img);
                //    view.SetRowCellValue(e.RowHandle, colImage, Images[code]);
                //}
                //catch (Exception)
                //{

                //}
            }
        }

        private void btnImportTSVT_Click(object sender, EventArgs e)
        {
            frmMaterialImportExcel frm = new frmMaterialImportExcel();
            TextUtils.OpenForm(frm);
        }

        private void btnCreateMaterialCode_Click(object sender, EventArgs e)
        {            
            int groupId = TextUtils.ToInt(treeData.FocusedNode.GetValue(colIDTree));

            string groupCode = treeData.FocusedNode.GetValue(colCodeTree).ToString();
            string groupName = treeData.FocusedNode.GetValue(colNameTree).ToString();

            createYC(groupId, groupCode, groupName); 
        }

        private void yêuCầuTạoMãVậtTưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int groupId = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colMaterialGroupID));
            DataTable dt = TextUtils.Select("select * from [MaterialGroup] with(nolock) where [ID] = " + groupId);

            string groupCode = TextUtils.ToString(dt.Rows[0]["Code"]);
            string groupName = TextUtils.ToString(dt.Rows[0]["Name"]);

            createYC(groupId, groupCode, groupName);
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
                catch (Exception)
                {
                }
            }
        }
        #endregion

        //Hashtable Images = new Hashtable();
        private void grvData_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            //if (e.Column == colImage && e.IsGetData)
            //{
            //    try
            //    {
            //        GridView view = sender as GridView;
            //        string code = TextUtils.ToString(view.GetFocusedRowCellValue(colCode));
            //        string filePath = TextUtils.ToString(view.GetFocusedRowCellValue(colImagePath));
            //        if (!Images.ContainsKey(code))
            //        {
            //            Image img = Image.FromFile(filePath);
            //            Images.Add(code, img);
            //        }
            //        e.Value = Images[code];
            //    }
            //    catch (Exception)
            //    {
            //    }
            //}
        }

        private void downloadFile3DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang download file 3D..."))
            {
                try
                {
                    FolderBrowserDialog fbd = new FolderBrowserDialog();
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        string materialCode = TextUtils.ToString(grvData.GetFocusedRowCellValue(colCode));
                        string filePath = "Materials/" + materialCode + ".ipt"; 
                        DocUtils.DownloadFile(fbd.SelectedPath, Path.GetFileName(filePath), filePath);

                        MessageBox.Show("Download file thành công!", TextUtils.Caption, MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Download file không thành công!\n Lỗi:" + ex.Message, TextUtils.Caption, MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
    }
}
