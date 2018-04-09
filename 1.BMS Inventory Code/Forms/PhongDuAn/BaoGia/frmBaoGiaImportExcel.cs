using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BMS
{
    public partial class frmBaoGiaImportExcel : _Forms
    {
        public DataTable DtData = new DataTable();
        public string ProductCode;
        public string ProductName;

        public delegate void LoadDataChangeHandler(object sender, EventArgs e);
        public event LoadDataChangeHandler LoadDataChange;

        public frmBaoGiaImportExcel()
        {
            InitializeComponent();
        }

        private void frmBaoGiaImportExcel_Load(object sender, EventArgs e)
        {
            this.Text += " " + ProductCode + " - " + ProductName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grvData.RowCount; i++)
            {
                string moduleCode = TextUtils.ToString(grvData.GetRowCellValue(i, "Code"));
                string moduleName = TextUtils.ToString(grvData.GetRowCellValue(i, "Name"));
                if (moduleCode == "") continue;
                string productCode = ProductCode;
                DataRow[] drs = DtData.Select("ModuleCode = '" + moduleCode + "' and ProductCode = '" + productCode + "'");
                if (drs.Length > 0) continue;

                DataRow dr = DtData.NewRow();
                dr["ModuleCode"] = moduleCode;
                dr["ModuleName"] = moduleName;
                //dr["ModuleCodeHD"] = txtModuleCode.Text.Trim().ToUpper();
                //dr["ModuleNameHD"] = txtModuleName.Text.Trim().ToUpper();
                dr["PriceType"] = "SX";
                dr["VAT"] = 5m;
                dr["Qty"] = 1m;
                //dr["PriceVT"] = TextUtils.ToDecimal(txtPriceVT.Text.Trim());
                //dr["PriceDT"] = TextUtils.ToDecimal(txtPriceVT.Text.Trim());
                //dr["TotalVT"] = 1 * TextUtils.ToDecimal(txtPriceVT.Text.Trim());
                //dr["PriceTPA"] = TextUtils.ToDecimal(txtPriceTPA.Text.Trim());
                //dr["TotalTPA"] = 1 * TextUtils.ToDecimal(txtPriceTPA.Text.Trim());
                dr["Product"] = ProductCode + "-" + ProductName;
                dr["ProductCode"] = ProductCode;
                dr["ProductName"] = ProductName;
                dr["CostGroupID"] = 0;
                DtData.Rows.Add(dr);
            }
        }

        private void grdData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                grdData.DataSource = null;

                string[] cb = Clipboard.GetText(TextDataFormat.UnicodeText).Split(new string[1] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                cb[0] = cb[0];
                string[] ColHeaders = cb[0].Split('\t');

                DataTable dTab = new DataTable();
                int colIndex = 1;

                for (int i = 0; i < ColHeaders.Length; i++)
                {
                    if (i == 0)
                    {
                        dTab.Columns.Add("Code", Type.GetType("System.String"));
                        dTab.Columns[0].Caption = "Mã module";
                    }
                    else if (i == 1)
                    {
                        dTab.Columns.Add("Name", Type.GetType("System.String"));
                        dTab.Columns[1].Caption = "Têm module";
                    }
                    else
                    {
                        dTab.Columns.Add("T" + colIndex, Type.GetType("System.String"));
                        colIndex++;
                    }                   
                }

                DataRow dr = null;
                for (int r = 0; r < cb.Length; r++)
                {
                    if (cb[r].Trim().Length > 0)
                    {
                        dr = dTab.NewRow();
                        string[] row = Convert.ToString(cb[r]).Split('\t');

                        for (int c = 0; c < ColHeaders.Length; c++)
                        {
                            dr[c] = row[c];
                        }

                        dTab.Rows.Add(dr);
                    }
                }

                grdData.DataSource = dTab;
                grvData.BestFitColumns();
            }
        }
    }
}
