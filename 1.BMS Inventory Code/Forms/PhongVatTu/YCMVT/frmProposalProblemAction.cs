using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPA.Model;
using TPA.Utils;
using TPA.Business;

namespace BMS
{
    public partial class frmProposalProblemAction : _Forms
    {
        public ProposalProblemModel ProposalProblem = new ProposalProblemModel();
        public ProposalBuyModel Proposal = new ProposalBuyModel();

        bool _isSaved = false;

        public delegate void LoadDataChangeHandler(object sender, EventArgs e);
        public event LoadDataChangeHandler LoadDataChange;

        DataTable _dtAction = new DataTable();

        public frmProposalProblemAction()
        {
            InitializeComponent();
        }

        private void frmProposalProblemAction_Load(object sender, EventArgs e)
        {
            txtYCMVT.Text = Proposal.ProposalCode;
            loadUser();
            if (ProposalProblem.ID > 0)
            {
                txtReason.Text = ProposalProblem.Reason;
                txtSolution.Text = ProposalProblem.Solution;
                //chkIsCompleted.Checked = ProposalProblem.IsCompleted;
            }

            loadGrid();               
        }

        void loadUser()
        {
            DataTable dt = LibQLSX.Select("Select * from [vUser] WITH(NOLOCK)");
            cboUser.Properties.DataSource = dt;
            cboUser.Properties.DisplayMember = "UserName";
            cboUser.Properties.ValueMember = "UserId";
            grvCboUser.BestFitColumns();

            //repositoryItemSearchLookUpEdit1.DataSource = dt;
            //repositoryItemSearchLookUpEdit1.DisplayMember = "UserName";
            //repositoryItemSearchLookUpEdit1.ValueMember = "UserId";
        }

        void loadGrid()
        {
            _dtAction = LibQLSX.Select("select * from vProposalProblemAction with(nolock) where ProposalProblemID = "
                           + ProposalProblem.ID);
            grdData.DataSource = _dtAction;     
        }

        bool ValidateForm()
        {            
            if (txtReason.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền Nguyên nhân.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            //if (chkTonDong.Checked && dtpDatePhatSinh.EditValue == null)
            //{
            //    MessageBox.Show("Xin hãy thêm Ngày phát sinh.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return false;
            //}

            //if (cboStatus.SelectedIndex < 0)
            //{
            //    MessageBox.Show("Xin hãy chọn Tình trạng.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return false;
            //}
            return true;
        }

        void save()
        {
            if (Global.AppUserName != ProposalProblem.UpdatedBy && ProposalProblem.ID > 0)
            {
                MessageBox.Show("Bạn không có quyền sửa vấn đề này!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();
            try
            {
                if (!ValidateForm())
                    return;

                grvData.FocusedRowHandle = -1;
                ProposalProblem.ProposalId = Proposal.ProposalId;
                ProposalProblem.Reason = txtReason.Text.Trim();
                ProposalProblem.Solution = txtSolution.Text.Trim();
                ProposalProblem.IsCompleted = 0;
                ProposalProblem.UpdatedDate = DateTime.Now;
                ProposalProblem.UpdatedBy = Global.AppUserName;

                if (ProposalProblem.ID <= 0)
                {
                    ProposalProblem.CreatedDate = DateTime.Now;
                    ProposalProblem.CreatedBy = Global.AppUserName;
                    ProposalProblem.ID = (int)pt.Insert(ProposalProblem);
                }
                else
                {
                    pt.Update(ProposalProblem);
                }

                for (int i = 0; i < grvData.RowCount; i++)
                {
                    ProposalProblemActionModel action = new ProposalProblemActionModel();
                    int id = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                    if (id > 0)
                    {
                        action = (ProposalProblemActionModel)ProposalProblemActionBO.Instance.FindByPK(id);
                    }

                    action.Action = TextUtils.ToString(grvData.GetRowCellValue(i, colAction));
                    action.ProposalProblemID = ProposalProblem.ID;
                    action.UserId = TextUtils.ToString(grvData.GetRowCellValue(i, colUserId));
                    action.Deadline = TextUtils.ToDate2(grvData.GetRowCellValue(i,colDeadline));
                    action.IsCompleted = TextUtils.ToBoolean(grvData.GetRowCellValue(i, colIsCompleted));

                    if (id > 0)
                    {
                        ProposalProblemActionBO.Instance.Update(action);
                    }
                    else
                    {
                        ProposalProblemActionBO.Instance.Insert(action);
                    }
                }

                pt.CommitTransaction();
                loadGrid();
                _isSaved = true;

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
            else
            {
                return;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save();
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            save();
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cboUser.EditValue == null)
            {
                MessageBox.Show("Bạn phải chọn một nhân viên!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (txtAction.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải điền hoạt động!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (dtpDeadline.EditValue == null)
            {
                MessageBox.Show("Bạn phải chọn hạn hoàn thành!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            DataRow dr = _dtAction.NewRow();
            dr["UserId"] = TextUtils.ToString(cboUser.EditValue);
            //dr["Account"] = TextUtils.ToString(grvCboUser.GetFocusedRowCellValue(colAccount));
            dr["UserName"] = TextUtils.ToString(grvCboUser.GetFocusedRowCellValue(colCboFullName));
            dr["Action"] = TextUtils.ToString(txtAction.Text.Trim());
            dr["Deadline"] = TextUtils.ToDate2(dtpDeadline.EditValue);
            _dtAction.Rows.Add(dr);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (grvData.RowCount == 0)
            {
                return;
            }
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            string name = TextUtils.ToString(grvData.GetFocusedRowCellValue(colAction)); ;
            if (id > 0)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa hành động/phương án [" + name + "] ra khỏi danh sách?", TextUtils.Caption,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ProposalProblemActionBO.Instance.Delete(id);
                    loadGrid();
                }
            }
            else
            {
                grvData.DeleteSelectedRows();
            }
        }

        private void btnIsCompleted_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn hoàn thành những hành động phương án này?", TextUtils.Caption,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (int i in grvData.GetSelectedRows())
                {
                    int id = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                    if (id == 0) continue;
                    ProposalProblemActionModel model = (ProposalProblemActionModel)ProposalProblemActionBO.Instance.FindByPK(id);
                    model.IsCompleted = true;
                    ProposalProblemActionBO.Instance.Update(model);
                }
                loadGrid();
            }
        }
    }
}
