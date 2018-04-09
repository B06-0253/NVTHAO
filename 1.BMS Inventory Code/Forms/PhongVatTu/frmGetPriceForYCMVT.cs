using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using Forms.Properties;
using System.Net.Sockets;
using TPA.Utils;
using TPA.Business;
using TPA.Model;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Diagnostics;

namespace BMS
{
    public partial class frmGetPriceForYCMVT : _Forms
    {
        DataTable _dtItem = new DataTable();
        //string 

        public frmGetPriceForYCMVT()
        {
            InitializeComponent();
        }

        private void frmGetPriceForYCMVT_Load(object sender, EventArgs e)
        {
            loadUser();
            
            _dtItem = LibQLSX.Select("spGetPartWithYCMVT_All ''");
            //_dtItem.Columns.Add("PriceGN", typeof(decimal));
            //_dtItem.Columns.Add("ChenhLech", typeof(decimal));
            //_dtItem.Columns.Add("TotalChenhLech", typeof(decimal));
            //_dtItem.Columns.Add("DeliveryTime1", typeof(int));

            DataColumn col1 = new DataColumn();
            col1.DataType = System.Type.GetType("System.Decimal");
            col1.ColumnName = "ChenhLech";
            col1.DefaultValue = 50;
            col1.Expression = "Price - PriceDM";
            _dtItem.Columns.Add(col1);

            DataColumn col2 = new DataColumn();
            col2.DataType = System.Type.GetType("System.Decimal");
            col2.ColumnName = "TotalChenhLech";
            col2.DefaultValue = 50;
            col2.Expression = "TotalBuy*ChenhLech";
            _dtItem.Columns.Add(col2);

            grdData.DataSource = _dtItem;
        }

        void loadUser()
        {
            DataTable dt = LibQLSX.Select("Select * from [vUser] WITH(NOLOCK) where [DepartmentId] = 'D004' and StatusDisable <> 1");
            cboUser.DataSource = dt;
            cboUser.DisplayMember = "UserName";
            cboUser.ValueMember = "UserId";
        }

        private void cboUser_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string userid = TextUtils.ToString(cboUser.SelectedValue);
            string sql = "SELECT * ,year([DateCreate]) as Year,month([DateCreate]) as Month, cast(0 as bit) as [check] FROM [ProductionManagement].[dbo].[ProposalBuy] with(nolock) where UserId = '" + userid + "'";
            DataTable dt = LibQLSX.Select(sql);
            grdYCMVT.DataSource = dt;
        }

        private void grvYCMVT_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát", "Đang load giá..."))
            //{
            //    string code = TextUtils.ToString(grvYCMVT.GetFocusedRowCellValue(colCodeYC));
            //    DataTable dt = LibQLSX.Select("spGetPartWithYCMVT_All '" + code + "'");
            //    dt = TextUtils.GetDistinctDatatable(dt, "PartsCode");
            //    dt.Columns.Add("PriceGN", typeof(decimal));
            //    dt.Columns.Add("ChenhLech", typeof(decimal));
            //    dt.Columns.Add("DeliveryTime1", typeof(int));

            //    foreach (DataRow item in dt.Rows)
            //    {
            //        string partCode = TextUtils.ToString(item["PartsCode"]);
            //        string sql1 = "SELECT top 1 * FROM  vGetPriceOfPart with(nolock)"
            //                            + " WHERE Price > 1 AND replace(replace([PartsCode],'/','#'),')','#') = '"
            //                            + partCode.Replace(" ", "").Replace("/", "#").Replace(")", "#") + "'"
            //                            + " ORDER BY DateAboutF DESC";
            //        DataTable dtOrderPrice = LibQLSX.Select(sql1);
            //        if (dtOrderPrice.Rows.Count > 0)
            //        {
            //            item["PriceGN"] = TextUtils.ToDecimal(dtOrderPrice.Rows[0]["Price"]);
            //            item["DeliveryTime1"] = TextUtils.ToInt(dtOrderPrice.Rows[0]["DeliveryTime"]);
            //        }
            //        else
            //        {
            //            item["PriceGN"] = TextUtils.ToDecimal(item["Price"]);
            //            item["DeliveryTime1"] = TextUtils.ToInt(item["DeliveryTime"]);
            //        }
            //        item["ChenhLech"] = TextUtils.ToDecimal(item["Price"]) - TextUtils.ToDecimal(item["PriceGN"]);
            //    }

