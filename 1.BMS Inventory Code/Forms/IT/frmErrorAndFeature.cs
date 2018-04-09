using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Business;
using BMS.Model;
using BMS.Utils;

namespace BMS
{
    public partial class frmErrorAndFeature : _Forms
    {
        bool _isSaved = false;
        public delegate void LoadDataChangeHandler(object sender, EventArgs e);
        public event LoadDataChangeHandler LoadDataChange;
        public UpdateSoftwareModel UpdateSoftware = new UpdateSoftwareModel();
        DataTable _dtNCC = new DataTable();
        DataTable _dtPhanMem = new DataTable();

        public frmErrorAndFeature()
        {
            InitializeComponent();
        }

        private void frmErrorAndFeature_Load(object sender, EventArgs e)
        {
            loadUser();
            loadNCC();
            loadPhanMem();

            if (UpdateSoftware.ID > 0)
            {
                txtCode.Text = UpdateSoftware.Code;
                txtName.Text = UpdateSoftware.Name;
                txtPrice.EditValue = UpdateSoftware.Price;

                dtpConfirmDate.EditValue = UpdateSoftware.ConfirmDate;
                dtpNgayBaoGia.EditValue = UpdateSoftware.NgayBaoGia;
                dtpNgayBaoGiaConfirm.EditValue = UpdateSoftware.NgayBaoGiaConfirm;
                dtpRequestDate.EditValue = UpdateSoftware.RequestDate;
                dtpWorkEndDate.EditValue = UpdateSoftware.WorkEndDate;
                dtpWorkEndDateDK.EditValue = UpdateSoftware.WorkEndDateDK;

                if(UpdateSoftware.SoftwareCompany!="")
                    cboNCC.SelectedValue = UpdateSoftware.SoftwareCompany;
                if (UpdateSoftware.SoftwareName != "")
                    cboPhanMem.SelectedValue = UpdateSoftware.SoftwareName;

                cboStatus.SelectedIndex = UpdateSoftware.Status;
                cboType.SelectedIndex = UpdateSoftware.Type;
                cboUser.EditValue = UpdateSoftware.UserID;

                chkClosed.Checked = UpdateSoftware.Complete;
            }
        }

        void loadUser()
        {            
            DataTable dt = TextUtils.Select("Select * from vUserInfo WITH(NOLOCK)");
            cboUser.Properties.DataSource = dt;
            cboUser.Properties.DisplayMember = "FullName";
            cboUser.Properties.ValueMember = "ID";
        }

        void loadNCC()
        {
            _dtNCC = TextUtils.Select("select distinct SoftwareCompany from UpdateSoftware with(nolock)");
            cboNCC.DisplayMember = "SoftwareCompany";
            cboNCC.ValueMember = "SoftwareCompany";
            cboNCC.DataSource = _dtNCC;
        }

        void loadPhanMem()
        {
            _dtPhanMem = TextUtils.Select("select distinct SoftwareName from UpdateSoftware with(nolock)");
            cboPhanMem.DisplayMember = "SoftwareName";
            cboPhanMem.ValueMember = "SoftwareName";
            cboPhanMem.DataSource = _dtPhanMem;
        }

        bool ValidateForm()
        {
            if (txtCode.Text.Trim() == "")
            {
                MessageBox.Show("Mã không thể để trống!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }            

            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Tên không thể để trống!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (cboStatus.SelectedIndex < 0)
            {
                MessageBox.Show("Trạng thái không thể để trống!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (cboUser.EditValue == null)
            {
                MessageBox.Show("Người yêu cầu không thể để trống!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }           

            return true;
        }

        void save()
        {
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();
            try
            {
                if (!ValidateForm())
                    return;
                
                UpdateSoftware.Code = txtCode.Text.Trim();
                UpdateSoftware.Name = txtName.Text.Trim();
                UpdateSoftware.Status = cboStatus.SelectedIndex;
                UpdateSoftware.Complete = chkClosed.Checked;
                
                UpdateSoftware.NgayBaoGia = TextUtils.ToDate2(dtpNgayBaoGia.EditValue);
                UpdateSoftware.NgayBaoGiaConfirm = TextUtils.ToDate2(dtpNgayBaoGiaConfirm.EditValue);
                UpdateSoftware.RequestDate = TextUtils.ToDate2(dtpRequestDate.EditValue);
                UpdateSoftware.WorkEndDate = TextUtils.ToDate2(dtpWorkEndDate.EditValue);
                UpdateSoftware.WorkEndDateDK = TextUtils.ToDate2(dtpWorkEndDateDK.EditValue);
                UpdateSoftware.ConfirmDate = TextUtils.ToDate2(dtpConfirmDate.EditValue);

                UpdateSoftware.Price = TextUtils.ToDecimal(txtPrice.EditValue);
                UpdateSoftware.SoftwareCompany = cboNCC.Text;
                UpdateSoftware.SoftwareName = cboPhanMem.Text;
                UpdateSoftware.Status = cboStatus.SelectedIndex;
                UpdateSoftware.Type = cboType.SelectedIndex;
                UpdateSoftware.UserID = TextUtils.ToInt(cboUser.EditValue);

                if (UpdateSoftware.ID == 0)
                {
                    UpdateSoftware.ID = (int)pt.Insert(UpdateSoftware);
                }
                else
                {
                    pt.Update(UpdateSoftware);
                }

                pt.CommitTransaction();
                loadNCC();
                loadPhanMem();

                _isSaved = true;
                MessageBox.Show("Lưu trữ thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lưu trữ không thành công!" + Environment.NewLine + ex.Message, TextUtils.Caption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                pt.CloseConnection();
            }

            if (_isSaved && this.LoadDataChange != null)
            {
                this.LoadDataChange(null, null);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save();
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            save();
            if (_isSaved)
            {
                this.Close();
            }
        }
    }
}
