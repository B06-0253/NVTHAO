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
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using DevExpress.Utils;

namespace BMS
{
    public partial class frmQuotationReport : _Forms
    {
        public C_QuotationModel thisQuotation = new C_QuotationModel();
        DataTable _dtReportQuotation = new DataTable();
        DataTable _dtCostQuotationLink = new DataTable();
        DataTable _dtCost = new DataTable();

        public frmQuotationReport()
        {
            InitializeComponent();
        }

        private void frmQuotationReport_Load(object sender, EventArgs e)
        {
            loadText();
            //loadCostDA();
            //loadCostSP();
            this.Text += ": " + thisQuotation.Code;
        }

        void loadText()
        {
            string[] paraName = new string[1];
            object[] paraValue = new object[1];
            paraName[0] = "@QuotationID"; paraValue[0] = thisQuotation.ID;

            _dtReportQuotation = C_CostBO.Instance.LoadDataFromSP("spReportQuotation", "Source", paraName, paraValue);
            if (_dtReportQuotation.Rows.Count > 0)
            {
                txtTotalHD.EditValue = TextUtils.ToDecimal(_dtReportQuotation.Rows[0]["TotalHD"]);
                txtTotalTPA.EditValue = TextUtils.ToDecimal(_dtReportQuotation.Rows[0]["TotalTPA"]);
                txtTax.EditValue = TextUtils.ToDecimal(_dtReportQuotation.Rows[0]["TotalVAT"]);
                //txtTotalReal.EditValue = TextUtils.ToDecimal(_dtReportQuotation.Rows[0]["TotalReal"]);
                
                txtTotalSX.EditValue = TextUtils.ToDecimal(_dtReportQuotation.Rows[0]["TotalSX"]);
                txtTotalNC.EditValue = TextUtils.ToDecimal(_dtReportQuotation.Rows[0]["TotalNC"]); 
                txtTotalVT.EditValue = TextUtils.ToDecimal(_dtReportQuotation.Rows[0]["TotalVT"]);
                txtTotalCP.EditValue = TextUtils.ToDecimal(_dtReportQuotation.Rows[0]["TotalCP"]);
                txtTotalProfitTPA.EditValue = TextUtils.ToDecimal(_dtReportQuotation.Rows[0]["TotalProfit"]);

                txtTotalTrienKhai.EditValue = thisQuotation.TotalCustomer;
                txtCustomerValue.EditValue = TextUtils.ToDecimal(txtTotalHD.EditValue) * thisQuotation.CustomerPercent / 100 + thisQuotation.CustomerCash;
                txtTotalReal.EditValue = TextUtils.ToDecimal(txtTotalHD.EditValue) - TextUtils.ToDecimal(txtCustomerValue.EditValue);

                loadCostDA();
                loadCostSP();                

                txtTotalPB.EditValue = TextUtils.ToDecimal(colTotalPrice.SummaryItem.SummaryValue) - TextUtils.ToDecimal(txtTotalNC.EditValue);

                txtTotalBX.EditValue = thisQuotation.IsVAT < 2 ? TextUtils.ToDecimal(txtCustomerValue.EditValue) * 0.15M : 0;               

                //txtTotalProfitHD.EditValue = TextUtils.ToDecimal(txtTotalHD.EditValue) - TextUtils.ToDecimal(txtTotalTPA.EditValue) + TextUtils.ToDecimal(txtTotalProfitTPA.EditValue);
                txtTotalProfitHD.EditValue = TextUtils.ToDecimal(txtTotalHD.EditValue)
                    - TextUtils.ToDecimal(txtTotalVT.EditValue)
                    - TextUtils.ToDecimal(txtTotalNC.EditValue)
                    - TextUtils.ToDecimal(txtTotalPB.EditValue)
                    - TextUtils.ToDecimal(txtTotalTrienKhai.EditValue)
                    - TextUtils.ToDecimal(txtTax.EditValue)
                    - TextUtils.ToDecimal(txtTotalBX.EditValue)
                    - TextUtils.ToDecimal(txtCustomerValue.EditValue);
                    
                try
                {
                    txtTotalHD_P.EditValue = TextUtils.ToDecimal(txtTotalHD.EditValue) / TextUtils.ToDecimal(txtTotalHD.EditValue) * 100;
                    txtTotalTPA_P.EditValue = TextUtils.ToDecimal(txtTotalTPA.EditValue) / TextUtils.ToDecimal(txtTotalHD.EditValue) * 100;
                    txtTax_P.EditValue = TextUtils.ToDecimal(txtTax.EditValue) / TextUtils.ToDecimal(txtTotalHD.EditValue) * 100;
                    txtTotalVT_P.EditValue = TextUtils.ToDecimal(txtTotalVT.EditValue) / TextUtils.ToDecimal(txtTotalHD.EditValue) * 100;
                    txtTotalCustomer_P.EditValue = TextUtils.ToDecimal(txtTotalTrienKhai.EditValue) / TextUtils.ToDecimal(txtTotalHD.EditValue) * 100;
                    txtCustomerValue_P.EditValue = TextUtils.ToDecimal(txtCustomerValue.EditValue) / TextUtils.ToDecimal(txtTotalHD.EditValue) * 100;
                    txtTotalReal_P.EditValue = TextUtils.ToDecimal(txtTotalReal.EditValue) / TextUtils.ToDecimal(txtTotalHD.EditValue) * 100;
                    txtTotalPB_P.EditValue = TextUtils.ToDecimal(txtTotalPB.EditValue) / TextUtils.ToDecimal(txtTotalHD.EditValue) * 100;
                    txtTotalNC_P.EditValue = TextUtils.ToDecimal(txtTotalNC.EditValue) / TextUtils.ToDecimal(txtTotalHD.EditValue) * 100;
                    txtTotalBX_P.EditValue = TextUtils.ToDecimal(txtTotalBX.EditValue) / TextUtils.ToDecimal(txtTotalHD.EditValue) * 100;
                    
                    txtPriceSX_P.EditValue = TextUtils.ToDecimal(txtTotalSX.EditValue) / TextUtils.ToDecimal(txtTotalHD.EditValue) * 100;
                    txtTotalCP_P.EditValue = TextUtils.ToDecimal(txtTotalCP.EditValue) / TextUtils.ToDecimal(txtTotalHD.EditValue) * 100;

                    txtTotalProfitTPA_P.EditValue = TextUtils.ToDecimal(txtTotalProfitTPA.EditValue) / TextUtils.ToDecimal(txtTotalCP.EditValue) * 100;
                    txtTotalProfitTPA_PHD.EditValue = TextUtils.ToDecimal(txtTotalProfitTPA.EditValue) / TextUtils.ToDecimal(txtTotalHD.EditValue) * 100;

                    txtTotalProfitHD_P.EditValue = TextUtils.ToDecimal(txtTotalProfitHD.EditValue) / TextUtils.ToDecimal(txtTotalCP.EditValue) * 100;
                    txtTotalProfitHD_PHD.EditValue = TextUtils.ToDecimal(txtTotalProfitHD.EditValue) / TextUtils.ToDecimal(txtTotalHD.EditValue) * 100;
                }
                catch
                {                   
                }                
            }
        }

