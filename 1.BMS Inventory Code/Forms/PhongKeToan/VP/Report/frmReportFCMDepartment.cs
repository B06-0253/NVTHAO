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
    public partial class frmReportFCMDepartment : _Forms
    {
        public frmReportFCMDepartment()
        {
            InitializeComponent();
        }

        private void frmReportFCMDepartment_Load(object sender, EventArgs e)
        {
            loadYear();
            loadPhongBan();
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

        void loadPhongBan()
        {
            string sql = "SELECT [PK_ID],[C_MA],[C_MOTA] FROM [T_DM_PHANXUONG] order by [C_MA]";
            DataTable dt = LibIE.Select(sql);
            cboPhongBan.Properties.DataSource = dt;
            cboPhongBan.Properties.DisplayMember = "C_MOTA";
            cboPhongBan.Properties.ValueMember = "C_MA";
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load dữ liệu..."))
            {
                string dCode = TextUtils.ToString(cboPhongBan.EditValue);
                int year = TextUtils.ToInt(cboYear.SelectedItem);
                int month = cboMonth.SelectedIndex;

                string sqlStart = "SELECT a.PK_ID, a.C_MA, a.C_MOTA, a.[GroupCode] +'-'+ a.[GroupName] as [GroupCode]";
                string sqlEnd = " FROM V_DM_KMP a where isnull([FK_GROUP],0) > 0";
                string sql = "";

                DataTable dt = LibIE.Select("select distinct [C_CODE] from [V_DM_FCM_DETAIL] where [C_YEAR] = " + year + " and [C_MONTH] = " + month);

                foreach (DataRow row in dt.Rows)
                {
                    string p = TextUtils.ToString(row["C_CODE"]);
                    sql += " ,[" + p + "] = (select SUM(ISNULL(C_PRICE,0)) from V_DM_FCM_DETAIL where C_CODE = '" + p + "' and (C_PHANXUONG_MA = '" + dCode + "') and FK_KMP = a.PK_ID and C_Month = " + month + " and C_Year = " + year + ") ";
                }

                string str = sqlStart + sql + sqlEnd;
                DataTable dtData = LibIE.Select(str);
                dtData.Columns["PK_ID"].Caption = "PK_ID";
                dtData.Columns["C_MA"].Caption = "Mã";
                dtData.Columns["C_MOTA"].Caption = "Tên";
                dtData.Columns["GroupCode"].Caption = "Nhóm";
                
                grvData.PopulateColumns(dtData);
                grdData.DataSource = dtData;

                grvData.Columns[0].Visible = false;
                grvData.Columns[3].GroupIndex = 0;
                grvData.Columns[3].Visible = false;

                for (int i = 4; i < dtData.Columns.Count; i++)
                {
                    grvData.Columns[i].DisplayFormat.FormatType = FormatType.Numeric;
                    grvData.Columns[i].DisplayFormat.FormatString = "n0";
                }

                grvData.BestFitColumns();
                grvData.ExpandAllGroups();
                grvData.Columns[1].Fixed = FixedStyle.Left;
                grvData.Columns[2].Fixed = FixedStyle.Left;
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
