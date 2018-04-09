using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Model;

namespace BMS
{
    public partial class frmVersionReason : _Forms
    {
        //public BaiThucHanhModel BaiThucHanh = new BaiThucHanhModel();
        public string Reason;

        public frmVersionReason()
        {
            InitializeComponent();
        }

        private void frmVersionReason_Load(object sender, EventArgs e)
        {
            this.Text = "Nguyên nhân tạo phiên bản";
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtReason.Text.Trim() == "")
            {
                TextUtils.ShowError("Bạn phải điền nguyên nhân tạo phiên bản");
                return;
            }

            Reason = txtReason.Text.Trim();
            DialogResult = DialogResult.OK;
        }
    }
}
