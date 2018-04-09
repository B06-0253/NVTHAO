using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using TPA.Model;
using TPA.Business;
using DevExpress.XtraGrid.Views.Grid;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Diagnostics;

namespace BMS
{
    public partial class frmProjectProblemManager : _Forms
    {
        int _rownIndex = 0;
        public string ModuleCode = "";
        public string ProjectCode = "";

        public frmProjectProblemManager()
        {
            InitializeComponent();
        }

        private void frmProjectProblemManager_Load(object sender, EventArgs e)
        {
            loadYear();
            LoadInfoSearch();
        }

        void loadYear()
        {
            cboYear.Items.Add("Tất cả");
            for (int i = 2014; i <= DateTime.Now.Year; i++)
            {
                cboYear.Items.Add(i);
            }
            if (ModuleCode == "")
                cboYear.SelectedItem = DateTime.Now.Year;
        }

        void LoadInfoSearch()
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load dữ liệu..."))
            {
                try
                {
                    int year = TextUtils.ToInt(cboYear.SelectedItem);

                    string sql = "exec spProjectProblemAll " + (chkShowAll.Checked?-1:0) + ",'" + ProjectCode + "', '" + ModuleCode + "', " + year;                    

                    DataTable Source = LibQLSX.Select(sql);

                    grdData.DataSource = Source;
                    if (_rownIndex >= grvData.RowCount)
                        _rownIndex = 0;
                    if (_rownIndex > 0)
                        grvData.FocusedRowHandle = _rownIndex;
                    grvData.SelectRow(_rownIndex);
                    //grvData.BestFitColumns();
                    if (ProjectCode != "")
                    {
                        grvData.ExpandAllGroups();
                    }
                    ProjectCode = ModuleCode = "";
                }
                catch
                {
                    grdData.DataSource = null;
                }
            }
        }

