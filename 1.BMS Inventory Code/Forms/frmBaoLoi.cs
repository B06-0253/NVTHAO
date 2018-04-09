using BMS.Business;
using BMS.Model;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
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

namespace BMS
{
    public partial class frmBaoLoi : _Forms
    {
        DataTable m_DataSource = new DataTable();
        private static string sPath = @"\\server\Public\Tuan2\file Bao Loi Phan Mem\"; 
        public frmBaoLoi()
        {
            InitializeComponent();
        }

        private void frmBaoLoi_Load(object sender, EventArgs e)
        {
            //LoadData();
            SelectAll(ref m_DataSource, grdData); 
            PageBase.StateButton(false, btnNew, btnEdit, btnSave, btnCancel, btnDelete);
            PageBase.VisibleColumnInGrid(grvData, false);
        }

        #region Methods
        void LoadData()
        {
            DataTable dt = TextUtils.Select("select * from BaoLoi");
            if (dt == null)
            {
                BaoLoiBO.KhoiTaoGrid();
            }

        }
        public void SelectAll(ref DataTable dt, GridControl grd)
        {
            try
            {
                //if (searchLookUpEdit1.EditValue != null)
                {
                    dt = TextUtils.Select("SELECT * FROM BaoLoi ORDER BY TinhTrangKhacPhuc");
                    if (dt==null|| dt.Rows.Count <= 0)
                    {
                        dt = BaoLoiBO.KhoiTaoGrid();
                    }
                    grdData.DataSource = dt;
                }
            }
            catch (Exception)
            {
                throw;
            }
            //leWeek_EditValueChanged(null, null);
        }
        public static void Save(ref DataTable dt)
        {
            DataTable dtRemine;
            dtRemine = dt.GetChanges();
            if (dtRemine != null)
            {
                foreach (DataRow item in dtRemine.Rows)
                {
                    BaoLoiModel model = new BaoLoiModel();

                    model.VanDe = item["VanDe"].ToString();
                    model.HangMuc = item["HangMuc"].ToString();
                    model.YeuCau = item["YeuCau"].ToString();
                    model.MucDoUuTien = item["MucDoUuTien"].ToString();
                    model.TinhTrangLoi = item["TinhTrangLoi"].ToString();
                    model.FileDinhKem =Path.GetFileName(item["FileDinhKem"].ToString());
                    if (item["FileDinhKem"].ToString().Contains("\\"))
                    {
                        File.Copy(item["FileDinhKem"].ToString(), sPath+model.FileDinhKem,true);
                    }
                    if (item["ID"] == DBNull.Value) //add new)
                    {
                        model.NguoiPhatHien = Global.AppFullName;
                        model.NgayYeuCau = (DateTime.Now);
                        BaoLoiBO.Instance.Insert(model);
                    }
                    else
                    {
                        model.NgayYeuCau = Convert.ToDateTime(item["NgayYeuCau"].ToString());
                        model.TinhTrangKhacPhuc =(item["TinhTrangKhacPhuc"].ToString());
                        model.NguoiKhacPhuc = item["NguoiKhacPhuc"].ToString();
                        //model.NgayKhacPhucXong = TextUtils.ToDate(item["NgayKhacPhucXong"].ToString());
                        model.ID = Convert.ToInt32(item["ID"].ToString());
                        BaoLoiBO.Instance.Update(model);
                    }
                }
            }
        } 
        #endregion

        #region Events
        private void btnNew_Click(object sender, EventArgs e)
        {
            grvData.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            PageBase.StateButton(true, btnNew, btnEdit, btnSave, btnCancel, btnDelete);
            PageBase.VisibleColumnInGrid(grvData, true);
            Global_Add.sFormStatus = Global_Add.FormStatus.Addnew;
            colTinhTrangKhacPhuc.OptionsColumn.AllowFocus = false;
            //colNgayKhacPhucXong.OptionsColumn.AllowFocus = false;
            colNguoiKhacPhuc.OptionsColumn.AllowFocus = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            PageBase.StateButton(true, btnNew, btnEdit, btnSave, btnCancel, btnDelete);
            PageBase.VisibleColumnInGrid(grvData, true);
            Global_Add.sFormStatus = Global_Add.FormStatus.Edit;
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
                {
                    if (XtraMessageBox.Show("Bạn có chắc xóa mẫu tin này không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        {
                            int IDs = Convert.ToInt32(grvData.GetRowCellValue(grvData.FocusedRowHandle, colID).ToString());
                          
                            BaoLoiBO.Instance.Delete(IDs);
                            SelectAll(ref m_DataSource, grdData);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            grvData.FocusedRowHandle = -1;
            Save(ref m_DataSource);
            {
                grvData.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                PageBase.StateButton(false, btnNew, btnEdit, btnSave, btnCancel, btnDelete);
                PageBase.VisibleColumnInGrid(grvData, false);
                Global_Add.sFormStatus = Global_Add.FormStatus.View;
                SelectAll(ref m_DataSource, grdData);
            }
        }
     
        private void btnCancel_Click(object sender, EventArgs e)
        {
            SelectAll(ref m_DataSource, grdData);
            PageBase.StateButton(false, btnNew, btnEdit, btnSave, btnCancel, btnDelete);
            PageBase.VisibleColumnInGrid(grvData, false);
            grvData.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion

        private void btnFileDinhKem_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                grvData.SetFocusedRowCellValue(colFileDinhKem,ofd.FileName);
                
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvData.FocusedRowHandle < 0)
                    return;
                if (File.Exists(sPath + grvData.GetFocusedRowCellValue(colFileDinhKem)))
                {
                    Process.Start(sPath + grvData.GetFocusedRowCellValue(colFileDinhKem));
                }
                else
                    XtraMessageBox.Show("Không tồn tại file này trên hệ thống");
            }
            catch (Exception)
            {
                throw;
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
                if (grvData.FocusedColumn == colTinhTrangKhacPhuc)
                {
                    if (Convert.ToInt32(e.Value) < 0||Convert.ToInt32(e.Value) >1)
                    {
                        e.ErrorText = "Chọn số 0 hoặc 1";
                        e.Valid = false;
                    }
                }
            }
            catch (Exception ex)
            {
                e.ErrorText = "Chọn số 0 hoặc 1";
                e.Valid = false;
            }
        }
    }
}
