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
    public partial class frmViewTranOfProduct : _Forms
    {
        public frmViewTranOfProduct()
        {
            InitializeComponent();
        }

        private void frmViewTranOfProduct_Load(object sender, EventArgs e)
        {
            loadStatus();
            loadModule();
        }

        void loadStatus()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Status", typeof(int));
            dt.Columns.Add("StatusText");
            dt.Rows.Add(1, "Đang tạo");
            dt.Rows.Add(2, "Đang chờ KCS");
            dt.Rows.Add(3, "Đã KCS xong");
            dt.Rows.Add(4, "Đang chờ nhập kho");
            dt.Rows.Add(5, "Đã xong");

            //TextUtils.PopulateCombo(repositoryItemLookUpEdit1, dt, "StatusText", "Status", "");
            repositoryItemLookUpEdit1.DataSource = dt;
            repositoryItemLookUpEdit1.DisplayMember = "StatusText";
            repositoryItemLookUpEdit1.ValueMember = "Status";
        }

        void loadModule()
        {
            DataTable tbl = TextUtils.Select("select * from Modules with(nolock) where Status = 2 and Code like 'TPAD.%' order by Code");
            TextUtils.PopulateCombo(cboModule, tbl, "Name", "Code", "");
        }

        void loadData(string code)
        {
            string sql = string.Format("select * from [vImportProduct] with(nolock) where [PartsCode] = '{0}' order by [ImportId] desc", code);
            DataTable dt = LibQLSX.Select(sql);
            grdData.DataSource = dt;
        }

        private void cboModule_EditValueChanged(object sender, EventArgs e)
        {
            if (cboModule.EditValue == null)
                return;
            txtCode.Text = TextUtils.ToString(cboModule.EditValue);
            loadData(TextUtils.ToString(cboModule.EditValue));
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtCode.Text.Trim() != "")
            {
                if (e.KeyCode == Keys.Enter)
                {
                    loadData(txtCode.Text.Trim());
                }
            }
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
                catch
                {
                }
            }
        }
    }
}
