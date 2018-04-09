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
using DevExpress.Utils;
using System.Diagnostics;

namespace BMS
{
    public partial class frmYCMVTwarningNew : _Forms
    {
        int _rownIndex = 0;
        public frmYCMVTwarningNew()
        {
            InitializeComponent();
        }

        private void frmYCMVTwarningNew_Load(object sender, EventArgs e)
        {
            loadData();
            loadYear();
            cboMonth.SelectedIndex = 0;
        }

        void loadYear()
        {
            cboYear.Items.Add("Tất cả");
            for (int i = 2013; i <= DateTime.Now.Year; i++)
            {
                cboYear.Items.Add(i);
            }
            cboYear.SelectedItem = DateTime.Now.Year;
        }

        void loadData()
        {
            //string[] _paraName = new string[5];
            //object[] _paraValue = new object[5];

            //_paraName[0] = "@Period"; _paraValue[0] = -1;
            //_paraName[1] = "@Status"; _paraValue[1] = -1;

            DataTable dt = new DataTable();
            //if (Global.AppUserName == "khoi.pd" || Global.AppUserName == "thao.nv")
            //{
            //    _paraName[2] = "@Account"; _paraValue[2] = "";
            //}
            //else
            //{
            //    _paraName[2] = "@Account"; _paraValue[2] = Global.AppUserName;
            //}

            //_paraName[3] = "@Year"; _paraValue[3] = cboYear.SelectedItem;
            //_paraName[4] = "@Month"; _paraValue[3] = cboMonth.SelectedIndex;

            //dt = LibQLSX.LoadDataFromSP("spGetProposalProblem", "PP", _paraName, _paraValue);
            string sql = "exec spGetProposalProblem -1,-1,''," + TextUtils.ToInt(cboYear.SelectedItem) + "," + cboMonth.SelectedIndex;
            dt = LibQLSX.Select(sql);

            grdYCMVT.DataSource = dt;
            if (_rownIndex >= grvYCMVT.RowCount)
                _rownIndex = 0;
            if (_rownIndex > 0)
                grvYCMVT.FocusedRowHandle = _rownIndex;
            grvYCMVT.SelectRow(_rownIndex);
        }

        private void cboIsCompleted_SelectionChangeCommitted(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                TextUtils.ExportExcel(grvYCMVT);
            }
            catch
            {
            }
        }

        private void btnExcelDetail_Click(object sender, EventArgs e)
        {
            if (grvYCMVT.RowCount == 0) return;

            string path = "";

            //bool isQtyTotal = false;

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path = fbd.SelectedPath;
            }
            else
            {
                return;
            }

            string filePath = Application.StartupPath + "\\Templates\\PhongVT\\VanDeVatTuNew.xls";
            string currentPath = path + "\\VanDeVatTu-" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" +
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

            grvYCMVT.ExpandAllGroups();

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

                    for (int i = grvYCMVT.RowCount - 1; i >= 0; i--)
                    {
                        string proposalCode = TextUtils.ToString(grvYCMVT.GetRowCellValue(i, colMProposalCode));
                        if (proposalCode == "") continue;
                        //string sql = "select *,DATEDIFF(day, DateAboutE, DateAboutF) as Period from [dbo].[vRequirePartFull_Order] " +
                        //    "where ProposalCode = '" + proposalCode + "'";
                        //DataTable dt = LibQLSX.Select(sql);
                        DataTable dt = LibQLSX.Select("spGetPartWithYCMVT_All '" + proposalCode + "'");
                        for (int j = dt.Rows.Count - 1; j >= 0; j--)
                        {
                            string partsCode = TextUtils.ToString(dt.Rows[j]["PartsCode"]);
                            string partsName = TextUtils.ToString(dt.Rows[j]["PartsName"]);
                            string module = TextUtils.ToString(dt.Rows[j]["ModuleCode"]);
                            string sl = TextUtils.ToString(dt.Rows[j]["TotalBuy"]);
                            //string dateE = TextUtils.ToDate1(dt.Rows[j]["DateAboutE"].ToString()).ToString("dd/MM/yyyy");
                            //string dateF = TextUtils.ToDate1(dt.Rows[j]["DateAboutF"].ToString()).ToString("dd/MM/yyyy");
                            //string period = TextUtils.ToString(dt.Rows[j]["Period"]);

                            workSheet.Cells[12, 1] = "";
                            workSheet.Cells[12, 2] = j + 1;
                            workSheet.Cells[12, 3] = partsCode;
                            workSheet.Cells[12, 4] = partsName;
                            workSheet.Cells[12, 5] = module;
                            workSheet.Cells[12, 6] = sl;
                            workSheet.Cells[12, 7] = TextUtils.ToString(dt.Rows[j]["ManufacturerCode"]);
                            //workSheet.Cells[12, 8] = dateE;
                            //workSheet.Cells[12, 9] = dateF;
                            //workSheet.Cells[12, 10] = period;
                            workSheet.Cells[12, 8] = TextUtils.ToString(grvYCMVT.GetRowCellValue(i, colAccount));
                            workSheet.Cells[12, 9] = proposalCode;
                            //workSheet.Cells[12, 10] = TextUtils.ToInt(grvYCMVT.GetRowCellValue(i, colIsCreatedPO));
                            workSheet.Cells[12, 11] = TextUtils.ToInt(grvYCMVT.GetRowCellValue(i, colIsCreatedPO));
                            workSheet.Cells[12, 12] = TextUtils.ToString(dt.Rows[j]["ProjectCode"]);

                            ((Excel.Range)workSheet.Rows[12]).Insert();
                        }

                        workSheet.Cells[12, 1] = i + 1;
                        workSheet.Cells[12, 2] = "";
                        workSheet.Cells[12, 3] = proposalCode;
                        //workSheet.Cells[12, 4] = TextUtils.ToString(grvYCMVT.GetRowCellValue(i, colAccount));
                        //workSheet.Cells[12, 5] = TextUtils.ToString(grvYCMVT.GetRowCellValue(i, colOrderCode));
                        //workSheet.Cells[12, 6] = TextUtils.ToInt(grvYCMVT.GetRowCellValue(i, colIsCreatedPO));
                        workSheet.Cells[12, 7] = TextUtils.ToInt(grvYCMVT.GetRowCellValue(i, colIsCreatedPO));
                        workSheet.Cells[12, 8] = TextUtils.ToString(grvYCMVT.GetRowCellValue(i, colAccount));

                        ((Excel.Range)workSheet.Rows[12]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.GreenYellow);// Color.Yellow;
                        ((Excel.Range)workSheet.Rows[12]).Font.Bold = true;
                        ((Excel.Range)workSheet.Rows[12]).Insert();

                    }
                    ((Excel.Range)workSheet.Rows[11]).Delete();
                    ((Excel.Range)workSheet.Rows[11]).Delete();
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

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
