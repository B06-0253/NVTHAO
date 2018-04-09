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
    public partial class frmReportNotPay : _Forms
    {
        public frmReportNotPay()
        {
            InitializeComponent();
        }

        private void frmReportNotPay_Load(object sender, EventArgs e)
        {
            loadItems();
        }

        void loadItems()
        {
            DataTable _dtItem = LibQLSX.Select("select * from vPaymentTableItem with(nolock) where IsPaid <> 1 or IsPaid is null order by ID");
            grdData.DataSource = _dtItem;
        }

        string loadNumber()
        {
            string value = "";
            string current = "BKTT." + DateTime.Now.ToString("ddMMyy");
            DataTable dt = LibQLSX.Select("select * from PaymentTable with(nolock) where Number like '%" + current + "%' order by ID desc");
            if (dt.Rows.Count > 0)
            {
                string number = TextUtils.ToString(dt.Rows[0]["Number"]);
                int index = TextUtils.ToInt(number.Split('.')[2]);
                value = current + "." + string.Format("{0:00}", index + 1);
            }
            else
            {
                value = current + ".01";
            }
            return value;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();

            decimal tm = 0;
            decimal ck = 0;

            PaymentTableModel PaymentTable = new PaymentTableModel();
            PaymentTable.IsDeleted = false;
            PaymentTable.Note = "";
            PaymentTable.Number = loadNumber();
            //PaymentTable.TotalTM = TextUtils.ToDecimal(colTM.SummaryItem.SummaryValue);
            //PaymentTable.TotalCK = TextUtils.ToDecimal(colCK.SummaryItem.SummaryValue);
            PaymentTable.UpdatedBy = Global.AppUserName;
            PaymentTable.UpdatedDate = DateTime.Now;            
            PaymentTable.CreatedBy = Global.AppUserName;
            PaymentTable.CreatedDate = DateTime.Now;

            PaymentTable.ID = (long)pt.Insert(PaymentTable);

            grvData.FocusedRowHandle = -1;
            for (int i = 0; i < grvData.RowCount; i++)			
            {
                if (i < 0) continue;
                bool check = TextUtils.ToBoolean(grvData.GetRowCellValue(i, colCheck));
                if (!check) continue;

                long iD = TextUtils.ToInt64(grvData.GetRowCellValue(i, colID));
                PaymentTableItemModel model = (PaymentTableItemModel)PaymentTableItemBO.Instance.FindByPK(iD);               

                PaymentTableModel pay = (PaymentTableModel)PaymentTableBO.Instance.FindByPK(model.PaymentTableID);
                pay.TotalTM -= model.TotalCash;
                pay.TotalCK -= model.TotalCK;
                pt.Update(pay);

                model.PaymentTableID = PaymentTable.ID;
                pt.Update(model);

                tm += model.TotalCash;
                ck += model.TotalCK;
            }

            pt.CommitTransaction();

            PaymentTable.TotalTM = tm;
            PaymentTable.TotalCK = ck;

            PaymentTableItemBO.Instance.Update(PaymentTable);

            loadItems();
        }
    }
}
