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
using DevExpress.Utils;
using System.Diagnostics;
using System.IO;

namespace BMS
{
    public partial class frmConfirmUser : _Forms
    {
        bool _isSaved = false;
        public MisMatchModel MisMatch = new MisMatchModel();

        #region Constructor and Load
        public frmConfirmUser()
        {
            InitializeComponent();
        }

        private void frmConfirmUser_Load(object sender, EventArgs e)
        {
            loadUserKP();
            loadGridUser();
            loadGridImage();
            cboStatus.SelectedIndex = MisMatch.StatusTK;
        }
        #endregion

        #region Methods
        void loadGridImage()
        {
            DataTable dt = TextUtils.Select("MisMatchImage", new Expression("MisMatchID", MisMatch.ID));
            grvDataImage.AutoGenerateColumns = false;
            grvDataImage.DataSource = dt;
        }        

        void loadUserKP()
        {
            try
            {
                DataTable dt = TextUtils.Select("Select * from vUserInfo WITH(NOLOCK)");
                cboUserKP.Properties.DataSource = dt;
                cboUserKP.Properties.DisplayMember = "FullName";
                cboUserKP.Properties.ValueMember = "ID";
            }
            catch (Exception)
            {
            }
        }

        void loadGridUser()
        {
            DataTable dt = TextUtils.Select("select * from vMisMatchUser where MisMatchID = '" + MisMatch.ID + "'");
            if (dt.Rows.Count > 0)
            {
                grvDataUser.AutoGenerateColumns = false;
                grvDataUser.DataSource = dt;
            }
        }

        bool ValidateForm()
        {
            if (cboStatus.SelectedIndex < 0)
            {
                MessageBox.Show("Xin hãy chọn tình trạng.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (cboStatus.SelectedIndex == 1 && grvDataUser.Rows.Count == 0)
            {
                MessageBox.Show("Xin hãy chọn nhân viên khắc phục.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

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
                
                MisMatch.StatusTK = cboStatus.SelectedIndex;              

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
        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            save(true);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (cboUserKP.EditValue == null)
            {
                MessageBox.Show("Bạn phải chọn một nhân viên!");
                return;
            }
            DataTable dt = TextUtils.Select("select * from vMisMatchUser where MisMatchID = '" + MisMatch.ID + "' and UserID= " + TextUtils.ToInt(cboUserKP.EditValue));
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Nhân viên này đã được gán!");
                return;
            }
            MisMatchUserModel model = new MisMatchUserModel();
            model.MisMatchID = MisMatch.ID;
            model.UserID = TextUtils.ToInt(cboUserKP.EditValue);
            MisMatchUserBO.Instance.Insert(model);
            MessageBox.Show("Thêm nhân viên thành công!", TextUtils.Caption);
            loadGridUser();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvDataUser.SelectedRows[0].Cells[colID.Index].Value);
            string name = grvDataUser.SelectedRows[0].Cells[colFullName.Index].Value.ToString();
            if (id > 0)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa nhân viên [" + name + "] ra khỏi danh sách?", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MisMatchUserBO.Instance.Delete(id);
                    loadGridUser();
                }
            }
        }

        private void frmConfirmUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_isSaved)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void grvDataImage_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grvDataImage.RowCount <= 0) return;
            if (grvDataImage.SelectedRows.Count > 0)
            {
                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang mở file!"))
                {
                    int id = TextUtils.ToInt(grvDataImage.SelectedRows[0].Cells[colImageID.Index].Value);
                    if (id == 0) return;

                    string filePath = grvDataImage.SelectedRows[0].Cells[colFilePath.Index].Value.ToString();
                    string fileName = grvDataImage.SelectedRows[0].Cells[colFileName.Index].Value.ToString();
                    DocUtils.InitFTPTK();
                    DocUtils.DownloadFile(Path.GetTempPath(), Path.GetFileName(filePath), filePath);

                    Process.Start(Path.GetTempPath() + "/" + Path.GetFileName(filePath));
                }
            }
        }

        #endregion
    }
}
