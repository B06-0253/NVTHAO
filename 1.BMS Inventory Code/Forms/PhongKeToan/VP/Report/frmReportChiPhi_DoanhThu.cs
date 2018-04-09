using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
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
using Excel = Microsoft.Office.Interop.Excel;

namespace BMS
{
    public partial class frmReportChiPhi_DoanhThu : _Forms
    {
        public frmReportChiPhi_DoanhThu()
        {
            InitializeComponent();
        }

        private void frmReportChiPhi_DoanhThu_Load(object sender, EventArgs e)
        {
            loadYear();
            loadPhongBan();
            //cboMonth.SelectedIndex = DateTime.Now.Month;
            gridBand1.Fixed = FixedStyle.Left;
        }

        void loadPhongBan()
        {
            string sql = "SELECT [PK_ID],[C_MA],[C_MOTA] FROM [T_DM_PHANXUONG] order by [C_MA]";
            DataTable dt = LibIE.Select(sql);
            cboPhongBan.Properties.DataSource = dt;
            cboPhongBan.Properties.DisplayMember = "C_MOTA";
            cboPhongBan.Properties.ValueMember = "C_MA";
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

        private void btnReloadData_Click(object sender, EventArgs e)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load dữ liệu..."))
            {
                string sql = "exec spReportChiPhi_DoanhThu " + TextUtils.ToInt(cboYear.SelectedItem) + ", '" + TextUtils.ToString(cboPhongBan.EditValue) + "'";
                DataTable dtData = LibIE.Select(sql);
                grdData.DataSource = dtData;
            }
        }

        private void btnExecl_Click(object sender, EventArgs e)
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

            //string filePath = Application.StartupPath + "\\Templates\\PhongKeToan\\MauChungTu.xlsx";
            //string currentPath = path + "\\" + TextUtils.ToString(cboPhongBan.EditValue)
            //    + "-" + TextUtils.ToString(grvCboProject.GetFocusedRowCellValue(colPhanXuongName))
            //    + "-" + TextUtils.ToString(cboYear.SelectedItem) + "-DT_CP.xlsx";

            //try
            //{
            //    File.Copy(filePath, currentPath, true);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Có lỗi: " + Environment.NewLine + ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}

            //using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang xuất báo cáo..."))
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

            //        DataTable dtItem = (DataTable)grdData.DataSource;
            //        DataTable dtGroup = LibIE.Select("select * from T_DM_KMP_GROUP with(nolock)");

            //        for (int i = 0; i < dtItem.Rows.Count; i++)
            //        {
            //            string orderCode = TextUtils.ToString(dtItem.Rows[i]["Code"]);
            //            string listProjects = TextUtils.ToString(dtItem.Rows[i]["Target"]);
            //            decimal vat = TextUtils.ToDecimal(dtItem.Rows[i]["VAT"]);
            //            decimal delivery = TextUtils.ToDecimal(dtItem.Rows[i]["DeliveryCost"]);
            //            decimal percentPay = TextUtils.ToDecimal(dtItem.Rows[i]["PercentPay"]);
            //            decimal totalTH = TextUtils.ToDecimal(dtItem.Rows[i]["TotalTH"]);
            //            string[] arrProject = listProjects.Split(',');
            //            if (arrProject.Length == 1)
            //            {
            //                //workSheet.Cells[8, 1] = i + 1;
            //                workSheet.Cells[8, 5] = orderCode.Length > 7 ? orderCode.Substring(0, 7) : orderCode;
            //                workSheet.Cells[8, 19] =
            //                    (TextUtils.ToDecimal(dtItem.Rows[i]["TotalCash"]) +
            //                     TextUtils.ToDecimal(dtItem.Rows[i]["TotalCK"])).ToString();
            //                workSheet.Cells[8, 7] = TextUtils.ToString(dtItem.Rows[i]["Name"]);
            //                workSheet.Cells[8, 20] = TextUtils.ToString(dtItem.Rows[i]["DCode"]);
            //                workSheet.Cells[8, 21] = TextUtils.ToString(dtItem.Rows[i]["CostCode"]);
            //                workSheet.Cells[8, 22] = TextUtils.ToString(dtItem.Rows[i]["Target"]);
            //                workSheet.Cells[8, 23] = orderCode;

            //                ((Excel.Range)workSheet.Rows[8]).Insert();
            //            }
            //            else if (arrProject.Length > 1)
            //            {
            //                //arrProject = arrProject.OrderByDescending(c => c).ToArray();
            //                foreach (string projectCode in arrProject)
            //                {
            //                    decimal total = 0;
            //                    if (orderCode.Length > 7)
            //                    {
            //                        string sql = "";
            //                        //bool isSXC = false;
            //                        if (!projectCode.Trim().StartsWith("Mua"))
            //                        {
            //                            sql = "select sum(TotalPrice) as total from vGetPartWithOrder where OrderCode = '" + orderCode +
            //                            "' and ProjectCode = '" + projectCode.Trim() + "'";
            //                            //isSXC = true;
            //                        }
            //                        else
            //                        {
            //                            sql = "select sum(TotalPrice) as total from vGetPartWithOrder where OrderCode = '" + orderCode +
            //                            "' and (ProjectCode is null or ProjectCode = '')";
            //                        }
            //                        DataTable dtSum = LibQLSX.Select(sql);
            //                        decimal totalTHp = TextUtils.ToDecimal(dtSum.Rows[0][0]);
            //                        decimal total_TH_D = totalTHp + totalTHp / (totalTH == 0 ? 1 : totalTH) * delivery;
            //                        total = Math.Round((total_TH_D + total_TH_D * vat / 100) * percentPay / 100);
            //                    }
            //                    else
            //                    {
            //                        total = TextUtils.ToDecimal(dtItem.Rows[i]["TotalCash"]) + TextUtils.ToDecimal(dtItem.Rows[i]["TotalCK"]);
            //                    }

            //                    workSheet.Cells[8, 5] = orderCode.Length > 7 ? orderCode.Substring(0, 7) : orderCode;
            //                    workSheet.Cells[8, 19] = total;
            //                    workSheet.Cells[8, 7] = TextUtils.ToString(dtItem.Rows[i]["Name"]);
            //                    workSheet.Cells[8, 20] = TextUtils.ToString(dtItem.Rows[i]["DCode"]);
            //                    workSheet.Cells[8, 21] = TextUtils.ToString(dtItem.Rows[i]["CostCode"]);
            //                    workSheet.Cells[8, 22] = projectCode.Trim();
            //                    workSheet.Cells[8, 23] = orderCode;

            //                    ((Excel.Range)workSheet.Rows[8]).Insert();
            //                }
            //            }
            //        }

            //        ((Excel.Range)workSheet.Rows[7]).Delete();
            //        ((Excel.Range)workSheet.Rows[7]).Delete();
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
    }
}
