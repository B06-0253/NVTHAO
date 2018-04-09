using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using BMS.Business;
using DevExpress.Utils;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using DevExpress.XtraGrid.Views.Grid;
using System.Runtime.InteropServices;
//using BMS.Model;
//using BMS.Utils;
using System.Collections;
using TPA.Model;
using TPA.Utils;
using TPA.Business;

namespace BMS
{
    public partial class frmDesignSummary : _Forms
    {
        public DesignSummaryModel DesignSummary = new DesignSummaryModel();
        DataTable _dtModule = new DataTable();
        DataTable _dtMaterial = new DataTable();

        DataTable _dtListModule = new DataTable();
        DataTable _dtListMaterial = new DataTable();

        DataTable _dtError = new DataTable();
        DataTable _dtPriceDauVao = new DataTable();

        public delegate void LoadDataChangeHandler(object sender, EventArgs e);
        public event LoadDataChangeHandler LoadDataChange;
        bool _isSaved = false;

        #region Constructor and Load
        public frmDesignSummary()
        {
            InitializeComponent();
        }

        private void frmDesignSummary_Load(object sender, EventArgs e)
        {
            if (DesignSummary.ID > 0 && DesignSummary.UpdatedBy != Global.AppUserName)
            {
                btnAddModule.Enabled = btnAddVT.Enabled = btnDeleteModule.Enabled = btnDeleteVT.Enabled = btnSave.Enabled = false;
            }
            if (DesignSummary.IsApproved)
            {
                btnAddModule.Enabled = btnAddVT.Enabled = btnDeleteModule.Enabled = btnDeleteVT.Enabled = btnSave.Enabled = false;
            }

            this.Text += ": " + DesignSummary.HangMuc + "-" + DesignSummary.ProjectCode + "-" + (DesignSummary.IsApproved ? "Đã duyệt" : "Chưa duyệt");

            _dtError.Columns.Add("Code");
            _dtError.Columns.Add("Name");
            _dtError.Columns.Add("Error");
            _dtError.Columns.Add("KPH");

            loadPhuTrachTK();
            loadProject();
            loadProductTK();
            loadDepartment();
            loadProduct(DesignSummary.ProjectCode);
            //loadProduct1(DesignSummary.ProjectCode);
            loadContract(DesignSummary.ProjectId);

            if (DesignSummary.ID > 0)
            {
                cboProject.EditValue = DesignSummary.ProjectCode;
                cboProduct.EditValue = DesignSummary.ProductId;
                cboContract.EditValue = DesignSummary.ContractId;
                cboBoPhanYC.SelectedValue = DesignSummary.DepartmentIDYC;
                cboBoPhanTH.SelectedValue = DesignSummary.DepartmentIDTH;
                cboUserTK.EditValue = DesignSummary.UserID;

                txtCustomer.Text = DesignSummary.CustomerName;
                txtPhuTrachHD.Text = DesignSummary.UserNamePTC;

                txtHangMuc.Text = DesignSummary.HangMuc;
                txtLanBanHanh.Text = DesignSummary.Version;

                dtpDateHT.EditValue = DesignSummary.DateHT;
                dtpDateYC.EditValue = DesignSummary.DateYC;

                txtProductCodeTK.Text = DesignSummary.ProductCodeTK;
                txtProductNameTK.Text = DesignSummary.ProductNameTK;

                loadDatatableHD(DesignSummary.ProjectCode);
            }           

            loadItem(0);
            loadItem(1);

            #region Init Table
            _dtModule.Columns.Add("ID");
            _dtModule.Columns.Add("Code");
            _dtModule.Columns.Add("Name");
            _dtModule.Columns.Add("Error");
            _dtModule.Columns.Add("KPH");
            _dtModule.Columns.Add("Hang");
            _dtModule.Columns.Add("Qty");
            _dtModule.Columns.Add("CodeHD");
            _dtModule.Columns.Add("NameHD");
            _dtModule.Columns.Add("Status");
            _dtModule.Columns.Add("CVersion");
            _dtModule.Columns.Add("NVersion");

            _dtMaterial.Columns.Add("ID");
            _dtMaterial.Columns.Add("Code");
            _dtMaterial.Columns.Add("Name");
            _dtMaterial.Columns.Add("Error");
            _dtMaterial.Columns.Add("KPH");
            _dtMaterial.Columns.Add("Hang");
            _dtMaterial.Columns.Add("Qty");
            _dtMaterial.Columns.Add("Status");
            _dtMaterial.Columns.Add("TonKho");
            _dtMaterial.Columns.Add("CVersion");
            _dtMaterial.Columns.Add("NVersion");
            _dtMaterial.Columns.Add("Unit");
            _dtMaterial.Columns.Add("Price");

            ////grdModule.DataSource = null;
            //grdModule.DataSource = _dtModule;

            ////grdVT.DataSource = null;
            //grdVT.DataSource = _dtMaterial;
            //grvVT.BestFitColumns();
            #endregion
        }
        #endregion

        #region Methods
        void loadItem(int type)
        {
            string sql = "select * from DesignSummaryItem with(nolock) where DesignSummaryID = " + DesignSummary.ID + " and Type = " + type;
            if (type == 0)
            {
                _dtListModule = LibQLSX.Select(sql);
                grdModule.DataSource = _dtListModule;
            }
            else
            {
                _dtListMaterial = LibQLSX.Select(sql);
                grdVT.DataSource = _dtListMaterial;
            }
        }

        void loadDepartment()
        {
            try
            {
                DataTable dt1 = TextUtils.Select("select * from Department WITH(NOLOCK)");
                DataTable dt2 = TextUtils.Select("select * from Department WITH(NOLOCK)");

                cboBoPhanYC.DataSource = dt1;
                cboBoPhanYC.ValueMember = "ID";
                cboBoPhanYC.DisplayMember = "Name";

                cboBoPhanTH.DataSource = dt2;
                cboBoPhanTH.ValueMember = "ID";
                cboBoPhanTH.DisplayMember = "Name";

                cboBoPhanYC.SelectedValue = 5;//mặc định là phòng dự án
                cboBoPhanTH.SelectedValue = 1;//mặc định là phòng thiết kế
            }
            catch (Exception)
            {
            }
        }

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

        void loadProduct(string projectCode)
        {
            if (projectCode != "")
            {
                try
                {
                    string[] paraName = new string[1];
                    string[] paraValue = new string[1];
                    paraName[0] = "@ProjectCode"; paraValue[0] = projectCode;
                    DataTable tbl =BMS.Business.ModulesBO.Instance.LoadDataFromSP("spGetProductOfProject", "Product", paraName, paraValue);
                    TextUtils.PopulateCombo(cboProduct, tbl, "ThietBi", "PProductId", "");
                }
                catch
                {
                    cboProduct.Properties.DataSource = null;
                }
            }
            //else
            //{
            //    cboProduct.Properties.DataSource = null;
            //}
        }

        void loadProduct1(string projectCode)
        {
            //string projectCode = "";
            //projectCode = TextUtils.ToString(grvProject.GetFocusedRowCellValue(colProjectCode));
            //if (DesignSummary.ID > 0)
            //{
            //    projectCode = DesignSummary.ProjectCode;
            //}
            if (projectCode != "")
            {
                try
                {
                    string[] paraName = new string[1];
                    string[] paraValue = new string[1];
                    paraName[0] = "@ProjectCode"; paraValue[0] = projectCode;
                    DataTable tbl = BMS.Business.ModulesBO.Instance.LoadDataFromSP("spGetProductOfProjectNew", "Product", paraName, paraValue);
                    TextUtils.PopulateCombo(cboProduct, tbl, "ThietBi", "PProductId", "");
                }
                catch
                {
                    cboProduct.Properties.DataSource = null;
                }
            }
            //else
            //{
            //    cboProduct.Properties.DataSource = null;
            //}
        }

        void loadProductTK()
        {
            DataTable dtProductTK = TextUtils.Select("select * from vProducts with(nolock)");
            cboProductTK.Properties.DataSource = dtProductTK;
            cboProductTK.Properties.DisplayMember = "Code";
            cboProductTK.Properties.ValueMember = "Code";
        }

        void loadContract(string projectId)
        {
            if (projectId!="")
            {
                try
                {
                    //string projectId = grvProject.GetFocusedRowCellValue(colProjectID).ToString();
                    DataTable dtContract = LibQLSX.Select(string.Format("SELECT *,[ContractCode] +' - '+[ContractName] Contract FROM [dbo].[Contracts] with(nolock) where [ProjectId] = '{0}'", projectId));
                    TextUtils.PopulateCombo(cboContract, dtContract, "Contract", "ContractId", "");
                }
                catch (Exception)
                {
                    cboContract.Properties.DataSource = null;
                }
            }            
        }

        void loadPhuTrachTK()
        {
            try
            {
                DataTable dt = TextUtils.Select("Select * from vUserInfo WITH(NOLOCK)");
                cboUserTK.Properties.DataSource = dt;
                cboUserTK.Properties.DisplayMember = "FullName";
                cboUserTK.Properties.ValueMember = "ID";
            }
            catch (Exception)
            {
            }
        }

