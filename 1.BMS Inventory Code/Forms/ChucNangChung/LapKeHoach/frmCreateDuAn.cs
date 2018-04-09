using BMS.Business;
using BMS.Model;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
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
    public partial class frmCreateDuAn : _Forms
    {
        public frmCreateDuAn()
        {
            InitializeComponent();
        }

        #region Event
        private void btnNew_Click(object sender, EventArgs e)
        {
            grvData.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            PageBase.StateButton(true, btnNew, btnEdit, btnSave, btnCancel, btnDelete);
            PageBase.VisibleColumnInGrid(grvData, true);
            Global_Add.sFormStatus = Global_Add.FormStatus.Addnew;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            PageBase.StateButton(true, btnNew, btnEdit, btnSave, btnCancel, btnDelete);
            PageBase.VisibleColumnInGrid(grvData, true);
            Global_Add.sFormStatus = Global_Add.FormStatus.Edit;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
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
                            ProjectSynBO.Instance.Delete(IDs);
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
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Variable

        DataTable m_DataSource = new DataTable();
        #endregion

        #region Method
        public void Save(ref DataTable dt)
        {
            grvData.FocusedRowHandle = -1;
            DataTable dtRemine;
            dtRemine = dt.GetChanges();
            if (dtRemine != null)
            {
                foreach (DataRow item in dtRemine.Rows)
                {
                    ProjectSynModel model = new ProjectSynModel();

                    model.ProjectId = item["ProjectId"].ToString();
                   // model.CustomerId = item["CustomerId"].ToString();
                    model.ProjectName = item["ProjectName"].ToString();
                    model.ProjectCode = item["ProjectCode"].ToString();
                    model.TimeMake = TextUtils.ToInt(item["TimeMake"].ToString());
                    model.DateFinishE =TextUtils.ToDate(item["DateFinishE"].ToString());
                    model.DateFinishF = TextUtils.ToDate(item["DateFinishF"].ToString());
                    model.Note = item["Note"].ToString();
                    model.Status = TextUtils.ToInt(item["Status"].ToString());
                    //model.ProjectType = null;
                    //model.DateCreate = TextUtils.ToDate(item["DateCreate"].ToString());
                    //model.StatusDisable = item["StatusDisable"].ToString();
                   // model.UserId = item["UserId"].ToString();
                    model.DateSingingContract = TextUtils.ToDate(item["DateSingingContract"].ToString());
                   // model.ID = item["ID"].ToString();
                    if (item["ID"] == DBNull.Value) //add new)
                    {
                        ProjectSynBO.Instance.Insert(model);
                    }
                    else
                    {
                        model.ID = Convert.ToInt32(item["ID"].ToString());
                        ProjectSynBO.Instance.Update(model);
                    }
                }
            }

        }
        public void SelectAll(ref DataTable dt, GridControl grd)
        {
         //string k=   ProjectSynBO.Instance.GenerateNo3("ProjectId");
         //string l = "1";
            dt = TextUtils.Select("SELECT * FROM ProjectSyn");
            if (dt == null)
            {
                dt = ProjectSynBO.KhoiTaoGrid();
            }
            grdData.DataSource = dt;
        }
        #endregion
        public void Genera(string h)
        {
            //ProjectSynBO.Instance.GenerateNo3
        }
        private void frmCreateDuAn_Load(object sender, EventArgs e)
        {
            PageBase.StateButton(false, btnNew, btnEdit, btnSave, btnCancel, btnDelete);
            PageBase.VisibleColumnInGrid(grvData, false);
            SelectAll(ref m_DataSource, grdData);
        }

        private void grvData_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            if (ProjectSynBO.Instance.CheckExist("ProjectCode", grvData.GetRowCellValue(e.RowHandle, colProjectCode).ToString()))
            {
                e.Valid = false;
            }
        }

    }
}