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
using BMS.Business;
using System.Collections;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using System.Reflection;
using System.Threading;
using DevExpress.XtraGrid.Views.Grid;
using System.IO;
using System.Diagnostics;
using DevExpress.XtraGrid.Localization;
using iTextSharp;
using iTextSharp.text.pdf;
using DevExpress.Utils;
using IOEx;

namespace BMS
{
    public partial class frmModuleManager : _Forms
    {
        #region Variables
        int _curentNode = 0;
        frmCshLoading _frmLoad = null;
        Thread _thSearch = null;
        int _rownIndex = 0;
        int _catID = 0;
        string[] _paraName = new string[3];
        object[] _paraValue = new object[3];
        #endregion

        #region Constructors
        public frmModuleManager()
        {
            InitializeComponent();            
        }

        private void frmModuleManager_Load(object sender, EventArgs e)
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
                DataTable tbl = TextUtils.Select("Select * from ModuleGroup with(nolock) order by Code");

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
            #region Parameter
            try
            {
                if (type == 0)
                {
                    _catID = TextUtils.ToInt(treeData.FocusedNode.GetValue(colIDTree));
                }
                else
                {
                    _catID = 0;
                }
                _paraName[0] = "@ModuleGroupID"; _paraValue[0] = _catID;
                _paraName[1] = "@Code"; _paraValue[1] = txtCode.Text.Trim();
                _paraName[2] = "@Name"; _paraValue[2] = txtName.Text.Trim();
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
                _thSearch = new Thread(new ThreadStart(ProcessLoadData));
                _thSearch.Start();
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
                DataTable Source = ModulesBO.Instance.LoadDataFromSP("spGetFilterModule", "Source", _paraName, _paraValue);
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

        private void repalaceText(Microsoft.Office.Interop.Word.Document doc, string oldText, string newText)
        {
            foreach (Microsoft.Office.Interop.Word.Range myStoryRange in doc.StoryRanges)
            {
                var _with1 = myStoryRange.Find;
                _with1.Text = oldText;
                _with1.Replacement.Text = newText;
                _with1.Wrap = Microsoft.Office.Interop.Word.WdFindWrap.wdFindContinue;
                _with1.Execute(Replace: Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll);
            }
        }

        #endregion

        #region Events
        #region Buttons
        void main_LoadDataChange(object sender, EventArgs e)
        {
            LoadInfoSearch();
        }

        #region Module Group Events
        private void btnNewGroup_Click(object sender, EventArgs e)
        {
            frmModuleGroup frm = new frmModuleGroup();
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
                ModuleGroupModel model = (ModuleGroupModel)ModuleGroupBO.Instance.FindByPK(id);
                frmModuleGroup frm = new frmModuleGroup();
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

                if (ModulesBO.Instance.CheckExist("ModuleGroupID", id))
                {
                    MessageBox.Show("Nhóm Module này đang được sử dụng nên không thể xóa được.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (MessageBox.Show("Bạn có chắc muốn xóa nhóm [" + treeData.Selection[0].GetValue(colNameTree).ToString() + "] không?",
                      TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                ModuleGroupBO.Instance.Delete(id);
                loadTree();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Module Events
        private void btnNew_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(treeData.FocusedNode.GetValue(colIDTree));
            frmModule frm = new frmModule();
            frm.CatID = id;
            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    LoadInfoSearch();
            //}
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            ModulesModel model = (ModulesModel)ModulesBO.Instance.FindByPK(id);
            int catId = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colGroup));
            _rownIndex = grvData.FocusedRowHandle;

            frmModule frm = new frmModule();
            frm.CatID = catId;
            frm.Module = model;
            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    LoadInfoSearch();
            //}
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvData.DataSource == null) return;
                int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
                string code = grvData.GetFocusedRowCellValue(colCode).ToString();
                if (id == 0) return;

                if (ModuleFilmBO.Instance.CheckExist("ModuleID", id))
                {
                    MessageBox.Show("Sản phẩm này đang chứa Film in nên không thể xóa được.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (ModuleTemBO.Instance.CheckExist("ModuleID", id))
                {
                    MessageBox.Show("Sản phẩm này đang chứa Tem nên không thể xóa được.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                //BaiThucHanhModule,ProductModuleLink
                if (BaiThucHanhModuleBO.Instance.CheckExist("Code", code))
                {
                    MessageBox.Show("Có bài thực hành đang chứa module này nên không thể xóa được.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (ProductModuleLinkBO.Instance.CheckExist("Code", code))
                {
                    MessageBox.Show("Có thiết bị đang chứa module này nên không thể xóa được.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (MessageBox.Show("Bạn có chắc muốn xóa module [" + grvData.GetFocusedRowCellValue(colName).ToString() + "] không?",
                      TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                ModulesBO.Instance.Delete(id);
                LoadInfoSearch();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            ModulesModel model = (ModulesModel)ModulesBO.Instance.FindByPK(id);
            int catId = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colGroup));

            frmModule frm = new frmModule();
            frm.CatID = catId;
            frm.Module = model;
            frm.IsCopy = true;
            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    LoadInfoSearch();
            //} 
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }
        #endregion

        private void btnListError_Click(object sender, EventArgs e)
        {
            frmErrorManager frm = new frmErrorManager();
            TextUtils.OpenForm(frm);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            frmImportExcel frm = new frmImportExcel();
            frm.ShowDialog();
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
            Close();
        }   
        #endregion        

        #region TreeList
        private void treeData_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            try
            {
                int id = TextUtils.ToInt(treeData.FocusedNode.GetValue(colIDTree));
                if (id > 0)
                {
                    txtCode.Text = txtName.Text = "";
                    loaData();
                }
            }
            catch (Exception)
            {
            }
        }

        private void treeData_DoubleClick(object sender, EventArgs e)
        {
            //btnEditGroup_Click(null,null);
        }
        #endregion

        #region GridView
        private void grvData_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0) return;
            GridView View = sender as GridView;
            int status = TextUtils.ToInt(View.GetRowCellValue(e.RowHandle, colS));

            if (status == 1)
            {
                e.Appearance.ForeColor = Color.Blue;
            }
            if (status == 2)
            {
                e.Appearance.ForeColor = Color.Red;
            }

            //bôi xanh những module tạo trong ngày
            //DateTime date = TextUtils.ToDate(View.GetRowCellValue(e.RowHandle, colCreatedDate).ToString()).Date;
            //if (date == DateTime.Now.Date)
            //{
            //    e.Appearance.BackColor = Color.GreenYellow;
            //}
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
        #endregion    

        #region Chức năng
        private void btnFindAll_Click(object sender, EventArgs e)
        {
            loaData(1);
        }     

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loaData(1);
                ((TextBox)sender).Focus();
            }
        }        

        private void showHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id > 0)
            {
                ModulesModel module = (ModulesModel)ModulesBO.Instance.FindByPK(id);
                frmModuleHistory frm = new frmModuleHistory();
                frm.Module = module;
                frm.Show();
            }
        }
        
