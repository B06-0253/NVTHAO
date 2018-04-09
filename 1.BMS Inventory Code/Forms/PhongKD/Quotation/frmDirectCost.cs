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
using DevExpress.Utils;
using System.Collections;

namespace BMS
{
    public partial class frmDirectCost : _Forms
    {
        public int C_QuotationID = 0;
        public bool IsSaved = false;
        public C_QuotationDetailModel QuotationDetail = new C_QuotationDetailModel();
        C_QuotationModel model = new C_QuotationModel();
        public frmDirectCost()
        {
            InitializeComponent();
        }

        private void frmDirectCost_Load(object sender, EventArgs e)
        {
            model = (C_QuotationModel)C_QuotationBO.Instance.FindByPK(C_QuotationID);
            //btnSave.en
            btnResetAll.Enabled = btnSave.Enabled = btnSaveAndClose.Enabled = resetToolStripMenuItem.Enabled = !model.IsApproved;
            loadData();            
        }

        void loadData()
        {
            DataTable dt = LibQLSX.Select("select *,TongTien = Price*Qty  from vC_CostQuotationItemLink where IsDirectCost = 1 and C_QuotationID = " + C_QuotationID);
            grdLink.DataSource = dt;
        }

        void save()
        {
            //grvLink.ClearColumnsFilter(); * (1 + 0.3M * (item.Qty >= 2 ? item.Qty - 1 : 0)) / item.Qty colC_QuotationDetailID
            grvLink.FocusedRowHandle = -1;
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang xử lý..."))
            {
                for (int i = 0; i < grvLink.RowCount; i++)
                {
                    int id = TextUtils.ToInt(grvLink.GetRowCellValue(i, colID));
                    if (id == 0) return;
                    decimal pricePerDay = TextUtils.ToDecimal(grvLink.GetRowCellValue(i, colPricePerDay));                    
                    int costID = TextUtils.ToInt(grvLink.GetRowCellValue(i, colC_CostID));
                    decimal qty = TextUtils.ToDecimal(grvLink.GetRowCellValue(i, colQty));                  

                    C_CostQuotationItemLinkModel link = (C_CostQuotationItemLinkModel)C_CostQuotationItemLinkBO.Instance.FindByPK(id);
                    link.NumberDay = TextUtils.ToDecimal(grvLink.GetRowCellValue(i, colNumberDay));
                    link.PersonNumber = TextUtils.ToDecimal(grvLink.GetRowCellValue(i, colPersonNumber));
                    link.TotalR = link.NumberDay * link.PersonNumber;
                    if (costID == 61)//nhân công thiết kế
                    {
                        //int quotationDetailID = TextUtils.ToInt(grvLink.GetRowCellValue(i, colC_QuotationDetailID));
                        //C_QuotationDetailModel item = (C_QuotationDetailModel)C_QuotationDetailBO.Instance.FindByPK(quotationDetailID);
                        link.TotalR *=  (1 + 0.3M * (qty - 1)) / qty;
                    }
                    link.Price = link.TotalR * pricePerDay;
                    C_CostQuotationItemLinkBO.Instance.Update(link);
                }
                IsSaved = true;
            }
            MessageBox.Show("Lưu trữ thành công.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save();
            loadData();
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            save();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void frmDirectCost_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            TextUtils.ExportExcel(grvLink);
        }

        private void grvLink_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //if (e.Column == colNumberDay || e.Column == colPersonNumber)
            //{
            //    decimal numberDay = TextUtils.ToDecimal(grvLink.GetFocusedRowCellValue(colNumberDay));
            //    decimal personNumber = TextUtils.ToDecimal(grvLink.GetFocusedRowCellValue(colPersonNumber));
            //    decimal qty = TextUtils.ToDecimal(grvLink.GetFocusedRowCellValue(colQty));
            //    decimal pricePerDay = TextUtils.ToDecimal(grvLink.GetFocusedRowCellValue(colPricePerDay));

            //    grvLink.SetFocusedRowCellValue(colTongTien, numberDay * personNumber * pricePerDay * (1 + 0.3M * (qty - 1)));
            //}
        }

