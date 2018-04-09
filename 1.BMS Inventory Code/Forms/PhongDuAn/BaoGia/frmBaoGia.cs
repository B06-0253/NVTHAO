using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using DevExpress.Utils;
using System.Diagnostics;
using BMS.Utils;
using BMS.Model;
using BMS.Business;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;

namespace BMS
{
    public partial class frmBaoGia : _Forms
    {
        #region Variables
        DataTable _dtBaoGia;
        decimal _rate = 0;
        List<string> _listProduct = new List<string>();
        bool _isSaved = false;
        public BaoGiaModel BaoGia = new BaoGiaModel();
        DataTable _dtProduct = new DataTable();

        public delegate void LoadDataChangeHandler(object sender, EventArgs e);
        public event LoadDataChangeHandler LoadDataChange;
        #endregion

        #region Constructors and Load
        public frmBaoGia()
        {
            InitializeComponent();
        }     

        private void frmBaoGia_Load(object sender, EventArgs e)
        {
            cboCustomerPercentType.SelectedIndex = 1;
            cboPriceType.SelectedIndex = 0;

            loadProject();               
            loadCustomer();
            loadCostGroup();
            loadModule();
            loadDiffCost();

            if (BaoGia.ID > 0)
            {
                txtBaoGiaCode.Text = BaoGia.Code;
                txtCustomerCash.Text = BaoGia.CustomerCash.ToString();
                txtCustomerCode.Text = BaoGia.CustomerCode;
                txtCustomerName.Text = BaoGia.CustomerName;
                txtCustomerPercent.Text = BaoGia.CustomerPercent.ToString();
                txtCustomerTotal.Text = BaoGia.CustomerTotal.ToString();
                txtFinishCustomerCode.Text = BaoGia.CustomerCodeF;
                txtFinishCustomerName.Text = BaoGia.CustomerNameF;
                txtProjectCode.Text = BaoGia.ProjectCode;
                txtProjectName.Text = BaoGia.ProjectName;

                cboCustomerPercentType.SelectedIndex = BaoGia.CustomerPercentType;
            }
            _dtProduct = TextUtils.Select("select distinct productcode, productname FROM [QLKHCV].[dbo].[BaoGiaItem] with(nolock) where BaoGiaID = " + BaoGia.ID);
            loadProduct();
            loadBaogiaItem();            
        }
        #endregion
        
        #region Methods
        void loadBaogiaItem()
        {
            _dtBaoGia = TextUtils.Select("Select *, Product = ProductCode+'-'+ProductName from BaoGiaItem with(nolock) where BaoGiaID = " + BaoGia.ID);
            grdData.DataSource = _dtBaoGia;
        }

