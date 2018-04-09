using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Model;
using BMS.Business;
using DevExpress.Utils;
using System.IO;
using System.Diagnostics;
using System.Collections;
using BMS.Utils;
using TPA.Utils;
using TPA.Business;
using TPA.Model;
using Excel = Microsoft.Office.Interop.Excel;
using Forms.Properties;

namespace BMS
{
    public partial class frmPhanBoDuLieu : _Forms
    {
        #region Variables

        DataTable _dtFile = new DataTable();
        #endregion

        #region Constructors and Load
        public frmPhanBoDuLieu()
        {
            InitializeComponent();
        }

        private void frmPhanBoDuLieu_Load(object sender, EventArgs e)
        {
            DocUtils.InitFTPQLSX();
            loadProject();

            _dtFile.Columns.Add("ID");
            _dtFile.Columns.Add("FileName");
            _dtFile.Columns.Add("Path");
        }
        #endregion

        #region Methods
        void loadProject()
        {
            try
            {
                DataTable tbl = LibQLSX.Select("exec spGetAllProject");
                TextUtils.PopulateCombo(cboProject, tbl, "ProjectName", "ProjectCode", "");
            }
            catch (Exception ex)
            {
            }
        }

        void loadModules1()
        {
            string projectCode = TextUtils.ToString(cboProject.EditValue);
            if (projectCode != "")
            {
                try
                {
                    string[] paraName = new string[1];
                    string[] paraValue = new string[1];
                    paraName[0] = "@ProjectCode"; paraValue[0] = projectCode;
                    DataTable tbl = SuppliersBO.Instance.LoadDataFromSP("spGetModuleOfProject", "Modules", paraName, paraValue);
                    tbl.Columns.Add("check", typeof(bool));
                    tbl.Columns["ProductCode"].ColumnName = "MaThietBi";
                    tbl.Columns["ProductName"].ColumnName = "TenThietBi";

                    //grvData.AutoGenerateColumns = false;
                    //grvData.DataSource = tbl;

                    grdModule.DataSource = tbl;
                }
                catch
                {
                    //grvData.DataSource = null;
                    grdModule.DataSource = null;
                }
            }
            else
            {
                //grvData.DataSource = null;
                grdModule.DataSource = null;
            }
        }

        void loadProducts()
        {
            string projectCode = grvProject.GetFocusedRowCellValue(colProjectCode).ToString();
            if (projectCode != "")
            {
                try
                {
                    string[] paraName = new string[1];
                    string[] paraValue = new string[1];
                    paraName[0] = "@ProjectCode"; paraValue[0] = projectCode;
                    DataTable tbl = SuppliersBO.Instance.LoadDataFromSP("spGetProductOfProject", "Product", paraName, paraValue);
                    TextUtils.PopulateCombo(cboProduct, tbl, "ThietBi", "PProductId", "");
                }
                catch
                {
                    cboProduct.Properties.DataSource = null;
                }
            }
            else
            {
                cboProduct.Properties.DataSource = null;
            }
        }

        void PhanBoOnlyModule()
        {
            #region Validate
            if (grvModule.RowCount == 0) return;
            string projectCode = cboProject.EditValue != null ? cboProject.EditValue.ToString() : "";
            if (projectCode == "")
            {
                MessageBox.Show("Bạn hãy chọn một dự án!");
                return;
            }

            string productCode = "SANPHAM";
            if (!chkDownloadOnlyModule.Checked)
            {
                productCode = grvProduct.GetFocusedRowCellValue(colMaThietBi) != null ? grvProduct.GetFocusedRowCellValue(colMaThietBi).ToString() : "";
            }
            if (productCode == "")
            {
                MessageBox.Show("Bạn hãy chọn một sản phẩm!");
                return;
            }

            int count = 0;
            for (int i = 0; i < grvModule.RowCount; i++)
            {
                if (TextUtils.ToBoolean(grvModule.GetRowCellValue(i, gridColumn1)))
                {
                    count++;
                    break;
                }
            }
            if (count < 1)
            {
                MessageBox.Show("Bạn hãy chọn một thiết kế!");
                return;
            }
            #endregion

            #region Get Path
            string initPath = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                initPath = fbd.SelectedPath;
            }
            else
            {
                MessageBox.Show("Bạn hãy chọn một đường dẫn!");
                return;
            }
            #endregion