        void loadCostDA()
        {
            decimal totalHD = TextUtils.ToDecimal(txtTotalHD.EditValue);
            _dtCostQuotationLink = LibQLSX.Select("select *,TyLe = (Case when " + totalHD + " = 0 then 0 else CAST (Total/" + totalHD + " * 100 as decimal(18,4)) end) from vC_CostQuotationLink where C_QuotationID = " 
                + thisQuotation.ID);
            grdLink.DataSource = _dtCostQuotationLink;
        }
       
        void loadCostSP()
        {
            string[] paraName = new string[3];
            object[] paraValue = new object[3];

            paraName[0] = "@QuotationID"; paraValue[0] = thisQuotation.ID;
            paraName[1] = "@TotalHD"; paraValue[1] = TextUtils.ToDecimal(txtTotalHD.EditValue);
            paraName[2] = "@TotalTPA"; paraValue[2] = TextUtils.ToDecimal(txtTotalVT.EditValue);

            _dtCost = C_CostBO.Instance.LoadDataFromSP("spReportCostWithQuotation", "Source", paraName, paraValue);

            DataColumn colTyLeTT = new DataColumn();
            colTyLeTT.DataType = System.Type.GetType("System.Decimal");
            colTyLeTT.ColumnName = "TyLeTT";
            colTyLeTT.Expression = "TotalPrice / " + TextUtils.ToDecimal(txtTotalReal.EditValue) + " *100";
            _dtCost.Columns.Add(colTyLeTT);

            grdSP.DataSource = _dtCost;
        }

