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
using Excel = Microsoft.Office.Interop.Excel;

namespace BMS
{
    public partial class frmReportProgressProject : _Forms
    {
        public frmReportProgressProject()
        {
            InitializeComponent();
        }

        private void frmReportProgressProject_Load(object sender, EventArgs e)
        {
            loadYear();
            loadProject();
            loadProjectStatus();
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

        void loadProject()
        {
            try
            {
                DataTable tbl = LibQLSX.Select("select * from Project");
                TextUtils.PopulateCombo(cboProject, tbl, "ProjectCode", "ProjectId", "");
            }
            catch (Exception ex)
            {
            }
        }

        void loadProjectStatus()
        {
            DataTable dt = LibQLSX.Select("select ID,Name from ProjectStatus with(nolock)");

            DataRow dr = dt.NewRow();
            dr["ID"] = 0;
            dr["Name"] = "--Tất cả--";
            dt.Rows.InsertAt(dr, 0);

            cboStatus.DataSource = dt;
            cboStatus.DisplayMember = "Name";
            cboStatus.ValueMember = "ID";
        }

        private void btnReloadData_Click(object sender, EventArgs e)
        {
            string sql = "spReportProgressProject @ProjectId = '" + TextUtils.ToString(cboProject.EditValue)
                + "', @Year = " + TextUtils.ToInt(cboYear.SelectedItem) + ", @ProjectStatusID = " + TextUtils.ToInt(cboStatus.SelectedValue);
            DataTable dt = LibQLSX.Select(sql);
            grdData.DataSource = dt;
        }

        private void đangSảnXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string projectId = TextUtils.ToString(grvData.GetFocusedRowCellValue(colID));
            string sql = "Update Project set IsAssembly = 1 where ProjectId = '" + projectId + "'";
            LibQLSX.ExcuteSQL(sql);
            btnReloadData_Click(null, null);
        }

        private void hủyĐangSảnXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string projectId = TextUtils.ToString(grvData.GetFocusedRowCellValue(colID));
            string sql = "Update Project set IsAssembly = 0 where ProjectId = '" + projectId + "'";
            LibQLSX.ExcuteSQL(sql);
            btnReloadData_Click(null, null);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (grvData.RowCount == 0) return;

            string localPath = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                localPath = fbd.SelectedPath + "\\ProjectReport_ " + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + ".xlsx";
            }
            else
            {
                return;
            }

            string filePath = Application.StartupPath + "\\Templates\\PhongSXLR\\ProjectReport.xlsx";

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

                    for (int i = grvData.RowCount-1; i >= 0; i--)
                    {
                        workSheet.Cells[3, 1] = i + 1;
                        workSheet.Cells[3, 2] = TextUtils.ToString(grvData.GetRowCellValue(i,colName));
                        workSheet.Cells[3, 3] = TextUtils.ToString(grvData.GetRowCellValue(i, colCode));
                        workSheet.Cells[3, 4] = TextUtils.ToDecimal(grvData.GetRowCellDisplayText(i, colCompletePercent));
                        workSheet.Cells[3, 5] = TextUtils.ToDecimal(grvData.GetRowCellDisplayText(i, colCNC));
                        workSheet.Cells[3, 6] = TextUtils.ToDecimal(grvData.GetRowCellDisplayText(i, colIN));
                        workSheet.Cells[3, 7] = TextUtils.ToDecimal(grvData.GetRowCellDisplayText(i, colGCAL));
                        workSheet.Cells[3, 8] = TextUtils.ToDecimal(grvData.GetRowCellDisplayText(i, colPCB));
                        workSheet.Cells[3, 9] = TextUtils.ToDecimal(grvData.GetRowCellDisplayText(i, colLR));
                        ((Excel.Range)workSheet.Rows[3]).Insert();
                    }

                    ((Excel.Range)workSheet.Rows[2]).Delete();
                    ((Excel.Range)workSheet.Rows[2]).Delete();
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

                //Process.Start(localPath);
                DataTable dtFile = new DataTable();

                dtFile.Columns.Add("ID");
                dtFile.Columns.Add("FileName");
                dtFile.Columns.Add("Path");

                dtFile.Rows.Add(0, Path.GetFileName(localPath), localPath);

                frmSendEmailAttach frm = new frmSendEmailAttach();
                frm.dtFile = dtFile;
                frm.Content = "Hi all!<br>SXLR gửi báo cáo tiến độ sản xuất ngày " + DateTime.Now.ToString("dd-MM-yyyy") 
                    + ".<br>Vui lòng xem trong attach file.<br>Để rõ chi tiết từng dự án, vui lòng xem trên phần mềm QLTK: PHÒNG SXLR/Báo cáo tiến độ/Báo cáo tiến độ theo thiết bị.";
                frm.To = "khsx@tpa.com.vn;sxlr@tpa.com.vn;kd2@tpa.com.vn;tk@tpa.com.vn;bgd@tpa.com.vn";
                frm.Subject = "Báo cáo tiến độ sản xuất đến ngày: " + DateTime.Now.ToString("dd-MM-yyyy");
                frm.Show();
            }
        }

        private void btnSetStatus_Click(object sender, EventArgs e)
        {
            int projectStatusID = TextUtils.ToInt(cboStatus.SelectedValue);
            if (projectStatusID == 0) return;

            foreach (int i in grvData.GetSelectedRows())
            {
                string projectId = TextUtils.ToString(grvData.GetRowCellValue(i,colID));
                string sql = "Update Project set ProjectStatusID = " + projectStatusID + " where ProjectId = '" + projectId + "'";
                LibQLSX.ExcuteSQL(sql);
            }
           
            btnReloadData_Click(null, null);
        }

        private void btnManageStatus_Click(object sender, EventArgs e)
        {
            frmProjectStatus frm = new frmProjectStatus();
            if(frm.ShowDialog()== DialogResult.OK)
            {
                loadProjectStatus();
            }
        }
    }
}
