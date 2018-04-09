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
using DevExpress.XtraGrid.Views.Grid;

namespace BMS
{
    public partial class frmVouchers : _Forms
    {
        private bool _isAdd;
        int _rownIndex = 0;
        public PaymentTableItemModel PaymentTableItem = new PaymentTableItemModel();
        DataTable _dtDebt = new DataTable();

        public frmVouchers()
        {
            InitializeComponent();
        }

        private void frmVouchers_Load(object sender, EventArgs e)
        {
            if (PaymentTableItem.ID > 0)
            {
                this.Text += ": " + PaymentTableItem.Code;
                label1.Text += ": " + PaymentTableItem.Code;
            }
            
            loadData();
            loadDebt();
            btnTransfer.Enabled = PaymentTableItem.ID > 0;
        }

        private void SetInterface(bool isEdit)
        {
            grdData.Enabled = !isEdit;

            btnSave.Visible = isEdit;
            btnCancel.Visible = isEdit;

            btnNew.Visible = !isEdit;
            btnEdit.Visible = !isEdit;
            btnDelete.Visible = !isEdit;
            //btnConfirm.Visible = !isEdit;
        }

        private void ClearInterface()
        {
            txtName.Text = "";            
        }

        private bool checkValid(PayVouchersModel dModel)
        {            
            if (txtName.Text == "")
            {
                MessageBox.Show("Xin hãy điền tên.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
            {
                DataTable dt;
                if (dModel.ID > 0)
                {
                    dt = TextUtils.Select("select Name from PayVouchers with(nolock) where upper(Replace(Name,' ','')) = '"
                        + txtName.Text.Trim().ToUpper() + "' and ID <> " + dModel.ID);
                }
                else
                {
                    dt = TextUtils.Select("select Name from PayVouchers with(nolock) where upper(Replace(Name,' ','')) = '"
                        + txtName.Text.Trim().ToUpper() + "'");
                }
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Tên này đã tồn tại!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }
                }
            }

            if (cboType.SelectedIndex < 1)
            {
                MessageBox.Show("Bạn phải chọn một kiểu chứng từ!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return true;
        }

        private void loadData()
        {
            try
            {
                DataTable tbl = LibQLSX.Select("Select * from PayVouchers with(nolock)");
                grdData.DataSource = tbl;
                if (_rownIndex >= grvData.RowCount)
                    _rownIndex = 0;
                if (_rownIndex > 0)
                    grvData.FocusedRowHandle = _rownIndex;
                grvData.SelectRow(_rownIndex);
            }
            catch (Exception)
            {
            }
        }
        
        void loadDebt()
        {
            _dtDebt = LibQLSX.Select("select * from vPayVoucherLink with(nolock) where PaymentTableItemID = " + PaymentTableItem.ID);
            grdDebt.DataSource = _dtDebt;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            SetInterface(true);
            _isAdd = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!grvData.IsDataRow(grvData.FocusedRowHandle))
                return;
            SetInterface(true);
            _isAdd = false;
            _rownIndex = grvData.FocusedRowHandle;

            int ID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            PayVouchersModel dModel = (PayVouchersModel)PayVouchersBO.Instance.FindByPK(ID);
            
            txtName.Text = dModel.Name;
            //txtCode.Text = dModel.Code;
            //txtDescription.Text = dModel.Description;
            //cboCostType.SelectedIndex = dModel.Type;
            //chkIsFix.Checked = dModel.IsFix == 1 ? true : false;
            //cboDepartment.EditValue = dModel.DepartmentID;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!grvData.IsDataRow(grvData.FocusedRowHandle))
                return;

            int strID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID).ToString());

            string strName = grvData.GetFocusedRowCellValue(colName).ToString();

