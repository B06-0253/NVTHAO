using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BMS.Model;
using System.IO;
using BMS.Business;
using BMS.Utils;

namespace BMS
{
    public partial class frmFileEplanGroupcs : _Forms
    {
        #region Variables
        public ProductGroupModel Model = new ProductGroupModel();
        public int ParentID = 0;
        public int CurentNode = 0;

        string DPath = "";
        string _currentPath = "";

        #endregion

        #region Contructors

        public frmFileEplanGroupcs()
        {
            InitializeComponent();
        }

        private void frmFileEplanGroupcs_Load(object sender, EventArgs e)
        {
            Expression exp = new Expression();
            DataTable dt = TextUtils.Select("ConfigSystem", new Expression("KeyName", "Eplan"));
           
            DPath = dt.Rows[0][2].ToString();
            Directory.CreateDirectory(DPath);

            loadCombo(ParentID);
            cboParent.SelectedValue = ParentID;
            cboParent.Enabled = false;

            if (Model.ID != 0)
            {
                txtName.Text = Model.Name;
                _currentPath = Model.Path;
            }
            else
            {
                if (ParentID != 0)
                {
                    DPath = ((ProductGroupModel)ProductGroupBO.Instance.FindByPK(ParentID)).Path;
                }
            }
        } 
        #endregion

        #region Functions

        void loadCombo(int id = 0)
        {
            DataTable tbl = TextUtils.Select(@"SELECT ID, Name FROM ProductGroup WITH(NOLOCK) where ID = " + id + " ORDER BY Name");
            if (tbl == null)
            {
                return;
            }
            TextUtils.PopulateCombo(cboParent, tbl.Copy(), "Name", "ID", "-- CẤP LỚN NHẤT --");
        }

        private bool ValidateForm()
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền Tên nhóm.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
            {
                DataTable dt;
                if (Model.ID > 0)
                {
                    dt = TextUtils.Select("select Name from ProductGroup where Name = '" + txtName.Text.Trim() + "' and ID <> " + Model.ID + " and ParentID = " + Model.ParentID);
                }
                else
                {
                    dt = TextUtils.Select("select Name from ProductGroup where Name = '" + txtName.Text.Trim() + "' and ParentID = " + ParentID);
                }
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Nhóm này đã tồn tại!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }
                }
            }
            //if (txtPath.Text.Trim()=="")
            //{
            //    MessageBox.Show("Xin hãy điền Đường dẫn.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return false;
            //}
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

                Model.Name = txtName.Text.Trim();
                Model.ParentID = ParentID;
                Model.Type = 3;
                if (ParentID == 0)
                {
                    Model.ParentPath = DPath;
                    Model.Path = Path.Combine(DPath, txtName.Text.Trim());
                }
                else
                {
                    Model.ParentPath = ((ProductGroupModel)ProductGroupBO.Instance.FindByPK(ParentID)).Path;
                    Model.Path = Path.Combine(Model.ParentPath, txtName.Text.Trim());
                }

                //   Model.Type = ParentID == 0 ? 1 : 0;
                Model.Description = txtDes.Text.Trim();

                if (Model.ID == 0)
                {
                    Model.CreatedDate = TextUtils.GetSystemDate();
                    Model.CreatedBy = Global.AppUserName;
                    Model.UpdatedDate = Model.CreatedDate;
                    Model.UpdatedBy = Global.AppUserName;
                    Model.ID = (int)pt.Insert(Model);

                    Directory.CreateDirectory(Model.Path);
                }
                else
                {
                    Model.UpdatedDate = TextUtils.GetSystemDate();
                    Model.UpdatedBy = Global.AppUserName;
                    pt.Update(Model);

                    if (_currentPath != Model.Path)
                        Directory.Move(_currentPath, Model.Path);
                }

                CurentNode = Model.ID;
                pt.CommitTransaction();
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
        #endregion     
    }
}