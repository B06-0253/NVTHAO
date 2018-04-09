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
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using BMS.Model;
using BMS.Business;

namespace BMS
{
    public partial class frmQuotationDetailSX : _Forms
    {
        int _rownIndex = 0;
        public C_Quotation_KDModel Quotation = new C_Quotation_KDModel();
        DataTable _dtProduct = new DataTable();
        //DataTable _dtQuotationItem = new DataTable();

        public delegate void LoadDataChangeHandler(object sender, EventArgs e);
        public event LoadDataChangeHandler LoadDataChange;
        public frmQuotationDetailSX()
        {
            InitializeComponent();
        }

        private void frmQuotationDetailSX_Load(object sender, EventArgs e)
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
            //_dtQuotationItem = LibQLSX.Select("select *,TyLe = (case when PriceVT > 0 then (PriceTPA/PriceVT) else 1 end) from vC_QuotationDetail_SX with(nolock) where C_QuotationID = " + Quotation.ID);
            DataTable dtQuotationItem = LibQLSX.Select("select * from vC_QuotationDetail_SX with(nolock) where C_QuotationID = " + Quotation.ID);
            treeData.DataSource = dtQuotationItem;
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
            DataTable dt = LibQLSX.Select("select * from C_QuotationDetail_SX with(nolock) where ParentID = 0 and C_QuotationID = " + Quotation.ID);
            cboProduct.Properties.DataSource = dt;
            cboProduct.Properties.DisplayMember = "ModuleCode";
            cboProduct.Properties.ValueMember = "ID";
        }

        void calculateCost(C_QuotationDetail_SXModel item)
        {
            int costID = (Quotation.DepartmentId == "D018" ? 73 : 72);//Phòng KD1->lấy ra chi phí nhân công KD2 không thì lấy chi phí nhân công KD1

            if (item.C_ProductGroupID == 0)
            {
                C_CostQuotationItemLinkNewBO.Instance.DeleteByAttribute("C_QuotationDetail_SXID", item.ID);
                item.TotalNC = 0;
                item.TotalPB = 0;
                C_QuotationDetail_SXBO.Instance.Update(item);
            }
            else
            {
                ArrayList arr = C_CostBO.Instance.FindByExpression(new Expression("IsUse", 1).And(new Expression("IsWithProject", 0)));
                DataTable dtCostProductGroup = LibQLSX.Select("select * from vC_CostProductGroupLinkNew where [C_ProductGroupID] = " + item.C_ProductGroupID);
                decimal totalNC = 0;
                decimal totalPB = 0;
                foreach (var c in arr)
                {
                    C_CostModel cost = (C_CostModel)c;
                    DataRow[] drs = dtCostProductGroup.Select("C_CostID = " + cost.ID);
                    if (drs.Length == 0) continue;
                    C_CostQuotationItemLinkNewModel link = new C_CostQuotationItemLinkNewModel();

                    ArrayList arrLink = C_CostQuotationItemLinkNewBO.Instance.FindByExpression(new Expression("C_CostID", cost.ID).And(new Expression("C_QuotationDetail_SXID", item.ID)));
                    if (arrLink != null && arrLink.Count > 0) link = (C_CostQuotationItemLinkNewModel)arrLink[0];

                    link.C_CostID = cost.ID;
                    link.C_QuotationDetail_SXID = item.ID;
                    link.IsDirect = cost.IsDirectCost;
                    if (link.IsDirect == 1)
                    {
                        #region Chi phí nhân công
                        if (link.ID == 0)
                        {
                            if (cost.Price == 0)
                            {
                                link.Price = 0;
                            }
                            else
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
                        }

                        totalNC += link.Price;
                        #endregion
                    }
                    else
                    {
                        #region Chi phí phân bổ
                        if (item.PriceHD > 0)
                        {
                            decimal valuePercent = TextUtils.ToDecimal(drs[0]["ValuePercentSX"]);

                            link.Price = valuePercent / 100 * item.PriceTPA;

                            if (link.C_CostID == costID)
                            {
                                link.Price = 0;
                            }
                            else
                            {
                                //link.Price = TextUtils.ToDecimal(row["ValuePercentSX"]) / 100 * item.PriceTPA;
                            }
                        }
                        #endregion
                    }

                    if (link.ID == 0)
                    {
                        C_CostQuotationItemLinkNewBO.Instance.Insert(link);
                    }
                    else
                    {
                        C_CostQuotationItemLinkNewBO.Instance.Update(link);
                    }

                    item.TotalNC = totalNC;
                    item.TotalPB = totalPB;
                    C_QuotationDetail_SXBO.Instance.Update(item);
                }
            }
        }

