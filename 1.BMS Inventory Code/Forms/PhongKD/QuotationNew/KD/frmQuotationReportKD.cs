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
using TPA.Utils;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using DevExpress.Utils;
using System.Diagnostics;

namespace BMS
{
    public partial class frmQuotationReportKD : _Forms
    {
        public C_Quotation_KDModel Quotation = new C_Quotation_KDModel();

        public frmQuotationReportKD()
        {
            InitializeComponent();
        }

        private void frmQuotationReportKD_Load(object sender, EventArgs e)
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

            DataTable dtQuotation = C_CostBO.Instance.LoadDataFromSP("spReportQuotationKD", "Source", paraName, paraValue);
            if (dtQuotation.Rows.Count > 0)
            {
                decimal vat = TextUtils.ToDecimal(dtQuotation.Rows[0]["TotalVAT_HD"]);

                txtTotalHD.EditValue = TextUtils.ToDecimal(dtQuotation.Rows[0]["TotalHD"]);
                txtTotalTPA.EditValue = TextUtils.ToDecimal(dtQuotation.Rows[0]["TotalTPA"]);
                txtTotalTPA_PreVAT.EditValue = TextUtils.ToDecimal(dtQuotation.Rows[0]["TotalTPA_PreVAT"]);
                txtTotalVAT.EditValue = TextUtils.ToDecimal(dtQuotation.Rows[0]["TotalVAT_HD"]);
                //txtTotalVAT.EditValue = TextUtils.ToDecimal(dtQuotation.Rows[0]["TotalVAT_HD"]);
                txtTotalVT_SX.EditValue = TextUtils.ToDecimal(dtQuotation.Rows[0]["TotalVT_SX"]);
                txtTotalVT_MN.EditValue = TextUtils.ToDecimal(dtQuotation.Rows[0]["TotalVT_MN"]);

                txtTotalNC.EditValue = TextUtils.ToDecimal(dtQuotation.Rows[0]["TotalNC"]);
                txtTotalPB.EditValue = TextUtils.ToDecimal(dtQuotation.Rows[0]["TotalPB"]);
                txtTotalDP.EditValue = Quotation.TotalDP_KD;
                txtTotalXL.EditValue = TextUtils.ToDecimal(dtQuotation.Rows[0]["TotalXL"]);
                txtTotalCustomer.EditValue = Quotation.CustomerCash;

                txtTotalNC_KD.EditValue = TextUtils.ToDecimal(dtQuotation.Rows[0]["TotalNC_KD"]);

                decimal chiXucTienBH = Quotation.DepartmentId == "D018" ? Quotation.CustomerCash + TextUtils.ToDecimal(dtQuotation.Rows[0]["TotalXL"]) : Quotation.CustomerCash;
                txtTotalReal.EditValue = TextUtils.ToDecimal(txtTotalHD.EditValue) - chiXucTienBH - vat;

                txtTotalProfitTT.EditValue = TextUtils.ToDecimal(dtQuotation.Rows[0]["TotalProfitTT"]);
                txtTotalProfitQD.EditValue = TextUtils.ToDecimal(dtQuotation.Rows[0]["TotalProfitQD"]);
            }
        }

        void loadGrid()
        {
            string[] paraName = new string[1];
            object[] paraValue = new object[1];

            paraName[0] = "@QuotationID"; paraValue[0] = Quotation.ID;

            DataTable dtCost = C_CostBO.Instance.LoadDataFromSP("spReportCostWithQuotationKD", "Source", paraName, paraValue);

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
                localPath = fbd.SelectedPath + "\\FCM-KD-" + Quotation.Code + ".xlsx";
            }
            else
            {
                return;
            }

