using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Data.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BMS.Business;
using BMS.Model;
using BMS.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid;

namespace BMS
{
    public partial class frmCreateThongSoVT : _Forms
    {
        #region Variable
        DataTable _dt;
        bool isAdd;
        bool isAddN;
        GridHitInfo downHitInfo = null;
        GridHitInfo downHitInfoN = null;
        #endregion

        #region Contructor and Load
        public frmCreateThongSoVT()
        {
            InitializeComponent();
        }

        private void frmCreateThongSoVT_Load(object sender, EventArgs e)
        {
            loadCombo();
            loadGroup();
            btnNew_Click(null, null);
            btnAddValue_Click(null, null);
            btnNewN_Click(null, null);
        }
        #endregion

        #region Thông số đích

        #region Method

        void loadCombo()
        {
            try
            {
                DataTable tbl = TextUtils.Select("Select * from vMaterialGroup with(nolock) order by Code");
                TextUtils.PopulateCombo(cboMaterialGroup, tbl, "Name", "ID", "");
            }
            catch (Exception ex)
            {
            }
        }

        private bool checkValid()
        {
            int groupID = TextUtils.ToInt(cboMaterialGroup.EditValue);

            if (groupID == 0)
            {
                MessageBox.Show("Bạn hãy chọn nhóm vật tư.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (txtName.Text == "")
            {
                MessageBox.Show("Bạn hãy điền tên thông số.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            DataTable dt;

            if (!isAdd)
            {
                int strID = TextUtils.ToInt(grvData.GetRowCellValue(grvData.FocusedRowHandle, "ID").ToString());
                dt = TextUtils.Select("select Name from MaterialParameters where MaterialGroupID =" + groupID + " and REPLACE(Name,' ','') = N'" + txtName.Text.Trim().Replace(" ", "") + "' and ID <> " + strID);
            }
            else
            {
                dt = TextUtils.Select("select Name from MaterialParameters where MaterialGroupID =" + groupID + " and REPLACE(Name,' ','') = N'" + txtName.Text.Trim().Replace(" ", "") + "'");
            }
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Tên thông số này đã tồn tại!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
            }

            return true;
        }

        void loadGridParas(string paraName = "")
        {
            try
            {
                if (paraName == "")
                {
                    _dt = TextUtils.Select(" select * from MaterialParameters with(nolock) where MaterialGroupID =" + TextUtils.ToInt(cboMaterialGroup.EditValue) + " Order by STT");
                }
                else
                {
                    _dt = TextUtils.Select(" select * from MaterialParameters with(nolock) where MaterialGroupID =" + TextUtils.ToInt(cboMaterialGroup.EditValue) + " and Name like N'%" + paraName + "%' Order by STT");
                }
                grdData.DataSource = _dt;
            }
            catch (Exception)
            {
                grdData.DataSource = null;
            }
        }

        private void ClearInterface()
        {
            txtName.Text = "";
            //leParentCat.EditValue = null;
        }

        private void SetInterface(bool isEdit)
        {
            btnSave.Visible = isEdit;
            btnCancel.Visible = isEdit;

            btnNew.Visible = !isEdit;
            btnEdit.Visible = !isEdit;
            btnDelete.Visible = !isEdit;
        }

        #endregion

        private void cboMaterialGroup_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboMaterialGroup.EditValue != null)
                {
                    loadGridParas();
                }
            }
            catch (Exception ex)
            {
                TextUtils.ShowError(ex);
            }
        }        

        private void btnNew_Click(object sender, EventArgs e)
        {
            SetInterface(true);
            isAdd = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!grvData.IsDataRow(grvData.FocusedRowHandle))
                return;
            SetInterface(true);
            isAdd = false;
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            MaterialParametersModel model = (MaterialParametersModel)MaterialParametersBO.Instance.FindByPK(id);
            txtName.Text = model.Name;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!grvData.IsDataRow(grvData.FocusedRowHandle))
                return;

            int strID = TextUtils.ToInt(grvData.GetRowCellValue(grvData.FocusedRowHandle, "ID").ToString());

            string strName = grvData.GetRowCellValue(grvData.FocusedRowHandle, "Name").ToString();

