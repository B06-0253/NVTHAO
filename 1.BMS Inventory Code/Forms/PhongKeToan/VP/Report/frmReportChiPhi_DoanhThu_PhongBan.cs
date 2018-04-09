using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class frmReportChiPhi_DoanhThu_PhongBan : _Forms
    {
        public frmReportChiPhi_DoanhThu_PhongBan()
        {
            InitializeComponent();
        }

        private void frmReportChiPhi_DoanhThu_PhongBan_Load(object sender, EventArgs e)
        {
            loadYear();
            gridBand1.Fixed = FixedStyle.Left;
            //GridOptionsBehavior = true;            
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
                string sql = "exec spReportChiPhi_DoanhThu_PhongBan " + TextUtils.ToInt(cboYear.SelectedItem) + ", " + cboMonth.SelectedIndex;
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
