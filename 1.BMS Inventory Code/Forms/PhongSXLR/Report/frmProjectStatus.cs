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
    public partial class frmProjectStatus : _Forms
    {
        private bool _isAdd;
        public frmProjectStatus()
        {
            InitializeComponent();
        }

        private void frmProjectStatus_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData();
            }
            catch (Exception ex)
            {
                TextUtils.ShowError(ex);
            }
        }

        private void SetInterface(bool isEdit)
        {
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
        }

        private bool checkValid()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Xin hãy điền mã của phòng ban.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
            {
                DataTable dt;
                if (!_isAdd)
                {
                    int strID = TextUtils.ToInt(grvData.GetRowCellValue(grvData.FocusedRowHandle, "ID"));
                    dt = LibQLSX.Select("select Name from ProjectStatus where Name = N'" + txtName.Text.Trim() + "' and ID <> " + strID);
                }
                else
                {
                    dt = LibQLSX.Select("select Name from ProjectStatus where Name = N'" + txtName.Text.Trim() + "'");
                }
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Tên này đã tồn tại!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }
                }
            }

            if (txtName.Text == "")
            {
                MessageBox.Show("Xin hãy điền tên của phòng ban.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
           

            return true;
        }

        private void LoadData()
        {
            try
            {
                DataTable tbl = LibQLSX.Select("Select a.* from ProjectStatus a with(nolock)");
                grdData.DataSource = tbl;
            }
            catch (Exception)
            {
            }

        }

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
            txtName.Text = grvData.GetRowCellValue(grvData.FocusedRowHandle, "Name").ToString();           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!grvData.IsDataRow(grvData.FocusedRowHandle))
                return;

            int strID = TextUtils.ToInt(grvData.GetRowCellValue(grvData.FocusedRowHandle, "ID").ToString());

            string strName = grvData.GetRowCellValue(grvData.FocusedRowHandle, "Name").ToString();

            if (ProjectBO.Instance.CheckExist("ProjectStatusID", strID))
            {
                MessageBox.Show("Trạng thái dự án này đang được sử dụng nên không thể xóa được!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (MessageBox.Show(String.Format("Bạn có chắc muốn xóa [{0}] không?", strName), TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    ProjectStatusBO.Instance.Delete(Convert.ToInt32(strID));
                    LoadData();
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
                    ProjectStatusModel dModel;
                    if (_isAdd)
                    {
                        dModel = new ProjectStatusModel();                        
                    }
                    else
                    {
                        int ID = Convert.ToInt32(grvData.GetRowCellValue(grvData.FocusedRowHandle, "ID").ToString());
                        dModel = (ProjectStatusModel)ProjectStatusBO.Instance.FindByPK(ID);
                        
                    }                  
                    dModel.Name = txtName.Text;                   

                    if (_isAdd)
                    {
                        ProjectStatusBO.Instance.Insert(dModel);
                    }
                    else
                        ProjectStatusBO.Instance.Update(dModel);

                    LoadData();
                    SetInterface(false);
                    ClearInterface();

                    this.DialogResult = DialogResult.OK;
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

        private void grdData_DoubleClick(object sender, EventArgs e)
        {
            if (grvData.RowCount > 0 && btnEdit.Enabled == true)
                btnEdit_Click(null, null);
        }
    }
}
