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

namespace BMS
{
    public partial class frmChiPhiNhanCong : _Forms
    {
        public int C_QuotationID = 0;
        public bool IsSaved = false;
        public frmChiPhiNhanCong()
        {
            InitializeComponent();
        }

        private void frmChiPhiNhanCong_Load(object sender, EventArgs e)
        {
            loadNCType();
            InsertLink();
            loadData();
        }

        void loadNCType()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("NCType");
            dt.Rows.Add("A");
            dt.Rows.Add("B");
            dt.Rows.Add("C");

            repositoryItemSearchLookUpEdit1.DataSource = dt;
            repositoryItemSearchLookUpEdit1.DisplayMember = "NCType";
            repositoryItemSearchLookUpEdit1.ValueMember = "NCType";
        }

        void InsertLink()
        {
            DataTable dtItem = LibQLSX.Select("select * from C_QuotationDetail_SX where C_QuotationID = " + C_QuotationID);
            foreach (DataRow item in dtItem.Rows)
            {
                int groupID = TextUtils.ToInt(item["C_ProductGroupID"]);
                int id = TextUtils.ToInt(item["ID"]);
                
                //if (groupID == 0)
                //{
                //    C_QuotationDetail_SXModel model = (C_QuotationDetail_SXModel)C_QuotationDetail_SXBO.Instance.FindByPK(id);
                //    C_CostQuotationItemLinkBO.Instance.DeleteByAttribute("C_QuotationDetail_SXID", id);
                //    model.TotalNC = 0;
                //    C_QuotationDetail_SXBO.Instance.Update(model);
                //}
                //else
                if (groupID > 0)
                {
                    string sql = "insert into [C_CostQuotationItemLinkNew] ([C_CostID],[C_QuotationDetail_SXID],[Price],[PersonNumber],[NumberDay],[TotalR],[IsDirect],[CostNCType])"
                                + " select ID ," + id + " as [C_QuotationDetail_SXID], 0 as b, 0 as c, 0 as d, 0 as e, 1 as f, 'C' as g"
                                + " from [C_Cost] m where m.IsDirectCost = 1 and ((select COUNT(ID) from [C_CostQuotationItemLinkNew] where [C_CostID] = m.ID and  [C_QuotationDetail_SXID] = " + id + ") = 0)";
                    LibQLSX.ExcuteSQL(sql);
                }
            }
        }

        void loadData()
        {
            DataTable dt = LibQLSX.Select("select *,TongTien = Price*Qty from vC_CostQuotationItemLinkSX where IsDirect = 1 and C_QuotationID = " + C_QuotationID);
            grdLink.DataSource = dt;
            DataRow[] drs = dt.Select("C_ProductGroupID = 9");
            colNCType.OptionsColumn.AllowEdit = (drs.Length > 0);
        }

        void save()
        {
            //grvLink.ClearColumnsFilter(); * (1 + 0.3M * (item.Qty >= 2 ? item.Qty - 1 : 0)) / item.Qty colC_QuotationDetailID
            grvLink.ExpandAllGroups();
            grvLink.FocusedRowHandle = -1;
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang xử lý..."))
            {
                for (int i = 0; i < grvLink.RowCount; i++)
                {
                    int id = TextUtils.ToInt(grvLink.GetRowCellValue(i, colID));
                    if (id == 0) return;
                    decimal pricePerDay = TextUtils.ToDecimal(grvLink.GetRowCellValue(i, colPricePerDay));

                    C_CostQuotationItemLinkNewModel link = (C_CostQuotationItemLinkNewModel)C_CostQuotationItemLinkNewBO.Instance.FindByPK(id);
                    link.NumberDay = TextUtils.ToDecimal(grvLink.GetRowCellValue(i, colNumberDay));
                    link.PersonNumber = TextUtils.ToDecimal(grvLink.GetRowCellValue(i, colPersonNumber));
                    link.TotalR = link.NumberDay * link.PersonNumber;
                    link.Price = link.TotalR * pricePerDay;
                    link.IsDirect = 1;
                    link.CostNCType = TextUtils.ToString(grvLink.GetRowCellValue(i, colNCType));
                    C_CostQuotationItemLinkNewBO.Instance.Update(link);
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
            //this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void frmDirectCost_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (IsSaved)
                DialogResult = DialogResult.OK;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            TextUtils.ExportExcel(grvLink);
        }

        private void btnResetAll_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void grvLink_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colNumberDay || e.Column == colPersonNumber || e.Column == colNCType)
            {
                decimal numberDay = TextUtils.ToDecimal(grvLink.GetFocusedRowCellValue(colNumberDay));
                decimal personNumber = TextUtils.ToDecimal(grvLink.GetFocusedRowCellValue(colPersonNumber));
                decimal qty = TextUtils.ToDecimal(grvLink.GetFocusedRowCellValue(colQty));
                decimal pricePerDay = 0;// TextUtils.ToDecimal(grvLink.GetFocusedRowCellValue(colPricePerDay));
                
                if (e.Column == colNCType)
                {
                    string ncType = TextUtils.ToString(grvLink.GetFocusedRowCellValue(colNCType));
                    int costID = TextUtils.ToInt(grvLink.GetFocusedRowCellValue(colC_CostID));
                    string sql = "select Price from C_CostNCType where C_CostID = " + costID + " and CostNCType = '" + ncType + "'";

                    pricePerDay = TextUtils.ToDecimal(LibQLSX.ExcuteScalar(sql));                    
                }
                else
                {
                    pricePerDay = TextUtils.ToDecimal(grvLink.GetFocusedRowCellValue(colPricePerDay));
                }

                grvLink.SetFocusedRowCellValue(colPricePerDay, pricePerDay);

                decimal price = numberDay * personNumber * pricePerDay;

                grvLink.SetFocusedRowCellValue(colPrice, price);
                grvLink.SetFocusedRowCellValue(colTongTien, qty * price);
            }
        }
    }
}
