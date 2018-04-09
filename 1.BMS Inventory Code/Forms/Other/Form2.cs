using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using System.Diagnostics;
using DevExpress.Utils;
using BMS.Model;
using BMS.Business;
using System.Collections;
using BMS.Utils;
using TPA.Model;
using TPA.Business;
using MODI;

namespace BMS
{
    public partial class Form2 : _Forms
    {
        DataTable dtData = null;
        DateTime _pStart = new DateTime(2015, 1, 1);
        DateTime _pEnd = new DateTime(2015, 2, 1);

        List<DateInfo> allDates = new List<DateInfo>();

        public class DateInfo
        {
            public DateTime ThisDate { get; set; }
            public string DayInWeek { get; set; }
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtData = new DataTable();
            dtData.Columns.Add("STT");
            dtData.Columns.Add("Name");
            dtData.Columns.Add("Author");
            dtData.Columns.Add("StartDate", typeof(DateTime));
            dtData.Columns.Add("FinishDate", typeof(DateTime));
            dtData.Columns.Add("CellsNumber");
            dtData.Columns.Add("Space");

            dtData.Rows.Add("1", "Chỉnh sửa bản vẽ 3D", "Phòng TK", new DateTime(2015, 1, 1), new DateTime(2015, 1, 8), 8,0);
            dtData.Rows.Add("2", "Canon đặt hàng", "Phòng Dự án", new DateTime(2015, 1, 9), new DateTime(2015, 1, 13), 5,8);
            dtData.Rows.Add("3", "Đặt hàng thiết bị", "Phòng vật tư", new DateTime(2015, 1, 14), new DateTime(2015, 1, 15), 2,13);
            
            //loadTree();
            //loadGrid();

        }