        void main_LoadDataChange(object sender, EventArgs e)
        {
            LoadInfoSearch();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmProjectProblem frm = new frmProjectProblem();
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            ProjectProblemModel model = (ProjectProblemModel)ProjectProblemBO.Instance.FindByPK(id);

            //if (Global.AppUserName != model.UpdatedBy)
            //{
            //    MessageBox.Show("Bạn không có quyền sửa vấn đề này!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}

            _rownIndex = grvData.FocusedRowHandle;
            frmProjectProblem frm = new frmProjectProblem();
            frm.ProjectProblem = model;
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            ProjectProblemModel model = (ProjectProblemModel)ProjectProblemBO.Instance.FindByPK(id);
            if (Global.AppUserName != model.UpdatedBy)
            {
                MessageBox.Show("Bạn không có quyền xóa vấn đề này!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa hoàn toàn yêu cầu [" + grvData.GetFocusedRowCellValue(colProjectName).ToString() + "] không?"
                , TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                return;
            }
            
            ProjectProblemBO.Instance.Delete(id);
            LoadInfoSearch();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            TextUtils.ExportExcel(grvData);
        }

        private void grvData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C)
            {
                try
                {
                    string text = TextUtils.ToString(grvData.GetFocusedRowCellValue(grvData.FocusedColumn));
                    Clipboard.SetText(text);
                }
                catch
                {
                }
            }
        }

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            frmProjectProblemReport frm = new frmProjectProblemReport();
            frm.Show();
        }

        private void chkIsDeleted_CheckedChanged(object sender, EventArgs e)
        {            
            LoadInfoSearch();            
        }

        private void khôiPhụcXóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (int i in grvData.GetSelectedRows())
            {
                int id = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                int isDeleted = TextUtils.ToInt(grvData.GetRowCellValue(i, colIsDeleted));

                if (id == 0) continue;
                if (isDeleted == 0) continue;

                ProjectProblemModel model = (ProjectProblemModel)ProjectProblemBO.Instance.FindByPK(id);
                model.IsDeleted = 0;
                ProjectProblemBO.Instance.Update(model);
                count++;
            }
            if (count > 0)
            {
                LoadInfoSearch();
            }
        }

        private void grvData_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0) return;
            GridView View = sender as GridView;
            int isDeleted = TextUtils.ToInt(View.GetRowCellValue(e.RowHandle, colIsDeleted));

            if (isDeleted == 1)
            {
                e.Appearance.ForeColor = Color.Red;
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            ProjectProblemModel model = (ProjectProblemModel)ProjectProblemBO.Instance.FindByPK(id);
            //_rownIndex = grvData.FocusedRowHandle;
            model.ID = 0;
            frmProjectProblem frm = new frmProjectProblem();
            frm.ProjectProblem = model;
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            ProjectProblemModel model = (ProjectProblemModel)ProjectProblemBO.Instance.FindByPK(id);
            //_rownIndex = grvData.FocusedRowHandle;
            model.ID = 0;
            frmProjectProblem frm = new frmProjectProblem();
            frm.ProjectProblem = model;
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnReportUser_Click(object sender, EventArgs e)
        {
            frmProjectProblemReportUser frm = new frmProjectProblemReportUser();
            frm.Show();
        }

        private void btnReloadData_Click(object sender, EventArgs e)
        {
            LoadInfoSearch();
        }

        private void btnExportDetail_Click(object sender, EventArgs e)
        {
            string projectCode = TextUtils.ToString(grvData.GetFocusedRowCellValue(colProjectCode));
            if (projectCode == "") return;

            string sql = "exec spProjectProblemAll -1,'" + projectCode + "', '', 0";
            DataTable dt = LibQLSX.Select(sql);

            if (dt.Rows.Count == 0) return;

            string localPath = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                localPath = fbd.SelectedPath + "\\VanDeChiTiet - " + projectCode + ".xlsx";
            }
            else
            {
                return;
            }

            string filePath = Application.StartupPath + "\\Templates\\PhongDuAn\\VanDeChiTiet.xlsx";

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

                    string nguoiPhuTrach = TextUtils.ToString(LibQLSX.ExcuteScalar("select UserName from vProject where ProjectCode = '" + projectCode + "'"));

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        workSheet.Cells[4, 1] = TextUtils.ToString(dt.Rows[i]["ProjectCode"]);
                        workSheet.Cells[4, 2] = TextUtils.ToString(dt.Rows[i]["ProjectName"]);
                        workSheet.Cells[4, 3] = nguoiPhuTrach;// TextUtils.ToString(dt.Rows[i]["UserName"]);
                        workSheet.Cells[4, 4] = TextUtils.ToString(dt.Rows[i]["DatePhatSinh"]);
                        workSheet.Cells[4, 5] = TextUtils.ToString(dt.Rows[i]["ModuleCode"]);
                        workSheet.Cells[4, 6] = TextUtils.ToString(dt.Rows[i]["Content"]);
                        workSheet.Cells[4, 7] = TextUtils.ToString(dt.Rows[i]["DName"]);
                        workSheet.Cells[4, 8] = TextUtils.ToString(dt.Rows[i]["Reason"]);
                        workSheet.Cells[4, 9] = TextUtils.ToString(dt.Rows[i]["DName"]);
                        workSheet.Cells[4, 10] = TextUtils.ToString(dt.Rows[i]["UserName"]);
                        //workSheet.Cells[4, 11] = TextUtils.ToString(dt.Rows[i][""]);
                        workSheet.Cells[4, 12] = TextUtils.ToString(dt.Rows[i]["StatusText"]) == "" ? "Chưa xử lý" : TextUtils.ToString(dt.Rows[i]["StatusText"]);
                        //workSheet.Cells[4, 13] = TextUtils.ToString(dt.Rows[i][""]);
                        //workSheet.Cells[4, 14] = TextUtils.ToString(dt.Rows[i][""]);

                        ((Excel.Range)workSheet.Rows[4]).Insert();
                    }

                    ((Excel.Range)workSheet.Rows[3]).Delete();
                    ((Excel.Range)workSheet.Rows[3]).Delete();
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
            }

            Process.Start(localPath);
        }

        private void btnExportSummary_Click(object sender, EventArgs e)
        {
            string projectCode = TextUtils.ToString(grvData.GetFocusedRowCellValue(colProjectCode));
            if (projectCode == "") return;

            string sql = "exec spProjectProblemSummary '" + projectCode + "'";
            DataTable dt = LibQLSX.Select(sql);

            if (dt.Rows.Count == 0) return;

            string localPath = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                localPath = fbd.SelectedPath + "\\TongHopVanDe - " + projectCode + ".xlsx";
            }
            else
            {
                return;
            }

            string filePath = Application.StartupPath + "\\Templates\\PhongDuAn\\TongHopVanDe.xlsx";

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

                    string nguoiPhuTrach = TextUtils.ToString(LibQLSX.ExcuteScalar("select top 1 UserName from vProject where ProjectCode = '" + projectCode + "'"));

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        workSheet.Cells[5, 1] = i + 1;
                        workSheet.Cells[5, 2] = projectCode;
                        workSheet.Cells[5, 3] = nguoiPhuTrach;

                        workSheet.Cells[5, 4] = TextUtils.ToString(dt.Rows[i]["Total"]);
                        workSheet.Cells[5, 5] = TextUtils.ToString(dt.Rows[i]["Total_CXL"]);

                        //workSheet.Cells[5, 6] = TextUtils.ToString(dt.Rows[i][""]);
                        //workSheet.Cells[5, 7] = TextUtils.ToString(dt.Rows[i][""]);

                        workSheet.Cells[5, 8] = TextUtils.ToString(dt.Rows[i]["TotalTK"]);
                        workSheet.Cells[5, 9] = TextUtils.ToString(dt.Rows[i]["TotalTK_CXL"]);

                        workSheet.Cells[5, 10] = TextUtils.ToString(dt.Rows[i]["TotalVT"]);
                        workSheet.Cells[5, 11] = TextUtils.ToString(dt.Rows[i]["TotalVT_CXL"]);

                        workSheet.Cells[5, 12] = TextUtils.ToString(dt.Rows[i]["TotalSXLR"]);
                        workSheet.Cells[5, 13] = TextUtils.ToString(dt.Rows[i]["TotalSXLR_CXL"]);

                        workSheet.Cells[5, 14] = TextUtils.ToString(dt.Rows[i]["TotalSV"]);
                        workSheet.Cells[5, 15] = TextUtils.ToString(dt.Rows[i]["TotalSV_CXL"]);

                        workSheet.Cells[5, 16] = TextUtils.ToString(dt.Rows[i]["TotalCG"]);
                        workSheet.Cells[5, 17] = TextUtils.ToString(dt.Rows[i]["TotalCG_CXL"]);

                        //workSheet.Cells[5, 18] = TextUtils.ToString(dt.Rows[i][""]);
                        //workSheet.Cells[5, 19] = TextUtils.ToString(dt.Rows[i][""]);
                        //workSheet.Cells[5, 20] = TextUtils.ToString(dt.Rows[i][""]);                        

                        ((Excel.Range)workSheet.Rows[5]).Insert();
                    }

                    ((Excel.Range)workSheet.Rows[4]).Delete();
                    ((Excel.Range)workSheet.Rows[4]).Delete();
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
            }

            Process.Start(localPath);
        }
    }
}
