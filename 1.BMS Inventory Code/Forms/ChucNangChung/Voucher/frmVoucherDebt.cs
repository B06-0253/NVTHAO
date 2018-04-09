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
    public partial class frmVoucherDebt : _Forms
    {
        public CasePaidModel Case = new CasePaidModel();
        DataTable _dtDebt = new DataTable();

        public delegate void LoadDataChangeHandler(object sender, EventArgs e);
        public event LoadDataChangeHandler LoadDataChange;
        private bool _isSaved;

        #region Constuctor and Load
        public frmVoucherDebt()
        {
            InitializeComponent();
        }

        private void frmVoucherDebt_Load(object sender, EventArgs e)
        {
            loadOrder();
            loadUser();
            loadSupplier();
            loadData();
            loadDebt();

            txtNote.Enabled = (Global.DepartmentID == 3);

            if (Case.ID > 0)
            {
                txtCode.Text = Case.Code;
                txtName.Text = Case.Name;
                txtContent.Text = Case.Content;
                txtTarget.Text = Case.Target;
                txtNote.Text = Case.Note;

                cboNguoiPhuTrach.EditValue = Case.UserId;
            }
            
            if (Case.IsLocked)
            {
                colDebtCompletedDateDK.OptionsColumn.AllowEdit = false;
                btnSave.Enabled = (Global.DepartmentID == 3);
                btnDeleteVoucher.Enabled = false;
            }
        }
        #endregion

        #region Methods
        void loadOrder()
        {
            DataTable dt = LibQLSX.Select("Select * from [vOrder] WITH(NOLOCK)");
            cboOrder.Properties.DataSource = dt;
            cboOrder.Properties.DisplayMember = "OrderId";
            cboOrder.Properties.ValueMember = "OrderId";
            grvCboOrder.BestFitColumns();
        }

        void loadUser()
        {
            DataTable dt = LibQLSX.Select("Select * from [vUser] WITH(NOLOCK)");
            cboUser.Properties.DataSource = dt;
            cboUser.Properties.DisplayMember = "UserName";
            cboUser.Properties.ValueMember = "UserId";
            grvCboUser.BestFitColumns();

            //repositoryItemGridLookUpEdit1.DataSource = dt;
            //repositoryItemGridLookUpEdit1.DisplayMember = "UserName";
            //repositoryItemGridLookUpEdit1.ValueMember = "UserId";

            cboNguoiPhuTrach.Properties.DataSource = dt;
            cboNguoiPhuTrach.Properties.DisplayMember = "UserName";
            cboNguoiPhuTrach.Properties.ValueMember = "UserId";
            grvNguoiPhuTrach.BestFitColumns();
        }

        void loadSupplier()
        {
            DataTable dt = LibQLSX.Select("select * from vSuppliers with(nolock) where SupplierCode not like 'nv%'");
            cboSupplier.Properties.DataSource = dt;
            cboSupplier.Properties.DisplayMember = "SupplierName";
            cboSupplier.Properties.ValueMember = "SupplierId";
            grvCboSupplier.BestFitColumns();
        }

        void loadData()
        {
            try
            {
                DataTable tbl = LibQLSX.Select("Select * from PayVouchers with(nolock)");
                grdData.DataSource = tbl;
            }
            catch
            {
                grdData.DataSource = null;
            }
        }

        void loadDebt()
        {
            _dtDebt = LibQLSX.Select("select * from vCaseVoucherDebt with(nolock) where CaseID = " + Case.ID);
            grdDebt.DataSource = _dtDebt;
        }

        bool ValidateForm()
        {
            if (txtCode.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền Mã.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
            {
                DataTable dt;
                if (Case.ID > 0)
                {
                    dt = TextUtils.Select("select Code from Case where Code = '" + txtCode.Text.Trim() + "' and ID <> " + Case.ID);
                }
                else
                {
                    dt = TextUtils.Select("select Code from Case where Code = '" + txtCode.Text.Trim() + "'");
                }
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Mã vụ việc này đã tồn tại!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }
                }
            }

            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền Tên.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (cboNguoiPhuTrach.EditValue == null)
            {
                MessageBox.Show("Xin hãy chọn người phụ trách.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            return true;
        }

        void save(bool close)
        {
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();

            try
            {
                if (!ValidateForm())
                    return;

                grvDebt.FocusedRowHandle = -1;

                #region Vụ việc
                Case.Name = txtName.Text.Trim().ToUpper();
                Case.Code = txtCode.Text.Trim().ToUpper();
                Case.Content = txtContent.Text.Trim();
                Case.UserId = TextUtils.ToString(cboNguoiPhuTrach.EditValue);                
                Case.Target = txtTarget.Text.Trim();
                Case.IsLocked = false;
                Case.Note = txtNote.Text.Trim();

                if (Case.ID == 0)
                {
                    Case.CreatedBy = Global.AppUserName;
                    Case.ID = (int)pt.Insert(Case);
                }
                else
                {
                    Case.UpdatedBy = Global.AppUserName;
                    pt.Update(Case);
                }
                #endregion

                #region Chứng từ vụ việc
                for (int i = 0; i < grvDebt.RowCount; i++)
                {
                    int id = TextUtils.ToInt(grvDebt.GetRowCellValue(i, colDebtID));

                    CaseVoucherDebtModel link = new CaseVoucherDebtModel();
                    if (id > 0)
                    {
                        link = (CaseVoucherDebtModel)CaseVoucherDebtBO.Instance.FindByPK(id);
                    }
                    link.PayVoucherID = TextUtils.ToInt(grvDebt.GetRowCellValue(i,colDebtVoucherID));
                    link.CaseID = Case.ID;
                    link.CompletedDateDK = TextUtils.ToDate2(grvDebt.GetRowCellValue(i, colDebtCompletedDateDK));
                    link.CompletedDate = null;

                    if (id > 0)
                    {
                        pt.Update(link); 
                    }
                    else
                    {
                        pt.Insert(link);
                    }
                }
                #endregion

                pt.CommitTransaction();
                loadDebt();

                _isSaved = true;
                if (close)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Lưu trữ thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                pt.CloseConnection();
            }

            if (_isSaved)
            {
                if (this.LoadDataChange != null)
                {
                    this.LoadDataChange(null, null);
                }
            }
        }
        #endregion

        private void cboOrder_EditValueChanged(object sender, EventArgs e)
        {
            string orderId = TextUtils.ToString(grvCboOrder.GetFocusedRowCellValue(colOrderID));
            if (orderId == "") return;

            cboUser.EditValue = null;
            cboSupplier.EditValue = null;
            cboNguoiPhuTrach.EditValue = null;

            txtCode.Text = TextUtils.ToString(grvCboOrder.GetFocusedRowCellValue(colOrderCode));
            txtName.Text = TextUtils.ToString(grvCboOrder.GetFocusedRowCellValue(colOrderSupplierName));

            DataTable dtProject = LibQLSX.Select("select * from vGetProjectWithOrder with(nolock) where OrderId = '" + orderId + "'");
            List<string> listProject = new List<string>();
            foreach (DataRow row in dtProject.Rows)
            {
                string projectCode = TextUtils.ToString(row["ProjectCode"]) == "" ? "Mua vật tư sản xuất chung" : TextUtils.ToString(row["ProjectCode"]);
                if (!listProject.Contains(projectCode))
                {
                    listProject.Add(projectCode);
                }
            }

            cboNguoiPhuTrach.EditValue = TextUtils.ToString(grvCboOrder.GetFocusedRowCellValue(colOrderUserId));
            txtTarget.Text = TextUtils.ArrayToString(" ,", listProject.ToArray());
        }

        private void cboSupplier_EditValueChanged(object sender, EventArgs e)
        {
            string supplierCode = TextUtils.ToString(grvCboSupplier.GetFocusedRowCellValue(colSupplierCode));
            if (supplierCode == "") return;

            cboUser.EditValue = null;
            //cboSupplier.EditValue = null;
            cboOrder.EditValue = null;
            cboNguoiPhuTrach.EditValue = null;

            txtCode.Text = TextUtils.ToString(grvCboSupplier.GetFocusedRowCellValue(colSupplierCode));
            txtName.Text = TextUtils.ToString(grvCboSupplier.GetFocusedRowCellValue(colSupplierName));
            txtTarget.Text = "";
        }

        private void cboUser_EditValueChanged(object sender, EventArgs e)
        {
            if (TextUtils.ToString(grvCboUser.GetFocusedRowCellValue(colUserCode)) == "") return;

            //cboUser.EditValue = null;
            cboSupplier.EditValue = null;
            cboOrder.EditValue = null;
            //cboNguoiPhuTrach.EditValue = null;

            txtCode.Text = TextUtils.ToString(grvCboUser.GetFocusedRowCellValue(colUserCode));
            txtName.Text = TextUtils.ToString(grvCboUser.GetFocusedRowCellValue(colFullName));
            txtTarget.Text = "";
            cboNguoiPhuTrach.EditValue = TextUtils.ToString(grvCboUser.GetFocusedRowCellValue(colUserID));
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            foreach (int i in grvData.GetSelectedRows())
            {
                int voucherID = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                DataRow[] drs = _dtDebt.Select("PayVoucherID = " + voucherID);
                if (drs.Length > 0)
                    continue;

                DataRow r = _dtDebt.NewRow();
                r["PayVoucherID"] = voucherID;                
                r["CompletedDateDK"] = DateTime.Now;
                r["Name"] = TextUtils.ToString(grvData.GetRowCellValue(i, colName));
                //r["CompletedDate"] = "";
                _dtDebt.Rows.Add(r);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save(false);
        }

        private void btnDeleteVoucher_Click(object sender, EventArgs e)
        {
            if (Case.IsLocked)
            {
                MessageBox.Show("Không thể xóa chứng từ do vụ việc này đã được chốt.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
            }

            int voucherID = TextUtils.ToInt(grvDebt.GetFocusedRowCellValue(colDebtID));
            if (voucherID > 0)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa chứng từ này không?",
                      TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                CaseVoucherDebtBO.Instance.Delete(voucherID);
            }
            else
            {
                grvDebt.DeleteSelectedRows();
            }
        }
    }
}
