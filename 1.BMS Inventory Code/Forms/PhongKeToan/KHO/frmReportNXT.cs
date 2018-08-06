using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPA.Model;
using TPA.Business;
using DevExpress.XtraGrid.Views.Grid;
using System.Diagnostics;
using DevExpress.Utils;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace BMS
{
    public partial class frmReportNXT : _Forms
    {
        DataTable _dtData = new DataTable();
        int _rownIndex = 0;
        public frmReportNXT()
        {
            InitializeComponent();
        }

        private void frmReportVoucher_Load(object sender, EventArgs e)
        {
            //loadData();
        }       

        void loadData()
        {
            string[] _paraName = new string[1];
            object[] _paraValue = new object[1];

            _paraName[0] = "@Type"; _paraValue[0] = TextUtils.ToInt(cboType.SelectedIndex);

            _dtData = LibIE.LoadDataFromSP("spGetReportNXT", "Source", _paraName, _paraValue);
            grdData.DataSource = _dtData;
            if (_rownIndex >= grvData.RowCount)
                _rownIndex = 0;
            if (_rownIndex > 0)
                grvData.FocusedRowHandle = _rownIndex;
            grvData.SelectRow(_rownIndex);
            grvData.BestFitColumns();
        }


        private void btnFind_Click(object sender, EventArgs e)
        {
            loadData();
        }


        private void cboUser_EditValueChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnExeclReport_Click(object sender, EventArgs e)
        {
            //string path = "";
            //FolderBrowserDialog fbd = new FolderBrowserDialog();
            //if (fbd.ShowDialog() == DialogResult.OK)
            //{
            //    path = fbd.SelectedPath;
            //}
            //else
            //{
            //    return;
            //}

            //string filePath = Application.StartupPath + "\\Templates\\PhongKeToan\\BangTheoDoiChungTu.xlsx";
            //string currentPath = path + "\\BangTheoDoiChungTu.xlsx";
            //try
            //{
            //    File.Copy(filePath, currentPath, true);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Có lỗi khi tạo báo cáo!" + Environment.NewLine + ex.Message,
            //        TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}

            //using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo báo cáo..."))
            //{
            //    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            //    Excel.Application app = default(Excel.Application);
            //    Excel.Workbook workBoook = default(Excel.Workbook);
            //    Excel.Worksheet workSheet = default(Excel.Worksheet);
            //    try
            //    {
            //        app = new Excel.Application();
            //        app.Workbooks.Open(currentPath);
            //        workBoook = app.Workbooks[1];
            //        workSheet = (Excel.Worksheet)workBoook.Worksheets[1];

            //        for (int i = grvData.RowCount - 1; i >= 0; i--)
            //        {
            //            string number = TextUtils.ToString(grvData.GetRowCellValue(i, colNumber));
            //            workSheet.Cells[6, 1] = i + 1;
            //            workSheet.Cells[6, 2] = number;
            //            workSheet.Cells[6, 3] = TextUtils.ToString(grvData.GetRowCellValue(i, colItemCode));
            //            workSheet.Cells[6, 4] = TextUtils.ToString(grvData.GetRowCellValue(i, colItemName));
            //            workSheet.Cells[6, 5] = TextUtils.ToString(grvData.GetRowCellValue(i, colVoucherName));
            //            workSheet.Cells[6, 6] = TextUtils.ToString(grvData.GetRowCellValue(i, colUserName));
            //            workSheet.Cells[6, 7] = TextUtils.ToString(grvData.GetRowCellDisplayText(i, colCreatedDate));
            //            workSheet.Cells[6, 8] = TextUtils.ToString(grvData.GetRowCellDisplayText(i, colCompletedDateDK));
            //            if (number != "")
            //            {
            //                ((Excel.Range)workSheet.Rows[6]).Insert();
            //            }
            //        }
            //        ((Excel.Range)workSheet.Rows[5]).Delete();
            //        ((Excel.Range)workSheet.Rows[5]).Delete();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //    finally
            //    {
            //        if (app != null)
            //        {
            //            app.ActiveWorkbook.Save();
            //            app.Workbooks.Close();
            //            app.Quit();
            //        }
            //    }
            //    Process.Start(currentPath);
            //}

            TextUtils.ExportExcel(grvData);
        }

        private void cboType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //loadData();
        }

        private void grvData_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;
            GridView View = sender as GridView;
            DateTime ngayLap = TextUtils.ToDate(View.GetRowCellValue(e.RowHandle, colC_NGAYLAP).ToString());
            decimal chenhLech = TextUtils.ToDecimal(View.GetRowCellValue(e.RowHandle, colChenhLech));
            
            if (chenhLech <= 0)
            {
                e.Appearance.BackColor = Color.GreenYellow;
            }
            else
            {
                TimeSpan span = DateTime.Now.Date - ngayLap.Date;
                int totalDay = span.Days;
                if (totalDay >= 7)
                {
                    e.Appearance.BackColor = Color.Yellow;
                }
            }
        }

        private void grvData_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string[] _paraName = new string[3];
            object[] _paraValue = new object[3];

            _paraName[0] = "@VthhID"; _paraValue[0] = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colFK_VTHH));
            _paraName[1] = "@DtcpID"; _paraValue[1] = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colFK_DTCP));
            _paraName[2] = "@ProjectCode"; _paraValue[2] = TextUtils.ToString(grvData.GetFocusedRowCellValue(colDuAn));

            DataTable dt = LibIE.LoadDataFromSP("spGetXT", "Source", _paraName, _paraValue);
            grdXuat.DataSource = dt;
        }

    }
}
