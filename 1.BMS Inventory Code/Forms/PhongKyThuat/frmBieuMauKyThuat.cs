using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using System.Diagnostics;

namespace BMS
{
    public partial class frmBieuMauKyThuat : _Forms
    {
        public frmBieuMauKyThuat()
        {
            InitializeComponent();
        }

        private void frmBieuMauKyThuat_Load(object sender, EventArgs e)
        {
            //this.Width
            loadVersion();
            loadModule();
        }

        void loadVersion()
        {
            List<int> version = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                version.Add(i);
            }
            cboVersion.DataSource = version;
            cboVersion.SelectedIndex = 0;
        }

        void loadModule()
        {
            DataTable dt = TextUtils.Select("select * from Modules with(nolock) where Status = 2 and Code like 'TPAD.%' order by Code");
            cboModule.Properties.DataSource = dt;
            cboModule.Properties.DisplayMember = "Name";
            cboModule.Properties.ValueMember = "Code";
        }

        private void btnHuongDanSuDung_Click(object sender, EventArgs e)
        {
            if (cboModule.EditValue == null)
            {
                return;
            }
            if (cboVersion.SelectedIndex < 0)
            {
                return;
            }

            string localPath = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                localPath = fbd.SelectedPath;
            }
            else
            {
                return;
            }

