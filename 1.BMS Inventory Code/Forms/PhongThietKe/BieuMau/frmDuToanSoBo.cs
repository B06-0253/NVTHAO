using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DevExpress.Utils;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace BMS
{
    public partial class frmDuToanSoBo : _Forms
    {
        DataTable _dtVT = new DataTable();

        #region Constructor and Load
        public frmDuToanSoBo()
        {
            InitializeComponent();
        }

        private void frmDuToanSoBo_Load(object sender, EventArgs e)
        {
            _dtVT.Columns.Add("Code");
            _dtVT.Columns.Add("Name");
            _dtVT.Columns.Add("VatLieu");
            _dtVT.Columns.Add("Hang");
            _dtVT.Columns.Add("Time", typeof(int));
            _dtVT.Columns.Add("Status");
            _dtVT.Columns.Add("Qty");
            _dtVT.Columns.Add("Unit");
            _dtVT.Columns.Add("Price");
            _dtVT.Columns.Add("Total");
            _dtVT.Columns.Add("Description");
            _dtVT.Columns.Add("TonKho", typeof(decimal));
            _dtVT.Columns.Add("DeliveryTime", typeof(int));
            grdVT.DataSource = _dtVT;

            loadProject();
            loadModuleTK();
        }
        #endregion

        #region Methods
        void loadProject()
        {
            try
            {
                DataTable tbl = LibQLSX.Select("exec spGetAllProject");
                TextUtils.PopulateCombo(cboProject, tbl, "ProjectName", "ProjectCode", "");
            }
            catch (Exception ex)
            {
            }
        }

        void loadModuleTK()
        {
            DataTable dtModule = TextUtils.Select("select * from Modules with(nolock) where Code like '%tpad.%' order by Code");
            TextUtils.PopulateCombo(cboModule, dtModule, "Code", "Code", "");
        }
        #endregion

        #region Events
        private void btnCreate_Click(object sender, EventArgs e)
        {
            grvVT.FocusedRowHandle = -1;
            if (grvVT.RowCount == 0) return;
            string moduleCode = TextUtils.ToString(grvModuleM.GetFocusedRowCellValue(colCodeM));
            string moduleName = TextUtils.ToString(grvModuleM.GetFocusedRowCellValue(colNameM));
            if (moduleCode == "")
            {
                MessageBox.Show("Bạn phải chọn một module thiết kế!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

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

            string filePath = Application.StartupPath + "\\Templates\\DuToanSoBo.xlsm";
            string currentPath = path + "\\DTSB." + moduleCode + ".xlsm";
            try
            {
                File.Copy(filePath, currentPath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi tạo file dự toán sơ bộ!" + Environment.NewLine + ex.Message, 
                    TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo dự toán sơ bộ..."))
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

                    workSheet.Cells[3, 3] = moduleName;
                    workSheet.Cells[3, 11] = "Mã:" + moduleCode;
                    workSheet.Cells[4, 3] = workSheet.Cells[18, 10] = Global.AppFullName;
                    workSheet.Cells[6, 3] = txtDateP.Text.Trim();
                    workSheet.Cells[6, 7] = txtTotalP.Text.Trim();
                    workSheet.Cells[13, 1] = "Tân Phát, ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;

                    for (int i = grvVT.RowCount-1; i >= 0; i--)
                    {
                        workSheet.Cells[10, 1] = i + 1;
                        workSheet.Cells[10, 2] = grvVT.GetRowCellDisplayText(i, colMaName);
                        workSheet.Cells[10, 3] = grvVT.GetRowCellDisplayText(i, colMaCode);
                        workSheet.Cells[10, 4] = grvVT.GetRowCellDisplayText(i, colMaVatLieu);
                        workSheet.Cells[10, 5] = grvVT.GetRowCellDisplayText(i, colMaHang);
                        workSheet.Cells[10, 6] = grvVT.GetRowCellDisplayText(i, colMaTime);
                        workSheet.Cells[10, 7] = grvVT.GetRowCellDisplayText(i, colMaStatus);
                        workSheet.Cells[10, 8] = grvVT.GetRowCellDisplayText(i, colMaUnit);
                        workSheet.Cells[10, 9] = grvVT.GetRowCellDisplayText(i, colMaQty);
                        workSheet.Cells[10, 10] = grvVT.GetRowCellDisplayText(i, colMaPrice);
                        workSheet.Cells[10, 11] = grvVT.GetRowCellDisplayText(i, colMaTotal);
                        workSheet.Cells[10, 12] = grvVT.GetRowCellDisplayText(i, colMaDes);
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

        private void cboProject_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string projectCode = TextUtils.ToString(grvProject.GetFocusedRowCellValue(colProjectCode));
                txtDateP.Text = TextUtils.ToString(grvProject.GetFocusedRowCellDisplayText(colDateFinishE));
                
                string filePath = @"\\SERVER\data2\Thietke\Luutru\Hoancong\TONG HOP GIA DAU VAO\" + projectCode + ".xls";

                if (!File.Exists(filePath))
                {
                    MessageBox.Show("Không tồn tại file tổng hợp giá đầu vào cho dự án [" + projectCode + "].", 
                        TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                DataTable dtData = TextUtils.ExcelToDatatableNoHeader(filePath, "Tổng hợp v1");
                dtData = dtData.Select("F3 <> ''").CopyToDataTable();
                TextUtils.PopulateCombo(cboModuleP, dtData, "F3", "F3", "");
            }
            catch (Exception)
            {
            }
        }

        private void cboModuleP_EditValueChanged(object sender, EventArgs e)
        {
            string code = TextUtils.ToString(grvModuleP.GetFocusedRowCellValue(colCodeP));

            //txtDateP.Text = TextUtils.ToString(grvModuleP.GetFocusedRowCellValue(colDateP));
            txtTotalP.Text = TextUtils.ToInt(grvModuleP.GetFocusedRowCellValue(colPriceP).ToString().Replace(",", "")).ToString("n0");
        }

        private void btnAddVT_Click(object sender, EventArgs e)
        {
            frmListMaterial frm = new frmListMaterial();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang thêm vật tư..."))
                {
                    foreach (DataRow r in frm.dtAll.Rows)
                    {
                        string code = TextUtils.ToString(r["Code"]);
                        if (code == "") continue;
                        DataRow[] drs = _dtVT.Select("Code = '" + code + "'");
                        if (drs.Length > 0) continue;
                        decimal tonKho = TextUtils.ToDecimal(r["TonKho"]);

                        //string sqlM = "SELECT top 1 * FROM  vGetPriceOfPart with(nolock)"
                        //                + " WHERE Price > 1 AND replace(replace([PartsCode],'/','#'),')','#') = '"
                        //                + code.Replace(" ", "").Replace("/", "#").Replace(")", "#") + "'"
                        //                + " ORDER BY DateAboutF DESC";
                        //DataTable dtPrice = LibQLSX.Select(sqlM);

                        string sqlM = "exec spGetPriceOfPart '" + code.Replace(" ", "").Replace("/", "#").Replace(")", "#") + "'";
                        DataTable dtPrice = LibQLSX.Select(sqlM);

                        DataRow dr = _dtVT.NewRow();
                        dr["Code"] = r["Code"].ToString();
                        dr["Name"] = r["Name"].ToString();
                        dr["Hang"] = r["Hang"].ToString();
                        dr["Unit"] = r["Unit"].ToString();
                        dr["TonKho"] = tonKho;
                        dr["DeliveryTime"] = TextUtils.ToInt(dtPrice.Rows[0]["DeliveryTime"]);

                        if (dtPrice.Rows.Count > 0)
                        {
                            dr["Price"] = TextUtils.ToDecimal(dtPrice.Rows[0]["Price"]).ToString("n0");
                            if (tonKho >= 1)
                            {
                                dr["Time"] = 1;
                            }
                            else
                            {
                                dr["Time"] = TextUtils.ToInt(dtPrice.Rows[0]["DeliveryTime"]);
                            }

                            DateTime dateP = TextUtils.ToDate1(txtDateP.Text);
                            int dateCurrent = TextUtils.ToInt(dr["Time"]);
                            if (dateCurrent < 0)
                            {
                                dr["Description"] = "Chưa phát sinh mua bán";
                            }
                            else
                            {
                                DateTime dateVT = DateTime.Now.AddDays(dateCurrent);
                                if (dateVT.Date <= dateP.Date)
                                {
                                    dr["Status"] = "Đạt";
                                }
                                else
                                {
                                    dr["Status"] = "Không đạt";
                                }
                            }
                        }
                        else
                        {
                            dr["Price"] = TextUtils.ToDecimal(r["Price"]).ToString("n0");
                            dr["Description"] = "Chưa phát sinh mua bán";
                        }
                        dr["Total"] = TextUtils.ToDecimal(dr["Price"]).ToString("n0");

                        dr["Qty"] = 1;
                        _dtVT.Rows.Add(dr);
                    }
                    txtTotalM.Text = TextUtils.ToDecimal(colMaTotal.SummaryItem.SummaryValue).ToString("n0");
                    txtDateM.Text = TextUtils.ToDecimal(colMaTime.SummaryItem.SummaryValue).ToString("n0");
                }
            }
        }

        private void btnDeleteVT_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa vật tư này?",TextUtils.Caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                grvVT.DeleteSelectedRows();
                txtDateM.Text = TextUtils.ToDecimal(colMaTime.SummaryItem.SummaryValue).ToString("n0");
                txtTotalM.Text = TextUtils.ToDecimal(colMaTotal.SummaryItem.SummaryValue).ToString("n0");
            }
        }

        private void grvVT_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int index = grvVT.FocusedRowHandle;
            if (e.Column == colMaTime)
            {
                DateTime dateP = TextUtils.ToDate1(txtDateP.Text);
                int dateCurrent = TextUtils.ToInt(grvVT.GetFocusedRowCellValue(colMaTime));
                DateTime dateVT = DateTime.Now.AddDays(dateCurrent);
                if (dateVT.Date <= dateP.Date)
                {
                    grvVT.SetFocusedRowCellValue(colMaStatus, "Đạt");
                }
                else
                {
                    grvVT.SetFocusedRowCellValue(colMaStatus, "Không đạt");
                }
                grvVT.FocusedRowHandle = index + 1;
                txtDateM.Text = TextUtils.ToDecimal(colMaTime.SummaryItem.SummaryValue).ToString("n0");
                grvVT.FocusedRowHandle = index;
            }

            if (e.Column == colMaQty)
            {
                decimal price = TextUtils.ToDecimal(grvVT.GetFocusedRowCellValue(colMaPrice));
                decimal qty = TextUtils.ToDecimal(grvVT.GetFocusedRowCellValue(colMaQty));
                decimal tonKho = TextUtils.ToDecimal(grvVT.GetFocusedRowCellValue(colMaTonKho));
                int deliveryTime = TextUtils.ToInt(grvVT.GetFocusedRowCellValue(colMaDeliveryTime));
                
                grvVT.SetFocusedRowCellValue(colMaTotal, (qty * price).ToString("n0"));

                grvVT.FocusedRowHandle = index + 1;
                txtTotalM.Text = TextUtils.ToDecimal(colMaTotal.SummaryItem.SummaryValue).ToString("n0");
                grvVT.FocusedRowHandle = index;

                if (qty > tonKho)
                {
                    grvVT.SetRowCellValue(index, colMaTime, deliveryTime);
                }
                else
                {
                    grvVT.SetRowCellValue(index, colMaTime, 1);
                }
            }
        }        

        private void btnAddModule_Click(object sender, EventArgs e)
        {
            frmListModules frm = new frmListModules();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang thêm module..."))
                {
                    foreach (DataRow r in frm.dtSeleted.Rows)
                    {
                        string code = TextUtils.ToString(r["Code"]);
                        if (code == "") continue;
                        DataRow[] drs = _dtVT.Select("Code = '" + code + "'");
                        if (drs.Length > 0) continue;

                        decimal price = TextUtils.GetPrice(code, true);

                        int deliveryTime = -1;
                        if (code.StartsWith("PCB."))
                        {
                            //string sqlM = "SELECT top 1 * FROM  vGetPriceOfPart with(nolock)"
                            //        + " WHERE Price > 1 AND replace(replace([PartsCode],'/','#'),')','#') = '"
                            //        + "TPAT." + code.Substring(4, 7) + "'"
                            //        + " ORDER BY DateAboutF DESC";
                            //DataTable dtPrice = LibQLSX.Select(sqlM);

                            string sqlM = "exec spGetPriceOfPart 'TPAT." + code.Substring(4, 7) + "'";
                            DataTable dtPrice = LibQLSX.Select(sqlM);

                            deliveryTime = TextUtils.ToInt(dtPrice.Rows[0]["DeliveryTime"]);
                        }

                        DataRow dr = _dtVT.NewRow();
                        dr["Code"] = TextUtils.ToString(r["Code"]);
                        dr["Name"] = TextUtils.ToString(r["Name"]);
                        dr["Hang"] = TextUtils.ToString(r["Hang"]);
                        dr["Unit"] = "Bộ";
                        dr["Price"] = price.ToString("n0");
                        dr["Total"] = price.ToString("n0");
                        dr["Qty"] = 1;

                        if (deliveryTime != -1)
                        {
                            dr["Time"] = deliveryTime;

                            DateTime dateP = TextUtils.ToDate1(txtDateP.Text);
                            int dateCurrent = TextUtils.ToInt(dr["Time"]);
                            if (dateCurrent < 0)
                            {
                                dr["Status"] = "Không đạt";
                            }
                            else
                            {
                                DateTime dateVT = DateTime.Now.AddDays(dateCurrent);
                                if (dateVT.Date <= dateP.Date)
                                {
                                    dr["Status"] = "Đạt";
                                }
                                else
                                {
                                    dr["Status"] = "Không đạt";
                                }
                            }
                        }                        
                        
                        _dtVT.Rows.Add(dr);
                    }

                    txtTotalM.Text = TextUtils.ToDecimal(colMaTotal.SummaryItem.SummaryValue).ToString("n0");
                }
            }
        }
        #endregion
    }
}
