using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using BMS.Model;
using BMS.Business;
using DevExpress.XtraGrid.Views.Grid;

namespace BMS
{
    public partial class frmErrorAndFeatureMonitor : _Forms
    {
        int _rownIndex = 0;
        DataTable _dtData = new DataTable();

        public frmErrorAndFeatureMonitor()
        {
            InitializeComponent();
        }

        private void frmErrorAndFeatureMonitor_Load(object sender, EventArgs e)
        {
            //refreshHlper = new RefreshHelper(grvData, "Year");
            LoadInfoSearch();
        }

        void LoadInfoSearch()
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load dữ liệu..."))
            {
                try
                {
                    _dtData = TextUtils.Select("select * from vUpdateSoftware with(nolock)");

                    grdData.DataSource = _dtData;
                    if (_rownIndex >= grvData.RowCount)
                        _rownIndex = 0;
                    if (_rownIndex > 0)
                        grvData.FocusedRowHandle = _rownIndex;
                    grvData.SelectRow(_rownIndex);
                    grvData.BestFitColumns();
                }
                catch
                {
                }
            }
        }

        void main_LoadDataChange(object sender, EventArgs e)
        {
            LoadInfoSearch();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmErrorAndFeature frm = new frmErrorAndFeature();
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            long id = TextUtils.ToInt64(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            UpdateSoftwareModel model = (UpdateSoftwareModel)UpdateSoftwareBO.Instance.FindByPK(id);
            _rownIndex = grvData.FocusedRowHandle;

            frmErrorAndFeature frm = new frmErrorAndFeature();
            frm.UpdateSoftware = model;
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            if (MessageBox.Show("Bạn có chắc muốn xóa vấn đề này không?",
                      TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            UpdateSoftwareBO.Instance.Delete(id);
            LoadInfoSearch();
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            LoadInfoSearch();
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
            catch
            {
            }
        }

        private void btnNoComplete_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            UpdateSoftwareModel model = (UpdateSoftwareModel)UpdateSoftwareBO.Instance.FindByPK(id);
            model.Complete = false;
            UpdateSoftwareBO.Instance.Update(model);
            grvData.SetFocusedRowCellValue(colComplete, false);
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            UpdateSoftwareModel model = (UpdateSoftwareModel)UpdateSoftwareBO.Instance.FindByPK(id);
            model.Complete = true;
            UpdateSoftwareBO.Instance.Update(model);
            grvData.SetFocusedRowCellValue(colComplete, true);
        }

        private void grvData_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0) return;
            GridView View = sender as GridView;
            bool complete = TextUtils.ToBoolean(View.GetRowCellValue(e.RowHandle, colComplete));
            if (complete)
            {
                e.Appearance.BackColor = Color.GreenYellow;
            }            
        }

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            btnSua_Click(null, null);
        }
    }
}
