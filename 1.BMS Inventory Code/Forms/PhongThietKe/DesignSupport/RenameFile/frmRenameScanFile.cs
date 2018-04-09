using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using Barcode;
using System.IO;
using PdfToImage;
using BMS.Model;
using BMS.Business;
using DevExpress.Utils;
using System.Collections;

namespace BMS
{
    public partial class frmRenameScanFile : _Forms
    {
        string _productCode = "";
        //string _filePath = "";
        string _folderScan = "D:\\Scan";
        DataTable _dtWillRename = new DataTable();
        DataTable _dtFileRenamed = new DataTable();
        int _id = 1;
        string _pathTKC = "";

        #region Constructors and Load
        public frmRenameScanFile()
        {
            InitializeComponent();
        }

        private void frmRenameScanFile_Load(object sender, EventArgs e)
        {
            _dtWillRename.Columns.Add("FileName");            
            _dtWillRename.Columns.Add("FilePath");

            _dtFileRenamed.Columns.Add("FileName");
            _dtFileRenamed.Columns.Add("ParentID", typeof(int));
            _dtFileRenamed.Columns.Add("ID", typeof(int));
            _dtFileRenamed.Columns.Add("FilePath");
            //dtFileRenamed.Columns.Add("FilePath");

            loadFileWillRename();
        }
        #endregion Constructors and Load

        #region Methods
        void loadFileWillRename()
        {
            _dtWillRename.Rows.Clear();
            if (!Directory.Exists(_folderScan))
            {
                Directory.CreateDirectory(_folderScan);
            }
            string[] listFiles = Directory.GetFiles(_folderScan);
            if (listFiles.Count()>0)
            {
                for (int i = 0; i < listFiles.Count(); i++)
                {
                    _dtWillRename.Rows.Add(Path.GetFileName(listFiles[i]), listFiles[i]);
                }
            }
            grdScan.DataSource = null;
            grdScan.DataSource = _dtWillRename;            
        }
        
        DataTable getAllFolderNormal(string initPath, int parent)
        {
            string[] listInitPath = Directory.GetDirectories(initPath);
            int count = 0;
            try
            {
                count = listInitPath.Length;
            }
            catch { }

            if (count <= 0) return new DataTable();

            foreach (string item in listInitPath)
            {
                int countFolder = 0;
                int countFile = 0;
                try
                {
                    countFolder = Directory.GetDirectories(initPath + "/" + Path.GetFileName(item)).Length;
                }
                catch (Exception)
                {
                }
                try
                {
                    countFile = Directory.GetFiles(initPath + "/" + Path.GetFileName(item)).Length;
                }
                catch (Exception)
                {
                }

                DataRow row = _dtFileRenamed.NewRow();
                row[0] = Path.GetFileName(item);               
                row[1] = parent;
                row[2] = _id;
                row[3] = item;
                _dtFileRenamed.Rows.Add(row);
                _id++;
                if (countFolder > 0)
                {
                    getAllFolderNormal(initPath + "/" + Path.GetFileName(item), Convert.ToInt16(row[4]));
                }
            }
            return _dtFileRenamed;
        }

        void loadFileRenamed()
        {
            _dtFileRenamed.Rows.Clear();

            getAllFolderNormal(_pathTKC, 0);

            for (int i = 0; i < _dtFileRenamed.Rows.Count; i++)
            {
                string[] listFiles = null;
                try
                {
                    listFiles = Directory.GetFiles(_dtFileRenamed.Rows[i][3].ToString());
                }
                catch (Exception)
                {
                    continue;
                }
                foreach (string item in listFiles)
                {
                    DataRow row1 = _dtFileRenamed.NewRow();
                    row1[0] = Path.GetFileName(item);
                    row1[1] = _dtFileRenamed.Rows[i][2];          
                    row1[2] = _id++;
                    row1[3] = item;
                    _dtFileRenamed.Rows.Add(row1);
                }
            }

            DataRow row = _dtFileRenamed.NewRow();
            row[0] = Path.GetFileName(_pathTKC);
            row[1] = -1;
            row[2] = 0;
            row[3] = _pathTKC;
            _dtFileRenamed.Rows.InsertAt(row, 0);

            treeList1.DataSource = _dtFileRenamed;
            treeList1.ExpandAll();
            _id = 1; 
        }

        PDFConvert pdfConverter()
        {
            PDFConvert converter = new PDFConvert();
            converter.RenderingThreads = -1;
            converter.TextAlphaBit = -1;
            converter.TextAlphaBit = -1;
            converter.OutputToMultipleFile = false;
            converter.FirstPageToConvert = 1;
            converter.LastPageToConvert = 0;
            converter.FitPage = false;
            converter.JPEGQuality = 10;
            converter.OutputFormat = "png256";
            converter.ResolutionX = 500;
            converter.ResolutionY = 500;
            return converter;
        }
            
        #endregion Methods

