using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Model;
using BMS.Utils;
using BMS.Business;

namespace BMS
{
    public partial class frmCoCauGroup : _Forms
    {
        #region Variables
        public CoCauGroupModel Model = new CoCauGroupModel();
        public int CurentNode = 0;
        #endregion

        public frmCoCauGroup()
        {
            InitializeComponent();
        }

        private void frmCoCauGroup_Load(object sender, EventArgs e)
        {
            loadCombo();
            if (Model != null && Model.ID != 0)
            {
                txtName.Text = Model.Name;
                txtCode.Text = Model.Code;
                txtDescription.Text = Model.Description;
                leParentCat.EditValue = Model.ParentID;
                if (CoCauMauBO.Instance.CheckExist("CoCauGroupID", Model.ID))
                {
                    txtCode.Enabled = false;
                }
                this.Text += ": " + Model.Code + " - " + Model.Name;
            }
        }

        #region Functions
        void loadCombo()
        {
            DataTable tbl = TextUtils.Select(@"SELECT ID,Code FROM CoCauGroup WITH(NOLOCK) where ParentID = 0 ORDER BY Code");
            if (tbl == null)
            {
                return;
            }
            TextUtils.PopulateCombo(leParentCat, tbl.Copy(), "Code", "ID", "--Cấp lớn nhất--");
        }

        private bool ValidateForm()
        {
            if (txtCode.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền Mã.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
            {
                DataTable dt = new DataTable();
                if (Model != null)
                {
                    if (Model.ID > 0)
                    {
                        dt = TextUtils.Select("select Code from CoCauGroup where Code = '" + txtCode.Text.Trim() + "' and ID <> " + Model.ID);
                    }
                }
                else
                {
                    dt = TextUtils.Select("select Code from CoCauGroup where Code = '" + txtCode.Text.Trim() + "'");
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
            return true;
        }
        #endregion


        private void btnSave_Click(object sender, EventArgs e)
        {
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();
            try
            {
                if (!ValidateForm())
                    return;

                if (Model.ID == 0)
                {
                    Model = new CoCauGroupModel();
                }
                Model.Name = txtName.Text.Trim().ToUpper();
                Model.Code = txtCode.Text.Trim().ToUpper();
                Model.Description = txtDescription.Text.Trim();
                Model.ParentID = TextUtils.ToInt(leParentCat.EditValue);
                if (Model.ID == 0)
                {
                    Model.CreatedDate = TextUtils.GetSystemDate();
                    Model.CreatedBy = Global.AppUserName;
                    Model.UpdatedDate = Model.CreatedDate;
                    Model.UpdatedBy = Global.AppUserName;
                    Model.ID = (int)pt.Insert(Model);
                }
                else
                {
                    Model.UpdatedDate = TextUtils.GetSystemDate();
                    Model.UpdatedBy = Global.AppUserName;
                    pt.Update(Model);
                }

                pt.CommitTransaction();

                CurentNode = Model.ID;
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            { 
                pt.CloseConnection(); 
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
