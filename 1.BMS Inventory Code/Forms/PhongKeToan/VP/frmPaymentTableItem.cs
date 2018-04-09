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
using System.Collections;

namespace BMS
{
    public partial class frmPaymentTableItem : _Forms
    {
        bool _isSaved = false;
        public delegate void LoadDataChangeHandler(object sender, EventArgs e);
        public event LoadDataChangeHandler LoadDataChange;
        DataTable _dtItem = new DataTable();
        public PaymentTableModel PaymentTable = new PaymentTableModel();

        int _type = -1;

        public frmPaymentTableItem()
        {
            InitializeComponent();
        }

        private void frmPaymentTableItem_Load(object sender, EventArgs e)
        {
            loadOrder();
            loadSupplier();
            loadUser();          

            loadNumber();
            loadItems();

            loadSearchLookUpEdit();

            chkTM.Checked = true;
        }

        void loadSearchLookUpEdit()
        {
            DataTable dt1 = LibQLSX.Select("Select * from [Project] WITH(NOLOCK)");
            repositoryItemSearchLookUpEdit1.DataSource = dt1;
            repositoryItemSearchLookUpEdit1.DisplayMember = "ProjectCode";
            repositoryItemSearchLookUpEdit1.ValueMember = "ProjectId";

            DataTable dt2 = LibQLSX.Select("Select * from [C_Cost] WITH(NOLOCK)");
            repositoryItemSearchLookUpEdit2.DataSource = dt2;
            repositoryItemSearchLookUpEdit2.DisplayMember = "Code";
            repositoryItemSearchLookUpEdit2.ValueMember = "ID";

            DataTable dt3 = LibQLSX.Select("Select * from [Company] WITH(NOLOCK)");
            repositoryItemSearchLookUpEdit3.DataSource = dt3;
            repositoryItemSearchLookUpEdit3.DisplayMember = "Code";
            repositoryItemSearchLookUpEdit3.ValueMember = "ID";

            DataTable dt4 = LibQLSX.Select("Select * from [Departments] WITH(NOLOCK) where ICode is not null order by ICode");
            repositoryItemSearchLookUpEdit4.DataSource = dt4;
            repositoryItemSearchLookUpEdit4.DisplayMember = "ICode";
            repositoryItemSearchLookUpEdit4.ValueMember = "DepartmentId";

            DataTable dt5 = new DataTable();
            dt5.Columns.Add("ID", typeof(int));
            dt5.Columns.Add("Name");
            dt5.Rows.Add(new Object[] { 0, "Có HĐ" });
            dt5.Rows.Add(new Object[] { 1, "Đã ghi nợ" });
            dt5.Rows.Add(new Object[] { 2, "Chưa có" });

            repositoryItemSearchLookUpEdit5.DataSource = dt5;
            repositoryItemSearchLookUpEdit5.DisplayMember = "Name";
            repositoryItemSearchLookUpEdit5.ValueMember = "ID";

            repositoryItemSearchLookUpEdit6.DataSource = dt5;
            repositoryItemSearchLookUpEdit6.DisplayMember = "Name";
            repositoryItemSearchLookUpEdit6.ValueMember = "ID";
        }

        void loadOrder()
        {
            DataTable dt = LibQLSX.Select("Select * from [vOrder] WITH(NOLOCK)");
            cboOrder.Properties.DataSource = dt;
            cboOrder.Properties.DisplayMember = "SupplierName";
            cboOrder.Properties.ValueMember = "OrderId";
            grvCboOrder.BestFitColumns();
        }

