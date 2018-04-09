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
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;


namespace BMS
{
    public partial class frmQuotationDetailManagementNew : _Forms
    {
        int _rownIndex = 0;
        public C_QuotationModel Quotation = new C_QuotationModel();
        DataTable _dtProduct = new DataTable();
        DataTable _dtQuotationItem = new DataTable();

        public delegate void LoadDataChangeHandler(object sender, EventArgs e);
        public event LoadDataChangeHandler LoadDataChange;
        public frmQuotationDetailManagementNew()
        {
            InitializeComponent();
        }

        private void frmQuotationDetailManagementNew_Load(object sender, EventArgs e)
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
            //_dtQuotationItem = LibQLSX.Select("select *,TyLe = (case when PriceVT > 0 then (PriceTPA/PriceVT) else 1 end) from vC_QuotationDetail with(nolock) where C_QuotationID = " + Quotation.ID);
            _dtQuotationItem = LibQLSX.Select("select * from vC_QuotationDetail with(nolock) where C_QuotationID = " + Quotation.ID);
            treeData.DataSource = _dtQuotationItem;
            treeData.KeyFieldName = "ID";
            treeData.PreviewFieldName = "ModuleCode";
            treeData.ExpandAll();
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

        void calculateCost(C_QuotationDetailModel item, decimal costVT)
        {
            if (item.C_ProductGroupID == 0)
            {
                C_CostQuotationItemLinkBO.Instance.DeleteByAttribute("C_QuotationDetailID", item.ID);
                item.TotalNC = 0;
                item.TotalPB = 0;
                C_QuotationDetailBO.Instance.Update(item);                
            }
            else
            {
                //decimal priceThucThu = (item.PriceHD - Quotation.CustomerPercent / 100 * item.PriceHD - Quotation.CustomerCash * item.PriceVT / costVT);

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
                        if (link.ID == 0)
                        {
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
                            link.TotalR = link.NumberDay * link.PersonNumber;                            
                            if (cost.ID == 61)//phòng thiết kế
                            {
                                link.TotalR = link.NumberDay * link.PersonNumber * (1 + 0.3M * (item.Qty - 1)) / item.Qty;
                                //link.Price = (link.NumberDay * link.PersonNumber) * (1 + 0.3M * (item.Qty - 1)) / item.Qty * cost.Price;
                            }
                            link.Price = link.TotalR * cost.Price;
                        }                       

                        totalNC += link.Price;
                        #endregion
                    }
                    else
                    {
                        #region Chi phí phân bổ
                        if (item.PriceHD > 0)
                        {
                            decimal valuePercent = TextUtils.ToDecimal(drs[0]["ValuePercent"]);

                            link.Price = valuePercent / 100 * item.PriceSX;
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
                        }                        
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

            if (TextUtils.ToDecimal(txtQtyT.EditValue) == 0)
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
                item.QtyT = TextUtils.ToDecimal(txtQtyT.EditValue);
                item.Qty = TextUtils.ToDecimal(txtQtyT.EditValue) * TextUtils.ToDecimal(grvCboProduct.GetFocusedRowCellValue(colPQty));
            }
            else
            {
                item.Qty = item.QtyT = TextUtils.ToDecimal(txtQtyT.EditValue);
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
            txtQtyT.EditValue = 1;
            txtModuleName.Text = txtModuleCode.Text = "";
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
            
            if (treeData.AllNodesCount == 0) return;
            
            for (int i = 0; i < treeData.AllNodesCount; i++)
            {
                int parentID = TextUtils.ToInt(treeData.GetNodeByVisibleIndex(i).GetValue(colParentID));
                if (parentID > 0) continue;
                int id = TextUtils.ToInt(treeData.GetNodeByVisibleIndex(i).GetValue(colDetailID));
                decimal totalHD = TextUtils.ToDecimal(treeData.GetNodeByVisibleIndex(i).GetValue(colPriceHD));
                decimal totalTPA = TextUtils.ToDecimal(treeData.GetNodeByVisibleIndex(i).GetValue(colPriceTPA));

                DataTable dtChild = LibQLSX.Select("select * from vC_QuotationDetail where ParentID = " + id);
                if (dtChild.Rows.Count > 0)
                {
                    foreach (DataRow row in dtChild.Rows)
                    {
                        int cID = TextUtils.ToInt(row["ID"]);
                        C_QuotationDetailModel child = (C_QuotationDetailModel)C_QuotationDetailBO.Instance.FindByPK(cID);
                        //child.PriceHD = totalHD * child.PriceTPA * child.QtyT / totalTPA;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool _isSaved = false;
            if (treeData.AllNodesCount == 0) return;            
            treeData.ExpandAll();
            treeData.FocusedNode = null;

            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang xử lý..."))
            {
                for (int i = 0; i < treeData.AllNodesCount; i++)
                {
                    int id = TextUtils.ToInt(treeData.GetNodeByVisibleIndex(i).GetValue(colDetailID));
                    C_QuotationDetailModel item = (C_QuotationDetailModel)C_QuotationDetailBO.Instance.FindByPK(id);

                    item.ModuleName = TextUtils.ToString(treeData.GetNodeByVisibleIndex(i).GetValue(colModuleName));
                    item.PriceVTLD = TextUtils.ToDecimal(treeData.GetNodeByVisibleIndex(i).GetValue(colPriceVTLD));
                    item.PriceVTPS = TextUtils.ToDecimal(treeData.GetNodeByVisibleIndex(i).GetValue(colPriceVTPS));
                    item.PriceVTSX = TextUtils.ToDecimal(treeData.GetNodeByVisibleIndex(i).GetValue(colPriceVTSX));
                    item.PriceVTTN = TextUtils.ToDecimal(treeData.GetNodeByVisibleIndex(i).GetValue(colPriceVTTN));
                   
                    item.PriceVT = item.PriceVTSX + item.PriceVTLD + item.PriceVTPS + item.PriceVTTN;

                    item.PriceHD = TextUtils.ToDecimal(treeData.GetNodeByVisibleIndex(i).GetValue(colPriceHD));

                    item.C_ProductGroupID = TextUtils.ToInt(treeData.GetNodeByVisibleIndex(i).GetValue(colProductGroupID));
                    item.VAT = TextUtils.ToDecimal(treeData.GetNodeByVisibleIndex(i).GetValue(colVAT));
                    item.QtyT = TextUtils.ToDecimal(treeData.GetNodeByVisibleIndex(i).GetValue(colQtyT));

                    int parentID = TextUtils.ToInt(treeData.GetNodeByVisibleIndex(i).GetValue(colParentID));
                    if (parentID == 0)
                    {
                        item.Qty = item.QtyT;
                    }
                    else
	                {
                        C_QuotationDetailModel parent = (C_QuotationDetailModel)C_QuotationDetailBO.Instance.FindByPK(parentID);
                         item.Qty = item.QtyT * parent.Qty;
	                }                   
                    
                    C_QuotationDetailBO.Instance.Update(item);
                }

                DataTable dtCostVT = LibQLSX.Select("select sum(Qty*PriceVT) from C_QuotationDetail where (ParentID > 0 or (ParentID = 0 and C_ProductGroupID > 0)) and [C_QuotationID] = " + Quotation.ID);
                decimal costVT = dtCostVT.Rows.Count > 0 ? TextUtils.ToDecimal(dtCostVT.Rows[0][0]) : 0;

                for (int i = 0; i < treeData.AllNodesCount; i++)
                {
                    int id = TextUtils.ToInt(treeData.GetNodeByVisibleIndex(i).GetValue(colDetailID));
                    C_QuotationDetailModel item = (C_QuotationDetailModel)C_QuotationDetailBO.Instance.FindByPK(id);

                    if (item.ParentID == 0 && item.C_ProductGroupID == 0) continue;

                    DataTable dtProductGroup = LibQLSX.Select("select ProfitPercent, CustomerPercent from C_ProductGroup where ID = " + item.C_ProductGroupID);
                    decimal profitPercent = dtProductGroup.Rows.Count > 0 ? TextUtils.ToDecimal(dtProductGroup.Rows[0]["ProfitPercent"]) / 100 : 0;
                    decimal customerPercent = dtProductGroup.Rows.Count > 0 ? TextUtils.ToDecimal(dtProductGroup.Rows[0]["CustomerPercent"]) / 100 : 0;
                    decimal percentPB = LibQLSX.GetPercentCostPB(item.C_ProductGroupID,Quotation.DeliveryTime) / 100;
                    decimal priceTPA = 0;
                    decimal nhanCongTrucTiep = item.TotalNC;
                    decimal costTrienKhai = Quotation.TotalCustomer * item.PriceVT / costVT;
                    decimal tienMat = Quotation.CustomerCash * item.PriceVT / costVT;
                    decimal percentKH = Quotation.CustomerPercent / 100;

                    //Gsx = CP + CP * %LN
                    //Gsx = VT + NC + TrienKhai + %PB * Gsx + (VT + NC + TrienKhai + %PB * Gsx) * %LN
                    //Gsx = (VT+NC+TrienKhai)(1+%LN) + Gsx(%PB+%PB*%LN)
                    //Gsx - Gsx(%PB+%PB*%LN) = (VT+NC+TrienKhai)(1+%LN)
                    //Gsx = (VT+NC+TrienKhai)(1+%LN)/(1-%PB-%PB*%LN)

                    //Gb = VTU + CPDA.NC  + CPDA.TKHAI + (1-1/(1+%VAT))*Gb + (tienMat+%KH*Gb) + %PB*(Gb-(tienMat+percentKH*Gb)) + 0.15*(tienMat+%KH*Gb) + %LN*Gb
                    //'Gb= (VTU + CPDA.NC  + CPDA.TKHAI +(1.15- %PB)* tienMat)/ (1/(1+%VAT) - %PB + %PB*%KH -1.15*%KH - %LN)
                    priceTPA = (item.PriceVT + nhanCongTrucTiep + costTrienKhai + (1 + customerPercent - percentPB) * tienMat) / (1 / (1 + item.VAT / 100) - percentPB + percentPB * percentKH - (1 + customerPercent) * percentKH - profitPercent);

                    //decimal priceSX = (item.PriceVT + nhanCongTrucTiep + costTrienKhai) * (1 + profitPercent) / (1 - percentPB - percentPB * profitPercent);
                    //priceTPA = (priceSX + (1 + customerPercent) * tienMat) / (1 - (1 + customerPercent) * percentKH - (1 - 1 / (1 + item.VAT / 100)));
                    if (item.PriceHD == 0)
                    {
                        item.PriceHD = priceTPA;
                    }

                    item.TotalCP = (item.PriceVT + nhanCongTrucTiep + costTrienKhai) + percentPB * (priceTPA - (tienMat + percentKH * priceTPA));
                    item.TotalProfit = profitPercent * priceTPA;

                    item.PriceSX = item.TotalCP;
                    //item.PriceReal = priceTPA - (1 + customerPercent) * (percentKH * priceTPA + tienMat);
                    item.PriceReal = item.PriceHD - (1 + customerPercent) * (percentKH * priceTPA + tienMat);
                    item.PriceTPA = priceTPA;
                    C_QuotationDetailBO.Instance.Update(item);

                    calculateCost(item, costVT);
                }

                ArrayList listParent = C_QuotationDetailBO.Instance.FindByExpression(new Expression("ParentID", 0)
                    .And(new Expression("C_ProductGroupID", 0))
                    .And(new Expression("C_QuotationID", Quotation.ID)));

                if (listParent != null)
                {
                    foreach (var item in listParent)
                    {
                        C_QuotationDetailModel itemP = (C_QuotationDetailModel)item;
                        DataTable dtChild = LibQLSX.Select("select Sum(QtyT*PriceVTLD),Sum(QtyT*PriceVTPS),Sum(QtyT*PriceVTSX),Sum(QtyT*PriceVTTN),Sum(QtyT*PriceTPA),Sum(QtyT*PriceHD) from C_QuotationDetail where ParentID = " + itemP.ID);

                        itemP.PriceVTLD = dtChild.Rows.Count > 0 ? TextUtils.ToDecimal(dtChild.Rows[0][0]) : itemP.PriceVTLD;
                        itemP.PriceVTPS = dtChild.Rows.Count > 0 ? TextUtils.ToDecimal(dtChild.Rows[0][1]) : itemP.PriceVTPS;
                        itemP.PriceVTSX = dtChild.Rows.Count > 0 ? TextUtils.ToDecimal(dtChild.Rows[0][2]) : itemP.PriceVTSX;
                        itemP.PriceVTTN = dtChild.Rows.Count > 0 ? TextUtils.ToDecimal(dtChild.Rows[0][3]) : itemP.PriceVTTN;                        
                        itemP.PriceTPA = dtChild.Rows.Count > 0 ? TextUtils.ToDecimal(dtChild.Rows[0][4]) : itemP.PriceTPA;
                        itemP.PriceHD = dtChild.Rows.Count > 0 ? TextUtils.ToDecimal(dtChild.Rows[0][5]) : itemP.PriceHD;
                        itemP.PriceVT = itemP.PriceVTSX + itemP.PriceVTLD + itemP.PriceVTPS + itemP.PriceVTTN;

                        C_QuotationDetailBO.Instance.Update(itemP);
                    }
                }

                loadQuotationItem();
                _isSaved = true;
            }

            MessageBox.Show("Lưu trữ thành công.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (_isSaved)
            {
                if (this.LoadDataChange != null)
                {
                    this.LoadDataChange(null, null);
                }
            }
        }

        private void treeData_KeyDown(object sender, KeyEventArgs e)
        {
            if (treeData.FocusedNode == null)
            {
                return;
            }
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    string moduleCode = TextUtils.ToString(treeData.FocusedNode.GetValue(colModuleCode));
                    int id = TextUtils.ToInt(treeData.FocusedNode.GetValue(colDetailID));
                    if (C_QuotationDetailBO.Instance.CheckExist("ParentID", id))
                    {
                        MessageBox.Show("Bạn không thể xóa được thiết bị chính khi nó còn chứa các thiết bị con.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    if (MessageBox.Show("Bạn có chắc muốn xóa thiết bị [" + moduleCode + "]?", TextUtils.Caption,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        C_QuotationDetailModel item = (C_QuotationDetailModel)C_QuotationDetailBO.Instance.FindByPK(id);
                        if (item.ParentID > 0)
                        {
                            C_QuotationDetailModel itemP = (C_QuotationDetailModel)C_QuotationDetailBO.Instance.FindByPK(item.ParentID);
                            itemP.PriceVTSX -= item.PriceVTSX;
                            itemP.PriceVTLD -= item.PriceVTLD;
                            itemP.PriceVTPS -= item.PriceVTPS;
                            itemP.PriceVTTN -= item.PriceVTTN;
                            itemP.PriceVT -= item.PriceVT;
                            itemP.PriceHD -= item.PriceHD;
                            C_QuotationDetailBO.Instance.Update(itemP);
                        }

                        C_CostQuotationItemLinkBO.Instance.DeleteByAttribute("C_QuotationDetailID", id);
                        C_QuotationDetailBO.Instance.Delete(id);
                        
                        treeData.DeleteSelectedNodes();
                        if (item.ParentID == 0) loadProduct();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (e.KeyCode == (Keys.C))
            {
                try
                {
                    string text = TextUtils.ToString(treeData.FocusedNode.GetValue(treeData.FocusedColumn));
                    Clipboard.SetText(text);
                }
                catch (Exception)
                {
                }
            }
        }

        private void btnShowDirectCost_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(treeData.FocusedNode.GetValue(colDetailID));
            if (id == 0) return;
            C_QuotationDetailModel item = (C_QuotationDetailModel)C_QuotationDetailBO.Instance.FindByPK(id);

            frmDirectCost frm = new frmDirectCost();
            frm.QuotationDetail = item;
            frm.C_QuotationID = Quotation.ID;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.IsSaved)
                {
                    btnSave_Click(null, null);
                }
            }
        }

        private void treeData_CustomDrawNodeCell(object sender, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {
            int parentID = TextUtils.ToInt(e.Node.GetValue(colParentID));
            if (parentID == 0)
            {
                e.Appearance.BackColor = Color.LemonChiffon;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog()==DialogResult.OK)
            {
                treeData.ExportToXls(fbd.SelectedPath + "\\ListEquipment - " + Quotation.Code + ".xls");
            }            
        }       

        private void repositoryItemTextEdit1_Spin(object sender, DevExpress.XtraEditors.Controls.SpinEventArgs e)
        {
            e.Handled = true;
        }

        private void btnDeletePriceHD_Click(object sender, EventArgs e)
        {
            treeData.ExpandAll();

            for (int i = 0; i < treeData.AllNodesCount; i++)
            {
                treeData.GetNodeByVisibleIndex(i).SetValue(colPriceHD, 0);
            }
        }
    }
}