        void loadTree(string projectCode)
        {
            try
            {
                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load danh sách module..."))
                {
                    string[] _paraName = new string[1];
                    object[] _paraValue = new object[1];
                    _paraName[0] = "@ProjectCode"; _paraValue[0] = "T009.1501";
                    //DataTable Source = ModulesBO.Instance.LoadDataFromSP("spGetProductOfProjectNew", "Source", _paraName, _paraValue);
                    DataTable Source = LibQLSX.Select("select * from vGetProductOfProject where ProjectCode ='" + projectCode + "'");
                    treeData.DataSource = Source;
                    treeData.KeyFieldName = "PProductId";
                    treeData.PreviewFieldName = "MaThietBi";
                    //treeData.ExpandAll();                
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        void loadGrid()
        {
            DataTable dt = LibQLSX.Select("select * from C_Cost");
            gridControl2.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //for (DateTime date = _pStart; date <= _pEnd; date = date.AddDays(1))
            //{
            //    DateInfo di = new DateInfo();
            //    di.DayInWeek = date.ToString("ddd");
            //    di.ThisDate = date;
            //    allDates.Add(di);
            //}

            TextUtils.WordFindAndReplace(@"C:\Users\thao.nv\Desktop\PTTK.TPAD.C4802.docm", "TPAD.C4802", "TPAD.C4800");
            MessageBox.Show("ok!");

            //string excelFile = @"C:\Users\thao.nv\Desktop\Test Excel.xlsx";

            //Excel.Application objXLApp = default(Excel.Application);
            //Excel.Workbook objXLWb = default(Excel.Workbook);
            //Excel.Worksheet objXLWs = default(Excel.Worksheet);

            ////File.Copy("D:\\Test Excel.xlsx", "D:\\1.xlsx", true); // Copy file hồ sơ thiết kế

            //objXLApp = new Excel.Application();
            //objXLApp.Workbooks.Open(excelFile);
            //objXLWb = objXLApp.Workbooks[1];
            //objXLWs = (Excel.Worksheet)objXLWb.Worksheets[1];

            ////for (int i = 0; i <= allDates.Count - 1; i++)
            ////{
            ////    objXLWs.Cells[5, 4 + i] = allDates[i].ThisDate.ToString("dd/MM");
            ////    objXLWs.Cells[6, 4 + i] = allDates[i].DayInWeek;
            ////}

            ////objXLWs.Shapes.AddPicture(@"C:\Users\thao.nv\Desktop\Untitled.png", Microsoft.Office.Core.MsoTriState.msoFalse,
            ////    Microsoft.Office.Core.MsoTriState.msoCTrue, 50, 50, 900, 200);

            //objXLWs.Cells.Replace(What: "TPAD.C9904", Replacement: "eee", LookAt: Excel.XlLookAt.xlWhole,
            //SearchOrder: Excel.XlSearchOrder.xlByRows, MatchCase: false, SearchFormat: true, ReplaceFormat: false);

            //objXLWs.PageSetup.LeftHeader = objXLWs.PageSetup.LeftHeader.Replace("TPAD.C9904", "eee");
            //objXLWs.PageSetup.CenterHeader = objXLWs.PageSetup.CenterHeader.Replace("TPAD.C9904", "eee");
            //objXLWs.PageSetup.RightHeader = objXLWs.PageSetup.RightHeader.Replace("TPAD.C9904", "eee");
            //objXLWs.PageSetup.LeftFooter = objXLWs.PageSetup.LeftFooter.Replace("TPAD.C9904", "eee");
            //objXLWs.PageSetup.CenterFooter = objXLWs.PageSetup.CenterFooter.Replace("TPAD.C9904", "eee");
            //objXLWs.PageSetup.RightFooter = objXLWs.PageSetup.RightFooter.Replace("TPAD.C9904", "eee"); 


            //objXLApp.ActiveWorkbook.Save();
            //objXLApp.Workbooks.Close();
            //objXLApp.Quit();

            //Process.Start(excelFile);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //frmMaterialImportExcel frm = new frmMaterialImportExcel();
            //frm.Show();
            frmShowExcel frm = new frmShowExcel();
            frm.Show();
        }

        private void btnTestGridBackground_Click(object sender, EventArgs e)
        {
            frmBackgroundGrid frm = new frmBackgroundGrid();
            TextUtils.OpenForm(frm);
        }

        private void btnErrorExcel_Click(object sender, EventArgs e)
        {
            frmErrorExcel frm = new frmErrorExcel();
            TextUtils.OpenForm(frm);
        }

        private void btnForm1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            TextUtils.OpenForm(frm);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (WaitDialogForm fWait1 = new WaitDialogForm("Vui lòng chờ trong giây lát", "Tạo", new Size(this.Width / 4, this.Height / 9), this))
            {
                DataTable dtModule = TextUtils.Select("select * from Modules with(nolock) where status = 2 and Code like '%tpad%' order by Code");
                foreach (DataRow item in dtModule.Rows)
                {
                    string productCode = item["Code"].ToString();
                    DataTable dt = TextUtils.Select("select * from ModuleVersion with(nolock) where ModuleCode = '" + productCode + "'");
                    if (dt.Rows.Count == 0)
                    {
                        using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát", "Tạo " + productCode, new Size(this.Width / 4, this.Height / 9), this))
                        {
                            try
                            {
                                string path = TextUtils.DownloadAll(productCode);

                                ModuleVersionModel model = new ModuleVersionModel();
                                //model.ProjectCode = misMatchModel.ProjectCode;
                                model.ModuleCode = productCode;
                                //model.MisMatchCode = misMatchModel.Code;
                                model.Version = 0;
                                model.Path = path;
                                model.Description = "Tạo phiên bản đầu tiên của module";
                                model.Reason = "Tạo phiên bản đầu tiên của module";
                                ModuleVersionBO.Instance.Insert(model);

                                //MessageBox.Show("Tạo phiên bản đầu tiên của module [" + productCode + "] thành công!");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Lỗi: " + ex.Message);
                            }
                        }
                    }
                }
            }
        }

        void Test()
        {
            string a = "TPAD";
            string a0 = "TPAD.B4501";
            string a1 = "TPAD.B4501.01";
            string a2 = "TPAD.B4501.01.01";
            string text = a + " - " + a.Split('.').Count() + Environment.NewLine +
                a0 + " - " + a0.Split('.').Count() + Environment.NewLine +
                a1 + " - " + a1.Split('.').Count() + Environment.NewLine +
                a2 + " - " + a2.Split('.').Count();
            MessageBox.Show(text);
        }

        void ChangeModuleName()
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang lấy mã mới"))
            {
                string tableCodeFilePath = @"\\server\data2\Thietke\ISO\ISO.Thietke\TAI LIEU DAO TAO\TAI LIEU HO TRO PHONG THIET KE\TK09- Huong dan doi ma san pham TK\TK09-BM01 - Bang thay doi ma TK.xlsx";
                List<string> listSheet = TextUtils.ListSheetInExcel(tableCodeFilePath);
                foreach (string sheetName in listSheet)
                {
                    if (!sheetName.ToUpper().StartsWith("TPAD.")) continue;

                    DataTable dt = TextUtils.ExcelToDatatableNoHeader(tableCodeFilePath, sheetName);
                    foreach (DataRow item in dt.Rows)
                    {                        
                        string newCode = item["F3"] == null ? "" : item["F3"].ToString();
                        if (newCode == "") continue;

                        ModulesModel model = null;
                        try
                        {
                            model = (ModulesModel)ModulesBO.Instance.FindByCode(newCode);
                        }
                        catch (Exception)
                        {                          
                        }
                        if (model != null)
                        {
                            string oldName = item["F5"] == null ? "" : item["F5"].ToString();
                            string newName = item["F6"] == null ? "" : item["F6"].ToString();
                            string name = (newName == "" ? oldName : newName);

                            model.Name = name;
                            ModulesBO.Instance.Update(model);
                        }                        
                    }                    
                }
            }
        }

        void DownloadDMVT()
        {
            DocUtils.InitFTPQLSX();
            ArrayList listModules = ModulesBO.Instance.FindByExpression(new Expression("Status", 2).And(new Expression("Code", "TPAD", "like")));
            int count = 0;
            foreach (var item in listModules)
            {
                ModulesModel module = (ModulesModel)item;
                string moduleCode = module.Code;
                string dmvtPath = string.Format("Thietke.Ck/{0}/{1}.Ck/VT.{1}.xlsm", moduleCode.Substring(0, 6), moduleCode);
                if (DocUtils.CheckExits(dmvtPath))
                {
                    DocUtils.DownloadFile("D:/ListDMVT", Path.GetFileName(dmvtPath), dmvtPath);
                    count++;
                }
            }
            MessageBox.Show(count.ToString());
        }

        void downloadCADandPDF()
        {
            string filePath = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            if (ofd.ShowDialog()== DialogResult.OK)
            {
                filePath = ofd.FileName;
            }
            else
            {
                return;
            }
            DocUtils.InitFTPQLSX();
            DataTable dt = TextUtils.ExcelToDatatableNoHeader(filePath, "Sheet1");
            foreach (DataRow item in dt.Rows)
            {
                try
                {
                    string partCode = TextUtils.ToString(item["F1"]);
                    string moduleCode = partCode.Substring(0, 10);
                    string cadPath = string.Format("Thietke.Ck/{0}/{1}.Ck/CAD.{1}/{2}.dwg", moduleCode.Substring(0, 6), moduleCode, partCode);
                    string pdfPath = string.Format("Thietke.Ck/{0}/{1}.Ck/BCCk.{1}/BC-CAD.{1}/{2}.jpg", moduleCode.Substring(0, 6), moduleCode, partCode);
                    if (DocUtils.CheckExits(cadPath))
                    {
                        DocUtils.DownloadFile("D:/CAD", Path.GetFileName(cadPath), cadPath);
                        DocUtils.DownloadFile("D:/CAD", Path.GetFileName(pdfPath), pdfPath);
                    }
                }
                catch
                {
                }                
            }
            MessageBox.Show("OK");
        }

        void KiemTraVatTu()
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang kiem tra..."))
            {
                string[] listFilePath = Directory.GetFiles("D:/ListDMVT");
                foreach (string filePath in listFilePath)
                {
                    try
                    {
                        string moduleCode = Path.GetFileName(filePath).Substring(3, 10);
                        DataTable dtDMVT = TextUtils.ExcelToDatatableNoHeader(filePath, "DMVT");
                        var results = from myRow in dtDMVT.AsEnumerable()
                                      where TextUtils.ToDecimal(myRow.Field<string>("F1")) > 0
                                      && !(myRow.Field<string>("F4")).StartsWith("TPAD")
                                      && !(myRow.Field<string>("F4")).StartsWith("PCB")
                                      select myRow;
                        if (results.Count() == 0) continue;

                        dtDMVT = results.CopyToDataTable();

                        for (int i = 0; i <= dtDMVT.Rows.Count - 1; i++)
                        {
                            string nameDMVT = dtDMVT.Rows[i][3].ToString();
                            if (nameDMVT == "") continue;
                            string hang = dtDMVT.Rows[i][9].ToString();

                            List<string> errorString = new List<string>();

                            #region Kiem tra hang co hop le
                            DataTable dtGroup = TextUtils.Select("select CustomerCode from vMaterialCustomer a where replace(a.Code,' ','') ='" + nameDMVT.Replace(" ", "").Replace("(", "/") + "'");
                            if (dtGroup.Rows.Count > 0)
                            {
                                DataRow[] drsCustomer = dtGroup.Select("CustomerCode = '" + hang + "'");
                                if (drsCustomer.Count() == 0)
                                {
                                    errorString.Add("Hãng không được sử dụng");
                                }
                            }
                            #endregion

                            #region Vật tư ngừng sử dụng

                            DataTable dtViewMaterial = TextUtils.Select("SELECT MaterialGroupCode FROM [vMaterial] with (nolock) where replace(Code,' ','') = '" + nameDMVT.Replace(" ", "").Replace(")", "/") + "'");
                            if (dtViewMaterial.Rows.Count > 0)
                            {
                                string materialGroupCode = dtViewMaterial.Rows[0][0].ToString();
                                if (materialGroupCode == "TPAVT.Z01")
                                {
                                    errorString.Add("Vật tư ngừng sử dụng");
                                }
                            }
                            #endregion

                            #region Vật tư tạm dừng sử dụng
                            DataTable dtMaterialCSDL = TextUtils.Select("SELECT * FROM [Material] with (nolock) where [StopStatus] = 1 and replace(Code,' ','') = '" + nameDMVT.Replace(" ", "").Replace(")", "/") + "'");
                            if (dtMaterialCSDL.Rows.Count > 0)
                            {
                                errorString.Add("Vật tư tạm dừng sử dụng");
                            }
                            #endregion

                            #region Kiểm tra trên quản lý sản xuất
                            //Kiem tra xem vat tu co trong kho chua
                            DataTable dtMaterialQLSX = LibQLSX.Select("SELECT top 1 p.PartsCode,m.ManufacturerCode"
                                + " FROM Manufacturer m RIGHT OUTER JOIN"
                                + " PartsManufacturer pm ON m.ManufacturerId = pm.ManufacturerId RIGHT OUTER JOIN"
                                + " Parts p ON pm.PartsId = p.PartsId"
                                + " where p.PartsCode = '" + nameDMVT.Replace(" ", "").Replace("(", "/") + "'");
                            if (dtMaterialQLSX.Rows.Count == 0)
                            {
                                errorString.Add("Vật tư không tồn tại");
                            }
                            else
                            {
                                if (dtMaterialQLSX.Rows[0]["ManufacturerCode"].ToString().ToUpper() != hang.ToUpper())
                                {
                                    errorString.Add("Hãng khác với hãng trên QLSX (" + hang + " - " + dtMaterialQLSX.Rows[0]["ManufacturerCode"].ToString() + ")");
                                }
                            }
                            #endregion

                            if (errorString.Count > 0)
                            {
                                TestModel model = new TestModel();
                                model.ModuleCode = moduleCode;
                                model.MaterialCode = nameDMVT;
                                model.MaterialName = dtDMVT.Rows[i]["F2"].ToString();
                                model.Hang = hang;
                                model.Error = string.Join(", ", errorString.ToArray());
                                TestBO.Instance.Insert(model);
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }

            MessageBox.Show("ok");
        }

        void KiemTraVatTu_VatLieu()
        {
            DataTable dtError = new DataTable();
            dtError.Columns.Add("ModuleCode");
            dtError.Columns.Add("STT");
            dtError.Columns.Add("MaterialCode");
            dtError.Columns.Add("MaterialName");
            dtError.Columns.Add("MaVatLieu");
            dtError.Columns.Add("VatLieu");
            dtError.Columns.Add("Error");

            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang kiem tra..."))
            {
                string[] listFilePath = Directory.GetFiles("D:/ListDMVT");
                foreach (string filePath in listFilePath)
                {
                    try
                    {
                        string moduleCode = Path.GetFileName(filePath).Substring(3, 10);
                        DataTable dtDMVT = TextUtils.ExcelToDatatableNoHeader(filePath, "DMVT");

                        var results = from myRow in dtDMVT.AsEnumerable()
                                      where TextUtils.ToDecimal(myRow.Field<string>("F1") != "" && myRow.Field<string>("F1") != null 
                                      ? myRow.Field<string>("F1").Substring(0, 1) : "") > 0
                                      select myRow;

                        if (results == null) continue;
                        if (results.Count() == 0) continue;
                        if (results.Count() > 0)
                        {
                            dtDMVT = results.CopyToDataTable();
                        }                        

                        for (int i = 0; i <= dtDMVT.Rows.Count - 1; i++)
                        {
                            string nameDMVT = dtDMVT.Rows[i]["F4"].ToString();
                            if (nameDMVT == "") continue;
                            //string hang = dtDMVT.Rows[i][9].ToString();
                            string MaVatLieu = TextUtils.ToString(dtDMVT.Rows[i]["F5"]).Trim();
                            string VatLieu = TextUtils.ToString(dtDMVT.Rows[i]["F8"]).Trim();
                            string stt = TextUtils.ToString(dtDMVT.Rows[i]["F1"]).Trim();

                            List<string> errorString = new List<string>();

                            if (MaVatLieu != "")
                            {
                                DataTable dtMaVatLieu = LibQLSX.Select("SELECT top 1 PartsCode from Parts with(nolock)"
                               + " where PartsCode = N'" + MaVatLieu.Replace(" ", "").Replace("(", "/") + "'");
                                if (dtMaVatLieu.Rows.Count == 0)
                                {
                                    errorString.Add("Mã vật liệu không tồn tại trên QLSX");
                                }
                            }

                            if (VatLieu != "" && VatLieu != "-")
                            {
                                DataTable dtVatLieu = LibQLSX.Select("SELECT top 1 MaterialsId from MaterialsModel with(nolock)"
                              + " where MaterialsId = N'" + VatLieu + "'");
                                if (dtVatLieu.Rows.Count == 0)
                                {
                                    errorString.Add("Vật tư không tồn tại trên QLSX");
                                }
                            }

                            if (MaVatLieu != "" && (VatLieu == "" || VatLieu == "-"))
                            {
                                errorString.Add("Vật tư không có vật liệu");
                            }

                            if (errorString.Count > 0)
                            {                                
                                DataRow dr = dtError.NewRow();
                                dr["ModuleCode"] = moduleCode;
                                dr["STT"] = stt;
                                dr["MaterialCode"] = nameDMVT;
                                dr["MaterialName"] = TextUtils.ToString(dtDMVT.Rows[i]["F2"]);
                                dr["MaVatLieu"] = MaVatLieu;
                                dr["VatLieu"] = VatLieu;
                                dr["Error"] = string.Join(", ", errorString.ToArray());
                                dtError.Rows.Add(dr);
                            }
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            gridControl1.DataSource = dtError;
            MessageBox.Show("ok");
        }

        void runMacroInWord(string filePath, string macroName, string parameter)
        {
            Word.Application word = new Word.Application();
            Word.Document doc = new Word.Document();

            doc = word.Documents.Open(filePath);
            word.Run(macroName, parameter);
            doc.Save();
            doc.Close();
            word.Quit();

            Process.Start(filePath);
        }

        void loadAllDmvt()
        {
            string[] listFile = Directory.GetFiles("D:\\ListDMVT", "*.*", SearchOption.TopDirectoryOnly);
            DataTable dtAll = new DataTable();
            foreach (string filePath in listFile)
            {
                try
                {
                    DataTable dt = TextUtils.ExcelToDatatableNoHeader(filePath, "DMVT");
                    dt = dt.AsEnumerable()
                                .Where(row => TextUtils.ToInt(row.Field<string>("F1") == "" ||
                                    row.Field<string>("F1") == null ? "0" : row.Field<string>("F1").Substring(0, 1)) > 0)
                                .CopyToDataTable();
                    if (dtAll.Rows.Count == 0)
                    {
                        dtAll = dt.Copy();
                    }
                    else
                    {
                        dtAll.Merge(dt);
                    }
                }
                catch
                {
                }
            }
            gridControl1.DataSource = dtAll;
            gridView1.BestFitColumns();
        }

        void addMaterialModuleLink()
        {
            //string localPath = "D:\\ListDMVT";
            //string[] listFiles = Directory.GetFiles(localPath);
            //foreach (string filePath in listFiles)
            //{
            //    string fileName = Path.GetFileName(filePath);
            //    string moduleCode = fileName.Substring(3, 10);
            //    try
            //    {
            //        DataTable dtDMVT = TextUtils.ExcelToDatatableNoHeader(filePath, "DMVT");
            //        string designer = TextUtils.ToString(dtDMVT.Rows[3]["F3"]);

            //        DataRow[] drs = dtDMVT.AsEnumerable()
            //                    .Where(row => TextUtils.ToInt(row.Field<string>("F1") == "" ||
            //                        row.Field<string>("F1") == null ? "0" : row.Field<string>("F1").Substring(0, 1)) > 0)
            //                    .ToArray();

            //        foreach (DataRow row in drs)
            //        {
            //            MaterialModuleLinkModel link = new MaterialModuleLinkModel();
            //            link.ModuleCode = moduleCode;
            //            link.STT = TextUtils.ToString(row["F1"]);
            //            link.Name = TextUtils.ToString(row["F2"]);
            //            link.ThongSo = TextUtils.ToString(row["F3"]);
            //            link.Code = TextUtils.ToString(row["F4"]);
            //            link.MaVatLieu = TextUtils.ToString(row["F5"]);
            //            link.Unit = TextUtils.ToString(row["F6"]);
            //            link.Qty = TextUtils.ToDecimal(row["F7"]);
            //            link.VatLieu = TextUtils.ToString(row["F8"]);
            //            link.Weight = TextUtils.ToDecimal(row["F9"]);
            //            link.Hang = TextUtils.ToString(row["F10"]);
            //            link.Note = TextUtils.ToString(row["F11"]);
            //            link.Designer = designer;
            //            link.DateCreated = DateTime.Now;

            //            MaterialModuleLinkBO.Instance.Insert(link);
            //        }
            //    }
            //    catch
            //    {                  
            //    }                
            //}
        }

        void addSuppliersManufacturerLink()
        {
            DataTable dt = LibQLSX.Select("SELECT     vRequirePartFull.SupplierId, Manufacturer.ManufacturerId"
                                            +" FROM vRequirePartFull INNER JOIN"
                                            +" Manufacturer ON vRequirePartFull.ManufacturerCode = Manufacturer.ManufacturerCode" 
                                            +" order by vRequirePartFull.SupplierId");
            long count = 0;
            foreach (DataRow r in dt.Rows)
            {
                string supplierId = TextUtils.ToString(r["SupplierId"]);
                string manufacturerId = TextUtils.ToString(r["ManufacturerId"]);
                if (supplierId == "" || manufacturerId == "") continue;

                DataTable dtSuppliersManufacturerLink = LibQLSX.Select("select * from SuppliersManufacturerLink with(nolock) where SupplierId = '" 
                    + supplierId + "' and ManufacturerId = '" + manufacturerId + "'");
                if (dtSuppliersManufacturerLink.Rows.Count > 0) continue;
                SuppliersManufacturerLinkModel model = new SuppliersManufacturerLinkModel();
                model.SupplierId = supplierId;
                model.ManufacturerId = manufacturerId;
                SuppliersManufacturerLinkBO.Instance.Insert(model);
                count++;
            }
            MessageBox.Show("Insert: " + count);
        }

        void uploadFolder(string folderPath, string ftpPath)
        {
            DocUtils.InitFTPTK();
            string folderName = Path.GetFileName(folderPath);
            if (!DocUtils.CheckExits(ftpPath + "/" + folderName))
            {
                DocUtils.MakeDir(ftpPath + "/" + folderName);
            }

            DocUtils.UploadDirectory(folderPath, ftpPath + "/" + folderName);
        }

        void updatePart()
        {
            string filePath = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
            }
            else
            {
                return;
            }
            //filePath = @"E:\PROJECTS\TanPhat\KAIZEN\Phòng vật tư\HScode-Xuất nhập khẩu\MISUMI-HSCODE.xlsx";
            DataTable dt = TextUtils.ExcelToDatatableNoHeader(filePath, "Sheet2");
            dt = dt.Select("F2 is not null and F2 <> ''").CopyToDataTable();
            DataTable dtPart = LibQLSX.Select("select * from Parts with(nolock)");

            int count = 0;
            foreach (DataRow row in dt.Rows)
            {
                string partsCode = TextUtils.ToString(row["F2"]);
                if (partsCode == "") continue;
                string des = TextUtils.ToString(row["F3"]);
                string hsCode = TextUtils.ToString(row["F4"]);
                decimal importTax = TextUtils.ToDecimal(row["F5"]);

                DataRow[] drs = dtPart.Select("PartsCode = '" + partsCode.Trim() + "'");
                if (drs.Length > 0)
                {
                    string partsId = TextUtils.ToString(drs[0]["PartsId"]);

                    PartsModel part = (PartsModel)PartsBO.Instance.FindByAttribute("PartsId", partsId)[0];
                    part.Description = des;
                    part.HsCode = hsCode;
                    part.ImportTax = importTax;

                    PartsBO.Instance.UpdateQLSX(part);
                    count++;
                }
            }
            MessageBox.Show(count.ToString());
        }

        void upateDatePrice()
        {
            string filePath = @"E:\PROJECTS\TanPhat\KAIZEN\VAT TU DA THEM GIA.xlsx";
            DataTable dt = TextUtils.ExcelToDatatableNoHeader(filePath, "Sheet");
            dt = dt.Select("F4 is not null and F4 <> ''").CopyToDataTable();
            DataTable dtPart = LibQLSX.Select("select * from Parts with(nolock)");

            int count = 0;
            foreach (DataRow row in dt.Rows)
            {
                string partsCode = TextUtils.ToString(row["F4"]);
                string MaVatLieu = TextUtils.ToString(row["F5"]);
                if (partsCode == "") continue;
                if (MaVatLieu != "" && MaVatLieu != "GCCX")
                {
                    partsCode = MaVatLieu;
                }

                DataRow[] drs = dtPart.Select("PartsCode = '" + partsCode.Trim() + "'");
                if (drs.Length > 0)
                {
                    string partsId = TextUtils.ToString(drs[0]["PartsId"]);
                    decimal price = TextUtils.ToDecimal(drs[0]["Price"]);
                    if (price <= 1) continue;

                    PartsModel part = (PartsModel)PartsBO.Instance.FindByAttribute("PartsId", partsId)[0];
                    part.UpdatedPriceDate = DateTime.Now;
                    PartsBO.Instance.UpdateQLSX(part);
                    count++;
                }
            }
            MessageBox.Show(count.ToString());
        }

        void updateUser()
        {
            string filePath = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
            }
            else
            {
                return;
            }
            DataTable dt = TextUtils.ExcelToDatatableNoHeader(filePath, "Sheet1");
            dt.Rows.RemoveAt(0);
            dt = dt.Select("F1 is not null and F1 > 0", "F2 ASC").CopyToDataTable();

            //DataTable dtKhongCoQLSX = dt.Copy();
            //dtKhongCoQLSX.Rows.Clear();

            //int count = 0;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    string code = TextUtils.ToString(row["F2"]);
                    if (code == "") continue;
                    string userName = TextUtils.ToString(row["F3"]);
                    string phongBanId = TextUtils.ToString(row["F9"]);
                    int groupId = TextUtils.ToInt(row["F10"]);

                    string sql = @"Update [Users] set DepartmentId1 = '" + phongBanId + "', UserGroup1ID = " + groupId + " where Code = '" + code + "'";

                    LibQLSX.ExcuteSQL(sql);

                    //DataTable dtUser = LibQLSX.Select("select top 1 * from Users with(nolock) where UserName = N'" + userName.Trim() + "'");
                    ////DataRow[] drs = dtUser.Select("UserName = '" + userName.Trim() + "'");
                    //if (dtUser.Rows.Count > 0)
                    //{
                    //    string userId = TextUtils.ToString(dtUser.Rows[0]["UserId"]);

                    //    TPA.Model.UsersModel user = (TPA.Model.UsersModel)TPA.Business.UsersBO.Instance.FindByAttribute("UserId", userId)[0];
                    //    user.Code = code;

                    //    PartsBO.Instance.UpdateQLSX(user);
                    //    count++;
                    //}
                    //else
                    //{
                    //    dtKhongCoQLSX.Rows.Add(userName, code);
                    //}
                }
                catch 
                {
                }
            }
            //TextUtils.DatatableToCSV(dtKhongCoQLSX, "D:\\1.csv");
            //MessageBox.Show(count.ToString());
        }

        void updateDepartmentUser_QLSX()
        {
            string filePath = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
            }
            else
            {
                return;
            }
            DataTable dt = TextUtils.ExcelToDatatableNoHeader(filePath, "Sheet1");
            //dt = dt.Select("F2 is not null and F2 <> ''").CopyToDataTable();

            DataTable dtKhongCoQLSX = dt.Copy();
            dtKhongCoQLSX.Rows.Clear();

            int count = 0;
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    string code = TextUtils.ToString(row["F2"]);
                    if (code == "") continue;
                    string userName = TextUtils.ToString(row["F3"]);
                    string departmentId = TextUtils.ToString(row["F7"]);

                    DataTable dtUser = LibQLSX.Select("select top 1 * from Users with(nolock) where Code = '" + code.Trim() + "'");
                    //DataRow[] drs = dtUser.Select("UserName = '" + userName.Trim() + "'");
                    if (dtUser.Rows.Count > 0)
                    {
                        string userId = TextUtils.ToString(dtUser.Rows[0]["UserId"]);

                        TPA.Model.UsersModel user = (TPA.Model.UsersModel)TPA.Business.UsersBO.Instance.FindByAttribute("UserId", userId)[0];
                        user.DepartmentId1 = departmentId;

                        PartsBO.Instance.UpdateQLSX(user);
                        count++;
                    }
                    //else
                    //{
                    //    dtKhongCoQLSX.Rows.Add(userName, code);
                    //}
                }
                catch
                {
                }
            }
            //TextUtils.DatatableToCSV(dtKhongCoQLSX, "D:\\2.csv");
            //MessageBox.Show(count.ToString());
        }

        void PrintMultipleFile()
        {
            string[] listFile = Directory.GetFiles("D:/Print");
            //Using below code we can print any document
            foreach (string filePath in listFile)
            {
                ProcessStartInfo info = new ProcessStartInfo(filePath);
                info.Verb = "Print";
                info.CreateNoWindow = true;
                info.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(info);
            }           
        }

        private string ExtractTextFromImage()
        {
            string filePath = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
            }
            else
            {
                return "";
            }
            Document modiDocument = new Document();
            modiDocument.Create(filePath);
            modiDocument.OCR(MiLANGUAGES.miLANG_ENGLISH);
            MODI.Image modiImage = (modiDocument.Images[0] as MODI.Image);
            string extractedText = modiImage.Layout.Text;
            modiDocument.Close();
            return extractedText;
        }

