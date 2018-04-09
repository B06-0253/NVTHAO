using DevExpress.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPA.Business;

namespace BMS
{
    public partial class frmListPartOfModule : _Forms
    {
        public string ProjectModuleId = "";
        public string ModuleCode = "";
        public decimal TotalReal = 0;
        public string ProjectId = "";
        public string STT = "";
        public frmListPartOfModule()
        {
            InitializeComponent();
        }

        private void frmListPartOfModule_Load(object sender, EventArgs e)
        {
            this.Text += ": " + ModuleCode;
            loadGrid();
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Location = new Point(this.Location.X, 0);
        }

        void loadGrid()
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load dữ liệu..."))
            {
                string sql = "";
                //if (ProjectModuleId == "")
                //{
                //    sql = "select * from SummaryPartsList where [ProjectModuleCode] = '" + ModuleCode + "' and ProjectId = '" + ProjectId + "'";
                //}
                //else
                //{
                    //sql = "select * from SummaryPartsList where [ProjectModuleId] = '" + ProjectModuleId + "'";
                    //string[] _paraName = new string[4];
                    //object[] _paraValue = new object[4];
                    //_paraName[0] = "@ProjectCode"; _paraValue[0] = ProjectId;
                    //_paraName[1] = "@Status"; _paraValue[1] = 0;
                    //_paraName[2] = "@ProjectModuleId"; _paraValue[2] = ProjectModuleId;
                    //_paraName[3] = "@IndexPart"; _paraValue[3] = STT;

                    sql = "spGetPartOfProject '" + ProjectId + "'," + 0 + ",'" + ProjectModuleId + "','" + STT + "'";
                //}
                //if (STT != "")
                //{
                //    sql += " and IndexPart like '" + STT + ".%'";
                //}

                DataTable dt = LibQLSX.Select(sql);
                //DataTable dt = PartsBO.Instance.LoadDataFromSP("spGetPartOfProject", "Source", _paraName, _paraValue);
                DataColumn column1 = new DataColumn();
                column1.DataType = System.Type.GetType("System.Decimal");
                column1.ColumnName = "TotalReal";
                column1.Expression = "Total * " + TotalReal;
                dt.Columns.Add(column1);
                grdData.DataSource = dt;
            }
        }

        private void grvData_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            decimal slMua = TextUtils.ToDecimal(grvData.GetRowCellValue(e.RowHandle, gridColumn11));
            decimal slDaVe = TextUtils.ToDecimal(grvData.GetRowCellValue(e.RowHandle, gridColumn12));
            int status = TextUtils.ToInt(grvData.GetRowCellValue(e.RowHandle, colStatus));
            string thongSo = TextUtils.ToString(grvData.GetRowCellValue(e.RowHandle, colSpecifications));
            string dateEnd = TextUtils.ToString(grvData.GetRowCellDisplayText(e.RowHandle, gridColumn18));
            string orderCode = TextUtils.ToString(grvData.GetRowCellValue(e.RowHandle, colOrderCode));
            if ((slMua > slDaVe && status > 1 && thongSo != "TPA") || (dateEnd == "" && orderCode != ""))
            {
                e.Appearance.BackColor = Color.Yellow;
            }
        }
    }
}
