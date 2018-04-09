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
    public partial class frmShowDNNKkhacPhuc : _Forms
    {
        public DataTable DtData = new DataTable();

        public frmShowDNNKkhacPhuc()
        {
            InitializeComponent();
        }

        private void frmShowDNNKkhacPhuc_Load(object sender, EventArgs e)
        {
            grdData.DataSource = DtData;
        }

        //void loadData()
        //{
        //    DataTable dt = LibQLSX.Select("select * from vImportMaterial a with(nolock) where (a.TotalNG > 0) AND (a.Status >= 3) order by a.Year");
        //    grdData.DataSource = dt;
        //}

        private void grvData_KeyDown(object sender, KeyEventArgs e)
        {
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
    }
}
