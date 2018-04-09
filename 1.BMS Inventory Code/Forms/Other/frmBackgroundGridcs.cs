using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

namespace BMS
{
    public partial class frmBackgroundGrid : _Forms
    {
        DataTable dtData = null;
        DateTime _pStart = new DateTime(2015, 1, 1);
        DateTime _pEnd = new DateTime(2015, 2, 1);

        List<DateInfo> allDates = new List<DateInfo>();

        public class DateInfo
        {
            public DateTime ThisDate { get; set; }
            public string DayInWeek { get; set; }
        }

        public frmBackgroundGrid()
        {
            InitializeComponent();
        }

        private void frmBackgroundGrid_Load(object sender, EventArgs e)
        {
            dtData = new DataTable();
            dtData.Columns.Add("STT");
            dtData.Columns.Add("Name");
            dtData.Columns.Add("Author");
            dtData.Columns.Add("StartDate", typeof(DateTime));
            dtData.Columns.Add("FinishDate", typeof(DateTime));
            dtData.Columns.Add("CellsNumber");
            dtData.Columns.Add("Space");

            dtData.Rows.Add("1", "Chỉnh sửa bản vẽ 3D", "Phòng TK", new DateTime(2015, 1, 1), new DateTime(2015, 1, 8), 8, 0);
            dtData.Rows.Add("2", "Canon đặt hàng", "Phòng Dự án", new DateTime(2015, 1, 9), new DateTime(2015, 1, 13), 5, 8);
            dtData.Rows.Add("3", "Đặt hàng thiết bị", "Phòng vật tư", new DateTime(2015, 1, 14), new DateTime(2015, 1, 15), 2, 13);

            dtData.Merge(dtData.Copy());

            gridControl1.DataSource = dtData.Select("", "STT asc").CopyToDataTable();
            gridView1.BestFitColumns();
        }

        private void gridView1_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            //if (e.Column.FieldName == "Name")
            //{
            //    GridView view = sender as GridView;
            //    string val1 = (string)view.GetRowCellValue(e.RowHandle1, e.Column);
            //    string val2 = (string)view.GetRowCellValue(e.RowHandle2, e.Column);
            //    e.Merge = val1 == val2;
            //    e.Handled = true;
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