        void resetAll()
        {
            grvLink.FocusedRowHandle = -1;
            decimal totalNC = 0;
            string sql = "update C_QuotationDetail set TotalNC = 0 where C_QuotationID = " + C_QuotationID;
            LibQLSX.ExcuteSQL(sql);
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang xử lý..."))
            {
                for (int i = 0; i < grvLink.RowCount; i++)
                {
                    int id = TextUtils.ToInt(grvLink.GetRowCellValue(i, colID));
                    if (id == 0) return;

                    int costID = TextUtils.ToInt(grvLink.GetRowCellValue(i, colC_CostID));
                    int quotationDetailID = TextUtils.ToInt(grvLink.GetRowCellValue(i, colC_QuotationDetailID));
                    C_QuotationDetailModel quotationDetail = (C_QuotationDetailModel)C_QuotationDetailBO.Instance.FindByPK(quotationDetailID);
                    C_CostModel cost = (C_CostModel)C_CostBO.Instance.FindByPK(costID);

                    C_CostProductGroupLinkModel group = (C_CostProductGroupLinkModel)C_CostProductGroupLinkBO.Instance.FindByExpression(new Expression("C_CostID", cost.ID)
                        .And(new Expression("C_ProductGroupID", quotationDetail.C_ProductGroupID)))[0];

                    decimal pricePerDay = TextUtils.ToDecimal(grvLink.GetRowCellValue(i, colPricePerDay));                    
                    decimal qty = TextUtils.ToDecimal(grvLink.GetRowCellValue(i, colQty));

                    C_CostQuotationItemLinkModel link = (C_CostQuotationItemLinkModel)C_CostQuotationItemLinkBO.Instance.FindByPK(id);
                    link.PersonNumber = group.PersonNumber;// TextUtils.ToDecimal(drs[0]["PersonNumber"]);
                    if (group.IsFix == 1)
                    {
                        link.NumberDay = group.NumberDay;// TextUtils.ToDecimal(drs[0]["NumberDay"]);
                    }
                    else
                    {
                        link.NumberDay = group.VtuPercent * quotationDetail.PriceVT / cost.Price;
                    }
                    link.TotalR = link.NumberDay * link.PersonNumber;
                    if (cost.ID == 61)//phòng thiết kế
                    {
                        link.TotalR *= (1 + 0.3M * (quotationDetail.Qty - 1)) / quotationDetail.Qty;
                    }
                    link.Price = link.TotalR * cost.Price;
                    C_CostQuotationItemLinkBO.Instance.Update(link);

                    quotationDetail.TotalNC += link.Price;
                    C_QuotationDetailBO.Instance.Update(quotationDetail);
                }
                IsSaved = true;
            }
            MessageBox.Show("Reset thành công.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnResetAll_Click(object sender, EventArgs e)
        {
            resetAll();
            loadData();     
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvLink.GetFocusedRowCellValue(colID));
            if (id == 0) return;

            int costID = TextUtils.ToInt(grvLink.GetFocusedRowCellValue(colC_CostID));
            int quotationDetailID = TextUtils.ToInt(grvLink.GetFocusedRowCellValue(colC_QuotationDetailID));
            C_QuotationDetailModel quotationDetail = (C_QuotationDetailModel)C_QuotationDetailBO.Instance.FindByPK(quotationDetailID);
            C_CostModel cost = (C_CostModel)C_CostBO.Instance.FindByPK(costID);

            C_CostProductGroupLinkModel group = (C_CostProductGroupLinkModel)C_CostProductGroupLinkBO.Instance.FindByExpression(new Expression("C_CostID", cost.ID)
                .And(new Expression("C_ProductGroupID", quotationDetail.C_ProductGroupID)))[0];

            decimal pricePerDay = TextUtils.ToDecimal(grvLink.GetFocusedRowCellValue(colPricePerDay));
            decimal qty = TextUtils.ToDecimal(grvLink.GetFocusedRowCellValue(colQty));

            C_CostQuotationItemLinkModel link = (C_CostQuotationItemLinkModel)C_CostQuotationItemLinkBO.Instance.FindByPK(id);
            quotationDetail.TotalNC -= link.Price;
            link.PersonNumber = group.PersonNumber;// TextUtils.ToDecimal(drs[0]["PersonNumber"]);
            if (group.IsFix == 1)
            {
                link.NumberDay = group.NumberDay;// TextUtils.ToDecimal(drs[0]["NumberDay"]);
            }
            else
            {
                link.NumberDay = group.VtuPercent * quotationDetail.PriceVT / cost.Price;
            }
            link.TotalR = link.NumberDay * link.PersonNumber;
            if (cost.ID == 61)//phòng thiết kế
            {
                link.TotalR *= (1 + 0.3M * (quotationDetail.Qty - 1)) / quotationDetail.Qty;
            }
            link.Price = link.TotalR * cost.Price;
            C_CostQuotationItemLinkBO.Instance.Update(link);

            quotationDetail.TotalNC += link.Price;
            C_QuotationDetailBO.Instance.Update(quotationDetail);
            loadData();
            MessageBox.Show("Reset thành công.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
