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

namespace BMS
{
    public partial class frmPBDLFile : _Forms
    {
        public PBDLFileModel FModel = new PBDLFileModel();

        public frmPBDLFile()
        {
            InitializeComponent();
        }

        private void frmPBDLFile_Load(object sender, EventArgs e)
        {
            try
            {
                if (FModel.ID>0)
                {
                    txtFolderContain.Text = FModel.FolderContain;
                    txtFileName.Text = FModel.FileName;
                    txtThongSo.Text = FModel.FilterThongSo;
                    txtDonVi.Text = FModel.FilterDonVi;
                    txtDescription.Text = FModel.Description;
                    txtExtension.Text = FModel.Extension;

                    cboGetType.SelectedIndex = FModel.GetType;
                    cboFileType.SelectedIndex = FModel.FileType;

                    chkMaVatLieu.Checked = FModel.FilterMaVatLieu;
                    chkMat.Checked = FModel.MAT;
                    chkTem.Checked = FModel.TEM;
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        #region Methods

        private bool checkValid()
        {
            if (txtFolderContain.Text == "")
            {
                MessageBox.Show("Xin hãy điền đường dẫn thư mục chứa.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }           
           
            if (cboGetType.SelectedIndex < 0)
            {
                MessageBox.Show("Xin hãy chọn số lượng file cần lấy.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else if (cboGetType.SelectedIndex == 0)
            {
                if (txtThongSo.Text.Trim() == "" && !chkMaVatLieu.Checked && txtDonVi.Text.Trim() == "" && !chkMat.Checked && !chkTem.Checked)
                {
                    MessageBox.Show("Xin hãy điền một điều kiện cần lấy trong file danh mục vật tư.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
            }
            else
            {
                if (txtFileName.Text.Trim()=="")
                {
                    MessageBox.Show("Xin hãy điền tên file(có cả phần mở rộng).", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
            }
            if (cboFileType.SelectedIndex < 0)
            {
                MessageBox.Show("Xin hãy chọn kiểu file.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            return true;
        }

        #endregion

        #region Buttons Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkValid())
                {                    
                    FModel.FolderContain = txtFolderContain.Text.Trim();
                    FModel.FolderPath = "";
                    FModel.FileName = txtFileName.Text.Trim();
                    FModel.FilterThongSo = txtThongSo.Text.Trim();                    
                    FModel.FilterDonVi = txtDonVi.Text.Trim();                    
                    FModel.Description = txtDescription.Text.Trim();
                    FModel.Extension = txtExtension.Text.Trim();

                    FModel.GetType = cboGetType.SelectedIndex;
                    FModel.FileType = cboFileType.SelectedIndex;

                    FModel.FilterMaVatLieu = chkMaVatLieu.Checked;
                    FModel.MAT = chkMat.Checked;
                    FModel.TEM = chkTem.Checked;

                    if (FModel.ID == 0)
                    {
                        PBDLFileBO.Instance.Insert(FModel);
                    }
                    else
                        PBDLFileBO.Instance.Update(FModel);

                    this.DialogResult = DialogResult.OK;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void cboGetType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGetType.SelectedIndex==0)
            {
                txtFileName.Text = "";
                txtFileName.Enabled = false;
                gbFilter.Enabled = true;
            }
            if (cboGetType.SelectedIndex == 1)
            {                
                txtFileName.Enabled = true;

                txtDonVi.Text = "";
                txtThongSo.Text = "";                

                chkMaVatLieu.Checked = false;
                chkTem.Checked = false;
                chkMat.Checked = false;
                
                gbFilter.Enabled = false;
            }
        }
    }
}
