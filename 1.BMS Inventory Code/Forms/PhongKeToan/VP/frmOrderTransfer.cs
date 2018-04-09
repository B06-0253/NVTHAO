using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BMS
{
    public partial class frmOrderTransfer : _Forms
    {
        public string OrderCode = "";
        public string SupplierCode = "";

        public frmOrderTransfer()
        {
            InitializeComponent();
        }

        private void frmOrderTransfer_Load(object sender, EventArgs e)
        {
            this.Text += " " + OrderCode;
            DataTable dt = new DataTable();

            //dt = LibQLSX.Select("select ROW_NUMBER() OVER(ORDER BY OrderId DESC) AS STT, * from vOrderMoneyTransfer with(nolock) where OrderCode = '" + OrderCode + "'");
            //grdData.DataSource = dt;

            string sql = "SELECT * FROM V_XNTC_VUVIEC WHERE (C_MA = '" + OrderCode + "') AND (FK_TKCO LIKE '111%' OR FK_TKCO LIKE '112%') AND (FK_TKNO LIKE '331%') and C_KHACHHANG_MA = '" + SupplierCode + "'";
            dt = LibIE.Select(sql);
            grdData.DataSource = dt;
        }
    }
}
