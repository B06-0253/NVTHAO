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
    public partial class frmProjectProblemAction : _Forms
    {
        public ProjectProblemActionModel Action = new ProjectProblemActionModel();
        public delegate void LoadDataChangeHandler(object sender, EventArgs e);
        public event LoadDataChangeHandler LoadDataChange;
        bool _isSaved = false;
        public long ProjectProblemID = 0;

        DataTable _dtUser = new DataTable();

        public frmProjectProblemAction()
        {
            InitializeComponent();
        }

        private void frmProjectProblemAction_Load(object sender, EventArgs e)
        {
            loadUser();

            if (Action.ID > 0)
            {
                txtAction.Text = Action.Action;
                txtResult.Text = Action.Result;
                dtpDateCompleted.EditValue = Action.CompletedDate;
                chkIsCompleted.Checked = Action.IsCompleted;
            }
            else
            {
            }

            loadGrid();
        }

        void loadGrid()
        {
            _dtUser = LibQLSX.Select("select * from vProjectProblemActionUserLink with(nolock) where ProjectProblemActionID = " + Action.ID);
            grdData.DataSource = _dtUser;
        }

        void loadUser()
        {
            DataTable dt = LibQLSX.Select("Select * from [vUser] WITH(NOLOCK)");
            cboUser.Properties.DataSource = dt;
            cboUser.Properties.DisplayMember = "UserName";
            cboUser.Properties.ValueMember = "UserId";
            grvCboUser.BestFitColumns();
        }

        bool ValidateForm()
        {
            //if (cboProject.EditValue == null)
            //{
            //    MessageBox.Show("Xin hãy chọn Dự án.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return false;
            //}

            //if (chkTonDong.Checked && cboModule.EditValue == null)
            //{
            //    MessageBox.Show("Xin hãy chọn Module.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return false;
            //}

            if (dtpDateCompleted.EditValue == null)
            {
                MessageBox.Show("Xin hãy chọn Hạn hoàn thành.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (txtAction.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền Hành động.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            //if (chkTonDong.Checked && dtpDatePhatSinh.EditValue == null)
            //{
            //    MessageBox.Show("Xin hãy thêm Ngày phát sinh.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return false;
            //}

            if (grvData.RowCount < 0)
            {
                MessageBox.Show("Xin hãy chọn Người phụ trách.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
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

                Action.Action = txtAction.Text.Trim();
                Action.CompletedDate = (DateTime?)dtpDateCompleted.EditValue;
                Action.Result = txtResult.Text.Trim();
                Action.IsCompleted = chkIsCompleted.Checked;
                Action.ProjectProblemID = ProjectProblemID;

                if (Action.ID <= 0)
                {
                    Action.ID = (int)pt.Insert(Action);
                }
                else
                {
                    pt.Update(Action);
                }

                for (int i = 0; i < grvData.RowCount; i++)
                {
                    long id = TextUtils.ToInt64(grvData.GetRowCellValue(i, colID));
                    ProjectProblemActionUserLinkModel model = new ProjectProblemActionUserLinkModel();
                    if (id > 0)
                    {
                        model = (ProjectProblemActionUserLinkModel)ProjectProblemActionUserLinkBO.Instance.FindByPK(id);
                    }

                    model.UserId = TextUtils.ToString(grvData.GetRowCellValue(i, colUserId));
                    model.ProjectProblemActionID = Action.ID;

                    if (id > 0)
                    {
                        pt.Update(model);
                    }
                    else
                    {
                        pt.Insert(model);
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

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (cboUser.EditValue == null)
            {
                MessageBox.Show("Bạn phải chọn một nhân viên!");
                return;
            }

            DataRow[] drs = _dtUser.Select("UserId = '" + TextUtils.ToString(cboUser.EditValue) + "'");
            if (drs.Length > 0)
            {
                return;
            }

            DataRow dr = _dtUser.NewRow();
            dr["UserId"] = TextUtils.ToString(cboUser.EditValue);
            dr["Account"] = TextUtils.ToString(grvCboUser.GetFocusedRowCellValue(colAccount));
            dr["UserName"] = TextUtils.ToString(grvCboUser.GetFocusedRowCellValue(colCboFullName));
            _dtUser.Rows.Add(dr);
            //loadGrid();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (grvData.RowCount == 0)
            {
                return;
            }
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            string name = TextUtils.ToString(grvData.GetFocusedRowCellValue(colUserName)); ;
            if (id > 0)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa nhân viên [" + name + "] ra khỏi danh sách?", TextUtils.Caption,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ProjectProblemActionUserLinkBO.Instance.Delete(id);
                    loadGrid();
                }
            }
            else
            {
                grvData.DeleteSelectedRows();
            }
        }
    }
}
