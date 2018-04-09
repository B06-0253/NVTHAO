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
    public partial class frmConfigTemplate : _Forms
    {
        private bool isAdd;

        public frmConfigTemplate()
        {
            InitializeComponent();
        }

        private void frmConfigTemplate_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        #region Methods
        private void SetInterface(bool isEdit)
        {
            txtCode.ReadOnly = !isEdit;
            cboType.Enabled = isEdit;

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
            cboType.SelectedIndex = 0;
            txtCode.Text = "";
            txtDescription.Text = "";
            txtPathFolderC.Text = "";            
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
                if (!isAdd)
                {
                    int strID = TextUtils.ToInt(grvData.GetRowCellValue(grvData.FocusedRowHandle, "ID").ToString());
                    dt = TextUtils.Select("select Code from Template where Code = '" + txtCode.Text.Trim() + "' and ID <> " + strID);
                }
                else
                {
                    dt = TextUtils.Select("select Code from Template where Code = '" + txtCode.Text.Trim() + "'");
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
            if (cboType.SelectedIndex < 0)
            {
                MessageBox.Show("Xin hãy chọn Kiểu biểu mẫu.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return true;
        }

        private void LoadData()
        {
            try
            {
                DataTable tbl = TextUtils.Select("Select a.*, Case when a.Type = 1 then N'BM cơ khí' when a.Type =2 then N'BM điện' else N'BM điện tử' end StatusText from Template a with(nolock)");
                grdData.DataSource = tbl;
            }
            catch (Exception)
            {
            }

        }
        #endregion

        #region Buttons Events
        private void btnNew_Click(object sender, EventArgs e)
        {
            SetInterface(true);
            isAdd = true;
            cboType.SelectedIndex = 0;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!grvData.IsDataRow(grvData.FocusedRowHandle))
                return;
            SetInterface(true);
            isAdd = false;

            int ID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            TemplateModel dModel = (TemplateModel)TemplateBO.Instance.FindByPK(ID);

            txtName.Text = dModel.Name;
            txtCode.Text = dModel.Code;
            cboType.SelectedIndex = dModel.Type;
            txtDescription.Text = dModel.Description;
            txtPathFolderC.Text = dModel.PathFolderC;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!grvData.IsDataRow(grvData.FocusedRowHandle))
                return;

            int strID = TextUtils.ToInt(grvData.GetRowCellValue(grvData.FocusedRowHandle, "ID").ToString());

            string strName = grvData.GetFocusedRowCellValue(colCode).ToString();

            //if (WorksBO.Instance.CheckExist("CustomerID", strID))
            //{
            //    MessageBox.Show("Khách hàng này đang được sử dụng nên không thể xóa được!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}

            if (MessageBox.Show(String.Format("Bạn có chắc muốn xóa [{0}] không?", strName), TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    TemplateBO.Instance.Delete(Convert.ToInt32(strID));
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
                    TemplateModel dModel;
                    if (isAdd)
                    {
                        dModel = new TemplateModel();
                    }
                    else
                    {
                        int ID = Convert.ToInt32(grvData.GetRowCellValue(grvData.FocusedRowHandle, "ID").ToString());
                        dModel = (TemplateModel)TemplateBO.Instance.FindByPK(ID);
                    }
                    dModel.Code = txtCode.Text;
                    dModel.Name = txtName.Text;
                    dModel.Type = cboType.SelectedIndex;
                    dModel.Description = txtDescription.Text;
                    dModel.PathFolderC = txtPathFolderC.Text;
                
                    if (isAdd)
                    {
                        TemplateBO.Instance.Insert(dModel);
                    }
                    else
                        TemplateBO.Instance.Update(dModel);

                    LoadData();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdData_DoubleClick(object sender, EventArgs e)
        {
            if (grvData.RowCount > 0 && btnEdit.Enabled == true)
                btnEdit_Click(null, null);
        }
        #endregion

        
    }
}
