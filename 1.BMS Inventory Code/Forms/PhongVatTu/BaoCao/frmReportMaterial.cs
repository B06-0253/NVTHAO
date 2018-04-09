using DevExpress.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Diagnostics;

namespace BMS
{
    public partial class frmReportMaterial : _Forms
    {
        public frmReportMaterial()
        {
            InitializeComponent();
        }

        private void frmReportMaterial_Load(object sender, EventArgs e)
        {
            loadYCMVT();
        }

        void loadYCMVT()
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load dữ liệu..."))
            {
                string sql =
                    "select distinct ProposalCode,Year,Month,UserName,OrderCode from [dbo].[vRequirePartFull_Order] " +
                    " where DateAboutE is not null and DateAboutF is not null " +
                    " and ProposalCode is not null and DATEDIFF(day, DateAboutE, DateAboutF) > 1";
                DataTable dt = LibQLSX.Select(sql);
                grdYC.DataSource = dt;
            }
        }

        void loadPart()
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load dữ liệu..."))
            {
                string proposalCode = TextUtils.ToString(grvYC.GetFocusedRowCellValue(colCode));
                string sql =
                    "select *,DATEDIFF(day, DateAboutE, DateAboutF) as Period from [dbo].[vRequirePartFull_Order] where ProposalCode ='" +
                    proposalCode + "'";
                DataTable dt = LibQLSX.Select(sql);
                grdYCDetail.DataSource = dt;
            }
        }

        private void grvYC_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            loadPart();
        }

        private void btnExeclGroup_Click(object sender, EventArgs e)
        {
            if (grvYC.RowCount == 0) return;

            string path = "";

            bool isQtyTotal = false;

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path = fbd.SelectedPath;
            }
            else
            {
                return;
            }

            string filePath = Application.StartupPath + "\\Templates\\PhongVT\\BaoCaoVatTuChamTienDo.xls";
            string currentPath = path + "\\BaoCaoVatTuChamTienDo-" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" +
                                 DateTime.Now.Year + ".xls";

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

            grvYC.ExpandAllGroups();

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
                    workSheet = (Excel.Worksheet) workBoook.Worksheets[1];

                    for (int i = grvYC.RowCount - 1; i >= 0; i--)
                    {
                        string proposalCode = TextUtils.ToString(grvYC.GetRowCellValue(i, colCode));
                        if (proposalCode == "") continue;
                        string sql =
                            "select *,DATEDIFF(day, DateAboutE, DateAboutF) as Period from [dbo].[vRequirePartFull_Order] " +
                            "where DATEDIFF(day, DateAboutE, DateAboutF) > 1 and ProposalCode ='" +
                            proposalCode + "'";
                        DataTable dt = LibQLSX.Select(sql);
                        for (int j = dt.Rows.Count - 1; j >= 0; j--)
                        {
                            string partsCode = TextUtils.ToString(dt.Rows[j]["PartsCode"]);
                            string partsName = TextUtils.ToString(dt.Rows[j]["PartsName"]);
                            string module = TextUtils.ToString(dt.Rows[j]["ProjectModuleCode"]);
                            string sl = TextUtils.ToString(dt.Rows[j]["TotalBuy"]);
                            string dateE = TextUtils.ToDate1(dt.Rows[j]["DateAboutE"].ToString()).ToString("dd/MM/yyyy");
                            string dateF = TextUtils.ToDate1(dt.Rows[j]["DateAboutF"].ToString()).ToString("dd/MM/yyyy");
                            string period = TextUtils.ToString(dt.Rows[j]["Period"]);

                            workSheet.Cells[12, 1] = "";
                            workSheet.Cells[12, 2] = j + 1;
                            workSheet.Cells[12, 3] = partsCode;
                            workSheet.Cells[12, 4] = partsName;
                            workSheet.Cells[12, 5] = module;
                            workSheet.Cells[12, 6] = sl;
                            workSheet.Cells[12, 7] = dateE;
                            workSheet.Cells[12, 8] = dateF;
                            workSheet.Cells[12, 9] = period;

                            ((Excel.Range) workSheet.Rows[12]).Insert();
                        }

                        workSheet.Cells[12, 1] = i + 1;
                        workSheet.Cells[12, 2] = "";
                        workSheet.Cells[12, 3] = TextUtils.ToString(grvYC.GetRowCellValue(i, colCode));
                        workSheet.Cells[12, 4] = TextUtils.ToString(grvYC.GetRowCellValue(i, colUserName));
                        workSheet.Cells[12, 5] = TextUtils.ToString(grvYC.GetRowCellValue(i, colOrderCode));

                        ((Excel.Range) workSheet.Rows[12]).Font.Bold = true;
                        ((Excel.Range) workSheet.Rows[12]).Insert();

                    }
                    ((Excel.Range) workSheet.Rows[11]).Delete();
                    ((Excel.Range) workSheet.Rows[11]).Delete();
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
    }
}
