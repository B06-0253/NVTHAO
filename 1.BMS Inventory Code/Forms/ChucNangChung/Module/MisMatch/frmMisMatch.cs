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
using DevExpress.Utils;
using System.IO;
using System.Diagnostics;

namespace BMS
{
    public partial class frmMisMatch : _Forms
    {
        public MisMatchModel MisMatch = new MisMatchModel();
        bool _isSaved = false;
        public bool OnlyShowImage = false;

        #region Constructor and Load
        public frmMisMatch()
        {
            InitializeComponent();
        }

        private void frmMisMatch_Load(object sender, EventArgs e)
        {
            loadUserFind();      

            txtCode.Enabled = false;
            loadProject();
            loadModule();
            if (MisMatch.ID > 0)
            {
                txtCode.Text = MisMatch.Code;
                txtDescription.Text = MisMatch.Description;
                cboProject.EditValue = MisMatch.ProjectCode;
                cboModule.EditValue = MisMatch.ModuleCode;
                txtCost.Value = MisMatch.Cost;
                cboUser.EditValue = MisMatch.UserFind;

                this.Text = MisMatch.Code;
            }
            else
            {
                DataTable dt = TextUtils.Select("SELECT top 1 Code FROM [MisMatch] order by ID desc");
                int code = 0;
                if (dt.Rows.Count > 0)
                {
                    code = TextUtils.ToInt(dt.Rows[0][0].ToString().Split('.')[1]);
                }
                txtCode.Text = DateTime.Now.ToString("yy") + "K." + (code + 1);

                groupBoxPicture.Enabled = false;
            }

            loadGridImage();

            if (OnlyShowImage)
            {
                mnuMenu.Enabled = false;
                //groupBoxDetail.Enabled = false;
                toolStrip1.Enabled = false;
            }
        }
        #endregion

        #region Methods
        void loadModule()
        {
            DataTable tbl = TextUtils.Select("select * from Modules with(nolock) where status = 2 order by Code");
            TextUtils.PopulateCombo(cboModule, tbl, "Name", "Code", "");
        }

        void loadUserFind()
        {
            DataTable dt = TextUtils.Select("Select * from vUserInfo WITH(NOLOCK)");
            cboUser.Properties.DataSource = dt;
            cboUser.Properties.DisplayMember = "FullName";
            cboUser.Properties.ValueMember = "ID";
        }

        void loadGridImage()
        {
            DataTable dt = TextUtils.Select("MisMatchImage", new Expression("MisMatchID", MisMatch.ID));
            grvDataImage.AutoGenerateColumns = false;
            grvDataImage.DataSource = dt;
        }        

