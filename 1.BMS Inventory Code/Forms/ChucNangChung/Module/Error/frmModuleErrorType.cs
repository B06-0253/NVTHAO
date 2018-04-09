using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Business;
using BMS.Model;
using BMS.Utils;

namespace BMS
{
    public partial class frmModuleErrorType : _Forms
    {
        private bool _isAdd;
        int _id;
        public int Type = -1;
        bool _isSaved = false;

        public frmModuleErrorType()
        {
            InitializeComponent();
        }

        private void frmModuleErrorType_Load(object sender, EventArgs e)
        {
            loadGroup();
            loadTree();
        }

        #region Methods

        void loadGroup()
        {
            try
            {
                DataTable tbl = TextUtils.Select("Select * from ModuleErrorType with(nolock) where Type = 0 and GroupID=0 order by Name");
                
                DataRow dr = tbl.NewRow();
                dr["Name"] = "Nhóm cha";
                dr["ID"] = 0;
                tbl.Rows.InsertAt(dr, 0);

                cboGroup.DataSource = tbl;
                cboGroup.ValueMember = "ID";
                cboGroup.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
            }
        }

        void loadTree()
        {
            try
            {
                DataTable tbl = TextUtils.Select("Select * from ModuleErrorType with(nolock) where Type = 0 order by Name");
                treeData.DataSource = tbl;
                treeData.KeyFieldName = "ID";
                treeData.PreviewFieldName = "Name";
                treeData.ExpandAll();
            }
            catch (Exception ex)
            {
            }
        }

        private void SetInterface(bool isEdit)
        {
            btnSave.Visible = isEdit;
            btnCancel.Visible = isEdit;

            btnNew.Visible = !isEdit;
            btnDelete.Visible = !isEdit;
            btnEdit.Visible = !isEdit;
        }

        private void ClearInterface()
        {
            txtName.Text = "";
            cboGroup.SelectedIndex = -1;
            _id = 0;
        }

        private bool checkValid()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Xin hãy điền tên của Loại lỗi.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
          
            if (cboGroup.SelectedIndex < 0)
            {
                MessageBox.Show("Xin hãy chọn nhóm Loại lỗi.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return true;
        }
        #endregion

        private void btnNew_Click(object sender, EventArgs e)
        {
            SetInterface(true);
            _isAdd = true;
            _id = 0;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _id = TextUtils.ToInt(treeData.FocusedNode.GetValue(colIDTree));
            string strName = ((ModuleErrorTypeModel)ModuleErrorTypeBO.Instance.FindByPK(_id)).Name;
            if (ModuleErrorTypeBO.Instance.CheckExist("GroupID", _id))
            {
                MessageBox.Show("Loại lỗi này là nhóm cha chứa các nhóm con nên không thể xóa được!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            } 
            if (ModuleErrorBO.Instance.CheckExist("PLLTQ", _id))
            {
                MessageBox.Show("Loại lỗi này đang được sử dụng nên không thể xóa được!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }          
           
            if (MessageBox.Show(String.Format("Bạn có chắc muốn xóa [{0}] không?", strName), TextUtils.Caption, 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    ModuleErrorTypeBO.Instance.Delete(_id);
                    SetInterface(false);
                    ClearInterface();
                    loadTree();
                }
                catch
                {
                    MessageBox.Show("Có lỗi xảy ra khi thực hiện thao tác, xin vui lòng thử lại sau.");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();
            try
            {
                if (!checkValid()) return;
                ModuleErrorTypeModel model;
                if (_isAdd)
                {
                    model = new ModuleErrorTypeModel();
                }
                else
                {
                    model = (ModuleErrorTypeModel)ModuleErrorTypeBO.Instance.FindByPK(_id);
                }

                //model.Type = cboType.SelectedIndex;
                model.Type = 0;
                model.Name = txtName.Text.Trim();
                model.GroupID = (int)cboGroup.SelectedValue;

                if (_isAdd)
                {
                    pt.Insert(model);
                }
                else
                {
                    pt.Update(model);
                }                

                pt.CommitTransaction();

                if ( model.GroupID==0)
                {
                    loadGroup();
                }

                loadTree();

                SetInterface(false);
                ClearInterface();

                _isSaved = true;
            }
            catch (Exception ex)
            {
                TextUtils.ShowError("Lưu trữ không thành công!", ex);
            }
            finally
            {
                pt.CloseConnection();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetInterface(false);
            ClearInterface();
        }

        private void frmModuleErrorType_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_isSaved)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (grvData0.RowCount > 0)
            //    {
            //        TextUtils.ExportExcel(grvData0);
            //    }
            //}
            //catch (Exception)
            //{

            //}
        }

        private void treeData_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _isAdd = false;
            SetInterface(true);
            _id = TextUtils.ToInt(treeData.FocusedNode.GetValue(colIDTree));
            txtName.Text = treeData.FocusedNode.GetValue(colNameTree).ToString();
            cboGroup.SelectedValue = treeData.FocusedNode.GetValue(colGroupID).ToString();
        }        
    }
}
