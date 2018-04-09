using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Business;
using BMS.Model;

namespace BMS
{
    public partial class ucDetailTS : UserControl
    {
        //public string ParaCode = "";
        //public string ParaName = "";

        public string Value = "";
        public string Des = "";

        //public int MaterialParamNSID = 0;
        public MaterialParamNSModel ParamNS = new MaterialParamNSModel();

        public ucDetailTS()
        {
            InitializeComponent();
        }

        private void ucDetailTS_Load(object sender, EventArgs e)
        {
            txtParaCode.Text = ParamNS.Code;
            txtParaName.Text = ParamNS.Name;
            txtUnit.Text = ParamNS.Unit;

            DataTable dt = TextUtils.Select("select * from MaterialParamValueNS where MaterialParamNSID = " + ParamNS.ID);
            cboValue.Properties.DataSource = dt;
            cboValue.Properties.ValueMember = "ID";
            cboValue.Properties.DisplayMember = "ValueTS";
        }

        private void cboValue_EditValueChanged(object sender, EventArgs e)
        {
            if (cboValue.EditValue == null)
                return;
            Value = TextUtils.ToString(grvValue.GetFocusedRowCellValue(colValue));
            Des = TextUtils.ToString(grvValue.GetFocusedRowCellValue(colDes));
        }
    }
}
