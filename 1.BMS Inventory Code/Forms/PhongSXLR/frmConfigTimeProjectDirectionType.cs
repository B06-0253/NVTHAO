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
using TPA;

namespace BMS
{
    public partial class frmConfigTimeProjectDirectionType : _Forms
    {
        private bool isAdd;
        public frmConfigTimeProjectDirectionType()
        {
            InitializeComponent();
        }

        private void frmConfigTimeProjectDirectionType_Load(object sender, EventArgs e)
        {
            try
            {
                loadParent();
                LoadData();
            }
            catch (Exception ex)
            {
                TextUtils.ShowError(ex);
            }
        }

        #region Methods
        void loadParent()
        {
            DataTable dt = LibQLSX.Select("select * from ProjectDirectionType with(nolock)");
            cboParent.Properties.DataSource = dt;
            cboParent.Properties.DisplayMember = "Name";
            cboParent.Properties.ValueMember = "ID";
        }

        private void SetInterface(bool isEdit)
        {
            txtCode.ReadOnly = !isEdit;

            treeData.Enabled = !isEdit;

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
            txtQty.EditValue = 0;
            txtTimeDK.EditValue = 0;
        }

        private bool checkValid()
        {
            if (txtCode.Text == "")
            {
                MessageBox.Show("Xin hãy điền Mã.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
            {
                DataTable dt;
                if (!isAdd)
                {
                    int strID = TextUtils.ToInt(treeData.FocusedNode.GetValue(colIDTree));
                    dt = LibQLSX.Select("select Code from ProjectDirectionType where Code = '" + txtCode.Text.Trim() + "' and ID <> " + strID);
                }
                else
                {
                    dt = LibQLSX.Select("select Code from ProjectDirectionType where Code = '" + txtCode.Text.Trim() + "'");
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
     
        private void LoadData()
        {
            try
            {
                DataTable tbl = LibQLSX.Select("Select a.* from vProjectDirectionType a with(nolock)");
                //grdData.DataSource = tbl;

                treeData.DataSource = tbl;
                treeData.ExpandAll();
            }
            catch (Exception)
            {
            }
        }
        #endregion

        private void btnNew_Click(object sender, EventArgs e)
        {
            SetInterface(true);
            isAdd = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(treeData.FocusedNode.GetValue(colIDTree));
            if (ID < 0) return;
            SetInterface(true);
            isAdd = false;
            //txtName.Text = grvData.GetRowCellValue(grvData.FocusedRowHandle, "Name").ToString();
            //txtCode.Text = grvData.GetRowCellValue(grvData.FocusedRowHandle, "Code").ToString();
            //txtQty.EditValue = TextUtils.ToDecimal(grvData.GetFocusedRowCellValue(colQty1));
            //txtTimeDK.EditValue = TextUtils.ToDecimal(grvData.GetFocusedRowCellValue(colTimeDK1));

            txtName.Text = TextUtils.ToString(treeData.FocusedNode.GetValue(colName));
            txtCode.Text = TextUtils.ToString(treeData.FocusedNode.GetValue(colCode));
            txtQty.EditValue = TextUtils.ToDecimal(treeData.FocusedNode.GetValue(colQty));
            txtTimeDK.EditValue = TextUtils.ToDecimal(treeData.FocusedNode.GetValue(colTimeDK));
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(treeData.FocusedNode.GetValue(colIDTree));
            if (ID < 0) return;

            //int strID = TextUtils.ToInt(grvData.GetRowCellValue(grvData.FocusedRowHandle, "ID").ToString());
            //string strName = grvData.GetRowCellValue(grvData.FocusedRowHandle, "Name").ToString();

            int strID = TextUtils.ToInt(treeData.FocusedNode.GetValue(colIDTree));
            string strName =TextUtils.ToString(treeData.FocusedNode.GetValue(colName));

            //if (UsersBO.Instance.CheckExist("DepartmentID", strID))
            //{
            //    MessageBox.Show("Phòng ban này đang được sử dụng nên không thể xóa được!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}

            if (MessageBox.Show(String.Format("Bạn có chắc muốn xóa [{0}] không?", strName), TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    ProjectDirectionTypeBO.Instance.Delete(Convert.ToInt32(strID));
                    LoadData();
                    loadParent();
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
                    ProjectDirectionTypeModel dModel;
                    if (isAdd)
                    {
                        dModel = new ProjectDirectionTypeModel();                       
                    }
                    else
                    {
                        //int ID = Convert.ToInt32(grvData.GetFocusedRowCellValue(colID).ToString());
                        int ID = Convert.ToInt32(treeData.FocusedNode.GetValue(colIDTree));
                        dModel = (ProjectDirectionTypeModel)ProjectDirectionTypeBO.Instance.FindByPK(ID);                       
                    }

                    dModel.Code = txtCode.Text;
                    dModel.Name = txtName.Text;
                    dModel.Qty = TextUtils.ToDecimal(txtQty.EditValue);
                    dModel.TimeDK = TextUtils.ToDecimal(txtTimeDK.EditValue);
                    dModel.ParentID = TextUtils.ToInt(cboParent.EditValue);

                    if (isAdd)
                    {
                        ProjectDirectionTypeBO.Instance.Insert(dModel);
                    }
                    else
                        ProjectDirectionTypeBO.Instance.Update(dModel);

                    LoadData();
                    loadParent();
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

        private void grdData_DoubleClick(object sender, EventArgs e)
        {
            if (treeData.FocusedNode != null && btnEdit.Enabled == true)
                btnEdit_Click(null, null);
        }

        private void treeData_DoubleClick(object sender, EventArgs e)
        {
            if (treeData.FocusedNode != null && btnEdit.Enabled == true)
                btnEdit_Click(null, null);
        }
    }
}
