using System;
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
    public partial class frmQuotationManagement : _Forms
    {
        int _rownIndex = 0;
        public frmQuotationManagement()
        {
            InitializeComponent();
        }

        private void QuotationManagement_Load(object sender, EventArgs e)
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
            DataTable dt = LibQLSX.Select("Select * from vC_Quotation with(nolock) where Year = " + TextUtils.ToInt(cboYear.SelectedItem));
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

        private void btnNewGroup_Click(object sender, EventArgs e)
        {
            frmQuotation frm = new frmQuotation();
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnEditGroup_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            C_QuotationModel model = (C_QuotationModel)C_QuotationBO.Instance.FindByPK(id);
            _rownIndex = grvData.FocusedRowHandle;

            frmQuotation frm = new frmQuotation();
            frm.CurrentQuotation = model;
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnDeleteGroup_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvData.DataSource == null) return;
                int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
                string code = grvData.GetFocusedRowCellValue(colCode).ToString();
                if (id == 0) return;

                if (C_QuotationDetailBO.Instance.CheckExist("C_QuotationID", id))
                {
                    MessageBox.Show("Báo giá này đang chứa thiết bị nên không thể xóa được.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
               
                if (MessageBox.Show("Bạn có chắc muốn xóa báo giá này không?",
                      TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                C_QuotationBO.Instance.Delete(id);
                LoadInfoSearch();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            C_QuotationModel model = (C_QuotationModel)C_QuotationBO.Instance.FindByPK(id);
            _rownIndex = grvData.FocusedRowHandle;

            //frmQuotationDetailManagement frm = new frmQuotationDetailManagement();
            frmQuotationDetailManagementNew frm = new frmQuotationDetailManagementNew();
            frm.Quotation = model;
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            btnEditGroup_Click(null, null);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            C_QuotationModel model = (C_QuotationModel)C_QuotationBO.Instance.FindByPK(id);

            frmQuotationReport frm = new frmQuotationReport();
            frm.thisQuotation = model;
            frm.Show();
        }

        private void btnReportProductGroup_Click(object sender, EventArgs e)
        {
            frmQuotationReportOfProductGroup frm = new frmQuotationReportOfProductGroup();
            frm.Show();
        }

        private void hủyDuyệtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            DialogResult result = MessageBox.Show("Bạn có chắc muốn hủy duyệt báo giá này?",TextUtils.Caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.No) return;
            C_QuotationModel model = (C_QuotationModel)C_QuotationBO.Instance.FindByPK(id);
            model.IsApproved = false;
            C_QuotationBO.Instance.Update(model);
            grvData.SetFocusedRowCellValue(colIsApproved, false);
        }

        private void btnApproved_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            DialogResult result = MessageBox.Show("Bạn có chắc muốn duyệt báo giá này?", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;
            C_QuotationModel model = (C_QuotationModel)C_QuotationBO.Instance.FindByPK(id);
            model.IsApproved = true;
            C_QuotationBO.Instance.Update(model);
            grvData.SetFocusedRowCellValue(colIsApproved, true);
        }

        private void btnReportNC_NganhHang_Click(object sender, EventArgs e)
        {

        }        
    }
}
