using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Model;
using BMS.Business;
using BMS.Utils;
using DevExpress.XtraGrid.Localization;
using System.IO;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;

namespace BMS
{
    public partial class frmModulePrice : _Forms
    {
        public ModulesModel Module = new ModulesModel();
        public string ProductCode;
        bool _isSaved = false;

        public frmModulePrice()
        {
            InitializeComponent();
        }

        private void frmModulePrice_Load(object sender, EventArgs e)
        {
            GridLocalizer.Active = new MyGridLocalizer();
            //loadCostGroup();
            ProductCode = Module.Code;
            this.Text += ": " + Module.Code;

            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load giá vật tư..."))
            {
                if (Module.Code.StartsWith("TPAD"))
                {
                    grdData.DataSource = TextUtils.LoadModulePriceTPAD(Module.Code, true);
                }
                else
                {
                    grdData.DataSource = TextUtils.LoadModulePricePCB(Module.Code);
                }
            }

            txtTotal.EditValue = TextUtils.ToDecimal(colMaTotalPrice.SummaryItem.SummaryValue);
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
            DataTable dtSX = TextUtils.Select("Select *,(CostPercent * " + TextUtils.ToDecimal(txtPrice.Text) + " / 100) as Total from vCostLink where Type = 0 and CostGroupID = " + costGroupID);
            grdCost.DataSource = dtSX;
            grvCost.Columns["Total"].SummaryItem.DisplayFormat = "{0:n2}";
            var chiPhiSX = grvCost.Columns["Total"].SummaryItem.SummaryValue;
            decimal priceSX = TextUtils.ToDecimal(txtPrice.Text) + TextUtils.ToDecimal(chiPhiSX);
            txtSXPrice.Text = priceSX.ToString("n2"); 

            DataTable dtTM = TextUtils.Select("Select *,(CostPercent * " + TextUtils.ToDecimal(txtSXPrice.Text) + " / 100) as Total from vCostLink where Type = 1 and CostGroupID = " + costGroupID);
            grdCostTM.DataSource = dtTM;
            grvCostTM.Columns["Total"].SummaryItem.DisplayFormat = "{0:n2}";
            var chiPhiTM = grvCostTM.Columns["Total"].SummaryItem.SummaryValue;
            txtTradePrice.Text = (TextUtils.ToDecimal(txtSXPrice.Text) + TextUtils.ToDecimal(chiPhiTM)).ToString("n2");
            
            //txtTradePrice.Text = (priceSX + (priceSX * TextUtils.ToDecimal(lblTradePercent.Text.Substring(0, lblTradePercent.Text.Length - 1)) / 100)).ToString("n2");
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

                Module.CostGroupID = TextUtils.ToInt(cboCostGroup.EditValue);

                Module.Price = TextUtils.ToDecimal(txtPrice.Text.Trim());
                //Module.RealPrice = TextUtils.ToDecimal(txtRealPrice.Text.Trim());
                Module.TradePrice = TextUtils.ToDecimal(txtTradePrice.Text.Trim());
                Module.UserPrice = TextUtils.ToDecimal(txtUserPrice.Text.Trim());
                Module.VAT = TextUtils.ToDecimal(txtVAT.Text.Trim());

                if (Module.ID == 0)
                {
                    Module.ID = (int)pt.Insert(Module);
                }
                else
                {
                    pt.Update(Module);
                }

                #region Material Detail
                //for (int i = 0; i < grvData.RowCount; i++)
                //{
                //    try
                //    {
                //        ModuleMaterialPriceModel price = new ModuleMaterialPriceModel();
                //        int id = TextUtils.ToInt(grvData.GetRowCellValue(i, colMaID));
                //        if (id > 0)
                //        {
                //            price = (ModuleMaterialPriceModel)ModuleMaterialPriceBO.Instance.FindByPK(id);
                //        }
                //        price.Hang = grvData.GetRowCellValue(i, colMaHang).ToString();
                //        price.MaterialCode = grvData.GetRowCellValue(i, colMaCode).ToString();
                //        price.MaterialName = grvData.GetRowCellValue(i, colMaName).ToString();
                //        price.ModuleCode = Module.Code;
                //        price.Price = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colMaPrice));
                //        price.Qty = TextUtils.ToInt(grvData.GetRowCellValue(i, colMaQty));
                //        price.TotalPrice = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colMaTotalPrice));
                //        price.Type = TextUtils.ToInt(grvData.GetRowCellValue(i, colMaType));
                //        price.TypeName = grvData.GetRowCellValue(i, colMaTypeName).ToString();
                //        if (id == 0)
                //        {
                //            pt.Insert(price);
                //        }
                //        else
                //        {
                //            pt.Update(price);
                //        }
                //    }
                //    catch (Exception)
                //    {
                        
                //    }                    
                //}
                #endregion

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
        }

