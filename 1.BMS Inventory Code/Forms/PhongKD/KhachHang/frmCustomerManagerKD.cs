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
    public partial class frmCustomerManagerKD : _Forms
    {
        public frmCustomerManagerKD()
        {
            InitializeComponent();
        }

        private void frmCustomerManagerKD_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCustomerKD frm = new frmCustomerKD();
            TextUtils.OpenForm(frm);
        }
    }
}
