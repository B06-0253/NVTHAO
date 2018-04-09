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
    public partial class frmWorkingDiariesLocation : _Forms
    {
        private bool _isAdd;
        public frmWorkingDiariesLocation()
        {
            InitializeComponent();
        }

        private void frmWorkingDiariesLocation_Load(object sender, EventArgs e)
        {
            try
            {
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
                MessageBox.Show("Xin hãy điền mã.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
            {
                DataTable dt;
                if (!_isAdd)
                {
                    int strID = TextUtils.ToInt(grvData.GetRowCellValue(grvData.FocusedRowHandle, "ID"));
                    dt = LibQLSX.Select("select top 1 Code from WorkingDiariesLocation where Code = '" + txtCode.Text.Trim() + "' and ID <> " + strID );
                }
                else
                {
                    dt = LibQLSX.Select("select top 1 Code from WorkingDiariesLocation where Code = '" + txtCode.Text.Trim() + "'");
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

            return true;
        }
        private void loadGrid()
        {
            try
            {
                //DataTable tbl = LibQLSX.Select("Select a.*, Case when a.IsUse = 0 then N'Ngừng hoạt động' else N'Hoạt động' end StatusText from Departments a with(nolock)");
                DataTable tbl = LibQLSX.Select("Select a.* from WorkingDiariesLocation a with(nolock)");
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
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!grvData.IsDataRow(grvData.FocusedRowHandle))
                return;
            SetInterface(true);
            _isAdd = false;
            txtName.Text = TextUtils.ToString(grvData.GetRowCellValue(grvData.FocusedRowHandle, "Name"));
            txtCode.Text = TextUtils.ToString(grvData.GetRowCellValue(grvData.FocusedRowHandle, "Code"));
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!grvData.IsDataRow(grvData.FocusedRowHandle))
                return;

            int strID = TextUtils.ToInt(grvData.GetRowCellValue(grvData.FocusedRowHandle, "ID"));

            string strName = TextUtils.ToString(grvData.GetRowCellValue(grvData.FocusedRowHandle, "Name"));

            if (WorkingDiariesBO.Instance.CheckExist("WorkingDiariesLocationID", strID))
            {
                MessageBox.Show("Địa điểm này đang được sử dụng nên không thể xóa được!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (MessageBox.Show(String.Format("Bạn có chắc muốn xóa [{0}] không?", strName), TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    WorkingDiariesLocationBO.Instance.Delete(Convert.ToInt32(strID));
                    loadGrid();
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
                if (!checkValid())
                    return;
                WorkingDiariesLocationModel dModel;
                if (_isAdd)
                {
                    dModel = new WorkingDiariesLocationModel();
                }
                else
                {
                    dModel = (WorkingDiariesLocationModel)WorkingDiariesLocationBO.Instance.FindByPK(TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID)));
                }

                dModel.Code = txtCode.Text.Trim();
                dModel.Name = txtName.Text.Trim();

                if (_isAdd)
                {
                    WorkingDiariesLocationBO.Instance.Insert(dModel);
                }
                else
                {
                    WorkingDiariesLocationBO.Instance.Update(dModel);
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