            List<string> errorList = new List<string>();
            DataTable dtDMVT_Tong = new DataTable();
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang download dữ liệu..."))
            {
                for (int i = 0; i < grvModule.RowCount; i++)
                {
                    if (!TextUtils.ToBoolean(grvModule.GetRowCellValue(i, gridColumn1)))
                    {
                        continue;
                    }

                    if (grvModule.GetRowCellValue(i, gridColumn2) == null)
                    {
                        continue;
                    }

                    string moduleCode = grvModule.GetRowCellValue(i, gridColumn2).ToString();

                    DocUtils.InitFTPQLSX();

                    if (!DocUtils.CheckExits(string.Format("/Thietke.Ck/{0}/{1}.Ck/", moduleCode.Substring(0, 6), moduleCode)))
                    {
                        continue;
                    }

                    #region Check Error
                    DataTable dtError = TextUtils.Select(
                        string.Format("select top 1 * from [vModuleError] with(nolock) where [ModuleCode]='{0}' and Status = 0 and ConfirmTemp = 0 and DepartmentID = 1 and ConfirmManager = 1 and isnull(IsDownloaded,0) = 0", moduleCode));
                    DataTable dtKPH = TextUtils.Select(
                        string.Format("select top 1 * from [vMisMatch] with(nolock) where [ModuleCode]='{0}' StatusKCS = 0 and ConfirmTemp = 0", moduleCode));
                    if (dtError.Rows.Count > 0 || dtKPH.Rows.Count > 0)
                    {
                        errorList.Add("Module " + moduleCode + ": còn " + dtError.Rows.Count + " lỗi và " + dtKPH.Rows.Count + " sự không phù hợp");
                        continue;
                    }
                    #endregion

                    #region Download 3D
                    if (Global.AppUserName.ToLower() == "dong.ld")
                    {
                        string file3D = string.Format("/Thietke.Ck/{0}/{1}.Ck/3D.{1}", moduleCode.Substring(0, 6), moduleCode);
                        TextUtils.DownloadFtpFolder(file3D, initPath + "/" + moduleCode);
                        continue;
                    }
                    #endregion
                    
                    string serverPathCK = "Thietke.Ck/" + moduleCode.Substring(0, 6) + "/" + moduleCode + ".Ck/";
                    DataTable dt = TextUtils.Select("vPBDL_Structure_File", new BMS.Utils.Expression("DepartmentID", Global.DepartmentID));
                    ArrayList listStruc = PBDLStructureBO.Instance.FindByAttribute("DepartmentID", Global.DepartmentID);

                    if (listStruc.Count > 0)
                    {
                        #region Lấy dữ liệu trong file danh mục vật tư cơ khí
                        try
                        {
                            if (DocUtils.CheckExits(serverPathCK + "/VT." + moduleCode + ".xlsm"))
                            {
                                //Download file danh mục vật tư
                                DocUtils.DownloadFile(initPath, "VT." + moduleCode + ".xlsm", serverPathCK + "/VT." + moduleCode + ".xlsm");
                            }
                            else
                            {
                                errorList.Add(moduleCode + ": Chưa có trên nguồn thiết kế!");
                            }
                        }
                        catch
                        {
                        }

                        string pathDMVT = initPath + "/VT." + moduleCode + ".xlsm";
                        DataTable dtDMVT = TextUtils.ExcelToDatatable(pathDMVT, "DMVT");                        
                        if (dtDMVT.Rows.Count == 0) continue;
                        if (i==0)
	                    {
                            dtDMVT_Tong = dtDMVT;
	                    }
                        else
                        {
                            dtDMVT_Tong.Merge(dtDMVT);
                        }
                        
                        for (int j = 0; j <= 4; j++)
                        {
                            dtDMVT.Rows.RemoveAt(0);
                        }
                        File.Delete(pathDMVT);

                        #endregion

                        string local = "";

                        foreach (var item in listStruc)
                        {
                            PBDLStructureModel strucModel = (PBDLStructureModel)item;
                            string pathStruc = strucModel.Path.Replace("project", projectCode).Replace("product", productCode.Replace(" ", "").Trim())
                                .Replace("code", moduleCode);
                            string pathLocal = initPath + "/" + pathStruc;
                            if (strucModel.ParentID == 0)
                            {
                                local = pathLocal;
                            }
                            Directory.CreateDirectory(pathLocal);
                            DataTable dtFile = TextUtils.Select("vPBDL_Structure_File", new BMS.Utils.Expression("PBDLStructureID", strucModel.ID));

                            foreach (DataRow row in dtFile.Rows)
                            {
                                int pBDLFileID = TextUtils.ToInt(row["PBDLFileID"]);
                                PBDLFileModel fileModel = (PBDLFileModel)PBDLFileBO.Instance.FindByPK(pBDLFileID);
                                string extension = fileModel.Extension;

                                if (fileModel.GetType == 0)//nhieu file
                                {
                                    string pathServer = fileModel.FolderContain.Replace("group", moduleCode.Substring(0, 6)).Replace("code", moduleCode);

                                    #region Mã vật liệu
                                    if (fileModel.FilterMaVatLieu)//nếu có mã vật liệu
                                    {
                                        DataRow[] listMaVatLieu = dtDMVT.Select("F5 <> '' and F4 like '%TPAD%' ");
                                        foreach (DataRow rowMVL in listMaVatLieu)
                                        {
                                            string fileName = rowMVL["F4"].ToString();
                                            try
                                            {
                                                if (DocUtils.CheckExits(pathServer + "/" + fileName + extension))
                                                {
                                                    DocUtils.DownloadFile(pathLocal, fileName + fileModel.Extension, pathServer + "/" + fileName + fileModel.Extension);
                                                }
                                            }
                                            catch
                                            {
                                            }
                                        }
                                    }
                                    #endregion

                                    #region Đơn vị
                                    if (fileModel.FilterDonVi != "")
                                    {
                                        DataRow[] listDonVi = dtDMVT.Select("F6 like '%" + fileModel.FilterDonVi.ToUpper() + "%' and F4 like '%TPAD%' ");
                                        foreach (DataRow rowMVL in listDonVi)
                                        {
                                            string fileName = rowMVL["F4"].ToString();
                                            try
                                            {
                                                if (DocUtils.CheckExits(pathServer + "/" + fileName + extension))
                                                {
                                                    DocUtils.DownloadFile(pathLocal, fileName + fileModel.Extension, pathServer + "/" + fileName + fileModel.Extension);
                                                }
                                            }
                                            catch
                                            {
                                            }
                                        }
                                    }
                                    #endregion Đơn vị

                                    #region Thông Số
                                    if (fileModel.FilterThongSo != "")
                                    {
                                        DataRow[] listThongSo;
                                        if (fileModel.ID == 51)//download bản vẽ sửa đổi
                                        {
                                            listThongSo = dtDMVT.Select("F4 like '%" + fileModel.FilterThongSo + "%' and F4 like '%TPAD%' ");
                                            foreach (DataRow r in listThongSo)
                                            {
                                                string fileName = r["F4"].ToString() + extension;
                                                if (DocUtils.CheckExits(pathServer + "/" + fileName))
                                                {
                                                    DocUtils.DownloadFile(pathLocal, fileName, pathServer + "/" + fileName);
                                                }
                                            }
                                        }
                                        listThongSo = dtDMVT.Select("F3 like '%" + fileModel.FilterThongSo.ToUpper() + "%' and F4 like '%TPAD%' ");
                                        List<string[]> listSTT = new List<string[]>();
                                        foreach (DataRow rowThongSo in listThongSo)
                                        {
                                            if (fileModel.FilterThongSo.ToUpper() == "HÀN")
                                            {
                                                listSTT.Add(new string[] { rowThongSo["F1"].ToString(), rowThongSo["F2"].ToString(), rowThongSo["F4"].ToString() });
                                            }
                                            else
                                            {
                                                string fileName = rowThongSo["F4"].ToString();
                                                try
                                                {
                                                    if (DocUtils.CheckExits(pathServer + "/" + fileName + extension))
                                                    {
                                                        DocUtils.DownloadFile(pathLocal, fileName + fileModel.Extension, pathServer + "/" + fileName + fileModel.Extension);
                                                    }
                                                }
                                                catch
                                                {
                                                }
                                            }
                                        }

                                        #region Thông số Hàn
                                        if (fileModel.FilterThongSo.ToUpper() == "HÀN")
                                        {
                                            if (listSTT.Count > 0)
                                            {
                                                foreach (string[] han in listSTT)
                                                {
                                                    string folderHan = pathLocal + "/" + han[0].ToString() + "-" + han[1].ToString();
                                                    Directory.CreateDirectory(folderHan);
                                                    if (DocUtils.CheckExits(pathServer + "/" + han[2] + extension))
                                                    {
                                                        DocUtils.DownloadFile(folderHan, han[2] + extension, pathServer + "/" + han[2] + extension);
                                                    }
                                                    DataRow[] listVatTu = dtDMVT.Select("F1 like '%" + han[0] + ".%'");                                                    
                                                    foreach (DataRow rowChild in listVatTu)
                                                    {
                                                        string fileName = rowChild["F4"].ToString();
                                                        try
                                                        {
                                                            if (DocUtils.CheckExits(pathServer + "/" + fileName + extension))
                                                            {
                                                                DocUtils.DownloadFile(folderHan, fileName + fileModel.Extension, pathServer + "/" + fileName + fileModel.Extension);
                                                            }
                                                        }
                                                        catch
                                                        {
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        #endregion Thông số hàn
                                    }
                                    #endregion Thông Số

                                    #region MẶT
                                    if (fileModel.MAT)
                                    {
                                        try
                                        {
                                            string[] listFileMat = DocUtils.GetFilesList(pathServer);
                                            if (listFileMat != null)
                                            {
                                                foreach (string fileName in listFileMat)
                                                {
                                                    try
                                                    {
                                                        if (DocUtils.CheckExits(pathServer + "/" + fileName))
                                                        {
                                                            DocUtils.DownloadFile(pathLocal, fileName, pathServer + "/" + fileName);
                                                        }
                                                    }
                                                    catch
                                                    {
                                                    }
                                                }
                                            }

                                        }
                                        catch
                                        {
                                        }
                                    }
                                    #endregion Mặt

                                    #region TEM
                                    if (fileModel.TEM)
                                    {
                                        try
                                        {
                                            string[] listFileTEM = DocUtils.GetFilesList(pathServer);
                                            if (listFileTEM != null)
                                            {
                                                foreach (string fileName in listFileTEM)
                                                {
                                                    try
                                                    {
                                                        if (DocUtils.CheckExits(pathServer + "/" + fileName))
                                                        {
                                                            DocUtils.DownloadFile(pathLocal, fileName, pathServer + "/" + fileName);
                                                        }
                                                    }
                                                    catch
                                                    {
                                                    }
                                                }
                                            }

                                        }
                                        catch
                                        {
                                        }
                                    }
                                    #endregion TEM
                                }
                                else//1 file
                                {
                                    if (strucModel.FolderType != 2)//nếu không phải là thư mục điện tử
                                    {
                                        string filePathServer = fileModel.FolderContain.Replace("group", moduleCode.Substring(0, 6)).Replace("code", moduleCode);
                                        try
                                        {
                                            if (DocUtils.CheckExits(filePathServer))
                                            {
                                                DocUtils.DownloadFile(pathLocal, Path.GetFileName(filePathServer), filePathServer);
                                            }
                                        }
                                        catch
                                        {
                                        }
                                    }
                                    else
                                    {
                                        #region Download file trong thư mục điện tử
                                        DataRow[] listPCB = dtDMVT.Select("F4 like '%PCB%'");
                                        foreach (DataRow rowDT in listPCB)
                                        {
                                            string pcbCode = rowDT["F4"].ToString();
                                            string pathPCB = pathLocal + "/" + pcbCode;
                                            if (pathPCB == "") continue;
                                            Directory.CreateDirectory(pathPCB);

                                            string filePathServer = fileModel.FolderContain.Replace("tpat", "TPAT." + pcbCode.Substring(4, 7)).Replace("code", pcbCode);
                                            try
                                            {
                                                if (DocUtils.CheckExits(filePathServer))
                                                {
                                                    DocUtils.DownloadFile(pathPCB, Path.GetFileName(filePathServer), filePathServer);
                                                }
                                            }
                                            catch
                                            {
                                            }
                                        }
                                        #endregion
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (errorList.Count > 0)
            {
                string contentMes = "";
                foreach (string item in errorList)
                {
                    contentMes += item + Environment.NewLine;
                }
                MessageBox.Show(contentMes, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (Global.AppUserName.ToLower() == "dong.ld")
            {
                MessageBox.Show("Lấy dữ liệu phân bổ thành công!", TextUtils.Caption);
            }
            else
            {
                //Gộp danh mục vật tư
                if (Global.DepartmentID == 3)//Phong ke toan
                {
                    #region Gộp file danh mục vật tư cho phòng kế toán
                    using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo file DMVT tổng hợp"))
                    {
                        DataColumn col = new DataColumn();
                        col.DefaultValue = "";
                        dtDMVT_Tong.Columns.Add(col);
                        string[] listFilePCB = Directory.GetFiles(initPath + "\\" + projectCode, "VT.PCB*", SearchOption.AllDirectories);
                        foreach (string item in listFilePCB)
                        {
                            string fileName = Path.GetFileNameWithoutExtension(item).Replace("VT.", "");
                            DataTable dtDMVT1 = TextUtils.ExcelToDatatable(item, "DMVT");
                            DataColumn col1 = new DataColumn();
                            col1.DefaultValue = fileName;
                            dtDMVT1.Columns.Add(col1);
                            dtDMVT_Tong.Merge(dtDMVT1);
                        }
                        if (dtDMVT_Tong.Rows.Count > 0)
                        {
                            var results = from myRow in dtDMVT_Tong.AsEnumerable()
                                          where TextUtils.ToDecimal(myRow.Field<string>("F1") != "" && myRow.Field<string>("F1") != null ? myRow.Field<string>("F1").Substring(0, 1) : "") > 0
                                          select myRow;
                            if (results.Count() >= 0)
                            {
                                dtDMVT_Tong = results.CopyToDataTable();
                            }
                            try
                            {
                                string fileTH = initPath + "\\" + projectCode + "\\" + projectCode + "-DMVT.csv";
                                dtDMVT_Tong.Columns[0].Caption = "STT";
                                dtDMVT_Tong.Columns[1].Caption = "TÊN VẬT TƯ";
                                dtDMVT_Tong.Columns[2].Caption = "THÔNG SỐ";
                                dtDMVT_Tong.Columns[3].Caption = "MÃ VẬT TƯ";
                                dtDMVT_Tong.Columns[4].Caption = "MÃ VẬT LIỆU";
                                dtDMVT_Tong.Columns[5].Caption = "ĐV";
                                dtDMVT_Tong.Columns[6].Caption = "SL";
                                dtDMVT_Tong.Columns[7].Caption = "VL";
                                dtDMVT_Tong.Columns[8].Caption = "KL";
                                dtDMVT_Tong.Columns[9].Caption = "HÃNG SX";
                                dtDMVT_Tong.Columns[10].Caption = "GHI CHÚ";
                                TextUtils.DatatableToCSV(dtDMVT_Tong, fileTH);
                            }
                            catch (Exception ex1)
                            {
                                MessageBox.Show("Có lỗi khi tạo file DMVT tổng hợp!\n" + ex1.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    #endregion
                }
                Process.Start("explorer.exe", "/select, " + initPath + "\\" + projectCode);
            }            
        }

        void PhanBoOnlyModule_WithVersion()
        {
            #region Validate
            if (grvModule.RowCount == 0) return;
            string projectCode = cboProject.EditValue != null ? cboProject.EditValue.ToString() : "";
            if (projectCode == "")
            {
                MessageBox.Show("Bạn hãy chọn một dự án!");
                return;
            }

            string productCode = "SANPHAM";
            if (!chkDownloadOnlyModule.Checked)
            {
                productCode = grvProduct.GetFocusedRowCellValue(colMaThietBi) != null ? grvProduct.GetFocusedRowCellValue(colMaThietBi).ToString() : "";
            }
            if (productCode == "")
            {
                MessageBox.Show("Bạn hãy chọn một sản phẩm!");
                return;
            }

            int count = 0;
            for (int i = 0; i < grvModule.RowCount; i++)
            {
                if (TextUtils.ToBoolean(grvModule.GetRowCellValue(i, gridColumn1)))
                {
                    count++;
                    break;
                }
            }
            if (count < 1)
            {
                MessageBox.Show("Bạn hãy chọn một thiết kế!");
                return;
            }
            #endregion

            #region Get Path
            string initPath = "";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                initPath = folderBrowserDialog1.SelectedPath;
            }

            if (initPath == "")
            {
                MessageBox.Show("Bạn hãy chọn một đường dẫn!");
                return;
            }
            #endregion

            List<string> errorList = new List<string>();
            DataTable dtDMVT_Tong = new DataTable();

            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang download dữ liệu..."))
            {
                for (int i = 0; i < grvModule.RowCount; i++)
                {
                    if (!TextUtils.ToBoolean(grvModule.GetRowCellValue(i, gridColumn1)))
                    {
                        continue;
                    }

                    if (grvModule.GetRowCellValue(i, gridColumn2) == null)
                    {
                        continue;
                    }

                    #region Check Error
                    string moduleCode = grvModule.GetRowCellValue(i, gridColumn2).ToString();
                    DataTable dtError = TextUtils.Select(
                        string.Format("select top 1 * from [vModuleError] where [ModuleCode]='{0}' and Status = 0 and ConfirmTemp = 0 and DepartmentID = 1", moduleCode));
                    DataTable dtKPH = TextUtils.Select(
                        string.Format("select top 1 * from [vMisMatch] where [ModuleCode]='{0}' StatusKCS = 0 and ConfirmTemp = 0", moduleCode));
                    if (dtError.Rows.Count > 0 || dtKPH.Rows.Count > 0)
                    {
                        errorList.Add("Module " + moduleCode + ": còn " + dtError.Rows.Count + " lỗi và " + dtKPH.Rows.Count + " sự không phù hợp");
                        continue;
                    }
                    #endregion

                    string serverPathCK = "Thietke.Ck/" + moduleCode.Substring(0, 6) + "/" + moduleCode + ".Ck/";

                    DataTable dt = TextUtils.Select("vPBDL_Structure_File", new BMS.Utils.Expression("DepartmentID", Global.DepartmentID));
                    ArrayList listStruc = PBDLStructureBO.Instance.FindByAttribute("DepartmentID", Global.DepartmentID);

                    DataTable dtModuleVersion = TextUtils.Select("select top 1 * from [ModuleVersion] with(nolock) where ModuleCode = '"
                    + moduleCode + "' and ProjectCode = '" + projectCode + "' order by Version desc");
                    if (dtModuleVersion.Rows.Count > 0)
                    {
                        int version = TextUtils.ToInt(dtModuleVersion.Rows[0]["Version"]);
                        string pathVersion = string.Format("W:\\ModuleVersion\\{0}\\{1}\\", moduleCode, version);
                        string pathVersionCK = pathVersion + serverPathCK;

                        #region Download 3D
                        if (Global.AppUserName.ToLower() == "dong.ld")
                        {
                            string file3D = string.Format(pathVersionCK + "/3D.{1}", moduleCode);
                            //TextUtils.DownloadFtpFolder(file3D, initPath + "/" + moduleCode);
                            TextUtils.CopyFolderVB(file3D, initPath + "/" + moduleCode);
                            continue;
                        }
                        #endregion

                        if (listStruc.Count > 0)
                        {
                            string pathDMVT = pathVersionCK + "/VT." + moduleCode + ".xlsm";

                            #region Lấy dữ liệu trong file danh mục vật tư cơ khí
                            try
                            {
                                if (File.Exists(pathDMVT))
                                {
                                    //Download file danh mục vật tư
                                    //DocUtils.DownloadFile(initPath, "VT." + moduleCode + ".xlsm", serverPathCK + "/VT." + moduleCode + ".xlsm");
                                    File.Copy(pathDMVT, initPath + "/VT." + moduleCode + ".xlsm", true);
                                }
                                else
                                {
                                    errorList.Add(moduleCode + ": Chưa có trên nguồn thiết kế!");
                                    continue;
                                }
                            }
                            catch
                            {
                            }

                            DataTable dtDMVT = TextUtils.ExcelToDatatable(pathDMVT, "DMVT");
                            if (dtDMVT.Rows.Count == 0) continue;
                            if (i == 0)
                            {
                                dtDMVT_Tong = dtDMVT;
                            }
                            else
                            {
                                dtDMVT_Tong.Merge(dtDMVT);
                            }

                            //for (int j = 0; j <= 4; j++)
                            //{
                            //    dtDMVT.Rows.RemoveAt(0);
                            //}
                            //File.Delete(pathDMVT);
                            dtDMVT = dtDMVT.AsEnumerable()
                                       .Where(row => TextUtils.ToInt(row.Field<string>("F1") == "" ||
                                           row.Field<string>("F1") == null ? "0" : row.Field<string>("F1").Substring(0, 1)) > 0)
                                       .CopyToDataTable();

                            #endregion

                            string local = "";

                            foreach (var item in listStruc)
                            {
                                PBDLStructureModel strucModel = (PBDLStructureModel)item;
                                string pathStruc = strucModel.Path.Replace("project", projectCode).Replace("product", productCode.Replace(" ", "").Trim())
                                    .Replace("code", moduleCode);
                                string pathLocal = initPath + "/" + pathStruc + "/";
                                if (strucModel.ParentID == 0)
                                {
                                    local = pathLocal;
                                }
                                Directory.CreateDirectory(pathLocal);
                                DataTable dtFile = TextUtils.Select("vPBDL_Structure_File", new BMS.Utils.Expression("PBDLStructureID", strucModel.ID));

                                foreach (DataRow row in dtFile.Rows)
                                {
                                    int pBDLFileID = TextUtils.ToInt(row["PBDLFileID"]);
                                    PBDLFileModel fileModel = (PBDLFileModel)PBDLFileBO.Instance.FindByPK(pBDLFileID);
                                    string extension = fileModel.Extension;

                                    if (fileModel.GetType == 0)//nhieu file
                                    {
                                        string pathServer = fileModel.FolderContain.Replace("group", moduleCode.Substring(0, 6)).Replace("code", moduleCode);

                                        #region Mã vật liệu
                                        if (fileModel.FilterMaVatLieu)//nếu có mã vật liệu
                                        {
                                            DataRow[] listMaVatLieu = dtDMVT.Select("F5 <> '' and F4 like '%TPAD%' ");
                                            foreach (DataRow rowMVL in listMaVatLieu)
                                            {
                                                string fileName = rowMVL["F4"].ToString() + extension;
                                                try
                                                {
                                                    //if (DocUtils.CheckExits(pathServer + "/" + fileName + extension))
                                                    //{
                                                    //    DocUtils.DownloadFile(pathLocal, fileName + fileModel.Extension, pathServer + "/" + fileName + fileModel.Extension);
                                                    //}
                                                    if (File.Exists(pathVersion + fileName))
                                                    {
                                                        File.Copy(pathVersion + fileName, pathLocal + fileName,true);
                                                    }
                                                }
                                                catch
                                                {
                                                }
                                            }
                                        }
                                        #endregion

                                        #region Đơn vị
                                        if (fileModel.FilterDonVi != "")
                                        {
                                            DataRow[] listDonVi = dtDMVT.Select("F6 like '%" + fileModel.FilterDonVi.ToUpper() + "%' and F4 like '%TPAD%' ");
                                            foreach (DataRow rowMVL in listDonVi)
                                            {
                                                string fileName = rowMVL["F4"].ToString() + extension;
                                                try
                                                {
                                                    //if (DocUtils.CheckExits(pathServer + "/" + fileName + extension))
                                                    //{
                                                    //    DocUtils.DownloadFile(pathLocal, fileName + fileModel.Extension, pathServer + "/" + fileName + fileModel.Extension);
                                                    //}
                                                    if (File.Exists(pathVersion + fileName ))
                                                    {
                                                        File.Copy(pathVersion + fileName, pathLocal + fileName, true);
                                                    }
                                                }
                                                catch
                                                {
                                                }
                                            }
                                        }
                                        #endregion Đơn vị

                                        #region Thông Số
                                        if (fileModel.FilterThongSo != "")
                                        {
                                            DataRow[] listThongSo;
                                            if (fileModel.ID == 51)//download bản vẽ sửa đổi
                                            {
                                                listThongSo = dtDMVT.Select("F4 like '%" + fileModel.FilterThongSo + "%' and F4 like '%TPAD%' ");
                                                foreach (DataRow r in listThongSo)
                                                {
                                                    string fileName = r["F4"].ToString() + extension;
                                                    //if (DocUtils.CheckExits(pathServer + "/" + fileName))
                                                    //{
                                                    //    DocUtils.DownloadFile(pathLocal, fileName, pathServer + "/" + fileName);
                                                    //}
                                                    if (File.Exists(pathVersion + fileName))
                                                    {
                                                        File.Copy(pathVersion + fileName, pathLocal + fileName, true);
                                                    }
                                                }
                                            }
                                            listThongSo = dtDMVT.Select("F3 like '%" + fileModel.FilterThongSo.ToUpper() + "%' and F4 like '%TPAD%' ");
                                            List<string[]> listSTT = new List<string[]>();
                                            foreach (DataRow rowThongSo in listThongSo)
                                            {
                                                if (fileModel.FilterThongSo.ToUpper() == "HÀN")
                                                {
                                                    listSTT.Add(new string[] { rowThongSo["F1"].ToString(), rowThongSo["F2"].ToString(), rowThongSo["F4"].ToString() });
                                                }
                                                else
                                                {
                                                    string fileName = rowThongSo["F4"].ToString() + extension;
                                                    try
                                                    {
                                                        //if (DocUtils.CheckExits(pathServer + "/" + fileName + extension))
                                                        //{
                                                        //    DocUtils.DownloadFile(pathLocal, fileName + fileModel.Extension, pathServer + "/" + fileName + fileModel.Extension);
                                                        //}
                                                        if (File.Exists(pathVersion + fileName))
                                                        {
                                                            File.Copy(pathVersion + fileName, pathLocal + fileName, true);
                                                        }
                                                    }
                                                    catch
                                                    {
                                                    }
                                                }
                                            }

                                            #region Thông số Hàn
                                            if (fileModel.FilterThongSo.ToUpper() == "HÀN")
                                            {
                                                if (listSTT.Count > 0)
                                                {
                                                    foreach (string[] han in listSTT)
                                                    {
                                                        string folderHan = pathLocal + "/" + han[0].ToString() + "-" + han[1].ToString() + "/";
                                                        Directory.CreateDirectory(folderHan);
                                                        //if (DocUtils.CheckExits(pathServer + "/" + han[2] + extension))
                                                        //{
                                                        //    DocUtils.DownloadFile(folderHan, han[2] + extension, pathServer + "/" + han[2] + extension);
                                                        //}
                                                        if (File.Exists(pathVersion + han[2] + extension))
                                                        {
                                                            File.Copy(pathVersion + han[2] + extension, folderHan + han[2] + extension, true);
                                                        }
                                                        DataRow[] listVatTu = dtDMVT.Select("F1 like '%" + han[0] + ".%'");
                                                        foreach (DataRow rowChild in listVatTu)
                                                        {
                                                            string fileName = rowChild["F4"].ToString() + extension;
                                                            try
                                                            {
                                                                //if (DocUtils.CheckExits(pathServer + "/" + fileName + extension))
                                                                //{
                                                                //    DocUtils.DownloadFile(folderHan, fileName + fileModel.Extension, pathServer + "/" + fileName + fileModel.Extension);
                                                                //}
                                                                if (File.Exists(pathVersion + fileName))
                                                                {
                                                                    File.Copy(pathVersion + fileName, folderHan + fileName, true);
                                                                }
                                                            }
                                                            catch
                                                            {
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            #endregion Thông số hàn
                                        }
                                        #endregion Thông Số

                                        #region MẶT
                                        if (fileModel.MAT)
                                        {
                                            try
                                            {
                                                string[] listFileMat = DocUtils.GetFilesList(pathServer);
                                                if (listFileMat != null)
                                                {
                                                    foreach (string fileName in listFileMat)
                                                    {
                                                        try
                                                        {
                                                            //if (DocUtils.CheckExits(pathServer + "/" + fileName))
                                                            //{
                                                            //    DocUtils.DownloadFile(pathLocal, fileName, pathServer + "/" + fileName);
                                                            //}
                                                            if (File.Exists(pathVersion + fileName))
                                                            {
                                                                File.Copy(pathVersion + fileName, pathLocal + fileName, true);
                                                            }
                                                        }
                                                        catch
                                                        {
                                                        }
                                                    }
                                                }

                                            }
                                            catch
                                            {
                                            }
                                        }
                                        #endregion Mặt

                                        #region TEM
                                        if (fileModel.TEM)
                                        {
                                            try
                                            {
                                                string[] listFileTEM = DocUtils.GetFilesList(pathServer);
                                                if (listFileTEM != null)
                                                {
                                                    foreach (string fileName in listFileTEM)
                                                    {
                                                        try
                                                        {
                                                            //if (DocUtils.CheckExits(pathServer + "/" + fileName))
                                                            //{
                                                            //    DocUtils.DownloadFile(pathLocal, fileName, pathServer + "/" + fileName);
                                                            //}
                                                            if (File.Exists(pathVersion + fileName))
                                                            {
                                                                File.Copy(pathVersion + fileName, pathLocal + fileName, true);
                                                            }
                                                        }
                                                        catch
                                                        {
                                                        }
                                                    }
                                                }

                                            }
                                            catch
                                            {
                                            }
                                        }
                                        #endregion TEM
                                    }
                                    else//1 file
                                    {
                                        if (strucModel.FolderType != 2)//nếu không phải là thư mục điện tử
                                        {
                                            string filePathServer = fileModel.FolderContain.Replace("group", moduleCode.Substring(0, 6)).Replace("code", moduleCode);
                                            try
                                            {
                                                //if (DocUtils.CheckExits(filePathServer))
                                                //{
                                                //    DocUtils.DownloadFile(pathLocal, Path.GetFileName(filePathServer), filePathServer);
                                                //}
                                                if (File.Exists(pathVersion + filePathServer))
                                                {
                                                    File.Copy(pathVersion + filePathServer, pathLocal + filePathServer, true);
                                                }
                                            }
                                            catch
                                            {
                                            }
                                        }
                                        else
                                        {
                                            #region Download file trong thư mục điện tử
                                            DataRow[] listPCB = dtDMVT.Select("F4 like '%PCB%'");
                                            foreach (DataRow rowDT in listPCB)
                                            {
                                                string pcbCode = rowDT["F4"].ToString();
                                                string pathPCB = pathLocal + "/" + pcbCode + "/";
                                                if (pathPCB == "") continue;
                                                Directory.CreateDirectory(pathPCB);

                                                string filePathServer = fileModel.FolderContain.Replace("tpat", "TPAT." + pcbCode.Substring(4, 7)).Replace("code", pcbCode);
                                                try
                                                {
                                                    //if (DocUtils.CheckExits(filePathServer))
                                                    //{
                                                    //    DocUtils.DownloadFile(pathPCB, Path.GetFileName(filePathServer), filePathServer);
                                                    //}
                                                    if (File.Exists(pathVersion + filePathServer))
                                                    {
                                                        File.Copy(pathVersion + filePathServer, pathPCB + filePathServer, true);
                                                    }
                                                }
                                                catch
                                                {
                                                }
                                            }
                                            #endregion
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        #region Phân bổ dữ liệu theo phiên bản trên nguồn
                        DocUtils.InitFTPQLSX();

                        #region Download 3D
                        if (Global.AppUserName.ToLower() == "dong.ld")
                        {
                            string file3D = string.Format("/Thietke.Ck/{0}/{1}.Ck/3D.{1}", moduleCode.Substring(0, 6), moduleCode);
                            TextUtils.DownloadFtpFolder(file3D, initPath + "/" + moduleCode);
                            continue;
                        }
                        #endregion                        

                        if (listStruc.Count > 0)
                        {
                            #region Lấy dữ liệu trong file danh mục vật tư cơ khí
                            try
                            {
                                if (DocUtils.CheckExits(serverPathCK + "/VT." + moduleCode + ".xlsm"))
                                {
                                    //Download file danh mục vật tư
                                    DocUtils.DownloadFile(initPath, "VT." + moduleCode + ".xlsm", serverPathCK + "/VT." + moduleCode + ".xlsm");
                                }
                                else
                                {
                                    errorList.Add(moduleCode + ": Chưa có trên nguồn thiết kế!");
                                }
                            }
                            catch
                            {
                            }

                            string pathDMVT = initPath + "/VT." + moduleCode + ".xlsm";
                            DataTable dtDMVT = TextUtils.ExcelToDatatable(pathDMVT, "DMVT");
                            if (dtDMVT.Rows.Count == 0) continue;
                            if (i == 0)
                            {
                                dtDMVT_Tong = dtDMVT;
                            }
                            else
                            {
                                dtDMVT_Tong.Merge(dtDMVT);
                            }

                            for (int j = 0; j <= 4; j++)
                            {
                                dtDMVT.Rows.RemoveAt(0);
                            }
                            File.Delete(pathDMVT);

                            #endregion

                            string local = "";

                            foreach (var item in listStruc)
                            {
                                PBDLStructureModel strucModel = (PBDLStructureModel)item;
                                string pathStruc = strucModel.Path.Replace("project", projectCode).Replace("product", productCode.Replace(" ", "").Trim())
                                    .Replace("code", moduleCode);
                                string pathLocal = initPath + "/" + pathStruc;
                                if (strucModel.ParentID == 0)
                                {
                                    local = pathLocal;
                                }
                                Directory.CreateDirectory(pathLocal);
                                DataTable dtFile = TextUtils.Select("vPBDL_Structure_File", new BMS.Utils.Expression("PBDLStructureID", strucModel.ID));

                                foreach (DataRow row in dtFile.Rows)
                                {
                                    int pBDLFileID = TextUtils.ToInt(row["PBDLFileID"]);
                                    PBDLFileModel fileModel = (PBDLFileModel)PBDLFileBO.Instance.FindByPK(pBDLFileID);
                                    string extension = fileModel.Extension;

                                    if (fileModel.GetType == 0)//nhieu file
                                    {
                                        string pathServer = fileModel.FolderContain.Replace("group", moduleCode.Substring(0, 6)).Replace("code", moduleCode);

                                        #region Mã vật liệu
                                        if (fileModel.FilterMaVatLieu)//nếu có mã vật liệu
                                        {
                                            DataRow[] listMaVatLieu = dtDMVT.Select("F5 <> '' and F4 like '%TPAD%' ");
                                            foreach (DataRow rowMVL in listMaVatLieu)
                                            {
                                                string fileName = rowMVL["F4"].ToString();
                                                try
                                                {
                                                    if (DocUtils.CheckExits(pathServer + "/" + fileName + extension))
                                                    {
                                                        DocUtils.DownloadFile(pathLocal, fileName + fileModel.Extension, pathServer + "/" + fileName + fileModel.Extension);
                                                    }
                                                }
                                                catch
                                                {
                                                }
                                            }
                                        }
                                        #endregion

                                        #region Đơn vị
                                        if (fileModel.FilterDonVi != "")
                                        {
                                            DataRow[] listDonVi = dtDMVT.Select("F6 like '%" + fileModel.FilterDonVi.ToUpper() + "%' and F4 like '%TPAD%' ");
                                            foreach (DataRow rowMVL in listDonVi)
                                            {
                                                string fileName = rowMVL["F4"].ToString();
                                                try
                                                {
                                                    if (DocUtils.CheckExits(pathServer + "/" + fileName + extension))
                                                    {
                                                        DocUtils.DownloadFile(pathLocal, fileName + fileModel.Extension, pathServer + "/" + fileName + fileModel.Extension);
                                                    }
                                                }
                                                catch
                                                {
                                                }
                                            }
                                        }
                                        #endregion Đơn vị

                                        #region Thông Số
                                        if (fileModel.FilterThongSo != "")
                                        {
                                            DataRow[] listThongSo;
                                            if (fileModel.ID == 51)//download bản vẽ sửa đổi
                                            {
                                                listThongSo = dtDMVT.Select("F4 like '%" + fileModel.FilterThongSo + "%' and F4 like '%TPAD%' ");
                                                foreach (DataRow r in listThongSo)
                                                {
                                                    string fileName = r["F4"].ToString() + extension;
                                                    if (DocUtils.CheckExits(pathServer + "/" + fileName))
                                                    {
                                                        DocUtils.DownloadFile(pathLocal, fileName, pathServer + "/" + fileName);
                                                    }
                                                }
                                            }
                                            listThongSo = dtDMVT.Select("F3 like '%" + fileModel.FilterThongSo.ToUpper() + "%' and F4 like '%TPAD%' ");
                                            List<string[]> listSTT = new List<string[]>();
                                            foreach (DataRow rowThongSo in listThongSo)
                                            {
                                                if (fileModel.FilterThongSo.ToUpper() == "HÀN")
                                                {
                                                    listSTT.Add(new string[] { rowThongSo["F1"].ToString(), rowThongSo["F2"].ToString(), rowThongSo["F4"].ToString() });
                                                }
                                                else
                                                {
                                                    string fileName = rowThongSo["F4"].ToString();
                                                    try
                                                    {
                                                        if (DocUtils.CheckExits(pathServer + "/" + fileName + extension))
                                                        {
                                                            DocUtils.DownloadFile(pathLocal, fileName + fileModel.Extension, pathServer + "/" + fileName + fileModel.Extension);
                                                        }
                                                    }
                                                    catch
                                                    {
                                                    }
                                                }
                                            }

                                            #region Thông số Hàn
                                            if (fileModel.FilterThongSo.ToUpper() == "HÀN")
                                            {
                                                if (listSTT.Count > 0)
                                                {
                                                    foreach (string[] han in listSTT)
                                                    {
                                                        string folderHan = pathLocal + "/" + han[0].ToString() + "-" + han[1].ToString();
                                                        Directory.CreateDirectory(folderHan);
                                                        if (DocUtils.CheckExits(pathServer + "/" + han[2] + extension))
                                                        {
                                                            DocUtils.DownloadFile(folderHan, han[2] + extension, pathServer + "/" + han[2] + extension);
                                                        }
                                                        DataRow[] listVatTu = dtDMVT.Select("F1 like '%" + han[0] + ".%'");
                                                        foreach (DataRow rowChild in listVatTu)
                                                        {
                                                            string fileName = rowChild["F4"].ToString();
                                                            try
                                                            {
                                                                if (DocUtils.CheckExits(pathServer + "/" + fileName + extension))
                                                                {
                                                                    DocUtils.DownloadFile(folderHan, fileName + fileModel.Extension, pathServer + "/" + fileName + fileModel.Extension);
                                                                }
                                                            }
                                                            catch
                                                            {
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            #endregion Thông số hàn
                                        }
                                        #endregion Thông Số

                                        #region MẶT
                                        if (fileModel.MAT)
                                        {
                                            try
                                            {
                                                string[] listFileMat = DocUtils.GetFilesList(pathServer);
                                                if (listFileMat != null)
                                                {
                                                    foreach (string fileName in listFileMat)
                                                    {
                                                        try
                                                        {
                                                            if (DocUtils.CheckExits(pathServer + "/" + fileName))
                                                            {
                                                                DocUtils.DownloadFile(pathLocal, fileName, pathServer + "/" + fileName);
                                                            }
                                                        }
                                                        catch
                                                        {
                                                        }
                                                    }
                                                }

                                            }
                                            catch
                                            {
                                            }
                                        }
                                        #endregion Mặt

                                        #region TEM
                                        if (fileModel.TEM)
                                        {
                                            try
                                            {
                                                string[] listFileTEM = DocUtils.GetFilesList(pathServer);
                                                if (listFileTEM != null)
                                                {
                                                    foreach (string fileName in listFileTEM)
                                                    {
                                                        try
                                                        {
                                                            if (DocUtils.CheckExits(pathServer + "/" + fileName))
                                                            {
                                                                DocUtils.DownloadFile(pathLocal, fileName, pathServer + "/" + fileName);
                                                            }
                                                        }
                                                        catch
                                                        {
                                                        }
                                                    }
                                                }

                                            }
                                            catch
                                            {
                                            }
                                        }
                                        #endregion TEM
                                    }
                                    else//1 file
                                    {
                                        if (strucModel.FolderType != 2)//nếu không phải là thư mục điện tử
                                        {
                                            string filePathServer = fileModel.FolderContain.Replace("group", moduleCode.Substring(0, 6)).Replace("code", moduleCode);
                                            try
                                            {
                                                if (DocUtils.CheckExits(filePathServer))
                                                {
                                                    DocUtils.DownloadFile(pathLocal, Path.GetFileName(filePathServer), filePathServer);
                                                }
                                            }
                                            catch
                                            {
                                            }
                                        }
                                        else
                                        {
                                            #region Download file trong thư mục điện tử
                                            DataRow[] listPCB = dtDMVT.Select("F4 like '%PCB%'");
                                            foreach (DataRow rowDT in listPCB)
                                            {
                                                string pcbCode = rowDT["F4"].ToString();
                                                string pathPCB = pathLocal + "/" + pcbCode;
                                                if (pathPCB == "") continue;
                                                Directory.CreateDirectory(pathPCB);

                                                string filePathServer = fileModel.FolderContain.Replace("tpat", "TPAT." + pcbCode.Substring(4, 7)).Replace("code", pcbCode);
                                                try
                                                {
                                                    if (DocUtils.CheckExits(filePathServer))
                                                    {
                                                        DocUtils.DownloadFile(pathPCB, Path.GetFileName(filePathServer), filePathServer);
                                                    }
                                                }
                                                catch
                                                {
                                                }
                                            }
                                            #endregion
                                        }
                                    }
                                }
                            }
                        }
                        #endregion Phân bổ dữ liệu theo phiên bản trên nguồn
                    }
                }
            }
            if (errorList.Count > 0)
            {
                string contentMes = "";
                foreach (string item in errorList)
                {
                    contentMes += item + Environment.NewLine;
                }
                MessageBox.Show(contentMes, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (Global.AppUserName.ToLower() == "dong.ld")
            {
                MessageBox.Show("Lấy dữ liệu phân bổ thành công!", TextUtils.Caption);
            }
            else
            {
                //Gộp danh mục vật tư
                if (Global.DepartmentID == 3)//Phong ke toan
                {
                    #region Gộp file danh mục vật tư cho phòng kế toán
                    using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo file DMVT tổng hợp"))
                    {
                        DataColumn col = new DataColumn();
                        col.DefaultValue = "";
                        dtDMVT_Tong.Columns.Add(col);
                        string[] listFilePCB = Directory.GetFiles(initPath + "\\" + projectCode, "VT.PCB*", SearchOption.AllDirectories);
                        foreach (string item in listFilePCB)
                        {
                            string fileName = Path.GetFileNameWithoutExtension(item).Replace("VT.", "");
                            DataTable dtDMVT1 = TextUtils.ExcelToDatatable(item, "DMVT");
                            DataColumn col1 = new DataColumn();
                            col1.DefaultValue = fileName;
                            dtDMVT1.Columns.Add(col1);
                            dtDMVT_Tong.Merge(dtDMVT1);
                        }
                        if (dtDMVT_Tong.Rows.Count > 0)
                        {
                            var results = from myRow in dtDMVT_Tong.AsEnumerable()
                                          where TextUtils.ToDecimal(myRow.Field<string>("F1") != "" && myRow.Field<string>("F1") != null ? myRow.Field<string>("F1").Substring(0, 1) : "") > 0
                                          select myRow;
                            if (results.Count() >= 0)
                            {
                                dtDMVT_Tong = results.CopyToDataTable();
                            }
                            try
                            {
                                string fileTH = initPath + "\\" + projectCode + "\\" + projectCode + "-DMVT.csv";
                                dtDMVT_Tong.Columns[0].Caption = "STT";
                                dtDMVT_Tong.Columns[1].Caption = "TÊN VẬT TƯ";
                                dtDMVT_Tong.Columns[2].Caption = "THÔNG SỐ";
                                dtDMVT_Tong.Columns[3].Caption = "MÃ VẬT TƯ";
                                dtDMVT_Tong.Columns[4].Caption = "MÃ VẬT LIỆU";
                                dtDMVT_Tong.Columns[5].Caption = "ĐV";
                                dtDMVT_Tong.Columns[6].Caption = "SL";
                                dtDMVT_Tong.Columns[7].Caption = "VL";
                                dtDMVT_Tong.Columns[8].Caption = "KL";
                                dtDMVT_Tong.Columns[9].Caption = "HÃNG SX";
                                dtDMVT_Tong.Columns[10].Caption = "GHI CHÚ";
                                TextUtils.DatatableToCSV(dtDMVT_Tong, fileTH);
                            }
                            catch (Exception ex1)
                            {
                                MessageBox.Show("Có lỗi khi tạo file DMVT tổng hợp!\n" + ex1.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    #endregion
                }
                Process.Start("explorer.exe", "/select, " + initPath + "\\" + projectCode);
            }
        }

        void loadYCMVT()
        {
            DataTable dtYC = new DataTable();
            
            if (Global.AppUserName == "khoi.pd" || Global.AppUserName == "thao.nv")
            {
                dtYC =
                    LibQLSX.Select("SELECT * FROM vGetYCMVT1 where [ManufacturerCode] = 'TPA' and Status = " +
                                   cboYcmvtType.SelectedIndex + " ORDER BY ProposalId");
            }
            else
            {
                if (Global.DepartmentID == 6) //phòng vật tư
                {
                    dtYC =
                        LibQLSX.Select("SELECT * FROM vGetYCMVT1 where account = '" + Global.AppUserName +
                                       "' and [ManufacturerCode] = 'TPA' and Status = " + cboYcmvtType.SelectedIndex +
                                       " ORDER BY ProposalId");
                }
            }
            grdYC.DataSource = null;
            grdYC.DataSource = dtYC;
        }

        void loadParts(string proposalCode)
        {
            DataTable dtP = LibQLSX.Select(" SELECT [PartsCode],[PartsName],[TotalBuy],[Unit],[Specifications],[ProjectModuleCode] FROM vRequireBuyPart where ProposalCode = '" + proposalCode + "'");
            grdYCDetail.DataSource = null;
            grdYCDetail.DataSource = dtP;
        }

        DataTable loadPartOfYCMVT(string proposalCode)
        {
            string[] paraName = new string[1];
            object[] paraValue = new object[1];
            paraName[0] = "@ListYCMVT"; paraValue[0] = proposalCode;
            DataTable Source = TPA.Business.SuppliersBO.Instance.LoadDataFromSP("spGetPartWithYCMVT1", "Source", paraName, paraValue);
            DataTable dt = Source.Copy();
            dt.Rows.Clear();
            foreach (DataRow row in Source.Rows)
            {
                string code = TextUtils.ToString(row["PartsCode"]);
                decimal qty = TextUtils.ToDecimal(row["TotalBuy"]);

                DataRow[] drs = dt.Select("PartsCode = '" + code + "'");
                if (drs.Length == 0)
                {
                    dt.ImportRow(row);
                }
                else
                {
                    drs[0]["TotalBuy"] = TextUtils.ToDecimal(drs[0]["TotalBuy"]) + qty;
                    //drs[0]["TotalPrice"] = TextUtils.ToDecimal(drs[0]["TotalBuy"]) * TextUtils.ToDecimal(drs[0]["Price"]);
                }
            }
            return dt;
        }
        #endregion

        #region Events
        private void cboProduct_EditValueChanged(object sender, EventArgs e)
        {
            grdModule.DataSource = null;
            //string productID = grvProduct.GetFocusedRowCellValue(colProductID) == null ? "" : grvProduct.GetFocusedRowCellValue(colProductID).ToString();
            //string productCode = grvProduct.GetFocusedRowCellValue(colMaThietBi) == null ? "" : grvProduct.GetFocusedRowCellValue(colMaThietBi).ToString();
            //string productName = grvProduct.GetFocusedRowCellValue(colTenThietBi) == null ? "" : grvProduct.GetFocusedRowCellValue(colTenThietBi).ToString();

            //if (productID != "")
            //{
            //    try
            //    {
            //        string[] paraName = new string[1];
            //        string[] paraValue = new string[1];
            //        paraName[0] = "@ProductID"; paraValue[0] = productID;
            //        DataTable tbl = ModulesBO.Instance.LoadDataFromSP("spGetModuleOfProduct", "Modules", paraName, paraValue);
            //        tbl.Columns.Add("check", typeof(bool));

            //        if (productCode.StartsWith("TPAD.") && productCode.Length == 10)
            //        {
            //            tbl.Rows.Add(productCode, productName, productCode + " - " + productName);
            //        }
            //        //grvData.DataSource = tbl;
            //        grdModule.DataSource = tbl;
            //    }
            //    catch
            //    {
            //        //grvData.DataSource = null;
            //        grdModule.DataSource = null;
            //    }
            //}
            //else
            //{
            //    //grvData.DataSource = null;
            //    grdModule.DataSource = null;
            //}
        }

        private void cboProject_EditValueChanged(object sender, EventArgs e)
        {
            grdModule.DataSource = null;
            loadProducts();
            //if (chkDownloadOnlyModule.Checked)
            //{
            //    loadModules1();
            //}            
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            frmDataManagement frm = new frmDataManagement();
            TextUtils.OpenForm(frm);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            grvModule.FocusedRowHandle = -1;
            PhanBoOnlyModule();
        }

        private void chkCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCheckAll.Checked)
            {
                //foreach (DataGridViewRow item in grvData.Rows)
                //{
                //    item.Cells[0].Value = true;
                //}
                for (int i = 0; i < grvModule.RowCount; i++)
                {
                    grvModule.SetRowCellValue(i, gridColumn1, true);
                }
            }
            else
            {
                //foreach (DataGridViewRow item in grvData.Rows)
                //{
                //    item.Cells[0].Value = false;
                //}
                for (int i = 0; i < grvModule.RowCount; i++)
                {
                    grvModule.SetRowCellValue(i, gridColumn1, false);
                }
            }
        }

        private void chkDownloadOnlyModule_CheckedChanged(object sender, EventArgs e)
        {
            cboProduct.Enabled = !chkDownloadOnlyModule.Checked;
        }
        #endregion
        
        private void btnDownload_Click(object sender, EventArgs e)
        {
            grvModule.FocusedRowHandle = -1;
            PhanBoOnlyModule();
        }

        private void grvYC_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string proposalCode = TextUtils.ToString(grvYC.GetFocusedRowCellValue(colCode));
            if (proposalCode != "")
            {
                loadParts(proposalCode);
            }
        }

        void PhanBoDL_PhongVatTu()
        {
            grvYC.FocusedRowHandle = -1;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            string folderPath = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = Settings.Default.VT_DownloadPath;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                folderPath = fbd.SelectedPath;
                Settings.Default.VT_DownloadPath = fbd.SelectedPath;
                Settings.Default.Save();
            }
            else
            {
                return;
            }

            DocUtils.InitFTPQLSX();

            int all = 0;
            int count = 0;
            bool isCreatedYCBG = false;
            _dtFile.Rows.Clear();

            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng đợi trong giây lát...", "Đang download dữ liệu.."))
            {
                string filePathT = Application.StartupPath + "\\Templates\\FileYCBG_Detail.xls";
                try
                {
                    File.Copy(filePathT, folderPath + "\\Bao gia tong hop.xls", true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: File báo giá tổng hợp dạng excel đang được mở.\n" + ex.Message);
                    return;
                }

                Excel.Application app1 = default(Excel.Application);
                Excel.Workbook workBoook1 = default(Excel.Workbook);
                Excel.Worksheet workSheet1 = default(Excel.Worksheet);

                app1 = new Excel.Application();
                app1.Workbooks.Open(folderPath + "\\Bao gia tong hop.xls");
                workBoook1 = app1.Workbooks[1];
                workSheet1 = (Excel.Worksheet)workBoook1.Worksheets[1];

                workSheet1.Cells[6, 2] = Global.AppUserName + ".@tpa.com.vn";
                workSheet1.Cells[7, 2] = Global.AppFullName;

                int countFileAttack = 0;
                for (int i = 0; i < grvYC.RowCount; i++)
                {
                    bool check = TextUtils.ToBoolean(grvYC.GetRowCellValue(i, colCheck));
                    if (!check) continue;

                    string proposalCode = TextUtils.ToString(grvYC.GetRowCellValue(i, colCode));
                    string projectCode = TextUtils.ToString(grvYC.GetRowCellValue(i, colProjectCodeVT));

                    string[] paraName = new string[1];
                    object[] paraValue = new object[1];
                    paraName[0] = "@ListYCMVT"; paraValue[0] = proposalCode;
                    DataTable dtParts = loadPartOfYCMVT(proposalCode);

                    string path = folderPath + "//" + proposalCode + "-" + projectCode;
                    Directory.CreateDirectory(path);

                    all += dtParts.Rows.Count;

                    #region Download bản vẽ
                    foreach (DataRow row in dtParts.Rows)
                    {
                        string partCode = TextUtils.ToString(row["PartsCode"]);
                        if (partCode == "") continue;
                        string thongSoPart = TextUtils.ToString(row["Specifications"]).ToUpper();                        
                        string moduleCode = TextUtils.ToString(row["ProjectModuleCode"]);
                        string indexPart = "";
                        if (partCode.StartsWith("TPAD"))
                        {
                            if (thongSoPart == "HÀN")
                            {
                                #region Download chi tiết hàn
                                string dmvtFilePath = "Thietke.Ck/" + moduleCode.Substring(0, 6) + "/" + moduleCode + ".Ck/VT."
                                    + moduleCode + ".xlsm";
                                if (DocUtils.CheckExits(dmvtFilePath))
                                {
                                    DocUtils.DownloadFile(path, Path.GetFileName(dmvtFilePath), dmvtFilePath);
                                }
                                string pathDMVT = path + "/" + Path.GetFileName(dmvtFilePath);
                                DataTable dtDMVT = TextUtils.ExcelToDatatableNoHeader(pathDMVT, "DMVT");
                                if (File.Exists(pathDMVT))
                                {
                                    File.Delete(pathDMVT);
                                }

                                //Get stt cua vat tu han
                                DataRow[] drsIndex = dtDMVT.Select("F4 ='" + partCode + "'");
                                if (drsIndex.Length > 0) 
                                    indexPart = TextUtils.ToString(drsIndex[0]["F1"]);                                
                                ////////////////////////////////////////////////////////

                                //download file cad vat tu han
                                string ftpPath = string.Format("/Thietke.Ck/{0}/{1}.Ck/CAD.{1}/",
                                    moduleCode.Substring(0, 6), moduleCode);
                                if (DocUtils.CheckExits(ftpPath + partCode + ".dwg"))
                                {
                                    DocUtils.DownloadFile(path, partCode + ".dwg", ftpPath + partCode + ".dwg");
                                }

                                string ftpPathBC = string.Format("/Thietke.Ck/{0}/{1}.Ck/BCCk.{1}/BC-CAD.{1}/",
                                    moduleCode.Substring(0, 6), moduleCode);
                                //string ftpPathBC = string.Format("/Thietke.Ck/{0}/{1}.Ck/BCCk.{1}/BC-CAD.{1}/{2}.jpg",
                                //    moduleCode.Substring(0, 6), moduleCode, partCode);
                                if (DocUtils.CheckExits(ftpPathBC + partCode + ".jpg"))
                                {
                                    DocUtils.DownloadFile(path, partCode + ".jpg", ftpPathBC + partCode + ".jpg");
                                }
                                /////////////////////////////////////////////////////

                                //download cac vat tu con cua cum han
                                DataRow[] drs = dtDMVT.Select("F1 like '" + indexPart + ".%' and F4 like 'TPAD.%'");
                                foreach (DataRow row1 in drs)
                                {
                                    string code = TextUtils.ToString(row1["F4"]);
                                    string ftpCadFile = ftpPath + code + ".dwg";
                                    if (DocUtils.CheckExits(ftpCadFile))
                                    {
                                        DocUtils.DownloadFile(path, Path.GetFileName(ftpCadFile), ftpCadFile);
                                    }

                                    string ftpCadFileBC = ftpPathBC + code + ".jpg";
                                    if (DocUtils.CheckExits(ftpCadFileBC))
                                    {
                                        DocUtils.DownloadFile(path, Path.GetFileName(ftpCadFileBC), ftpCadFileBC);
                                    }

                                    if (code == partCode)
                                    {
                                        count++;
                                    }
                                }
                                //////////////////////////////////////////////
                                #endregion
                            }
                            else
                            {
                                string ftpPath = string.Format("/Thietke.Ck/{0}/{1}.Ck/CAD.{1}/{2}.dwg",
                                    moduleCode.Substring(0, 6), moduleCode, partCode);                                
                                if (DocUtils.CheckExits(ftpPath))
                                {
                                    DocUtils.DownloadFile(path, Path.GetFileName(ftpPath), ftpPath);
                                    count++;
                                }

                                string ftpPathBC = string.Format("/Thietke.Ck/{0}/{1}.Ck/BCCk.{1}/BC-CAD.{1}/{2}.jpg",
                                    moduleCode.Substring(0, 6), moduleCode, partCode);
                                if (DocUtils.CheckExits(ftpPathBC))
                                {
                                    DocUtils.DownloadFile(path, Path.GetFileName(ftpPathBC), ftpPathBC);
                                }
                            }
                        }
                        if (partCode.StartsWith("TPAT"))
                        {
                            #region Download chi tiết mạch
                            string code = partCode.Substring(5, 7);
                            string ftpPath = string.Format("/Thietke.Dt/PCB/PCB.{0}/PRD.PCB.{0}/{1}.PcbDoc",
                                code, partCode);
                            if (DocUtils.CheckExits(ftpPath))
                            {
                                DocUtils.DownloadFile(path, Path.GetFileName(ftpPath), ftpPath);
                                count++;
                            }
                            #endregion
                        }
                    }
                    #endregion

                    #region Tạo file yêu cầu báo giá
                    string filePath = Application.StartupPath + "\\Templates\\FileYCBG.xls";
                    try
                    {
                        File.Copy(filePath, path + "\\" + proposalCode + ".xls", true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: File excel đang được mở.\n" + ex.Message);
                        return;
                    }

                    Excel.Application app = default(Excel.Application);
                    Excel.Workbook workBoook = default(Excel.Workbook);
                    Excel.Worksheet workSheet = default(Excel.Worksheet);
                    try
                    {
                        app = new Excel.Application();
                        app.Workbooks.Open(path + "\\" + proposalCode + ".xls");
                        workBoook = app.Workbooks[1];
                        workSheet = (Excel.Worksheet)workBoook.Worksheets[1];

                        int countPart = 0;
                        for (int j = dtParts.Rows.Count - 1; j >= 0; j--)
                        {
                            string partCode = TextUtils.ToString(dtParts.Rows[j]["PartsCode"]);
                            decimal totalBuy = TextUtils.ToDecimal(dtParts.Compute("sum(TotalBuy)", "PartsCode = '" + partCode + "'"));
                            countPart++;
                            workSheet.Cells[5, 1] = j + 1;
                            workSheet.Cells[5, 2] = TextUtils.ToString(dtParts.Rows[j]["PartsName"]);
                            workSheet.Cells[5, 3] = TextUtils.ToString(dtParts.Rows[j]["PartsCode"]);
                            workSheet.Cells[5, 4] = totalBuy.ToString("n2");
                            workSheet.Cells[5, 5] = TextUtils.ToString(dtParts.Rows[j]["Unit"]);
                            workSheet.Cells[5, 6] = TextUtils.ToString(dtParts.Rows[j]["ManufacturerCode"]);
                            workSheet.Cells[5, 7] = TextUtils.ToString(dtParts.Rows[j]["Specifications"]);
                            ((Excel.Range)workSheet.Rows[5]).Insert();

                            workSheet1.Cells[14, 1] = j + 1;
                            workSheet1.Cells[14, 2] = TextUtils.ToString(dtParts.Rows[j]["PartsName"]);
                            workSheet1.Cells[14, 3] = TextUtils.ToString(dtParts.Rows[j]["PartsCode"]);
                            workSheet1.Cells[14, 4] = totalBuy.ToString("n0");
                            workSheet1.Cells[14, 5] = TextUtils.ToString(dtParts.Rows[j]["Unit"]);
                            //workSheet1.Cells[14, 6] = TextUtils.ToString(dtParts.Rows[j]["ManufacturerCode"]);
                            //workSheet1.Cells[14, 7] = TextUtils.ToString(dtParts.Rows[j]["Specifications"]);
                            workSheet1.Cells[14, 8] = proposalCode;
                            ((Excel.Range)workSheet1.Rows[14]).Insert();
                        }


                        ((Excel.Range)workSheet.Rows[4]).Delete();
                        ((Excel.Range)workSheet.Rows[4]).Delete();
                        isCreatedYCBG = true;

                        //((Excel.Range)workSheet1.Rows[14]).Insert();
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
                            workSheet = null;
                            workBoook = null;
                            app.Workbooks.Close();
                            app.Quit();
                        }
                    }
                    #endregion


                    TextUtils.ZipFolder(path);
                    if (File.Exists(path + ".zip"))
                    {
                        _dtFile.Rows.Add(i, Path.GetFileName(path + ".zip"), path + ".zip ");
                        countFileAttack = i;
                    }

                    ((Excel.Range)workSheet1.Rows[14]).Insert();
                }

                ((Excel.Range)workSheet1.Rows[13]).Delete();
                ((Excel.Range)workSheet1.Rows[13]).Delete();
                ((Excel.Range)workSheet1.Rows[13]).Delete();

                if (app1 != null)
                {
                    app1.ActiveWorkbook.Save();
                    workSheet1 = null;
                    workBoook1 = null;
                    app1.Workbooks.Close();
                    app1.Quit();
                }
                //if (File.Exists(folderPath + "\\Bao gia tong hop.xls"))
                //{
                //    _dtFile.Rows.Add(countFileAttack + 1, "Bao gia tong hop.xls", folderPath + "\\Bao gia tong hop.xls");
                //}
            }
            if (count >= all && isCreatedYCBG)
            {
                DialogResult result = MessageBox.Show("Download các bản vẽ thành công!\nBạn có muốn gửi mail những thông tin trên đến nhà cung cấp không?", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    frmSendYCBG frm = new frmSendYCBG();
                    frm.DtFile = _dtFile;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        #region Update trạng thái gửi mail
                        if (frm.IsSent)
                        {
                            for (int i = 0; i < grvYC.RowCount; i++)
                            {
                                bool check = TextUtils.ToBoolean(grvYC.GetRowCellValue(i, colCheck));
                                if (!check) continue;
                                string proposalCode = TextUtils.ToString(grvYC.GetRowCellValue(i, colCode));

                                ProposalSentStatusModel model = new ProposalSentStatusModel();
                                model.DateSent = DateTime.Now;
                                model.ProposalCode = proposalCode;
                                model.UserFrom = Global.AppUserName;
                                model.UserTo = frm.SentTo;
                                ProposalSentStatusBO.Instance.Insert(model);

                                grvYC.SetRowCellValue(i, colIsSend, true);
                            }
                        }
                        #endregion
                    }
                }
            }
            else
            {
                MessageBox.Show("Download thành công " + Environment.NewLine + count + "/" + all + " vật tư", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void downloadFile(DataTable dtParts, string path, int count)
        {
            #region Download bản vẽ
            foreach (DataRow row in dtParts.Rows)
            {
                string partCode = TextUtils.ToString(row["PartsCode"]);
                if (partCode == "") continue;
                string thongSoPart = TextUtils.ToString(row["Specifications"]).ToUpper();
                string indexPart = TextUtils.ToString(row["IndexPart"]);
                string moduleCode = TextUtils.ToString(row["ProjectModuleCode"]);

                if (partCode.StartsWith("TPAD"))
                {
                    if (thongSoPart == "HÀN")
                    {
                        #region Download chi tiết hàn
                        string dmvtFilePath = "Thietke.Ck/" + moduleCode.Substring(0, 6) + "/" + moduleCode + ".Ck/VT."
                            + moduleCode + ".xlsm";
                        if (DocUtils.CheckExits(dmvtFilePath))
                        {
                            DocUtils.DownloadFile(path, Path.GetFileName(dmvtFilePath), dmvtFilePath);
                        }
                        string pathDMVT = path + "/" + Path.GetFileName(dmvtFilePath);
                        DataTable dtDMVT = TextUtils.ExcelToDatatableNoHeader(pathDMVT, "DMVT");
                        if (File.Exists(pathDMVT))
                        {
                            File.Delete(pathDMVT);
                        }

                        string ftpPath = string.Format("/Thietke.Ck/{0}/{1}.Ck/CAD.{1}/",
                            moduleCode.Substring(0, 6), moduleCode);
                        if (DocUtils.CheckExits(ftpPath + partCode + ".dwg"))
                        {
                            DocUtils.DownloadFile(path, partCode + ".dwg", ftpPath + partCode + ".dwg");
                        }

                        DataRow[] drs = dtDMVT.Select("F1 like '" + indexPart + ".%' and F4 like 'TPAD.%'");
                        foreach (DataRow row1 in drs)
                        {
                            string code = TextUtils.ToString(row1["F4"]);
                            string ftpCadFile = ftpPath + code + ".dwg";
                            if (DocUtils.CheckExits(ftpCadFile))
                            {
                                DocUtils.DownloadFile(path, Path.GetFileName(ftpCadFile), ftpCadFile);
                            }
                            if (code == partCode)
                            {
                                count++;
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        string ftpPath = string.Format("/Thietke.Ck/{0}/{1}.Ck/CAD.{1}/{2}.dwg",
                            moduleCode.Substring(0, 6), moduleCode, partCode);
                        if (DocUtils.CheckExits(ftpPath))
                        {
                            DocUtils.DownloadFile(path, Path.GetFileName(ftpPath), ftpPath);
                            count++;
                        }
                    }
                }
                if (partCode.StartsWith("TPAT"))
                {
                    #region Download chi tiết mạch
                    string code = partCode.Substring(5, 7);
                    string ftpPath = string.Format("/Thietke.Dt/PCB/PCB.{0}/PRD.PCB.{0}/{1}.PcbDoc",
                        code, partCode);
                    if (DocUtils.CheckExits(ftpPath))
                    {
                        DocUtils.DownloadFile(path, Path.GetFileName(ftpPath), ftpPath);
                        count++;
                    }
                    #endregion
                }
            }
            #endregion
        }

        void downloadFileWithVersion(DataTable dtParts, string path, int count)
        {
            foreach (DataRow row in dtParts.Rows)
            {
                string partCode = TextUtils.ToString(row["PartsCode"]);
                if (partCode == "") continue;
                string thongSoPart = TextUtils.ToString(row["Specifications"]).ToUpper();
                string indexPart = TextUtils.ToString(row["IndexPart"]);
                string moduleCode = TextUtils.ToString(row["ProjectModuleCode"]);
                string projectCode = TextUtils.ToString(row["ProjectCode"]);

                DataTable dtModuleVersion = TextUtils.Select("select top 1 * from [ModuleVersion] with(nolock) where ModuleCode = '"
                    + moduleCode + "' and ProjectCode = '" + projectCode + "' order by Version desc");
                if (dtModuleVersion.Rows.Count > 0)
                {
                    int version = TextUtils.ToInt(dtModuleVersion.Rows[0]["Version"]);
                    string pathVersion = string.Format("W:\\ModuleVersion\\{0}\\{1}", moduleCode, version);

                    if (version > 0)
                    {
                        if (partCode.StartsWith("TPAD"))
                        {
                            if (thongSoPart == "HÀN")
                            {
                                #region Download chi tiết hàn
                                string dmvtFilePath = pathVersion + "/Thietke.Ck/" + moduleCode.Substring(0, 6) + "/" + moduleCode + ".Ck/VT."
                                    + moduleCode + ".xlsm";
                                DataTable dtDMVT = TextUtils.ExcelToDatatableNoHeader(dmvtFilePath, "DMVT");

                                string sourcePath = string.Format(pathVersion + "/Thietke.Ck/{0}/{1}.Ck/CAD.{1}/",
                                    moduleCode.Substring(0, 6), moduleCode);
                                if (File.Exists(sourcePath + partCode + ".dwg"))
                                {
                                    File.Copy(sourcePath + partCode + ".dwg", path + "/" + partCode + ".dwg");
                                }

                                DataRow[] drs = dtDMVT.Select("F1 like '" + indexPart + ".%' and F4 like 'TPAD.%'");
                                foreach (DataRow row1 in drs)
                                {
                                    string code = TextUtils.ToString(row1["F4"]);
                                    string sourceCadFile = sourcePath + code + ".dwg";
                                    if (File.Exists(sourceCadFile))
                                    {
                                        File.Copy(sourceCadFile, path + "/" + Path.GetFileName(sourceCadFile));
                                    }
                                    if (code == partCode)
                                    {
                                        count++;
                                    }
                                }
                                #endregion
                            }
                            else
                            {
                                #region Download chi tiet CG, GCCX
                                string sourcePath = string.Format(pathVersion + "/Thietke.Ck/{0}/{1}.Ck/CAD.{1}/{2}.dwg",
                                    moduleCode.Substring(0, 6), moduleCode, partCode);
                                if (File.Exists(sourcePath))
                                {
                                    File.Copy(sourcePath, path + "/" + Path.GetFileName(sourcePath));
                                    count++;
                                }
                                #endregion
                            }
                        }
                        if (partCode.StartsWith("TPAT"))
                        {
                            #region Download chi tiết mạch
                            string code = partCode.Substring(5, 7);
                            string sourceFilePath = string.Format(pathVersion + "/Thietke.Dt/PCB/PCB.{0}/PRD.PCB.{0}/{1}.PcbDoc",
                                code, partCode);
                            if (File.Exists(sourceFilePath))
                            {
                                File.Copy(sourceFilePath, path + "/" + Path.GetFileName(sourceFilePath));
                                count++;
                            }
                            #endregion
                        }
                    }
                    else
                    {
                    }
                }
            }
        }

        private void btnDownloadVT_Click(object sender, EventArgs e)
        {
            PhanBoDL_PhongVatTu();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabPageVT)
            {
                //using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát..", "Đang load dữ liệu..."))
                //{
                cboYcmvtType.SelectedIndex = 2;
                //    //loadYCMVT();
                //}
            }
        }

        private void btnMailHistory_Click(object sender, EventArgs e)
        {
            string code = TextUtils.ToString(grvYC.GetFocusedRowCellValue(colCode));
            if (code != "")
            {
                frmMailHistory frm = new frmMailHistory();
                frm.ProposalCode = code;
                frm.Show();
            }            
        }

        private void btnDownloadWithVersion_Click(object sender, EventArgs e)
        {
            PhanBoOnlyModule_WithVersion();
        }

        private void cboYcmvtType_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát..", "Đang load dữ liệu..."))
            {
                loadYCMVT();
            }
        }

        private void btnDownloadCK_Click(object sender, EventArgs e)
        {
            grvYC.FocusedRowHandle = -1;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            string folderPath = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = Settings.Default.VT_DownloadPath;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                folderPath = fbd.SelectedPath;
                Settings.Default.VT_DownloadPath = fbd.SelectedPath;
                Settings.Default.Save();
            }
            else
            {
                return;
            }

            DocUtils.InitFTPQLSX();

            int all = 0;
            int count = 0;
            bool isCreatedYCBG = true;
            _dtFile.Rows.Clear();

            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng đợi trong giây lát...", "Đang download dữ liệu.."))
            {
                string filePathT = Application.StartupPath + "\\Templates\\FileYCBG_Detail.xls";
                try
                {
                    File.Copy(filePathT, folderPath + "\\Bao gia tong hop.xls", true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: File báo giá tổng hợp dạng excel đang được mở.\n" + ex.Message);
                    return;
                }

                Excel.Application app1 = default(Excel.Application);
                Excel.Workbook workBoook1 = default(Excel.Workbook);
                Excel.Worksheet workSheet1 = default(Excel.Worksheet);

                app1 = new Excel.Application();
                app1.Workbooks.Open(folderPath + "\\Bao gia tong hop.xls");
                workBoook1 = app1.Workbooks[1];
                workSheet1 = (Excel.Worksheet)workBoook1.Worksheets[1];

                workSheet1.Cells[6, 2] = Global.AppUserName + ".@tpa.com.vn";
                workSheet1.Cells[7, 2] = Global.AppFullName;

                int countFileAttack = 0;
                for (int i = 0; i < grvYC.RowCount; i++)
                {
                    bool check = TextUtils.ToBoolean(grvYC.GetRowCellValue(i, colCheck));
                    if (!check) continue;

                    string proposalCode = TextUtils.ToString(grvYC.GetRowCellValue(i, colCode));
                    string projectCode = TextUtils.ToString(grvYC.GetRowCellValue(i, colProjectCodeVT));

                    string[] paraName = new string[1];
                    object[] paraValue = new object[1];
                    paraName[0] = "@ListYCMVT"; paraValue[0] = proposalCode;
                    DataTable dtParts = loadPartOfYCMVT(proposalCode);

                    string path = folderPath + "//" + proposalCode + "-" + projectCode;
                    Directory.CreateDirectory(path);

                    all += dtParts.Rows.Count;

                    #region Download bản vẽ
                    foreach (DataRow row in dtParts.Rows)
                    {
                        string partCode = TextUtils.ToString(row["PartsCode"]);
                        if (partCode == "") continue;
                        string thongSoPart = TextUtils.ToString(row["Specifications"]).ToUpper();
                        string moduleCode = TextUtils.ToString(row["ProjectModuleCode"]);
                        string indexPart = "";
                        if (partCode.StartsWith("TPAD"))
                        {
                            if (thongSoPart == "HÀN")
                            {
                                #region Download chi tiết hàn
                                string dmvtFilePath = "Thietke.Ck/" + moduleCode.Substring(0, 6) + "/" + moduleCode + ".Ck/VT."
                                    + moduleCode + ".xlsm";
                                if (DocUtils.CheckExits(dmvtFilePath))
                                {
                                    DocUtils.DownloadFile(path, Path.GetFileName(dmvtFilePath), dmvtFilePath);
                                }
                                string pathDMVT = path + "/" + Path.GetFileName(dmvtFilePath);
                                DataTable dtDMVT = TextUtils.ExcelToDatatableNoHeader(pathDMVT, "DMVT");
                                if (File.Exists(pathDMVT))
                                {
                                    File.Delete(pathDMVT);
                                }

                                //Get stt cua vat tu han
                                DataRow[] drsIndex = dtDMVT.Select("F4 ='" + partCode + "'");
                                if (drsIndex.Length > 0)
                                    indexPart = TextUtils.ToString(drsIndex[0]["F1"]);
                                ////////////////////////////////////////////////////////

                                //download file cad vat tu han
                                string ftpPath = string.Format("/Thietke.Ck/{0}/{1}.Ck/CAD.{1}/",
                                    moduleCode.Substring(0, 6), moduleCode);
                                if (DocUtils.CheckExits(ftpPath + partCode + ".dwg"))
                                {
                                    DocUtils.DownloadFile(path, partCode + ".dwg", ftpPath + partCode + ".dwg");
                                }

                                string ftpPathBC = string.Format("/Thietke.Ck/{0}/{1}.Ck/BCCk.{1}/BC-CAD.{1}/",
                                    moduleCode.Substring(0, 6), moduleCode);
                                //string ftpPathBC = string.Format("/Thietke.Ck/{0}/{1}.Ck/BCCk.{1}/BC-CAD.{1}/{2}.jpg",
                                //    moduleCode.Substring(0, 6), moduleCode, partCode);
                                if (DocUtils.CheckExits(ftpPathBC + partCode + ".jpg"))
                                {
                                    DocUtils.DownloadFile(path, partCode + ".jpg", ftpPathBC + partCode + ".jpg");
                                }
                                /////////////////////////////////////////////////////

                                //download cac vat tu con cua cum han
                                DataRow[] drs = dtDMVT.Select("F1 like '" + indexPart + ".%' and F4 like 'TPAD.%'");
                                foreach (DataRow row1 in drs)
                                {
                                    string code = TextUtils.ToString(row1["F4"]);
                                    string ftpCadFile = ftpPath + code + ".dwg";
                                    if (DocUtils.CheckExits(ftpCadFile))
                                    {
                                        DocUtils.DownloadFile(path, Path.GetFileName(ftpCadFile), ftpCadFile);
                                    }

                                    string ftpCadFileBC = ftpPathBC + code + ".jpg";
                                    if (DocUtils.CheckExits(ftpCadFileBC))
                                    {
                                        DocUtils.DownloadFile(path, Path.GetFileName(ftpCadFileBC), ftpCadFileBC);
                                    }

                                    if (code == partCode)
                                    {
                                        count++;
                                    }
                                }
                                //////////////////////////////////////////////
                                #endregion
                            }
                            else
                            {
                                string ftpPath = string.Format("/Thietke.Ck/{0}/{1}.Ck/CAD.{1}/{2}.dwg",
                                    moduleCode.Substring(0, 6), moduleCode, partCode);
                                if (DocUtils.CheckExits(ftpPath))
                                {
                                    DocUtils.DownloadFile(path, Path.GetFileName(ftpPath), ftpPath);
                                    count++;
                                }

                                string ftpPathBC = string.Format("/Thietke.Ck/{0}/{1}.Ck/BCCk.{1}/BC-CAD.{1}/{2}.jpg",
                                    moduleCode.Substring(0, 6), moduleCode, partCode);
                                if (DocUtils.CheckExits(ftpPathBC))
                                {
                                    DocUtils.DownloadFile(path, Path.GetFileName(ftpPathBC), ftpPathBC);
                                }
                            }
                        }
                        if (partCode.StartsWith("TPAT"))
                        {
                            #region Download chi tiết mạch
                            string code = partCode.Substring(5, 7);
                            string ftpPath = string.Format("/Thietke.Dt/PCB/PCB.{0}/PRD.PCB.{0}/{1}.PcbDoc",
                                code, partCode);
                            if (DocUtils.CheckExits(ftpPath))
                            {
                                DocUtils.DownloadFile(path, Path.GetFileName(ftpPath), ftpPath);
                                count++;
                            }
                            #endregion
                        }
                    }
                    #endregion

                    #region Tạo file yêu cầu báo giá
                    string filePath = Application.StartupPath + "\\Templates\\PhongVT\\YCMVT_CK.xls";

                    try
                    {
                        File.Copy(filePath, path + "\\" + proposalCode + ".xls", true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: File excel đang được mở.\n" + ex.Message);
                        return;
                    }

                    Excel.Application app = default(Excel.Application);
                    Excel.Workbook workBoook = default(Excel.Workbook);
                    Excel.Worksheet workSheet = default(Excel.Worksheet);
                    try
                    {
                        app = new Excel.Application();
                        app.Workbooks.Open(path + "\\" + proposalCode + ".xls");
                        workBoook = app.Workbooks[1];
                        workSheet = (Excel.Worksheet)workBoook.Worksheets[1];

                        workSheet.Cells[7, 1] = proposalCode;
                        DataRow[] drs = dtParts.Select("SupplierName is not null");
                        workSheet.Cells[10, 3] = drs.Length > 0 ? TextUtils.ToString(drs[0]["SupplierName"]) : "";
                        workSheet.Cells[17, 5] = "Tân Phát, ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;
                        workSheet.Cells[22, 20] = Global.AppFullName;

                        int countPart = 0;
                        for (int j = dtParts.Rows.Count - 1; j >= 0; j--)
                        {
                            string partCode = TextUtils.ToString(dtParts.Rows[j]["PartsCode"]);
                            countPart++;

                            workSheet.Cells[15, 1] = j + 1;
                            workSheet.Cells[15, 2] = TextUtils.ToString(dtParts.Rows[j]["PartsName"]);
                            workSheet.Cells[15, 3] = partCode;
                            workSheet.Cells[15, 4] = TextUtils.ToDecimal(dtParts.Rows[j]["TotalBuy"]);
                            //workSheet.Cells[15, 5] = TextUtils.ToDecimal(dtParts.Rows[j]["TotalInventory"]);
                            //workSheet.Cells[15, 6] = TextUtils.ToString(dtParts.Rows[j]["Total"]);
                            workSheet.Cells[15, 7] = TextUtils.ToString(dtParts.Rows[j]["Unit"]);
                            workSheet.Cells[15, 21] = TextUtils.ToString(dtParts.Rows[j]["RequestCode"]);
                            workSheet.Cells[15, 22] = TextUtils.ToString(dtParts.Rows[j]["ProjectCode"]);
                            workSheet.Cells[15, 23] = TextUtils.ToString(dtParts.Rows[j]["ManufacturerCode"]);

                            ((Excel.Range)workSheet.Rows[15]).Insert();
                        }

                        ((Excel.Range)workSheet.Rows[14]).Delete();
                        ((Excel.Range)workSheet.Rows[14]).Delete();
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
                            workSheet = null;
                            workBoook = null;
                            app.Workbooks.Close();
                            app.Quit();
                        }
                    }
                    #endregion

                    TextUtils.ZipFolder(path);
                    if (File.Exists(path + ".zip"))
                    {
                        _dtFile.Rows.Add(i, Path.GetFileName(path + ".zip"), path + ".zip ");
                        countFileAttack = i;
                    }

                    ((Excel.Range)workSheet1.Rows[14]).Insert();
                }

                ((Excel.Range)workSheet1.Rows[13]).Delete();
                ((Excel.Range)workSheet1.Rows[13]).Delete();
                ((Excel.Range)workSheet1.Rows[13]).Delete();

                if (app1 != null)
                {
                    app1.ActiveWorkbook.Save();
                    workSheet1 = null;
                    workBoook1 = null;
                    app1.Workbooks.Close();
                    app1.Quit();
                }
                //if (File.Exists(folderPath + "\\Bao gia tong hop.xls"))
                //{
                //    _dtFile.Rows.Add(countFileAttack + 1, "Bao gia tong hop.xls", folderPath + "\\Bao gia tong hop.xls");
                //}
            }
            if (count >= all && isCreatedYCBG)
            {
                DialogResult result = MessageBox.Show("Download các bản vẽ thành công!\nBạn có muốn gửi mail những thông tin trên đến nhà cung cấp không?", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    frmSendYCBG frm = new frmSendYCBG();
                    frm.DtFile = _dtFile;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        #region Update trạng thái gửi mail
                        if (frm.IsSent)
                        {
                            for (int i = 0; i < grvYC.RowCount; i++)
                            {
                                bool check = TextUtils.ToBoolean(grvYC.GetRowCellValue(i, colCheck));
                                if (!check) continue;
                                string proposalCode = TextUtils.ToString(grvYC.GetRowCellValue(i, colCode));

                                ProposalSentStatusModel model = new ProposalSentStatusModel();
                                model.DateSent = DateTime.Now;
                                model.ProposalCode = proposalCode;
                                model.UserFrom = Global.AppUserName;
                                model.UserTo = frm.SentTo;
                                ProposalSentStatusBO.Instance.Insert(model);

                                grvYC.SetRowCellValue(i, colIsSend, true);
                            }
                        }
                        #endregion
                    }
                }
            }
            else
            {
                MessageBox.Show("Download thành công " + Environment.NewLine + count + "/" + all + " vật tư", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tải dữ liệu..."))
            {
                if (chkDownloadOnlyModule.Checked)
                {
                    loadModules1();
                }
                else
                {
                    string productID = TextUtils.ToString(cboProduct.EditValue);

                    if (productID != "")
                    {
                        DataTable dt = new DataTable();
                        dt = loadAllModuleOfProduct(dt, productID);
                        dt.Columns.Add("check", typeof(bool));
                        if (dt.Rows.Count == 0) return;
                        DataRow[] drs = dt.Select("MaThietBi like 'TPAD.%'");
                        if (drs.Length > 0)
                        {
                            grdModule.DataSource = drs.CopyToDataTable();
                        }
                        else
                        {
                            grdModule.DataSource = null;
                        }
                    }
                }
            }         
        }

        DataTable loadAllModuleOfProduct(DataTable dt, string pProductId)
        {
            string sql = "SELECt [PProductId], ManageId, ProjectModuleCode AS MaThietBi, ProjectModuleName AS TenThietBi, "
                + " ProjectModuleCode + ' - ' + ProjectModuleName as ThietBi from vProjectProducts where ManageId = '" + pProductId + "'";
            DataTable tbl = LibQLSX.Select(sql);
            if (tbl.Rows.Count == 0) return dt;
            if (dt.Rows.Count == 0)
	        {
                dt = tbl;
	        }
            else
            {
                dt.Merge(tbl);
            }
            DataTable dtTemp = tbl.Copy();
            foreach (DataRow item in dtTemp.Rows)
            {
                string ppId = TextUtils.ToString(item["PProductId"]);
                loadAllModuleOfProduct(dt, ppId);
            }

            return dt;
        }
    }
}
