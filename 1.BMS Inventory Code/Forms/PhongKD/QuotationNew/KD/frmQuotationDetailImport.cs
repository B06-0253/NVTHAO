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
    public partial class frmQuotationDetailImport : _Forms
    {
        public C_Quotation_KDModel Quotation = new C_Quotation_KDModel();
        //public int QuotationID = 0;
        public delegate void LoadDataChangeHandler(object sender, EventArgs e);
        public event LoadDataChangeHandler LoadDataChange;

        DataTable _dtData = new DataTable();

        public frmQuotationDetailImport()
        {
            InitializeComponent();
        }

        private void btnBrowse_EditValueChanged(object sender, EventArgs e)
        {

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
                _dtData.Rows.RemoveAt(0);
                grdData.DataSource = _dtData;
            }
            catch (Exception ex)
            {
                TextUtils.ShowError(ex);
                grdData.DataSource = null;
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

                DataRow[] drsParent = _dtData.Select("F2 = '0'");
                foreach (DataRow row in drsParent)
                {
                    int stt = TextUtils.ToInt(row["F1"]);
                    //int parentID = TextUtils.ToInt(row["F2"]);
                    decimal qty = TextUtils.ToDecimal(row["F7"]);

                    C_QuotationDetail_KDModel item = new C_QuotationDetail_KDModel();
                    item.C_QuotationID = Quotation.ID;
                    item.ParentID = 0;
                    item.Qty = item.QtyT = qty;
                    item.PriceVT = TextUtils.ToDecimal(row["F8"]);
                    //item.PriceVT = item.PriceVT;
                    item.Manufacture = TextUtils.ToString(row["F9"]);
                    item.ModuleCode = TextUtils.ToString(row["F4"]);
                    item.ModuleName = TextUtils.ToString(row["F3"]);
                    item.Origin = TextUtils.ToString(row["F10"]);
                    item.VAT = TextUtils.ToDecimal(row["F6"]) * 100;
                    item.PriceHD = TextUtils.ToDecimal(row["F12"]);

                    //DataTable dtGroup = LibQLSX.Select();
                    string sqlGroup = "select ID from C_ProductGroup where Code = '" + TextUtils.ToString(row["F5"]) + "'";
                    item.C_ProductGroupID = TextUtils.ToInt(LibQLSX.ExcuteScalar(sqlGroup)); //dtGroup.Rows.Count > 0 ? TextUtils.ToInt(dtGroup.Rows[0][0]) : 0;

                    string sqlPercentXLKH = "select top 1 " + (Quotation.DepartmentId == "D018" ? "CustomerPercentKD1" : "CustomerPercentKD2")
                                + " from C_ProductGroup where ID = " + item.C_ProductGroupID;
                    item.PercentXLKH = TextUtils.ToDecimal(LibQLSX.ExcuteScalar(sqlPercentXLKH));

                    item.ID = (int)pt.Insert(item);
                    count++;
                    row["ID"] = item.ID;

                    DataRow[] drs = _dtData.Select("F2 = '" + stt + "'");
                    foreach (DataRow rowC in drs)
                    {
                        int sttC = TextUtils.ToInt(rowC["F1"]);
                        int parentIDC = TextUtils.ToInt(rowC["F2"]);
                        decimal qtyC = TextUtils.ToDecimal(rowC["F7"]);
                        string groupCode = TextUtils.ToString(rowC["F5"]);
                        int groupID = 0;

                        DataTable dtGroupC = LibQLSX.Select("select ID from C_ProductGroup where Code = '" + groupCode + "'");
                        groupID = dtGroupC.Rows.Count > 0 ? TextUtils.ToInt(dtGroupC.Rows[0][0]) : 0;

                        C_QuotationDetail_KDModel itemC = new C_QuotationDetail_KDModel();
                        itemC.C_QuotationID = Quotation.ID;
                        itemC.ParentID = item.ID;
                        itemC.C_ProductGroupID = groupID;

                        string sqlPercentXLKH1 = "select top 1 " + (Quotation.DepartmentId == "D018" ? "CustomerPercentKD1" : "CustomerPercentKD2")
                                + " from C_ProductGroup where ID = " + itemC.C_ProductGroupID;
                        item.PercentXLKH = TextUtils.ToDecimal(LibQLSX.ExcuteScalar(sqlPercentXLKH1));

                        itemC.VAT = TextUtils.ToDecimal(rowC["F6"]) * 100;
                        itemC.Qty = qtyC * item.Qty;
                        itemC.QtyT = qtyC;
                        itemC.PriceVT = TextUtils.ToDecimal(rowC["F8"]);
                        //itemC.PriceVT = itemC.PriceVT;

                        itemC.ModuleName = TextUtils.ToString(rowC["F3"]);
                        itemC.ModuleCode = TextUtils.ToString(rowC["F4"]);
                        itemC.Manufacture = TextUtils.ToString(rowC["F9"]);
                        itemC.Origin = TextUtils.ToString(rowC["F10"]);

                        string pTK = TextUtils.ToString(rowC["F11"]);
                        if (pTK.ToUpper().Trim() == "TK1")
                        {
                            itemC.DepartmentId = "D009";
                        }
                        else if (pTK.ToUpper().Trim() == "TK2")
                        {
                            itemC.DepartmentId = "D028";
                        }
                        else
                        {
                            itemC.DepartmentId = "";
                        }

                        itemC.ID = (int)pt.Insert(itemC);
                        rowC["ID"] = itemC.ID;
                        count++;
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

        
    }
}