            string fileName = "";
            if (Quotation.CreatedDepartmentID == 10)//KD1
            {
                fileName = "FCM-KD1.xlsx";
            }
            if (Quotation.CreatedDepartmentID == 16)//KD2
            {
                fileName = "FCM-KD2.xlsx";
            }
            string filePath = Application.StartupPath + "\\Templates\\PhongKinhDoanh\\" + fileName;
            //string filePath = Application.StartupPath + "\\Templates\\PhongKinhDoanh\\FCM-KD-TEMPLATE.xlsx";

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
                DataTable dtQuotation = LibQLSX.Select("exec [spGetQuotation] @QuotationID = " + Quotation.ID);
                DataTable dtAllCost = LibQLSX.Select("exec [spReportCostWithQuotationKD] " + Quotation.ID);
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
                    workSheet.Cells[9, 4] = TextUtils.ToString(dtQuotation.Rows[0]["DName"]);
                    workSheet.Cells[8, 7] = TextUtils.ToString(dtQuotation.Rows[0]["StatusText"]);
                    workSheet.Cells[9, 7] = TextUtils.ToString(Quotation.POnumber);
                    //Lợi nhuận
                    workSheet.Cells[13, 7] = TextUtils.ToDecimal(txtTotalProfitTT.EditValue);
                    workSheet.Cells[14, 7] = TextUtils.ToDecimal(txtTotalProfitQD.EditValue);
                    //Giá bán
                    workSheet.Cells[16, 7] = TextUtils.ToDecimal(txtTotalReal.EditValue);//Giá thực thu
                    workSheet.Cells[17, 7] = TextUtils.ToDecimal(txtTotalHD.EditValue);//Giá có VAT thực tế bán trên HĐ
                    workSheet.Cells[18, 7] = TextUtils.ToDecimal(txtTotalHD.EditValue);//Giá chưa VAT thực tế bán trên HĐ
                    workSheet.Cells[19, 7] = TextUtils.ToDecimal(txtTotalTPA.EditValue);//Giá có VAT theo quy định phải bán
                    workSheet.Cells[20, 7] = TextUtils.ToDecimal(txtTotalTPA_PreVAT.EditValue);//Giá chưa VAT theo quy định phải bán
                    //Chi phí
                    workSheet.Cells[22, 7] = TextUtils.ToDecimal(txtTotalVAT.EditValue);//Thuế GTGT phải nộp

                    //Khách hàng gửi
                    if (Quotation.CreatedDepartmentID == 10)//KD1
                    {
                        workSheet.Cells[23, 7] = Quotation.CustomerCash;//Chênh lệch chi- thu xúc tiền bán hàng 
                        workSheet.Cells[24, 7] = TextUtils.ToDecimal(txtTotalXL.EditValue);//Xử lí phần gửi
                        workSheet.Cells[25, 7] = Quotation.CustomerCash + TextUtils.ToDecimal(txtTotalXL.EditValue);//Khách hàng gửi
                    }
                    else
                    {
                        workSheet.Cells[23, 7] = Quotation.CustomerCash - TextUtils.ToDecimal(txtTotalXL.EditValue);//Chênh lệch chi- thu xúc tiền bán hàng 
                        workSheet.Cells[24, 7] = TextUtils.ToDecimal(txtTotalXL.EditValue);//Xử lí phần gửi
                        workSheet.Cells[25, 7] = Quotation.CustomerCash;//Khách hàng gửi
                    }

                    workSheet.Cells[26, 7] = Quotation.TotalVC_KD;//Chi phí vận chuyển
                    workSheet.Cells[27, 7] = Quotation.TotalBX_KD;//Chi phí bốc xếp

                    workSheet.Cells[29, 7] = TextUtils.ToDecimal(txtTotalVT_SX.EditValue);//Mua tại TPA
                    workSheet.Cells[30, 7] = TextUtils.ToDecimal(txtTotalVT_MN.EditValue);//Mua ngoài TPA

                    workSheet.Cells[31, 7] = TextUtils.ToDecimal(txtTotalNC.EditValue);//Chi phí cố định - Nhân công gián tiếp 
                    workSheet.Cells[32, 7] = TextUtils.ToDecimal(txtTotalNC_KD.EditValue);//Chi phí cố định - Nhân công KD
                    workSheet.Cells[33, 7] = TextUtils.ToDecimal(dtAllCost.Compute("Sum(TotalPrice)", "GroupCode = 'N08'"));//Chi phí quản lí N08
                    workSheet.Cells[34, 7] = TextUtils.ToDecimal(txtTotalDP.EditValue);//Chi phí dự phòng