            string code = TextUtils.ToString(cboModule.EditValue).Substring(5, 5);
            string name = TextUtils.ToString(grvCboModule.GetFocusedRowCellValue(colModuleName)).ToUpper();
            string version = string.Format("{0:00}", (int)cboVersion.SelectedValue);
            string _pPathDT = Application.StartupPath + "\\Templates\\PhongKyThuat\\";

            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo biểu mẫu"))
            {
                Word.Application word = new Word.Application();
                Word.Document doc = new Word.Document();
                try
                {
                    string fileName = "D0." + version + "." + code + ".docx";
                    try
                    {
                        File.Copy(_pPathDT + "HDSD.docx", (localPath + "\\" + fileName), true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        doc.Close();
                        word.Quit();
                        return;
                    }


                    doc = word.Documents.Open(localPath + "\\" + fileName);
                    doc.Activate();

                    TextUtils.FindReplaceAnywhere(word, "<code>", Path.GetFileNameWithoutExtension(fileName));
                    TextUtils.FindReplaceAnywhere(word, "<name>", name);
                    //TextUtils.FindReplaceAnywhere(word, "<thongso>", TextUtils.ToString(grvCboModule.GetFocusedRowCellValue(colSpecifications)));
                    //TextUtils.RepalaceText(doc, "<thongso>", TextUtils.ToString(grvCboModule.GetFocusedRowCellValue(colSpecifications)));
                    doc.Save();

                    Process.Start(localPath + "\\" + fileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    doc.Close();
                    word.Quit();
                    TextUtils.ReleaseComObject(doc);
                    TextUtils.ReleaseComObject(word);
                }
            }
        }

        private void cboModule_EditValueChanged(object sender, EventArgs e)
        {
            if (cboModule.EditValue != null)
            {
                txtTSKT.Text = TextUtils.ToString(grvCboModule.GetFocusedRowCellValue(colSpecifications)).Replace("\n", "\r\n");
            }
        }

        private void btnHDTH_Click(object sender, EventArgs e)
        {
            if (txtCode.Text.Trim() == "" || txtName.Text.Trim() == "")
            {
                return;
            }

            string localPath = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                localPath = fbd.SelectedPath;
            }
            else
            {
                return;
            }

            string code = txtCode.Text.Trim();
            string name = txtName.Text.Trim().ToUpper();
            //string version = string.Format("{0:00}", (int)cboVersion.SelectedValue);
            string _pPathDT = Application.StartupPath + "\\Templates\\PhongKyThuat\\";

            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo biểu mẫu"))
            {
                Word.Application word = new Word.Application();
                Word.Document doc = new Word.Document();
                try
                {
                    string fileName = code + ".docx";
                    try
                    {
                        File.Copy(_pPathDT + "HDTH.docx", (localPath + "\\" + fileName), true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        doc.Close();
                        word.Quit();
                        return;
                    }


                    doc = word.Documents.Open(localPath + "\\" + fileName);
                    doc.Activate();

                    TextUtils.FindReplaceAnywhere(word, "<code>", Path.GetFileNameWithoutExtension(fileName));
                    TextUtils.FindReplaceAnywhere(word, "<name>", name);
                    //TextUtils.FindReplaceAnywhere(word, "<thongso>", TextUtils.ToString(grvCboModule.GetFocusedRowCellValue(colSpecifications)));
                    //TextUtils.RepalaceText(doc, "<thongso>", TextUtils.ToString(grvCboModule.GetFocusedRowCellValue(colSpecifications)));
                    doc.Save();

                    Process.Start(localPath + "\\" + fileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    doc.Close();
                    word.Quit();
                    TextUtils.ReleaseComObject(doc);
                    TextUtils.ReleaseComObject(word);
                }
            }

        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string filePath = @"\\SERVER\Company\Share\Chuyen giao\HDTH.xlsx";
                DataTable dt = TextUtils.ExcelToDatatableNoHeader(filePath, "EX");
                DataRow[] drs = dt.Select("F3 = '" + txtCode.Text.Trim() + "'");
                if (drs.Length > 0)
                {
                    txtName.Text = TextUtils.ToString(drs[0]["F2"]).ToUpper();
                }
            }
        }

        private void btnCreateTHTL_Click(object sender, EventArgs e)
        {
            if (txtFilePathTHTK.Text.Trim() == "") return;
            DataTable dt = TextUtils.ExcelToDatatableNoHeader(txtFilePathTHTK.Text.Trim(), "3");

            string khCuoi = TextUtils.ToString(dt.Rows[2]["F1"]);
            string duAn = TextUtils.ToString(dt.Rows[2]["F8"]);
            string HangMuc = TextUtils.ToString(dt.Rows[5]["F12"]);
            string spHD = TextUtils.ToString(dt.Rows[5]["F1"]);
            string maSPHD = TextUtils.ToString(dt.Rows[5]["F8"]);

            //DataRow[] drs = dt.Select("F5 like 'TPAD.%' and F13 not like 'VTP%'");
            DataRow[] drs = dt.Select("F5 like 'TPAD.%' and (F13 <> 'VTP' or F13 is null)");

            string localPath = "";

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                localPath = fbd.SelectedPath + "\\THTL - Muc " + HangMuc.Replace(":", "") + " - " + duAn + ".xlsm";
            }
            else
            {
                return;
            }

            string filePath = Application.StartupPath + "\\Templates\\PhongKyThuat\\THTL.xlsm";

            try
            {
                File.Copy(filePath, localPath, true);
            }
            catch (Exception ex)
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
                    app.Workbooks.Open(localPath);
                    workBoook = app.Workbooks[1];
                    workSheet = (Excel.Worksheet)workBoook.Worksheets[1];

                    workSheet.Cells[4, 1] = khCuoi;
                    workSheet.Cells[4, 5] = "Dự án: " + duAn;
                    workSheet.Cells[4, 6] = HangMuc;

                    workSheet.Cells[5, 1] = spHD;
                    workSheet.Cells[5, 5] = maSPHD;

                    workSheet.Cells[19, 6] = "Hà Nội, Ngày " + string.Format("{0:00}", DateTime.Now.Day)
                            + " tháng " + string.Format("{0:00}", DateTime.Now.Month)
                            + " năm " + DateTime.Now.Year;

                    for (int i = drs.Length-1; i >= 0; i--)
                    {
                        ((Excel.Range)workSheet.Rows[10]).Insert();

                        string code = TextUtils.ToString(drs[i]["F5"]);

                        workSheet.Cells[10, 1] = i + 1;
                        workSheet.Cells[10, 2] = TextUtils.ToString(drs[i]["F2"]).ToUpper();
                        workSheet.Cells[10, 3] = TextUtils.ToString(drs[i]["F3"]).ToUpper();
                        workSheet.Cells[10, 4] = TextUtils.ToString(drs[i]["F4"]).ToUpper();
                        workSheet.Cells[10, 5] = code.ToUpper();
                        workSheet.Cells[10, 6] = "D0.00." + code.Substring(5, 5).ToUpper();
                        workSheet.Cells[10, 7] = TextUtils.ToString(drs[i]["F13"]);
                        //workSheet.Cells[10, 7] = TextUtils.ToString(drs[i][""]);
                    }
                    ((Excel.Range)workSheet.Rows[9]).Delete();
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
            }
            Process.Start(localPath);
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFilePathTHTK.Text = ofd.FileName;
            }
        }
    }
}
