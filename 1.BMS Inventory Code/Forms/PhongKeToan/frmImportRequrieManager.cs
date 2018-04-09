using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using TPA.Business;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Diagnostics;
using System.Collections;
using TPA.Model;
using TPA.Utils;

namespace BMS
{
    public partial class frmImportRequrieManager : _Forms
    {
        public frmImportRequrieManager()
        {
            InitializeComponent();
        }

        private void frmImportRequrieManager_Load(object sender, EventArgs e)
        {
            loadYear();
            loadUser();

            cboStatus.SelectedIndex = 0;
            cboType.SelectedIndex = 0;

            loadImport();
        }

        void loadYear()
        {
            for (int i = 2013; i <= DateTime.Now.Year; i++)
            {
                cboYear.Items.Add(i);
            }
            cboYear.SelectedItem = DateTime.Now.Year;
        }

        void loadUser()
        {
            DataTable dt = LibQLSX.Select("Select * from [vUser] WITH(NOLOCK)");
            cboUser.Properties.DataSource = dt;
            cboUser.Properties.DisplayMember = "UserName";
            cboUser.Properties.ValueMember = "UserId";
            grvCboUser.BestFitColumns();
        }

        void loadImport()
        {
            string[] paraName = new string[5];
            object[] paraValue = new object[5];

            try
            {
                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load danh sách ĐNNK..."))
                {
                    paraName[0] = "@Year"; paraValue[0] = TextUtils.ToInt(cboYear.Text);
                    paraName[1] = "@TextFind"; paraValue[1] = txtTextFind.Text.Trim();
                    paraName[2] = "@Status"; paraValue[2] = cboStatus.SelectedIndex;
                    paraName[3] = "@UserId"; paraValue[3] = TextUtils.ToString(cboUser.EditValue);
                    paraName[4] = "@Type"; paraValue[4] = cboType.SelectedIndex;

                    DataTable Source = OrdersBO.Instance.LoadDataFromSP("spGetRequestImportWarehouse", "Source", paraName, paraValue);

                    grdDNNK.DataSource = Source;
                }
            }
            catch
            {
                grdDNNK.DataSource = null;
            }
        }

        void loadItem()
        {
            string importId = TextUtils.ToString(grvDNNK.GetFocusedRowCellValue(colImportId));

            if (importId == "")
            {
                grdData.DataSource = null;
                return;
            }

            int type = TextUtils.ToInt(grvDNNK.GetFocusedRowCellValue(colImportType));

            string[] paraName = new string[2];
            object[] paraValue = new object[2];

            paraName[0] = "@Type"; paraValue[0] = type;
            paraName[1] = "@ImportID"; paraValue[1] = importId;

            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load danh sách vật tư..."))
            {
                DataTable Source = OrdersBO.Instance.LoadDataFromSP("spGetImportItem", "Source", paraName, paraValue);

                grdData.DataSource = Source;

                //DataTable dt = new DataTable();
                //if (type == 1)
                //{
                //    dt = LibQLSX.Select("select *, ROW_NUMBER() OVER(ORDER BY [ProductPartsImportId]) AS STT from [vImportMaterial] with(nolock) where [ImportId] = '" + importId + "'");
                //}
                //else
                //{
                //    dt = LibQLSX.Select("select *, ROW_NUMBER() OVER(ORDER BY [ProjectProductImportId]) AS STT from [vImportProduct] with(nolock) where [ImportId] = '" + importId + "'");
                //}
                //grdData.DataSource = dt;
            }
        }

        void main_LoadDataChange(object sender, EventArgs e)
        {
            loadItem();
        }

        private void btnExportListMaterial_Click(object sender, EventArgs e)
        {
            if (grvData.RowCount == 0) return;

            string importCode = TextUtils.ToString(grvDNNK.GetFocusedRowCellValue(colImportCode));

            string path = "";

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path = fbd.SelectedPath;
            }
            else
            {
                return;
            }

            string filePath = Application.StartupPath + "\\Templates\\KCS\\DMVT.xls";
            string currentPath = path + "\\DMVT-" + importCode + ".xls";

