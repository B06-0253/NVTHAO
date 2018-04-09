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
    public partial class frmShowNGdetail : _Forms
    {
        public string ProductPartsImportId = "";

        public frmShowNGdetail()
        {
            InitializeComponent();
        }

        private void frmShowNGdetail_Load(object sender, EventArgs e)
        {
            loadData();
        }

        void loadData()
        {
            DataTable dt = LibQLSX.Select("select * from [CriteriaImport] with(nolock) where [Status] = 0 and [ProductPartsImportId] = '" 
                + ProductPartsImportId + "' order by [CriteriaIndex]");
            grdData.DataSource = dt;
        }

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
