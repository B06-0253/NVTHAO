using IE.Business;
using IE.Model;
using IE.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BMS
{
    public partial class frmFCMmanagement : _Forms
    {
        int _rownIndex = 0;
        public frmFCMmanagement()
        {
            InitializeComponent();
        }

        private void frmFCMmanagement_Load(object sender, EventArgs e)
        {
            loadYear();
            cboMonth.SelectedIndex = DateTime.Now.Month;
        }

        void loadYear()
        {
            cboYear.Items.Add("Tất cả");
            for (int i = 2013; i <= DateTime.Now.Year; i++)
            {
                cboYear.Items.Add(i);
            }
            cboYear.SelectedItem = DateTime.Now.Year;
        }

        void loadData()
        {
            string[] _paraName = new string[2];
            object[] _paraValue = new object[2];
            _paraName[0] = "@Year"; _paraValue[0] = TextUtils.ToInt(cboYear.SelectedItem);
            _paraName[1] = "@Month"; _paraValue[1] = cboMonth.SelectedIndex < 0 ? 0 : cboMonth.SelectedIndex;

            DataTable Source = LibIE.LoadDataFromSP("spGetFCM", "Source", _paraName, _paraValue);

            grdData.DataSource = Source;
            
            if (_rownIndex >= grvData.RowCount)
                _rownIndex = 0;
            if (_rownIndex > 0)
                grvData.FocusedRowHandle = _rownIndex;
            grvData.SelectRow(_rownIndex);
        }

        void main_LoadDataChange(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnFindAll_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmImportInfoFCM frm = new frmImportInfoFCM();
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _rownIndex = grvData.FocusedRowHandle;
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            T_DM_FCMModel model = (T_DM_FCMModel)T_DM_FCMBO.Instance.FindByPK(id);

            frmFCMdetail frm = new frmFCMdetail();
            frm.FCM = model;
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            _rownIndex = grvData.FocusedRowHandle;
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            if (MessageBox.Show("Bạn có chắc muốn xóa FCM này không?",
                    TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            T_DM_FCMBO.Instance.Delete(id);
            LibIE.ExcuteSQL("delete T_DM_FCM_DETAIL where FK_FCM = " + id);

            loadData();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            TextUtils.ExportExcel(grvData);
        }

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }
    }
}
