using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPA.Business;

namespace BMS
{
    public partial class frmEquipmentManagement : _Forms
    {
        public frmEquipmentManagement()
        {
            InitializeComponent();
        }

        private void frmEquipmentManagement_Load(object sender, EventArgs e)
        {
            loadProject();
            loadData();
        }

        void loadProject()
        {
            try
            {
                DataTable tbl = LibQLSX.Select("exec spGetAllProject");
                TextUtils.PopulateCombo(cboProject, tbl, "ProjectName", "ProjectId", "");
            }
            catch
            {
            }
        }

        void loadData()
        {
            string[] _paraName = new string[2];
            object[] _paraValue = new object[2];
            _paraName[0] = "@ProjectId"; _paraValue[0] = TextUtils.ToString(cboProject.EditValue);
            _paraName[1] = "@TextFind"; _paraValue[1] = txtTextFind.Text.Trim();

            DataTable Source = SuppliersBO.Instance.LoadDataFromSP("spGetProjectProduct", "Source", _paraName, _paraValue);
            grdData.DataSource = Source;
        }

        private void btnExeclGroup_Click(object sender, EventArgs e)
        {
            TextUtils.ExportExcel(grvData);
        }

        private void btnFindAll_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void txtTextFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadData();
            }
        }

        private void cboProject_EditValueChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnShowEquipment_Click(object sender, EventArgs e)
        {
            frmShowEquipment frm = new frmShowEquipment();
            TextUtils.OpenForm(frm);
        }
    }
}