        void calculateCost_PB(C_QuotationDetail_SXModel item)
        {
            int costID = (Quotation.DepartmentId == "D018" ? 73 : 72);//Phòng KD1->lấy ra chi phí nhân công KD2 không thì lấy chi phí nhân công KD1

            if (item.C_ProductGroupID == 0)
            {
                C_CostQuotationItemLinkNewBO.Instance.DeleteByAttribute("C_QuotationDetail_SXID", item.ID);
                item.TotalNC = 0;
                item.TotalPB = 0;
                C_QuotationDetail_KDBO.Instance.Update(item);
            }
            else
            {
                //ArrayList arr = C_CostBO.Instance.FindByExpression(new Expression("IsUse", 1));
                string sql = "";
                if (Quotation.StatusNC == 1)
                {
                    sql = "select *, ValuePercentSX = (select top 1 ValuePercentSX from vC_CostProductGroupLinkNew where C_CostID = a.ID and [C_ProductGroupID] = "
                    + item.C_ProductGroupID + " and [C_VersionID] = " + Quotation.C_VersionID + ") from vC_CostNew a where IsUse = 1 and IsDeleted = 0 and GroupCode in ('N01','N08','N09','N11','N02','N03','N04','N07.02','N07.03')";
                }
                else
                {
                    sql = "select *, ValuePercentSX = (select top 1 ValuePercentSX from vC_CostProductGroupLinkNew where C_CostID = a.ID and [C_ProductGroupID] = "
                    + item.C_ProductGroupID + " and [C_VersionID] = " + Quotation.C_VersionID + ") from vC_CostNew a where IsUse = 1 and IsDeleted = 0 and GroupCode in ('N01','N08','N09','N11')";
                }

                DataTable dtCost = LibQLSX.Select(sql);

                foreach (DataRow row in dtCost.Rows)
                {
                    string code = TextUtils.ToString(row["Code"]);
                    C_CostQuotationItemLinkNewModel link = new C_CostQuotationItemLinkNewModel();
                    ArrayList arrLink = C_CostQuotationItemLinkNewBO.Instance.FindByExpression(new Expression("C_CostID", TextUtils.ToInt(row["ID"]))
                        .And(new Expression("C_QuotationDetail_SXID", item.ID)));
                    if (arrLink != null && arrLink.Count > 0) link = (C_CostQuotationItemLinkNewModel)arrLink[0];

                    link.C_CostID = TextUtils.ToInt(row["ID"]);
                    link.C_QuotationDetail_SXID = item.ID;
                    //if (link.C_CostID == costID)
                    //{
                    //    link.Price = 0;
                    //}
                    //else
                    //{
                    link.Price = TextUtils.ToDecimal(row["ValuePercentSX"]) / 100 * item.PriceTPA;
                    //}

                    if (link.ID == 0)
                    {
                        C_CostQuotationItemLinkNewBO.Instance.Insert(link);
                    }
                    else
                    {
                        C_CostQuotationItemLinkNewBO.Instance.Update(link);
                    }
                }
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

            C_QuotationDetail_SXModel item = new C_QuotationDetail_SXModel();

            item.C_QuotationID = Quotation.ID;
            item.ParentID = TextUtils.ToInt(cboProduct.EditValue);
            item.C_ProductGroupID = TextUtils.ToInt(cboProductGroup.EditValue);
            item.PriceVT = TextUtils.ToDecimal(txtPriceVTSX.EditValue);
            item.PriceVTLD = TextUtils.ToDecimal(txtPriceVTLD.EditValue);
            item.PriceVTPS = TextUtils.ToDecimal(txtPriceVTPS.EditValue);
            item.PriceVTTN = TextUtils.ToDecimal(txtPriceVTTN.EditValue);
            item.QtyT = TextUtils.ToDecimal(txtQtyT.EditValue);
            item.Manufacture = txtManufacture.Text.Trim();
            item.ModuleCode = item.ModuleCodeHD = txtModuleCode.Text.Trim().ToUpper();
            item.ModuleName = item.ModuleNameHD = txtModuleName.Text.Trim();
            item.Origin = txtOrigin.Text.Trim();
            item.VAT = TextUtils.ToDecimal(txtVAT.EditValue);

            if (item.ParentID > 0)
            {
                item.Qty = TextUtils.ToDecimal(txtQtyT.EditValue) * TextUtils.ToDecimal(grvCboProduct.GetFocusedRowCellValue(colPQty));
            }
            else
            {
                item.Qty = item.QtyT = TextUtils.ToDecimal(txtQtyT.EditValue);
            }

            item.CreatedBy = item.UpdatedBy = Global.AppUserName;
            item.CreatedDate = item.UpdatedDate = DateTime.Now;

            item.ID = (int)C_QuotationDetail_SXBO.Instance.Insert(item);

            if (item.ParentID > 0)
            {
                C_QuotationDetail_SXModel itemP = (C_QuotationDetail_SXModel)C_QuotationDetail_SXBO.Instance.FindByPK(item.ParentID);
                itemP.C_ProductGroupID = 0;
                itemP.PriceVT += item.PriceVT;
                itemP.PriceVTLD += item.PriceVTLD;
                itemP.PriceVTPS += item.PriceVTPS;
                itemP.PriceVTTN += item.PriceVTTN;
                C_QuotationDetail_SXBO.Instance.Update(itemP);
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
            if (treeData.AllNodesCount > 0)
            {
                MessageBox.Show("Báo giá đã được thêm từ Excel.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            frmQuotationDetailImportSX frm = new frmQuotationDetailImportSX();
            frm.Quotation = Quotation;
            //frm.QuotationID = Quotation.ID;
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
            DataRow[] drsVatTu = dtSource.Select("(PriceVT is null or PriceVT = 0) and (C_ProductGroupID > 0 and ParentID > 0)");
            if (drsVatTu.Length > 0)
            {
                MessageBox.Show("Bạn chưa nhập đủ VẬT TƯ SẢN XUẤT cho các hạng mục.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            int costID = (Quotation.DepartmentId == "D018" ? 73 : 72);//Phòng KD1->lấy ra chi phí nhân công KD2 không thì lấy chi phí nhân công KD1
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang xử lý..."))
            {
                #region Save item
                for (int i = 0; i < treeData.AllNodesCount; i++)
                {
                    int id = TextUtils.ToInt(treeData.GetNodeByVisibleIndex(i).GetValue(colDetailID));
                    C_QuotationDetail_SXModel item = (C_QuotationDetail_SXModel)C_QuotationDetail_SXBO.Instance.FindByPK(id);

                    item.ModuleCode = TextUtils.ToString(treeData.GetNodeByVisibleIndex(i).GetValue(colModuleCode));
                    item.ModuleName = TextUtils.ToString(treeData.GetNodeByVisibleIndex(i).GetValue(colModuleName));
                    item.PriceVTLD = TextUtils.ToDecimal(treeData.GetNodeByVisibleIndex(i).GetValue(colPriceVTLD));
                    item.PriceVTPS = TextUtils.ToDecimal(treeData.GetNodeByVisibleIndex(i).GetValue(colPriceVTPS));
                    item.PriceVT = TextUtils.ToDecimal(treeData.GetNodeByVisibleIndex(i).GetValue(colPriceVTSX));
                    item.PriceVTTN = TextUtils.ToDecimal(treeData.GetNodeByVisibleIndex(i).GetValue(colPriceVTTN));

                    item.PriceHD = TextUtils.ToDecimal(treeData.GetNodeByVisibleIndex(i).GetValue(colPriceHD));

                    item.C_ProductGroupID = TextUtils.ToInt(treeData.GetNodeByVisibleIndex(i).GetValue(colProductGroupID));
                    item.VAT = TextUtils.ToDecimal(treeData.GetNodeByVisibleIndex(i).GetValue(colVAT));
                    item.QtyT = TextUtils.ToDecimal(treeData.GetNodeByVisibleIndex(i).GetValue(colQtyT));

                    string sqlPB = "select sum(ValuePercentSX) from vC_CostProductGroupLinkNew where C_CostGroupNew_Code in ('N01','N08','N09','N11') and C_ProductGroupID = " + item.C_ProductGroupID + " and [C_VersionID] = " + Quotation.C_VersionID;
                    string sqlNC = "select sum(ValuePercentSX) from vC_CostProductGroupLinkNew where C_CostGroupNew_Code in ('N02','N03','N04','N07.02','N07.03') and C_ProductGroupID = " + item.C_ProductGroupID + " and [C_VersionID] = " + Quotation.C_VersionID;

                    decimal totalPercentCP_PB = TextUtils.ToDecimal(LibQLSX.ExcuteScalar(sqlPB)) / 100;
                    decimal totalPercentCP_NC = TextUtils.ToDecimal(LibQLSX.ExcuteScalar(sqlNC)) / 100;

                    item.TotalPercentCP_NC = totalPercentCP_NC;
                    item.TotalPercentCP_PB = totalPercentCP_PB;

                    int parentID = TextUtils.ToInt(treeData.GetNodeByVisibleIndex(i).GetValue(colParentID));
                    if (parentID == 0)
                    {
                        item.Qty = item.QtyT;
                    }
                    else
                    {
                        C_QuotationDetail_SXModel parent = (C_QuotationDetail_SXModel)C_QuotationDetail_SXBO.Instance.FindByPK(parentID);
                        item.Qty = item.QtyT * parent.Qty;
                    }

                    item.UpdatedDate = DateTime.Now;
                    item.UpdatedBy = Global.AppUserName;
                    C_QuotationDetail_SXBO.Instance.Update(item);
                }
                #endregion

                DataTable dtCostVT = LibQLSX.Select("select sum(isnull(Qty,0)*(isnull(PriceVT,0)+isnull(PriceVTTN,0)+isnull(PriceVTPS,0)+isnull(PriceVTLD,0)))"
                    + ", sum(isnull(Qty,0)*isnull(TotalPercentCP_NC,0))"
                    //+ ", sum(isnull(Qty,0)*isnull(TotalPercentCP_PB,0))"
                    + " from C_QuotationDetail_SX where (ParentID > 0 or (ParentID = 0 and C_ProductGroupID > 0)) and [C_QuotationID] = " + Quotation.ID);
                decimal totalAllVT = dtCostVT.Rows.Count > 0 ? TextUtils.ToDecimal(dtCostVT.Rows[0][0]) : 0;
                decimal totalAllPercentCP_NC = dtCostVT.Rows.Count > 0 ? TextUtils.ToDecimal(dtCostVT.Rows[0][1]) : 0;
                //decimal totalAllPercentCP_PB = dtCostVT.Rows.Count > 0 ? TextUtils.ToDecimal(dtCostVT.Rows[0][2]) : 0;

                if (Quotation.StatusNC == 1)
                {
                    #region Tính nhân công theo % phân bổ
                    for (int i = 0; i < treeData.AllNodesCount; i++)
                    {
                        int id = TextUtils.ToInt(treeData.GetNodeByVisibleIndex(i).GetValue(colDetailID));
                        C_QuotationDetail_SXModel item = (C_QuotationDetail_SXModel)C_QuotationDetail_SXBO.Instance.FindByPK(id);

                        if (item.ParentID == 0 && item.C_ProductGroupID == 0) continue;

                        decimal profitPercent = TextUtils.ToDecimal(LibQLSX.ExcuteScalar("select top 1 ProfitPercentSX from C_ProductGroup where ID = " + item.C_ProductGroupID)) / 100;

                        decimal percentPB = item.TotalPercentCP_NC + item.TotalPercentCP_PB;

                        decimal totalVT = item.PriceVT + item.PriceVTLD + item.PriceVTPS + item.PriceVTTN;

                        decimal tyle = (item.TotalPercentCP_NC + totalVT) / (totalAllPercentCP_NC + totalAllVT);
                        item.TotalDP = Quotation.TotalDP_SX * tyle;//dự phòng
                        item.TotalVC = Quotation.TotalCPVCHB_C13 * tyle;//vận chuyển
                        item.TotalBX = Quotation.TotalBXHB_C52 * tyle;//bốc xếp
                        item.PriceDiLai = Quotation.TotalDiLai * tyle;//Đi lại

                        item.TotalPB_DA = item.TotalDP + item.TotalVC + item.TotalBX + item.PriceDiLai;

                        item.PriceCP = item.TotalPB_DA + totalVT;
                        item.PriceTPA = item.PriceCP * (1 + profitPercent) / (1 - percentPB * (1 + profitPercent));

                        item.TotalPB = item.TotalPercentCP_PB / 100 * item.PriceTPA;
                        item.TotalNC = item.TotalPercentCP_NC / 100 * item.PriceTPA;
                        item.TotalProfit = profitPercent * (item.PriceCP + (percentPB * item.PriceTPA));

                        C_QuotationDetail_SXBO.Instance.Update(item);

                        calculateCost_PB(item);
                    }
                    #endregion
                }
                else
                {
                    #region Tính nhân công theo công nhật

                    decimal totalAllNC = TextUtils.ToDecimal(LibQLSX.ExcuteScalar("select sum(isnull(Qty,0) * isnull(Price,0)) from vC_CostQuotationItemLinkSX"
                        + " where IsDirect = 1 and [C_QuotationID] = " + Quotation.ID));

                    for (int i = 0; i < treeData.AllNodesCount; i++)
                    {
                        int id = TextUtils.ToInt(treeData.GetNodeByVisibleIndex(i).GetValue(colDetailID));
                        C_QuotationDetail_SXModel item = (C_QuotationDetail_SXModel)C_QuotationDetail_SXBO.Instance.FindByPK(id);

                        if (item.ParentID == 0 && item.C_ProductGroupID == 0) continue;

                        decimal profitPercent = TextUtils.ToDecimal(LibQLSX.ExcuteScalar("select top 1 ProfitPercentSX from C_ProductGroup where ID = " + item.C_ProductGroupID)) / 100;
                        decimal percentPB = item.TotalPercentCP_PB;

                        decimal totalVT = item.PriceVT + item.PriceVTLD + item.PriceVTPS + item.PriceVTTN;
                        decimal totalNC = TextUtils.ToDecimal(LibQLSX.ExcuteScalar("select sum(Price) from C_CostQuotationItemLinkNew where IsDirect = 1 and C_QuotationDetail_SXID = " + item.ID));

                        item.TotalNC = totalNC;
                        item.TotalDP = Quotation.TotalDP_SX * (item.TotalNC + totalVT) / (totalAllNC + totalAllVT);//dự phòng
                        item.TotalVC = Quotation.TotalCPVCHB_C13 * (item.TotalNC + totalVT) / (totalAllNC + totalAllVT);//vận chuyển
                        item.TotalBX = Quotation.TotalBXHB_C52 * (item.TotalNC + totalVT) / (totalAllNC + totalAllVT);//bốc xếp
                        item.PriceDiLai = Quotation.TotalDiLai * (item.TotalNC + totalVT) / (totalAllNC + totalAllVT);//Đi lại

                        item.TotalPB_DA = item.TotalDP + item.TotalVC + item.TotalBX;

                        item.PriceCP = item.TotalNC + item.TotalPB_DA + totalVT;
                        item.PriceTPA = item.PriceCP * (1 + profitPercent) / (1 - percentPB * (1 + profitPercent));

                        item.TotalPB = percentPB * item.PriceTPA;
                        //item.TotalNC = item.TotalPercentCP_NC * item.PriceTPA;
                        item.TotalProfit = profitPercent * (item.PriceCP + (percentPB * item.PriceTPA));

                        C_QuotationDetail_SXBO.Instance.Update(item);

                        calculateCost_PB(item);
                    }
                    #endregion
                }

                #region Save parent
                ArrayList listParent = C_QuotationDetail_SXBO.Instance.FindByExpression(new Expression("ParentID", 0)
                    .And(new Expression("C_ProductGroupID", 0))
                    .And(new Expression("C_QuotationID", Quotation.ID)));

                if (listParent != null)
                {
                    foreach (var item in listParent)
                    {
                        C_QuotationDetail_SXModel itemP = (C_QuotationDetail_SXModel)item;

                        DataTable dtChild = LibQLSX.Select("select PriceVTLD=Sum(QtyT*PriceVTLD),PriceVTPS=Sum(QtyT*PriceVTPS),PriceVT=Sum(QtyT*PriceVT),PriceVTTN=Sum(QtyT*PriceVTTN)"
                        + ",TotalNC=Sum(QtyT*TotalNC),TotalPB_DA=Sum(QtyT*TotalPB_DA),TotalPB=Sum(QtyT*TotalPB),PriceCP=Sum(QtyT*PriceCP),PriceTPA=Sum(QtyT*PriceTPA),PriceHD=Sum(QtyT*PriceHD)"
                        + ",TotalProfit=Sum(QtyT*TotalProfit)"
                        + ",TotalDP=Sum(QtyT*TotalDP),TotalVC=Sum(QtyT*TotalVC),TotalBX=Sum(QtyT*TotalBX) from C_QuotationDetail_SX where ParentID = " + itemP.ID);

                        itemP.PriceVTLD = dtChild.Rows.Count > 0 ? TextUtils.ToDecimal(dtChild.Rows[0]["PriceVTLD"]) : itemP.PriceVTLD;
                        itemP.PriceVTPS = dtChild.Rows.Count > 0 ? TextUtils.ToDecimal(dtChild.Rows[0]["PriceVTPS"]) : itemP.PriceVTPS;
                        itemP.PriceVT = dtChild.Rows.Count > 0 ? TextUtils.ToDecimal(dtChild.Rows[0]["PriceVT"]) : itemP.PriceVT;
                        itemP.PriceVTTN = dtChild.Rows.Count > 0 ? TextUtils.ToDecimal(dtChild.Rows[0]["PriceVTTN"]) : itemP.PriceVTTN;
                        itemP.TotalNC = dtChild.Rows.Count > 0 ? TextUtils.ToDecimal(dtChild.Rows[0]["TotalNC"]) : itemP.TotalNC;
                        itemP.TotalPB_DA = dtChild.Rows.Count > 0 ? TextUtils.ToDecimal(dtChild.Rows[0]["TotalPB_DA"]) : itemP.TotalPB_DA;
                        itemP.TotalPB = dtChild.Rows.Count > 0 ? TextUtils.ToDecimal(dtChild.Rows[0]["TotalPB"]) : itemP.TotalPB;
                        itemP.PriceCP = dtChild.Rows.Count > 0 ? TextUtils.ToDecimal(dtChild.Rows[0]["PriceCP"]) : itemP.PriceCP;
                        itemP.PriceTPA = dtChild.Rows.Count > 0 ? TextUtils.ToDecimal(dtChild.Rows[0]["PriceTPA"]) : itemP.PriceTPA;
                        itemP.PriceHD = dtChild.Rows.Count > 0 ? TextUtils.ToDecimal(dtChild.Rows[0]["PriceHD"]) : itemP.PriceHD;
                        itemP.TotalProfit = dtChild.Rows.Count > 0 ? TextUtils.ToDecimal(dtChild.Rows[0]["TotalProfit"]) : itemP.TotalProfit;

                        itemP.TotalDP = dtChild.Rows.Count > 0 ? TextUtils.ToDecimal(dtChild.Rows[0]["TotalDP"]) : itemP.TotalDP;
                        itemP.TotalVC = dtChild.Rows.Count > 0 ? TextUtils.ToDecimal(dtChild.Rows[0]["TotalVC"]) : itemP.TotalVC;
                        itemP.TotalBX = dtChild.Rows.Count > 0 ? TextUtils.ToDecimal(dtChild.Rows[0]["TotalBX"]) : itemP.TotalBX;

                        C_QuotationDetail_SXBO.Instance.Update(itemP);
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
                    if (C_QuotationDetail_SXBO.Instance.CheckExist("ParentID", id))
                    {
                        MessageBox.Show("Bạn không thể xóa được thiết bị chính khi nó còn chứa các thiết bị con.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    if (MessageBox.Show("Bạn có chắc muốn xóa thiết bị [" + moduleCode + "]?", TextUtils.Caption,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        C_QuotationDetail_SXModel item = (C_QuotationDetail_SXModel)C_QuotationDetail_SXBO.Instance.FindByPK(id);
                        if (item.ParentID > 0)
                        {
                            C_QuotationDetail_SXModel itemP = (C_QuotationDetail_SXModel)C_QuotationDetail_SXBO.Instance.FindByPK(item.ParentID);
                            itemP.PriceVT -= item.PriceVT;
                            itemP.PriceVTLD -= item.PriceVTLD;
                            itemP.PriceVTPS -= item.PriceVTPS;
                            itemP.PriceVTTN -= item.PriceVTTN;
                            //itemP.PriceVT -= item.PriceVT;
                            itemP.PriceHD -= item.PriceHD;
                            C_QuotationDetail_SXBO.Instance.Update(itemP);
                        }

                        C_CostQuotationItemLinkNewBO.Instance.DeleteByAttribute("C_QuotationDetail_SXID", id);
                        C_QuotationDetail_SXBO.Instance.Delete(id);

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
            //C_QuotationDetail_SXModel item = (C_QuotationDetail_SXModel)C_QuotationDetail_SXBO.Instance.FindByPK(id);

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

        private void treeData_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            int parentID = TextUtils.ToInt(e.Node.GetValue(colParentID));
            if (parentID == 0)
            {
                e.Appearance.BackColor = Color.LemonChiffon;
            }
        }

        private void btnCPNC_Click(object sender, EventArgs e)
        {
            if (Quotation.StatusNC != 2)
            {
                MessageBox.Show("Báo giá này Nhân công tính theo tỉ lệ %.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            frmChiPhiNhanCong frm = new frmChiPhiNhanCong();
            //frm.QuotationDetail = item;
            frm.C_QuotationID = Quotation.ID;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (frm.IsSaved)
                {
                    btnSave_Click(null, null);
                }
            }
        }

        void exportBaoGia()
        {
            if (treeData.AllNodesCount == 0) return;

            string localPath = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                localPath = fbd.SelectedPath + "\\SX." + Quotation.Code + ".xls";
            }
            else
            {
                return;
            }

            string filePath = Application.StartupPath + "\\Templates\\PhongKinhDoanh\\BaoGia.xls";

            try
            {
                File.Copy(filePath, localPath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + Environment.NewLine + ex.Message);
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

                    DataTable dtItem = LibQLSX.Select("select * from vC_QuotationDetail_SX with(nolock) where ParentID = 0 and C_QuotationID = " + Quotation.ID);

                    for (int i = dtItem.Rows.Count - 1; i >= 0; i--)
                    {
                        int id = TextUtils.ToInt(dtItem.Rows[i]["ID"]);
                        string moduleCodeP = TextUtils.ToString(dtItem.Rows[i]["ModuleCode"]);
                        string moduleNameP = TextUtils.ToString(dtItem.Rows[i]["ModuleName"]);
                        decimal qtyP = TextUtils.ToDecimal(dtItem.Rows[i]["Qty"]);
                        decimal priceP = TextUtils.ToDecimal(dtItem.Rows[i]["PriceHD"]);
                        string hangP = TextUtils.ToString(dtItem.Rows[i]["Manufacture"]);
                        DataTable dtC = LibQLSX.Select("select * from vC_QuotationDetail_SX with(nolock) where ParentID = " + id);

                        if (dtC.Rows.Count == 0)//nếu thiết bị không có thiết bị con
                        {
                            #region Add Parent
                            if (moduleCodeP.ToUpper().StartsWith("TPAD.") && moduleCodeP.Length == 10)
                            {
                                try
                                {
                                    string spec = TextUtils.ToString(TextUtils.ExcuteScalar("select top 1 Specifications from Modules where Code = '" + moduleCodeP + "'"));
                                    if (spec.Length > 0)
                                    {
                                        string[] thongSo = spec.Split('\n');
                                        for (int k = thongSo.Length - 1; k >= 0; k--)
                                        {
                                            workSheet.Cells[16, 3] = thongSo[k];
                                            ((Excel.Range)workSheet.Rows[16]).Insert();
                                        }
                                    }
                                    else
                                    {
                                        ((Excel.Range)workSheet.Rows[16]).Insert();
                                        ((Excel.Range)workSheet.Rows[16]).Insert();
                                    }
                                }
                                catch
                                {
                                }
                            }
                            else
                            {
                                ((Excel.Range)workSheet.Rows[16]).Insert();
                                ((Excel.Range)workSheet.Rows[16]).Insert();
                            }

                            workSheet.Cells[16, 2] = (i + 1);
                            workSheet.Cells[16, 3] = moduleNameP.ToUpper();
                            workSheet.Cells[16, 4] = moduleCodeP.ToUpper();
                            workSheet.Cells[16, 5] = hangP;
                            workSheet.Cells[16, 6] = "BỘ";
                            workSheet.Cells[16, 7] = qtyP.ToString("n0");
                            workSheet.Cells[16, 8] = priceP.ToString("n0");
                            workSheet.Cells[16, 9] = qtyP * priceP;
                            ((Excel.Range)workSheet.Rows[16]).Font.Bold = true;
                            ((Excel.Range)workSheet.Rows[16]).Insert();
                            #endregion
                        }
                        else
                        {
                            decimal sumPrice = 0;

                            #region Add child module
                            for (int j = dtC.Rows.Count - 1; j >= 0; j--)
                            {
                                string moduleCode = TextUtils.ToString(dtC.Rows[j]["ModuleCode"]);
                                string moduleName = TextUtils.ToString(dtC.Rows[j]["ModuleName"]);
                                string qty = TextUtils.ToDecimal(dtC.Rows[j]["QtyT"]).ToString("n0");
                                string price = TextUtils.ToDecimal(dtC.Rows[j]["PriceHD"]).ToString("n0");
                                string hang = TextUtils.ToString(dtC.Rows[j]["Manufacture"]);
                                //string total = TextUtils.ToDecimal(dtC.Rows[j]["TotalTPA"]).ToString("n0");
                                sumPrice += TextUtils.ToDecimal(qty) * TextUtils.ToDecimal(price);

                                if (moduleCode.ToUpper().StartsWith("TPAD.") && moduleCode.Length == 10)
                                {
                                    try
                                    {
                                        string spec = TextUtils.ToString(TextUtils.ExcuteScalar("select top 1 Specifications from Modules where Code = '" + moduleCode + "'"));
                                        if (spec.Length > 0)
                                        {
                                            string[] thongSo = spec.Split('\n');
                                            for (int k = thongSo.Length - 1; k >= 0; k--)
                                            {
                                                workSheet.Cells[16, 3] = thongSo[k];
                                                ((Excel.Range)workSheet.Rows[16]).Insert();
                                            }
                                        }
                                        else
                                        {
                                            ((Excel.Range)workSheet.Rows[16]).Insert();
                                            ((Excel.Range)workSheet.Rows[16]).Insert();
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                                else
                                {
                                    ((Excel.Range)workSheet.Rows[16]).Insert();
                                    ((Excel.Range)workSheet.Rows[16]).Insert();
                                }

                                workSheet.Cells[16, 2] = (i + 1) + "." + (j + 1);
                                workSheet.Cells[16, 3] = moduleName;//.ToUpper();
                                workSheet.Cells[16, 4] = moduleCode;//.ToUpper();
                                workSheet.Cells[16, 5] = hang;
                                workSheet.Cells[16, 6] = "";
                                workSheet.Cells[16, 7] = qty;
                                workSheet.Cells[16, 8] = price;
                                //workSheet.Cells[16, 9] = total;
                                ((Excel.Range)workSheet.Rows[16]).Font.Bold = true;
                                ((Excel.Range)workSheet.Rows[16]).Insert();
                            }
                            #endregion

                            #region Add Parent
                            workSheet.Cells[16, 3] = "'* Thông số kỹ thuật chi tiết";
                            ((Excel.Range)workSheet.Rows[16]).Font.Bold = true;
                            ((Excel.Range)workSheet.Rows[16]).Insert();

                            for (int j = dtC.Rows.Count - 1; j >= 0; j--)
                            {
                                string moduleName = TextUtils.ToString(dtC.Rows[j]["ModuleName"]);
                                string qty = TextUtils.ToDecimal(dtC.Rows[j]["QtyT"]).ToString("n0");
                                workSheet.Cells[16, 3] = qty + " " + moduleName;
                                ((Excel.Range)workSheet.Rows[16]).Insert();
                            }

                            workSheet.Cells[16, 3] = "'* Danh mục thiết bị";
                            ((Excel.Range)workSheet.Rows[16]).Font.Bold = true;
                            ((Excel.Range)workSheet.Rows[16]).Insert();
                            ((Excel.Range)workSheet.Rows[16]).Insert();
                            ((Excel.Range)workSheet.Rows[16]).Insert();

                            workSheet.Cells[16, 3] = "'* Nội dung thực hành";
                            ((Excel.Range)workSheet.Rows[16]).Font.Bold = true;
                            ((Excel.Range)workSheet.Rows[16]).Insert();

                            workSheet.Cells[16, 3] = "'- Xuất xứ: Việt Nam";
                            ((Excel.Range)workSheet.Rows[16]).Insert();
                            workSheet.Cells[16, 3] = "'- Hãng sản xuất: TPA";
                            ((Excel.Range)workSheet.Rows[16]).Insert();
                            workSheet.Cells[16, 3] = "'- Model: " + moduleCodeP;
                            ((Excel.Range)workSheet.Rows[16]).Insert();

                            workSheet.Cells[16, 2] = (i + 1);
                            workSheet.Cells[16, 3] = moduleNameP.ToUpper();
                            workSheet.Cells[16, 4] = moduleCodeP.ToUpper();
                            workSheet.Cells[16, 5] = hangP;
                            workSheet.Cells[16, 6] = "BỘ";
                            workSheet.Cells[16, 7] = qtyP.ToString("n0");
                            workSheet.Cells[16, 8] = sumPrice.ToString("n0");
                            workSheet.Cells[16, 9] = qtyP * sumPrice;
                            ((Excel.Range)workSheet.Rows[16]).Font.Bold = true;
                            ((Excel.Range)workSheet.Rows[16]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);// Color.Yellow;
                            ((Excel.Range)workSheet.Rows[16]).Insert();
                            #endregion
                        }
                    }
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

                if (File.Exists(localPath))
                    Process.Start(localPath);
            }
        }

        private void btnCreateBaoGia_Click(object sender, EventArgs e)
        {
            exportBaoGia();
        }
    }
}
