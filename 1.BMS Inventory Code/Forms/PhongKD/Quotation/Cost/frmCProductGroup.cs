using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPA.Business;
using TPA.Model;

namespace BMS
{
    public partial class frmCProductGroup : _Forms
    {
        private bool _isAdd;
        public frmCProductGroup()
        {
            InitializeComponent();
        }

        private void frmCProductGroup_Load(object sender, EventArgs e)
        {
            //repositoryItemCheckEdit1.ValueChecked = 1;
            //repositoryItemCheckEdit1.ValueUnchecked = 0;
            LoadData();
        }

        #region Methods
        private void SetInterface(bool isEdit)
        {
            grdData.Enabled = !isEdit;

            btnSave.Visible = isEdit;
            btnCancel.Visible = isEdit;

            btnNew.Visible = !isEdit;
            btnEdit.Visible = !isEdit;
            btnDelete.Visible = !isEdit;
        }

        private void ClearInterface()
        {
            txtName.Text = "";
            txtCode.Text = "";
            txtCustomerPercent.EditValue = 0;
            txtPercentProfit.EditValue = 0;
            txtVat.EditValue = 0;
        }

        private bool checkValid()
        {
            if (txtCode.Text == "")
            {
                MessageBox.Show("Xin hãy điền mã.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
            {
                DataTable dt;
                if (!_isAdd)
                {
                    int strID = TextUtils.ToInt(grvData.GetRowCellValue(grvData.FocusedRowHandle, "ID"));
                    dt = LibQLSX.Select("select Code from C_ProductGroup where Code = '" + txtCode.Text.Trim() + "' and ID <> " + strID);
                }
                else
                {
                    dt = LibQLSX.Select("select Code from C_ProductGroup where Code = '" + txtCode.Text.Trim() + "'");
                }
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Mã này đã tồn tại!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }
                }
            }
            if (txtName.Text == "")
            {
                MessageBox.Show("Xin hãy điền tên.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return true;
        }

        private void LoadData()
        {
            try
            {
                DataTable tbl = LibQLSX.Select("Select * from C_ProductGroup with(nolock)");
                grdData.DataSource = tbl;
            }
            catch (Exception)
            {
            }

        }
        #endregion

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
            txtName.Text = TextUtils.ToString(grvData.GetFocusedRowCellValue(colName));
            txtCode.Text = TextUtils.ToString(grvData.GetFocusedRowCellValue(colCode));
            txtVat.EditValue = TextUtils.ToDecimal(grvData.GetFocusedRowCellValue(colVAT));
            txtPercentProfit.EditValue = TextUtils.ToDecimal(grvData.GetFocusedRowCellValue(colProfitPercent));
            txtCustomerPercent.EditValue = TextUtils.ToDecimal(grvData.GetFocusedRowCellValue(colCustomerPercent));
            chkIsAfterTax.Checked = TextUtils.ToBoolean(grvData.GetFocusedRowCellValue(colIsAfterTax));
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!grvData.IsDataRow(grvData.FocusedRowHandle))
                return;

            int strID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));

            string strName = TextUtils.ToString(grvData.GetFocusedRowCellValue(colName));

            if (C_CostProductGroupLinkBO.Instance.CheckExist("C_ProductGroupID", strID))
            {
                MessageBox.Show("Loại sản phẩm này đang được sử dụng nên không thể xóa được!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (MessageBox.Show(String.Format("Bạn có chắc muốn xóa [{0}] không?", strName), TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    C_ProductGroupBO.Instance.Delete(Convert.ToInt32(strID));
                    LoadData();
                }
                catch
                {
                    MessageBox.Show("Có lỗi xảy ra khi thực hiện thao tác, xin vui lòng thử lại sau.");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkValid())
                {
                    C_ProductGroupModel dModel;
                    if (_isAdd)
                    {
                        dModel = new C_ProductGroupModel();
                    }
                    else
                    {
                        int ID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
                        dModel = (C_ProductGroupModel)C_ProductGroupBO.Instance.FindByPK(ID);
                    }
                    dModel.Code = txtCode.Text;
                    dModel.Name = txtName.Text;
                    dModel.VAT = TextUtils.ToDecimal(txtVat.EditValue);
                    dModel.CustomerPercent = TextUtils.ToDecimal(txtCustomerPercent.EditValue);
                    dModel.ProfitPercent = TextUtils.ToDecimal(txtPercentProfit.EditValue);
                    dModel.IsAfterTax = chkIsAfterTax.Checked;

                    if (_isAdd)
                    {
                        C_ProductGroupBO.Instance.Insert(dModel);
                    }
                    else
                        C_ProductGroupBO.Instance.Update(dModel);

                    LoadData();
                    SetInterface(false);
                    ClearInterface();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetInterface(false);
            ClearInterface();
        }

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            if (grvData.RowCount > 0 && btnEdit.Enabled == true)
                btnEdit_Click(null, null);
        }

    }
}