            if (MessageBox.Show(String.Format("Bạn có chắc muốn xóa thông số [{0}] không?", strName), TextUtils.Caption, MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question) == DialogResult.No) return;
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();
            try
            {
                pt.Delete("MaterialParameters", strID);
                loadGridParas();
                pt.DeleteByAttribute("MaterialConnect", "MaterialParameterID", strID.ToString());
                pt.DeleteByAttribute("MaterialParameterValue", "MaterialParameterID", strID.ToString());

                pt.CommitTransaction();
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra khi thực hiện thao tác, xin vui lòng thử lại sau.");
            }
            finally
            {
                pt.CloseConnection();
            }
            
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();
            try
            {
                if (checkValid())
                {
                    MaterialParametersModel model = new MaterialParametersModel();

                    if (isAdd)
                    {
                        model.CreatedDate = TextUtils.GetSystemDate();
                        model.CreatedBy = Global.AppUserName;
                        model.UpdatedDate = model.CreatedDate;
                        model.UpdatedBy = Global.AppUserName;
                    }
                    else
                    {
                        int ID = Convert.ToInt32(grvData.GetFocusedRowCellValue(colID).ToString());
                        model = (MaterialParametersModel)MaterialParametersBO.Instance.FindByPK(ID);                        
                        model.UpdatedDate = model.CreatedDate;
                        model.UpdatedBy = Global.AppUserName;
                    }

                    model.Name = txtName.Text;
                    model.MaterialGroupID = TextUtils.ToInt(cboMaterialGroup.EditValue);

                    if (isAdd)
                    {
                        DataTable dt = TextUtils.Select("SELECT isnull(MAX(STT),0) FROM MaterialParameters with(nolock) where MaterialParameters.MaterialGroupID = " + model.MaterialGroupID);
                        model.STT = TextUtils.ToInt(dt.Rows[0][0].ToString()) + 1;
                        pt.Insert(model);
                    }
                    else
                    {
                        pt.Update(model);
                    }

                    pt.CommitTransaction();

                    loadGridParas();
                    SetInterface(false);
                    cboMaterialGroup.Enabled = true;
                    ClearInterface();
                }
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetInterface(false);
            ClearInterface();
        }

        private void grdData_DoubleClick(object sender, EventArgs e)
        {
            if (grvData.RowCount > 0 && btnEdit.Enabled == true)
                btnEdit_Click(null, null);
        }

        #region Move row by drap and drop
        private void MoveRow(int sourceRow, int targetRow)
        {
            if (sourceRow <= targetRow)
                return;

            int sourceID = TextUtils.ToInt(grvData.GetRowCellValue(sourceRow, colID));
            MaterialParametersModel sourceModel = (MaterialParametersModel)MaterialParametersBO.Instance.FindByPK(sourceID);
            sourceModel.STT = targetRow;
            MaterialParametersBO.Instance.Update(sourceModel);

            for (int i = 0; i < grvData.RowCount; i++)
            {
                if (i < targetRow || i == sourceRow || i > sourceRow) continue;

                int id = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                MaterialParametersModel model = (MaterialParametersModel)MaterialParametersBO.Instance.FindByPK(id);
                model.STT = i + 1;
                MaterialParametersBO.Instance.Update(model);
            }
            loadGridParas();
        }

        private void grdData_DragDrop(object sender, DragEventArgs e)
        {
            DataRow row = e.Data.GetData(typeof(DataRow)) as DataRow;
            if (row == null)
            {
                GridControl grid = sender as GridControl;
                GridView view = grid.MainView as GridView;
                GridHitInfo srcHitInfo = e.Data.GetData(typeof(GridHitInfo)) as GridHitInfo;
                GridHitInfo hitInfo = view.CalcHitInfo(grid.PointToClient(new Point(e.X, e.Y)));
                int sourceRow = srcHitInfo.RowHandle;
                int targetRow = hitInfo.RowHandle;
                MoveRow(sourceRow, targetRow);
            }
            else
            {

            }            
        }

