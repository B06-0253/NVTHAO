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
using System.IO;
using BMS.Business;

namespace BMS
{
    public partial class frmPBDLStructure : _Forms
    {
          #region Biến

        public PBDLStructureModel Model = new PBDLStructureModel();
        public int ParentID = 0;
        public long CurentNode = 0;
        private string _currentPath;
        private string DPath = "";
        public int DepartmentID;
        #endregion

        #region Contructors
        public frmPBDLStructure()
        {
            InitializeComponent();
        }  
        private void frmPBDLStructure_Load(object sender, EventArgs e)
        {
            loadCombo(ParentID);
            cboParent.SelectedValue = ParentID;

            if (Model.ID != 0)
            {
                txtName.Text = Model.Name;
                txtDes.Text = Model.Description;
                _currentPath = Model.Path;
                cboFolderType.SelectedIndex = Model.FolderType;
            }
            else
            {
                if (ParentID != 0)
                {
                    DPath = ((PBDLStructureModel)PBDLStructureBO.Instance.FindByPK(ParentID)).Path;
                }

                //txtPath.Text = DPath;
            }
        }
        #endregion

        #region Method

        void loadCombo(int id = 0)
        {
            DataTable tbl = TextUtils.Select(@"SELECT ID, Name FROM PBDLStructure WITH(NOLOCK) ORDER BY Name");
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
                Model.DepartmentID = DepartmentID;
                Model.Description = txtDes.Text.Trim();
                Model.FolderType = cboFolderType.SelectedIndex;

                if (ParentID == 0)
                {
                    Model.ParentPath = DPath;
                    Model.Path = Path.Combine(DPath, txtName.Text.Trim());
                }
                else
                {
                    Model.ParentPath = ((PBDLStructureModel)PBDLStructureBO.Instance.FindByPK(ParentID)).Path;
                    Model.Path = Path.Combine(Model.ParentPath, txtName.Text.Trim());
                }

                if (Model.ID == 0)
                {
                    Model.ID = (int)pt.Insert(Model);
                }
                else
                {
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