            if (PayVoucherDebtBO.Instance.CheckExist("PayVoucherID", strID))
            {
                MessageBox.Show("Chứng từ này đang được sử dụng nên không thể xóa được!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (MessageBox.Show(String.Format("Bạn có chắc muốn xóa [{0}] không?", strName), TextUtils.Caption,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    PayVouchersBO.Instance.Delete(Convert.ToInt32(strID));
                    loadData();
                }
                catch
                {
                    MessageBox.Show("Có lỗi xảy ra khi thực hiện thao tác, xin vui lòng thử lại sau.");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();
            try
            {               
                PayVouchersModel dModel;
                if (_isAdd)
                {
                    dModel = new PayVouchersModel();
                }
                else
                {
                    int ID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
                    dModel = (PayVouchersModel)PayVouchersBO.Instance.FindByPK(ID);
                }
                if (!checkValid(dModel))
                {
                    return;
                }
                
                dModel.Name = txtName.Text.Trim();
                dModel.Type = cboType.SelectedIndex;

                if (_isAdd)
                {
                    pt.Insert(dModel);
                }
                else
                {
                    pt.Update(dModel);
                }
                pt.CommitTransaction();
                loadData();
                SetInterface(false);
                ClearInterface();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                pt.CloseConnection();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetInterface(false);
            ClearInterface();
        }

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            if (grvData.RowCount > 0 && btnEdit.Enabled)
                btnEdit_Click(null, null);
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            if (PaymentTableItem.ID <= 0) return;

            foreach (int i in grvData.GetSelectedRows())
            {
                int voucherID = TextUtils.ToInt(grvData.GetRowCellValue(i,colID));
                DataRow[] drs = _dtDebt.Select("PayVoucherID = " + voucherID);
                if (drs.Length > 0)
                    continue;
                PayVoucherDebtModel model = new PayVoucherDebtModel();
                model.PayVoucherID = voucherID;
                model.PaymentTableItemID = PaymentTableItem.ID;
                model.CreatedBy = Global.AppUserName;
                model.CreatedDate = TextUtils.GetSystemDate();
                PayVoucherDebtBO.Instance.Insert(model);
            }

            loadDebt();
        }

        private void btnDeleteDebt_Click(object sender, EventArgs e)
        {
            if (grvDebt.SelectedRowsCount == 0) return;

            foreach (int i in grvDebt.GetSelectedRows())
            {
                long id = TextUtils.ToInt64(grvDebt.GetRowCellValue(i, colDebtID));
                PayVoucherDebtModel model = (PayVoucherDebtModel)PayVoucherDebtBO.Instance.FindByPK(id);
                model.CompletedDate = TextUtils.GetSystemDate();
                PayVoucherDebtBO.Instance.Update(model);                
            }
            loadDebt();
        }

        private void grvDebt_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0) return;
            GridView View = sender as GridView;
            string completeDate = TextUtils.ToString(View.GetRowCellValue(e.RowHandle, colDebtCompletedDate));
            DateTime completeDateDK = TextUtils.ToDate(View.GetRowCellValue(e.RowHandle, colDebtCompletedDateDK).ToString());
            if (completeDate == "")
            {
                if (completeDateDK.Date <= DateTime.Now.Date)
                {
                    e.Appearance.BackColor = Color.Red;
                }
                else
                {
                    e.Appearance.BackColor = Color.Yellow;
                }
            }
        }

        private void btnDeleteConfirm_Click(object sender, EventArgs e)
        {
            if (grvDebt.SelectedRowsCount == 0) return;

            foreach (int i in grvDebt.GetSelectedRows())
            {
                long id = TextUtils.ToInt64(grvDebt.GetRowCellValue(i, colDebtID));
                PayVoucherDebtModel model = (PayVoucherDebtModel)PayVoucherDebtBO.Instance.FindByPK(id);
                model.CompletedDate = null;
                PayVoucherDebtBO.Instance.Update(model);
            }
            
            loadDebt();
        }

        private void grvDebt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                long id = TextUtils.ToInt64(grvDebt.GetFocusedRowCellValue(colDebtID));
                string strName = TextUtils.ToString(grvDebt.GetFocusedRowCellValue(colDebtName));

                if (MessageBox.Show(String.Format("Bạn có chắc muốn xóa [{0}] không?", strName), TextUtils.Caption,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        PayVoucherDebtBO.Instance.Delete(id);
                        loadDebt();
                    }
                    catch
                    {
                        MessageBox.Show("Có lỗi xảy ra khi thực hiện thao tác, xin vui lòng thử lại sau.");
                    }
                }
            }
        }      

        private void btnSaveDateDK_Click(object sender, EventArgs e)
        {
            grvDebt.FocusedRowHandle = -1;
            for (int i = 0; i < grvDebt.RowCount; i++)
            {
                try
                {
                    long id = TextUtils.ToInt64(grvDebt.GetRowCellValue(i, colDebtID));
                    PayVoucherDebtModel model = (PayVoucherDebtModel)PayVoucherDebtBO.Instance.FindByPK(id);
                    model.CompletedDateDK = TextUtils.ToDate(grvDebt.GetFocusedRowCellValue(colDebtCompletedDateDK).ToString());
                    PayVoucherDebtBO.Instance.Update(model);   
                }
                catch (Exception)
                {                   
                }                    
            }
            MessageBox.Show("Lưu trữ ngày trả dự kiến thànhg công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
