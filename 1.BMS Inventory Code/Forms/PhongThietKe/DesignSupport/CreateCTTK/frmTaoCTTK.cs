using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BMS.Business;
using BMS.Utils;
using System.Collections;
using BMS.Model;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using DevExpress.Utils;

namespace BMS
{
    public partial class frmTaoCTTK : _Forms
    {
        string _bieuMauPath = @"\\SERVER\Company\VAN BAN HIEN HANH\THU TUC-HUONG DAN\TT 13 Thu tuc kiem soat thiet ke";
        #region Variables
        int _type;
        string _initPath;
        string _duongDanChinh; 
        #endregion

        #region Constructor
        public frmTaoCTTK()
        {
            InitializeComponent();
        }
        private void frmTaoDuongDan_Load(object sender, EventArgs e)
        {
            cboParent.SelectedIndex = 0;
        } 
        #endregion   
        
        #region Method

        private bool validateForm()
        {
            string model=txtModel.Text.Trim().ToUpper();
            if (model == "")
            {
                MessageBox.Show("Xin hãy điền Mã đầy đủ của thiết kế.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
            {              

                if (cboParent.SelectedIndex == 0 || cboParent.SelectedIndex == 1)
                {
                    //if (!model.StartsWith("TPAD"))
                    //{
                    //    MessageBox.Show("Mã không đúng định dạng!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    //    return false;
                    //}
                    if (model.Length != 5)
                    {
                        MessageBox.Show("Mã không đúng định dạng!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }
                    int number = TextUtils.ToInt(model.Substring(1, 4));
                    if (number == 0)
                    {
                        MessageBox.Show("Mã không đúng định dạng!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }
                }

                if (cboParent.SelectedIndex == 2)
                {
                    //if (!model.StartsWith("PCB"))
                    //{
                    //    MessageBox.Show("Mã không đúng định dạng!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    //    return false;
                    //}
                    if (model.Length != 7)
                    {
                        MessageBox.Show("Mã không đúng định dạng!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }
                    int number = TextUtils.ToInt(model.Substring(1, 6));
                    if (number == 0)
                    {
                        MessageBox.Show("Mã không đúng định dạng!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }
                }
            }
          
            return true;
        }

        private void taoDuongDan()
        {
            try
            {
                if (!validateForm()) return;
                string productCode = txtModel.Text.ToUpper();
                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo cây thư mục..."))
                {
                    if (Directory.Exists(@"D:\"))
                    {
                        if (cboParent.SelectedIndex == 0)//cơ khí
                        {
                            _initPath = "D:\\Thietke.Ck\\TPAD." + productCode.ToUpper().Substring(0, 1);
                        }
                        if (cboParent.SelectedIndex == 1)//điện
                        {
                            _initPath = "D:\\Thietke.Dn\\TPAD." + productCode.ToUpper().Substring(0, 1);
                        }
                        if (cboParent.SelectedIndex == 2)//điện tử
                        {
                            _initPath = "D:\\Thietke.Dt\\PCB." + productCode.ToUpper().Substring(0, 1);
                        }
                    }
                    else
                    {
                        if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                        {
                            _initPath = folderBrowserDialog1.SelectedPath;
                        }
                        else
                            return;
                    }

                    ArrayList list = DesignStructureBO.Instance.FindByAttribute("Type", cboParent.SelectedIndex);

                    for (int i = 0; i < list.Count; i++)
                    {
                        DesignStructureModel model = (DesignStructureModel)list[i];
                        string directtion = "";
                        if (model.Path.Contains("code"))
                        {
                            if (cboParent.SelectedIndex == 0 || cboParent.SelectedIndex == 1)//cơ khí
                            {
                                directtion = (_initPath + @"\" + model.Path).Replace("code", "TPAD." + productCode);
                            }
                            if (cboParent.SelectedIndex == 2)//điện tử
                            {
                                directtion = (_initPath + @"\" + model.Path).Replace("code", productCode);
                            }
                        }
                        else
                            directtion = (_initPath + @"\" + model.Path);
                        if (i == 0)
                        {
                            _duongDanChinh = directtion;
                        }
                        Directory.CreateDirectory(directtion);
                    }
                    if (cboParent.SelectedIndex == 0)//cơ khí
                    {
                        ModulesModel module = (ModulesModel)ModulesBO.Instance.FindByAttribute("Code", "TPAD." + productCode.ToUpper())[0];

                        #region Danh muc vat tu
                        try
                        {
                           // File.Copy(_bieuMauPath + "\\TP-TT13-BM04 - Danh muc vat tu.xlsm",
                           //_duongDanChinh + "\\VT.TPAD." + productCode + ".xlsm");

                            File.Copy(Application.StartupPath + "\\Templates\\PhongThietKe\\VT.Code.xlsm",
                           _duongDanChinh + "\\VT.TPAD." + productCode + ".xlsm",true);

                            Excel.Application objXLApp = default(Excel.Application);
                            Excel.Workbook objXLWb = default(Excel.Workbook);
                            Excel.Worksheet objXLWs = default(Excel.Worksheet);

                            try
                            {
                                objXLApp = new Excel.Application();
                                objXLApp.Workbooks.Open(_duongDanChinh + "\\VT.TPAD." + productCode + ".xlsm");
                                objXLWb = objXLApp.Workbooks[1];
                                objXLWs = (Excel.Worksheet)objXLWb.Worksheets[1];

                                objXLWs.Cells[4, 3] = Global.AppUserName.ToUpper();
                                objXLApp.Cells[3, 3] = module.Name.ToUpper();
                                objXLApp.Cells[3, 10] = "Mã: TPAD." + productCode.ToUpper();
                            }
                            catch
                            {
                            }
                            finally
                            {
                                objXLApp.ActiveWorkbook.Save();
                                objXLApp.Workbooks.Close();
                                objXLApp.Quit();
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Không tạo được danh mục vật tư do module [TPAD." + productCode.ToUpper() + "] chưa có trên nguồn", 
                                TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        #endregion

                        #region Thư mục Doc
                        string moduleCode = "TPAD." + productCode;
                        string toFolder = string.Format(@"D:\Thietke.Ck\{0}\{1}.Ck\DOC.{1}\", moduleCode.Substring(0, 6), moduleCode);
                        string fromFolder = Application.StartupPath + "/Templates/PhongThietKe/DOC.TPAD.XYYYY";
                        string[] listFile = Directory.GetFiles(fromFolder);
                        foreach (string filePath in listFile)
                        {
                            string fileName = Path.GetFileNameWithoutExtension(filePath);
                            string extension = Path.GetExtension(filePath);
                            try
                            {
                                File.Copy(filePath, toFolder + fileName + moduleCode + extension, true);
                            }
                            catch
                            {
                            }
                        }                        
                        #endregion

                        #region Bảng kiểm tra phương án
                        string path = "D:\\Thietke.Ck\\" + moduleCode.Substring(0, 6) + "\\" + moduleCode + ".Ck\\DOC." + moduleCode;
                        string filePathSource = Application.StartupPath + "\\Templates\\KTPA.docm";
                        string filePathKTPA = path + "\\KTPA." + moduleCode + ".docm";

                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }

                        File.Copy(filePathSource, filePathKTPA, true);

                        string groupCode = moduleCode.Substring(0, 6).ToLower();
                        string groupName = ((ModuleGroupModel)ModuleGroupBO.Instance.FindByCode(groupCode)).Name.ToLower();
                        string userName = Global.AppUserName.ToLower();

                        string parametter = TextUtils.ConvertUnicode(groupName + "$" + groupCode + "$" + module.Name.ToLower() + "$" + moduleCode.ToLower()
                            + "$" + userName, 0).ToUpper();
                        TextUtils.RunMacroInWord(filePathKTPA, "Macro1", parametter);
                        #endregion
                    }
                    //if (cboParent.SelectedIndex == 1)
                    //{
                       // ModulesModel module = (ModulesModel)ModulesBO.Instance.FindByAttribute("Code", "TPAD." + productCode.ToUpper())[0];

                        #region Hang muc TK
                        //try
                        //{
                        //    File.Copy(_bieuMauPath + "\\TP-TT13-BM38 - Hang muc TK.xlsm",
                        //   _duongDanChinh + "\\DAT.TPAD." + productCode + "\\MTK.TPAD." + productCode + ".Dn.xlsm");

                        //    Excel.Application objXLApp = default(Excel.Application);
                        //    Excel.Workbook objXLWb = default(Excel.Workbook);
                        //    Excel.Worksheet objXLWs = default(Excel.Worksheet);

                        //    try
                        //    {
                        //        objXLApp = new Excel.Application();
                        //        objXLApp.Workbooks.Open(_duongDanChinh + "\\DAT.TPAD." + productCode + "\\MTK.TPAD." + productCode + ".Dn.xlsm");
                        //        objXLWb = objXLApp.Workbooks[1];
                        //        objXLWs = (Excel.Worksheet)objXLWb.Worksheets[1];

                        //        objXLWs.Cells[9, 3] = module.Name.ToUpper();
                        //        objXLWs.Cells[9, 4] = "Mã: " + module.Code.ToUpper();
                        //        objXLApp.Cells[10, 3] = Global.AppFullName;
                        //    }
                        //    catch
                        //    {
                        //    }
                        //    finally
                        //    {
                        //        objXLApp.ActiveWorkbook.Save();
                        //        objXLApp.Workbooks.Close();
                        //        objXLApp.Quit();
                        //    }
                        //}
                        //catch (Exception)
                        //{
                        //}
                        #endregion

                        #region Bang kiem tra nguyen ly
                        //try
                        //{
                        //    File.Copy(_bieuMauPath + "\\TP-TT13-BM31 - Bang kiem tra nguyen ly.xlsm",
                        //   _duongDanChinh + "\\DAT.TPAD." + productCode + "\\BKT.TPAD." + productCode + ".Dn.xlsm");

                        //    Excel.Application objXLApp = default(Excel.Application);
                        //    Excel.Workbook objXLWb = default(Excel.Workbook);
                        //    Excel.Worksheet objXLWs = default(Excel.Worksheet);

                        //    try
                        //    {
                        //        objXLApp = new Excel.Application();
                        //        objXLApp.Workbooks.Open(_duongDanChinh + "\\DAT.TPAD." + productCode + "\\BKT.TPAD." + productCode + ".Dn.xlsm");
                        //        objXLWb = objXLApp.Workbooks[1];
                        //        objXLWs = (Excel.Worksheet)objXLWb.Worksheets[1];

                        //        objXLWs.Cells[9, 4] = module.Name.ToUpper();
                        //        objXLWs.Cells[9, 9] = module.Code.ToUpper();
                        //        objXLApp.Cells[10, 4] = Global.AppFullName;
                        //    }
                        //    catch
                        //    {
                        //    }
                        //    finally
                        //    {
                        //        objXLApp.ActiveWorkbook.Save();
                        //        objXLApp.Workbooks.Close();
                        //        objXLApp.Quit();
                        //    }
                        //}
                        //catch (Exception)
                        //{
                        //}
                        #endregion

                        #region Bang du lieu lap trinh
                        //try
                        //{
                        //    File.Copy(_bieuMauPath + "\\TP-TT13-BM32 - Bang du lieu lap trinh.xlsm",
                        //   _duongDanChinh + "\\DAT.TPAD." + productCode + "\\BLT.TPAD." + productCode + ".Dn.xlsm");

                        //    Excel.Application objXLApp = default(Excel.Application);
                        //    Excel.Workbook objXLWb = default(Excel.Workbook);
                        //    Excel.Worksheet objXLWs = default(Excel.Worksheet);

                        //    try
                        //    {
                        //        objXLApp = new Excel.Application();
                        //        objXLApp.Workbooks.Open(_duongDanChinh + "\\DAT.TPAD." + productCode + "\\BLT.TPAD." + productCode + ".Dn.xlsm");
                        //        objXLWb = objXLApp.Workbooks[1];
                        //        objXLWs = (Excel.Worksheet)objXLWb.Worksheets[1];

                        //        objXLWs.Cells[8, 4] = module.Name.ToUpper();
                        //        objXLWs.Cells[8, 8] = "Mã: " + module.Code.ToUpper();
                        //        objXLApp.Cells[9, 4] = Global.AppFullName;
                        //    }
                        //    catch
                        //    {
                        //    }
                        //    finally
                        //    {
                        //        objXLApp.ActiveWorkbook.Save();
                        //        objXLApp.Workbooks.Close();
                        //        objXLApp.Quit();
                        //    }
                        //}
                        //catch (Exception)
                        //{
                        //}
                        #endregion

                        #region Du lieu cai dat
                        //try
                        //{
                        //    File.Copy(_bieuMauPath + "\\TP-TT13-BM34 - Du lieu cai dat.docm",
                        //   _duongDanChinh + "\\DAT.TPAD." + productCode + "\\BCD.TPAD." + productCode + ".Dn.docm");
                        //}
                        //catch (Exception)
                        //{
                        //}
                        #endregion
                    //}
                }
                MessageBox.Show("Tạo cấu trúc thiết kế thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start(_duongDanChinh);
            }
            catch (System.Exception ex)
            {
                TextUtils.ShowError(ex);
            }
        }
        #endregion

        #region Events
        private void bCreate_Click(object sender, EventArgs e)
        {
            taoDuongDan();
        }

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmConfigDirectories frm = new frmConfigDirectories();
            frm.ShowDialog();
        }

        private void txtModel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                taoDuongDan();
            }
        }

        private void btnCreateFromDMVT_Click(object sender, EventArgs e)
        {
            frmCreateIPT frm = new frmCreateIPT();
            TextUtils.OpenForm(frm);
        }
    }
}