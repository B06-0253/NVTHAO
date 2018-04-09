using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPA.Model;
using TPA.Business;
using TPA.Utils;

namespace BMS
{
    public partial class frmCCost : _Forms
    {
        #region Variables
        public C_CostModel CurrentCost = new C_CostModel();
        public int CatID = 0;
        bool _isSaved = false;

        public delegate void LoadDataChangeHandler(object sender, EventArgs e);
        public event LoadDataChangeHandler LoadDataChange;

        #endregion

        public frmCCost()
        {
            InitializeComponent();
        }

        private void frmCost_Load(object sender, EventArgs e)
        {
            repositoryItemCheckEdit1.ValueChecked = 1;
            repositoryItemCheckEdit1.ValueUnchecked = 0;
            loadCombo();
            loadProductGroup();
            if (CurrentCost.ID > 0)
            {
                txtCode.Text = CurrentCost.Code;
                txtNote.Text = CurrentCost.Note;
                txtName.Text = CurrentCost.Name;
                txtPercentProfit.EditValue = CurrentCost.PercentProfit;
                txtPrice.EditValue = CurrentCost.Price;
                txtUnit.Text = CurrentCost.Unit;

                cboCostType.SelectedIndex = CurrentCost.CostType;
                leParentCat.EditValue = CurrentCost.C_CostGroupID;

                chkIsProfit.Checked = CurrentCost.IsProfit == 1;
                chkIsWithProject.Checked = CurrentCost.IsWithProject == 1;
                chkIsDeliveryTime.Checked = CurrentCost.IsDeliveryTime == 1;
                chkIsDirectCost.Checked = CurrentCost.IsDirectCost == 1;

                rdoIsWithProject.Checked = CurrentCost.IsWithProject == 1;
                gbIsSP.Visible = rdoSP.Checked = CurrentCost.IsWithProject != 1;
                rdoIsDirectCost.Checked = CurrentCost.IsDirectCost == 1;
                gb1.Visible = CurrentCost.IsDirectCost != 1;
            }
            else
            {
                rdoSP.Checked = true;
                rdoCPSX.Checked = true;
            }
        }

        bool _isGroup = true;
        void loadProductGroup()
        {
            DataTable dt = new DataTable();
            dt = LibQLSX.Select("select * from vC_CostProductGroupLink where C_CostID = " + CurrentCost.ID);
            _isGroup = true;
            if (dt.Rows.Count == 0)
            {
                dt = LibQLSX.Select("select *,ValuePercentKD = 0,ValuePercentSX = 0,NumberDay=0,PersonNumber=0,VtuPercent=0,IsFix = 0 from C_ProductGroup");
                _isGroup = false;
            }
            grdLink.DataSource = dt;
        }

        void loadCombo()
        {
            DataTable tbl = LibQLSX.Select(@"SELECT ID,Code,Name FROM C_CostGroup WITH(NOLOCK) ORDER BY Code");
            if (tbl == null)
            {
                return;
            }
            //TextUtils.PopulateCombo(leParentCat, tbl.Copy(), "Code", "ID", "--Cấp lớn nhất--");
            leParentCat.Properties.DataSource = tbl;
            leParentCat.Properties.ValueMember = "ID";
            leParentCat.Properties.DisplayMember = "Code";

        }