                    workSheet.Cells[38, 7] = TextUtils.ToDecimal(dtAllCost.Compute("Sum(TotalPrice)", "GroupCode = 'N11'"));//Chi phí bảo hành
                    workSheet.Cells[39, 7] = TextUtils.ToDecimal(dtAllCost.Compute("Sum(TotalPrice)", "GroupCode = 'N09'"));//Chi phí lãi vay

                    for (int i = dtGroup.Rows.Count - 1; i >= 0; i--)
                    {
                        string groupCode = TextUtils.ToString(dtGroup.Rows[i]["GroupCode"]);

                        DataRow[] listCost = dtAllCost.AsEnumerable()
                            .Where(y => y.Field<string>("GroupCode") == groupCode)
                            .ToArray();

                        for (int k = listCost.Length - 1; k >= 0; k--)
                        {
                            workSheet.Cells[42, 2] = TextUtils.ToString(listCost[k]["Code"]);
                            workSheet.Cells[42, 3] = TextUtils.ToString(listCost[k]["Name"]);
                            //workSheet.Cells[42, 4] = TextUtils.ToString(listCost[k]["Name"]);
                            workSheet.Cells[42, 5] = "Đồng";
                            //workSheet.Cells[42, 6] = TextUtils.ToDecimal(listCost[k]["Qty"]);
                            workSheet.Cells[42, 7] = TextUtils.ToDecimal(listCost[k]["TotalPrice"]);

                            ((Excel.Range)workSheet.Rows[42]).Insert();
                            Excel.Range range = workSheet.get_Range(workSheet.Cells[42, 3], workSheet.Cells[42, 4]);
                            range.Merge(true);
                        }

                        workSheet.Cells[42, 2] = TextUtils.ToString(dtGroup.Rows[i]["GroupCode"]);
                        workSheet.Cells[42, 3] = TextUtils.ToString(dtGroup.Rows[i]["GroupName"]);

                        ((Excel.Range)workSheet.Rows[42]).Font.Bold = true;
                        ((Excel.Range)workSheet.Rows[42]).Insert();
                        Excel.Range range1 = workSheet.get_Range(workSheet.Cells[42, 3], workSheet.Cells[42, 4]);
                        range1.Merge(true);
                    }

                    ((Excel.Range)workSheet.Rows[41]).Delete();
                    ((Excel.Range)workSheet.Rows[41]).Delete();

                    Excel.Worksheet workSheet2 = (Excel.Worksheet)workBoook.Worksheets[2];
                    DataTable dtItem = LibQLSX.Select("select * from vC_QuotationDetail_KD with(nolock) where ParentID = 0 and C_QuotationID = " + Quotation.ID);

