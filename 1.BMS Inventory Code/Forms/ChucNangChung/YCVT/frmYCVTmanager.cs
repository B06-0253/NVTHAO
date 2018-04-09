using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using DevExpress.Utils;
using System.Diagnostics;

namespace BMS
{
    public partial class frmYCVTmanager : _Forms
    {
        public frmYCVTmanager()
        {
            InitializeComponent();
        }

        private void frmYCVTmanager_Load(object sender, EventArgs e)
        {
            loadDepartment();
        }

        #region Methods
        void loadUserFind()
        {
            ////load danh sach nhan vien phong vat tu
            //DataTable dt = LibQLSX.Select("Select * from [Users] WITH(NOLOCK) where StatusDisable = 0 and DepartmentId ='D004'");
            //cboUser.Properties.DataSource = dt;
            //cboUser.Properties.DisplayMember = "UserName";
            //cboUser.Properties.ValueMember = "UserId";
        }

        void loadDepartment()
        {
            DataTable dtD = LibQLSX.Select("select DepartmentId, DName from Departments with(nolock)");
            cboDepartment.DataSource = dtD;
            cboDepartment.DisplayMember = "DName";
            cboDepartment.ValueMember = "DepartmentId";
        }

        void loadProject()
        {
            //string sql = "";
            //if (cboProductType.SelectedIndex == 0)
            //{
            //    sql = "select distinct [ProjectId], [ProjectCode], [ProjectName], [Year], cast(0 as bit) as [check] from [vRequest] with(nolock) "
            //            + " where ([TotalOut] > 0) "
            //            + " and [ProductType] = 1"
            //            + " and [DepartmentId] = '" + TextUtils.ToString(cboDepartment.SelectedValue) + "'"
            //            + " order by [ProjectCode]";
            //}
            //if (cboProductType.SelectedIndex == 1)
            //{
            //    sql = "select distinct [ProjectId], [ProjectCode], [ProjectName], [Year], cast(0 as bit) as [check] from [vRequest] with(nolock) "
            //            + " where ([TotalPart] > 0) "
            //            + " and [ProductType] = 2"
            //            + " and [DepartmentId] = '" + TextUtils.ToString(cboDepartment.SelectedValue) + "'"
            //            + " order by [ProjectCode]";
            //}
            //if (cboProductType.SelectedIndex == 2)
            //{
            //    //sql = "select distinct [ProjectId], [ProjectCode], [ProjectName], [Year], cast(0 as bit) as [check] from [vRequest] with(nolock) "
            //    //        + " where ([TotalMaterial] > 0) "
            //    //        + " and [ProductType] = 3" 
            //    //        + " and [DepartmentId] = '" + TextUtils.ToString(cboDepartment.SelectedValue) + "'"
            //    //        + " order by [ProjectCode]";
            //}
            //if (sql == "")
            //    return;
            //DataTable dtP = LibQLSX.Select(sql);
            //grdProject.DataSource = dtP;
        }

        void addYCVT()
        {
            string sql = "";

            sql = "select * from [vRequest] with(nolock) "
                    + " where [DepartmentId] = '" + TextUtils.ToString(cboDepartment.SelectedValue) + "' order by [Year]";

            if (sql == "")
                return;
            DataTable dt = LibQLSX.Select(sql);
            grdYCVT.DataSource = dt;
        }

        void addRequestItem(string requestCode)
        {
            string sql = "";

            //sql = "select * from vRequirePartFull with(nolock) where RequestCode ='" + requestCode + "'";
            sql = "select *,(Price * TotalBuy) as TotalPrice from vRequestMaterial with(nolock) where RequestCode ='" + requestCode + "'";

            DataTable dt = LibQLSX.Select(sql);
            //DataRow[] drs = dt.Select("Price = 0 or Price is null");
            foreach (DataRow r in dt.Rows)
            {
                //string sqlM = "SELECT top 1 Price FROM  vGetPriceOfPart with(nolock)"
                //            + " WHERE Price > 1 AND replace(replace([PartsCode],'/','#'),')','#') = '" + TextUtils.ToString(r["PartsCode"]) + "'"
                //            + " ORDER BY DateAboutF DESC";
                //DataTable dtOrderPriceM = LibQLSX.Select(sqlM);

                string sqlM = "exec spGetPriceOfPart '" + TextUtils.ToString(r["PartsCode"]) + "'";
                DataTable dtOrderPriceM = LibQLSX.Select(sqlM);
                if (dtOrderPriceM.Rows.Count > 0)
                {
                    r["Price"] = TextUtils.ToDecimal(dtOrderPriceM.Rows[0][0]);
                    r["TotalPrice"] = TextUtils.ToDecimal(r["Price"]) * TextUtils.ToDecimal(r["TotalBuy"]);
                }
            }
            grdParts.DataSource = dt;
        }
        #endregion

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (grvParts.RowCount == 0) return;

