using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using BMS.Utils;
using BMS.Model;
using BMS.Business;

namespace BMS
{
    public partial class frmVatTuThayThe : _Forms
    {

        #region Variables
        int _type = 0;
        #endregion

        #region Constructors and Load
        public frmVatTuThayThe()
        {
            InitializeComponent();
        }
        
        private void frmVatTuThayThe_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = TextUtils.Select("select * from vCheckPermission where Code ='frmVatTuThayThe_Edit' and UserID=" + Global.UserID);
                if (dt.Rows.Count > 0)
                {
                    grvData.OptionsBehavior.Editable = true;
                }
                else
                {
                    grvData.OptionsBehavior.Editable = false;
                }
            }
            catch (Exception)
            {                  
            }            

            cboBang.SelectedIndex = 0;
        } 
        #endregion

        #region Funcitions
        private void LoadGrid()
        {
            try
            {
                DataTable tbl = TextUtils.Select("SELECT * FROM VatTuThayThe WHERE (Type =" + _type + ") ORDER BY STT");
                if (tbl==null)
                {
                    tbl = TextUtils.Select("SELECT * FROM VatTuThayThe ORDER BY STT");
                }
                grdData.DataSource = tbl;
                grvData.BestFitColumns();
            }
            catch (Exception ex)
            {
                TextUtils.ShowError(ex);
            }
        } 
        #endregion

        #region Event

        private void grvData_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;

            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();

            VatTuThayTheModel Model = new VatTuThayTheModel();

            Model.STT = TextUtils.ToInt(grvData.GetRowCellValue(e.RowHandle, "STT").ToString());
            Model.Ngay = TextUtils.ToDate(grvData.GetRowCellValue(e.RowHandle, "Ngay").ToString());
            Model.NameTK = grvData.GetRowCellValue(e.RowHandle, "NameTK").ToString();
            Model.NameTT = grvData.GetRowCellValue(e.RowHandle, "NameTT").ToString();
            Model.CodeTK = grvData.GetRowCellValue(e.RowHandle, "CodeTK").ToString();
            Model.CodeTT = grvData.GetRowCellValue(e.RowHandle, "CodeTT").ToString();
            Model.HangTK = grvData.GetRowCellValue(e.RowHandle, "HangTK").ToString();
            Model.HangTT = grvData.GetRowCellValue(e.RowHandle, "HangTT").ToString();
            Model.ThuocThietBi = grvData.GetRowCellValue(e.RowHandle, "ThuocThietBi").ToString();
            Model.ChiTietLienQuan = grvData.GetRowCellValue(e.RowHandle, "ChiTietLienQuan").ToString();
            Model.Status = grvData.GetRowCellValue(e.RowHandle, "Status").ToString();
            Model.CodeAfter = grvData.GetRowCellValue(e.RowHandle, "CodeAfter").ToString();
            Model.Note = grvData.GetRowCellValue(e.RowHandle, "Note").ToString();
            Model.Type = _type;
            //Kiểm tra đây là dòng dữ liệu mới hay cũ, nếu là mới thì mình insert
            if (view.IsNewItemRow(e.RowHandle))
            {                
                try
                {
                    Model.CreatedDate = TextUtils.GetSystemDate();
                    Model.CreatedBy = Global.AppUserName;
                    Model.UpdatedDate = Model.CreatedDate;
                    Model.UpdatedBy = Global.AppUserName;
                    Model.ID = (int)pt.Insert(Model);
                    pt.CommitTransaction();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    pt.CloseConnection();
                }
            }
            //Cũ thì update
            else
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn cập nhật?",TextUtils.Caption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
                        Model.ID = id;
                        Model.UpdatedDate = TextUtils.GetSystemDate();
                        Model.UpdatedBy = Global.AppUserName;
                        pt.Update(Model);
                        pt.CommitTransaction();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        pt.CloseConnection();
                    }
                }
            }
            LoadGrid();
        }
       
        private void btnDeleteGroup_Click(object sender, EventArgs e)
        {
            if (grvData.RowCount>0)
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", TextUtils.Caption, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ProcessTransaction pt = new ProcessTransaction();
                    pt.OpenConnection();
                    pt.BeginTransaction();
                    int id = (int)grvData.GetRowCellValue(grvData.FocusedRowHandle, "ID");
                    pt.Delete("VatTuThayThe", id);
                    pt.CommitTransaction();
                    pt.CloseConnection();

                    LoadGrid();
                }
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvData.RowCount > 0)
                {
                    TextUtils.ExportExcel(grvData);
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboBang_SelectedIndexChanged(object sender, EventArgs e)
        {            
            _type = cboBang.SelectedIndex;
            LoadGrid();
        }       
        #endregion
    }
}