using IE.Business;
using IE.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BMS
{
    public partial class frmKMP_GROUP_management : _Forms
    {
        int _curentNode = 0;
        public frmKMP_GROUP_management()
        {
            InitializeComponent();
        }

        private void frmKMPmanagement_Load(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Location = new Point(this.Location.X, 0);
            loadTree();
            loadKMP();
        }

        void loadTree()
        {
            try
            {
                DataTable tbl = LibIE.Select("Select * from T_DM_KMP_GROUP with(nolock) order by C_Code");

                treeData.DataSource = tbl;
                treeData.KeyFieldName = "ID";
                treeData.PreviewFieldName = "C_Name";
                treeData.ExpandAll();

                DevExpress.XtraTreeList.Nodes.TreeListNode currentNode = treeData.FindNodeByFieldValue("ID", _curentNode);
                treeData.SetFocusedNode(currentNode);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        void loadKMP()
        {
            string sql = "SELECT [PK_ID],[C_MA],[C_MOTA] FROM [T_DM_KMP] order by [C_MA]";
            DataTable dt = LibIE.Select(sql);
            grdData.DataSource = dt;
        }

        void loadLink()
        {
            int groupID = TextUtils.ToInt(treeData.FocusedNode.GetValue(colIDTree));
            string sql = "SELECT [PK_ID],[C_MA],[C_MOTA] from T_DM_KMP where FK_GROUP = " + groupID + " order by [C_MA]";
            DataTable dt = LibIE.Select(sql);
            grdLink.DataSource = dt;
        }

        private void treeData_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (treeData.DataSource == null) return;
            string code = TextUtils.ToString(treeData.Selection[0].GetValue(colCodeTree));
            if (code == "") return;
            label1.Text = "Danh sách khoản mục phí của nhóm " + code;
            loadLink();
            grvData.FocusedRowHandle = -1;
        }

        private void btnNewGroup_Click(object sender, EventArgs e)
        {
            frmKMP_GROUP frm = new frmKMP_GROUP();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //_curentNode = treeData.GetNodeIndex(treeData.FocusedNode);
                loadTree();
            }
        }

        private void btnEditGroup_Click(object sender, EventArgs e)
        {
            try
            {
                int id = TextUtils.ToInt(treeData.FocusedNode.GetValue(colIDTree));
                if (id == 0) return;
                _curentNode = treeData.GetNodeIndex(treeData.FocusedNode);

                T_DM_KMP_GROUPModel model = (T_DM_KMP_GROUPModel)T_DM_KMP_GROUPBO.Instance.FindByPK(id);
                frmKMP_GROUP frm = new frmKMP_GROUP();
                frm.Model = model;
                if (frm.ShowDialog() == DialogResult.OK)
                {
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

                if (T_DM_FCMBO.Instance.CheckExist("FK_GROUP", id))
                {
                    MessageBox.Show("Nhóm này đang chứa danh sách khoản mục nên không thể xóa được.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (MessageBox.Show("Bạn có chắc muốn xóa nhóm [" + treeData.Selection[0].GetValue(colNameTree).ToString() + "] không?",
                      TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                T_DM_KMP_GROUPBO.Instance.Delete(id);
                loadTree();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (treeData.DataSource == null) return;
            int id = TextUtils.ToInt(treeData.Selection[0].GetValue(colIDTree));
            if (id == 0) return;
            int count = 0;
            foreach (int i in grvData.GetSelectedRows())
            {
                int pkKMP = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                string sql = "update [T_DM_KMP] set [FK_GROUP] = " + id + " where [PK_ID] = " + pkKMP;
                LibIE.ExcuteSQL(sql);
                count++;
            }
            if (count > 0)
            {
                //MessageBox.Show("Thêm khoản mục phí vào nhóm thành công.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadLink();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (treeData.DataSource == null) return;
            int id = (int)treeData.Selection[0].GetValue(colIDTree);
            if (id == 0) return;
            int pkKMP = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (MessageBox.Show("Bạn có chắc muốn xóa chi phí [" +  TextUtils.ToInt(grvData.GetFocusedRowCellValue(colLinkName)) + "] ra khỏi nhóm không?",
                     TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            string sql = "update [T_DM_KMP] set [FK_GROUP] = 0 where [PK_ID] = " + pkKMP;
            LibIE.ExcuteSQL(sql);
            MessageBox.Show("Khoản mục phí ra khỏi nhóm thành công.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadLink();
        }
    }
}