        bool ValidateForm()
        {
            if (txtCode.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền Mã.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
            {
                DataTable dt;
                if (MisMatch.ID > 0)
                {
                    dt = TextUtils.Select("select Code from MisMatch with (nolock) where Code = '" + txtCode.Text.Trim() + "' and ID <> " + MisMatch.ID);
                }
                else
                {
                    dt = TextUtils.Select("select Code from MisMatch with (nolock) where Code = '" + txtCode.Text.Trim() + "'");
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

            //if (cboProject.EditValue ==null || cboProject.EditValue.ToString() == "")
            //{
            //    MessageBox.Show("Xin hãy chọn một dự án.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return false;
            //}

            if (cboModule.EditValue == null || cboModule.EditValue.ToString() == "")
            {
                MessageBox.Show("Xin hãy chọn một sản phẩm.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (txtDescription.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy nhập mô tả.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (TextUtils.ToInt(cboUser.EditValue) == 0)
            {
                MessageBox.Show("Xin hãy chọn nhân viên phát hiện.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            return true;
        }

        void loadProject()
        {
            try
            {
                DataTable tbl = LibQLSX.Select("exec spGetAllProject");
                TextUtils.PopulateCombo(cboProject, tbl, "ProjectName", "ProjectCode", "");
            }
            catch (Exception ex)
            {
            }
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

                if (MisMatch.ID > 0)
                {
                    MisMatch = (MisMatchModel)MisMatchBO.Instance.FindByPK(MisMatch.ID);
                }

                MisMatch.Code = txtCode.Text.Trim().ToUpper();
                MisMatch.Description = txtDescription.Text.Trim();
                MisMatch.StatusTK = 0;
                MisMatch.ProjectCode = TextUtils.ToString(cboProject.EditValue);
                MisMatch.ModuleCode = cboModule.EditValue != null ? cboModule.EditValue.ToString() : "";
                MisMatch.Cost = txtCost.Value;
                MisMatch.UserFind = TextUtils.ToInt(cboUser.EditValue);

                //MisMatch.CompleteTime = _completeTime;

                if (MisMatch.ID == 0)
                {
                    MisMatch.ID = (int)pt.Insert(MisMatch);
                }
                else
                {
                    pt.Update(MisMatch);
                }

                pt.CommitTransaction();
                _isSaved = true;

                if (close)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Lưu trữ thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    groupBoxPicture.Enabled = true;
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
        #endregion

        #region Events
        private void cboProject_EditValueChanged(object sender, EventArgs e)
        {
            //string projectCode = cboProject.EditValue.ToString();
            //if (projectCode != "")
            //{
            //    try
            //    {
            //        string[] paraName = new string[1];
            //        string[] paraValue = new string[1];
            //        paraName[0] = "@ProjectCode"; paraValue[0] = projectCode;
            //        DataTable tbl = ModulesBO.Instance.LoadDataFromSP("spGetModuleOfProject", "Modules", paraName, paraValue);
            //        TextUtils.PopulateCombo(cboModule, tbl, "ProductName", "ProductCode", "");
            //    }
            //    catch (Exception ex)
            //    {
            //        cboModule.Properties.DataSource = null;
            //    }
            //}
            //else
            //{
            //    cboModule.Properties.DataSource = null;
            //}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save(false);
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            save(true);
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            DocUtils.InitFTPTK();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang up file lên server!"))
                {
                    foreach (string filePath in ofd.FileNames)
                    {
                        ProcessTransaction pt = new ProcessTransaction();
                        pt.OpenConnection();
                        pt.BeginTransaction();
                        try
                        {
                            MisMatchImageModel errorImageModel;
                            bool isAdd = true;
                            if (!MisMatchImageBO.Instance.CheckExist("FileName", Path.GetFileName(filePath)))
                            {
                                errorImageModel = new MisMatchImageModel();
                            }
                            else
                            {
                                errorImageModel = (MisMatchImageModel)MisMatchImageBO.Instance.FindByAttribute("FileName", Path.GetFileName(filePath))[0];
                                isAdd = false;
                            }

                            FileInfo fInfo = new FileInfo(filePath);

                            string ftpFolderPath = "Modules\\KPHImage\\" + MisMatch.Code;

                            errorImageModel.CreatedDate = TextUtils.GetSystemDate();
                            errorImageModel.CreatedBy = Global.LoginName;
                            errorImageModel.FileName = Path.GetFileName(filePath);
                            errorImageModel.Size = fInfo.Length;
                            errorImageModel.FilePath = ftpFolderPath + "\\" + errorImageModel.FileName;
                            errorImageModel.MisMatchID = MisMatch.ID;

                            if (isAdd)
                            {
                                errorImageModel.ID = (int)pt.Insert(errorImageModel);
                            }
                            else
                            {
                                pt.Update(errorImageModel);
                            }

                            if (!DocUtils.CheckExits(ftpFolderPath))
                            {
                                DocUtils.MakeDir(ftpFolderPath);
                            }
                            DocUtils.UploadFile(filePath, ftpFolderPath);

                            pt.CommitTransaction();
                        }
                        catch (Exception)
                        {
                        }
                        finally
                        {
                            pt.CloseConnection();
                        }
                    }

                    loadGridImage();
                }
            }
        }

        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang xóa file lên server!"))
            {
                DocUtils.InitFTPTK();
                if (grvDataImage.RowCount <= 0) return;

                int id = TextUtils.ToInt(grvDataImage.SelectedRows[0].Cells[colID.Name].Value);
                if (id == 0) return;

                string filePath = grvDataImage.SelectedRows[0].Cells[colFilePath.Name].Value.ToString();
                string fileName = grvDataImage.SelectedRows[0].Cells[colFileName.Name].Value.ToString();

                if (MessageBox.Show("Bạn có thật sự muốn xóa file [" + fileName + "] này không?", TextUtils.Caption,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

                ProcessTransaction pt = new ProcessTransaction();
                pt.OpenConnection();
                pt.BeginTransaction();
                try
                {
                    pt.Delete("MisMatchImage", id);

                    if (DocUtils.CheckExits(filePath))
                    {
                        DocUtils.DeleteFile(filePath);
                    }

                    pt.CommitTransaction();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa file [" + fileName + "] không thành công!" + Environment.NewLine + ex.Message,
                        TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                    pt.CloseConnection();
                }
                loadGridImage();
            }
        }      

        private void grvDataImage_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grvDataImage.RowCount <= 0) return;
            if (grvDataImage.SelectedRows.Count > 0)
            {
                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang mở file!"))
                {
                    int id = TextUtils.ToInt(grvDataImage.SelectedRows[0].Cells[colID.Index].Value);
                    if (id == 0) return;

                    string filePath = grvDataImage.SelectedRows[0].Cells[colFilePath.Index].Value.ToString();
                    string fileName = grvDataImage.SelectedRows[0].Cells[colFileName.Index].Value.ToString();
                    DocUtils.InitFTPTK();
                    DocUtils.DownloadFile(Path.GetTempPath(), Path.GetFileName(filePath), filePath);

                    Process.Start(Path.GetTempPath() + "/" + Path.GetFileName(filePath));
                }
            }
        }

        private void chkConfirm_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void frmMisMatch_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_isSaved)
            {
                DialogResult = DialogResult.OK;
            }
        }
        #endregion
    }
}
