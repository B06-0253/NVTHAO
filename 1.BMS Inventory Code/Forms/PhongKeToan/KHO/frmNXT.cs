using DevExpress.Utils;
using System;
using System.Collections;
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
    public partial class frmNXT : _Forms
    {
        int _rownIndex = 0;
        public frmNXT()
        {
            InitializeComponent();
        }

        private void frmNXT_Load(object sender, EventArgs e)
        {
            loadYear(); 
            cboStatus.SelectedIndex = 0;
            loadImport();
        }

        void loadYear()
        {
            for (int i = 2016; i <= DateTime.Now.Year; i++)
            {
                cboYear.Items.Add(i);
            }
            cboYear.SelectedItem = DateTime.Now.Year;
        }

        void loadImport()
        {
            string[] paraName = new string[2];
            object[] paraValue = new object[2];

            try
            {
                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load danh sách ĐNNK..."))
                {
                    paraName[0] = "@Year"; paraValue[0] = TextUtils.ToInt(cboYear.Text);
                    paraName[1] = "@StatusNXT"; paraValue[1] = cboStatus.SelectedIndex;

                    DataTable Source = OrdersBO.Instance.LoadDataFromSP("spGetRequestImportWarehouseNXT", "Source", paraName, paraValue);

                    grdDNNK.DataSource = Source;
                    if (_rownIndex >= grvDNNK.RowCount)
                        _rownIndex = 0;
                    if (_rownIndex > 0)
                        grvDNNK.FocusedRowHandle = _rownIndex;
                    grvDNNK.SelectRow(_rownIndex);
                    //grvDNNK.BestFitColumns();
                }
            }
            catch
            {
                grdDNNK.DataSource = null;
            }
        }

        DataTable _dtItem = new DataTable();

        void loadItem()
        {
            string importId = TextUtils.ToString(grvDNNK.GetFocusedRowCellValue(colImportId));

            if (importId == "")
            {
                grdData.DataSource = null;
                return;
            }

            int type = TextUtils.ToInt(grvDNNK.GetFocusedRowCellValue(colImportType));

            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load danh sách vật tư..."))
            {
                _dtItem = new DataTable();
                if (type == 1)
                {
                    _dtItem = LibQLSX.Select("select *, ROW_NUMBER() OVER(ORDER BY [ProductPartsImportId]) AS STT from [vImportMaterial] with(nolock) where [ImportId] = '" + importId + "'");
                }
                else
                {
                    _dtItem = LibQLSX.Select("select *, ROW_NUMBER() OVER(ORDER BY [ProjectProductImportId]) AS STT from [vImportProduct] with(nolock) where [ImportId] = '" + importId + "'");
                }
                grdData.DataSource = _dtItem;
            }
        }

        private void btnConfirmNK_Click(object sender, EventArgs e)
        {
            string importId = TextUtils.ToString(grvDNNK.GetFocusedRowCellValue(colImportId));
            if (importId == "") return;
            int statusNXT = TextUtils.ToInt(grvDNNK.GetFocusedRowCellValue(colStatusNXT));
            if (statusNXT == 2) return;

            DataRow[] drs = _dtItem.Select("(DeliveryOrderCodeFact = '' or DeliveryOrderCodeFact is null) and (TotalNG < Total)");
            if (drs.Length > 0)
            {
                MessageBox.Show("Bạn không thể xác nhận ĐNNK này đã được xuất kho. \nBởi vì các vật tư trong nó chưa được xuất kho hết.",
               TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc muốn xác nhận ĐNNK này đã được xuất kho", 
                TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;

            ArrayList arr = RequestImportWarehouseBO.Instance.FindByAttribute("ImportId", importId);
            RequestImportWarehouseModel import = (RequestImportWarehouseModel)arr[0];
            import.StatusNXT = 2;
            RequestImportWarehouseBO.Instance.UpdateQLSX(import);

            _rownIndex = grvDNNK.FocusedRowHandle;
            loadImport();
        }

        private void btnYCXK_Click(object sender, EventArgs e)
        {
            string importId = TextUtils.ToString(grvDNNK.GetFocusedRowCellValue(colImportId));
            if (importId == "") return;
            int statusNXT = TextUtils.ToInt(grvDNNK.GetFocusedRowCellValue(colStatusNXT));
            if (statusNXT >= 1) return;

            ArrayList arr = RequestImportWarehouseBO.Instance.FindByAttribute("ImportId", importId);
            RequestImportWarehouseModel import = (RequestImportWarehouseModel)arr[0];
            import.StatusNXT = 1;
            RequestImportWarehouseBO.Instance.UpdateQLSX(import);

            _rownIndex = grvDNNK.FocusedRowHandle;
            loadImport();
        }

        private void cboYear_SelectionChangeCommitted(object sender, EventArgs e)
        {
            loadImport();
        }

        private void cboStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {            
            loadImport();
        }

        private void grvDNNK_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {            
            loadItem();
            int statusNXT = TextUtils.ToInt(grvDNNK.GetFocusedRowCellValue(colStatusNXT));
            btnSave.Visible = statusNXT >= 1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int statusNXT = TextUtils.ToInt(grvDNNK.GetFocusedRowCellValue(colStatusNXT));
            if (statusNXT < 1) return;
            if (txtSoPX.Text.Trim() == "") return;

            foreach (int i in grvData.GetSelectedRows())
            {
                string productPartsImportId = TextUtils.ToString(grvData.GetRowCellValue(i, colProductPartsImportId));

                ArrayList arr = ProductPartsImportBO.Instance.FindByAttribute("ProductPartsImportId", productPartsImportId);
                ProductPartsImportModel ProductPartsImport = (ProductPartsImportModel)arr[0];
                ProductPartsImport.DeliveryOrderCodeFact = txtSoPX.Text.Trim();                
                ProductPartsImportBO.Instance.UpdateQLSX(ProductPartsImport);
                grvData.SetRowCellValue(i, colDeliveryOrderCodeFact, txtSoPX.Text.Trim());
            }
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

        private void btnDNNKthanhPham_Click(object sender, EventArgs e)
        {
            if (grvData.RowCount == 0) return;
            TextUtils.ExportExcel(grvData);
        }

        private void grvDNNK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == (Keys.C))
            {
                try
                {
                    string text = TextUtils.ToString(grvDNNK.GetFocusedRowCellValue(grvDNNK.FocusedColumn));
                    Clipboard.SetText(text);
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
