using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using BMS.Model;
using BMS.Business;
using BMS.Utils;
using DevExpress.Utils;

namespace BMS
{
    public partial class frmTemManager : _Forms
    {
        private bool _isAdd;
        public int ModuleID;
        public string ModuleCode;
        public string ModuleName;

        public frmTemManager()
        {
            InitializeComponent();
        }

        private void frmTemManager_Load(object sender, EventArgs e)
        {
            this.Text += ": " + ModuleCode + " - " + ModuleName;
            DocUtils.InitFTPQLSX();
            LoadData();
        }

        #region Methods
        private void setInterface(bool isEdit)
        {
            txtCode.ReadOnly = !isEdit;

            grdData.Enabled = !isEdit;

            btnSave.Visible = isEdit;
            btnCancel.Visible = isEdit;

            btnNew.Visible = !isEdit;
            btnEdit.Visible = !isEdit;
            btnDelete.Visible = !isEdit;
        }

        private void clearInterface()
        {
            txtCode.Text = "";
            txtTime.Text = "";
            deUpdatedDate.EditValue = null;
            txtReason.Text = "";
        }

        private bool checkValid()
        {
            if (txtCode.Text == "")
            {
                MessageBox.Show("Bạn hãy điền mã.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
            {
                if (!txtCode.Text.Trim().ToUpper().StartsWith("TPAD"))
                {
                    MessageBox.Show("Mã tem không đúng định dạng!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
                DataTable dt;
                if (!_isAdd)
                {
                    int strID = TextUtils.ToInt(grvData.GetRowCellValue(grvData.FocusedRowHandle, "ID").ToString());
                    dt = TextUtils.Select("select Code from ModuleTem where Code = '" + txtCode.Text.Trim() + "' and ID <> " + strID);
                }
                else
                {
                    dt = TextUtils.Select("select Code from ModuleTem where Code = '" + txtCode.Text.Trim() + "'");
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

            if (deUpdatedDate.EditValue == null)
            {
                MessageBox.Show("Bạn hãy chọn ngày sửa đổi!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (txtReason.Enabled && txtReason.Text.Trim() == "")
            {
                MessageBox.Show("Bạn hãy điền lý do sửa đổi!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return true;
        }

        private void LoadData()
        {
            try
            {
                DataTable tbl = TextUtils.Select("Select * from ModuleTem with(nolock) where ModuleID = " + ModuleID);
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
            setInterface(true);
            _isAdd = true;
            txtReason.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!grvData.IsDataRow(grvData.FocusedRowHandle))
                return;
            setInterface(true);
            _isAdd = false;

            int ID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            ModuleTemModel dModel = (ModuleTemModel)ModuleTemBO.Instance.FindByPK(ID);

            txtCode.Text = dModel.Code;
            txtTime.Text = dModel.LastTimeChange.ToString();
            deUpdatedDate.EditValue = dModel.LastDateChange;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!grvData.IsDataRow(grvData.FocusedRowHandle))
                return;

            int strID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID).ToString());

            string strName = grvData.GetFocusedRowCellValue(colCode).ToString();

            //if (WorksBO.Instance.CheckExist("CustomerID", strID))
            //{
            //    MessageBox.Show("Khách hàng này đang được sử dụng nên không thể xóa được!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}

            if (MessageBox.Show(String.Format("Bạn có chắc muốn xóa in Tem [{0}] không?", strName), TextUtils.Caption,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    ModuleTemBO.Instance.Delete(strID);
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
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();
            try
            {
                if (checkValid())
                {
                    ModuleTemModel dModel;
                    if (_isAdd)
                    {
                        dModel = new ModuleTemModel();
                    }
                    else
                    {
                        int ID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
                        dModel = (ModuleTemModel)ModuleTemBO.Instance.FindByPK(ID);
                    }

                    dModel.Code = txtCode.Text.ToUpper().Trim();
                    dModel.LastDateChange = TextUtils.ToDate(deUpdatedDate.EditValue.ToString());
                    dModel.LastTimeChange = TextUtils.ToInt(txtTime.Text.Trim());
                    dModel.ModuleID = ModuleID;

                    if (_isAdd)
                    {
                        pt.Insert(dModel);
                    }
                    else
                    {
                        pt.Update(dModel);

                        if (txtReason.Enabled)
                        {
                            ModuleTemHistoryModel hModel = new ModuleTemHistoryModel();
                            hModel.ModuleTemID = dModel.ID;
                            hModel.LastTimeChange = dModel.LastTimeChange;
                            hModel.LastDateChange = dModel.LastDateChange;
                            hModel.Reason = txtReason.Text.Trim();
                            hModel.UpdatedDate = TextUtils.GetSystemDate();
                            hModel.UpdatedBy = Global.AppUserName;
                            hModel.Code = dModel.Code;
                            pt.Insert(hModel);
                        }
                    }

                    pt.CommitTransaction();

                    LoadData();
                    setInterface(false);
                    clearInterface();
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
            setInterface(false);
            clearInterface();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang download file!"))
            {
                try
                {
                    string path = @"Thietke.Ck\\" + ModuleCode.Substring(0, 6) + "\\" + ModuleCode + ".Ck\\DATA1.Ck." + ModuleCode;
                    string localPath = "D:\\" + path;
                    if (!DocUtils.CheckExits(path))
                    {
                        MessageBox.Show("Không tồn tại thư mục DATA1.Ck." + ModuleCode + " trên nguồn thiết kế!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    Directory.CreateDirectory(localPath);
                    string[] listTem = DocUtils.GetContentList(path);

                    foreach (string fileName in listTem)
                    {
                        try
                        {
                            DocUtils.DownloadFile(localPath, fileName, path + "\\" + fileName);
                            Process.Start(localPath + "\\" + fileName);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
                catch (Exception ex)
                {
                    TextUtils.ShowError("Download file không thành công!" + Environment.NewLine + ex.ToString());
                }
            }
        }

        #endregion

        private void grdData_DoubleClick(object sender, EventArgs e)
        {
            if (grvData.RowCount > 0 && btnEdit.Enabled == true)
                btnEdit_Click(null, null);
        }

        private void txtTime_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!_isAdd)
                {
                    int ID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
                    ModuleTemModel dModel = (ModuleTemModel)ModuleTemBO.Instance.FindByPK(ID);

                    if (dModel.LastTimeChange != TextUtils.ToInt(txtTime.Text.Trim()))
                    {
                        txtReason.Enabled = true;
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnModuleHistory_Click(object sender, EventArgs e)
        {
            int iD = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (iD == 0) return;
            frmTemHistory frm = new frmTemHistory();
            frm.ModuleTemID = iD;
            frm.ModuleTemCode = grvData.GetFocusedRowCellValue(colCode).ToString();
            TextUtils.OpenForm(frm);
        }     
    }
}