        void loadUser()
        {
            //string filePath = Application.StartupPath + "\\Templates\\MNV.xlsx";

            DataTable dt = new DataTable();
            //dt = TextUtils.ExcelToDatatableNoHeader(filePath, "Sheet1");
            dt = LibQLSX.Select("Select * from [vUser] WITH(NOLOCK)");

            cboUser.Properties.DataSource = dt;
            cboUser.Properties.DisplayMember = "UserName";
            cboUser.Properties.ValueMember = "UserId";
            grvCboUser.BestFitColumns();

            repositoryItemGridLookUpEdit1.DataSource = dt;
            repositoryItemGridLookUpEdit1.DisplayMember = "UserName";
            repositoryItemGridLookUpEdit1.ValueMember = "UserId";

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

        void calculateCost()
        {
            if (chkTM.Checked)
            {
                txtTM.EditValue = TextUtils.ToDecimal(txtPercentPay.EditValue) * TextUtils.ToDecimal(txtTotal.EditValue)/100;
                txtCK.EditValue = 0;
            }
            else
            {
                txtCK.EditValue = TextUtils.ToDecimal(txtPercentPay.EditValue) * TextUtils.ToDecimal(txtTotal.EditValue)/100;
                txtTM.EditValue = 0;
            }

            //decimal diff = TextUtils.ToDecimal(txtTotal.EditValue) - (TextUtils.ToDecimal(txtTM.EditValue) 
            //    + TextUtils.ToDecimal(txtCK.EditValue) + TextUtils.ToDecimal(txtTotalTransfer.EditValue));

            //if (diff > 0)
            //{
            //    txtContent.Text = "Thanh toán " + txtPercentPay.Text + "% tiền hàng";
            //}
            //else
            //{
            //    txtContent.Text = "Thanh toán nốt tiền hàng";
            //}
        }
        
        void loadItems()
        {
            _dtItem = LibQLSX.Select("select * from vPaymentTableItem with(nolock) where PaymentTableID = " + PaymentTable.ID);
            grdData.DataSource = _dtItem;
        }

        void loadNumber()
        {
            if (PaymentTable.ID == 0)
            {
                string current = "BKTT." + DateTime.Now.ToString("ddMMyy");
                DataTable dt = LibQLSX.Select("select * from PaymentTable with(nolock) where Number like '%" + current + "%' order by ID desc");
                if (dt.Rows.Count > 0)
                {
                    string number = TextUtils.ToString(dt.Rows[0]["Number"]);
                    int index = TextUtils.ToInt(number.Split('.')[2]);
                    txtNumber.Text = current + "." + string.Format("{0:00}", index + 1);
                }
                else
                {
                    txtNumber.Text = current + ".01";
                }
            }
            else
            {
                txtNumber.Text = PaymentTable.Number;
            }
        }

        DataTable loadPartOfOrder(string orderCode)
        {
            string[] paraName = new string[1];
            object[] paraValue = new object[1];
            paraName[0] = "@OrderCode"; paraValue[0] = orderCode;
            DataTable Source = SuppliersBO.Instance.LoadDataFromSP("spGetPartWithOrder_New060318", "Source", paraName, paraValue);
            //DataTable dt = Source.Copy();
            //dt.Rows.Clear();
            //foreach (DataRow row in Source.Rows)
            //{
            //    string code = TextUtils.ToString(row["PartsCode"]);
            //    decimal price = TextUtils.ToDecimal(row["Price"]);
            //    decimal qty = TextUtils.ToDecimal(row["TotalBuy"]);

            //    DataRow[] drs = dt.Select("PartsCode = '" + code + "' and Price = " + price);
            //    if (drs.Length == 0)
            //    {
            //        dt.ImportRow(row);
            //    }
            //    else
            //    {
            //        drs[0]["TotalBuy"] = TextUtils.ToDecimal(drs[0]["TotalBuy"]) + qty;
            //        drs[0]["TotalPrice"] = TextUtils.ToDecimal(drs[0]["TotalBuy"]) * TextUtils.ToDecimal(drs[0]["Price"]);
            //    }
            //}
            return Source;
        }

        private int _countProject = 0;
        private void cboOrder_EditValueChanged(object sender, EventArgs e)
        {            
            string orderId = TextUtils.ToString(grvCboOrder.GetFocusedRowCellValue(colOrderID));
            if (orderId == "") return;

            _type = 0;
            _countProject = 0;

            cboUser.EditValue = null;
            cboSupplier.EditValue = null;
            cboNguoiPhuTrach.EditValue = null;

            txtCode.Text = TextUtils.ToString(grvCboOrder.GetFocusedRowCellValue(colOrderCode));
            txtName.Text = TextUtils.ToString(grvCboOrder.GetFocusedRowCellValue(colOrderSupplierName));

            DataTable dtPrice = loadPartOfOrder(txtCode.Text);

            decimal totalTransfer = TextUtils.ToDecimal(LibIE.ExcuteScalar("SELECT * FROM V_XNTC_VUVIEC WHERE (C_MA = '"
                + txtCode.Text.Trim() + "') AND (FK_TKCO LIKE '111%' OR FK_TKCO LIKE '112%') AND (FK_TKNO LIKE '331%') and C_KHACHHANG_MA = '" 
                + TextUtils.ToString(grvCboOrder.GetFocusedRowCellValue(colOrderSupplierCode)) + "'"));

            decimal totalPrice = TextUtils.ToDecimal(dtPrice.Compute("Sum(TotalPrice)", ""));

            txtTotalTH.EditValue = totalPrice;
            txtDiffCost.EditValue = TextUtils.ToDecimal(grvCboOrder.GetFocusedRowCellValue(colOrderDiffCost));

            //Tính lại công thức lấy tổng tiền PO = tiền hàng + vat + chi phí vận chuyển 10/03/2018
            decimal deliveryNew = TextUtils.ToDecimal(
                    LibQLSX.ExcuteScalar("select isnull(sum(isnull(Amount,0) ),0) FROM [dbo].vTransport where [OrderId]='" + orderId + "'")
                );
            txtDeliveryCost.EditValue = deliveryNew;

            txtVAT.EditValue = TextUtils.ToDecimal(grvCboOrder.GetFocusedRowCellValue(colOrderVAT));
            decimal total = (TextUtils.ToDecimal(txtTotalTH.EditValue) + TextUtils.ToDecimal(txtDiffCost.EditValue) + TextUtils.ToDecimal(txtDeliveryCost.EditValue));
            total = total + (TextUtils.ToDecimal(txtVAT.EditValue) * total / 100);
            txtTotal.EditValue = total;
            
            txtTotalTransfer.EditValue = totalTransfer;
            txtTotalRest.EditValue = TextUtils.ToDecimal(txtTotal.EditValue) - TextUtils.ToDecimal(txtTotalTransfer.EditValue);

            txtPercentPay.Text = "100";
            chkTM.Checked = true;

            txtTM.EditValue = TextUtils.ToDecimal(txtTotal.EditValue) * TextUtils.ToDecimal(txtPercentPay.EditValue) / 100;
            txtCK.EditValue = 0;

            DataTable dtProject = LibQLSX.Select("select * from vGetProjectWithOrder with(nolock) where OrderId = '" + orderId + "'");
            List<string> listProject = new List<string>();
            foreach (DataRow row in dtProject.Rows)
            {
                string projectCode = TextUtils.ToString(row["ProjectCode"]) == "" ? "Mua vật tư sản xuất chung" : TextUtils.ToString(row["ProjectCode"]);
                if (!listProject.Contains(projectCode))
                {
                    listProject.Add(projectCode);
                    _countProject++;
                }
            }

            cboNguoiPhuTrach.EditValue = TextUtils.ToString(grvCboOrder.GetFocusedRowCellValue(colOrderUserId));
            txtTarget.Text = TextUtils.ArrayToString(" ,", listProject.ToArray());            
        }

        private void cboSupplier_EditValueChanged(object sender, EventArgs e)
        {
            string supplierCode = TextUtils.ToString(grvCboSupplier.GetFocusedRowCellValue(colSupplierCode));
            if (supplierCode == "") return;

            _type = 1;

            cboUser.EditValue = null;
            //cboSupplier.EditValue = null;
            cboOrder.EditValue = null;
            cboNguoiPhuTrach.EditValue = null;

            txtCode.Text = TextUtils.ToString(grvCboSupplier.GetFocusedRowCellValue(colSupplierCode));
            txtName.Text = TextUtils.ToString(grvCboSupplier.GetFocusedRowCellValue(colSupplierName));
            txtTotalTH.EditValue = 0;
            txtDiffCost.EditValue = 0;
            txtDeliveryCost.EditValue = 0;
            txtTotal.EditValue = 0;
            txtPercentPay.Text = "100";
            chkTM.Checked = true;
            txtTM.EditValue = TextUtils.ToDecimal(txtTotal.EditValue) * TextUtils.ToDecimal(txtPercentPay.EditValue) / 100;
            txtCK.EditValue = 0;
            txtTarget.Text = "";
            txtTotalTransfer.EditValue = 0;
        }

        private void cboUser_EditValueChanged(object sender, EventArgs e)
        {
            if (TextUtils.ToString(grvCboUser.GetFocusedRowCellValue(colUserCode)) == "") return;

            _type = 2;

            //cboUser.EditValue = null;
            cboSupplier.EditValue = null;
            cboOrder.EditValue = null;
            //cboNguoiPhuTrach.EditValue = null;

            txtCode.Text = TextUtils.ToString(grvCboUser.GetFocusedRowCellValue(colUserCode));
            txtName.Text = TextUtils.ToString(grvCboUser.GetFocusedRowCellValue(colFullName));
            txtTotalTH.EditValue = 0;
            txtDiffCost.EditValue = 0;
            txtDeliveryCost.EditValue = 0;
            txtTotal.EditValue = 0;
            txtPercentPay.Text = "100";
            chkTM.Checked = true;
            txtTM.EditValue = TextUtils.ToDecimal(txtTotal.EditValue) * TextUtils.ToDecimal(txtPercentPay.EditValue) / 100;
            txtCK.EditValue = 0;
            txtTarget.Text = "";
            txtTotalTransfer.EditValue = 0;
            cboNguoiPhuTrach.EditValue = TextUtils.ToString(grvCboUser.GetFocusedRowCellValue(colUserID));
        }
        
        private void txtPercentPay_EditValueChanged(object sender, EventArgs e)
        {
            calculateCost();
        }

        private void chkTM_CheckedChanged(object sender, EventArgs e)
        {
            calculateCost();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtCode.Text.Trim() == "")
            {
                MessageBox.Show("Mã vụ việc không được để trống!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Tên vụ việc không được để trống!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (cboNguoiPhuTrach.EditValue == null)
            {
                MessageBox.Show("Người phụ trách không được để trống!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (TextUtils.ToDecimal(txtVAT.EditValue)<0)
            {
                MessageBox.Show("VAT không không hợp lệ, Vật tư chưa điền VAT!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (_type == 0)
            {
                DataRow[] drs = _dtItem.Select("Code = '" + txtCode.Text.Trim() + "'");
                if (drs.Length > 0)
                {
                    MessageBox.Show("Mã vụ việc này đã tồn tại trong danh sách!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                decimal totalTransfer = TextUtils.ToDecimal(txtTotalTransfer.EditValue);
                decimal total = (TextUtils.ToDecimal(txtTotalTH.EditValue) + TextUtils.ToDecimal(txtDiffCost.EditValue) + TextUtils.ToDecimal(txtDeliveryCost.EditValue));
                total = total + (TextUtils.ToDecimal(txtVAT.EditValue) * total / 100);
                if (totalTransfer >= total)
                {
                    MessageBox.Show("Vụ việc này đã được thanh toán!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }

            DataRow row = _dtItem.NewRow();
            row["ID"] = 0;
            row["PaymentTableID"] = 0;
            row["Code"] = txtCode.Text.Trim();
            row["Name"] = txtName.Text.Trim();
            row["Content"] = txtContent.Text.Trim();
            row["Target"] = txtTarget.Text.Trim();
            row["IsCash"] = chkTM.Checked;
            row["PercentPay"] = TextUtils.ToDecimal(txtPercentPay.EditValue);
            row["Total"] = TextUtils.ToDecimal(txtTotal.EditValue);
            row["TotalTH"] = TextUtils.ToDecimal(txtTotalTH.EditValue);
            row["DeliveryCost"] = TextUtils.ToDecimal(txtDeliveryCost.EditValue);
            row["DiffCost"] = TextUtils.ToDecimal(txtDiffCost.EditValue);
            row["TotalCash"] = TextUtils.ToDecimal(txtTM.EditValue);
            row["TotalCK"] = TextUtils.ToDecimal(txtCK.EditValue);
            row["ContentCheck"] = "";
            row["Note"] = "";
            row["UserId"] = TextUtils.ToString(cboNguoiPhuTrach.EditValue);
            row["CountProject"] = _countProject;
            row["VAT"] = TextUtils.ToDecimal(txtVAT.EditValue);
            _dtItem.Rows.Add(row);
        }

        bool ValidateForm()
        {
            if (PaymentTable.ID == 0)
            {
                DataTable dt = LibQLSX.Select("select top 1 * from PaymentTable with(nolock) where Number = '" + txtNumber.Text.Trim() + "'");
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Bảng kê thanh toán này đã tồn tại!", TextUtils.Caption,MessageBoxButtons.OK,MessageBoxIcon.Stop);
                    return false;
                }
            }
            
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();
            try
            {
                if (!ValidateForm())
                    return;
                grvData.FocusedRowHandle = -1;

                PaymentTable.IsDeleted = false;
                PaymentTable.Note = "";
                PaymentTable.Number = txtNumber.Text.Trim();
                PaymentTable.TotalTM = TextUtils.ToDecimal(colTM.SummaryItem.SummaryValue);
                PaymentTable.TotalCK = TextUtils.ToDecimal(colCK.SummaryItem.SummaryValue);
                PaymentTable.UpdatedBy = Global.AppUserName;
                PaymentTable.UpdatedDate = DateTime.Now;

                if (PaymentTable.ID == 0)
                {
                    PaymentTable.CreatedBy = Global.AppUserName;
                    PaymentTable.CreatedDate = DateTime.Now;                    
                    PaymentTable.ID = (long)pt.Insert(PaymentTable);
                }
                else
                {
                    pt.Update(PaymentTable);
                }

                for (int i = 0; i < grvData.RowCount; i++)
                {
                    string code = TextUtils.ToString(grvData.GetRowCellValue(i, colCode));
                    if (code == "") continue;

                    long id = TextUtils.ToInt64(grvData.GetRowCellValue(i,colID));
                    PaymentTableItemModel item = new PaymentTableItemModel();
                    if (id > 0)
                    {
                        item = (PaymentTableItemModel)PaymentTableItemBO.Instance.FindByPK(id);
                    }
                    item.Code = code;
                    item.Content = TextUtils.ToString(grvData.GetRowCellValue(i, colContent));
                    item.ContentCheck = TextUtils.ToString(grvData.GetRowCellValue(i, colContentCheck));
                    item.Target = TextUtils.ToString(grvData.GetRowCellValue(i, colTarget));
                    item.Name = TextUtils.ToString(grvData.GetRowCellValue(i, colName));
                    item.Note = TextUtils.ToString(grvData.GetRowCellValue(i, colNote));

                    item.PaymentTableID = PaymentTable.ID;

                    item.IsCash = TextUtils.ToBoolean(grvData.GetRowCellValue(i, colIsTM));

                    item.Total = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colTotal));
                    item.TotalTH = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colTotalTH));
                    item.DeliveryCost = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colDeliveryCost));
                    item.DiffCost = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colDiffCost));
                    
                    item.PercentPay = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colPercentPay));
                    item.TotalCash = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colTM));
                    item.TotalCK = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colCK));

