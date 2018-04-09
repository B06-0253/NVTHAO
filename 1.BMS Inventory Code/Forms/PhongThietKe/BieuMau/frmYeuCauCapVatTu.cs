using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DevExpress.Utils;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace BMS
{
    public partial class frmYeuCauCapVatTu : _Forms
    {
        DataTable _dtListMaterial = new DataTable();
        DataTable _dtMaterial = new DataTable();

        public frmYeuCauCapVatTu()
        {
            InitializeComponent();
        }

        private void frmYeuCauCapVatTu_Load(object sender, EventArgs e)
        {
            loadProject();
            loadModule();

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
           
            _dtListMaterial.Columns.Add("ID");
            _dtListMaterial.Columns.Add("Code");
            _dtListMaterial.Columns.Add("Name");
            _dtListMaterial.Columns.Add("Hang");
            _dtListMaterial.Columns.Add("Qty");
            _dtListMaterial.Columns.Add("TonKho");
            _dtListMaterial.Columns.Add("Unit");
            _dtListMaterial.Columns.Add("ModuleCode");
            _dtListMaterial.Columns.Add("Date");
            _dtListMaterial.Columns.Add("Note");
            
            grdVT.DataSource = _dtListMaterial;
        }

        void loadProject()
        {
            try
            {
                DataTable tbl = LibQLSX.Select("exec spGetAllProject");
                TextUtils.PopulateCombo(cboProject, tbl, "ProjectName", "ProjectCode", "");
            }
            catch
            {
            }
        }

        void loadContract(string projectId)
        {
            if (projectId != "")
            {
                try
                {
                    DataTable dtContract = LibQLSX.Select(string.Format("SELECT *, [ContractCode] +' - '+[ContractName] Contract FROM [dbo].[Contracts] with(nolock) where [ProjectId] = '{0}'", projectId));
                    TextUtils.PopulateCombo(cboContract, dtContract, "Contract", "ContractId", "");
                }
                catch
                {
                    cboContract.Properties.DataSource = null;
                }
            }
        }

        void loadModule()
        {
            DataTable dt = TextUtils.Select("select * from Modules with(nolock) where Status = 2 and Code like 'TPAD.%'");
            repositoryItemSearchLookUpEdit1.DataSource = dt;
            repositoryItemSearchLookUpEdit1.DisplayMember = "Code";
            repositoryItemSearchLookUpEdit1.ValueMember = "Code";
        }

        private void cboProject_EditValueChanged(object sender, EventArgs e)
        {
            string projectCode = TextUtils.ToString(cboProject.EditValue);
            if (projectCode != "")
            {
                string projectId = TextUtils.ToString(grvProject.GetFocusedRowCellValue(colProjectID));
                loadContract(projectId);
                txtCustomer.Text = TextUtils.ToString(grvProject.GetFocusedRowCellValue(colCustomerName));
                txtKhachHangCuoi.Text = TextUtils.ToString(grvProject.GetFocusedRowCellValue(colProjectName)).Split('-')[1];
                txtCustomerCode.Text = projectCode.Split('.')[0];
                txtPhuTrachHD.Text = TextUtils.ToString(grvProject.GetFocusedRowCellValue(colUserName));
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
                        dr["Code"] = TextUtils.ToString(row["Code"]);
                        dr["Name"] = TextUtils.ToString(row["Name"]);
                        dr["Hang"] = TextUtils.ToString(row["Hang"]);
                        dr["Unit"] = TextUtils.ToString(row["Unit"]);
                        dr["Qty"] = TextUtils.ToDecimal(row["Qty"]);
                        dr["TonKho"] = TextUtils.ToDecimal(row["TonKho"]);
                        _dtListMaterial.Rows.Add(dr);
                    }
                }
                //grdVT.DataSource = _dtListMaterial;
            }
        }

        private void btnCreateBM_Click(object sender, EventArgs e)
        {
            grvVT.FocusedRowHandle = -1;
            if (grvVT.RowCount == 0) return;
            //string materialCode = TextUtils.ToString(grvModuleM.GetFocusedRowCellValue(colCodeM));
            //string materialName = TextUtils.ToString(grvModuleM.GetFocusedRowCellValue(colNameM));
            //if (materialName == "")
            //{
            //    MessageBox.Show("Tên vật tư không được để trống!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}

            string path = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path = fbd.SelectedPath;
            }
            else
            {
                return;
            }

            string filePath = Application.StartupPath + "\\Templates\\YCVT.xls";
            string currentPath = path + "\\YCVT." + DateTime.Now.ToString("ddMMyyy") + ".xls";
            try
            {
                File.Copy(filePath, currentPath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi tạo file yêu cầu cấp vật tư!" + Environment.NewLine + ex.Message,
                    TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo Yêu cầu cấp vật tư..."))
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                Excel.Application app = default(Excel.Application);
                Excel.Workbook workBoook = default(Excel.Workbook);
                Excel.Worksheet workSheet = default(Excel.Worksheet);
                try
                {
                    app = new Excel.Application();
                    app.Workbooks.Open(currentPath);
                    workBoook = app.Workbooks[1];
                    workSheet = (Excel.Worksheet)workBoook.Worksheets[1];

                    workSheet.Cells[6, 3] = txtCustomer.Text.Trim();
                    workSheet.Cells[6, 5] = txtCustomerCode.Text.Trim();
                    workSheet.Cells[6, 9] = txtPhuTrachHD.Text.Trim();
                    workSheet.Cells[7, 3] = txtKhachHangCuoi.Text.Trim();
                    workSheet.Cells[7, 5] = TextUtils.ToString(grvContract.GetFocusedRowCellValue(colContractCode));
                    workSheet.Cells[13, 7] = "Tân Phát, ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;

                    for (int i = grvVT.RowCount - 1; i >= 0; i--)
                    {
                        workSheet.Cells[12, 1] = i + 1;
                        workSheet.Cells[12, 2] = grvVT.GetRowCellDisplayText(i, colMaName);
                        workSheet.Cells[12, 3] = grvVT.GetRowCellDisplayText(i, colMaCode);
                        workSheet.Cells[12, 4] = grvVT.GetRowCellDisplayText(i, colMaHang);
                        workSheet.Cells[12, 5] = grvVT.GetRowCellDisplayText(i, colUnit);
                        workSheet.Cells[12, 6] = grvVT.GetRowCellDisplayText(i, colMaQty);
                        workSheet.Cells[12, 7] = grvVT.GetRowCellDisplayText(i, colMaModule);
                        workSheet.Cells[12, 8] = grvVT.GetRowCellDisplayText(i, colDate);
                        workSheet.Cells[12, 9] = grvVT.GetRowCellDisplayText(i, colNote);
                        //workSheet.Cells[12, 10] = grvVT.GetRowCellDisplayText(i, colMaPrice);
                        //workSheet.Cells[12, 11] = grvVT.GetRowCellDisplayText(i, colMaTotal);
                        //workSheet.Cells[12, 12] = grvVT.GetRowCellDisplayText(i, colMaDes);
                        ((Excel.Range)workSheet.Rows[12]).Insert();
                    }
                    ((Excel.Range)workSheet.Rows[11]).Delete();
                    ((Excel.Range)workSheet.Rows[11]).Delete();
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
                Process.Start(currentPath);
            }
        }

        private void btnDeleteVT_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa vật tư này?", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                grvVT.DeleteSelectedRows();
            }
        }
    }
}
