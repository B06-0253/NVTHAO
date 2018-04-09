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
    public partial class frmCostGroupDetail : _Forms
    {
        public CostGroupModel CostGroup = new CostGroupModel();
        DataTable dtCost;
        bool _isSaved = false;

        public frmCostGroupDetail()
        {
            InitializeComponent();
        }

        private void frmCostGroupDetail_Load(object sender, EventArgs e)
        {
            this.Location = new Point(this.Width / 2, 0);
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            loadGrid();
            if (CostGroup.ID > 0)
            {
                txtCode.Text = CostGroup.Code;
                txtName.Text = CostGroup.Name;
                txtDescription.Text = CostGroup.Description;

                txtPercentTrade.Text = CostGroup.PercentTrade.ToString();
                txtPercentUser.Text = CostGroup.PercentUser.ToString();
                txtPercentVat.Text = CostGroup.VAT.ToString();

                txtProfitSX.Text = CostGroup.ProfitSX.ToString();
                txtProfitTM.Text = CostGroup.ProfitTM.ToString();
                txtDividedRate.Text = CostGroup.DividedRate.ToString();
            }
        }

        void loadGrid()
        {
            dtCost = TextUtils.Select("vCostLink", new Expression("CostGroupID", CostGroup.ID));
            grdData.DataSource = dtCost;
        }

        private bool ValidateForm()
        {
            if (txtCode.Text == "")
            {
                MessageBox.Show("Xin hãy điền mã.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
            {
                DataTable dt;
                if (CostGroup.ID > 0)
                {                   
                    dt = TextUtils.Select("select Code from CostDetail where Code = '" + txtCode.Text.Trim() + "' and ID <> " + CostGroup.ID);
                }
                else
                {
                    dt = TextUtils.Select("select Code from CostDetail where Code = '" + txtCode.Text.Trim() + "'");
                }
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Mã này đã tồn tại!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }
                }
            }

            if (txtName.Text == "")
            {
                MessageBox.Show("Xin hãy điền tên.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (txtPercentTrade.Text == "")
            {
                MessageBox.Show("Xin hãy điền % giá thương mại.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (txtPercentUser.Text == "")
            {
                MessageBox.Show("Xin hãy điền % giá NSDụng.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (txtPercentVat.Text == "")
            {
                MessageBox.Show("Xin hãy điền % VAT.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return true;
        }

        void save(bool close)
        {
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();

            try
            {
                if (!ValidateForm())
                    return;

                CostGroup.Code = txtCode.Text.Trim();
                CostGroup.Name = txtName.Text.Trim();
                CostGroup.Description = txtDescription.Text.Trim();
                CostGroup.PercentTrade = TextUtils.ToDecimal(txtPercentTrade.Text.Trim());
                CostGroup.PercentUser = TextUtils.ToDecimal(txtPercentUser.Text.Trim());
                CostGroup.VAT = TextUtils.ToDecimal(txtPercentVat.Text.Trim());
                CostGroup.DividedRate = TextUtils.ToDecimal(txtDividedRate.Text.Trim());
                CostGroup.ProfitSX = TextUtils.ToDecimal(txtProfitSX.Text.Trim());
                CostGroup.ProfitTM = TextUtils.ToDecimal(txtProfitTM.Text.Trim());

                if (CostGroup.ID == 0)
                {
                    CostGroup.ID = (int)pt.Insert(CostGroup);
                }
                else
                {
                    pt.Update(CostGroup);
                }

                if (grvData.RowCount>0)
                {
                    for (int i = 0; i < grvData.RowCount; i++)
                    {
                        int id = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                        CostLinkModel costLink;
                        if (id == 0)
                        {
                            costLink = new CostLinkModel();
                        }
                        else
                        {
                            costLink = (CostLinkModel)CostLinkBO.Instance.FindByPK(id);
                        }

                        costLink.CostGroupID = CostGroup.ID;
                        costLink.CostDetailID = TextUtils.ToInt(grvData.GetRowCellValue(i, colCostDetailID));
                        costLink.CostPercent = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colPercent));

                        if (id == 0)
                        {
                            pt.Insert(costLink);
                        }
                        else
                        {
                            pt.Update(costLink);
                        }
                    }
                }               

                pt.CommitTransaction();
                _isSaved = true;

                if (close)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    loadGrid();
                    MessageBox.Show("Lưu trữ thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                pt.CloseConnection();
            }
        }       

        private void btnSave_Click(object sender, EventArgs e)
        {
            save(false);
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            save(true);
        }

        private void frmCostGroupDetail_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_isSaved)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void btnAddCostDetail_Click(object sender, EventArgs e)
        {
            frmCostDetail frm = new frmCostDetail();
            frm.dtDetail = dtCost;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                dtCost = frm.dtDetail;
                grdData.DataSource = dtCost;
            }
        }

        private void btnRemoveCostDetail_Click(object sender, EventArgs e)
        {
            int iD = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (iD == 0)
            {
                grvData.DeleteRow(grvData.FocusedRowHandle);
            }
            else
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa chi phí này không?", TextUtils.Caption,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        CostLinkBO.Instance.Delete(iD);
                        grvData.DeleteRow(grvData.FocusedRowHandle);
                    }
                    catch
                    {
                        MessageBox.Show("Có lỗi xảy ra khi thực hiện thao tác, xin vui lòng thử lại sau.");
                    }
                }
            }            
        }        
    }
}
