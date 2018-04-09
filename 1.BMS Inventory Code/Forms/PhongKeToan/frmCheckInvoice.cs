using DevExpress.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace BMS
{
    public partial class frmCheckInvoice : _Forms
    {
        public frmCheckInvoice()
        {
            InitializeComponent();
        }

        private void frmReportVAT_XNTC_Order_Load(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Location = new Point(this.Location.X, 0);
            loadProject();
        }

        void loadProject()
        {
            try
            {
                //DataTable tbl = LibQLSX.Select("exec spGetAllProject");
                DataTable tbl = LibQLSX.Select("select * from Project");
                TextUtils.PopulateCombo(cboProject, tbl, "ProjectCode", "ProjectId", "");
            }
            catch (Exception ex)
            {
            }
        }

        void loadData()
        {
            string projectId = TextUtils.ToString(cboProject.EditValue);
            if (projectId == "") return;

            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load dữ liệu..."))
            {
                string sql = "spGetOrderOfProject '" + projectId + "'";
                DataTable dt = LibQLSX.Select(sql);
                dt.Columns.Add("ChenhLech", typeof(decimal));
                foreach (DataRow row in dt.Rows)
                {
                    decimal totalVAT = TextUtils.ToDecimal(row["TotalVAT"]);
                    string orderCode = TextUtils.ToString(row["OrderCode"]);
                   
                    decimal totalInvoice = 0;
                    string sql1 = "select sum(T_XNTC.C_PSNO) FROM T_XNTC INNER JOIN T_DM_VUVIEC ON T_XNTC.FK_VUVIEC = T_DM_VUVIEC.PK_ID" +
                            " WHERE (T_DM_VUVIEC.C_MA = '" + orderCode + "') AND (T_XNTC.FK_TKNO LIKE '133%')";
                    totalInvoice = TextUtils.ToDecimal(LibIE.ExcuteScalar(sql1));

                    row["ChenhLech"] = totalVAT - totalInvoice;
                }
                grdData.DataSource = dt;
            }
        }

        private void btnReloadData_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void grvData_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string orderCode = TextUtils.ToString(grvData.GetFocusedRowCellValue(colOrderCode));

            string sql = "SELECT    T_XNTC.PK_ID, T_XNTC.FK_CHUNGTU, T_XNTC.C_SOPHIEU,[C_DIENGIAI] ,T_XNTC.C_NGAYLAP, T_XNTC.C_NGAYCT, T_XNTC.C_SOCT, " +
                            " T_XNTC.FK_PHONGBAN, T_XNTC.FK_TKNO, T_XNTC.FK_TKCO, T_XNTC.C_PSNO, T_XNTC.C_PSCO, T_XNTC.FK_VUVIEC, " +
                            " T_XNTC.FK_USER, T_XNTC.FK_ORDER, T_XNTC.C_PSNO2, T_XNTC.C_PSCO2, T_XNTC.C_TIENTHUE2, T_DM_VUVIEC.C_MA, T_XNTC.C_NGUOILH" +
                            ",InvoiceNumber = (CASE WHEN [C_DIENGIAI2] IS NULL OR [C_DIENGIAI2] = '' THEN (case when [C_SOHDGTGT] IS NULL OR [C_SOHDGTGT] = '' THEN [C_DIENGIAI] ELSE [C_SOHDGTGT] END) ELSE [C_DIENGIAI2] END)" +
                        " FROM     T_XNTC INNER JOIN T_DM_VUVIEC ON T_XNTC.FK_VUVIEC = T_DM_VUVIEC.PK_ID" +
                        " WHERE    (T_DM_VUVIEC.C_MA = '" + orderCode + "') AND (T_XNTC.FK_TKNO LIKE '133%')";

            DataTable dt = LibIE.Select(sql);
            grdInvoice.DataSource = dt;
        }

        private void btnExecl_Click(object sender, EventArgs e)
        {
            if (cboProject.EditValue == null)
            {
                MessageBox.Show("Bạn phải chọn một dự án.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            string projectCode = TextUtils.ToString(grvProject.GetFocusedRowCellValue(colProjectCode));
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

            string filePath = Application.StartupPath + "\\Templates\\PhongKeToan\\KIEM TRA HOA DON.xls";
            string currentPath = path + "\\KIEM TRA HOA DON - " + projectCode + ".xls";
            try
            {
                File.Copy(filePath, currentPath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi xuất excel!" + Environment.NewLine + ex.Message,
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

                    workSheet.Cells[2, 3] = projectCode;

                    //DataTable dtItem = LibQLSX.Select("select * from vPaymentTableItem with(nolock) where PaymentTableID = " + PaymentTable.ID);
                    //DataTable dtSupplier = LibQLSX.Select("select Distinct SupplierCode from vPaymentTableItem with(nolock) where PaymentTableID = " + PaymentTable.ID);

                    for (int i = grvData.RowCount - 1; i >= 0; i--)
                    {
                        string orderCode = TextUtils.ToString(grvData.GetRowCellValue(i, colOrderCode));
                        string sql = "SELECT  T_XNTC.C_SOPHIEU,[C_DIENGIAI] ,T_XNTC.C_NGAYLAP, T_XNTC.C_NGAYCT, T_XNTC.C_SOCT, T_XNTC.C_PSNO, T_XNTC.C_PSCO, T_DM_VUVIEC.C_MA" +
                            ",InvoiceNumber = (CASE WHEN [C_DIENGIAI2] IS NULL OR [C_DIENGIAI2] = '' THEN (case when [C_SOHDGTGT] IS NULL OR [C_SOHDGTGT] = '' THEN [C_DIENGIAI] ELSE [C_SOHDGTGT] END) ELSE [C_DIENGIAI2] END)" +
                        " FROM     T_XNTC INNER JOIN T_DM_VUVIEC ON T_XNTC.FK_VUVIEC = T_DM_VUVIEC.PK_ID" +
                        " WHERE    (T_DM_VUVIEC.C_MA = '" + orderCode + "') AND (T_XNTC.FK_TKNO LIKE '133%')";

                        DataTable dt = LibIE.Select(sql);
                        decimal total = 0;

                        for (int j = dt.Rows.Count - 1; j >= 0; j--)
                        {
                            DateTime? date = TextUtils.ToDate2(dt.Rows[j]["C_NGAYCT"]);

                            workSheet.Cells[7, 9] = TextUtils.ToString(dt.Rows[j]["InvoiceNumber"]);
                            workSheet.Cells[7, 10] = date != null ? date.Value.ToString("dd/MM/yyyy") : "";
                            workSheet.Cells[7, 11] = TextUtils.ToString(dt.Rows[j]["C_PSNO"]);

                            total += TextUtils.ToDecimal(dt.Rows[j]["C_PSNO"]);
                            ((Excel.Range)workSheet.Rows[7]).Insert();
                        }

                        decimal chenhLech = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colChenhLech));

                        workSheet.Cells[7, 1] = i + 1;
                        workSheet.Cells[7, 2] = TextUtils.ToString(grvData.GetRowCellValue(i, colOrderCode));
                        workSheet.Cells[7, 3] = TextUtils.ToString(grvData.GetRowCellValue(i, colNCC));
                        workSheet.Cells[7, 4] = TextUtils.ToString(grvData.GetRowCellValue(i, colNguoiPhuTrach));
                        workSheet.Cells[7, 5] = TextUtils.ToString(grvData.GetRowCellValue(i, colTienHang));
                        workSheet.Cells[7, 6] = TextUtils.ToString(grvData.GetRowCellValue(i, colVAT));
                        workSheet.Cells[7, 7] = total;
                        workSheet.Cells[7, 8] = TextUtils.ToString(grvData.GetRowCellValue(i, colChenhLech));

                        ((Excel.Range)workSheet.Rows[7]).Font.Bold = true;
                        //((Excel.Range)workSheet.Rows[7]).Font.Size = 10;
                        if (chenhLech > 0)
                        {
                            ((Excel.Range)workSheet.Cells[7, 8]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);// Color.Yellow;
                        }
                        if (chenhLech < 0)
                        {
                            ((Excel.Range)workSheet.Cells[7, 8]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red); //Color.Red;
                        }
                        
                        //workSheet.Cells[7, 8].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightYellow);
                        ((Excel.Range)workSheet.Rows[7]).Insert();
                    }

                    ((Excel.Range)workSheet.Rows[6]).Delete();
                    ((Excel.Range)workSheet.Rows[6]).Delete();
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

        private void cboProject_EditValueChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void grvData_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == colChenhLech)
            {
                decimal value = TextUtils.ToDecimal(grvData.GetRowCellValue(e.RowHandle, colChenhLech));
                if (value > 0)
                {
                    e.Appearance.BackColor = Color.Yellow;
                }
                if (value < 0)
                {
                    e.Appearance.BackColor = Color.Red;
                }
            }
        }
    }
}
