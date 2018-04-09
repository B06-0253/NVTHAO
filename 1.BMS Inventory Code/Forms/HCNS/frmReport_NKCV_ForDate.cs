using DevExpress.XtraGrid.Views.Grid;
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
    public partial class frmReport_NKCV_ForDate : _Forms
    {
        public frmReport_NKCV_ForDate()
        {
            InitializeComponent();
        }

        private void frmReport_NKCV_ForDate_Load(object sender, EventArgs e)
        {
            loadDepartment();
            dtpEndDate.EditValue = DateTime.Now.AddDays(-1);
            dtpStartDate.EditValue = DateTime.Now.AddDays(-1);
        }

        void loadDepartment()
        {
            DataTable dt = LibQLSX.Select("select * from Departments with(nolock)");
            cboDepartment.Properties.DataSource = dt;
            cboDepartment.Properties.ValueMember = "DepartmentId";
            cboDepartment.Properties.DisplayMember = "DName";
        }

        private void btnXemTatCa_Click(object sender, EventArgs e)
        {
            string[] _paraName = new string[3];
            object[] _paraValue = new object[3];

            _paraName[0] = "@StartDate"; _paraValue[0] = TextUtils.ToDate2(dtpStartDate.EditValue);
            _paraName[1] = "@EndDate"; _paraValue[1] = TextUtils.ToDate2(dtpEndDate.EditValue);
            _paraName[2] = "@DepartmentId"; _paraValue[2] = TextUtils.ToString(cboDepartment.EditValue);
            DataTable Source = LibQLSX.LoadDataFromSP("spReport_NKCV_ForDate", "Source", _paraName, _paraValue);
            grdData.DataSource = Source;
        }

        private void btnExecl_Click(object sender, EventArgs e)
        {
            TextUtils.ExportExcel(grvData);
        }

        private void dtpStartDate_EditValueChanged(object sender, EventArgs e)
        {
            if (dtpEndDate.EditValue == null && dtpStartDate.EditValue == null) return;
            txtTotalTime.Text = ((TextUtils.ToDate3(dtpEndDate.EditValue).AddDays(1) - TextUtils.ToDate3(dtpStartDate.EditValue)).Days*8).ToString();
        }

        private void dtpEndDate_EditValueChanged(object sender, EventArgs e)
        {
            if (dtpEndDate.EditValue == null && dtpStartDate.EditValue == null) return;
            txtTotalTime.Text = ((TextUtils.ToDate3(dtpEndDate.EditValue).AddDays(1) - TextUtils.ToDate3(dtpStartDate.EditValue)).Days * 8).ToString();
        }

        private void grvData_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;
            GridView View = sender as GridView;
            decimal totalTime = TextUtils.ToInt(View.GetRowCellValue(e.RowHandle, colWorkTime));
            if (totalTime < TextUtils.ToDecimal(txtTotalTime.Text))
            {
                e.Appearance.BackColor = Color.Yellow;
            }
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
