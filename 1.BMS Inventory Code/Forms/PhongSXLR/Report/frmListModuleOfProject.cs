using DevExpress.Utils;
using DevExpress.XtraTreeList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPA.Business;
using TPA.Model;

namespace BMS
{
    public partial class frmListModuleOfProject : _Forms
    {
        public frmListModuleOfProject()
        {
            InitializeComponent();
        }

        private void frmListModuleOfProject_Load(object sender, EventArgs e)
        {
            loadProject();
            //FilterCondition fc = new FilterCondition(FilterConditionEnum.Equals, colPercentVT, 100);
            //FilterCondition fc1 = new FilterCondition(FilterConditionEnum.Equals, colPercentExport, 100);
            //treeData.FilterConditions.Add(fc);
            //treeData.FilterConditions.Add(fc1);
            colQty.Fixed = colNameTK.Fixed = colCodeTK.Fixed = colNameHD.Fixed = colCodeHD.Fixed = DevExpress.XtraTreeList.Columns.FixedStyle.Left;
        }

        void loadProject()
        {
            try
            {
                //DataTable tbl = LibQLSX.Select("exec spGetAllProject");
                DataTable tbl = LibQLSX.Select("select * from Project");
                TextUtils.PopulateCombo(cboProject, tbl, "ProjectCode", "ProjectId", "");
            }
            catch (Exception ex)
            {
            }
        }

        void loadTree()
        {
            string projectCode = TextUtils.ToString(grvProject.GetFocusedRowCellValue(colProjectCode));
            try
            {
                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load danh sách sản phẩm..."))
                {
                    string[] _paraName = new string[1];
                    object[] _paraValue = new object[1];
                    _paraName[0] = "@ProjectCode"; _paraValue[0] = projectCode;
                    DataTable Source = LibQLSX.Select("exec spGetProductOfProject1 '" + projectCode + "'");
                    treeData.DataSource = Source;
                    treeData.KeyFieldName = "PProductId";
                    treeData.PreviewFieldName = "MaThietBi";
                    treeData.ExpandAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnReloadData_Click(object sender, EventArgs e)
        {
            loadTree();
            try
            {
                DataTable dt = (DataTable)treeData.DataSource;
                decimal avgTienDo = dt.AsEnumerable()
                                    .Where(c => c.Field<string>("PercentLR") != "X")
                                    .Average(r => TextUtils.ToDecimal(r.Field<string>("PercentLR")));
                txtTienDo.EditValue = avgTienDo;
            }
            catch (Exception)
            {
            }
        }

        private void cboProject_EditValueChanged(object sender, EventArgs e)
        {
            dtpSXLRDeadline.EditValue = TextUtils.ToDate2(grvProject.GetFocusedRowCellValue(colAssemblyDeadline));
        }

        private void xemChiTiếtVậtTưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string projectModuleId = TextUtils.ToString(treeData.FocusedNode.GetValue(colProjectModuleId));
            if (projectModuleId == "") return;
            frmListPartOfModule frm = new frmListPartOfModule();
            frm.ProjectModuleId = projectModuleId;
            frm.ModuleCode = TextUtils.ToString(treeData.FocusedNode.GetValue(colCodeTK));
            frm.TotalReal = TextUtils.ToDecimal(treeData.FocusedNode.GetValue(colQty));
            frm.Show();       
        }

        private void treeData_DoubleClick(object sender, EventArgs e)
        {
            string projectModuleId = TextUtils.ToString(treeData.FocusedNode.GetValue(colProjectModuleId));
            if (projectModuleId == "") return;
            frmListPartOfModule frm = new frmListPartOfModule();
            frm.ProjectModuleId = projectModuleId;
            frm.ModuleCode = TextUtils.ToString(treeData.FocusedNode.GetValue(colCodeTK));
            frm.TotalReal = TextUtils.ToDecimal(treeData.FocusedNode.GetValue(colQty));
            frm.Show();       
        }

        private void treeData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == (Keys.C))
            {
                try
                {
                    string text = TextUtils.ToString(treeData.FocusedNode.GetValue(treeData.FocusedColumn));
                    Clipboard.SetText(text);
                }
                catch (Exception)
                {
                }
            }
        }

