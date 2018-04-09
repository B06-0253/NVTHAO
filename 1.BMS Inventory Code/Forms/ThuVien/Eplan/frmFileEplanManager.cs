using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using DevExpress.XtraGrid.Views.Grid;
using System.Reflection;
using BMS.Business;
using BMS.Model;
using System.IO;
using BMS.Utils;

namespace BMS
{
    public partial class frmFileEplanManager : _Forms
    {

        #region Biến
        int _curentNode = 0;
        frmCshLoading frmLoad = null;
        Thread thSearch = null;
        int _RownIndex = 0;
        int _catID = 0; 
        #endregion

        #region Contructors
		
        public frmFileEplanManager()
        {
            InitializeComponent();
        }

        private void frmFileEplanManager_Load(object sender, EventArgs e)
        {
            loadTree();
        } 
	#endregion

        #region Methods

        void loadTree()
        {
            try
            {
                DataTable tbl = TextUtils.Select("Select ID,Name,ParentID from ProductGroup with(nolock) WHERE (Type = 3) order by Name");

                DataRow row = tbl.NewRow();
                row["ID"] = 0;
                row["Name"] = "Thư viện Eplan";
                tbl.Rows.InsertAt(row, 0);

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

        private void LoadInfoSearch()
        {
            #region Parameter
            try
            {
                _catID = TextUtils.ToInt(treeData.FocusedNode.GetValue(colIDTree));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            #endregion

            try
            {
                // Gọi Thread để xử lí dữ liệu
                thSearch = new Thread(new ThreadStart(ProcessLoadData));
                thSearch.Start();
                treeData.Select();
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public void ProcessLoadData()
        {
            try
            {
                //Load trạng thái khi bắt đầu search.
                SetMode(true);
                //Truy xuất dữ liệu.                
                DataTable Source = TextUtils.Select("Select * from File3D WITH(NOLOCK) where ProductGroupID = " + _catID + " ORDER BY Name");
                //Đổ dữ liệu lên grid              
                this.BeginInvoke((MethodInvoker)delegate
                {
                    grdData.DataSource = Source;
                    //Focus con trỏ chuột tại dòng đã select khi load lại dữ liệu
                    if (_RownIndex >= grvData.RowCount)
                        _RownIndex = 0;
                    if (_RownIndex > 0)
                        grvData.FocusedRowHandle = _RownIndex;
                    grvData.BestFitColumns();
                });
                //Kết thúc khi load xong dữ liệu
                SetMode(false);
                //Focus
                this.BeginInvoke((MethodInvoker)delegate { this.SetFocus(); });
            }
            catch (Exception ex)
            {
                SetMode(false);
                thSearch.Abort();
                return;
            }
        }

        private void SetMode(bool IsBeginLoad)
        {
            if (IsBeginLoad == true)
            {
                this.BeginInvoke((MethodInvoker)delegate { frmLoad = new frmCshLoading(); frmLoad.ShowDialog(); });
            }
            else
            {
                this.BeginInvoke((MethodInvoker)delegate { frmLoad.CloseForm(); });
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
            treeData.Focus();
        }

        #endregion

        #region Event

        private void btnNewGroup_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(treeData.FocusedNode.GetValue(colIDTree));
            frmFileEplanGroupcs frm = new frmFileEplanGroupcs();
            frm.ParentID = id;
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
                ProductGroupModel model = (ProductGroupModel)ProductGroupBO.Instance.FindByPK(id);
                frmFileEplanGroupcs frm = new frmFileEplanGroupcs();
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

                if (File3DBO.Instance.CheckExist("ProductGroupID", id))
                {
                    MessageBox.Show("Nhóm này đang chứa file nên không thể xóa được.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (ProductGroupBO.Instance.CheckExist("ParentID", id))
                {
                    MessageBox.Show("Nhóm này là nhóm cha nên không thể xóa được.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (MessageBox.Show("Bạn có chắc muốn xóa nhóm [" + treeData.Selection[0].GetValue(colNameTree).ToString() + "] không?",
                      TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                string path = ((ProductGroupModel)ProductGroupBO.Instance.FindByPK(id)).Path;
                Directory.Delete(path);
                ProductGroupBO.Instance.Delete(id);
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
            if (id == 0) return;

            frmFileEplan frm = new frmFileEplan();
            frm.CatID = id;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadInfoSearch();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                _RownIndex = grvData.FocusedRowHandle;
                if (grvData.DataSource == null) return;
                int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
                if (id == 0) return;
                if (MessageBox.Show("Bạn có chắc muốn xóa file [" + grvData.GetFocusedRowCellValue(colName).ToString() + "] không?",
                      TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                File3DModel model = (File3DModel)File3DBO.Instance.FindByPK(id);
                model.IsDeleted = true;
                File3DBO.Instance.Update(model);
                LoadInfoSearch();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteApprove_Click(object sender, EventArgs e)
        {
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();
            try
            {
                for (int i = 0; i < grvData.RowCount; i++)
                {
                    if (grvData.DataSource == null) return;
                    int id = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                    if (id == 0) return;
                    File3DModel model = (File3DModel)File3DBO.Instance.FindByPK(id);
                    if (!model.IsDeleted) continue;

                    if (MessageBox.Show("Bạn có chắc muốn duyệt xóa file [" + grvData.GetFocusedRowCellValue(colName).ToString() + "] ?",
                          TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        continue;

                    pt.Delete("File3D", id);
                    File.Delete(model.Path);
                }
                pt.CommitTransaction();
                LoadInfoSearch();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void treeData_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            try
            {
                int id = TextUtils.ToInt(treeData.FocusedNode.GetValue(colIDTree));
                if (id > 0)
                {
                    LoadInfoSearch();
                }
            }
            catch (Exception)
            {
            }
        }

        private void treeData_DoubleClick(object sender, EventArgs e)
        {
            btnEditGroup_Click(null, null);
        }

        private void grdData_Click(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void grvData_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                bool status = TextUtils.ToBoolean(View.GetRowCellValue(e.RowHandle, colIsDeleted));
                if (status)// && e.Column == colName)
                {
                    e.Appearance.BackColor = Color.Yellow;
                }
            }
        }

        private void XemLichSu_toolstrip_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));

            if (id > 0)
            {
                frmShowHistory frm = new frmShowHistory(3);
                frm.ID = id;
                frm.Code = grvData.GetFocusedRowCellValue(colName).ToString();
                frm.ShowDialog();
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Title = "Chọn nơi lưu trữ";
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            dlg.FileName = grvData.GetFocusedRowCellValue(colName).ToString();//name;
            dlg.Filter = "Files slk (.slk)|*.slk";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.Copy(grvData.GetFocusedRowCellValue(colPath).ToString(), dlg.FileName, true);
                    MessageBox.Show("Tải xuống thành công!");
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi");
                }
            }
        } 
        #endregion
    }
}