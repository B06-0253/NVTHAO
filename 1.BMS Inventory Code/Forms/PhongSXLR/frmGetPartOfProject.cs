using DevExpress.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BMS
{
    public partial class frmGetPartOfProject : _Forms
    {
        public frmGetPartOfProject()
        {
            InitializeComponent();
        }

        private void frmGetPartOfProject_Load(object sender, EventArgs e)
        {
            loadProject();
            //loadData();
            cboStatus.SelectedIndex = 0;
        }

        void loadData()
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load dữ liệu..."))
            {
                string sql = "spGetPartOfProject '" + TextUtils.ToString(cboProject.EditValue) + "'," + cboStatus.SelectedIndex;
                DataTable dt = LibQLSX.Select(sql);
                grdData.DataSource = dt;
            }
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

        private void btnReloadData_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnExeclGroup_Click(object sender, EventArgs e)
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
                catch (Exception)
                {
                }
            }
        }
    }
}
