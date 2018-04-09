using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPA.Business;
using TPA.Model;

namespace BMS
{
    public partial class frmUserGroupQLSX : _Forms
    {
        private bool isAdd;
        public frmUserGroupQLSX()
        {
            InitializeComponent();
        }

        private void frmUserGroupQLSX_Load(object sender, EventArgs e)
        {
            try
            {
                loadDepartment();
                loadLeader();
                loadData();
            }
            catch (Exception ex)
            {
                TextUtils.ShowError(ex);
            }
        }

        #region Methods
        private void SetInterface(bool isEdit)
        {
            txtCode.ReadOnly = !isEdit;

            grdData.Enabled = !isEdit;

            btnSave.Visible = isEdit;
            btnCancel.Visible = isEdit;

            btnNew.Visible = !isEdit;
            btnEdit.Visible = !isEdit;
            btnDelete.Visible = !isEdit;
        }

        private void ClearInterface()
        {
            txtName.Text = "";
            txtCode.Text = "";
        }

        private bool checkValid()
        {
            if (txtCode.Text == "")
            {
                MessageBox.Show("Xin hãy điền mã nhóm.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
            {
                DataTable dt;
                if (!isAdd)
                {
                    int strID = TextUtils.ToInt(grvData.GetRowCellValue(grvData.FocusedRowHandle, "ID").ToString());
                    dt = TextUtils.Select("select Code from UserGroup where Code = '" + txtCode.Text.Trim() + "' and ID <> " + strID);
                }
                else
                {
                    dt = TextUtils.Select("select Code from UserGroup where Code = '" + txtCode.Text.Trim() + "'");
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
                MessageBox.Show("Xin hãy điền tên nhóm.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            //if (cboDepartment.EditValue == null)
            //{
            //    MessageBox.Show("Xin hãy chọn phòng ban.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return false;
            //}

            return true;
        }

        void loadDepartment()
        {
            try
            {
                DataTable tblDepartment = LibQLSX.Select("Select * from Departments a with(nolock)");
                TextUtils.PopulateCombo(cboDepartment, tblDepartment.Copy(), "DName", "DepartmentId", "");
            }
            catch
            {
            }
        }

        void loadLeader()
        {
            DataTable dt = LibQLSX.Select("select * from Users with(nolock) where isnull(Code,'') <> '' order by Code");
            cboLeader.Properties.DataSource = dt;
            cboLeader.Properties.ValueMember = "UserId";
            cboLeader.Properties.DisplayMember = "UserName";
        }

        private void loadData()
        {
            try
            {
                DataTable tbl = LibQLSX.Select("Select * from vUserGroup1 with(nolock)");
                grdData.DataSource = tbl;               
            }
            catch
            {
            }
        }
        
        #endregion

        #region Buttons Events
        private void btnNew_Click(object sender, EventArgs e)
        {
            SetInterface(true);
            isAdd = true;
            //cboStatus.SelectedIndex = 1;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!grvData.IsDataRow(grvData.FocusedRowHandle))
                return;
            SetInterface(true);
            isAdd = false;

            int ID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            UserGroup1Model dModel = (UserGroup1Model)UserGroup1BO.Instance.FindByPK(ID);

            txtName.Text = dModel.Name;
            txtCode.Text = dModel.Code;
            cboDepartment.SelectedValue = dModel.DepartmentId;
            cboLeader.EditValue = dModel.UserId;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!grvData.IsDataRow(grvData.FocusedRowHandle))
                return;

            int strID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));

            string strName = TextUtils.ToString(grvData.GetFocusedRowCellValue(colName));

            if (UsersBO.Instance.CheckExist("UserGroup1ID", strID))
            {
                MessageBox.Show("Nhóm nhân viên này đang được sử dụng nên không thể xóa được!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (MessageBox.Show(String.Format("Bạn có chắc muốn xóa [{0}] không?", strName), TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    UserGroup1BO.Instance.Delete(Convert.ToInt32(strID));
                    loadData();
                }
                catch
                {
                    MessageBox.Show("Có lỗi xảy ra khi thực hiện thao tác, xin vui lòng thử lại sau.");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkValid())
                {
                    UserGroup1Model dModel;
                    if (isAdd)
                    {
                        dModel = new UserGroup1Model();
                    }
                    else
                    {
                        int ID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
                        dModel = (UserGroup1Model)UserGroup1BO.Instance.FindByPK(ID);
                    }
                    dModel.Code = txtCode.Text;
                    dModel.Name = txtName.Text;
                    dModel.DepartmentId = TextUtils.ToString(cboDepartment.SelectedValue);
                    dModel.UserId = TextUtils.ToString(cboLeader.EditValue);
                    if (isAdd)
                    {
                        UserGroup1BO.Instance.Insert(dModel);
                    }
                    else
                        UserGroup1BO.Instance.Update(dModel);

                    loadData();
                    SetInterface(false);
                    ClearInterface();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetInterface(false);
            ClearInterface();
        }

        #endregion

        private void grdData_Click(object sender, EventArgs e)
        {

        }

        private void grdData_DoubleClick(object sender, EventArgs e)
        {
            if (grvData.RowCount > 0 && btnEdit.Enabled == true)
                btnEdit_Click(null, null);
        }
    }
}
