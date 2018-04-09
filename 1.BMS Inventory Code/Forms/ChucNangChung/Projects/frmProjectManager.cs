using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Utils;
using BMS.Business;
using BMS.Model;
using System.Globalization;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using System.IO;
using System.Diagnostics;
using System.Collections;

namespace BMS
{
    public partial class frmProjectManager : _Forms
    {
        public frmProjectManager()
        {
            InitializeComponent();
        }

        private void frmProjectManager_Load(object sender, EventArgs e)
        {
            loadGrid();
        }

        void loadGrid()
        {
            DataTable tbl = LibQLSX.Select("exec spGetAllProject");
            grdData.DataSource = null;
            grdData.DataSource = tbl;
        }

        void loadModules()
        {
            string projectCode = grvData.GetFocusedRowCellValue(colCode).ToString();
            if (projectCode != "")
            {
                try
                {
                    string[] paraName = new string[1];
                    string[] paraValue = new string[1];
                    paraName[0] = "@ProjectCode"; paraValue[0] = projectCode;
                    DataTable tbl = ModulesBO.Instance.LoadDataFromSP("spGetModuleOfProject", "Modules", paraName, paraValue);
                    grdProduct.DataSource = tbl;
                }
                catch
                {
                    grdProduct.DataSource = null;
                }
            }
            else
            {
                grdProduct.DataSource = null;
            }
        }

        void loadDate()
        {
            string projectCode = TextUtils.ToString(grvData.GetFocusedRowCellValue(colCode));
            string projectId = TextUtils.ToString(grvData.GetFocusedRowCellValue(colID));
            if (projectCode == "" || projectId == "") return;
         
            ArrayList listModule = ProjectDesignDateBO.Instance.FindByAttribute("ProjectCode", projectCode);
            if (listModule.Count != 0)
            {
                ProjectDesignDateModel model = (ProjectDesignDateModel)listModule[0];
                dtpStartDate.Value = (DateTime)model.DateYC;
                dtpEndDate.Value = (DateTime)model.DateHT;
            }
            else
            {
                dtpStartDate.Value = DateTime.Now;
                dtpEndDate.Value = DateTime.Now;
            }

            ArrayList arr = TPA.Business.ProjectBO.Instance.FindByAttribute("ProjectId", projectId);
            TPA.Model.ProjectModel p = (TPA.Model.ProjectModel)arr[0];
            dtpSXLRDeadline.EditValue = p.AssemblyDeadline;
            dtpEndDateDK.EditValue = p.DateFinishE;
        }

        private void grvData_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                loadModules();
                loadDate();
            }
            catch (Exception)
            {
            }
        }

        private void btnUpdateModule_Click(object sender, EventArgs e)
        {

        }

        private void grvProduct_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                string projectCode = grvData.GetFocusedRowCellValue(colCode).ToString();
                string moduleCode = grvProduct.GetFocusedRowCellValue(colProductCode).ToString();
                DataTable dt = TextUtils.Select("select *,case when ProjectCode is null or ProjectCode='' then '" + projectCode 
                    + "' else ProjectCode end as ProjectCode1 from ModuleVersion where ModuleCode = '"
                    + moduleCode + "' and (ProjectCode = '' or ProjectCode = '" + projectCode + "')");
                grdVersion.DataSource = dt;
                grvVersion.BestFitColumns();
            }
            catch
            {
                grdVersion.DataSource = null;
            }
        }

        private void grvVersion_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0) return;
            GridView View = sender as GridView;
            string projectCode = View.GetRowCellValue(e.RowHandle, colProjectCode) == null ? "" : View.GetRowCellValue(e.RowHandle, colProjectCode).ToString();
            string projectCodeP = grvData.GetFocusedRowCellValue(colCode).ToString();
            if (projectCode == projectCodeP)
            {
                e.Appearance.ForeColor = Color.Green;
            }
            else
            {
                string version = View.GetRowCellValue(e.RowHandle, colVersion) == null ? "-1" : View.GetRowCellValue(e.RowHandle, colProjectCode).ToString();
                if (version=="0")
                {
                    e.Appearance.ForeColor = Color.Green;
                }
            }            
        }

        private void btnDownloadVersion_Click(object sender, EventArgs e)
        {
            string year = grvData.GetFocusedRowCellValue(colYear).ToString();
            string projectCode = grvData.GetFocusedRowCellValue(colCode).ToString();
            string moduleCode = grvProduct.GetFocusedRowCellValue(colProductCode).ToString();
            string version = grvVersion.GetFocusedRowCellValue(colVersion).ToString();
            string sourcePath = grvVersion.GetFocusedRowCellValue(colPath).ToString();

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát",
                    "Đang download phiên bản thiết kế"))
                {
                    TextUtils.CopyFolderVB(sourcePath,
                        fbd.SelectedPath + "/" + year + "/" + projectCode + "/" + moduleCode + "/" + version);
                }
            }
            else
            {
                return;
            }
            Process.Start(fbd.SelectedPath + "/" + year + "/" + projectCode + "/" + moduleCode);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (grvData.SelectedRowsCount == 0) return;
            string projectId = TextUtils.ToString(grvData.GetFocusedRowCellValue(colID));
            string projectCode = TextUtils.ToString(grvData.GetFocusedRowCellValue(colCode));
            DataTable dt = TextUtils.Select("select top 1 * from ProjectDesignDate with(nolock) where ProjectCode = '" + projectCode + "'");
            
            ProjectDesignDateModel model = new ProjectDesignDateModel();
            if (dt.Rows.Count > 0)
            {
                model = (ProjectDesignDateModel)ProjectDesignDateBO.Instance.FindByPK(TextUtils.ToInt64(dt.Rows[0]["ID"]));
            }

            model.ProjectCode = projectCode;
            model.DateYC = dtpStartDate.Value;
            model.DateHT = dtpEndDate.Value;

            if (model.ID == 0)
            {
                ProjectDesignDateBO.Instance.Insert(model);
            }
            else
            {
                ProjectDesignDateBO.Instance.Update(model);
            }

            ArrayList arr = TPA.Business.ProjectBO.Instance.FindByAttribute("ProjectId", projectId);
            TPA.Model.ProjectModel p = (TPA.Model.ProjectModel)arr[0];
            p.AssemblyDeadline = (DateTime)dtpSXLRDeadline.EditValue;
            TPA.Business.ProjectBO.Instance.UpdateQLSX(p);

            MessageBox.Show("Cập nhật thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnExeclGroup_Click(object sender, EventArgs e)
        {
            TextUtils.ExportExcel(grvData);
        }
    }
}