        private void txtPrice_EditValueChanged(object sender, EventArgs e)
        {
            //loadCost(TextUtils.ToInt(cboCostGroup.EditValue));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save(false);
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            save(true);
        }

        private void frmModulePrice_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_isSaved)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void cboCostGroup_EditValueChanged(object sender, EventArgs e)
        {
            lblTradePercent.Text = TextUtils.ToDecimal(grvCostGroup.GetFocusedRowCellValue(colPercentTrade)) == 0 ? "0%" : grvCostGroup.GetFocusedRowCellValue(colPercentTrade).ToString() + "%";
            lblUserPercent.Text = TextUtils.ToDecimal(grvCostGroup.GetFocusedRowCellValue(colPercentUser)) == 0 ? "0%" : grvCostGroup.GetFocusedRowCellValue(colPercentUser).ToString() + "%";
            lblVAT.Text = TextUtils.ToDecimal(grvCostGroup.GetFocusedRowCellValue(colVAT)) == 0 ? "0%" : grvCostGroup.GetFocusedRowCellValue(colVAT).ToString() + "%";

            //loadCost(TextUtils.ToInt(cboCostGroup.EditValue));
        }

        private void grvData_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colMaPrice)
            {
                int qty = TextUtils.ToInt(grvData.GetRowCellValue(e.RowHandle, colMaQty));
                int price = TextUtils.ToInt(grvData.GetRowCellValue(e.RowHandle, colMaPrice));
                grvData.SetRowCellValue(e.RowHandle, colMaTotalPrice, qty * price);
                if (grvData.FocusedRowHandle != grvData.RowCount - 1)
                {
                    grvData.FocusedRowHandle++;
                }
                else
                {
                    grvData.FocusedRowHandle--;
                }
                txtPrice.Text = colMaTotalPrice.SummaryItem.SummaryValue.ToString();
                txtTotal.EditValue = TextUtils.ToDecimal(colMaTotalPrice.SummaryItem.SummaryValue);
            }
        }

        private void btnExecl_Click(object sender, EventArgs e)
        {
            //grvData.ShowPrintPreview();  
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                TextUtils.ExportExcel(grvData, fbd.SelectedPath, Module.Code, true);
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

        string exportPath = "";
        private void grvData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.S))
            {
                if (MessageBox.Show("Bạn có muốn xuất dữ liệu ra file excel?",TextUtils.Caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    if (exportPath != "")
                    {
                        TextUtils.ExportExcel(grvData, exportPath, Module.Code, false);
                    }
                    else
                    {
                        FolderBrowserDialog fbd = new FolderBrowserDialog();
                        if (fbd.ShowDialog() == DialogResult.OK)
                        {
                            exportPath = fbd.SelectedPath;
                            TextUtils.ExportExcel(grvData, fbd.SelectedPath, Module.Code, false);
                        }
                    }
                }               
            }

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

        private void xemGiáToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string code = TextUtils.ToString(grvData.GetFocusedRowCellValue(colMaCode));
            if (code.StartsWith("PCB.") || (code.StartsWith("TPAD.") && code.Length == 10))
            {
                ModulesModel model = (ModulesModel)ModulesBO.Instance.FindByCode(code);
                if (model.Status != 2)
                {
                    MessageBox.Show("Module chưa có trên nguồn chuẩn!");
                    return;
                }
                frmModulePrice frm = new frmModulePrice();
                frm.Module = model;
                frm.Show();
            }            
        }

        private void grvData_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                decimal price = TextUtils.ToDecimal(grvData.GetRowCellValue(e.RowHandle, colMaTotalPrice));
                if (price == 0)
                {
                    e.Appearance.BackColor = Color.Yellow;
                }
            }
            //txtPriceVT.Text = colMaTotalPrice.SummaryItem.SummaryValue.ToString();
            txtPrice.Text = colMaTotalPrice.SummaryItem.SummaryValue.ToString();
        }
    }
}