        private bool ValidateForm()
        {
            txtCode.Text = txtCode.Text.Trim().ToUpper().Replace(" ", "");
            
            if (txtCode.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền Mã.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
            {
                DataTable dt;
                if (CurrentCost.ID > 0)
                {
                    dt = TextUtils.Select("select Code from C_Cost where upper(Replace(Code,' ','')) = '" 
                        + txtCode.Text.Trim().ToUpper() + "' and ID <> " + CurrentCost.ID);
                }
                else
                {
                    dt = TextUtils.Select("select Code from C_Cost where upper(Replace(Code,' ','')) = '" 
                        + txtCode.Text.Trim().ToUpper() + "'");
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

            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền Tên.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (TextUtils.ToInt(leParentCat.EditValue) == 0)
            {
                MessageBox.Show("Xin hãy chọn một nhóm!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            //if (cboCostType.SelectedIndex == -1)
            //{
            //    MessageBox.Show("Xin hãy chọn một loại chi phí!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return false;
            //}
            
            return true;
        }

        void save()
        {
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();
            try
            {
                if (!ValidateForm())
                    return;
                CurrentCost.Name = txtName.Text.Trim();
                CurrentCost.Code = txtCode.Text.Trim();
                CurrentCost.CostType = 0;//cboCostType.SelectedIndex;
                CurrentCost.C_CostGroupID = TextUtils.ToInt(leParentCat.EditValue);

                CurrentCost.Unit = txtUnit.Text;
                CurrentCost.Note = txtNote.Text;

                CurrentCost.Price = TextUtils.ToDecimal(txtPrice.EditValue);
                CurrentCost.PercentProfit = TextUtils.ToDecimal(txtPercentProfit.EditValue);    

                CurrentCost.IsProfit = chkIsProfit.Checked ? 1 : 0;
                //CurrentCost.IsWithProject = chkIsWithProject.Checked ? 1 : 0;
                //CurrentCost.IsDirectCost = chkIsDirectCost.Checked ? 1 : 0;

                CurrentCost.IsWithProject = rdoIsWithProject.Checked ? 1 : 0;
                CurrentCost.IsDeliveryTime = chkIsDeliveryTime.Checked ? 1 : 0;
                CurrentCost.IsDirectCost = rdoIsDirectCost.Checked ? 1 : 0;

                if (CurrentCost.ID <= 0)
                {
                    //CurrentCost.CreatedDate = TextUtils.GetSystemDate();
                    //CurrentCost.CreatedBy = Global.AppUserName;
                    //CurrentCost.UpdatedDate = CurrentCost.CreatedDate;
                    //CurrentCost.UpdatedBy = Global.AppUserName;
                    CurrentCost.ID = (int)pt.Insert(CurrentCost);
                }
                else
                {
                    //CurrentCost.UpdatedDate = TextUtils.GetSystemDate();
                    //CurrentCost.UpdatedBy = Global.AppUserName;
                    pt.Update(CurrentCost);
                }

                grvLink.FocusedRowHandle = -1;
                if (_isGroup)
                {
                    for (int i = 0; i < grvLink.RowCount; i++)
                    {
                        int linkID = TextUtils.ToInt(grvLink.GetRowCellValue(i, colID));
                        C_CostProductGroupLinkModel m = (C_CostProductGroupLinkModel)C_CostProductGroupLinkBO.Instance.FindByPK(linkID);
                        m.ValuePercentKD = TextUtils.ToDecimal(grvLink.GetRowCellValue(i, colValuePercentKD));
                        m.ValuePercentSX = TextUtils.ToDecimal(grvLink.GetRowCellValue(i, colValuePercentSX));
                        m.NumberDay = TextUtils.ToDecimal(grvLink.GetRowCellValue(i, colNumberDay));
                        m.PersonNumber = TextUtils.ToDecimal(grvLink.GetRowCellValue(i, colPersonNumber));
                        m.VtuPercent = TextUtils.ToDecimal(grvLink.GetRowCellValue(i, colVtuPercent));
                        pt.Update(m);
                    }
                }
                else
                {
                    //DataTable dt = (DataTable)grvLink.DataSource;
                    //DataRow[] drs = dt.Select("ValuePercent > 0");
                    //if (drs.Length > 0)
                    //{
                        for (int i = 0; i < grvLink.RowCount; i++)
                        {
                            int groupID = TextUtils.ToInt(grvLink.GetRowCellValue(i, colID));
                            C_CostProductGroupLinkModel m = new C_CostProductGroupLinkModel();
                            m.ValuePercentKD = TextUtils.ToDecimal(grvLink.GetRowCellValue(i, colValuePercentKD));
                            m.ValuePercentSX = TextUtils.ToDecimal(grvLink.GetRowCellValue(i, colValuePercentSX));
                            m.NumberDay = TextUtils.ToDecimal(grvLink.GetRowCellValue(i, colNumberDay));
                            m.PersonNumber = TextUtils.ToDecimal(grvLink.GetRowCellValue(i, colPersonNumber));
                            m.VtuPercent = TextUtils.ToDecimal(grvLink.GetRowCellValue(i, colVtuPercent));
                            m.C_ProductGroupID = groupID;
                            m.C_CostID = CurrentCost.ID;
                            pt.Insert(m);
                        }
                    //}                    
                }
                
                pt.CommitTransaction();
                _isSaved = true;

                loadProductGroup();

                MessageBox.Show("Lưu trữ thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lưu trữ không thành công!" + Environment.NewLine + ex.Message, TextUtils.Caption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                pt.CloseConnection();
            }

            if (_isSaved)
            {
                if (this.LoadDataChange != null)
                {
                    this.LoadDataChange(null, null);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save();
            CurrentCost = new C_CostModel();
            txtCode.Text = "";
            txtName.Text = "";
            loadProductGroup();
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            save();
            this.Close();
        }

        private void repositoryItemTextEdit1_Spin(object sender, DevExpress.XtraEditors.Controls.SpinEventArgs e)
        {
            e.Handled = true;
        }

        private void rdoIsWithProject_CheckedChanged(object sender, EventArgs e)
        {
            gbIsSP.Visible = gb1.Visible = grdLink.Enabled = !rdoIsWithProject.Checked;
            //grdLink.Enabled = false;
        }

        private void rdoSP_CheckedChanged(object sender, EventArgs e)
        {
            gbIsSP.Visible = rdoSP.Checked;
            rdoIsDirectCost.Checked = CurrentCost.IsDirectCost == 1;
            rdoCPSX.Checked = !(CurrentCost.IsDirectCost == 1);            
        }
        
        private void rdoCPSX_CheckedChanged(object sender, EventArgs e)
        {
            gb1.Visible = rdoCPSX.Checked;

            colValuePercentKD.Visible = rdoCPSX.Checked;
            colVtuPercent.Visible = colPersonNumber.Visible = colNumberDay.Visible = colIsFix.Visible = !rdoCPSX.Checked;            

            chkIsDeliveryTime.Visible = rdoCPSX.Checked;
            chkIsDeliveryTime.Checked = CurrentCost.IsDeliveryTime == 1;
        }

        private void rdoIsDirectCost_CheckedChanged(object sender, EventArgs e)
        {
            gb1.Visible = !rdoIsDirectCost.Checked;

            colValuePercentKD.Visible = !rdoIsDirectCost.Checked;
            colVtuPercent.Visible = colPersonNumber.Visible = colNumberDay.Visible = colIsFix.Visible = rdoIsDirectCost.Checked;            

            chkIsDeliveryTime.Visible = !rdoIsDirectCost.Checked;
            chkIsDeliveryTime.Checked = CurrentCost.IsDeliveryTime == 1;
        }
    }
}
