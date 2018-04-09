using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPA.Utils;
using DevExpress.Utils;
using System.IO;
using BMS.Model;
using BMS.Business;

namespace BMS
{
    public partial class frmModelContained : _Forms
    {
        public string MaterialCode = "";
        public string MaterialName = "";
        public int DisplayType = 0;

        public frmModelContained()
        {
            InitializeComponent();
        }

        private void frmModelContained_Load(object sender, EventArgs e)
        {
            this.Text += ": " + MaterialCode + " - " + MaterialName;
            DataTable dt = new DataTable();

            //if (DisplayType == 0)
            //{
            //    dt = LibQLSX.Select("select * from vGetModuleOfPart with(nolock) where PartsCode = '" 
            //        + MaterialCode + "' and ProjectModuleCode like 'TPAD.%' order by ProjectModuleCode");
            //}
            //if (DisplayType == 1)
            //{
            //    dt = LibQLSX.Select("select * from vGetModuleOfPart with(nolock) where [ModuleCode] = '" 
            //        + MaterialCode + "' and ProjectModuleCode like 'TPAD.%' order by ProjectModuleCode");
            //}
            //dt = TextUtils.GetDistinctDatatable(dt, "ProjectModuleCode");
            
            dt = TextUtils.Select("select distinct ModuleCode, ModuleName from vMaterialModuleLink with(nolock) where Code = '" + MaterialCode + "'");

            gridControl1.DataSource = dt;
            gridView1.BestFitColumns();
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == (Keys.C))
            {
                try
                {
                    string text = TextUtils.ToString(gridView1.GetFocusedRowCellValue(gridView1.FocusedColumn));
                    Clipboard.SetText(text);
                }
                catch
                {
                }
            }
        }

        private void xemDanhMụcVậtTưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát", "Đang load danh mục vật tư"))
                {
                    DocUtils.InitFTPQLSX();
                    string code = gridView1.GetFocusedRowCellValue(colModuleCode).ToString();
                    string name = gridView1.GetFocusedRowCellValue(colModuleName).ToString();

                    //string strFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    //string strFTPFileName = @"//Thietke.Ck/" + code.Substring(0, 6) + "/" + code + ".Ck" + "/VT." + code + ".xlsm ";
                    //string strSaveName = code + ".xlsm";
                    //if (!DocUtils.CheckExits(strFTPFileName))
                    //{
                    //    MessageBox.Show("Module không có trên nguồn thiết kế!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    //    return;
                    //}
                    //DocUtils.DownloadFile(strFilePath, strSaveName, strFTPFileName);
                    //DataTable dtDMVT = TextUtils.ExcelToDatatableNoHeader(strFilePath + "/" + strSaveName, "DMVT");
                    //if (File.Exists(strFilePath + "/" + strSaveName))
                    //{
                    //    File.Delete(strFilePath + "/" + strSaveName);
                    //}
                    //dtDMVT = dtDMVT.AsEnumerable()
                    //           .Where(row => TextUtils.ToInt(row.Field<string>("F1") == "" ||
                    //               row.Field<string>("F1") == null ? "0" : row.Field<string>("F1").Substring(0, 1)) > 0)
                    //           .CopyToDataTable();

                    DataTable dtDMVT = TextUtils.Select("select * from vMaterialModuleLink with(nolock) where ModuleCode = '" + code + "'");
                    
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

        private void xemDanhSáchDựÁnChứaModuleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string code = TextUtils.ToString(gridView1.GetFocusedRowCellValue(colModuleCode));
            ModulesModel model = (ModulesModel)ModulesBO.Instance.FindByCode(code);
            if (model.Status != 2)
            {
                MessageBox.Show("Module chưa có trên nguồn chuẩn!");
                return;
            }

            frmListProjectContainModule frm = new frmListProjectContainModule();
            frm.Module = model;
            frm.Show();
        }
    }
}
