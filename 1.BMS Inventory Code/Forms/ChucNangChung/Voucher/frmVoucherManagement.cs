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
    public partial class frmVoucherManagement : _Forms
    {
        private bool _isAdd;
        int _rownIndex = 0;

        public frmVoucherManagement()
        {
            InitializeComponent();
        }

        private void frmVoucherManagement_Load(object sender, EventArgs e)
        {
            loadData();
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

            return true;
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
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!grvData.IsDataRow(grvData.FocusedRowHandle))
                return;

            int strID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID).ToString());

            string strName = grvData.GetFocusedRowCellValue(colName).ToString();

            if (CaseVoucherDebtBO.Instance.CheckExist("PayVoucherID", strID))
            {
                MessageBox.Show("Chứng từ này đang được sử dụng nên không thể xóa được!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            
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
            btnEdit_Click(null, null);
        }
    }
}
