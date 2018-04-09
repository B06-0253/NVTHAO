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
    public partial class frmTemHistory : _Forms
    {
        public int ModuleTemID;
        public string ModuleTemCode;
        public frmTemHistory()
        {
            InitializeComponent();
        }

        private void frmTemHistory_Load(object sender, EventArgs e)
        {
            this.Text += ": " + ModuleTemCode;
            try
            {
                DataTable dt = TextUtils.Select("ModuleTemHistory", new Utils.Expression("ModuleTemID", ModuleTemID));
                grdData.DataSource = dt;
            }
            catch (Exception)
            {

            }
        }
    }
}
