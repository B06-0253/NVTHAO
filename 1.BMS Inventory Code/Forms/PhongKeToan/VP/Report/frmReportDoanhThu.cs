using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
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
    public partial class frmReportDoanhThu : _Forms
    {
        public frmReportDoanhThu()
        {
            InitializeComponent();
        }

        private void frmReportDoanhThu_Load(object sender, EventArgs e)
        {
            loadYear();
            loadPhongBan();
            gridBand1.Fixed = FixedStyle.Left;
        }

        void loadPhongBan()
        {
            string sql = "SELECT [PK_ID],[C_MA],[C_MOTA] FROM [T_DM_PHANXUONG] order by [C_MA]";
            DataTable dt = LibIE.Select(sql);
            cboPhongBan.Properties.DataSource = dt;
            cboPhongBan.Properties.DisplayMember = "C_MOTA";
            cboPhongBan.Properties.ValueMember = "C_MA";
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

        private void btnReloadData_Click(object sender, EventArgs e)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load dữ liệu..."))
            {
                string sql = "exec spReportDoanhThu " + TextUtils.ToInt(cboYear.SelectedItem) + ", '" + TextUtils.ToString(cboPhongBan.EditValue) + "'";
                DataTable dtData = LibIE.Select(sql);
                grdData.DataSource = dtData;
            }
        }

        private void btnExecl_Click(object sender, EventArgs e)
        {
            TextUtils.ExportExcel(grvData);
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
    }
}
