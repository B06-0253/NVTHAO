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
using TPA.Business;
using TPA.Model;
using Excel = Microsoft.Office.Interop.Excel;

namespace BMS
{
    public partial class frmQuotationReportSX : _Forms
    {
        public C_Quotation_KDModel Quotation = new C_Quotation_KDModel();
        public frmQuotationReportSX()
        {
            InitializeComponent();
        }

        private void frmQuotationReportSX_Load(object sender, EventArgs e)
        {
            this.Location = new Point(this.Width / 4, 0);
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Text += ": " + Quotation.Code + " - " + Quotation.ProjectCode;
            loadText();
            loadGrid();
        }

        void loadText()
        {
            string[] paraName = new string[2];
            object[] paraValue = new object[2];
            paraName[0] = "@Year"; paraValue[0] = 0;
            paraName[1] = "@QuotationID"; paraValue[1] = Quotation.ID;

            DataTable dtQuotation = C_CostBO.Instance.LoadDataFromSP("spReportQuotationSX", "Source", paraName, paraValue);
            if (dtQuotation.Rows.Count > 0)
            {
                txtTotalHD.EditValue = TextUtils.ToDecimal(dtQuotation.Rows[0]["TotalHD"]);
                txtTotalTPA.EditValue = TextUtils.ToDecimal(dtQuotation.Rows[0]["TotalTPA"]);
                //txtTotalTPA_PreVAT.EditValue = TextUtils.ToDecimal(dtQuotation.Rows[0]["TotalTPA_PreVAT"]);
                //txtTotalVAT.EditValue = TextUtils.ToDecimal(dtQuotation.Rows[0]["TotalVAT"]);
                txtTotalVT.EditValue = TextUtils.ToDecimal(dtQuotation.Rows[0]["TotalVT"]);

                txtTotalNC.EditValue = TextUtils.ToDecimal(dtQuotation.Rows[0]["TotalNC"]);
                txtTotalPB.EditValue = TextUtils.ToDecimal(dtQuotation.Rows[0]["TotalPB"]);
                txtTotalDP.EditValue = Quotation.TotalDP_SX;
                txtTotalVC.EditValue = Quotation.TotalCPVCHB_C13;
                txtTotalBX.EditValue = Quotation.TotalBXHB_C52;
                txtTotalDiLai.EditValue = Quotation.TotalDiLai;

                //txtTotalNC_KD.EditValue = TextUtils.ToDecimal(dtQuotation.Rows[0]["TotalNC_KD"]);
                //txtTotalReal.EditValue = TextUtils.ToDecimal(txtTotalHD.EditValue) - TextUtils.ToDecimal(txtTotalVC.EditValue);
                txtTotalProfit.EditValue = TextUtils.ToDecimal(dtQuotation.Rows[0]["TotalProfit"]);
                //txtTotalProfitQD.EditValue = TextUtils.ToDecimal(dtQuotation.Rows[0]["TotalProfitQD"]);
            }
        }

        void loadGrid()
        {
            string[] paraName = new string[1];
            object[] paraValue = new object[1];

            paraName[0] = "@QuotationID"; paraValue[0] = Quotation.ID;

            DataTable dtCost = new DataTable();
            if (Quotation.StatusNC==1)
            {
                dtCost = C_CostBO.Instance.LoadDataFromSP("spReportCostWithQuotationSX_DN", "Source", paraName, paraValue);
            }
            else
            {
                dtCost = C_CostBO.Instance.LoadDataFromSP("spReportCostWithQuotationSX_CN", "Source", paraName, paraValue);
            }            

            grdSP.DataSource = dtCost;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadText();
            loadGrid();
        }

        private void btnFCM_Click(object sender, EventArgs e)
        {
            string localPath = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                localPath = fbd.SelectedPath + "\\FCM-SX- " + Quotation.Code + ".xlsx";
            }
            else
            {
                return;
            }

            string filePath = Application.StartupPath + "\\Templates\\PhongKinhDoanh\\FCM-SX-TEMPLATE.xlsx";

