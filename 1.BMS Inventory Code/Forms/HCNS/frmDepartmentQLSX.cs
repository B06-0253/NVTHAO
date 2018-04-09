using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPA.Utils;
using TPA.Model;
using TPA.Business;

namespace BMS
{
    public partial class frmDepartmentQLSX : _Forms
    {
        private bool _isAdd;
        public frmDepartmentQLSX()
        {
            InitializeComponent();
        }

        private void frmDepartmentQLSX_Load(object sender, EventArgs e)
        {
            try
            {
                loadLeader();
                loadGrid();
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
            cboStatus.Enabled = isEdit;

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
            cboStatus.SelectedIndex = 1;
            txtCode.Text = "";
            cboLeader.EditValue = 0;
        }

        private bool checkValid()
        {
            if (txtCode.Text == "")
            {
                MessageBox.Show("Xin hãy điền mã của phòng ban.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
            {
                DataTable dt;
                if (!_isAdd)
                {
                    int strID = TextUtils.ToInt(grvData.GetRowCellValue(grvData.FocusedRowHandle, "DepartmentId").ToString());
                    dt = LibQLSX.Select("select top 1 Code from Departments where DCode = '" + txtCode.Text.Trim() + "' and DepartmentId <> '" + strID + "'");
                }
                else
                {
                    dt = LibQLSX.Select("select top 1 Code from Departments where DCode = '" + txtCode.Text.Trim() + "'");
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
                MessageBox.Show("Xin hãy điền tên của phòng ban.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (cboStatus.SelectedIndex < 0)
            {
                MessageBox.Show("Xin hãy chọn trạng thái của phòng ban.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return true;
        }

        void loadLeader()
        {
            try
            {
                DataTable tblPerson = LibQLSX.Select("select * from vUser with(nolock) where Code is not null order by Code");
                
                cboLeader.Properties.DataSource = tblPerson;
                cboLeader.Properties.DisplayMember = "UserName";
                cboLeader.Properties.ValueMember = "UserId";
            }
            catch
            {
            }
        }
        private void loadGrid()
        {
            try
            {
                DataTable tbl = LibQLSX.Select("Select a.*, Case when a.IsUse = 0 then N'Ngừng hoạt động' else N'Hoạt động' end StatusText from Departments a with(nolock)");
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
            _isAdd = true;
            cboStatus.SelectedIndex = 1;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!grvData.IsDataRow(grvData.FocusedRowHandle))
                return;
            SetInterface(true);
            _isAdd = false;
            txtName.Text = grvData.GetRowCellValue(grvData.FocusedRowHandle, "DName").ToString();
            txtCode.Text = grvData.GetRowCellValue(grvData.FocusedRowHandle, "DCode").ToString();
            cboStatus.SelectedIndex = TextUtils.ToInt(grvData.GetRowCellValue(grvData.FocusedRowHandle, "IsUse"));
            cboLeader.EditValue = TextUtils.ToString(grvData.GetFocusedRowCellValue(colLeader));
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //if (!grvData.IsDataRow(grvData.FocusedRowHandle))
            //    return;

            //int strID = TextUtils.ToInt(grvData.GetRowCellValue(grvData.FocusedRowHandle, "DepartmentId").ToString());

            //string strName = grvData.GetRowCellValue(grvData.FocusedRowHandle, "DName").ToString();

            ////if (UsersBO.Instance.CheckExist("DepartmentID", strID))
            ////{
            ////    MessageBox.Show("Phòng ban này đang được sử dụng nên không thể xóa được!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            ////    return;
            ////}

            //if (MessageBox.Show(String.Format("Bạn có chắc muốn xóa [{0}] không?", strName), TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    try
            //    {
            //        DepartmentsBO.Instance.UpdateQLSX(Convert.ToInt32(strID));
            //        loadGrid();
            //    }
            //    catch
            //    {
            //        MessageBox.Show("Có lỗi xảy ra khi thực hiện thao tác, xin vui lòng thử lại sau.");
            //    }
            //}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!checkValid())
                    return;
                DepartmentsModel dModel;
                string departmentId = "";
                if (_isAdd)
                {
                    dModel = new DepartmentsModel();

                    DataTable dt = LibQLSX.Select("SELECT top 1 DepartmentId FROM Departments order by DepartmentId desc");
                    departmentId = TextUtils.ToString(dt.Rows[0]["DepartmentId"]);
                    string number = departmentId.Substring(1, 3);
                    departmentId = "D" + string.Format("{0:000}", TextUtils.ToInt(number) + 1);
                }
                else
                {
                    departmentId = TextUtils.ToString(grvData.GetRowCellValue(grvData.FocusedRowHandle, "DepartmentId"));
                    dModel = (DepartmentsModel)DepartmentsBO.Instance.FindByAttribute("DepartmentId", departmentId)[0];
                }

                dModel.DepartmentId = departmentId;
                dModel.DCode = txtCode.Text.Trim();
                dModel.DName = txtName.Text.Trim();
                dModel.IsUse = cboStatus.SelectedIndex;
                dModel.UserId = TextUtils.ToString(cboLeader.EditValue);

                if (_isAdd)
                {
                    DepartmentsBO.Instance.InsertQLSX(dModel);
                }
                else
                {
                    DepartmentsBO.Instance.UpdateQLSX(dModel);
                }
                    

                loadGrid();
                SetInterface(false);
                ClearInterface();

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void grdData_DoubleClick(object sender, EventArgs e)
        {
            if (grvData.RowCount > 0 && btnEdit.Enabled == true)
                btnEdit_Click(null, null);
        }
    }
}
