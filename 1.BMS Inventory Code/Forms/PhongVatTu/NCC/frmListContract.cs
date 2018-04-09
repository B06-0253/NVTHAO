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
using DevExpress.XtraGrid.Views.Grid;

namespace BMS
{
    public partial class frmListContract : _Forms
    {
        int _rowIndex = 0;
        public frmListContract()
        {
            InitializeComponent();
        }

        private void frmListContract_Load(object sender, EventArgs e)
        {
            loadContract();
        }

        void loadContract()
        {
            DataTable dtContract = LibQLSX.Select("select * from vSupplierContract with(nolock)");
            grdData.DataSource = dtContract;
            if (_rowIndex >= grvData.RowCount)
                _rowIndex = 0;
            if (_rowIndex > 0)
                grvData.FocusedRowHandle = _rowIndex;
            grvData.SelectRow(_rowIndex);
        }

        private void btnExeclGroup_Click(object sender, EventArgs e)
        {
            if (grvData.RowCount == 0) return;
            
            TextUtils.ExportExcel(grvData);
        }

        private void btnIsReceived_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id <= 0) return;

            DialogResult result = MessageBox.Show("Bạn có chắc muốn xác nhận đã nhận hợp đồng này từ bộ phận vật tư?",
                TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;

            SupplierContractModel model = (SupplierContractModel)SupplierContractBO.Instance.FindByPK(id);
            model.IsReceived = true;
            SupplierContractBO.Instance.Update(model);

            _rowIndex = grvData.FocusedRowHandle;
            loadContract();
        }

        private void grvData_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0) return;
            GridView View = sender as GridView;
            int isOut = TextUtils.ToInt(View.GetRowCellValue(e.RowHandle, colIsOut));

            if (isOut == 1)
            {
                e.Appearance.ForeColor = Color.Yellow;
            }            
        }
    }
}