        void loadCostGroup()
        {
            DataTable tbl = TextUtils.Select(@"SELECT *,Code+'-'+Name as Name1 FROM CostGroup WITH(NOLOCK) ORDER BY Code");
            cboCostGroup.Properties.DataSource = tbl.Copy();
            cboCostGroup.Properties.DisplayMember = "Name1";
            cboCostGroup.Properties.ValueMember = "ID";

            repositoryItemSearchLookUpEdit1.DataSource = tbl.Copy();
            repositoryItemSearchLookUpEdit1.DisplayMember = "Name1";
            repositoryItemSearchLookUpEdit1.ValueMember = "ID";
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

        void loadProduct()
        {               
            cboProduct.Properties.DataSource = _dtProduct;
            cboProduct.Properties.ValueMember = "productcode";
            cboProduct.Properties.DisplayMember = "productname";
        }

        void loadCustomer()
        {
            try
            {
                DataTable tbl = LibQLSX.Select("SELECT *  FROM [Customers] with(nolock)");
                TextUtils.PopulateCombo(cboCustomer, tbl, "CustomerName", "CustomerCode", "");
            }
            catch (Exception ex)
            {
            }
        }

        void loadModule()
        {
            DataTable dt = TextUtils.Select("select * from Modules with(nolock) where code like '%tpad%' and status = 2");
            cboModule.Properties.DataSource = dt;
            cboModule.Properties.ValueMember = "ID";
            cboModule.Properties.DisplayMember = "Code";
        }

        decimal GetCostSX(int costGroupID,decimal priceVT)
        {
            decimal costSX = 0;

            try
            {
                DataTable dtSX = TextUtils.Select("Select *,(CostPercent * " + priceVT
               + " / 100) as Total from vCostLink where Type = 0 and CostGroupID = " + costGroupID);
                decimal chiPhiSX = TextUtils.ToDecimal(dtSX.Compute("Sum(Total)", ""));
                costSX = chiPhiSX + priceVT;
            }
            catch 
            {                
            }

            return costSX;
        }

        decimal GetCostTM(int costGroupID, decimal priceVT)
        {
            decimal costTM = 0;
            try
            {
                decimal costSX = GetCostSX(costGroupID, priceVT);
                DataTable dtTM = TextUtils.Select("Select *,(CostPercent * " + costSX + " / 100) as Total from vCostLink where Type = 1 and CostGroupID = " + costGroupID);
                decimal chiPhiTM = TextUtils.ToDecimal(dtTM.Compute("Sum(Total)", ""));
                costTM = chiPhiTM + costSX;
            }
            catch
            {
            }
            return costTM;
        }

        void getPriceTPA()
        {
            int costGroupID = TextUtils.ToInt(cboCostGroup.EditValue);
            if (cboPriceType.SelectedIndex == 0)
            {
                txtPriceTPA.Text = GetCostSX(costGroupID,TextUtils.ToDecimal(txtPriceVT.Text)).ToString("n0");
            }
            else
            {
                txtPriceTPA.Text = GetCostTM(costGroupID, TextUtils.ToDecimal(txtPriceVT.Text)).ToString("n0");
            }
        }

        void loadRealPrice()
        {
            try
            {
                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load giá thực..."))
                {
                    grvData.FocusedRowHandle = -1;

                    decimal totalPriceHD = TextUtils.ToDecimal(colTotalHD.SummaryItem.SummaryValue);
                    decimal totalPriceHDnoVAT = TextUtils.ToDecimal(colTotalHDnoVat.SummaryItem.SummaryValue);
                    decimal totalChiPhi;
                    decimal customerPecent = TextUtils.ToDecimal(txtCustomerPercent.Text);
                    decimal customerCash = TextUtils.ToDecimal(txtCustomerCash.Text);

                    if (cboCustomerPercentType.SelectedIndex == 0)
                    {
                        totalChiPhi = customerPecent * totalPriceHDnoVAT / 100 + customerCash;
                        _rate = (totalPriceHDnoVAT - totalChiPhi) / totalPriceHDnoVAT;
                    }
                    else
                    {
                        totalChiPhi = customerPecent * totalPriceHD / 100 + customerCash;
                        _rate = (totalPriceHD - totalChiPhi) / totalPriceHD;
                    }
                    txtCustomerTotal.Text = totalChiPhi.ToString("n0");

                    for (int i = 0; i < grvData.RowCount; i++)
                    {
                        decimal thisPriceHD = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colPriceHD));
                        decimal qty = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colQty));
                        decimal real = Math.Round(_rate * thisPriceHD);

                        grvData.SetRowCellValue(i, colPriceReal, real);
                        grvData.SetRowCellValue(i, colTotalReal, qty * real);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private bool ValidateForm()
        {
            txtBaoGiaCode.Text = txtBaoGiaCode.Text.Trim().ToUpper().Replace(" ", "");

            if (txtBaoGiaCode.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền Mã báo giá.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
            {
                DataTable dt;
                if (BaoGia.ID > 0)
                {
                    dt = TextUtils.Select("select Code from BaoGia with(nolock) where upper(Replace(Code,' ','')) = '"
                        + txtBaoGiaCode.Text.Trim().ToUpper() + "' and ID <> " + BaoGia.ID);
                }
                else
                {
                    dt = TextUtils.Select("select Code from BaoGia with(nolock) where upper(Replace(Code,' ','')) = '"
                        + txtBaoGiaCode.Text.Trim().ToUpper() + "'");
                }
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Mã báo giá này đã tồn tại!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }
                }
            }

            if (txtProjectName.Text.Trim() == "" || txtProjectCode.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền đầy đủ thông tin dự án.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }            

            return true;
        }

        void loadDiffCost()
        {
            DataTable dt = TextUtils.Select("select * from BaoGiaDiff with(nolock) where BaoGiaID = " + BaoGia.ID);
            grdDiff.DataSource = dt;
        }