        private void btnScanAll_Click(object sender, EventArgs e)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang đổi tên file trong thư mục Scan"))
            {
                for (int i = 0; i < grvScan.RowCount; i++)
                {
                    try
                    {
                        string filePath = grvScan.GetRowCellValue(i, colFilePath).ToString();
                        
                        string thisProductCode = "";

                        if (Path.GetExtension(filePath) == ".jpg")
                        {
                            Image img = Image.FromFile(filePath);
                            Bitmap mBitmap = new Bitmap(img);

                            ArrayList barcodes = new ArrayList();
                            BarcodeImaging.FullScanPage(ref barcodes, mBitmap, 100);
                            //string[] barcodes = BarcodeReader.read(mBitmap, BarcodeReader.CODE39);
                            mBitmap.Dispose();
                            string contentBarcode = barcodes.ToArray().Where(o => o.ToString().StartsWith("+")).ToArray()[0].ToString();//nội dung barcode chứa tên biểu mẫu (VD: 2.BM01.A0101)
                            thisProductCode = "TPAD." + contentBarcode.Substring(3);
                            if (!thisProductCode.ToUpper().Contains(_productCode))
                            {
                                continue;
                            }
                            string destFileName = @"D:\Thietke.Ck\TPAD." + _productCode.Substring(5, 1) + "\\" + _productCode + ".Ck\\BCCk."
                                + _productCode + "\\BC-CAD." + _productCode + "\\" + thisProductCode + ".jpg";
                            if (File.Exists(destFileName))
                            {
                                DialogResult result = MessageBox.Show("Đã tồn tại file: '" + thisProductCode + ".jpg' trong thiết kế" + Environment.NewLine +
                                    "Bạn có muốn ghi đè lên file cũ không?", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (result == DialogResult.Yes)
                                {
                                    File.Delete(destFileName);
                                    File.Copy(filePath, destFileName, true);

                                    img.Dispose();
                                    mBitmap.Dispose();
                                    File.Delete(filePath);
                                }
                                else
                                {
                                    TextUtils.RenameFileVB(filePath, thisProductCode + ".jpg");
                                }
                            }
                            else
                            {
                                File.Copy(filePath, destFileName, true);
                                img.Dispose();
                                mBitmap.Dispose();
                                File.Delete(filePath);
                            }                            
                        }
                        else if (Path.GetExtension(filePath).ToLower() == ".pdf")
                        {
                            System.Collections.ArrayList barcodes = new System.Collections.ArrayList();
                            string outputFilePath = Path.GetDirectoryName(filePath) + "\\" + Path.GetFileNameWithoutExtension(filePath) + ".png";
                            pdfConverter().Convert(filePath, outputFilePath);

                            Bitmap mBitmap = new Bitmap(outputFilePath);

                            BarcodeImaging.FullScanPage(ref barcodes, mBitmap, 100);
                            //string[] barcodes = BarcodeReader.read(mBitmap, BarcodeReader.CODE39);

                            mBitmap.Dispose();
                            File.Delete(outputFilePath);

                            string contentBarcode = barcodes.ToArray().Where(o => o.ToString().StartsWith("2.")).ToArray()[0].ToString();//nội dung barcode chứa tên biểu mẫu (VD: 2.BM01.A0101)
                            string templateCode = contentBarcode.Split('.')[1];
                            TemplateModel temModel = (TemplateModel)TemplateBO.Instance.FindByAttribute("Code", templateCode)[0];

                            int tempType = temModel.Type;
                            string code = contentBarcode.Split('.')[2];
                            if (tempType == 1 || tempType == 2) //1:cơ khí,2:điện,3:điện tử
                            {
                                thisProductCode = "TPAD." + code;
                            }
                            else
                            {
                                thisProductCode = "PCB." + code;
                            }

                            if (_productCode != thisProductCode)
                            {
                                continue;
                            }
                            string tempName = temModel.Name.Replace("code", thisProductCode);
                            string tempFolderPath = temModel.PathFolderC.Replace("code", thisProductCode);

                            if (tempType == 1)
                            {
                                string destFileName = @"D:\Thietke.Ck\TPAD." + code.Substring(0, 1) + "\\" + tempFolderPath + "\\"
                                                    + tempName + Path.GetExtension(filePath);
                                checkBeforeCopyFile(filePath, destFileName);                                
                            }
                            if (tempType == 2)
                            {
                                
                            }
                            if (tempType == 3)
                            {
                                string destFileName = @"D:\Thietke.Dt\PCB." + code.Substring(0, 1) + "\\" + tempFolderPath + "\\"
                                + tempName + ".pdf";
                                checkBeforeCopyFile(filePath, destFileName);    
                            }                            
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }

                btnRefresh_Click(null, null);
            }
        }

        void checkBeforeCopyFile(string sourceFileName, string destFileName)
        {
            try
            {
                if (File.Exists(destFileName))
                {
                    DialogResult result = MessageBox.Show("Đã tồn tại file: '" + Path.GetFileName(destFileName) + "' trong thiết kế" + Environment.NewLine +
                        "Bạn có muốn ghi đè lên file cũ không?", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        File.Delete(destFileName);
                        File.Copy(sourceFileName, destFileName);

                        if (pictureBox1.Image != null)
                        {
                            pictureBox1.Image.Dispose();
                        }

                        File.Delete(sourceFileName);
                    }
                    else
                    {
                        TextUtils.RenameFileVB(sourceFileName, Path.GetFileName(destFileName));
                    }
                }
                else
                {
                    File.Copy(sourceFileName, destFileName);
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                    }
                    File.Delete(sourceFileName);
                }
            }
            catch (Exception ex)
            {
                TextUtils.ShowError(ex);
            }
            
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _productCode = txtCode.Text.Trim().ToUpper();
                if (_productCode=="")
                {
                    MessageBox.Show("Bạn hãy nhập mã sản phẩm!");
                    return;
                }
                if (_productCode.StartsWith("TPAD"))
                {
                    _pathTKC = @"D:\Thietke.Ck\TPAD." + _productCode.Substring(5, 1) + "\\" + _productCode + ".Ck" + "\\BCCk." + _productCode;
                }

                if (_productCode.StartsWith("PCB"))
                {
                    _pathTKC = @"D:\Thietke.Dt\PCB." + _productCode.Substring(4, 1) + "\\" + _productCode + "\\BCDt." + _productCode;
                }               

                if (!Directory.Exists(_pathTKC))
                {
                    MessageBox.Show("Không tồn tại thiết kế cho sản phẩm này trong ổ D!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                btnRefresh_Click(null, null);
            }
        }

        private void grdScan_DoubleClick(object sender, EventArgs e)
        {
                  
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                loadFileWillRename();                
            }
            catch (Exception)
            {              
            }

            try
            {
                loadFileRenamed();
            }
            catch
            {
                
            }
            
        }

        private void xoaFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa file này không?", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                }
                File.Delete(grvScan.GetFocusedRowCellValue(colFilePath).ToString());
                loadFileWillRename();
            }
        }

