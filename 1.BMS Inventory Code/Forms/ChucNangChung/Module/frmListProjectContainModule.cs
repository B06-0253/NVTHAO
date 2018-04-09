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
    public partial class frmListProjectContainModule : _Forms
    {
        public ModulesModel Module = new ModulesModel();

        public frmListProjectContainModule()
        {
            InitializeComponent();
        }

        private void frmListProjectContainModule_Load(object sender, EventArgs e)
        {
            this.Text += ": " + Module.Code + " - " + Module.Name;
            loadGrid();
        }

        void loadGrid()
        {
            DataTable tbl = LibQLSX.Select("exec spGetHistoryModuleUsing '" + Module.Code + "'");
            grdData.DataSource = null;
            grdData.DataSource = tbl;
        }
    }
}
