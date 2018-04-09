using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DevExpress.Utils;
using Excel = Microsoft.Office.Interop.Excel;

namespace BMS
{
    public partial class frmConvertModule : _Forms
    {
        string _modulePath = "";
        string _newModuleCode = "";
        string _oldModuleCode = "";
        string _newModuleName = "";

        public frmConvertModule()
        {
            InitializeComponent();
        }

        void rename(string initPath)
        {
            string folderName = Path.GetFileName(initPath);
           
            string[] listInitFile = Directory.GetFiles(initPath, "*" + _oldModuleCode + "*", SearchOption.TopDirectoryOnly);
            foreach (string filePath in listInitFile)
            {
                string fileName = Path.GetFileName(filePath);
                if (folderName.StartsWith("DOC.") && Path.GetExtension(filePath) == ".xlsm")
                {
                    Excel.Application objXLApp = default(Excel.Application);
                    Excel.Workbook objXLWb = default(Excel.Workbook);
                    Excel.Worksheet objXLWs = default(Excel.Worksheet);
                    try
                    {
                        objXLApp = new Excel.Application();
                        objXLApp.Workbooks.Open(filePath);
                        objXLWb = objXLApp.Workbooks[1];
                        objXLWs = (Excel.Worksheet)objXLWb.Worksheets[1];

                        if (fileName.StartsWith("DMVTC."))
                        {
                            objXLWs.Cells[3, 3] = _newModuleName;
                            objXLWs.Cells[3, 10] = "Mã: " + _newModuleCode;
                            //objXLWs.Cells[4, 3] = Global.AppUserName.ToUpper();
                            objXLWs.PageSetup.LeftHeader = _newModuleName;
                        }

                        if (fileName.StartsWith("DTSB."))
                        {
                            objXLWs.Cells[3, 3] = _newModuleName;
                            objXLWs.Cells[3, 11] = _newModuleCode;
                            //objXLWs.Cells[4, 3] = Global.AppUserName.ToUpper();
                            objXLWs.PageSetup.LeftHeader = _newModuleName;
                        }

                        if (fileName.StartsWith("HS."))
                        {
                            objXLWs.Cells[5, 3] = _newModuleName;
                            objXLWs.Cells[6, 3] = _newModuleCode;
                            //objXLWs.Cells[7, 3] = Global.AppUserName.ToUpper();
                            objXLWs.PageSetup.LeftHeader = _newModuleCode + " - " + _newModuleName;
                        }

                        if (fileName.StartsWith("KCS."))
                        {
                            objXLWs.Cells[3, 3] = _newModuleName;
                            objXLWs.Cells[3, 7] = _newModuleCode;
                            //objXLWs.Cells[4, 3] = Global.AppUserName.ToUpper(); 
                            objXLWs.PageSetup.LeftHeader = _newModuleName;
                        }

                        if (fileName.StartsWith("KTVC."))
                        {
                            objXLWs.Cells[4, 3] = _newModuleName;
                            objXLWs.Cells[4, 8] = _newModuleCode;
                            //objXLWs.Cells[5, 3] = Global.AppUserName.ToUpper();
                            objXLWs.PageSetup.LeftHeader = _newModuleName;
                        }

                        if (fileName.StartsWith("XNVT."))
                        {
                            objXLWs.Cells[3, 3] = _newModuleName;
                            objXLWs.Cells[3, 10] = "Mã: " + _newModuleCode;
                            //objXLWs.Cells[4, 3] = Global.AppUserName.ToUpper();
                            objXLWs.PageSetup.LeftHeader = _newModuleName;
                        }
                    }
                    catch (Exception)
                    {
                    }
                    finally
                    {
                        objXLApp.ActiveWorkbook.Save();
                        objXLApp.Workbooks.Close();
                        objXLApp.Quit();
                    }                       
                }

                if (Path.GetExtension(filePath) == ".xlsm")
                {
                    TextUtils.ExcelFindAndReplace(filePath, _oldModuleCode, _newModuleCode);
                }

                TextUtils.RenameFileVB(filePath, Path.GetFileName(filePath).Replace(_oldModuleCode, _newModuleCode));
            }

            string[] listInitFolder = Directory.GetDirectories(initPath, "*" + _oldModuleCode + "*", SearchOption.TopDirectoryOnly);
            foreach (string folderPath in listInitFolder)
            {                
                rename(folderPath);                
            }
           
            TextUtils.RenameFolderVB(initPath, Path.GetFileName(initPath).Replace(_oldModuleCode, _newModuleCode));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _newModuleCode = txtNewModule.Text.ToUpper();
            _oldModuleCode = txtOldModule.Text.ToUpper();

            //Kiểm tra lỗi trong module con
            string moduleCode = _oldModuleCode;
            DataTable dtError = TextUtils.Select(
                string.Format("select * from [vModuleError] where [ModuleCode]='{0}' and Status = 0 and ConfirmTemp = 0", moduleCode));
            DataTable dtKPH = TextUtils.Select(
                string.Format("select * from [vMisMatch] where [ModuleCode]='{0}' StatusKCS = 0 and ConfirmTemp = 0", moduleCode));
            if (dtError.Rows.Count > 0 || dtKPH.Rows.Count > 0)
            {
                string errorString = "Có " + dtError.Rows.Count + " lỗi và " + dtKPH.Rows.Count + " sự không phù hợp";
                MessageBox.Show(errorString,TextUtils.Caption,MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang đổi mã thiết kế"))
            {                
                string desPath = @"D:\DOIMA\Thietke.Ck\" + _newModuleCode.Substring(0, 6) + "/" + _newModuleCode.ToUpper() + ".Ck";
                if (Directory.Exists(desPath))
                {
                    MessageBox.Show("Thiết kế mới đã tồn tại trong ổ D", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Directory.CreateDirectory(desPath);

                TextUtils.CopyFolderVB(_modulePath, desPath);
                TextUtils.DeleteFolderVB(desPath + "/3D." + _oldModuleCode);

                rename(desPath);
            }
            MessageBox.Show("Đã chuyển mã thành công!");
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = @"D:\Thietke.Ck\TPAD.D";
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                _modulePath = fbd.SelectedPath;
                txtOldModule.Text = Path.GetFileNameWithoutExtension(_modulePath);

                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang lấy mã mới"))
                {
                    string tableCodeFilePath = @"\\server\data2\Thietke\ISO\ISO.Thietke\TAI LIEU DAO TAO\TAI LIEU HO TRO PHONG THIET KE\TK09- Huong dan doi ma san pham TK\TK09-BM01 - Bang thay doi ma TK.xlsx";
                    List<string> listSheet = TextUtils.ListSheetInExcel(tableCodeFilePath);
                    foreach (string sheetName in listSheet)
                    {
                        DataTable dt = TextUtils.ExcelToDatatableNoHeader(tableCodeFilePath, sheetName);
                        try
                        {
                            DataRow[] drs = dt.Select("F4 = '" + txtOldModule.Text + "'");
                            if (drs.Length > 0)
                            {
                                string oldName = drs[0]["F5"] == null ? "" : drs[0]["F5"].ToString();
                                string newName = drs[0]["F6"] == null ? "" : drs[0]["F6"].ToString();
                                _newModuleName = newName == "" ? oldName : newName;
                                txtNewModule.Text = drs[0]["F3"].ToString();
                                break;
                            }
                        }
                        catch (Exception)
                        {                            
                        }
                    }
                }
            }
        }
    }
}
