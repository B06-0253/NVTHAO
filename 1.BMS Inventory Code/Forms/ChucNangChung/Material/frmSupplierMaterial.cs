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
    public partial class frmSupplierMaterial : _Forms
    {

        public string MaterialCode;
        public string MaterialName;

        public frmSupplierMaterial()
        {
            InitializeComponent();
        }

        private void frmSupplierMaterial_Load(object sender, EventArgs e)
        {
            this.Text += ": " + MaterialCode + " - " + MaterialName;
            try
            {
                string sql = "SELECT distinct a.SupplierName as Name ,max(a.Price) as Price,max(a.TotalDelivery) as Delivery"
                                + " ,Code =(SELECT top 1 SupplierCode FROM [Suppliers]"
                                + " b where b.SupplierName = a.SupplierName)"
                                + " ,Phone =(SELECT top 1 Phone FROM [Suppliers] "
                                + " b where b.SupplierName = a.SupplierName)"
                                + " ,Email =(SELECT top 1 Email FROM [Suppliers] "
                                + " b where b.SupplierName = a.SupplierName)"
                     + " FROM [SummaryPartsList] a where a.SupplierName <>'' and a.PartsCode = '" + MaterialCode + "'"
                     + " Group by a.SupplierName";
                DataTable dt = LibQLSX.Select(sql);
                grdData.DataSource = dt;
                grvData.BestFitColumns();
            }
            catch (Exception)
            {
               
            }
            
        }


    }
}
