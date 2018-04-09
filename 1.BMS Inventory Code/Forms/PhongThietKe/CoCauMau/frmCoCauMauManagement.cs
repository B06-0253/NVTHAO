using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using BMS.Business;
using System.Threading;
using DevExpress.XtraGrid.Localization;
using BMS.Model;
using System.IO;
using DevExpress.Utils;
using System.Diagnostics;

namespace BMS
{
    public partial class frmCoCauMauManagement : _Forms
    {
        #region Variables
        int _curentNode = 0;
        frmCshLoading _frmLoad = null;
        Thread _thSearch = null;
        int _rownIndex = 0;
        int _catID = 0;
        string[] _paraName = new string[2];
        object[] _paraValue = new object[2];
        #endregion

        #region Constuctors and Load
        public frmCoCauMauManagement()
        {
            InitializeComponent();
        }

        private void frmCoCauMauManagement_Load(object sender, EventArgs e)
        {
            DocUtils.InitFTPQLSX();
            repositoryItemCheckEdit1.ValueChecked = 1;
            repositoryItemCheckEdit1.ValueUnchecked = 0;
            GridLocalizer.Active = new MyGridLocalizer();

            loadTree();
        }
        #endregion

        #region Methods
        void loaData(int type = 0)
        {
            grvData.ActiveFilterString = "";
            grvData.HideFindPanel();
            LoadInfoSearch(type);
            grvData.ShowFindPanel();
        }

