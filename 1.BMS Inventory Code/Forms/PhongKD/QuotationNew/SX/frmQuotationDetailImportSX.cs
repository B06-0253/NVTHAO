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
using TPA.Utils;

namespace BMS
{
    public partial class frmQuotationDetailImportSX : _Forms
    {
        public C_Quotation_KDModel Quotation = new C_Quotation_KDModel();
        //public int QuotationID = 0;
        public delegate void LoadDataChangeHandler(object sender, EventArgs e);
        public event LoadDataChangeHandler LoadDataChange;

        DataTable _dtData = new DataTable();

        public frmQuotationDetailImportSX()
        {
            InitializeComponent();
        }
        //
        private void frmQuotationDetailImportSX_Load(object sender, EventArgs e)
        {
        }

        void saveDN(ProcessTransaction pt, int count, DataRow row)
        {
            int stt = TextUtils.ToInt(row["F1"]);
            decimal qty = TextUtils.ToDecimal(row["F7"]);

            C_QuotationDetail_SXModel item = new C_QuotationDetail_SXModel();
            item.C_QuotationID = Quotation.ID;
            item.ParentID = 0;
            item.Qty = item.QtyT = qty;
            item.PriceVT = TextUtils.ToDecimal(row["F41"]);
            item.PriceVTTN = TextUtils.ToDecimal(row["F42"]);
            item.PriceVTPS = TextUtils.ToDecimal(row["F43"]);
            item.Manufacture = TextUtils.ToString(row["F4"]);
            item.ModuleCode = TextUtils.ToString(row["F3"]);
            item.ModuleName = TextUtils.ToString(row["F2"]);
            item.Origin = TextUtils.ToString(row["F5"]);

            item.C_ProductGroupID = TextUtils.ToInt(LibQLSX.ExcuteScalar("select ID from C_ProductGroup where Code = '" + TextUtils.ToString(row["F6"]) + "'"));

            item.ID = (int)pt.Insert(item);
            count++;
            row["ID"] = item.ID;

            DataRow[] drs = _dtData.Select("F1 like '" + stt + ".%'");
            foreach (DataRow rowC in drs)
            {
                decimal qtyC = TextUtils.ToDecimal(rowC["F7"]);
                string groupCode = TextUtils.ToString(rowC["F6"]);

                int groupID = TextUtils.ToInt(LibQLSX.ExcuteScalar("select ID from C_ProductGroup where Code = '" + groupCode + "'"));

                C_QuotationDetail_SXModel itemC = new C_QuotationDetail_SXModel();
                itemC.C_QuotationID = Quotation.ID;
                itemC.ParentID = item.ID;
                itemC.C_ProductGroupID = groupID;

                itemC.Qty = qtyC;
                itemC.QtyT = qtyC / item.Qty;
                itemC.PriceVT = TextUtils.ToDecimal(rowC["F41"]);
                itemC.PriceVTTN = TextUtils.ToDecimal(row["F42"]);
                itemC.PriceVTPS = TextUtils.ToDecimal(row["F43"]);

                itemC.ModuleName = TextUtils.ToString(rowC["F2"]);
                itemC.ModuleCode = TextUtils.ToString(rowC["F3"]);
                itemC.Manufacture = TextUtils.ToString(rowC["F4"]);
                itemC.Origin = TextUtils.ToString(rowC["F5"]);

                itemC.ID = (int)pt.Insert(itemC);
                rowC["ID"] = itemC.ID;
                count++;
            }
        }