        void save(bool close)
        {
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();
            try
            {
                if (!ValidateForm())
                    return;

                grvDiff.FocusedRowHandle = grvData.FocusedRowHandle = -1;

                BaoGia.Code = txtBaoGiaCode.Text.Trim();
                BaoGia.ProjectCode = txtProjectCode.Text.Trim().ToUpper();
                BaoGia.ProjectName = txtProjectName.Text.Trim().ToUpper();

                BaoGia.DepartmentName = txtDepartmentName.Text.Trim().ToUpper();

                BaoGia.CustomerCode = txtCustomerCode.Text.Trim().ToUpper();
                BaoGia.CustomerName = txtCustomerName.Text.Trim().ToUpper();
                BaoGia.CustomerCodeF = txtFinishCustomerCode.Text.Trim().ToUpper();
                BaoGia.CustomerNameF = txtFinishCustomerName.Text.Trim().ToUpper();

                BaoGia.CustomerPercentType = cboPriceType.SelectedIndex;

                BaoGia.CustomerPercent = TextUtils.ToDecimal(txtCustomerPercent.Text);
                BaoGia.CustomerCash = TextUtils.ToDecimal(txtCustomerCash.Text);
                BaoGia.CustomerTotal = TextUtils.ToDecimal(txtCustomerTotal.Text);
                BaoGia.TotalTPA = TextUtils.ToDecimal(colTotalTPA.SummaryItem.SummaryValue);
                BaoGia.TotalReal = TextUtils.ToDecimal(colTotalReal.SummaryItem.SummaryValue);
                BaoGia.TotalHD = TextUtils.ToDecimal(colTotalHD.SummaryItem.SummaryValue);
                BaoGia.TotalVT = TextUtils.ToDecimal(colTotalVT.SummaryItem.SummaryValue);
                BaoGia.TotalPhatSinh = TextUtils.ToDecimal(colDiffPrice.SummaryItem.SummaryValue);

                if (BaoGia.ID <= 0)
                {                   
                    BaoGia.ID = (int)pt.Insert(BaoGia);
                }
                else
                {
                    pt.Update(BaoGia);                   
                }

                #region BaoGiaItem
                for (int i = 0; i < grvData.RowCount; i++)
                {
                    string code = TextUtils.ToString(grvData.GetRowCellValue(i, colModuleCode)).ToUpper();
                    if (code == "") continue;
                    try
                    {
                        BaoGiaItemModel curentItem = new BaoGiaItemModel();
                        int baoGiaID = TextUtils.ToInt(grvData.GetRowCellValue(i, colBaoGiaID));
                        if (baoGiaID > 0)
                        {
                            curentItem = (BaoGiaItemModel)BaoGiaItemBO.Instance.FindByPK(baoGiaID);
                        }

                        curentItem.BaoGiaID = BaoGia.ID;
                        curentItem.CostGroupID = TextUtils.ToInt(grvData.GetRowCellValue(i, colCostGroupID));

                        curentItem.ModuleCode = code;
                        curentItem.ModuleName = TextUtils.ToString(grvData.GetRowCellValue(i, colModuleName)).ToUpper();
                        curentItem.ModuleCodeHD = TextUtils.ToString(grvData.GetRowCellValue(i, colModuleCodeHD));
                        curentItem.ModuleNameHD = TextUtils.ToString(grvData.GetRowCellValue(i, colModuleNameHD));

                        curentItem.PriceHD = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colPriceHD));
                        curentItem.PriceHDnoVAT = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colPriceHDnoVAT));
                        curentItem.PriceReal = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colPriceReal));
                        curentItem.PriceTPA = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colPriceTPA));

                        curentItem.PriceType = grvData.GetRowCellValue(i, colPriceType).ToString();

                        curentItem.PriceVT = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colPriceVT));
                        curentItem.PriceDT = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colPriceDT));

                        curentItem.ProductCode = grvData.GetRowCellValue(i, colProductCode).ToString().ToUpper();
                        curentItem.ProductName = grvData.GetRowCellValue(i, colProductName).ToString().ToUpper();

                        curentItem.Qty = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colQty));
                        curentItem.TotalHD = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colTotalHD));
                        curentItem.TotalReal = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colTotalReal));
                        curentItem.TotalHDnoVAT = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colTotalHDnoVat));
                        curentItem.TotalTPA = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colTotalTPA));
                        curentItem.TotalVT = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colTotalVT));
                        curentItem.VAT = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colVAT));

                        if (baoGiaID > 0)
                        {
                            pt.Update(curentItem);
                        }
                        else
                        {
                            pt.Insert(curentItem);
                        }
                    }
                    catch (Exception)
                    {
                       
                    }                   
                }
                #endregion

                #region Chi phí phát sinh
                for (int i = 0; i < grvDiff.RowCount; i++)
                {
                    BaoGiaDiffModel diffModel = new BaoGiaDiffModel();
                    int diffID = TextUtils.ToInt(grvDiff.GetRowCellValue(i, colDiffID));
                    if (diffID > 0)
                    {
                        diffModel = (BaoGiaDiffModel)BaoGiaDiffBO.Instance.FindByPK(diffID);
                    }

                    diffModel.STT = TextUtils.ToInt(grvDiff.GetRowCellValue(i, colDiffSTT));
                    diffModel.BaoGiaID = BaoGia.ID;
                    diffModel.Description = grvDiff.GetRowCellValue(i, colDiffDescription) != null ? grvDiff.GetRowCellValue(i, colDiffDescription).ToString() : "";
                    diffModel.Name = grvDiff.GetRowCellValue(i, colDiffName) != null ? grvDiff.GetRowCellValue(i, colDiffName).ToString() : "";
                    diffModel.Price = TextUtils.ToDecimal(grvDiff.GetRowCellValue(i, colDiffPrice));

                    if (diffID > 0)
                    {
                        pt.Update(diffModel);
                    }
                    else
                    {
                        pt.Insert(diffModel);
                    }
                }
                #endregion

                pt.CommitTransaction();
                _isSaved = true;

                loadBaogiaItem();
                //loadModule();
                loadDiffCost();
                
                if (close)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Lưu trữ thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lưu trữ không thành công!" + Environment.NewLine + ex.Message, TextUtils.Caption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                pt.CloseConnection();
            }
        }

        void loadProductOfProject(string projectCode)
        {
            try
            {
                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load danh sách module..."))
                {
                    string[] paraName = new string[1];
                    object[] paraValue = new object[1];
                    paraName[0] = "@ProjectCode"; paraValue[0] = projectCode;
                    DataTable dt = TPA.Business.SuppliersBO.Instance.LoadDataFromSP("spGetProductOfProject", "Source", paraName, paraValue);
                    
                    _dtBaoGia.Rows.Clear();
                    _dtBaoGia.Merge(dt);

                    if (chkGetPriceVT.Checked)
                    {
                        foreach (DataRow dr in _dtBaoGia.Rows)
                        {
                            string code = TextUtils.ToString(dr["ModuleCode"]);
                            if (code == "") continue;
                            decimal price = TextUtils.GetPrice(code, true);

                            //dr["VAT"] = 5m;
                            //dr["Qty"] = 1m;
                            dr["PriceVT"] = price;
                            dr["TotalVT"] = price;
                            dr["PriceTPA"] = price;
                            dr["TotalTPA"] = price;
                        }
                    }
                    
                    grdData.DataSource = _dtBaoGia;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void addModules(string projectCode)
        {
            
        }
        #endregion

        #region Events
        private void btnAddModule_Click(object sender, EventArgs e)
        {
            if (cboPriceType.Text == "")
            {
                MessageBox.Show("Bạn phải chọn một loại giá!",TextUtils.Caption,MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            if (txtModuleCode.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải thêm mã module!",TextUtils.Caption,MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            if (txtModuleName.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải thêm tên module!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cboCostGroup.EditValue == null)
            {
                 MessageBox.Show("Bạn phải chọn một nhóm chi phí!",TextUtils.Caption,MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            string moduleCode = txtModuleCode.Text.Trim();
            string productCode = txtProductCode.Text.Trim();

            DataRow[] drs1 = _dtBaoGia.Select("ModuleCode ='" + moduleCode + "' and ProductCode='" + productCode + "'");
            if (drs1.Length > 0)
            {
                MessageBox.Show("Module [" + moduleCode + "] đã được thêm cho sản phẩm [" + productCode + "]!", TextUtils.Caption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataRow dr = _dtBaoGia.NewRow();
            dr["ModuleCode"] = txtModuleCode.Text.Trim().ToUpper();
            dr["ModuleName"] = txtModuleName.Text.Trim().ToUpper();
            dr["ModuleCodeHD"] = txtModuleCode.Text.Trim().ToUpper();
            dr["ModuleNameHD"] = txtModuleName.Text.Trim().ToUpper();
            dr["PriceType"] = cboPriceType.Text;
            dr["VAT"] = 5m;
            dr["Qty"] = 1m;
            dr["PriceVT"] = TextUtils.ToDecimal(txtPriceVT.Text.Trim());
            dr["PriceDT"] = TextUtils.ToDecimal(txtPriceVT.Text.Trim());
            dr["TotalVT"] = 1 * TextUtils.ToDecimal(txtPriceVT.Text.Trim());
            dr["PriceTPA"] = TextUtils.ToDecimal(txtPriceTPA.Text.Trim());
            dr["TotalTPA"] = 1 * TextUtils.ToDecimal(txtPriceTPA.Text.Trim());
            dr["Product"] = txtProductCode.Text.Trim() + "-" + txtProductName.Text.Trim();
            dr["ProductCode"] = txtProductCode.Text.Trim().ToUpper();
            dr["ProductName"] = txtProductName.Text.Trim().ToUpper();
            dr["CostGroupID"] = TextUtils.ToInt(cboCostGroup.EditValue);
            _dtBaoGia.Rows.Add(dr);

            DataRow[] drs = _dtProduct.Select("productcode = '" + txtProductCode.Text.Trim() + "'");
            if (drs.Length == 0)
            {
                DataRow row = _dtProduct.NewRow();
                row[0] = txtProductCode.Text.ToUpper().Trim();
                row[1] = txtProductName.Text.ToUpper().Trim();
                _dtProduct.Rows.Add(row);

                loadProduct();
            }
            MessageBox.Show("Thêm module thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void grvData_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            decimal qty = TextUtils.ToDecimal(grvData.GetRowCellValue(e.RowHandle, colQty));
            decimal vat = TextUtils.ToDecimal(grvData.GetRowCellValue(e.RowHandle, colVAT)) / 100;

            decimal priceHD = TextUtils.ToDecimal(grvData.GetRowCellValue(e.RowHandle, colPriceHD));            
            decimal priceTPA = TextUtils.ToDecimal(grvData.GetRowCellValue(e.RowHandle, colPriceTPA));
            decimal priceReal = TextUtils.ToDecimal(grvData.GetRowCellValue(e.RowHandle, colPriceReal));
            decimal priceVT = TextUtils.ToDecimal(grvData.GetRowCellValue(e.RowHandle, colPriceDT));
            string priceType = TextUtils.ToString(grvData.GetRowCellValue(e.RowHandle, colPriceType));
            int costGroupID = TextUtils.ToInt(grvData.GetRowCellValue(e.RowHandle, colCostGroupID));

            bool isChange = false;

            if (e.Column == colQty)
            {
                grvData.SetRowCellValue(e.RowHandle, colTotalVT, qty * priceVT);
                grvData.SetRowCellValue(e.RowHandle, colTotalHD, qty * priceHD);
                grvData.SetRowCellValue(e.RowHandle, colTotalTPA, qty * priceTPA);
                grvData.SetRowCellValue(e.RowHandle, colTotalReal, qty * priceReal);
                isChange = true;
            }

            if (e.Column == colVAT)
            {
                grvData.SetRowCellValue(e.RowHandle, colPriceHDnoVAT, priceHD * (1 - vat));
                grvData.SetRowCellValue(e.RowHandle, colTotalHDnoVat, qty * (priceHD * (1 - vat)));
                isChange = true;
            }

            if (e.Column == colPriceType || e.Column == colPriceDT || e.Column == colCostGroupID)
            {
                decimal costSX = GetCostSX(costGroupID, priceVT);
                decimal costTM = GetCostTM(costGroupID, priceVT);
                if (priceType.ToUpper() == "SX")
                {
                    grvData.SetRowCellValue(e.RowHandle, colPriceTPA, costSX);
                    grvData.SetRowCellValue(e.RowHandle, colTotalTPA, qty * costSX);
                }
                else
                {
                    grvData.SetRowCellValue(e.RowHandle, colPriceTPA, costTM);
                    grvData.SetRowCellValue(e.RowHandle, colTotalTPA, qty * costTM);
                }
            }

            if (e.Column == colPriceHD)
            {
                grvData.SetRowCellValue(e.RowHandle, colPriceHDnoVAT, priceHD * (1 - vat));
                grvData.SetRowCellValue(e.RowHandle, colTotalHDnoVat, qty * (priceHD * (1 - vat)));
                grvData.SetRowCellValue(e.RowHandle, colTotalHD, qty * priceHD);
                isChange = true;
            }

            if (isChange)
            {
                loadRealPrice();                
            }
        }

        private void cboModule_EditValueChanged(object sender, EventArgs e)
        {
            string code = TextUtils.ToString(grvCboModule.GetFocusedRowCellValue(colCode));
            string name = TextUtils.ToString(grvCboModule.GetFocusedRowCellValue(colName));

            txtModuleCode.Text = code;
            txtModuleName.Text = name;

            if (chkGetPriceVT.Checked)
            {
                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load giá vật tư..."))
                {
                    try
                    {
                        txtPriceVT.EditValue = TextUtils.GetPrice(code, true);
                    }
                    catch
                    {
                    }
                }
            }
        }

        private void grvData_KeyDown(object sender, KeyEventArgs e)
        {
            if (grvData.SelectedRowsCount < 1)
            {
                return;
            }
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    string moduleCode = grvData.GetFocusedRowCellValue(colModuleCode).ToString();
                    int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colBaoGiaID));
                    if (MessageBox.Show("Bạn có chắc muốn xóa module [" + moduleCode + "]?", TextUtils.Caption,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (id > 0)
                        {
                            BaoGiaItemBO.Instance.Delete(id);
                        }
                        grvData.DeleteSelectedRows();
                        loadRealPrice();
                    }
                }
                catch (Exception)
                {                    
                }             
            }
        }

        private void cboCustomerPercentType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            loadRealPrice();
        }

        private void btnCreateBaoGia_Click(object sender, EventArgs e)
        {
            if (BaoGia.ID == 0) return;
            string localPath = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                localPath = fbd.SelectedPath + "\\" + BaoGia.Code + ".xlsx";
            }
            else
            {
                return;
            }

            string filePath = Application.StartupPath + "\\Templates\\FORM BAO GIA.xlsx";

            try
            {
                File.Copy(filePath, localPath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: File excel đang được mở." + Environment.NewLine + ex.Message);
                return;
            }

            UsersModel userModel = (UsersModel)UsersBO.Instance.FindByPK(Global.UserID);
            DataTable dtProduct = TextUtils.Select("select distinct productcode, productname from baogiaitem with(nolock) where productcode <> '' and baogiaid= " + BaoGia.ID);
            //DataTable dtProductAo = TextUtils.Select("select distinct productcode, productname from baogiaitem with(nolock) where productcode = '' and baogiaid= " + BaoGia.ID);

            if (grvData.RowCount == 0)
            {
                MessageBox.Show("Lỗi: Không có thiết bị nào để báo giá");
                return;
            }
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo báo giá..."))
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

                    workSheet.Cells[5, 4] = "Số báo giá: " + BaoGia.Code;
                    workSheet.Cells[6, 2] = "Đơn vị: " + BaoGia.CustomerCodeF + " - " + BaoGia.CustomerNameF;
                    workSheet.Cells[6, 4] = "Ngày báo giá: " + DateTime.Now.ToString("dd/MM/yyyy");
                    workSheet.Cells[7, 4] = "Người báo giá: " + userModel.FullName;
                    workSheet.Cells[8, 4] = "Số điện thoại: " + userModel.HandPhone;
                    workSheet.Cells[9, 4] = "Email: " + userModel.Email;
                    workSheet.Cells[25, 6] = "Hà nội, ngày " + DateTime.Now.Day + " tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year;

                    int rowCountProduct = dtProduct.Rows.Count;
                    DataTable dtModuleAo = TextUtils.Select("select * from baogiaitem where ProductCode = '' and Baogiaid = " + BaoGia.ID);
                    if (dtModuleAo.Rows.Count > 0)
                    {
                        int indexAo = dtModuleAo.Rows.Count - 1;
                        for (int i = indexAo; i >= 0; i--)
                        {
                            string moduleCode = TextUtils.ToString(dtModuleAo.Rows[i]["ModuleCode"]);
                            string moduleName = TextUtils.ToString(dtModuleAo.Rows[i]["ModuleName"]);
                            string qty = TextUtils.ToDecimal(dtModuleAo.Rows[i]["Qty"]).ToString("n0");
                            string price = TextUtils.ToDecimal(dtModuleAo.Rows[i]["PriceTPA"]).ToString("n0");
                            string total = TextUtils.ToDecimal(dtModuleAo.Rows[i]["TotalTPA"]).ToString("n0");

                            ModulesModel module = new ModulesModel();
                            try
                            {
                                module = (ModulesModel)ModulesBO.Instance.FindByCode(moduleCode);
                            }
                            catch (Exception)
                            {
                            }
                            if (module.ID > 0)
                            {
                                if (module.Specifications.Length > 0)
                                {
                                    string[] thongSo = module.Specifications.Split('\n');
                                    for (int k = thongSo.Length - 1; k >= 0; k--)
                                    {
                                        workSheet.Cells[15, 2] = thongSo[k];
                                        ((Excel.Range)workSheet.Rows[15]).Insert();
                                    }
                                }
                            }

                            workSheet.Cells[15, 1] = rowCountProduct + i + 1;
                            workSheet.Cells[15, 2] = moduleName.ToUpper();
                            workSheet.Cells[15, 3] = moduleCode.ToUpper();
                            workSheet.Cells[15, 6] = qty;
                            workSheet.Cells[15, 7] = price;
                            workSheet.Cells[15, 8] = total;
                            ((Excel.Range)workSheet.Rows[15]).Font.Bold = true;
                            ((Excel.Range)workSheet.Rows[15]).Insert();
                        }
                    }

                    for (int i = rowCountProduct - 1; i >= 0; i--)
                    {
                        try
                        {
                            DataTable dtModule = TextUtils.Select("select * from baogiaitem where ProductCode = '"
                                + dtProduct.Rows[i][0].ToString() + "' and Baogiaid = " + BaoGia.ID);

                            for (int j = dtModule.Rows.Count - 1; j >= 0; j--)
                            {
                                string moduleCode = TextUtils.ToString(dtModule.Rows[j]["ModuleCode"]);
                                string moduleName = TextUtils.ToString(dtModule.Rows[j]["ModuleName"]);
                                string qty = TextUtils.ToDecimal(dtModule.Rows[j]["Qty"]).ToString("n0");
                                string price = TextUtils.ToDecimal(dtModule.Rows[j]["PriceTPA"]).ToString("n0");
                                string total = TextUtils.ToDecimal(dtModule.Rows[j]["TotalTPA"]).ToString("n0");
                                
                                try
                                {
                                    ModulesModel module = new ModulesModel();
                                    module = (ModulesModel)ModulesBO.Instance.FindByCode(moduleCode);
                                    if (module != null && module.ID > 0)
                                    {
                                        if (module.Specifications.Length > 0)
                                        {
                                            string[] thongSo = module.Specifications.Split('\n');
                                            for (int k = thongSo.Length - 1; k >= 0; k--)
                                            {
                                                workSheet.Cells[15, 2] = thongSo[k];
                                                ((Excel.Range)workSheet.Rows[15]).Insert();
                                            }
                                        }
                                    }
                                }
                                catch
                                {
                                }                                

                                workSheet.Cells[15, 2] = moduleName.ToUpper();
                                workSheet.Cells[15, 3] = moduleCode.ToUpper();
                                workSheet.Cells[15, 6] = qty;
                                workSheet.Cells[15, 7] = price;
                                workSheet.Cells[15, 8] = total;
                                ((Excel.Range)workSheet.Rows[15]).Font.Bold = true;
                                ((Excel.Range)workSheet.Rows[15]).Insert();
                            }

                            workSheet.Cells[15, 2] = "B. Thông số kỹ thuật:";
                            ((Excel.Range)workSheet.Rows[15]).Font.Bold = true;
                            ((Excel.Range)workSheet.Rows[15]).Insert();

                            for (int j = dtModule.Rows.Count - 1; j >= 0; j--)
                            {
                                string moduleName = TextUtils.ToString(dtModule.Rows[j]["ModuleName"]);
                                string qty = TextUtils.ToDecimal(dtModule.Rows[j]["Qty"]).ToString("n0");
                                workSheet.Cells[15, 2] = string.Format("{0:00}", TextUtils.ToInt(qty)) + " " + moduleName.ToLower();
                                ((Excel.Range)workSheet.Rows[15]).Insert();
                            }
                            
                            workSheet.Cells[15, 2] = "A. Danh mục các module:";
                            ((Excel.Range)workSheet.Rows[15]).Font.Bold = true;
                            ((Excel.Range)workSheet.Rows[15]).Insert();

                            decimal productPrice = TextUtils.ToDecimal(dtModule.Compute("Sum(TotalTPA)", ""));

                            workSheet.Cells[15, 1] = i + 1;
                            workSheet.Cells[15, 2] = dtProduct.Rows[i][1].ToString().ToUpper();
                            workSheet.Cells[15, 3] = dtProduct.Rows[i][0].ToString().ToUpper();
                            workSheet.Cells[15, 4] = "Tân Phát";
                            workSheet.Cells[15, 5] = "Bộ";
                            workSheet.Cells[15, 6] = 1;
                            workSheet.Cells[15, 7] = productPrice.ToString("n0");
                            workSheet.Cells[15, 8] = productPrice.ToString("n0");

                            ((Excel.Range)workSheet.Rows[15]).Font.Bold = true;
                            ((Excel.Range)workSheet.Rows[15]).Insert();
                        }
                        catch (Exception)
                        {
                        }
                    }

                    ((Excel.Range)workSheet.Rows[15]).Delete();
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
                Process.Start(localPath);
            }
        }

        private void cboProject_EditValueChanged(object sender, EventArgs e)
        {            
            txtProjectCode.Text = grvCboProject.GetFocusedRowCellValue(colProjectCode).ToString();
            txtProjectName.Text = grvCboProject.GetFocusedRowCellValue(colProjectName).ToString();
            if (BaoGia.ID == 0)
            {
                loadProductOfProject(txtProjectCode.Text.Trim());
            }
           
            loadRealPrice();
        }

        private void cboCustomer_EditValueChanged(object sender, EventArgs e)
        {
            txtCustomerCode.Text = grvCboCustomer.GetFocusedRowCellValue(colCustomerCode).ToString();
            txtCustomerName.Text = grvCboCustomer.GetFocusedRowCellValue(colCustomerName).ToString();
        }

        private void cboCostGroup_EditValueChanged(object sender, EventArgs e)
        {
            getPriceTPA();
        }

        private void cboPriceType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getPriceTPA();
        }

        private void txtPriceVT_EditValueChanged(object sender, EventArgs e)
        {
            getPriceTPA();
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            save(false);
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            save(true);
            this.Close();
        }

        private void frmBaoGia_FormClosed(object sender, FormClosedEventArgs e)
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

        private void txtCustomerCash_EditValueChanged(object sender, EventArgs e)
        {
            loadRealPrice();
        }

        private void txtCustomerPercent_EditValueChanged(object sender, EventArgs e)
        {
            loadRealPrice();
        }

        private void cboProduct_EditValueChanged(object sender, EventArgs e)
        {
            string code = grvCboProduct.GetFocusedRowCellValue(colPCode).ToString();
            string name = grvCboProduct.GetFocusedRowCellValue(colPName).ToString();

            txtProductCode.Text = code;
            txtProductName.Text = name;
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            frmBaoGiaImportExcel frm = new frmBaoGiaImportExcel();
            frm.DtData = _dtBaoGia;
            frm.ProductCode = txtProductCode.Text.Trim();
            frm.ProductName = txtProductName.Text.Trim();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _dtBaoGia = frm.DtData;
                grdData.DataSource = _dtBaoGia;

                DataRow[] drs = _dtProduct.Select("productcode = '" + txtProductCode.Text.Trim() + "'");
                if (drs.Length == 0)
                {
                    DataRow row = _dtProduct.NewRow();
                    row[0] = txtProductCode.Text.ToUpper().Trim();
                    row[1] = txtProductName.Text.ToUpper().Trim();
                    _dtProduct.Rows.Add(row);

                    loadProduct();
                }
            }            
        }

        private void grvData_ShownEditor(object sender, EventArgs e)
        {
            TextEdit edit = (sender as BaseView).ActiveEditor as TextEdit;
            if (edit != null)
                edit.Spin += new DevExpress.XtraEditors.Controls.SpinEventHandler(edit_Spin);
        }

        void edit_Spin(object sender, DevExpress.XtraEditors.Controls.SpinEventArgs e)
        {
            e.Handled = true;
        }

        private void lấyGiáChoModuleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load giá cho module..."))
            {
                foreach (int i in grvData.GetSelectedRows())
                {
                    string code = TextUtils.ToString(grvData.GetRowCellValue(i, colModuleCode));
                    if (!code.StartsWith("TPAD.")) continue;
                    decimal price = TextUtils.GetPrice(code, true);
                    int costGroupID = TextUtils.ToInt(grvData.GetRowCellValue(i, colCostGroupID));
                    decimal qty = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colQty));
                    string priceType = TextUtils.ToString(grvData.GetRowCellValue(i, colPriceType));

                    decimal totalVT = qty * price;
                    decimal priceTPA = 0;

                    if (priceType.ToUpper() == "SX")
                    {
                        priceTPA = GetCostSX(costGroupID, price);
                    }
                    else
                    {
                        priceTPA = GetCostTM(costGroupID, price);
                    }
                    decimal totalTPA = priceTPA * qty;

                    grvData.SetRowCellValue(i, colPriceVT, price);
                    grvData.SetRowCellValue(i, colPriceDT, price);
                    grvData.SetRowCellValue(i, colTotalVT, totalVT);
                    grvData.SetRowCellValue(i, colPriceTPA, priceTPA);
                    grvData.SetRowCellValue(i, colTotalTPA, totalTPA);
                }
            }
        }
    }
}
