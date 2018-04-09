using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraTreeList.Nodes;
using System.Collections;
using TPA.Model;
using TPA.Business;

namespace BMS
{
    public partial class frmImportProducts : _Forms
    {
        DataTable _dtProduct = new DataTable();
        int _count = 0;

        public frmImportProducts()
        {
            InitializeComponent();
        }

        private void frmImportProducts_Load(object sender, EventArgs e)
        {
            loadProject();
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

        void addModule(string moduleCode, string moduleName, int ID, int qty, string manageId, decimal price)
        {
            string typeID = "T0068";
            DataTable dt = LibQLSX.Select("select TypeId from SourceCode with(nolock) where FolderCode = '" + moduleCode + "'");
            if (dt.Rows.Count > 0)
            {
                typeID = TextUtils.ToString(dt.Rows[0]["TypeId"]);
            }

            ProjectProductsModel projectProduct = new ProjectProductsModel();

            #region Create PProductInfor
            DataTable dtPMID = LibQLSX.Select(" SELECT top 1 PProductInforId FROM PProductInfor with(nolock) order by PProductInforId desc");
            string PMid = TextUtils.ToString(dtPMID.Rows[0]["PProductInforId"]);//PPI0000001
            PMid = PMid.Substring(3, PMid.Length - 3);
            PMid = "PPI" + string.Format("{0:0000000}", TextUtils.ToInt(PMid) + 1);

            PProductInforModel ppi = new PProductInforModel();
            ppi.PPCode = moduleCode.Length >= 50 ? moduleCode.Substring(0, 50) : moduleCode;
            ppi.PPName = moduleName;
            ppi.Price = price;
            ppi.PProductInforId = PMid;
            PProductInforBO.Instance.InsertQLSX(ppi);
            #endregion

            #region Create ProjectProducts
            DataTable dtPPID = LibQLSX.Select(" SELECT top 1 PProductId FROM ProjectProducts with(nolock) order by PProductId desc");
            string PPid = TextUtils.ToString(dtPPID.Rows[0]["PProductId"]);
            PPid = PPid.Substring(2, PPid.Length - 2);
            PPid = "PP" + string.Format("{0:00000000}", TextUtils.ToInt(PPid) + 1);

            projectProduct.DepartmentCreateId = "D002";
            //projectProduct.DepartmentDesignId = "D009";
            projectProduct.ManageId = manageId;
            projectProduct.ManufacturerId = "M000000001";
            projectProduct.ProjectModuleId = "";
            projectProduct.ProjectId = TextUtils.ToString(grvProject.GetFocusedRowCellValue(colProjectID));
            projectProduct.PProductInforId = ppi.PProductInforId;
            projectProduct.Status = 1;
            projectProduct.StatusCheckDesignInfor = 1;
            projectProduct.StatusConfirm = 1;
            projectProduct.Total = qty;
            projectProduct.TypeId = typeID;
            projectProduct.Origin = "Việt Nam";

            projectProduct.PProductId = PPid;
            ProjectProductsBO.Instance.InsertQLSX(projectProduct);
            #endregion

            #region Create ChildModule
            DataRow[] drsChild = _dtProduct.Select("F2 = '" + ID+"'");
            if (drsChild.Length > 0)
            {
                foreach (DataRow item in drsChild)
                {
                    string moduleName1 = TextUtils.ToString(item["F4"]);
                    string moduleCode1 = TextUtils.ToString(item["F5"]);
                    if (moduleCode1 == "") moduleCode1 = moduleName1.Length >= 50 ? moduleName1.Substring(0, 50) : moduleName1;
                    
                    int ID1 = TextUtils.ToInt(item["F1"]);
                    int qty1 = TextUtils.ToInt(item["F7"]);
                    decimal price1 = TextUtils.ToDecimal(item["F8"]);
                    string manageId1 = projectProduct.PProductId;

                    addModule(moduleCode1, moduleName1, ID1, qty1, manageId1, price1);
                }
            }
            #endregion
        }

        private void btnReloadData_Click(object sender, EventArgs e)
        {
            loadTree();
        }

        private void cboProject_EditValueChanged(object sender, EventArgs e)
        {
            loadTree();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load danh sách thiết bị..."))
                {
                    _count = 0;
                    _dtProduct = TextUtils.ExcelToDatatableNoHeader(ofd.FileName, "Sheet1");
                    if (_dtProduct.Rows.Count == 0) return;
                    _dtProduct.Rows.RemoveAt(0);
                    DataRow[] drs = _dtProduct.Select("F1 > 0");

                    //_dtProduct = _dtProduct.AsEnumerable()
                    //        .Where(row => TextUtils.ToInt(row.Field<string>("F1") == "" ||
                    //            row.Field<string>("F1") == null ? "0" : row.Field<string>("F1").Substring(0, 1)) > 0)
                    //        .CopyToDataTable();

                    grvModule.DataSource = null;
                    grvModule.AutoGenerateColumns = false;
                    grvModule.DataSource = _dtProduct;
                }
            }
        }

        private void btnAddModule_Click(object sender, EventArgs e)
        {
            if (grvModule.RowCount == 0) return;
            //if (treeData.FocusedNode == null) return;
            //if (treeData.Selection == null) return;
            string projectCode = TextUtils.ToString(grvProject.GetFocusedRowCellValue(colProjectCode));
            if (projectCode == "") return;
            DataTable Source = LibQLSX.Select("select top 1 from vGetProductOfProject where ProjectCode ='" + projectCode + "'");
            if (Source.Rows.Count > 0)
            {
                MessageBox.Show("Dự án đã khởi tạo các thiết bị trước đó nên không thể thêm thiết bị bằng cách này!");
                return;
            }

            DataRow[] drs = _dtProduct.Select("F2 = '0'");

            foreach (DataRow row in drs)
            {
                int ID = TextUtils.ToInt(row["F1"]);
                int parentID = TextUtils.ToInt(row["F2"]);

                string moduleCode = TextUtils.ToString(row["F5"]);
                string moduleName = TextUtils.ToString(row["F4"]);
                if (moduleName == "") continue;
                if (moduleCode == "") moduleCode = moduleName.Length >= 50 ? moduleName.Substring(0, 50) : moduleName;

                int qty = TextUtils.ToInt(row["F7"]);
                if (qty == 0) qty = 1;
                decimal price = TextUtils.ToDecimal(row["F8"]);
                //if (drs.Length > 1)
                //{
                addModule(moduleCode, moduleName, ID, qty, null, price);
                //}
            }

            MessageBox.Show("Thêm cáct thiết bị vào dự án thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadTree();

            btnAddModule.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (treeData.DataSource == null) return;
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa?", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;

            string pProductId = TextUtils.ToString(treeData.Selection[0].GetValue(colIDTree));
            ProjectProductsBO.Instance.DeleteByAttribute("ManageId", pProductId);
            ProjectProductsBO.Instance.DeleteByAttribute("PProductId", pProductId);

            treeData.Nodes.Remove(treeData.FocusedNode);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string projectCode = TextUtils.ToString(cboProject.EditValue);
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog()== DialogResult.OK)
            {
                treeData.ExportToXls(fbd.SelectedPath + "\\" + projectCode + ".xls");
            }
           
            //treeData.ExportToXls();
        }
    }
}
