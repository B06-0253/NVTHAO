using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Localization;
using BMS.Business;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using BMS.Utils;
using BMS.Model;
using DevExpress.Utils;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using System.Collections;
using System.IO;

namespace BMS
{
    public partial class frmCompareTSKT : _Forms
    {
        string[] paraName = new string[2];
        object[] paraValue = new object[2];
        DataTable dtAllMaterial = new DataTable();
        DataTable dtOne = new DataTable();
        bool _vtd = false;
        GridHitInfo downHitInfo = null;

        #region Constructors and Loads
        public frmCompareTSKT()
        {
            InitializeComponent();
        }
     
        private void frmCompareTSKT_Load(object sender, EventArgs e)
        {
            GridLocalizer.Active = new MyGridLocalizer();
            loadCombo();
            loadGroup();
            loadProject();
            _vtd = rdbVTD.Checked;
        }
        #endregion

        #region Methods
        void loadCombo()
        {
            try
            {
                DataTable tbl = TextUtils.Select("Select * from MaterialGroup with(nolock) order by Code");
                TextUtils.PopulateCombo(cboMaterialGroup, tbl, "Name", "ID", "");
            }
            catch (Exception ex)
            {
            }
        }

        void loadGroup()
        {
            try
            {
                DataTable tbl = TextUtils.Select("Select *, ParentCode+' - '+ParentName as Parent,Code+' - '+Name as Name1 from vMaterialGroup with(nolock) where ParentID > 0 order by Code");
                TextUtils.PopulateCombo(cboMaterialGroup, tbl, "Name1", "ID", "");
            }
            catch (Exception ex)
            {
            }
        }

        void loadMaterial()
        {
            try
            {
                int groupID = TextUtils.ToInt(cboMaterialGroup.EditValue);
                if (groupID == 0) return;
                DataTable dt = TextUtils.Select("Select Name from MaterialParameters with(nolock) where MaterialGroupID= " + groupID + " order by STT");
                if (dt.Rows.Count == 0)
                {
                    TextUtils.ShowError("Nhóm vật tư này chưa có thông số!");
                    grdData.DataSource = null;
                    return;
                }
                string listPara = "";

                foreach (DataRow item in dt.Rows)
                {
                    listPara += "[" + item[0] + "]" + ",";
                }

                listPara = listPara.Substring(0, listPara.Length - 1);
                paraName[0] = "@MaterialGroupID"; paraValue[0] = groupID.ToString();
                paraName[1] = "@ListParams"; paraValue[1] = listPara;

                dtAllMaterial = MaterialBO.Instance.LoadDataFromSP("spMaterialAndPara", "Source", paraName, paraValue);

                dtAllMaterial.Columns[0].Caption = "ID";
                dtAllMaterial.Columns[1].Caption = "Mã";
                dtAllMaterial.Columns[2].Caption = "Tên";
                dtAllMaterial.Columns[3].Caption = "Hãng";
                dtAllMaterial.Columns[4].Caption = "Giá(VNĐ)";
                dtAllMaterial.Columns[5].Caption = "Thời gian GH(Ngày)";
                dtAllMaterial.Columns[6].Caption = "Ngày GD gần nhất";

                grvData.PopulateColumns(dtAllMaterial);
                grdData.DataSource = dtAllMaterial;

                grvData.Columns[6].DisplayFormat.FormatType = FormatType.DateTime;
                grvData.Columns[6].DisplayFormat.FormatString = "dd/MM/yyyy";
                //grvData.Columns[6].AppearanceCell.HAlignment = DevExpress.Utils.HorzAlignment.Center;

                grvData.Columns[4].DisplayFormat.FormatType = FormatType.Numeric;
                grvData.Columns[4].DisplayFormat.FormatString = "{0:#,##0.####}";

                grvData.Columns[0].Visible = false;
                grvData.Columns[7].Visible = false;
                grvData.Columns[8].Visible = false;
                grvData.BestFitColumns();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                grdOne.DataSource = null;
            }
        }

        void loadHistory()
        {
            try
            {
                if (cboModule.EditValue != null)
                {
                    DataTable dt = TextUtils.Select("vDMVTC", new Expression("ProductCode", cboModule.EditValue));
                    grdHistory.DataSource = dt;
                    grvHistory.BestFitColumns();
                }
                else
                {
                    grdHistory.DataSource = null;
                }
            }
            catch (Exception)
            {
                grdHistory.DataSource = null;
            }
           
        }

