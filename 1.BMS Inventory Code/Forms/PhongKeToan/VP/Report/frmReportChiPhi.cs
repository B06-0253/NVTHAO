using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace BMS
{
    public partial class frmReportChiPhi : _Forms
    {
        public frmReportChiPhi()
        {
            InitializeComponent();
        }

        private void frmReportChiPhi_Load(object sender, EventArgs e)
        {
            loadYear();
            loadPhongBan();
            //cboMonth.SelectedIndex = DateTime.Now.Month;
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
                string dCode = TextUtils.ToString(cboPhongBan.EditValue);
                int dID = TextUtils.ToInt(grvCboPhongBan.GetFocusedRowCellValue(colPhanXuongID));
                int year = TextUtils.ToInt(cboYear.SelectedItem);

                DataTable dtData = new DataTable();

                if (dCode.ToUpper() == "P21")
                {
                    string sql = "exec spReportChiPhi_BanGiamDoc " + year;
                    dtData = LibIE.Select(sql);
                }
                else
                {
                    string sql = "exec spReportChiPhi " + year + ", '" + dCode + "'";
                    dtData = LibIE.Select(sql);
                }

                DataRow[] drs = dtData.Select("C_MA = 'C17'");

                if (dCode.ToUpper() == "P21" || dCode.ToUpper() == "P13" || dCode.ToUpper() == "P14") // Ban giam doc, kinh doanh cn, kinh doanh day nghe
                {                    
                    string sql = "SELECT Sum(ISNULL(C_PSNO,0)) XangXe,C_Month FROM [V_XNTC_REPORT] where (C_KMP_MA = 'C17') and C_Year = " + year + " Group by C_Month";
                    DataTable dtXangXe = LibIE.Select(sql);
                    decimal tyle = TextUtils.ToDecimal(LibIE.ExcuteScalar("select top 1 TYLE from T_DM_PHANXUONG_KMP where PK_KMP = 41 and PK_PHANXUONG = " + dID));

                    decimal total = 0;
                    for (int i = 1; i <= 12; i++)
                    {
                        try
                        {
                            decimal value = TextUtils.ToDecimal(dtXangXe.Rows[i - 1]["XangXe"]);
                            decimal giaTriPB = tyle * value / 100;
                            drs[0]["T" + i + "_PB"] = giaTriPB;
                            drs[0]["T" + i] = giaTriPB;
                            drs[0]["T" + i + "_TT"] = 0;

                            total += giaTriPB;
                        }
                        catch (Exception)
                        {
                        }
                    }

                    drs[0]["Total_PB"] = total;
                    drs[0]["Total_TT"] = 0;
                    drs[0]["Total"] = total;
                }
                else if(dCode != "")
                {
                    for (int i = 1; i <= 12; i++)
                    {
                        drs[0]["T" + i + "_PB"] = 0;
                        drs[0]["T" + i] = 0;
                        drs[0]["T" + i + "_TT"] = 0;
                    }

                    drs[0]["Total_PB"] = 0;
                    drs[0]["Total_TT"] = 0;
                    drs[0]["Total"] = 0;
                }
                else
                {
                    for (int i = 1; i <= 12; i++)
                    {
                        drs[0]["T" + i + "_PB"] = TextUtils.ToDecimal(drs[0]["T" + i + "_TT"]);
                        drs[0]["T" + i] = TextUtils.ToDecimal(drs[0]["T" + i + "_TT"]); 
                        drs[0]["T" + i + "_TT"] = 0;
                    }
                    drs[0]["Total_PB"] = TextUtils.ToDecimal(drs[0]["Total_TT"]); 
                    drs[0]["Total_TT"] = 0;
                    drs[0]["Total"] = TextUtils.ToDecimal(drs[0]["Total_PB"]); 
                }

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