        private void btnCreateFCM_Click(object sender, EventArgs e)
        {
            string localPath = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                localPath = fbd.SelectedPath + "\\FCM - " + thisQuotation.Code + ".xlsx";
            }
            else
            {
                return;
            }

            string filePath = Application.StartupPath + "\\Templates\\PhongKinhDoanh\\FCM.xlsx";
            
            try
            {
                File.Copy(filePath, localPath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: File excel đang được mở." + Environment.NewLine + ex.Message);
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

                    DataTable dtQuotation = LibQLSX.Select("select * from vC_Quotation where ID = " + thisQuotation.ID);

                    workSheet.Cells[3, 4] = TextUtils.ToString(dtQuotation.Rows[0]["Name"]);
                    workSheet.Cells[4, 4] = "";
                    //workSheet.Cells[5, 4] = TextUtils.ToString(thisQuotation.Code);
                    workSheet.Cells[5, 4] = TextUtils.ToString(thisQuotation.ProjectCode);
                    workSheet.Cells[6, 4] = TextUtils.ToString(thisQuotation.ProjectName);
                    workSheet.Cells[7, 4] = TextUtils.ToString(thisQuotation.CustomerName);
                    workSheet.Cells[8, 4] = TextUtils.ToString(thisQuotation.CustomerName);
                    workSheet.Cells[9, 4] = TextUtils.ToString(dtQuotation.Rows[0]["Name"]);

                    workSheet.Cells[4, 6] = thisQuotation.DeliveryTime;
                    workSheet.Cells[8, 7] = TextUtils.ToString(dtQuotation.Rows[0]["StatusText"]);
                    workSheet.Cells[9, 7] = TextUtils.ToString(thisQuotation.POnumber);

                    workSheet.Cells[13, 7] = TextUtils.ToDecimal(txtTotalHD.EditValue);
                    workSheet.Cells[14, 7] = TextUtils.ToDecimal(txtTotalTPA.EditValue);
                    workSheet.Cells[15, 7] = TextUtils.ToDecimal(txtTax.EditValue);
                    workSheet.Cells[16, 7] = TextUtils.ToDecimal(txtTotalReal.EditValue);
                    workSheet.Cells[17, 7] = TextUtils.ToDecimal(txtTotalTrienKhai.EditValue);
                    workSheet.Cells[18, 7] = TextUtils.ToDecimal(txtTotalNC.EditValue);
                    workSheet.Cells[19, 7] = TextUtils.ToDecimal(txtTotalPB.EditValue);
                    workSheet.Cells[20, 7] = TextUtils.ToDecimal(txtTotalBX.EditValue);
                    workSheet.Cells[21, 7] = TextUtils.ToDecimal(txtTotalProfitTPA.EditValue);

                    workSheet.Cells[23, 7] = TextUtils.ToDecimal(txtTotalVT.EditValue);
                    workSheet.Cells[49, 6] = 1;
                    workSheet.Cells[49, 7] = thisQuotation.CustomerPercent * TextUtils.ToDecimal(txtTotalHD.EditValue) / 100 + thisQuotation.CustomerCash;
                   
                    for (int i = 27 ; i <= 100; i++)
                    {
                        int id = TextUtils.ToInt((workSheet.Cells[i, 9] as Excel.Range).Value2);
                        if (id == 0) continue;
                        
                        if(i >= 49 && i <= 63)
                        {
                            DataRow[] drs = _dtCostQuotationLink.Select("C_CostID = " + id);
                            workSheet.Cells[i, 6] = TextUtils.ToDecimal(drs[0]["Qty"]);
                            workSheet.Cells[i, 7] = TextUtils.ToDecimal(drs[0]["Total"]);
                        }
                        else
                        {
                            DataRow[] drs = _dtCost.Select("C_CostID = " + id);
                            workSheet.Cells[i, 6] = TextUtils.ToDecimal(drs[0]["Qty"]);
                            workSheet.Cells[i, 7] = TextUtils.ToDecimal(drs[0]["TotalPrice"]);
                        }
                    }
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

        private void btnCP_Click(object sender, EventArgs e)
        {
            if (thisQuotation.ID == 0) return;           

            string localPath = "";

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                localPath = fbd.SelectedPath + "\\ChiPhiTrucTiep - " + this.thisQuotation.Code + ".xlsx";
            }
            else
            {
                return;
            }

            string filePath = Application.StartupPath + "\\Templates\\PhongKinhDoanh\\ChiPhiTrucTiep.xlsx";

            try
            {
                File.Copy(filePath, localPath, true);
            }
            catch
            {
                MessageBox.Show("Lỗi: File excel đang được mở.");
                return;
            }

            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo biểu mẫu..."))
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

                    DataTable dt = LibQLSX.Select("select * from vC_QuotationDetail_NC where C_QuotationID = " + thisQuotation.ID);

                    workSheet.Cells[2, 5] = TextUtils.ToString(dt.Rows[0]["QuotationCode"]);
                    workSheet.Cells[3, 5] = TextUtils.ToString(dt.Rows[0]["ProjectName"]);

                    DataRow[] drsParent = dt.Select("ParentID = 0","ID ASC");
                    for (int i = drsParent.Length - 1; i >= 0; i--)
                    {
                        int parentID = TextUtils.ToInt(drsParent[i]["ID"]);
                        DataRow[] drsChild = dt.Select("ParentID = " + parentID, "ID ASC");
                        if(drsChild.Length > 0)
                        {
                            for (int j = drsChild.Length - 1; j >= 0; j--)
                            {
                                ((Excel.Range)workSheet.Cells[10, 12]).Formula = "=M10*N10";
                                ((Excel.Range)workSheet.Cells[10, 15]).Formula = "=P10*Q10*(1 + 0.3 * (F10 - 1))/F10"; //=P29*Q29*(1 + 0.3 * (F29 - 1))/F29
                                ((Excel.Range)workSheet.Cells[10, 18]).Formula = "=S10*T10";
                                ((Excel.Range)workSheet.Cells[10, 21]).Formula = "=V10*W10";
                                ((Excel.Range)workSheet.Cells[10, 24]).Formula = "=Y10*Z10";
                                ((Excel.Range)workSheet.Cells[10, 27]).Formula = "=AB10*AC10";
                                ((Excel.Range)workSheet.Cells[10, 30]).Formula = "=AE10*AF10";

                                workSheet.Cells[10, 1] = "";
                                workSheet.Cells[10, 2] = "";
                                workSheet.Cells[10, 3] = j + 1;
                                workSheet.Cells[10, 4] = TextUtils.ToString(drsChild[j]["ModuleName"]);
                                workSheet.Cells[10, 5] = TextUtils.ToString(drsChild[j]["ModuleCode"]);
                                workSheet.Cells[10, 6] = TextUtils.ToDecimal(drsChild[j]["Qty"]);
                                workSheet.Cells[10, 7] = TextUtils.ToString(drsChild[j]["ProductGroupCode"]);
                                workSheet.Cells[10, 8] = TextUtils.ToDecimal(drsChild[j]["PriceVTSX"]);
                                workSheet.Cells[10, 9] = TextUtils.ToDecimal(drsChild[j]["PriceVTTN"]);
                                workSheet.Cells[10, 10] = TextUtils.ToDecimal(drsChild[j]["PriceVTPS"]);
                                workSheet.Cells[10, 11] = TextUtils.ToDecimal(drsChild[j]["PriceVTLD"]);
                                //workSheet.Cells[10, 12] = "";
                                workSheet.Cells[10, 13] = TextUtils.ToDecimal(drsChild[j]["Person_DA"]);
                                workSheet.Cells[10, 14] = TextUtils.ToDecimal(drsChild[j]["Day_DA"]);
                                //workSheet.Cells[10, 15] = "";
                                workSheet.Cells[10, 16] = TextUtils.ToDecimal(drsChild[j]["Person_TK"]);
                                workSheet.Cells[10, 17] = TextUtils.ToDecimal(drsChild[j]["Day_TK"]);
                                //workSheet.Cells[10, 18] = "";
                                workSheet.Cells[10, 19] = TextUtils.ToDecimal(drsChild[j]["Person_VT"]);
                                workSheet.Cells[10, 20] = TextUtils.ToDecimal(drsChild[j]["Day_VT"]);
                                //workSheet.Cells[10, 21] = "";
                                workSheet.Cells[10, 22] = TextUtils.ToDecimal(drsChild[j]["Person_KT"]);
                                workSheet.Cells[10, 23] = TextUtils.ToDecimal(drsChild[j]["Day_KT"]);
                                //workSheet.Cells[10, 24] = "";
                                workSheet.Cells[10, 25] = TextUtils.ToDecimal(drsChild[j]["Person_SX"]);
                                workSheet.Cells[10, 26] = TextUtils.ToDecimal(drsChild[j]["Day_SX"]);
                                //workSheet.Cells[10, 27] = "";
                                workSheet.Cells[10, 28] = TextUtils.ToDecimal(drsChild[j]["Person_PM"]);
                                workSheet.Cells[10, 29] = TextUtils.ToDecimal(drsChild[j]["Day_PM"]);
                                //workSheet.Cells[10, 30] = "";
                                workSheet.Cells[10, 31] = TextUtils.ToDecimal(drsChild[j]["Person_KCS"]);
                                workSheet.Cells[10, 32] = TextUtils.ToDecimal(drsChild[j]["Day_KCS"]);

                                ((Excel.Range)workSheet.Rows[10]).Insert();
                            }
                        }

                        ((Excel.Range)workSheet.Cells[10, 12]).Formula = "=M10*N10";
                        ((Excel.Range)workSheet.Cells[10, 15]).Formula = "=P10*Q10*(1 + 0.3 * (F10 - 1))/F10";
                        ((Excel.Range)workSheet.Cells[10, 18]).Formula = "=S10*T10";
                        ((Excel.Range)workSheet.Cells[10, 21]).Formula = "=V10*W10";
                        ((Excel.Range)workSheet.Cells[10, 24]).Formula = "=Y10*Z10";
                        ((Excel.Range)workSheet.Cells[10, 27]).Formula = "=AB10*AC10";
                        ((Excel.Range)workSheet.Cells[10, 30]).Formula = "=AE10*AF10";

                        workSheet.Cells[10, 1] = "";
                        workSheet.Cells[10, 2] = i + 1;
                        workSheet.Cells[10, 3] = "";
                        workSheet.Cells[10, 4] = TextUtils.ToString(drsParent[i]["ModuleName"]);
                        workSheet.Cells[10, 5] = TextUtils.ToString(drsParent[i]["ModuleCode"]);
                        workSheet.Cells[10, 6] = TextUtils.ToDecimal(drsParent[i]["Qty"]);
                        workSheet.Cells[10, 7] = TextUtils.ToString(drsParent[i]["ProductGroupCode"]);

                        if (TextUtils.ToString(drsParent[i]["ProductGroupCode"]) != "")
                        {
                            workSheet.Cells[10, 8] = TextUtils.ToDecimal(drsParent[i]["PriceVTSX"]);
                            workSheet.Cells[10, 9] = TextUtils.ToDecimal(drsParent[i]["PriceVTTN"]);
                            workSheet.Cells[10, 10] = TextUtils.ToDecimal(drsParent[i]["PriceVTPS"]);
                            workSheet.Cells[10, 11] = TextUtils.ToDecimal(drsParent[i]["PriceVTLD"]);
                        }                       

                        //workSheet.Cells[10, 12] = "";
                        workSheet.Cells[10, 13] = TextUtils.ToDecimal(drsParent[i]["Person_DA"]);
                        workSheet.Cells[10, 14] = TextUtils.ToDecimal(drsParent[i]["Day_DA"]);
                        //workSheet.Cells[10, 15] = "";
                        workSheet.Cells[10, 16] = TextUtils.ToDecimal(drsParent[i]["Person_TK"]);
                        workSheet.Cells[10, 17] = TextUtils.ToDecimal(drsParent[i]["Day_TK"]);
                        //workSheet.Cells[10, 18] = "";
                        workSheet.Cells[10, 19] = TextUtils.ToDecimal(drsParent[i]["Person_VT"]);
                        workSheet.Cells[10, 20] = TextUtils.ToDecimal(drsParent[i]["Day_VT"]);
                        //workSheet.Cells[10, 21] = "";
                        workSheet.Cells[10, 22] = TextUtils.ToDecimal(drsParent[i]["Person_KT"]);
                        workSheet.Cells[10, 23] = TextUtils.ToDecimal(drsParent[i]["Day_KT"]);
                        //workSheet.Cells[10, 24] = "";
                        workSheet.Cells[10, 25] = TextUtils.ToDecimal(drsParent[i]["Person_SX"]);
                        workSheet.Cells[10, 26] = TextUtils.ToDecimal(drsParent[i]["Day_SX"]);
                        //workSheet.Cells[10, 27] = "";
                        workSheet.Cells[10, 28] = TextUtils.ToDecimal(drsParent[i]["Person_PM"]);
                        workSheet.Cells[10, 29] = TextUtils.ToDecimal(drsParent[i]["Day_PM"]);
                        //workSheet.Cells[10, 30] = "";
                        workSheet.Cells[10, 31] = TextUtils.ToDecimal(drsParent[i]["Person_KCS"]);
                        workSheet.Cells[10, 32] = TextUtils.ToDecimal(drsParent[i]["Day_KCS"]);

                        ((Excel.Range)workSheet.Rows[10]).Font.Bold = true;
                        ((Excel.Range)workSheet.Rows[10]).Font.Size = 11;

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
                if (File.Exists(localPath))
                {
                    Process.Start(localPath);
                }
            }
        }

        private void grvLink_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == (Keys.C))
            {
                try
                {
                    string text = TextUtils.ToString(grvLink.GetFocusedRowCellValue(grvLink.FocusedColumn));
                    Clipboard.SetText(text);
                }
                catch (Exception)
                {
                }
            }
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == (Keys.C))
            {
                try
                {
                    string text = TextUtils.ToString(gridView1.GetFocusedRowCellValue(gridView1.FocusedColumn));
                    Clipboard.SetText(text);
                }
                catch (Exception)
                {
                }
            }
        }

        private void btnFCM_Click(object sender, EventArgs e)
        {
            string localPath = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                localPath = fbd.SelectedPath + "\\FCM - " + thisQuotation.Code + ".xlsx";
            }
            else
            {
                return;
            }

            string filePath = Application.StartupPath + "\\Templates\\PhongKinhDoanh\\FCM.xlsx";

            try
            {
                File.Copy(filePath, localPath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: File excel đang được mở." + Environment.NewLine + ex.Message);
                return;
            }

            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo báo giá..."))
            {
                DataTable dtQuotation = LibQLSX.Select("select * from vC_Quotation where ID = " + thisQuotation.ID);
                DataTable dtAllCost = LibQLSX.Select("exec spReportAllCostWithQuotation " + thisQuotation.ID);
                DataTable dtGroupP = TextUtils.GetDistinctDatatable(dtAllCost, "GroupCodeP");

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

                    workSheet.Cells[3, 4] = TextUtils.ToString(dtQuotation.Rows[0]["Name"]);
                    workSheet.Cells[4, 4] = "";
                    //workSheet.Cells[5, 4] = TextUtils.ToString(thisQuotation.Code);
                    workSheet.Cells[5, 4] = TextUtils.ToString(thisQuotation.ProjectCode);
                    workSheet.Cells[6, 4] = TextUtils.ToString(thisQuotation.ProjectName);
                    workSheet.Cells[7, 4] = TextUtils.ToString(thisQuotation.CustomerName);
                    workSheet.Cells[8, 4] = TextUtils.ToString(thisQuotation.CustomerName);
                    workSheet.Cells[9, 4] = TextUtils.ToString(dtQuotation.Rows[0]["Name"]);

                    workSheet.Cells[4, 6] = thisQuotation.DeliveryTime;
                    workSheet.Cells[8, 7] = TextUtils.ToString(dtQuotation.Rows[0]["StatusText"]);
                    workSheet.Cells[9, 7] = TextUtils.ToString(thisQuotation.POnumber);

                    workSheet.Cells[13, 7] = TextUtils.ToDecimal(txtTotalHD.EditValue);
                    workSheet.Cells[14, 7] = TextUtils.ToDecimal(txtTotalTPA.EditValue);
                    workSheet.Cells[15, 7] = TextUtils.ToDecimal(txtTax.EditValue);
                    workSheet.Cells[16, 7] = TextUtils.ToDecimal(txtTotalReal.EditValue);
                    workSheet.Cells[17, 7] = TextUtils.ToDecimal(txtTotalTrienKhai.EditValue);
                    workSheet.Cells[18, 7] = TextUtils.ToDecimal(txtTotalNC.EditValue);
                    workSheet.Cells[19, 7] = TextUtils.ToDecimal(txtTotalPB.EditValue);
                    workSheet.Cells[20, 7] = TextUtils.ToDecimal(txtTotalBX.EditValue);
                    workSheet.Cells[21, 7] = TextUtils.ToDecimal(txtCustomerValue.EditValue);
                    workSheet.Cells[22, 7] = TextUtils.ToDecimal(txtTotalProfitHD.EditValue);
                    workSheet.Cells[23, 7] = TextUtils.ToDecimal(txtTotalProfitHD.EditValue);
                    workSheet.Cells[24, 7] = TextUtils.ToDecimal(txtTotalProfitHD.EditValue);
                    workSheet.Cells[26, 7] = TextUtils.ToDecimal(txtTotalVT.EditValue);

                    for (int i = dtGroupP.Rows.Count - 1; i >= 0; i--)
                    {
                        string groupCodeP = TextUtils.ToString(dtGroupP.Rows[i]["GroupCodeP"]);
                        DataRow[] listGroupC = dtAllCost.AsEnumerable()
                            .Where(y => y.Field<string>("GroupCodeP") == groupCodeP)
                            .GroupBy(r => r.Field<string>("GroupCode"))
                            .Select(g => g.First())
                            .Distinct()
                            .OrderBy(r => r.Field<string>("GroupCode"))
                            .ToArray();

                        for (int j = listGroupC.Length - 1; j >= 0; j--)
                        {
                            string groupCode = TextUtils.ToString(listGroupC[j]["GroupCode"]);

                            DataRow[] listCost = dtAllCost.AsEnumerable()
                            .Where(y => y.Field<string>("GroupCode") == groupCode)                            
                            .ToArray();

                            for (int k = listCost.Length - 1; k >= 0; k--)
                            {
                                //workSheet.Cells[31, 2] = TextUtils.ToString(listCost[k]["Code"]);
                                workSheet.Cells[31, 3] = TextUtils.ToString(listCost[k]["Code"]);
                                workSheet.Cells[31, 4] = TextUtils.ToString(listCost[k]["Name"]);
                                workSheet.Cells[31, 5] = TextUtils.ToString(listCost[k]["Unit"]);
                                workSheet.Cells[31, 6] = TextUtils.ToDecimal(listCost[k]["Qty"]);
                                workSheet.Cells[31, 7] = TextUtils.ToDecimal(listCost[k]["TotalPrice"]);
                                workSheet.Cells[31, 8] = TextUtils.ToDecimal(listCost[k]["TotalPrice"]) / TextUtils.ToDecimal(txtTotalHD.EditValue);

                                ((Excel.Range)workSheet.Rows[31]).Insert();
                            }

                            workSheet.Cells[31, 2] = TextUtils.ToString(listGroupC[j]["GroupCode"]);
                            workSheet.Cells[31, 3] = TextUtils.ToString(listGroupC[j]["GroupName"]);
                            //workSheet.Cells[31, 4] = TextUtils.ToString(listGroupC[j]["Name"]);
                            workSheet.Cells[31, 5] = "Đồng";//TextUtils.ToString(listGroupC[j]["Unit"]);
                            workSheet.Cells[31, 6] = 1;// TextUtils.ToDecimal(listGroupC[j]["Qty"]);
                            decimal costC = TextUtils.ToDecimal(dtAllCost.Select("GroupCode = '" + groupCode + "'")
                                .Sum(x => x.Field<decimal>("TotalPrice")));
                            workSheet.Cells[31, 7] = costC;
                            workSheet.Cells[31, 8] = costC/TextUtils.ToDecimal(txtTotalHD.EditValue);

                            ((Excel.Range)workSheet.Rows[31]).Font.Bold = true;
                            ((Excel.Range)workSheet.Rows[31]).Insert();
                        }

                        workSheet.Cells[31, 2] = TextUtils.ToString(dtGroupP.Rows[i]["GroupCodeP"]);
                        workSheet.Cells[31, 3] = TextUtils.ToString(dtGroupP.Rows[i]["GroupNameP"]);
                        //workSheet.Cells[31, 4] = TextUtils.ToString(dtGroupP.Rows[i]["Name"]);
                        workSheet.Cells[31, 5] = "Đồng";//TextUtils.ToString(dtGroupP.Rows[i]["Unit"]);
                        workSheet.Cells[31, 6] = 1;// TextUtils.ToDecimal(dtGroupP.Rows[i]["Qty"]);
                        decimal costP = TextUtils.ToDecimal(dtAllCost.Select("GroupCodeP = '" + groupCodeP + "'")
                            .Sum(x => x.Field<decimal>("TotalPrice"))); ;
                        workSheet.Cells[31, 7] = costP;
                        workSheet.Cells[31, 8] = costP / TextUtils.ToDecimal(txtTotalHD.EditValue);

                        ((Excel.Range)workSheet.Rows[31]).Font.Bold = true;
                        ((Excel.Range)workSheet.Rows[31]).Insert();
                    }

                    ((Excel.Range)workSheet.Rows[30]).Delete();
                    ((Excel.Range)workSheet.Rows[30]).Delete();
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
