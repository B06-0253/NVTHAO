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
    public partial class frmSupplierParts : _Forms
    {
        public string NCCcode = "";

        public frmSupplierParts()
        {
            InitializeComponent();
        }

        private void frmSupplierParts_Load(object sender, EventArgs e)
        {
            this.Text += ": " + NCCcode;
            loadData();
        }

        void loadData()
        {
            string sql = "SELECT vRequirePartFull.*, Groups.GroupCode + ' - ' + Groups.GroupName AS GroupName"
                              + " FROM Parts LEFT OUTER JOIN"
                              + " Groups ON Parts.GroupId = Groups.GroupId RIGHT OUTER JOIN"
                              + " vRequirePartFull WITH (nolock) ON Parts.PartsCode = vRequirePartFull.PartsCode"
                              +" where SupplierCode = '" + NCCcode + "'";
            DataTable dt = LibQLSX.Select(sql);
            //DataTable dt = LibQLSX.Select("select * from vRequirePartFull with(nolock) where SupplierCode = '" + NCCcode + "'");
            //grvData.BestFitColumns();
            grdData.DataSource = dt;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                TextUtils.ExportExcel(grvData);
            }
            catch
            {
            }
        }
    }
}
