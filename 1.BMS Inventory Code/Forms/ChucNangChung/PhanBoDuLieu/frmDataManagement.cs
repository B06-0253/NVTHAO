using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Model;
using BMS.Business;
using System.IO;
using BMS.Utils;

namespace BMS
{
    public partial class frmDataManagement : _Forms
    {
        #region variables
        long _curentNode = 0;
        int _departmentIndex = -1;
        bool _isAdd = false;
        #endregion

        public frmDataManagement()
        {
            InitializeComponent();
        }

        private void frmDataManagement_Load(object sender, EventArgs e)
        {
            loadTree();
            loadListFileGrid();
            loadDepartment();
        }      

        #region Method
        void loadTree()
        {
            try
            {
                DataTable tbl = TextUtils.Select("Select ID,Name,ParentID from PBDLStructure with(nolock) WHERE (DepartmentID = " + TextUtils.ToInt(cboParent.SelectedValue) + ")");
                treeData.DataSource = tbl;
                treeData.ExpandAll();
            }
            catch (Exception ex)
            {                
            }
        }

        void loadGrid()
        {
            int groupID = TextUtils.ToInt(treeData.FocusedNode != null ? treeData.FocusedNode.GetValue(colIDTree) : 0);
            DataTable dt = TextUtils.Select("vPBDL_Structure_File", new Expression("PBDLStructureID", groupID));
            grvData.DataSource = null;
            grvData.AutoGenerateColumns = false;
            grvData.DataSource = dt;
        }

        void loadListFileGrid()
        {
            //int groupID = TextUtils.ToInt(treeData.FocusedNode != null ? treeData.FocusedNode.GetValue(colIDTree) : 0);
            //PBDLStructureModel model = (PBDLStructureModel)PBDLStructureBO.Instance.FindByPK(groupID);
            //if (model == null) return;
            DataTable dt = new DataTable();
            //if (model.FolderType!=3)
            //{
            //    dt = TextUtils.Select("PBDLFile", new Expression("FileType", model.FolderType));
            //}
            //else
            //{
                dt = TextUtils.Select("PBDLFile", new Expression("ID", 0, ">"));
            //}
            
            grvListFile.DataSource = null;
            grvListFile.AutoGenerateColumns = false;
            grvListFile.DataSource = dt;
        }

        void loadDepartment()
        {
            cboParent.DataSource = null;
            DataTable dt = TextUtils.Select("Department", new Expression("ID", 0, ">"));
            cboParent.DataSource = dt;
            cboParent.DisplayMember = "Name";
            cboParent.ValueMember = "ID";
        }
        #endregion

        #region Events

        private void treeData_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            loadGrid();
            //loadListFileGrid();
        }

        private void cboParent_SelectedIndexChanged(object sender, EventArgs e)
        {
            grvData.DataSource = null;
            loadTree();
        }

        #region Config folder
        private void btnNewGroup_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(treeData.FocusedNode != null ? treeData.FocusedNode.GetValue(colIDTree) : 0);
            frmPBDLStructure frm = new frmPBDLStructure();
            frm.ParentID = id;
            frm.DepartmentID = TextUtils.ToInt(cboParent.SelectedValue);
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
                PBDLStructureModel model = (PBDLStructureModel)PBDLStructureBO.Instance.FindByPK(id);
                frmPBDLStructure frm = new frmPBDLStructure();
                frm.Model = model;
                frm.ParentID = model.ParentID;
                frm.DepartmentID = TextUtils.ToInt(cboParent.SelectedValue);
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

                if (PBDLStructureBO.Instance.CheckExist("ParentID", id) || PBDLStructureFileLinkBO.Instance.CheckExist("PBDLStructureID", id))
                {
                    MessageBox.Show("Thư mục này đang được sử dụng nên không thể xóa được.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (MessageBox.Show("Bạn có chắc muốn xóa thư mục [" + treeData.Selection[0].GetValue(colNameTree).ToString() + "] không?",
                      TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                PBDLStructureBO.Instance.Delete(id);
                loadTree();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion Config folder

        #region Config File
        private void btnNew_Click(object sender, EventArgs e)
        {
            frmPBDLFile frm = new frmPBDLFile();
            if (frm.ShowDialog()==DialogResult.OK)
            {
                loadListFileGrid();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvListFile.SelectedRows[0].Cells[colIDListFile.Index].Value);
            if (id == 0) return;
            PBDLFileModel model = (PBDLFileModel)PBDLFileBO.Instance.FindByPK(id);
            frmPBDLFile frm = new frmPBDLFile();
            frm.FModel = model;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                loadListFileGrid();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa file này?", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int id = TextUtils.ToInt(grvListFile.SelectedRows[0].Cells[colIDListFile.Index].Value);
                PBDLFileBO.Instance.Delete(id);
                loadListFileGrid();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            int groupID = TextUtils.ToInt(treeData.FocusedNode != null ? treeData.FocusedNode.GetValue(colIDTree) : 0);
            if (groupID == 0) return;
            if (grvListFile.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in grvListFile.SelectedRows)
                {
                    int fileID = TextUtils.ToInt(row.Cells[colIDListFile.Index].Value);
                    DataTable dt = TextUtils.Select("PBDLStructureFileLink", new Expression("PBDLStructureID", groupID).And(new Expression("PBDLFileID", fileID)));
                    if (dt.Rows.Count > 0) continue;
                    PBDLStructureFileLinkModel model = new PBDLStructureFileLinkModel();
                    model.PBDLFileID = fileID;
                    model.PBDLStructureID = groupID;
                    PBDLStructureFileLinkBO.Instance.Insert(model);
                }
                loadGrid();
            }
        }
        #endregion            

        private void btnDeleteLink_Click(object sender, EventArgs e)
        {
            if (grvData.SelectedRows.Count == 0) return;           
            int iD = TextUtils.ToInt(grvData.SelectedRows[0].Cells[colIDListFile.Index].Value);
            if (iD == 0) return;
            string fileName = grvData.SelectedRows[0].Cells[colFileName.Index].Value.ToString();
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa file [" + fileName + "] này không?",
                TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                PBDLStructureFileLinkBO.Instance.Delete(iD);
                loadGrid();
            }
        }

        #endregion
    }
}
