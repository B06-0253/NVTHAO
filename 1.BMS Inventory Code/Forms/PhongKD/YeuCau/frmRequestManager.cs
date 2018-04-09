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
    public partial class frmRequestManager : _Forms
    {
        public frmRequestManager()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSolution frm = new frmSolution();
            TextUtils.OpenForm(frm);
        }
    }
}
