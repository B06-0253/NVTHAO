using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Forms.Properties;
using Microsoft.VisualBasic;
using System.Media;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using System.Diagnostics;
using BMS.Model;
using BMS.Business;
using DevExpress.Utils;
using BMS.Utils;
using System.Collections;

namespace BMS
{
    public partial class frmCheckDataDesign : _Forms
    {
        #region Variables
        int _completeTK = -1;
        int _completeIPT = -1;
        string _selectedPath;//đường dẫn đến thiết kế (D:\Thietke.Ck\TPAD.A\TPAD.A0001.Ck)
        string _moduleCode;
        bool _checkIPT;
        string _pathDMVT;
        int _cadNumber = -1;

        DateTime _dateFirst = new DateTime(1950, 1, 1);
        string _pathThuVien3D = "\\\\server\\data2\\Thietke\\Luutru\\Thu vien 3D";

        DataTable _dtDataMEM;
        DataTable _dtHistoryCheck = new DataTable();

        DataTable dtLocal;

        List<MaterialModel> _listMaterialSaiKichThuoc = new List<MaterialModel>();
        List<MaterialModel> _listMaterialNotUse = new List<MaterialModel>();
        #endregion Variables

        #region Constructors and Load
        public frmCheckDataDesign()
        {
            InitializeComponent();
        }

        private void frmCheckDataDesign_Load(object sender, EventArgs e)
        {
            DocUtils.InitFTPQLSX();
            dtLocal = new DataTable();
            dtLocal.Columns.Add("Name", typeof(string));            
            dtLocal.Columns.Add("Size", typeof(string));
            dtLocal.Columns.Add("Type", typeof(string));
            dtLocal.Columns.Add("Hang", typeof(string));
            dtLocal.Columns.Add("PathLocal", typeof(string));
            dtLocal.Columns.Add("Path3D", typeof(string));
            dtLocal.Columns.Add("NameVT", typeof(string));
            dtLocal.Columns.Add("KLold", typeof(string));
            dtLocal.Columns.Add("KLnew", typeof(string));
        }
        #endregion

        #region Methods
        private void InitGridBeforeCheck()
        {

            if (grvDataNeedCompare.Rows.Count >= 1)
            {
                for (int i = 0; i <= grvDataNeedCompare.Rows.Count - 1; i++)
                {
                    grvDataNeedCompare.Rows[i].Cells[0].Style.BackColor = Color.White;
                    grvDataNeedCompare.Rows[i].Cells[1].Style.BackColor = Color.White;
                    grvDataNeedCompare.Rows[i].Cells[2].Style.BackColor = Color.White;
                }
            }

            if (grvData.Rows.Count >= 1)
            {
                for (int j = 0; j <= grvData.Rows.Count - 1; j++)
                {
                    grvData.Rows[j].DefaultCellStyle.BackColor = Color.White;
                }
            }

        }

        public string DateString(string ToFileName)
        {
            try
            {
                long mVal = System.Convert.ToInt64(Convert.ToInt64(ToFileName));
                TimeSpan a1 = TimeSpan.FromSeconds(mVal);
                DateTime mDate = default(DateTime);
                mDate = DateTime.MinValue;
                mDate = mDate.AddDays(System.Convert.ToDouble(a1.TotalDays));
                return mDate.ToString();
            }
            catch (Exception)
            {
                return "";
            }

        }

        private void GetUserDefProperties(string mPath, ref string[] mName, ref string[] mVal)
        {
            Inventor.Property oProp = default(Inventor.Property);
            Inventor.PropertySet oPropSet = default(Inventor.PropertySet);
            int mArrIndex = default(int);
            Inventor.ApprenticeServerComponent oApprenticeApp = new Inventor.ApprenticeServerComponent();
            Inventor.ApprenticeServerDocument oApprenticeServerDoc = default(Inventor.ApprenticeServerDocument);
            oApprenticeServerDoc = oApprenticeApp.Open(mPath);
            if (oApprenticeServerDoc == null)
            {
                MessageBox.Show("File không hợp lệ");
                return;
            }
            foreach (Inventor.PropertySet tempLoopVar_oPropSet in oApprenticeServerDoc.PropertySets)
            {
                oPropSet = tempLoopVar_oPropSet;
                if (oPropSet.DisplayName == "User Defined Properties")
                {
                    mArrIndex = 0;
                    mName = new string[oPropSet.Count + 1];
                    mVal = new string[oPropSet.Count + 1];
                    foreach (Inventor.Property tempLoopVar_oProp in oPropSet)
                    {
                        oProp = tempLoopVar_oProp;

                        if (oProp.Name.ToLower().StartsWith("plot"))
                        {
                            continue;
                        }

                        if (Information.VarType(oProp.Value) != Constants.vbDate)
                        {
                            mName[mArrIndex] = (string)oProp.Name;
                            mVal[mArrIndex] = (string)oProp.Value;
                            mArrIndex++;
                        }
                    }
                    break;
                }
            }
        }

        public void FillDataInGridIDW()
        {
            try
            {
                _dtDataMEM = new DataTable();
                _dtDataMEM.Columns.Add("Name", typeof(string));
                _dtDataMEM.Columns.Add("IValue", typeof(string));
                _dtDataMEM.Columns.Add("WValue", typeof(string));
                _dtDataMEM.Columns.Add("Date", typeof(string));
                int M = default(int);
                int i = default(int);
                string[] mName = null;
                string[] mVal = null;
                string mSt;
                GetUserDefProperties(txtPathSC.Text, ref mName, ref mVal);
                M = mName.Length;
                try
                {
                    for (i = 0; i <= M - 2; i += 2)
                    {
                        mSt = "";
                        DataRow newRow = _dtDataMEM.NewRow();
                        newRow["Name"] = mName[i].Replace("Size.", "");
                        newRow["IValue"] = mVal[i];
                        newRow["WValue"] = mVal[i + 1];
                        newRow["Date"] = DateString(mVal[i + 1]);
                        if (mName[i] != "" && mName[i].ToUpper().Contains((string)_moduleCode.ToUpper()))
                        {
                            _dtDataMEM.Rows.Add(newRow);
                        }
                    }
                }
                catch (Exception)
                {
                }

                DataRow newRow1 = _dtDataMEM.NewRow();
                newRow1["Name"] = "";
                newRow1["IValue"] = "";
                newRow1["WValue"] = "";
                newRow1["Date"] = "";
                _dtDataMEM.Rows.Add(newRow1);

                grvData.DataSource = null;
                grvData.Rows.Clear();
                grvData.AutoGenerateColumns = false;
                grvData.DataSource = _dtDataMEM;

                grvData.Columns[0].HeaderText = "Tên file";
                grvData.Columns[1].HeaderText = "Size";
                grvData.Columns[2].HeaderText = "Date modified";

                if (grvData.Rows.Count == 0)
                {
                    return;
                }
                grvData.Rows[grvData.Rows.Count - 1].Selected = true;
                //grvDataNeedCompare.Select()
                //txtDate.Select()

            }
            catch (Exception)
            {
                grvData.DataSource = null;
                grvData.Rows.Clear();
            }
        }

        public DataTable GetDMVT(string filePath)
        {
            try
            {
                DataTable dt1 = TextUtils.ExcelToDatatable(filePath.Trim(), "DMVT");
                DataTable dt = dt1.Copy();
                for (int i = 0; i <= 4; i++)
                {
                    dt.Rows.RemoveAt(0);
                }
                //for (int i = 0; i <4; i++)
                //{
                //    dt.Rows.RemoveAt(dt.Rows.Count - 1);
                //}
                for (int i = 1; i <= 5; i++)
                {
                    dt.Columns.RemoveAt(4);
                }
                dt.Columns.RemoveAt(dt.Columns.Count - 1);
                dt.Columns.RemoveAt(dt.Columns.Count - 1);
                dt.Columns.RemoveAt(2);
                dt.Columns.RemoveAt(0);
                return dt.Select("F4 like '%TPAD%'").CopyToDataTable();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public DataTable GetDMVT_Excel(string filePath)
        {
            try
            {
                DataTable dtDMVT = TextUtils.ExcelToDatatableNoHeader(filePath, "DMVT");
                dtDMVT = dtDMVT.AsEnumerable()
                            .Where(row => TextUtils.ToInt(row.Field<string>("F1") == "" ||
                                row.Field<string>("F1") == null ? "0" : row.Field<string>("F1").Substring(0, 1)) > 0)
                            .CopyToDataTable();
                //DataTable dtDMVT1 = dtDMVT.Copy();
                //dtDMVT1.Rows.Clear();              
                //for (int i = 0; i < dtDMVT.Rows.Count; i++)
                //{
                //    try
                //    {
                //        if (dtDMVT.Rows[i][0] == null)
                //        {
                //            continue;
                //        }
                //        if (dtDMVT.Rows[i][0].ToString().Trim() == "")
                //        {
                //            continue;
                //        }
                //        string STT = dtDMVT.Rows[i][0].ToString().Trim();
                //        if (TextUtils.ToDecimal(STT.Substring(0, 1)) > 0)
                //        {
                //            dtDMVT1.ImportRow(dtDMVT.Rows[i]);
                //        }
                //    }
                //    catch (Exception)
                //    {
                //    }
                //}
                //dtDMVT = dtDMVT.Select("Type <> 1").CopyToDataTable();
                return dtDMVT;
            }
            catch (Exception)
            {
                return new DataTable();
            }
        }

        void loadDanhSachScan()
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tải dữ liệu kiểm tra..."))
            {
                DocUtils.InitFTPQLSX();
                string pathCAD_cung = string.Format("Thietke.Ck/{0}/{1}.Ck/BCCk.{1}/BC-CAD.{1}", _moduleCode.Substring(0, 6), _moduleCode);

                DataTable dt = new DataTable();
                dt = TextUtils.Select("CheckCTTKHistory", new Expression("ID", 0));
                dt.Columns.Add("FilePath");

                foreach (string filePath in Directory.GetFiles("D:/" + pathCAD_cung))
                {
                    string fileName = Path.GetFileNameWithoutExtension(filePath);
                    if (!fileName.Contains(_moduleCode.Substring(5, 5)))
                    {
                        continue;
                    }

                    System.Collections.ArrayList barcodes = new System.Collections.ArrayList();
                    //Image img = Image.FromFile(filePath);
                    Bitmap mBitmap = new Bitmap(filePath);
                    BarcodeImaging.FullScanPage(ref barcodes, mBitmap, 100);

                    //string[] barcodes = BarcodeReader.read(mBitmap, BarcodeReader.CODE39);
                    //string[] barcodes = OnBarcode.Barcode.BarcodeScanner.BarcodeScanner.Scan(mBitmap, OnBarcode.Barcode.BarcodeScanner.BarcodeType.Code39);
                    mBitmap.Dispose();

                    string code = "";
                    string date = "";
                    string size = "";
                    string fullDate = "";
                    try
                    {
                        code = barcodes.ToArray().Where(o => o.ToString().StartsWith("+")).ToArray()[0].ToString();
                        if (!code.Contains(_moduleCode.Substring(5, 5)))
                        {
                            continue;
                        }
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        date = barcodes.ToArray().Where(o => o.ToString().StartsWith("1")).ToArray()[0].ToString();
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        size = barcodes.ToArray().Where(o => o.ToString().StartsWith("2")).ToArray()[0].ToString();
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        fullDate = DateString(date.Substring(2));
                    }
                    catch (Exception)
                    {

                    }

                    dt.Rows.Add(0, _moduleCode, code, size, date, fullDate, 0, filePath);
                }
                grvDataNeedCompare.DataSource = null;
                grvDataNeedCompare.AutoGenerateColumns = false;
                grvDataNeedCompare.DataSource = dt;

            }
        }
        #endregion Methods

        #region Events
        private void btnChooseMat_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                FolderBrowserDialog FolderBrowser1 = new FolderBrowserDialog();
                FolderBrowser1.SelectedPath = Settings.Default.CheckCMPath;
                FolderBrowser1.RootFolder = Environment.SpecialFolder.MyComputer;
                if (FolderBrowser1.ShowDialog() == DialogResult.OK)
                {
                    _checkIPT = false;
                    _completeIPT = 1;
                    _completeTK = 1;

                    //btnReportSC.Enabled = false;

                    _selectedPath = FolderBrowser1.SelectedPath;
                    _moduleCode = Path.GetFileNameWithoutExtension(_selectedPath);
                    txtCode.Text = _moduleCode;
                    _pathDMVT = _selectedPath + "\\" + "VT." + _moduleCode + ".xlsm";
                    txtDMVTPath.Text = _pathDMVT;
                    txtPathSC.Text = _selectedPath + "\\" + "3D." + _moduleCode + "\\IDW." + _moduleCode + ".idw";

                    grvDataCT.DataSource = null;
                    grvDataCT.Rows.Clear();
                    grvData.DataSource = null;
                    grvData.Rows.Clear();
                    //
                    grvDMVTchuan.DataSource = null;
                    grvDMVTchuan.Rows.Clear();
                    grvCAD.DataSource = null;
                    grvCAD.Rows.Clear();

                    //loadHistoryCheck();
                    FillDataInGridIDW();
                }

                if (!string.IsNullOrEmpty((string)_selectedPath) && _selectedPath.ToUpper() != Settings.Default.CheckCMPath)
                {
                    Settings.Default.CheckCMPath = _selectedPath;
                    Settings.Default.Save();

                    grvDataNeedCompare.DataSource = null;
                    grvDataNeedCompare.Rows.Clear();
                }
                else
                {
                    //reload lại grid chứa bản cứng
                    foreach (DataGridViewRow row in grvDataNeedCompare.Rows)
                    {
                        if (row.Cells[0].Style.BackColor == Color.Yellow || row.Cells[1].Style.BackColor == Color.GreenYellow ||
                            row.Cells[2].Style.BackColor == Color.GreenYellow)
                        {
                            row.Cells[0].Style.BackColor = Color.White;
                            row.Cells[1].Style.BackColor = Color.White;
                            row.Cells[2].Style.BackColor = Color.White;
                            row.Cells[0].Value = "";
                            row.Cells[1].Value = "";
                            row.Cells[2].Value = "";
                            row.Cells[3].Value = "";
                        }
                    }
                }

            }
            catch (Exception)
            {
                grvDataCT.DataSource = null;
                grvDataCT.Rows.Clear();
            }
        }

        private void txtCode_KeyDown(System.Object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                string dirc = "";
                if (e.KeyCode == Keys.ShiftKey)
                {
                    dirc = "D:\\Thietke.Ck\\TPAD." + txtCode.Text.Trim().Substring(3, 1) + "\\TPAD." + txtCode.Text.Trim().Substring(3, 5) + ".Ck";
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    dirc = "D:\\Thietke.Ck\\" + txtCode.Text.Substring(0, 6) + "\\" + txtCode.Text.Trim() + ".Ck";
                }
                else
                {
                    return;
                }

                if (Directory.Exists(dirc))
                {
                    _completeIPT = 1;
                    _completeTK = -1;
                    _checkIPT = false;

                    //btnReportSC.Enabled = false;

                    _selectedPath = dirc;
                    _moduleCode = Path.GetFileNameWithoutExtension(dirc);
                    txtCode.Text = _moduleCode;
                    _pathDMVT = _selectedPath + "\\" + "VT." + _moduleCode + ".xlsm";
                    txtDMVTPath.Text = _pathDMVT;
                    txtPathSC.Text = _selectedPath + "\\" + "3D." + _moduleCode + "\\IDW." + _moduleCode + ".idw";

                    grvDataCT.DataSource = null;
                    grvDataCT.Rows.Clear();
                    grvData.DataSource = null;
                    grvData.Rows.Clear(); //
                    grvDMVTchuan.DataSource = null;
                    grvDMVTchuan.Rows.Clear();
                    grvCAD.DataSource = null;
                    grvCAD.Rows.Clear();

                    //loadHistoryCheck();

                    FillDataInGridIDW();

                    if (!string.IsNullOrEmpty((string)_selectedPath) && _selectedPath.ToUpper() != Settings.Default.CheckCMPath)
                    {
                        Settings.Default.CheckCMPath = _selectedPath.ToUpper();
                        Settings.Default.Save();

                        grvDataNeedCompare.DataSource = null;
                        grvDataNeedCompare.Rows.Clear();
                    }
                    else
                    {
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy bản mềm của thiết kế này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCode.Text = "";
                    txtCode.Select();
                }
            }
            catch (Exception)
            {

            }

        }