        bool validate()
        {
            if (DesignSummary.ID == 0)
            {
                MessageBox.Show("Bạn phải lưu lại tổng hợp thiết kế trước khi tạo.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (cboProject.EditValue == null || cboProject.EditValue.ToString() == "")
            {
                MessageBox.Show("Xin hãy chọn một dự án.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (cboProduct.EditValue == null || cboProduct.EditValue.ToString() == "")
            {
                MessageBox.Show("Xin hãy chọn một sản phẩm.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            //if (cboContract.EditValue == null || cboContract.EditValue.ToString() == "")
            //{
            //    MessageBox.Show("Xin hãy chọn một hợp đồng.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return false;
            //}

            if (cboBoPhanYC.SelectedIndex < 0)
            {
                MessageBox.Show("Xin hãy chọn bộ phận yêu cầu.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (cboBoPhanTH.SelectedIndex < 0)
            {
                MessageBox.Show("Xin hãy chọn bộ phận thiết kế.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (cboUserTK.EditValue == null)
            {
                MessageBox.Show("Xin hãy chọn người phụ trách thiết kế.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (grvModule.RowCount == 0)
            {
                MessageBox.Show("Bạn chưa nhập danh mục module.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (dtpDateYC.EditValue == null)
            {
                MessageBox.Show("Bạn chưa nhập Ngày yêu cầu.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (dtpDateHT.EditValue == null)
            {
                MessageBox.Show("Bạn chưa nhập Ngày hoàn thành.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            //if (_dtListModule.Select("QtyError <> '0'").Count() > 0)
            //{
            //    MessageBox.Show("Vẫn tồn tại lỗi trong các module.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return false;
            //}

            //if (_dtListModule.Select("QtyKPH <> '0'").Count() > 0)
            //{
            //    MessageBox.Show("Vẫn tồn tại sự không phù hợp trong các module.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return false;
            //}

            //if (_dtListMaterial.Select("QtyError <> '0'").Count() > 0)
            //{
            //    MessageBox.Show("Vẫn tồn tại lỗi trong các vật tư phụ.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return false;
            //}

            //if (_dtListMaterial.Select("QtyKPH <> '0'").Count() > 0)
            //{
            //    MessageBox.Show("Vẫn tồn tại sự không phù hợp trong các vật tư phụ.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return false;
            //}

            if (txtProductNameTK.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập tên sản phẩm theo thiết kế.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (txtProductCodeTK.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập mã sản phẩm theo thiết kế.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (txtHangMuc.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy nhập tên hạng mục.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (txtLanBanHanh.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập lần ban hành.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            //string warningModule = "";
            //string warningMaterial = "";
            DocUtils.InitFTPQLSX();

            #region Kiểm tra lỗi trong danh sách module
            //foreach (DataRow dr in _dtListModule.Rows)
            //{
            //    string moduleCode = dr["Code"].ToString();
            //    string status = dr["Status"].ToString();
            //    if (status != "2") continue;
            //    string serverPathCK = "Thietke.Ck/" + moduleCode.Substring(0, 6) + "/" + moduleCode + ".Ck/";
            //    try
            //    {
            //        if (DocUtils.CheckExits(serverPathCK + "/VT." + moduleCode + ".xlsm"))
            //        {
            //            //Download file danh mục vật tư
            //            DocUtils.DownloadFile("D:/", "VT." + moduleCode + ".xlsm", serverPathCK + "/VT." + moduleCode + ".xlsm");
            //        }
            //    }
            //    catch
            //    {
            //    }

            //    string pathDMVT = "D:/VT." + moduleCode + ".xlsm";
            //    DataTable dtDMVT = TextUtils.ExcelToDatatable(pathDMVT, "DMVT");
            //    if (dtDMVT.Rows.Count == 0) continue;
            //    for (int i = 0; i <= 4; i++)
            //    {
            //        dtDMVT.Rows.RemoveAt(0);
            //    }
            //    if (File.Exists(pathDMVT))
            //    {
            //        File.Delete(pathDMVT);
            //    }

            //    //DataRow rowInsert = dtDMVT.NewRow();
            //    //rowInsert["F4"] = "TPAD.E6405";
            //    //dtDMVT.Rows.Add(rowInsert);

            //    //DataRow rowInsert1 = dtDMVT.NewRow();
            //    //rowInsert1["F4"] = "TPAD.F3301";
            //    //dtDMVT.Rows.Add(rowInsert1);

            //    DataRow[] rows = dtDMVT.Select("F4 like '%TPAD%' and len(F4) = 10");
            //    if (rows.Count() > 0)
            //    {
            //        dtDMVT = rows.CopyToDataTable();

            //        string detail = "";
            //        foreach (DataRow row in dtDMVT.Rows)
            //        {
            //            DataTable dtError = TextUtils.Select(
            //            string.Format("select * from [vModuleError] where [ModuleCode]='{0}' and Status = 0 and ConfirmTemp = 0", row["F4"].ToString()));
            //            DataTable dtKPH = TextUtils.Select(
            //                string.Format("select * from [vMisMatch] where [ModuleCode]='{0}' StatusKCS = 0 and ConfirmTemp = 0", row["F4"].ToString()));
            //            if (dtError.Rows.Count > 0 || dtKPH.Rows.Count > 0)
            //            {
            //                detail += "\t+ Module " + row["F4"].ToString() + ": có " + dtError.Rows.Count
            //                    + " lỗi và " + dtKPH.Rows.Count + " sự không phù hợp" + Environment.NewLine;
            //            }
            //        }
            //        if (detail != "")
            //        {
            //            warningModule += moduleCode + " chứa:" + Environment.NewLine + detail;
            //        }
            //    }
            //    if (warningModule != "")
            //    {
            //        MessageBox.Show("Danh sách module:" + Environment.NewLine + warningModule, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //        return false;
            //    }
            //}
            #endregion

            #region Kiểm tra lỗi trong danh mục vật tư phụ
            //if (_dtListMaterial.Rows.Count > 0)
            //{
            //    foreach (DataRow dr in _dtListMaterial.Rows)
            //    {
            //        string moduleCode = dr["Code"].ToString();
            //        if (!moduleCode.StartsWith("TPAD")) continue;
            //        string status = dr["Status"].ToString();
            //        if (status != "2") continue;
            //        string serverPathCK = "Thietke.Ck/" + moduleCode.Substring(0, 6) + "/" + moduleCode + ".Ck/";
            //        try
            //        {
            //            if (DocUtils.CheckExits(serverPathCK + "/VT." + moduleCode + ".xlsm"))
            //            {
            //                //Download file danh mục vật tư
            //                DocUtils.DownloadFile("D:/", "VT." + moduleCode + ".xlsm", serverPathCK + "/VT." + moduleCode + ".xlsm");
            //            }
            //        }
            //        catch
            //        {
            //        }

            //        string pathDMVT = "D:/VT." + moduleCode + ".xlsm";
            //        DataTable dtDMVT = TextUtils.ExcelToDatatable(pathDMVT, "DMVT");
            //        if (dtDMVT.Rows.Count == 0) continue;
            //        for (int i = 0; i <= 4; i++)
            //        {
            //            dtDMVT.Rows.RemoveAt(0);
            //        }
            //        if (File.Exists(pathDMVT))
            //        {
            //            File.Delete(pathDMVT);
            //        }

            //        //DataRow rowInsert = dtDMVT.NewRow();
            //        //rowInsert["F4"] = "TPAD.E6405";
            //        //dtDMVT.Rows.Add(rowInsert);

            //        //DataRow rowInsert1 = dtDMVT.NewRow();
            //        //rowInsert1["F4"] = "TPAD.F3301";
            //        //dtDMVT.Rows.Add(rowInsert1);

            //        DataRow[] rows = dtDMVT.Select("F4 like '%TPAD%' and len(F4)=10");
            //        if (rows.Count() > 0)
            //        {
            //            dtDMVT = rows.CopyToDataTable();

            //            string detail = "";
            //            foreach (DataRow row in dtDMVT.Rows)
            //            {
            //                DataTable dtError = TextUtils.Select(
            //                string.Format("select * from [vModuleError] where [ModuleCode]='{0}' and Status = 0 and ConfirmTemp = 0", row["F4"].ToString()));
            //                DataTable dtKPH = TextUtils.Select(
            //                    string.Format("select * from [vMisMatch] where [ModuleCode]='{0}' StatusKCS = 0 and ConfirmTemp = 0", row["F4"].ToString()));
            //                if (dtError.Rows.Count > 0 || dtKPH.Rows.Count > 0)
            //                {
            //                    detail += "\t+ Module " + row["F4"].ToString() + ": có " + dtError.Rows.Count
            //                        + " lỗi và " + dtKPH.Rows.Count + " sự không phù hợp" + Environment.NewLine;
            //                }
            //            }
            //            if (detail != "")
            //            {
            //                warningMaterial += moduleCode + " chứa:" + Environment.NewLine + detail;
            //            }
            //        }
            //        if (warningMaterial != "")
            //        {
            //            MessageBox.Show("Danh sách vật tư phụ:" + Environment.NewLine + warningMaterial, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //            return false;
            //        }
            //    }
            //}
            #endregion

            return true;
        }

        string getModulePart(DataTable dtModulePart)
        {
            string result = "";
            if (dtModulePart.Rows.Count > 0)
            {
                foreach (DataRow row in dtModulePart.Rows)
                {
                    result += "*" + row["Code"] + "-" + row["Name"] + ";" + Environment.NewLine;
                }
            }
            return result;
        }

        bool ValidateForm()
        {
            if (txtHangMuc.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy nhập tên hạng mục.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }           

            if (TextUtils.ToString(cboProject.EditValue) == "")
            {
                MessageBox.Show("Xin hãy chọn một dự án.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (TextUtils.ToString(cboProduct.EditValue) == "")
            {
                MessageBox.Show("Xin hãy chọn một sản phẩm.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (cboBoPhanYC.SelectedIndex < 0)
            {
                MessageBox.Show("Xin hãy chọn bộ phận yêu cầu.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (cboBoPhanTH.SelectedIndex < 0)
            {
                MessageBox.Show("Xin hãy chọn bộ phận thiết kế.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (cboUserTK.EditValue == null)
            {
                MessageBox.Show("Xin hãy chọn người phụ trách thiết kế.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (_dtListModule.Rows.Count == 0)
            {
                MessageBox.Show("Bạn chưa nhập danh mục module.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (dtpDateYC.EditValue == null)
            {
                 MessageBox.Show("Bạn chưa nhập Ngày yêu cầu.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (dtpDateHT.EditValue == null)
            {
                MessageBox.Show("Bạn chưa nhập Ngày hoàn thành.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (txtProductNameTK.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập tên sản phẩm theo thiết kế.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (txtProductCodeTK.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập mã sản phẩm theo thiết kế.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            
            if (txtLanBanHanh.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập lần ban hành.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            DataTable dt;
            if (DesignSummary.ID > 0)
            {
                dt = LibQLSX.Select("select HangMuc from DesignSummary where HangMuc = '" + txtHangMuc.Text.Trim() 
                    + "' and ProjectCode = '" + TextUtils.ToString(cboProject.EditValue) 
                    + "' and ID <> " + DesignSummary.ID);
            }
            else
            {
                dt = LibQLSX.Select("select HangMuc from DesignSummary where HangMuc = '" + txtHangMuc.Text.Trim() + "' and ProjectCode = '" + TextUtils.ToString(cboProject.EditValue) + "'");
            }

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Hạng mục này đã tồn tại!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return true;
        }

        void CreateVTP(DesignSummaryModel model)
        {
            string mP = "TB.A0001";
            DataTable dt = TextUtils.Select("select top 1 ProductCodePhu from DesignSummary with(nolock) where ProjectCode = '"
                + model.ProjectCode + "' order by ID desc");
            if (dt.Rows.Count > 0)
            {
                string old = TextUtils.ToString(dt.Rows[0][0]).Split('.')[1].Substring(1, 4);
                mP = "TB.A" + string.Format("{0:0000}", TextUtils.ToInt(old) + 1);
            }

            model.ProductCodePhu = mP;
            model.ProductNamePhu = "Vật tư phụ của " + model.ProductCodeTK;
        }

        void loadDatatableHD(string projectCode)
        {
            string filePath = @"\\SERVER\data2\Thietke\Luutru\Hoancong\TONG HOP GIA DAU VAO\" + projectCode + ".xls";
            _dtPriceDauVao = TextUtils.ExcelToDatatableNoHeader(filePath, "Tổng hợp v1");
        }
        #endregion

        private void cboProject_EditValueChanged(object sender, EventArgs e)
        {
            string projectCode = TextUtils.ToString(cboProject.EditValue);
            if (projectCode != "")
            {
                string projectId = TextUtils.ToString(grvProject.GetFocusedRowCellValue(colProjectID));
                loadProduct(projectCode);
                loadContract(projectId);
                txtCustomer.Text = TextUtils.ToString(grvProject.GetFocusedRowCellValue(colCustomerName));
                txtPhuTrachHD.Text = TextUtils.ToString(grvProject.GetFocusedRowCellValue(colUserName));

                DataTable dtProjectDate = TextUtils.Select("select top 1 * from ProjectDesignDate with(nolock) where ProjectCode = '" + projectCode + "'");
                if (dtProjectDate.Rows.Count > 0)
                {
                    dtpDateYC.EditValue = TextUtils.ToDate(dtProjectDate.Rows[0]["DateYC"].ToString());
                    dtpDateHT.EditValue = TextUtils.ToDate(dtProjectDate.Rows[0]["DateHT"].ToString());
                }
                else
                {
                    dtpDateYC.EditValue = null;
                    dtpDateHT.EditValue = null;
                }

                loadDatatableHD(projectCode);
            }
        }

        private void btnAddModule_Click(object sender, EventArgs e)
        {
            frmListModules frm = new frmListModules();
            frm.dtSeleted = _dtModule.Copy();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _dtModule = frm.dtSeleted;
                foreach (DataRow row in _dtModule.Rows)
                {
                    string moduleCode = TextUtils.ToString(row["Code"]);
                    DataRow[] drs = _dtListModule.Select("Code = '" + moduleCode + "'");
                    if (drs.Length == 0)
                    {
                        DataRow dr = _dtListModule.NewRow();
                        dr["ID"] = 0;
                        dr["DesignSummaryID"] = DesignSummary.ID;
                        //dr["CodeHD"] = TextUtils.ToString(row["CodeHD"]);
                        //dr["NameHD"] = TextUtils.ToString(row["NameHD"]);
                        dr["Code"] = TextUtils.ToString(row["Code"]);
                        dr["Name"] = TextUtils.ToString(row["Name"]);
                        dr["Hang"] = TextUtils.ToString(row["Hang"]);
                        //dr["Unit"] = TextUtils.ToString(row["Unit"]);
                        dr["Qty"] = TextUtils.ToDecimal(row["Qty"]);
                        dr["QtyError"] = TextUtils.ToDecimal(row["Error"]);
                        dr["QtyKPH"] = TextUtils.ToDecimal(row["KPH"]);
                        //dr["QtyTon"] = TextUtils.ToDecimal(row["TonKho"]);
                        //dr["Price"] = TextUtils.ToDecimal(row["Price"]);
                        //dr["TotalPrice"] = TextUtils.ToDecimal(row["TotalPrice"]);
                        dr["CVersion"] = TextUtils.ToInt(row["CVersion"]);
                        dr["Status"] = TextUtils.ToInt(row["Status"]);
                        dr["Type"] = 0;
                        _dtListModule.Rows.Add(dr);
                    }
                }
                grdModule.DataSource = _dtListModule;
            }
        }

        private void btnDeleteModule_Click(object sender, EventArgs e)
        {
            long id = TextUtils.ToInt64(grvModule.GetFocusedRowCellValue(colMID));
            string moduleCode = TextUtils.ToString(grvModule.GetFocusedRowCellValue(colMCode));
            if (moduleCode == "") return;
            try
            {
               DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa module này?", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
               if (result == DialogResult.Yes)
               {
                   if (id > 0)
                   {
                       DesignSummaryItemBO.Instance.Delete(id);
                   }                   
                   //_dtListModule = _dtListModule.Select("Code <> '" + moduleCode + "'").CopyToDataTable();
                   //grdModule.DataSource = _dtListModule;
                   grvModule.DeleteSelectedRows();
                   _dtModule = _dtModule.Select("Code <> '" + moduleCode + "'").CopyToDataTable();
               }
                
            }
            catch (Exception)
            {
                _dtModule.Rows.Clear();
                //grdModule.DataSource = null;
            }
        }

        private void btnAddVT_Click(object sender, EventArgs e)
        {
            frmListMaterial frm = new frmListMaterial();
            frm.dtAll = _dtMaterial.Copy();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _dtMaterial = frm.dtAll;
                foreach (DataRow row in _dtMaterial.Rows)
                {
                    string code = TextUtils.ToString(row["Code"]);
                    DataRow[] drs = _dtListMaterial.Select("Code = '" + code + "'");
                    if (drs.Length == 0)
                    {
                        DataRow dr = _dtListMaterial.NewRow();
                        dr["ID"] = 0;
                        dr["DesignSummaryID"] = DesignSummary.ID;
                        //dr["CodeHD"] = TextUtils.ToString(row["CodeHD"]);
                        //dr["NameHD"] = TextUtils.ToString(row["NameHD"]);
                        dr["Code"] = TextUtils.ToString(row["Code"]);
                        dr["Name"] = TextUtils.ToString(row["Name"]);
                        dr["Hang"] = TextUtils.ToString(row["Hang"]);
                        dr["Unit"] = TextUtils.ToString(row["Unit"]);
                        dr["Qty"] = TextUtils.ToDecimal(row["Qty"]);
                        dr["QtyError"] = TextUtils.ToDecimal(row["Error"]);
                        dr["QtyKPH"] = TextUtils.ToDecimal(row["KPH"]);
                        dr["QtyTon"] = TextUtils.ToDecimal(row["TonKho"]);
                        dr["Price"] = TextUtils.ToDecimal(row["Price"]);
                        dr["TotalPrice"] = TextUtils.ToDecimal(row["Qty"]) * TextUtils.ToDecimal(row["Price"]);
                        dr["CVersion"] = TextUtils.ToInt(row["CVersion"]);
                        dr["Status"] = TextUtils.ToInt(row["Status"]);
                        dr["Type"] = 1;
                        _dtListMaterial.Rows.Add(dr);
                    }
                }
                grdVT.DataSource = _dtListMaterial;
            }
        }

        private void btnDeleteVT_Click(object sender, EventArgs e)
        {
            long id = TextUtils.ToInt64(grvVT.GetFocusedRowCellValue(colMaID));
            string code = TextUtils.ToString(grvVT.GetFocusedRowCellValue(colMaCode));
            if (code == "") return;
            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa vật tư phụ này?", TextUtils.Caption, 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (id > 0)
                    {
                        DesignSummaryItemBO.Instance.Delete(id);
                    }
                    grvVT.DeleteSelectedRows();
                    _dtMaterial = _dtMaterial.Select("Code <> '" + code + "'").CopyToDataTable();
                }               
            }
            catch (Exception)
            {
                _dtMaterial.Rows.Clear();
                //grdVT.DataSource = null;
            }
        }

        private void grvVT_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0) return;
            GridView View = sender as GridView;
            int status = TextUtils.ToInt(View.GetRowCellValue(e.RowHandle, colMaStatus));

            if (status == 2)
            {
                e.Appearance.ForeColor = Color.Red;
            }
        }

        private void grvModule_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0) return;
            GridView View = sender as GridView;
            int status = TextUtils.ToInt(View.GetRowCellValue(e.RowHandle, colMStatus));

            if (status == 2)
            {
                e.Appearance.ForeColor = Color.Red;
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            string productCode = TextUtils.ToString(grvProject.GetFocusedRowCellValue(colProjectCode));
            if (chkAll.Checked)
            {
                loadProduct1(productCode);
            }
            else
            {
                loadProduct(productCode);
            }
        }

        private void btnCreateTHTK_Click(object sender, EventArgs e)
        {
            if (!validate()) return;
            _dtError.Rows.Clear();
            DocUtils.InitFTPQLSX();

            #region init table
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
            dtData.Columns.Add("TypeName");
            dtData.Columns.Add("Type");
            dtData.Columns.Add("Price", typeof(decimal));
            dtData.Columns.Add("TotalPrice", typeof(decimal));
            dtData.Columns.Add("NgungSuDung");
            #endregion

            try
            {
                #region Thông tin chung
                string khachHang = "Tên KH cuối: " + txtCustomer.Text.Trim();
                string soHopDong = "";
                if (TextUtils.ToString(grvContract.GetFocusedRowCellValue(colContractCode)) != "")
                {
                    soHopDong = "Số HĐ: " + TextUtils.ToString(grvContract.GetFocusedRowCellValue(colContractCode));
                }
                else
                {
                    soHopDong = "Số HĐ: ";
                }

                string bophanYC = "Bộ Phận YC: " + cboBoPhanYC.Text;
                string ngayYC = "Ngày YC: " + TextUtils.ToDate(dtpDateYC.EditValue.ToString()).ToString("dd/MM/yyyy");
                string phutrachHD = "Phụ trách HĐ: " + txtPhuTrachHD.Text.Trim();
                string bophanTK = "Bộ Phận TH: " + cboBoPhanTH.Text;
                string ngayHT = "Ngày HT: " + TextUtils.ToDate(dtpDateHT.EditValue.ToString()).ToString("dd/MM/yyyy");
                string phutrachTK = "Phụ trách TK: " + cboUserTK.Text;
                string nameHD = "Tên sản phẩm theo hợp đồng: " + TextUtils.ToString(grvProduct.GetFocusedRowCellValue(colTenThietBi));
                string codeHD = "Mã SP theo hợp đồng: " + TextUtils.ToString(grvProduct.GetFocusedRowCellValue(colMaThietBi));
                string hangMuc = "Hạng mục: " + txtHangMuc.Text.Trim();
                string lanBanHanh = txtLanBanHanh.Text.Trim();
                string nameTK = "Tên sản phẩm theo thiết kế: " + txtProductNameTK.Text.Trim();
                string codeTK = "Mã SP theo thiết kế: " + txtProductCodeTK.Text.Trim();
                #endregion

                #region Đường dẫn
                string localPath = "";

                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    localPath = fbd.SelectedPath + "\\THTK - Muc " + txtHangMuc.Text.Trim() + " - " + txtProductNameTK.Text.Replace("/", "-").Replace("\"", "-") + ".xlsm";
                }
                else
                {
                    return;
                }

                string filePath = Application.StartupPath + "\\Templates\\THTK.xlsm";

                try
                {
                    File.Copy(filePath, localPath, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: File excel đang được mở.");
                    return;
                }
                #endregion

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

                        #region Thông tin chung
                        workSheet.Cells[3, 1] = "Số: " + txtHangMuc.Text.Trim() + "-"
                            + (grvContract.GetFocusedRowCellValue(colContractCode) == null ? "" : grvContract.GetFocusedRowCellValue(colContractCode).ToString())
                            + "-PTK/" + lanBanHanh;

                        workSheet.Cells[4, 1] = khachHang;
                        workSheet.Cells[4, 8] = cboProject.EditValue.ToString();
                        workSheet.Cells[4, 11] = soHopDong;

                        workSheet.Cells[5, 1] = bophanYC;
                        workSheet.Cells[5, 8] = ngayYC;
                        workSheet.Cells[5, 11] = phutrachHD;

                        workSheet.Cells[6, 1] = bophanTK;
                        workSheet.Cells[6, 8] = ngayHT;
                        workSheet.Cells[6, 11] = phutrachTK;

                        workSheet.Cells[7, 1] = nameHD;
                        workSheet.Cells[7, 8] = codeHD;
                        workSheet.Cells[7, 12] = hangMuc;

                        workSheet.Cells[8, 1] = nameTK;
                        workSheet.Cells[8, 8] = codeTK;

                        if (grvVT.RowCount > 0)
                        {
                            workSheet.Cells[14, 3] = DesignSummary.ProductNamePhu;
                            workSheet.Cells[14, 4] = DesignSummary.ProductCodePhu;
                        }
                        workSheet.Cells[19, 10] = "Hà Nội, ngày " + string.Format("{0:00}", DateTime.Now.Day) 
                            + " tháng " + string.Format("{0:00}", DateTime.Now.Month) 
                            + " năm " + DateTime.Now.Year;
                        #endregion

                        #region Thêm vật tư vào biểu mẫu
                        int rowCountMa = grvVT.RowCount;
                        for (int i = rowCountMa - 1; i >= 0; i--)
                        {
                            try
                            {
                                ((Excel.Range)workSheet.Rows[17]).Insert();

                                string code = grvVT.GetRowCellValue(i, colMaCode).ToString();
                                string name = TextUtils.ToString(grvVT.GetRowCellValue(i, colMaName));
                                int error = TextUtils.ToInt(grvVT.GetRowCellValue(i, colMaError));
                                int kph = TextUtils.ToInt(grvVT.GetRowCellValue(i, colMaKPH));

                                if (error > 0 || kph > 0)
                                {
                                    DataRow drError = _dtError.NewRow();
                                    drError["Code"] = code;
                                    drError["Name"] = name;
                                    drError["Error"] = error;
                                    drError["KPH"] = kph;
                                    _dtError.Rows.Add(drError);
                                }
                                //
                                ((Excel.Range)workSheet.Cells[18, 15]).Formula = "=G18*K18";
                                workSheet.Cells[18, 14] = "00000";

                                workSheet.Cells[18, 1] = i + 1;
                                workSheet.Cells[18, 3] = grvVT.GetRowCellValue(i, colMaName).ToString();
                                workSheet.Cells[18, 5] = code;
                                workSheet.Cells[18, 6] = grvVT.GetRowCellValue(i, colMaHang).ToString();
                                workSheet.Cells[18, 7] = grvVT.GetRowCellValue(i, colMaQty).ToString();
                                workSheet.Cells[18, 8] = grvVT.GetRowCellValue(i, colMaError).ToString() == "0" ? "" : grvVT.GetRowCellValue(i, colMaError).ToString();
                                workSheet.Cells[18, 9] = grvVT.GetRowCellValue(i, colMaKPH).ToString() == "0" ? "" : grvVT.GetRowCellValue(i, colMaKPH).ToString();
                                workSheet.Cells[18, 10] = grvVT.GetRowCellValue(i, colMaTonKho).ToString() == "0" ? "0" : grvVT.GetRowCellValue(i, colMaTonKho).ToString();

                                decimal total = 0;

                                if (code.StartsWith("TPAD") && code.Length == 10)
                                {
                                    DataTable dtNoPrice = new DataTable();
                                    DataTable dt = TextUtils.LoadModulePriceTPAD(code, true, out dtNoPrice, DesignSummary.ProjectCode);
                                    if (dt.Rows.Count > 0)
                                    {
                                        total = TextUtils.ToDecimal(dt.Compute("Sum(TotalPrice)", ""));

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

                                        //Update Price
                                        if (dtNoPrice.Rows.Count == 0)
                                        {
                                            try
                                            {
                                                long id = TextUtils.ToInt64(grvVT.GetRowCellValue(i, colMaID));
                                                DesignSummaryItemModel item = (DesignSummaryItemModel)DesignSummaryItemBO.Instance.FindByPK(id);
                                                item.Price = total;
                                                item.TotalPrice = total * item.Qty;
                                                DesignSummaryItemBO.Instance.Update(item);
                                            }
                                            catch (Exception)
                                            {
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    string sqlM = "exec spGetPriceOfPart '" + code + "'";
                                    DataTable dtPrice = LibQLSX.Select(sqlM);
                                    if (dtPrice.Rows.Count > 0)
                                    {
                                        total = TextUtils.ToDecimal(dtPrice.Rows[0]["Price"]);
                                        if (total == 0)
                                        {
                                            DataRow dr = dtData.NewRow();
                                            dr["F2"] = grvVT.GetRowCellValue(i, colMaName).ToString();
                                            dr["F4"] = code;
                                            dtData.Rows.Add(dr);
                                        }
                                    }                                  
                                }
                                workSheet.Cells[18, 11] = total.ToString("n0");
                                workSheet.Cells[18, 12] = "";
                                workSheet.Cells[18, 13] = "VTP";
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        ((Excel.Range)workSheet.Rows[16]).Delete();
                        ((Excel.Range)workSheet.Rows[16]).Delete();
                        #endregion

                        #region Thêm module vào biểu mẫu
                        int rowCountMo = grvModule.RowCount;
                        for (int i = rowCountMo - 1; i >= 0; i--)
                        {
                            string code = grvModule.GetRowCellValue(i, colMCode).ToString();
                            if (code == "") continue;
                            try
                            {                                
                                ((Excel.Range)workSheet.Rows[12]).Insert();

                                string name = TextUtils.ToString(grvModule.GetRowCellValue(i, colMName));
                                int error = TextUtils.ToInt(grvModule.GetRowCellValue(i, colMError));
                                int kph = TextUtils.ToInt(grvModule.GetRowCellValue(i, colMKPH));

                                if (error > 0 || kph > 0)
                                {
                                    DataRow drError = _dtError.NewRow();
                                    drError["Code"] = code;
                                    drError["Name"] = name;
                                    drError["Error"] = error;
                                    drError["KPH"] = kph;
                                    _dtError.Rows.Add(drError);
                                }
                                ((Excel.Range)workSheet.Cells[13, 15]).Formula = "=K13*G13";
                                workSheet.Cells[13, 14] = "00000";

                                workSheet.Cells[13, 1] = i + 1;
                                workSheet.Cells[13, 2] = grvModule.GetRowCellValue(i, colMNameHD).ToString();
                                workSheet.Cells[13, 3] = grvModule.GetRowCellValue(i, colMName).ToString();
                                workSheet.Cells[13, 4] = grvModule.GetRowCellValue(i, colMCodeHD).ToString();
                                workSheet.Cells[13, 5] = grvModule.GetRowCellValue(i, colMCode).ToString();
                                workSheet.Cells[13, 6] = grvModule.GetRowCellValue(i, colMHang).ToString();
                                workSheet.Cells[13, 7] = grvModule.GetRowCellValue(i, colMQty).ToString();
                                workSheet.Cells[13, 8] = grvModule.GetRowCellValue(i, colMError).ToString();
                                workSheet.Cells[13, 9] = grvModule.GetRowCellValue(i, colMKPH).ToString();
                                workSheet.Cells[13, 10] = grvModule.GetRowCellValue(i, colMStatus).ToString() == "2" ? "Đã chuẩn" : "";
                                
                                decimal total = 0;
                                string note = "";
                                if (code.StartsWith("TPAD") && code.Length == 10)
                                {
                                    DataTable dtNoPrice = new DataTable();
                                    DataTable dt = TextUtils.LoadModulePriceTPAD(code, true, out dtNoPrice, DesignSummary.ProjectCode);
                                    if (dt.Rows.Count > 0)
                                    {
                                        total = TextUtils.ToDecimal(dt.Compute("Sum(TotalPrice)", ""));

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

                                        //Lấy danh sách các vật tư phụ của module
                                        BMS.Model.ModulesModel module = (BMS.Model.ModulesModel)BMS.Business.ModulesBO.Instance.FindByCode(code);
                                        if (module != null)
                                        {
                                            DataTable dtPart = TextUtils.Select("select * from ModulePart with(nolock) where ModuleID = " + module.ID);
                                            note = getModulePart(dtPart);
                                        }

                                        //Update Price
                                        if (dtNoPrice.Rows.Count == 0)
                                        {
                                            try
                                            {
                                                long id = TextUtils.ToInt64(grvModule.GetRowCellValue(i, colMID));
                                                DesignSummaryItemModel item = (DesignSummaryItemModel)DesignSummaryItemBO.Instance.FindByPK(id);
                                                item.Price = total;
                                                item.TotalPrice = total * item.Qty;
                                                DesignSummaryItemBO.Instance.Update(item);
                                            }
                                            catch (Exception)
                                            {
                                            }
                                        }
                                    }
                                }
                                workSheet.Cells[13, 11] = total.ToString("n0");
                                workSheet.Cells[13, 12] = TextUtils.ToDecimal(grvModule.GetRowCellValue(i, colMPriceHD)).ToString("n0");
                                workSheet.Cells[13, 13] = note;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        ((Excel.Range)workSheet.Rows[11]).Delete();
                        ((Excel.Range)workSheet.Rows[11]).Delete();
                        #endregion
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

                if (dtData.Rows.Count > 0 || _dtError.Rows.Count > 0)
                {
                    File.Delete(localPath);
                    MessageBox.Show("Có nhiều vật tư chưa có giá hoặc module có lỗi. \nBạn không thể tạo tổng hợp thiết kế.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    FolderBrowserDialog fbd1 = new FolderBrowserDialog();
                    if (fbd1.ShowDialog() == DialogResult.OK)
                    {
                        string path = fbd1.SelectedPath + "\\" + TextUtils.ToString(cboProject.EditValue) + "-" + txtHangMuc.Text.Trim() + "-Vật tư không có giá - lỗi\\";
                        Directory.CreateDirectory(path);

                        #region Xuất module lỗi, không phù hợp
                        if (_dtError.Rows.Count > 0)
                        {
                            TextUtils.DatatableToCSV(_dtError, path + "\\Module lỗi-KPH.csv");
                            File.Move(path + "\\Module lỗi-KPH.csv", path + "\\Module lỗi-KPH.csv.xls");
                        }
                        #endregion

                        #region Xuất danh sách file không có giá
                        using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang xuất vật tư không có giá..."))
                        {
                            #region Doi ten column
                            dtData.Columns["F1"].ColumnName = "STT";
                            dtData.Columns["F2"].ColumnName = "TenVatTu";
                            dtData.Columns["F3"].ColumnName = "ThongSo";
                            dtData.Columns["F4"].ColumnName = "MaVatTu";
                            dtData.Columns["F5"].ColumnName = "MaVatLieu";
                            dtData.Columns["F6"].ColumnName = "DonVi";
                            dtData.Columns["F7"].ColumnName = "SL";
                            dtData.Columns["F8"].ColumnName = "VatLieu";
                            dtData.Columns["F9"].ColumnName = "KhoiLuong";
                            dtData.Columns["F10"].ColumnName = "Hang";
                            #endregion                            

                            #region No Price
                            #region Ke toan
                            //DataRow[] drsPhip = dtData.Select("VatLieu like 'PHÍP%' or (MaVatLieu <> '' and MaVatLieu is not null)");
                            //if (drsPhip.Length > 0)
                            //{
                            //    DataTable dtPhip = drsPhip.CopyToDataTable();
                            //    TextUtils.DatatableToCSV(dtPhip, path + "\\Vật tư hỏi giá kế toán.csv");
                            //    File.Move(path + "\\Vật tư hỏi giá kế toán.csv", path + "\\Vật tư hỏi giá kế toán.xls");
                            //    DataRow[] drsData = dtData.Select("VatLieu not like 'PHÍP%' and MaVatLieu = ''");
                            //    if (drsData.Length > 0)
                            //    {
                            //        dtData = drsData.CopyToDataTable();
                            //    }
                            //    else
                            //    {
                            //        dtData.Rows.Clear();
                            //    }
                            //}
                            #endregion

                            #region Dien tu
                            //DataRow[] drsPCB = dtData.Select("TypeName like 'PCB%'");
                            //if (drsPCB.Length > 0)
                            //{
                            //    DataTable dtPCB = drsPCB.CopyToDataTable();
                            //    TextUtils.DatatableToCSV(dtPCB, path + "\\Vật tư điện tử không có giá.csv");
                            //    File.Move(path + "\\Vật tư điện tử không có giá.csv", path + "\\Vật tư điện tử không có giá.xls");
                            //    DataRow[] drsData = dtData.Select("TypeName not like 'PCB%'");
                            //    if (drsData.Length > 0)
                            //    {
                            //        dtData = drsData.CopyToDataTable();
                            //    }
                            //    else
                            //    {
                            //        dtData.Rows.Clear();
                            //    }
                            //}
                            #endregion

                            #region Co khi
                            //DataRow[] drsCoKhi = dtData.Select("(ThongSo = 'TPA' or ThongSo = 'CG' or ThongSo = 'GCCX' or ThongSo = 'HÀN') and (MaVatLieu = '' or MaVatLieu is null)");
                            //if (drsCoKhi.Length > 0)
                            //{
                            //    int count = 0;
                            //    DataTable dtCoKhi = drsCoKhi.CopyToDataTable();
                            //    TextUtils.DatatableToCSV(dtCoKhi, path + "\\Vật tư cơ khí không có giá.csv");
                            //    File.Move(path + "\\Vật tư cơ khí không có giá.csv", path + "\\Vật tư cơ khí không có giá.xls");
                            //    string coKhiPath = path + "\\Bản vẽ cơ khí";
                            //    Directory.CreateDirectory(coKhiPath);
                            //    foreach (DataRow row in drsCoKhi)
                            //    {
                            //        string thongSo = TextUtils.ToString(row["ThongSo"]).Trim();
                            //        string moduleCode = TextUtils.ToString(row["TypeName"]).Trim();
                            //        string partsCode = TextUtils.ToString(row["MaVatTu"]).Trim();
                            //        string indexPart = TextUtils.ToString(row["STT"]).Trim();
                            //        if (thongSo == "HÀN")
                            //        {
                            //            string dmvtFilePath = "Thietke.Ck/" + moduleCode.Substring(0, 6) + "/" + moduleCode + ".Ck/VT."
                            //            + moduleCode + ".xlsm";
                            //            if (DocUtils.CheckExits(dmvtFilePath))
                            //            {
                            //                DocUtils.DownloadFile(coKhiPath, Path.GetFileName(dmvtFilePath), dmvtFilePath);
                            //            }
                            //            string pathDMVT = coKhiPath + "/" + Path.GetFileName(dmvtFilePath);
                            //            DataTable dtDMVT = TextUtils.ExcelToDatatableNoHeader(pathDMVT, "DMVT");
                            //            if (File.Exists(pathDMVT))
                            //            {
                            //                File.Delete(pathDMVT);
                            //            }
                            //            DataRow[] drs = dtDMVT.Select("F1 like '" + indexPart + ".%' and F4 like 'TPAD.%'");
                            //            string ftpPath1 = string.Format("/Thietke.Ck/{0}/{1}.Ck/CAD.{1}/",
                            //                moduleCode.Substring(0, 6), moduleCode);
                            //            foreach (DataRow row1 in drs)
                            //            {
                            //                string code = TextUtils.ToString(row1["F4"]);
                            //                string ftpCadFile = ftpPath1 + code + ".dwg";
                            //                if (DocUtils.CheckExits(ftpCadFile))
                            //                {
                            //                    DocUtils.DownloadFile(coKhiPath, Path.GetFileName(ftpCadFile), ftpCadFile);
                            //                    count++;
                            //                }
                            //            }
                            //        }
                                    
                            //        string ftpPath = string.Format("/Thietke.Ck/{0}/{1}.Ck/CAD.{1}/{2}.dwg",
                            //        moduleCode.Substring(0, 6), moduleCode, partsCode);
                            //        if (DocUtils.CheckExits(ftpPath))
                            //        {
                            //            DocUtils.DownloadFile(coKhiPath, Path.GetFileName(ftpPath), ftpPath);
                            //            count++;
                            //        }                                    
                            //    }
                            //    if (count > 0)
                            //    {
                            //        TextUtils.ZipFolder(coKhiPath);
                            //    }

                            //    var results = from myRow in dtData.AsEnumerable()
                            //                  where TextUtils.ToString(myRow.Field<string>("ThongSo")).Trim() != "TPA"
                            //                          && TextUtils.ToString(myRow.Field<string>("ThongSo")).Trim() != "CG"
                            //                          && TextUtils.ToString(myRow.Field<string>("ThongSo")).Trim() != "GCCX"
                            //                          && TextUtils.ToString(myRow.Field<string>("ThongSo")).Trim() != "HÀN"
                            //                          //&& TextUtils.ToString(myRow.Field<string>("MaVatLieu")).Trim() != ""
                            //                  select myRow;
                            //    if (results != null)
                            //    {
                            //        if (results.Count() > 0)
                            //        {
                            //            dtData = results.CopyToDataTable();
                            //        }
                            //        else
                            //        {
                            //            dtData.Rows.Clear();
                            //        }
                            //    }
                            //    else
                            //    {
                            //        dtData.Rows.Clear();
                            //    }
                            //}
                            #endregion
                            #endregion

                            #region Vat tu ngung su dung
                            DataRow[] drsNSD = dtData.Select("NgungSuDung = '1'");
                            if (drsNSD.Length > 0)
                            {
                                DataTable dtNSD = drsNSD.CopyToDataTable();
                                TextUtils.DatatableToCSV(dtNSD, path + "\\Vật tư ngừng sử dụng.csv");
                                File.Move(path + "\\Vật tư ngừng sử dụng.csv", path + "\\Vật tư ngừng sử dụng.xls");
                                DataRow[] drsData = dtData.Select("NgungSuDung <> '1'");
                                if (drsData.Length > 0)
                                {
                                    dtData = drsData.CopyToDataTable();
                                }
                                else
                                {
                                    dtData.Rows.Clear();
                                }
                            }
                            #endregion

                            if (dtData.Rows.Count > 0)
                            {
                                TextUtils.DatatableToCSV(dtData, path + "\\Vật tư hàng hãng không có giá.csv");
                                File.Move(path + "\\Vật tư hàng hãng không có giá.csv", path + "\\Vật tư hàng hãng không có giá.xls");
                            }
                        }
                        MessageBox.Show("Xuất danh sách vật tư không có giá thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        #endregion
                    }
                }
                else
                {
                    Process.Start(localPath);
                }
            }
            catch (Exception)
            {
            }
        }       

        private void btnSave_Click(object sender, EventArgs e)
        {
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();
            try
            {
                if (!ValidateForm())
                    return;

                #region DesignSummary
                DesignSummary.HangMuc = txtHangMuc.Text.Trim();
                DesignSummary.ProjectId = TextUtils.ToString(grvProject.GetFocusedRowCellValue(colProjectID));
                DesignSummary.ProductId = TextUtils.ToString(cboProduct.EditValue);               
                DesignSummary.ProductCodeTK = txtProductCodeTK.Text.Trim().ToUpper();                
                DesignSummary.ProductNameTK = txtProductNameTK.Text.Trim().ToUpper();
                DesignSummary.ProjectCode = TextUtils.ToString(cboProject.EditValue);
                DesignSummary.ContractId = TextUtils.ToString(cboContract.EditValue);
                DesignSummary.UserNamePTC = txtPhuTrachHD.Text.Trim();
                DesignSummary.CustomerName = txtCustomer.Text.Trim();
                DesignSummary.DateHT = TextUtils.ToDate(dtpDateHT.EditValue.ToString());
                DesignSummary.DateYC = TextUtils.ToDate(dtpDateYC.EditValue.ToString());
                DesignSummary.DepartmentIDTH =TextUtils.ToInt(cboBoPhanTH.SelectedValue);
                DesignSummary.DepartmentIDYC = TextUtils.ToInt(cboBoPhanYC.SelectedValue);
                DesignSummary.Version = txtLanBanHanh.Text;
                DesignSummary.UserID = TextUtils.ToInt(cboUserTK.EditValue);

                DesignSummary.UpdatedDate = TextUtils.GetSystemDate();
                DesignSummary.UpdatedBy = Global.AppUserName;
                if (DesignSummary.ID == 0)
	            {
                    CreateVTP(DesignSummary);
                    DesignSummary.CreatedDate = TextUtils.GetSystemDate();
                    DesignSummary.CreatedBy = Global.AppUserName;
                    DesignSummary.ID = (long)pt.Insert(DesignSummary);
	            }
                else
                {
                    if (grvVT.RowCount > 0 && TextUtils.ToString(DesignSummary.ProductCodePhu) == "")
                    {
                        CreateVTP(DesignSummary);
                    }
                    pt.Update(DesignSummary);
                }
                #endregion

                #region Module Items
                for (int i = 0; i < grvModule.RowCount; i++)
                {
                    long id = TextUtils.ToInt64(grvModule.GetRowCellValue(i, colMID));
                    DesignSummaryItemModel itemModel = new DesignSummaryItemModel();
                    if (id > 0)
                    {
                        itemModel = (DesignSummaryItemModel)DesignSummaryItemBO.Instance.FindByPK(id);
                    }

                    itemModel.Code = TextUtils.ToString(grvModule.GetRowCellValue(i,colMCode));
                    itemModel.CodeHD = TextUtils.ToString(grvModule.GetRowCellValue(i, colMCodeHD));
                    itemModel.CVersion = TextUtils.ToInt(grvModule.GetRowCellValue(i, colMCVersion));
                    itemModel.DesignSummaryID = DesignSummary.ID;
                    itemModel.Hang = TextUtils.ToString(grvModule.GetRowCellValue(i, colMHang));
                    itemModel.Name = TextUtils.ToString(grvModule.GetRowCellValue(i, colMName));
                    itemModel.NameHD = TextUtils.ToString(grvModule.GetRowCellValue(i, colMNameHD));
                    itemModel.Price = 0;
                    itemModel.TotalPrice = 0;
                    itemModel.Qty = TextUtils.ToDecimal(grvModule.GetRowCellValue(i, colMQty));
                    itemModel.QtyError = TextUtils.ToInt(grvModule.GetRowCellValue(i, colMError));
                    itemModel.QtyKPH = TextUtils.ToInt(grvModule.GetRowCellValue(i, colMKPH));
                    itemModel.QtyTon = 0;
                    itemModel.Status = TextUtils.ToInt(grvModule.GetRowCellValue(i, colMStatus));
                    itemModel.Type = 0;
                    itemModel.Unit = TextUtils.ToString(grvModule.GetRowCellValue(i, colMUnit));
                    itemModel.PriceHD = TextUtils.ToDecimal(grvModule.GetRowCellValue(i, colMPriceHD));
                    if (id > 0)
                    {
                        pt.Update(itemModel);
                    }
                    else
                    {
                        pt.Insert(itemModel);
                    }                   
                }
                #endregion

                #region Material Items
                for (int i = 0; i < grvVT.RowCount; i++)
                {
                    long id = TextUtils.ToInt64(grvVT.GetRowCellValue(i, colMaID));
                    DesignSummaryItemModel itemModel = new DesignSummaryItemModel();
                    if (id > 0)
                    {
                        itemModel = (DesignSummaryItemModel)DesignSummaryItemBO.Instance.FindByPK(id);
                    }

                    itemModel.Code = TextUtils.ToString(grvVT.GetRowCellValue(i, colMaCode));
                    //itemModel.CodeHD = TextUtils.ToString(grvVT.GetRowCellValue(i, colMaCodeHD));
                    //itemModel.CVersion = TextUtils.ToInt(grvVT.GetRowCellValue(i, colMaCVersion));
                    itemModel.DesignSummaryID = DesignSummary.ID;
                    itemModel.Hang = TextUtils.ToString(grvVT.GetRowCellValue(i, colMaHang));
                    itemModel.Name = TextUtils.ToString(grvVT.GetRowCellValue(i, colMaName));
                    //itemModel.NameHD = TextUtils.ToString(grvVT.GetRowCellValue(i, colMaNameHD));
                    itemModel.Price = 0;
                    itemModel.TotalPrice = 0;
                    itemModel.Qty = TextUtils.ToDecimal(grvVT.GetRowCellValue(i, colMaQty));
                    itemModel.QtyError = TextUtils.ToInt(grvVT.GetRowCellValue(i, colMaError));
                    itemModel.QtyKPH = TextUtils.ToInt(grvVT.GetRowCellValue(i, colMaKPH));
                    itemModel.QtyTon = TextUtils.ToDecimal(grvVT.GetRowCellValue(i, colMaTonKho));
                    itemModel.Status = TextUtils.ToInt(grvVT.GetRowCellValue(i, colMaStatus));
                    itemModel.Type = 1;
                    //itemModel.Unit = TextUtils.ToString(grvVT.GetRowCellValue(i, colMaUnit));

                    if (id > 0)
                    {
                        pt.Update(itemModel);
                    }
                    else
                    {
                        pt.Insert(itemModel);
                    }           
                }
                #endregion

                pt.CommitTransaction();
                _isSaved = true;
                if (this.LoadDataChange != null)
                {
                    this.LoadDataChange(null, null);
                }
                loadItem(0);
                loadItem(1);
                
                MessageBox.Show("Lưu trữ thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                pt.CloseConnection();
            }
        }

        private void frmDesignSummary_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_isSaved)
            {
                if (this.LoadDataChange != null)
                {
                    this.LoadDataChange(null, null);
                }
                DialogResult = DialogResult.OK;
            }
        }

        private void cboProductTK_EditValueChanged(object sender, EventArgs e)
        {
            string code = TextUtils.ToString(grvCboProductTK.GetFocusedRowCellValue(colPCode));
            if (code == "")
                return;
            string name = TextUtils.ToString(grvCboProductTK.GetFocusedRowCellValue(colPName));
            txtProductCodeTK.Text = code;
            txtProductNameTK.Text = name;
        }

        private void btnModulePrice_Click(object sender, EventArgs e)
        {
            string moduleCode = TextUtils.ToString(grvModule.GetFocusedRowCellValue(colMCode));
            if (moduleCode == "") return;
            BMS.Model.ModulesModel model = (BMS.Model.ModulesModel)BMS.Business.ModulesBO.Instance.FindByCode(moduleCode);
            if (model.Status != 2)
            {
                MessageBox.Show("Module chưa có trên nguồn chuẩn!");
                return;
            }
            frmModulePrice frm = new frmModulePrice();
            frm.Module = model;
            frm.Show();
        }

        private void btnModulePriceVTP_Click(object sender, EventArgs e)
        {
            string moduleCode = TextUtils.ToString(grvVT.GetFocusedRowCellValue(colMaCode));
            if (moduleCode == "") return;
            BMS.Model.ModulesModel model = (BMS.Model.ModulesModel)BMS.Business.ModulesBO.Instance.FindByCode(moduleCode);
            if (model.Status != 2)
            {
                MessageBox.Show("Module chưa có trên nguồn chuẩn!");
                return;
            }
            frmModulePrice frm = new frmModulePrice();
            frm.Module = model;
            frm.Show();
        }

        private void btnUpdateError_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grvModule.RowCount; i++)
            {
                int id = TextUtils.ToInt(grvModule.GetRowCellValue(i, colMID));
                if (id == 0) continue;
                string code = grvModule.GetRowCellValue(i, colMCode).ToString();
                if (code == "") continue;
                BMS.Model.ModulesModel module = (BMS.Model.ModulesModel)BMS.Business.ModulesBO.Instance.FindByCode(code);
                if (module == null) continue;
                DataTable dtError = TextUtils.Select("select ISNULL(count(*), 0) from dbo.ModuleError with (nolock) where ModuleID =" + module.ID + " and Status = 0 and ConfirmTemp = 0");
                DataTable dtKPH = TextUtils.Select("select ISNULL(count(*), 0) from dbo.MisMatch with (nolock) where ModuleCode ='" + code + "' and StatusKCS = 0 and ConfirmTemp = 0");

                grvModule.SetRowCellValue(i, colMError, TextUtils.ToInt(dtError.Rows[0][0]));
                grvModule.SetRowCellValue(i, colMKPH, TextUtils.ToInt(dtKPH.Rows[0][0]));

                DesignSummaryItemModel ditem = (DesignSummaryItemModel)DesignSummaryItemBO.Instance.FindByPK(id);
                ditem.QtyError = TextUtils.ToInt(grvModule.GetRowCellValue(i, colMError));
                ditem.QtyKPH = TextUtils.ToInt(grvModule.GetRowCellValue(i, colMKPH));
                DesignSummaryItemBO.Instance.Update(ditem);
                //
            }

            for (int i = 0; i < grvVT.RowCount; i++)
            {
                int id = TextUtils.ToInt(grvVT.GetRowCellValue(i, colMaID));
                if (id == 0) continue;
                string code = grvVT.GetRowCellValue(i, colMaCode).ToString();
                if (code == "") continue;
                BMS.Model.ModulesModel module = (BMS.Model.ModulesModel)BMS.Business.ModulesBO.Instance.FindByCode(code);
                if (module == null) continue;

                DataTable dtError = TextUtils.Select("select ISNULL(count(*), 0) from dbo.ModuleError with (nolock) where ModuleID =" + module.ID + " and Status = 0 and ConfirmTemp = 0");
                DataTable dtKPH = TextUtils.Select("select ISNULL(count(*), 0) from dbo.MisMatch with (nolock) where ModuleCode ='" + code + "' and StatusKCS = 0 and ConfirmTemp = 0");

                grvVT.SetRowCellValue(i, colMaError, TextUtils.ToInt(dtError.Rows[0][0]));
                grvVT.SetRowCellValue(i, colMaKPH, TextUtils.ToInt(dtKPH.Rows[0][0]));

                DesignSummaryItemModel ditem = (DesignSummaryItemModel)DesignSummaryItemBO.Instance.FindByPK(id);
                ditem.QtyError = TextUtils.ToInt(grvVT.GetRowCellValue(i, colMaError));
                ditem.QtyKPH = TextUtils.ToInt(grvVT.GetRowCellValue(i, colMaKPH));
                DesignSummaryItemBO.Instance.Update(ditem);
            }
        }

        private void grvModule_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colMCodeHD)
            {
                string moduleCodeHD = TextUtils.ToString(grvModule.GetFocusedRowCellValue(colMCodeHD));
                if (_dtPriceDauVao.Rows.Count > 0)
                {
                    DataRow[] drs = _dtPriceDauVao.Select("F3 = '" + moduleCodeHD + "'");
                    if (drs.Length > 0)
                    {
                        grvModule.SetFocusedRowCellValue(colMPriceHD, TextUtils.ToDecimal(drs[0]["F6"]));
                    }
                }        
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (!validate()) return;
            _dtError.Rows.Clear();
            DocUtils.InitFTPQLSX();

            #region init table
            DataTable dtData = new DataTable();
            //dtData.Columns.Add("F1");
            //dtData.Columns.Add("F2");
            //dtData.Columns.Add("F3");
            //dtData.Columns.Add("F4");
            //dtData.Columns.Add("F5");
            //dtData.Columns.Add("F6");
            //dtData.Columns.Add("F7");
            //dtData.Columns.Add("F8");
            //dtData.Columns.Add("F9");
            //dtData.Columns.Add("F10");
            //dtData.Columns.Add("F11");
            //dtData.Columns.Add("F12");
            //dtData.Columns.Add("TypeName");
            //dtData.Columns.Add("Type");
            //dtData.Columns.Add("Price", typeof(decimal));
            //dtData.Columns.Add("TotalPrice", typeof(decimal));
            //dtData.Columns.Add("NgungSuDung");
            //dtData.Columns.Add("GiaQuaHan", typeof(int));
            #endregion

            try
            {
                #region Thông tin chung
                string khachHang = "Tên KH cuối: " + txtCustomer.Text.Trim();
                string soHopDong = "";
                if (TextUtils.ToString(grvContract.GetFocusedRowCellValue(colContractCode)) != "")
                {
                    soHopDong = "Số HĐ: " + TextUtils.ToString(grvContract.GetFocusedRowCellValue(colContractCode));
                }
                else
                {
                    soHopDong = "Số HĐ: ";
                }

                string bophanYC = "Bộ Phận YC: " + cboBoPhanYC.Text;
                string ngayYC = "Ngày YC: " + TextUtils.ToDate(dtpDateYC.EditValue.ToString()).ToString("dd/MM/yyyy");
                string phutrachHD = "Phụ trách HĐ: " + txtPhuTrachHD.Text.Trim();
                string bophanTK = "Bộ Phận TH: " + cboBoPhanTH.Text;
                string ngayHT = "Ngày HT: " + TextUtils.ToDate(dtpDateHT.EditValue.ToString()).ToString("dd/MM/yyyy");
                string phutrachTK = "Phụ trách TK: " + cboUserTK.Text;
                string nameHD = "Tên sản phẩm theo hợp đồng: " + TextUtils.ToString(grvProduct.GetFocusedRowCellValue(colTenThietBi));
                string codeHD = "Mã SP theo hợp đồng: " + TextUtils.ToString(grvProduct.GetFocusedRowCellValue(colMaThietBi));
                string hangMuc = "Hạng mục: " + txtHangMuc.Text.Trim();
                string lanBanHanh = txtLanBanHanh.Text.Trim();
                string nameTK = "Tên sản phẩm theo thiết kế: " + txtProductNameTK.Text.Trim();
                string codeTK = "Mã SP theo thiết kế: " + txtProductCodeTK.Text.Trim();
                #endregion

                #region Đường dẫn
                string localPath = "";

                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    localPath = fbd.SelectedPath + "\\THTK - Muc " + txtHangMuc.Text.Trim() + " - " + txtProductNameTK.Text + ".xlsm";
                }
                else
                {
                    return;
                }

                string filePath = Application.StartupPath + "\\Templates\\THTK.xlsm";

                try
                {
                    File.Copy(filePath, localPath, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: File excel đang được mở.");
                    return;
                }
                #endregion

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

                        #region Thông tin chung
                        workSheet.Cells[3, 1] = "Số: " + txtHangMuc.Text.Trim() + "-"
                            + (grvContract.GetFocusedRowCellValue(colContractCode) == null ? "" : grvContract.GetFocusedRowCellValue(colContractCode).ToString())
                            + "-PTK/" + lanBanHanh;

                        workSheet.Cells[4, 1] = khachHang;
                        workSheet.Cells[4, 8] = cboProject.EditValue.ToString();
                        workSheet.Cells[4, 11] = soHopDong;

                        workSheet.Cells[5, 1] = bophanYC;
                        workSheet.Cells[5, 8] = ngayYC;
                        workSheet.Cells[5, 11] = phutrachHD;

                        workSheet.Cells[6, 1] = bophanTK;
                        workSheet.Cells[6, 8] = ngayHT;
                        workSheet.Cells[6, 11] = phutrachTK;

                        workSheet.Cells[7, 1] = nameHD;
                        workSheet.Cells[7, 8] = codeHD;
                        workSheet.Cells[7, 12] = hangMuc;

                        workSheet.Cells[8, 1] = nameTK;
                        workSheet.Cells[8, 8] = codeTK;

                        if (grvVT.RowCount > 0)
                        {
                            workSheet.Cells[14, 3] = DesignSummary.ProductNamePhu;
                            workSheet.Cells[14, 4] = DesignSummary.ProductCodePhu;
                        }
                        workSheet.Cells[19, 10] = "Hà Nội, ngày " + string.Format("{0:00}", DateTime.Now.Day)
                            + " tháng " + string.Format("{0:00}", DateTime.Now.Month)
                            + " năm " + DateTime.Now.Year;
                        #endregion

                        #region Thêm vật tư vào biểu mẫu
                        int rowCountMa = grvVT.RowCount;
                        for (int i = rowCountMa - 1; i >= 0; i--)
                        {
                            try
                            {
                                ((Excel.Range)workSheet.Rows[17]).Insert();

                                string code = grvVT.GetRowCellValue(i, colMaCode).ToString();
                                string name = TextUtils.ToString(grvVT.GetRowCellValue(i, colMaName));
                                int error = TextUtils.ToInt(grvVT.GetRowCellValue(i, colMaError));
                                int kph = TextUtils.ToInt(grvVT.GetRowCellValue(i, colMaKPH));

                                if (error > 0 || kph > 0)
                                {
                                    DataRow drError = _dtError.NewRow();
                                    drError["Code"] = code;
                                    drError["Name"] = name;
                                    drError["Error"] = error;
                                    drError["KPH"] = kph;
                                    _dtError.Rows.Add(drError);
                                }

                                workSheet.Cells[18, 1] = i + 1;
                                workSheet.Cells[18, 3] = grvVT.GetRowCellValue(i, colMaName).ToString();
                                workSheet.Cells[18, 5] = code;
                                workSheet.Cells[18, 6] = grvVT.GetRowCellValue(i, colMaHang).ToString();
                                workSheet.Cells[18, 7] = grvVT.GetRowCellValue(i, colMaQty).ToString();
                                workSheet.Cells[18, 8] = grvVT.GetRowCellValue(i, colMaError).ToString() == "0" ? "" : grvVT.GetRowCellValue(i, colMaError).ToString();
                                workSheet.Cells[18, 9] = grvVT.GetRowCellValue(i, colMaKPH).ToString() == "0" ? "" : grvVT.GetRowCellValue(i, colMaKPH).ToString();
                                workSheet.Cells[18, 10] = grvVT.GetRowCellValue(i, colMaTonKho).ToString() == "0" ? "0" : grvVT.GetRowCellValue(i, colMaTonKho).ToString();

                                decimal total = 0;

                                if (code.StartsWith("TPAD") && code.Length == 10)
                                {
                                    //DataTable dtNoPrice = new DataTable();
                                    DataTable dt = TextUtils.GetPriceTPAD(code, true);
                                    if (dt.Rows.Count > 0)
                                    {
                                        total = TextUtils.ToDecimal(dt.Compute("Sum(TotalPrice)", ""));

                                        if (dtData.Rows.Count == 0)
                                        {
                                            if (dt.Rows.Count > 0)
                                            {
                                                dtData = dt;
                                            }
                                        }
                                        else
                                        {
                                            if (dt.Rows.Count > 0)
                                                dtData.Merge(dt);
                                        }

                                        //Update Price
                                        if (dt.Rows.Count == 0)
                                        {
                                            try
                                            {
                                                long id = TextUtils.ToInt64(grvVT.GetRowCellValue(i, colMaID));
                                                DesignSummaryItemModel item = (DesignSummaryItemModel)DesignSummaryItemBO.Instance.FindByPK(id);
                                                item.Price = total;
                                                item.TotalPrice = total * item.Qty;
                                                DesignSummaryItemBO.Instance.Update(item);
                                            }
                                            catch (Exception)
                                            {
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    //DataTable dtPrice = LibQLSX.Select("select Price from Parts with(nolock) where PartsCode = '" + code + "'");
                                    //string sqlM = "SELECT top 1 Price FROM  vGetPriceOfPart with(nolock)"
                                    //                       + " WHERE Price > 1 AND replace(replace([PartsCode],'/','#'),')','#') = '" + code + "'"
                                    //                       + " ORDER BY DateAboutF DESC";
                                    //DataTable dtPrice = LibQLSX.Select(sqlM);

                                    string sqlM = "exec spGetPriceOfPart '" + code + "'";
                                    DataTable dtPrice = LibQLSX.Select(sqlM);

                                    if (dtPrice.Rows.Count > 0)
                                    {
                                        total = TextUtils.ToDecimal(dtPrice.Rows[0]["Price"]);
                                        if (total == 0)
                                        {
                                            DataRow dr = dtData.NewRow();
                                            dr["F2"] = grvVT.GetRowCellValue(i, colMaName).ToString();
                                            dr["F4"] = code;
                                            dtData.Rows.Add(dr);
                                        }
                                    }
                                }
                                workSheet.Cells[18, 11] = total.ToString("n0");
                                workSheet.Cells[18, 12] = "";
                                workSheet.Cells[18, 13] = "VTP";
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        ((Excel.Range)workSheet.Rows[16]).Delete();
                        ((Excel.Range)workSheet.Rows[16]).Delete();
                        #endregion

                        #region Thêm module vào biểu mẫu
                        int rowCountMo = grvModule.RowCount;
                        for (int i = rowCountMo - 1; i >= 0; i--)
                        {
                            string code = grvModule.GetRowCellValue(i, colMCode).ToString();
                            if (code == "") continue;
                            try
                            {
                                ((Excel.Range)workSheet.Rows[12]).Insert();

                                string name = TextUtils.ToString(grvModule.GetRowCellValue(i, colMName));
                                int error = TextUtils.ToInt(grvModule.GetRowCellValue(i, colMError));
                                int kph = TextUtils.ToInt(grvModule.GetRowCellValue(i, colMKPH));

                                if (error > 0 || kph > 0)
                                {
                                    DataRow drError = _dtError.NewRow();
                                    drError["Code"] = code;
                                    drError["Name"] = name;
                                    drError["Error"] = error;
                                    drError["KPH"] = kph;
                                    _dtError.Rows.Add(drError);
                                }

                                workSheet.Cells[13, 1] = i + 1;
                                workSheet.Cells[13, 2] = grvModule.GetRowCellValue(i, colMNameHD).ToString();
                                workSheet.Cells[13, 3] = grvModule.GetRowCellValue(i, colMName).ToString();
                                workSheet.Cells[13, 4] = grvModule.GetRowCellValue(i, colMCodeHD).ToString();
                                workSheet.Cells[13, 5] = grvModule.GetRowCellValue(i, colMCode).ToString();
                                workSheet.Cells[13, 6] = grvModule.GetRowCellValue(i, colMHang).ToString();
                                workSheet.Cells[13, 7] = grvModule.GetRowCellValue(i, colMQty).ToString();
                                workSheet.Cells[13, 8] = grvModule.GetRowCellValue(i, colMError).ToString();
                                workSheet.Cells[13, 9] = grvModule.GetRowCellValue(i, colMKPH).ToString();
                                workSheet.Cells[13, 10] = grvModule.GetRowCellValue(i, colMStatus).ToString() == "2" ? "Đã chuẩn" : "";

                                decimal total = 0;
                                string note = "";
                                if (code.StartsWith("TPAD") && code.Length == 10)
                                {
                                    //DataTable dtNoPrice = new DataTable();
                                    DataTable dt = TextUtils.GetPriceTPAD(code, true);
                                    if (dt.Rows.Count > 0)
                                    {
                                        total = TextUtils.ToDecimal(dt.Compute("Sum(TotalPrice)", ""));

                                        if (dtData.Rows.Count == 0)
                                        {
                                            if (dt.Rows.Count > 0)
                                            {
                                                dtData = dt;
                                            }
                                        }
                                        else
                                        {
                                            if (dt.Rows.Count > 0)
                                                dtData.Merge(dt);
                                        }

                                        //Lấy danh sách các vật tư phụ của module
                                        BMS.Model.ModulesModel module = (BMS.Model.ModulesModel)BMS.Business.ModulesBO.Instance.FindByCode(code);
                                        if (module != null)
                                        {
                                            DataTable dtPart = TextUtils.Select("select * from ModulePart with(nolock) where ModuleID = " + module.ID);
                                            note = getModulePart(dtPart);
                                        }

                                        //Update Price
                                        if (dt.Rows.Count == 0)
                                        {
                                            try
                                            {
                                                long id = TextUtils.ToInt64(grvModule.GetRowCellValue(i, colMID));
                                                DesignSummaryItemModel item = (DesignSummaryItemModel)DesignSummaryItemBO.Instance.FindByPK(id);
                                                item.Price = total;
                                                item.TotalPrice = total * item.Qty;
                                                DesignSummaryItemBO.Instance.Update(item);
                                            }
                                            catch (Exception)
                                            {
                                            }
                                        }
                                    }
                                }
                                workSheet.Cells[13, 11] = total.ToString("n0");
                                workSheet.Cells[13, 12] = TextUtils.ToDecimal(grvModule.GetRowCellValue(i, colMPriceHD)).ToString("n0");
                                workSheet.Cells[13, 13] = note;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        ((Excel.Range)workSheet.Rows[11]).Delete();
                        ((Excel.Range)workSheet.Rows[11]).Delete();
                        #endregion
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

                dtData.Columns.Remove("F11");
                dtData.Columns.Remove("F12");
                dtData.Columns.Remove("ID");

                DataTable dtAll = dtData.Copy();
                DataRow[] drs1 = dtData.Select("Price = 0 or Price is null");
                if (drs1.Length > 0)
                {
                    dtData = drs1.CopyToDataTable();
                }
                else
                {
                    dtData.Rows.Clear();
                }

                if (dtData.Rows.Count > 0 || _dtError.Rows.Count > 0)
                {
                    File.Delete(localPath);
                    MessageBox.Show("Có nhiều vật tư chưa có giá hoặc module có lỗi. \nBạn không thể tạo tổng hợp thiết kế.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    FolderBrowserDialog fbd1 = new FolderBrowserDialog();
                    if (fbd1.ShowDialog() == DialogResult.OK)
                    {
                        string path = fbd1.SelectedPath + "\\" + TextUtils.ToString(cboProject.EditValue) + "-" + txtHangMuc.Text.Trim() + "-Vật tư không có giá - lỗi\\";
                        Directory.CreateDirectory(path);

                        #region Xuất module lỗi, không phù hợp
                        if (_dtError.Rows.Count > 0)
                        {
                            TextUtils.DatatableToCSV(_dtError, path + "\\Module lỗi-KPH.csv");
                            File.Move(path + "\\Module lỗi-KPH.csv", path + "\\Module lỗi-KPH.csv.xls");
                        }
                        #endregion

                        #region Xuất danh sách file không có giá
                        using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang xuất vật tư không có giá..."))
                        {
                            #region Doi ten column
                            //dtData.Columns["F1"].ColumnName = "STT";
                            //dtData.Columns["F2"].ColumnName = "TenVatTu";
                            //dtData.Columns["F3"].ColumnName = "ThongSo";
                            //dtData.Columns["F4"].ColumnName = "MaVatTu";
                            //dtData.Columns["F5"].ColumnName = "MaVatLieu";
                            //dtData.Columns["F6"].ColumnName = "DonVi";
                            //dtData.Columns["F7"].ColumnName = "SL";
                            //dtData.Columns["F8"].ColumnName = "VatLieu";
                            //dtData.Columns["F9"].ColumnName = "KhoiLuong";
                            //dtData.Columns["F10"].ColumnName = "Hang";
                            #endregion                            

                            #region Vat tu ngung su dung
                            DataRow[] drsNSD = dtData.Select("NgungSuDung = '1'");
                            if (drsNSD.Length > 0)
                            {
                                DataTable dtNSD = drsNSD.CopyToDataTable();
                                TextUtils.DatatableToCSV(dtNSD, path + "\\Vật tư ngừng sử dụng.csv");
                                File.Move(path + "\\Vật tư ngừng sử dụng.csv", path + "\\Vật tư ngừng sử dụng.xls");
                                DataRow[] drsData = dtData.Select("NgungSuDung <> '1'");
                                if (drsData.Length > 0)
                                {
                                    dtData = drsData.CopyToDataTable();
                                }
                                else
                                {
                                    dtData.Rows.Clear();
                                }
                            }
                            #endregion

                            #region No Price
                            #region Ke toan
                            //DataRow[] drsPhip = dtData.Select("VatLieu like 'PHÍP%' or (MaVatLieu <> '' and MaVatLieu is not null)");
                            //if (drsPhip.Length > 0)
                            //{
                            //    DataTable dtPhip = drsPhip.CopyToDataTable();
                            //    TextUtils.DatatableToCSV(dtPhip, path + "\\Vật tư hỏi giá kế toán.csv");
                            //    File.Move(path + "\\Vật tư hỏi giá kế toán.csv", path + "\\Vật tư hỏi giá kế toán.xls");
                            //    DataRow[] drsData = dtData.Select("VatLieu not like 'PHÍP%' and MaVatLieu = ''");
                            //    if (drsData.Length > 0)
                            //    {
                            //        dtData = drsData.CopyToDataTable();
                            //    }
                            //    else
                            //    {
                            //        dtData.Rows.Clear();
                            //    }
                            //}
                            #endregion

                            #region Dien tu
                            //DataRow[] drsPCB = dtData.Select("TypeName like 'PCB%'");
                            //if (drsPCB.Length > 0)
                            //{
                            //    DataTable dtPCB = drsPCB.CopyToDataTable();
                            //    TextUtils.DatatableToCSV(dtPCB, path + "\\Vật tư điện tử không có giá.csv");
                            //    File.Move(path + "\\Vật tư điện tử không có giá.csv", path + "\\Vật tư điện tử không có giá.xls");
                            //    DataRow[] drsData = dtData.Select("TypeName not like 'PCB%'");
                            //    if (drsData.Length > 0)
                            //    {
                            //        dtData = drsData.CopyToDataTable();
                            //    }
                            //    else
                            //    {
                            //        dtData.Rows.Clear();
                            //    }
                            //}
                            #endregion

                            #region Co khi
                            //DataRow[] drsCoKhi = dtData.Select("(ThongSo = 'TPA' or ThongSo = 'CG' or ThongSo = 'GCCX' or ThongSo = 'HÀN') and (MaVatLieu = '' or MaVatLieu is null)");
                            //if (drsCoKhi.Length > 0)
                            //{
                            //    int count = 0;
                            //    DataTable dtCoKhi = drsCoKhi.CopyToDataTable();
                            //    TextUtils.DatatableToCSV(dtCoKhi, path + "\\Vật tư cơ khí không có giá.csv");
                            //    File.Move(path + "\\Vật tư cơ khí không có giá.csv", path + "\\Vật tư cơ khí không có giá.xls");
                            //    string coKhiPath = path + "\\Bản vẽ cơ khí";
                            //    Directory.CreateDirectory(coKhiPath);
                            //    foreach (DataRow row in drsCoKhi)
                            //    {
                            //        string thongSo = TextUtils.ToString(row["ThongSo"]).Trim();
                            //        string moduleCode = TextUtils.ToString(row["TypeName"]).Trim();
                            //        string partsCode = TextUtils.ToString(row["MaVatTu"]).Trim();
                            //        string indexPart = TextUtils.ToString(row["STT"]).Trim();
                            //        if (thongSo == "HÀN")
                            //        {
                            //            string dmvtFilePath = "Thietke.Ck/" + moduleCode.Substring(0, 6) + "/" + moduleCode + ".Ck/VT."
                            //            + moduleCode + ".xlsm";
                            //            if (DocUtils.CheckExits(dmvtFilePath))
                            //            {
                            //                DocUtils.DownloadFile(coKhiPath, Path.GetFileName(dmvtFilePath), dmvtFilePath);
                            //            }
                            //            string pathDMVT = coKhiPath + "/" + Path.GetFileName(dmvtFilePath);
                            //            DataTable dtDMVT = TextUtils.ExcelToDatatableNoHeader(pathDMVT, "DMVT");
                            //            if (File.Exists(pathDMVT))
                            //            {
                            //                File.Delete(pathDMVT);
                            //            }
                            //            DataRow[] drs = dtDMVT.Select("F1 like '" + indexPart + ".%' and F4 like 'TPAD.%'");
                            //            string ftpPath1 = string.Format("/Thietke.Ck/{0}/{1}.Ck/CAD.{1}/",
                            //                moduleCode.Substring(0, 6), moduleCode);
                            //            foreach (DataRow row1 in drs)
                            //            {
                            //                string code = TextUtils.ToString(row1["F4"]);
                            //                string ftpCadFile = ftpPath1 + code + ".dwg";
                            //                if (DocUtils.CheckExits(ftpCadFile))
                            //                {
                            //                    DocUtils.DownloadFile(coKhiPath, Path.GetFileName(ftpCadFile), ftpCadFile);
                            //                    count++;
                            //                }
                            //            }
                            //        }

                            //        string ftpPath = string.Format("/Thietke.Ck/{0}/{1}.Ck/CAD.{1}/{2}.dwg",
                            //        moduleCode.Substring(0, 6), moduleCode, partsCode);
                            //        if (DocUtils.CheckExits(ftpPath))
                            //        {
                            //            DocUtils.DownloadFile(coKhiPath, Path.GetFileName(ftpPath), ftpPath);
                            //            count++;
                            //        }
                            //    }
                            //    if (count > 0)
                            //    {
                            //        TextUtils.ZipFolder(coKhiPath);
                            //    }

                            //    var results = from myRow in dtData.AsEnumerable()
                            //                  where TextUtils.ToString(myRow.Field<string>("ThongSo")).Trim() != "TPA"
                            //                          && TextUtils.ToString(myRow.Field<string>("ThongSo")).Trim() != "CG"
                            //                          && TextUtils.ToString(myRow.Field<string>("ThongSo")).Trim() != "GCCX"
                            //                          && TextUtils.ToString(myRow.Field<string>("ThongSo")).Trim() != "HÀN"
                            //                  //&& TextUtils.ToString(myRow.Field<string>("MaVatLieu")).Trim() != ""
                            //                  select myRow;
                            //    if (results != null)
                            //    {
                            //        if (results.Count() > 0)
                            //        {
                            //            dtData = results.CopyToDataTable();
                            //        }
                            //        else
                            //        {
                            //            dtData.Rows.Clear();
                            //        }
                            //    }
                            //    else
                            //    {
                            //        dtData.Rows.Clear();
                            //    }
                            //}
                            #endregion                            
                            #endregion

                            if (dtData.Rows.Count > 0)
                            {
                                TextUtils.DatatableToCSV(dtData, path + "\\Vật tư không có giá.csv");
                                File.Move(path + "\\Vật tư không có giá.csv", path + "\\Vật tư không có giá.xls");
                            }
                        }
                        MessageBox.Show("Xuất danh sách vật tư không có giá thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        #endregion
                    }
                }
                else
                {                    
                    DataTable dtModule = TextUtils.GetDistinctDatatable(dtAll, "TypeName");
                    string path = Path.GetDirectoryName(localPath) + "\\" + TextUtils.ToString(cboProject.EditValue) + "-" + txtHangMuc.Text.Trim();
                    Directory.CreateDirectory(path);
                    foreach (DataRow r in dtModule.Rows)
                    {
                        string moduleCode = TextUtils.ToString(r["TypeName"]);
                        DataRow[] drs = dtAll.Select("TypeName = '" + moduleCode + "'");

                        TextUtils.DatatableToCSV(drs.CopyToDataTable(), path + "\\" + moduleCode + ".csv");
                    }
                    Process.Start(localPath);
                }
            }
            catch (Exception)
            {
            }
        }

        private void grvModule_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == (Keys.C))
            {
                try
                {
                    string text = TextUtils.ToString(grvModule.GetFocusedRowCellValue(grvModule.FocusedColumn));
                    Clipboard.SetText(text);
                }
                catch (Exception)
                {
                }
            }
        }

        private void grvVT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == (Keys.C))
            {
                try
                {
                    string text = TextUtils.ToString(grvVT.GetFocusedRowCellValue(grvVT.FocusedColumn));
                    Clipboard.SetText(text);
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
