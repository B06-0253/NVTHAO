using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPA.Model;
using TPA.Business;
using TPA.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using System.IO;
using System.Diagnostics;

namespace BMS
{
    public partial class frmProjectProblem : _Forms
    {
        #region Variables
        public ProjectProblemModel ProjectProblem = new ProjectProblemModel();
        bool _isSaved = false;
        DataTable _dtAction = new DataTable();
        public delegate void LoadDataChangeHandler(object sender, EventArgs e);
        public event LoadDataChangeHandler LoadDataChange;
        #endregion

        #region Constractor and Load
        public frmProjectProblem()
        {
            InitializeComponent();
        }

        private void frmProjectProblem_Load(object sender, EventArgs e)
        {
            loadProject();
            loadModule();
            loadUser();
            loadGrid();
            loadImage();
            loadDepartment();

            if (ProjectProblem.ID > 0)
            {
                dtpDatePhatSinh.EditValue = ProjectProblem.DatePhatSinh;
                chkTonDong.Checked = ProjectProblem.IsTonDong;
                chkIsTinhTrang.Checked = ProjectProblem.IsTinhTrang;
                cboStatus.SelectedIndex = ProjectProblem.Status;

                cboProject.EditValue = ProjectProblem.ProjectId;
                cboModule.EditValue = ProjectProblem.ModuleCode;
                cboUser.EditValue = ProjectProblem.Monitor;
                cboPhongBan.EditValue = ProjectProblem.DepartmentId;

                txtContent.Text = ProjectProblem.Content;
                txtReason.Text = ProjectProblem.Reason;
                txtSolution.Text = ProjectProblem.Solution;
                
            }
            else
            {
                if (ProjectProblem.ProjectId != "")
                {
                    cboProject.EditValue = ProjectProblem.ProjectId;
                    cboUser.EditValue = ProjectProblem.Monitor;
                }                

                cboStatus.SelectedIndex = 0;
                dtpDatePhatSinh.EditValue = DateTime.Now;
            }
        }
        #endregion

        #region Methods

        void loadDepartment()
        {
            DataTable tbl = LibQLSX.Select("select * from Departments");
            TextUtils.PopulateCombo(cboPhongBan, tbl, "DName", "DepartmentId", "");
        }
        void loadProject()
        {
            try
            {
                DataTable tbl = LibQLSX.Select("exec spGetAllProject");
                TextUtils.PopulateCombo(cboProject, tbl, "ProjectName", "ProjectId", "");
            }
            catch
            {
            }
        }

        void loadModule()
        {
            DataTable tbl = TextUtils.Select("select * from Modules with(nolock) where status = 2 order by Code");
            TextUtils.PopulateCombo(cboModule, tbl, "Name", "Code", "");
        }

        void loadUser()
        {
            DataTable dt = LibQLSX.Select("Select * from [vUser] WITH(NOLOCK)");
            cboUser.Properties.DataSource = dt;
            cboUser.Properties.DisplayMember = "UserName";
            cboUser.Properties.ValueMember = "UserId";
            grvCboUser.BestFitColumns();

            repositoryItemSearchLookUpEdit1.DataSource = dt;
            repositoryItemSearchLookUpEdit1.DisplayMember = "UserName";
            repositoryItemSearchLookUpEdit1.ValueMember = "UserId";
        }

        void loadGrid()
        {
            _dtAction = LibQLSX.Select("select * from vProjectProblemAction with(nolock) where ProjectProblemID = " + ProjectProblem.ID);
            grdData.DataSource = _dtAction;
        }

        void loadImage()
        {
            DataTable dt = LibQLSX.Select("select * from ProjectProblemImage with(nolock) where ProjectProblemID = " + ProjectProblem.ID);
            grvImage.AutoGenerateColumns = false;
            grvImage.DataSource = dt;
        }

