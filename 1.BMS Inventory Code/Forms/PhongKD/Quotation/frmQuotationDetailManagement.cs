using DevExpress.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPA.Model;
using TPA.Business;
using TPA.Utils;
using System.Collections;

namespace BMS
{
    public partial class frmQuotationDetailManagement : _Forms
    {
        int _rownIndex = 0;
        public C_QuotationModel Quotation = new C_QuotationModel();
        DataTable _dtProduct = new DataTable();
        DataTable _dtQuotationItem = new DataTable();

        public delegate void LoadDataChangeHandler(object sender, EventArgs e);
        public event LoadDataChangeHandler LoadDataChange;
        public frmQuotationDetailManagement()
        {
            InitializeComponent();
        }

        private void frmQuotationDetailManagement_Load(object sender, EventArgs e)
        {
            loadModule();
            loadProductGroup();
            loadProduct();
            loadQuotationItem();

            this.Text += ": " + Quotation.Code;
        }
        void loadModule()
        {
            DataTable dt = LibQLSX.Select("select FolderCode,FolderName from SourceCode with(nolock) where FolderCode like 'TPAD%' order by FolderCode");
            cboModule.Properties.DataSource = dt;
            cboModule.Properties.ValueMember = "FolderCode";
            cboModule.Properties.DisplayMember = "FolderCode";
        }

        void loadQuotationItem()
        {
            _dtQuotationItem = LibQLSX.Select("select * from vC_QuotationDetail with(nolock) where C_QuotationID = " + Quotation.ID);
            grdData.DataSource = _dtQuotationItem;
            if (_rownIndex >= grvData.RowCount)
                _rownIndex = 0;
            if (_rownIndex > 0)
                grvData.FocusedRowHandle = _rownIndex;
            grvData.SelectRow(_rownIndex);
        }

        void loadProductGroup()
        {
            DataTable tbl = LibQLSX.Select(@"SELECT * FROM C_ProductGroup WITH(NOLOCK) ORDER BY Code");
            cboProductGroup.Properties.DataSource = tbl.Copy();
            cboProductGroup.Properties.DisplayMember = "Code";
            cboProductGroup.Properties.ValueMember = "ID";

            repositoryItemSearchLookUpEdit1.DataSource = tbl.Copy();
            repositoryItemSearchLookUpEdit1.DisplayMember = "Code";
            repositoryItemSearchLookUpEdit1.ValueMember = "ID";
        }

        void loadProduct()
        {
            DataTable dt = LibQLSX.Select("select * from C_QuotationDetail with(nolock) where ParentID = 0 and C_QuotationID = " + Quotation.ID);
            cboProduct.Properties.DataSource = dt;
            cboProduct.Properties.DisplayMember = "ModuleCode";
            cboProduct.Properties.ValueMember = "ID";
        }

        void main_LoadDataChange(object sender, EventArgs e)
        {
            loadQuotationItem();
        }

        private void cboModule_EditValueChanged(object sender, EventArgs e)
        {
            string code = TextUtils.ToString(grvCboModule.GetFocusedRowCellValue(colCode));
            string name = TextUtils.ToString(grvCboModule.GetFocusedRowCellValue(colName));

            txtModuleCode.Text = code;
            txtModuleName.Text = name;

            //if (chkGetPriceVT.Checked)
            //{
            //    using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load giá vật tư..."))
            //    {
            //        try
            //        {
            //            txtPriceVTSX.EditValue = TextUtils.GetPrice(code, true);
            //        }
            //        catch
            //        {
            //        }
            //    }
            //}
        }

