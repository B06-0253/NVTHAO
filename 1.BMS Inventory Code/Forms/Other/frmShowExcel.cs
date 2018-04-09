using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Business;
using BMS.Model;
using BMS.Utils;
using System.Collections;
using TPA.Business;
using TPA.Model;
using TPA.Utils;


namespace BMS
{
    public partial class frmShowExcel : _Forms
    {
        public frmShowExcel()
        {
            InitializeComponent();
        }

        void CreateProduct()
        {
            for (int i = 0; i < grvData.RowCount; i++)
            {
                try
                {
                    string code = grvData.GetRowCellValue(i, "F2").ToString();
                    if (code == "") continue;

                    DataTable dt = TextUtils.Select("select * from Products with(nolock) where Code = '" + code + "'");
                    if (dt.Rows.Count > 0) continue;

                    string groupCode = code.Split('.')[0];
                    ProductGroupModel group = (ProductGroupModel)ProductGroupBO.Instance.FindByAttribute("Code", groupCode)[0];
                    string name = grvData.GetRowCellValue(i, "F1").ToString();

                    ProductsModel product = new ProductsModel();
                    product.ProductGroupID = group.ID;
                    product.Code = code;
                    product.Name = name;
                    ProductsBO.Instance.Insert(product);
                }
                catch (Exception ex)
                {
                    TextUtils.ShowError(ex);
                }                
            }
        }

        //Tao vat tu phi tieu chuan
        void CreateVTN()
        {
            for (int i = 0; i < grvData.RowCount; i++)
            {
                try
                {
                    string code = grvData.GetRowCellValue(i, "F3").ToString();                    
                    if (code == "") continue;
                    ArrayList list = MaterialNSBO.Instance.FindByAttribute("Code", code.Replace(" ", ""));
                    if (list.Count > 0) continue;

                    string name = grvData.GetRowCellValue(i, "F2").ToString();
                    string customerCode = grvData.GetRowCellValue(i, "F4").ToString();

                    DataTable dtCustomer = TextUtils.Select("select top 1 * from Customer with(nolock) where Code = N'" + customerCode.Trim() + "'");
                    if (dtCustomer.Rows.Count == 0)
                    {
                        string a = customerCode;
                        continue;
                    }

                    MaterialNSModel material = new MaterialNSModel();
                    material.CustomerID = TextUtils.ToInt(dtCustomer.Rows[0]["ID"]);
                    material.Code = code.Replace(" ","");
                    material.Name = name;
                    material.ParentID = 0;
                    material.Type = cboSheet.SelectedIndex;
                    MaterialNSBO.Instance.Insert(material);
                }
                catch (Exception ex)
                {
                    TextUtils.ShowError(ex);
                }
            }
        }

        void updateSuppliers()
        {
            for (int i = 0; i < grvData.RowCount; i++)
            {
                try
                {
                    string code = TextUtils.ToString(grvData.GetRowCellValue(i, "F2")).Trim();
                    if (code == "") continue;
                    ArrayList list = TPA.Business.SuppliersBO.Instance.FindByAttribute("SupplierCode", code.Replace(" ", ""));
                    if (list == null) continue;
                    if (list.Count == 0) continue;
                    string office = TextUtils.ToString(grvData.GetRowCellValue(i, "F4")).Trim();
                    string mst = TextUtils.ToString(grvData.GetRowCellValue(i, "F5")).Trim();
                    string bankName = TextUtils.ToString(grvData.GetRowCellValue(i, "F11")).Trim();
                    string bankAcount = TextUtils.ToString(grvData.GetRowCellValue(i, "F9")).Trim();

                    TPA.Model.SuppliersModel supplier = (TPA.Model.SuppliersModel)list[0];
                    supplier.Address = office;
                    supplier.Office = office;
                    supplier.MST = mst;
                    supplier.BankName = bankName;
                    supplier.BankAcount = TextUtils.ToDecimal(bankAcount) == 0 ? bankAcount : Math.Round(TextUtils.ToDecimal(bankAcount), 0).ToString();
                    supplier.PaymentTerm = TextUtils.ToString(grvData.GetRowCellValue(i, "F12")).Trim();
                    TPA.Business.SuppliersBO.Instance.UpdateQLSX(supplier);
                }
                catch (Exception ex)
                {
                    TextUtils.ShowError(ex);
                }
            }
        }

        string getNCC_ID()
        {
            try
            {
                DataTable dt = LibQLSX.Select(" SELECT top 1 SupplierId ,SupplierCode FROM Suppliers order by SupplierId desc");
                string id = dt.Rows[0]["SupplierId"].ToString();
                string code = dt.Rows[0]["SupplierCode"].ToString();

                id = id.Substring(1, id.Length - 1);
                code = code.Substring(3, code.Length - 3);

                id = "S" + string.Format("{0:000000000}", TextUtils.ToInt(id) + 1);                
                return id;
            }
            catch (Exception)
            {
                return "";
            }
            
        }