        bool ValidateForm()
        {            
            if (cboProject.EditValue == null)
            {
                MessageBox.Show("Xin hãy chọn Dự án.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            //if (chkTonDong.Checked && cboModule.EditValue == null)
            //{
            //    MessageBox.Show("Xin hãy chọn Module.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return false;
            //}

            if (cboUser.EditValue == null)
            {
                MessageBox.Show("Xin hãy chọn Người phụ trách.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (txtContent.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền Nội dung vấn đề.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (chkTonDong.Checked && dtpDatePhatSinh.EditValue == null)
            {
                MessageBox.Show("Xin hãy thêm Ngày phát sinh.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (cboStatus.SelectedIndex < 0)
            {
                MessageBox.Show("Xin hãy chọn Tình trạng.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            return true;
        }

        void save()
        {
            if (!TextUtils.HasPermission("frmProjectProblem_EditAll"))
            {
                if (Global.AppUserName != ProjectProblem.UpdatedBy && ProjectProblem.ID > 0)
                {
                    MessageBox.Show("Bạn không có quyền sửa vấn đề này!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }            

            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();
            try
            {
                if (!ValidateForm())
                    return;

                grvData.FocusedRowHandle = -1;

                ProjectProblem.Code = "";
                ProjectProblem.ProjectId = TextUtils.ToString(cboProject.EditValue);

                ProjectProblem.ModuleCode = TextUtils.ToString(cboModule.EditValue);
                ProjectProblem.Content = txtContent.Text.Trim();
                ProjectProblem.DatePhatSinh = (DateTime?)dtpDatePhatSinh.EditValue;
                ProjectProblem.Reason = txtReason.Text.Trim();
                ProjectProblem.Solution = txtSolution.Text.Trim();
                ProjectProblem.Status = cboStatus.SelectedIndex;
                ProjectProblem.IsTonDong = chkTonDong.Checked;
                ProjectProblem.IsTinhTrang = chkIsTinhTrang.Checked;

                ProjectProblem.Monitor = TextUtils.ToString(cboUser.EditValue);

                ProjectProblem.DepartmentId = TextUtils.ToString(cboPhongBan.EditValue);

                ProjectProblem.UpdatedDate = DateTime.Now;
                ProjectProblem.UpdatedBy = Global.AppUserName;

                if (ProjectProblem.ID <= 0)
                {
                    ProjectProblem.CreatedDate = DateTime.Now;
                    ProjectProblem.CreatedBy = Global.AppUserName;
                    ProjectProblem.ID = (int)pt.Insert(ProjectProblem);
                }
                else
                {
                    pt.Update(ProjectProblem);
                }

                pt.CommitTransaction();

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

            if (_isSaved)
            {
                if (this.LoadDataChange != null)
                {
                    this.LoadDataChange(null, null);
                }
            }
        }

        void reloadControl()
        {
            ProjectProblem = new ProjectProblemModel();
            loadGrid();
            loadImage();

            cboStatus.SelectedIndex = 0;
            dtpDatePhatSinh.EditValue = DateTime.Now;
            cboModule.EditValue = null;

            txtContent.Text = "";
            txtReason.Text = "";
            txtSolution.Text = "";
        }

        void addFile(bool allFile)
        {
            DocUtils.InitFTPTK();
            OpenFileDialog ofd = new OpenFileDialog();
            if (!allFile)
            {
                ofd.Filter = "Image files (*.jpg, *.jpeg, *.png,*.gif) | *.jpg; *.jpeg; *.png; *.gif";
            }
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
                            ProjectProblemImageModel problemImageModel;
                            bool isAdd = true;
                            if (!ProjectProblemImageBO.Instance.CheckExist("FileName", Path.GetFileName(filePath)))
                            {
                                problemImageModel = new ProjectProblemImageModel();
                            }
                            else
                            {
                                problemImageModel = (ProjectProblemImageModel)ProjectProblemImageBO.Instance.FindByAttribute("FileName", Path.GetFileName(filePath))[0];
                                isAdd = false;
                            }

                            FileInfo fInfo = new FileInfo(filePath);

                            string ftpFolderPath = "ProjectProblem\\" + ProjectProblem.ID;

                            problemImageModel.DateCreated = TextUtils.GetSystemDate();
                            problemImageModel.FileName = Path.GetFileName(filePath);
                            problemImageModel.Size = fInfo.Length;
                            problemImageModel.FilePath = ftpFolderPath + "\\" + problemImageModel.FileName;
                            problemImageModel.ProjectProblemID = ProjectProblem.ID;

                            if (isAdd)
                            {
                                problemImageModel.ID = (int)pt.Insert(problemImageModel);
                            }
                            else
                            {
                                pt.Update(problemImageModel);
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

                    loadImage();
                }
            }
        }
        #endregion

        #region Events
        void main_LoadDataChange(object sender, EventArgs e)
        {
            loadGrid();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save();            
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            save();
           
            this.Close();
        }

        private void btnSaveAndNext_Click(object sender, EventArgs e)
        {
            save();

            reloadControl();
        }

        private void grvData_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0) return;
            GridView View = sender as GridView;

            bool isCompleted = TextUtils.ToBoolean(View.GetRowCellValue(e.RowHandle, colIsCompleted));
            DateTime? completedDate = TextUtils.ToDate2(View.GetRowCellValue(e.RowHandle, colCompletedDate));
            if (completedDate == null)
            {
                return;
            }
            if (!isCompleted && completedDate.Value.Date <= DateTime.Now.Date)
            {
                e.Appearance.BackColor = Color.Yellow;
            }
        }

        private void btnAddAction_Click(object sender, EventArgs e)
        {
            if (ProjectProblem.ID == 0)
            {
                MessageBox.Show("Bạn phải chưa ghi lại vấn đề.",TextUtils.Caption, MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }
            frmProjectProblemAction frm = new frmProjectProblemAction();
            frm.ProjectProblemID = ProjectProblem.ID;
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnDeleteAction_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa hành động này không?"              
                      , TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ProjectProblemActionBO.Instance.Delete(id);
                loadGrid();
            }
        }

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            ProjectProblemActionModel model = (ProjectProblemActionModel)ProjectProblemActionBO.Instance.FindByPK(id);
            frmProjectProblemAction frm = new frmProjectProblemAction();
            frm.Action = model;
            frm.ProjectProblemID = ProjectProblem.ID;
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnCompleted_Click(object sender, EventArgs e)
        {            
            foreach (int i in grvData.GetSelectedRows())
            {
                int id = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));                
                ProjectProblemActionModel model = (ProjectProblemActionModel)ProjectProblemActionBO.Instance.FindByPK(id);
                model.IsCompleted = true;
                ProjectProblemActionBO.Instance.Update(model);
            }
            loadGrid();
        }

        private void btnAddFileImage_Click(object sender, EventArgs e)
        {
            if (ProjectProblem.ID == 0)
            {
                MessageBox.Show("Bạn phải ghi lại trước khi thêm file!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            addFile(false);
        }

        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang xóa file lên server!"))
            {
                DocUtils.InitFTPTK();
                if (grvImage.RowCount <= 0) return;

                int id = TextUtils.ToInt(grvImage.SelectedRows[0].Cells[colIDimage.Index].Value);
                if (id == 0) return;

                string filePath = grvImage.SelectedRows[0].Cells[colFilePath.Name].Value.ToString();
                string fileName = grvImage.SelectedRows[0].Cells[colFileName.Name].Value.ToString();

                if (MessageBox.Show("Bạn có thật sự muốn xóa file [" + fileName + "] này không?", TextUtils.Caption,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

                ProcessTransaction pt = new ProcessTransaction();
                pt.OpenConnection();
                pt.BeginTransaction();
                try
                {
                    pt.Delete("ProjectProblemImage", id);

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
                loadImage();
            }
        }

        private void grvImage_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grvImage.RowCount <= 0) return;
            if (grvImage.SelectedRows.Count > 0)
            {
                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang mở file!"))
                {
                    int id = TextUtils.ToInt(grvImage.SelectedRows[0].Cells[colIDimage.Index].Value);
                    if (id == 0) return;

                    string localPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    string filePath = grvImage.SelectedRows[0].Cells[colFilePath.Index].Value.ToString();
                    string fileName = grvImage.SelectedRows[0].Cells[colFileName.Index].Value.ToString();

                    DocUtils.InitFTPTK();
                    DocUtils.DownloadFile(localPath, Path.GetFileName(filePath), filePath);

                    Process.Start(localPath + "/" + Path.GetFileName(filePath));
                }
            }
        }
        #endregion
    }
}
