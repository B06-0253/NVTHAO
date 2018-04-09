using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BMS.Utils;
using BMS.Model;
using System.IO;
using BMS.Business;

namespace BMS
{
    public partial class frmCreate : _Forms
    {
        #region Biến

        public DesignStructureModel Model = new DesignStructureModel();
        public int ParentID = 0;
        public long CurentNode = 0;
        private string _currentPath;
        private string DPath="";
        public int Type;
        #endregion

        #region Contructors
        public frmCreate()
        {
            InitializeComponent();
        }

        private void frmCreate_Load(object sender, EventArgs e)
        {
            loadCombo(ParentID);
            cboParent.SelectedValue = ParentID;

            if (Model.ID != 0)
            {
                txtName.Text = Model.Name;                
                txtDes.Text = Model.Description;
                txtContain.Text = Model.Contain;
                txtExtension.Text = Model.Extension;
                _currentPath = Model.Path;
                Type = Model.Type;
            }
            else
            {
                if (ParentID != 0)
                {
                    DPath = ((DesignStructureModel)DesignStructureBO.Instance.FindByPK(ParentID)).Path;
                }

                //txtPath.Text = DPath;
            }
        }
        
        #endregion

        #region Method

        void loadCombo(int id = 0)
        {
            DataTable tbl = TextUtils.Select(@"SELECT ID, Name FROM DesignStructure WITH(NOLOCK) ORDER BY Name");
            if (tbl == null)
            {
                return;
            }
            TextUtils.PopulateCombo(cboParent, tbl.Copy(), "Name", "ID", "-- CẤP LỚN NHẤT --");
        } 
        #endregion

        #region Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();
            try
            {
                Model.Name = txtName.Text.Trim();
                Model.ParentID = TextUtils.ToInt(cboParent.SelectedValue);
                Model.Type = Type;
                Model.Description = txtDes.Text.Trim();
                Model.Extension = txtExtension.Text.Trim();
                Model.Contain = txtContain.Text.Trim();

                if (ParentID == 0)
                {
                    Model.ParentPath = DPath;
                    Model.Path = Path.Combine(DPath, txtName.Text.Trim());
                }
                else
                {
                    Model.ParentPath = ((DesignStructureModel)DesignStructureBO.Instance.FindByPK(ParentID)).Path;
                    Model.Path = Path.Combine(Model.ParentPath, txtName.Text.Trim());
                }

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
            this.Close();
        } 
        #endregion
    }
}