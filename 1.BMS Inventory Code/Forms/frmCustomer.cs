using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Utils;
using BMS.Business;
using BMS.Model;
using DevExpress.Utils;

namespace BMS
{
    public partial class frmCustomer : _Forms
    {
        private bool _isAdd;
        public bool HasDialogResult = false;

        public frmCustomer()
        {
            InitializeComponent();
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            try
            {
                loadCombo();
                LoadData();
            }
            catch (Exception ex)
            {
                TextUtils.ShowError(ex);
            }
            DocUtils.InitFTPTK();
        }

        #region Methods
        private void SetInterface(bool isEdit)
        {
            txtCode.ReadOnly = !isEdit;

            grdData.Enabled = !isEdit;

            btnSave.Visible = isEdit;
            btnCancel.Visible = isEdit;

            btnNew.Visible = !isEdit;
            btnEdit.Visible = !isEdit;
            btnDelete.Visible = !isEdit;
        }

        private void ClearInterface()
        {
            txtName.Text = "";
            //cboStatus.SelectedIndex = 1;
            txtCode.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            //leHead.EditValue = 0;
        }

        private bool checkValid()
        {
            if (txtCode.Text == "")
            {
                MessageBox.Show("Xin hãy điền mã của Khách hàng.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
            {
                DataTable dt;
                if (!_isAdd)
                {
                    int strID = TextUtils.ToInt(grvData.GetRowCellValue(grvData.FocusedRowHandle, "ID").ToString());
                    dt = TextUtils.Select("select Code from Customer where Code = '" + txtCode.Text.Trim() + "' and ID <> " + strID);
                }
                else
                {
                    dt = TextUtils.Select("select Code from Customer where Code = '" + txtCode.Text.Trim() + "'");
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
                MessageBox.Show("Xin hãy điền tên của Khách hàng.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            //if (cboStatus.SelectedIndex < 0)
            //{
            //    MessageBox.Show("Xin hãy chọn trạng thái của Khách hàng.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return false;
            //}

            return true;
        }

        void loadCombo()
        {
            try
            {
                //load lookupedit
                DataTable tblPerson = TextUtils.Select("Select ID, Code, FullName from Users a with(nolock)");
                //leHead.Properties.DataSource = tblPerson;
                //leHead.Properties.DisplayMember = "FullName";
                //leHead.Properties.ValueMember = "ID";
                //TextUtils.PopulateCombo(leHead, tblPerson.Copy(), "Name", "ID", "-- Chọn trưởng phòng --");
            }
            catch (Exception)
            {
            }
        }

        private void LoadData()
        {
            try
            {
                DataTable tbl = TextUtils.Select("Select a.*, Case when a.Status = 0 then N'Ngừng hoạt động' else N'Hoạt động' end StatusText from Customer a with(nolock)");
                grdData.DataSource = tbl;
            }
            catch (Exception)
            {
            }

        }
        #endregion

        #region Buttons Events
        private void btnNew_Click(object sender, EventArgs e)
        {
            SetInterface(true);
            _isAdd = true;
            //cboStatus.SelectedIndex = 1;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!grvData.IsDataRow(grvData.FocusedRowHandle))
                return;
            SetInterface(true);
            _isAdd = false;

            int ID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            CustomerModel dModel = (CustomerModel)CustomerBO.Instance.FindByPK(ID);

            txtName.Text = dModel.Name;
            txtCode.Text = dModel.Code;
            txtEmail.Text = dModel.Email;
            txtAddress.Text = dModel.Address;
            txtPhone.Text = dModel.Phone;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!grvData.IsDataRow(grvData.FocusedRowHandle))
                return;

            int strID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID).ToString());

            string strName = grvData.GetFocusedRowCellValue(colName).ToString();

            if (MaterialBO.Instance.CheckExist("CustomerID", strID))
            {
                MessageBox.Show("Khách hàng này đang được sử dụng nên không thể xóa được!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (MessageBox.Show(String.Format("Bạn có chắc muốn xóa [{0}] không?", strName), TextUtils.Caption, 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    CustomerBO.Instance.Delete(Convert.ToInt32(strID));
                    LoadData();
                }
                catch
                {
                    MessageBox.Show("Có lỗi xảy ra khi thực hiện thao tác, xin vui lòng thử lại sau.");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang hãng vật tư!"))
            {
                ProcessTransaction pt = new ProcessTransaction();
                pt.OpenConnection();
                pt.BeginTransaction();
                try
                {
                    if (checkValid())
                    {
                        CustomerModel dModel;
                        if (_isAdd)
                        {
                            dModel = new CustomerModel();
                        }
                        else
                        {
                            int ID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
                            dModel = (CustomerModel)CustomerBO.Instance.FindByPK(ID);
                        }

                        string oldName = dModel.Code;

                        dModel.Code = txtCode.Text.Trim().ToUpper();
                        dModel.Name = txtName.Text.Trim().ToUpper();
                        dModel.Email = txtEmail.Text;
                        dModel.Phone = txtPhone.Text;
                        dModel.Address = txtAddress.Text;
                        dModel.Type = 0;

                        if (_isAdd)
                        {
                            pt.Insert(dModel);
                            if (!DocUtils.CheckExits("Datasheet" + "/" + dModel.Code))
                            {
                                DocUtils.MakeDir("Datasheet" + "/" + dModel.Code);
                            }
                        }
                        else
                        {
                            pt.Update(dModel);
                            if (!DocUtils.CheckExits("Datasheet" + "/" + oldName))
                            {
                                DocUtils.MakeDir("Datasheet" + "/" + oldName);
                            }
                            if (oldName.ToUpper() != dModel.Code.ToUpper())
                            {
                                DocUtils.Rename("Datasheet" + "/" + oldName, dModel.Code);
                            }
                        }
                        pt.CommitTransaction();
                        LoadData();
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
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetInterface(false);
            ClearInterface();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void grdData_Click(object sender, EventArgs e)
        {
            
        }

        private void grdData_DoubleClick(object sender, EventArgs e)
        {
            if (grvData.RowCount > 0 && btnEdit.Enabled == true)
                btnEdit_Click(null, null);
        }

        private void frmCustomer_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (HasDialogResult)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

    }
}