            string requestCode = TextUtils.ToString(grvYCVT.GetFocusedRowCellValue(colRCode));

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

            string filePath = Application.StartupPath + "\\Templates\\PhongSXLR\\YCVT.xlsx";
            string currentPath = path + "\\YCVT-" + requestCode + ".xlsx";

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

                    workSheet.Cells[7, 1] = "(Số: " + requestCode + ")";
                    workSheet.Cells[9, 1] = "Bộ phận yêu cầu: SXLR";
                    workSheet.Cells[9, 3] = "Ngày yêu cầu: " + TextUtils.ToString(grvYCVT.GetFocusedRowCellDisplayText(colRDateCreate));
                    workSheet.Cells[9, 7] = "Ngày cần DK: " + TextUtils.ToString(grvYCVT.GetFocusedRowCellDisplayText(colRDateExpected));
                    //workSheet.Cells[9, 31] = "Ngày cần DK: ";
                    workSheet.Cells[15, 8] = "Tân Phát, ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;

                    for (int i = grvParts.RowCount - 1; i >= 0; i--)
                    {
                        workSheet.Cells[13, 1] = i+1;
                        workSheet.Cells[13, 2] = TextUtils.ToString(grvParts.GetRowCellValue(i, colRiPartsName));
                        workSheet.Cells[13, 3] = TextUtils.ToString(grvParts.GetRowCellValue(i, colRiPartCode));
                        workSheet.Cells[13, 4] = TextUtils.ToString(grvParts.GetRowCellValue(i, colRiOrigin));
                        workSheet.Cells[13, 5] = TextUtils.ToString(grvParts.GetRowCellValue(i, colRiUnit));
                        workSheet.Cells[13, 6] = TextUtils.ToString(grvParts.GetRowCellValue(i, colRiQty));
                        workSheet.Cells[13, 7] = "";
                        workSheet.Cells[13, 8] = "";
                        workSheet.Cells[13, 9] = TextUtils.ToString(grvParts.GetRowCellValue(i, colRiPrice));
                        workSheet.Cells[13, 10] = TextUtils.ToString(grvParts.GetRowCellValue(i, colRiTotalPrice));
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

        private void cboDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private void grvYCVT_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string RequestCode = TextUtils.ToString(grvYCVT.GetFocusedRowCellValue(colRCode));
            if (RequestCode == "") return;
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát", "Đang load vật tư"))
            {
                addRequestItem(RequestCode);
            }
        }

        private void grvParts_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            //if (e.RowHandle < 0) return;
            //GridView View = sender as GridView;
            //decimal price = TextUtils.ToInt(View.GetRowCellValue(e.RowHandle, colRiPrice));
            //if (price == 0)
            //{
            //    e.Appearance.BackColor = Color.Yellow;
            //}
        }

        private void grvParts_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colRiPrice)
            {
                decimal qty = TextUtils.ToInt(grvParts.GetRowCellValue(e.RowHandle, colRiQty));
                decimal price = TextUtils.ToInt(grvParts.GetRowCellValue(e.RowHandle, colRiPrice));
                grvParts.SetRowCellValue(e.RowHandle, colRiTotalPrice, qty * price);
            }
        }

        private void grvParts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == (Keys.C))
            {
                try
                {
                    string text = TextUtils.ToString(grvParts.GetFocusedRowCellValue(grvParts.FocusedColumn));
                    Clipboard.SetText(text);
                }
                catch
                {
                }
            }
        }

        private void grvYCVT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == (Keys.C))
            {
                try
                {
                    string text = TextUtils.ToString(grvYCVT.GetFocusedRowCellValue(grvYCVT.FocusedColumn));
                    Clipboard.SetText(text);
                }
                catch
                {
                }
            }
        }

        private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDepartment.SelectedValue == null) return;

            addYCVT();
        }
    }
}
