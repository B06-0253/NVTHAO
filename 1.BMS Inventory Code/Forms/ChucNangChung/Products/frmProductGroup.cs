using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Utils;
using BMS.Model;
using BMS.Business;

namespace BMS
{
    public partial class frmProductGroup : _Forms
    {
        public int CurentNode;
        public ProductGroupModel Model = new ProductGroupModel();

        public frmProductGroup()
        {
            InitializeComponent();
        }

        private void frmProductGroup_Load(object sender, EventArgs e)
        {
            loadCombo();
            if (Model != null)
                if (Model.ID != 0)
                {
                    txtName.Text = Model.Name;
                    txtCode.Text = Model.Code;
                    txtDescription.Text = Model.Description;
                    leParentCat.EditValue = Model.ParentID;
                    if (ProductsBO.Instance.CheckExist("ProductGroupID", Model.ID))
                    {
                        txtCode.Enabled = false;
                    }
                    this.Text += ": " + Model.Code + " - " + Model.Name;
                }
        }

        #region Functions
        void loadCombo()
        {
            DataTable tbl = TextUtils.Select(@"SELECT ID,Code FROM ProductGroup WITH(NOLOCK) where ParentID = 0 ORDER BY Code");
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
                //Kiểm tra định dạng
                DataTable dt = new DataTable();
               
                if (Model.ID > 0)
                {
                    dt = TextUtils.Select("select Code from ProductGroup where Code = '" + txtCode.Text.Trim() + "' and ID <> " + Model.ID);
                }
                else
                {
                    dt = TextUtils.Select("select Code from ProductGroup where Code = '" + txtCode.Text.Trim() + "'");
                }
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Mã này đã tồn tại!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
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

        #region Buttons Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();
            try
            {
                if (!ValidateForm())
                    return;

                if (Model == null)
                {
                    Model = new ProductGroupModel();
                }
                Model.Name = txtName.Text.Trim().ToUpper();
                Model.Code = txtCode.Text.Trim().ToUpper();
                Model.Description = txtDescription.Text.Trim();
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

                CurentNode = Model.ID;
                this.DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            { pt.CloseConnection(); }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion       
    }
}
