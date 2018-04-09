using DevExpress.XtraGrid.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TPA.Business;
using TPA.Model;

namespace BMS
{
    public partial class frmCCostManagement : _Forms
    {
        #region Variables
        int _curentNode = 0;
        frmCshLoading _frmLoad = null;
        Thread _thSearch = null;
        int _rownIndex = 0;
        int _groupID = 0;
        string[] _paraName = new string[2];
        object[] _paraValue = new object[2];
        #endregion
        public frmCCostManagement()
        {
            InitializeComponent();
        }

        private void frmCCostManagement_Load(object sender, EventArgs e)
        {
            repositoryItemCheckEdit1.ValueChecked = 1;
            repositoryItemCheckEdit1.ValueUnchecked = 0;
            GridLocalizer.Active = new MyGridLocalizer();

            loadTree();
        }

        void loadTree()
        {
            try
            {
                DataTable tbl = LibQLSX.Select("Select * from C_CostGroup with(nolock) order by Code");

                treeData.DataSource = tbl;
                treeData.KeyFieldName = "ID";
                treeData.PreviewFieldName = "Name";
                treeData.ExpandAll();

                DevExpress.XtraTreeList.Nodes.TreeListNode currentNode = treeData.FindNodeByFieldValue("ID", _curentNode);
                treeData.SetFocusedNode(currentNode);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        private void LoadInfoSearch(int type = 0)
        {            
            try
            {
                if (type == 0)
                {
                    _groupID = TextUtils.ToInt(treeData.FocusedNode.GetValue(colIDTree));
                }
                else
                {
                    _groupID = 0;
                }
                _paraName[0] = "@C_CostGroupID"; _paraValue[0] = _groupID;
                _paraName[1] = "@TextFind"; _paraValue[1] = txtName.Text.Trim();

                DataTable Source = C_CostGroupBO.Instance.LoadDataFromSP("spGetFilterCost", "Source", _paraName, _paraValue);

                grdData.DataSource = Source;
                //Focus con trỏ chuột tại dòng đã select khi load lại dữ liệu
                if (_rownIndex >= grvData.RowCount)
                    _rownIndex = 0;
                if (_rownIndex > 0)
                    grvData.FocusedRowHandle = _rownIndex;
                grvData.SelectRow(_rownIndex);
            }
            catch (Exception ex)
            {
                grdData.DataSource = null;
                MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //try
            //{
            //    // Gọi Thread để xử lí dữ liệu
            //    _thSearch = new Thread(new ThreadStart(ProcessLoadData));
            //    _thSearch.Start();
            //    treeData.Select();
            //}
            //catch (Exception ex)
            //{
            //    return;
            //}
        }

        public void ProcessLoadData()
        {
            try
            {
                //Load trạng thái khi bắt đầu search.
                SetMode(true);
                //Truy xuất dữ liệu.       
                DataTable Source = C_CostGroupBO.Instance.LoadDataFromSP("spGetFilterCost", "Source", _paraName, _paraValue);
                //Đổ dữ liệu lên grid              
                this.BeginInvoke((MethodInvoker)delegate
                {
                    grdData.DataSource = Source;
                    //Focus con trỏ chuột tại dòng đã select khi load lại dữ liệu
                    if (_rownIndex >= grvData.RowCount)
                        _rownIndex = 0;
                    if (_rownIndex > 0)
                        grvData.FocusedRowHandle = _rownIndex;
                    grvData.SelectRow(_rownIndex);
                    //grvData.BestFitColumns();
                });
                //Kết thúc khi load xong dữ liệu
                SetMode(false);
                //Focus
                this.BeginInvoke((MethodInvoker)delegate { this.SetFocus(); });
            }
            catch (Exception ex)
            {
                SetMode(false);
                _thSearch.Abort();
                return;
            }
        }

        private void SetMode(bool IsBeginLoad)
        {
            try
            {
                if (IsBeginLoad == true)
                {
                    this.BeginInvoke((MethodInvoker)delegate { _frmLoad = new frmCshLoading(); _frmLoad.ShowDialog(); });
                }
                else
                {
                    this.BeginInvoke((MethodInvoker)delegate { _frmLoad.CloseForm(); });
                }
            }
            catch (Exception)
            {
            }
        }

        private delegate void SetControlPropertyThreadSafeDelegate(Control control, string propertyName, object propertyValue);
        public static void SetControlPropertyThreadSafe(Control control, string propertyName, object propertyValue)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new SetControlPropertyThreadSafeDelegate(SetControlPropertyThreadSafe), new object[] { control, propertyName, propertyValue });
            }
            else
            {
                control.GetType().InvokeMember(propertyName, BindingFlags.SetProperty, null, control, new object[] { propertyValue });
            }
        }