        void saveCN(ProcessTransaction pt, int count, DataRow row)
        {
            int stt = TextUtils.ToInt(row["F1"]);
            decimal qty = TextUtils.ToDecimal(row["F7"]);

            C_QuotationDetail_SXModel item = new C_QuotationDetail_SXModel();
            item.C_QuotationID = Quotation.ID;
            item.ParentID = 0;
            item.Qty = item.QtyT = qty;
            item.PriceVT = TextUtils.ToDecimal(row["F47"]);
            item.PriceVTTN = TextUtils.ToDecimal(row["F48"]);
            item.PriceVTPS = TextUtils.ToDecimal(row["F49"]);
            item.Manufacture = TextUtils.ToString(row["F4"]);
            item.ModuleCode = TextUtils.ToString(row["F3"]);
            item.ModuleName = TextUtils.ToString(row["F2"]);
            item.Origin = TextUtils.ToString(row["F5"]);

            item.C_ProductGroupID = TextUtils.ToInt(LibQLSX.ExcuteScalar("select ID from C_ProductGroup where Code = '" + TextUtils.ToString(row["F6"]) + "'"));

            item.ID = (int)pt.Insert(item);
            count++;
            row["ID"] = item.ID;

            DataRow[] drs = _dtData.Select("F1 like '" + stt + ".%'");
            foreach (DataRow rowC in drs)
            {
                decimal qtyC = TextUtils.ToDecimal(rowC["F7"]);
                string groupCode = TextUtils.ToString(rowC["F6"]);

                int groupID = TextUtils.ToInt(LibQLSX.ExcuteScalar("select ID from C_ProductGroup where Code = '" + groupCode + "'"));

                C_QuotationDetail_SXModel itemC = new C_QuotationDetail_SXModel();
                itemC.C_QuotationID = Quotation.ID;
                itemC.ParentID = item.ID;
                itemC.C_ProductGroupID = groupID;

                itemC.Qty = qtyC;
                itemC.QtyT = qtyC / item.Qty;
                itemC.PriceVT = TextUtils.ToDecimal(rowC["F47"]);
                itemC.PriceVTTN = TextUtils.ToDecimal(row["F48"]);
                itemC.PriceVTPS = TextUtils.ToDecimal(row["F49"]);

                itemC.ModuleName = TextUtils.ToString(rowC["F2"]);
                itemC.ModuleCode = TextUtils.ToString(rowC["F3"]);
                itemC.Manufacture = TextUtils.ToString(rowC["F4"]);
                itemC.Origin = TextUtils.ToString(rowC["F5"]);

                itemC.ID = (int)pt.Insert(itemC);
                rowC["ID"] = itemC.ID;
                count++;

                #region Chi phí nhân công

                //Phòng thiết kê
                C_CostQuotationItemLinkNewModel linkP24 = new C_CostQuotationItemLinkNewModel();
                linkP24.C_CostID = Quotation.CreatedDepartmentID == 18 ? 101 : 61;
                linkP24.C_QuotationDetail_SXID = itemC.ID;
                linkP24.NumberDay = TextUtils.ToDecimal(rowC["F10"]);
                linkP24.PersonNumber = TextUtils.ToDecimal(rowC["F9"]);
                linkP24.CostNCType = TextUtils.ToString(rowC["F12"]);
                linkP24.TotalR = linkP24.NumberDay * linkP24.PersonNumber;
                linkP24.Price = linkP24.TotalR * TextUtils.ToDecimal(LibQLSX.ExcuteScalar("select Price from C_CostNCType where C_CostID = " 
                    + linkP24.C_CostID + " and CostNCType = '" + linkP24.CostNCType + "'"));//pricePerDay;
                linkP24.IsDirect = 1;
                pt.Insert(linkP24);

                //Phòng SXLR
                C_CostQuotationItemLinkNewModel linkP07 = new C_CostQuotationItemLinkNewModel();
                linkP07.C_CostID = 64;
                linkP07.C_QuotationDetail_SXID = itemC.ID;
                linkP07.NumberDay = TextUtils.ToDecimal(rowC["F16"]);
                linkP07.PersonNumber = TextUtils.ToDecimal(rowC["F15"]);
                linkP07.CostNCType = TextUtils.ToString(rowC["F17"]);
                linkP07.TotalR = linkP07.NumberDay * linkP07.PersonNumber;
                linkP07.Price = linkP07.TotalR * TextUtils.ToDecimal(LibQLSX.ExcuteScalar("select Price from C_CostNCType where C_CostID = " 
                    + linkP07.C_CostID + " and CostNCType = '" + linkP07.CostNCType + "'")); //pricePerDay;
                linkP07.IsDirect = 1;
                pt.Insert(linkP07);

                //Phòng Service
                C_CostQuotationItemLinkNewModel linkP12 = new C_CostQuotationItemLinkNewModel();
                linkP12.C_CostID = 63;
                linkP12.C_QuotationDetail_SXID = itemC.ID;
                linkP12.NumberDay = TextUtils.ToDecimal(rowC["F21"]);
                linkP12.PersonNumber = TextUtils.ToDecimal(rowC["F20"]);
                linkP12.CostNCType = TextUtils.ToString(rowC["F22"]);
                linkP12.TotalR = linkP12.NumberDay * linkP12.PersonNumber;
                linkP12.Price = linkP12.TotalR * TextUtils.ToDecimal(LibQLSX.ExcuteScalar("select Price from C_CostNCType where C_CostID = " 
                    + linkP12.C_CostID + " and CostNCType = '" + linkP12.CostNCType + "'"));//pricePerDay;
                linkP12.IsDirect = 1;
                pt.Insert(linkP12);

                //Phòng PLD
                C_CostQuotationItemLinkNewModel linkPLD = new C_CostQuotationItemLinkNewModel();
                linkPLD.C_CostID = 103;
                linkPLD.C_QuotationDetail_SXID = itemC.ID;
                linkPLD.NumberDay = TextUtils.ToDecimal(rowC["F30"]);
                linkPLD.PersonNumber = TextUtils.ToDecimal(rowC["F29"]);
                linkPLD.CostNCType = TextUtils.ToString(rowC["F31"]);
                linkPLD.TotalR = linkPLD.NumberDay * linkPLD.PersonNumber;
                linkPLD.Price = linkPLD.TotalR * TextUtils.ToDecimal(LibQLSX.ExcuteScalar("select Price from C_CostNCType where C_CostID = " 
                    + linkPLD.C_CostID + " and CostNCType = '" + linkPLD.CostNCType + "'"));//pricePerDay;
                linkPLD.IsDirect = 1;
                pt.Insert(linkPLD);

                //Phòng PCG
                C_CostQuotationItemLinkNewModel linkPCG = new C_CostQuotationItemLinkNewModel();
                linkPCG.C_CostID = 104;
                linkPCG.C_QuotationDetail_SXID = itemC.ID;
                linkPCG.NumberDay = TextUtils.ToDecimal(rowC["F35"]);
                linkPCG.PersonNumber = TextUtils.ToDecimal(rowC["F34"]);
                linkPCG.CostNCType = TextUtils.ToString(rowC["F36"]);
                linkPCG.TotalR = linkPCG.NumberDay * linkPCG.PersonNumber;
                linkPCG.Price = linkPCG.TotalR * TextUtils.ToDecimal(LibQLSX.ExcuteScalar("select Price from C_CostNCType where C_CostID = " 
                    + linkPCG.C_CostID + " and CostNCType = '" + linkPCG.CostNCType + "'"));//pricePerDay;
                linkPCG.IsDirect = 1;
                pt.Insert(linkPCG);
                #endregion
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (grvData.RowCount == 0) return;
            if (_dtData.Rows.Count == 0) return;
            int count = 0;
            bool isSaved = false;

            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();

            try
            {
                DataRow[] drsIsSaved = _dtData.Select("ID > 0");
                if (drsIsSaved.Length > 0)
                    MessageBox.Show("Danh sách thiết bị đã được lưu!");

                DataRow[] drsParent = _dtData.Select("F1 not like '%.%'");
                foreach (DataRow row in drsParent)
                {
                    if (TextUtils.ToString(cboSheet.SelectedValue).Contains(".CN"))
                    {
                        saveCN(pt, count, row);
                    }
                    else
                    {
                        saveDN(pt, count, row);
                    }
                }

                pt.CommitTransaction();
                isSaved = true;
                MessageBox.Show("Đã lưu trữ thành công " + count + "/" + _dtData.Rows.Count + " thiết bị!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lưu trữ không thành công!" + Environment.NewLine + ex.Message, TextUtils.Caption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                pt.CloseConnection();
            }

            if (count > 0 && isSaved)
            {
                if (this.LoadDataChange != null)
                {
                    this.LoadDataChange(null, null);
                }
            }
        }

        private void btnBrowse_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                btnBrowse.Text = ofd.FileName;
                cboSheet.DataSource = null;
                cboSheet.DataSource = TextUtils.ListSheetInExcel(ofd.FileName);

                grdData.DataSource = null;

                cboSheet.SelectedIndex = 0;
            }
        }

        private void cboSheet_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                _dtData = TextUtils.ExcelToDatatableNoHeader(btnBrowse.Text, cboSheet.SelectedValue.ToString());
                _dtData.Columns.Add("ID", typeof(int));
               
                _dtData = _dtData.AsEnumerable()
                           .Where(row => TextUtils.ToInt(row.Field<string>("F1") == "" ||
                               row.Field<string>("F1") == null ? "0" : row.Field<string>("F1").Substring(0, 1)) > 0)
                           .CopyToDataTable();
                grdData.DataSource = _dtData;
            }
            catch (Exception ex)
            {
                TextUtils.ShowError(ex);
                grdData.DataSource = null;
            }
        }
    }
}
