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

namespace BMS
{
    public partial class frmVoucherDebtManagement : _Forms
    {
        int _rownIndex = 0;

        public frmVoucherDebtManagement()
        {
            InitializeComponent();
        }

        private void frmVoucherDebtManagement_Load(object sender, EventArgs e)
        {
            loadData();
        }

        void loadData()
        {
            string sql = "select * from vCase with(nolock)";
            if (!chkAll.Checked)
            {
                sql += " where IsCompleted = 0";
            }
            DataTable dt = LibQLSX.Select(sql);
            grdData.DataSource = dt;
            if (_rownIndex >= grvData.RowCount)
                _rownIndex = 0;
            if (_rownIndex > 0)
                grvData.FocusedRowHandle = _rownIndex;
            grvData.SelectRow(_rownIndex);
        }

        void loadDebt()
        {
            int caseID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            DataTable dt = LibQLSX.Select("select * from vCaseVoucherDebt with(nolock) where CaseID = " + caseID);
            grdDebt.DataSource = dt;
        }

        void updateCompleted()
        {
            DataTable dt = (DataTable)grdDebt.DataSource;
            DataRow[] drs = dt.Select("CompletedDate is null");
            int caseID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            CasePaidModel casePaid = (CasePaidModel)CasePaidBO.Instance.FindByPK(caseID);
            casePaid.IsCompleted = drs.Length == 0;
            CasePaidBO.Instance.Update(casePaid);

            loadData();
        }

        void main_LoadDataChange(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmVoucherDebt frm = new frmVoucherDebt();            
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            CasePaidModel model = (CasePaidModel)CasePaidBO.Instance.FindByPK(id);
            _rownIndex = grvData.FocusedRowHandle;

            frmVoucherDebt frm = new frmVoucherDebt();
            frm.Case = model;
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvData.DataSource == null) return;
                int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
                string code = grvData.GetFocusedRowCellValue(colCode).ToString();
                bool islocked = TextUtils.ToBoolean(grvData.GetFocusedRowCellValue(colIsLocked));
                if (id == 0) return;

                if (CaseVoucherDebtBO.Instance.CheckExist("CaseID", id))
                {
                    MessageBox.Show("Vụ việc này đang chứa chứng từ nên không thể xóa được.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (islocked)
                {
                    MessageBox.Show("Vụ việc này đã chốt nên không thể xóa được.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                
                if (MessageBox.Show("Bạn có chắc muốn xóa vụ việc [" + grvData.GetFocusedRowCellValue(colName).ToString() + "] không?",
                      TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                CasePaidBO.Instance.Delete(id);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            TextUtils.ExportExcel(grvData);
        }

        private void grvData_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            loadDebt();
        }

        private void btnIsLocked_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn chốt các vụ việc này không?",
                      TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            foreach (int i in grvData.GetSelectedRows())
            {
                int iD = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                if (iD == 0) continue;

                CasePaidModel model = (CasePaidModel)CasePaidBO.Instance.FindByPK(iD);
                model.IsLocked = true;
                CasePaidBO.Instance.Update(model);
            }
            
            MessageBox.Show("Các vụ việc này đã được chốt.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);

            loadData();
        }

        private void btnShowVoucher_Click(object sender, EventArgs e)
        {
            frmVoucherManagement frm = new frmVoucherManagement();
            frm.Show();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            _rownIndex = grvData.FocusedRowHandle;

            if (MessageBox.Show("Bạn có chắc muốn xác nhận các chứng từ đã chọn này là đã trả?",
                      TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            foreach (int i in grvDebt.GetSelectedRows())
            {
                int iD = TextUtils.ToInt(grvDebt.GetRowCellValue(i, colDebtID));
                if (iD == 0) continue;

                CaseVoucherDebtModel model = (CaseVoucherDebtModel)CaseVoucherDebtBO.Instance.FindByPK(iD);
                model.CompletedDate = DateTime.Now;
                CaseVoucherDebtBO.Instance.Update(model);
            }

            loadDebt();

            updateCompleted();            
        }

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            frmReportVoucher frm = new frmReportVoucher();
            TextUtils.OpenForm(frm);
        }

        private void btnCancelIsLocked_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn hủy chốt các vụ việc này không?",
                      TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            foreach (int i in grvData.GetSelectedRows())
            {
                int iD = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                if (iD == 0) continue;

                CasePaidModel model = (CasePaidModel)CasePaidBO.Instance.FindByPK(iD);
                model.IsLocked = false;
                CasePaidBO.Instance.Update(model);
            }

            MessageBox.Show("Các vụ việc này đã được hủy chốt.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);

            loadData();
        }

        private void btnCancelConfirm_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn hủy xác nhận các chứng từ đã chọn này là đã trả?",
                      TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            foreach (int i in grvDebt.GetSelectedRows())
            {
                int iD = TextUtils.ToInt(grvDebt.GetRowCellValue(i, colDebtID));
                if (iD == 0) continue;

                CaseVoucherDebtModel model = (CaseVoucherDebtModel)CaseVoucherDebtBO.Instance.FindByPK(iD);
                model.CompletedDate = null;
                CaseVoucherDebtBO.Instance.Update(model);
            }

            updateCompleted();

            loadDebt();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
