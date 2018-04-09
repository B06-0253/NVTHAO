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
using System.IO;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;
using DevExpress.XtraGrid.Views.Grid;

namespace BMS
{
    public partial class frmPartBorrowManager : _Forms
    {
        int _rownIndex = 0;

        public frmPartBorrowManager()
        {
            InitializeComponent();
        }

        private void frmPartBorrowManager_Load(object sender, EventArgs e)
        {
            loadData();
        }

        void loadData()
        {
            DataTable dt = LibQLSX.Select("select * from vPartBorrow with(nolock)");
            grdData.DataSource = dt;

            if (_rownIndex >= grvData.RowCount)
                _rownIndex = 0;
            if (_rownIndex > 0)
                grvData.FocusedRowHandle = _rownIndex;
            grvData.SelectRow(_rownIndex);
            //grvData.BestFitColumns();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadData();
        }

        void main_LoadDataChange(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmPartBorrow frm = new frmPartBorrow();
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            long id = TextUtils.ToInt64(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            PartBorrowModel model = (PartBorrowModel)PartBorrowBO.Instance.FindByPK(id);
            _rownIndex = grvData.FocusedRowHandle;

            frmPartBorrow frm = new frmPartBorrow();
            frm.PartBorrow = model;
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            long id = TextUtils.ToInt64(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;

            if (MessageBox.Show("Bạn có chắc muốn xóa theo dõi vật tư [" + grvData.GetFocusedRowCellValue(colPartsCode).ToString() + "] không?",
                     TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            _rownIndex = grvData.FocusedRowHandle;
            PartBorrowBO.Instance.Delete(id);

            loadData();
        }

        private void grvData_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            //if (e.RowHandle < 0) return;
            //GridView View = sender as GridView;
            //int sl = TextUtils.ToInt(View.GetRowCellValue(e.RowHandle, colTongSoNgay));
            //string dateReturn = TextUtils.ToString(View.GetRowCellValue(e.RowHandle, colDateReturn));
            //if (sl > 15 && dateReturn == "")
            //{
            //    e.Appearance.BackColor = Color.Red;
            //}
        }

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                TextUtils.ExportExcel(grvData);
            }
            catch
            {                
            }
        }
    }
}
