using BMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Model;
using BMS.Business;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System.IO;

namespace BMS
{
    public partial class frmTheoDoiImportExcel : Form
    {
        private string NgayLap="";
        public frmTheoDoiImportExcel()
        {
            InitializeComponent();
        }
        #region Funcitions

        DataTable ExcelToDatatable(string filename, string sheetName)
        {
            DataTable dt = new DataTable();
            string connString = "";
            connString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 12.0;", filename);
            OleDbConnection conn1 = new OleDbConnection();
            conn1.ConnectionString = connString;
            try
            {
                conn1.Open();
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM [" + sheetName + "$]", conn1);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];

            }
            catch (Exception)
            {
            }
            finally
            {
                conn1.Close();
            }

            return dt;
        }
        List<string> GetListExcelSheetName(string filename)
        {
            List<string> lst = new List<string>();

            Microsoft.Office.Interop.Excel.Application UserExcel = new Microsoft.Office.Interop.Excel.Application();
            UserExcel.Workbooks.Open(filename);

            foreach (Microsoft.Office.Interop.Excel.Worksheet worksheet in UserExcel.Worksheets)
            {
                lst.Add(worksheet.Name);
            }

            UserExcel.Workbooks.Close();
            UserExcel.Quit();

            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(UserExcel);
            }
            catch (Exception)
            {

            }
            UserExcel = null;
            return lst;
        }
        #endregion

        #region Events

