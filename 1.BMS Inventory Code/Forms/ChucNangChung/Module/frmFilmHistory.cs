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
    public partial class frmFilmHistory : _Forms
    {
        public int ModuleFilmID;
        public string ModuleFilmCode;

        public frmFilmHistory()
        {
            InitializeComponent();
        }

        private void frmFilmHistory_Load(object sender, EventArgs e)
        {
            this.Text += ": " + ModuleFilmCode;
            try
            {
                DataTable dt = TextUtils.Select("ModuleFilmHistory", new Utils.Expression("ModuleFilmID", ModuleFilmID));
                grdData.DataSource = dt;
            }
            catch (Exception)
            {
                                
            }
        }
    }
}
