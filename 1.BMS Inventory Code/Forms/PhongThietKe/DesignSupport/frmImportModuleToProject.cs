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
using TPA.Model;
using TPA.Business;
using TPA.Utils;
using System.Collections;
using DevExpress.XtraTreeList.Nodes;

namespace BMS
{
    public partial class frmImportModuleToProject : _Forms
    {
        DataTable _dtModule = new DataTable();
        int _count = 0;

        public frmImportModuleToProject()
        {
            InitializeComponent();
        }

        private void frmImportModuleToProject_Load(object sender, EventArgs e)
        {
            loadProject();
            grvModule.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
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

        void loadTree()
        {
            string projectCode = TextUtils.ToString(grvProject.GetFocusedRowCellValue(colProjectCode));
            try
            {
                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load danh sách sản phẩm..."))
                {
                    string[] _paraName = new string[1];
                    object[] _paraValue = new object[1];
                    _paraName[0] = "@ProjectCode"; _paraValue[0] = projectCode;
                    DataTable Source = LibQLSX.Select("select * from vGetProductOfProject where ProjectCode ='" + projectCode + "'");
                    treeData.DataSource = Source;
                    treeData.KeyFieldName = "PProductId";
                    treeData.PreviewFieldName = "MaThietBi";
                    treeData.ExpandAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cboProject_EditValueChanged(object sender, EventArgs e)
        {
            loadTree();
        }

        void loadChildModule(string moduleCode, int parentID)
        {
            DocUtils.InitFTPQLSX();
            string _serverPathCK = string.Format("Thietke.Ck/{0}/{1}.Ck/VT.{1}.xlsm", moduleCode.Substring(0, 6), moduleCode);
            string localPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (DocUtils.CheckExits(_serverPathCK))
            {
                DocUtils.DownloadFile(localPath, "VT." + moduleCode + ".xlsm", _serverPathCK);
            }
            else
            {
                return;
            }
            DataTable dtDMVT = TextUtils.ExcelToDatatable(localPath + "/VT." + moduleCode + ".xlsm", "DMVT");
            if (File.Exists(localPath + "/VT." + moduleCode + ".xlsm"))
            {
                File.Delete(localPath + "/VT." + moduleCode + ".xlsm");
            }
            DataRow[] drs = dtDMVT.Select("F4 like 'TPAD%' and len(F4) = 10");
            if (drs.Length > 0)
            {
                for (int i = 0; i < drs.Length; i++)
                {
                    string stt = TextUtils.ToString(drs[i]["F1"]);
                    decimal qty = TextUtils.ToDecimal(drs[i]["F7"]);

                    if (stt.Contains("."))
                    {
                        string[] arr = stt.Split('.');
                        string parentSTT = arr[0];
                        DataRow[] drs0 = dtDMVT.Select("F1 ='" + parentSTT + "'");
                        if (drs0.Length > 0)
                        {
                            qty *= TextUtils.ToDecimal(drs0[0]["F7"]);
                        }
                        for (int j = 1; j < arr.Length - 1; j++)
                        {
                            parentSTT += "." + TextUtils.ToString(arr[i]);
                            DataRow[] drsC = dtDMVT.Select("F1 ='" + parentSTT + "'");
                            if (drsC.Length > 0)
                            {
                                qty *= TextUtils.ToDecimal(drsC[0]["F7"]);
                            }
                        }
                    }

                    string code = TextUtils.ToString(drs[i]["F4"]);
                    string name = "";

                    DataTable dt = LibQLSX.Select("select FolderName from SourceCode with(nolock) where FolderCode = '" + code + "'");
                    if (dt.Rows.Count > 0)
                    {
                        name = TextUtils.ToString(dt.Rows[0]["FolderName"]);
                    }
                    else
                    {
                        name = TextUtils.ToString(drs[i]["F2"]);
                    }
                    _count++;
                    DataRow dr = _dtModule.NewRow();
                    dr["F3"] = name;
                    dr["F5"] = code;
                    dr["F7"] = qty;
                    dr["ID"] = _count;
                    dr["ParentID"] = parentID;
                    
                    _dtModule.Rows.Add(dr);
                    loadChildModule(code, _count);
                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load danh sách module..."))
                {
                    _count = 0;
                    _dtModule = TextUtils.ExcelToDatatableNoHeader(ofd.FileName, "3");
                    if (_dtModule.Rows.Count == 0) return;
                    DataRow[] drs = _dtModule.Select("F5 like 'TPAD%' and len(F5) = 10 and F12 <> 'VTP'");
                    DataRow[] drsVTP = _dtModule.Select("F4 like 'TB.%'");
                    if (drs.Length > 0)
                    {                       
                        _dtModule = drs.CopyToDataTable();
                        _dtModule.Columns.Add("ID", typeof(int));
                        _dtModule.Columns.Add("ParentID", typeof(int));
                        _dtModule.Columns.Add("TypeId");
                        int rowCount = _dtModule.Rows.Count;
                        for (int i = 0; i < rowCount; i++)
                        {
                            string moduleCode = TextUtils.ToString(_dtModule.Rows[i]["F5"]);
                            if (i == 0)
                            {
                                _count = 1;
                            }
                            else
                            {
                                _count++;
                            }
                            _dtModule.Rows[i]["ID"] = _count;
                            _dtModule.Rows[i]["ParentID"] = 0;
                            loadChildModule(moduleCode, _count);
                        }
                        if (drsVTP.Length > 0)
                        {
                            DataRow r = _dtModule.NewRow();                            
                            r["F3"] = TextUtils.ToString(drsVTP[0]["F3"]);
                            r["F4"] = TextUtils.ToString(drsVTP[0]["F4"]);
                            r["F5"] = TextUtils.ToString(drsVTP[0]["F4"]);
                            r["F7"] = 1.ToString();
                            _count++;
                            r["ID"] = _count;
                            if (rowCount == 1)
                            {
                                r["ParentID"] = TextUtils.ToString(_dtModule.Rows[0]["ID"]);
                            }
                            else
                            {
                                r["ParentID"] = 0;
                            }
                            _dtModule.Rows.Add(r);
                        }
                        grvModule.DataSource = null;
                        grvModule.AutoGenerateColumns = false;
                        grvModule.DataSource = _dtModule;
                    }
                }
            }
        }

        void addModule(string moduleCode, string moduleName, int ID, int parentID, int qty, string manageId, string moduleCodeHD)
        {
            string typeID = "T0068";
            DataTable dt = LibQLSX.Select("select TypeId from SourceCode with(nolock) where FolderCode = '" + moduleCode + "'");
            if (dt.Rows.Count > 0)
            {
                typeID = TextUtils.ToString(dt.Rows[0]["TypeId"]);
            }

            ProjectProductsModel projectProduct = new ProjectProductsModel();
            if (parentID == 0)
            {
                if (moduleCode.StartsWith("TPAD"))
                {
                    DataTable dtPP = LibQLSX.Select("select * from vGetProductOfProject with(nolock) where ManageId = '" + manageId + "' and PPCode = '" + moduleCodeHD + "'");
                    foreach (DataRow row in dtPP.Rows)
                    {
                        string id = TextUtils.ToString(row["PProductId"]);

                        #region Create ProjectModule
                        DataTable dtPMID = LibQLSX.Select(" SELECT top 1 ProjectModuleId FROM ProjectModule with(nolock) order by ProjectModuleId desc");
                        string PMid = TextUtils.ToString(dtPMID.Rows[0]["ProjectModuleId"]);
                        PMid = PMid.Substring(2, PMid.Length - 2);
                        PMid = "PM" + string.Format("{0:00000000}", TextUtils.ToInt(PMid) + 1);

                        ProjectModuleModel projectModule = new ProjectModuleModel();
                        projectModule.IsModuleStandard = 0;
                        projectModule.Note = "";
                        projectModule.ProjectModuleCode = moduleCode;
                        projectModule.ProjectModuleName = moduleName;
                        projectModule.Specifications = "";

                        projectModule.ProjectModuleId = PMid;
                        ProjectModuleBO.Instance.InsertQLSX(projectModule);
                        #endregion

                        #region Update ProjectProducts
                        ArrayList listPP = ProjectProductsBO.Instance.FindByAttribute("PProductId", id);
                        projectProduct = (ProjectProductsModel)listPP[0];
                        projectProduct.ProjectModuleId = PMid;
                        projectProduct.TypeId = typeID;
                        ProjectProductsBO.Instance.UpdateQLSX(projectProduct);
                        #endregion

                        #region Create ChildModule
                        DataRow[] drsChild = _dtModule.Select("ParentID = " + ID);
                        if (drsChild.Length > 0)
                        {
                            foreach (DataRow item in drsChild)
                            {
                                string moduleCode1 = TextUtils.ToString(item["F5"]);
                                string moduleName1 = TextUtils.ToString(item["F3"]);
                                int ID1 = TextUtils.ToInt(item["ID"]);
                                int parentID1 = TextUtils.ToInt(item["ParentID"]);
                                int qty1 = TextUtils.ToInt(item["F7"]);
                                string manageId1 = projectProduct.PProductId;
                                addModule(moduleCode1, moduleName1, ID1, parentID1, qty1, manageId1, "");
                            }
                        }
                        #endregion
                    }
                }
                else //Nếu là vật tư phụ
                {
                    #region Create ProjectModule
                    DataTable dtPMID = LibQLSX.Select(" SELECT top 1 ProjectModuleId FROM ProjectModule with(nolock) order by ProjectModuleId desc");
                    string PMid = TextUtils.ToString(dtPMID.Rows[0]["ProjectModuleId"]);
                    PMid = PMid.Substring(2, PMid.Length - 2);
                    PMid = "PM" + string.Format("{0:00000000}", TextUtils.ToInt(PMid) + 1);

                    ProjectModuleModel projectModule = new ProjectModuleModel();
                    projectModule.IsModuleStandard = 0;
                    projectModule.Note = "";
                    projectModule.ProjectModuleCode = moduleCode;
                    projectModule.ProjectModuleName = moduleName;
                    projectModule.Specifications = "";

                    projectModule.ProjectModuleId = PMid;
                    ProjectModuleBO.Instance.InsertQLSX(projectModule);
                    #endregion

                    #region Create ProjectProducts
                    DataTable dtPPID = LibQLSX.Select(" SELECT top 1 PProductId FROM ProjectProducts with(nolock) order by PProductId desc");
                    string PPid = TextUtils.ToString(dtPPID.Rows[0]["PProductId"]);
                    PPid = PPid.Substring(2, PPid.Length - 2);
                    PPid = "PP" + string.Format("{0:00000000}", TextUtils.ToInt(PPid) + 1);

                    projectProduct.DepartmentCreateId = "D009";
                    projectProduct.DepartmentDesignId = "D009";
                    projectProduct.ManageId = manageId;
                    projectProduct.ManufacturerId = "M000000001";
                    projectProduct.PProductInforId = "";
                    projectProduct.ProjectId = TextUtils.ToString(grvProject.GetFocusedRowCellValue(colProjectID));
                    projectProduct.ProjectModuleId = projectModule.ProjectModuleId;
                    projectProduct.Status = 2;
                    projectProduct.StatusCheckDesignInfor = 1;
                    projectProduct.StatusConfirm = 1;
                    projectProduct.Total = qty;
                    projectProduct.TypeId = typeID;
                    projectProduct.Origin = "Việt Nam";

                    projectProduct.PProductId = PPid;
                    ProjectProductsBO.Instance.InsertQLSX(projectProduct);
                    #endregion
                }
            }
            else //nếu là module con
            {
                #region Create ProjectModule
                DataTable dtPMID = LibQLSX.Select(" SELECT top 1 ProjectModuleId FROM ProjectModule with(nolock) order by ProjectModuleId desc");
                string PMid = TextUtils.ToString(dtPMID.Rows[0]["ProjectModuleId"]);
                PMid = PMid.Substring(2, PMid.Length - 2);
                PMid = "PM" + string.Format("{0:00000000}", TextUtils.ToInt(PMid) + 1);

                ProjectModuleModel projectModule = new ProjectModuleModel();
                projectModule.IsModuleStandard = 0;
                projectModule.Note = "";
                projectModule.ProjectModuleCode = moduleCode;
                projectModule.ProjectModuleName = moduleName;
                projectModule.Specifications = "";

                projectModule.ProjectModuleId = PMid;
                ProjectModuleBO.Instance.InsertQLSX(projectModule);
                #endregion

                #region Create ProjectProducts
                DataTable dtPPID = LibQLSX.Select(" SELECT top 1 PProductId FROM ProjectProducts with(nolock) order by PProductId desc");
                string PPid = TextUtils.ToString(dtPPID.Rows[0]["PProductId"]);
                PPid = PPid.Substring(2, PPid.Length - 2);
                PPid = "PP" + string.Format("{0:00000000}", TextUtils.ToInt(PPid) + 1);

                projectProduct.DepartmentCreateId = "D009";
                projectProduct.DepartmentDesignId = "D009";
                projectProduct.ManageId = manageId;
                projectProduct.ManufacturerId = "M000000001";
                projectProduct.PProductInforId = "";
                projectProduct.ProjectId = TextUtils.ToString(grvProject.GetFocusedRowCellValue(colProjectID));
                projectProduct.ProjectModuleId = projectModule.ProjectModuleId;
                projectProduct.Status = 2;
                projectProduct.StatusCheckDesignInfor = 1;
                projectProduct.StatusConfirm = 1;
                projectProduct.Total = qty;
                projectProduct.TypeId = typeID;
                projectProduct.Origin = "Việt Nam";

                projectProduct.PProductId = PPid;
                ProjectProductsBO.Instance.InsertQLSX(projectProduct);
                #endregion

                #region Create ChildModule
                DataRow[] drsChild = _dtModule.Select("ParentID = " + ID);
                if (drsChild.Length > 0)
                {
                    foreach (DataRow item in drsChild)
                    {
                        string moduleCode1 = TextUtils.ToString(item["F5"]);
                        string moduleName1 = TextUtils.ToString(item["F3"]);
                        int ID1 = TextUtils.ToInt(item["ID"]);
                        int parentID1 = TextUtils.ToInt(item["ParentID"]);
                        int qty1 = TextUtils.ToInt(item["F7"]);
                        string manageId1 = projectProduct.PProductId;
                        addModule(moduleCode1, moduleName1, ID1, parentID1, qty1, manageId1, "");
                    }
                }
                #endregion
            }
        }

        void addModuleSelf(string moduleCode, string moduleName, int ID, int parentID, int qty, string manageId, string moduleCodeHD)
        {
            string typeID = "T0068";
            DataTable dt = LibQLSX.Select("select TypeId from SourceCode with(nolock) where FolderCode = '" + moduleCode + "'");
            if (dt.Rows.Count > 0)
            {
                typeID = TextUtils.ToString(dt.Rows[0]["TypeId"]);
            }

            ProjectProductsModel projectProduct = new ProjectProductsModel();

            #region Create ProjectModule
            DataTable dtPMID = LibQLSX.Select(" SELECT top 1 ProjectModuleId FROM ProjectModule with(nolock) order by ProjectModuleId desc");
            string PMid = TextUtils.ToString(dtPMID.Rows[0]["ProjectModuleId"]);
            PMid = PMid.Substring(2, PMid.Length - 2);
            PMid = "PM" + string.Format("{0:00000000}", TextUtils.ToInt(PMid) + 1);

            ProjectModuleModel projectModule = new ProjectModuleModel();
            projectModule.IsModuleStandard = 0;
            projectModule.Note = "";
            projectModule.ProjectModuleCode = moduleCode;
            projectModule.ProjectModuleName = moduleName;
            projectModule.Specifications = "";

            projectModule.ProjectModuleId = PMid;
            ProjectModuleBO.Instance.InsertQLSX(projectModule);
            #endregion

            #region Update ProjectProducts
            ArrayList listPP = ProjectProductsBO.Instance.FindByAttribute("PProductId", manageId);
            projectProduct = (ProjectProductsModel)listPP[0];
            projectProduct.ProjectModuleId = projectModule.ProjectModuleId;
            projectProduct.TypeId = typeID;
            ProjectProductsBO.Instance.UpdateQLSX(projectProduct);
            #endregion

            #region Create ChildModule
            DataRow[] drsChild = _dtModule.Select("ParentID = " + ID);
            if (drsChild.Length > 0)
            {
                foreach (DataRow item in drsChild)
                {
                    string moduleCode1 = TextUtils.ToString(item["F5"]);
                    string moduleName1 = TextUtils.ToString(item["F3"]);
                    int ID1 = TextUtils.ToInt(item["ID"]);
                    int parentID1 = TextUtils.ToInt(item["ParentID"]);
                    int qty1 = TextUtils.ToInt(item["F7"]);
                    string manageId1 = projectProduct.PProductId;
                    addModule(moduleCode1, moduleName1, ID1, parentID1, qty1, manageId1, "");
                }
            }
            #endregion
        }

        private void btnAddModule_Click(object sender, EventArgs e)
        {
            if (grvModule.RowCount == 0) return;
            if (treeData.FocusedNode == null) return;
            if (treeData.Selection == null) return;

            DataRow[] drs = _dtModule.Select("ParentID = 0");
            for (int i = 0; i < treeData.Selection.Count; i++)
            {
                TreeListNode node = treeData.Selection[i];
                string manageId = TextUtils.ToString(node.GetValue(colIDTree));
                foreach (DataRow row in drs)
                {
                    string moduleCode = TextUtils.ToString(row["F5"]);
                    string moduleName = TextUtils.ToString(row["F3"]);
                    int ID = TextUtils.ToInt(row["ID"]);
                    int parentID = TextUtils.ToInt(row["ParentID"]);
                    int qty = TextUtils.ToInt(row["F7"]);
                    string moduleCodeHD = TextUtils.ToString(row["F4"]);
                    if (drs.Length > 1)
                    {
                        addModule(moduleCode, moduleName, ID, parentID, qty, manageId, moduleCodeHD);
                    }
                    else
                    {
                        addModuleSelf(moduleCode, moduleName, ID, parentID, qty, manageId, moduleCodeHD);
                        break;
                    }
                }
            }
            MessageBox.Show("Thêm module vào dự án thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadTree();
        }

        private void btnReloadData_Click(object sender, EventArgs e)
        {
            loadTree();
        }

        private void grvModule_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                grvModule.Rows.RemoveAt(grvModule.SelectedCells[0].RowIndex);
            }
        }
    }
}