        private void btnReportMAT_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
           
            if (id > 0)
            {
                string code = grvData.GetFocusedRowCellValue(colCode).ToString();
                string name = grvData.GetFocusedRowCellValue(colName).ToString();

                Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
                Microsoft.Office.Interop.Word.Document doc = new Microsoft.Office.Interop.Word.Document();
                try 
                {
                    Directory.CreateDirectory(@"D:\\ReportData\\KIEM TRA THIET KE\\");
	                string reportPath = @"D:\\ReportData\\KIEM TRA THIET KE\\" + code + ".docx";
	                File.Copy(Application.StartupPath + "\\Templates\\ReportHSCK.docx", reportPath, true);

	                string productname = name;
	                string productcode = code;

	                doc = word.Documents.Open(reportPath);
	                doc.Activate();

	                repalaceText(doc, "<productname>", productname);
	                repalaceText(doc, "<productcode>", productcode);
	                repalaceText(doc, "<username>", Global.AppFullName);

                    repalaceText(doc, "<day>", DateTime.Now.Day.ToString());
                    repalaceText(doc, "<month>", DateTime.Now.Month.ToString());
                    repalaceText(doc, "<year>", DateTime.Now.Year.ToString());

                    doc.Save();
	                Process.Start(reportPath);                   
                } 
                catch (Exception ex) 
                {
	                MessageBox.Show(ex.Message);
                } 
                finally 
                {
	                
                }
            }
        }

        private void btnSendModuleContentByMail_Click(object sender, EventArgs e)
        {
            int rowCount = grvData.GetSelectedRows().Count();
            if (rowCount>0)
            {
                int count = Process.GetProcesses().Where(o => o.ProcessName.Contains("OUTLOOK")).Count();
                if (count==0)
                {
                    try
                    {
                        Process.Start("outlook.exe");
                    }
                    catch (Exception)
                    {                       
                    }                    
                }                              

                string content = "";             

                foreach (int i in grvData.GetSelectedRows())
                {
                    string code = grvData.GetRowCellValue(i, colCode).ToString();
                    string name = grvData.GetRowCellValue(i, colName).ToString();
                    content += code + " - " + name + "<br>";
                }

                string subject = "DANH SÁCH TPA MODEL";
                frmSendMail frm = new frmSendMail();
                frm.Content = content;
                frm.Subject = subject;
                TextUtils.OpenForm(frm);
            }
        }
        