        private void btnAddModule_Click(object sender, EventArgs e)
        {
            #region Check
            if (txtModuleCode.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải thêm mã module!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtModuleName.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải thêm tên module!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtManufacture.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải thêm hãng!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtOrigin.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải thêm xuất xứ!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TextUtils.ToDecimal(txtPriceVTSX.EditValue) == 0 && cboProduct.EditValue != null)
            {
                MessageBox.Show("Bạn phải điền giá vật tư sản xuất!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TextUtils.ToDecimal(txtQty.EditValue) == 0)
            {
                MessageBox.Show("Bạn phải điền số lượng!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cboProductGroup.EditValue == null && cboProduct.EditValue != null)
            {
                MessageBox.Show("Bạn phải chọn một nhóm sản phẩm!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            C_QuotationDetailModel item = new C_QuotationDetailModel();

            item.C_QuotationID = Quotation.ID;
            item.ParentID = TextUtils.ToInt(cboProduct.EditValue);
            if (item.ParentID > 0)
            {
                item.C_ProductGroupID = TextUtils.ToInt(cboProductGroup.EditValue);
                item.PriceVTSX = TextUtils.ToDecimal(txtPriceVTSX.EditValue);
                item.PriceVTLD = TextUtils.ToDecimal(txtPriceVTLD.EditValue);
                item.PriceVTPS = TextUtils.ToDecimal(txtPriceVTPS.EditValue);
                item.PriceVTTN = TextUtils.ToDecimal(txtPriceVTTN.EditValue);
                item.PriceVT = item.PriceVTSX + item.PriceVTLD + item.PriceVTPS + item.PriceVTTN;

                item.Qty = TextUtils.ToDecimal(txtQty.EditValue) * TextUtils.ToDecimal(grvCboProduct.GetFocusedRowCellValue(colPQty));
            }
            else
            {
                item.Qty = TextUtils.ToDecimal(txtQty.EditValue);
            }

            item.Manufacture = txtManufacture.Text.Trim();
            item.ModuleCode = item.ModuleCodeHD = txtModuleCode.Text.Trim().ToUpper();
            item.ModuleName = item.ModuleNameHD = txtModuleName.Text.Trim();
            item.Origin = txtOrigin.Text.Trim();

            item.VAT = TextUtils.ToDecimal(txtVAT.EditValue);

            item.ID = (int)C_QuotationDetailBO.Instance.Insert(item);

            if (item.ParentID > 0)
            {
                C_QuotationDetailModel itemP = (C_QuotationDetailModel)C_QuotationDetailBO.Instance.FindByPK(item.ParentID);
                itemP.PriceVTSX += item.PriceVTSX;
                itemP.PriceVTLD += item.PriceVTLD;
                itemP.PriceVTPS += item.PriceVTPS;
                itemP.PriceVTTN += item.PriceVTTN;
                itemP.PriceVT += item.PriceVT;
                C_QuotationDetailBO.Instance.Update(itemP);

                //calculateCost(item);
            }          

            MessageBox.Show("Lưu trữ thành công.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);

            loadProduct();
            loadQuotationItem();

            txtPriceVTSX.EditValue = 0;
            txtQty.EditValue = 1;
            txtModuleName.Text = txtModuleCode.Text = "";
        }

        void calculateCost(C_QuotationDetailModel item)
        {
            ArrayList arr = C_CostBO.Instance.FindByExpression(new Expression("IsUse", 1).And(new Expression("IsWithProject", 0)));
            DataTable dtCostProductGroup = LibQLSX.Select("select * from vC_CostProductGroupLink where [C_ProductGroupID] = " + item.C_ProductGroupID);
            decimal totalNC = 0;
            decimal totalPB = 0;
            foreach (var c in arr)
            {
                C_CostModel cost = (C_CostModel)c;
                DataRow[] drs = dtCostProductGroup.Select("C_CostID = " + cost.ID);
                if (drs.Length == 0) continue;
                C_CostQuotationItemLinkModel link = new C_CostQuotationItemLinkModel();

                ArrayList arrLink = C_CostQuotationItemLinkBO.Instance.FindByExpression(new Expression("C_CostID", cost.ID).And(new Expression("C_QuotationDetailID", item.ID)));
                if (arrLink != null && arrLink.Count > 0) link = (C_CostQuotationItemLinkModel)arrLink[0];

                link.C_CostID = cost.ID;
                link.C_QuotationDetailID = item.ID;
                link.IsDirect = cost.IsDirectCost;
                if (link.IsDirect == 1)
                {
                    #region Chi phí nhân công
                    link.PersonNumber = TextUtils.ToDecimal(drs[0]["PersonNumber"]);
                    int isFix = TextUtils.ToInt(drs[0]["IsFix"]);
                    if (isFix == 1)
                    {
                        link.NumberDay = TextUtils.ToDecimal(drs[0]["NumberDay"]);
                    }
                    else
                    {
                        link.NumberDay = TextUtils.ToDecimal(drs[0]["VtuPercent"]) * item.PriceVT / cost.Price;
                    }

                    link.Price = link.NumberDay * link.PersonNumber * cost.Price * item.Qty;
                    if (cost.ID == 61)//phòng thiết kế
                    {
                        link.Price = (link.NumberDay * link.PersonNumber) * (1 + 0.3M * (item.Qty >= 2 ? item.Qty - 1 : 0)) * cost.Price;
                    }

                    totalNC += link.Price;
                    #endregion
                }
                else
                {
                    #region Chi phí phân bổ
                    decimal valuePercent = TextUtils.ToDecimal(drs[0]["ValuePercent"]);

                    link.Price = valuePercent * item.Qty * item.PriceHD;
                    if (cost.IsDeliveryTime == 1)
                    {
                        link.Price *= Quotation.DeliveryTime / 288;
                    }

                    if (cost.ID == 72 || cost.ID == 73)
                    {
                        if (cost.ID != Quotation.DepartmentId)
                        {
                            link.Price = 0;
                        }
                    }
                    totalPB += link.Price;
                    #endregion
                }

                if (link.ID == 0)
                {
                    C_CostQuotationItemLinkBO.Instance.Insert(link);
                }
                else
                {
                    C_CostQuotationItemLinkBO.Instance.Update(link);
                }

                item.TotalNC = totalNC;
                item.TotalPB = totalPB;
                C_QuotationDetailBO.Instance.Update(item);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool _isSaved = false;
            if (grvData.RowCount == 0) return;
            grvData.FocusedRowHandle = -1;

            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang xử lý..."))
            {
                for (int i = 0; i < grvData.RowCount; i++)
                {
                    int id = TextUtils.ToInt(grvData.GetRowCellValue(i, colDetailID));
                    C_QuotationDetailModel item = (C_QuotationDetailModel)C_QuotationDetailBO.Instance.FindByPK(id);

                    item.PriceVTLD = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colPriceVTLD));
                    item.PriceVTPS = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colPriceVTPS));
                    item.PriceVTSX = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colPriceVTSX));
                    item.PriceVTTN = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colPriceVTTN));
                    item.PriceVT = item.PriceVTSX + item.PriceVTLD + item.PriceVTPS + item.PriceVTTN;

                    item.PriceHD = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colPriceHDnoVAT));

                    item.C_ProductGroupID = TextUtils.ToInt(grvData.GetRowCellValue(i, colProductGroupID));
                    item.VAT = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colVAT));
                    item.Qty = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colQty));

                    C_QuotationDetailBO.Instance.Update(item);

                    calculateCost(item);

                    //LibQLSX.CalculatePriceTPA(item, Quotation);
                }

                for (int i = 0; i < grvData.RowCount; i++)
                {
                     int id = TextUtils.ToInt(grvData.GetRowCellValue(i, colParentID));
                     if (id == 0) continue;
                     C_QuotationDetailModel item = (C_QuotationDetailModel)C_QuotationDetailBO.Instance.FindByPK(id);
                     DataTable dtChildTPA = LibQLSX.Select("select Sum(PriceTPA) from C_QuotationDetail where ParentID = " + id);
                     DataTable dtChildHD = LibQLSX.Select("select Sum(PriceHD) from C_QuotationDetail where ParentID = " + id);

                     item.PriceTPA = dtChildTPA.Rows.Count > 0 ? TextUtils.ToDecimal(dtChildTPA.Rows[0][0]) : item.PriceTPA;
                     item.PriceHD = dtChildHD.Rows.Count > 0 ? TextUtils.ToDecimal(dtChildHD.Rows[0][0]) : item.PriceHD;
                     C_QuotationDetailBO.Instance.Update(item);
                }

                loadQuotationItem();
                _isSaved = true;
            }

            MessageBox.Show("Lưu trữ thành công.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);

            if(_isSaved)
            {
                if (this.LoadDataChange != null)
                {
                    this.LoadDataChange(null, null);
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
                    string moduleCode = TextUtils.ToString( grvData.GetFocusedRowCellValue(colModuleCode));
                    int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colDetailID));
                    if (C_QuotationDetailBO.Instance.CheckExist("ParentID",id))
                    {
                        MessageBox.Show("Bạn không thể xóa được thiết bị chính khi nó còn chứa các thiết bị con.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    if (MessageBox.Show("Bạn có chắc muốn xóa thiết bị [" + moduleCode + "]?", TextUtils.Caption,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        C_QuotationDetailModel item = (C_QuotationDetailModel)C_QuotationDetailBO.Instance.FindByPK(id);
                        if(item.ParentID > 0)
                        {
                            C_QuotationDetailModel itemP = (C_QuotationDetailModel)C_QuotationDetailBO.Instance.FindByPK(item.ParentID);
                            itemP.PriceVTSX -= item.PriceVTSX;
                            itemP.PriceVTLD -= item.PriceVTLD;
                            itemP.PriceVTPS -= item.PriceVTPS;
                            itemP.PriceVTTN -= item.PriceVTTN;
                            itemP.PriceVT -= item.PriceVT;
                            C_QuotationDetailBO.Instance.Update(itemP);
                        }
                        C_QuotationDetailBO.Instance.Delete(id);
                        grvData.DeleteSelectedRows();
                        if (item.ParentID == 0) loadProduct();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnShowDirectCost_Click(object sender, EventArgs e)
        {
            _rownIndex = grvData.FocusedRowHandle;
            int parentID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colParentID));
            if (parentID == 0) return;

            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colDetailID));
            if (id == 0) return;

            frmDirectCost frm = new frmDirectCost();
            //frm.C_QuotationDetailID = id;
            frm.C_QuotationID = Quotation.ID;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.IsSaved)
                {
                    btnSave_Click(null, null);
                }                
            }
        }

        private void grvData_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //if (e.Column == colPriceHD)
            //{
            //    decimal qty = TextUtils.ToDecimal(grvData.GetFocusedRowCellValue(colQty));
            //}
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            frmQuotationDetailImport frm = new frmQuotationDetailImport();
            frm.QuotationID = Quotation.ID;
            frm.LoadDataChange += main_LoadDataChange;
            TextUtils.OpenForm(frm);
        }

        private void btnPhanBo_Click(object sender, EventArgs e)
        {
            bool isSaved = false;
            if (grvData.RowCount == 0) return;
            for (int i = 0; i < grvData.RowCount; i++)
            {                
                int parentID = TextUtils.ToInt(grvData.GetRowCellValue(i, colParentID));
                if (parentID > 0) continue;
                int id = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                decimal totalHD = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colPriceHD));
                decimal totalTPA = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colPriceTPA));                

                DataTable dtChild = LibQLSX.Select("select * from vC_QuotationDetail where ParentID = " + id);
                if (dtChild.Rows.Count > 0)
                {
                    foreach (DataRow row in dtChild.Rows)
                    {
                        int cID = TextUtils.ToInt(row["ID"]);
                        C_QuotationDetailModel child = (C_QuotationDetailModel)C_QuotationDetailBO.Instance.FindByPK(cID);
                        child.PriceHD = totalHD * child.PriceTPA / totalTPA;
                        C_QuotationDetailBO.Instance.Update(child);
                    }
                }
                C_QuotationDetailModel parent = (C_QuotationDetailModel)C_QuotationDetailBO.Instance.FindByPK(id);
                parent.PriceHD = totalHD;
                C_QuotationDetailBO.Instance.Update(parent);
                isSaved = true;
            }
            if (isSaved)
            {
                loadQuotationItem();
            }
        }
    }
}
