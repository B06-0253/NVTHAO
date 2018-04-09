using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Business;
using DevExpress.XtraGrid.Views.Grid;
using TPA.Business;

namespace BMS
{
    public partial class frmListMaterial : _Forms
    {
        private int _RecordPerPage = 100;
        private int _PageIndex = 1;
        private int _TotalPage = 1;        

        DataTable _dtMaterial = new DataTable();
        public DataTable dtAll = new DataTable();

        public frmListMaterial()
        {
            InitializeComponent();
        }

        private void frmListMaterial_Load(object sender, EventArgs e)
        {
            loadModuleGroup();            

            if (dtAll.Columns.Count == 0)
            {
                dtAll.Columns.Add("ID");
                dtAll.Columns.Add("Code");
                dtAll.Columns.Add("Name");
                dtAll.Columns.Add("Error");
                dtAll.Columns.Add("KPH");
                dtAll.Columns.Add("Hang");
                dtAll.Columns.Add("Qty");
                dtAll.Columns.Add("Status");
                dtAll.Columns.Add("TonKho");
                dtAll.Columns.Add("CVersion");
                dtAll.Columns.Add("NVersion");
                dtAll.Columns.Add("Unit");
                dtAll.Columns.Add("Price");
            }

            grvSelected.AutoGenerateColumns = false;
            grvSelected.DataSource = dtAll;

            repositoryItemCheckEdit1.ValueChecked = 1;
            repositoryItemCheckEdit1.ValueUnchecked = 0;
        }

        void loadModuleGroup()
        {
            DataTable tbl = TextUtils.Select(@"SELECT * FROM ModuleGroup WITH(NOLOCK) where ParentID > 0 and Code like '%tpad%' ORDER BY Code");
            if (tbl == null)
            {
                return;
            }
            //TextUtils.PopulateCombo(cboModuleGroup, tbl.Copy(), "Code", "ID", "");
            cboModuleGroup.Properties.DataSource = tbl;
            cboModuleGroup.Properties.DisplayMember = "Code";
            cboModuleGroup.Properties.ValueMember = "ID";
        }

        void loadData(int pageIndex)
        {
            try
            {
                string[] paraName = new string[3];
                object[] paraValue = new object[3];

                paraName[0] = "@RecordPerPage"; paraValue[0] = _RecordPerPage;
                paraName[1] = "@PageIndex"; paraValue[1] = pageIndex;
                paraName[2] = "@TextFind"; paraValue[2] = txtTextFind.Text.Trim();

                _dtMaterial = SuppliersBO.Instance.LoadDataFromSP("spGetMaterialQLSX", "Source", paraName, paraValue);
                if (pageIndex == 1)
                {
                    string sqlSum = "";
                    sqlSum = "select PartsId from [dbo].[Parts] where ([PartType] = 1 or [PartType] = 2) and [PartsUse] = 1 ";
                    if (txtTextFind.Text.Trim() != "")
                    {
                        sqlSum += " and (PartsCode like N'%" + txtTextFind.Text.Trim() + "%' or PartsName like N'%" + txtTextFind.Text.Trim() + "%')";
                    }
                    DataTable dt = LibQLSX.Select(sqlSum);
                    int rowCount = dt.Rows.Count;
                    _TotalPage = rowCount / _RecordPerPage;
                    if (rowCount % _RecordPerPage > 0 || _TotalPage == 0)
                    {
                        _TotalPage += 1;
                        txtTotalPage.Text = _TotalPage.ToString();
                    }
                }
                grvDataMaterial.AutoGenerateColumns = false;
                grvDataMaterial.DataSource = _dtMaterial;
            }
            catch
            {
            }
        }

        private void btnFindAll_Click(object sender, EventArgs e)
        {
            _PageIndex = 1;
            txtPageIndex.Text = 1.ToString();
            loadData(1);
        }

        private void cboModuleGroup_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string[] paraName = new string[1];
                object[] paraValue = new object[1];
                paraName[0] = "@ModuleGroupID"; paraValue[0] = cboModuleGroup.EditValue;
                DataTable Source = ModulesBO.Instance.LoadDataFromSP("spGetFilterModule", "Source", paraName, paraValue);
                grdModule.DataSource = Source;
            }
            catch
            {
                grdModule.DataSource = null;
            }
        }

        #region Paging
        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            _PageIndex = 1;
            txtPageIndex.Text = 1.ToString();
            loadData(1);
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (_PageIndex == 1) return;
            _PageIndex--;
            txtPageIndex.Text = _PageIndex.ToString();
            loadData(_PageIndex);
        }

        private void btnNxtPage_Click(object sender, EventArgs e)
        {
            if (_PageIndex == _TotalPage) return;
            _PageIndex++;
            txtPageIndex.Text = _PageIndex.ToString();
            loadData(_PageIndex);
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            _PageIndex = _TotalPage;
            txtPageIndex.Text = _TotalPage.ToString();
            loadData(_TotalPage);
        }

        private void txtTextFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _PageIndex = 1;
                txtPageIndex.Text = 1.ToString();
                loadData(1);
            }
        }
        #endregion

        private void grvModule_DoubleClick(object sender, EventArgs e)
        {
            string code = grvModule.GetFocusedRowCellValue(colMoCode).ToString();
            int stop =TextUtils.ToInt(grvModule.GetFocusedRowCellValue(colStop));
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

            if (dtAll.Select("Code = '" + code + "'").Count() > 0)
            {
                return;
            }

            dtAll.Rows.Add(id, code, name, error, kph, "TPA", "1", status, "0", cVersion, nVersion);
        }

        private void grvDataMaterial_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = grvDataMaterial.SelectedRows[0].Cells[colMaID.Index].Value.ToString();
            string code = grvDataMaterial.SelectedRows[0].Cells[colMaCode.Index].Value.ToString();
            string name = grvDataMaterial.SelectedRows[0].Cells[colMaName.Index].Value.ToString();
            string hang = grvDataMaterial.SelectedRows[0].Cells[colMaHang.Index].Value.ToString();
            string tonkho = grvDataMaterial.SelectedRows[0].Cells[colInventory.Index].Value.ToString();     
            string unit = grvDataMaterial.SelectedRows[0].Cells[colMaUnit.Index].Value.ToString();
            string price = grvDataMaterial.SelectedRows[0].Cells[colMaPrice.Index].Value.ToString();     
            if (dtAll.Select("Code = '" + code + "'").Count() > 0)
            {
                return;
            }

            dtAll.Rows.Add(id, code, name, "0", "0", hang, "1", "0", tonkho, "0", "0", unit, price);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
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

        private void grvModule_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                //string projectCode = grvData.GetFocusedRowCellValue(colCode).ToString();
                string moduleCode = grvModule.GetFocusedRowCellValue(colMoCode).ToString();
                DataTable dt = TextUtils.Select("select * from ModuleVersion with(nolock) where ModuleCode = '" + moduleCode + "'");
                grdVersion.DataSource = dt;
                if (grvVersion.RowCount>0)
                {
                    grvVersion.FocusedRowHandle = grvVersion.RowCount - 1;
                }
                
            }
            catch
            {
                grdVersion.DataSource = null;
            }
        }

        private void hủyChọnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow itemRow in grvSelected.SelectedRows)
            {
                grvSelected.Rows.Remove(itemRow);
            }
        }
    }
}
