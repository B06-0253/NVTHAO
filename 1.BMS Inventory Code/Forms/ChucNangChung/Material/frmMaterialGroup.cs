using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BMS.Model;
using BMS.Utils;
using BMS.Business;

namespace BMS
{
    public partial class frmMaterialGroup : _Forms
    {
        #region Variables
        public BMS.Model.MaterialGroupModel Model = new MaterialGroupModel();
        public int CurentNode = 0;
        bool _isSaved = false;
        #endregion

        #region Constructors
        public frmMaterialGroup()
        {
            InitializeComponent();
        }

        private void frmMaterialGroup_Load(object sender, EventArgs e)
        {
            loadCombo();
            loadCustomer();
            loadGridCustomer();

            if (Model.ID > 0)
            {
                txtName.Text = Model.Name;
                txtCode.Text = Model.Code;
                txtDescription.Text = Model.Description;
                leParentCat.EditValue = Model.ParentID;
            }
        } 
        #endregion

        #region Functions
        void loadCombo()
        {
            DataTable tbl = TextUtils.Select(@"SELECT ID,Code,Name FROM MaterialGroup WITH(NOLOCK) where ParentID = 0 ORDER BY Code");
            if (tbl == null)
            {
                return;
            }

            DataRow dr = tbl.NewRow();
            dr["Name"] = "--Cấp lớn nhất--";
            dr["ID"] = 0;
            tbl.Rows.InsertAt(dr, 0);

            leParentCat.Properties.DataSource = tbl;
            leParentCat.Properties.DisplayMember = "Name";
            leParentCat.Properties.ValueMember = "ID";
        }

        private bool ValidateForm()
        {
            if (txtCode.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền Mã.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
            {
                DataTable dt = new DataTable();
                if (Model != null)
                {
                    if (Model.ID > 0)
                    {
                        dt = TextUtils.Select("select Code from MaterialGroup where Code = '" + txtCode.Text.Trim() + "' and ID <> " + Model.ID);
                    }
                }
                else
                {
                    dt = TextUtils.Select("select Code from MaterialGroup where Code = '" + txtCode.Text.Trim() + "'");
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
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền Tên.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            //if (TextUtils.ToInt(leParentCat.EditValue)<0)
            //{
            //     MessageBox.Show("Xin hãy chọn nhóm cha.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return false;
            //}
            return true;
        }

        void save(bool close)
        {
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();
            try
            {
                if (!ValidateForm())
                    return;

                if (Model == null)
                {
                    Model = new MaterialGroupModel();
                }
                Model.Name = txtName.Text.Trim().ToUpper();
                Model.Code = txtCode.Text.Trim().ToUpper();
                Model.Description = txtDescription.Text.Trim();
                Model.ParentID = TextUtils.ToInt(leParentCat.EditValue);
                if (Model.ID == 0)
                {
                    Model.ID = (int)pt.Insert(Model);
                }
                else
                {
                    pt.Update(Model);
                }

                if (grvData.RowCount > 0)
                {
                    for (int i = 0; i < grvData.RowCount; i++)
                    {
                        MaterialGroupCustomerLinkModel link = new MaterialGroupCustomerLinkModel();
                        int id = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                        if (id > 0)
                        {
                            link = (MaterialGroupCustomerLinkModel)MaterialGroupCustomerLinkBO.Instance.FindByPK(id);
                        }
                        link.CustomerID = TextUtils.ToInt(grvData.GetRowCellValue(i, colCustomerID));
                        link.MaterialGroupID = Model.ID;
                        if (id > 0)
                        {
                            pt.Update(link);
                        }
                        else
                        {
                            pt.Insert(link);
                        }
                    }
                }

                pt.CommitTransaction();

                _isSaved = true;

                if (close)
                {
                    CurentNode = Model.ID;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    loadGridCustomer();
                    MessageBox.Show("Lưu trữ thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        void loadCustomer()
        {
            try
            {
                DataTable dt = TextUtils.Select("Select * from Customer WITH(NOLOCK)");
                cboCustomer.Properties.DataSource = dt;
                cboCustomer.Properties.DisplayMember = "Code";
                cboCustomer.Properties.ValueMember = "ID";
            }
            catch (Exception)
            {
            }
        }

        DataTable dtHang = new DataTable();
        void loadGridCustomer()
        {
            dtHang = TextUtils.Select("select * from vMaterialGroupCustomerLink where MaterialGroupID = '" + Model.ID + "'");
            grdData.DataSource = dtHang;
        }
        #endregion

        #region Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            save(false);
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            save(true);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (TextUtils.ToInt(cboCustomer.EditValue) == 0)
            {
                MessageBox.Show("Bạn phải chọn một hãng!");
                return;
            }
            DataRow row = dtHang.NewRow();
            row["ID"] = 0;
            row["MaterialGroupID"] = 0;
            row["CustomerID"] = TextUtils.ToInt(cboCustomer.EditValue);
            row["Code"] = cboCustomer.Text;
            dtHang.Rows.Add(row);

            grdData.DataSource = dtHang;
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            int iD = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            string hang = grvData.GetFocusedRowCellValue(colCode).ToString();

            if (MessageBox.Show("Bạn có chắc muốn xóa hãng này không?", TextUtils.Caption,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (iD > 0)
                    {
                        MaterialGroupCustomerLinkBO.Instance.Delete(iD);
                    }

                    grvData.DeleteRow(grvData.FocusedRowHandle);
                }
                catch
                {
                    MessageBox.Show("Có lỗi xảy ra khi thực hiện thao tác, xin vui lòng thử lại sau.");
                }
            }
        }

        private void frmMaterialGroup_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_isSaved)
            {
                CurentNode = Model.ID;
                DialogResult = DialogResult.OK;
            }
        }
        #endregion
    }
}