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

namespace BMS
{
    public partial class frmPOyctt : _Forms
    {
        public frmPOyctt()
        {
            InitializeComponent();
        }

        private void frmPOyctt_Load(object sender, EventArgs e)
        {
            loadPaymentType();
            loadData();
        }

        void loadData()
        {
            string sql = "exec spGetOrderRequirePaid";
            DataTable dt = LibQLSX.Select(sql);
            grdYC.DataSource = dt;
        }

        void loadPaymentType()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Name");
            dt.Rows.Add(0, "Chuyển khoản");
            dt.Rows.Add(1, "Tiền mặt");
            repositoryItemLookUpEdit1.DataSource = dt;
            repositoryItemLookUpEdit1.ValueMember = "ID";
            repositoryItemLookUpEdit1.DisplayMember = "Name";
        }

        string loadNumber(PaymentTableModel paymentTable)
        {
            string numberPT = "";
            if (paymentTable.ID == 0)
            {
                string current = "BKTT." + DateTime.Now.ToString("ddMMyy");
                DataTable dt = LibQLSX.Select("select * from PaymentTable with(nolock) where Number like '%" + current + "%' order by ID desc");
                if (dt.Rows.Count > 0)
                {
                    string number = TextUtils.ToString(dt.Rows[0]["Number"]);
                    int index = TextUtils.ToInt(number.Split('.')[2]);
                    numberPT = current + "." + string.Format("{0:00}", index + 1);
                }
                else
                {
                    numberPT = current + ".01";
                }
            }
            else
            {
                numberPT = paymentTable.Number;
            }
            return numberPT;
        }

        private void btnCreateBKTT_Click(object sender, EventArgs e)
        {
            grvYC.FocusedRowHandle = -1;
            DataTable dtYC = (DataTable)grdYC.DataSource;

            DataRow[] drsYC = dtYC.Select("Check = 1");
            if (drsYC.Length == 0) return;
            
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();
            try
            {
                PaymentTableModel PaymentTable = new PaymentTableModel();
                PaymentTable.IsDeleted = false;
                PaymentTable.Number = loadNumber(PaymentTable);
                //PaymentTable.TotalTM = TextUtils.ToDecimal(colTM.SummaryItem.SummaryValue);
                //PaymentTable.TotalCK = TextUtils.ToDecimal(colCK.SummaryItem.SummaryValue);
                PaymentTable.UpdatedBy = Global.AppUserName;
                PaymentTable.UpdatedDate = DateTime.Now;
                PaymentTable.CreatedBy = Global.AppUserName;
                PaymentTable.CreatedDate = DateTime.Now;
                PaymentTable.ID = (long)pt.Insert(PaymentTable);
                int count = 0;
                foreach (DataRow row in drsYC)
                {
                    PaymentTableItemModel item = new PaymentTableItemModel();
                    item.Code = TextUtils.ToString(row["OrderCode"]);
                    item.Target = TextUtils.ToString(row["Project"]);
                    item.Name = TextUtils.ToString(row["SupplierName"]);
                    item.Total = TextUtils.ToDecimal(row["TienThanhToan"]);
                    item.TotalTH = TextUtils.ToDecimal(row["TotalPrice"]);
                    item.DeliveryCost = TextUtils.ToDecimal(row["DeliveryCost"]);
                    item.DiffCost = TextUtils.ToDecimal(row["DiffCost"]);
                    item.UserId = TextUtils.ToString(row["UserId"]);
                    //item.ProjectId = TextUtils.ToString(row["Project"]);
                    item.VAT = TextUtils.ToDecimal(row["VAT"]);

                    item.OrderRequirePaidID = TextUtils.ToInt(row["ID"]);
                    item.PaymentTableID = PaymentTable.ID;
                    item.IsCash = TextUtils.ToInt(row["PaymentType"]) == 1 ? true : false;
                    item.PercentPay = TextUtils.ToDecimal(row["PayPercent"]);
                    item.TotalCash = item.IsCash ? TextUtils.ToDecimal(row["TotalPay"]) : 0;
                    item.TotalCK = item.IsCash ? 0 : TextUtils.ToDecimal(row["TotalPay"]);

                    pt.Insert(item);

                    OrdersModel order = (OrdersModel)OrdersBO.Instance.FindByAttribute("OrderId", TextUtils.ToString(row["OrderId"]))[0];
                    order.StatusTT = 2;
                    pt.UpdateQLSX(order);

                    OrderRequirePaidModel paid = (OrderRequirePaidModel)OrderRequirePaidBO.Instance.FindByPK(TextUtils.ToInt(row["ID"]));
                    paid.Status = 2;
                    pt.Update(paid);

                    count++;
                }
                if (count > 0)
                {
                    pt.CommitTransaction();
                    MessageBox.Show("Lưu trữ thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    loadData();

                    PaymentTableModel model = (PaymentTableModel)PaymentTableBO.Instance.FindByAttribute("Number", PaymentTable.Number)[0];
                    frmPaymentTableItem frm = new frmPaymentTableItem();
                    frm.PaymentTable = model;
                    frm.Show();
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
    }
}