        private void đôiTênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = grvScan.GetFocusedRowCellValue(colFilePath).ToString();
            int type = 0;
            if (_productCode.StartsWith("PCB"))
            {
                type = 3;
            }
            if (_productCode.StartsWith("TPAD"))
            {
                if (rdbCokhi.Checked)
                {
                    type = 1;
                }
                else
                {
                    type = 2;
                }
            }

            frmRenameNormalFile frm = new frmRenameNormalFile();
            frm.SelectedFilePath = filePath;
            frm.TemplateType = type;
            frm.ProductCode = _productCode;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    btnRefresh_Click(null, null);
                }
                catch (Exception)
                {                    
                }                
            }
        }

        private void treeList1_DoubleClick(object sender, EventArgs e)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Hiển thị ảnh"))
            {
                string filePath = treeList1.FocusedNode.GetValue(colTreeFilelPath).ToString();
                if (Path.GetExtension(filePath).ToLower() == ".jpg")
                {
                    pictureBox1.ImageLocation = filePath;
                }
                if (Path.GetExtension(filePath).ToLower() == ".pdf")
                {
                    string directoryPath = System.IO.Path.GetTempPath();
                    string outputFilePath = directoryPath + "\\" + Path.GetFileNameWithoutExtension(filePath) + ".png";
                    pdfConverter().Convert(filePath, outputFilePath);
                    pictureBox1.ImageLocation = outputFilePath;
                }
            }            
        }

        private void diChuyênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string parent = treeList1.FocusedNode.GetValue(colTreeParentID).ToString();
            if (parent!="0")
            {
                MessageBox.Show("Bạn hãy chọn đúng đường dẫn cần di chuyển tới");
                return;
            }
            
            try
            {
                string selectedFolderPath = treeList1.FocusedNode.GetValue(colTreeFilelPath).ToString();
                string selectedFileName = grvScan.GetFocusedRowCellValue(colFilePath).ToString();
                string destFileName = selectedFolderPath + "\\" + Path.GetFileName(selectedFileName);
                if (File.Exists(destFileName))
                {
                    File.Delete(destFileName);
                }
                File.Move(selectedFileName, destFileName);
                btnRefresh_Click(null, null);
            }
            catch (Exception ex)
            {
                TextUtils.ShowError(ex);
                return;
            }
        }

        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa file này không?", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                    }
                    File.Delete(treeList1.FocusedNode.GetValue(colTreeFilelPath).ToString());
                    loadFileRenamed();
                }
            }
            catch (Exception)
            {
               
            }
            
        }

        private void grvScan_DoubleClick(object sender, EventArgs e)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Hiển thị ảnh"))
            {
                string filePath = grvScan.GetFocusedRowCellValue(colFilePath).ToString();
                if (Path.GetExtension(filePath).ToLower() == ".jpg")
                {
                    pictureBox1.ImageLocation = filePath;
                }
                if (Path.GetExtension(filePath).ToLower() == ".pdf")
                {
                    string directoryPath = System.IO.Path.GetTempPath();
                    string outputFilePath = directoryPath + "\\" + Path.GetFileNameWithoutExtension(filePath) + ".png";
                    pdfConverter().Convert(filePath, outputFilePath);
                    pictureBox1.ImageLocation = outputFilePath;
                }
            }      
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            frmConfigTemplate frm = new frmConfigTemplate();
            TextUtils.OpenForm(frm);
        }
    }
}