        decimal loadLaiVay(int month, int year)
        {
            decimal per = 0.07m / 365m;
            DataTable dt = LibIE.Select("SELECT [C_NGAYLAP],[FK_TKNO],[C_Month] ,[C_Year],sum([C_PSNO]) as [C_PSNO],0.00 as Total, 0.00 as Lai, 0.00 as TongLai FROM [tanphat].[dbo].V_XNTC_REPORT_ALL"
                                            + " where (FK_TKCO like '131%' or [FK_TKNO] like '331%') and [C_DTCP_MA] = 'F017.1602' and C_Month <= " + month + " and C_Year = " + year
                                            + " group by [C_NGAYLAP],[FK_TKNO],[C_Month],[C_Year]"
                                            + " order by [C_NGAYLAP]");
            if (dt.Rows.Count == 0) return 0;
            int days = DateTime.DaysInMonth(year, month);
            DateTime cuoiThang = new DateTime(year, month, days);
            dt.Rows.Add(cuoiThang, "331", month, year, 0, 0, 0, 0);
            decimal total = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string tk = TextUtils.ToString(dt.Rows[i]["FK_TKNO"]);
                DateTime ngayLap = TextUtils.ToDate3(dt.Rows[i]["C_NGAYLAP"]);
                if (tk.StartsWith("331"))
                {
                    total += TextUtils.ToDecimal(dt.Rows[i]["C_PSNO"]);
                }
                else
                {
                    total -= TextUtils.ToDecimal(dt.Rows[i]["C_PSNO"]);
                }

                dt.Rows[i]["Total"] = total;
                dt.Rows[i]["Lai"] = per * total;
                if (i == 0)
                {
                    dt.Rows[i]["TongLai"] = per * total;
                }
                else
                {
                    DateTime ngayLapTruoc = TextUtils.ToDate3(dt.Rows[i - 1]["C_NGAYLAP"]);
                    decimal laiTruoc = TextUtils.ToDecimal(dt.Rows[i - 1]["Lai"]);
                    decimal tongLaiTruoc = TextUtils.ToDecimal(dt.Rows[i - 1]["TongLai"]);
                    TimeSpan ts = ngayLap - ngayLapTruoc;
                    decimal tongLai = (ts.Days - 1) * laiTruoc + per * total + tongLaiTruoc;
                    dt.Rows[i]["TongLai"] = tongLai;
                }
            }
            decimal value = TextUtils.ToDecimal(dt.Rows[dt.Rows.Count - 1]["TongLai"]);
            
