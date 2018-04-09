using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Utils;
using BMS.Business;
using BMS.Model;

namespace BMS
{
    public partial class frmListDesigner : _Forms
    {
        private bool _isAdd;
        public string Name;
        public string Code;
        public int ModuleID;

        public frmListDesigner()
        {
            InitializeComponent();
        }

        private void frmListDesigner_Load(object sender, EventArgs e)
        {
            this.Text += ": " + Code + " - " + Name;
            try
            {
                loadCombo();
                LoadData();
            }
            catch (Exception ex)
            {
                TextUtils.ShowError(ex);
            }
        }

        #region Methods
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
            txtMaCum.Text = "";
            
            txtTenCum.Text = "";
            txtCongViec.Text = "";
            
            cboGroup.SelectedIndex = -1;
            cboUser.SelectedValue = "";
        }

        private bool checkValid()
        {
            if (cboUser.SelectedValue == null)
            {
                MessageBox.Show("Xin hãy chọn Nhân viên.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (cboGroup.SelectedIndex < 0)
            {
               MessageBox.Show("Xin hãy chọn Nhóm.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false; 
            }

            return true;
        }

        void loadCombo()
        {
            try
            {
                DataTable tblPerson = TextUtils.Select("Select LoginName, FullName from Users a with(nolock)");
                TextUtils.PopulateCombo(cboUser, tblPerson.Copy(), "FullName", "Loginname", "");
            }
            catch (Exception)
            {
            }
        }

        private void LoadData()
        {
            try
            {
                DataTable tbl = TextUtils.Select("Select * from vModuleDesigner a with(nolock) where ModuleID = " + ModuleID);
                grdData.DataSource = tbl;
                grvData.BestFitColumns();
            }
            catch (Exception)
            {
            }            
        }
        #endregion

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

            int ID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            ModuleDesignerModel dModel = (ModuleDesignerModel)ModuleDesignerBO.Instance.FindByPK(ID);

            txtMaCum.Text = dModel.MaCum;
            txtTenCum.Text = dModel.TenCum;
            txtCongViec.Text = dModel.WorkDetail;
            txtLoginName.Text = dModel.LoginName;

            cboGroup.SelectedIndex = dModel.GroupType;
            cboUser.SelectedValue = dModel.LoginName;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!grvData.IsDataRow(grvData.FocusedRowHandle))
                return;

            int strID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID).ToString());

            if (MessageBox.Show("Bạn có chắc muốn xóa người thiết kế này không?", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    ModuleDesignerBO.Instance.Delete(strID);
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
                    ModuleDesignerModel dModel;
                    if (_isAdd)
                    {
                        dModel = new ModuleDesignerModel();
                    }
                    else
                    {
                        int ID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
                        dModel = (ModuleDesignerModel)ModuleDesignerBO.Instance.FindByPK(ID);
                    }

                    dModel.MaCum = txtMaCum.Text;
                    dModel.TenCum = txtTenCum.Text;
                    dModel.WorkDetail = txtCongViec.Text;

                    dModel.GroupType = cboGroup.SelectedIndex;
                    dModel.LoginName = cboUser.SelectedValue.ToString();
                    dModel.ModuleID = ModuleID;
                    dModel.Author = dModel.LoginName;
                    //txtLoginName.Text = cboUser.SelectedValue.ToString();

                    if (_isAdd)
                    {
                        ModuleDesignerBO.Instance.Insert(dModel);
                    }
                    else
                        ModuleDesignerBO.Instance.Update(dModel);

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
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cboUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtLoginName.Text = cboUser.SelectedValue.ToString();
        }

    }
}
