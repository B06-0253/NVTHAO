using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Model;
using BMS.Business;
using BMS.Utils;

namespace BMS
{
    public partial class frmCostDetail : _Forms
    {
        private bool _isAdd;
        public DataTable dtDetail = new DataTable();

        public frmCostDetail()
        {
            InitializeComponent();
        }

        private void frmCostDetail_Load(object sender, EventArgs e)
        {
            loadDepartment();
            this.Location = new Point(this.Width/2, 0);
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            loadData();
        }

        void loadDepartment()
        {
            DataTable dt = TextUtils.Select("select * from Department with(nolock) order by Name");

            cboDepartment.Properties.DataSource = dt;
            cboDepartment.Properties.DisplayMember = "Name";
            cboDepartment.Properties.ValueMember = "ID";

            repositoryItemGridLookUpEdit1.DataSource = dt;
            repositoryItemGridLookUpEdit1.DisplayMember = "Name";
            repositoryItemGridLookUpEdit1.ValueMember = "ID";
        }

        private void SetInterface(bool isEdit)
        {
            grdData.Enabled = !isEdit;

            btnSave.Visible = isEdit;
            btnCancel.Visible = isEdit;

            btnNew.Visible = !isEdit;
            btnEdit.Visible = !isEdit;
            btnDelete.Visible = !isEdit;
            btnConfirm.Visible = !isEdit;
        }

        private void ClearInterface()
        {
            txtName.Text = "";
            txtCode.Text = "";
            txtDescription.Text = "";
            cboCostType.SelectedIndex = -1;
            chkIsFix.Checked = false;
            cboDepartment.EditValue = null;
        }

        private bool checkValid()
        {
            if (txtCode.Text == "")
            {
                MessageBox.Show("Xin hãy điền mã.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
            {
                DataTable dt;
                if (!_isAdd)
                {
                    int strID = TextUtils.ToInt(grvData.GetRowCellValue(grvData.FocusedRowHandle, "ID").ToString());
                    dt = TextUtils.Select("select Code from CostDetail where Code = '" + txtCode.Text.Trim() + "' and ID <> " + strID);
                }
                else
                {
                    dt = TextUtils.Select("select Code from CostDetail where Code = '" + txtCode.Text.Trim() + "'");
                }
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Mã này đã tồn tại!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }
                }
            }
            if (txtName.Text == "")
            {
                MessageBox.Show("Xin hãy điền tên.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (cboCostType.SelectedIndex<0)
            {
                MessageBox.Show("Xin hãy chọn một loại chi phí.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return true;
        }

        private void loadData()
        {
            try
            {
                DataTable tbl = TextUtils.Select("Select *, case when Type = 0 then N'Chi phí sản xuất' else N'Chi phí thương mại' end as TypeName from CostDetail with(nolock)");
                grdData.DataSource = tbl;
            }
            catch (Exception)
            {
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (grvData.SelectedRowsCount>0)
            {
                foreach (int i in grvData.GetSelectedRows())
                {
                    int detailID = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));

                    DataRow[] dr = dtDetail.Select("CostDetailID = " + detailID);
                    if (dr.Count() > 0) continue;

                    string name = grvData.GetRowCellValue(i, colName).ToString();
                    dtDetail.Rows.Add(0, 0, detailID,name, 0);
                }
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            SetInterface(true);
            _isAdd = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!grvData.IsDataRow(grvData.FocusedRowHandle))
                return;
            SetInterface(true);
            _isAdd = false;

            int ID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            CostDetailModel dModel = (CostDetailModel)CostDetailBO.Instance.FindByPK(ID);

            txtName.Text = dModel.Name;
            txtCode.Text = dModel.Code;
            txtDescription.Text = dModel.Description;
            cboCostType.SelectedIndex = dModel.Type;
            chkIsFix.Checked = dModel.IsFix == 1 ? true : false;
            cboDepartment.EditValue = dModel.DepartmentID;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!grvData.IsDataRow(grvData.FocusedRowHandle))
                return;

            int strID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID).ToString());

            string strName = grvData.GetFocusedRowCellValue(colName).ToString();

            if (CostLinkBO.Instance.CheckExist("CostDetailID", strID))
            {
                MessageBox.Show("Chi phí này đang được sử dụng nên không thể xóa được!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (MessageBox.Show(String.Format("Bạn có chắc muốn xóa [{0}] không?", strName), TextUtils.Caption,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    CostDetailBO.Instance.Delete(Convert.ToInt32(strID));
                    loadData();
                }
                catch
                {
                    MessageBox.Show("Có lỗi xảy ra khi thực hiện thao tác, xin vui lòng thử lại sau.");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();
            try
            {
                if (checkValid())
                {
                    CostDetailModel dModel;
                    if (_isAdd)
                    {
                        dModel = new CostDetailModel();
                    }
                    else
                    {
                        int ID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
                        dModel = (CostDetailModel)CostDetailBO.Instance.FindByPK(ID);
                    }

                    dModel.Code = txtCode.Text.Trim();
                    dModel.Name = txtName.Text.Trim();
                    dModel.Description = txtDescription.Text.Trim();
                    dModel.Type = cboCostType.SelectedIndex;
                    dModel.IsFix = chkIsFix.Checked ? 1 : 0;
                    dModel.DepartmentID = TextUtils.ToInt(cboDepartment.EditValue);

                    if (_isAdd)
                    {
                        pt.Insert(dModel);
                    }
                    else
                    {
                        pt.Update(dModel);
                    }
                    pt.CommitTransaction();
                    loadData();
                    SetInterface(false);
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

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            if (grvData.RowCount > 0 && btnEdit.Enabled == true)
                btnEdit_Click(null, null);
        }
    }
}
