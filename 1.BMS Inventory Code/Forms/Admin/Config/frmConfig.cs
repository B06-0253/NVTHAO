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
    public partial class frmConfig : _Forms
    {
        public frmConfig()
        {
            InitializeComponent();
        }

        private void btnConfigGeneral_Click(object sender, EventArgs e)
        {
            frmConfigSystem frm = new frmConfigSystem();
            TextUtils.OpenForm(frm);
        }

        private void btnModulePartPrice_Click(object sender, EventArgs e)
        {
            frmConfigStuffs frm = new frmConfigStuffs();
            TextUtils.OpenForm(frm);
        }

        private void btnConfigNonConvert_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCreateCTTM_Click(object sender, EventArgs e)
        {
            frmConfigDirectories frm = new frmConfigDirectories();
            frm.ShowDialog();
        }
    }
}
