using BMS.Business;
using BMS.Model;
using DevExpress.XtraEditors;
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
    public partial class frmPhanGio : _Forms
    {
        public frmPhanGio()
        {
            InitializeComponent();
        }

        private void frmPhanGio_Load(object sender, EventArgs e)
        {
            SelectAll();
        }
        public int demsongaylamviec(int thang, int nam)
        {
            int dem = 0;
            DateTime f = new DateTime(nam, thang, 01);
            int x = f.Month + 1;
            while (f.Month < x)
            {
                dem = dem + 1;
                if (f.DayOfWeek == DayOfWeek.Sunday)
                {
                    dem = dem - 1;
                }
                f = f.AddDays(1);
            }
            return dem;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            label1.Text = monthCalendar1.SelectionEnd.ToShortDateString();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    Convert.ToDateTime(label1.Text);
                }
                catch (Exception)
                {
                    XtraMessageBox.Show("Bạn phải click chọn ngày trước khi thêm mới");
                    return;
                }
                
                DataTable df = TextUtils.Select("SELECT NgayNghi FROM NgayNghi WITH (NOLOCK) WHERE NgayNghi = '" + (monthCalendar1.SelectionEnd).ToString("yyyy/MM/dd") + " 23:59:59.000'");
                if (df == null || df.Rows.Count > 0)
                {
                    XtraMessageBox.Show("Ngày này đã có trong cơ sở dữ liệu");
                    return;
                }
                NgayNghiModel model = new NgayNghiModel();
                model.NgayNghi = monthCalendar1.SelectionEnd;
                NgayNghiBO.Instance.Insert(model);
                SelectAll();
            }
            catch (Exception)
            {

                throw;
            }
        }
        void SelectAll()
        {
            grdData.DataSource = NgayNghiBO.Instance.FindAll();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvData.FocusedRowHandle < 0)
                {
                    XtraMessageBox.Show("Không có mẫu tin nào để xóa", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
                if (grvData.GetSelectedRows().Count() < 0)
                {
                    return;
                }
                int IDs = Convert.ToInt32(grvData.GetRowCellValue(grvData.FocusedRowHandle, colID).ToString());
                if (XtraMessageBox.Show("Bạn có chắc xóa mẫu tin này không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int j = -1;
                    for (int i = grvData.SelectedRowsCount-1; i >=0 ; i--)
                    {
                        if (grvData.GetSelectedRows()[i] >= 0)
                            j = grvData.GetSelectedRows()[i];
                        if (j >= 0)
                        {
                            
                            NgayNghiBO.Instance.Delete(IDs);
                        }
                    }
                    SelectAll();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
