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
    public partial class frmSupplierHistory : _Forms
    {
        public int TypeFind = 0;
        public string TextFind = "";

        public frmSupplierHistory()
        {
            InitializeComponent();
        }

        private void frmSupplierHistory_Load(object sender, EventArgs e)
        {
            if (TypeFind == 0)
            {
                this.Text += "cho vật tư: " + TextFind;
            }
            if (TypeFind == 1)
            {
                this.Text += "cho nhóm vật tư: " + TextFind;
            }
            loadData();
        }

        void loadData()
        {
            DataTable dt = new DataTable();
            if (TypeFind == 0)
            {
                dt = LibQLSX.Select("select * from vGetListSupplierOfParts with(nolock) where PartsCode = '" + TextFind + "'");
            }
            if (TypeFind == 1)
            {
                dt = LibQLSX.Select("SELECT distinct [SupplierId],[SupplierName],[SupplierCode],[ContactPerson],[Phone],[Email]"
                  +" ,[Note],[StatusDisable],[SupplierERPId],[DateArising],[NhanTinStatus],[MST],[BankName],[BankAcount],[BankAcountName]"
                  +" ,[Office],[Address],[PaymentTerm],[MaterialGroup],[ProductProvided],[Agency],[Discount],[UserId],[HopDongNguyenTac],[BangDanhGia]"
                  +" ,[DKKD],[UyQuyenHang],[DateChecked],[DateCheckedNext],[ContactPhone],[UpdatedDate],[MaterialGroupName],[UserName],[Hang]"
                  +" ,[GroupCode],[GroupName]"
              + " FROM [ProductionManagement].[dbo].[vGetListSupplierOfParts] where GroupCode = '" + TextFind + "'");
            }
            grdData.DataSource = dt;
        }
    }
}
