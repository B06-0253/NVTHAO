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
    public partial class frmCompareIPT : _Forms
    {
        public string PropertyName;
        public string OldValue;
        public string IPTValue;
        public string RightValue;

        public frmCompareIPT()
        {
            InitializeComponent();
        }

        private void frmCompareIPT_Load(object sender, EventArgs e)
        {
            txtOldValue.Text = OldValue.Trim();
            txtIPTValue.Text = IPTValue.Trim();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRightValue.Text.Trim()))
            {
                MessageBox.Show("Bạn hãy nhập giá trị đúng!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            RightValue = txtRightValue.Text.Trim();
            DialogResult = DialogResult.OK;
        }


    }
}