        void loadProject()
        {
            try
            {
                DataTable tbl = LibQLSX.Select("exec spGetAllProject");
                //DataTable tbl = TextUtils.Select("Select ProjectId, ProjectName, ProjectCode,DateFinishE from ProjectSyn with(nolock) order by ProjectCode");
                TextUtils.PopulateCombo(cboProject, tbl, "ProjectName", "ProjectCode", "");
                cboProject.Properties.View.BestFitColumns();
            }
            catch (Exception ex)
            {
            }           
        }

        void CreateExcel()
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo biểu mẫu danh mục vật tư chính..."))
            {
                ModulesModel thisModule = (ModulesModel)(ModulesBO.Instance.FindByAttribute("Code", cboModule.EditValue.ToString()))[0];
                int moduleID = thisModule.ID;
                if (moduleID == 0) return;

                ArrayList listModuleHistory = vDMVTCBO.Instance.FindByAttribute("ModuleID", moduleID);
                if (listModuleHistory.Count <= 0) return;

                DataTable dt = TextUtils.Select("SELECT top 1 (select COUNT(*) from [dbo].[fnStringToTable]([NameTS],'@')) as countTS "
                                                + " FROM [QLKHCV].[dbo].[MaterialHistory]  with(nolock) where ModuleID = " + moduleID
                                                + " order by (select COUNT(*) from [dbo].[fnStringToTable]([NameTS],'@')) desc");
                int numberTT = TextUtils.ToInt(dt.Rows[0][0]);

                if (numberTT == 0) return;

                vDMVTCModel mModel = (vDMVTCModel)listModuleHistory[0];
                string productName = mModel.ProductName;
                string productCode = mModel.ProductCode;

                string projectName = "";
                string projectCode = "";
                string projectDateEnd = "";
                string projectID = cboProject.Properties.View.GetFocusedRowCellValue(colProjectID) != null 
                    ? cboProject.Properties.View.GetFocusedRowCellValue(colProjectID).ToString() : "";
                if (projectID != "")
                {
                    projectName = cboProject.Properties.View.GetFocusedRowCellValue(colProjectName).ToString();
                    projectCode = cboProject.Properties.View.GetFocusedRowCellValue(colProjectCode).ToString();
                    projectDateEnd = cboProject.Properties.View.GetFocusedRowCellDisplayText(colDateEnd).ToString();
                }                

                string localPath = @"D:/Thietke.Ck/" + productCode.Substring(0, 6) + "/" + productCode + ".Ck/DOC." + productCode + "/";
                string filePath = Application.StartupPath + "/Templates/DMVTC.xlsm";
                if (!Directory.Exists(localPath))
                {
                    Directory.CreateDirectory(localPath);
                }
                File.Copy(filePath, localPath + "DMVTC." + productCode + ".xlsm", true);

                Excel.Application app = default(Excel.Application);
                Excel.Workbook workBoook = default(Excel.Workbook);
                Excel.Worksheet workSheet = default(Excel.Worksheet);
                try
                {
                    app = new Excel.Application();
                    app.Workbooks.Open(localPath + "DMVTC." + productCode + ".xlsm");
                    workBoook = app.Workbooks[1];
                    workSheet = (Excel.Worksheet)workBoook.Worksheets[1];

                    //chi tiết dự án                   
                    workSheet.Cells[4, 4] = productCode;
                    workSheet.Cells[5, 4] = productName;
                    workSheet.Cells[6, 4] = projectCode;
                    workSheet.Cells[7, 4] = projectName.ToUpper();

                    DataTable dtHistory = TextUtils.Select("vDMVTC", new Expression("ModuleID", moduleID));
                    
                    workSheet.Cells[4, 19] = dtHistory.Compute("Sum(Total)", "");
                    workSheet.Cells[5, 19] = dtHistory.Compute("Max(Delivery)", "");
                    workSheet.Cells[6, 19] = projectDateEnd;

                    workSheet.Cells[15, 20] = "Tân Phát, ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
                    workSheet.PageSetup.RightHeader = "Người sửa đổi: " + Global.AppFullName;

                    //nếu như vượt quá 14 thông số thì thêm cột
                    if (numberTT > 14)
                    {
                        for (int i = 0; i < numberTT - 14; i++)
                        {
                            Excel.Range oRng = workSheet.Range["Y1"];
                            oRng.EntireColumn.Insert(Excel.XlInsertShiftDirection.xlShiftToRight, Excel.XlInsertFormatOrigin.xlFormatFromRightOrBelow);
                        }
                    }

                    for (int i = 0; i < listModuleHistory.Count; i++)
                    {
                        vDMVTCModel hModel = (vDMVTCModel)listModuleHistory[i];

                        for (int j = 0; j <= 3; j++)
                        {
                            ((Excel.Range)workSheet.Rows[13]).Insert();
                        }

                        //Copy and Past file
                        Excel.Range rCopy = workSheet.Range["A10", "AZ12"];
                        rCopy.Copy();

                        Excel.Range rPaste = workSheet.Range["A14", "AZ16"];
                        rPaste.PasteSpecial(Excel.XlPasteType.xlPasteAll);

                        workSheet.Cells[14, 1] = listModuleHistory.Count - i;//stt
                        workSheet.Cells[14, 2] = hModel.Code;//Mã vật tư
                        workSheet.Cells[14, 3] = hModel.Name;//Tên vật tư
                        workSheet.Cells[14, 4] = hModel.Hang;//Hãng
                        workSheet.Cells[14, 5] = hModel.ThoiGianGHCuoi.ToString("dd/MM/yyyy");//Thời gian GH cuối
                        workSheet.Cells[14, 6] = hModel.Delivery;//Thời gian giao hàng(ngày)
                        workSheet.Cells[14, 7] = hModel.Unit;//Đơn vị tính
                        workSheet.Cells[14, 8] = hModel.Qty;//Số lượng
                        workSheet.Cells[14, 9] = hModel.Price;//Đơn giá
                        workSheet.Cells[14, 10] = hModel.Qty * hModel.Price;//Thành tiền

                        string[] arrTT = hModel.NameTS.Split('@');
                        string[] arrValueTT = hModel.ValueTT.Split('@');
                        string[] arrValueYC = hModel.ValueYC.Split('@');
                        for (int t = 0; t < arrTT.Count(); t++)
                        {
                            workSheet.Cells[14, 12 + t] = arrTT[t];
                            workSheet.Cells[15, 12 + t] = arrValueTT[t];
                            workSheet.Cells[16, 12 + t] = arrValueYC[t];
                        }
                    }

                    for (int i = 0; i < 4; i++)
                    {
                        ((Excel.Range)workSheet.Rows[10]).Delete();
                    }

                    app.ActiveWorkbook.Save();
                    app.Workbooks.Close();
                    app.Quit();

                    Process.Start(localPath + "DMVTC." + productCode + ".xlsm");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    TextUtils.ReleaseComObject(app);
                    TextUtils.ReleaseComObject(workBoook);
                    TextUtils.ReleaseComObject(workSheet);
                }
            }
        }