        private void btnShowDMVT_Click(object sender, EventArgs e)
        {
            try
            {
                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát", "Đang load danh mục vật tư"))
                {
                    //DocUtils.InitFTPQLSX();
                    string code = grvData.GetFocusedRowCellValue(colCode).ToString();
                    string name = grvData.GetFocusedRowCellValue(colName).ToString();
                    string strFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    string strFTPFileName = "";
                    string strSaveName = "";
                    DocUtils.InitFTPQLSX();
                    DataTable dtDMVT = new DataTable();

                    if (code.StartsWith("TPAD."))
                    {
                        //dtDMVT = LibQLSX.Select("select * from MaterialModuleLink with(nolock) where ModuleCode = '" + code + "' order by ID");
                        strFTPFileName = string.Format("Thietke.Ck/{0}/{1}.Ck/VT.{1}.xlsm", code.Substring(0, 6), code);
                        strSaveName = code + ".xlsm";
                    }
                    else
                    {
                        strFTPFileName = @"//Thietke.Dt/PCB/" + code + "/PRD." + code + "/VT." + code + ".xls";
                        strSaveName = code + ".xls";
                    }

                    if (!DocUtils.CheckExits(strFTPFileName))
                    {
                        MessageBox.Show("Module không có trên nguồn thiết kế!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    DocUtils.DownloadFile(strFilePath, strSaveName, strFTPFileName);
                    dtDMVT = TextUtils.ExcelToDatatableNoHeader(strFilePath + "/" + strSaveName, "DMVT");
                    if (File.Exists(strFilePath + "/" + strSaveName))
                    {
                        File.Delete(strFilePath + "/" + strSaveName);
                    }
                    dtDMVT.Columns["F1"].ColumnName = "STT";
                    dtDMVT.Columns["F2"].ColumnName = "Name";
                    dtDMVT.Columns["F3"].ColumnName = "ThongSo";
                    dtDMVT.Columns["F4"].ColumnName = "Code";
                    dtDMVT.Columns["F5"].ColumnName = "MaVatLieu";
                    dtDMVT.Columns["F6"].ColumnName = "Unit";
                    dtDMVT.Columns["F7"].ColumnName = "Qty";
                    dtDMVT.Columns["F8"].ColumnName = "VatLieu";
                    dtDMVT.Columns["F9"].ColumnName = "Weight";
                    dtDMVT.Columns["F10"].ColumnName = "Hang";
                    dtDMVT.Columns["F11"].ColumnName = "Description";

                    dtDMVT = dtDMVT.AsEnumerable()
                               .Where(row => TextUtils.ToInt(row.Field<string>("STT") == "" ||
                                   row.Field<string>("STT") == null ? "0" : row.Field<string>("STT").Substring(0, 1)) > 0)
                               .CopyToDataTable();

                    // Hiển thị trên form
                    frmViewDMVT frm = new frmViewDMVT();
                    frm.Name = name;
                    frm.Code = code;
                    frm.DtDMVT = dtDMVT.Copy();
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                TextUtils.ShowError(ex);
            }
        }

        private void xemTaiLiêuThiêtKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DocUtils.InitFTPQLSX();
            int status = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colS));
            if (status == 0)
            {
                MessageBox.Show("Sản phẩm này không có tài liệu thiết kế!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //DriveListEx m_list = new DriveListEx();
            //m_list.Load();
            //List<string> listSerial = new List<string>();
            //foreach (var item in m_list)
            //{
            //    listSerial.Add(item.SerialNumber);
            //}

            //if (listSerial.Contains("serialDemo"))
            //{
                
            //}

            string productCode = grvData.GetFocusedRowCellValue(colCode).ToString();
            string name = grvData.GetFocusedRowCellValue(colName).ToString();

            if (productCode.StartsWith("TPAD"))
            {
                string _pathCkFTP = "Thietke.Ck/" + productCode.Substring(0, 6) + "/" + productCode + ".Ck";
                if (!DocUtils.CheckExits(_pathCkFTP))
                {
                    MessageBox.Show("Sản phẩm này không có tài liệu thiết kế!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                frmTLTK frm = new frmTLTK();
                frm.ProductCode = productCode;
                frm.ProductName = name;
                frm.Status = status;
                frm.Show();
            }
            else
            {
                string _pathDtFTP = "Thietke.Dt/PCB/" + productCode;
                if (!DocUtils.CheckExits(_pathDtFTP))
                {
                    MessageBox.Show("Sản phẩm này không có tài liệu thiết kế!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                frmElectronicMaterial frm = new frmElectronicMaterial();
                frm.ProductCode = productCode;
                frm.Show();
            }            
        }

        private void danhSachNgươiThiêtKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSearchDesigner frm = new frmSearchDesigner();
            frm.ProductCode = grvData.GetFocusedRowCellValue(colCode).ToString();
            frm.Show();
        }       

        private void btnShowTem_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));

            if (id > 0)
            {
                string code = grvData.GetFocusedRowCellValue(colCode).ToString();
                string name = grvData.GetFocusedRowCellValue(colName).ToString();

                frmTemManager frm = new frmTemManager();
                frm.ModuleID = id;
                frm.ModuleCode = code;
                frm.ModuleName = name;
                frm.Show();
            }
        }

        private void btnShowFilm_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));