            try
            {
                File.Copy(filePath, localPath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: File excel đang được mở." + Environment.NewLine + ex.Message);
                return;
            }

            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo FCM..."))
            {
                DataTable dtQuotation = LibQLSX.Select("exec spGetQuotation @QuotationID = " + Quotation.ID);

                DataTable dtAllCost = new DataTable();
                if (Quotation.StatusNC == 1)
                {
                    dtAllCost = LibQLSX.Select("exec [spReportCostWithQuotationSX_DN] " + Quotation.ID);
                }
                else
                {
                    dtAllCost = LibQLSX.Select("exec [spReportCostWithQuotationSX_CN] " + Quotation.ID);
                }

                decimal totalNC_ThietKe1 = TextUtils.ToDecimal(dtAllCost.Compute("Sum(TotalPrice)", "Code = 'C09P11' and Code = 'C09P24'"));

                DataTable dtGroup = TextUtils.GetDistinctDatatable(dtAllCost, "GroupCode");

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

                    workSheet.Cells[4, 4] = "KD";
                    workSheet.Cells[4, 6] = Quotation.DeliveryTime;

                    workSheet.Cells[5, 4] = TextUtils.ToString(Quotation.ProjectCode);
                    workSheet.Cells[6, 4] = TextUtils.ToString(Quotation.ProjectName);
                    workSheet.Cells[7, 4] = TextUtils.ToString(Quotation.CustomerName);
                    workSheet.Cells[8, 8] = TextUtils.ToString(dtQuotation.Rows[0]["StatusText"]);
                    workSheet.Cells[9, 4] = TextUtils.ToString(dtQuotation.Rows[0]["DName"]);
                    workSheet.Cells[9, 7] = TextUtils.ToString(Quotation.POnumber);
                    //Lợi nhuận
                    workSheet.Cells[14, 8] = TextUtils.ToDecimal(txtTotalProfit.EditValue);
                    //Giá bán
                    workSheet.Cells[16, 8] = TextUtils.ToDecimal(txtTotalTPA.EditValue);//Giá bán chưa VAT
                    workSheet.Cells[16, 9] = TextUtils.ToDecimal(txtTotalHD.EditValue);
                    //Chi phí vật tư
                    workSheet.Cells[19, 8] = TextUtils.ToDecimal(txtTotalVT.EditValue);//Giá vật tư
                    workSheet.Cells[19, 9] = TextUtils.ToDecimal(txtTotalVT.EditValue);

                    decimal totalNC_GianTiep = TextUtils.ToDecimal(dtAllCost.Compute("Sum(TotalPrice)", "GroupCode = 'N01'"));
                    workSheet.Cells[23, 6] = totalNC_GianTiep / TextUtils.ToDecimal(txtTotalTPA.EditValue);
                    workSheet.Cells[23, 8] = totalNC_GianTiep;
                    workSheet.Cells[23, 9] = totalNC_GianTiep;//Chi phí cố định - đầu nhân viên gián tiếp

                    //Chi phí phân bổ khác
                    decimal totalPB_QuanLy = TextUtils.ToDecimal(dtAllCost.Compute("Sum(TotalPrice)", "GroupCode = 'N08'"));
                    workSheet.Cells[35, 6] = totalPB_QuanLy / TextUtils.ToDecimal(txtTotalTPA.EditValue);
                    workSheet.Cells[35, 9] = totalPB_QuanLy;//Chi phí quản lí

                    decimal totalPB_TaiChinh = TextUtils.ToDecimal(dtAllCost.Compute("Sum(TotalPrice)", "GroupCode = 'N09'"));
                    workSheet.Cells[36, 6] = totalPB_TaiChinh / TextUtils.ToDecimal(txtTotalTPA.EditValue);
                    workSheet.Cells[36, 9] = totalPB_TaiChinh;//Chi phí tài chính và lãi vay

                    workSheet.Cells[37, 9] = TextUtils.ToDecimal(txtTotalDP.EditValue);//Chi phí dự phòng

                    decimal totalPB_BaoHanh = TextUtils.ToDecimal(dtAllCost.Compute("Sum(TotalPrice)", "GroupCode = 'N11'"));
                    workSheet.Cells[43, 6] = totalPB_BaoHanh / TextUtils.ToDecimal(txtTotalTPA.EditValue);
                    workSheet.Cells[43, 9] = totalPB_BaoHanh;//Chi phí bảo hành

                    if (Quotation.StatusNC == 1)
                    {
                        //Chi phí nhân công
                        decimal totalNC_ThietKe = TextUtils.ToDecimal(dtAllCost.Compute("Sum(TotalPrice)", "GroupCode = 'N02'"));
                        workSheet.Cells[24, 6] = totalNC_ThietKe / TextUtils.ToDecimal(txtTotalTPA.EditValue);
                        workSheet.Cells[24, 9] = totalNC_ThietKe;//Chi phí cố định - đầu nhân viên Tkế

                        decimal totalNC_SXLR = TextUtils.ToDecimal(dtAllCost.Compute("Sum(TotalPrice)", "GroupCode = 'N03'"));
                        workSheet.Cells[25, 6] = totalNC_SXLR / TextUtils.ToDecimal(txtTotalTPA.EditValue);
                        workSheet.Cells[25, 9] = totalNC_SXLR;//Chi phí cố định - đầu nhân viên SXLR

                        //Chi phí kỹ thuật
                        workSheet.Cells[28, 9] = TextUtils.ToDecimal(txtTotalVC.EditValue);//Chi phí vận chuyển hàng bán
                        workSheet.Cells[29, 9] = TextUtils.ToDecimal(txtTotalDiLai.EditValue);// Chi phí đi lại

                        //workSheet.Cells[27, 9] = TextUtils.ToDecimal(txtTotalVC.EditValue);//Chi phí vận chuyển hàng bán
                        workSheet.Cells[30, 9] = TextUtils.ToDecimal(txtTotalBX.EditValue);//Chi phí bốc xếp hàng bán

                        decimal totalKT_Service = TextUtils.ToDecimal(dtAllCost.Compute("Sum(TotalPrice)", "GroupCode = 'N04'"));
                        workSheet.Cells[31, 6] = totalKT_Service / TextUtils.ToDecimal(txtTotalTPA.EditValue);
                        workSheet.Cells[31, 9] = totalKT_Service;//Chi phí cố bộ phận Service (Lắp đặt, chuyển giao, follow)

                        decimal totalKT_SXLR = TextUtils.ToDecimal(dtAllCost.Compute("Sum(TotalPrice)", "GroupCode = 'N07.02'"));
                        workSheet.Cells[32, 6] = totalKT_SXLR / TextUtils.ToDecimal(txtTotalTPA.EditValue);
                        workSheet.Cells[32, 9] = totalKT_SXLR;//Chi phí bộ phận SXLR  (Lắp đặt, chuyển giao, follow)

                        decimal totalKT_TK = TextUtils.ToDecimal(dtAllCost.Compute("Sum(TotalPrice)", "GroupCode = 'N07.03'"));
                        workSheet.Cells[33, 6] = totalKT_TK / TextUtils.ToDecimal(txtTotalTPA.EditValue);
                        workSheet.Cells[33, 9] = totalKT_TK;//Chi phí bộ phận thiết kế (Lắp đặt, chuyển giao, follow)
                        
                    }
                    else
                    {
                        //Chi phí nhân công
                        decimal totalNC_ThietKe = TextUtils.ToDecimal(dtAllCost.Compute("Sum(TotalPrice)", "Code = 'C09P11' and Code = 'C09P24'"));
                        workSheet.Cells[24, 6] = totalNC_ThietKe / TextUtils.ToDecimal(txtTotalTPA.EditValue);
                        workSheet.Cells[24, 9] = totalNC_ThietKe;//Chi phí cố định - đầu nhân viên Tkế

                        decimal totalNC_SXLR = TextUtils.ToDecimal(dtAllCost.Compute("Sum(TotalPrice)", "Code = 'C09P07'"));
                        workSheet.Cells[25, 6] = totalNC_SXLR / TextUtils.ToDecimal(txtTotalTPA.EditValue);
                        workSheet.Cells[25, 9] = totalNC_SXLR;//Chi phí cố định - đầu nhân viên SXLR

                        //Chi phí kỹ thuật
                        workSheet.Cells[28, 9] = TextUtils.ToDecimal(txtTotalVC.EditValue);//Chi phí vận chuyển hàng bán
                        workSheet.Cells[29, 9] = TextUtils.ToDecimal(txtTotalDiLai.EditValue);// Chi phí đi lại

                        //workSheet.Cells[27, 9] = TextUtils.ToDecimal(txtTotalVC.EditValue);//Chi phí vận chuyển hàng bán
                        //workSheet.Cells[28, 9] = TextUtils.ToDecimal(txtTotalBX.EditValue);//Chi phí bốc xếp hàng bán

                        decimal totalKT_Service = TextUtils.ToDecimal(dtAllCost.Compute("Sum(TotalPrice)", "Code = 'C09P12'"));
                        workSheet.Cells[31, 6] = totalKT_Service / TextUtils.ToDecimal(txtTotalTPA.EditValue);
                        workSheet.Cells[31, 9] = totalKT_Service;//Chi phí cố bộ phận Service (Lắp đặt, chuyển giao, follow)

                        decimal totalKT_SXLR = TextUtils.ToDecimal(dtAllCost.Compute("Sum(TotalPrice)", "Code = 'PLD'"));
                        workSheet.Cells[32, 6] = totalKT_SXLR / TextUtils.ToDecimal(txtTotalTPA.EditValue);
                        workSheet.Cells[32, 9] = totalKT_SXLR;//Chi phí bộ phận SXLR  (Lắp đặt, chuyển giao, follow)

                        decimal totalKT_TK = TextUtils.ToDecimal(dtAllCost.Compute("Sum(TotalPrice)", "Code = 'PCG'"));
                        workSheet.Cells[33, 6] = totalKT_TK / TextUtils.ToDecimal(txtTotalTPA.EditValue);
                        workSheet.Cells[33, 9] = totalKT_TK;//Chi phí bộ phận thiết kế (Lắp đặt, chuyển giao, follow)
                    }
                    

                    for (int i = dtGroup.Rows.Count - 1; i >= 0; i--)
                    {
                        string groupCode = TextUtils.ToString(dtGroup.Rows[i]["GroupCode"]);

                        DataRow[] listCost = dtAllCost.AsEnumerable()
                            .Where(y => y.Field<string>("GroupCode") == groupCode)
                            .ToArray();

                        for (int k = listCost.Length - 1; k >= 0; k--)
                        {
                            workSheet.Cells[46, 2] = TextUtils.ToString(listCost[k]["Code"]);
                            workSheet.Cells[46, 3] = TextUtils.ToString(listCost[k]["Name"]);
                            //workSheet.Cells[46, 4] = TextUtils.ToString(listCost[k]["Name"]);
                            workSheet.Cells[46, 5] = "Đồng";
                            //workSheet.Cells[46, 6] = TextUtils.ToDecimal(listCost[k]["Qty"]);
                            workSheet.Cells[46, 8] = TextUtils.ToDecimal(listCost[k]["TotalPrice"]);

                            ((Excel.Range)workSheet.Rows[46]).Insert();
                            Excel.Range range = workSheet.get_Range(workSheet.Cells[46, 3], workSheet.Cells[46, 4]);
                            range.Merge(true);
                        }

                        workSheet.Cells[46, 2] = TextUtils.ToString(dtGroup.Rows[i]["GroupCode"]);
                        workSheet.Cells[46, 3] = TextUtils.ToString(dtGroup.Rows[i]["GroupName"]);

                        ((Excel.Range)workSheet.Rows[46]).Font.Bold = true;
                        ((Excel.Range)workSheet.Rows[46]).Insert();
                        Excel.Range range1 = workSheet.get_Range(workSheet.Cells[46, 3], workSheet.Cells[46, 4]);
                        range1.Merge(true);
                    }

                    ((Excel.Range)workSheet.Rows[45]).Delete();
                    ((Excel.Range)workSheet.Rows[45]).Delete();
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
