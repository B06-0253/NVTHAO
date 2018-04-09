using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Model;
using BMS.Business;
using BMS.Utils;

namespace BMS
{
    public partial class frmBaoGiaCostModule : _Forms
    {
        public BaoGiaModel BaoGia = new BaoGiaModel();
        bool _isSaved = false;

        public frmBaoGiaCostModule()
        {
            InitializeComponent();
        }

        private void frmBaoGiaCostModule_Load(object sender, EventArgs e)
        {
            this.Location = new Point(this.Width / 2, 0);
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Text += ": " + BaoGia.Code + " - Mã DA: " + BaoGia.ProjectCode + " - Tên DA: " + BaoGia.ProjectName;
            loadDepartment();
            loadModule();
        }

        void loadDepartment()
        {
            DataTable dt = TextUtils.Select("select ID, Name from Department with(nolock)");

            cboDepartment.DataSource = dt;
            cboDepartment.ValueMember = "ID";
            cboDepartment.DisplayMember = "Name";

            cboDepartmentTM.DataSource = dt;
            cboDepartmentTM.ValueMember = "ID";
            cboDepartmentTM.DisplayMember = "Name";
        }

        void loadModule()
        {
            DataTable dt = TextUtils.Select("select *, ModuleCode+ '-'+ ModuleName as Module from BaoGiaItem where BaoGiaID = " + BaoGia.ID);
            cboModule.Properties.DataSource = dt;
            cboModule.Properties.DisplayMember = "Module";
            cboModule.Properties.ValueMember = "ModuleCode";
        }

        void loadGrid(int type)
        {
            DataTable Source = new DataTable();

            try
            {
                string[] paraName = new string[3];
                object[] paraValue = new object[3];
                paraName[0] = "@BaoGiaID"; paraValue[0] = BaoGia.ID;
                paraName[1] = "@Type"; paraValue[1] = type;
                paraName[2] = "@ModuleCode"; paraValue[2] = cboModule.EditValue.ToString();

                Source = BaoGiaBO.Instance.LoadDataFromSP("spGetPhanBoChiPhi", "Source", paraName, paraValue);      
            }
            catch (Exception)
            {               
            }                

            if (type == 0)
            {
                grdCost.DataSource = Source;
            }
            else
            {
                grdCostTM.DataSource = Source;
            }
        }

        private void cboModule_EditValueChanged(object sender, EventArgs e)
        {
            loadGrid(0);
            loadGrid(1);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboModule.EditValue == null)
            {
                MessageBox.Show("Bạn phải chọn một module!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                grvCost.FocusedRowHandle = grvCostTM.FocusedRowHandle = -1;

                #region Chi phí sản xuất
                if (grvCost.RowCount > 0)
                {
                    for (int i = 0; i < grvCost.RowCount; i++)
                    {                       
                        int thisDepartmentID = TextUtils.ToInt(grvCost.GetRowCellValue(i, colDepartmentID));
                        int defaultDepartmentID = TextUtils.ToInt(grvCost.GetRowCellValue(i, colDID));
                        if (thisDepartmentID == defaultDepartmentID) continue;

                        CostSummaryModuleModel sxModel = new CostSummaryModuleModel();
                        int sxID = TextUtils.ToInt(grvCost.GetRowCellValue(i, colID));
                        if (sxID > 0)
                        {
                            sxModel = (CostSummaryModuleModel)CostSummaryModuleBO.Instance.FindByPK(sxID);
                        }

                        sxModel.CostDetailID = TextUtils.ToInt(grvCost.GetRowCellValue(i, colCostDetailID));
                        sxModel.BaoGiaID = BaoGia.ID;
                        sxModel.DepartmentID = TextUtils.ToInt(grvCost.GetRowCellValue(i, colDepartmentID));
                        sxModel.ModuleCode = cboModule.EditValue.ToString();

                        if (sxID > 0)
                        {
                            CostSummaryModuleBO.Instance.Update(sxModel);
                        }
                        else
                        {
                            CostSummaryModuleBO.Instance.Insert(sxModel);
                        }
                    }
                }
                #endregion

                #region Chi phí thương mại
                if (grvCostTM.RowCount > 0)
                {
                    for (int i = 0; i < grvCostTM.RowCount; i++)
                    {
                        int thisDepartmentID = TextUtils.ToInt(grvCostTM.GetRowCellValue(i, colDepartmentIDTM));
                        int defaultDepartmentID = TextUtils.ToInt(grvCostTM.GetRowCellValue(i, colDIDTM));
                        if (thisDepartmentID == defaultDepartmentID) continue;

                        CostSummaryModuleModel tmModel = new CostSummaryModuleModel();
                        int tmID = TextUtils.ToInt(grvCostTM.GetRowCellValue(i, colIDTM));
                        if (tmID > 0)
                        {
                            tmModel = (CostSummaryModuleModel)CostSummaryModuleBO.Instance.FindByPK(tmID);
                        }

                        tmModel.CostDetailID = TextUtils.ToInt(grvCostTM.GetRowCellValue(i, colCostDetailIDTM));
                        tmModel.BaoGiaID = BaoGia.ID;
                        tmModel.DepartmentID = TextUtils.ToInt(grvCostTM.GetRowCellValue(i, colDepartmentIDTM));
                        tmModel.ModuleCode = cboModule.EditValue.ToString();

                        if (tmID > 0)
                        {
                            CostSummaryModuleBO.Instance.Update(tmModel);
                        }
                        else
                        {
                            CostSummaryModuleBO.Instance.Insert(tmModel);
                        }
                    }
                }
                #endregion

                #region Update Báo giá
                //BaoGia.TotalPhatSinh = TextUtils.ToDecimal(colDiffPrice.SummaryItem.SummaryValue);
                BaoGia.TotalSX = TextUtils.ToDecimal(colTotal.SummaryItem.SummaryValue);
                BaoGia.TotalDkSX = TextUtils.ToDecimal(colTotalReal.SummaryItem.SummaryValue);
                BaoGia.TotalTM = TextUtils.ToDecimal(colTotalTM.SummaryItem.SummaryValue);
                BaoGia.TotalDkTM = TextUtils.ToDecimal(colTotalRealTM.SummaryItem.SummaryValue);
                BaoGiaBO.Instance.Update(BaoGia);
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Ghi dữ liệu thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }      
    }
}
