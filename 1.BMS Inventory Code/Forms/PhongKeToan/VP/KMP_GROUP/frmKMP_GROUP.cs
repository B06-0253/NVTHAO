using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IE.Model;
using IE.Business;
using IE.Utils;

namespace BMS
{
    public partial class frmKMP_GROUP : _Forms
    {
        public T_DM_KMP_GROUPModel Model = new T_DM_KMP_GROUPModel();
        public frmKMP_GROUP()
        {
            InitializeComponent();
        }

        private void frmKMP_GROUP_Load(object sender, EventArgs e)
        {
            loadCombo();
            if (Model != null && Model.ID != 0)
            {
                txtName.Text = Model.C_Name;
                txtCode.Text = Model.C_Code;
                txtDescription.Text = Model.C_MOTA;
                leParentCat.EditValue = Model.ParentID;
                //if (ModulesBO.Instance.CheckExist("ModuleGroupID", Model.ID))
                //{
                //    txtCode.Enabled = false;
                //}
                this.Text += ": " + Model.C_Code + " - " + Model.C_Name;
            }
        }
        void loadCombo()
        {
            DataTable tbl = LibIE.Select(@"SELECT ID,C_Code+'-'+C_Name as C_Code FROM T_DM_KMP_GROUP WITH(NOLOCK)");
            if (tbl == null)
            {
                return;
            }
            TextUtils.PopulateCombo(leParentCat, tbl.Copy(), "C_Code", "ID", "--Cấp lớn nhất--");
        }

        private bool ValidateForm()
        {
            if (txtCode.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền Mã.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền Tên.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            return true;
        }

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
                    Model = new T_DM_KMP_GROUPModel();
                }
                Model.C_Name = txtName.Text.Trim().ToUpper();
                Model.C_Code = txtCode.Text.Trim().ToUpper();
                Model.C_MOTA = txtDescription.Text.Trim();
                Model.ParentID = TextUtils.ToInt(leParentCat.EditValue);
                if (Model.ID == 0)
                {                
                    Model.ID = (int)pt.Insert(Model);
                }
                else
                {                   
                    pt.Update(Model);
                }

                pt.CommitTransaction();
                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            { pt.CloseConnection(); }
        }

    }
}
