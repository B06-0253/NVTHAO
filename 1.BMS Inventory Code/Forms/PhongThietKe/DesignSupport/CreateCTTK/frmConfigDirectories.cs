using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BMS.Model;
using BMS.Business;
using System.IO;

namespace BMS
{
    public partial class frmConfigDirectories : _Forms
    {
        #region variables
        long _curentNode = 0;
        int _type;
        bool _isAdd = false;
        DesignStructureFileModel _model;
        public int ComboIndex = 0;

        #endregion

        #region Constructor
        public frmConfigDirectories()
        {
            InitializeComponent();
        }
        private void frmCreateDirection_Load(object sender, EventArgs e)
        {
            cboParent.SelectedIndex = ComboIndex;
        } 
        #endregion

        #region Method
        void loadTree()
        {
            try
            {
                DataTable tbl = TextUtils.Select("Select ID,Name,ParentID from DesignStructure with(nolock) WHERE (Type = " + _type + ")");

                treeData.DataSource = tbl;
                treeData.ExpandAll();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        void loadGrid()
        {
            int groupID = TextUtils.ToInt(treeData.FocusedNode.GetValue(colIDTree));
            DataTable dt = TextUtils.Select("DesignStructureFile", new Utils.Expression("DesignStructureID", groupID));
            grvData.DataSource = null;
            grvData.AutoGenerateColumns = false;
            grvData.DataSource = dt;

            txtName.Text = "";
            chkExist.Checked = false;
        }
        #endregion

        #region Events
        #region Folders
        private void btnNewGroup_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (treeData.FocusedNode != null)
            {
                id = TextUtils.ToInt(treeData.FocusedNode.GetValue(colIDTree));
            }
            
            frmCreate frm = new frmCreate();
            frm.ParentID = id;
            frm.Type = _type;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _curentNode = frm.CurentNode;
                loadTree();
            }
        }

        private void btnEditGroup_Click(object sender, EventArgs e)
        {
            try
            {
                int id = TextUtils.ToInt(treeData.FocusedNode.GetValue(colIDTree));
                if (id == 0) return;
                DesignStructureModel model = (DesignStructureModel)DesignStructureBO.Instance.FindByPK(id);
                frmCreate frm = new frmCreate();
                frm.Model = model;
                frm.ParentID = model.ParentID;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    _curentNode = frm.CurentNode;
                    loadTree();
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnDeleteGroup_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeData.DataSource == null) return;
                int id = (int)treeData.Selection[0].GetValue(colIDTree);
                if (id == 0) return;

                if (DesignStructureBO.Instance.CheckExist("ParentID", id) || DesignStructureFileBO.Instance.CheckExist("DesignStructureID",id))
                {
                    MessageBox.Show("Thư mục này đang được sử dụng nên không thể xóa được.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (MessageBox.Show("Bạn có chắc muốn xóa nhóm [" + treeData.Selection[0].GetValue(colNameTree).ToString() + "] không?",
                      TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                DesignStructureBO.Instance.Delete(id);
                loadTree();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboParent_SelectedIndexChanged(object sender, EventArgs e)
        {
            _type = cboParent.SelectedIndex;
            loadTree();
        }
        #endregion

        #region Files
        private void btnNew_Click(object sender, EventArgs e)
        {
            _isAdd = true;
            txtName.Text = "";
            chkExist.Checked = false;
            _model = new DesignStructureFileModel();
            SetInterface(true);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (grvData.SelectedRows.Count <= 0) return;
            _isAdd = false;            
            txtName.Text = grvData.SelectedRows[0].Cells[colFileName.Name].Value.ToString();
            chkExist.Checked = TextUtils.ToBoolean(grvData.SelectedRows[0].Cells[colExist.Name].Value.ToString());
            int iD = TextUtils.ToInt(grvData.SelectedRows[0].Cells[colID.Name].Value.ToString());
            _model = (DesignStructureFileModel)DesignStructureFileBO.Instance.FindByPK(iD);
            SetInterface(true);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (grvData.SelectedRows.Count>0)
            {
                DialogResult result = MessageBox.Show("Bạn có thật sự muốn xóa nhứng file này không?", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result==DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in grvData.SelectedRows)
                    {
                        int id = TextUtils.ToInt(row.Cells[colID.Name].Value.ToString());
                        DesignStructureFileBO.Instance.Delete(id);
                    }
                    loadGrid();
                }                
            }
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text == "")
                {
                    MessageBox.Show("Bạn hãy nhập định dạng cho file!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                int groupID = TextUtils.ToInt(treeData.FocusedNode.GetValue(colIDTree));

                if (groupID == 0)
                {
                    MessageBox.Show("Bạn hãy chọn một thư mục chứa!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                _model.DesignStructureID = groupID;
                _model.Name = txtName.Text.Trim();
                _model.Exist = chkExist.Checked;

                if (_isAdd)
                {
                    DesignStructureFileBO.Instance.Insert(_model);
                }
                else
                {
                    DesignStructureFileBO.Instance.Update(_model);
                }
                loadGrid();
                SetInterface(false);
                MessageBox.Show("Tạo định nghĩa file thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                TextUtils.ShowError(ex);
            }
        }

        private void SetInterface(bool isEdit)
        {
            btnSave.Visible = isEdit;
            btnCancel.Visible = isEdit;
            btnNew.Visible = !isEdit;
            btnEdit.Visible = !isEdit;
            btnDelete.Visible = !isEdit;
        }        

        private void treeData_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            loadGrid();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetInterface(false);
            txtName.Text = "";
            chkExist.Checked = false;
        }
        #endregion
        #endregion
    }
}