        private void btnPrintReport_Click(System.Object sender, System.EventArgs e)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo biểu mẫu kiểm tra 13"))
            {
                if (_moduleCode.Trim() == "")
                {
                    MessageBox.Show("Bạn chưa chọn bản thiết kế.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string moduleName = "";
                try
                {
                    moduleName = ((ModulesModel)ModulesBO.Instance.FindByAttribute("Code", _moduleCode)[0]).Name;
                }
                catch (Exception)
                {
                    MessageBox.Show("Sản phẩm này không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Word.Application word = new Word.Application();
                Word.Document doc = default(Word.Document);
                try
                {
                    string reportPath = "D:\\Hien data\\KIEM TRA THIET KE\\ReportHSCK(" + _moduleCode + ").docm";
                    File.Copy(Application.StartupPath + "\\Templates\\ReportHSCK.docm", reportPath, true);

                    doc = word.Documents.Open(reportPath);
                    doc.Activate();

                    TextUtils.FindReplaceAnywhere(word, "<productname>", moduleName);
                    TextUtils.FindReplaceAnywhere(word, ".CODE", "." + _moduleCode.Substring(5, 5));
                    TextUtils.FindReplaceAnywhere(word, "<username>", Global.AppFullName);
                    TextUtils.FindReplaceAnywhere(word, "<now>", DateTime.Now.ToString());

                    //2.1 file hồ sơ thiết kế
                    if (File.Exists(_selectedPath + "\\DOC." + _moduleCode + "\\HS." + _moduleCode + ".xlsm"))
                    {
                        TextUtils.RepalaceText(doc, "<21>", "V");
                    }
                    else
                    {
                        TextUtils.RepalaceText(doc, "<21>", "X");
                    }

                    //2.2 file phác thảo thiết kế
                    if (File.Exists(_selectedPath + "\\DOC." + _moduleCode + "\\PTTK." + _moduleCode + ".docm"))
                    {
                        TextUtils.RepalaceText(doc, "<22>", "V");
                    }
                    else
                    {
                        TextUtils.RepalaceText(doc, "<22>", "X");
                    }

                    //2.3 file danh mục vật tư
                    if (File.Exists(_selectedPath + "\\VT." + _moduleCode + ".xlsm"))
                    {
                        TextUtils.RepalaceText(doc, "<23>", "V");
                    }
                    else
                    {
                        TextUtils.RepalaceText(doc, "<23>", "X");
                    }

                    //2.4 Bản vẽ lắp ráp
                    //Directory.GetFiles(sPath & "\LRP." & sModel).Count()
                    if (Directory.GetFiles(_selectedPath + "\\LRP." + _moduleCode).Count() > 0)
                    {
                        TextUtils.RepalaceText(doc, "<24>", "V");
                    }
                    else
                    {
                        TextUtils.RepalaceText(doc, "<24>", "X");
                    }

                    //2.5 Bản vẽ thủy lực
                    if (Directory.GetFiles(_selectedPath + "\\TL." + _moduleCode).Count() > 0)
                    {
                        TextUtils.RepalaceText(doc, "<25>", "V");
                    }
                    else
                    {
                        TextUtils.RepalaceText(doc, "<25>", "X");
                    }

                    //2.6 Bản vẽ khí nén
                    if (Directory.GetFiles(_selectedPath + "\\KN." + _moduleCode).Count() > 0)
                    {
                        TextUtils.RepalaceText(doc, "<26>", "V");
                    }
                    else
                    {
                        TextUtils.RepalaceText(doc, "<26>", "X");
                    }

                    //2.7 BC-BM
                    if (_completeIPT == 1)
                    {
                        TextUtils.RepalaceText(doc, "<27>", "V");
                    }
                    else
                    {
                        TextUtils.RepalaceText(doc, "<27>", "-");
                    }

                    //2.8 kiểm tra cấu trúc thiết kế
                    if (_completeTK == 1)
                    {
                        TextUtils.RepalaceText(doc, "<28>", "V");
                    }
                    else
                    {
                        TextUtils.RepalaceText(doc, "<28>", "-");
                    }

                    //3.x Bản vẽ CAD cơ khí
                    int countSameCode = 0;
                    int countNotSame = 0;
                    DateTime dateCad = default(DateTime);
                    List<string> cadFiles = Directory.GetFiles(_selectedPath + "\\CAD." + _moduleCode, "*.dwg", SearchOption.AllDirectories).ToList();
                    string j = "0";
                    if (cadFiles.Count > 0)
                    {
                        for (int i = 0; i <= cadFiles.Count - 1; i++)
                        {
                            DateTime currentDate = new FileInfo(cadFiles[i]).LastWriteTime;
                            if (Path.GetFileNameWithoutExtension(cadFiles[i]).StartsWith(_moduleCode))
                            {
                                if (i == 0)
                                {
                                    dateCad = currentDate;
                                }
                                else
                                {

                                    if (dateCad < currentDate)
                                    {
                                        dateCad = currentDate;
                                    }

                                }
                                countSameCode++;
                            }
                            else
                            {
                                countNotSame++;
                            }
                        }
                        //thong tin ban mem
                        TextUtils.RepalaceText(doc, "<31>", countSameCode.ToString());
                        TextUtils.RepalaceText(doc, "<32>", countNotSame.ToString());

                        //thong tin ban cung
                        string folderCADC = "D:\\Thietke.Ck\\" + _moduleCode.Substring(0, 6) + "\\" + _moduleCode
                            + ".Ck\\BCCk." + _moduleCode + "\\BC-CAD." + _moduleCode;
                        string[] cadFilesC = Directory.GetFiles(folderCADC, "*.jpg", SearchOption.AllDirectories);
                        if (cadFilesC.Count() > 0)
                        {
                            int sameCodeC = 0;
                            int diffCodeC = 0;
                            try
                            {
                                sameCodeC = cadFilesC.Count(o => Path.GetFileName(o).Contains(_moduleCode));
                            }
                            catch { }
                            try
                            {
                                diffCodeC = cadFilesC.Count(o => !Path.GetFileName(o).Contains(_moduleCode));
                            }
                            catch { }
                            TextUtils.RepalaceText(doc, "<34>", sameCodeC.ToString());
                            TextUtils.RepalaceText(doc, "<35>", diffCodeC.ToString());
                            TextUtils.RepalaceText(doc, "<36>", _dateFirst.ToString("dd/MM/yyyy") + " " + _dateFirst.ToShortTimeString());


                            if (dateCad < Convert.ToDateTime(_dateFirst))
                            {
                                TextUtils.RepalaceText(doc, "<33>", "-");
                            }
                            else
                            {
                                TextUtils.RepalaceText(doc, "<33>", dateCad.ToString("dd/MM/yyyy") + " " + dateCad.ToShortTimeString());
                            }

                        }
                    }

                    //5.x Kiểm tra bản vẽ đấu nối điện
                    string fdfFileName = "D:\\Thietke.Dn\\" + _moduleCode.Substring(0, 6) + "\\" + _moduleCode + ".Dn\\PRD." + _moduleCode + "\\" + _moduleCode + ".Dn.pdf";

                    if (File.Exists(fdfFileName))
                    {
                        iTextSharp.text.pdf.PdfReader oReader = new iTextSharp.text.pdf.PdfReader(fdfFileName);
                        string sOut = "";
                        for (int i = 1; i <= oReader.NumberOfPages; i++)
                        {
                            iTextSharp.text.pdf.parser.SimpleTextExtractionStrategy its = new iTextSharp.text.pdf.parser.SimpleTextExtractionStrategy();
                            sOut += (string)(iTextSharp.text.pdf.parser.PdfTextExtractor.GetTextFromPage(oReader, i, its));
                            break;
                        }

                        //5.1 Kiểm tra mã modul

                        if (sOut.Contains("Mã sản phẩm " + _moduleCode))
                        {
                            TextUtils.RepalaceText(doc, "<51>", "V");
                        }
                        else
                        {
                            TextUtils.RepalaceText(doc, "<51>", "-");
                        }

                        //5.2 Kiểm tra số trang số tờ
                        if (oReader.NumberOfPages > 0)
                        {
                            TextUtils.RepalaceText(doc, "<52>", oReader.NumberOfPages.ToString());
                        }
                        else
                        {
                            TextUtils.RepalaceText(doc, "<52>", "0");
                        }

                        //5.3 Thời gian bản vẽ
                        TextUtils.RepalaceText(doc, "<53>", new FileInfo(fdfFileName).LastWriteTime.ToString("dd/MM/yyyy") + " "
                            + new FileInfo(fdfFileName).LastWriteTime.ToShortTimeString());
                    }
                    else
                    {
                        TextUtils.RepalaceText(doc, "<51>", "");
                        TextUtils.RepalaceText(doc, "<52>", "");
                        TextUtils.RepalaceText(doc, "<53>", "");
                    }

                    TextUtils.RepalaceText(doc, "<day>", (DateTime.Now.Day > 9 ? DateTime.Now.Day.ToString() : "0" + DateTime.Now.Day));
                    TextUtils.RepalaceText(doc, "<month>", (DateTime.Now.Month > 9 ? DateTime.Now.Month.ToString() : "0" + DateTime.Now.Month));
                    TextUtils.RepalaceText(doc, "<year>", DateTime.Now.Year.ToString());
                    doc.Save();

                    Process.Start(reportPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    //doc.Close();
                    //word.Quit();
                }
            }
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            frmConfigSystem frm = new frmConfigSystem();
            frm.Show();
        }

        #region KIỂM TRA BẢN CỨNG - BẢN MỀM
        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (grvData.Rows.Count == 0)
            {
                return;
            }
            if (grvDataNeedCompare.Rows.Count == 0)
            {
                return;
            }

            InitGridBeforeCheck();

            DataTable dtDMVT = GetDMVT(_pathDMVT.Trim());

            #region Kiểm tra bản cứng
            //Cảnh báo trên bản cứng
            int count = 0;
            _dateFirst = new DateTime(1950, 1, 1);

            for (int i = 0; i <= grvDataNeedCompare.Rows.Count - 1; i++)
            {
                if (grvDataNeedCompare.Rows[i].Cells[0].Value == null || grvDataNeedCompare.Rows[i].Cells[0].Value.ToString() == "")
                {
                    grvDataNeedCompare.Rows[i].DefaultCellStyle.BackColor = Color.White;
                    grvDataNeedCompare.Rows[i].Cells[1].Value = "";
                    grvDataNeedCompare.Rows[i].Cells[2].Value = "";
                    continue;
                }
                //Dim nameC As String = grvDataNeedCompare.Rows(i).Cells(2).Value.ToString.Trim.Replace("+M.", "").Replace("+T.", "")
                string nameC = (string)(grvDataNeedCompare.Rows[i].Cells[colFileName.Index].Value.ToString().Trim().Substring(3));
                string sizeValue = default(string);
                string dateValue = default(string);
                try
                {
                    sizeValue = (string)(grvDataNeedCompare.Rows[i].Cells[colSizeCheckCTTK.Index].Value.ToString().Trim().Substring(2));
                }
                catch (Exception)
                {
                    sizeValue = "";
                }
                try
                {
                    dateValue = (string)(grvDataNeedCompare.Rows[i].Cells[colDateModified.Index].Value.ToString().Trim().Substring(2));
                }
                catch (Exception)
                {
                    dateValue = "";
                }
                string filePath;
                try
                {
                    filePath = grvDataNeedCompare.Rows[i].Cells[colFilePathC.Index].Value.ToString();
                }
                catch (Exception)
                {
                    filePath = "";
                }
                //Cảnh báo sự khác nhau về nội dung giữa bản cứng và bản mềm
                foreach (DataRow itemRow in _dtDataMEM.Rows)
                {
                    string nameM = (string)(itemRow[0].ToString().Trim().Replace("TPAD.", "").Replace(".ipt", "").Replace(".iam", "")); //.Replace(")", "/")
                    string sizeM = (string)(itemRow[1].ToString().Trim());
                    string dateM = (string)(itemRow[2].ToString().Trim());
                    //Tên file trên bản cứng = tên file trên bản mềm
                    if (nameM.ToUpper() == nameC.ToUpper())
                    {
                        //Kiểm tra size file
                        if (sizeM != sizeValue)
                        {
                            grvDataNeedCompare.Rows[i].Cells[colSizeCheckCTTK.Index].Style.BackColor = Color.GreenYellow;
                            count++;
                        }
                        else
                        {
                            grvDataNeedCompare.Rows[i].Cells[colSizeCheckCTTK.Index].Style.BackColor = Color.White;
                        }
                        //Kiểm tra ngày file
                        if (dateM != dateValue)
                        {
                            grvDataNeedCompare.Rows[i].Cells[colDateModified.Index].Style.BackColor = Color.GreenYellow;
                            count++;
                        }
                        else
                        {
                            grvDataNeedCompare.Rows[i].Cells[colDateModified.Index].Style.BackColor = Color.White;
                        }
                        //isNew = False
                        break;
                    }
                }

                try
                {
                    if (_dtDataMEM.Select("Name = 'TPAD." + nameC + ".ipt'").Count() <= 0 && _dtDataMEM.Select("Name = 'TPAD." + nameC + ".iam'").Count() <= 0)
                    {
                        try
                        {
                            grvDataNeedCompare.Rows[i].Cells[0].Style.BackColor = Color.Yellow;
                            grvDataNeedCompare.Rows[i].Cells[1].Style.BackColor = Color.Yellow;
                            grvDataNeedCompare.Rows[i].Cells[2].Style.BackColor = Color.Yellow;
                            count++;
                        }
                        catch (Exception)
                        {
                            grvDataNeedCompare.Rows[i].Cells[0].Style.BackColor = Color.Yellow;
                            grvDataNeedCompare.Rows[i].Cells[1].Style.BackColor = Color.Yellow;
                            grvDataNeedCompare.Rows[i].Cells[2].Style.BackColor = Color.Yellow;
                            count++;
                        }

                    }
                    else
                    {
                        grvDataNeedCompare.Rows[i].Cells[0].Style.BackColor = Color.White;

                        if (_dateFirst < TextUtils.ToDate(DateString(dateValue)))
                        {
                            _dateFirst = TextUtils.ToDate(DateString(dateValue));
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
            #endregion

            #region Kiểm tra bản mềm
            //Cảnh báo trên bản mềm
            for (int j = 0; j <= grvData.Rows.Count - 1; j++)
            {
                if (grvData.Rows[j].Cells[0].Value == null || grvData.Rows[j].Cells[0].Value.ToString() == "")
                {
                    continue;
                }
                string nameM = (string)(grvData.Rows[j].Cells[0].Value.ToString().Trim().Replace("TPAD.", "").Replace(".ipt", "").Replace(".iam", ""));

                //Cảnh báo nếu có bản ghi mới trong bản mềm
                bool isNew = true;
                foreach (DataGridViewRow row in grvDataNeedCompare.Rows)
                {
                    if (row.Cells[0].Value == null || row.Cells[0].Value.ToString() == "")
                    {
                        continue;
                    }
                    if (nameM.ToUpper() == row.Cells[0].Value.ToString().Trim().ToUpper().Substring(3))
                    {
                        isNew = false;
                    }
                }

                if (isNew == true)
                {
                    grvData.Rows[j].DefaultCellStyle.BackColor = Color.Yellow;
                    count++;
                }
                else
                {
                    grvData.Rows[j].DefaultCellStyle.BackColor = Color.White;
                }
            }
            #endregion

            _checkIPT = true;

            if (count>0)
            {
                _completeIPT = 0;
            }
            else
            {
                _completeIPT = 1;
            }

            if (_completeIPT == 1)
            {
                MessageBox.Show("'Bản cứng - Bản mềm' đã chuẩn", "Thông báo");
            }
            else if (_completeIPT == 0)
            {
                MessageBox.Show("Chưa chuẩn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            txtCode.Select();
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            ////reload lại grid chứa bản cứng
            //foreach (DataGridViewRow row in grvDataNeedCompare.SelectedRows)
            //{
            //    if (row.Cells[0].Style.BackColor == Color.Yellow || row.Cells[1].Style.BackColor == Color.GreenYellow 
            //        || row.Cells[2].Style.BackColor == Color.GreenYellow)
            //    {
            //        grvDataNeedCompare.Rows.Remove(row);
            //    }
            //}
        }

        private void btnReportSC_Click(System.Object sender, System.EventArgs e)
        {
            if (_moduleCode.Trim() == "")
            {
                MessageBox.Show("Bạn hãy chọn một bản thiết kế!");
                return;
            }

            if (!_checkIPT)
            {
                MessageBox.Show("Bạn chưa kiểm tra \'Bản cứng - Bản mềm\' !", "Thông báo");
                return;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("Date", typeof(string));
            dt.Columns.Add("Size", typeof(string));

            foreach (DataGridViewRow rowC in grvData.Rows)
            {
                if (rowC.Cells[0].Value.ToString() == "")
                {
                    continue;
                }
                if (rowC.DefaultCellStyle.BackColor == Color.Yellow)
                {
                    DataRow row = dt.NewRow();
                    row["Name"] = rowC.Cells[0].Value.ToString().Replace(".ipt", "").Replace(".iam", "");
                    row["Type"] = "Bản cứng không có";
                    row["Date"] = "";
                    row["Size"] = "";
                    dt.Rows.Add(row);
                }
            }

            if (grvDataNeedCompare.Rows.Count > 0)
            {
                foreach (DataGridViewRow rowS in grvDataNeedCompare.Rows)
                {
                    if (rowS.Cells[0].Value == null || rowS.Cells[0].Value.ToString() == "")
                    {
                        continue;
                    }

                    bool er = false;
                    DataRow row = dt.NewRow();
                    row["Name"] = "TPAD." + rowS.Cells[0].Value.ToString().Substring(3);

                    if (rowS.Cells[0].Style.BackColor == Color.Yellow)
                    {
                        row["Type"] = "Bản mềm không có";
                        row["Date"] = "";
                        row["Size"] = "";
                        dt.Rows.Add(row);
                        continue;
                    }

                    if (rowS.Cells[2].Style.BackColor == Color.GreenYellow)
                    {
                        row["Date"] = "V";
                        er = true;
                    }

                    if (rowS.Cells[1].Style.BackColor == Color.GreenYellow)
                    {
                        row["Size"] = "V";
                        er = true;
                    }

                    if (er == true)
                    {
                        dt.Rows.Add(row);
                    }
                }
            }

            if (dt.Rows.Count > 0)
            {
                string reportPath = "D:\\ReportCM.xlsx";
                File.Copy(Application.StartupPath + "\\ReportCM.xlsx", reportPath, true);
                Excel.Application objXLApp = default(Excel.Application);
                Excel.Workbook objXLWb = default(Excel.Workbook);
                Excel.Worksheet objXLWs = default(Excel.Worksheet);
                //------------ Tạo file Excel trong thư mục chứa ------------
                string fileReport = reportPath;
                objXLApp = new Excel.Application();
                objXLApp.Visible = true;
                objXLApp.Workbooks.Open(fileReport);
                objXLWb = objXLApp.Workbooks[1];
                objXLWs = (Excel.Worksheet)objXLWb.Worksheets[1];

                objXLApp.Cells[13, 3] = "Hà Nội, ngày " + (DateTime.Now.Day < 10 ? "0" + DateTime.Now.Day : DateTime.Now.Day.ToString())
                    + " tháng " + (DateTime.Now.Month < 10 ? "0" + DateTime.Now.Month : DateTime.Now.Month.ToString()) + " năm " + DateTime.Now.Year;
                //Some things
                objXLApp.Cells[5, 2] = _moduleCode.Trim();
                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    ((Excel.Range)objXLWs.Rows[11]).Insert();
                    objXLWs.Cells[11, 1] = dt.Rows[i]["Name"].ToString();
                    objXLWs.Cells[11, 2] = dt.Rows[i]["Type"].ToString();
                    objXLWs.Cells[11, 3] = dt.Rows[i]["Date"].ToString();
                    objXLWs.Cells[11, 4] = dt.Rows[i]["Size"].ToString();
                }

                objXLApp.ActiveWorkbook.Save();
                objXLApp.Workbooks.Close();
                objXLApp.Quit();
                TextUtils.ReleaseComObject(objXLApp);
                TextUtils.ReleaseComObject(objXLWb);
                TextUtils.ReleaseComObject(objXLWs);

                Process.Start(fileReport);
            }
        }

        private void btnDeleteError_Click(object sender, EventArgs e)
        {
            //if (_productCode!="")
            //{
            //    loadHistoryCheck();
            //}           
        }

        void loadHistoryCheck()
        {
            try
            {
                _dtHistoryCheck = TextUtils.Select("CheckCTTKHistory", new Expression("Code", _moduleCode));
                grvDataNeedCompare.DataSource = null;
                grvDataNeedCompare.AutoGenerateColumns = false;
                grvDataNeedCompare.DataSource = _dtHistoryCheck;
                //grvDataNeedCompare.DataBindings();
            }
            catch
            {
            }

        }

        private void btnLoadBC_Click(object sender, EventArgs e)
        {
            loadDanhSachScan();
        }
        #endregion KIỂM TRA BẢN CỨNG - BẢN MỀM

        #region XÁC NHẬN DANH MỤC VẬT TƯ
        public DataTable GetFullDMVT(string filePath)
        {
            try
            {
                DataTable dt1 = TextUtils.ExcelToDatatableNoHeader(filePath.Trim(), "DMVT");
                DataTable dt = dt1.Copy();
                //for (int i = 0; i <= 4; i++)
                //{
                //    dt.Rows.RemoveAt(0);
                //}
                //for (int i = 0; i <= 7; i++)
                //{
                //    dt.Rows.RemoveAt(dt.Rows.Count - 1);
                //}
                dt = dt.AsEnumerable()
                            .Where(row => TextUtils.ToInt(row.Field<string>("F1") == "" ||
                                row.Field<string>("F1") == null ? "0" : row.Field<string>("F1").Substring(0, 1)) > 0)
                            .CopyToDataTable();
                List<string> listConfig = new List<string>();
                try
                {
                    listConfig = ((ConfigSystemModel)ConfigSystemBO.Instance.FindByAttribute("KeyName", "ConfigDMVTchuan")[0]).KeyValue.Split(',').ToList();
                }
                catch (Exception)
                {
                }
                if (listConfig.Count > 0)
                {
                    foreach (string item in listConfig)
                    {
                        dt = dt.Select("F4 not like '" + item + "%'").CopyToDataTable();
                    }
                }

                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void btnGetDMVTchuan_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                grvDMVTchuan.DataSource = null;
                grvDMVTchuan.AutoGenerateColumns = false;
                grvDMVTchuan.DataSource = GetFullDMVT(_pathDMVT);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnDMVT_Click(System.Object sender, System.EventArgs e)
        {
            string productcode = _moduleCode;
            string productname = "";
            try
            {
                productname = ((ModulesModel)ModulesBO.Instance.FindByAttribute("Code", productcode)[0]).Name;
            }
            catch (Exception)
            {
                MessageBox.Show("Module này không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (grvDMVTchuan.Rows.Count == 0)
            {
                MessageBox.Show("Danh mục vật tư trống!", "Thông báo");
                return;
            }

            if (_pathDMVT == "")
            {
                MessageBox.Show("Không tồn tại danh mục vật tư trong thiết kế này!", "Thông báo");
                return;
            }

            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo biểu mẫu 08"))
            {
                File.Copy(@"\\SERVER\Company\VAN BAN HIEN HANH\THU TUC-HUONG DAN\TT 13 Thu tuc kiem soat thiet ke\TP-TT13-BM08 - xac nhan vat tu dien, dien tu.xlsm"
                    , _selectedPath + "\\DOC." + _moduleCode + "\\XNVT." + _moduleCode + ".xlsm", true);

                DataTable dt1 = TextUtils.ExcelToDatatable(_pathDMVT, "DMVT");

                Excel.Application objXLApp = default(Excel.Application);
                Excel.Workbook objXLWb = default(Excel.Workbook);
                Excel.Worksheet objXLWs = default(Excel.Worksheet);

                try
                {
                    objXLApp = new Excel.Application();
                    objXLApp.Workbooks.Open(_selectedPath + "\\DOC." + _moduleCode + "\\XNVT." + _moduleCode + ".xlsm");
                    objXLWb = objXLApp.Workbooks[1];
                    objXLWs = (Excel.Worksheet)objXLWb.Worksheets[1];

                    objXLWs.Cells[3, 3] = productname;
                    objXLWs.Cells[3, 10] = "Mã: " + productcode;
                    objXLWs.Cells[4, 3] = dt1.Rows[2][2].ToString();
                    objXLWs.Cells[17, 1] = "Tân Phát, ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;

                    for (int i = 0; i < 7; i++)
                    {
                        ((Excel.Range)objXLWs.Rows[7]).Delete();
                    }
                    for (int i = grvDMVTchuan.Rows.Count - 1; i >= 0; i--)
                    {
                        ((Excel.Range)objXLWs.Rows[8]).Insert();
                        objXLWs.Cells[8, 1] = grvDMVTchuan.Rows[i].Cells[0].Value.ToString(); //.ToLower
                        objXLWs.Cells[8, 2] = grvDMVTchuan.Rows[i].Cells[1].Value.ToString(); //.ToLower
                        objXLWs.Cells[8, 3] = grvDMVTchuan.Rows[i].Cells[2].Value.ToString(); //.ToLower
                        objXLWs.Cells[8, 4] = grvDMVTchuan.Rows[i].Cells[3].Value.ToString(); //.ToLower
                        objXLWs.Cells[8, 5] = grvDMVTchuan.Rows[i].Cells[4].Value.ToString(); //.ToLower
                        objXLWs.Cells[8, 6] = grvDMVTchuan.Rows[i].Cells[5].Value.ToString(); //.ToLower
                        objXLWs.Cells[8, 7] = grvDMVTchuan.Rows[i].Cells[6].Value.ToString(); //.ToLower
                        objXLWs.Cells[8, 8] = grvDMVTchuan.Rows[i].Cells[7].Value.ToString(); //.ToLower
                        objXLWs.Cells[8, 9] = grvDMVTchuan.Rows[i].Cells[8].Value.ToString(); //.ToLower
                        objXLWs.Cells[8, 10] = grvDMVTchuan.Rows[i].Cells[9].Value.ToString(); //.ToLower
                        objXLWs.Cells[8, 11] = grvDMVTchuan.Rows[i].Cells[10].Value.ToString(); //.ToLower
                    }
                    ((Excel.Range)objXLWs.Rows[7]).Delete();

                    objXLApp.ActiveWorkbook.Save();
                    objXLApp.Workbooks.Close();
                    objXLApp.Quit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    TextUtils.ReleaseComObject(objXLApp);
                    TextUtils.ReleaseComObject(objXLWb);
                    TextUtils.ReleaseComObject(objXLWs);
                }
            }
            MessageBox.Show("Tạo biểu mẫu xác nhận vật tư điện - điện tử thành công!");
        }
        #endregion XÁC NHẬN DANH MỤC VẬT TƯ

        #region KIỂM TRA THƯ MỤC CAD
        private void btnCheckCAD_Click(object sender, EventArgs e)
        {
            grvCAD.DataSource = null;
            grvCAD.AutoGenerateColumns = false;
            bool _OKCAD = true;
            try
            {
                List<string> cadFiles = Directory.GetFiles(_selectedPath + "\\CAD." + _moduleCode, "*.dwg", SearchOption.AllDirectories).ToList();

                if (cadFiles.Count == 0)
                {
                    MessageBox.Show("Không tồn tại file CAD trong thiết kế!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                _cadNumber = cadFiles.Count;
                DataTable dtDMVT = GetDMVT(_pathDMVT.Trim());
                if (dtDMVT == null)
                {
                    MessageBox.Show("Danh mục vật tư không có mã vật tư bắt đầu bằng TPAD", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable dtCAD = new DataTable();
                dtCAD.Columns.Add("Code", typeof(string));
                dtCAD.Columns.Add("CadName", typeof(string));
                dtCAD.Columns.Add("Type", typeof(string));
                dtCAD.Columns.Add("PathL", typeof(string));
                dtDMVT.Columns.Add("Type");

                #region Kiểm tra DMVT
                int rowCount = dtDMVT.Rows.Count;
                for (int i = 0; i <= rowCount - 1; i++)
                {
                    string name = dtDMVT.Rows[i][1].ToString();
                    string nameCad = "";

                    nameCad = cadFiles.Find(o => Path.GetFileNameWithoutExtension(o).Replace(" ", "") == name.Replace(" ", ""));
                    if (name != Path.GetFileNameWithoutExtension(nameCad))
                    {
                        DataRow row = dtCAD.NewRow();
                        row["Code"] = name;
                        row["Type"] = "Không có file CAD";
                        row["CadName"] = "";
                        row["PathL"] = nameCad;
                        dtCAD.Rows.Add(row);
                        _OKCAD = false;
                    }

                }
                #endregion

                #region Kiểm tra thư mục CAD
                for (int j = 0; j <= cadFiles.Count - 1; j++)
                {
                    string nameCad = Path.GetFileNameWithoutExtension(cadFiles[j]).Trim();

                    if (nameCad == _moduleCode.Trim())
                    {
                        continue;
                    }
                    int count = 0;
                    try
                    {
                        count = dtDMVT.Select("F4 = '" + nameCad + "'").Length;
                    }
                    catch
                    {
                    }
                    if (count <= 0)
                    {
                        DataRow row = dtCAD.NewRow();
                        row["Code"] = "";
                        row["Type"] = "Thừa";
                        row["CadName"] = nameCad;
                        row["PathL"] = cadFiles[j];
                        dtCAD.Rows.Add(row);
                        _OKCAD = false;
                    }
                }
                #endregion

                #region Kiểm tra file Cad tổng
                int count1 = 0;
                try
                {
                    count1 = cadFiles.Find(o => Path.GetFileNameWithoutExtension(o).Replace(" ", "") == _moduleCode.Replace(" ", "")).Count();
                }
                catch { }
                if (count1 <= 0)
                {
                    DataRow row = dtCAD.NewRow();
                    row["Code"] = "";
                    row["Type"] = "File Cad tổng " + _moduleCode.Trim() + " không tồn tại";
                    row["CadName"] = _moduleCode.Trim();
                    row["PathL"] = "";
                    dtCAD.Rows.Add(row);
                    //dtDMVT.Rows(i).Item(3) = "Không có file CAD"
                    _OKCAD = false;
                }
                #endregion

                #region Kiểm tra ngày giờ
                //_dtDataMEM
                foreach (string item in cadFiles)
                {
                    string fileName = Path.GetFileNameWithoutExtension(item);
                    DateTime dateFile = File.GetLastWriteTime(item);

                    int count = 0;
                    try
                    {
                        count = _dtDataMEM.Select().Where(o => Path.GetFileNameWithoutExtension(o["Name"].ToString()) == fileName).Count();
                    }
                    catch { }

                    if (count > 0)
                    {
                        try
                        {
                            DataRow dr = (_dtDataMEM.Select().Where(o => Path.GetFileNameWithoutExtension(o["Name"].ToString()) == fileName).ToArray())[0];
                            DateTime iptDate = Convert.ToDateTime(dr["Date"]);
                            if (dateFile < iptDate)
                            {
                                DataRow row = dtCAD.NewRow();
                                row["Code"] = "";
                                row["Type"] = "Chưa xuất lại";
                                row["CadName"] = fileName;
                                row["PathL"] = item;
                                dtCAD.Rows.Add(row);
                                _OKCAD = false;
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
                #endregion

                if (_OKCAD)
                {
                    MessageBox.Show("Thư mục CAD thiết kế '" + _moduleCode.Trim() + "' đã chuẩn", "Thông báo");
                }
                else
                {
                    grvCAD.DataSource = dtCAD.Select("Type <> ''").CopyToDataTable();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCADFile_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("explorer.exe", _selectedPath + "\\CAD." + _moduleCode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void deleteCADFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grvCAD.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn hãy chọn các files muốn xóa!", "Thông báo");
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa các file này?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                foreach (DataGridViewRow grow in grvCAD.SelectedRows)
                {
                    if (grow.Cells[2].Value == null || grow.Cells[2].Value.ToString() != "Thừa")
                    {
                        continue;
                    }
                    if (grow.Cells[2].Value.ToString() == "Thừa")
                    {
                        File.Delete(grow.Cells[3].Value.ToString());
                        grvCAD.Rows.Remove(grow);
                    }
                }
            }
        }

        private void copyFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvCAD.Rows.Count > 0)
                {
                    bool reload = false;
                    foreach (DataGridViewRow itemRow in grvCAD.Rows)
                    {
                        string status = itemRow.Cells[colType.Name].Value.ToString();
                        if (status == "Không có file CAD")
                        {
                            string fileName = itemRow.Cells[0].Value.ToString();
                            string productCode = fileName.Substring(0, 10);
                            string ftpFilePath = "Thietke.Ck/" + productCode.Substring(0, 6) + "/" + productCode + ".Ck/CAD." + productCode + "/" + fileName + ".dwg";
                            string filePath = "D:\\Thietke.Ck\\" + _moduleCode.Substring(0, 6) + "\\" + _moduleCode + ".Ck\\CAD." + _moduleCode;
                            if (DocUtils.CheckExits(ftpFilePath))
                            {
                                DocUtils.DownloadFile(filePath, fileName + ".dwg", ftpFilePath);
                                reload = true;
                            }
                            else
                            {
                                string sourceFileName = "\\SERVER\\data2\\Thietke\\Luutru\\Thietkechuan\\" + ftpFilePath;
                                if (File.Exists(sourceFileName))
                                {
                                    File.Copy(sourceFileName, filePath + "\\" + fileName + ".dwg");
                                    reload = true;
                                }
                            }
                        }
                    }
                    if (reload)
                    {
                        MessageBox.Show("Download file cad Cứng về máy thành công");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy vài file CAD trên nguồn!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    btnCheckCAD_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnCopyAllCad_Click(object sender, EventArgs e)
        {
            copyFileToolStripMenuItem_Click(null, null);
        }
        #endregion KIỂM TRA THƯ MỤC CAD

        #region KIỂM TRA CẤU TRÚC THIẾT KẾ
        private void showSuccessReport()
        {
            string htmlText = ((ConfigSystemModel)ConfigSystemBO.Instance.FindByAttribute("KeyName", "ReportCTTK")[0]).KeyValue;

            DataTable dtDMVT = TextUtils.ExcelToDatatable(_pathDMVT, "DMVT");
            htmlText = htmlText.Replace("<path>", Application.StartupPath + "\\logoTP.png");
            htmlText = htmlText.Replace("<productname>", dtDMVT.Rows[1][2].ToString());
            htmlText = htmlText.Replace("<productcode>", (string)_moduleCode.Trim());
            htmlText = htmlText.Replace("<username>", dtDMVT.Rows[2][2].ToString());
            htmlText = htmlText.Replace("<datedesign>", DateTime.Now.ToString("dd/MM/yyyy"));
            htmlText = htmlText.Replace("<day>", DateTime.Now.Day.ToString());
            htmlText = htmlText.Replace("<month>", DateTime.Now.Month.ToString());
            htmlText = htmlText.Replace("<year>", DateTime.Now.Year.ToString());

            string moduleCode = _moduleCode;
            DataTable dtError = TextUtils.Select(string.Format("select * from [vModuleError] where [ModuleCode]='{0}' and Status = 0 and ConfirmTemp = 0", moduleCode));
            DataTable dtKPH = TextUtils.Select(string.Format("select * from [vMisMatch] where [ModuleCode]='{0}' StatusKCS = 0 and ConfirmTemp = 0", moduleCode));
            htmlText = htmlText.Replace("<qtyError>", dtError.Rows.Count.ToString());
            htmlText = htmlText.Replace("<qtyKPH>", dtKPH.Rows.Count.ToString());

            string saikichthuoc = ((ConfigSystemModel)ConfigSystemBO.Instance.FindByAttribute("KeyName", "SaiKichThuoc")[0]).KeyValue;
            if (_listMaterialSaiKichThuoc.Count > 0)
            {
                string saikichthuocItem = ((ConfigSystemModel)ConfigSystemBO.Instance.FindByAttribute("KeyName", "SaiKichThuocItem")[0]).KeyValue;
                string items = "";
                foreach (MaterialModel item in _listMaterialSaiKichThuoc)
                {
                    items += saikichthuocItem.Replace("<MaterialCode>", item.Code).Replace("<MaterialName>", item.Name);
                }
                saikichthuoc = saikichthuoc.Replace("<items>", items);
            }
            htmlText = htmlText.Replace("<SaiKichThuoc>", saikichthuoc);

            string isNotUse = TextUtils.GetConfigValue("IsNotUse");
            if (_listMaterialNotUse.Count > 0)
            {
                string saikichthuocItem = ((ConfigSystemModel)ConfigSystemBO.Instance.FindByAttribute("KeyName", "SaiKichThuocItem")[0]).KeyValue;
                string items = "";
                foreach (MaterialModel item in _listMaterialNotUse)
                {
                    items += saikichthuocItem.Replace("<MaterialCode>", item.Code).Replace("<MaterialName>", item.Name);
                }
                isNotUse = isNotUse.Replace("<items>", items);
            }
            htmlText = htmlText.Replace("<IsNotUse>", isNotUse);

            frmReportShow frm = new frmReportShow();
            frm.HtmlText = htmlText;
            frm.Show();
        }

        void checkCTTK(DataTable dt, DataTable dtDMVT)
        {
            try
            {
                DataTable dtCT = TextUtils.Select("Select * from DesignStructure where Type = 0");//lấy những thư mục cấu trúc cơ khí
                string[] listDirectories = Directory.GetDirectories(_selectedPath, "**", SearchOption.AllDirectories);
                foreach (string item in listDirectories)
                {
                    string folderName = Path.GetFileName(item);
                    if (item.Contains("COM." + _moduleCode) || item.Contains("OldVersions") || item.Contains("DAT." + _moduleCode)) continue;
                    if (item.Contains("3D." + _moduleCode) && folderName != ("3D." + _moduleCode))
                    {
                        if (!folderName.StartsWith(_moduleCode))
                        {
                            DataRow row = dt.NewRow();
                            row["Name"] = folderName;
                            row["PathLocal"] = item;
                            row["Type"] = "Folder THỪA";
                            dt.Rows.Add(row);
                        }
                    }
                    else
                    {
                        int count = 0;
                        foreach (DataRow r in dtCT.Rows)
                        {
                            string formatFolder = r["Name"].ToString().Replace("code", _moduleCode);
                            if (folderName != formatFolder)
                            {
                                count = 1;
                            }
                            else
                            {
                                count = 0;
                                break;
                            }
                        }
                        if (count == 1)
                        {
                            DataRow row = dt.NewRow();
                            row["Name"] = folderName;
                            row["PathLocal"] = item;
                            row["Type"] = "Folder THỪA";
                            dt.Rows.Add(row);
                        }
                    }
                }
                foreach (DataRow itemRow in dtCT.Rows)
                {
                    string nameCT = itemRow["Name"].ToString().Replace("code", _moduleCode);//OldVersions
                    //int count = listDirectories.Where(o => Path.GetFileName(o) == nameCT).Count();
                    //bool hasCheckFile = TextUtils.ToBoolean(itemRow["IsCheckContent"]);
                    int iD = TextUtils.ToInt(itemRow["ID"]);

                    string[] arrExtension = null;

                    try
                    {
                        arrExtension = itemRow["Extension"].ToString().Split(',').Where(o => o.Trim() != "").ToArray();
                    }
                    catch (Exception)
                    {
                    }

                    string folderPath = Path.GetDirectoryName(_selectedPath) + "\\" + itemRow["Path"].ToString().Replace("code", _moduleCode);
                    if (!Directory.Exists(folderPath))
                    {
                        DataRow row = dt.NewRow();
                        row["Name"] = nameCT;
                        row["PathLocal"] = folderPath;
                        row["Type"] = "THIẾU THƯ MỤC";
                        dt.Rows.Add(row);
                    }
                    else
                    {
                        DataTable dtCTFile = TextUtils.Select("SELECT * FROM DesignStructureFile where DesignStructureID = " + iD);
                        string[] listFiles = Directory.GetFiles(folderPath, "*.*", SearchOption.TopDirectoryOnly);

                        if (dtCTFile.Rows.Count > 0)
                        {
                            foreach (DataRow row in dtCTFile.Rows)
                            {
                                string fileNameCT = row["Name"].ToString().Replace("code", _moduleCode);
                                bool exist = TextUtils.ToBoolean(row["Exist"]);
                                if (exist && !File.Exists(folderPath + "\\" + fileNameCT))
                                {
                                    DataRow row1 = dt.NewRow();
                                    row1["Name"] = fileNameCT;
                                    row1["PathLocal"] = folderPath;
                                    row1["Type"] = "THIẾU FILE";
                                    dt.Rows.Add(row1);
                                }
                            }
                        }

                        if (listFiles.Count() > 0)
                        {
                            foreach (string item in listFiles)
                            {
                                string fileName = Path.GetFileName(item);
                                if (Path.GetExtension(fileName).ToLower() == ".ipt" || Path.GetExtension(fileName).ToLower() == ".lck") continue;
                                if (Path.GetExtension(fileName).ToLower() == ".iam") continue;//(sửa ngày 27/02/2015 không check file iam trong thư mục bất kỳ)
                                if (dtCTFile.Rows.Count > 0)
                                {
                                    int count = 0;
                                    try { count = dtCTFile.Select().Count(r => r["Name"].ToString().Replace("code", _moduleCode) == fileName); }
                                    catch { }
                                    if (count == 0)
                                    {
                                        DataRow row1 = dt.NewRow();
                                        row1["Name"] = fileName;
                                        row1["Size"] = new FileInfo(item).Length;
                                        row1["PathLocal"] = item;
                                        row1["Type"] = "THỪA";
                                        dt.Rows.Add(row1);
                                    }
                                }

                                if (arrExtension != null && arrExtension.Count() > 0 && !arrExtension.Contains(Path.GetExtension(fileName)))
                                {
                                    DataRow row1 = dtLocal.NewRow();
                                    row1["Name"] = fileName;
                                    row1["Size"] = new FileInfo(item).Length;
                                    row1["PathLocal"] = item;
                                    row1["Type"] = "THỪA";
                                    dt.Rows.Add(row1);
                                }
                            }
                        }

                        #region Kiem tra thu muc mat
                        if (nameCT.StartsWith("MAT"))
                        {
                            string[] listFileMAT = Directory.GetFiles(folderPath, "*.*", SearchOption.TopDirectoryOnly);
                            if (listFileMAT.Count() > 0)
                            {
                                foreach (string item in listFileMAT)
                                {
                                    string fileName = Path.GetFileName(item);
                                    if (Path.GetExtension(fileName).ToUpper()!=".DWG")
                                    {
                                        DataRow row1 = dt.NewRow();
                                        row1["Name"] = fileName;
                                        row1["Size"] = new FileInfo(item).Length;
                                        row1["PathLocal"] = item;
                                        row1["Type"] = "THỪA";
                                        dt.Rows.Add(row1);
                                        continue;
                                    }
                                    if (!fileName.StartsWith("TPAD") && (!fileName.Contains("-IN") || !fileName.Contains("-KHAC")) && Path.GetExtension(fileName).ToLower() == ".dwg")
                                    {
                                        DataRow row1 = dt.NewRow();
                                        row1["Name"] = fileName;
                                        row1["Size"] = new FileInfo(item).Length;
                                        row1["PathLocal"] = item;
                                        row1["Type"] = "File mặt không đúng định dạng";
                                        dt.Rows.Add(row1);
                                    }
                                    else
                                    {
                                        string part = "";
                                        string fileNameNoEx = Path.GetFileNameWithoutExtension(item);
                                        if (fileName.Contains("-IN"))
                                        {
                                            part = fileNameNoEx.Substring(0, fileNameNoEx.Length - 3);
                                        }
                                        else
                                        {
                                            part = fileNameNoEx.Substring(0, fileNameNoEx.Length - 5);
                                        }
                                        DataRow[] drs = dtDMVT.Select("F4 = '" + part + "' or F4 like '" + part + "-%'");
                                        if(drs.Length == 0)
                                        {
                                            DataRow row1 = dt.NewRow();
                                            row1["Name"] = fileName;
                                            row1["Size"] = new FileInfo(item).Length;
                                            row1["PathLocal"] = item;
                                            row1["Type"] = "File mặt không có trong DMVT";
                                            dt.Rows.Add(row1);
                                        }
                                    }
                                }
                            }
                        }
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Kiểm tra các thư mục cụm
        /// </summary>
        /// <param name="initPath">Đường dẫn thư mục cụm</param>
        void checkCum(string initPath, DataTable dt)
        {
            string[] listDirectories = Directory.GetDirectories(initPath, _moduleCode + "*", SearchOption.AllDirectories);
            foreach (string path in listDirectories)
            {
                string[] listChild = Directory.GetDirectories(path, _moduleCode + "*", SearchOption.TopDirectoryOnly);
                if (listChild.Length > 0)
                {
                    continue;
                }

                string[] listFileIPT = Directory.GetFiles(path, "*.ipt", SearchOption.TopDirectoryOnly);
                string[] listFileIAM = Directory.GetFiles(path, "*.iam", SearchOption.TopDirectoryOnly);

                if (listFileIAM.Length > 0 && listFileIPT.Length == 0)
                {
                    DataRow row = dt.NewRow();
                    row["Name"] = Path.GetFileName(path);
                    //row["Size"] = "";
                    row["PathLocal"] = path;
                    row["Type"] = "CHƯA CÓ TÀI LIỆU 3D";
                    dt.Rows.Add(row);
                }

                if (listFileIAM.Length == 0 && listFileIPT.Length > 0)
                {
                    DataRow row = dt.NewRow();
                    row["Name"] = Path.GetFileName(path);
                    //row["Size"] = "";
                    row["PathLocal"] = path;
                    row["Type"] = "THIẾU FILE .iam";
                    dt.Rows.Add(row);
                }
            }

        }
        void checkCumQLSX(string initPath, DataTable dt)
        {
            string[] listDirectories = Directory.GetDirectories(initPath, _moduleCode + "*", SearchOption.AllDirectories);
            foreach (string path in listDirectories)
            {
                string[] listChild = Directory.GetDirectories(path, _moduleCode + "*", SearchOption.TopDirectoryOnly);
                string pathName = Path.GetFileName(path);

                if (listChild.Length > 0) continue;
                if (path.Contains("OldVersions")) continue;
                if (path.Contains(initPath + "\\" + "COM." + _moduleCode)) continue;

                string[] listFileIPT = Directory.GetFiles(path, "*.ipt", SearchOption.TopDirectoryOnly);
                string[] listFileIAM = Directory.GetFiles(path, "*.iam", SearchOption.TopDirectoryOnly);

                if (listFileIAM.Length > 0 && listFileIPT.Length == 0)
                {
                    if (listFileIAM.Length == 1)
                    {
                        DataRow row = dt.NewRow();
                        row["Name"] = Path.GetFileName(path);
                        //row["Size"] = "";
                        row["PathLocal"] = path;
                        row["Type"] = "FILE iam sai thư mục chứa";
                        dt.Rows.Add(row);
                    }
                    else
                    {
                        foreach (string fileiamPath in listFileIAM)
                        {
                            string fileNameIam = Path.GetFileName(fileiamPath);
                            if (!fileNameIam.StartsWith(pathName))
                            {
                                DataRow row = dt.NewRow();
                                row["Name"] = fileNameIam;
                                //row["Size"] =;
                                row["PathLocal"] = fileiamPath;
                                row["Type"] = "FILE iam sai thư mục chứa";
                                dt.Rows.Add(row);
                            }
                        }
                    }
                }

                if (listFileIAM.Length == 0 && listFileIPT.Length == 0)
                {
                    DataRow row = dt.NewRow();
                    row["Name"] = Path.GetFileName(path);
                    //row["Size"] = "";
                    row["PathLocal"] = path;
                    row["Type"] = "Folder THỪA";
                    dt.Rows.Add(row);
                }
                
                if (listFileIPT.Length > 0)
                {
                    foreach (string filePath in listFileIPT)
                    {
                        if (!Path.GetFileNameWithoutExtension(filePath).StartsWith(pathName))
                        {
                            DataRow row = dt.NewRow();
                            row["Name"] = Path.GetFileName(filePath);
                            row["Size"] = new FileInfo(filePath).Length.ToString(); 
                            row["PathLocal"] = filePath;
                            row["Type"] = "File không đúng thư mục chứa";
                            dt.Rows.Add(row);
                        }
                    }
                }
            }
        }

        private void btnCheckCT_Click(object sender, EventArgs e)
        {
            ModulesModel module;
            try
            {
                module = (ModulesModel)ModulesBO.Instance.FindByAttribute("Code", _moduleCode)[0];
            }
            catch (Exception)
            {
                MessageBox.Show("Module chưa được tạo trên quản lý thiết kế!", TextUtils.Caption);
                return;
            }

            _listMaterialSaiKichThuoc.Clear();
            _listMaterialNotUse.Clear();

            List<string> listErrorMain = new List<string>();

            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang kiểm tra cấu trúc thiết kế"))
            {
                //try
                //{
                    #region Kiểm tra
                    if (_pathDMVT == null)
                    {
                        MessageBox.Show("Xin vui lòng chọn bản thiết kế cần kiểm tra! ", "Thông báo");
                        return;
                    }

                    DataTable dtDMVT = GetDMVT_Excel(_pathDMVT);
                    if (dtDMVT == null)
                    {
                        MessageBox.Show("Chưa tồn tại danh mục vật tư trong thiết kế." + Environment.NewLine + "Hoặc nội dung của nó không đúng định dạng.", "Thông báo");
                        return;
                    }
                    #endregion Kiểm tra

                    #region Tạo Bảng Ảo
                    dtLocal.Rows.Clear();
                    #endregion

                    string pathLocal = _selectedPath + "\\3D." + _moduleCode;
                    System.IO.DirectoryInfo dirLocal = new System.IO.DirectoryInfo(pathLocal);
                    System.IO.DirectoryInfo dir3D = new System.IO.DirectoryInfo(_pathThuVien3D);
                    FileInfo[] listLocal = dirLocal.GetFiles("*.*", System.IO.SearchOption.AllDirectories);//Lấy danh sách các file trên thư viện 3D máy cá nhân
                    
                    if (listLocal.Length == 0)
                    {
                        MessageBox.Show("Thiết kế chưa hoàn thành!", "Thông báo");
                        return;
                    }

                    DocUtils.InitFTPTK();

                    #region Lấy danh sách cấu hình
                    string[] contentNotCheck = null;
                    try
                    {
                        DataTable dt = TextUtils.Select("SELECT ID, KeyName, KeyValue, Description FROM ConfigSystem WHERE (KeyName = N'CTTK')");
                        contentNotCheck = dt.Rows[0]["KeyValue"].ToString().Split(',').Where(o => o.Trim() != "").ToArray();
                    }
                    catch (Exception)
                    {
                        contentNotCheck = null;
                    }
                    DataTable dtVatLieuDMVT = TextUtils.Select("SELECT ID, KeyName, KeyValue, Description FROM ConfigSystem WHERE (KeyName = N'VatLieuDMVT')");
                    List<string> listVatLieuDMVT = dtVatLieuDMVT.Rows[0]["KeyValue"].ToString().Split(',').Where(o => o.Trim() != "").ToList();
                    #endregion

                    #region Kiểm tra thư mục 3D
                    foreach (FileInfo fi in listLocal)
                    {
                        if (fi.FullName.Contains("lockfile") || fi.FullName.Contains("OldVersions") || Path.GetExtension(fi.FullName).ToLower() == ".idw"
                            || Path.GetExtension(fi.FullName).ToLower() == ".ipj" || Path.GetExtension(fi.FullName).ToLower() == ".iam")
                        {
                            continue;
                        }
                        string name = Path.GetFileNameWithoutExtension(fi.Name);
                        string nameVT = "";
                        string serverPath = "";
                        string hang = "";
                        if (fi.Extension.ToLower() != ".ipt")
                        {
                            DataRow row = dtLocal.NewRow();
                            row["Name"] = name;
                            row["NameVT"] = nameVT;
                            row["Hang"] = hang;
                            row["Size"] = fi.Length;
                            row["PathLocal"] = fi.FullName;
                            row["Path3D"] = serverPath;
                            row["Type"] = "THỪA";
                            dtLocal.Rows.Add(row);
                            continue;
                        }
                        DataTable dtMaterialCSDL = TextUtils.Select("SELECT * FROM [MaterialFile] with (nolock) where [FileType] = 0 and replace(Name,' ','') = N'" + fi.Name.Replace(" ", "").Replace("''","''''") + "'");
                        
                        if (dtMaterialCSDL.Rows.Count > 0)
                        {
                            serverPath = TextUtils.ToString(dtMaterialCSDL.Rows[0]["Path"]);
                        }

                        #region Những vật tư không cần kiểm tra
                        bool dk = false;
                        if (contentNotCheck != null)
                        {
                            foreach (string a in contentNotCheck)
                            {
                                if (a == null || a.Trim() == "")
                                {
                                    continue;
                                }
                                if (a == contentNotCheck[0])
                                {
                                    dk = System.Convert.ToBoolean(name.ToUpper().StartsWith(a));
                                }
                                dk = dk || name.ToUpper().StartsWith(a);
                                if (dk)
                                {
                                    break;
                                }
                            }
                        }

                        if (dk)
                        {
                            continue;
                        }
                        #endregion
                        
                        char[] sp = { '\\' };
                        string[] split = fi.FullName.Split(sp);
                        hang = split[split.Length - 2];
                        if (hang.Contains("3D.") || hang.Contains("TPAD."))
                        {
                            hang = "";
                        }
                        
                        int count = 0;

                        //DataRow[] drsDMVT = dtDMVT.Select("F4 = '" + name.Replace(" ", "").Replace(")", "/") + "'");
                        string filterString = "F4 = '" + name.Replace(" ", "") + "' or F4 = '" + name.Replace(" ", "").Replace(")", "/").Replace("''", "''''") + "'";
                        //string filterString = "F4 = '" + name.Replace(" ", "") + "' or F4 = '" + name.Replace(" ", "").Replace(")", "/").Replace("\"", "") + "'";
                        DataRow[] drsDMVT = null;
                        try 
	                    {
                            drsDMVT = dtDMVT.Select(filterString);
	                    }
	                    catch 
	                    {
                            DataRow row = dtLocal.NewRow();
                            row["Name"] = name;
                            row["NameVT"] = nameVT;
                            row["Hang"] = hang;
                            row["Size"] = fi.Length;
                            row["PathLocal"] = fi.FullName;
                            row["Path3D"] = serverPath;
                            row["Type"] = "THỪA";
                            dtLocal.Rows.Add(row);
                            continue;
	                    }

                        
                        if (drsDMVT.Length > 0)
                        {
                            nameVT = TextUtils.ToString(drsDMVT[0]["F2"]);
                        }
                        //count = Convert.ToInt32(dtDMVT.Select("F4 = '" + name.Replace(" ", "").Replace(")", "/") + "'").Length);
                        count = drsDMVT.Length;

                        if (count > 0)
                        {
                            #region Kiểm tra thư viện 3D
                            if (dtMaterialCSDL.Rows.Count > 0)
                            {                                
                                if (fi.Length != DocUtils.GetFileSize(serverPath))
                                {
                                    DataRow row = dtLocal.NewRow();
                                    row["Name"] = name;
                                    row["NameVT"] = nameVT;
                                    row["Hang"] = hang;
                                    row["Size"] = fi.Length;
                                    row["PathLocal"] = fi.FullName;
                                    row["Path3D"] = serverPath;
                                    row["Type"] = "Khác size";
                                    dtLocal.Rows.Add(row);
                                }

                                string materialCode = Path.GetFileNameWithoutExtension(dtMaterialCSDL.Rows[0]["Name"].ToString()).Replace(")", "/");
                                MaterialModel model = null;
                                try
                                {
                                    model = (MaterialModel)MaterialBO.Instance.FindByAttribute("Code", materialCode)[0];
                                }
                                catch (Exception)
                                {
                                }
                                if (model != null)
                                {
                                    if (model.MaterialGroupID == 282)//TPAVT.Z02
                                    {
                                        _listMaterialSaiKichThuoc.Add(model);
                                    }
                                }
                            }
                            else
                            {
                                if (hang != "")
                                {
                                    if (!name.StartsWith("TPAD"))
                                    {
                                        DataRow row = dtLocal.NewRow();
                                        row["Name"] = name;
                                        row["NameVT"] = nameVT;
                                        row["Hang"] = hang;
                                        row["Size"] = fi.Length;
                                        row["PathLocal"] = fi.FullName;
                                        row["Path3D"] = serverPath;
                                        row["Type"] = "Không có trong thư viện 3D";
                                        dtLocal.Rows.Add(row);
                                        //type = "Không có trong thư viện 3D";
                                    }
                                }
                            }

                            if (!name.ToLower().StartsWith(_moduleCode.ToLower()))
                            {
                                string error = "";
                                if (!fi.FullName.Contains("COM." + _moduleCode.ToUpper()))
                                {
                                    error = "File không đúng địa chỉ";
                                }
                                else
                                {
                                    if (!name.ToLower().StartsWith("tpad"))
                                    {
                                        if (Path.GetFileName(Path.GetDirectoryName(fi.FullName)).ToLower() != hang.ToLower())
                                        {
                                            error = "File không đúng địa chỉ";
                                        }
                                    }
                                    else
                                    {
                                        if (!fi.FullName.Contains("\\TPA\\"))
                                        {
                                            error = "File không đúng địa chỉ";
                                        }
                                    }
                                }

                                if (error != "")
                                {
                                    DataRow row = dtLocal.NewRow();
                                    row["Name"] = name;
                                    row["NameVT"] = nameVT;
                                    row["Hang"] = hang;
                                    row["Size"] = fi.Length;
                                    row["PathLocal"] = fi.FullName;
                                    row["Path3D"] = serverPath;
                                    row["Type"] = error;
                                    dtLocal.Rows.Add(row);
                                }                                
                            }
                            else //Kiểm tra thiết kế 3D trên nguồn với trên thiết kế
                            {
                                DocUtils.InitFTPQLSX();
                                string ftpFilePath = fi.FullName.Replace("D:", "");
                                //string ftpPath = string.Format("/Thietke.Ck/{0}/{1}.Ck", _productCode.Substring(0, 6), _productCode);
                                if (DocUtils.CheckExits(ftpFilePath))
                                {
                                    if (fi.Length != DocUtils.GetFileSize(ftpFilePath))
                                    {
                                        DataRow row1 = dtLocal.NewRow();
                                        row1["Name"] = name;
                                        row1["PathLocal"] = fi.FullName;
                                        row1["Path3D"] = ftpFilePath;
                                        row1["Type"] = "Khác size với thiết kế cũ trên nguồn";
                                        dtLocal.Rows.Add(row1);
                                    }
                                }                                
                                DocUtils.InitFTPTK();
                            }
                            #endregion Kiểm tra thư viện 3D
                        }
                        else
                        {
                            if (hang != "TPA")
                            {
                                DataRow row = dtLocal.NewRow();
                                row["Name"] = name;
                                row["NameVT"] = nameVT;
                                row["Hang"] = hang;
                                row["Size"] = fi.Length;
                                row["PathLocal"] = fi.FullName;
                                row["Path3D"] = serverPath;
                                row["Type"] = "THỪA";
                                dtLocal.Rows.Add(row);
                                //type = "THỪA";
                            }
                        }                        
                    }
                    #endregion Kiểm tra thư mục 3D

                    #region Kiểm tra danh mục vật tư
                    for (int i = 0; i <= dtDMVT.Rows.Count - 1; i++)
                    {
                        string codeVT = dtDMVT.Rows[i][3].ToString();
                        if (codeVT == "") continue;
                        string nameVT = TextUtils.ToString(dtDMVT.Rows[i][1]).Trim();
                        string stt = TextUtils.ToString(dtDMVT.Rows[i][0]).Trim();
                        string unit = TextUtils.ToString(dtDMVT.Rows[i][5]).Trim();

                        string sourceCode = TextUtils.ToString(dtDMVT.Rows[i][4]).Trim();
                        string vatLieu = TextUtils.ToString(dtDMVT.Rows[i][7]).Trim();
                        string khoiLuong = TextUtils.ToString(dtDMVT.Rows[i][8]).Trim();
                        string hang = TextUtils.ToString(dtDMVT.Rows[i][9]).Trim();

                        string thongSo = TextUtils.ToString(dtDMVT.Rows[i][2]).Trim();

                        int parent = stt.Split('.').Count();                        
                        
                        string comPath1 = string.Format(pathLocal + "\\COM.{0}\\", _moduleCode);

                        if (codeVT.ToUpper() == _moduleCode.ToUpper())
                        {
                            DataRow row1 = dtLocal.NewRow();
                            row1["Name"] = codeVT;
                            row1["PathLocal"] = "Trong DMVT";
                            row1["Type"] = "Vật tư không được cùng mã với module";
                            row1["NameVT"] = nameVT;
                            dtLocal.Rows.Add(row1);
                            continue;
                        }

                        #region Kiểm tra vật liệu
                        if (vatLieu != "")
                        {
                            if (vatLieu != "-")
                            {
                                DataTable dtVatLieu =
                                TextUtils.Select("select * from [Stuffs] with(nolock) where Code = N'" + vatLieu + "'");
                                if (dtVatLieu.Rows.Count == 0)
                                {
                                    DataRow row1 = dtLocal.NewRow();
                                    row1["Name"] = codeVT;
                                    row1["PathLocal"] = "Trong DMVT";
                                    row1["Type"] = "Vật liệu không tồn tại";
                                    row1["NameVT"] = nameVT;
                                    dtLocal.Rows.Add(row1);
                                }
                            }
                        }
                        else
                        {
                            DataRow row1 = dtLocal.NewRow();
                            row1["Name"] = codeVT;
                            row1["PathLocal"] = "Trong DMVT";
                            row1["Type"] = "Vật liệu không tồn tại";
                            row1["NameVT"] = nameVT;
                            dtLocal.Rows.Add(row1);
                        }
                        #endregion

                        #region Kiểm tra thông số hàng hãng
                        if (hang.ToUpper() != "TPA" && thongSo != "")
                        {
                            DataRow row1 = dtLocal.NewRow();
                            row1["Name"] = codeVT;
                            row1["PathLocal"] = "Trong DMVT";
                            row1["Type"] = "Thông số sai";
                            row1["NameVT"] = nameVT;
                            dtLocal.Rows.Add(row1);
                        }
                        #endregion

                        if (unit == "BỘ")
                        {
                            if (!codeVT.StartsWith("TPAD.") && !codeVT.StartsWith("PCB."))
                            {
                                DataRow row1 = dtLocal.NewRow();
                                row1["Name"] = codeVT;
                                row1["PathLocal"] = "Trong DMVT";;
                                row1["Type"] = "Vật tư sai đơn vị";
                                row1["NameVT"] = nameVT;
                                dtLocal.Rows.Add(row1);
                            }

                            #region Kiểm tra vật tư đơn vị là Bộ
                            DataRow[] drs = dtDMVT.Select("F1 like '" + stt + ".%' and F4 like '" + _moduleCode + "%'");
                            if (drs.Count() > 0)
                            {
                                foreach (DataRow r in drs)
                                {
                                    string sttChild = r[0].ToString();
                                    string[] splitFileName = sttChild.Split('.');
                                    int child = splitFileName.Count();

                                    if (child - parent != 1) continue;

                                    string unitChild = r[5].ToString();
                                    if (unitChild == "BỘ") continue;

                                    string materialCode = r[3].ToString();
                                    string materialName = r[1].ToString();

                                    if (materialCode.StartsWith(codeVT))
                                    {
                                        string[] splitMaterialCode = materialCode.Split('.');
                                        string thisFilePath = pathLocal + "\\";
                                        string ne = _moduleCode;
                                        for (int ii = 2; ii < splitMaterialCode.Length; ii++)
                                        {
                                            ne += "." + splitMaterialCode[ii];
                                            if (ii == splitMaterialCode.Length - 1)
                                            {
                                                thisFilePath += ne;
                                            }
                                            else
                                            {
                                                thisFilePath += ne + "\\";
                                            }
                                        }

                                        thisFilePath += ".ipt";
                                        if (!File.Exists(thisFilePath))
                                        {
                                            DataRow row1 = dtLocal.NewRow();
                                            row1["Name"] = materialCode;
                                            row1["PathLocal"] = thisFilePath;
                                            row1["Type"] = "Vật tư không có tài liệu 3D";
                                            row1["NameVT"] = materialName;
                                            dtLocal.Rows.Add(row1);
                                        }
                                    }
                                }
                            }
                            #endregion
                        }
                        else if (unit == "CÁI" )
                        {
                            if (codeVT.StartsWith("PCB.") || (codeVT.StartsWith("TPAD.") && codeVT.Length == 10))
                            {
                                DataRow row1 = dtLocal.NewRow();
                                row1["Name"] = codeVT;
                                row1["PathLocal"] = "Trong DMVT";
                                row1["Type"] = "Vật tư sai đơn vị";
                                row1["NameVT"] = nameVT;
                                dtLocal.Rows.Add(row1);
                            }

                            #region Kiểm tra vật tư thường được sử dụng
                            DataTable dtViewMaterial = TextUtils.Select("SELECT top 1 * FROM [vMaterial] with (nolock) where replace(replace(Code,' ',''),')','/') = '" 
                                + codeVT.Replace(" ", "").Replace(")", "/") + "'");
                            if (dtViewMaterial.Rows.Count>0)
                            {
                                bool isUse = TextUtils.ToBoolean(dtViewMaterial.Rows[0]["IsUse"]);
                                if (!isUse)
                                {
                                    int id = TextUtils.ToInt(dtViewMaterial.Rows[0]["ID"]);
                                    int groupId = TextUtils.ToInt(dtViewMaterial.Rows[0]["MaterialGroupID"]);
                                    DataTable dtGroup = TextUtils.Select("SELECT top 1 * FROM [vMaterial] with (nolock) where IsUse = 1 and MaterialGroupID = " + groupId);
                                    if (dtGroup.Rows.Count > 0)
                                    {
                                        _listMaterialNotUse.Add((MaterialModel)MaterialBO.Instance.FindByPK(id));
                                    }
                                }
                            }                           
                            #endregion

                            #region Kiểm tra vật tư đơn vị là Cái
                            if (codeVT.StartsWith(_moduleCode) && parent == 1)
                            {                                
                                string thisFilePath = pathLocal + "\\";
                                if (!File.Exists(thisFilePath + codeVT + ".ipt"))
                                {
                                    DataRow row1 = dtLocal.NewRow();
                                    row1["Name"] = codeVT;
                                    row1["PathLocal"] = "Trong DMVT";
                                    row1["Type"] = "Vật tư không có tài liệu 3D";
                                    row1["NameVT"] = nameVT;
                                    dtLocal.Rows.Add(row1);
                                }
                            }
                           
                            #endregion
                        }
                        else
                        {
                            if (unit != "M" )
                            {
                                DataRow row1 = dtLocal.NewRow();
                                row1["Name"] = codeVT;
                                row1["PathLocal"] = "Trong DMVT";
                                row1["Type"] = "Vật tư sai đơn vị";
                                row1["NameVT"] = nameVT;
                                dtLocal.Rows.Add(row1);
                            }
                        }

                        if (!Directory.Exists(comPath1 + hang))
                        {
                            #region Kiểm tra sự tồn tại của thư mục hãng trong thiết kế
                            if (!codeVT.StartsWith("TPAD") && !codeVT.StartsWith("PCB"))
                            {
                                DataRow row1 = dtLocal.NewRow();
                                row1["Name"] = hang;
                                row1["PathLocal"] = comPath1;
                                row1["Type"] = "Không tồn tại hãng này trong thiết kế";
                                dtLocal.Rows.Add(row1);
                            }
                            else if (codeVT.StartsWith("TPAD"))
                            {
                                if (codeVT.Substring(0, 10) != _moduleCode)
                                {
                                    DataRow row1 = dtLocal.NewRow();
                                    row1["Name"] = hang;
                                    row1["PathLocal"] = comPath1;
                                    row1["Type"] = "Không tồn tại hãng này trong thiết kế";
                                    dtLocal.Rows.Add(row1);
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            if (!codeVT.StartsWith("TPAD") && !codeVT.StartsWith("PCB"))
                            {
                                //Kiểm tra xem vật tư có tồn tại trong thư mục hãng không
                                System.IO.DirectoryInfo dirComFile = new System.IO.DirectoryInfo(comPath1 + hang);
                                FileInfo[] listFileInHang = dirComFile.GetFiles("*.ipt*", SearchOption.TopDirectoryOnly);
                                int count = 0;
                                try
                                {
                                    count = listFileInHang.Count(o => Path.GetFileNameWithoutExtension(o.Name)
                                        .Replace(" ", "").Replace(")", "/")
                                        == codeVT.Replace(" ", "").Replace(")", "/"));
                                }
                                catch
                                {
                                }
                                if (count == 0)
                                {
                                    DataRow row = dtLocal.NewRow();
                                    row["Name"] = codeVT;
                                    row["Type"] = "Vật tư không có tài liệu 3D";
                                    row["Hang"] = hang;
                                    row["NameVT"] = nameVT;
                                    dtLocal.Rows.Add(row);
                                }
                                else
                                {
                                    #region Kiem tra hang co hop le
                                    DataTable dtGroup = TextUtils.Select("select CustomerCode from vMaterialCustomer a where replace(replace(a.Code,' ',''),')','/') ='" + codeVT.Replace(" ", "").Replace(")", "/") + "'");
                                    if (dtGroup.Rows.Count > 0)
                                    {
                                        DataRow[] drsCustomer = dtGroup.Select("CustomerCode = '" + hang + "'");
                                        if (drsCustomer.Count() == 0)
                                        {
                                            DataRow row = dtLocal.NewRow();
                                            row["Name"] = codeVT;
                                            row["Type"] = "Hãng không được sử dụng";
                                            row["Hang"] = hang;
                                            row["NameVT"] = nameVT;
                                            dtLocal.Rows.Add(row);
                                        }
                                    }
                                    #endregion
                                }

                                #region Vật tư dừng sử dụng
                                decimal currentQty = TextUtils.ToDecimal(dtDMVT.Rows[i][6]);
                                DataTable dtTonKho = LibQLSX.Select("select dbo.fMaterialInventory('" + codeVT.Replace(" ", "").Replace(")", "/") + "')");
                                decimal inventoryQty = TextUtils.ToDecimal(dtTonKho.Rows[0][0]);
                                if (currentQty > inventoryQty)
                                {
                                    //Kiểm tra vật tư dừng sử dụng
                                    DataTable dtViewMaterial = TextUtils.Select("SELECT MaterialGroupCode FROM [vMaterial] with (nolock) where replace(replace(Code,' ',''),')','/') = '" + codeVT.Replace(" ", "").Replace(")", "/") + "'");
                                    if (dtViewMaterial.Rows.Count > 0)
                                    {
                                        string materialGroupCode = dtViewMaterial.Rows[0][0].ToString();
                                        if (materialGroupCode == "TPAVT.Z01")
                                        {
                                            DataRow row = dtLocal.NewRow();
                                            row["Name"] = codeVT;
                                            row["Type"] = "Vật tư ngừng sử dụng";
                                            row["Hang"] = hang;
                                            row["NameVT"] = nameVT;
                                            dtLocal.Rows.Add(row);
                                            listErrorMain.Add(codeVT + " - " + TextUtils.ToString(row["Type"]));
                                        }
                                    }

                                    //Kiểm tra sự tạm dừng của vật tư
                                    DataTable dtMaterialCSDL = TextUtils.Select("SELECT * FROM [Material] with (nolock) where [StopStatus] = 1 and replace(replace(Code,' ',''),')','/') = '" + codeVT.Replace(" ", "").Replace(")", "/") + "'");
                                    if (dtMaterialCSDL.Rows.Count > 0)
                                    {
                                        DataRow row = dtLocal.NewRow();
                                        row["Name"] = codeVT;
                                        row["Type"] = "Vật tư tạm dừng sử dụng";
                                        row["Hang"] = hang;
                                        row["NameVT"] = nameVT;
                                        dtLocal.Rows.Add(row);
                                        listErrorMain.Add(codeVT + " - " + TextUtils.ToString(row["Type"]));
                                    }
                                }
                                #endregion

                                #region Kiểm tra trên quản lý sản xuất
                                //Kiem tra xem vat tu co trong kho chua
                                DataTable dtMaterialQLSX = LibQLSX.Select("SELECT top 1 p.PartsCode,m.ManufacturerCode"
                                    + " FROM Manufacturer m RIGHT OUTER JOIN"
                                    + " PartsManufacturer pm ON m.ManufacturerId = pm.ManufacturerId RIGHT OUTER JOIN"
                                    + " Parts p ON pm.PartsId = p.PartsId"
                                    + " where replace(REPLACE(REPLACE(p.PartsCode, CHAR(13), ''), CHAR(10), ''),')','/') = N'" + codeVT.Replace(" ", "").Replace(")", "/").Replace("''","''''") + "'");
                                if (dtMaterialQLSX.Rows.Count == 0)
                                {
                                    DataRow row = dtLocal.NewRow();
                                    //row["STT"] = dtDMVT.Rows[i][0].ToString();
                                    row["Name"] = codeVT;
                                    row["Type"] = "Vật tư không tồn tại trên QLSX";
                                    row["Hang"] = hang;
                                    row["NameVT"] = nameVT;
                                    dtLocal.Rows.Add(row);
                                }
                                else
                                {
                                    string hangQLSX = dtMaterialQLSX.Rows[0]["ManufacturerCode"].ToString().ToUpper();
                                   
                                    if ( hangQLSX!= hang.ToUpper())
                                    {
                                        DataRow row = dtLocal.NewRow();
                                        //row["STT"] = dtDMVT.Rows[i][0].ToString();
                                        row["Name"] = codeVT;
                                        row["Type"] = "Hãng khác với hãng trên QLSX (" + hang + " - " + dtMaterialQLSX.Rows[0]["ManufacturerCode"].ToString() + ")";
                                        row["Hang"] = hang;
                                        //row["Size"] = dtMaterialQLSX.Rows[0]["ManufacturerCode"].ToString();
                                        row["NameVT"] = nameVT;
                                        dtLocal.Rows.Add(row);
                                    }
                                }
                                #endregion
                            }
                            else
                            {
                                #region Kiểm tra các module con
                                if (codeVT.StartsWith("TPAD") && codeVT.Length == 10 && codeVT != _moduleCode)
                                {
                                    //Kiểm tra lỗi trong module con
                                    string moduleCode = codeVT;
                                    DataTable dtError = TextUtils.Select(
                                        string.Format("select * from [vModuleError] where [ModuleCode]='{0}' and Status = 0 and ConfirmTemp = 0", moduleCode));
                                    DataTable dtKPH = TextUtils.Select(
                                        string.Format("select * from [vMisMatch] where [ModuleCode]='{0}' StatusKCS = 0 and ConfirmTemp = 0", moduleCode));
                                    if (dtError.Rows.Count > 0 || dtKPH.Rows.Count > 0)
                                    {
                                        DataRow row = dtLocal.NewRow();
                                        row["Name"] = codeVT;
                                        row["Type"] = "Có " + dtError.Rows.Count + " lỗi và " + dtKPH.Rows.Count + " sự không phù hợp";
                                        row["Hang"] = hang;
                                        row["NameVT"] = nameVT;
                                        dtLocal.Rows.Add(row);
                                    }

                                    //Kiểm tra sự tồn tại trong thiết kế
                                    if (!File.Exists(comPath1 + "TPA\\" + codeVT + ".ipt"))
                                    {
                                        DataRow row = dtLocal.NewRow();
                                        row["Name"] = codeVT;
                                        row["Type"] = "Vật tư không có tài liệu 3D";
                                        row["Hang"] = hang;
                                        row["NameVT"] = nameVT;
                                        dtLocal.Rows.Add(row);
                                    }
                                }
                                if (codeVT.StartsWith("PCB"))
                                {
                                }
                                #endregion
                            }
                        }

                        #region Kiểm tra vật tư nguồn
                        if (sourceCode != "")
                        {
                            DataTable dtMaterialQLSX_VTN = LibQLSX.Select("SELECT top 1 * FROM vPartsManufacture"
                                 + " where  REPLACE(REPLACE(REPLACE(PartsCode, CHAR(13), ''), CHAR(10), ''),')','/') = '" + sourceCode.Replace(" ", "").Replace(")", "/") + "'");
                            if (dtMaterialQLSX_VTN.Rows.Count == 0)
                            {
                                DataRow row = dtLocal.NewRow();
                                row["Name"] = codeVT;
                                row["Type"] = "Vật tư nguồn (" + sourceCode + ") không tồn tại trên QLSX";
                                row["Hang"] = hang;
                                row["NameVT"] = nameVT;
                                dtLocal.Rows.Add(row);
                                listErrorMain.Add(codeVT + " - " + TextUtils.ToString(row["Type"]));
                            }
                            else
                            {
                                string unitNguon = TextUtils.ToString(dtMaterialQLSX_VTN.Rows[0]["Unit"]).Trim();
                                if (unitNguon.ToUpper() == "M" || unitNguon.ToUpper() == "MET" || unitNguon.ToUpper() == "MM")//|| unitNguon.ToUpper() == "THANH" 
                                {
                                    //Kiểm tra việc chuyển đổi đơn vị của vật tư
                                    DataTable dtUnitDefinition = LibQLSX.Select("SELECT top 1 * FROM [vUnitDefinition] with(nolock)"
                                        + " WHERE REPLACE(REPLACE(PartsCode, CHAR(13), ''), CHAR(10), '') = '" + sourceCode + "'");
                                    if (dtUnitDefinition.Rows.Count == 0)
                                    {
                                        DataRow row = dtLocal.NewRow();
                                        row["Name"] = codeVT;
                                        row["Type"] = "Vật tư nguồn (" + sourceCode + ") chưa được chuyển đổi đơn vị";
                                        row["Hang"] = hang;
                                        row["NameVT"] = nameVT;
                                        dtLocal.Rows.Add(row);
                                        listErrorMain.Add(codeVT + " - " + TextUtils.ToString(row["Type"]));
                                    }
                                }
                            }

                            if (vatLieu == "" || vatLieu=="-")
                            {
                                DataRow row = dtLocal.NewRow();
                                row["Name"] = codeVT;
                                row["Type"] = "Vật liệu không có giá trị trong DMVT";
                                row["Hang"] = hang;
                                row["NameVT"] = nameVT;
                                dtLocal.Rows.Add(row);
                            }

                            if (khoiLuong == "" || khoiLuong == "-")
                            {
                                DataRow row = dtLocal.NewRow();
                                row["Name"] = codeVT;
                                row["Type"] = "Khối lượng không có giá trị trong DMVT";
                                row["Hang"] = hang;
                                row["NameVT"] = nameVT;
                                dtLocal.Rows.Add(row);
                            }
                        }
                        if (thongSo == "TPA" && codeVT.StartsWith("TPAD") && hang == "TPA")
                        {
                            if (listVatLieuDMVT.Contains(vatLieu))
                            {
                                if (sourceCode == "")
                                {
                                    DataRow row = dtLocal.NewRow();
                                    row["Name"] = codeVT;
                                    row["Type"] = "Vật liệu nguồn không thể để trống";
                                    row["Hang"] = hang;
                                    row["NameVT"] = nameVT;
                                    dtLocal.Rows.Add(row);
                                }
                            }
                        }
                        #endregion
                    }
                    #endregion Kiểm tra vật tư trong danh mục vật tư nhưng không có trong thiết kế

                    checkCumQLSX(pathLocal, dtLocal);

                    checkCTTK(dtLocal, dtDMVT);

                    #region Kiểm tra thông số kỹ thuật
                    //ModulesModel module = (ModulesModel)ModulesBO.Instance.FindByAttribute("Code", _moduleCode)[0];
                    if (module.Specifications.Length <= 20)
                    {
                        string filePathTSKT = string.Format("D:/Thietke.Ck/{0}/{1}.Ck/DOC.{1}/TSKT.{1}.docx", _moduleCode.Substring(0, 6), _moduleCode);
                        if (!File.Exists(filePathTSKT))
                        {
                            DataRow row1 = dtLocal.NewRow();
                            row1["Name"] = Path.GetFileName(filePathTSKT);
                            //row["Size"] = "";
                            row1["PathLocal"] = Path.GetDirectoryName(filePathTSKT);
                            row1["Type"] = "THIẾU FILE";
                            dtLocal.Rows.Add(row1);
                        }
                    }
                    #endregion Kiểm tra thông số kỹ thuật

                    #region Kiểm tra file iam
                    try
                    {
                        //List<FileInfo> listFileIam = listLocal.Where(o => o.Extension == ".iam").ToList();
                        //foreach (FileInfo item in listFileIam)
                        //{
                        //    if (item.FullName.Contains("COM." + _productCode) || item.FullName.Contains("OldVersions"))
                        //    {
                        //        continue;
                        //    }
                        //    if (Path.GetFileNameWithoutExtension(item.Name) == _productCode)
                        //    {
                        //        if (Path.GetFileName(item.DirectoryName) != "3D." + _productCode)
                        //        {
                        //            DataRow row1 = dtLocal.NewRow();
                        //            row1["Name"] = item.Name;
                        //            row1["Size"] = item.Length;
                        //            row1["PathLocal"] = item.FullName;
                        //            row1["Type"] = "FILE sai thư mục chứa";
                        //            dtLocal.Rows.Add(row1);
                        //        }
                        //    }
                        //    else
                        //    {
                        //        if (Path.GetFileName(item.DirectoryName) != Path.GetFileNameWithoutExtension(item.Name))
                        //        {
                        //            DataRow row1 = dtLocal.NewRow();
                        //            row1["Name"] = item.Name;
                        //            row1["Size"] = item.Length;
                        //            row1["PathLocal"] = item.FullName;
                        //            row1["Type"] = "FILE sai thư mục chứa";
                        //            dtLocal.Rows.Add(row1);
                        //        }
                        //    }
                        //}
                    }
                    catch
                    {
                    }

                    #endregion

                    DocUtils.InitFTPQLSX();

                    #region Kiểm tra file 3D TPA dùng chung
                    string tpaPath = string.Format("D:\\Thietke.Ck\\{0}\\{1}.Ck\\3D.{1}\\COM.{1}\\TPA", _moduleCode.Substring(0, 6), _moduleCode);
                    if (Directory.Exists(tpaPath))
                    {
                        string[] listTPA_File = Directory.GetFiles(tpaPath, "TPAD.*", SearchOption.AllDirectories);
                        foreach (string filePath in listTPA_File)
                        {
                            if (filePath.Contains("OldVersions")) continue;
                            FileInfo fInfo = new FileInfo(filePath);//OldVersions
                            if (fInfo.Extension != ".ipt") continue;

                            string fileName = Path.GetFileNameWithoutExtension(fInfo.Name);
                            DataRow[] drs = dtDMVT.Select("F4 = '" + fileName.Replace(" ", "").Replace(")", "/") + "'");
                            if (drs.Count() == 0)
                            {
                                DataRow row1 = dtLocal.NewRow();
                                row1["Name"] = fInfo.Name;
                                row1["Size"] = fInfo.Length;
                                row1["PathLocal"] = fInfo.FullName;
                                row1["Type"] = "THỪA";
                                row1["Path3D"] = "";
                                dtLocal.Rows.Add(row1);
                                continue;
                            }
                            string thisProductCode = fileName.Substring(0, 10);

                            string thisServerPath = string.Format("Thietke.Ck\\{0}\\{1}.Ck\\3D.{1}\\",
                                thisProductCode.Substring(0, 6), thisProductCode);
                            string[] splitFileName = fileName.Split('.');

                            if (splitFileName.Length == 2)//vd: tpad.a0001.ipt
                            {
                                continue;
                            }

                            if (splitFileName.Length == 3)
                            {
                                thisServerPath += fInfo.Name;
                            }

                            if (splitFileName.Length > 3)
                            {
                                string ne = thisProductCode;
                                for (int i = 2; i < splitFileName.Length; i++)
                                {
                                    if (i == splitFileName.Length - 1)
                                    {
                                        thisServerPath += fInfo.Name;
                                    }
                                    else
                                    {
                                        ne += "." + splitFileName[i];
                                        thisServerPath += ne + "\\";
                                    }
                                }
                            }

                            if (!DocUtils.CheckExits(thisServerPath))
                            {
                                DataRow row1 = dtLocal.NewRow();
                                row1["Name"] = fInfo.Name;
                                row1["Size"] = fInfo.Length;
                                row1["PathLocal"] = fInfo.FullName;
                                row1["Type"] = "FILE TPA DÙNG CHUNG KHÔNG CÓ TRÊN NGUỒN";
                                dtLocal.Rows.Add(row1);
                            }
                            else
                            {
                                if (fInfo.Length != DocUtils.GetFileSize(thisServerPath))
                                {
                                    string filePathDMVT_Server = string.Format("Thietke.Ck\\{0}\\{1}.Ck\\VT.{1}.xlsm", thisProductCode.Substring(0, 6), thisProductCode);
                                    string fileNameServer = string.Format("VT.{0}.xlsm",thisProductCode);
                                    DocUtils.DownloadFile("D:\\", fileNameServer, filePathDMVT_Server);
                                    DataTable dtVT_Server = GetDMVT_Excel("D:\\"+ fileNameServer);

                                    DataRow[] drsOld = dtVT_Server.Select("F4 = '" + Path.GetFileNameWithoutExtension(fInfo.Name) + "'");
                                    DataRow[] drsNew = dtDMVT.Select("F4 = '" + Path.GetFileNameWithoutExtension(fInfo.Name) + "'");

                                    DataRow row1 = dtLocal.NewRow();
                                    row1["Name"] = fInfo.Name;
                                    row1["Size"] = fInfo.Length;
                                    row1["PathLocal"] = fInfo.FullName;
                                    row1["Type"] = "Khác size QLSX";
                                    row1["Path3D"] = thisServerPath;
                                    row1["KLold"] = drsOld.Length > 0 ? TextUtils.ToString(drsOld[0]["F9"]) : "";
                                    row1["KLnew"] = drsNew.Length > 0 ? TextUtils.ToString(drsNew[0]["F9"]) : "";
                                    dtLocal.Rows.Add(row1);
                                }
                            }
                        }
                    }
                    #endregion

                    #region Kiem tra ten hang
                    string comPath = string.Format("D:\\Thietke.Ck\\{0}\\{1}.Ck\\3D.{1}\\COM.{1}\\",
                        _moduleCode.Substring(0, 6), _moduleCode);
                    if (Directory.Exists(comPath))
                    {
                        string[] listFolderHang = Directory.GetDirectories(comPath, "*", SearchOption.TopDirectoryOnly);
                        DataTable dtDMVT_Hang = TextUtils.GetDistinctDatatable(dtDMVT, "F10");
                        foreach (string item in listFolderHang)
                        {
                            string tenHang = Path.GetFileName(item);
                            int count = 0;
                            try
                            {
                                count = dtDMVT_Hang.Select().Count(r => r["F10"].ToString() == tenHang);
                            }
                            catch { }
                            if (count == 0)
                            {
                                DataRow row1 = dtLocal.NewRow();
                                row1["Name"] = tenHang;
                                row1["PathLocal"] = item;
                                row1["Type"] = "Không tồn tại hãng này trong danh mục vật tư";
                                dtLocal.Rows.Add(row1);
                            }
                            if (tenHang != "TPA")
                            {
                                string[] listChildPath = Directory.GetDirectories(item, "*", SearchOption.TopDirectoryOnly);
                                foreach (string childPath in listChildPath)
                                {
                                    string childName = Path.GetFileName(childPath);
                                    if (childName == "OldVersions") continue;
                                    DataRow row1 = dtLocal.NewRow();
                                    row1["Name"] = childName;
                                    row1["PathLocal"] = childPath;
                                    row1["Type"] = "Folder THỪA";
                                    dtLocal.Rows.Add(row1);
                                }
                            }
                        }
                    }
                    #endregion                  

                    #region Thông báo kết quả kiểm tra
                    DataTable datatbleCT = new DataTable();
                    try
                    {
                        datatbleCT = dtLocal.Select("Type <> ''", "Hang ASC").CopyToDataTable();
                    }
                    catch (Exception)
                    {
                    }

                    if (datatbleCT.Rows.Count > 0)
                    {
                        _completeTK = 0;
                        grvDataCT.AutoGenerateColumns = false;
                        grvDataCT.DataSource = datatbleCT;

                        module.IsCheckCTok = 0;
                        ModulesBO.Instance.Update(module);

                        if (listErrorMain.Count > 0)
                        {
                            string error = "";
                            foreach (string item in listErrorMain)
                            {
                                error += item + Environment.NewLine;
                            }
                            MessageBox.Show(error, "Danh sách lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        _completeTK = 1;
                        DialogResult result = MessageBox.Show("Cấu trúc thiết kế '" + _moduleCode.Trim() + "' đã chuẩn!" + Environment.NewLine +
                        "Bạn có muốn in báo cáo kiểm tra không?", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            showSuccessReport();
                        }
                    }
                    #endregion Thông báo kết quả kiểm tra
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.ToString());
                //}
            }
        }

        private void XóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grvDataCT.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn hãy chọn các files muốn xóa!", "Thông báo");
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa các file này?", "Thông báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                foreach (DataGridViewRow grow in grvDataCT.SelectedRows)
                {
                    if (grow.Cells[colWarning.Index].Value == null || grow.Cells[colWarning.Index].Value.ToString() != "THỪA")
                    {
                        continue;
                    }
                    if (grow.Cells[colWarning.Index].Value.ToString() == "THỪA")
                    {
                        //Di chuyển file vào trong thùng rác
                        try
                        {
                            TextUtils.DeleteFileToRecycle(grow.Cells[colPath.Index].Value.ToString());
                        }
                        catch (Exception)
                        {
                            //File.Delete(grow.Cells[4].Value.ToString());
                        }

                        grvDataCT.Rows.Remove(grow);
                    }
                }
            }
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grvDataCT.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn hãy chọn các files muốn lấy file tương ứng từ thư viện 3D!", "Thông báo");
                return;
            }
            try
            {
                bool isDo = false;
                foreach (DataGridViewRow grow in grvDataCT.SelectedRows)
                {
                    if (grow.Cells["colWarning"].Value.ToString() == "Khác size")
                    {
                        DocUtils.InitFTPTK();
                    }
                    else if (grow.Cells["colWarning"].Value.ToString() == "Khác size QLSX")
                    {
                        DocUtils.InitFTPQLSX();
                    }
                    //else if (grow.Cells["colWarning"].Value.ToString() == "Khác size QLSX")
                    //{
                    //    DocUtils.InitFTPQLSX();
                    //}
                    else
                    {
                        continue;
                    }
                    string localPath = grow.Cells["colPath"].Value.ToString();
                    string serverPath = grow.Cells["col3D"].Value.ToString();
                    DocUtils.DownloadFile(Path.GetDirectoryName(localPath), Path.GetFileName(localPath), serverPath);
                    isDo = true;
                    grvDataCT.Rows.Remove(grow);
                }
                if (isDo)
                {
                    MessageBox.Show("Lấy file tương ứng từ thư viện 3D về máy thành công!", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                TextUtils.ShowError("Copy file không thành công!" + Environment.NewLine + ex.Message);
            }
        }

        private void MởĐườngDẫnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = grvDataCT.SelectedRows[0].Cells[colPath.Index].Value.ToString();
            try
            {
                Process.Start("explorer.exe", "/select, " + path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnViewVTChange_Click(object sender, EventArgs e)
        {
            if (grvDataCT.SelectedRows[0].Cells[colWarning.Index].Value.ToString() == "Vật tư cần thay thế")
            {
                try
                {
                    frmVatTuThayThe frm = new frmVatTuThayThe();
                    frm.ShowDialog();
                }
                catch (Exception ex)
                {
                    TextUtils.ShowError(ex);
                }
            }
        }

        private void btnExportNot3D_Click(object sender, EventArgs e)
        {
            int count = 0;
            string initFolder = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                initFolder = fbd.SelectedPath + "/" + _moduleCode;
            }
            else
            {
                return;
            }
            try
            {
                foreach (DataGridViewRow grow in grvDataCT.Rows)
                {
                    if (grow.Cells["colWarning"].Value.ToString().Contains("Không có trong thư viện 3D"))
                    {
                        string hang = grow.Cells["colHang"].Value.ToString();
                        string code = grow.Cells["colCode"].Value.ToString();
                        string codePath = grow.Cells["colPath"].Value.ToString();
                        string hangFolder = initFolder + "/" + hang.ToUpper();

                        Directory.CreateDirectory(hangFolder);
                        File.Copy(codePath, hangFolder + "/" + Path.GetFileName(codePath), true);

                        count++;
                    }

                    if (grow.Cells["colWarning"].Value.ToString().Contains("Vật tư không tồn tại"))
                    {
                        //string notExist = initFolder + "/" + "Vật tư không tồn tại";
                        //Directory.CreateDirectory(notExist);

                        //string hang = grow.Cells["colHang"].Value.ToString();
                        //string code = grow.Cells["colCode"].Value.ToString();
                        //string codePath = grow.Cells["colPath"].Value.ToString();
                        //string hangFolder = notExist + "/" + hang.ToUpper();

                        //Directory.CreateDirectory(hangFolder);
                        //File.Copy(codePath, hangFolder, true);

                        //count++;
                    }
                }
                if (count > 0)
                {
                    Process.Start("explorer.exe", "/select, " + initFolder);
                }
                else
                {
                    MessageBox.Show("Không có vật tư cần xuất!", TextUtils.Caption);
                }
            }
            catch (Exception ex)
            {
                TextUtils.ShowError("Xuất vật tư không có 3D không thành công!" + Environment.NewLine + ex.Message);
            }
        }

        private void downloadFile3DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grvDataCT.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bạn hãy chọn các files muốn lấy file tương ứng từ thư viện 3D!", "Thông báo");
                return;
            }
            string localPath = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                localPath = fbd.SelectedPath;
            }
            if (localPath == "") return;
            DocUtils.InitFTPQLSX();
            int count = 0;
            foreach (DataGridViewRow grow in grvDataCT.SelectedRows)
            {
                string fileName = TextUtils.ToString(grow.Cells["colCode"].Value);
                if (TextUtils.ToString(grow.Cells["colWarning"].Value) == "Khác size với thiết kế cũ trên nguồn" && fileName.StartsWith("TPAD."))
                {
                    string serverPath = grow.Cells["col3D"].Value.ToString();
                    DocUtils.DownloadFile(localPath, Path.GetFileName(serverPath), serverPath);
                    count++;
                }
            }
            if (count > 0)
            {
                MessageBox.Show("Lấy file tương ứng từ nguồn về máy thành công!", "Thông báo");
            }
        }
        #endregion KIỂM TRA CẤU TRÚC THIẾT KẾ

        #region KIỂM TRA BẢN CỨNG - BẢN MỀM CAD

        private void btnCheckCM_CAD_Click(object sender, EventArgs e)
        {
            grvCadC.DataSource = null;
            grvCadM.DataSource = null;
            DataTable dtC = new DataTable();
            dtC.Columns.Add("NameC");
            dtC.Columns.Add("Path");
            DataTable dtM = new DataTable();
            dtM.Columns.Add("NameM");
            dtM.Columns.Add("Path");

            string folderM = "D:\\Thietke.Ck\\" + _moduleCode.Substring(0, 6) + "\\" + _moduleCode + ".Ck\\CAD." + _moduleCode;
            string folderC = "D:\\Thietke.Ck\\" + _moduleCode.Substring(0, 6) + "\\" + _moduleCode + ".Ck\\BCCk." + _moduleCode + "\\BC-CAD." + _moduleCode;
            List<string> listFileM = Directory.GetFiles(folderM).ToList();
            List<string> listFileC = Directory.GetFiles(folderC).ToList();

            if (listFileC.Count > 0)
            {
                listFileC.ForEach(o => dtC.Rows.Add(Path.GetFileNameWithoutExtension(o), o));
            }
            else
            {
                MessageBox.Show("Không tồn tại file trong thư mục chứa file CAD cứng", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (listFileM.Count > 0)
            {
                listFileM.ForEach(o => dtM.Rows.Add(Path.GetFileNameWithoutExtension(o), o));
            }
            else
            {
                MessageBox.Show("Không tồn tại file CAD trong thiết kế", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            grvCadC.AutoGenerateColumns = false;
            grvCadM.AutoGenerateColumns = false;
            grvCadC.DataSource = dtC;
            grvCadM.DataSource = dtM;

            bool isSuccess = true;

            foreach (DataGridViewRow rowC in grvCadC.Rows)
            {
                if (rowC.Cells[0].Value == null || rowC.Cells[0].Value.ToString() == "") continue;
                int rowcount = 0;
                try
                {
                    rowcount = dtM.Select("NameM = '" + rowC.Cells[0].Value.ToString() + "'").Count();
                }
                catch
                {
                }
                if (rowcount == 0)
                {
                    rowC.Cells[0].Style.BackColor = Color.Yellow;
                    isSuccess = false;
                }
            }

            foreach (DataGridViewRow rowM in grvCadM.Rows)
            {
                if (rowM.Cells[0].Value == null || rowM.Cells[0].Value.ToString() == "") continue;
                int rowcount = 0;
                try
                {
                    rowcount = dtC.Select("NameC = '" + rowM.Cells[0].Value.ToString() + "'").Count();
                }
                catch
                {
                }
                if (rowcount == 0)
                {
                    rowM.Cells[0].Style.BackColor = Color.Yellow;
                    isSuccess = false;
                }
            }
            //grvCadC.Rows[grvCadC.Rows.Count - 1].Selected = true;
            //grvCadM.Rows[grvCadM.Rows.Count - 1].Selected = true;

            if (isSuccess)
            {
                MessageBox.Show("Đã chuẩn", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không chuẩn", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnCopyCADcung_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvCadM.Rows.Count > 0)
                {
                    bool reload = false;
                    DocUtils.InitFTPQLSX();
                    foreach (DataGridViewRow itemRow in grvCadM.Rows)
                    {
                        if (itemRow.Cells[0].Style.BackColor == Color.Yellow)
                        {
                            string fileName = itemRow.Cells[0].Value.ToString();
                            string productCode = fileName.Substring(0, 10);
                            string ftpFilePath = "Thietke.Ck/" + productCode.Substring(0, 6) + "/" + productCode + ".Ck/BCCk."
                                + productCode + "\\BC-CAD." + productCode + "/" + fileName + ".jpg";
                            string filePath = "D:\\Thietke.Ck\\" + _moduleCode.Substring(0, 6) + "\\" + _moduleCode + ".Ck\\BCCk."
                                + _moduleCode + "\\BC-CAD." + _moduleCode;
                            if (DocUtils.CheckExits(ftpFilePath))
                            {
                                DocUtils.DownloadFile(filePath, fileName + ".jpg", ftpFilePath);
                                reload = true;
                            }
                        }
                    }
                    if (reload)
                    {
                        MessageBox.Show("Download file cad Cứng về máy thành công");
                        btnCheckCM_CAD_Click(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void xóaFileBCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grvCadC.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in grvCadC.SelectedRows)
                {
                    string name = row.Cells[colCName.Index].Value == null ? "" : row.Cells[colCName.Index].Value.ToString();
                    if (name == "") return;
                    DialogResult result = MessageBox.Show("Bạn có thật sự muốn xóa file bản cứng [" + name + "] này?",
                        TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        TextUtils.DeleteFileToRecycle(row.Cells["colCpath"].Value.ToString());                        
                    }
                }
                btnCheckCM_CAD_Click(null, null);
            }
        }

        #endregion

        #region Kiểm tra thông số kỹ thuật
        private void btnCheckTSKT_Click(object sender, EventArgs e)
        {
            DataTable dtDMVTnew = TextUtils.ExcelToDatatable(txtDMVTPath.Text, "DMVT");
            for (int i = 0; i <= 4; i++)
            {
                dtDMVTnew.Rows.RemoveAt(0);
            }
            dtDMVTnew = dtDMVTnew.Select("F1 <> ''").CopyToDataTable();
            dtDMVTnew.Columns.Add("Type");

            string filePathDMVT = string.Format("Thietke.Ck/{0}/{1}.Ck/VT.{1}.xlsm", _moduleCode.Substring(0, 6), _moduleCode);
            DataTable dtDMVTold = new DataTable();

            bool diff = false;
            DataTable dtNew = dtDMVTnew.Copy();
            dtNew.Rows.Clear();
            List<string> listStatus = new List<string>();

            DataTable dtOld = dtDMVTold.Copy();
            dtOld.Rows.Clear();

            try
            {
                DocUtils.InitFTPQLSX();
                DocUtils.DownloadFile("D:/", Path.GetFileName(filePathDMVT), filePathDMVT);
                dtDMVTold = TextUtils.ExcelToDatatable("D:/" + Path.GetFileName(filePathDMVT), "DMVT");
                for (int i = 0; i <= 4; i++)
                {
                    dtDMVTold.Rows.RemoveAt(0);
                }
                dtDMVTold = dtDMVTold.Select("F1 <> ''").CopyToDataTable();
                dtDMVTold.Columns.Add("Type");
                File.Delete("D:/" + Path.GetFileName(filePathDMVT));
            }
            catch
            {
            }          

            foreach (DataRow row in dtDMVTnew.Rows)
            {
                string code = row["F4"].ToString();

                DataRow[] listRow = dtDMVTold.Select("F4 = '" + code + "'");
                if (listRow.Count() == 0)
                {
                    if (code.StartsWith(_moduleCode) && code.Contains("-"))
                    {
                        string sourceCode = code.Split('-')[0];
                        int version = TextUtils.ToInt(code.Split('-')[1]);
                        if (version ==1)
                        {
                            listStatus.Add(sourceCode + " => " + code);
                        }
                        else
                        {
                            listStatus.Add(sourceCode + "-" + string.Format("{0:00}", (version - 1)) + " => " + code);
                        }                        
                    }
                    else
                    {
                        DataRow r = dtOld.NewRow();
                        r["F1"] = row["F1"];//STT
                        r["F2"] = row["F2"];//Ten vat tu
                        r["F4"] = row["F4"];//Ma vat tu
                        r["F7"] = row["F7"];//so luong
                        r["F10"] = row["F10"];//hang
                        r["Type"] = "0";
                        dtOld.Rows.Add(r);
                        diff = true;
                    }
                }
            }
          
            foreach (DataRow row in dtDMVTold.Rows)
            {
                string code = row["F4"].ToString();
                DataRow[] listRow = dtDMVTnew.Select("F4 = '" + code + "'");
                if (listRow.Count() == 0)
                {
                    DataRow r = dtNew.NewRow();
                    r["F1"] = row["F1"].ToString();
                    r["F2"] = row["F2"].ToString();
                    r["F4"] = row["F4"].ToString();
                    r["F7"] = row["F7"].ToString();
                    r["F10"] = row["F10"].ToString();
                    r["Type"] = "0";
                    dtNew.Rows.Add(r);
                    diff = true;
                }
            }

            grvDMVT.AutoGenerateColumns = false;
            grvDMVT.DataSource = dtNew;

            grvDMVTold.AutoGenerateColumns = false;
            grvDMVTold.DataSource = dtOld;

            grvDMVT.Rows[grvDMVT.Rows.Count - 1].Selected = true;
            grvDMVTold.Rows[grvDMVTold.Rows.Count - 1].Selected = true;

            foreach (string item in listStatus)
            {
                txtDiff.Text += item + Environment.NewLine;
            }

            if (diff)
            {
                MessageBox.Show("Có sai khác giữa 2 danh mục vật tư!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                MessageBox.Show("Không có sai khác!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Kiểm tra sai khác cũ mới

        void loadDanhSachScanNew()
        {
            try
            {
                string pathCAD_cung = string.Format("Thietke.Ck/{0}/{1}.Ck/BCCk.{1}/BC-CAD.{1}", _moduleCode.Substring(0, 6), _moduleCode);

                DataTable dt = new DataTable();
                dt = TextUtils.Select("CheckCTTKHistory", new Expression("ID", 0));
                dt.Columns.Add("FilePath");
                string[] listFileCad = Directory.GetFiles("D:/" + pathCAD_cung);
                foreach (string filePath in listFileCad)
                {
                    System.Collections.ArrayList barcodes = new System.Collections.ArrayList();
                    Image img = Image.FromFile(filePath);
                    Bitmap mBitmap = new Bitmap(img);
                    BarcodeImaging.FullScanPage(ref barcodes, mBitmap, 100);
                    mBitmap.Dispose();
                    //string[] barcodes = BarcodeReader.read(mBitmap, BarcodeReader.CODE39);
                    string code = "";
                    string date = "";
                    string size = "";
                    string fullDate = "";
                    try
                    {
                        code = barcodes.ToArray().Where(o => o.ToString().StartsWith("+")).ToArray()[0].ToString();
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        date = barcodes.ToArray().Where(o => o.ToString().StartsWith("1")).ToArray()[0].ToString();
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        size = barcodes.ToArray().Where(o => o.ToString().StartsWith("2")).ToArray()[0].ToString();
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        fullDate = DateString(date.Substring(2));
                    }
                    catch (Exception)
                    {
                    }

                    dt.Rows.Add(0, _moduleCode, code, size, date, fullDate, 0, filePath);
                }
                grvSaiKhacNew.DataSource = null;
                grvSaiKhacNew.AutoGenerateColumns = false;
                grvSaiKhacNew.DataSource = dt;
            }
            catch (Exception)
            {

            }
        }

        void loadDanhSachScanOld()
        {
            try
            {
                string pathCAD_cung = string.Format("Thietke.Ck/{0}/{1}.Ck/BCCk.{1}/BC-CAD.{1}", _moduleCode.Substring(0, 6), _moduleCode);
                string pathLocal = "D:/Compare";
                if (Directory.Exists(pathLocal))
                {
                    TextUtils.DeleteFolderVB(pathLocal);
                }
                Directory.CreateDirectory(pathLocal);
                //Download file ảnh scan bản vẽ từ nguồn về local
                if (DocUtils.CheckExits(pathCAD_cung))
                {
                    string[] listFileBC = DocUtils.GetFilesList(pathCAD_cung);
                    if (listFileBC != null)
                    {
                        foreach (string item in listFileBC)
                        {
                            try
                            {
                                if (DocUtils.CheckExits(pathCAD_cung + "/" + item))
                                {
                                    DocUtils.DownloadFile(pathLocal, item, pathCAD_cung + "/" + item);
                                }
                            }
                            catch
                            {
                            }
                        }
                    }
                    DataTable dt = new DataTable();
                    dt = TextUtils.Select("CheckCTTKHistory", new Expression("ID", 0));
                    dt.Columns.Add("FilePath");

                    string[] listFileCad = Directory.GetFiles(pathLocal);
                    foreach (string filePath in listFileCad)
                    {
                        System.Collections.ArrayList barcodes = new System.Collections.ArrayList();
                        Image img = Image.FromFile(filePath);
                        Bitmap mBitmap = new Bitmap(img);
                        BarcodeImaging.FullScanPage(ref barcodes, mBitmap, 100);
                        mBitmap.Dispose();
                        //string[] barcodes = BarcodeReader.read(mBitmap, BarcodeReader.CODE39);
                        string code = "";
                        string date = "";
                        string size = "";
                        string fullDate = "";
                        try
                        {
                            code = barcodes.ToArray().Where(o => o.ToString().StartsWith("+")).ToArray()[0].ToString();
                        }
                        catch (Exception)
                        {
                        }
                        try
                        {
                            date = barcodes.ToArray().Where(o => o.ToString().StartsWith("1")).ToArray()[0].ToString();
                        }
                        catch (Exception)
                        {
                        }
                        try
                        {
                            size = barcodes.ToArray().Where(o => o.ToString().StartsWith("2")).ToArray()[0].ToString();
                        }
                        catch (Exception)
                        {
                        }
                        try
                        {
                            fullDate = DateString(date.Substring(2));
                        }
                        catch (Exception)
                        {
                        }

                        dt.Rows.Add(0, _moduleCode, code, size, date, fullDate, 0, filePath);
                    }
                    grvSaiKhacOld.DataSource = null;
                    grvSaiKhacOld.AutoGenerateColumns = false;
                    grvSaiKhacOld.DataSource = dt;
                }

            }
            catch (Exception)
            {
            }

        }

        void loadCadMemOld()
        {
            try
            {
                string pathCAD_mem = string.Format("Thietke.Ck/{0}/{1}.Ck/CAD.{1}", _moduleCode.Substring(0, 6), _moduleCode);
                string pathLocal = "D:/CompareMem";
                if (Directory.Exists(pathLocal))
                {
                    TextUtils.DeleteFolderVB(pathLocal);
                }
                Directory.CreateDirectory(pathLocal);
                //Download file ảnh scan bản vẽ từ nguồn về local
                if (DocUtils.CheckExits(pathCAD_mem))
                {
                    string[] listFileBC = DocUtils.GetFilesList(pathCAD_mem);
                    if (listFileBC != null)
                    {
                        foreach (string item in listFileBC)
                        {
                            try
                            {
                                if (DocUtils.CheckExits(pathCAD_mem + "/" + item))
                                {
                                    DocUtils.DownloadFile(pathLocal, item, pathCAD_mem + "/" + item);
                                }
                            }
                            catch
                            {
                            }
                        }
                    }
                    DataTable dt = new DataTable();
                    dt.Columns.Add("FileName");
                    dt.Columns.Add("Size");

                    string[] listFileCad = Directory.GetFiles(pathLocal);
                    foreach (string filePath in listFileCad)
                    {
                        dt.Rows.Add(Path.GetFileNameWithoutExtension(filePath), new FileInfo(filePath).Length);
                    }
                    grvSaiKhacOld.DataSource = null;
                    grvSaiKhacOld.AutoGenerateColumns = false;
                    grvSaiKhacOld.DataSource = dt;
                }

            }
            catch (Exception)
            {
            }
        }

        void loadCadMemNew()
        {
            try
            {
                string pathCAD_mem = string.Format("Thietke.Ck/{0}/{1}.Ck/CAD.{1}", _moduleCode.Substring(0, 6), _moduleCode);

                DataTable dt = new DataTable();
                dt.Columns.Add("FileName");
                dt.Columns.Add("Size");

                string[] listFileCad = Directory.GetFiles("D:/" + pathCAD_mem);
                foreach (string filePath in listFileCad)
                {
                    dt.Rows.Add(Path.GetFileNameWithoutExtension(filePath), new FileInfo(filePath).Length);
                }
                grvSaiKhacNew.DataSource = null;
                grvSaiKhacNew.AutoGenerateColumns = false;
                grvSaiKhacNew.DataSource = dt;
            }
            catch (Exception)
            {

            }
        }
        bool _checkCADmem = false;
        private void btnLoadSaiKhac_Click(object sender, EventArgs e)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tải dữ liệu kiểm tra..."))
            {
                DocUtils.InitFTPQLSX();
                loadDanhSachScanOld();
                if (grvSaiKhacOld.Rows.Count >= 2)
                {
                    loadDanhSachScanNew();
                }
                else
                {
                    _checkCADmem = true;
                    loadCadMemOld();
                    loadCadMemNew();
                }
            }
        }

        private void btnCheckSaiKhac_Click(object sender, EventArgs e)
        {
            if (grvSaiKhacNew.Rows.Count <= 1) return;
            int hasError = 0;
            foreach (DataGridViewRow rowNew in grvSaiKhacNew.Rows)
            {
                if (rowNew.Cells[colFileNameNewSK.Index].Value == null)
                    continue;
                string nameNew = rowNew.Cells[colFileNameNewSK.Index].Value.ToString();
                string sizeNew = default(string);
                string dateNew = default(string);

                try
                {
                    sizeNew = rowNew.Cells[colSizeNewSK.Index].Value.ToString().Trim();
                }
                catch (Exception)
                {
                    sizeNew = "";
                }
                try
                {
                    dateNew = rowNew.Cells[colDateModifieldNewSK.Index].Value.ToString();
                }
                catch (Exception)
                {
                    dateNew = "";
                }

                //Cảnh báo sự khác nhau về nội dung giữa bản cứng và bản mềm
                foreach (DataGridViewRow rowOld in grvSaiKhacOld.Rows)
                {
                    if (rowOld.Cells[colFileNameOldSK.Index].Value == null)
                        continue;
                    string nameOld = rowOld.Cells[colFileNameOldSK.Index].Value.ToString();//.Replace("TPAD.", "").Replace(".ipt", "").Replace(".iam", "")); //.Replace(")", "/")
                    string sizeOld = "";
                    try
                    {
                        sizeOld = rowOld.Cells[colSizeOldSK.Index].Value.ToString();
                    }
                    catch
                    {
                    }

                    string dateOld = "";
                    try
                    {
                        dateOld = rowOld.Cells[colDateModifieldOldSK.Index].Value.ToString();
                    }
                    catch
                    {
                    }

                    if (nameNew.ToUpper() == nameOld.ToUpper())
                    {
                        //Kiểm tra size file
                        if (sizeNew != sizeOld)
                        {
                            rowNew.Cells[colSizeNewSK.Index].Style.BackColor = Color.GreenYellow;
                            hasError = 1;
                        }
                        else
                        {
                            rowNew.Cells[colSizeNewSK.Index].Style.BackColor = Color.White;
                        }
                        //Kiểm tra ngày file
                        if (dateNew != dateOld)
                        {
                            rowNew.Cells[colDateModifieldNewSK.Index].Style.BackColor = Color.GreenYellow;
                            hasError = 1;
                        }
                        else
                        {
                            rowNew.Cells[colDateModifieldNewSK.Index].Style.BackColor = Color.White;
                        }
                        //isNew = False
                        break;
                    }
                }
            }
            grvSaiKhacNew.Rows[grvSaiKhacNew.Rows.Count - 1].Selected = true;
            grvSaiKhacOld.Rows[grvSaiKhacOld.Rows.Count - 1].Selected = true;
            if (hasError == 0)
            {
                MessageBox.Show("Không có sai khác!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Xuất hiện sai khác!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void grvDataCT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C)
            {
                Clipboard.SetText(grvDataCT.SelectedRows[0].Cells["colCode"].Value.ToString());
            }
            if (e.KeyCode == Keys.D)
            {
                Clipboard.SetText(grvDataCT.SelectedRows[0].Cells["colNameVT"].Value.ToString());
            }
        }

        #endregion Events

        #region Kiểm tra điện tử
        private void btnCheckCTDT_Click(object sender, EventArgs e)
        {
            if (txtPath_DT.Text.Trim() == "") return;

            DataTable dtLocal_DT = new DataTable();
            dtLocal_DT.Columns.Add("Name", typeof(string));
            dtLocal_DT.Columns.Add("Size", typeof(string));
            dtLocal_DT.Columns.Add("Type", typeof(string));
            dtLocal_DT.Columns.Add("Hang", typeof(string));
            dtLocal_DT.Columns.Add("PathLocal", typeof(string));
            dtLocal_DT.Columns.Add("Path3D", typeof(string));

            string code = Path.GetFileName(txtPath_DT.Text.Trim());

            string[] listFile = Directory.GetFiles(txtPath_DT.Text.Trim(), "*.*", SearchOption.AllDirectories);

            int countFile = 0;
            try
            {
                countFile = listFile.FirstOrDefault(o => Path.GetExtension(o).ToLower() == ".schdoc").Count();
            }
            catch (Exception)
            {                
            }

            if (countFile < 1)
            {
                 MessageBox.Show("Thiết kế không chứa các file điện tử!", TextUtils.Caption,MessageBoxButtons.OK,MessageBoxIcon.Error);
                 return;
            }

            DocUtils.InitFTPQLSX();

            foreach (string filePath in listFile)
            {
                string extension = Path.GetExtension(filePath).ToLower();                
                if (extension == ".docm" || extension == ".xls") continue;

                DocUtils.InitFTPQLSX();
                string ftpFilePath = filePath.Replace("D:", "").Replace("\\" + code.Substring(0, 5) + "\\", "\\" + code.Substring(0, 3) + "\\");
                if (DocUtils.CheckExits(ftpFilePath))
                {
                    if (new FileInfo(filePath).Length != DocUtils.GetFileSize(ftpFilePath))
                    {
                        DataRow row1 = dtLocal_DT.NewRow();
                        row1["Name"] = Path.GetFileName(filePath);
                        row1["PathLocal"] = filePath;
                        row1["Size"] = new FileInfo(filePath).Length;
                        row1["Path3D"] = ftpFilePath;
                        row1["Type"] = "Khác size với thiết kế cũ trên nguồn";
                        dtLocal_DT.Rows.Add(row1);
                    }
                }
            }

            grvCTTK_DT.AutoGenerateColumns = false;
            grvCTTK_DT.DataSource = dtLocal_DT;

            if (dtLocal_DT.Rows.Count == 0)
            {
                DialogResult result = MessageBox.Show("Thiết kế điện tử [" + code.Trim() + "] đã chuẩn!" + Environment.NewLine +
                        "Bạn có muốn in báo cáo kiểm tra không?", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string htmlText = ((ConfigSystemModel)ConfigSystemBO.Instance.FindByAttribute("KeyName", "ReportCTTK_DT")[0]).KeyValue;
                    
                    htmlText = htmlText.Replace("<path>", Application.StartupPath + "\\logoTP.png");
                    //htmlText = htmlText.Replace("<productname>", dtDMVT.Rows[1][2].ToString());
                    htmlText = htmlText.Replace("<productcode>", code.Trim());
                    htmlText = htmlText.Replace("<username>", Global.AppFullName);
                    htmlText = htmlText.Replace("<datedesign>", DateTime.Now.ToString("dd/MM/yyyy"));
                    htmlText = htmlText.Replace("<day>", DateTime.Now.Day.ToString());
                    htmlText = htmlText.Replace("<month>", DateTime.Now.Month.ToString());
                    htmlText = htmlText.Replace("<year>", DateTime.Now.Year.ToString());

                    frmReportShow frm = new frmReportShow();
                    frm.HtmlText = htmlText;
                    frm.Show();
                }
            }
            else
            {
                MessageBox.Show("Thiết kế điện tử chưa chuẩn!", TextUtils.Caption,MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnBrowserDT_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = @"D:\Thietke.Dt";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtPath_DT.Text = fbd.SelectedPath;
            }
        }
        #endregion

        #region Kiểm tra thư mục Mặt
        DataTable dtLocalMat;
        DataTable dtFtpMat;

        void loadLocalMat()
        {
            if (_moduleCode == "" || _moduleCode == null) return;

            dtLocalMat = new DataTable();
            dtLocalMat.Columns.Add("Name");
            dtLocalMat.Columns.Add("Size");
            dtLocalMat.Columns.Add("FilePath");

            string pathMAT = string.Format(@"D:\Thietke.Ck\{0}\{1}.Ck\MAT.{1}\", _moduleCode.Substring(0, 6), _moduleCode);
            string[] listFileMAT = Directory.GetFiles(pathMAT);
            foreach (string filePath in listFileMAT)
            {
                FileInfo fi = new FileInfo(filePath);
                DataRow dr = dtLocalMat.NewRow();
                dr["Name"] = fi.Name;
                dr["Size"] = fi.Length.ToString();
                dr["FilePath"] = fi.FullName;
                dtLocalMat.Rows.Add(dr);
            }

            grvMatT.AutoGenerateColumns = false;
            grvMatT.DataSource = dtLocalMat;
        }

        void loadFtpMat()
        {
            if (_moduleCode == "" || _moduleCode == null) return;
            DocUtils.InitFTPQLSX();

            dtFtpMat = new DataTable();
            dtFtpMat.Columns.Add("Name");
            dtFtpMat.Columns.Add("Size");
            dtFtpMat.Columns.Add("FilePath");

            string pathMAT = string.Format(@"\Thietke.Ck\{0}\{1}.Ck\MAT.{1}\", _moduleCode.Substring(0, 6), _moduleCode);
            string[] listFileMAT = BMS.DocUtils.GetFilesList(pathMAT);
            if (listFileMAT != null)
            {
                foreach (string fileName in listFileMAT)
                {
                    DataRow dr = dtFtpMat.NewRow();
                    dr["Name"] = fileName;
                    dr["Size"] = DocUtils.GetFileSize(pathMAT + "//" + fileName).ToString();
                    dr["FilePath"] = pathMAT + fileName;
                    dtFtpMat.Rows.Add(dr);
                }
            }
            grvMatN.AutoGenerateColumns = false;
            grvMatN.DataSource = dtFtpMat;
        }

        private void refreshCheck()
        {
            if (grvMatN.Rows.Count >= 1)
            {
                for (int i = 0; i <= grvMatN.Rows.Count - 1; i++)
                {
                    grvMatN.Rows[i].Cells[0].Style.BackColor = Color.White;
                    grvMatN.Rows[i].Cells[1].Style.BackColor = Color.White;
                    //grvMatN.Rows[i].Cells[2].Style.BackColor = Color.White;
                }
            }

            if (grvMatT.Rows.Count >= 1)
            {
                for (int j = 0; j <= grvMatT.Rows.Count - 1; j++)
                {
                    grvMatT.Rows[j].Cells[0].Style.BackColor = Color.White;
                    grvMatT.Rows[j].Cells[1].Style.BackColor = Color.White;
                    //grvMatT.Rows[j].Cells[2].Style.BackColor = Color.White;
                }
            }
        }

        private void btnLoadMAT_Click(object sender, EventArgs e)
        {
            
        }

        private void btnKiemTraMAT_Click(object sender, EventArgs e)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load dữ liệu để so sánh"))
            {
                loadLocalMat();
                loadFtpMat();
            }

            refreshCheck();
            int count = 0;
            foreach (DataGridViewRow row in grvMatN.Rows)
            {
                if (row.Cells[0].Value == null) continue;
                string fileName = row.Cells[0].Value.ToString();
                string fileSize = row.Cells[1].Value.ToString();

                DataRow[] drs = dtLocalMat.Select("Name = '" + fileName + "'");
                if (drs.Length>0)
                {
                    string fileLocalSize = drs[0]["Size"].ToString();
                    if (fileSize != fileLocalSize)
                    {
                        row.Cells[0].Style.BackColor = Color.GreenYellow;
                        count++;
                    }
                }
                else
                {
                    row.Cells[0].Style.BackColor = Color.Yellow;
                    count++;
                }
            }

            foreach (DataGridViewRow row in grvMatT.Rows)
            {
                if (row.Cells[0].Value == null) continue;
                string fileName = row.Cells[0].Value.ToString();
                string fileSize = row.Cells[1].Value.ToString();

                DataRow[] drs = dtFtpMat.Select("Name = '" + fileName + "'");
                if (drs.Length > 0)
                {
                    string fileFtpSize = drs[0]["Size"].ToString();
                    if (fileSize != fileFtpSize)
                    {
                        row.Cells[0].Style.BackColor = Color.GreenYellow;
                        count++;
                    }
                }
                else
                {
                    row.Cells[0].Style.BackColor = Color.Yellow;
                    count++;
                }
            }

            grvMatN.Rows[grvMatN.Rows.Count - 1].Selected = true;
            grvMatT.Rows[grvMatT.Rows.Count - 1].Selected = true;

            if (count==0)
            {
                MessageBox.Show("Đã chuẩn");
            }
            else
            {
                MessageBox.Show("Có sai khác trong kiểm tra.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void btnLoadBanMem_Click(object sender, EventArgs e)
        {

        }

        private void btnExecl_Click(object sender, EventArgs e)
        {
            string filePath = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                filePath = fbd.SelectedPath + "\\" + _moduleCode + ".csv";
            }
            else
            {
                return;
            }
            TextUtils.GridToCsv(grvDataCT, filePath);
            File.Move(filePath, fbd.SelectedPath + "\\" + _moduleCode + ".xls");
        }

        private void btnCheckCTDien_Click(object sender, EventArgs e)
        {
            if (txtPathDien.Text.Trim() == "") return;

            DataTable dtLocal_Dien = new DataTable();
            dtLocal_Dien.Columns.Add("Name", typeof(string));
            dtLocal_Dien.Columns.Add("Size", typeof(string));
            dtLocal_Dien.Columns.Add("Type", typeof(string));
            dtLocal_Dien.Columns.Add("Hang", typeof(string));
            dtLocal_Dien.Columns.Add("PathLocal", typeof(string));
            dtLocal_Dien.Columns.Add("Path3D", typeof(string));

            string moduleCode = Path.GetFileName(txtPathDien.Text.Trim()).Substring(0, 10);

            ArrayList listModule = ModulesBO.Instance.FindByAttribute("Code", moduleCode);
            if (listModule == null)
            {
                MessageBox.Show("Module chưa có trên nguồn.", TextUtils.Caption, MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
                return;
            }

            var thisModule = (ModulesModel)listModule[0];

            string selectedPath_Dien = txtPathDien.Text.Trim();
            try
            {
                DataTable dtCT = TextUtils.Select("Select * from DesignStructure where Type = 1");//lấy những thư mục cấu trúc cơ khí
                string[] listDirectories = Directory.GetDirectories(selectedPath_Dien, "**", SearchOption.AllDirectories);
                foreach (string item in listDirectories)
                {
                    string folderName = Path.GetFileName(item);

                    if (!folderName.Contains(moduleCode))
                    {
                        DataRow row = dtLocal_Dien.NewRow();
                        row["Name"] = folderName;
                        row["PathLocal"] = item;
                        row["Type"] = "Folder THỪA";
                        dtLocal_Dien.Rows.Add(row);
                    }
                }

                foreach (DataRow itemRow in dtCT.Rows)
                {
                    string nameCT = itemRow["Name"].ToString().Replace("code", moduleCode);//OldVersions
                    int iD = TextUtils.ToInt(itemRow["ID"]);

                    string[] arrExtension = null;

                    try
                    {
                        arrExtension = itemRow["Extension"].ToString().Split(',').Where(o => o.Trim() != "").ToArray();
                    }
                    catch (Exception)
                    {
                    }

                    string folderPath = Path.GetDirectoryName(selectedPath_Dien) + "\\" + itemRow["Path"].ToString().Replace("code", moduleCode);
                    if (!Directory.Exists(folderPath))
                    {
                        DataRow row = dtLocal_Dien.NewRow();
                        row["Name"] = nameCT;
                        row["PathLocal"] = folderPath;
                        row["Type"] = "THIẾU THƯ MỤC";
                        dtLocal_Dien.Rows.Add(row);
                    }
                    else
                    {
                        DataTable dtCTFile = TextUtils.Select("SELECT * FROM DesignStructureFile where DesignStructureID = " + iD);
                        string[] listFiles = Directory.GetFiles(folderPath, "*.*", SearchOption.TopDirectoryOnly);

                        if (dtCTFile.Rows.Count > 0)
                        {
                            foreach (DataRow row in dtCTFile.Rows)
                            {
                                string fileNameCT = row["Name"].ToString().Replace("code", moduleCode);
                                bool exist = TextUtils.ToBoolean(row["Exist"]);
                                if (exist && !File.Exists(folderPath + "\\" + fileNameCT))
                                {
                                    DataRow row1 = dtLocal_Dien.NewRow();
                                    row1["Name"] = fileNameCT;
                                    row1["PathLocal"] = folderPath;
                                    row1["Type"] = "THIẾU FILE";
                                    dtLocal_Dien.Rows.Add(row1);
                                }
                            }
                        }

                        if (listFiles.Count() > 0)
                        {
                            bool isChange = false;
                            foreach (string item in listFiles)
                            {
                                string fileName = Path.GetFileName(item);

                                if (fileName == "HMI."+moduleCode+".rar")
                                {
                                    thisModule.IsHMI = 2;
                                    isChange = true;
                                }

                                if (fileName == "PLC." + moduleCode + ".rar")
                                {
                                    thisModule.IsPLC = 2;
                                    isChange = true;
                                }

                                if (dtCTFile.Rows.Count > 0)
                                {
                                    int count = 0;
                                    try { count = dtCTFile.Select().Count(r => r["Name"].ToString().Replace("code", moduleCode) == fileName); }
                                    catch { }
                                    if (count == 0)
                                    {
                                        DataRow row1 = dtLocal_Dien.NewRow();
                                        row1["Name"] = fileName;
                                        row1["Size"] = new FileInfo(item).Length;
                                        row1["PathLocal"] = item;
                                        row1["Type"] = "THỪA";
                                        dtLocal_Dien.Rows.Add(row1);
                                    }
                                }

                                if (arrExtension != null && arrExtension.Count() > 0 && !arrExtension.Contains(Path.GetExtension(fileName)))
                                {
                                    DataRow row1 = dtLocal_Dien.NewRow();
                                    row1["Name"] = fileName;
                                    row1["Size"] = new FileInfo(item).Length;
                                    row1["PathLocal"] = item;
                                    row1["Type"] = "THỪA";
                                    dtLocal_Dien.Rows.Add(row1);
                                }
                            }
                            if(isChange)
                                ModulesBO.Instance.Update(thisModule);
                        }
                    }
                }

                grvCTDien.DataSource = null;
                grvCTDien.DataSource = dtLocal_Dien;
                grvCTDien.AutoGenerateColumns = false;

                if (dtLocal_Dien.Rows.Count > 0)
                {
                    MessageBox.Show("Thiết kế điện chưa chuẩn!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Thiết kế điện đã chuẩn!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBrowseDien_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = @"D:\Thietke.Dn";
            if (fbd.ShowDialog()==DialogResult.OK)
            {
                txtPathDien.Text = fbd.SelectedPath;
            }
        }        
    }
}
