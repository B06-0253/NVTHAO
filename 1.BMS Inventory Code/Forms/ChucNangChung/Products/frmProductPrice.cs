using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Model;
using DevExpress.Utils;
using BMS.Business;
using DevExpress.XtraGrid.Localization;
using BMS.Utils;

namespace BMS
{
    public partial class frmProductPrice : _Forms
    {
        public ProductsModel Product = new ProductsModel();
        bool _isSaved = false;
        
        public frmProductPrice()
        {
            InitializeComponent();
        }

        private void frmProductPrice_Load(object sender, EventArgs e)
        {
            GridLocalizer.Active = new MyGridLocalizer();
            DocUtils.InitFTPQLSX();
            this.Text = "Giá sản phẩm: " + Product.Code + " - " + Product.Name;
            loadCostGroup();
            if (Product.ID > 0)
            {
                CostGroupModel costGroup = (CostGroupModel)CostGroupBO.Instance.FindByPK(Product.CostGroupID);
                if (costGroup != null)
                {
                    lblTradePercent.Text = costGroup.PercentTrade.ToString() + "%";
                    lblUserPercent.Text = costGroup.PercentUser.ToString() + "%";
                    lblVAT.Text = costGroup.VAT.ToString() + "%";
                }    
            }
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load giá..."))
            {
                loadGrid();
            }
        }

        void loadGrid()
        {
            DataTable dtBaiThucHanhLink = TextUtils.Select("Select * from vProductBaiThucHanhLink where ProductID = " + Product.ID);
            List<string> listBthID = new List<string>();
            foreach (DataRow item in dtBaiThucHanhLink.Rows)
            {
                string id = item["BaiThucHanhID"].ToString();
                if (!listBthID.Contains(id))
                {
                    listBthID.Add(id);
                }
            }
            string ids = string.Join(",", listBthID.ToArray());

            DataTable dt = TextUtils.Select("Select *,0 as Price,0 as TotalPrice,0 as PriceType from vBaiThucHanhModule where [BaiThucHanhID] in (" + ids + ")");
            foreach (DataRow row in dt.Rows)
            {
                string code = row["Code"].ToString();
                try
                {
                    if (code.StartsWith("TPAD."))
                    {
                        DataTable dtPrice = TextUtils.LoadModulePriceTPAD(code,false);
                        row["Price"] = TextUtils.ToInt(dtPrice.Compute("Sum(TotalPrice)", ""));
                        row["TotalPrice"] = TextUtils.ToInt(row["Qty"]) * TextUtils.ToInt(row["Price"]);
                        row["PriceType"] = TextUtils.ToInt(dtPrice.Rows[0]["PriceType"]);
                    }
                    else
                    {
                        string sql = "select top 1 Price from [Parts] with(nolock) where Replace(PartsCode,' ','') = '" + code.Replace(" ", "") + "'";
                        DataTable dtPrice = LibQLSX.Select(sql);
                        row["Price"] = TextUtils.ToInt(dtPrice.Rows[0][0]);
                        row["TotalPrice"] = TextUtils.ToInt(row["Qty"]) * TextUtils.ToInt(row["Price"]);
                        row["PriceType"] = 1;
                    }
                }
                catch (Exception)
                {
                }
            }
            grdModule.DataSource = dt;
        }

        void loadCostGroup()
        {
            DataTable tbl = TextUtils.Select(@"SELECT *,Code+'-'+Name as Name1 FROM CostGroup WITH(NOLOCK) ORDER BY Code");
            if (tbl == null)
            {
                return;
            }

            DataRow dr = tbl.NewRow();
            dr["ID"] = 0;
            dr["Name1"] = "Tất cả";
            tbl.Rows.InsertAt(dr, 0);

            cboCostGroup.Properties.DataSource = tbl.Copy();
            cboCostGroup.Properties.DisplayMember = "Name1";
            cboCostGroup.Properties.ValueMember = "ID";
        }