        private void grdData_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(GridHitInfo)))
            {
                GridHitInfo downHitInfo = e.Data.GetData(typeof(GridHitInfo)) as GridHitInfo;
                if (downHitInfo == null)
                    return;

                GridControl grid = sender as GridControl;
                GridView view = grid.MainView as GridView;
                GridHitInfo hitInfo = view.CalcHitInfo(grid.PointToClient(new Point(e.X, e.Y)));
                if (hitInfo.InRow && hitInfo.RowHandle != downHitInfo.RowHandle && hitInfo.RowHandle != GridControl.NewItemRowHandle)
                    e.Effect = DragDropEffects.Move;
                else
                    e.Effect = DragDropEffects.None;
            }
        }

        private void grvData_MouseDown(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            downHitInfo = null;

            GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
            if (Control.ModifierKeys != Keys.None)
                return;
            if (e.Button == MouseButtons.Left && hitInfo.InRow && hitInfo.RowHandle != GridControl.NewItemRowHandle)
                downHitInfo = hitInfo;
        }
        
        private void grvData_MouseMove(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Button == MouseButtons.Left && downHitInfo != null)
            {
                Size dragSize = SystemInformation.DragSize;
                Rectangle dragRect = new Rectangle(new Point(downHitInfo.HitPoint.X - dragSize.Width / 2,
                    downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);

                if (!dragRect.Contains(new Point(e.X, e.Y)))
                {
                    view.GridControl.DoDragDrop(downHitInfo, DragDropEffects.All);
                    downHitInfo = null;
                }
            }
        }
        #endregion

        #endregion

        #region Value

        bool _isAddValue = false;
        MaterialParameterValueModel _model = new MaterialParameterValueModel();

        void loadGridValue()
        {            
            int groupID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (groupID <= 0) return;
            DataTable dt = TextUtils.Select("MaterialParameterValue", new Expression("MaterialParameterID", groupID));
            try
            {
                grdValue.DataSource = dt.Select().OrderBy(o => o["ParaValue"]).CopyToDataTable();
            }
            catch (Exception)
            {
                grdValue.DataSource = dt;
            }        
            txtValue.Text = "";
        }

        private void SetInterfaceValue(bool isEdit)
        {
            btnSaveValue.Visible = isEdit;
            btnCancelValue.Visible = isEdit;

            btnNewValue.Visible = !isEdit;
            btnEditValue.Visible = !isEdit;
            btnDeleteValue.Visible = !isEdit;
        }

        private void btnAddValue_Click(object sender, EventArgs e)
        {
            _isAddValue = true;
            txtName.Text = "";
            _model = new MaterialParameterValueModel();
            SetInterfaceValue(true);
        }

        private void btnEditValue_Click(object sender, EventArgs e)
        {
            if (grvValue.FocusedRowHandle < 0) return;
            _isAddValue = false;
            int iD = TextUtils.ToInt(grvValue.GetFocusedRowCellValue(colIDValue));
            _model = (MaterialParameterValueModel)MaterialParameterValueBO.Instance.FindByPK(iD);
            txtValue.Text = _model.ParaValue;
            SetInterfaceValue(true);
        }

        private void btnDeleteValue_Click(object sender, EventArgs e)
        {
            if (grvData.FocusedRowHandle >= 0)
            {
                DialogResult result = MessageBox.Show("Bạn có thật sự muốn xóa nhứng file này không?", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int iD = TextUtils.ToInt(grvValue.GetFocusedRowCellValue(colIDValue));
                    MaterialParameterValueBO.Instance.Delete(iD);
                    loadGridValue();
                }
            }
        }

        private void btnSaveValue_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtValue.Text == "")
                {
                    MessageBox.Show("Bạn hãy nhập giá trị!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                int groupID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));

                if (groupID == 0)
                {
                    MessageBox.Show("Bạn hãy chọn một thông số!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                _model.MaterialParameterID = groupID;
                _model.ParaValue = txtValue.Text.Trim();

                if (_isAddValue)
                {
                    MaterialParameterValueBO.Instance.Insert(_model);
                }
                else
                {
                    MaterialParameterValueBO.Instance.Update(_model);
                }
                loadGridValue();
                SetInterfaceValue(false);
                //MessageBox.Show("Tạo giá trị thông số thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                TextUtils.ShowError(ex);
            }
        }

        private void btnCancelValue_Click(object sender, EventArgs e)
        {
            SetInterfaceValue(false);
            txtValue.Text = "";
        }

        private void grvData_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            loadGridValue();
        }
        #endregion

        #region Thông số nguồn
        void loadGroup()
        {
            try
            {
                DataTable tbl = TextUtils.Select("Select * from vMaterialGroup with(nolock) order by Code");
                TextUtils.PopulateCombo(cboMaterialGroupN, tbl, "Name", "ID", "");
            }
            catch (Exception ex)
            {
            }
        }

        private bool checkValidN()
        {

            int groupID = TextUtils.ToInt(cboMaterialGroupN.EditValue);

            if (groupID == 0)
            {
                MessageBox.Show("Bạn hãy chọn nhóm vật tư.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (txtNameN.Text == "")
            {
                MessageBox.Show("Bạn hãy điền tên thông số.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            DataTable dt;

            if (!isAddN)
            {
                int strID = TextUtils.ToInt(grvDataN.GetRowCellValue(grvDataN.FocusedRowHandle, "ID").ToString());
                dt = TextUtils.Select("select Name from MaterialParameters where MaterialGroupID =" + groupID + " and Name = N'" + txtNameN.Text.Trim() + "' and ID <> " + strID);
            }
            else
            {
                dt = TextUtils.Select("select Name from MaterialParameters where MaterialGroupID =" + groupID + " and Name = N'" + txtNameN.Text.Trim() + "'");
            }
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Tên thông số này đã tồn tại!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
            }

            return true;
        }

        void loadGridParasN()
        {
            try
            {
                _dt = TextUtils.Select(" select * from MaterialParameters with(nolock) where MaterialGroupID =" + TextUtils.ToInt(cboMaterialGroupN.EditValue) + " Order by STT");
                grdDataN.DataSource = _dt;
            }
            catch (Exception)
            {
                grdDataN.DataSource = null;
            }
        }

        private void ClearInterfaceN()
        {
            txtNameN.Text = "";
        }

        private void SetInterfaceN(bool isEdit)
        {
            btnSaveN.Visible = isEdit;
            btnCancelN.Visible = isEdit;

            btnNewN.Visible = !isEdit;
            btnEditN.Visible = !isEdit;
            btnDeleteN.Visible = !isEdit;
        }

        private void cboMaterialGroupN_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboMaterialGroupN.EditValue != null)
                {
                    loadGridParasN();
                }
            }
            catch (Exception ex)
            {
                TextUtils.ShowError(ex);
            }
        }

        private void btnNewN_Click(object sender, EventArgs e)
        {
            SetInterfaceN(true);
            isAddN = true;
        }

        private void btnEditN_Click(object sender, EventArgs e)
        {
            if (!grvDataN.IsDataRow(grvDataN.FocusedRowHandle))
                return;
            SetInterfaceN(true);
            isAddN = false;
            int id = TextUtils.ToInt(grvDataN.GetFocusedRowCellValue(colID));
            MaterialParametersModel model = (MaterialParametersModel)MaterialParametersBO.Instance.FindByPK(id);
            txtNameN.Text = model.Name;
        }

        private void btnDeleteN_Click(object sender, EventArgs e)
        {
            if (!grvDataN.IsDataRow(grvDataN.FocusedRowHandle))
                return;

            int strID = TextUtils.ToInt(grvDataN.GetRowCellValue(grvDataN.FocusedRowHandle, "ID").ToString());

            string strName = grvDataN.GetRowCellValue(grvDataN.FocusedRowHandle, "Name").ToString();

            if (MessageBox.Show(String.Format("Bạn có chắc muốn xóa thông số [{0}] không?", strName), TextUtils.Caption, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No) return;
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();
            try
            {
                pt.Delete("MaterialParameters", strID);
                loadGridParasN();
                pt.DeleteByAttribute("MaterialConnect", "MaterialParameterID", strID.ToString());
                pt.DeleteByAttribute("MaterialParameterValue", "MaterialParameterID", strID.ToString());

                pt.CommitTransaction();
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra khi thực hiện thao tác, xin vui lòng thử lại sau.");
            }
            finally
            {
                pt.CloseConnection();
            }
        }

        private void btnSaveN_Click(object sender, EventArgs e)
        {
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();
            try
            {
                if (checkValidN())
                {
                    MaterialParametersModel model = new MaterialParametersModel();

                    if (isAddN)
                    {
                        model.CreatedDate = TextUtils.GetSystemDate();
                        model.CreatedBy = Global.AppUserName;
                        model.UpdatedDate = model.CreatedDate;
                        model.UpdatedBy = Global.AppUserName;
                    }
                    else
                    {
                        int ID = Convert.ToInt32(grvDataN.GetFocusedRowCellValue(colID).ToString());
                        model = (MaterialParametersModel)MaterialParametersBO.Instance.FindByPK(ID);
                        model.UpdatedDate = model.CreatedDate;
                        model.UpdatedBy = Global.AppUserName;
                    }

                    model.Name = txtNameN.Text;
                    model.MaterialGroupID = TextUtils.ToInt(cboMaterialGroupN.EditValue);

                    if (isAddN)
                    {
                        DataTable dt = TextUtils.Select("SELECT isnull(MAX(STT),0) FROM MaterialParameters with(nolock) where MaterialParameters.MaterialGroupID = " + model.MaterialGroupID);
                        model.STT = TextUtils.ToInt(dt.Rows[0][0].ToString()) + 1;
                        pt.Insert(model);
                    }
                    else
                    {
                        pt.Update(model);
                    }

                    pt.CommitTransaction();

                    loadGridParasN();
                    SetInterfaceN(false);
                    cboMaterialGroupN.Enabled = true;
                    ClearInterfaceN();
                }
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

        private void btnCancelN_Click(object sender, EventArgs e)
        {
            SetInterfaceN(false);
            ClearInterfaceN();
        }

        #region Gridcontrol Events
        private void MoveRowN(int sourceRow, int targetRow)
        {
            if (sourceRow <= targetRow)
                return;

            int sourceID = TextUtils.ToInt(grvDataN.GetRowCellValue(sourceRow, colID));
            MaterialParametersModel sourceModel = (MaterialParametersModel)MaterialParametersBO.Instance.FindByPK(sourceID);
            sourceModel.STT = targetRow;
            MaterialParametersBO.Instance.Update(sourceModel);

            for (int i = 0; i < grvDataN.RowCount; i++)
            {
                if (i < targetRow || i == sourceRow || i > sourceRow) continue;

                int id = TextUtils.ToInt(grvDataN.GetRowCellValue(i, colID));
                MaterialParametersModel model = (MaterialParametersModel)MaterialParametersBO.Instance.FindByPK(id);
                model.STT = i + 1;
                MaterialParametersBO.Instance.Update(model);
            }
            loadGridParasN();
        }

        private void grdDataN_DragDrop(object sender, DragEventArgs e)
        {
            GridControl grid = sender as GridControl;
            GridView view = grid.MainView as GridView;
            GridHitInfo srcHitInfo = e.Data.GetData(typeof(GridHitInfo)) as GridHitInfo;
            GridHitInfo hitInfo = view.CalcHitInfo(grid.PointToClient(new Point(e.X, e.Y)));
            int sourceRow = srcHitInfo.RowHandle;
            int targetRow = hitInfo.RowHandle;
            MoveRowN(sourceRow, targetRow);

            //DataRow row = e.Data.GetData(typeof(DataRow)) as DataRow;
            //string name = row[1].ToString();

            //try
            //{

            //}
            //catch (Exception)
            //{

            //}
        }

        private void grdDataN_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(GridHitInfo)))
            {
                GridHitInfo downHitInfo = e.Data.GetData(typeof(GridHitInfo)) as GridHitInfo;
                if (downHitInfo == null)
                    return;

                GridControl grid = sender as GridControl;
                GridView view = grid.MainView as GridView;
                GridHitInfo hitInfo = view.CalcHitInfo(grid.PointToClient(new Point(e.X, e.Y)));
                if (hitInfo.InRow && hitInfo.RowHandle != downHitInfo.RowHandle && hitInfo.RowHandle != GridControl.NewItemRowHandle)
                    e.Effect = DragDropEffects.Move;
                else
                    e.Effect = DragDropEffects.None;
            }

            //if (e.Data.GetDataPresent(typeof(DataRow)))
            //    e.Effect = DragDropEffects.Move;
            //else
            //    e.Effect = DragDropEffects.None;
        }

        private void grvDataN_MouseDown(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            downHitInfoN = null;

            GridHitInfo hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
            if (Control.ModifierKeys != Keys.None)
                return;
            if (e.Button == MouseButtons.Left && hitInfo.InRow && hitInfo.RowHandle != GridControl.NewItemRowHandle)
                downHitInfoN = hitInfo;
        }

        private void grvDataN_MouseMove(object sender, MouseEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Button == MouseButtons.Left && downHitInfo != null)
            {
                Size dragSize = SystemInformation.DragSize;
                Rectangle dragRect = new Rectangle(new Point(downHitInfo.HitPoint.X - dragSize.Width / 2,
                    downHitInfo.HitPoint.Y - dragSize.Height / 2), dragSize);

                if (!dragRect.Contains(new Point(e.X, e.Y)))
                {
                    view.GridControl.DoDragDrop(downHitInfo, DragDropEffects.All);
                    downHitInfo = null;
                }
            }
            
        }

        private void grdDataN_DoubleClick(object sender, EventArgs e)
        {
            if (grvDataN.RowCount > 0 && btnEditN.Enabled == true)
                btnEditN_Click(null, null);
        }
        #endregion                

        #endregion

        private void btnCopy_Click(object sender, EventArgs e)
        {
            //chuyển thông số nguồn sang đích
            int groupID = TextUtils.ToInt(cboMaterialGroup.EditValue);

            if (groupID == 0)
            {
                MessageBox.Show("Bạn hãy chọn nhóm vật tư.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            foreach (int rowHandle in grvDataN.GetSelectedRows())
            {
                string name = grvDataN.GetRowCellValue(rowHandle, colNameN).ToString();
                DataTable dt;
                dt = TextUtils.Select("select Name from MaterialParameters where MaterialGroupID =" + groupID + " and Name = N'" + name + "'");               
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Tên thông số [" + name + "] này đã tồn tại!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        continue;
                    }
                }

                ProcessTransaction pt = new ProcessTransaction();
                pt.OpenConnection();
                pt.BeginTransaction();
                try
                {                   
                    MaterialParametersModel model = new MaterialParametersModel();

                    model.CreatedDate = TextUtils.GetSystemDate();
                    model.CreatedBy = Global.AppUserName;
                    model.UpdatedDate = model.CreatedDate;
                    model.UpdatedBy = Global.AppUserName;

                    model.Name = grvDataN.GetRowCellValue(rowHandle, colNameN).ToString();
                    model.MaterialGroupID = TextUtils.ToInt(cboMaterialGroup.EditValue);

                    DataTable dtmax = TextUtils.Select("SELECT isnull(MAX(STT),0) FROM MaterialParameters with(nolock) where MaterialParameters.MaterialGroupID = " 
                        + model.MaterialGroupID);
                    model.STT = TextUtils.ToInt(dtmax.Rows[0][0].ToString()) + 1;

                    pt.Insert(model);
                    pt.CommitTransaction();
                    loadGridParas();
                }
                catch (Exception)
                {
                }
                finally 
                {
                    pt.CloseConnection();
                }              
            }
        }

        private void btnCopyN_Click(object sender, EventArgs e)
        {
            //chuyển thông số đích sang nguồns

            int groupID = TextUtils.ToInt(cboMaterialGroupN.EditValue);

            if (groupID == 0)
            {
                MessageBox.Show("Bạn hãy chọn nhóm vật tư.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            foreach (int rowHandle in grvData.GetSelectedRows())
            {
                string name = grvData.GetRowCellValue(rowHandle, colNameN).ToString();
                DataTable dt;
                dt = TextUtils.Select("select Name from MaterialParameters where MaterialGroupID =" + groupID + " and Name = N'" + name + "'");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Tên thông số [" + name + "] này đã tồn tại!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        continue;
                    }
                }

                ProcessTransaction pt = new ProcessTransaction();
                pt.OpenConnection();
                pt.BeginTransaction();
                try
                {
                    MaterialParametersModel model = new MaterialParametersModel();

                    model.CreatedDate = TextUtils.GetSystemDate();
                    model.CreatedBy = Global.AppUserName;
                    model.UpdatedDate = model.CreatedDate;
                    model.UpdatedBy = Global.AppUserName;

                    model.Name = grvData.GetRowCellValue(rowHandle, colNameN).ToString();
                    model.MaterialGroupID = TextUtils.ToInt(cboMaterialGroupN.EditValue);

                    DataTable dtmax = TextUtils.Select("SELECT isnull(MAX(STT),0) FROM MaterialParameters with(nolock) where MaterialParameters.MaterialGroupID = "
                        + model.MaterialGroupID);
                    model.STT = TextUtils.ToInt(dtmax.Rows[0][0].ToString()) + 1;

                    pt.Insert(model);
                    pt.CommitTransaction();
                    loadGridParasN();
                }
                catch (Exception)
                {
                }
                finally
                {
                    pt.CloseConnection();
                }
            }
        }

        private void txtName_EditValueChanged(object sender, EventArgs e)
        {
            if (isAdd)
            {
                string paraName = txtName.Text.Trim();
                loadGridParas(paraName);
            }
        }

    }
}