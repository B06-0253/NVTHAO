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
    public partial class frmReportChiPhi_FCM : _Forms
    {
        public frmReportChiPhi_FCM()
        {
            InitializeComponent();
        }

        private void frmReportChiPhi_FCM_Load(object sender, EventArgs e)
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

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load dữ liệu..."))
            {
                string fcmCode = TextUtils.ToString(cboFCM.EditValue);
                txtTotalVT.EditValue = LibQLSX.ExcuteScalar("select sum( isnull(TotalBuy,0) * isnull(Price,0))  FROM [vRequirePartFull_Order] where ProjectCode = '" + fcmCode + "' and isnull([OrderCode],'')<>''");
                int year = TextUtils.ToInt(cboYear.SelectedItem);
                //int month = cboMonth.SelectedIndex;

                DataTable dtLaiVay = loadLaiVay(fcmCode);

                string sqlStart = "SELECT a.PK_ID, a.C_MA, a.C_MOTA, a.[GroupCode] +'-'+ a.[GroupName] as [GroupCode]";
                string sqlEnd = " FROM V_DM_KMP a where isnull([FK_GROUP],0) > 0";
                string sql = ",[C_Value] = isnull((select sum([C_PRICE]) from [V_DM_FCM_DETAIL] where [C_CODE] like '" + fcmCode + "%' and [C_KMP_MA] = a.C_MA),0)";

                DataTable dtMonth = LibIE.Select("select distinct [C_Month] from [V_XNTC_REPORT_ALL] where [C_DTCP_MA] like '" + fcmCode + "%'"
                                            //+ " and (FK_TKNO like '154%' or FK_TKNO like '6321%' or FK_TKNO like '642%' or FK_TKNO like '521%' or FK_TKNO like '635%' or FK_TKCO like '131%' or [FK_TKNO] like '331%')"
                                            + " and [C_YEAR] = " + year);

                sql += " ,[Total_NamTruoc] = isnull((SELECT sum([C_PSNO]) FROM [V_XNTC_REPORT_ALL]"
                                + " where [C_DTCP_MA] = '" + fcmCode + "' "
                                + " and (FK_TKNO like '154%' or FK_TKNO like '6321%' or FK_TKNO like '642%' or FK_TKNO like '521%' or FK_TKNO like '635%')"
                                + " and [C_KMP_MA] = a.C_MA "
                                + " and [C_Year] < " + year + "),0)";

                string exp = "Total_NamTruoc";
                foreach (DataRow row in dtMonth.Rows)
                {
                    string p = TextUtils.ToString(row["C_Month"]);
                    sql += " ,[T_" + p + "] = isnull((SELECT sum([C_PSNO]) FROM [V_XNTC_REPORT_ALL]"
                                + " where [C_DTCP_MA] like '" + fcmCode + "%' "
                                + " and (FK_TKNO like '154%' or FK_TKNO like '6321%' or FK_TKNO like '642%' or FK_TKNO like '521%' or FK_TKNO like '635%')"
                                + " and [C_KMP_MA] = a.C_MA "
                                + " and [C_Year] = " + year
                                + " and [C_Month] = " + p + "),0) ";
                    exp += "+ T_" + p;
                }

                string str = sqlStart + sql + sqlEnd;
                DataTable dtData = LibIE.Select(str);

                #region Nhập chi phí vật tư thực tế của dự án
                DataRow[] drsVT = dtData.Select("C_MA = 'C27' or C_MA = 'C20' or C_MA = 'C24' or C_MA = 'C22'");
                foreach (DataRow r in drsVT)
                {
                    string kmpCode = TextUtils.ToString(r["C_MA"]);
                    foreach (DataRow row in dtMonth.Rows)
                    {
                        string p = TextUtils.ToString(row["C_Month"]);
                        string sql1 = "SELECT sum([C_PSNO]) FROM [V_XNTC_REPORT_ALL]"
                                    + " where [C_DTCP_MA] like '" + fcmCode + "%' "
                                    + " and (FK_TKNO like '154%' or FK_TKNO like '6321%' or FK_TKNO like '642%' or FK_TKNO like '521%' or FK_TKNO like '635%')"
                                    + " and [C_KMP_MA] = '" + kmpCode + "'"
                                    + " and [C_Year] = " + year
                                    + " and [C_Month] = " + p;

                        string sql2 = "SELECT sum([C_PSNO]) FROM [V_XNTC_REPORT_ALL]"
                                    + " where [C_DTCP_MA_LUU] like '" + fcmCode + "%' "
                                    + " and (FK_TKNO = '154' AND  FK_TKNO = '154')"
                                    //+ " and [C_KMP_MA] = '" + kmpCode + "'"
                                    + " and [C_Year] = " + year
                                    + " and [C_Month] = " + p;

                        r["T_" + p] = TextUtils.ToDecimal(LibIE.ExcuteScalar(sql1)) + TextUtils.ToDecimal(LibIE.ExcuteScalar(sql2));
                    }
                }
                #endregion

                #region Nhập chi phí lãi vay thực tế của dự án
                DataRow[] drsLaiVay = dtData.Select("C_MA = 'C11'");
              
                foreach (DataRow r in drsLaiVay)
                {
                    string kmpCode = TextUtils.ToString(r["C_MA"]);
                    foreach (DataRow row in dtMonth.Rows)
                    {
                        int p = TextUtils.ToInt(row["C_Month"]);
                        decimal cLai = TextUtils.ToDecimal(dtLaiVay.Compute("SUM(LaiGop)", "C_Month = " + p + " and C_Year = " + year));
                        r["T_" + p] = cLai;
                    }
                }
                #endregion
                
                DataColumnCollection columns = dtData.Columns;

                DataTable dtFCM = LibIE.Select("select top 1 * from T_DM_FCM where C_CODE = '" + fcmCode + "'");
                if (dtFCM.Rows.Count > 0)
                {
                    #region Add column
                    DataRow dr1 = dtData.NewRow();
                    dr1["PK_ID"] = 0;
                    dr1["C_MA"] = "T1";
                    dr1["C_MOTA"] = "DT.Giá bán trên HĐ";
                    dr1["GroupCode"] = "";
                    dr1["C_Value"] = TextUtils.ToDecimal(dtFCM.Rows[0]["TotalHD"]);
                    if (columns.Contains("Total_NamTruoc")) dr1["Total_NamTruoc"] = 0;
                    dtData.Rows.Add(dr1);

                    DataRow dr2 = dtData.NewRow();
                    dr2["PK_ID"] = 0;
                    dr2["C_MA"] = "T2";
                    dr2["C_MOTA"] = "DT.Giá bán theo quy định TPA";
                    dr2["GroupCode"] = "";
                    dr2["C_Value"] = TextUtils.ToDecimal(dtFCM.Rows[0]["TotalTPA"]);
                    if (columns.Contains("Total_NamTruoc")) dr2["Total_NamTruoc"] = 0;
                    dtData.Rows.Add(dr2);

                    DataRow dr3 = dtData.NewRow();
                    dr3["PK_ID"] = 0;
                    dr3["C_MA"] = "T3";
                    dr3["C_MOTA"] = "DT.Thuế GTGT";
                    dr3["GroupCode"] = "";
                    dr3["C_Value"] = TextUtils.ToDecimal(dtFCM.Rows[0]["TotalVAT"]);
                    if (columns.Contains("Total_NamTruoc")) dr3["Total_NamTruoc"] = 0;
                    dtData.Rows.Add(dr3);

                    DataRow dr4 = dtData.NewRow();
                    dr4["PK_ID"] = 0;
                    dr4["C_MA"] = "T4";
                    dr4["C_MOTA"] = "DT.Giá thực thu";
                    dr4["GroupCode"] = "";
                    dr4["C_Value"] = TextUtils.ToDecimal(dtFCM.Rows[0]["TotalReal"]);
                    if (columns.Contains("Total_NamTruoc")) dr4["Total_NamTruoc"] = 0;
                    dtData.Rows.Add(dr4);

                    DataRow dr5 = dtData.NewRow();
                    dr5["PK_ID"] = 0;
                    dr5["C_MA"] = "T5";
                    dr5["C_MOTA"] = "DT.Tổng chi phí triển khai DA tại Khách Hàng";
                    dr5["GroupCode"] = "";
                    dr5["C_Value"] = TextUtils.ToDecimal(dtFCM.Rows[0]["TotalTrienKhai"]);
                    if (columns.Contains("Total_NamTruoc")) dr5["Total_NamTruoc"] = 0;
                    dtData.Rows.Add(dr5);

                    DataRow dr6 = dtData.NewRow();
                    dr6["PK_ID"] = 0;
                    dr6["C_MA"] = "T6";
                    dr6["C_MOTA"] = "DT.Tổng chi phí nhân công trực tiếp";
                    dr6["GroupCode"] = "";
                    dr6["C_Value"] = TextUtils.ToDecimal(dtFCM.Rows[0]["TotalNC"]);
                    if (columns.Contains("Total_NamTruoc")) dr6["Total_NamTruoc"] = 0;
                    dtData.Rows.Add(dr6);

                    DataRow dr7 = dtData.NewRow();
                    dr7["PK_ID"] = 0;
                    dr7["C_MA"] = "T7";
                    dr7["C_MOTA"] = "DT.Tổng chi phí quản lí phân bổ";
                    dr7["GroupCode"] = "";
                    dr7["C_Value"] = TextUtils.ToDecimal(dtFCM.Rows[0]["TotalPB"]);
                    if (columns.Contains("Total_NamTruoc")) dr7["Total_NamTruoc"] = 0;
                    dtData.Rows.Add(dr7);

                    DataRow dr8 = dtData.NewRow();
                    dr8["PK_ID"] = 0;
                    dr8["C_MA"] = "T8";
                    dr8["C_MOTA"] = "DT.Chi phí bổ xung";
                    dr8["GroupCode"] = "";
                    dr8["C_Value"] = TextUtils.ToDecimal(dtFCM.Rows[0]["TotalBX"]);
                    if (columns.Contains("Total_NamTruoc")) dr8["Total_NamTruoc"] = 0;
                    dtData.Rows.Add(dr8);

                    DataRow dr9 = dtData.NewRow();
                    dr9["PK_ID"] = 0;
                    dr9["C_MA"] = "T9";
                    dr9["C_MOTA"] = "DT.Loi Nhuan";
                    dr9["GroupCode"] = "";
                    dr9["C_Value"] = TextUtils.ToDecimal(dtFCM.Rows[0]["TotalProfit"]);
                    if (columns.Contains("Total_NamTruoc")) dr9["Total_NamTruoc"] = 0;
                    dtData.Rows.Add(dr9);
                    #endregion
                }
                DataRow[] drsTong = dtData.Select("C_MA like 'T%'","C_MA ASC");

                #region Update Tổng
                foreach (DataRow r in drsTong)
                {
                    foreach (DataRow row in dtMonth.Rows)
                    {
                        string p = TextUtils.ToString(row["C_Month"]);
                        decimal totalTrienKhai = 0;
                        decimal totalPB = 0;
                        decimal totalReal = 0;

                        if (TextUtils.ToString(r["C_MA"]) == "T4")
                        {
                            string sql1 = "SELECT sum([C_PSNO]) FROM [V_XNTC_REPORT_ALL]"
                                        + " where [C_DTCP_MA] like '%" + fcmCode + "%' "
                                        + " and (FK_TKCO like '511%')"
                                        //+ " and [C_KMP_MA] in ('C13','C52','C03','C38','C39','C40','C43','C04','C41','C42','C46','C05','C44','C45')"
                                        + " and [C_Year] = " + year
                                        + " and [C_Month] = " + p;
                            string sql2 = "SELECT sum([C_PSNO]) FROM [V_XNTC_REPORT_ALL]"
                                        + " where [C_DTCP_MA] like '%" + fcmCode + "%' "
                                        + " and (FK_TKNO like '521%')"
                                        //+ " and [C_KMP_MA] in ('C13','C52','C03','C38','C39','C40','C43','C04','C41','C42','C46','C05','C44','C45')"
                                        + " and [C_Year] = " + year
                                        + " and [C_Month] = " + p;
                            r["T_" + p] = totalReal = TextUtils.ToDecimal(LibIE.ExcuteScalar(sql1)) - TextUtils.ToDecimal(LibIE.ExcuteScalar(sql2));
                        }
                        else if (TextUtils.ToString(r["C_MA"]) == "T5")
                        {
                            string sql1 = "SELECT sum([C_PSNO]) FROM [V_XNTC_REPORT_ALL]"
                                        + " where [C_DTCP_MA] like '%" + fcmCode + "%' "
                                        + " and (FK_TKNO like '154%' or FK_TKNO like '6321%' or FK_TKNO like '642%' or FK_TKNO like '521%' or FK_TKNO like '635%')"
                                        + " and [C_KMP_MA] in ('C13','C52','C03','C38','C39','C40','C43','C04','C41','C42','C46','C05','C44','C45')"
                                        + " and [C_Year] = " + year
                                        + " and [C_Month] = " + p;
                            r["T_" + p] = totalTrienKhai = TextUtils.ToDecimal(LibIE.ExcuteScalar(sql1));
                        }
                        else if (TextUtils.ToString(r["C_MA"]) == "T7")
                        {
                            string sql1 = "SELECT sum([C_PSNO]) FROM [V_XNTC_REPORT_ALL]"
                                        + " where [C_DTCP_MA] like '%" + fcmCode + "%' "
                                        + " and (FK_TKNO like '154%' or FK_TKNO like '6321%' or FK_TKNO like '642%' or FK_TKNO like '521%' or FK_TKNO like '635%')"
                                        + " and [C_KMP_MA] in ('C09P01','C09P03','C09P05','C09P06','C09P08','C09P09','C09P13','C09P14','C09P16','C09P20','C09P23'"
                                                                + ",'C07','C12','C01','C06','C02','C17','C16','C32','C51','C47','C48',"
                                                                + "'C50','C54','C55','C57','C10','C23','C25','C26','C11','C19','C31','C30','C53','C29','C33')"
                                        + " and [C_Year] = " + year
                                        + " and [C_Month] = " + p;
                            r["T_" + p] = totalPB = TextUtils.ToDecimal(LibIE.ExcuteScalar(sql1));
                        }
                        else if (TextUtils.ToString(r["C_MA"]) == "T9")
                        {
                            string sqlReal1 = "SELECT sum([C_PSNO]) FROM [V_XNTC_REPORT_ALL]"
                                        + " where [C_DTCP_MA] like '%" + fcmCode + "%' "
                                        + " and (FK_TKCO like '511%')"
                                //+ " and [C_KMP_MA] in ('C13','C52','C03','C38','C39','C40','C43','C04','C41','C42','C46','C05','C44','C45')"
                                        + " and [C_Year] = " + year
                                        + " and [C_Month] = " + p;
                            string sqlReal2 = "SELECT sum([C_PSNO]) FROM [V_XNTC_REPORT_ALL]"
                                        + " where [C_DTCP_MA] like '%" + fcmCode + "%' "
                                        + " and (FK_TKNO like '521%')"
                                //+ " and [C_KMP_MA] in ('C13','C52','C03','C38','C39','C40','C43','C04','C41','C42','C46','C05','C44','C45')"
                                        + " and [C_Year] = " + year
                                        + " and [C_Month] = " + p;
                            string sqlTrienKhai = "SELECT sum([C_PSNO]) FROM [V_XNTC_REPORT_ALL]"
                                        + " where [C_DTCP_MA] like '%" + fcmCode + "%' "
                                        + " and (FK_TKNO like '154%' or FK_TKNO like '6321%' or FK_TKNO like '642%' or FK_TKNO like '521%' or FK_TKNO like '635%')"
                                        + " and [C_KMP_MA] in ('C13','C52','C03','C38','C39','C40','C43','C04','C41','C42','C46','C05','C44','C45')"
                                        + " and [C_Year] = " + year
                                        + " and [C_Month] = " + p;
                            string sqlPB = "SELECT sum([C_PSNO]) FROM [V_XNTC_REPORT_ALL]"
                                        + " where [C_DTCP_MA] like '%" + fcmCode + "%' "
                                        + " and (FK_TKNO like '154%' or FK_TKNO like '6321%' or FK_TKNO like '642%' or FK_TKNO like '521%' or FK_TKNO like '635%')"
                                        + " and [C_KMP_MA] in ('C09P01','C09P03','C09P05','C09P06','C09P08','C09P09','C09P13','C09P14','C09P16','C09P20','C09P23'"
                                                                + ",'C07','C12','C01','C06','C02','C17','C16','C32','C51','C47','C48',"
                                                                + "'C50','C54','C55','C57','C10','C23','C25','C26','C11','C19','C31','C30','C53','C29','C33')"
                                        + " and [C_Year] = " + year
                                        + " and [C_Month] = " + p;
                            string sqlNhanCong = "SELECT sum([C_PSNO]) FROM [V_XNTC_REPORT_ALL]"
                                        + " where [C_DTCP_MA] like '%" + fcmCode + "%' "
                                        + " and (FK_TKNO like '154%' or FK_TKNO like '6321%' or FK_TKNO like '642%' or FK_TKNO like '521%' or FK_TKNO like '635%')"
                                        + " and [C_KMP_MA] in ('C09','C09P01','C09P07','C09P10','C09P11','C09P12','C09P17','C15','C34','C35','C36')"
                                        + " and [C_Year] = " + year
                                        + " and [C_Month] = " + p;
                            string sqlVT = "SELECT sum([C_PSNO]) FROM [V_XNTC_REPORT_ALL]"
                                        + " where [C_DTCP_MA] like '%" + fcmCode + "%' "
                                        + " and (FK_TKNO like '154%' or FK_TKNO like '6321%' or FK_TKNO like '642%' or FK_TKNO like '521%' or FK_TKNO like '635%')"
                                        + " and [C_KMP_MA] in ('C27','C20','C24','C22')"
                                        + " and [C_Year] = " + year
                                        + " and [C_Month] = " + p;
                            decimal totalLoiNhuan = TextUtils.ToDecimal(LibIE.ExcuteScalar(sqlReal1)) - TextUtils.ToDecimal(LibIE.ExcuteScalar(sqlReal2)) - TextUtils.ToDecimal(LibIE.ExcuteScalar(sqlNhanCong)) 
                                - TextUtils.ToDecimal(LibIE.ExcuteScalar(sqlPB)) - TextUtils.ToDecimal(LibIE.ExcuteScalar(sqlTrienKhai)) - 0 - TextUtils.ToDecimal(LibIE.ExcuteScalar(sqlVT));
                            r["T_" + p] = totalLoiNhuan;
                        }
                        else
                        {
                            r["T_" + p] = 0;
                        }
                    }
                }
                #endregion

                dtData.Columns.Add("LuyKe", typeof(decimal), exp);
                dtData.Columns.Add("ChenhLech", typeof(decimal), "C_Value - (" + exp + ")");

                dtData.Columns["PK_ID"].Caption = "PK_ID";
                dtData.Columns["C_MA"].Caption = "Mã";
                dtData.Columns["C_MOTA"].Caption = "Tên";
                dtData.Columns["GroupCode"].Caption = "Nhóm";
                dtData.Columns["C_Value"].Caption = "Tổng tiền";
                dtData.Columns["Total_NamTruoc"].Caption = "Năm trước";
                dtData.Columns["LuyKe"].Caption = "Lũy kế";
                dtData.Columns["ChenhLech"].Caption = "Chênh lệch (DK-TT)";

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
                grvData.Columns[3].Fixed = FixedStyle.Left;
                grvData.Columns[4].Fixed = FixedStyle.Left;

                grvData.Columns["LuyKe"].AppearanceCell.BackColor = Color.Yellow;
                grvData.Columns["ChenhLech"].AppearanceCell.BackColor = Color.YellowGreen;
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