                    for (int i = dtItem.Rows.Count - 1; i >= 0; i--)
                    {
                        int id = TextUtils.ToInt(dtItem.Rows[i]["ID"]);
                        DataTable dtC = LibQLSX.Select("select * from vC_QuotationDetail_KD with(nolock) where ParentID = " + id);

                        for (int j = dtC.Rows.Count - 1; j >= 0; j--)
                        {
                            workSheet2.Cells[5, 1] = (i + 1) + "." + (j + 1);
                            workSheet2.Cells[5, 2] = TextUtils.ToString(dtC.Rows[j]["ModuleName"]);
                            workSheet2.Cells[5, 3] = TextUtils.ToString(dtC.Rows[j]["ModuleCode"]);
                            workSheet2.Cells[5, 4] = TextUtils.ToString(dtC.Rows[j]["Manufacture"]);
                            workSheet2.Cells[5, 5] = TextUtils.ToString(dtC.Rows[j]["Origin"]);
                            workSheet2.Cells[5, 6] = TextUtils.ToString(dtC.Rows[j]["DCode"]);
                            workSheet2.Cells[5, 7] = TextUtils.ToString(dtC.Rows[j]["C_ProductGroupCode"]);
                            workSheet2.Cells[5, 8] = TextUtils.ToString(dtC.Rows[j]["Qty"]);
                            workSheet2.Cells[5, 17] = TextUtils.ToString(dtC.Rows[j]["PriceVT"]);
                            workSheet2.Cells[5, 18] = TextUtils.ToDecimal(dtC.Rows[j]["VAT"]) / 100;

                            workSheet2.Cells[5, 22] = TextUtils.ToString(dtC.Rows[j]["PriceTPA_PreVAT"]);
                            workSheet2.Cells[5, 23] = TextUtils.ToString(dtC.Rows[j]["PriceTPA"]);
                            workSheet2.Cells[5, 24] = TextUtils.ToString(dtC.Rows[j]["PriceVAT_HD"]);
                            workSheet2.Cells[5, 25] = TextUtils.ToDecimal(dtC.Rows[j]["PriceHD"]) * (1 - TextUtils.ToDecimal(dtC.Rows[j]["VAT"]) / 100);
                            workSheet2.Cells[5, 26] = TextUtils.ToDecimal(dtC.Rows[j]["Qty"]) * TextUtils.ToDecimal(dtC.Rows[j]["PriceHD"]);
                            workSheet2.Cells[5, 27] = TextUtils.ToDecimal(dtC.Rows[j]["Qty"]) * TextUtils.ToDecimal(dtC.Rows[j]["PriceVT"]);

                            ((Excel.Range)workSheet2.Rows[5]).Insert();
                        }

                        workSheet2.Cells[5, 1] = i + 1;
                        workSheet2.Cells[5, 2] = TextUtils.ToString(dtItem.Rows[i]["ModuleName"]);
                        workSheet2.Cells[5, 3] = TextUtils.ToString(dtItem.Rows[i]["ModuleCode"]);
                        workSheet2.Cells[5, 4] = TextUtils.ToString(dtItem.Rows[i]["Manufacture"]);
                        workSheet2.Cells[5, 5] = TextUtils.ToString(dtItem.Rows[i]["Origin"]);
                        workSheet2.Cells[5, 6] = TextUtils.ToString(dtItem.Rows[i]["DCode"]);
                        workSheet2.Cells[5, 8] = TextUtils.ToString(dtItem.Rows[i]["Qty"]);
                        
                        if (dtC.Rows.Count == 0)
                        {
                            workSheet2.Cells[5, 7] = TextUtils.ToString(dtItem.Rows[i]["C_ProductGroupCode"]);
                            workSheet2.Cells[5, 17] = TextUtils.ToString(dtItem.Rows[i]["PriceVT"]);
                            workSheet2.Cells[5, 18] = TextUtils.ToDecimal(dtItem.Rows[i]["VAT"]) / 100;

                            workSheet2.Cells[5, 22] = TextUtils.ToString(dtItem.Rows[i]["PriceTPA_PreVAT"]);
                            workSheet2.Cells[5, 23] = TextUtils.ToString(dtItem.Rows[i]["PriceTPA"]);
                            workSheet2.Cells[5, 24] = TextUtils.ToString(dtItem.Rows[i]["PriceVAT_HD"]);
                            workSheet2.Cells[5, 25] = TextUtils.ToDecimal(dtItem.Rows[i]["PriceHD"]) * (1 - TextUtils.ToDecimal(dtItem.Rows[i]["VAT"]) / 100);
                            workSheet2.Cells[5, 26] = TextUtils.ToDecimal(dtItem.Rows[i]["Qty"]) * TextUtils.ToDecimal(dtItem.Rows[i]["PriceHD"]);
                            workSheet2.Cells[5, 27] = TextUtils.ToDecimal(dtItem.Rows[i]["Qty"]) * TextUtils.ToDecimal(dtItem.Rows[i]["PriceVT"]);
                        }

                        ((Excel.Range)workSheet2.Rows[5]).Font.Bold = true;
                        ((Excel.Range)workSheet2.Rows[5]).Insert();
                    }

                    ((Excel.Range)workSheet2.Rows[4]).Delete();
                    ((Excel.Range)workSheet2.Rows[4]).Delete();
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