        void loadCost(int costGroupID)
        {
            DataTable dt = TextUtils.Select("Select *,(CostPercent * " + TextUtils.ToDecimal(txtPrice.Text) + " / 100) as Total from vCostLink where CostGroupID = " + costGroupID);
            grdCost.DataSource = dt;
            grvCost.Columns["Total"].SummaryItem.DisplayFormat = "{0:n2}";
            var a = grvCost.Columns["Total"].SummaryItem.SummaryValue;
            decimal priceSX = TextUtils.ToDecimal(txtPrice.Text) + TextUtils.ToDecimal(a);

            txtRealPrice.Text = priceSX.ToString("n2");
            txtTradePrice.Text = (priceSX + (priceSX * TextUtils.ToDecimal(lblTradePercent.Text.Substring(0, lblTradePercent.Text.Length - 1)) / 100)).ToString("n2");
            txtUserPrice.Text = (priceSX + (priceSX * TextUtils.ToDecimal(lblUserPercent.Text.Substring(0, lblUserPercent.Text.Length - 1)) / 100)).ToString("n2");
            txtVAT.Text = ((priceSX * TextUtils.ToDecimal(lblVAT.Text.Substring(0, lblVAT.Text.Length - 1)) / 100)).ToString("n2");
        }

        bool ValidateForm()
        {
            //DataTable dt = (DataTable)grdData.DataSource;
            //DataRow[] drs = dt.Select("Price = 0");
            //if (grvData.RowCount == 0)
            //{
            //    MessageBox.Show("Module không có danh mục vật tư.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return false;
            //}

            //if (drs.Count() > 0)
            //{
            //    MessageBox.Show("Vẫn tồn tại giá vật tư bằng 0.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return false;
            //}

            //if (txtPrice.Text.Trim() == "")
            //{
            //    MessageBox.Show("Xin hãy điền giá gốc.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return false;
            //}

            if (TextUtils.ToInt(cboCostGroup.EditValue) == 0)
            {
                MessageBox.Show("Xin hãy chọn nhóm chi phí.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return true;
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

                Product.CostGroupID = TextUtils.ToInt(cboCostGroup.EditValue);
                
                pt.Update(Product);

                pt.CommitTransaction();
                _isSaved = true;

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
                MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                pt.CloseConnection();
            }
            if (_isSaved && close)
            {
                this.Close();
            }
        }

        private void grvModule_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            int priceType = TextUtils.ToInt(grvModule.GetRowCellValue(e.RowHandle, colPriceType));
            if (priceType == 0)
            {
                if (e.Column == colTotalPrice)
                {
                    e.Appearance.BackColor = Color.Yellow;
                }
            }
            txtPrice.Text = colTotalPrice.SummaryItem.SummaryValue.ToString();
        }

        private void xemChiTiếtGiáModuleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string moduleCode = grvModule.GetFocusedRowCellValue(colMCode).ToString();
            if (moduleCode.StartsWith("TPAD."))
            {
                ModulesModel model = (ModulesModel)ModulesBO.Instance.FindByAttribute("Code", moduleCode)[0];

                frmModulePrice frm = new frmModulePrice();              
                frm.Module = model;
                TextUtils.OpenForm(frm);
            }
        }

        private void cboCostGroup_EditValueChanged(object sender, EventArgs e)
        {
            lblTradePercent.Text = TextUtils.ToDecimal(grvCostGroup.GetFocusedRowCellValue(colPercentTrade)) == 0 ? "0%" : grvCostGroup.GetFocusedRowCellValue(colPercentTrade).ToString() + "%";
            lblUserPercent.Text = TextUtils.ToDecimal(grvCostGroup.GetFocusedRowCellValue(colPercentUser)) == 0 ? "0%" : grvCostGroup.GetFocusedRowCellValue(colPercentUser).ToString() + "%";
            lblVAT.Text = TextUtils.ToDecimal(grvCostGroup.GetFocusedRowCellValue(colVAT)) == 0 ? "0%" : grvCostGroup.GetFocusedRowCellValue(colVAT).ToString() + "%";

            loadCost(TextUtils.ToInt(cboCostGroup.EditValue));
        }

        private void txtPrice_EditValueChanged(object sender, EventArgs e)
        {
            loadCost(TextUtils.ToInt(cboCostGroup.EditValue));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save(false);
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            save(true);
        }
    }
}