        void save()
        {
            if (grvHistory.RowCount == 0) return;
            for (int i = 0; i < grvHistory.RowCount; i++)
            {
                try
                {
                    int id = TextUtils.ToInt(grvHistory.GetRowCellValue(i, colID));
                    MaterialHistoryModel model = (MaterialHistoryModel)MaterialHistoryBO.Instance.FindByPK(id);
                    model.Qty = TextUtils.ToDecimal(grvHistory.GetRowCellValue(i, colQty));
                    MaterialHistoryBO.Instance.Update(model);
                }
                catch
                {
                }
            }
        }
        #endregion

        #region Move row by drap and drop
        private void grdData_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (cboModule.EditValue == null)
                {
                    MessageBox.Show("Bạn hãy chọn một thiết kế!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (dtOne.Rows.Count == 0)
                {
                    MessageBox.Show("Bạn hãy nhập thông số yêu cầu!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataRow row = e.Data.GetData(typeof(DataRow)) as DataRow;

                try
                {
                    DataTable dt = TextUtils.Select("vDMVTC", new Expression("ProductCode", TextUtils.ToInt(cboModule.EditValue))
                        .And(new Expression("MaterialID", TextUtils.ToInt(row["ID"]))));
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Vật tư này đã được chọn!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }
                catch (Exception)
                {
                }

                int moduleID = ((ModulesModel)(ModulesBO.Instance.FindByAttribute("Code", cboModule.EditValue.ToString()))[0]).ID;
                if (moduleID == 0)
                {
                     MessageBox.Show("Module chưa có trong quản lý thiết kế!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                }

                string valueTT = "";
                string nameTS = "";
                for (int i = 0; i < dtAllMaterial.Columns.Count; i++)
                {
                    if (i > 6)
                    {
                        nameTS += dtAllMaterial.Columns[i].Caption + "@";
                        valueTT += row[i].ToString() + "@";
                    }
                }

                string valueYC = "";
                for (int i = 0; i < dtOne.Columns.Count; i++)
                {
                    if (i > 6)
                    {
                        valueYC += dtOne.Rows[0][i].ToString() + "@";
                    }
                }                

                MaterialHistoryModel model = new MaterialHistoryModel();
                model.MaterialID = TextUtils.ToInt(row["ID"]);
                model.ModuleID = moduleID; //TextUtils.ToInt(cboModule.EditValue);
                model.Price = TextUtils.ToDecimal(row["Price"]);
                model.Qty = 1;
                model.Delivery = TextUtils.ToDecimal(row["DeliveryPeriod"]);
                model.ValueTT = valueTT.Substring(0, valueTT.Length - 1);
                model.ValueYC = valueYC.Substring(0, valueYC.Length - 1);
                model.NameTS = nameTS.Substring(0, nameTS.Length - 1);
                MaterialHistoryBO.Instance.Insert(model);

                loadHistory();
            }
            catch (Exception ex)
            {
                TextUtils.ShowError(ex);
            }
            
        }

        private void grdData_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DataRow)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void grvData_MouseDown(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            downHitInfo = null;

            GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
            if (Control.ModifierKeys != Keys.None)
                return;
            if (e.Button == MouseButtons.Left && hitInfo.InRow && hitInfo.RowHandle != GridControl.NewItemRowHandle)
                downHitInfo = hitInfo;
        }

        private void grvData_MouseMove(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;

            if (e.Button == MouseButtons.Left && downHitInfo != null)
            {

                Size dragSize = SystemInformation.DragSize;

                Rectangle dragRect = new Rectangle(new Point(downHitInfo.HitPoint.X - dragSize.Width / 2,

                    downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);



                if (!dragRect.Contains(new Point(e.X, e.Y)))
                {

                    DataRow row = view.GetDataRow(downHitInfo.RowHandle);

                    view.GridControl.DoDragDrop(row, DragDropEffects.Move);

                    downHitInfo = null;

                    DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = true;

                }

            }

        }

        private void grvData_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(grvData.Columns[0]));
                pictureBox2.ImageLocation = ((MaterialModel)MaterialBO.Instance.FindByPK(id)).ImagePath;
            }
            catch (Exception)
            {
            }
        }

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView sndr =
                   sender as DevExpress.XtraGrid.Views.Grid.GridView;
            DevExpress.Utils.DXMouseEventArgs dxMouseEventArgs =
                e as DevExpress.Utils.DXMouseEventArgs;
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hitInfo =
               sndr.CalcHitInfo(dxMouseEventArgs.Location);

            if (hitInfo.InColumn)
            {
                grvHistory.ShowCustomFilterDialog(hitInfo.Column);
            }
            else
            {
                int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(grvData.Columns[0]));
                dtOne = dtAllMaterial.Select("ID = " + id).CopyToDataTable();
                if (!_vtd)
                {
                    dtOne.Rows.Clear();
                    DataRow row = dtOne.NewRow();
                    dtOne.Rows.Add(row);
                }

                dtOne.Columns[0].Caption = "ID";
                dtOne.Columns[1].Caption = "Mã";
                dtOne.Columns[2].Caption = "Tên";
                dtOne.Columns[3].Caption = "Hãng";
                dtOne.Columns[4].Caption = "Giá(VNĐ)";
                dtOne.Columns[5].Caption = "Thời gian GH(Ngày)";
                dtOne.Columns[6].Caption = "Ngày GD gần nhất";

                grvData.Columns[4].DisplayFormat.FormatType = FormatType.Numeric;
                grvData.Columns[4].DisplayFormat.FormatString = "{0:#,##0.####}";

                grvOne.PopulateColumns(dtOne);
                grdOne.DataSource = dtOne;
                grvOne.Columns[0].Visible = false;

                try
                {
                    pictureBox1.ImageLocation = ((MaterialModel)MaterialBO.Instance.FindByPK(id)).ImagePath;
                }
                catch (Exception)
                {
                }

                for (int i = 0; i < grvOne.Columns.Count; i++)
                {
                    grvOne.Columns[i].Width = grvData.Columns[i].Width;
                }
            }
        }
        #endregion

        #region Events
        private void cboProject_EditValueChanged(object sender, EventArgs e)
        {
            if (cboProject.EditValue == null) return;
            string projectCode = cboProject.EditValue.ToString();
            if (projectCode != "")
            {
                try
                {
                    //DataTable tbl = TextUtils.Select("Select ID, Code, Name from Modules with(nolock) where Code like '%TPAD%' and " +
                    //                                  " code in (SELECT MaTheoThietKe FROM [QLKHCV].[dbo].[SanPhamDA] where ProjectsID='" + projectID + "') order by Code");
                    string[] paraName = new string[1];
                    string[] paraValue = new string[1];
                    paraName[0] = "@ProjectCode"; paraValue[0] = projectCode;
                    DataTable tbl = ModulesBO.Instance.LoadDataFromSP("spGetModuleOfProject", "Modules", paraName, paraValue);
                    TextUtils.PopulateCombo(cboModule, tbl, "ProductName", "ProductCode", "");
                }
                catch (Exception ex)
                {
                    cboModule.Properties.DataSource = null;
                }
            }
            else
            {
                cboModule.Properties.DataSource = null;
            }
        }

        private void cboModule_EditValueChanged(object sender, EventArgs e)
        {
            loadHistory();
        }

        private void cboMaterialGroup_SelectionChangeCommitted(object sender, EventArgs e)
        {
            loadMaterial();
        }

        private void btnDeleteHistory_Click(object sender, EventArgs e)
        {
            try
            {
                int id = TextUtils.ToInt(grvHistory.GetFocusedRowCellValue(colID));
                if (id == 0) return;
                if (MessageBox.Show("Bạn có chắc muốn xóa vật tư [" + grvHistory.GetFocusedRowCellValue(colName).ToString() + "] trong danh sách không?",
                          TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                MaterialHistoryBO.Instance.Delete(id);
                loadHistory();
            }
            catch (Exception ex)
            {
                TextUtils.ShowError(ex);
            }
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save();
            MessageBox.Show("Lưu trữ thành công!");
        }

        private void btnPrintView_Click(object sender, EventArgs e)
        {
            //save();
            CreateExcel();
        }

        private void grvOne_Click(object sender, EventArgs e)
        {

        }

        private void cboMaterialGroup1_EditValueChanged(object sender, EventArgs e)
        {
            loadMaterial();
        }

        private void rdbVTD_CheckedChanged(object sender, EventArgs e)
        {
            _vtd = rdbVTD.Checked;
        }

        private void rdbYC_CheckedChanged(object sender, EventArgs e)
        {
        }
        #endregion

        private void grvHistory_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                int id = TextUtils.ToInt(grvHistory.GetFocusedRowCellValue(colID));
                pictureBox2.ImageLocation = ((MaterialModel)MaterialBO.Instance.FindByPK(id)).ImagePath;
            }
            catch (Exception)
            {
            }
        }

        private void grvHistory_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            MaterialHistoryModel model = (MaterialHistoryModel)MaterialHistoryBO.Instance.FindByPK(TextUtils.ToInt(view.GetRowCellValue(e.RowHandle, colID)));
            model.Qty = TextUtils.ToDecimal(view.GetRowCellValue(e.RowHandle, colQty));
            MaterialHistoryBO.Instance.Update(model);
        }

        private void grvData_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                string code = grvData.GetRowCellValue(e.RowHandle, "Code").ToString();
                bool stop = TextUtils.ToBoolean(grvData.GetRowCellValue(e.RowHandle, "StopStatus"));
                string group = grvData.GetRowCellValue(e.RowHandle, "MaterialGroupCode").ToString();
                if (code == "") return;
                //MaterialModel material = (MaterialModel)MaterialBO.Instance.FindByAttribute("Code", code)[0];
                //DataTable dt = TextUtils.Select("SELECT * FROM [vMaterial] with(nolock) where Code ='" + code + "'");
                if (stop)
                {
                    e.Appearance.BackColor = Color.Yellow;
                }
                if (group == "TPAVT.Z01")
                {
                    e.Appearance.BackColor = Color.Red;
                }
            }
        }
    }
}