        void loadTree()
        {
            try
            {
                DataTable tbl = TextUtils.Select("Select * from CoCauGroup with(nolock) order by Code");

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
                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load dữ liệu..."))
                {
                    if (type == 0)
                    {
                        _catID = TextUtils.ToInt(treeData.FocusedNode.GetValue(colIDTree));
                    }
                    else
                    {
                        _catID = 0;
                    }
                    _paraName[0] = "@GroupID"; _paraValue[0] = _catID;
                    _paraName[1] = "@TextFind"; _paraValue[1] = txtName.Text.Trim();

                    DataTable Source = ModulesBO.Instance.LoadDataFromSP("spGetFilterCoCau1", "Source", _paraName, _paraValue);
                    Source.Columns.Add("Image", typeof(Image));
                    foreach (DataRow item in Source.Rows)
                    {
                        try
                        {
                            string filePath = TextUtils.ToString(item["ImagePath"]);
                            item["Image"] = Image.FromFile(filePath);
                        }
                        catch (Exception)
                        {
                        }
                    }

                    grdData.DataSource = Source;
                    //Focus con trỏ chuột tại dòng đã select khi load lại dữ liệu
                    if (_rownIndex >= grvData.RowCount)
                        _rownIndex = 0;
                    if (_rownIndex > 0)
                        grvData.FocusedRowHandle = _rownIndex;
                    grvData.SelectRow(_rownIndex);
                    grvData.BestFitColumns();
                }
            }
            catch (Exception ex)
            {
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
                DataTable Source = ModulesBO.Instance.LoadDataFromSP("spGetFilterCoCau1", "Source", _paraName, _paraValue);
                Source.Columns.Add("Image", typeof(Image));
                foreach (DataRow item in Source.Rows)
                {
                    try
                    {
                        string filePath = TextUtils.ToString(item["ImagePath"]);
                        item["Image"] = Image.FromFile(filePath);
                    }
                    catch (Exception)
                    {
                    }
                }
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
        #endregion

        void main_LoadDataChange(object sender, EventArgs e)
        {
            LoadInfoSearch();
        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loaData(1);
                ((TextBox)sender).Focus();
            }
        }     
 
        private void btnFindAll_Click(object sender, EventArgs e)
        {
            loaData(1);
        }

        private void treeData_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            try
            {
                int id = TextUtils.ToInt(treeData.FocusedNode.GetValue(colIDTree));
                if (id > 0)
                {
                    txtName.Text = "";
                    loaData();
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnNewGroup_Click(object sender, EventArgs e)
        {
            frmCoCauGroup frm = new frmCoCauGroup();
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
                CoCauGroupModel model = (CoCauGroupModel)CoCauGroupBO.Instance.FindByPK(id);
                frmCoCauGroup frm = new frmCoCauGroup();
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

                if (CoCauMauBO.Instance.CheckExist("CoCauGroupID", id))
                {
                    MessageBox.Show("Nhóm này đang được sử dụng nên không thể xóa được.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (MessageBox.Show("Bạn có chắc muốn xóa nhóm [" + treeData.Selection[0].GetValue(colNameTree).ToString() + "] không?",
                      TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                CoCauGroupBO.Instance.Delete(id);
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
            frmCoCauMau frm = new frmCoCauMau();
            frm.GroupID = id;
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            CoCauMauModel model = (CoCauMauModel)CoCauMauBO.Instance.FindByPK(id);
            int catId = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colGroup));
            _rownIndex = grvData.FocusedRowHandle;

            frmCoCauMau frm = new frmCoCauMau();
            frm.GroupID = catId;
            frm.CoCau = model;
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

                if (MessageBox.Show("Bạn có chắc muốn xóa cơ cấu [" + grvData.GetFocusedRowCellValue(colName).ToString() + "] không?",
                      TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                CoCauMauBO.Instance.Delete(id);
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

        private void xemTaiLiêuThiêtKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DocUtils.InitFTPQLSX();            

            string productCode = TextUtils.ToString(grvData.GetFocusedRowCellValue(colCode)).Substring(0, 10);
            string name = TextUtils.ToString(grvData.GetFocusedRowCellValue(colName));

            if (productCode.StartsWith("TPAD"))
            {
                string _pathCkFTP = "Thietke.Ck/" + productCode.Substring(0, 6) + "/" + productCode + ".Ck";
                if (!DocUtils.CheckExits(_pathCkFTP))
                {
                    MessageBox.Show("Cơ cấu này không có tài liệu thiết kế!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                frmTLTK frm = new frmTLTK();
                frm.ProductCode = productCode;
                frm.ProductName = name;
                frm.Status = 2;
                frm.Show();
            }
        }

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void btnCreateFromModule_Click(object sender, EventArgs e)

        {
            int id = TextUtils.ToInt(treeData.FocusedNode.GetValue(colIDTree));
            if (id == 0) return;

            frmTLTKCoCau frm = new frmTLTKCoCau();
            frm.GroupID = id;
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void downloadCụmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DocUtils.InitFTPQLSX();
            string code = TextUtils.ToString(grvData.GetFocusedRowCellValue(colCode));
            string oldCode = "";
            if (code.Contains("-"))
            {
                oldCode = code.Split('-')[0];
            }
            string moduleCode = code.Substring(0, 10);

            string pathCkFTP = "Thietke.Ck/" + moduleCode.Substring(0, 6) + "/" + moduleCode + ".Ck/";
            string comFtpPath = pathCkFTP + "3D." + moduleCode + "/COM." + moduleCode + "/";
            string dmvtFtpPath = pathCkFTP + "VT." + moduleCode + ".xlsm";

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang download cụm"))
                {
                    string ftpPathCum = TextUtils.GetPathOfCum(code);
                    TextUtils.DownloadFtpFolder(ftpPathCum, fbd.SelectedPath);

                    string parentPath = Path.GetDirectoryName(ftpPathCum);
                    List<string> listPath = TextUtils.GetListFolderInFtpPath(parentPath);
                    foreach (string path in listPath)
                    {
                        string pathName = Path.GetFileName(path);
                        if (oldCode == "")
                        {
                            if (pathName.StartsWith(code + "-"))
                            {
                                TextUtils.DownloadFtpFolder(path, fbd.SelectedPath);
                            }
                        }
                        else
                        {
                            if (pathName.StartsWith(oldCode))
                            {
                                TextUtils.DownloadFtpFolder(path, fbd.SelectedPath);
                            }
                        }
                    }

                    DocUtils.DownloadFile(fbd.SelectedPath, Path.GetFileName(dmvtFtpPath), dmvtFtpPath);
                    DataTable dtDMVT = TextUtils.ExcelToDatatableNoHeader(fbd.SelectedPath + "/" + Path.GetFileName(dmvtFtpPath), "DMVT");
                    File.Delete(fbd.SelectedPath + "/" + Path.GetFileName(dmvtFtpPath));
                    DataRow[] drs = dtDMVT.Select("F4 = '" + code + "'");
                    if (drs.Length > 0)
                    {
                        string stt = TextUtils.ToString(drs[0]["F1"]);
                        DataRow[] drsCum = dtDMVT.Select("F1 like '" + stt + "%' and F4 not like '" + moduleCode + "%'");
                        foreach (DataRow row in drsCum)
                        {
                            string hang = TextUtils.ToString(row["F10"]);
                            string codeVT = TextUtils.ToString(row["F4"]);
                            string unit = TextUtils.ToString(row["F6"]);
                            string localPath = fbd.SelectedPath + "/COM." + moduleCode + "/" + hang;
                            if (unit == "BỘ" && codeVT.StartsWith("TPAD.") && hang == "TPA")
                            {
                                TextUtils.DownloadFtpFolder(comFtpPath + hang + "/" + codeVT, localPath);
                            }
                            else
                            {
                                List<string> listFilePath = new List<string>();
                                listFilePath = TextUtils.GetListFileInFtpPath(comFtpPath + hang);
                                foreach (string item in listFilePath)
                                {
                                    string itemCode = Path.GetFileNameWithoutExtension(item).Replace(" ", "");
                                    if (itemCode.ToLower() == codeVT.ToLower())
                                    {
                                        DocUtils.DownloadFile(localPath, Path.GetFileName(item), item);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void xemDanhMụcVậtTưCủaCụmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string code = TextUtils.ToString(grvData.GetFocusedRowCellValue(colCode));
            string name = TextUtils.ToString(grvData.GetFocusedRowCellValue(colName));
            string moduleCode = code.Substring(0, 10);

            DataTable dtDMVT = TextUtils.Select("select * from MaterialModuleLink with(nolock) where ModuleCode = '" + moduleCode + "'");

            DataRow[] drs = dtDMVT.Select("Code = '" + code + "'");
            if (drs.Length < 0) return;

            string stt = TextUtils.ToString(drs[0]["STT"]);

            DataRow[] drs1 = dtDMVT.Select("STT like '" + stt + ".%'");
            if (drs1.Length > 0)
            {                
                DataTable dt = drs1.CopyToDataTable();
                dt.ImportRow(drs[0]);

                frmViewDMVT frm = new frmViewDMVT();
                frm.DtDMVT = dt;
                frm.Code = code;
                frm.Name = name;
                frm.Show();
            }
        }

        private void btnExeclGroup_Click(object sender, EventArgs e)
        {
            treeData.ExpandAll();
            string filepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\NhomCoCau.xls";
            treeData.ExportToXls(filepath);
            Process.Start(filepath);
        }
    }
}