        private void treeData_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {
            //if (_isStyle) return;

            decimal percentVT = TextUtils.ToDecimal(e.Node.GetValue(colPercentVT));
            decimal qty = TextUtils.ToDecimal(e.Node.GetValue(colQty));

            if (e.Column == colPercentExport || e.Column == colPercentVT)
            {
                decimal percentExport = TextUtils.ToDecimal(e.Node.GetValue(colPercentExport));
                if (percentVT >= 100 && percentExport >= 100)
                {
                    e.Appearance.BackColor = Color.GreenYellow;
                }
                if (percentVT >= 100 && percentExport < 100)
                {
                    e.Appearance.BackColor = Color.Yellow;
                }
                //if (percentVT == 0 && qty == 0)
                //{
                //    e.Appearance.BackColor = Color.MediumTurquoise;
                //}
            }

            if (e.Column == colDateAboutE && percentVT < 100)
            {
                if (qty == 0) return;

                if (TextUtils.ToDate3(e.Node.GetValue(colDateAboutE)).Date > TextUtils.ToDate3(dtpSXLRDeadline.EditValue).Date)
                {
                    e.Appearance.BackColor = Color.Red;
                }
                else
                {
                    if (TextUtils.ToInt(e.Node.GetValue(colTotalDateAboutENull)) > 0)
                    {
                        e.Appearance.BackColor = Color.Orange;
                    }
                }
            }
    
            if (e.Column == colIN || e.Column == colCNC ||e.Column == colPCB ||e.Column == colGCAL ||e.Column == colLR)
            {
                string date = TextUtils.ToString(e.Node.GetValue(e.Column));
                if (date.Contains("-"))
                {
                    DateTime dateDK = TextUtils.ToDate(date);
                    if (DateTime.Now.Date > dateDK.Date)
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                }
            }
            //_isStyle = true;
        }

        private void btnExecl_Click(object sender, EventArgs e)
        {
            string projectCode = TextUtils.ToString(grvProject.GetFocusedRowCellValue(colProjectCode));
            string filePath = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog()==DialogResult.OK)
            {
                filePath = fbd.SelectedPath + "/" + projectCode + ".xls";
                treeData.ExportToXls(filePath);
            }
            Process.Start(filePath);
        }

        private void đãYCVTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string pProductId = TextUtils.ToString(treeData.FocusedNode.GetValue(colPProductId));
            if (pProductId == "") return;
            ProjectProductsModel m = (ProjectProductsModel)ProjectProductsBO.Instance.FindByAttribute("PProductId", pProductId)[0];
            m.IsYCVT = 1;
            ProjectProductsBO.Instance.UpdateQLSX(m);

            treeData.FocusedNode.SetValue(colIsYCVT, true);
        }

        private void chưaYCVTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string pProductId = TextUtils.ToString(treeData.FocusedNode.GetValue(colPProductId));
            if (pProductId == "") return;
            ProjectProductsModel m = (ProjectProductsModel)ProjectProductsBO.Instance.FindByAttribute("PProductId", pProductId)[0];
            m.IsYCVT = 0;
            ProjectProductsBO.Instance.UpdateQLSX(m);

            treeData.FocusedNode.SetValue(colIsYCVT, false);
        }

        private void btnDeadlineSXLR_Click(object sender, EventArgs e)
        {
            string projectCode = TextUtils.ToString(grvProject.GetFocusedRowCellValue(colProjectCode));
            if (dtpSXLRDeadline.EditValue != null && projectCode != "")
            {
                DateTime date = TextUtils.ToDate3(dtpSXLRDeadline.EditValue);
                LibQLSX.ExcuteSQL("update Project set AssemblyDeadline = '" + date.Year + "-" + date.Month + "-" + date.Day
                    + "' where [ProjectCode] = '" + projectCode + "'");
                string id = TextUtils.ToString(cboProject.EditValue);
                loadProject();
                cboProject.EditValue = id;

                MessageBox.Show("Thay đổi deadline SXLR thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void xemVấnĐềDựÁnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isProblem = TextUtils.ToBoolean(treeData.FocusedNode.GetValue(colIsProjectProblem));
            if (!isProblem) return;

            frmProjectProblemManager frm = new frmProjectProblemManager();
            frm.ModuleCode = TextUtils.ToString(treeData.FocusedNode.GetValue(colCodeTK));
            frm.ProjectCode = TextUtils.ToString(grvProject.GetFocusedRowCellValue(colProjectCode));
            frm.Show();
        }
    }
}
