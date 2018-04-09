using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using System.IO;
using System.Diagnostics;

namespace BMS
{
    public partial class frmXemGiaVatTu : _Forms
    {
        public frmXemGiaVatTu()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            string filePath = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
                txtDMVTPath.Text = filePath;
            }
            else
            {
                return;
            }
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load giá vật tư..."))
            {
                grdData.DataSource = TextUtils.LoadModulePriceTPAD(filePath);
            }
        }

        private void btnExecl_Click(object sender, EventArgs e)
        {
            if (grvData.RowCount > 0)
            {
                TextUtils.ExportExcel(grvData);
            }
        }

        private void btnGetTemp_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                File.Copy(Application.StartupPath + "/Templates/DMVT.xlsm", fbd.SelectedPath + "/DMVT.xlsm", true);
                Process.Start(fbd.SelectedPath + "/DMVT.xlsm");
            }
        }

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            if (true)
            {
                
            }
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
    }
}
