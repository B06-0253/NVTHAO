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
    public partial class frmMailHistory : _Forms
    {
        public string ProposalCode = "";
        public frmMailHistory()
        {
            InitializeComponent();
        }

        private void frmMailHistory_Load(object sender, EventArgs e)
        {
            this.Text += " " + ProposalCode;
            loadMailHistory();
        }

        void loadMailHistory()
        {
            DataTable dt = LibQLSX.Select("SELECT *  FROM [ProposalSentStatus] with(nolock) where [ProposalCode]='" + ProposalCode + "'");
            grdData.DataSource = dt;

        }
    }
}