        private void btnBrowse_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (ofd.FileName.Contains("xls"))
                {
                    btnBrowse.Text = ofd.FileName;
                    NgayLap = File.GetCreationTime(ofd.FileName).ToString();
                    cboStatus.DataSource = null;
                    cboStatus.DataSource = TextUtils.ListSheetInExcel(ofd.FileName);
                }
                else
                {
                    MessageBox.Show("Không phải là file Excel");
                    return;
                }
            }
        }

        private void cboStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (btnBrowse.Text == "") return;
            gridControl1.DataSource = null;

            try
            {
                DataTable dt = TextUtils.ExcelToDatatable(btnBrowse.Text, cboStatus.SelectedValue.ToString());

                if (dt.Rows.Count <= 0) return;

                dt.Columns[0].ColumnName = "STT";
                dt.Columns[1].ColumnName = "TenVatTu";
                dt.Columns[2].ColumnName = "MaVatTu";
                dt.Columns[3].ColumnName = "Hang";
                dt.Columns[4].ColumnName = "DonVi";
                dt.Columns[5].ColumnName = "SoLuong";
                dt.Columns[6].ColumnName = "ThongSo";
                dt.Columns[7].ColumnName = "NgayVeDuKien";
                dt.Columns[8].ColumnName = "GhiChu";
                dt.Columns.Add("TenDuAn");
                dt.Columns.Add("MaDuAn");
                string re = dt.Rows[4][2].ToString();
                string te = dt.Rows[4][4].ToString();
                for (int i = 8; i >= 0; i--)
                {
                    dt.Rows.RemoveAt(i);
                }
                //linq lấy các dòng mà code khác rỗng và khác null
                dt = (from order in dt.AsEnumerable()
                      where order.Field<string>("TenVatTu") != "" && order.Field<string>("TenVatTu") != null
                      select order).CopyToDataTable();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dt.Rows[i]["TenDuAn"] = re;
                        dt.Rows[i]["MaDuAn"] = te;
                    }
                }
                gridControl1.DataSource = dt;


                DataTable dt1 = new DataTable();
                foreach (GridColumn colum in gridView1.VisibleColumns)
                {
                    dt1.Columns.Add(colum.FieldName, colum.ColumnType);
                }
                for (int i = 0; i < gridView1.DataRowCount; i++)
                {
                    DataRow row = dt1.NewRow();
                    foreach (GridColumn colum in gridView1.VisibleColumns)
                    {
                        row[colum.FieldName] = gridView1.GetRowCellValue(i, colum);

                    }
                    dt1.Rows.Add(row);
                }
                dt = dt1;
                #region Tinh ngay thuc te
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow row = dt.Rows[i];
                        if (row["NgayYeuCau"].ToString().Trim() != "")
                        {
                            if (row["NgayThucTe"].ToString().Trim() != "")
                            {
                                DateTime ngaymuon = Convert.ToDateTime(row["NgayYeuCau"]);
                                DateTime ngaytra = Convert.ToDateTime(row["NgayThucTe"]);
                                TimeSpan tim = ngaytra - ngaymuon;
                                row["ThoiGianDatHangThucTe"] = tim.Days.ToString();
                            }

                        }
                    }
                }
                #endregion
                gridControl1.DataSource = dt;
                gridView1.BestFitColumns();
                gridControl1.Focus();
            }
            catch (Exception ex)
            {
                TextUtils.ShowError(ex);
            }
        }
        private void grvData_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (e.Value == null)
            {
                return;
            }
            try
            {
                if (grvData.FocusedColumn == colSoLuong)
                {
                    if (Convert.ToInt32(e.Value) < 0)
                    {
                        e.ErrorText = "Số lượng phải lớn hơn hoặc bằng 0";
                        e.Valid = false;
                    }
                }
            }
            catch (Exception ex)
            {
                e.ErrorText = "Số lượng phải lớn hơn hoặc bằng 0";
                e.Valid = false;
            }
        }
        private void grvData_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    if (View.GetRowCellValue(e.RowHandle, colNgayVeDuKien).ToString().Trim() != "")
                    {
                        if (View.GetRowCellValue(e.RowHandle, colNgayThucTe).ToString().Trim() != "")
                        {

                            DateTime ngaymuon = Convert.ToDateTime(View.GetRowCellValue(e.RowHandle, colNgayVeDuKien));
                            DateTime ngaytra = Convert.ToDateTime(View.GetRowCellValue(e.RowHandle, colNgayThucTe));
                            TimeSpan tim = ngaytra - ngaymuon;
                            if (tim.Days > 0 && e.Column == colNguyenNhanCham)
                            {
                                e.Appearance.BackColor = Color.Yellow;
                            }

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                return;
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            //for (int i = 0; i < gridView1.GetSelectedRows().Count(); i++)
            //{
            //    string ff = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], colHang).ToString();
            //}
            //DataTable dt2 = new DataTable();
            //foreach (GridColumn colum in gridView1.VisibleColumns)
            //{
            //    dt2.Columns.Add(colum.FieldName, colum.ColumnType);
            //}
            //for (int i = 0; i < gridView1.GetSelectedRows().Count(); i++)
            //{
            //    DataRow row = dt2.NewRow();
            //    foreach (GridColumn colum in gridView1.VisibleColumns)
            //    {
            //        row[colum.FieldName] = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[i], colum);
            //    }
            //    dt2.Rows.Add(row);
            //}
            //return;
            try
            {
                DataTable dt = new DataTable();
                foreach (GridColumn colum in gridView1.VisibleColumns)
                {
                    dt.Columns.Add(colum.FieldName, colum.ColumnType);
                }
                for (int i = 0; i < gridView1.DataRowCount; i++)
                {
                    DataRow row = dt.NewRow();
                    foreach (GridColumn colum in gridView1.VisibleColumns)
                    {
                        row[colum.FieldName] = gridView1.GetRowCellValue(i, colum);

                    }
                    dt.Rows.Add(row);
                }

                DataTable dtRemine = dt;

                if (dtRemine != null)
                {
                    for (int i = 0; i < dtRemine.Rows.Count; i++)
                    {
                        YeuCauVatTuModel model = new YeuCauVatTuModel();
                        model.UserID = Global.UserID;
                        model.TenVatTu = dtRemine.Rows[i]["TenVatTu"].ToString();
                        model.MaVatTu = dtRemine.Rows[i]["MaVatTu"].ToString();
                        model.Hang = dtRemine.Rows[i]["Hang"].ToString();
                        model.MaSP = dtRemine.Rows[i]["MaSP"].ToString();
                        model.TenDuAn = dtRemine.Rows[i]["TenDuAn"].ToString();
                        model.MaDuAn = dtRemine.Rows[i]["MaDuAn"].ToString();//["MaDuAn"].ToString();
                        model.SoLuong = dtRemine.Rows[i]["SoLuong"].ToString();
                        model.NgayYeuCau = NgayLap;//["NgayYeuCau"].ToString();
                        model.NgayVeDuKien = ""; //(dtRemine.Rows[i]["NgayVeDuKien"].ToString());//["NgayVeDuKien"].ToString();
                        model.NgayThucTe = "";// (dtRemine.Rows[i]["NgayThucTe"].ToString());//["NgayThucTe"].ToString();
                        model.ThoiGianDatHangTHucTe = dtRemine.Rows[i]["ThoiGianDatHangTHucTe"].ToString();//["ThoiGianDatHangTHucTe"].ToString();
                        model.NguyenNhanCham = dtRemine.Rows[i]["NguyenNhanCham"].ToString();//["NguyenNhanCham"].ToString();
                        model.GhiChu = dtRemine.Rows[i]["GhiChu"].ToString();

                        YeuCauVatTuBO.Instance.Insert(model);
                    }
                }
                MessageBox.Show("Nhập dữ liệu từ file Excel thành công", "Thông báo");
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboStatus_SelectionChangeCommitted(null, null);
        } 
        #endregion

    }
}
