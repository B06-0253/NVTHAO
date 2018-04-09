using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using Microsoft.VisualBasic;
using BMS.Model;
using BMS.Business;
using DevExpress.Utils;
using Forms.Properties;

namespace BMS
{
    public partial class frmHSTK : _Forms
    {
        string _fileNameHSTKCK = "HSTK.xlsm"; // Tên file HSTk mẫu
        string _pPath = Application.StartupPath + "\\Templates\\";
        string _pPathDT = Application.StartupPath + "\\Templates\\DT\\";
        string _productCodeDT = "";
        string _productNameDT = "";

        public frmHSTK()
        {
            InitializeComponent();
        }

        private void frmHSTK_Load(object sender, EventArgs e)
        {
            txtPheDuyet.Text = Settings.Default.APPROVE;
            txtKiemTra.Text = Settings.Default.CHECK;
            txtVe.Text = Settings.Default.PAINT;
            cboMaterialMI.Text = Settings.Default.MATERIAL;

            loadModule();
        }

        public DataTable GetMachIn(string filePath)
        {
            try
            {
                DataTable dt1 = TextUtils.ExcelToDatatable(filePath.Trim(), "DMVT");
                DataTable dt = dt1.Copy();

                dt = dt.Select("F4 like '%PCB%'").CopyToDataTable();
                dt = dt.AsEnumerable()
                            .GroupBy(r => r.Field<string>("F4"))
                            .Select(g => g.First())
                            .Distinct()
                            .CopyToDataTable();
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }

        void checkExistProduct()
        {
            if (txtCode.Text.Trim() == "")
            {
                MessageBox.Show("Xin vui lòng chọn mã sản phẩm!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            try
            {
                _productCodeDT = txtCode.Text.Trim().Split('.')[1].ToUpper();
            }
            catch (Exception)
            {
                MessageBox.Show("Mã sản phẩm không đúng định dạng!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            try
            {
                _productNameDT = ((ModulesModel)ModulesBO.Instance.FindByAttribute("Code", txtCode.Text.Trim())[0]).Name.ToUpper();
            }
            catch (Exception)
            {
                MessageBox.Show("Mã này không tồn tại!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }

        private void btnHSTK_Click(object sender, EventArgs e)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo hồ sơ thiết kế cơ khí!"))
            {
                string productName = "";
                string productCode = txtProductCode.Text.Trim().ToUpper();
                try
                {
                    productName = ((ModulesModel)ModulesBO.Instance.FindByAttribute("Code", productCode.Trim())[0]).Name;
                }
                catch (Exception)
                {
                    MessageBox.Show("Mã này không tồn tại!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                string pathProduct = "D:\\Thietke.Ck\\" + Strings.Mid((string)productCode, 1, 6) + "\\" + productCode + ".Ck\\VT." + productCode + ".xlsm";

                Excel.Application objXLApp = default(Excel.Application);
                Excel.Workbook objXLWb = default(Excel.Workbook);
                Excel.Worksheet objXLWs = default(Excel.Worksheet);

                string path = "D:\\Thietke.Ck\\" + productCode.Substring(0, 6) + "\\" + productCode + ".Ck\\DOC." + productCode;
                string fileNameHSTK = "HS." + productCode + ".xlsm";
                try
                {
                    if (productCode != "")
                    {
                        //TextUtils.EndProcess("EXCEL");

                        File.Copy(_pPath + "\\" + _fileNameHSTKCK, path + "\\" + fileNameHSTK, true); // Copy file hồ sơ thiết kế

                        //------------ Chỉnh sửa nội dung ------------
                        objXLApp = new Excel.Application();
                        objXLApp.Workbooks.Open(path + "\\" + fileNameHSTK);
                        objXLWb = objXLApp.Workbooks[1];
                        objXLWs = (Excel.Worksheet)objXLWb.Worksheets[1];

                        #region Add Data
                        if (chkTKD.Checked)
                        {
                            objXLApp.Cells[27, 3] = productCode;
                        }
                        else
                        {
                            objXLApp.Cells[27, 3] = "Không có";
                        }

                        if (chkDatasheet.Checked)
                        {
                            objXLApp.Cells[28, 3] = "DAT." + productCode;
                        }
                        else
                        {
                            objXLApp.Cells[28, 3] = "Không có";
                        }

                        if (chkFolderTKD.Checked)
                        {
                            objXLApp.Cells[29, 3] = "PRJ." + productCode;
                        }
                        else
                        {
                            objXLApp.Cells[29, 3] = "Không có";
                        }

                        if (chkFileDND.Checked)
                        {
                            objXLApp.Cells[30, 3] = productCode + ".Dn.pdf";
                        }
                        else
                        {
                            objXLApp.Cells[30, 3] = "Không có";
                        }
                        //------------ Du lieu TK CƠ KHÍ ------------

                        //--File DMVT --
                        if (cDMVT.Checked) // File danh mục vật tư
                        {
                            objXLApp.Cells[14, 3] = "VT." + productCode + ".xlsm";
                        }
                        else
                        {
                            objXLApp.Cells[14, 3] = "Không có";
                        }
                        //--Thư mục chứa file DOC --
                        if (cDOC.Checked) // File HSTK
                        {
                            objXLApp.Cells[15, 3] = "DOC." + productCode;
                        }
                        else
                        {
                            objXLApp.Cells[15, 3] = "Không có";
                        }
                        //--File HSTK --
                        if (cHSTK.Checked) // File HSTK
                        {
                            objXLApp.Cells[16, 3] = "HS." + productCode + ".xlsx";
                        }
                        else
                        {
                            objXLApp.Cells[16, 3] = "Không có";
                        }
                        //--File PTTK --
                        if (cPTTK.Checked) // File PTTK
                        {
                            objXLApp.Cells[17, 3] = "PTTK." + productCode + ".docm";
                        }
                        else
                        {
                            objXLApp.Cells[17, 3] = "Không có";
                        }

                        objXLApp.Cells[18, 3] = "3D." + productCode;

                        if (c2D.Checked) // Thư mục 2D
                        {
                            objXLApp.Cells[19, 3] = "CAD." + productCode;
                        }
                        else
                        {
                            objXLApp.Cells[19, 3] = "Không có";
                        }
                        //--Thư mục CNC --
                        if (cCNC.Checked)
                        {
                            objXLApp.Cells[20, 3] = "MAT." + productCode;
                        }
                        else
                        {
                            objXLApp.Cells[20, 3] = "Không có";
                        }
                        //--Thư mục IN TEM --
                        if (cInTem.Checked)
                        {
                            objXLApp.Cells[21, 3] = "DATA1.Ck." + productCode;
                        }
                        else
                        {
                            objXLApp.Cells[21, 3] = "Không có";
                        }
                        //--Thư mục gia công 3D --
                        if (c3D.Checked)
                        {
                            objXLApp.Cells[22, 3] = "IGS." + productCode;
                        }
                        else
                        {
                            objXLApp.Cells[22, 3] = "Không có";
                        }
                        //--Thư mục gia công HDLR --
                        if (cHDLR.Checked)
                        {
                            objXLApp.Cells[23, 3] = "LRP." + productCode;
                        }
                        else
                        {
                            objXLApp.Cells[23, 3] = "Không có";
                        }
                        //--Thư mục Datasheets --
                        if (cDatasheets.Checked)
                        {
                            objXLApp.Cells[24, 3] = "DAT." + productCode;
                        }
                        else
                        {
                            objXLApp.Cells[24, 3] = "Không có";
                        }
                        //--Thư mục bản vẽ Thủy lực --
                        if (cTL.Checked)
                        {
                            objXLApp.Cells[25, 3] = "TL." + productCode;
                        }
                        else
                        {
                            objXLApp.Cells[25, 3] = "Không có";
                        }
                        //--Thư mục bản vẽ Khí nén --
                        if (cKN.Checked)
                        {
                            objXLApp.Cells[26, 3] = "KN." + productCode;
                        }
                        else
                        {
                            objXLApp.Cells[26, 3] = "Không có";
                        }

                        #endregion Add Data

                        objXLWs.Cells[5, 3] = productName;
                        objXLApp.Cells[6, 3] = productCode;
                        objXLApp.Cells[7, 3] = Global.AppFullName;

                        objXLApp.Cells[9, 1] = "Tân Phát - " + DateTime.Now.Year;
                        objXLWs.PageSetup.LeftHeader = productCode + " - " + productName;
                        objXLWs.PageSetup.RightHeader = Global.AppFullName;
                        objXLWs.Cells[34, 3] = "Tân Phát, ngày " + (DateTime.Now.Day) + " tháng " + (DateTime.Now.Month) + " năm " + DateTime.Now.Year;

                        //Thêm mạch vào trong hồ sơ thiết kế
                        System.Data.DataTable dt = GetMachIn(pathProduct);
                        if (dt != null)
                        {
                            int count = dt.Rows.Count;
                            for (int i = count - 1; i >= 0; i--)
                            {
                                ((Excel.Range)objXLWs.Rows[33]).Insert();
                                objXLWs.Cells[33, 1] = "3." + (i + 1);
                                objXLWs.Cells[33, 2] = dt.Rows[i][1].ToString(); //.ToLower
                                objXLWs.Cells[33, 3] = dt.Rows[i][3].ToString(); //.ToLower
                            }
                            ((Excel.Range)objXLWs.Rows[32]).Delete();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Chưa chọn mã sản phẩm!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                finally
                {
                    objXLApp.ActiveWorkbook.Save();
                    objXLApp.Workbooks.Close();
                    objXLApp.Quit();
                    Process.Start(path + "\\" + fileNameHSTK);
                }
            }
        }

        private void btnBrowerCK_Click(object sender, EventArgs e)
        {

        }

        private void btnBanVeMachIn_Click(object sender, EventArgs e)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo biểu mẫu bản vẽ mạch in"))
            {
                checkExistProduct();
                Word.Application word = new Word.Application();
                Word.Document doc = new Word.Document();
                try
                {
                    string localFilePath = @"D:\Thietke.Dt\PCB." + _productCodeDT.Substring(0, 1) + @"\PCB." + _productCodeDT + @"\PRD.PCB." + _productCodeDT + @"\";
                    string fileName = "KTMI.PCB." + _productCodeDT + ".docm";
                    try
                    {
                        File.Copy(_pPathDT + "KTMI.PCB.CODE.docm", (localFilePath + fileName), true);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Xin vui lòng chọn đúng mã thiết kế.", "Thông báo");
                        doc.Close();
                        word.Quit();
                        return;
                    }


                    doc = word.Documents.Open((localFilePath + fileName));
                    doc.Activate();

                    TextUtils.FindReplaceAnywhere(word, ".CODE", "." + _productCodeDT);
                    TextUtils.FindReplaceAnywhere(word, "<productname>", _productNameDT);
                    TextUtils.FindReplaceAnywhere(word, "<tenmach>", txtTenMachIn.Text.Trim());

                    TextUtils.FindReplaceAnywhere(word, "<now>", DateTime.Now.ToString());
                    TextUtils.FindReplaceAnywhere(word, "<user>", Global.AppUserName);

                    TextUtils.RepalaceText(doc, "<day>", DateTime.Now.Day.ToString());
                    TextUtils.RepalaceText(doc, "<month>", DateTime.Now.Month.ToString());
                    TextUtils.RepalaceText(doc, "<year>", DateTime.Now.Year.ToString());

                    TextUtils.RepalaceText(doc, "<designer>", Global.AppFullName);
                    TextUtils.RepalaceText(doc, "<paint>", txtVe.Text.Trim());
                    TextUtils.RepalaceText(doc, "<check>", txtKiemTra.Text.Trim());
                    TextUtils.RepalaceText(doc, "<approve>", txtPheDuyet.Text.Trim());

                    TextUtils.FindReplaceAnywhere(word, "<ma>", cboMaterialMI.Text);

                    TextUtils.RepalaceText(doc, "<date>", DateTime.Now.ToString("dd/MM/yyyy"));

                    doc.Save();
                    doc.Close();
                    word.Quit();

                    //Process.Start(localFilePath + fileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    TextUtils.ReleaseComObject(doc);
                    TextUtils.ReleaseComObject(word);
                }
            }
        }

        private void btnKTCL_Click(object sender, EventArgs e)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo biểu mẫu bản vẽ mạch in"))
            {
                checkExistProduct();
                Word.Application word = new Word.Application();
                Word.Document doc = new Word.Document();
                try
                {
                    string localFilePath = @"D:\Thietke.Dt\PCB." + _productCodeDT.Substring(0, 1) + @"\PCB." + _productCodeDT + @"\PRD.PCB." + _productCodeDT + @"\";
                    string fileName = "KTCL.PCB." + _productCodeDT + ".docm";
                    try
                    {
                        File.Copy(_pPathDT + "KTCL.PCB.CODE.docm", (localFilePath + fileName), true);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Xin vui lòng chọn đúng mã thiết kế.", "Thông báo");
                        return;
                    }

                    doc = word.Documents.Open((localFilePath + fileName));
                    doc.Activate();
                    TextUtils.FindReplaceAnywhere(word, ".CODE", "." + _productCodeDT);
                    TextUtils.FindReplaceAnywhere(word, "<productname>", _productNameDT);

                    TextUtils.FindReplaceAnywhere(word, "<now>", DateTime.Now.ToString());
                    TextUtils.FindReplaceAnywhere(word, "<user>", Global.AppUserName);

                    TextUtils.FindReplaceAnywhere(word, "<day>", DateTime.Now.Day.ToString());
                    TextUtils.FindReplaceAnywhere(word, "<month>", DateTime.Now.Month.ToString());
                    TextUtils.FindReplaceAnywhere(word, "<year>", DateTime.Now.Year.ToString());

                    doc.Save();
                    doc.Close();
                    word.Quit();

                    //Process.Start(localFilePath + fileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    TextUtils.ReleaseComObject(doc);
                    TextUtils.ReleaseComObject(word);
                }
            }
        }

        private void btnLR_Click(object sender, EventArgs e)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo biểu mẫu bản vẽ mạch in"))
            {
                checkExistProduct();
                Word.Application word = new Word.Application();
                Word.Document doc = new Word.Document();
                try
                {
                    string localFilePath = @"D:\Thietke.Dt\PCB." + _productCodeDT.Substring(0, 1) + @"\PCB." + _productCodeDT + @"\PRD.PCB." + _productCodeDT + @"\";
                    string fileName = "LR.PCB." + _productCodeDT + ".docm";
                    try
                    {
                        File.Copy(_pPathDT + "LR.PCB.CODE.docm", (localFilePath + fileName), true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi khi copy file!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }


                    doc = word.Documents.Open((localFilePath + fileName));
                    doc.Activate();
                    TextUtils.FindReplaceAnywhere(word, ".CODE", "." + _productCodeDT);
                    TextUtils.FindReplaceAnywhere(word, "<productname>", _productNameDT);

                    TextUtils.FindReplaceAnywhere(word, "<user>", Global.AppUserName);

                    TextUtils.FindReplaceAnywhere(word, "<day>", DateTime.Now.Day.ToString());
                    TextUtils.FindReplaceAnywhere(word, "<month>", DateTime.Now.Month.ToString());
                    TextUtils.FindReplaceAnywhere(word, "<year>", DateTime.Now.Year.ToString());

                    doc.Save();
                    doc.Close();
                    word.Quit();

                    //Process.Start(localFilePath + fileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    TextUtils.ReleaseComObject(doc);
                    TextUtils.ReleaseComObject(word);
                }
            }
        }

        private void btnVT_Click(object sender, EventArgs e)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo hồ sơ thiết kế cơ khí!"))
            {
                string productName = "";
                string productCode = txtCode.Text.Trim().ToUpper();
                try
                {
                    productName = ((ModulesModel)ModulesBO.Instance.FindByAttribute("Code", productCode.Trim())[0]).Name;
                }
                catch (Exception)
                {
                    MessageBox.Show("Mã này không tồn tại!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                string pathProduct = @"D:\\Thietke.Dt\\PCB." + productCode.Substring(4, 1) + @"\\" + productCode + @"\\PRD." + productCode + "\\VT." + productCode + ".xlsm";

                Excel.Application objXLApp = default(Excel.Application);
                Excel.Workbook objXLWb = default(Excel.Workbook);
                Excel.Worksheet objXLWs = default(Excel.Worksheet);

                string path = @"D:\\Thietke.Dt\\PCB." + productCode.Substring(4, 1) + @"\\" + productCode + @"\\PRD." + productCode + "\\";
                string fileName = "VT." + productCode + ".xlsm";
                try
                {
                    //TextUtils.EndProcess("EXCEL");
                    try
                    {
                        File.Copy(_pPathDT + "\\VT.PCB.CODE.xlsm", (path + fileName), true); // Copy file hồ sơ thiết kế
                    }
                    catch
                    {
                        MessageBox.Show("Có lỗi khi copy file!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    //------------ Chỉnh sửa nội dung ------------
                    objXLApp = new Excel.Application();
                    objXLApp.Workbooks.Open(path + fileName);
                    objXLWb = objXLApp.Workbooks[1];
                    objXLWs = (Excel.Worksheet)objXLWb.Worksheets[1];

                    objXLWs.Cells[3, 3] = productName;
                    objXLApp.Cells[3, 10] = "Mã: " + productCode;
                    objXLApp.Cells[4, 3] = Global.AppFullName;
                    objXLApp.Cells[12, 1] = "Tân Phát,  ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;

                    objXLApp.ActiveWorkbook.Save();
                    objXLApp.Workbooks.Close();
                    objXLApp.Quit();

                    //Process.Start(path + fileName);
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
        }

        private void btnHSDT_Click(object sender, EventArgs e)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo biểu mẫu bản vẽ mạch in"))
            {
                checkExistProduct();
                Word.Application word = new Word.Application();
                Word.Document doc = new Word.Document();
                try
                {
                    string localFilePath = @"D:\Thietke.Dt\PCB." + _productCodeDT.Substring(0, 1) + @"\PCB." + _productCodeDT + @"\PRD.PCB." + _productCodeDT + @"\";
                    string fileName = "HS.PCB." + _productCodeDT + ".docm";
                    try
                    {
                        File.Copy(_pPathDT + "HS.PCB.CODE.docm", (localFilePath + fileName), true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi khi copy file!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    doc = word.Documents.Open((localFilePath + fileName));
                    TextUtils.FindReplaceAnywhere(word, ".CODE", "." + _productCodeDT);
                    TextUtils.FindReplaceAnywhere(word, "<productname>", _productNameDT);

                    TextUtils.FindReplaceAnywhere(word, "<user>", Global.AppFullName);

                    TextUtils.FindReplaceAnywhere(word, "<4M>", chkM4.Checked ? "Có" : "Không có");
                    TextUtils.FindReplaceAnywhere(word, "<4C>", chkC4.Checked ? "Có" : "Không có");
                    TextUtils.FindReplaceAnywhere(word, "<5M>", chkM5.Checked ? "Có" : "Không có");
                    TextUtils.FindReplaceAnywhere(word, "<5C>", chkC5.Checked ? "Có" : "Không có");
                    TextUtils.FindReplaceAnywhere(word, "<11B>", chk11B.Checked ? "Có" : "Không có");
                    TextUtils.FindReplaceAnywhere(word, "<12A>", chk12A.Checked ? "Có" : "Không có");
                    TextUtils.FindReplaceAnywhere(word, "<12B>", chk12B.Checked ? "Có" : "Không có");

                    TextUtils.FindReplaceAnywhere(word, "<day>", DateTime.Now.Day.ToString());
                    TextUtils.FindReplaceAnywhere(word, "<month>", DateTime.Now.Month.ToString());
                    TextUtils.FindReplaceAnywhere(word, "<year>", DateTime.Now.Year.ToString());

                    doc.Save();
                    doc.Close();
                    word.Quit();

                    Process.Start(localFilePath + fileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    TextUtils.ReleaseComObject(doc);
                    TextUtils.ReleaseComObject(word);
                }
            }
        }

        private void btnKTNL_Click(object sender, EventArgs e)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo biểu mẫu bản vẽ mạch in"))
            {
                checkExistProduct();
                Word.Application word = new Word.Application();
                Word.Document doc = new Word.Document();
                try
                {
                    string localFilePath = @"D:\Thietke.Dt\PCB." + _productCodeDT.Substring(0, 1) + @"\PCB." + _productCodeDT + @"\PRJ.PCB." + _productCodeDT + @"\";
                    string fileName = "KTNL.PCB." + _productCodeDT + ".docm";
                    try
                    {
                        File.Copy(_pPathDT + "KTNL.PCB.CODE.docm", (localFilePath + fileName), true);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Xin vui lòng chọn đúng mã thiết kế.", "Thông báo");
                        return;
                    }

                    doc = word.Documents.Open((localFilePath + fileName));
                    doc.Activate();
                    TextUtils.FindReplaceAnywhere(word, ".CODE", "." + _productCodeDT);
                    TextUtils.FindReplaceAnywhere(word, "<productname>", _productNameDT);

                    TextUtils.FindReplaceAnywhere(word, "<now>", DateTime.Now.ToString());
                    TextUtils.FindReplaceAnywhere(word, "<user>", Global.AppUserName);

                    TextUtils.FindReplaceAnywhere(word, "<day>", DateTime.Now.Day.ToString());
                    TextUtils.FindReplaceAnywhere(word, "<month>", DateTime.Now.Month.ToString());
                    TextUtils.FindReplaceAnywhere(word, "<year>", DateTime.Now.Year.ToString());

                    TextUtils.FindReplaceAnywhere(word, "<designer>", Global.AppFullName);
                    TextUtils.FindReplaceAnywhere(word, "<paint>", txtVe.Text.Trim());
                    TextUtils.FindReplaceAnywhere(word, "<check>", txtKiemTra.Text.Trim());
                    TextUtils.FindReplaceAnywhere(word, "<approve>", txtPheDuyet.Text.Trim());

                    TextUtils.FindReplaceAnywhere(word, "<ma>", cboMaterialMI.Text);

                    TextUtils.RepalaceText(doc, "<date>", DateTime.Now.ToString("dd/MM/yyyy"));

                    doc.Save();
                    doc.Close();
                    word.Quit();

                    //Process.Start(localFilePath + fileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    TextUtils.ReleaseComObject(doc);
                    TextUtils.ReleaseComObject(word);
                }
            }
        }

        private void btnTTNL_Click(object sender, EventArgs e)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo biểu mẫu bản vẽ mạch in"))
            {
                checkExistProduct();
                Word.Application word = new Word.Application();
                Word.Document doc = new Word.Document();
                try
                {
                    string localFilePath = @"D:\Thietke.Dt\PCB." + _productCodeDT.Substring(0, 1) + @"\PCB." + _productCodeDT + @"\PRJ.PCB." + _productCodeDT + @"\";
                    string fileName = "TTNL.PCB." + _productCodeDT + ".docm";
                    try
                    {
                        File.Copy(_pPathDT + "TTNL.PCB.CODE.docm", (localFilePath + fileName), true);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Xin vui lòng chọn đúng mã thiết kế.", "Thông báo");
                        return;
                    }


                    doc = word.Documents.Open((localFilePath + fileName));
                    doc.Activate();
                    TextUtils.FindReplaceAnywhere(word, ".CODE", "." + _productCodeDT);
                    TextUtils.FindReplaceAnywhere(word, "<productname>", _productNameDT);

                    TextUtils.FindReplaceAnywhere(word, "<now>", DateTime.Now.ToString());
                    TextUtils.FindReplaceAnywhere(word, "<user>", Global.AppUserName);

                    TextUtils.FindReplaceAnywhere(word, "<day>", DateTime.Now.Day.ToString());
                    TextUtils.FindReplaceAnywhere(word, "<month>", DateTime.Now.Month.ToString());
                    TextUtils.FindReplaceAnywhere(word, "<year>", DateTime.Now.Year.ToString());

                    doc.Save();
                    doc.Close();
                    word.Quit();

                    //Process.Start(localFilePath + fileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    TextUtils.ReleaseComObject(doc);
                    TextUtils.ReleaseComObject(word);
                }
            }
        }

        private void btnPATKC_Click(object sender, EventArgs e)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo biểu mẫu PATK-C.PCB.CODE"))
            {
                checkExistProduct();
                Word.Application word = new Word.Application();
                Word.Document doc = new Word.Document();
                try
                {
                    string localFilePath = @"D:\Thietke.Dt\PCB." + _productCodeDT.Substring(0, 1) + @"\PCB." + _productCodeDT + @"\PRJ.PCB." + _productCodeDT + @"\";
                    string fileName = "PATK-C.PCB." + _productCodeDT + ".docm";
                    try
                    {
                        File.Copy(_pPathDT + "PATK-C.PCB.CODE.docm", (localFilePath + fileName), true);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Xin vui lòng chọn đúng mã thiết kế.", "Thông báo");
                        return;
                    }

                    doc = word.Documents.Open((localFilePath + fileName));
                    doc.Activate();
                    TextUtils.FindReplaceAnywhere(word, ".CODE", "." + _productCodeDT);
                    TextUtils.FindReplaceAnywhere(word, "<productname>", _productNameDT);

                    TextUtils.FindReplaceAnywhere(word, "<now>", DateTime.Now.ToString());
                    TextUtils.FindReplaceAnywhere(word, "<user>", Global.AppUserName);

                    TextUtils.FindReplaceAnywhere(word, "<day>", DateTime.Now.Day.ToString());
                    TextUtils.FindReplaceAnywhere(word, "<month>", DateTime.Now.Month.ToString());
                    TextUtils.FindReplaceAnywhere(word, "<year>", DateTime.Now.Year.ToString());

                    doc.Save();
                    doc.Close();
                    word.Quit();

                    //Process.Start(localFilePath + fileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    TextUtils.ReleaseComObject(doc);
                    TextUtils.ReleaseComObject(word);
                }
            }
        }

        private void btnPATKCN_Click(object sender, EventArgs e)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "PATK-CN.PCB.CODE"))
            {
                checkExistProduct();
                Word.Application word = new Word.Application();
                Word.Document doc = new Word.Document();
                try
                {
                    string localFilePath = @"D:\Thietke.Dt\PCB." + _productCodeDT.Substring(0, 1) + @"\PCB." + _productCodeDT + @"\PRJ.PCB." + _productCodeDT + @"\";
                    string fileName = "PATK-CN.PCB." + _productCodeDT + ".docm";
                    try
                    {
                        File.Copy(_pPathDT + "PATK-CN.PCB.CODE.docm", (localFilePath + fileName), true);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Xin vui lòng chọn đúng mã thiết kế.", "Thông báo");
                        return;
                    }

                    doc = word.Documents.Open((localFilePath + fileName));
                    doc.Activate();
                    TextUtils.FindReplaceAnywhere(word, ".CODE", "." + _productCodeDT);
                    TextUtils.FindReplaceAnywhere(word, "<productname>", _productNameDT);

                    TextUtils.FindReplaceAnywhere(word, "<now>", DateTime.Now.ToString());
                    TextUtils.FindReplaceAnywhere(word, "<user>", Global.AppUserName);

                    TextUtils.FindReplaceAnywhere(word, "<day>", DateTime.Now.Day.ToString());
                    TextUtils.FindReplaceAnywhere(word, "<month>", DateTime.Now.Month.ToString());
                    TextUtils.FindReplaceAnywhere(word, "<year>", DateTime.Now.Year.ToString());

                    doc.Save();
                    doc.Close();
                    word.Quit();

                    //Process.Start(localFilePath + fileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    TextUtils.ReleaseComObject(doc);
                    TextUtils.ReleaseComObject(word);
                }
            }
        }

        private void btnPATKLK_Click(object sender, EventArgs e)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo biểu mẫu PATK-LK.PCB.CODE"))
            {
                checkExistProduct();
                Word.Application word = new Word.Application();
                Word.Document doc = new Word.Document();
                try
                {
                    string localFilePath = @"D:\Thietke.Dt\PCB." + _productCodeDT.Substring(0, 1) + @"\PCB." + _productCodeDT + @"\PRJ.PCB." + _productCodeDT + @"\";
                    string fileName = "PATK-LK.PCB." + _productCodeDT + ".docm";
                    try
                    {
                        File.Copy(_pPathDT + "PATK-LK.PCB.CODE.docm", (localFilePath + fileName), true);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Xin vui lòng chọn đúng mã thiết kế.", "Thông báo");
                        return;
                    }

                    doc = word.Documents.Open((localFilePath + fileName));
                    doc.Activate();
                    TextUtils.FindReplaceAnywhere(word, ".CODE", "." + _productCodeDT);
                    TextUtils.FindReplaceAnywhere(word, "<productname>", _productNameDT);

                    TextUtils.FindReplaceAnywhere(word, "<now>", DateTime.Now.ToString());
                    TextUtils.FindReplaceAnywhere(word, "<user>", Global.AppUserName);

                    TextUtils.FindReplaceAnywhere(word, "<day>", DateTime.Now.Day.ToString());
                    TextUtils.FindReplaceAnywhere(word, "<month>", DateTime.Now.Month.ToString());
                    TextUtils.FindReplaceAnywhere(word, "<year>", DateTime.Now.Year.ToString());

                    doc.Save();
                    doc.Close();
                    word.Quit();

                    //Process.Start(localFilePath + fileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    TextUtils.ReleaseComObject(doc);
                    TextUtils.ReleaseComObject(word);
                }
            }
        }

        private void frmHSTK_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.APPROVE = txtPheDuyet.Text.Trim();
            Settings.Default.CHECK = txtKiemTra.Text.Trim();
            Settings.Default.PAINT = txtVe.Text.Trim();
            Settings.Default.MATERIAL = cboMaterialMI.Text;
            Settings.Default.Save();
        }

        private void btnDesignSummary_Click(object sender, EventArgs e)
        {
            //frmDesignSummary frm = new frmDesignSummary();
            frmDesignSummaryManager frm = new frmDesignSummaryManager();
            TextUtils.OpenForm(frm);
        }

        private void btnPhacThaoThietKe_Click(object sender, EventArgs e)
        {
            if (txtModuleCode.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa điền mã module!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string moduleName = "";
            string moduleCode = txtModuleCode.Text.Trim().ToUpper();
            try
            {
                moduleName = ((ModulesModel)ModulesBO.Instance.FindByCode(moduleCode)).Name;
            }
            catch (Exception)
            {
                MessageBox.Show("Mã thiết kế này không tồn tại!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo phác thảo thiết kế!", new Size(), this))
            {
                string path = "D:\\Thietke.Ck\\" + moduleCode.Substring(0, 6) + "\\" + moduleCode + "\\DOC." + moduleCode;
                string filePathSource = _pPath + "\\PTTK.docm";
                string filePath = path + "\\PTTK." + moduleCode + ".docm";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                File.Copy(filePathSource, filePath, true);

                string groupCode = moduleCode.Substring(0, 6).ToLower();
                string groupName = ((ModuleGroupModel)ModuleGroupBO.Instance.FindByCode(groupCode)).Name.ToLower();
                string phucTrachChinh = txtPhuTrachChinh.Text.Trim().ToLower();
                string userName = Global.AppUserName.ToLower();
                string fileCongNghe = btnCongNghe.Text;
                string fileMat = btnMatModule.Text;
                string fileCum = btnCum.Text;

                string parametter = TextUtils.ConvertUnicode(groupName + "$" + groupCode + "$" + moduleName.ToLower() + "$" + moduleCode.ToLower()
                    + "$" + phucTrachChinh + "$" + userName, 0).ToUpper();
                parametter += "$" + btnCongNghe.Text + "$" + btnMatModule.Text + "$" + btnCum.Text;
                TextUtils.RunMacroInWord(filePath, "Macro1", parametter);

                Process.Start(filePath);
            }
        }

        private void btnCongNghe_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files (*.jpg)|*.jpg";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                btnCongNghe.Text = ofd.FileName;
            }
        }

        private void btnMatModule_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files (*.jpg)|*.jpg";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                btnMatModule.Text = ofd.FileName;
            }
        }

        private void btnCum_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files (*.jpg)|*.jpg";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                btnCum.Text = ofd.FileName;
            }
        }

        private void btnKTPA_Click(object sender, EventArgs e)
        {
            if (txtModuleCode.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa điền mã module!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string moduleName = "";
            string moduleCode = txtModuleCode.Text.Trim().ToUpper();
            try
            {
                moduleName = ((ModulesModel)ModulesBO.Instance.FindByCode(moduleCode)).Name;
            }
            catch (Exception)
            {
                MessageBox.Show("Mã thiết kế này không tồn tại!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo phác thảo thiết kế!", new Size(), this))
            {
                string path = "D:\\Thietke.Ck\\" + moduleCode.Substring(0, 6) + "\\" + moduleCode + "\\DOC." + moduleCode;
                string filePathSource = _pPath + "\\KTPA.docm";
                string filePath = path + "\\KTPA." + moduleCode + ".docm";

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                File.Copy(filePathSource, filePath, true);

                string groupCode = moduleCode.Substring(0, 6).ToLower();
                string groupName = ((ModuleGroupModel)ModuleGroupBO.Instance.FindByCode(groupCode)).Name.ToLower();
                //string phucTrachChinh = txtPhuTrachChinh.Text.Trim().ToLower();
                string userName = Global.AppUserName.ToLower();

                string parametter = TextUtils.ConvertUnicode(groupName + "$" + groupCode + "$" + moduleName.ToLower() + "$" + moduleCode.ToLower()
                    + "$" + userName, 0).ToUpper();
                TextUtils.RunMacroInWord(filePath, "Macro1", parametter);

                Process.Start(filePath);
            }
        }

        private void btnDuToanSB_Click(object sender, EventArgs e)
        {
            frmDuToanSoBo frm = new frmDuToanSoBo();
            TextUtils.OpenForm(frm);
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            btnBanVeMachIn_Click(null, null);
            btnKTNL_Click(null, null);
            btnTTNL_Click(null, null);
            btnKTCL_Click(null, null);
            btnLR_Click(null, null);
            btnVT_Click(null, null);
            btnPATKC_Click(null, null);
            btnPATKCN_Click(null, null);
            btnPATKLK_Click(null, null);
            MessageBox.Show("Tạo biểu mẫu thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmYeuCauCapVatTu frm = new frmYeuCauCapVatTu();
            TextUtils.OpenForm(frm);
        }

        void loadModule()
        {
            DataTable tbl = TextUtils.Select("select * from Modules with(nolock) where status = 2 order by Code");
            TextUtils.PopulateCombo(cboModule, tbl, "Name", "ID", "");
        }

        private void btnCreateHSDien_Click(object sender, EventArgs e)
        {
            int moduleId = TextUtils.ToInt(cboModule.EditValue);
            if (moduleId == 0) return;

            string moduleCode = TextUtils.ToString(grvModule.GetFocusedRowCellValue(colModuleCode));
            string moduleName = TextUtils.ToString(grvModule.GetFocusedRowCellValue(colModuleName));

            string localPath = string.Format(@"D:\Thietke.Dn\{0}\{1}.Dn\DAT.{2}", moduleCode.Substring(0, 6), moduleCode,
                moduleCode);

            if (!Directory.Exists(localPath))
            {
                MessageBox.Show("Không tồn tại cấu trúc thiết kế điện của module: " + moduleCode + " trên ổ D:");
                return;
            }

            string filePath = Application.StartupPath + "\\Templates\\PhongThietKe\\HSTK_D.xlsm";

            try
            {
                File.Copy(filePath, localPath + "\\HS." + moduleCode + ".Dn.xlsm", true);
            }
            catch
            {
                MessageBox.Show("Lỗi: File excel đang được mở.");
                return;
            }

            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo biểu mẫu..."))
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                Excel.Application app = default(Excel.Application);
                Excel.Workbook workBoook = default(Excel.Workbook);
                Excel.Worksheet workSheet = default(Excel.Worksheet);
                try
                {
                    app = new Excel.Application();
                    app.Workbooks.Open(localPath + "\\HS." + moduleCode + ".Dn.xlsm");
                    workBoook = app.Workbooks[1];
                    workSheet = (Excel.Worksheet)workBoook.Worksheets[1];

                    workSheet.Cells[5, 3] = moduleName;
                    workSheet.Cells[6, 3] = moduleCode;
                    workSheet.Cells[7, 3] = Global.AppFullName;

                    workSheet.Cells[9, 1] = "Tân Phát - " + DateTime.Now.Year;
                    workSheet.Cells[33, 3] = "Tân Phát, ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month +
                                             " năm " + DateTime.Now.Year;

                    workSheet.Cells[13, 3] = "DAT." + moduleCode;
                    workSheet.Cells[14, 3] = "BCD." + moduleCode + ".Dn.docm";
                    workSheet.Cells[15, 3] = "BKT." + moduleCode + ".Dn.xlsm";
                    workSheet.Cells[16, 3] = "BLT." + moduleCode + ".Dn.xlsm";
                    workSheet.Cells[17, 3] = "MTK." + moduleCode + ".Dn.xlsm";
                    workSheet.Cells[18, 3] = "HS." + moduleCode + ".Dn.xlsm";
                    workSheet.Cells[19, 3] = "PRJ." + moduleCode;
                    workSheet.Cells[20, 3] = moduleCode + ".Dn.zw1";
                    workSheet.Cells[21, 3] = "PRD." + moduleCode ;
                    workSheet.Cells[22, 3] = moduleCode+".Dn.pdf";
                    workSheet.Cells[23, 3] = "HMI." + moduleCode;
                    workSheet.Cells[24, 3] = "HMI." + moduleCode + ".rar";
                    workSheet.Cells[25, 3] = "PLC." + moduleCode;
                    workSheet.Cells[26, 3] = "PLC." + moduleCode + ".rar";

                   // workSheet.Cells[13, 4] = chk11.Checked ? "Có" : "Không có";
                    workSheet.Cells[14, 4] = chk11.Checked ? "Có" : "Không có";
                    workSheet.Cells[15, 4] = chk12.Checked ? "Có" : "Không có";
                    workSheet.Cells[16, 4] = chk13.Checked ? "Có" : "Không có";
                    workSheet.Cells[17, 4] = chk14.Checked ? "Có" : "Không có";
                    workSheet.Cells[18, 4] = chk15.Checked ? "Có" : "Không có";
                    //workSheet.Cells[19, 4] = chk11.Checked ? "Có" : "Không có";
                    workSheet.Cells[20, 4] = chk21.Checked ? "Có" : "Không có";
                    //workSheet.Cells[21, 4] = chk11.Checked ? "Có" : "Không có";
                    workSheet.Cells[22, 4] = chk31.Checked ? "Có" : "Không có";
                    //workSheet.Cells[23, 4] = chk11.Checked ? "Có" : "Không có";
                    workSheet.Cells[24, 4] = chk41.Checked ? "Có" : "Không có";
                    //workSheet.Cells[25, 4] = chk11.Checked ? "Có" : "Không có";
                    workSheet.Cells[26, 4] = chk51.Checked ? "Có" : "Không có";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (app != null)
                    {
                        app.ActiveWorkbook.Save();
                        app.Workbooks.Close();
                        app.Quit();
                    }
                }

                if (File.Exists(localPath + "\\HS." + moduleCode + ".Dn.xlsm")) 
                    Process.Start(localPath + "\\HS." + moduleCode + ".Dn.xlsm");
            }
        }
    }
}