        void CreateNCC()
        {
            for (int i = 0; i < grvData.RowCount; i++)
            {
                try
                {
                    string code = grvData.GetRowCellValue(i, "F2").ToString();
                    string name = grvData.GetRowCellValue(i, "F3").ToString();    

                    if (code == "") continue;
                   
                    DataTable dtSuppliers = LibQLSX.Select("select top 1 * from Suppliers with(nolock) where SupplierCode = N'" + code.Trim() + "'");
                    if (dtSuppliers.Rows.Count > 0)
                    {
                        continue;
                    }

                    SuppliersModel ncc = new SuppliersModel();                    
                    ncc.SupplierCode = code.Trim();
                    ncc.SupplierName = name;
                    ncc.SupplierId = getNCC_ID();
                    ncc.SupplierERPId = ncc.SupplierId;
                    ncc.DateArising = DateTime.Now;
                    ncc.NhanTinStatus = 2;
                    ncc.StatusDisable = 0;
                    SuppliersBO.Instance.InsertQLSX(ncc);
                }
                catch (Exception ex)
                {
                    TextUtils.ShowError(ex);
                }
            }
        }

        void loadData() 
        {
            string sql = "select *,DATEDIFF(day, DateAboutE, DateCreate) as ChenhLech  from vImportMaterial a with(nolock) where Year(DateCreate) = 2016 and OrderCode is not null order by OrderCode";
            //string sql = "select *,DATEDIFF(day, DateCreate, DateCreateOrder) as ChenhLech from [dbo].[vRequirePartFull_Order] where DateAboutE is not null and ProposalCode is not null and year(DateCreate) = 2016";
            //string sql = "select * from vImportMaterial a with(nolock) where Year(DateCreate) = 2016 and (a.TotalNG = 0) AND (a.Status >= 3) ";

            //string sql = "select * from vImportMaterial a with(nolock) where Year(DateCreate) = 2016 and (a.Status >= 3) ";

            DataTable dt = LibQLSX.Select(sql);
            grdData.DataSource = dt;
            grvData.BestFitColumns();
        }

        void getHangVT()
        {
            DataTable dtPart = LibQLSX.Select("select * from vParts");
            for (int i = 0; i < grvData.RowCount; i++)
            {
                string part = TextUtils.ToString(grvData.GetRowCellValue(i, "F4"));
                DataRow[] drs = dtPart.Select("PartsCode = '" + part.Trim() + "'");
                if (drs.Length > 0)
                    grvData.SetRowCellValue(i, "F10", TextUtils.ToString(drs[0]["ManufacturerCode"]));
            }
        }

        void updateCostProductLink()
        {
            for (int i = 0; i < grvData.RowCount; i++)
            {
                //int costID = TextUtils.ToInt(grvData.GetRowCellValue(i, "F2"));
                //if (costID == 0) continue;
                //for (int j = 1; j < 14; j++)
                //{
                //    decimal value = TextUtils.ToDecimal(grvData.GetRowCellValue(i, "F" + (2 + j)));
                //    ArrayList arr = C_CostProductGroupLinkBO.Instance.FindByExpression(new TPA.Utils.Expression("C_CostID", costID).And(new TPA.Utils.Expression("C_ProductGroupID", j)));
                //    C_CostProductGroupLinkModel m = (C_CostProductGroupLinkModel)arr[0];
                //    m.ValuePercent = value;
                //    C_CostProductGroupLinkBO.Instance.Update(m);
                //}

                int linkID = TextUtils.ToInt(grvData.GetRowCellValue(i, "F1"));
                if (linkID == 0) continue;
                C_CostProductGroupLinkModel arr = (C_CostProductGroupLinkModel)C_CostProductGroupLinkBO.Instance.FindByPK(linkID);
                //arr.IsDirectCost = TextUtils.ToInt(grvData.GetRowCellValue(i, "F10"));
                arr.IsFix = TextUtils.ToInt(grvData.GetRowCellValue(i, "F9"));
                arr.NumberDay = TextUtils.ToDecimal(grvData.GetRowCellValue(i, "F8"));
                arr.PersonNumber = TextUtils.ToDecimal(grvData.GetRowCellValue(i, "F6"));
                arr.VtuPercent = TextUtils.ToDecimal(grvData.GetRowCellValue(i, "F7"));
                C_CostProductGroupLinkBO.Instance.Update(arr);
            }
            MessageBox.Show("OK");
        }

        

        private void btnSave_Click(object sender, EventArgs e)
        {
            //CreateProduct();
            //CreateVTN();
            //updateSuppliers();
            //CreateNCC();
            //loadData();
            //updateCostProductLink();
        }

        private void btnBrowse_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                btnBrowse.Text = ofd.FileName;
                cboSheet.DataSource = null;
                cboSheet.DataSource = TextUtils.ListSheetInExcel(ofd.FileName);
            }
        }

        private void cboSheet_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = TextUtils.ExcelToDatatableNoHeader(btnBrowse.Text, cboSheet.SelectedValue.ToString());

                grdData.DataSource = dt;
                grvData.PopulateColumns();
                grvData.BestFitColumns();
            }
            catch (Exception ex)
            {
                TextUtils.ShowError(ex);
                grdData.DataSource = null;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            TextUtils.ExportExcel(grvData);
        }

        private void cboSheet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
