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

namespace BMS
{
    public partial class frmPartAccessoriesManager : _Forms
    {
        int _rownIndex = 0;
        public frmPartAccessoriesManager()
        {
            InitializeComponent();
        }

        private void frmPartAccessoriesManager_Load(object sender, EventArgs e)
        {
            loadType();
            LoadInfoSearch();
        }

        void loadType()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name");

            dt.Rows.Add(0, "Vật tư tiêu hao");
            dt.Rows.Add(1, "Vật tư phụ");

            repositoryItemLookUpEdit1.DataSource = dt;
            repositoryItemLookUpEdit1.DisplayMember = "Name";
            repositoryItemLookUpEdit1.ValueMember = "ID";
        }

        void main_LoadDataChange(object sender, EventArgs e)
        {
            LoadInfoSearch();
        }

        void LoadInfoSearch()
        {
            DataTable dt = LibQLSX.Select("select *,TotalPrice = Total * Price from vPartsGeneral with(nolock)");
            grdData.DataSource = dt;
            if (_rownIndex >= grvData.RowCount)
                _rownIndex = 0;
            if (_rownIndex > 0)
                grvData.FocusedRowHandle = _rownIndex;
            grvData.SelectRow(_rownIndex);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            string filePath = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
            }
            else
            {
                return;
            }

            DataTable dt = TextUtils.ExcelToDatatableNoHeader(filePath, "Sheet1");
            dt.Rows.RemoveAt(0);
            dt.Rows.RemoveAt(0);
            int count = 0;

            DataTable dtError = new DataTable();
            dtError.Columns.Add("STT");
            dtError.Columns.Add("PartsCode");
            dtError.Columns.Add("PartsName");
            dtError.Columns.Add("IsPart", typeof(int));
            dtError.Columns.Add("IsPartGereral", typeof(int));

            DataTable dtPartsGeneral = LibQLSX.Select("select PartsCode from [vPartsGeneral]");
            DataTable dtParts = LibQLSX.Select("select PartsCode from [Parts] where PartsCode is not null and PartsCode <> ''");

            foreach (DataRow row in dt.Rows)
            {
                string partsCode = TextUtils.ToString(row["F2"]);
                if (partsCode == "") continue;
                string name = TextUtils.ToString(row["F1"]);
                string unit = TextUtils.ToString(row["F4"]);
                string hang = TextUtils.ToString(row["F5"]);
                decimal qtyMin = TextUtils.ToDecimal(row["F6"]);
                decimal price = TextUtils.ToDecimal(row["F7"]);
                decimal qty = TextUtils.ToDecimal(row["F9"]);
                decimal total = TextUtils.ToDecimal(row["F9"]);
                decimal projectPercent = TextUtils.ToDecimal(row["F10"]);
                int type = TextUtils.ToInt(row["F11"]);
                int isProject = TextUtils.ToInt(row["F12"]);

                PartAccessoriesModel model = new PartAccessoriesModel();
                model.Code = partsCode;
                model.Name = name;
                model.Hang = hang;
                model.IsProject = isProject;
                model.Price = price;
                model.ProjectPercent = projectPercent;
                model.Qty = qty;
                model.QtyDM = 0;
                model.QtyMin = qtyMin;
                model.Total = total;
                model.Type = type;
                model.Unit = unit;
                PartAccessoriesBO.Instance.Insert(model);
                count++;
            }

            //foreach (DataRow row in dt.Rows)
            //{
            //    string partsCode = TextUtils.ToString(row["F3"]);
            //    if (partsCode == "") continue;
            //    DataRow[] drsG = dtPartsGeneral.Select("PartsCode = '" + partsCode + "'");
            //    DataRow[] drsP = dtParts.Select("PartsCode = '" + partsCode + "'");
            //    DataRow dr = dtError.NewRow();
            //    dr["STT"] = TextUtils.ToString(row["F1"]); 
            //    dr["PartsCode"] = partsCode;
            //    dr["PartsName"] = TextUtils.ToString(row["F2"]); 
            //    dr["IsPart"] = drsP.Length > 0 ? 1 : 0;
            //    dr["IsPartGereral"] = drsG.Length > 0 ? 1 : 0;
            //    dtError.Rows.Add(dr);
            //    count++;
            //}
            //TextUtils.DatatableToCSV(dtError, "D:\\1.csv");
            MessageBox.Show(count.ToString());
            LoadInfoSearch();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //frmPartsGeneral frm = new frmPartsGeneral();
            //frm.LoadDataChange += main_LoadDataChange;
            //frm.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string id = TextUtils.ToString(grvData.GetFocusedRowCellValue(colID));
                if (id == "") return;
                PartsGeneralModel model = (PartsGeneralModel)PartsGeneralBO.Instance.FindByAttribute("PartsId", id)[0];
                _rownIndex = grvData.FocusedRowHandle;

                frmPartsGeneral frm = new frmPartsGeneral();
                frm.PartA = model;
                frm.LoadDataChange += main_LoadDataChange;
                frm.Show();
            }
            catch (Exception)
            {                
            }            
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (grvData.DataSource == null) return;
            //    int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            //    string code = TextUtils.ToString(grvData.GetFocusedRowCellValue(colCode));
            //    if (id == 0) return;

            //    //if (ModuleFilmBO.Instance.CheckExist("ModuleID", id))
            //    //{
            //    //    MessageBox.Show("Sản phẩm này đang chứa Film in nên không thể xóa được.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    //    return;
            //    //}
               
            //    if (MessageBox.Show("Bạn có chắc muốn xóa vật tư phụ [" +TextUtils.ToString(grvData.GetFocusedRowCellValue(colName)) + "] không?",
            //          TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //        return;
            //    PartAccessoriesBO.Instance.Delete(id);
            //    LoadInfoSearch();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvData.RowCount > 0)
                {
                    TextUtils.ExportExcel(grvData);
                }
            }
            catch (Exception)
            {

            }
        }

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void grvData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C)
            {
                try
                {
                    string text = TextUtils.ToString(grvData.GetFocusedRowCellValue(grvData.FocusedColumn));
                    Clipboard.SetText(text);
                }
                catch
                {
                }
            }
        }
    }
}
