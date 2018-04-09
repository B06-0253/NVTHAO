using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Utils;
using BMS.Business;
using BMS.Model;
using System.IO;

namespace BMS
{
    public partial class frmRenameNormalFile : _Forms
    {
        public int TemplateType;
        public string ProductCode;
        public string SelectedFilePath;

        public frmRenameNormalFile()
        {
            InitializeComponent();
        }

        private void frmRenameNormalFile_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = TextUtils.Select("Template", new Expression("Type", TemplateType));
                grdData.DataSource = dt;
                grvData.BestFitColumns();
            }
            catch (Exception)
            {                    
            }

            txtFileName.Text = Path.GetFileNameWithoutExtension(SelectedFilePath);
        }

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string fileName = grvData.GetFocusedRowCellValue(colName).ToString().Replace("code", ProductCode);
                string temFolder = grvData.GetFocusedRowCellValue(colPathFolderC).ToString().Replace("code", ProductCode);
                string destFileName = "";
                if (TemplateType == 1)//cơ khí
                {
                    destFileName=@"D:\Thietke.Ck\TPAD." + ProductCode.Substring(5, 1) + "\\" + temFolder + "\\"
                    + fileName + Path.GetExtension(SelectedFilePath);                   
                }

                if (TemplateType == 3)//điện tử
                {
                    destFileName = @"D:\Thietke.Dt\PCB." + ProductCode.Substring(4, 1) + "\\" + temFolder + "\\"
                    + fileName + ".pdf";
                }
                if (File.Exists(destFileName))
                {
                    File.Delete(destFileName);
                }
                File.Move(SelectedFilePath, destFileName);
            }
            catch (Exception ex)
            {
                TextUtils.ShowError(ex);
                return;
            }
           
            DialogResult = DialogResult.OK;
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            try
            {
                TextUtils.RenameFileVB(SelectedFilePath, (txtFileName.Text.ToUpper().Replace(" ", "")) + Path.GetExtension(SelectedFilePath));
                if (Path.GetExtension(SelectedFilePath) == ".jpg")
                {
                    string destFileName = "D:\\Thietke.Ck\\" + ProductCode.Substring(0, 6) + "\\" + ProductCode + ".Ck\\BCCk." + ProductCode + "\\BC-CAD." + ProductCode + "\\"
                        + (txtFileName.Text.ToUpper().Replace(" ", "")) + Path.GetExtension(SelectedFilePath);

                    string sourceFile=Path.GetDirectoryName(SelectedFilePath) + "\\" + (txtFileName.Text.Replace(" ", "")) + Path.GetExtension(SelectedFilePath);
                    if (File.Exists(destFileName))
                    {
                        DialogResult result = MessageBox.Show("Đã tồn tại file: '" + Path.GetFileName(destFileName) + "' trong thư mục BC-CAD." + ProductCode + Environment.NewLine +
                      "Bạn có muốn ghi đè lên file cũ không?", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            File.Copy(sourceFile, destFileName, true);
                            File.Delete(sourceFile);
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        File.Move(sourceFile, destFileName);
                    }                  
                }
            }
            catch (Exception ex)
            {
                TextUtils.ShowError(ex);
                return;
            }
            
            DialogResult = DialogResult.OK;
        }

        private void txtFileName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnRename_Click(null, null);
            }
        }
    }
}
