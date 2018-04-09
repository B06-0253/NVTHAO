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
using System.IO;
using BMS.Business;
using Microsoft.VisualBasic;

namespace BMS
{
    public partial class frmFile3DGroupcs : _Forms
    {
        #region Variables
        public ProductGroupModel Model = new ProductGroupModel();
        public int ParentID = 0;
        public int CurentNode = 0;
        string DPath ="";
        string _currentPath="";

        #endregion

        #region Constructor and Load
        public frmFile3DGroupcs()
        {
            InitializeComponent();
        }

        private void frmFile3DGroupcs_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = TextUtils.Select("ConfigSystem", new Expression("KeyName", "3D"));
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
            catch (Exception ex)
            {
                TextUtils.ShowError(ex);
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
                    dt = TextUtils.Select("select Name from ProductGroup where Name = '" + txtName.Text.Trim() + "' and ID <> " + Model.ID + " and ParentID = "+Model.ParentID);
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

                Model.Name = txtName.Text.Trim().ToUpper();
                Model.ParentID = ParentID;

                if (ParentID == 0)
                {
                    Model.ParentPath = DPath;
                    Model.Path = Path.Combine(DPath, txtName.Text.Trim());
                }
                else
                {
                    Model.ParentPath = ((ProductGroupModel)ProductGroupBO.Instance.FindByPK(ParentID)).Path;
                    Model.Path = Path.Combine(Model.ParentPath, txtName.Text.Trim().ToUpper());
                }

                Model.Description = txtDes.Text.Trim();
                Model.Type = 2;

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
                    {
                        Directory.Move(_currentPath, Model.Path);
                    }
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

        private void txtName_EditValueChanged(object sender, EventArgs e)
        {
            //txtPath.Text = Path.Combine(txtPath.Text.Trim(), txtName.Text.Trim());
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            //try
            //{
            //    if (ParentID==0)
            //    {
            //        txtPath.Text = Path.Combine(DPath, txtName.Text.Trim());
            //    }
            //    else
            //    {
            //         txtPath.Text = Path.Combine(((ProductGroupModel)ProductGroupBO.Instance.FindByPK(ParentID)).Path, txtName.Text.Trim());
            //    }
                
            //}
            //catch (Exception)
            //{
                
            //}
        }
        #endregion
    }
}
