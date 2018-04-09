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
    public partial class frmReportChiPhi_FCM_KD : _Forms
    {
        public frmReportChiPhi_FCM_KD()
        {
            InitializeComponent();
        }

        private void frmReportChiPhi_FCM_KD_Load(object sender, EventArgs e)
        {
            loadYear();
            loadFCM();
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

        void loadFCM()
        {
            //string sql = "select ID, [C_CODE] from T_DM_FCM";
            string sql = "SELECT * FROM [T_DM_DTCP] where ([C_MA] like 'F%' or [C_MA] like 'S%' or [C_MA] like 'T%') and len(C_Ma) = 9 ";
            DataTable dt = LibIE.Select(sql);
            cboFCM.Properties.DataSource = dt;
            cboFCM.Properties.DisplayMember = "C_MA";
            cboFCM.Properties.ValueMember = "C_MA";
        }

        DataTable loadLaiVay(string projectCode)
        {
            DataTable dtTime = LibIE.Select("SELECT distinct [C_Month],[C_Year] FROM [tanphat].[dbo].V_XNTC_REPORT_ALL"
                                            + " where (FK_TKCO like '131%' or [FK_TKNO] like '331%') and [C_DTCP_MA] like '" + projectCode + "%' "
                                            + " order by [C_Year],[C_Month]");

            DataTable dtLaiVay = LibIE.Select("SELECT [C_NGAYLAP],[FK_TKNO],[C_Month] ,[C_Year],sum([C_PSNO]) as [C_PSNO],0.00 as Total, 0.00 as Lai, 0.00 as LaiGop, 0.00 as TongLai FROM [tanphat].[dbo].V_XNTC_REPORT_ALL"
                                            + " where (FK_TKCO like '131%' or [FK_TKNO] like '331%') and [C_DTCP_MA] like '" + projectCode + "%'"
                                            + " group by [C_NGAYLAP],[FK_TKNO],[C_Month],[C_Year]"
                                            + " order by [C_NGAYLAP]");

            foreach (DataRow r in dtTime.Rows)
            {
                int month = TextUtils.ToInt(r["C_Month"]);
                int year = TextUtils.ToInt(r["C_Year"]);
                int days = DateTime.DaysInMonth(year, month);
                DateTime cuoiThang = new DateTime(year, month, days);
                dtLaiVay.Rows.Add(cuoiThang, "331", month, year, 0, 0, 0, 0);
            }

            DataRow[] dataRows = dtLaiVay.Select().OrderBy(u => u["C_NGAYLAP"]).ToArray();
            if (dataRows.Length == 0)
            {
                return dtLaiVay;
            }
            else
            {
                dtLaiVay = dataRows.CopyToDataTable();
            }


            decimal per = 0.07m / 365m;
            decimal total = 0;
            for (int i = 0; i < dtLaiVay.Rows.Count; i++)
            {
                string tk = TextUtils.ToString(dtLaiVay.Rows[i]["FK_TKNO"]);
                DateTime ngayLap = TextUtils.ToDate3(dtLaiVay.Rows[i]["C_NGAYLAP"]);
                if (tk.StartsWith("331"))
                {
                    total += TextUtils.ToDecimal(dtLaiVay.Rows[i]["C_PSNO"]);
                }
                else
                {
                    total -= TextUtils.ToDecimal(dtLaiVay.Rows[i]["C_PSNO"]);
                }

                dtLaiVay.Rows[i]["Total"] = total;
                dtLaiVay.Rows[i]["Lai"] = per * total;

                if (i == 0)
                {
                    dtLaiVay.Rows[i]["TongLai"] = per * total;
                    dtLaiVay.Rows[i]["LaiGop"] = per * total;
                }
                else
                {
                    DateTime ngayLapTruoc = TextUtils.ToDate3(dtLaiVay.Rows[i - 1]["C_NGAYLAP"]);
                    decimal laiTruoc = TextUtils.ToDecimal(dtLaiVay.Rows[i - 1]["Lai"]);
                    decimal tongLaiTruoc = TextUtils.ToDecimal(dtLaiVay.Rows[i - 1]["TongLai"]);
                    TimeSpan ts = ngayLap - ngayLapTruoc;
                    decimal tongLai = (ts.Days - 1) * laiTruoc + per * total + tongLaiTruoc;
                    dtLaiVay.Rows[i]["TongLai"] = tongLai;

                    dtLaiVay.Rows[i]["LaiGop"] = (ts.Days - 1) * laiTruoc + per * total;
                }
            }

            return dtLaiVay;
        }

        DataTable _dtData = new DataTable();
        void initTable()
        {
            _dtData = new DataTable();
            _dtData.Columns.Add("STT", typeof(int));
            _dtData.Columns.Add("Code");
            _dtData.Columns.Add("Name");
            _dtData.Columns.Add("SqlText1");
            _dtData.Columns.Add("SqlText2");
            _dtData.Columns.Add("Group");
            _dtData.Columns.Add("C_Value", typeof(decimal));
            _dtData.Columns.Add("NamTruoc", typeof(decimal));

            string sql1 = "SELECT sum([C_PSNO]) FROM [V_XNTC_REPORT_ALL] where FK_TKNO like '3359%' and FK_TKCO like '1111%'";// and  [C_KMP_MA] = 'C09P15' and C_PHANXUONG_MA in ('P11','P24','P16')";
            _dtData.Rows.Add(1, "2", "Chênh lệch chi - thu xúc tiến bán hàng", sql1, "", "", 0, 0);
            string sql2 = "SELECT sum([C_PSNO]) FROM [V_XNTC_REPORT_ALL] where FK_TKNO like '5211%' and FK_TKCO like '3359%'";
            _dtData.Rows.Add(2, "2.1", "Thu xúc tiến bán hàng", sql2, "", "", 0, 0);

            _dtData.Rows.Add(3, "2.2", "Chi xúc tiến bán hàng", "", "", "", 0, 0);

            string sql4 = "SELECT sum([C_PSNO]) FROM [V_XNTC_REPORT_ALL] where [C_KMP_MA] = 'C13'";
            _dtData.Rows.Add(4, "3", "Chi phí vận chuyển", sql4, "", "", 0, 0);
            string sql5 = "SELECT sum([C_PSNO]) FROM [V_XNTC_REPORT_ALL] where [C_KMP_MA] = 'C52'";
            _dtData.Rows.Add(5, "4", "Chi phí bốc xếp", sql5, "", "", 0, 0);
            string sql6 = "SELECT sum([C_PSNO]) FROM [V_XNTC_REPORT_ALL] where FK_TKNO like '632%'";
            _dtData.Rows.Add(6, "5.2", "Vật tư mua ngoài TPA", sql6, "", "", 0, 0);
            string sql7 = "SELECT sum([C_PSNO]) FROM [V_XNTC_REPORT_ALL] where [C_KMP_MA] = 'C25'";
            _dtData.Rows.Add(7, "9", "Chi phí dự phòng", sql7, "", "", 0, 0);
            _dtData.Rows.Add(8, "11", "Chi phí lãi vay", "", "", "", 0, 0);
        }

        void loadData()
        {
            string fcmCode = TextUtils.ToString(cboFCM.EditValue);
            int year = TextUtils.ToInt(cboYear.SelectedItem);
            //txtTotalVT.EditValue = LibQLSX.ExcuteScalar("select sum(isnull(TotalBuy,0) * isnull(Price,0))  FROM [vRequirePartFull_Order] where ProjectCode = '" + fcmCode + "' and isnull([OrderCode],'') <> ''");

            DataTable dtQuotation = LibQLSX.Select("exec [spReportQuotationKD_Project] @ProjectCode = '" + fcmCode + "'");
            DataTable dtAllCost = LibQLSX.Select("exec [spReportCostWithQuotationKD_Project] '" + fcmCode + "'");

            DataTable dtLaiVay = loadLaiVay(fcmCode);
            DataTable dtMonth = LibIE.Select("select distinct [C_Month] from [V_XNTC_REPORT_ALL] where [C_DTCP_MA] like '" + fcmCode + "%' and [C_YEAR] = " + year);

            initTable();

            string exp = "NamTruoc";
            foreach (DataRow row in dtMonth.Rows)
            {
                string p = TextUtils.ToString(row["C_Month"]);
                _dtData.Columns.Add("T_" + p, typeof(decimal));
                exp += "+ T_" + p;
            }

            foreach (DataRow r in _dtData.Rows)
            {
                string sql1 = TextUtils.ToString(r["SqlText1"]);
                string sql2 = TextUtils.ToString(r["SqlText2"]);

                if (sql1 == "") continue;

                foreach (DataColumn c in _dtData.Columns)
                {
                    if (c.ColumnName == "NamTruoc")
                    {
                        if (sql2 == "")
                        {
                            r["NamTruoc"] = TextUtils.ToDecimal(LibIE.ExcuteScalar(sql1 + " and C_DTCP_MA like '" + fcmCode + "%' and [C_Year] < " + year));
                        }
                        else
                        {
                            r["NamTruoc"] = TextUtils.ToDecimal(LibIE.ExcuteScalar(sql1 + " and C_DTCP_MA like '" + fcmCode + "%' and [C_Year] < " + year))
                                - TextUtils.ToDecimal(LibIE.ExcuteScalar(sql2 + " and C_DTCP_MA like '" + fcmCode + "%' and [C_Year] < " + year));
                        }
                    }

                    if (c.ColumnName.StartsWith("T_"))
                    {
                        if (sql2 == "")
                        {
                            r[c.ColumnName] = TextUtils.ToDecimal(LibIE.ExcuteScalar(sql1 + " and C_DTCP_MA like '" + fcmCode + "%' and [C_Year] = " + year + " and [C_Month] = " + c.ColumnName.Replace("T_", "")));
                        }
                        else
                        {
                            r[c.ColumnName] = TextUtils.ToDecimal(LibIE.ExcuteScalar(sql1 + " and C_DTCP_MA like '" + fcmCode + "%' and [C_Year] = " + year + " and [C_Month] = " + c.ColumnName.Replace("T_", "")))
                                - TextUtils.ToDecimal(LibIE.ExcuteScalar(sql2 + " and C_DTCP_MA like '" + fcmCode + "%' and [C_Year] = " + year + " and [C_Month] = " + c.ColumnName.Replace("T_", "")));
                        }
                    }
                }
            }

            foreach (DataColumn c in _dtData.Columns)
            {
                if (c.ColumnName == "NamTruoc" || c.ColumnName.StartsWith("T_"))
                {
                    _dtData.Rows[2][c.ColumnName] = TextUtils.ToDecimal(_dtData.Rows[0][c.ColumnName]) + TextUtils.ToDecimal(_dtData.Rows[1][c.ColumnName]);
                }
            }

            #region Lấy chi phí lãi vay thực tế của dự án
            DataRow[] drsLaiVay = _dtData.Select("STT = 8");

            foreach (DataRow r in drsLaiVay)
            {
                r["NamTruoc"] = TextUtils.ToDecimal(dtLaiVay.Compute("SUM(LaiGop)", "C_Month <= 12 and C_Year = " + (year - 1)));
                foreach (DataRow row in dtMonth.Rows)
                {
                    int p = TextUtils.ToInt(row["C_Month"]);
                    decimal cLai = TextUtils.ToDecimal(dtLaiVay.Compute("SUM(LaiGop)", "C_Month = " + p + " and C_Year = " + year));
                    r["T_" + p] = cLai;
                }
            }
            #endregion

            _dtData.Columns.Add("LuyKe", typeof(decimal), exp);
            _dtData.Columns.Add("ChenhLech", typeof(decimal), "C_Value - (" + exp + ")");

            //_dtData.Columns["PK_ID"].Caption = "PK_ID";
            _dtData.Columns["Code"].Caption = "STT";
            _dtData.Columns["Name"].Caption = "Tên";
            //_dtData.Columns["GroupCode"].Caption = "Nhóm";
            _dtData.Columns["C_Value"].Caption = "Tổng tiền";
            _dtData.Columns["NamTruoc"].Caption = "Năm trước";
            _dtData.Columns["LuyKe"].Caption = "Lũy kế";
            _dtData.Columns["ChenhLech"].Caption = "Chênh lệch (DK-TT)";

            grvData.PopulateColumns(_dtData);
            grdData.DataSource = _dtData;

            grvData.Columns["STT"].Visible = false;
            grvData.Columns["SqlText1"].Visible = false;
            grvData.Columns["SqlText2"].Visible = false;

            for (int i = 4; i < _dtData.Columns.Count; i++)
            {
                grvData.Columns[i].DisplayFormat.FormatType = FormatType.Numeric;
                grvData.Columns[i].DisplayFormat.FormatString = "n0";
            }

            grvData.BestFitColumns();

            grvData.Columns["Code"].Fixed = FixedStyle.Left;
            grvData.Columns["Name"].Fixed = FixedStyle.Left;
            //grvData.Columns["SqlText1"].Fixed = FixedStyle.Left;
            //grvData.Columns["SqlText2"].Fixed = FixedStyle.Left;
            //grvData.Columns["Group"].Fixed = FixedStyle.Left;
            grvData.Columns["C_Value"].Fixed = FixedStyle.Left;
            grvData.Columns["NamTruoc"].Fixed = FixedStyle.Left;

            grvData.Columns["Group"].GroupIndex = 0;
            grvData.Columns["Group"].Visible = false;

            grvData.Columns["LuyKe"].AppearanceCell.BackColor = Color.Yellow;
            grvData.Columns["ChenhLech"].AppearanceCell.BackColor = Color.YellowGreen;

            grvData.Columns["LuyKe"].SummaryItem.FieldName = "LuyKe";
            grvData.Columns["LuyKe"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            grvData.Columns["LuyKe"].SummaryItem.DisplayFormat = "{0:n0}";

            grvData.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "LuyKe", grvData.Columns["LuyKe"], "{0:n0}");
            grvData.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "NamTruoc", grvData.Columns["NamTruoc"], "{0:n0}");
            foreach (DataRow row in dtMonth.Rows)
            {
                string p = TextUtils.ToString(row["C_Month"]);
                grvData.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "T_" + p, grvData.Columns["T_" + p], "{0:n0}");
                grvData.Columns["T_" + p].Width = 90;
            }
            grvData.Columns["NamTruoc"].Width = 100;
            grvData.Columns["Code"].Width = 80;
            grvData.Columns["LuyKe"].Width = 200;

            grvData.ExpandAllGroups();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load dữ liệu..."))
            {
                loadData();
            }
        }

        private void btnExecl_Click(object sender, EventArgs e)
        {
            TextUtils.ExportExcel(grvData);
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
                catch (Exception)
                {
                }
            }
        }
    }
}
