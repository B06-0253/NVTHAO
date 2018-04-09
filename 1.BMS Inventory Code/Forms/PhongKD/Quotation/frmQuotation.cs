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
    public partial class frmQuotation : _Forms
    {
        #region Variables
        public C_QuotationModel CurrentQuotation = new C_QuotationModel();
        public int CatID = 0;
        bool _isSaved = false;

        public delegate void LoadDataChangeHandler(object sender, EventArgs e);
        public event LoadDataChangeHandler LoadDataChange;

        #endregion
        public frmQuotation()
        {
            InitializeComponent();
        }

        private void frmQuotation_Load(object sender, EventArgs e)
        {
            btnReload.Enabled = btnSave.Enabled = btnSaveAndClose.Enabled = !CurrentQuotation.IsApproved;
            loadDepartment();
            loadCustomer();
            loadProject();

            if (CurrentQuotation.ID > 0)
            {
                txtCode.Text = CurrentQuotation.Code;
                txtCustomerCode.Text = CurrentQuotation.CustomerCode;
                txtCustomerName.Text = CurrentQuotation.CustomerName;
                txtDeliveryTime.EditValue = CurrentQuotation.DeliveryTime;
                txtDepartmentName.Text = CurrentQuotation.DepartmentName;
                txtFinishCustomerCode.Text = CurrentQuotation.CustomerCodeF;
                txtFinishCustomerName.Text = CurrentQuotation.CustomerNameF;
                txtPOnumber.Text = CurrentQuotation.POnumber;
                txtProjectCode.Text = CurrentQuotation.ProjectCode;
                txtProjectName.Text = CurrentQuotation.ProjectName;
                txtTax.EditValue = CurrentQuotation.Tax;
                txtTotalBX.EditValue = CurrentQuotation.TotalBX;
                txtTotalCustomer.EditValue = CurrentQuotation.TotalCustomer;
                txtTotalHD.EditValue = CurrentQuotation.TotalHD;
                txtTotalNC.EditValue = CurrentQuotation.TotalNC;
                txtTotalPB.EditValue = CurrentQuotation.TotalPB;
                txtTotalProfit.EditValue = CurrentQuotation.TotalProfit;
                txtTotalReal.EditValue = CurrentQuotation.TotalReal;
                txtTotalTPA.EditValue = CurrentQuotation.TotalTPA;

                cboStatus.SelectedIndex = CurrentQuotation.Status;
                cboDepartment.SelectedValue = CurrentQuotation.DepartmentId;
                cboIsVAT.SelectedIndex = CurrentQuotation.IsVAT;

                //chkIsCustomerVAT.Checked = CurrentQuotation.IsCustomerVAT;
                txtCustomerPercent.EditValue = CurrentQuotation.CustomerPercent;
                txtCustomerCash.EditValue = CurrentQuotation.CustomerCash;
            }
            loadCost();
        }

        void loadCost()
        {
            DataTable dtLink = new DataTable();
            //if (CurrentQuotation.ID > 0)
            //{
            dtLink = LibQLSX.Select("select *, Price1 = (case when C_CostID in (50,12,77,78,79) then Total/dbo.IsZero(Qty,1) else Price end) from vC_CostQuotationLink where C_QuotationID = " + CurrentQuotation.ID);
            //}
            //else
            //{
            //    dtLink = LibQLSX.Select("select * from C_Cost where IsWithProject = 1 or CostType = 1");
            //} 
            grdLink.DataSource = dtLink;
        }

        void loadDepartment()
        {
            DataTable dt = LibQLSX.Select("select * from C_Cost where id in (72,73)");
            cboDepartment.DataSource = dt;
            cboDepartment.DisplayMember = "Name";
            cboDepartment.ValueMember = "ID";
        }

        void loadCustomer()
        {
            DataTable dt = LibQLSX.Select("select CustomerCode,CustomerName from Customers");
            cboCustomer.Properties.DataSource = dt;
            cboCustomer.Properties.DisplayMember = "CustomerCode";
            cboCustomer.Properties.ValueMember = "CustomerCode";
        }

        void loadProject()
        {
            DataTable dt = LibQLSX.Select("select [ProjectName],[ProjectCode] from Project");
            cboProject.Properties.DataSource = dt;
            cboProject.Properties.DisplayMember = "ProjectCode";
            cboProject.Properties.ValueMember = "ProjectCode";
        }

        private bool ValidateForm()
        {
            txtCode.Text = txtCode.Text.Trim().ToUpper().Replace(" ", "");

            if (txtCode.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền Mã.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
            {
                DataTable dt;
                if (CurrentQuotation.ID > 0)
                {
                    dt = TextUtils.Select("select Code from C_Quotation where upper(Replace(Code,' ','')) = '"
                        + txtCode.Text.Trim().ToUpper() + "' and ID <> " + CurrentQuotation.ID);
                }
                else
                {
                    dt = TextUtils.Select("select Code from C_Quotation where upper(Replace(Code,' ','')) = '"
                        + txtCode.Text.Trim().ToUpper() + "'");
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

            //if (txtName.Text.Trim() == "")
            //{
            //    MessageBox.Show("Xin hãy điền Tên.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return false;
            //}

            //if (TextUtils.ToInt(leParentCat.EditValue) == 0)
            //{
            //    MessageBox.Show("Xin hãy chọn một nhóm!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return false;
            //}

            if (cboStatus.SelectedIndex < 1)
            {
                MessageBox.Show("Xin hãy chọn một trạng thái!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (cboIsVAT.SelectedIndex < 1)
            {
                MessageBox.Show("Xin hãy chọn một tình trạng VAT!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (cboDepartment.SelectedIndex == -1)
            {
                MessageBox.Show("Xin hãy chọn một phòng phụ trách báo giá!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (TextUtils.ToDecimal(txtDeliveryTime.EditValue) <= 0)
            {
                MessageBox.Show("Xin hãy thêm ngày giao hàng!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return true;
        }

        void save()
        {
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();
            try
            {
                if (!ValidateForm())
                    return;

                grvLink.FocusedRowHandle = -1;

                CurrentQuotation.Code = txtCode.Text.Trim();
                CurrentQuotation.CustomerCode = txtCustomerCode.Text.Trim();
                CurrentQuotation.CustomerName = txtCustomerName.Text.Trim();
                CurrentQuotation.DeliveryTime = TextUtils.ToDecimal(txtDeliveryTime.EditValue);
                CurrentQuotation.DepartmentName = txtDepartmentName.Text.Trim();
                CurrentQuotation.CustomerCodeF = txtFinishCustomerCode.Text.Trim();
                CurrentQuotation.CustomerNameF = txtFinishCustomerName.Text.Trim();
                CurrentQuotation.POnumber = txtPOnumber.Text.Trim();
                CurrentQuotation.ProjectCode = txtProjectCode.Text.Trim();
                CurrentQuotation.ProjectName = txtProjectName.Text.Trim();
                CurrentQuotation.Tax = TextUtils.ToDecimal(txtTax.EditValue);

                CurrentQuotation.TotalCustomer = TextUtils.ToDecimal(colTotal.SummaryItem.SummaryValue);

                //CurrentQuotation.TotalBX = TextUtils.ToDecimal(txtTotalBX.EditValue);                
                //CurrentQuotation.TotalHD = TextUtils.ToDecimal(txtTotalHD.EditValue);
                //CurrentQuotation.TotalNC = TextUtils.ToDecimal(txtTotalNC.EditValue);
                //CurrentQuotation.TotalPB = TextUtils.ToDecimal(txtTotalPB.EditValue);
                //CurrentQuotation.TotalProfit = TextUtils.ToDecimal(txtTotalProfit.EditValue);
                //CurrentQuotation.TotalReal = TextUtils.ToDecimal(txtTotalReal.EditValue);
                //CurrentQuotation.TotalTPA = TextUtils.ToDecimal(txtTotalTPA.EditValue);
                //CurrentQuotation.TotalVT = TextUtils.ToDecimal(txtTotalVT.EditValue);

                CurrentQuotation.Status = cboStatus.SelectedIndex;
                CurrentQuotation.DepartmentId = TextUtils.ToInt(cboDepartment.SelectedValue);

                CurrentQuotation.CustomerPercent = TextUtils.ToDecimal(txtCustomerPercent.EditValue);
                CurrentQuotation.CustomerCash = TextUtils.ToDecimal(txtCustomerCash.EditValue);
                //CurrentQuotation.IsCustomerVAT = chkIsCustomerVAT.Checked;
                CurrentQuotation.IsVAT = cboIsVAT.SelectedIndex;

                CurrentQuotation.UpdatedDate = DateTime.Now;
                CurrentQuotation.UpdatedBy = Global.AppUserName;
                if (CurrentQuotation.ID <= 0)
                {
                    CurrentQuotation.CreatedDate = DateTime.Now;
                    CurrentQuotation.CreatedBy = Global.AppUserName;
                    CurrentQuotation.ID = (int)pt.Insert(CurrentQuotation);                    
                }
                else
                {
                    pt.Update(CurrentQuotation);                    
                }
                if (grvLink.RowCount > 0)
                {
                    for (int i = 0; i < grvLink.RowCount; i++)
                    {
                        int id = TextUtils.ToInt(grvLink.GetRowCellValue(i, colID));
                        C_CostQuotationLinkModel link = (C_CostQuotationLinkModel)C_CostQuotationLinkBO.Instance.FindByPK(id);
                        link.Qty = TextUtils.ToDecimal(grvLink.GetRowCellValue(i, colQty));
                        link.Price = TextUtils.ToDecimal(grvLink.GetRowCellValue(i, colPrice));
                        link.Total = link.Qty * link.Price;
                        pt.Update(link);
                    }
                }
                else
                {
                    DataTable dtLink = LibQLSX.Select("select * from C_Cost where IsWithProject = 1");
                    //DataTable dtLink = LibQLSX.Select("select * from C_Cost where IsWithProject = 1 or CostType = 1");
                    foreach (DataRow row in dtLink.Rows)
                    {
                        C_CostQuotationLinkModel link = new C_CostQuotationLinkModel();
                        link.C_CostID = TextUtils.ToInt(row["ID"]);
                        link.C_QuotationID = CurrentQuotation.ID;
                        link.Price = TextUtils.ToDecimal(row["Price"]);
                        link.Qty = 0;
                        link.Total = link.Qty * link.Price;
                        pt.Insert(link);
                    }
                }

                pt.CommitTransaction();
                _isSaved = true;
                loadCost();
                MessageBox.Show("Lưu trữ thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            if (_isSaved)
            {
                if (this.LoadDataChange != null)
                {
                    this.LoadDataChange(null, null);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save();
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            save();
            if (_isSaved) this.Close();
        }

        private void cboCustomer_EditValueChanged(object sender, EventArgs e)
        {
            txtCustomerCode.Text = TextUtils.ToString(grvCboCustomer.GetFocusedRowCellValue(colCustomerCode));
            txtCustomerName.Text = TextUtils.ToString(grvCboCustomer.GetFocusedRowCellValue(colCustomerName));
        }

        private void cboProject_EditValueChanged(object sender, EventArgs e)
        {
            txtProjectCode.Text = TextUtils.ToString(grvCboProject.GetFocusedRowCellValue(colProjectCode));
            txtProjectName.Text = TextUtils.ToString(grvCboProject.GetFocusedRowCellValue(colProjectName));
        }

        private void grvLink_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colQty || e.Column == colPrice)
            {
                decimal qty = TextUtils.ToDecimal(grvLink.GetFocusedRowCellValue(colQty));
                decimal price = TextUtils.ToDecimal(grvLink.GetFocusedRowCellValue(colPrice));
                grvLink.SetFocusedRowCellValue(colTotal, qty * price);
            }
        }

        private void repositoryItemTextEdit1_Spin(object sender, DevExpress.XtraEditors.Controls.SpinEventArgs e)
        {
            e.Handled = true;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            if (CurrentQuotation.ID == 0) return;
            C_CostQuotationLinkBO.Instance.DeleteByAttribute("C_QuotationID", CurrentQuotation.ID);
            //DataTable dtLink = LibQLSX.Select("select * from C_Cost where IsWithProject = 1 or CostType = 1");
            DataTable dtLink = LibQLSX.Select("select * from C_Cost where IsWithProject = 1 or CostType = 1");
            foreach (DataRow row in dtLink.Rows)
            {
                C_CostQuotationLinkModel link = new C_CostQuotationLinkModel();
                link.C_CostID = TextUtils.ToInt(row["ID"]);
                link.C_QuotationID = CurrentQuotation.ID;
                link.Price = TextUtils.ToDecimal(row["Price"]);
                link.Qty = 0;
                link.Total = link.Qty * link.Price;
                C_CostQuotationLinkBO.Instance.Insert(link);
            }
            loadCost();
        }

        private void btnExeclGroup_Click(object sender, EventArgs e)
        {
            TextUtils.ExportExcel(grvLink);
        }
    }
}
