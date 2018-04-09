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
    public partial class frmPOUpdateCost : _Forms
    {
        public OrdersModel Order = new OrdersModel();
        public delegate void LoadDataChangeHandler(object sender, EventArgs e);
        public event LoadDataChangeHandler LoadDataChange;
        public decimal TotalOrder = 0;
        public decimal TotalPrice = 0;
        DataTable _dtYC = new DataTable();
        public frmPOUpdateCost()
        {
            InitializeComponent();
        }

        private void frmPOUpdateCost_Load(object sender, EventArgs e)
        {
            this.Text += ": " + Order.OrderCode;

            txtDeliveryCost.EditValue = Order.DeliveryCost;
            txtDiffCost.EditValue = Order.DiffCost;
            //dtpPayment.EditValue = Order.PaymentDate;
            //dtpRequireDate.EditValue = Order.RequirePaymentDate;
            //cboPaymentType.SelectedIndex = Order.PaymentType;
            txtDescription.Text = Order.Description;
            txtVAT.EditValue = Order.VAT;
            txtTotalNCC.EditValue = Order.TotalNCC;
            //txtPayPercent.EditValue = Order.PayPercent;
            chkIsTranferAfterVAT.Checked = Order.IsTranferAfferVAT;

            dtpDateTTDK1.EditValue = Order.DateTTDK1;
            dtpDateTTDK2.EditValue = Order.DateTTDK2;
            dtpDateTTDK3.EditValue = Order.DateTTDK3;

            txtPrice1.EditValue = Order.Price1;
            txtPrice2.EditValue = Order.Price2;
            txtPrice3.EditValue = Order.Price3;

            loadRepo();
            loadYC();
        }

        void loadYC()
        {
            _dtYC = LibQLSX.Select("[dbo].[spGetOrderMoney] '" + Order.OrderId + "'");
            grdYC.DataSource = _dtYC;
        }

        void loadRepo()
        {
            DataTable dtPaymentType = new DataTable();
            dtPaymentType.Columns.Add("ID", typeof(int));
            dtPaymentType.Columns.Add("Name");
            dtPaymentType.Rows.Add(new object[] { 0, "Chuyển khoản" });
            dtPaymentType.Rows.Add(new object[] { 1, "Tiền mặt" });

            repositoryItemLookUpEdit1.DataSource = dtPaymentType;
            repositoryItemLookUpEdit1.DisplayMember = "Name";
            repositoryItemLookUpEdit1.ValueMember = "ID";

            DataTable dtStatus = new DataTable();
            dtStatus.Columns.Add("ID", typeof(int));
            dtStatus.Columns.Add("Name");
            dtStatus.Rows.Add(new object[] { 0, "Chưa thanh toán" });
            dtStatus.Rows.Add(new object[] { 1, "Đã có bảng kê" });
            dtStatus.Rows.Add(new object[] { 2, "Đã thanh toán" });

            repositoryItemLookUpEdit2.DataSource = dtStatus;
            repositoryItemLookUpEdit2.DisplayMember = "Name";
            repositoryItemLookUpEdit2.ValueMember = "ID";
        }

        bool validate()
        {
            if (_dtYC.Rows.Count > 0)
            {
                if (_dtYC.Select("PayPercent = 0 or PayPercent is null").Length > 0)
                {
                    MessageBox.Show("Bạn phải nhập %TT!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
                if (_dtYC.Select("RequirePaymentDate is null").Length > 0)
                {
                    MessageBox.Show("Bạn phải chọn Ngày YC thanh toán!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
                if (_dtYC.Select("PaymentType is null").Length > 0)
                {
                    MessageBox.Show("Bạn phải chọn kiểu thanh toán!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }                
            }
            
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Order.OrderId == "") return;

            grvYC.FocusedRowHandle = -1;

            if (!validate())
            {
                return;
            }

            Order.DeliveryCost = TextUtils.ToDecimal(txtDeliveryCost.EditValue);
            Order.DiffCost = TextUtils.ToDecimal(txtDiffCost.EditValue);
            Order.Description = txtDescription.Text.Trim();
            Order.VAT = TextUtils.ToDecimal1(txtVAT.EditValue);
            Order.TotalNCC = TextUtils.ToDecimal(txtTotalNCC.EditValue);
            Order.IsTranferAfferVAT = chkIsTranferAfterVAT.Checked;

            Order.DateTTDK1 = TextUtils.ToDate2(dtpDateTTDK1.EditValue);
            Order.DateTTDK2 = TextUtils.ToDate2(dtpDateTTDK2.EditValue);
            Order.DateTTDK3 = TextUtils.ToDate2(dtpDateTTDK3.EditValue);

            Order.Price1 = TextUtils.ToDecimal1(txtPrice1.EditValue);
            Order.Price2 = TextUtils.ToDecimal1(txtPrice2.EditValue);
            Order.Price3 = TextUtils.ToDecimal1(txtPrice3.EditValue);

            OrdersBO.Instance.UpdateQLSX(Order);

            for (int i = 0; i < grvYC.RowCount; i++)
            {
                int status = TextUtils.ToInt(grvYC.GetFocusedRowCellValue(colStatus));
                if (status > 0) continue;

                int id = TextUtils.ToInt(grvYC.GetRowCellValue(i, colID));
                OrderRequirePaidModel model = new OrderRequirePaidModel();
                if (id > 0)
                {
                    model = (OrderRequirePaidModel)OrderRequirePaidBO.Instance.FindByPK(id);
                }

                model.OrderId = Order.OrderId;
                model.PayPercent = TextUtils.ToDecimal(grvYC.GetRowCellValue(i, colPayPercent));
                model.RequirePaymentDate = TextUtils.ToDate2(grvYC.GetRowCellValue(i, colRequirePaymentDate));
                model.TotalPay = TextUtils.ToDecimal(grvYC.GetRowCellValue(i, colTotalYC));
                model.PaymentType = TextUtils.ToInt1(grvYC.GetRowCellValue(i, colPaymentType));
                model.Status = TextUtils.ToInt(grvYC.GetRowCellValue(i, colStatus));

                if (id > 0)
                {
                    OrderRequirePaidBO.Instance.Update(model);
                }
                else
                {
                    OrderRequirePaidBO.Instance.Insert(model);
                }
            }
            loadYC();

            MessageBox.Show("Lưu trữ thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (this.LoadDataChange != null)
            {
                this.LoadDataChange(null, null);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (grvYC.SelectedRowsCount > 0)
            {
                int id = TextUtils.ToInt(grvYC.GetFocusedRowCellValue(colID));
                int status = TextUtils.ToInt(grvYC.GetFocusedRowCellValue(colStatus));
                if (status > 0) return;
                
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa yêu cầu thanh toán này không?",
                    TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (id > 0)
                        OrderRequirePaidBO.Instance.Delete(id);
                    grvYC.DeleteSelectedRows();                    
                }
            }
        }

        private void grvYC_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colPayPercent)
            {
                decimal totalYC = 0;
                if (chkIsTranferAfterVAT.Checked)
                {
                    decimal total = ((TotalPrice + Order.DiffCost) + (TotalPrice + Order.DiffCost) * Order.VAT / 100) + Order.DeliveryCost;
                    totalYC = TextUtils.ToDecimal(grvYC.GetFocusedRowCellValue(colPayPercent)) * total / 100;
                }
                else
                {
                    totalYC = TextUtils.ToDecimal(grvYC.GetFocusedRowCellValue(colPayPercent)) * TotalOrder / 100;
                }
                
                grvYC.SetFocusedRowCellValue(colTotalYC, totalYC);
                grvYC.SetFocusedRowCellValue(colPaymentType, 0);
            }
        }        
    }
}
