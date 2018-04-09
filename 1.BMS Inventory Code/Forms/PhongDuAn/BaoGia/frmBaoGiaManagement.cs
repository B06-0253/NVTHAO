using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using BMS.Model;
using BMS.Business;
using BMS.Utils;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Diagnostics;

namespace BMS
{
    public partial class frmBaoGiaManagement : _Forms
    {
        int _rownIndex = 0;

        public frmBaoGiaManagement()
        {
            InitializeComponent();
        }

        private void frmBaoGiaManagement_Load(object sender, EventArgs e)
        {
            LoadInfoSearch();
        }

        void LoadInfoSearch()
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load danh sách báo giá..."))
            {
                try
                {
                    DataTable Source = TextUtils.Select("select *,case when CustomerPercentType = 0 then N'TRƯỚC VAT' ELSE N'SAU VAT' END CustomerPercentTypeText  from BaoGia with(nolock)");
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

        void main_LoadDataChange(object sender, EventArgs e)
        {
            LoadInfoSearch();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmBaoGia frm = new frmBaoGia();
            //frmBaoGiaNew frm = new frmBaoGiaNew();
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            BaoGiaModel model = (BaoGiaModel)BaoGiaBO.Instance.FindByPK(id);
            frmBaoGia frm = new frmBaoGia();
            frm.BaoGia = model;
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();
            try
            {
                if (grvData.DataSource == null) return;
                int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
                if (id == 0) return;
                
                if (MessageBox.Show("Bạn có chắc muốn xóa vật tư [" + grvData.GetFocusedRowCellValue(colCode).ToString() + "] không?",
                    TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                
                pt.DeleteByAttribute("BaoGiaItem", "BaoGiaID", id.ToString());
                pt.Delete("BaoGia", id);           

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

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void btnTongHopChiPhi_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            BaoGiaModel model = (BaoGiaModel)BaoGiaBO.Instance.FindByPK(id);

            //frmBaoGiaCost frm = new frmBaoGiaCost();
            //frm.BaoGia = model;
            //frm.LoadDataChange += main_LoadDataChange;
            //TextUtils.OpenForm(frm);

            frmBaoGiaCostModule frm = new frmBaoGiaCostModule();
            frm.BaoGia = model;
            TextUtils.OpenForm(frm);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            frmBaoGiaReport frm = new frmBaoGiaReport();
            TextUtils.OpenForm(frm);
        }

        private void btnCreateBaoGia_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;

            BaoGiaModel BaoGia = (BaoGiaModel)BaoGiaBO.Instance.FindByPK(id);            
            string localPath = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                localPath = fbd.SelectedPath + "\\" + BaoGia.Code + ".xlsx";
            }
            else
            {
                return;
            }

            string filePath = Application.StartupPath + "\\Templates\\FORM BAO GIA.xlsx";

            try
            {
                File.Copy(filePath, localPath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: File excel đang được mở." + Environment.NewLine + ex.Message);
                return;
            }

            UsersModel userModel = (UsersModel)UsersBO.Instance.FindByPK(Global.UserID);
            DataTable dtProduct = TextUtils.Select("select distinct productcode, productname from baogiaitem with(nolock) where productcode <> '' and baogiaid= " + BaoGia.ID);
            //DataTable dtProductAo = TextUtils.Select("select distinct productcode, productname from baogiaitem with(nolock) where productcode = '' and baogiaid= " + BaoGia.ID);

            if (grvData.RowCount == 0)
            {
                MessageBox.Show("Lỗi: Không có thiết bị nào để báo giá");
                return;
            }
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo báo giá..."))
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

                    workSheet.Cells[5, 4] = "Số báo giá: " + BaoGia.Code;
                    workSheet.Cells[6, 2] = "Đơn vị: " + BaoGia.CustomerCodeF + " - " + BaoGia.CustomerNameF;
                    workSheet.Cells[6, 4] = "Ngày báo giá: " + DateTime.Now.ToString("dd/MM/yyyy");
                    workSheet.Cells[7, 4] = "Người báo giá: " + userModel.FullName;
                    workSheet.Cells[8, 4] = "Số điện thoại: " + userModel.HandPhone;
                    workSheet.Cells[9, 4] = "Email: " + userModel.Email;
                    workSheet.Cells[25, 6] = "Hà nội, ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;

                    int rowCountProduct = dtProduct.Rows.Count;
                    DataTable dtModuleAo = TextUtils.Select("select * from baogiaitem where ProductCode = '' and Baogiaid = " + BaoGia.ID);
                    if (dtModuleAo.Rows.Count > 0)
                    {
                        int indexAo = dtModuleAo.Rows.Count - 1;
                        for (int i = indexAo; i >= 0; i--)
                        {
                            string moduleCode = TextUtils.ToString(dtModuleAo.Rows[i]["ModuleCode"]);
                            string moduleName = TextUtils.ToString(dtModuleAo.Rows[i]["ModuleName"]);
                            string qty = TextUtils.ToDecimal(dtModuleAo.Rows[i]["Qty"]).ToString("n0");
                            string price = TextUtils.ToDecimal(dtModuleAo.Rows[i]["PriceTPA"]).ToString("n0");
                            string total = TextUtils.ToDecimal(dtModuleAo.Rows[i]["TotalTPA"]).ToString("n0");

                            ModulesModel module = new ModulesModel();
                            try
                            {
                                module = (ModulesModel)ModulesBO.Instance.FindByCode(moduleCode);
                            }
                            catch (Exception)
                            {
                            }
                            if (module.ID > 0)
                            {
                                if (module.Specifications.Length > 0)
                                {
                                    string[] thongSo = module.Specifications.Split('\n');
                                    for (int k = thongSo.Length - 1; k >= 0; k--)
                                    {
                                        workSheet.Cells[15, 2] = thongSo[k];
                                        ((Excel.Range)workSheet.Rows[15]).Insert();
                                    }
                                }
                            }

                            workSheet.Cells[15, 1] = rowCountProduct + i + 1;
                            workSheet.Cells[15, 2] = moduleName.ToUpper();
                            workSheet.Cells[15, 3] = moduleCode.ToUpper();
                            workSheet.Cells[15, 6] = qty;
                            workSheet.Cells[15, 7] = price;
                            workSheet.Cells[15, 8] = total;
                            ((Excel.Range)workSheet.Rows[15]).Font.Bold = true;
                            ((Excel.Range)workSheet.Rows[15]).Insert();
                        }
                    }
                    for (int i = rowCountProduct - 1; i >= 0; i--)
                    {
                        try
                        {
                            DataTable dtModule = TextUtils.Select("select * from baogiaitem where ProductCode = '"
                                + dtProduct.Rows[i][0].ToString() + "' and Baogiaid = " + BaoGia.ID);

                            for (int j = dtModule.Rows.Count - 1; j >= 0; j--)
                            {
                                string moduleCode = TextUtils.ToString(dtModule.Rows[j]["ModuleCode"]);
                                string moduleName = TextUtils.ToString(dtModule.Rows[j]["ModuleName"]);
                                string qty = TextUtils.ToDecimal(dtModule.Rows[j]["Qty"]).ToString("n0");
                                string price = TextUtils.ToDecimal(dtModule.Rows[j]["PriceTPA"]).ToString("n0");
                                string total = TextUtils.ToDecimal(dtModule.Rows[j]["TotalTPA"]).ToString("n0");

                                ModulesModel module = new ModulesModel();
                                try
                                {
                                    module = (ModulesModel)ModulesBO.Instance.FindByCode(moduleCode);
                                }
                                catch (Exception)
                                {
                                }
                                if (module.ID > 0)
                                {
                                    if (module.Specifications.Length > 0)
                                    {
                                        string[] thongSo = module.Specifications.Split('\n');
                                        for (int k = thongSo.Length - 1; k >= 0; k--)
                                        {
                                            workSheet.Cells[15, 2] = thongSo[k];
                                            ((Excel.Range)workSheet.Rows[15]).Insert();
                                        }
                                    }
                                }
                                workSheet.Cells[15, 2] = moduleName.ToUpper();
                                workSheet.Cells[15, 3] = moduleCode.ToUpper();
                                workSheet.Cells[15, 6] = qty;
                                workSheet.Cells[15, 7] = price;
                                workSheet.Cells[15, 8] = total;
                                ((Excel.Range)workSheet.Rows[15]).Font.Bold = true;
                                ((Excel.Range)workSheet.Rows[15]).Insert();
                            }

                            decimal productPrice = TextUtils.ToDecimal(dtModule.Compute("Sum(TotalTPA)", ""));

                            workSheet.Cells[15, 1] = i + 1;
                            workSheet.Cells[15, 2] = dtProduct.Rows[i][1].ToString().ToUpper();
                            workSheet.Cells[15, 3] = dtProduct.Rows[i][0].ToString().ToUpper();
                            workSheet.Cells[15, 4] = "Tân Phát";
                            workSheet.Cells[15, 5] = "Bộ";
                            workSheet.Cells[15, 6] = 1;
                            workSheet.Cells[15, 7] = productPrice.ToString("n0");
                            workSheet.Cells[15, 8] = productPrice.ToString("n0");

                            ((Excel.Range)workSheet.Rows[15]).Font.Bold = true;
                            ((Excel.Range)workSheet.Rows[15]).Insert();
                        }
                        catch (Exception)
                        {
                        }
                    }                   

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
                Process.Start(localPath);
            }
        }
    }
}
