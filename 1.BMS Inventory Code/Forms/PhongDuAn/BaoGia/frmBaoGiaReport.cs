using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Business;
using DevExpress.XtraEditors.Controls;

namespace BMS
{
    public partial class frmBaoGiaReport : _Forms
    {
        public frmBaoGiaReport()
        {
            InitializeComponent();
        }

        private void BaoGiaReport_Load(object sender, EventArgs e)
        {
            dtpStartDateCP.Value = dtpStartDepartment.Value = new DateTime(DateTime.Now.Year, 1, 1);
            loadProject();
        }

        void loadProject()
        {
            DataTable dt = TextUtils.Select("select distinct ProjectCode, ProjectName from BaoGia with(nolock)");

            cboProjectD.Properties.DataSource = dt;
            cboProjectD.Properties.DisplayMember = "ProjectCode";
            cboProjectD.Properties.ValueMember = "ProjectCode";

            cboProjectC.Properties.DataSource = dt;
            cboProjectC.Properties.DisplayMember = "ProjectCode";
            cboProjectC.Properties.ValueMember = "ProjectCode";
        }

        void LoadGrid(int type)
        {
            string[] array = (from CheckedListBoxItem item in cboProjectC.Properties.Items
                              where item.CheckState == CheckState.Checked
                              select item.Value.ToString()).ToArray();
            string listProjectCode = string.Join(",", array);

            DataTable Source = new DataTable();

            string[] paraName = new string[6];
            object[] paraValue = new object[6];

            paraName[0] = "@Type"; paraValue[0] = type;
            paraName[1] = "@FromDate"; paraValue[1] = dtpStartDateCP.Value.ToString("yyyy/MM/dd");
            paraName[2] = "@ToDate"; paraValue[2] = dtpEndCP.Value.ToString("yyyy/MM/dd");
            paraName[3] = "@ListProject"; paraValue[3] = listProjectCode;
            paraName[4] = "@DepartmentName"; paraValue[4] = txtDepartmentNameC.Text.Trim();
            paraName[5] = "@CustomerCode"; paraValue[5] = txtCustomerCodeC.Text.Trim();

            Source = BaoGiaBO.Instance.LoadDataFromSP("spGetCostReport1", "Source", paraName, paraValue);           

            if (type == 0)
            {
                grdCost.DataSource = Source;
            }
            else
            {
                grdCostTM.DataSource = Source;
            }
        }

        private void btnSearchCP_Click(object sender, EventArgs e)
        {
            LoadGrid(0);
            LoadGrid(1);
        }

        private void btnSearchDepartment_Click(object sender, EventArgs e)
        {
            string[] array = (from CheckedListBoxItem item in cboProjectD.Properties.Items
                       where item.CheckState == CheckState.Checked
                       select item.Value.ToString()).ToArray();
            string listProjectCode = string.Join(",", array);

            DataTable Source = new DataTable();

            string[] paraName = new string[5];
            object[] paraValue = new object[5];
            paraName[0] = "@FromDate"; paraValue[0] = dtpStartDepartment.Value.ToString("yyyy/MM/dd");
            paraName[1] = "@ToDate"; paraValue[1] = dtpEndDepartment.Value.ToString("yyyy/MM/dd");
            paraName[2] = "@ListProject"; paraValue[2] = listProjectCode;
            paraName[3] = "@DepartmentName"; paraValue[3] = txtDepartmentNameD.Text.Trim();
            paraName[4] = "@CustomerCode"; paraValue[4] = txtCustomerCodeD.Text.Trim();

            Source = BaoGiaBO.Instance.LoadDataFromSP("spGetCostDepartment1", "Source", paraName, paraValue);

            grdDepartment.DataSource = Source;            
        }

        private void grvDepartment_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int departmentID = TextUtils.ToInt(grvDepartment.GetFocusedRowCellValue(colDepartmentID));
            
            if (departmentID > 0)
            {
                string start = dtpStartDepartment.Value.ToString("yyyy/MM/dd");
                string end = dtpEndDepartment.Value.ToString("yyyy/MM/dd");

                DataTable dt = TextUtils.Select("SELECT * FROM [vBaoGiaCostLink] with(nolock) where DepartmentID = " 
                    + departmentID + " and DATEDIFF(DAY, CreatedDate,'" + start + "') <= 0 AND DATEDIFF(DAY,CreatedDate,'" + end + "') >= 0");
                grdDetail.DataSource = dt;
            }
        }
    }
}