            return value;
        }

        void UpdateC_CostProductGroupLink(int type)
        {
            string filePath = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
            }
            else
            {
                return;
            }
            DataTable dt = TextUtils.ExcelToDatatableNoHeader(filePath, "Sheet1");

            int count = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i == 0) continue;
                string costCode = TextUtils.ToString(dt.Rows[i]["F1"]);
                int costId = TextUtils.ToInt(LibQLSX.ExcuteScalar("select top 1 ID from C_Cost where [IsDeleted] = 0 and Code = '" + costCode + "'"));
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (j < 2) continue;
                    string pGroupCode = TextUtils.ToString(dt.Rows[0][j]);
                    int pGroupId = TextUtils.ToInt(LibQLSX.ExcuteScalar("select top 1 ID from C_ProductGroup where Code = '" + pGroupCode + "'"));
                    int linkID = TextUtils.ToInt(LibQLSX.ExcuteScalar("select top 1 ID from [C_CostProductGroupLinkNew] where [C_CostID] = " + costId + " and [C_ProductGroupID] = " + pGroupId));
                    if (linkID == 0)
                    {
                        //notSave += costCode + "-" + pGroupCode + Environment.NewLine;
                        continue;
                    }
                    C_CostProductGroupLinkNewModel m = (C_CostProductGroupLinkNewModel)C_CostProductGroupLinkNewBO.Instance.FindByPK(linkID);
                    if (type == 0)
                    {
                        m.ValuePercentSX = TextUtils.ToDecimal(dt.Rows[i][j]);
                    }
                    if (type == 1)
                    {
                        m.ValuePercentKD1 = TextUtils.ToDecimal(dt.Rows[i][j]);
                    }
                    if (type == 2)
                    {
                        m.ValuePercentKD2 = TextUtils.ToDecimal(dt.Rows[i][j]);
                    }
                    //m.ValuePercentSX = TextUtils.ToDecimal(dt.Rows[i][j]);
                    C_CostProductGroupLinkNewBO.Instance.Update(m);
                    count++;
                }
            }
            MessageBox.Show(count.ToString());
        }

        void resetCostProductGroupLink()
        {
            //LibTest.ExcuteScalar("truncate table C_CostProductGroupLink");
            //DataTable dtCost = LibQLSX.Select("select ID from C_Cost where [IsDeleted] = 0");
            //DataTable dtProductGroup = LibQLSX.Select("select ID from C_ProductGroup");

            //int count = 0;
            //foreach (DataRow rCost in dtCost.Rows)
            //{
            //    int costID = TextUtils.ToInt(rCost["ID"]);
            //    foreach (DataRow rGroup in dtProductGroup.Rows)
            //    {
            //        int groupID = TextUtils.ToInt(rGroup["ID"]);
            //        C_CostProductGroupLinkNewModel m = new C_CostProductGroupLinkNewModel();
            //        m.ValuePercentKD1 = 0;
            //        m.ValuePercentKD2 = 0;
            //        m.ValuePercentSX = 0;
            //        m.NumberDay = 0;
            //        m.PersonNumber = 0;
            //        m.VtuPercent = 0;
            //        m.C_ProductGroupID = groupID;
            //        m.C_CostID = costID;
            //        C_CostProductGroupLinkNewBO.Instance.Insert(m);
            //        count++;
            //    }
            //}
            //MessageBox.Show("OK: " + count);
        }

        void updateSupplier()
        {
            string filePath = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
            }
            else
            {
                return;
            }
            DataTable dt = TextUtils.ExcelToDatatableNoHeader(filePath, "Sheet1");
            dt = dt.Select("F1 is not null and F1 > 0").CopyToDataTable();

            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    string code = TextUtils.ToString(row["F2"]);
                    if (code == "") continue;

                    string sql = @"Update [Suppliers] set Status = 2 where SupplierCode = N'" + code + "'";

                    LibQLSX.ExcuteSQL(sql);
                }
                catch
                {
                }
            }
        }
        private void btnTest_Click(object sender, EventArgs e)
        {
            updateSupplier();
            //updateUser();
        }

        private void btnTest2_Click(object sender, EventArgs e)
        {
            int type = TextUtils.ToInt(txtType.Text.Trim());
            UpdateC_CostProductGroupLink(type);
        }

        void updateMaterialModuleLink()
        {
            string pathLocal = @"D:\ListDMVT";
            System.IO.DirectoryInfo dirLocal = new System.IO.DirectoryInfo(pathLocal);
            FileInfo[] listLocal = dirLocal.GetFiles("*.*", System.IO.SearchOption.TopDirectoryOnly);
            foreach (FileInfo item in listLocal)
            {
                TextUtils.AddDMVTfromModule(item.FullName);
            }
        }

        private void btnDownloadDMVT_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn download tất cả các dmvt ở trên nguồn?", TextUtils.Caption, MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DownloadDMVT();
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            //TextUtils.ExportExcel(gridView1);
        }

        private void btnBaoGia_Click(object sender, EventArgs e)
        {
            frmBaoGia frm = new frmBaoGia();
            TextUtils.OpenForm(frm);
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (gridView2.RowCount > 0)
            {
                TextUtils.ExportExcel(gridView2);
            }
        }

        private void btnGetBarcode_Click(object sender, EventArgs e)
        {
            string filePath = @"D:\Thietke.Ck\TPAD.M\TPAD.M5211.Ck\BCCk.TPAD.M5211\BC-CAD.TPAD.M5211\TPAD.M5211.01.01.01.jpg";
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog()==DialogResult.OK)
            {
                filePath = ofd.FileName;
            }
            System.Drawing.Image img = System.Drawing.Image.FromFile(filePath);
            Bitmap mBitmap = new Bitmap(img);

            ArrayList barcodes = new ArrayList();
            BarcodeImaging.FullScanPage(ref barcodes, mBitmap, 100);
            mBitmap.Dispose();
            if (barcodes.Count>0)
            {
                textBox1.Text = barcodes.ToArray()[0].ToString();
            }
            else
            {
                MessageBox.Show("Không tìm thấy barcode!");
            }
           
        }

        private void btnGetTextInImage_Click(object sender, EventArgs e)
        {
            //string filePath = "";
            //OpenFileDialog ofd = new OpenFileDialog();
            //if (ofd.ShowDialog() == DialogResult.OK)
            //{
            //    textBox1.Text = TextUtils.ExtractTextFromPdf(ofd.FileName);
            //}
        }

        private void btnLoadProductModule_Click(object sender, EventArgs e)
        {
            loadTree("T009.1501");
        }

        private void treeData_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {

        }

        private void btnGetListNoPrice_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            TextUtils.LoadModulePriceTPAD("TPAD.B3580", false, out dt,"");
            gridControl1.DataSource = dt;
        }

        private void btnAddMaterialModuleLink_Click(object sender, EventArgs e)
        {
            //addMaterialModuleLink();
        }

        private void btnUpdateTonKho_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                DataTable dt = TextUtils.ExcelToDatatableNoHeader(ofd.FileName, "Sheet1");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    
                }
            }
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtPass.Text = BMS.Utils.MD5.DecryptPassword(txtPass.Text.Trim());
        }

        public void LoadModulePriceTPAD(string moduleCode, bool usingStuffsPrice, out DataTable dtNoPrice, string projectCode)
        {
            DataTable dtDmvtFull = new DataTable();
            dtNoPrice = new DataTable();

            #region Load tu danh muc vat tu
            string _serverPathCK = string.Format("Thietke.Ck/{0}/{1}.Ck/VT.{1}.xlsm", moduleCode.Substring(0, 6), moduleCode);
            try
            {
                if (DocUtils.CheckExits(_serverPathCK))
                {
                    #region Init table dmvt
                    if (File.Exists("D:/VT." + moduleCode + ".xlsm"))
                    {
                        File.Delete("D:/VT." + moduleCode + ".xlsm");
                    }
                    //Download file danh mục vật tư
                    DocUtils.DownloadFile("D:/", "VT." + moduleCode + ".xlsm", _serverPathCK);
                    DataTable dtDMVT = TextUtils.ExcelToDatatable("D:/VT." + moduleCode + ".xlsm", "DMVT");
                    File.Delete("D:/VT." + moduleCode + ".xlsm");

                    dtDmvtFull = dtDMVT.AsEnumerable()
                        .Where(row => TextUtils.ToInt(row.Field<string>("F1") == "" ||
                            row.Field<string>("F1") == null ? "0" : row.Field<string>("F1").Substring(0, 1)) > 0)
                        .CopyToDataTable();

                    dtDmvtFull.Columns.Add("Price", typeof(decimal));
                    dtDmvtFull.Columns.Add("TotalPrice", typeof(decimal));
                    #endregion

                    foreach (DataRow itemRow in dtDmvtFull.Rows)
                    {
                        string code = TextUtils.ToString(itemRow["F4"]);
                        decimal qty = TextUtils.ToDecimal(itemRow["F7"]);
                        //decimal qty = TextUtils.ToDecimal(itemRow["F7"]);
                        string thongSo = TextUtils.ToString(itemRow["F3"]);
                        string unit = TextUtils.ToString(itemRow["F6"]);
                        string stt = TextUtils.ToString(itemRow["F1"]);
                        decimal price = TextUtils.ToDecimal(itemRow["Price"]);
                        string materialCode = code.Replace(" ", "").Replace("/", "#").Replace(")", "#");
                        string sourceCode = TextUtils.ToString(itemRow["F5"]).Trim().Replace("/", "#").Replace(")", "#");
                        string vatLieu = TextUtils.ToString(itemRow["F8"]);
                        string hang = TextUtils.ToString(itemRow["F10"]);
                        decimal weight = TextUtils.ToDecimal(itemRow["F9"]);

                        #region Get Price of VT

                        #region Set Qty
                        string sttParent = "";
                        string[] array = stt.Split('.');
                        if (array.Length > 1)
                        {
                            for (int i = 0; i < array.Length; i++)
                            {
                                if (i == 0)
                                {
                                    sttParent += array[i];
                                }
                                else if (i == array.Length - 1)
                                {
                                    continue;
                                }
                                else
                                {
                                    sttParent += "." + array[i];
                                }
                            }

                            DataRow[] drsParent = dtDmvtFull.Select("F1 = '" + sttParent + "'");
                            itemRow["F7"] = TextUtils.ToString(qty * TextUtils.ToDecimal(drsParent[0]["F7"]));
                            qty = TextUtils.ToDecimal(itemRow["F7"]);
                        }
                        #endregion

                        if (code == moduleCode)
                        {
                            itemRow["Price"] = 0;
                            itemRow["TotalPrice"] = 0;
                            continue;
                        }

                        if (price > 0) continue;
                        if (code.StartsWith("TPAD") && code.Length == 10)
                        {
                            #region Get Price of Thiet ke co khi con
                            try
                            {
                                DataTable dtNO = new DataTable();
                                LoadModulePriceTPAD(code, true, out dtNO, projectCode);
                                if (dtNO.Rows.Count > 0)
                                {
                                    dtNoPrice.Merge(dtNO);
                                }

                                itemRow["Price"] = 1;//TextUtils.ToDecimal(dtChild.Compute("Sum(TotalPrice)", ""));
                            }
                            catch
                            {
                                itemRow["Price"] = 0;
                            }
                            #endregion
                        }
                        else if (code.StartsWith("PCB"))
                        {
                            #region Get Price of Thiet ke dien tu
                            try
                            {
                                DataTable dtNO = new DataTable();
                                DataTable dtDMVT_DT = TextUtils.LoadModulePricePCB(code, out dtNO);
                                if (dtNO.Rows.Count > 0)
                                {
                                    dtNoPrice.Merge(dtNO);
                                }
                                itemRow["Price"] = TextUtils.ToDecimal(dtDMVT_DT.Compute("Sum(TotalPrice)", ""));
                            }
                            catch
                            {
                                itemRow["Price"] = 0;
                            }
                            #endregion
                        }
                        else
                        {
                            if (unit == "BỘ")
                            {
                                #region Get price of Bộ
                                DataRow[] drs = dtDmvtFull.Select("F1 like '" + stt + ".%'");

                                foreach (DataRow r in drs)
                                {
                                    if (thongSo == "HÀN")
                                    {
                                        r["Price"] = 1;
                                        r["TotalPrice"] = 1;
                                    }
                                    //else
                                    //{
                                    //    r["F7"] = (qty * TextUtils.ToDecimal(r["F7"])).ToString();
                                    //}
                                }

                                if (thongSo != "HÀN")
                                {
                                    itemRow["Price"] = 1;
                                }
                                else
                                {
                                    //string sql1 = "SELECT top 1 Price FROM  vGetPriceOfPart with(nolock)"
                                    //                   + " WHERE Price > 1 AND replace(replace([PartsCode],'/','#'),')','#') = '" + materialCode + "'"
                                    //                   + " ORDER BY DateAboutF DESC";
                                    string sql1 = "exec spGetPriceOfPart '" + materialCode + "'";
                                    DataTable dtOrderPrice = LibQLSX.Select(sql1);
                                    if (dtOrderPrice.Rows.Count > 0)
                                    {
                                        itemRow["Price"] = TextUtils.ToDecimal(dtOrderPrice.Rows[0][0]);
                                    }
                                    else
                                    {
                                        itemRow["Price"] = 0;
                                    }
                                }
                                #endregion
                            }
                            else
                            {
                                try
                                {
                                    #region Get price of Vt
                                    decimal currentPrice = 0;
                                    if (sourceCode != "")
                                    {
                                        #region Nếu có vật tư gốc
                                        DataTable dtUnitDefinition = LibQLSX.Select("SELECT * FROM [vUnitDefinition] with(nolock)"
                                            + " WHERE REPLACE(REPLACE(replace(replace([PartsCode],'/','#'),')','#'), CHAR(13), ''), CHAR(10), '') = '" + sourceCode + "'");

                                        //string sql1 = "SELECT top 1 Price FROM  vGetPriceOfPart with(nolock)"
                                        //            + " WHERE Price > 1 AND replace(replace([PartsCode],'/','#'),')','#') = '" + sourceCode + "'"
                                        //            + " ORDER BY DateAboutF DESC";
                                        string sql1 = "exec spGetPriceOfPart '" + sourceCode + "'";
                                        DataTable dtOrderPrice = LibQLSX.Select(sql1);
                                        if (dtOrderPrice.Rows.Count > 0)
                                        {
                                            currentPrice = TextUtils.ToDecimal(dtOrderPrice.Rows[0][0]);
                                        }

                                        if (dtUnitDefinition.Rows.Count > 0)
                                        {
                                            DataRow[] drs = dtUnitDefinition.Select("UnitName = 'kg'");
                                            if (drs.Length > 0)
                                            {
                                                decimal weightData = TextUtils.ToDecimal(drs[0]["Value"]);
                                                itemRow["Price"] = (weight / weightData) * currentPrice;
                                            }
                                            else
                                            {
                                                if (currentPrice > 0)
                                                {
                                                    itemRow["Price"] = currentPrice;
                                                }
                                                else
                                                {
                                                    #region Giá theo hãng, vật liệu
                                                    if (usingStuffsPrice)
                                                    {
                                                        DataTable dtStuffsHang = TextUtils.Select("Select top 1 * from Stuffs with(nolock) where (Code = '' or Code is null) and Hang = N'" + hang + "'");
                                                        if (dtStuffsHang.Rows.Count > 0)
                                                        {
                                                            itemRow["Price"] = TextUtils.ToDecimal(dtStuffsHang.Rows[0]["Price"]);
                                                        }
                                                        else
                                                        {
                                                            DataTable dtStuffsHangVl = TextUtils.Select("Select top 1 * from Stuffs with(nolock) where Code = N'" + vatLieu
                                                            + "' and Hang = N'" + hang + "'");

                                                            if (dtStuffsHangVl.Rows.Count > 0)
                                                            {
                                                                bool isWeight = TextUtils.ToBoolean(dtStuffsHangVl.Rows[0]["TypeWeight"]);
                                                                if (isWeight)
                                                                {
                                                                    itemRow["Price"] = weight * TextUtils.ToDecimal(dtStuffsHangVl.Rows[0]["Price"]);
                                                                }
                                                                else
                                                                {
                                                                    itemRow["Price"] = TextUtils.ToDecimal(dtStuffsHangVl.Rows[0]["Price"]);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                DataTable dtStuffsVT = TextUtils.Select("Select top 1 * from Stuffs with(nolock) where Code = N'" + vatLieu + "'");
                                                                if (dtStuffsVT.Rows.Count > 0)
                                                                {
                                                                    itemRow["Price"] = weight * TextUtils.ToDecimal(dtStuffsVT.Rows[0]["Price"]);
                                                                }
                                                                else
                                                                {
                                                                    itemRow["Price"] = 0;
                                                                }
                                                            }
                                                        }
                                                    }
                                                    #endregion
                                                }
                                            }
                                        }
                                        else
                                        {
                                            itemRow["Price"] = currentPrice;
                                        }
                                        #endregion
                                    }
                                    else
                                    {
                                        #region Không có vật tư gốc
                                        if (thongSo == "TPA" && code.StartsWith("TPAD."))
                                        {
                                            #region Giá theo hãng, vật liệu
                                            if (usingStuffsPrice)
                                            {
                                                DataTable dtStuffsHang = TextUtils.Select("Select top 1 * from Stuffs with(nolock) where (Code = '' or Code is null) and Hang = N'" + hang + "'");
                                                if (dtStuffsHang.Rows.Count > 0)
                                                {
                                                    itemRow["Price"] = TextUtils.ToDecimal(dtStuffsHang.Rows[0]["Price"]);
                                                }
                                                else
                                                {
                                                    DataTable dtStuffsHangVl = TextUtils.Select("Select top 1 * from Stuffs with(nolock) where Code = N'" + vatLieu
                                                    + "' and Hang = N'" + hang + "'");

                                                    if (dtStuffsHangVl.Rows.Count > 0)
                                                    {
                                                        bool isWeight = TextUtils.ToBoolean(dtStuffsHangVl.Rows[0]["TypeWeight"]);
                                                        if (isWeight)
                                                        {
                                                            itemRow["Price"] = weight * TextUtils.ToDecimal(dtStuffsHangVl.Rows[0]["Price"]);
                                                        }
                                                        else
                                                        {
                                                            itemRow["Price"] = TextUtils.ToDecimal(dtStuffsHangVl.Rows[0]["Price"]);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        DataTable dtStuffsVT = TextUtils.Select("Select top 1 * from Stuffs with(nolock) where Code = N'" + vatLieu + "'");
                                                        if (dtStuffsVT.Rows.Count > 0)
                                                        {
                                                            itemRow["Price"] = weight * TextUtils.ToDecimal(dtStuffsVT.Rows[0]["Price"]);
                                                        }
                                                        else
                                                        {
                                                            itemRow["Price"] = 0;
                                                        }
                                                    }
                                                }
                                            }
                                            #endregion
                                        }
                                        else
                                        {
                                            //string sqlM = "SELECT top 1 Price FROM  vGetPriceOfPart with(nolock)"
                                            //            + " WHERE Price > 1 AND replace(replace([PartsCode],'/','#'),')','#') = '" + materialCode + "'"
                                            //            + " ORDER BY DateAboutF DESC";
                                            string sqlM = "exec spGetPriceOfPart '" + materialCode + "'";
                                            DataTable dtOrderPriceM = LibQLSX.Select(sqlM);
                                            if (dtOrderPriceM.Rows.Count > 0)
                                            {
                                                currentPrice = TextUtils.ToDecimal(dtOrderPriceM.Rows[0][0]);
                                            }
                                            if (currentPrice > 0)
                                            {
                                                itemRow["Price"] = currentPrice;
                                            }
                                            else
                                            {
                                                if (thongSo.ToUpper() == "TPA")
                                                {
                                                    #region Giá theo hãng, vật liệu
                                                    if (usingStuffsPrice)
                                                    {
                                                        DataTable dtStuffsHang = TextUtils.Select("Select top 1 * from Stuffs with(nolock) where (Code = '' or Code is null) and Hang = N'" + hang + "'");
                                                        if (dtStuffsHang.Rows.Count > 0)
                                                        {
                                                            itemRow["Price"] = TextUtils.ToDecimal(dtStuffsHang.Rows[0]["Price"]);
                                                        }
                                                        else
                                                        {
                                                            DataTable dtStuffsHangVl = TextUtils.Select("Select top 1 * from Stuffs with(nolock) where Code = N'" + vatLieu
                                                            + "' and Hang = N'" + hang + "'");

                                                            if (dtStuffsHangVl.Rows.Count > 0)
                                                            {
                                                                bool isWeight = TextUtils.ToBoolean(dtStuffsHangVl.Rows[0]["TypeWeight"]);
                                                                if (isWeight)
                                                                {
                                                                    itemRow["Price"] = weight * TextUtils.ToDecimal(dtStuffsHangVl.Rows[0]["Price"]);
                                                                }
                                                                else
                                                                {
                                                                    itemRow["Price"] = TextUtils.ToDecimal(dtStuffsHangVl.Rows[0]["Price"]);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                DataTable dtStuffsVT = TextUtils.Select("Select top 1 * from Stuffs with(nolock) where Code = N'" + vatLieu + "'");
                                                                if (dtStuffsVT.Rows.Count > 0)
                                                                {
                                                                    itemRow["Price"] = weight * TextUtils.ToDecimal(dtStuffsVT.Rows[0]["Price"]);
                                                                }
                                                                else
                                                                {
                                                                    itemRow["Price"] = 0;
                                                                }
                                                            }
                                                        }
                                                    }
                                                    #endregion
                                                }
                                            }
                                        }

                                        #endregion
                                    }
                                    #endregion
                                }
                                catch
                                {
                                    itemRow["Price"] = 0;
                                }
                            }
                        }
                        #endregion
                    }
                }
            }
            catch
            {
            }
            #endregion

            #region Set finish table
            if (dtDmvtFull.Rows.Count > 0)
            {
                DataRow[] drs = dtDmvtFull.Select("Price = 0 or Price is null");
                if (drs.Length > 0)
                {
                    if (dtNoPrice.Rows.Count > 0)
                    {
                        dtNoPrice.Merge(drs.CopyToDataTable());
                    }
                    else
                    {
                        dtNoPrice = drs.CopyToDataTable();
                    }
                }
            }
            #endregion
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "List Part with Price = 0 ..."))
            {
                DocUtils.InitFTPQLSX();

                DataTable dtData = new DataTable();
                dtData.Columns.Add("F1");
                dtData.Columns.Add("F2");
                dtData.Columns.Add("F3");
                dtData.Columns.Add("F4");
                dtData.Columns.Add("F5");
                dtData.Columns.Add("F6");
                dtData.Columns.Add("F7");
                dtData.Columns.Add("F8");
                dtData.Columns.Add("F9");
                dtData.Columns.Add("F10");
                dtData.Columns.Add("F11");
                dtData.Columns.Add("F12");
                //dtData.Columns.Add("TypeName");
                //dtData.Columns.Add("Type");
                dtData.Columns.Add("Price", typeof(decimal));
                dtData.Columns.Add("TotalPrice", typeof(decimal));
                //dtData.Columns.Add("NgungSuDung");

                DataTable dtModule = LibQLSX.Select("select FolderCode from SourceCode where FolderCode like 'TPAD.%' order by FolderCode");
                foreach (DataRow r in dtModule.Rows)
                {
                    try
                    {
                        string code = TextUtils.ToString(r["FolderCode"]);
                        DataTable dtNoPrice = new DataTable();
                        LoadModulePriceTPAD(code, true, out dtNoPrice, "");
                        if (dtData.Rows.Count == 0)
                        {
                            if (dtNoPrice.Rows.Count > 0)
                            {
                                dtData = dtNoPrice;
                            }
                        }
                        else
                        {
                            if (dtNoPrice.Rows.Count > 0)
                                dtData.Merge(dtNoPrice);
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }

                if (dtData.Rows.Count > 0)
                {
                    string path = @"D:";
                    TextUtils.DatatableToCSV(dtData, path + "\\PartNotPrice.csv");
                    File.Move(path + "\\PartNotPrice.csv", path + "\\PartNotPrice.xls");
                }
            }
        }

        private void btnUpdatePriceVT_Click(object sender, EventArgs e)
        {
            string filePath = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
            }
            else
            {
                return;
            }

            DataTable dt = TextUtils.ExcelToDatatableNoHeader(filePath, "Sheet1");

            DataTable dtQLSX = new DataTable();
            dtQLSX.Columns.Add("Code");

            int count = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i == 0) continue;
                string Code = TextUtils.ToString(dt.Rows[i]["F2"]);
                if (Code == "") continue;
                
                decimal price = TextUtils.ToDecimal(dt.Rows[i]["F4"]);

                string sql1 = "select count(PartsId) from Parts where PartsCode = '" + Code + "'";

                int countP = TextUtils.ToInt(LibQLSX.ExcuteScalar(sql1));
                if (countP > 0)
                {
                    string sql = "update Parts set Price = " + price + ", UpdatedPriceDate = GETDATE() where PartsCode = '" + Code + "'";
                    LibQLSX.ExcuteSQL(sql);
                    count++;
                }
                else
                {
                    dtQLSX.Rows.Add(Code);                    
                }
            }
            if (dtQLSX.Rows.Count>0)
            {
                TextUtils.DatatableToCSV(dtQLSX, @"D:\\1.csv");
            }

            MessageBox.Show("OK - " + dtQLSX.Rows.Count);
        }
    }
}
