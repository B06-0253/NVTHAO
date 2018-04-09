using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using BMS.Business;
//using BMS.Model;
//using BMS.Utils;
using TPA.Business;
using TPA.Model;
using TPA.Utils;

namespace BMS
{
    public partial class frmDesignSummaryManager : _Forms
    {
        int _rownIndex = 0;

        public frmDesignSummaryManager()
        {
            InitializeComponent();
        }

        private void frmDesignSummaryManager_Load(object sender, EventArgs e)
        {
            loadYear();
            loadData(DateTime.Now.Year.ToString());
        }

        void loadYear()
        {
            for (int i = 2015; i <= DateTime.Now.Year; i++)
            {
                cboYear.Items.Add(i.ToString());
            }
            cboYear.SelectedItem = DateTime.Now.Year.ToString();
        }

        void loadData(string year)
        {
            //frmDesignSummaryManager_View_All
            string sql = "";
            DataTable dt = new DataTable();
            //if(TextUtils.HasPermission("frmDesignSummaryManager_View_All"))
            //{
                sql = "select * from vDesignSummary with(nolock) where [Year] = '" + year + "'";
            //}
            //else
            //{
            //    sql = "select * from vDesignSummary with(nolock) where [Year] = '" + year + "' and UpdatedBy = '" + Global.AppUserName + "'";
            //}
            dt = LibQLSX.Select(sql);
            grdData.DataSource = dt;
            if (_rownIndex >= grvData.RowCount)
                _rownIndex = 0;
            if (_rownIndex > 0)
                grvData.FocusedRowHandle = _rownIndex;
        }

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData(cboYear.Text);
            grvData.Focus();
        }

        void main_LoadDataChange(object sender, EventArgs e)
        {
            loadData(cboYear.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _rownIndex = grvData.FocusedRowHandle;
            frmDesignSummary frm = new frmDesignSummary();
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            long id = TextUtils.ToInt64(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            DesignSummaryModel model = (DesignSummaryModel)DesignSummaryBO.Instance.FindByPK(id);

            //if (model.UpdatedBy != Global.AppUserName)
            //{
            //    MessageBox.Show("Bạn không có quyền sửa THTK này.", TextUtils.Caption,
            //       MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}

            frmDesignSummary frm = new frmDesignSummary();
            frm.DesignSummary = model;
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            long id = TextUtils.ToInt64(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;

            DesignSummaryModel model = (DesignSummaryModel)DesignSummaryBO.Instance.FindByPK(id);

            if (model.UpdatedBy != Global.AppUserName)
            {
                MessageBox.Show("Bạn không có quyền xóa THTK này.", TextUtils.Caption,
                   MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (model.IsApproved)
            {
                MessageBox.Show("Tổng hợp thiết kế đã được duyệt.\n Bạn không thể xóa được.", TextUtils.Caption,
                   MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa tổng hợp thiết kế này?", TextUtils.Caption,
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DesignSummaryBO.Instance.Delete(id);
                grvData.DeleteSelectedRows();
            }
        }

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void btnIsApproved_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn duyệt những THTK này?", TextUtils.Caption, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (int i in grvData.GetSelectedRows())
                {
                    if (i < 0) continue;
                    int iD = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                    if (iD == 0) continue;

                    DesignSummaryModel model = (DesignSummaryModel)DesignSummaryBO.Instance.FindByPK(iD);
                    if (!model.IsApproved)
                    {
                        model.IsApproved = true;
                        DesignSummaryBO.Instance.Update(model);
                        //grvData.SetFocusedRowCellValue(colIsApproved, true);
                    }
                }
                loadData(cboYear.Text);
            }

            MessageBox.Show("Duyệt thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void hủyDuyệtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn hủy duyệt những THTK này?", TextUtils.Caption, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (int i in grvData.GetSelectedRows())
                {
                    if (i < 0) continue;
                    int iD = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                    if (iD == 0) continue;

                    DesignSummaryModel model = (DesignSummaryModel)DesignSummaryBO.Instance.FindByPK(iD);
                    if (model.IsApproved)
                    {
                        model.IsApproved = false;
                        DesignSummaryBO.Instance.Update(model);
                        grvData.SetFocusedRowCellValue(colIsApproved, false);
                    }
                }
                loadData(cboYear.Text);
            }

            MessageBox.Show("Hủy duyệt thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
