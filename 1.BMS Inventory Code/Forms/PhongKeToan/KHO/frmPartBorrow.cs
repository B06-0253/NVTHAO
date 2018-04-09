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
using TPA.Utils;
using System.IO;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace BMS
{
    public partial class frmPartBorrow : _Forms
    {
        public PartBorrowModel PartBorrow = new PartBorrowModel();

        public delegate void LoadDataChangeHandler(object sender, EventArgs e);
        public event LoadDataChangeHandler LoadDataChange;

        public bool _isSaved;

        public frmPartBorrow()
        {
            InitializeComponent();
        }

        private void frmPartBorrow_Load(object sender, EventArgs e)
        {
            loadParts();
            loadUser();
            loadUnit();

            if (PartBorrow.ID > 0)
            {
                btnSaveAndClose.Visible = true;
                btnSave.Visible = false;

                cboPart.EditValue = PartBorrow.PartsId;
                cboUnit.SelectedValue = PartBorrow.Unit;
                cboUser.EditValue = PartBorrow.UserId;

                dtpDateBorrow.EditValue = PartBorrow.DateBorrow;
                dtpDateReturn.EditValue = PartBorrow.DateReturn;
                dtpDateReturnExpected.EditValue = PartBorrow.DateReturnExpected;

                txtPrice.EditValue = PartBorrow.Price;
                txtQty.EditValue = PartBorrow.Qty;
                txtQtyBorrow.EditValue = PartBorrow.QtyBorrow;
                txtQtyReturn.EditValue = PartBorrow.QtyReturn;
                txtTotal.EditValue = PartBorrow.Total;
                txtDescription.Text = PartBorrow.Description;
            }
            else
            {
                btnSaveAndClose.Visible = false;
                btnSave.Visible = true;
            }
        }

        void loadParts()
        {
            DataTable dt = LibQLSX.Select("select PartsId,PartsCode,PartsCode +' - '+ PartsName as PartsName from [dbo].[Parts] with(nolock) where ([PartType] =1 or [PartType]=2) and [PartsUse]=1 order by PartsCode");
            cboPart.Properties.DataSource = dt;
            cboPart.Properties.DisplayMember = "PartsName";
            cboPart.Properties.ValueMember = "PartsId";
        }

        void loadUser()
        {
            DataTable dt = LibQLSX.Select("Select * from [vUser] WITH(NOLOCK)");
            cboUser.Properties.DataSource = dt;
            cboUser.Properties.DisplayMember = "UserName";
            cboUser.Properties.ValueMember = "UserId";
            grvCboUser.BestFitColumns();
        }

        void loadUnit()
        {
            DataTable dt = LibQLSX.Select("select distinct Unit from [dbo].[Parts] with(nolock) where ([PartType] =1 or [PartType]=2) and [PartsUse]=1 order by Unit");
            cboUnit.DataSource = dt;
            cboUnit.ValueMember = "Unit";
            cboUnit.DisplayMember = "Unit";
        }

        bool ValidateForm()
        {
            if (cboUser.EditValue == null)
            {
                MessageBox.Show("Bạn chưa chọn Người mượn!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (cboPart.EditValue == null)
            {
                MessageBox.Show("Bạn chưa chọn Vật tư!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (cboUnit.SelectedValue == null)
            {
                MessageBox.Show("Bạn chưa chọn Đơn vị!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (dtpDateBorrow.EditValue == null)
            {
                MessageBox.Show("Bạn chưa nhập Ngày mượn!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (dtpDateReturnExpected.EditValue == null)
            {
                MessageBox.Show("Bạn chưa nhập Ngày trả dự kiến!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            return true;
        }

        void refresh()
        {
            PartBorrow = new PartBorrowModel();

            cboPart.EditValue = PartBorrow.PartsId;
            //cboUnit.SelectedValue = PartBorrow.Unit;
            //cboUser.EditValue = PartBorrow.UserId;

            //dtpDateBorrow.EditValue = PartBorrow.DateBorrow;
            //dtpDateReturn.EditValue = PartBorrow.DateReturn;
            //dtpDateReturnExpected.EditValue = PartBorrow.DateReturnExpected;

            txtPrice.EditValue = 0;
            txtQty.EditValue = 1;
            txtQtyBorrow.EditValue =1;
            txtQtyReturn.EditValue = 0;
            txtTotal.EditValue = 0;
            txtDescription.Text = "";
        }

        void save()
        {
            mnuMenu.Focus();
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();
            try
            {
                if (!ValidateForm())
                    return;

                PartBorrow.DateBorrow = (DateTime?)dtpDateBorrow.EditValue;
                PartBorrow.DateReturn = (DateTime?)dtpDateReturn.EditValue;
                PartBorrow.DateReturnExpected = (DateTime?)dtpDateReturnExpected.EditValue;

                PartBorrow.Price = TextUtils.ToDecimal(txtPrice.EditValue);
                PartBorrow.Qty = TextUtils.ToDecimal(txtQty.EditValue);
                PartBorrow.QtyBorrow = TextUtils.ToDecimal(txtQtyBorrow.EditValue);
                PartBorrow.QtyReturn = TextUtils.ToDecimal(txtQtyReturn.EditValue);
                PartBorrow.Total = TextUtils.ToDecimal(txtTotal.EditValue);
                PartBorrow.Description = txtDescription.Text.Trim();

                PartBorrow.PartsId = TextUtils.ToString(cboPart.EditValue);
                PartBorrow.Unit = TextUtils.ToString(cboUnit.SelectedValue);
                PartBorrow.UserId = TextUtils.ToString(cboUser.EditValue);
                
                if (PartBorrow.ID == 0)
                {
                    PartBorrow.ID = (long)pt.Insert(PartBorrow);
                }
                else
                {
                    pt.Update(PartBorrow);
                }                

                pt.CommitTransaction();
                
                _isSaved = true;
                MessageBox.Show("Lưu trữ thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (this.LoadDataChange != null)
                {
                    this.LoadDataChange(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lưu trữ không thành công!" + Environment.NewLine + ex.Message, TextUtils.Caption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                pt.CloseConnection();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save();
            refresh();
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            save();
            this.Close();
        }

        private void cboPart_EditValueChanged(object sender, EventArgs e)
        {
            if (cboPart.EditValue == null) return;

            string partsCode = TextUtils.ToString(grvCboKhachHang.GetFocusedRowCellValue(colCboCode));
            txtPrice.EditValue = TextUtils.GiaGanNhat(partsCode);
        }

        private void txtQtyBorrow_EditValueChanged(object sender, EventArgs e)
        {
            txtQty.EditValue = TextUtils.ToDecimal(txtQtyBorrow.EditValue) - TextUtils.ToDecimal(txtQtyReturn.EditValue);
        }

        private void txtQtyReturn_EditValueChanged(object sender, EventArgs e)
        {
            txtQty.EditValue = TextUtils.ToDecimal(txtQtyBorrow.EditValue) - TextUtils.ToDecimal(txtQtyReturn.EditValue);
        }

        private void txtQty_EditValueChanged(object sender, EventArgs e)
        {
            txtTotal.EditValue = TextUtils.ToDecimal(txtPrice.EditValue) * TextUtils.ToDecimal(txtQty.EditValue);
        }

        private void txtPrice_EditValueChanged(object sender, EventArgs e)
        {
            txtTotal.EditValue = TextUtils.ToDecimal(txtPrice.EditValue)*TextUtils.ToDecimal(txtQty.EditValue);
        }

        private void dtpDateBorrow_EditValueChanged(object sender, EventArgs e)
        {
            if (dtpDateBorrow.EditValue != null)
            {
                dtpDateReturnExpected.EditValue = ((DateTime)dtpDateBorrow.EditValue).AddDays(15);
            }
        }
    }
}
