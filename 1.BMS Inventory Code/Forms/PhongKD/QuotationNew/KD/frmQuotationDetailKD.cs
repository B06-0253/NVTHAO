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
    public partial class frmQuotationDetailKD : _Forms
    {
        public C_Quotation_KDModel Quotation = new C_Quotation_KDModel();
        DataTable _dtProduct = new DataTable();
        DataTable _dtQuotationItem = new DataTable();

        public delegate void LoadDataChangeHandler(object sender, EventArgs e);
        public event LoadDataChangeHandler LoadDataChange;
        public frmQuotationDetailKD()
        {
            InitializeComponent();
        }

        private void frmQuotationDetailKD_Load(object sender, EventArgs e)
        {
            btnSave.Enabled = btnPhanBo.Enabled = btnDeletePriceHD.Enabled = btnAddModule.Enabled = btnImportExcel.Enabled = !Quotation.IsApproved;
            loadModule();
            loadProductGroup();
            loadDepartment();
            loadProduct();
            loadQuotationItem();
            loadCustomerType();

            this.Text += ": " + Quotation.Code;

            if (Global.AppUserName.ToLower() == "quynh.dm")
            {
                colModuleCode.OptionsColumn.AllowEdit = true;
            }

            //colPercentXLKH.Visible = Quotation.DepartmentId == "D018";//KD1
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
            _dtQuotationItem = LibQLSX.Select("select * from vC_QuotationDetail_KD with(nolock) where C_QuotationID = " + Quotation.ID);
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

        void loadCustomerType()
        {
            DataTable dtCustomerType = new DataTable();
            dtCustomerType.Columns.Add("ID", typeof(int));
            dtCustomerType.Columns.Add("Name");

            dtCustomerType.Rows.Add(1, "EUS");
            dtCustomerType.Rows.Add(2, "OEM");

            repositoryItemSearchLookUpEdit2.DataSource = dtCustomerType.Copy();
            repositoryItemSearchLookUpEdit2.DisplayMember = "Name";
            repositoryItemSearchLookUpEdit2.ValueMember = "ID";
        }

        void loadDepartment()
        {
            DataTable tbl = LibQLSX.Select(@"SELECT * FROM Departments WITH(NOLOCK) where DepartmentId in ('D028','D009')");//phòng thiết kế 1, 2

            repositoryItemSearchLookUpEdit3.DataSource = tbl.Copy();
            repositoryItemSearchLookUpEdit3.DisplayMember = "DName";
            repositoryItemSearchLookUpEdit3.ValueMember = "DepartmentId";
        }

        void loadProduct()
        {
            DataTable dt = LibQLSX.Select("select * from C_QuotationDetail_KD with(nolock) where ParentID = 0 and C_QuotationID = " + Quotation.ID);
            cboProduct.Properties.DataSource = dt;
            cboProduct.Properties.DisplayMember = "ModuleCode";
            cboProduct.Properties.ValueMember = "ID";
        }

        void calculateCost(C_QuotationDetail_KDModel item)
        {
            int costID = (Quotation.DepartmentId == "D018" ? 73 : 72);//Phòng KD1->lấy ra chi phí nhân công KD2 không thì lấy chi phí nhân công KD1
            int costID_KD = (Quotation.DepartmentId == "D018" ? 72 : 73);

            if (item.C_ProductGroupID == 0)
            {
                C_CostQuotationItemLinkNewBO.Instance.DeleteByAttribute("C_QuotationDetail_KDID", item.ID);
                item.TotalNC = 0;
                item.TotalPB = 0;
                item.TotalNC_KD = 0;
                C_QuotationDetail_KDBO.Instance.Update(item);
            }
            else
            {
                decimal totalNC = 0;
                decimal totalNC_KD = 0;
                decimal totalPB = 0;

                string sql = "select *, ValuePercentKD = (select top 1 " + (Quotation.DepartmentId == "D018" ? "ValuePercentKD1" : "ValuePercentKD2")
                    + " from vC_CostProductGroupLinkNew where C_CostID = a.ID and [C_ProductGroupID] = "
                    + item.C_ProductGroupID + " and [C_VersionID] = " + Quotation.C_VersionID
                    + ") from vC_CostNew a where IsDeleted = 0 and GroupCode in ('N01','N05','N08','N09','N11')";
                DataTable dtCost = LibQLSX.Select(sql);

                foreach (DataRow row in dtCost.Rows)
                {
                    string code = TextUtils.ToString(row["Code"]);
                    string groupCode = TextUtils.ToString(row["GroupCode"]);

                    C_CostQuotationItemLinkNewModel link = new C_CostQuotationItemLinkNewModel();
                    ArrayList arrLink = C_CostQuotationItemLinkNewBO.Instance.FindByExpression(new Expression("C_CostID", TextUtils.ToInt(row["ID"])).And(new Expression("C_QuotationDetail_KDID", item.ID)));
                    if (arrLink != null && arrLink.Count > 0) link = (C_CostQuotationItemLinkNewModel)arrLink[0];

                    link.C_CostID = TextUtils.ToInt(row["ID"]);
                    link.C_QuotationDetail_KDID = item.ID;
                    if (link.C_CostID == costID)
                    {
                        link.Price = 0;
                    }
                    else
                    {
                        link.Price = TextUtils.ToDecimal(row["ValuePercentKD"]) / 100 * (link.C_CostID == 10 ? item.PriceTPA : item.PriceCP);//lãi vay tính theo giá theo tpa
                    }

                    if (groupCode == "N05")//nhan cong kinh doanh
                    {
                        totalNC_KD += link.Price;
                    }
                    else if (groupCode == "N01")// nhan cong gian tiep khac
                    {
                        totalNC += link.Price;
                    }
                    else
                    {
                        totalPB += link.Price;
                    }                    

                    if (link.ID == 0)
                    {
                        C_CostQuotationItemLinkNewBO.Instance.Insert(link);
                    }
                    else
                    {
                        C_CostQuotationItemLinkNewBO.Instance.Update(link);
                    }
                }
                item.TotalNC_KD = totalNC_KD;
                item.TotalNC = totalNC;
                item.TotalPB = totalPB;
                C_QuotationDetail_KDBO.Instance.Update(item);
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

            C_QuotationDetail_KDModel item = new C_QuotationDetail_KDModel();

            item.C_QuotationID = Quotation.ID;
            item.ParentID = TextUtils.ToInt(cboProduct.EditValue);
            item.C_ProductGroupID = TextUtils.ToInt(cboProductGroup.EditValue);
            //if (item.C_ProductGroupID > 0)
            //{
                item.PriceVT = TextUtils.ToDecimal(txtPriceVTSX.EditValue);
            //}

            string sql = "select top 1 " + (Quotation.DepartmentId == "D018" ? "CustomerPercentKD1" : "CustomerPercentKD2")
                + " from C_ProductGroup where ID = " + item.C_ProductGroupID;
            item.PercentXLKH = TextUtils.ToDecimal(LibQLSX.ExcuteScalar(sql));

            if (item.ParentID > 0)
            {
                item.QtyT = TextUtils.ToDecimal(txtQtyT.EditValue);
                item.Qty = TextUtils.ToDecimal(txtQtyT.EditValue) * TextUtils.ToDecimal(grvCboProduct.GetFocusedRowCellValue(colPQty));

                C_QuotationDetail_KDModel itemP = (C_QuotationDetail_KDModel)C_QuotationDetail_KDBO.Instance.FindByPK(item.ParentID);
                itemP.C_ProductGroupID = 0;
                C_QuotationDetail_KDBO.Instance.Update(itemP);
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

            item.ID = (int)C_QuotationDetail_KDBO.Instance.Insert(item);

            //if (item.ParentID > 0)
            //{
            //    C_QuotationDetail_KDModel itemP = (C_QuotationDetail_KDModel)C_QuotationDetail_KDBO.Instance.FindByPK(item.ParentID);
            //    //itemP.PriceVTSX += item.PriceVTSX;
            //    //itemP.PriceVTLD += item.PriceVTLD;
            //    //itemP.PriceVTPS += item.PriceVTPS;
            //    //itemP.PriceVTTN += item.PriceVTTN;
            //    itemP.PriceVT += item.PriceVT;
            //    C_QuotationDetail_KDBO.Instance.Update(itemP);

            //    //calculateCost(item);
            //}

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
            //frm.QuotationID = Quotation.ID;
            frm.Quotation = Quotation;
            frm.LoadDataChange += main_LoadDataChange;
            TextUtils.OpenForm(frm);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool _isSaved = false;
            if (treeData.AllNodesCount == 0) return;
            treeData.ExpandAll();
            treeData.FocusedNode = null;

            DataTable dtSource = (DataTable)treeData.DataSource;
            DataRow[] drsQty = dtSource.Select("(QtyT is null or QtyT = 0) and C_ProductGroupID > 0");
            //DataRow[] drsVatTu = dtSource.Select("(PriceVT is null or PriceVT = 0) and C_ProductGroupID > 0");
            int checkVT = dtSource.AsEnumerable().Count(o => TextUtils.ToDecimal(o.Field<decimal>("PriceVT")) == 0 && TextUtils.ToInt(o.Field<object>("C_ProductGroupID")) > 0);
            int checkQty = dtSource.AsEnumerable().Count(o => TextUtils.ToDecimal(o.Field<decimal>("QtyT")) == 0 && TextUtils.ToInt(o.Field<object>("C_ProductGroupID")) > 0);

            if (checkQty > 0)
            {
                MessageBox.Show("Bạn chưa nhập số lượng cho các hạng mục.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (checkVT > 0)
            {
                MessageBox.Show("Bạn chưa nhập đủ VẬT TƯ SẢN XUẤT cho các hạng mục.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            int costID = (Quotation.DepartmentId == "D018" ? 73 : 72);//Phòng KD1->lấy ra chi phí nhân công KD2 không thì lấy chi phí nhân công KD1

            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang xử lý..."))
            {
                #region Tính vật tư
                for (int i = 0; i < treeData.AllNodesCount; i++)
                {
                    int id = TextUtils.ToInt(treeData.GetNodeByVisibleIndex(i).GetValue(colDetailID));
                    C_QuotationDetail_KDModel item = (C_QuotationDetail_KDModel)C_QuotationDetail_KDBO.Instance.FindByPK(id);

                    item.ModuleCode = TextUtils.ToString(treeData.GetNodeByVisibleIndex(i).GetValue(colModuleCode));
                    item.ModuleName = TextUtils.ToString(treeData.GetNodeByVisibleIndex(i).GetValue(colModuleName));
                    item.PriceVT = TextUtils.ToDecimal(treeData.GetNodeByVisibleIndex(i).GetValue(colPriceVT));
                    item.PriceHD = TextUtils.ToDecimal(treeData.GetNodeByVisibleIndex(i).GetValue(colPriceHD));
                    item.C_ProductGroupID = TextUtils.ToInt(treeData.GetNodeByVisibleIndex(i).GetValue(colProductGroupID));
                    item.VAT = TextUtils.ToDecimal(treeData.GetNodeByVisibleIndex(i).GetValue(colVAT));
                    item.QtyT = TextUtils.ToDecimal(treeData.GetNodeByVisibleIndex(i).GetValue(colQtyT));
                    item.DepartmentId = TextUtils.ToString(treeData.GetNodeByVisibleIndex(i).GetValue(colDepartmentId));
                    //item.CustomerType = TextUtils.ToInt(treeData.GetNodeByVisibleIndex(i).GetValue(colCustomerType));

                    item.PercentXLKH = TextUtils.ToDecimal(treeData.GetNodeByVisibleIndex(i).GetValue(colPercentXLKH));

                    int parentID = TextUtils.ToInt(treeData.GetNodeByVisibleIndex(i).GetValue(colParentID));
                    if (parentID == 0)
                    {
                        item.Qty = item.QtyT;
                    }
                    else
                    {
                        C_QuotationDetail_KDModel parent = (C_QuotationDetail_KDModel)C_QuotationDetail_KDBO.Instance.FindByPK(parentID);
                        item.Qty = item.QtyT * parent.Qty;
                    }

                    C_QuotationDetail_KDBO.Instance.Update(item);
                }
                #endregion

                #region Tính giá, chi phí
                //DataTable dtCostVT = LibQLSX.Select("select sum(Qty*PriceVT) from C_QuotationDetail_KD where (ParentID > 0 or (ParentID = 0 and C_ProductGroupID > 0)) and [C_QuotationID] = " + Quotation.ID);
                //decimal totalCostVT = dtCostVT.Rows.Count > 0 ? TextUtils.ToDecimal(dtCostVT.Rows[0][0]) : 0;
                string sqlSumCostVT = "select sum(isnull(Qty,0)*isnull(PriceVT,0)) from C_QuotationDetail_KD where (ParentID > 0 or (ParentID = 0 and C_ProductGroupID > 0)) and [C_QuotationID] = " + Quotation.ID;
                decimal totalCostVT = TextUtils.ToDecimal(LibQLSX.ExcuteScalar(sqlSumCostVT));

                for (int i = 0; i < treeData.AllNodesCount; i++)
                {
                    int id = TextUtils.ToInt(treeData.GetNodeByVisibleIndex(i).GetValue(colDetailID));
                    C_QuotationDetail_KDModel item = (C_QuotationDetail_KDModel)C_QuotationDetail_KDBO.Instance.FindByPK(id);

                    if (item.ParentID == 0 && item.C_ProductGroupID == 0) continue;

                    DataTable dtProductGroup = LibQLSX.Select("select top 1 ProfitPercentKD, CustomerPercentKD1, CustomerPercentKD2, ProfitPercentKD_OEM, XLPercent from C_ProductGroup where ID = " + item.C_ProductGroupID);
                    decimal profitPercent = 0;

                    if (Quotation.DepartmentId == "D018")
                    {
                        profitPercent = dtProductGroup.Rows.Count > 0 ? TextUtils.ToDecimal(dtProductGroup.Rows[0]["XLPercent"]) / 100 : 0;
                        
                    }
                    else
                    {
                        if (Quotation.CustomerType == 1)//EUS
                        {
                            profitPercent = dtProductGroup.Rows.Count > 0 ? TextUtils.ToDecimal(dtProductGroup.Rows[0]["ProfitPercentKD"]) / 100 : 0;
                        }
                        if (Quotation.CustomerType == 2)//OEM
                        {
                            profitPercent = dtProductGroup.Rows.Count > 0 ? TextUtils.ToDecimal(dtProductGroup.Rows[0]["ProfitPercentKD_OEM"]) / 100 : 0;
                        }
                    }                   
                    
                    decimal xuLyPhanGuiPercent = item.PercentXLKH;                    
                    
                    decimal chiXucTienBanHang = (Quotation.CustomerCash * item.PriceVT) / totalCostVT;
                    if (Quotation.DepartmentId == "D018")
                    {
                        chiXucTienBanHang = chiXucTienBanHang / (1 - xuLyPhanGuiPercent / 100);
                    }

                    decimal priceDuPhong = (Quotation.TotalDP_KD * item.PriceVT) / totalCostVT;

                    decimal totalPercentCP = TextUtils.ToDecimal(LibQLSX.ExcuteScalar("select Sum(" + (Quotation.DepartmentId == "D018" ? "ValuePercentKD1" : "ValuePercentKD2")
                        + ") from vC_CostProductGroupLinkNew where IsDeleted = 0 and C_CostGroupNew_Code in ('N01','N05','N08','N09','N11') "
                        + " and C_ProductGroupID = " + item.C_ProductGroupID + " and [C_VersionID] = " + Quotation.C_VersionID)) / 100;

                    item.TotalBX = Quotation.TotalBX_KD * item.PriceVT / totalCostVT;   
                    item.TotalVC = Quotation.TotalVC_KD * item.PriceVT / totalCostVT;
                    item.TotalDP = priceDuPhong;
                    item.TotalCustomer = chiXucTienBanHang;
                    item.TotalXL = Quotation.IsVAT == 1 ? xuLyPhanGuiPercent / 100 * chiXucTienBanHang : 0;
                    
                    item.PriceCP = (item.PriceVT + item.TotalBX + item.TotalVC + priceDuPhong) * (1 + profitPercent) / (1 - totalPercentCP * (1 + profitPercent));
                    
                    item.PriceTPA = chiXucTienBanHang + item.PriceCP * (1 + item.VAT / 100);
                    item.PriceTPA_PreVAT = item.PriceTPA / (1 + item.VAT / 100);
                    item.PriceVAT = (item.PriceTPA_PreVAT - chiXucTienBanHang) * item.VAT / 100;
                    item.PriceVAT_HD = ((item.PriceHD / (1 + item.VAT / 100)) - chiXucTienBanHang) * item.VAT / 100;

                    item.PriceReal = item.PriceHD - item.PriceVAT_HD - chiXucTienBanHang;

                    C_QuotationDetail_KDBO.Instance.Update(item);

                    calculateCost(item);

                    decimal totalAllCP = (item.TotalVC + item.TotalBX + item.PriceVT + item.TotalNC + item.TotalNC_KD + item.TotalPB + item.TotalDP);
                    item.TotalProfitQD = item.PriceCP - totalAllCP;
                    item.TotalProfitTT = item.PriceHD - totalAllCP - item.PriceVAT_HD - chiXucTienBanHang;
                    C_QuotationDetail_KDBO.Instance.Update(item);
                }
                #endregion

                #region Tính thiết bị cha
                ArrayList listParent = C_QuotationDetail_KDBO.Instance.FindByExpression(new Expression("ParentID", 0)
                    .And(new Expression("C_ProductGroupID", 0))
                    .And(new Expression("C_QuotationID", Quotation.ID)));

                if (listParent != null)
                {
                    foreach (var item in listParent)
                    {
                        C_QuotationDetail_KDModel itemP = (C_QuotationDetail_KDModel)item;
                        DataTable dtChild = LibQLSX.Select("select Sum(QtyT*PriceVT),Sum(QtyT*PriceTPA),Sum(QtyT*PriceCP),Sum(QtyT*PriceTPA_PreVAT)"
                            + ",Sum(QtyT*PriceVAT),Sum(QtyT*PriceHD),Sum(QtyT*TotalXL)"
                            + ",Sum(QtyT*PriceReal),Sum(QtyT*TotalDP),Sum(QtyT*TotalCustomer),Sum(QtyT*TotalProfitQD),Sum(QtyT*TotalProfitTT)"
                            + ",Sum(QtyT*TotalNC_KD),Sum(QtyT*TotalNC),Sum(QtyT*TotalPB)"
                            + ",Sum(QtyT*TotalBX),Sum(QtyT*TotalVC)"
                            + " from C_QuotationDetail_KD where ParentID = " + itemP.ID);

                        itemP.PriceVT = dtChild.Rows.Count > 0 ? TextUtils.ToDecimal(dtChild.Rows[0][0]) : itemP.PriceVT;
                        itemP.PriceTPA = dtChild.Rows.Count > 0 ? TextUtils.ToDecimal(dtChild.Rows[0][1]) : itemP.PriceTPA;
                        itemP.PriceCP = dtChild.Rows.Count > 0 ? TextUtils.ToDecimal(dtChild.Rows[0][2]) : itemP.PriceCP;
                        itemP.PriceTPA_PreVAT = dtChild.Rows.Count > 0 ? TextUtils.ToDecimal(dtChild.Rows[0][3]) : itemP.PriceTPA_PreVAT;
                        itemP.PriceVAT = dtChild.Rows.Count > 0 ? TextUtils.ToDecimal(dtChild.Rows[0][4]) : itemP.PriceVAT;
                        itemP.PriceHD = dtChild.Rows.Count > 0 ? TextUtils.ToDecimal(dtChild.Rows[0][5]) : itemP.PriceHD;
                        itemP.TotalXL = dtChild.Rows.Count > 0 ? TextUtils.ToDecimal(dtChild.Rows[0][6]) : itemP.TotalXL;
                        itemP.PriceReal = dtChild.Rows.Count > 0 ? TextUtils.ToDecimal(dtChild.Rows[0][7]) : itemP.PriceReal;
                        itemP.TotalDP = dtChild.Rows.Count > 0 ? TextUtils.ToDecimal(dtChild.Rows[0][8]) : itemP.TotalDP;
                        itemP.TotalCustomer = dtChild.Rows.Count > 0 ? TextUtils.ToDecimal(dtChild.Rows[0][9]) : itemP.TotalCustomer;
                        itemP.TotalProfitQD = dtChild.Rows.Count > 0 ? TextUtils.ToDecimal(dtChild.Rows[0][10]) : itemP.TotalProfitQD;
                        itemP.TotalProfitTT = dtChild.Rows.Count > 0 ? TextUtils.ToDecimal(dtChild.Rows[0][11]) : itemP.TotalProfitTT;

                        itemP.TotalNC_KD = dtChild.Rows.Count > 0 ? TextUtils.ToDecimal(dtChild.Rows[0][12]) : itemP.TotalNC_KD;
                        itemP.TotalNC = dtChild.Rows.Count > 0 ? TextUtils.ToDecimal(dtChild.Rows[0][13]) : itemP.TotalNC;
                        itemP.TotalPB = dtChild.Rows.Count > 0 ? TextUtils.ToDecimal(dtChild.Rows[0][14]) : itemP.TotalPB;

                        itemP.TotalBX = dtChild.Rows.Count > 0 ? TextUtils.ToDecimal(dtChild.Rows[0][15]) : itemP.TotalBX;
                        itemP.TotalVC = dtChild.Rows.Count > 0 ? TextUtils.ToDecimal(dtChild.Rows[0][16]) : itemP.TotalVC;

                        C_QuotationDetail_KDBO.Instance.Update(itemP);
                    }
                }
                #endregion

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
                if (Quotation.IsApproved) return;
                try
                {
                    string moduleCode = TextUtils.ToString(treeData.FocusedNode.GetValue(colModuleCode));
                    int id = TextUtils.ToInt(treeData.FocusedNode.GetValue(colDetailID));
                    if (C_QuotationDetail_KDBO.Instance.CheckExist("ParentID", id))
                    {
                        MessageBox.Show("Bạn không thể xóa được thiết bị chính khi nó còn chứa các thiết bị con.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    if (MessageBox.Show("Bạn có chắc muốn xóa thiết bị [" + moduleCode + "]?", TextUtils.Caption,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        C_QuotationDetail_KDModel item = (C_QuotationDetail_KDModel)C_QuotationDetail_KDBO.Instance.FindByPK(id);
                        if (item.ParentID > 0)
                        {
                            C_QuotationDetail_KDModel itemP = (C_QuotationDetail_KDModel)C_QuotationDetail_KDBO.Instance.FindByPK(item.ParentID);
                           
                            itemP.PriceVT -= item.PriceVT;
                            itemP.PriceTPA -= item.PriceTPA;
                            itemP.PriceCP -= item.PriceCP;
                            itemP.PriceTPA_PreVAT -= item.PriceTPA_PreVAT;
                            itemP.PriceVAT -= item.PriceVAT;
                            itemP.PriceHD -= item.PriceHD;
                            itemP.TotalXL -= item.TotalXL;
                            itemP.PriceReal -= item.PriceReal;
                            itemP.TotalDP -= item.TotalDP;
                            itemP.TotalCustomer -= item.TotalCustomer;
                            itemP.TotalProfitQD -= item.TotalProfitQD;
                            itemP.TotalProfitTT -= item.TotalProfitTT;
                            itemP.TotalNC_KD -= item.TotalNC_KD;
                            itemP.TotalNC -= item.TotalNC;
                            itemP.TotalPB -= item.TotalPB;
                            itemP.TotalBX -= item.TotalBX;
                            itemP.TotalVC -= item.TotalVC;

                            C_QuotationDetail_KDBO.Instance.Update(itemP);
                        }

                        C_CostQuotationItemLinkNewBO.Instance.DeleteByAttribute("C_QuotationDetail_KDID", id);
                        C_QuotationDetail_KDBO.Instance.Delete(id);

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
            //int id = TextUtils.ToInt(treeData.FocusedNode.GetValue(colDetailID));
            //if (id == 0) return;
            //C_QuotationDetail_KDModel item = (C_QuotationDetail_KDModel)C_QuotationDetail_KDBO.Instance.FindByPK(id);

            //frmDirectCost frm = new frmDirectCost();
            //frm.QuotationDetail = item;
            //frm.C_QuotationID = Quotation.ID;
            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    if (frm.IsSaved)
            //    {
            //        btnSave_Click(null, null);
            //    }
            //}
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
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

        private void treeData_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            int parentID = TextUtils.ToInt(e.Node.GetValue(colParentID));
            if (parentID == 0)
            {
                e.Appearance.BackColor = Color.LemonChiffon;
            }
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

                DataTable dtChild = LibQLSX.Select("select ID from C_QuotationDetail_KD where ParentID = " + id);
                if (dtChild.Rows.Count > 0)
                {
                    foreach (DataRow row in dtChild.Rows)
                    {
                        int cID = TextUtils.ToInt(row["ID"]);
                        C_QuotationDetail_KDModel child = (C_QuotationDetail_KDModel)C_QuotationDetail_KDBO.Instance.FindByPK(cID);
                        child.PriceHD = totalHD * child.PriceTPA / totalTPA;
                        C_QuotationDetail_KDBO.Instance.Update(child);
                    }
                }

                C_QuotationDetail_KDModel parent = (C_QuotationDetail_KDModel)C_QuotationDetail_KDBO.Instance.FindByPK(id);
                parent.PriceHD = totalHD;
                C_QuotationDetail_KDBO.Instance.Update(parent);
                isSaved = true;
            }
            if (isSaved)
            {
                loadQuotationItem();
            }
        }

        private void btnSetPercentXLPG_Click(object sender, EventArgs e)
        {
            if (treeData.AllNodesCount == 0) return;

            for (int i = 0; i < treeData.AllNodesCount; i++)
            {
                treeData.GetNodeByVisibleIndex(i).SetValue(colPercentXLKH, TextUtils.ToDecimal(txtPercentXLPG.EditValue));
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
