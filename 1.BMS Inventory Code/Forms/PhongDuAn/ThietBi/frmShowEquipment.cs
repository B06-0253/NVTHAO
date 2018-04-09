using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPA.Business;
using BMS;

namespace BMS
{
    public partial class frmShowEquipment : _Forms
    {
        public frmShowEquipment()
        {
            InitializeComponent();
        }

        private void frmShowEquipment_Load(object sender, EventArgs e)
        {
            loadProject();
            loadData();
        }

        private void cboProject_EditValueChanged(object sender, EventArgs e)
        {
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
            string projectCode = TextUtils.ToString(cboProject.EditValue);
            if (projectCode == "") return;

            string[] _paraName = new string[2];
            object[] _paraValue = new object[2];
            _paraName[0] = "@ProjectId"; _paraValue[0] = projectCode;
            _paraName[1] = "@TextFind"; _paraValue[1] = "";

            DataTable Source = SuppliersBO.Instance.LoadDataFromSP("spGetProjectProduct", "Source", _paraName, _paraValue);
            treeData.DataSource = Source;
            treeData.KeyFieldName = "PProductId";
            treeData.PreviewFieldName = "PPCode";
            treeData.ExpandAll();            
        }

        private void btnExeclGroup_Click(object sender, EventArgs e)
        {
            string projectCode = TextUtils.ToString(grvProject.GetFocusedRowCellValue(colProjectCode));
            if (projectCode == "") return;

            treeData.ExpandAll();

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                treeData.ExportToXls(fbd.SelectedPath + "\\" + projectCode + ".xls");
            }            
        }        
    }
}