        public void SetFocus()
        {
            //txtCode.Focus();
            //treeData.Focus();
        }

        void main_LoadDataChange(object sender, EventArgs e)
        {
            LoadInfoSearch();
        }

        private void btnNewGroup_Click(object sender, EventArgs e)
        {
            frmCCostGroup frm = new frmCCostGroup();
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
                C_CostGroupModel model = (C_CostGroupModel)C_CostGroupBO.Instance.FindByPK(id);
                frmCCostGroup frm = new frmCCostGroup();
                frm.Model = model;
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

                if (C_CostBO.Instance.CheckExist("C_CostGroupID", id))
                {
                    MessageBox.Show("Nhóm này đang được sử dụng nên không thể xóa được.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (MessageBox.Show("Bạn có chắc muốn xóa nhóm [" + treeData.Selection[0].GetValue(colNameTree).ToString() + "] không?",
                      TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                C_CostGroupBO.Instance.Delete(id);
                loadTree();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(treeData.FocusedNode.GetValue(colIDTree));
            frmCCost frm = new frmCCost();
            frm.CatID = id;
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            C_CostModel model = (C_CostModel)C_CostBO.Instance.FindByPK(id);
            int catId = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colGroup));
            _rownIndex = grvData.FocusedRowHandle;

            frmCCost frm = new frmCCost();
            frm.CatID = catId;
            frm.CurrentCost = model;
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvData.DataSource == null) return;
                int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
                string code = grvData.GetFocusedRowCellValue(colCode).ToString();
                if (id == 0) return;

                //if (C_CostProductGroupLinkBO.Instance.CheckExist("C_CostID", id))
                //{
                //    MessageBox.Show("Chi phí này đang liên kết với nghành hàng nên không thể xóa được.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //    return;
                //}

                if (C_CostQuotationItemLinkBO.Instance.CheckExist("C_CostID", id))
                {
                    MessageBox.Show("Chi phí này đang liên kết với thiết bị nên không thể xóa được.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                
                if (MessageBox.Show("Bạn có chắc muốn xóa chi phí [" + grvData.GetFocusedRowCellValue(colName).ToString() + "] không?",
                      TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                //ModulesBO.Instance.Delete(id);
                C_CostModel model = (C_CostModel)C_CostBO.Instance.FindByPK(id);
                model.IsDeleted = true;
                C_CostBO.Instance.Update(model);

                LibQLSX.ExcuteSQL("delete C_CostProductGroupLink where C_CostID = " + id);
                LibQLSX.ExcuteSQL("delete C_CostQuotationLink where C_CostID = " + id);

                LoadInfoSearch();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvData.RowCount > 0)
                {
                    TextUtils.ExportExcel(grvData);
                }
            }
            catch (Exception)
            {
            }
        }

        private void treeData_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            try
            {
                int id = TextUtils.ToInt(treeData.FocusedNode.GetValue(colIDTree));
                if (id > 0)
                {
                    txtName.Text = "";
                    LoadInfoSearch();
                }
            }
            catch (Exception)
            {
            }
        }

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void grvData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == (Keys.C))
            {
                try
                {
                    string text = TextUtils.ToString(grvData.GetFocusedRowCellValue(grvData.FocusedColumn));
                    Clipboard.SetText(text);
                }
                catch (Exception)
                {
                }
            }
        }

        private void btnFindAll_Click(object sender, EventArgs e)
        {
            LoadInfoSearch(1);
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadInfoSearch(1);
            }
        }

        private void linkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grvData.SelectedRowsCount == 0) return;
            DataTable dt = LibQLSX.Select("select * from C_ProductGroup");

            foreach (int i in grvData.GetSelectedRows())
            {
                DataTable dtLink = LibQLSX.Select("select * from C_CostProductGroupLink where C_CostID = " + TextUtils.ToInt(grvData.GetRowCellValue(i, colID)));
                if(dtLink.Rows.Count > 0)
                {
                    MessageBox.Show("Đã được tạo");
                    continue;
                }
                foreach (DataRow row in dt.Rows)
                {
                    C_CostProductGroupLinkModel m = new C_CostProductGroupLinkModel();
                    m.C_CostID = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                    m.C_ProductGroupID = TextUtils.ToInt(row["ID"]);
                    C_CostProductGroupLinkBO.Instance.Insert(m);
                }
            }

            MessageBox.Show("OK");
        }
    }
}
