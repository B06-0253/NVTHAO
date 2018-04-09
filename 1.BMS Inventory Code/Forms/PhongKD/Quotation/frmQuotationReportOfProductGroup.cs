using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPA.Business;
using TPA.Model;

namespace BMS
{
    public partial class frmQuotationReportOfProductGroup : _Forms
    {
        //public C_QuotationModel thisQuotation = new C_QuotationModel();
        public frmQuotationReportOfProductGroup()
        {
            InitializeComponent();
        }
        
        private void frmQuotationReportOfProductGroup_Load(object sender, EventArgs e)
        {
            loadCombo();
            loadCost();
        }

        void loadCombo()
        {
            DataTable dt = LibQLSX.Select("select * from C_Quotation with(nolock)");
            cboBaoGia.Properties.DataSource = dt;
            cboBaoGia.Properties.DisplayMember = "Code";
            cboBaoGia.Properties.ValueMember = "ID";

            cboBaoGia1.Properties.DataSource = dt;
            cboBaoGia1.Properties.DisplayMember = "Code";
            cboBaoGia1.Properties.ValueMember = "ID";
        }       

        void loadCost()
        {
            DataTable dt = LibQLSX.Select("select * from C_Cost with(nolock) where ID >= 60 and ID <= 73");
            cboCost.Properties.DataSource = dt;
            cboCost.Properties.DisplayMember = "Name";
            cboCost.Properties.ValueMember = "ID";
        }

        private void cboProject_EditValueChanged(object sender, EventArgs e)
        {
            int quotationID = TextUtils.ToInt(cboBaoGia.EditValue);
            //if (quotationID == 0) return;

            C_QuotationModel thisQuotation = (C_QuotationModel)C_QuotationBO.Instance.FindByPK(quotationID);

            string[] paraName = new string[1];
            object[] paraValue = new object[1];
            paraName[0] = "@QuotationID"; paraValue[0] = quotationID;

            DataTable dtQuotation = C_CostBO.Instance.LoadDataFromSP("spReportQuotation", "Source", paraName, paraValue);
            if (dtQuotation.Rows.Count > 0)
            {
                thisQuotation.TotalHD = TextUtils.ToDecimal(dtQuotation.Rows[0]["TotalHD"]);
            }

            DataTable dt = LibQLSX.Select("spReportQuotationWithProductGroup " + quotationID);

            DataColumn colTotalCustomer = new DataColumn();
            colTotalCustomer.DataType = System.Type.GetType("System.Decimal");
            colTotalCustomer.ColumnName = "TotalCustomer";
            colTotalCustomer.Expression = thisQuotation.TotalCustomer + " * TotalHD / " + thisQuotation.TotalHD;
            dt.Columns.Add(colTotalCustomer);

            DataColumn colCustomerValue = new DataColumn();
            colCustomerValue.DataType = System.Type.GetType("System.Decimal");
            colCustomerValue.ColumnName = "CustomerValue";
            colCustomerValue.Expression = "TotalHD * " + (thisQuotation.CustomerPercent / 100) + " + TotalHD / " + thisQuotation.TotalHD + " * " + thisQuotation.CustomerCash;
            dt.Columns.Add(colCustomerValue);

            DataColumn colTotalReal = new DataColumn();
            colTotalReal.DataType = System.Type.GetType("System.Decimal");
            colTotalReal.ColumnName = "TotalReal";
            colTotalReal.Expression = "TotalHD - CustomerValue";
            dt.Columns.Add(colTotalReal);

            DataColumn colTotalBX = new DataColumn();
            colTotalBX.DataType = System.Type.GetType("System.Decimal");
            colTotalBX.ColumnName = "TotalBX";
            colTotalBX.Expression = "CustomerValue * 0.15";
            dt.Columns.Add(colTotalBX);

            DataColumn colTotalProfit = new DataColumn();
            colTotalProfit.DataType = System.Type.GetType("System.Decimal");
            colTotalProfit.ColumnName = "TotalProfit";
            colTotalProfit.Expression = "TotalReal - TotalVAT - TotalCustomer - TotalNC - TotalVT - TotalPB - TotalBX";
            dt.Columns.Add(colTotalProfit);            

            grdData.DataSource = dt;
        }

        private void grvData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == (Keys.C))
            {
                try
                {
                    string text = TextUtils.ToString(grvData.GetFocusedRowCellValue(grvData.FocusedColumn));
                    Clipboard.SetText(text);
                }
                catch (Exception)
                {
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog()== DialogResult.OK)
            {
                grvData.ExportToXls(fbd.SelectedPath + "\\BaoCaoTheoNghangHang-" + grvCboBaoGia.GetFocusedRowCellValue(colQuotationProjectCode) + ".xls");
            }            
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            int quotationID = TextUtils.ToInt(cboBaoGia1.EditValue);
            int costID = TextUtils.ToInt(cboCost.EditValue);

            DataTable dt = LibQLSX.Select("spReportQuotationWithProductGroup_PhongBan " + quotationID + "," + costID);

            grdNC.DataSource = dt;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                grvNC.ExportToXls(fbd.SelectedPath + "\\ReportNC-" + grvCboBaoGia1.GetFocusedRowCellValue(colQuotationProjectCode) + "-"
                    + grvCboCost.GetFocusedRowCellValue(colCostName) + ".xls");
            }   
        }
    }
}
