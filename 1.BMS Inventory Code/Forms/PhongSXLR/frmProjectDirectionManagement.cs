using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPA.Business;

namespace BMS
{
    public partial class frmProjectDirectionManagement : _Forms
    {
        public frmProjectDirectionManagement()
        {
            InitializeComponent();
        }

        private void frmProjectDirectionManagement_Load(object sender, EventArgs e)
        {
            loadProject();
        }

        void loadProject()
        {
            try
            {
                //DataTable tbl = LibQLSX.Select("exec spGetAllProject");
                DataTable tbl = LibQLSX.Select("select * from Project");
                TextUtils.PopulateCombo(cboProject, tbl, "ProjectCode", "ProjectId", "");
            }
            catch (Exception ex)
            {
            }
        }

        void loadGrid()
        {
            string sql = "exec spGetProjectDirection '" + TextUtils.ToString(cboProject.EditValue) + "'";
            grdData.DataSource = LibQLSX.Select(sql);
        }

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            frmProjectDirection frm = new frmProjectDirection();
            frm.ProjectDirectionID = id;
            frm.Show();
        }

        private void btnReloadData_Click(object sender, EventArgs e)
        {
            loadGrid();
        }

        private void cboProject_EditValueChanged(object sender, EventArgs e)
        {
            loadGrid();
        }

        private void grvData_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            decimal complete = TextUtils.ToDecimal(grvData.GetRowCellValue(e.RowHandle, colCompletePercent));
            if (e.Column == colCompletePercent && complete >= 100)
            {
                e.Appearance.BackColor = Color.GreenYellow;
            }       
        }

        private void btnDeadline_Click(object sender, EventArgs e)
        {
            if (TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID)) <= 0)
            {
                return;
            }

            frmDeadlineSX frm = new frmDeadlineSX();
            frm.ProjectDirectionID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (frm.ShowDialog() == DialogResult.OK)
            {
                loadGrid();
            }
        }

        private void btnDeleteChiThi_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;

            if (ProjectDirectionDetailBO.Instance.CheckExist("ProjectDirectionID", id))
            {
                MessageBox.Show("Chỉ thị này đang có dữ liệu nên không thể xóa được.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xóa Chỉ thị [" + id + "] không?",
                      TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            ProjectDirectionBO.Instance.Delete(id);
            loadGrid();
            MessageBox.Show("Xóa chỉ chị thành công.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
