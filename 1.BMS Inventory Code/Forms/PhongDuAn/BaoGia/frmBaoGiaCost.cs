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

namespace BMS
{
    public partial class frmBaoGiaCost : _Forms
    {
        public BaoGiaModel BaoGia = new BaoGiaModel();
        bool _isSaved = false;

        public delegate void LoadDataChangeHandler(object sender, EventArgs e);
        public event LoadDataChangeHandler LoadDataChange;

        public frmBaoGiaCost()
        {
            InitializeComponent();
        }

        private void frmReportBaoGia_Load(object sender, EventArgs e)
        {
            this.Text += ": " + BaoGia.Code + " - Dự án: " + BaoGia.ProjectCode;

            txtTotalTPA.Text = BaoGia.TotalTPA.ToString("n0");
            txtTotalHD.Text = BaoGia.TotalHD.ToString("n0");
            txtTotalVT.Text = BaoGia.TotalVT.ToString("n0");
            txtTotalReal.Text = BaoGia.TotalReal.ToString("n0");

            loadDepartment();

            LoadGrid(0);
            LoadGrid(1);

            loadDiffGrid();
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

        void loadDiffGrid()
        {
            DataTable dt = TextUtils.Select("select * from BaoGiaDiff with(nolock) where BaoGiaID = " + BaoGia.ID);
            grdDiff.DataSource = dt;
        }

        void LoadGrid(int type)
        {
            DataTable Source = new DataTable();

            string[] paraName = new string[2];
            object[] paraValue = new object[2];
            paraName[0] = "@BaoGiaID"; paraValue[0] = BaoGia.ID;
            paraName[1] = "@Type"; paraValue[1] = type;

            Source = BaoGiaBO.Instance.LoadDataFromSP("spGetCostBaoGia1", "Source", paraName, paraValue);

            if (Source.Rows.Count == 0)
            {
                Source = BaoGiaBO.Instance.LoadDataFromSP("spGetCostBaoGia", "Source", paraName, paraValue);
                Source.Columns.Add("DepartmentID", typeof(int));
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

        bool ValidateForm()
        {
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            grvCost.FocusedRowHandle = grvCostTM.FocusedRowHandle = grvDiff.FocusedRowHandle = -1;

            try
            {
                #region Chi phí phát sinh
                if (grvDiff.RowCount > 0)
                {
                    for (int i = 0; i < grvDiff.RowCount; i++)
                    {
                        BaoGiaDiffModel diffModel = new BaoGiaDiffModel();
                        int diffID = TextUtils.ToInt(grvDiff.GetRowCellValue(i, colDiffID));
                        if (diffID > 0)
                        {
                            diffModel = (BaoGiaDiffModel)BaoGiaDiffBO.Instance.FindByPK(diffID);
                        }

                        diffModel.STT = TextUtils.ToInt(grvDiff.GetRowCellValue(i, colDiffSTT));
                        diffModel.BaoGiaID = BaoGia.ID;
                        diffModel.Description = grvDiff.GetRowCellValue(i, colDiffDescription) != null ? grvDiff.GetRowCellValue(i, colDiffDescription).ToString() : "";
                        diffModel.Name = grvDiff.GetRowCellValue(i, colDiffName) != null ? grvDiff.GetRowCellValue(i, colDiffName).ToString() : "";
                        diffModel.Price = grvDiff.GetRowCellValue(i, colDiffPrice) != null ? TextUtils.ToDecimal(grvDiff.GetRowCellValue(i, colDiffPrice)) : 0;

                        if (diffID > 0)
                        {
                            BaoGiaDiffBO.Instance.Update(diffModel);
                        }
                        else
                        {
                            BaoGiaDiffBO.Instance.Insert(diffModel);
                        }
                    }
                }
                #endregion

                #region Chi phí sản xuất
                if (grvCost.RowCount > 0)
                {
                    for (int i = 0; i < grvCost.RowCount; i++)
                    {
                        CostSummaryModel sxModel = new CostSummaryModel();
                        int sxID = TextUtils.ToInt(grvCost.GetRowCellValue(i, colID));
                        if (sxID > 0)
                        {
                            sxModel = (CostSummaryModel)CostSummaryBO.Instance.FindByPK(sxID);
                        }

                        sxModel.CostDetailID = TextUtils.ToInt(grvCost.GetRowCellValue(i, colCostDetailID));
                        sxModel.BaoGiaID = BaoGia.ID;
                        sxModel.DepartmentID = TextUtils.ToInt(grvCost.GetRowCellValue(i, colDepartmentID));
                        sxModel.TotalDK = TextUtils.ToDecimal(grvCost.GetRowCellValue(i, colTotal));
                        sxModel.TotalTT = TextUtils.ToDecimal(grvCost.GetRowCellValue(i, colTotalReal));

                        if (sxID > 0)
                        {
                            CostSummaryBO.Instance.Update(sxModel);
                        }
                        else
                        {
                            CostSummaryBO.Instance.Insert(sxModel);
                        }
                    }
                }
                #endregion

                #region Chi phí thương mại
                if (grvCostTM.RowCount > 0)
                {
                    for (int i = 0; i < grvCostTM.RowCount; i++)
                    {
                        CostSummaryModel tmModel = new CostSummaryModel();
                        int tmID = TextUtils.ToInt(grvCostTM.GetRowCellValue(i, colIDTM));
                        if (tmID > 0)
                        {
                            tmModel = (CostSummaryModel)CostSummaryBO.Instance.FindByPK(tmID);
                        }

                        tmModel.CostDetailID = TextUtils.ToInt(grvCostTM.GetRowCellValue(i, colCostDetailIDTM));
                        tmModel.BaoGiaID = BaoGia.ID;
                        tmModel.DepartmentID = TextUtils.ToInt(grvCostTM.GetRowCellValue(i, colDepartmentIDTM));
                        tmModel.TotalDK = TextUtils.ToDecimal(grvCostTM.GetRowCellValue(i, colTotalTM));
                        tmModel.TotalTT = TextUtils.ToDecimal(grvCostTM.GetRowCellValue(i, colTotalRealTM));

                        if (tmID > 0)
                        {
                            CostSummaryBO.Instance.Update(tmModel);
                        }
                        else
                        {
                            CostSummaryBO.Instance.Insert(tmModel);
                        }
                    }
                }
                #endregion

                #region Update Báo giá
                BaoGia.TotalPhatSinh = TextUtils.ToDecimal(colDiffPrice.SummaryItem.SummaryValue);
                BaoGia.TotalSX = TextUtils.ToDecimal(colTotal.SummaryItem.SummaryValue);
                BaoGia.TotalDkSX = TextUtils.ToDecimal(colTotalReal.SummaryItem.SummaryValue);
                BaoGia.TotalTM = TextUtils.ToDecimal(colTotalTM.SummaryItem.SummaryValue);
                BaoGia.TotalDkTM = TextUtils.ToDecimal(colTotalRealTM.SummaryItem.SummaryValue);
                BaoGiaBO.Instance.Update(BaoGia);
                #endregion

                _isSaved = true;

                LoadGrid(0);
                LoadGrid(1);
                loadDiffGrid();

                MessageBox.Show("Ghi dữ liệu thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }

        private void grvDiff_KeyDown(object sender, KeyEventArgs e)
        {
            if (grvDiff.SelectedRowsCount < 1)
            {
                return;
            }
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    string name = grvDiff.GetFocusedRowCellValue(colDiffName).ToString();
                    int id = TextUtils.ToInt(grvDiff.GetFocusedRowCellValue(colDiffID));
                    if (MessageBox.Show("Bạn có chắc muốn xóa chi phí [" + name + "]?", TextUtils.Caption,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (id > 0)
                        {
                            BaoGiaDiffBO.Instance.Delete(id);
                        }
                        grvDiff.DeleteSelectedRows();
                        //loadRealPrice();
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void frmReportBaoGia_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_isSaved)
            {
                if (this.LoadDataChange != null)
                {
                    this.LoadDataChange(null, null);
                }
                DialogResult = DialogResult.OK;
            }
        }
    }
}