            try
            {
                File.Copy(filePath, currentPath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi tạo biểu mẫu!" + Environment.NewLine + ex.Message,
                    TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo biểu mẫu..."))
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                Excel.Application app = default(Excel.Application);
                Excel.Workbook workBoook = default(Excel.Workbook);
                Excel.Worksheet workSheet = default(Excel.Worksheet);
                try
                {
                    app = new Excel.Application();
                    app.Workbooks.Open(currentPath);
                    workBoook = app.Workbooks[1];
                    workSheet = (Excel.Worksheet)workBoook.Worksheets[1];

                    workSheet.Cells[3, 1] = "(Số ĐNNK: " + importCode + ")";
                    //workSheet.Cells[9, 27] = Global.AppFullName;
                    //workSheet.Cells[9, 31] = DateTime.Now.Date.ToString("dd/MM/yyyy");

                    for (int i = grvData.RowCount - 1; i >= 0; i--)
                    {
                        workSheet.Cells[13, 1] = TextUtils.ToString(grvData.GetRowCellValue(i, colSTT));
                        workSheet.Cells[13, 2] = TextUtils.ToString(grvData.GetRowCellValue(i, colName));
                        workSheet.Cells[13, 3] = TextUtils.ToString(grvData.GetRowCellValue(i, colCode));
                        workSheet.Cells[13, 4] = TextUtils.ToString(grvData.GetRowCellValue(i, colUnit));
                        workSheet.Cells[13, 5] = TextUtils.ToString(grvData.GetRowCellValue(i, colTotal));
                        workSheet.Cells[13, 6] = TextUtils.ToString(grvData.GetRowCellValue(i, colProjectCode));
                        workSheet.Cells[13, 7] = TextUtils.ToString(grvData.GetRowCellValue(i, colYCMVT));
                        workSheet.Cells[13, 8] = TextUtils.ToString(grvData.GetRowCellValue(i, colHSX));
                        //workSheet.Cells[13, 9] = TextUtils.ToString(grvData.GetRowCellValue(i, colTotal));
                        ((Excel.Range)workSheet.Rows[13]).Insert();
                    }
                    ((Excel.Range)workSheet.Rows[12]).Delete();
                    ((Excel.Range)workSheet.Rows[12]).Delete();
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
                Process.Start(currentPath);
            }
        }

        private void btnExportListCheck_Click(object sender, EventArgs e)
        {
            if (grvData.RowCount == 0) return;

            string importCode = TextUtils.ToString(grvDNNK.GetFocusedRowCellValue(colImportCode));

            string path = "";

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path = fbd.SelectedPath;
            }
            else
            {
                return;
            }

            string filePath = Application.StartupPath + "\\Templates\\KCS\\KTCLVT.xls";
            string currentPath = path + "\\KTCLVT-" + importCode + ".xls";

            try
            {
                File.Copy(filePath, currentPath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi tạo biểu mẫu!" + Environment.NewLine + ex.Message,
                    TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo biểu mẫu..."))
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                Excel.Application app = default(Excel.Application);
                Excel.Workbook workBoook = default(Excel.Workbook);
                Excel.Worksheet workSheet = default(Excel.Worksheet);
                try
                {
                    app = new Excel.Application();
                    app.Workbooks.Open(currentPath);
                    workBoook = app.Workbooks[1];
                    workSheet = (Excel.Worksheet)workBoook.Worksheets[1];

                    workSheet.Cells[7, 2] = "Số ĐNNK: " + importCode;
                    workSheet.Cells[9, 27] = Global.AppFullName;
                    workSheet.Cells[9, 31] = DateTime.Now.Date.ToString("dd/MM/yyyy");

                    for (int i = grvData.RowCount - 1; i >= 0; i--)
                    {
                        workSheet.Cells[16, 1] = TextUtils.ToString(grvData.GetRowCellValue(i, colSTT));
                        workSheet.Cells[16, 2] = TextUtils.ToString(grvData.GetRowCellValue(i, colName));
                        workSheet.Cells[16, 3] = TextUtils.ToString(grvData.GetRowCellValue(i, colCode));
                        workSheet.Cells[16, 4] = TextUtils.ToString(grvData.GetRowCellValue(i, colTotal));
                        //workSheet.Cells[13, 5] = TextUtils.ToString(grvData.GetRowCellValue(i, colTotal));
                        //workSheet.Cells[13, 6] = TextUtils.ToString(grvData.GetRowCellValue(i, colProjectCode));
                        //workSheet.Cells[13, 7] = TextUtils.ToString(grvData.GetRowCellValue(i, colYCMVT));
                        //workSheet.Cells[13, 8] = TextUtils.ToString(grvData.GetRowCellValue(i, colHSX));
                        ((Excel.Range)workSheet.Rows[16]).Insert();
                    }
                    ((Excel.Range)workSheet.Rows[15]).Delete();
                    ((Excel.Range)workSheet.Rows[15]).Delete();
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
                Process.Start(currentPath);
            }
        }

        private void cboYear_SelectionChangeCommitted(object sender, EventArgs e)
        {
            loadImport();
        }

        private void cboType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            loadImport();
        }

        private void cboStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            loadImport();
        }

        private void cboUser_EditValueChanged(object sender, EventArgs e)
        {
            loadImport();
        }

        private void grvDNNK_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            loadItem();
        }