            //    grdData.DataSource = dt;
            //}
        }

        private void btnExeclGroup_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvData.RowCount > 0)
                {
                    string code = TextUtils.ToString(grvYCMVT.GetFocusedRowCellValue(colCodeYC));
                    FolderBrowserDialog fbd = new FolderBrowserDialog();
                    fbd.SelectedPath = Settings.Default.VT_PriceChenhLech;
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        Settings.Default.VT_PriceChenhLech = fbd.SelectedPath;
                        Settings.Default.Save();
                        TextUtils.ExportExcel(grvData, fbd.SelectedPath, "G_" + code);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnLoadPrice_Click(object sender, EventArgs e)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát", "Đang load giá..."))
            {
                foreach (DataRow item in _dtItem.Rows)
                {
                    string partCode = TextUtils.ToString(item["PartsCode"]);                   
                    string sql1 = "exec spGetPriceOfPart '" + partCode + "'";
                    DataTable dtOrderPrice = LibQLSX.Select(sql1);
                    if (dtOrderPrice.Rows.Count > 0)
                    {
                        item["PriceDM"] = TextUtils.ToDecimal(dtOrderPrice.Rows[0]["Price"]);
                        item["DeliveryTimeDM"] = TextUtils.ToInt(dtOrderPrice.Rows[0]["DeliveryTime"]);
                    }
                    else
                    {
                        item["PriceDM"] = TextUtils.ToDecimal(item["Price"]);
                        item["DeliveryTimeDM"] = TextUtils.ToInt(item["DeliveryTime"]);
                    }
                    //item["ChenhLech"] = TextUtils.ToDecimal(item["Price"]) - TextUtils.ToDecimal(item["PriceDM"]);
                    //item["TotalChenhLech"] = TextUtils.ToDecimal(item["TotalBuy"]) * TextUtils.ToDecimal(item["ChenhLech"]);
                }
                grdData.DataSource = _dtItem;
            }
        }

        private void btnImportPrice_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                DataTable dtPrice = TextUtils.ExcelToDatatableNoHeader(ofd.FileName, "Sheet1");
                for (int i = 0; i < grvData.RowCount; i++)
                {
                    string partsCode = TextUtils.ToString(grvData.GetRowCellValue(i, colCode));
                    decimal giaGanNhat = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colPriceGN));
                    decimal qty = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colTotalBuy));
                    DataRow[] drs = dtPrice.Select("F3 = '" + partsCode + "'");
                    if (drs.Length > 0)
                    {
                        decimal currentPrice = TextUtils.ToDecimal(drs[0]["F7"]);
                        grvData.SetRowCellValue(i, colPrice, currentPrice);
                        grvData.SetRowCellValue(i, colChenhLech, currentPrice - giaGanNhat);
                        //grvData.SetRowCellValue(i, colChenhLech, currentPrice - giaGanNhat);
                        grvData.SetRowCellValue(i, colTotalChenhLech, qty * (currentPrice - giaGanNhat));
                    }
                }
            }
        }

        void addItem(string YCMVTCode)
        {
            DataTable dtRi1 = LibQLSX.Select("spGetPartWithYCMVT_All '" + YCMVTCode + "'");
            _dtItem.Merge(dtRi1);
            grdData.DataSource = _dtItem;
        }

        private void grvYCMVT_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colCheck)
            {
                bool check = TextUtils.ToBoolean(grvYCMVT.GetFocusedRowCellValue(colCheck));
                string YCMVTCode = TextUtils.ToString(grvYCMVT.GetFocusedRowCellValue(colCodeYC));
                if (check)
                {
                    addItem(YCMVTCode);
                }
                else
                {
                    DataRow[] drs = _dtItem.Select("ProposalCode <> '" + YCMVTCode + "'");
                    if (drs.Length > 0)
                    {
                        _dtItem = drs.CopyToDataTable();
                    }
                    else
                    {
                        _dtItem.Rows.Clear();
                        //chkRAll.Checked = false;
                    }
                    grdData.DataSource = _dtItem;
                }
                //grvData.FocusedRowHandle = -1;
            }
        }

        private void repositoryItemCheckEdit1_EditValueChanged(object sender, EventArgs e)
        {
            grvYCMVT.PostEditor();
        }

        DataTable loadPartOfYCMVT(string proposalCode)
        {
            DataTable Source = LibQLSX.Select("spGetPartWithYCMVT_All '" + proposalCode + "'");
            DataTable dt = Source.Copy();
            dt.Rows.Clear();
            foreach (DataRow row in Source.Rows)
            {
                string code = TextUtils.ToString(row["PartsCode"]);
                decimal totalBuy = TextUtils.ToDecimal(row["TotalBuy"]);
                decimal total = TextUtils.ToDecimal(row["Total"]);
                decimal totalInventory = TextUtils.ToDecimal(row["TotalInventory"]);

                DataRow[] drs = dt.Select("PartsCode = '" + code + "'");
                if (drs.Length == 0)
                {
                    dt.ImportRow(row);
                }
                else
                {
                    drs[0]["TotalBuy"] = TextUtils.ToDecimal(drs[0]["TotalBuy"]) + totalBuy;
                    drs[0]["Total"] = TextUtils.ToDecimal(drs[0]["Total"]) + total;
                    drs[0]["TotalInventory"] = TextUtils.ToDecimal(drs[0]["TotalInventory"]) + totalInventory;                    
                }
            }
            return dt;
        }

        private void btnExportYCMVT_Click(object sender, EventArgs e)
        {
            string proposalCode = TextUtils.ToString(grvYCMVT.GetFocusedRowCellValue(colCodeYC));
            #region Tạo file yêu cầu báo giá
            string filePath = Application.StartupPath + "\\Templates\\PhongVT\\YCMVT_HS.xls";
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

            try
            {
                File.Copy(filePath, path + "\\" + proposalCode + ".xls", true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: File excel đang được mở.\n" + ex.Message);
                return;
            }

            DataTable dtParts = loadPartOfYCMVT(proposalCode);            

            Excel.Application app = default(Excel.Application);
            Excel.Workbook workBoook = default(Excel.Workbook);
            Excel.Worksheet workSheet = default(Excel.Worksheet);
            try
            {
                app = new Excel.Application();
                app.Workbooks.Open(path + "\\" + proposalCode + ".xls");
                workBoook = app.Workbooks[1];
                workSheet = (Excel.Worksheet)workBoook.Worksheets[1];

                workSheet.Cells[7, 1] = proposalCode;
                workSheet.Cells[16, 10] = "Tân Phát, ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
                workSheet.Cells[21, 12] = Global.AppFullName;

                int countPart = 0;
                for (int j = dtParts.Rows.Count - 1; j >= 0; j--)
                {
                    string partCode = TextUtils.ToString(dtParts.Rows[j]["PartsCode"]);
                    countPart++;

                    workSheet.Cells[14, 1] = j + 1;
                    workSheet.Cells[14, 2] = TextUtils.ToString(dtParts.Rows[j]["PartsName"]);
                    workSheet.Cells[14, 3] = TextUtils.ToString(dtParts.Rows[j]["PartsCode"]);
                    workSheet.Cells[14, 4] = TextUtils.ToString(dtParts.Rows[j]["Description"]);
                    workSheet.Cells[14, 5] = TextUtils.ToString(dtParts.Rows[j]["HsCode"]);
                    workSheet.Cells[14, 6] = TextUtils.ToString(dtParts.Rows[j]["ImportTax"]);

                    workSheet.Cells[14, 7] = TextUtils.ToDecimal(dtParts.Rows[j]["TotalBuy"]);
                    workSheet.Cells[14, 8] = TextUtils.ToDecimal(dtParts.Rows[j]["TotalInventory"]);
                    workSheet.Cells[14, 9] = TextUtils.ToString(dtParts.Rows[j]["Total"]);

                    workSheet.Cells[14, 10] = TextUtils.ToString(dtParts.Rows[j]["Unit"]);
                    workSheet.Cells[14, 11] = "";
                    workSheet.Cells[14, 12] = "";

                    workSheet.Cells[14, 13] = TextUtils.ToString(dtParts.Rows[j]["RequestCode"]);
                    workSheet.Cells[14, 14] = TextUtils.ToString(dtParts.Rows[j]["ProjectCode"]);
                    workSheet.Cells[14, 15] = TextUtils.ToString(dtParts.Rows[j]["ManufacturerCode"]);
                    ((Excel.Range)workSheet.Rows[14]).Insert();
                }

                ((Excel.Range)workSheet.Rows[13]).Delete();
                ((Excel.Range)workSheet.Rows[13]).Delete();

                //((Excel.Range)workSheet1.Rows[14]).Insert();
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
                    workSheet = null;
                    workBoook = null;
                    app.Workbooks.Close();
                    app.Quit();
                }
            }
            #endregion
            if (File.Exists(path + "\\" + proposalCode + ".xls"))
            {
                Process.Start(path + "\\" + proposalCode + ".xls");
            }
            
        }

        private void grvYCMVT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == (Keys.C))
            {
                try
                {
                    string text = TextUtils.ToString(grvYCMVT.GetFocusedRowCellValue(grvYCMVT.FocusedColumn));
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

        private void btnExportCK_Click(object sender, EventArgs e)
        {
            string proposalCode = TextUtils.ToString(grvYCMVT.GetFocusedRowCellValue(colCodeYC));
            #region Tạo file yêu cầu báo giá
            string filePath = Application.StartupPath + "\\Templates\\PhongVT\\YCMVT_CK.xls";
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

            try
            {
                File.Copy(filePath, path + "\\" + proposalCode + ".xls", true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: File excel đang được mở.\n" + ex.Message);
                return;
            }

            DataTable dtParts = loadPartOfYCMVT(proposalCode);

            Excel.Application app = default(Excel.Application);
            Excel.Workbook workBoook = default(Excel.Workbook);
            Excel.Worksheet workSheet = default(Excel.Worksheet);
            try
            {
                app = new Excel.Application();
                app.Workbooks.Open(path + "\\" + proposalCode + ".xls");
                workBoook = app.Workbooks[1];
                workSheet = (Excel.Worksheet)workBoook.Worksheets[1];

                workSheet.Cells[7, 1] = proposalCode;
                DataRow[] drs = dtParts.Select("SupplierName is not null");
                workSheet.Cells[10, 3] = drs.Length > 0 ? TextUtils.ToString(drs[0]["SupplierName"]) : "";
                workSheet.Cells[17, 5] = "Tân Phát, ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
                workSheet.Cells[22, 20] = Global.AppFullName;

                int countPart = 0;
                for (int j = dtParts.Rows.Count - 1; j >= 0; j--)
                {
                    string partCode = TextUtils.ToString(dtParts.Rows[j]["PartsCode"]);
                    countPart++;

                    workSheet.Cells[15, 1] = j + 1;
                    workSheet.Cells[15, 2] = TextUtils.ToString(dtParts.Rows[j]["PartsName"]);
                    workSheet.Cells[15, 3] = partCode;
                    workSheet.Cells[15, 4] = TextUtils.ToDecimal(dtParts.Rows[j]["TotalBuy"]);
                    workSheet.Cells[15, 5] = TextUtils.ToDecimal(dtParts.Rows[j]["TotalInventory"]);
                    workSheet.Cells[15, 6] = TextUtils.ToString(dtParts.Rows[j]["Total"]);
                    workSheet.Cells[15, 7] = TextUtils.ToString(dtParts.Rows[j]["Unit"]);
                    workSheet.Cells[15, 21] = TextUtils.ToString(dtParts.Rows[j]["RequestCode"]);
                    workSheet.Cells[15, 22] = TextUtils.ToString(dtParts.Rows[j]["ProjectCode"]);
                    workSheet.Cells[15, 23] = TextUtils.ToString(dtParts.Rows[j]["ManufacturerCode"]);

                    ((Excel.Range)workSheet.Rows[15]).Insert();
                }

                ((Excel.Range)workSheet.Rows[14]).Delete();
                ((Excel.Range)workSheet.Rows[14]).Delete();
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
                    workSheet = null;
                    workBoook = null;
                    app.Workbooks.Close();
                    app.Quit();
                }
            }
            #endregion
            if (File.Exists(path + "\\" + proposalCode + ".xls"))
            {
                Process.Start(path + "\\" + proposalCode + ".xls");
            }
        }
    }
}