                    item.UserId = TextUtils.ToString(grvData.GetRowCellValue(i, colOrderUserId));

                    item.CompanyID = TextUtils.ToInt(grvData.GetRowCellValue(i, colCompany));
                    item.DepartmentId = TextUtils.ToString(grvData.GetRowCellValue(i, colDepartment));
                    item.ProjectId = TextUtils.ToString(grvData.GetRowCellValue(i, colProject));
                    item.CostID = TextUtils.ToInt(grvData.GetRowCellValue(i, colCost));
                    item.CountProject = TextUtils.ToInt(grvData.GetRowCellValue(i, colCountProject));
                    item.VAT = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colVAT));

                    item.ContractStatus = TextUtils.ToInt1(grvData.GetRowCellValue(i, colContractStatus));
                    item.InvoiceStatus = TextUtils.ToInt1(grvData.GetRowCellValue(i, colInvoiceStatus));
                    item.IsPO = TextUtils.ToBoolean(grvData.GetRowCellValue(i, colIsPO));
                    item.IsCongNo = TextUtils.ToBoolean(grvData.GetRowCellValue(i, colIsCongNo));
                    item.IsCuongVe = TextUtils.ToBoolean(grvData.GetRowCellValue(i, colIsCuongVe));
                    item.IsGDD = TextUtils.ToBoolean(grvData.GetRowCellValue(i, colIsGĐĐ));
                    item.IsTTGH = TextUtils.ToBoolean(grvData.GetRowCellValue(i, colIsTTGH));
                    item.IsVV_DA_NCC = TextUtils.ToBoolean(grvData.GetRowCellValue(i, colIsVV_DA_NCC));

                    if (id > 0)
                    {
                        pt.Update(item);
                    }
                    else
                    {
                        pt.Insert(item);
                    }

                    ArrayList listOrder = OrdersBO.Instance.FindByAttribute("OrderCode", item.Code);
                    if (listOrder.Count > 0)
                    {
                        OrdersModel order = (OrdersModel)listOrder[0];
                        order.StatusTT = 2;
                        pt.UpdateQLSX(order);
                    }
                }

                pt.CommitTransaction();
                loadItems();
                _isSaved = true;
                MessageBox.Show("Lưu trữ thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information); 
                if (this.LoadDataChange != null)
                {
                    this.LoadDataChange(null, null);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lưu trữ không thành công!" + Environment.NewLine + ex.Message, TextUtils.Caption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                pt.CloseConnection(); 
            }
        }

        private void txtTotal_EditValueChanged(object sender, EventArgs e)
        {
            calculateCost();
        }

        private void grvData_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            bool isTM = TextUtils.ToBoolean(grvData.GetFocusedRowCellValue(colIsTM));
            decimal total = TextUtils.ToDecimal(grvData.GetFocusedRowCellValue(colTotal));
            decimal percent = TextUtils.ToDecimal(grvData.GetFocusedRowCellValue(colPercentPay));
            int handle = e.RowHandle;
            if (e.Column == colPercentPay || e.Column == colTotal || e.Column == colIsTM)
            {
                decimal value = 0;
                if (total > 0)
                {
                    value = percent * total / 100;
                    if (isTM)
                    {
                        grvData.SetFocusedRowCellValue(colTM, percent * total / 100);
                        grvData.SetFocusedRowCellValue(colCK, 0);
                    }
                    else
                    {
                        grvData.SetFocusedRowCellValue(colCK, percent * total / 100);
                        grvData.SetFocusedRowCellValue(colTM, 0);
                    }
                }
                else
                {
                    if (isTM)
                    {
                        grvData.SetFocusedRowCellValue(colTM, 0);
                        grvData.SetFocusedRowCellValue(colCK, 0);
                    }
                    else
                    {
                        grvData.SetFocusedRowCellValue(colCK, 0);
                        grvData.SetFocusedRowCellValue(colTM, 0);
                    }
                }
                grvData.FocusedRowHandle = -1;
                grvData.FocusedRowHandle = handle;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (PaymentTable.ID == 0)
            {
                MessageBox.Show("Bạn phải lưu lại trước khi xuất file", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            string path = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path = fbd.SelectedPath;
            }
            else
            {
                return;
            }

            string filePath = Application.StartupPath + "\\Templates\\PhongKeToan\\BKTT.xlsx";
            string currentPath = path + "\\" + PaymentTable.Number + ".xlsx";
            try
            {
                File.Copy(filePath, currentPath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi tạo bảng kê thanh toán!" + Environment.NewLine + ex.Message,
                    TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo biểu mẫu..."))
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                Excel.Application app = default(Excel.Application);
                Excel.Workbook workBoook = default(Excel.Workbook);
                Excel.Worksheet workSheet = default(Excel.Worksheet);
                try
                {
                    app = new Excel.Application();
                    app.Workbooks.Open(currentPath);
                    workBoook = app.Workbooks[1];
                    workSheet = (Excel.Worksheet)workBoook.Worksheets[1];

                    workSheet.Cells[6, 1] = "(Số: " + PaymentTable.Number + ")";
                    workSheet.Cells[21, 8] = "Ngày " + DateTime.Now.ToString("dd/MM/yyyy");

                    DataTable dtItem = LibQLSX.Select("select * from vPaymentTableItem with(nolock) where PaymentTableID = " + PaymentTable.ID);
                    DataTable dtSupplier = LibQLSX.Select("select Distinct SupplierCode from vPaymentTableItem with(nolock) where PaymentTableID = " + PaymentTable.ID);

                    for (int i = dtSupplier.Rows.Count - 1; i >= 0; i--)
                    {
                        string supplierCode = TextUtils.ToString(dtSupplier.Rows[i]["SupplierCode"]);
                        DataRow[] drsItem = dtItem.Select("SupplierCode = '" + supplierCode + "'");
                        decimal total = 0;

                        for (int j = drsItem.Length - 1; j >= 0; j--)
                        {
                            ((Excel.Range)workSheet.Cells[18, 9]).Formula = "=IF(OR($T18=1,$T18=2,$T18=3),\"\",\"-\")";
                            ((Excel.Range)workSheet.Cells[18, 10]).Formula = "=IF(OR($T18=1,$T18=4,$T18=3),\"\",\"-\")";
                            ((Excel.Range)workSheet.Cells[18, 11]).Formula = "=IF(OR($T18=4,$T18=3),\"\",\"-\")";
                            ((Excel.Range)workSheet.Cells[18, 12]).Formula = "=IF(OR($T18=1,$T18=2,$T18=3,$T18=4,$T18=5),\"\",\"-\")";
                            ((Excel.Range)workSheet.Cells[18, 13]).Formula = "=IF(OR($T18=1),\"\",\"-\")";
                            ((Excel.Range)workSheet.Cells[18, 14]).Formula = "=IF(OR($T18=4,$T18=3),\"\",\"-\")";
                            ((Excel.Range)workSheet.Cells[18, 15]).Formula = "=IF(OR($T18=2),\"\",\"-\")";
                            ((Excel.Range)workSheet.Cells[18, 16]).Formula = "=IF(OR($T18=4,$T18=3),\"\",\"-\")";

                            workSheet.Cells[18, 1] = j + 1;
                            workSheet.Cells[18, 2] = TextUtils.ToString(drsItem[j]["Name"]);
                            workSheet.Cells[18, 3] = TextUtils.ToString(drsItem[j]["Content"]);
                            workSheet.Cells[18, 4] = TextUtils.ToString(drsItem[j]["Code"]);
                            workSheet.Cells[18, 5] = TextUtils.ToString(drsItem[j]["Target"]);
                            workSheet.Cells[18, 6] = TextUtils.ToString(drsItem[j]["TotalCash"]);
                            workSheet.Cells[18, 7] = TextUtils.ToString(drsItem[j]["TotalCK"]);

                            //int contractStatus = TextUtils.ToInt(drsItem[j]["ContractStatus"]);

                            workSheet.Cells[18, 9] = TextUtils.ToString(drsItem[j]["ContractStatusText"]);
                            workSheet.Cells[18, 10] = TextUtils.ToString(drsItem[j]["InvoiceStatusText"]);
                            //workSheet.Cells[10, 11] = TextUtils.ToInt(drsItem[j]["IsPO"]) > 0 ? "R" : "£";
                            //workSheet.Cells[10, 12] = TextUtils.ToInt(drsItem[j]["IsCongNo"]) > 0 ? "R" : "£";
                            //workSheet.Cells[10, 13] = TextUtils.ToInt(drsItem[j]["IsCuongVe"]) > 0 ? "R" : "£";
                            //workSheet.Cells[10, 14] = TextUtils.ToInt(drsItem[j]["IsTTGH"]) > 0 ? "R" : "£";
                            //workSheet.Cells[10, 15] = TextUtils.ToInt(drsItem[j]["IsGDD"]) > 0 ? "R" : "£";
                            //workSheet.Cells[10, 16] = TextUtils.ToInt(drsItem[j]["IsVV_DA_NCC"]) > 0 ? "R" : "£";
                            //workSheet.Cells[10, 17] = TextUtils.ToInt(drsItem[j]["IsApproved"]) > 0 ? "R" : "£";
                            workSheet.Cells[18, 18] = TextUtils.ToString(drsItem[j]["Note"]);
                            workSheet.Cells[18, 19] = TextUtils.ToString(drsItem[j]["UserName"]);

                            total += TextUtils.ToDecimal(drsItem[j]["TotalCash"]) +
                                    TextUtils.ToDecimal(drsItem[j]["TotalCK"]);
                            ((Excel.Range)workSheet.Rows[18]).Insert();
                        }

                        workSheet.Cells[18, 2] = supplierCode;
                        workSheet.Cells[18, 8] = total;
                        ((Excel.Range)workSheet.Rows[18]).Font.Bold = true;
                        ((Excel.Range)workSheet.Rows[18]).Font.Size = 10;
                        ((Excel.Range)workSheet.Rows[18]).Insert();
                    }

                    ((Excel.Range)workSheet.Rows[17]).Delete();
                    ((Excel.Range)workSheet.Rows[17]).Delete();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (app != null)
                    {
                        app.ActiveWorkbook.Save();
                        app.Workbooks.Close();
                        app.Quit();
                    }
                }
                Process.Start(currentPath);
            }
        }

        private void grvData_ShownEditor(object sender, EventArgs e)
        {
            TextEdit edit = (sender as BaseView).ActiveEditor as TextEdit;
            if (edit != null)
                edit.Spin += new DevExpress.XtraEditors.Controls.SpinEventHandler(edit_Spin);
        }

        void edit_Spin(object sender, DevExpress.XtraEditors.Controls.SpinEventArgs e)
        {
            e.Handled = true;
        }

        private void grvData_KeyDown(object sender, KeyEventArgs e)
        {
            if (grvData.SelectedRowsCount < 1)
            {
                return;
            }
            if (e.KeyCode == Keys.Delete)
            {
               btnDelete_Click(null, null);
            }
            if (e.KeyCode == (Keys.C))
            {
                try
                {
                    string text = TextUtils.ToString(grvData.GetFocusedRowCellValue(grvData.FocusedColumn));
                    Clipboard.SetText(text);
                }
                catch (Exception)
                {
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (grvData.SelectedRowsCount < 1)
            {
                return;
            }
            try
            {
                string code = grvData.GetFocusedRowCellValue(colCode).ToString();
                int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
                int orderRequirePaidID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colOrderRequirePaidID));

                if (MessageBox.Show("Bạn có chắc muốn xóa mã vụ việc [" + code + "]?", TextUtils.Caption,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (id > 0)
                    {
                        PaymentTableItemBO.Instance.Delete(id);

                        if (orderRequirePaidID > 0)
                        {
                            OrderRequirePaidModel paid = (OrderRequirePaidModel)OrderRequirePaidBO.Instance.FindByPK(orderRequirePaidID);
                            paid.Status = 1;
                            OrderRequirePaidBO.Instance.Update(paid);
                        }

                        ArrayList listOrder = OrdersBO.Instance.FindByAttribute("OrderCode", code);
                        if (listOrder.Count > 0)
                        {
                            OrdersModel order = (OrdersModel)listOrder[0];
                            order.StatusTT = 1;
                            OrdersBO.Instance.UpdateQLSX(order);                            
                        }
                    }
                    grvData.DeleteSelectedRows();
                }
            }
            catch (Exception)
            {
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (cboOrder.EditValue != null && txtCode.Text.Trim() != "")
            {
                frmOrderTransfer frm = new frmOrderTransfer();
                frm.SupplierCode = TextUtils.ToString(grvCboOrder.GetFocusedRowCellValue(colOrderSupplierCode));
                frm.OrderCode = txtCode.Text.Trim();
                frm.Show();
            }
        }

        private void btnShowHistoryTransfer_Click(object sender, EventArgs e)
        {
            //if (TextUtils.ToString(grvData.GetFocusedRowCellValue(colCode)) == "") return;
            frmOrderTransfer frm = new frmOrderTransfer();
            frm.OrderCode = TextUtils.ToString(grvData.GetFocusedRowCellValue(colCode));
            frm.Show();
        }

        private void btnVouchers_Click(object sender, EventArgs e)
        {
            long id = TextUtils.ToInt64(grvData.GetFocusedRowCellValue(colID));
            PaymentTableItemModel item = new PaymentTableItemModel();
            if (id > 0)
            {
                item = (PaymentTableItemModel)PaymentTableItemBO.Instance.FindByPK(id);
            }
            else
            {
                MessageBox.Show("Bạn phải Ghi lại dữ liệu trước khi thêm chứng từ nợ.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            frmVouchers frm = new frmVouchers();
            frm.PaymentTableItem = item;
            frm.Show();
        }

        private void grvData_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            //if (e.RowHandle < 0) return;
            //GridView View = sender as GridView;
            //int id = TextUtils.ToInt(View.GetRowCellValue(e.RowHandle, colID));
            //DataTable dtDebt = LibQLSX.Select("select top 1 * from vPayVoucherLink with(nolock) where CompletedDate is null and PaymentTableItemID = " + id);
            //if (dtDebt.Rows.Count > 0 && e.Column == colCode)
            //{
            //    e.Appearance.BackColor = Color.Yellow;
            //}
        }

        private void xácNhậnĐãThanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (int i in grvData.GetSelectedRows())
            {
                if (i < 0) continue;
                int iD = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                PaymentTableItemModel model = (PaymentTableItemModel)PaymentTableItemBO.Instance.FindByPK(iD);
                if (!model.IsPaid)
                {
                    model.IsPaid = true;
                    PaymentTableItemBO.Instance.Update(model);
                    grvData.SetRowCellValue(i, colIsPaid, true);
                }
            }
            //long id = TextUtils.ToInt64(grvData.GetFocusedRowCellValue(colID));
            //PaymentTableItemModel item = new PaymentTableItemModel();
            //if (id > 0)
            //{
            //    item = (PaymentTableItemModel)PaymentTableItemBO.Instance.FindByPK(id);
            //    item.IsPaid = true;
            //    PaymentTableItemBO.Instance.Update(item);

            //    grvData.SetFocusedRowCellValue(colIsPaid, true);
            //}
            //else
            //{
            //    MessageBox.Show("Bạn phải Ghi lại dữ liệu trước khi xác nhận.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}
        }

        private void bỏXácNhậnĐãThanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (int i in grvData.GetSelectedRows())
            {
                if (i < 0) continue;
                int iD = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                PaymentTableItemModel model = (PaymentTableItemModel)PaymentTableItemBO.Instance.FindByPK(iD);
                if (!model.IsPaid)
                {
                    model.IsPaid = false;
                    PaymentTableItemBO.Instance.Update(model);
                    grvData.SetRowCellValue(i, colIsPaid, false);
                }
            }
            //long id = TextUtils.ToInt64(grvData.GetFocusedRowCellValue(colID));
            //PaymentTableItemModel item = new PaymentTableItemModel();
            //if (id > 0)
            //{
            //    item = (PaymentTableItemModel)PaymentTableItemBO.Instance.FindByPK(id);
            //    item.IsPaid = false;
            //    PaymentTableItemBO.Instance.Update(item);
            //    grvData.SetFocusedRowCellValue(colIsPaid, false);
            //}
            //else
            //{
            //    MessageBox.Show("Bạn phải Ghi lại dữ liệu trước khi xác nhận.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}
        }

        private void btnApproved_Click(object sender, EventArgs e)
        {
            foreach (int i in grvData.GetSelectedRows())
            {
                if (i < 0) continue;
                int iD = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                PaymentTableItemModel model = (PaymentTableItemModel)PaymentTableItemBO.Instance.FindByPK(iD);
                if (!model.IsApproved)
                {
                    model.IsApproved = true;
                    PaymentTableItemBO.Instance.Update(model);
                    grvData.SetRowCellValue(i, colIsApproved, true);
                }
            }
        }

        private void bỏDuyệtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (int i in grvData.GetSelectedRows())
            {
                if (i < 0) continue;
                int iD = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                PaymentTableItemModel model = (PaymentTableItemModel)PaymentTableItemBO.Instance.FindByPK(iD);
                if (model.IsApproved)
                {
                    model.IsApproved = false;
                    PaymentTableItemBO.Instance.Update(model);
                    grvData.SetRowCellValue(i,colIsApproved, false);
                }
            }
        }

        private void btnExcelDetail_Click(object sender, EventArgs e)
        {
            if (PaymentTable.ID == 0)
            {
                MessageBox.Show("Bạn phải lưu lại trước khi xuất file", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            string path = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path = fbd.SelectedPath;
            }
            else
            {
                return;
            }

            string filePath = Application.StartupPath + "\\Templates\\PhongKeToan\\MauChungTu.xlsx";
            string currentPath = path + "\\ChungTu-" + PaymentTable.Number + ".xlsx";

            try
            {
                File.Copy(filePath, currentPath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi tạo bảng kê thanh toán chi tiết!" + Environment.NewLine + ex.Message,
                    TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo biểu mẫu..."))
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                Excel.Application app = default(Excel.Application);
                Excel.Workbook workBoook = default(Excel.Workbook);
                Excel.Worksheet workSheet = default(Excel.Worksheet);
                try
                {
                    app = new Excel.Application();
                    app.Workbooks.Open(currentPath);
                    workBoook = app.Workbooks[1];
                    workSheet = (Excel.Worksheet)workBoook.Worksheets[1];

                    DataTable dtItem = LibQLSX.Select("select * from vPaymentTableItem with(nolock) where PaymentTableID = " + PaymentTable.ID);

                    for (int i = 0; i < dtItem.Rows.Count; i++)
                    {
                        string orderCode = TextUtils.ToString(dtItem.Rows[i]["Code"]);
                        //if (orderCode == "NCC1016.201702.007")
                        //{
                        //    MessageBox.Show("a");
                        //}
                        string listProjects = TextUtils.ToString(dtItem.Rows[i]["Target"]);
                        decimal vat = TextUtils.ToDecimal(dtItem.Rows[i]["VAT"]);
                        decimal delivery = TextUtils.ToDecimal(dtItem.Rows[i]["DeliveryCost"]);
                        decimal percentPay = TextUtils.ToDecimal(dtItem.Rows[i]["PercentPay"]);
                        decimal totalTH = TextUtils.ToDecimal(dtItem.Rows[i]["TotalTH"]);
                        string[] arrProject = listProjects.Split(',');
                        if (arrProject.Length == 1)
                        {
                            //workSheet.Cells[8, 1] = i + 1;
                            workSheet.Cells[8, 5] = orderCode.Length > 7 ? orderCode.Substring(0, 7) : orderCode;
                            workSheet.Cells[8, 19] =
                                (TextUtils.ToDecimal(dtItem.Rows[i]["TotalCash"]) +
                                 TextUtils.ToDecimal(dtItem.Rows[i]["TotalCK"])).ToString();
                            workSheet.Cells[8, 7] = TextUtils.ToString(dtItem.Rows[i]["Name"]);
                            workSheet.Cells[8, 20] = TextUtils.ToString(dtItem.Rows[i]["DCode"]);
                            workSheet.Cells[8, 21] = TextUtils.ToString(dtItem.Rows[i]["CostCode"]);
                            workSheet.Cells[8, 22] = TextUtils.ToString(dtItem.Rows[i]["Target"]);
                            workSheet.Cells[8, 23] = orderCode;

                            ((Excel.Range)workSheet.Rows[8]).Insert();
                        }
                        else if (arrProject.Length > 1)
                        {
                            //if (orderCode == "NCC1281.201803.017")
                            //{
                            //    MessageBox.Show(orderCode);
                            //}
                            
                            //arrProject = arrProject.OrderByDescending(c => c).ToArray();
                            foreach (string projectCode in arrProject)
                            {
                                decimal total = 0;
                                if (orderCode.Length > 7)
                                {
                                    string sql = "";
                                    //bool isSXC = false;
                                    if (!projectCode.Trim().StartsWith("Mua"))
                                    {
                                        sql = "select sum(TotalPrice) as total from vGetPartWithOrder_New060318 where OrderCode = '" + orderCode +
                                        "' and ProjectCode = '" + projectCode.Trim() + "'";
                                        //isSXC = true;
                                    }
                                    else
                                    {
                                        sql = "select sum(TotalPrice) as total from vGetPartWithOrder_New060318 where OrderCode = '" + orderCode +
                                        "' and (ProjectCode is null or ProjectCode = '')";
                                    }
                                    //DataTable dtSum = LibQLSX.Select(sql);
                                    decimal totalTH_Project = TextUtils.ToDecimal(LibQLSX.ExcuteScalar(sql));
                                    decimal total_TH_Delivery = (delivery / (totalTH == 0 ? 1 : totalTH) * totalTH_Project) + totalTH_Project;

                                    total = Math.Round((total_TH_Delivery + total_TH_Delivery * vat / 100) * (percentPay / 100));                                   
                                }
                                else
                                {
                                    total = TextUtils.ToDecimal(dtItem.Rows[i]["TotalCash"]) + TextUtils.ToDecimal(dtItem.Rows[i]["TotalCK"]);
                                }                                

                                workSheet.Cells[8, 5] = orderCode.Length > 7 ? orderCode.Substring(0, 7) : orderCode;
                                workSheet.Cells[8, 19] = total;
                                workSheet.Cells[8, 7] = TextUtils.ToString(dtItem.Rows[i]["Name"]);
                                workSheet.Cells[8, 20] = TextUtils.ToString(dtItem.Rows[i]["DCode"]);
                                workSheet.Cells[8, 21] = TextUtils.ToString(dtItem.Rows[i]["CostCode"]);
                                workSheet.Cells[8, 22] = projectCode.Trim();
                                workSheet.Cells[8, 23] = orderCode;

                                ((Excel.Range)workSheet.Rows[8]).Insert();
                            }
                        }
                    }

                    ((Excel.Range)workSheet.Rows[7]).Delete();
                    ((Excel.Range)workSheet.Rows[7]).Delete();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (app != null)
                    {
                        app.ActiveWorkbook.Save();
                        app.Workbooks.Close();
                        app.Quit();
                    }
                }
                Process.Start(currentPath);
            }
        }

        private void txtVAT_EditValueChanged(object sender, EventArgs e)
        {
            decimal total = (TextUtils.ToDecimal(txtTotalTH.EditValue) + TextUtils.ToDecimal(txtDiffCost.EditValue) + TextUtils.ToDecimal(txtDeliveryCost.EditValue));
            total = total + (TextUtils.ToDecimal(txtVAT.EditValue) * total / 100);
            txtTotal.EditValue = total;
        }
    }
}
