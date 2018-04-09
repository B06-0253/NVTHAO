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
using TPA.Model;
using System.IO;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;

namespace BMS
{
    public partial class frmPaymentTableManager : _Forms
    {
        int _rownIndex = 0;

        public frmPaymentTableManager()
        {
            InitializeComponent();
        }

        private void frmPaymentTableManager_Load(object sender, EventArgs e)
        {
            LoadInfoSearch();
        }

        void LoadInfoSearch()
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load dữ liệu..."))
            {
                try
                {
                    DataTable Source = LibQLSX.Select("select * from vPaymentTable with(nolock) where IsDeleted = 0");
                    grdData.DataSource = Source;
                    if (_rownIndex >= grvData.RowCount)
                        _rownIndex = 0;
                    if (_rownIndex > 0)
                        grvData.FocusedRowHandle = _rownIndex;
                    grvData.SelectRow(_rownIndex);
                    grvData.BestFitColumns();
                }
                catch
                {
                }
            }
        }

        void main_LoadDataChange(object sender, EventArgs e)
        {
            LoadInfoSearch();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmPaymentTableItem frm = new frmPaymentTableItem();
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            long id = TextUtils.ToInt64(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            PaymentTableModel model = (PaymentTableModel)PaymentTableBO.Instance.FindByPK(id);
            _rownIndex = grvData.FocusedRowHandle;

            frmPaymentTableItem frm = new frmPaymentTableItem();
            frm.PaymentTable = model;
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            long id = TextUtils.ToInt64(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            if (PaymentTableItemBO.Instance.CheckExist("PaymentTableID",id))
            {
                MessageBox.Show("Đề nghị thanh toán này đang chứa vụ việc nên không thể xóa được.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xóa bảng kê thanh toán [" + grvData.GetFocusedRowCellValue(colNumber).ToString() + "] không?",
                      TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            PaymentTableModel model = (PaymentTableModel)PaymentTableBO.Instance.FindByPK(id);
            model.IsDeleted = true;
            PaymentTableBO.Instance.Update(model);
            LoadInfoSearch();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            long id = TextUtils.ToInt64(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            PaymentTableModel PaymentTable = (PaymentTableModel)PaymentTableBO.Instance.FindByPK(id);
            
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

            string filePath = Application.StartupPath + "\\Templates\\BKTT.xlsx";
            string currentPath = path + "\\" + PaymentTable.Number + ".xlsx";
            try
            {
                File.Copy(filePath, currentPath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi tạo bảng kê thanh toán!" + Environment.NewLine + ex.Message,
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

                    workSheet.Cells[6, 1] = "(Số: " + PaymentTable.Number + ")";
                    workSheet.Cells[13, 8] = "Ngày " + DateTime.Now.ToString("dd/MM/yyyy");

                    DataTable dtItem = LibQLSX.Select("select * from PaymentTableItem with(nolock) where PaymentTableID = " + PaymentTable.ID);

                    for (int i = dtItem.Rows.Count - 1; i >= 0; i--)
                    {
                        workSheet.Cells[10, 1] = i + 1;
                        workSheet.Cells[10, 2] = TextUtils.ToString(dtItem.Rows[i]["Name"]);
                        workSheet.Cells[10, 3] = TextUtils.ToString(dtItem.Rows[i]["Content"]);
                        workSheet.Cells[10, 4] = TextUtils.ToString(dtItem.Rows[i]["Code"]);
                        workSheet.Cells[10, 5] = TextUtils.ToString(dtItem.Rows[i]["Target"]);
                        workSheet.Cells[10, 6] = TextUtils.ToString(dtItem.Rows[i]["TotalCash"]);
                        workSheet.Cells[10, 7] = TextUtils.ToString(dtItem.Rows[i]["TotalCK"]);
                        workSheet.Cells[10, 8] = TextUtils.ToString(dtItem.Rows[i]["ContentCheck"]);
                        workSheet.Cells[10, 9] = TextUtils.ToString(dtItem.Rows[i]["Note"]);
                        ((Excel.Range)workSheet.Rows[10]).Insert();
                    }
                    ((Excel.Range)workSheet.Rows[9]).Delete();
                    ((Excel.Range)workSheet.Rows[9]).Delete();
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

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void btnShowVoucher_Click(object sender, EventArgs e)
        {
            frmVouchers frm = new frmVouchers();
            frm.Show();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            frmReportVoucherDebt frm = new frmReportVoucherDebt();
            TextUtils.OpenForm(frm);
        }

        private void grvData_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0) return;
            GridView View = sender as GridView;
            int count = TextUtils.ToInt(View.GetRowCellValue(e.RowHandle, colTotalVoucherDebt));
            if (count > 0 && e.Column == colNumber)
            {
                e.Appearance.BackColor = Color.Yellow;
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadInfoSearch();
        }

        private void btnNotPay_Click(object sender, EventArgs e)
        {
            frmReportNotPay frm = new frmReportNotPay();
            TextUtils.OpenForm(frm);
        }

        private void btnPOyctt_Click(object sender, EventArgs e)
        {
            frmPOyctt frm = new frmPOyctt();
            TextUtils.OpenForm(frm);
        }
    }
}