            if (id > 0)
            {
                string code = grvData.GetFocusedRowCellValue(colCode).ToString();
                string name = grvData.GetFocusedRowCellValue(colName).ToString();
                
                frmFilmManager frm = new frmFilmManager();
                frm.ModuleID = id;
                frm.ModuleCode = code;
                frm.ModuleName = name;
                frm.Show();
            }
        }

        private void btnUpdateModuleVersion_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            ModulesModel model = (ModulesModel)ModulesBO.Instance.FindByPK(id);
            if (model.Status != 2)
            {
                MessageBox.Show("Module chưa có trên nguồn chuẩn!");
                return;
            }

            frmUpdateModuleVersion frm = new frmUpdateModuleVersion();
            frm.Module = model;
            frm.Show();            
        }

        private void btnModulePrice_Click(object sender, EventArgs e)
        {           
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            ModulesModel model = (ModulesModel)ModulesBO.Instance.FindByPK(id);
            if (model.Status != 2)
            {
                MessageBox.Show("Module chưa có trên nguồn chuẩn!");
                return;
            }
            frmModulePrice frm = new frmModulePrice();
            frm.Module = model;
            frm.Show();
        }

        private void danhSáchVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            ModulesModel model = (ModulesModel)ModulesBO.Instance.FindByPK(id);
            if (model.Status != 2)
            {
                MessageBox.Show("Module chưa có trên nguồn chuẩn!");
                return;
            }
            frmModuleVersion frm = new frmModuleVersion();
            frm.Module = model;
            frm.Show();
        }

        private void xemDanhSáchDựÁnChứaModuleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            ModulesModel model = (ModulesModel)ModulesBO.Instance.FindByPK(id);
            if (model.Status != 2)
            {
                MessageBox.Show("Module chưa có trên nguồn chuẩn!");
                return;
            }

            frmListProjectContainModule frm = new frmListProjectContainModule();
            frm.Module = model;
            frm.Show();
        }

        private void xemDanhSáchModuleChứaMạchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string code = TextUtils.ToString(grvData.GetFocusedRowCellValue(colCode));
            string name = TextUtils.ToString(grvData.GetFocusedRowCellValue(colName));

            frmModelContained frm = new frmModelContained();
            frm.MaterialCode = code;
            frm.MaterialName = name;
            //frm.DisplayType = 1;
            frm.Show();
        }
        #endregion

        private void btnUpdateDMVT_Click(object sender, EventArgs e)
        {
            try
            {
                int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
                if (id == 0) return;
                ModulesModel model = (ModulesModel)ModulesBO.Instance.FindByPK(id);
                if (model.Status != 2)
                {
                    MessageBox.Show("Module chưa có trên nguồn chuẩn!");
                    return;
                }

                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo danh mục vật tư..."))
                {
                    string _serverPathCK = string.Format("Thietke.Ck/{0}/{1}.Ck/VT.{1}.xlsm",
                        model.Code.Substring(0, 6), model.Code);
                    DocUtils.InitFTPQLSX();
                    if (DocUtils.CheckExits(_serverPathCK))
                    {
                        DocUtils.DownloadFile("D:/", "VT." + model.Code + ".xlsm", _serverPathCK);
                        DataTable dtDMVT = TextUtils.ExcelToDatatableNoHeader("D:/VT." + model.Code + ".xlsm", "DMVT");
                        TextUtils.AddDMVTfromModule("D:/VT." + model.Code + ".xlsm");
                        File.Delete("D:/VT." + model.Code + ".xlsm");
                    }                    
                }

                MessageBox.Show("Cập nhật danh mục vật tư thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Cập nhật danh mục vật tư không thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
        #endregion
    }
}
