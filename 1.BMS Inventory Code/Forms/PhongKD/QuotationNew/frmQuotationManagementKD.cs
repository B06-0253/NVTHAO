using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPA.Model;
using TPA.Business;
using TPA.Utils;

namespace BMS
{
    public partial class frmQuotationManagementKD : _Forms
    {
        int _rownIndex = 0;
        public frmQuotationManagementKD()
        {
            InitializeComponent();
        }

        private void frmQuotationManagementKD_Load(object sender, EventArgs e)
        {
            loadYear();
            LoadInfoSearch();
        }

        void loadYear()
        {
            cboYear.Items.Add("Tất cả");
            for (int i = 2015; i <= DateTime.Now.Year; i++)
            {
                cboYear.Items.Add(i);
            }
            cboYear.SelectedItem = DateTime.Now.Year;
        }
        
        void LoadInfoSearch()
        {
            List<int> listDepartmentID = new List<int>(new int[] { 1, 10, 16, 18 });

            DataTable dt = LibQLSX.Select("exec spGetQuotation " + TextUtils.ToInt(cboYear.SelectedItem) + ",0" + (!listDepartmentID.Contains(Global.DepartmentID) ? "" : ", " + Global.DepartmentID));
            grdData.DataSource = dt;
            if (_rownIndex >= grvData.RowCount)
                _rownIndex = 0;
            if (_rownIndex > 0)
                grvData.FocusedRowHandle = _rownIndex;
            grvData.SelectRow(_rownIndex);
        }

        void main_LoadDataChange(object sender, EventArgs e)
        {
            LoadInfoSearch();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            LoadInfoSearch();
        }

        private void btnReportProductGroup_Click(object sender, EventArgs e)
        {
            frmQuotationReportOfProductGroup frm = new frmQuotationReportOfProductGroup();
            frm.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmQuotationKD frm = new frmQuotationKD();
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            C_Quotation_KDModel model = (C_Quotation_KDModel)C_Quotation_KDBO.Instance.FindByPK(id);
            _rownIndex = grvData.FocusedRowHandle;

            frmQuotationKD frm = new frmQuotationKD();
            frm.CurrentQuotation = model;
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvData.DataSource == null) return;
                int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
                string code = grvData.GetFocusedRowCellValue(colCode).ToString();
                if (id == 0) return;

                if (C_QuotationDetail_KDBO.Instance.CheckExist("C_Quotation_KDID", id))
                {
                    MessageBox.Show("Báo giá này đang chứa thiết bị nên không thể xóa được.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (MessageBox.Show("Bạn có chắc muốn xóa báo giá này không?",
                      TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                C_Quotation_KDBO.Instance.Delete(id);
                LoadInfoSearch();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuotationDetailKD_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            C_Quotation_KDModel model = (C_Quotation_KDModel)C_Quotation_KDBO.Instance.FindByPK(id);
            _rownIndex = grvData.FocusedRowHandle;

            frmQuotationDetailKD frm = new frmQuotationDetailKD();
            frm.Quotation = model;
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnReportKD_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            C_Quotation_KDModel model = (C_Quotation_KDModel)C_Quotation_KDBO.Instance.FindByPK(id);

            frmQuotationReportKD frm = new frmQuotationReportKD();
            frm.Quotation = model;
            frm.Show();
        }

        private void btnApprovedKD_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            DialogResult result = MessageBox.Show("Bạn có chắc muốn duyệt báo giá này?", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;
            C_Quotation_KDModel model = (C_Quotation_KDModel)C_Quotation_KDBO.Instance.FindByPK(id);
            model.IsApproved = true;
            C_Quotation_KDBO.Instance.Update(model);
            grvData.SetFocusedRowCellValue(colIsApproved, true);
        }

        private void hủyDuyệtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            DialogResult result = MessageBox.Show("Bạn có chắc muốn hủy duyệt báo giá này?", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;
            C_Quotation_KDModel model = (C_Quotation_KDModel)C_Quotation_KDBO.Instance.FindByPK(id);
            model.IsApproved = false;
            C_Quotation_KDBO.Instance.Update(model);
            grvData.SetFocusedRowCellValue(colIsApproved, false);
        }

        private void btnNewSX_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            C_Quotation_KDModel model = (C_Quotation_KDModel)C_Quotation_KDBO.Instance.FindByPK(id);
            _rownIndex = grvData.FocusedRowHandle;

            frmQuotationDetailSX frm = new frmQuotationDetailSX();
            frm.Quotation = model;
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void btnReportSX_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            C_Quotation_KDModel model = (C_Quotation_KDModel)C_Quotation_KDBO.Instance.FindByPK(id);

            frmQuotationReportSX frm = new frmQuotationReportSX();
            frm.Quotation = model;
            frm.Show();
        }

        private void btnApprovedSX_Click(object sender, EventArgs e)
        {

        }
    }
}
