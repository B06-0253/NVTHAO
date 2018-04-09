using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Model;
using System.Diagnostics;
using DevExpress.Utils;
using System.IO;

namespace BMS
{
    public partial class frmModuleVersion : _Forms
    {
        public ModulesModel Module = new ModulesModel();
        public frmModuleVersion()
        {
            InitializeComponent();
        }

        private void frmModuleVersion_Load(object sender, EventArgs e)
        {
            this.Text = "Danh sách phiên bản: " + Module.Code + " - " + Module.Name;
            loadModule();
        }

        void loadModule()
        {
            try
            {
                string moduleCode = Module.Code;
                DataTable dt = TextUtils.Select("select * from ModuleVersion where ModuleCode = '"+ moduleCode + "'");
                grdVersion.DataSource = dt;
                grvVersion.BestFitColumns();
            }
            catch
            {
                grdVersion.DataSource = null;
            }
        }

        private void btnDownloadVersion_Click(object sender, EventArgs e)
        {
            string moduleCode = Module.Code;

            string sourcePath = grvVersion.GetFocusedRowCellValue(colPath).ToString();
            string version = grvVersion.GetFocusedRowCellValue(colVersion).ToString();

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát", "Đang download phiên bản thiết kế"))
                {
                    TextUtils.CopyFolderVB(sourcePath, fbd.SelectedPath + "/" + moduleCode + "/" + version);
                }
            }
            else
            {
                return;
            }
            Process.Start(fbd.SelectedPath);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvVersion.RowCount > 0)
                {
                    TextUtils.ExportExcel(grvVersion);
                }
            }
            catch
            {
            }
        }
    }
}