        private void grvDNNK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == (Keys.C))
            {
                try
                {
                    string text = TextUtils.ToString(grvDNNK.GetFocusedRowCellValue(grvDNNK.FocusedColumn));
                    Clipboard.SetText(text);
                }
                catch (Exception)
                {
                }
            }
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

        private void btnDNNKthanhPham_Click(object sender, EventArgs e)
        {
            int importType = TextUtils.ToInt(grvDNNK.GetFocusedRowCellValue(colImportType));
            if (importType != 2) return;

            if (Global.DepartmentID == 3 || Global.AppUserName == "thao.nv")
            //if (Global.DepartmentID == 6)
            {
                if (grvData.RowCount == 0) return;

                string importCode = TextUtils.ToString(grvDNNK.GetFocusedRowCellValue(colImportCode));

                string path = "";

                bool isQtyTotal = false;
                DialogResult result = MessageBox.Show("Bạn muốn xuất ĐNNK với số lượng tổng của module?", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    isQtyTotal = true;
                }
                else
                {
                    isQtyTotal = false;
                }

                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    path = fbd.SelectedPath;
                }
                else
                {
                    return;
                }

                string filePath = Application.StartupPath + "\\Templates\\PhongKeToan\\Nhap kho thanh pham.xls";
                string currentPath = path + "\\Nhap kho thanh pham-" + importCode + ".xls";

                try
                {
                    File.Copy(filePath, currentPath, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi tạo biểu mẫu!" + Environment.NewLine + ex.Message,
                        TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo biểu mẫu..."))
                {
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                    Excel.Application app = default(Excel.Application);
                    Excel.Workbook workBoook = default(Excel.Workbook);
                    Excel.Worksheet workSheet = default(Excel.Worksheet);
                    try
                    {
                        app = new Excel.Application();
                        app.Workbooks.Open(currentPath);
                        workBoook = app.Workbooks[1];
                        workSheet = (Excel.Worksheet)workBoook.Worksheets[1];

                        for (int i = grvData.RowCount - 1; i >= 0; i--)
                        {
                            string qty = "0";
                            if (isQtyTotal)
                            {
                                qty = TextUtils.ToString(grvData.GetRowCellValue(i, colTotal));
                            }
                            else
                            {
                                qty = TextUtils.ToString(grvData.GetRowCellValue(i, colTotalOK));
                            }
                            workSheet.Cells[3, 1] = TextUtils.ToString(grvData.GetRowCellValue(i, colSTT));
                            workSheet.Cells[3, 2] = TextUtils.ToString(grvData.GetRowCellValue(i, colName));
                            workSheet.Cells[3, 3] = TextUtils.ToString(grvData.GetRowCellValue(i, colCode)) + "." + TextUtils.ToString(grvData.GetRowCellValue(i, colProjectCode));
                            workSheet.Cells[3, 4] = TextUtils.ToString(grvData.GetRowCellValue(i, colUnit));
                            workSheet.Cells[3, 5] = qty;
                            workSheet.Cells[3, 6] = TextUtils.ToString(grvData.GetRowCellValue(i, colProjectCode)) + "." + TextUtils.ToString(grvData.GetRowCellValue(i, colCode));
                            workSheet.Cells[3, 7] = "KTP";
                            workSheet.Cells[3, 8] = "FINIS";
                            workSheet.Cells[3, 9] = "155";
                            workSheet.Cells[3, 10] = "C27";
                            //workSheet.Cells[13, 9] = TextUtils.ToString(grvData.GetRowCellValue(i, colTotal));
                            ((Excel.Range)workSheet.Rows[3]).Insert();
                        }
                        ((Excel.Range)workSheet.Rows[2]).Delete();
                        ((Excel.Range)workSheet.Rows[2]).Delete();
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
                    Process.Start(currentPath);
                }
            }
        }

        private void btnExportModule_Click(object sender, EventArgs e)
        {
            int importType = TextUtils.ToInt(grvDNNK.GetFocusedRowCellValue(colImportType));
            if (importType != 2) return;

            if (Global.DepartmentID == 3 || Global.AppUserName == "thao.nv")
            //if (Global.DepartmentID == 6)
            {
                if (grvData.RowCount == 0) return;

                string importCode = TextUtils.ToString(grvDNNK.GetFocusedRowCellValue(colImportCode));

                string path = "";

                bool isQtyTotal = false;
                DialogResult result = MessageBox.Show("Bạn muốn xuất ĐNNK với số lượng tổng của module?", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    isQtyTotal = true;
                }
                else
                {
                    isQtyTotal = false;
                }

                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    path = fbd.SelectedPath;
                }
                else
                {
                    return;
                }

                string filePath = Application.StartupPath + "\\Templates\\PhongKeToan\\Xuat kho thanh pham.xls";
                string currentPath = path + "\\Xuat kho thanh pham-" + importCode + ".xls";

                try
                {
                    File.Copy(filePath, currentPath, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi tạo biểu mẫu!" + Environment.NewLine + ex.Message,
                        TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo biểu mẫu..."))
                {
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                    Excel.Application app = default(Excel.Application);
                    Excel.Workbook workBoook = default(Excel.Workbook);
                    Excel.Worksheet workSheet = default(Excel.Worksheet);
                    try
                    {
                        app = new Excel.Application();
                        app.Workbooks.Open(currentPath);
                        workBoook = app.Workbooks[1];
                        workSheet = (Excel.Worksheet)workBoook.Worksheets[1];

                        for (int i = grvData.RowCount - 1; i >= 0; i--)
                        {
                            string qty = "0";
                            if (isQtyTotal)
                            {
                                qty = TextUtils.ToString(grvData.GetRowCellValue(i, colTotal));
                            }
                            else
                            {
                                qty = TextUtils.ToString(grvData.GetRowCellValue(i, colTotalOK));
                            }
                            workSheet.Cells[4, 1] = TextUtils.ToString(grvData.GetRowCellValue(i, colSTT));
                            workSheet.Cells[4, 2] = TextUtils.ToString(grvData.GetRowCellValue(i, colName));
                            workSheet.Cells[4, 3] = TextUtils.ToString(grvData.GetRowCellValue(i, colCode)) + "." + TextUtils.ToString(grvData.GetRowCellValue(i, colProjectCode));
                            workSheet.Cells[4, 4] = "";
                            workSheet.Cells[4, 5] = TextUtils.ToString(grvData.GetRowCellValue(i, colUnit));
                            workSheet.Cells[4, 6] = qty;

                            workSheet.Cells[2, 4] = TextUtils.ToString(grvData.GetRowCellValue(i, colProjectCode));
                            ((Excel.Range)workSheet.Rows[4]).Insert();
                        }
                        ((Excel.Range)workSheet.Rows[3]).Delete();
                        ((Excel.Range)workSheet.Rows[3]).Delete();
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
                    Process.Start(currentPath);
                }
            }
        }

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            DataTable dtUserKCS = LibQLSX.Select("select top 1 * from Users where Account = '" + Global.AppUserName + "'");
            if (dtUserKCS.Rows.Count == 0)
            {
                MessageBox.Show("Tài khoản đăng nhập không có trên QLSX", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //pt.CloseConnection();
                return;
            }

            int status = TextUtils.ToInt(grvDNNK.GetFocusedRowCellValue(colStatus));
            //if (status != 2)
            //{
            //    MessageBox.Show("Không thể hủy yêu cầu nhập kho.\nYêu cầu nhập kho này đã được nhập kho.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}

            int importType = TextUtils.ToInt(grvDNNK.GetFocusedRowCellValue(colImportType));
            decimal qty = TextUtils.ToDecimal(grvData.GetFocusedRowCellValue(colTotal));
            string partsCode = TextUtils.ToString(grvData.GetFocusedRowCellValue(colCode));
            string dnnk = TextUtils.ToString(grvDNNK.GetFocusedRowCellValue(colImportCode));
            string productPartsImportId = TextUtils.ToString(grvData.GetFocusedRowCellValue(colProductPartsImportId));
            string projectProductImportId = TextUtils.ToString(grvData.GetFocusedRowCellValue(colProjectProductImportId));
            string projectCode = TextUtils.ToString(grvData.GetFocusedRowCellValue(colProjectCode));
            string moduleCode = TextUtils.ToString(grvData.GetFocusedRowCellValue(colModuleCode));

            if (importType == 1)
            {
                ArrayList arr = ProductPartsImportBO.Instance.FindByAttribute("ProductPartsImportId", productPartsImportId);
                ProductPartsImportModel model = (ProductPartsImportModel)arr[0];

                int moduleID = TextUtils.ToInt(TextUtils.ExcuteScalar("select top 1 ID from Modules where Code = '" + moduleCode + "'"));

                frmImportErrorPart frm = new frmImportErrorPart(projectCode, moduleID);
                frm.ProductImportType = importType;
                frm.PartsCode = partsCode;
                frm.DNNK = dnnk;
                frm.Qty = qty;
                frm.ProductPartsImport = model;
                frm.ImportStatus = status;
                frm.LoadDataChange += main_LoadDataChange;
                frm.Show();
            }
            else
            {
                ArrayList arr = ProjectProductImportBO.Instance.FindByAttribute("ProjectProductImportId", projectProductImportId);
                ProjectProductImportModel model = (ProjectProductImportModel)arr[0];

                int moduleID = TextUtils.ToInt(TextUtils.ExcuteScalar("select top 1 ID from Modules where Code = '" + partsCode + "'"));

                frmImportErrorModule frm = new frmImportErrorModule(projectCode, moduleID);
                frm.PartsCode = partsCode;
                frm.DNNK = dnnk;
                frm.Qty = qty;
                frm.ProjectProductImport = model;
                frm.ImportStatus = status;
                frm.LoadDataChange += main_LoadDataChange;
                frm.Show();
            }
        }

        private void btnDNNKvattu_Click(object sender, EventArgs e)
        {
            int importType = TextUtils.ToInt(grvDNNK.GetFocusedRowCellValue(colImportType));
            if (importType != 1) return;

            if (Global.DepartmentID == 3 || Global.AppUserName == "thao.nv")
            //if (Global.DepartmentID == 6)
            {
                #region Init
                if (grvData.RowCount == 0) return;

                string importCode = TextUtils.ToString(grvDNNK.GetFocusedRowCellValue(colImportCode));

                string path = "";

                bool isQtyTotal = false;
                DialogResult result = MessageBox.Show("Bạn muốn xuất ĐNNK với số lượng tổng của module?", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    isQtyTotal = true;
                }
                else
                {
                    isQtyTotal = false;
                }

                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    path = fbd.SelectedPath;
                }
                else
                {
                    return;
                }

                string filePath = Application.StartupPath + "\\Templates\\PhongKeToan\\Nhap kho vat tu.xls";
                string currentPath = path + "\\Nhap kho vat tu-" + importCode + ".xls";

                try
                {
                    File.Copy(filePath, currentPath, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi tạo biểu mẫu!" + Environment.NewLine + ex.Message,
                        TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                #endregion

                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo biểu mẫu..."))
                {
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                    Excel.Application app = default(Excel.Application);
                    Excel.Workbook workBoook = default(Excel.Workbook);
                    Excel.Worksheet workSheet = default(Excel.Worksheet);
                    try
                    {
                        app = new Excel.Application();
                        app.Workbooks.Open(currentPath);
                        workBoook = app.Workbooks[1];
                        workSheet = (Excel.Worksheet)workBoook.Worksheets[1];

                        DataTable dt = (DataTable)grdData.DataSource;

                        DataTable dtAllProject = TextUtils.GetDistinctDatatable(dt, "ProjectCode");
                        foreach (DataRow row in dtAllProject.Rows)
                        {
                            string projectCode = TextUtils.ToString(row["ProjectCode"]);
                            DataRow[] drsProject;
                            if (projectCode == "")
                            {
                                //drsProject = dt.Select("ProjectCode is null");
                                drsProject = dt.AsEnumerable().Where(r1 => TextUtils.ToString(r1.Field<string>("ProjectCode")) == "").ToArray();

                                #region Add Parts
                                for (int i = drsProject.Length - 1; i >= 0; i--)
                                {
                                    decimal qty = 0;
                                    if (isQtyTotal)
                                    {
                                        qty = TextUtils.ToDecimal(drsProject[i]["Total"]);
                                    }
                                    else
                                    {
                                        qty = TextUtils.ToDecimal(drsProject[i]["TotalOK"]);
                                    }

                                    string orderCode = TextUtils.ToString(drsProject[i]["OrderCode"]);
                                    DataTable dtOrderCode = LibQLSX.Select("spGetPartWithOrder '" + orderCode + "'");
                                    int partCount = dtOrderCode.Rows.Count;
                                    decimal more = 0;
                                    decimal deliveryCost = TextUtils.ToDecimal(drsProject[i]["DeliveryCost"]);
                                    if (partCount > 0 && deliveryCost > 0)
                                    {
                                        more = Math.Round(deliveryCost / partCount / qty, 0);
                                    }
                                    decimal price = TextUtils.ToDecimal(drsProject[i]["Price"]) + more;
                                    decimal totalPrice = qty * price;

                                    workSheet.Cells[3, 1] = i + 1;
                                    workSheet.Cells[3, 2] = TextUtils.ToString(drsProject[i]["PartsName"]);
                                    workSheet.Cells[3, 3] = TextUtils.ToString(drsProject[i]["PartsCode"]);
                                    workSheet.Cells[3, 4] = "";
                                    workSheet.Cells[3, 5] = TextUtils.ToString(drsProject[i]["Unit"]);
                                    workSheet.Cells[3, 6] = qty;
                                    workSheet.Cells[3, 7] = price;
                                    workSheet.Cells[3, 8] = totalPrice;
                                    workSheet.Cells[3, 9] = "";
                                    workSheet.Cells[3, 10] = "";
                                    workSheet.Cells[3, 11] = TextUtils.ToString(drsProject[i]["ManufacturerCode"]);
                                    workSheet.Cells[3, 12] = TextUtils.ToString(drsProject[i]["StoreCode"]);
                                    workSheet.Cells[3, 13] = TextUtils.ToString(drsProject[i]["GroupCode"]);
                                    workSheet.Cells[3, 14] = TextUtils.ToString(drsProject[i]["AccountCode"]);
                                    workSheet.Cells[3, 15] = "C27";
                                    workSheet.Cells[3, 16] = orderCode;
                                    workSheet.Cells[3, 20] = TextUtils.ToDecimal(drsProject[i]["Price"]);
                                    ((Excel.Range)workSheet.Rows[3]).Insert();
                                }

                                workSheet.Cells[3, 2] = "VTSXC";
                                workSheet.Cells[3, 4] = "VTSXC";
                                ((Excel.Range)workSheet.Rows[3]).Insert();
                                #endregion
                            }
                            else
                            {
                                drsProject = dt.Select("ProjectCode = '" + projectCode + "'");

                                DataTable dtProject = drsProject.CopyToDataTable();
                                DataTable dtAllModule = TextUtils.GetDistinctDatatable(dtProject, "ProjectModuleCode");

                                foreach (DataRow item in dtAllModule.Rows)
                                {
                                    string moduleCode = TextUtils.ToString(item["ProjectModuleCode"]);
                                    DataTable dtParts;
                                    if (moduleCode == "")
                                    {
                                        dtParts = dtProject.Select("ProjectModuleCode is null").CopyToDataTable();
                                    }
                                    else
                                    {
                                        dtParts = dtProject.Select("ProjectModuleCode = '" + moduleCode + "'").CopyToDataTable();
                                    }

                                    #region Add Parts
                                    for (int i = dtParts.Rows.Count - 1; i >= 0; i--)
                                    {
                                        decimal qty = 0;
                                        if (isQtyTotal)
                                        {
                                            qty = TextUtils.ToDecimal(dtParts.Rows[i]["Total"]);
                                        }
                                        else
                                        {
                                            qty = TextUtils.ToDecimal(dtParts.Rows[i]["TotalOK"]);
                                        }

                                        string orderCode = TextUtils.ToString(dtParts.Rows[i]["OrderCode"]);
                                        DataTable dtOrderCode = LibQLSX.Select("spGetPartWithOrder '" + orderCode + "'");
                                        int partCount = dtOrderCode.Rows.Count;
                                        decimal more = 0;
                                        decimal deliveryCost = TextUtils.ToDecimal(dtParts.Rows[i]["DeliveryCost"]);
                                        if (partCount > 0 && deliveryCost > 0)
                                        {
                                            more = Math.Round(deliveryCost / partCount / qty, 0);
                                        }
                                        decimal price = TextUtils.ToDecimal(dtParts.Rows[i]["Price"]) + more;
                                        decimal totalPrice = qty * price;

                                        workSheet.Cells[3, 1] = i + 1;
                                        workSheet.Cells[3, 2] = TextUtils.ToString(dtParts.Rows[i]["PartsName"]);
                                        workSheet.Cells[3, 3] = TextUtils.ToString(dtParts.Rows[i]["PartsCode"]);
                                        workSheet.Cells[3, 4] = "";
                                        workSheet.Cells[3, 5] = TextUtils.ToString(dtParts.Rows[i]["Unit"]);
                                        workSheet.Cells[3, 6] = qty;
                                        workSheet.Cells[3, 7] = price;
                                        workSheet.Cells[3, 8] = totalPrice;
                                        workSheet.Cells[3, 9] = "";
                                        workSheet.Cells[3, 10] = "";
                                        workSheet.Cells[3, 11] = TextUtils.ToString(dtParts.Rows[i]["ManufacturerCode"]);
                                        workSheet.Cells[3, 12] = TextUtils.ToString(dtParts.Rows[i]["StoreCode"]);
                                        workSheet.Cells[3, 13] = TextUtils.ToString(dtParts.Rows[i]["GroupCode"]);
                                        workSheet.Cells[3, 14] = TextUtils.ToString(dtParts.Rows[i]["AccountCode"]);
                                        workSheet.Cells[3, 15] = "C27";
                                        workSheet.Cells[3, 16] = orderCode;
                                        workSheet.Cells[3, 20] = TextUtils.ToDecimal(dtParts.Rows[i]["Price"]);
                                        ((Excel.Range)workSheet.Rows[3]).Insert();
                                    }

                                    workSheet.Cells[3, 2] = "VTSXC";
                                    if (moduleCode != "")
                                    {
                                        workSheet.Cells[3, 4] = projectCode + "." + moduleCode;
                                    }
                                    else
                                    {
                                        workSheet.Cells[3, 4] = "VTSXC";
                                    }
                                    ((Excel.Range)workSheet.Rows[3]).Insert();
                                    #endregion
                                }
                            }
                        }

                        ((Excel.Range)workSheet.Rows[2]).Delete();
                        ((Excel.Range)workSheet.Rows[2]).Delete();
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
                    Process.Start(currentPath);
                }
            }
        }

        private void btnCompletedKcs_Click(object sender, EventArgs e)
        {
            int status = TextUtils.ToInt(grvDNNK.GetFocusedRowCellValue(colStatus));
            if (status != 2) return;

            DataTable dtUserKCS = LibQLSX.Select("select top 1 * from Users where Account = '" + Global.AppUserName + "'");
            if (dtUserKCS.Rows.Count == 0)
            {
                MessageBox.Show("Tài khoản đăng nhập không có trên QLSX", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc muốn hoàn thành KCS các vật tư này?", TextUtils.Caption, 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;            

            int importType = TextUtils.ToInt(grvDNNK.GetFocusedRowCellValue(colImportType));

            try
            {
                foreach (int i in grvData.GetSelectedRows())
                {
                    string userIdKcs = TextUtils.ToString(grvData.GetRowCellValue(i, colUserIdKCS));
                    if (userIdKcs != "") continue;

                    if (importType == 1)
                    {
                        #region Hoàn thành kiểu vật tư
                        string productPartsImportId = TextUtils.ToString(grvData.GetRowCellValue(i, colProductPartsImportId));

                        ArrayList arr = ProductPartsImportBO.Instance.FindByAttribute("ProductPartsImportId", productPartsImportId);
                        ProductPartsImportModel ProductPartsImport = (ProductPartsImportModel)arr[0];

                        //CriteriaImportBO.Instance.DeleteByAttribute("ProductPartsImportId", productPartsImportId);

                        
                        ProductPartsImport.TotalKCS = ProductPartsImport.Total;
                        ProductPartsImport.TotalOK = ProductPartsImport.Total;
                        ProductPartsImport.TotalNG = 0;
                        ProductPartsImport.UserId = TextUtils.ToString(dtUserKCS.Rows[0]["UserId"]);
                        ProductPartsImportBO.Instance.UpdateQLSX(ProductPartsImport);
                        #endregion
                    }
                    else
                    {
                        #region Hoàn thành kiểu thành phẩm
                        string projectProductImportId = TextUtils.ToString(grvData.GetRowCellValue(i, colProjectProductImportId));

                        ArrayList arr = ProjectProductImportBO.Instance.FindByAttribute("ProjectProductImportId", projectProductImportId);
                        ProjectProductImportModel ProjectProductImport = (ProjectProductImportModel)arr[0];

                        //CriteriaImportBO.Instance.DeleteByAttribute("ProductPartsImportId", projectProductImportId);
                       
                        ProjectProductImport.TotalKCS = ProjectProductImport.Total;
                        ProjectProductImport.TotalOK = ProjectProductImport.Total;
                        ProjectProductImport.TotalNG = 0;
                        ProjectProductImport.UserId = TextUtils.ToString(dtUserKCS.Rows[0]["UserId"]);
                        ProjectProductImportBO.Instance.UpdateQLSX(ProjectProductImport);
                        #endregion
                    }
                }

                loadItem();

                MessageBox.Show("Hoàn thành KCS thành công!", TextUtils.Caption,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tác vụ không thành công!" + Environment.NewLine + ex.Message, TextUtils.Caption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //pt.CloseConnection();
            }
        }

        private void btnConfirmKcs_Click(object sender, EventArgs e)
        {
            DataTable dtUserKCS = LibQLSX.Select("select top 1 * from Users where Account = '" + Global.AppUserName + "'");
            if (dtUserKCS.Rows.Count == 0)
            {
                MessageBox.Show("Tài khoản đăng nhập không có trên QLSX", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //pt.CloseConnection();
                return;
            }

            DataTable dtItem = (DataTable)grdData.DataSource;
            DataRow[] drs = dtItem.Select("UserNameKCS = '' or UserNameKCS is null");

            if (drs.Length > 0)
            {
                MessageBox.Show("ĐNNK chưa hoàn thành KCS.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc muốn yêu cầu nhập kho cho ĐNNK này?", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;

            string importId = TextUtils.ToString(grvDNNK.GetFocusedRowCellValue(colImportId));

            if (importId == "")
                return;

            try
            {
                ArrayList arr = RequestImportWarehouseBO.Instance.FindByAttribute("ImportId", importId);
                RequestImportWarehouseModel RequestImportWarehouse = (RequestImportWarehouseModel)arr[0];
                RequestImportWarehouse.DateKCS = DateTime.Now;
                RequestImportWarehouse.Status = 4;
                RequestImportWarehouseBO.Instance.UpdateQLSX(RequestImportWarehouse);

                MessageBox.Show("Yêu cầu nhập kho thành công.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);

                loadImport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelYCNhapKho_Click(object sender, EventArgs e)
        {
            DataTable dtUserKCS = LibQLSX.Select("select top 1 * from Users where Account = '" + Global.AppUserName + "'");
            if (dtUserKCS.Rows.Count == 0)
            {
                MessageBox.Show("Tài khoản đăng nhập không có trên QLSX", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //pt.CloseConnection();
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc muốn hủy yêu cầu nhập kho cho ĐNNK này?", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;

            string importId = TextUtils.ToString(grvDNNK.GetFocusedRowCellValue(colImportId));

            if (importId == "")
                return;

            try
            {
                ArrayList arr = RequestImportWarehouseBO.Instance.FindByAttribute("ImportId", importId);
                RequestImportWarehouseModel RequestImportWarehouse = (RequestImportWarehouseModel)arr[0];
                if (RequestImportWarehouse.Status == 5)
                {
                    MessageBox.Show("Không thể hủy yêu cầu nhập kho.\nYêu cầu nhập kho này đã được nhập kho.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                RequestImportWarehouse.DateKCS = DateTime.Now;
                RequestImportWarehouse.Status = 2;
                RequestImportWarehouseBO.Instance.UpdateQLSX(RequestImportWarehouse);

                MessageBox.Show("Hủy yêu cầu nhập kho thành công.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);

                loadImport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelConfirmKCS_Click(object sender, EventArgs e)
        {
            int status = TextUtils.ToInt(grvDNNK.GetFocusedRowCellValue(colStatus));
            if (status != 2) return;

            DataTable dtUserKCS = LibQLSX.Select("select top 1 * from Users where Account = '" + Global.AppUserName + "'");
            if (dtUserKCS.Rows.Count == 0)
            {
                MessageBox.Show("Tài khoản đăng nhập không có trên QLSX", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc muốn hủy hoàn thành KCS cho những vật tư này?",TextUtils.Caption,
                MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.No) return;

            int importType = TextUtils.ToInt(grvDNNK.GetFocusedRowCellValue(colImportType));

            try
            {
                foreach (int i in grvData.GetSelectedRows())
                {
                    string userIdKcs = TextUtils.ToString(grvData.GetRowCellValue(i, colUserIdKCS));
                    //if (userIdKcs != "") continue;

                    if (importType == 1)
                    {
                        #region Hủy hoàn thành kiểu vật tư
                        string productPartsImportId = TextUtils.ToString(grvData.GetRowCellValue(i, colProductPartsImportId));

                        ArrayList arr = ProductPartsImportBO.Instance.FindByAttribute("ProductPartsImportId", productPartsImportId);
                        ProductPartsImportModel ProductPartsImport = (ProductPartsImportModel)arr[0];

                        CriteriaImportBO.Instance.DeleteByAttribute("ProductPartsImportId", productPartsImportId);

                        ProductPartsImport.TotalOK = 0;
                        ProductPartsImport.TotalNG = ProductPartsImport.Total;
                        ProductPartsImport.TotalKCS = 0;
                        ProductPartsImport.UserId = "";
                        ProductPartsImportBO.Instance.UpdateQLSX(ProductPartsImport);
                        #endregion
                    }
                    else
                    {
                        #region Hủy hoàn thành kiểu thành phẩm
                        string projectProductImportId = TextUtils.ToString(grvData.GetRowCellValue(i, colProjectProductImportId));

                        ArrayList arr = ProjectProductImportBO.Instance.FindByAttribute("ProjectProductImportId", projectProductImportId);
                        ProjectProductImportModel ProjectProductImport = (ProjectProductImportModel)arr[0];

                        CriteriaImportBO.Instance.DeleteByAttribute("ProductPartsImportId", projectProductImportId);

                        ProjectProductImport.TotalOK = 0;
                        ProjectProductImport.TotalNG = ProjectProductImport.Total;
                        ProjectProductImport.TotalKCS = 0;
                        ProjectProductImport.UserId = "";
                        ProjectProductImportBO.Instance.UpdateQLSX(ProjectProductImport);
                        #endregion
                    }
                }

                loadItem();

                MessageBox.Show("Hủy hoàn thành KCS thành công!", TextUtils.Caption,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tác vụ không thành công!" + Environment.NewLine + ex.Message, TextUtils.Caption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //pt.CloseConnection();
            }
        }

        DataTable getProject(string partCode)
        {
            string sql = "select distinct [ProjectCode] from [ProductionManagement].[dbo].[vGetDNNKofPart] where PartsCode = '" + partCode + "'"
                          + " union"
                          + " select distinct [ProjectCode] from [ProductionManagement].[dbo].[vGetDNXKofPart] where PartsCode = '" + partCode + "'"
                          + " order by [ProjectCode]";
            DataTable dt = LibQLSX.Select(sql);
            return dt;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string path = "";

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path = fbd.SelectedPath;
            }
            else
            {
                return;
            }

            string filePath = Application.StartupPath + "\\Templates\\PhongKeToan\\BaoCaoTonKho.xlsx";
            string currentPath = path + "\\BaoCaoTonKho-" + DateTime.Now.ToString("ddMMyyyy") + ".xls";

            try
            {
                File.Copy(filePath, currentPath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi tạo biểu mẫu!" + Environment.NewLine + ex.Message,
                    TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }            

            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo biểu mẫu..."))
            {
                DataTable dtPart = LibQLSX.Select("select * from vParts with(nolock) where Inventory > 0");
                DataTable dtDNNK = LibQLSX.Select("select * from vGetDNNKofPart with(nolock) where Inventory > 0");
                DataTable dtDNXK = LibQLSX.Select("select * from vGetDNXKofPart with(nolock) where Inventory > 0");

                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                Excel.Application app = default(Excel.Application);
                Excel.Workbook workBoook = default(Excel.Workbook);
                Excel.Worksheet workSheet = default(Excel.Worksheet);
                try
                {
                    app = new Excel.Application();
                    app.Workbooks.Open(currentPath);
                    workBoook = app.Workbooks[1];
                    workSheet = (Excel.Worksheet)workBoook.Worksheets[1];

                    for (int i = dtPart.Rows.Count - 1; i >= 0; i--)
                    {
                        string partCode = TextUtils.ToString(dtPart.Rows[i]["PartsCode"]);
                        string partName = TextUtils.ToString(dtPart.Rows[i]["PartsName"]);
                        DataTable dtProject = getProject(partCode);

                        for (int j = 0; j < dtProject.Rows.Count; j++)
                        {
                            string projectCode = TextUtils.ToString(dtProject.Rows[j]["ProjectCode"]);
                            DataRow[] drsDNNK = dtDNNK.Select("PartsCode = '" + partCode + "' and ProjectCode = '" + projectCode + "'");
                            DataRow[] drsDNXK = dtDNXK.Select("PartsCode = '" + partCode + "' and ProjectCode = '" + projectCode + "'");

                            int count = drsDNNK.Length > drsDNXK.Length ? drsDNNK.Length : drsDNXK.Length;

                            for (int ii = 0; ii < count; ii++)
                            {
                                workSheet.Cells[4, 1] = partCode;
                                workSheet.Cells[4, 2] = partName;
                                workSheet.Cells[4, 3] = "";

                                decimal price = 0;

                                try
                                {
                                    workSheet.Cells[4, 4] = TextUtils.ToString(drsDNNK[ii]["ImportCode"]);
                                    workSheet.Cells[4, 5] = TextUtils.ToString(drsDNNK[ii]["OrderCode"]);
                                    workSheet.Cells[4, 6] = TextUtils.ToString(drsDNNK[ii]["RequestCode"]);
                                    workSheet.Cells[4, 7] = TextUtils.ToString(drsDNNK[ii]["ProjectCode"]);
                                    workSheet.Cells[4, 8] = "";
                                    workSheet.Cells[4, 9] = TextUtils.ToString(drsDNNK[ii]["TotalOK"]);
                                    workSheet.Cells[4, 10] = TextUtils.ToString(drsDNNK[ii]["Price"]);
                                    workSheet.Cells[4, 11] = TextUtils.ToDecimal(drsDNNK[ii]["TotalOK"]) * TextUtils.ToDecimal(drsDNNK[ii]["Price"]);
                                    price = TextUtils.ToDecimal(drsDNNK[ii]["Price"]); 
                                }
                                catch
                                {                                  
                                }

                                try
                                {
                                    workSheet.Cells[4, 12] = TextUtils.ToString(drsDNXK[ii]["DeliveryOrderCode"]);
                                    workSheet.Cells[4, 13] = TextUtils.ToString(drsDNXK[ii]["ProjectCode"]);
                                    workSheet.Cells[4, 14] = "";
                                    workSheet.Cells[4, 15] = TextUtils.ToString(drsDNXK[ii]["TotalDelivery"]);
                                    workSheet.Cells[4, 16] = 0;
                                    workSheet.Cells[4, 17] = TextUtils.ToDecimal(drsDNXK[ii]["TotalDelivery"]) * price;       
                                }
                                catch
                                {                                  
                                }

                                ((Excel.Range)workSheet.Rows[4]).Insert();
                            }
                            
                            ((Excel.Range)workSheet.Rows[4]).Insert();
                            ((Excel.Range)workSheet.Rows[4]).Insert();
                        }                        

                        ((Excel.Range)workSheet.Rows[4]).Insert();
                        ((Excel.Range)workSheet.Rows[4]).Insert();
                        ((Excel.Range)workSheet.Rows[4]).Insert();
                        ((Excel.Range)workSheet.Rows[4]).Insert();
                    }
                    ((Excel.Range)workSheet.Rows[3]).Delete();
                    ((Excel.Range)workSheet.Rows[3]).Delete();
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
                Process.Start(currentPath);
            }
        }

        private void btnErrorCompleteKCS_Click(object sender, EventArgs e)
        {
            int status = TextUtils.ToInt(grvDNNK.GetFocusedRowCellValue(colStatus));
            if (status != 2) return;

            DataTable dtUserKCS = LibQLSX.Select("select top 1 * from Users where Account = '" + Global.AppUserName + "'");
            if (dtUserKCS.Rows.Count == 0)
            {
                MessageBox.Show("Tài khoản đăng nhập không có trên QLSX", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            int typeError = 0;
            string valueResult = "";

            DialogResult result = MessageBox.Show("Chọn: \n 'Yes' - Hoàn thành lỗi KCS \n 'No' - Hoàn thành hàng chưa về", 
                TextUtils.Caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel) return;
            if (result == DialogResult.Yes)
            {
                typeError = 0;
                valueResult = "Lỗi";
            }
            if (result == DialogResult.No)
            {
                typeError = 1;
                valueResult = "Hàng chưa về";
            }

            int importType = TextUtils.ToInt(grvDNNK.GetFocusedRowCellValue(colImportType));

            try
            {
                foreach (int i in grvData.GetSelectedRows())
                {
                    string userIdKcs = TextUtils.ToString(grvData.GetRowCellValue(i, colUserIdKCS));
                    if (userIdKcs != "") continue;

                    if (importType == 1)
                    {
                        #region Hoàn thành kiểu vật tư
                        string productPartsImportId = TextUtils.ToString(grvData.GetRowCellValue(i, colProductPartsImportId));

                        ArrayList arr = ProductPartsImportBO.Instance.FindByAttribute("ProductPartsImportId", productPartsImportId);
                        ProductPartsImportModel ProductPartsImport = (ProductPartsImportModel)arr[0];
                        if (typeError == 0)
                        {
                            CriteriaImportBO.Instance.DeleteByAttribute("ProductPartsImportId", productPartsImportId);

                            for (int j = 0; j < ProductPartsImport.Total; j++)
                            {
                                CriteriaImportModel model = new CriteriaImportModel();
                                model.CriteriaIndex = j + 1;
                                model.IsHalf = false;
                                model.ProductPartsImportId = ProductPartsImport.ProductPartsImportId;
                                model.Status = 0;
                                model.ValueResult = valueResult;
                                model.CriteriaName = "Đúng thông số, kích thước kỹ thuật.";
                                model.ValueRequest = "Vật tư, thiết bị đảm bảo chất lượng.";
                                model.CountError = 1;

                                DataTable dt = LibQLSX.Select("SELECT top 1 CriteriaImportId FROM CriteriaImport order by CriteriaImportId desc");
                                if (dt.Rows.Count > 0)
                                {
                                    string criteriaImportId = TextUtils.ToString(dt.Rows[0]["CriteriaImportId"]);
                                    string number = criteriaImportId.Substring(2, 8);
                                    criteriaImportId = "CI" + string.Format("{0:00000000}", TextUtils.ToInt(number) + 1);
                                    model.CriteriaImportId = criteriaImportId;
                                }

                                CriteriaImportBO.Instance.InsertQLSX(model);
                            }
                            ProductPartsImport.TotalKCS = ProductPartsImport.Total;
                            ProductPartsImport.TotalOK = 0;
                            ProductPartsImport.TotalNG = ProductPartsImport.Total;
                            ProductPartsImport.CountError += 1;
                            ProductPartsImport.LevelError = 0;
                        }
                        else
                        {
                            ProductPartsImport.TotalKCS = 0;
                            ProductPartsImport.TotalOK = 0;
                            ProductPartsImport.TotalNG = 0;
                        }
                        
                        ProductPartsImport.UserId = TextUtils.ToString(dtUserKCS.Rows[0]["UserId"]);
                        ProductPartsImportBO.Instance.UpdateQLSX(ProductPartsImport);
                        #endregion
                    }
                    else
                    {
                        #region Hoàn thành kiểu thành phẩm
                        string projectProductImportId = TextUtils.ToString(grvData.GetRowCellValue(i, colProjectProductImportId));

                        ArrayList arr = ProjectProductImportBO.Instance.FindByAttribute("ProjectProductImportId", projectProductImportId);
                        ProjectProductImportModel ProjectProductImport = (ProjectProductImportModel)arr[0];

                        if (typeError == 0)
                        {
                            CriteriaImportBO.Instance.DeleteByAttribute("ProductPartsImportId", projectProductImportId);

                            for (int j = 0; j < ProjectProductImport.Total; j++)
                            {
                                CriteriaImportModel model = new CriteriaImportModel();
                                model.CriteriaIndex = j + 1;
                                model.IsHalf = false;
                                model.ProductPartsImportId = ProjectProductImport.ProjectProductImportId;
                                model.Status = 0;
                                model.ValueResult = valueResult;
                                model.CriteriaName = "Đúng thông số, kích thước kỹ thuật.";
                                model.ValueRequest = "Vật tư, thiết bị đảm bảo chất lượng.";

                                DataTable dt = LibQLSX.Select("SELECT top 1 CriteriaImportId FROM CriteriaImport order by CriteriaImportId desc");
                                if (dt.Rows.Count > 0)
                                {
                                    string criteriaImportId = TextUtils.ToString(dt.Rows[0]["CriteriaImportId"]);
                                    string number = criteriaImportId.Substring(2, 8);
                                    criteriaImportId = "CI" + string.Format("{0:00000000}", TextUtils.ToInt(number) + 1);
                                    model.CriteriaImportId = criteriaImportId;
                                }

                                CriteriaImportBO.Instance.InsertQLSX(model);
                            }

                            ProjectProductImport.TotalKCS = ProjectProductImport.Total;
                            ProjectProductImport.TotalOK = 0;
                            ProjectProductImport.TotalNG = ProjectProductImport.Total;
                        }
                        else
                        {
                            ProjectProductImport.TotalKCS = 0;
                            ProjectProductImport.TotalOK = 0;
                            ProjectProductImport.TotalNG = 0;
                        }
                        
                        ProjectProductImport.UserId = TextUtils.ToString(dtUserKCS.Rows[0]["UserId"]);
                        ProjectProductImportBO.Instance.UpdateQLSX(ProjectProductImport);
                        #endregion
                    }
                }

                loadItem();

                MessageBox.Show("Hoàn thành KCS thành công!", TextUtils.Caption,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tác vụ không thành công!" + Environment.NewLine + ex.Message, TextUtils.Caption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //pt.CloseConnection();
            }
        }
    }
}
