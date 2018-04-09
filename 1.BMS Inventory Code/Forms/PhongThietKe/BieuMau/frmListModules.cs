using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Business;
using BMS.Model;
using DevExpress.XtraGrid.Views.Grid;

namespace BMS
{
    public partial class frmListModules : _Forms
    {
        public DataTable dtSeleted = new DataTable();

        public frmListModules()
        {
            InitializeComponent();
        }

        private void frmListModules_Load(object sender, EventArgs e)
        {
            repositoryItemCheckEdit1.ValueChecked = 1;
            repositoryItemCheckEdit1.ValueUnchecked = 0;

            loadTree();

            if (dtSeleted.Columns.Count == 0)
            {
                dtSeleted.Columns.Add("ID");
                dtSeleted.Columns.Add("Code");
                dtSeleted.Columns.Add("Name");
                dtSeleted.Columns.Add("Error");
                dtSeleted.Columns.Add("KPH");
                dtSeleted.Columns.Add("Hang");
                dtSeleted.Columns.Add("Qty");
                dtSeleted.Columns.Add("CodeHD");
                dtSeleted.Columns.Add("NameHD");
                dtSeleted.Columns.Add("Status");
                dtSeleted.Columns.Add("CVersion");
                dtSeleted.Columns.Add("NVersion");
            }

            grvSelected.AutoGenerateColumns = false;
            grvSelected.DataSource = dtSeleted;
        }

        void loadTree()
        {
            try
            {
                //DataTable tbl = TextUtils.Select("Select * from ModuleGroup with(nolock) where code like '%TPAD%' order by Code");
                DataTable tbl = TextUtils.Select("Select * from ModuleGroup with(nolock) order by Code");
                treeData.DataSource = tbl;
                treeData.KeyFieldName = "ID";
                treeData.PreviewFieldName = "Name";
            }
            catch (Exception ex)
            {
            }
        }

        DataTable Source = new DataTable();
        void loadData(int type = 0)
        {
            try
            {
                string[] paraName = new string[4];
                object[] paraValue = new object[4];
                if (type == 0)
                {
                    paraValue[0] = 0;
                }
                else
                {
                    paraValue[0] = TextUtils.ToInt(treeData.FocusedNode.GetValue(colIDTree));
                }
                paraName[0] = "@ModuleGroupID";
                paraName[1] = "@Code"; paraValue[1] = txtCode.Text.Trim();
                paraName[2] = "@Name"; paraValue[2] = txtName.Text.Trim();
                //paraName[3] = "@GroupCode"; paraValue[3] = "TPAD";
                paraName[3] = "@GroupCode"; paraValue[3] = "";

                Source = ModulesBO.Instance.LoadDataFromSP("spGetFilterModule", "Source", paraName, paraValue);
                grdModule.DataSource = Source;
            }
            catch
            {                
            }
        }

        private void btnFindAll_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadData();
                ((TextBox)sender).Focus();
            }
        }

        private void treeData_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            loadData(1);
        }

        private void grvData_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow itemRow in grvSelected.SelectedRows)
            {
                grvSelected.Rows.Remove(itemRow);
            }            
        }

        private void grvModule_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void grvModule_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0) return;
            GridView View = sender as GridView;
            int status = TextUtils.ToInt(View.GetRowCellValue(e.RowHandle, colMoStatus));
           
            if (status == 2)
            {
                e.Appearance.ForeColor = Color.Red;
            }
        }

        private void grvModule_DoubleClick(object sender, EventArgs e)
        {
            string code = grvModule.GetFocusedRowCellValue(colMoCode).ToString();
            int stop = TextUtils.ToInt(grvModule.GetFocusedRowCellValue(colStop));
            if (stop == 1)
            {
                MessageBox.Show(code + " đã tạm dừng");
                return;
            }

            string id = grvModule.GetFocusedRowCellValue(colMoID).ToString();
            string name = grvModule.GetFocusedRowCellValue(colMoName).ToString();
            string error = grvModule.GetFocusedRowCellValue(colMoError).ToString();
            string kph = grvModule.GetFocusedRowCellValue(colMoKPH).ToString();
            string status = grvModule.GetFocusedRowCellValue(colMoStatus).ToString();

            string cVersion = TextUtils.ToInt(grvVersion.GetFocusedRowCellValue(colVersion)).ToString();
            string nVersion = TextUtils.ToInt(grvVersion.GetRowCellValue(grvVersion.RowCount - 1, colVersion)).ToString();

            if (dtSeleted.Select("Code = '" + code + "'").Count() > 0)
            {
                return;
            }
            else
            {
                dtSeleted.Rows.Add(id, code, name, error, kph, "TPA", "1", "", "", status, cVersion, nVersion);
            }
        }

        private void grvModule_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                //string projectCode = grvData.GetFocusedRowCellValue(colCode).ToString();
                string moduleCode = grvModule.GetFocusedRowCellValue(colMoCode).ToString();
                DataTable dt = TextUtils.Select("select * from ModuleVersion with(nolock) where ModuleCode = '" + moduleCode + "'");
                grdVersion.DataSource = dt; 
                if (grvVersion.RowCount > 0)
                {
                    grvVersion.FocusedRowHandle = grvVersion.RowCount - 1;
                }
            }
            catch
            {
                grdVersion.DataSource = null;
            }
        }
    }
}
