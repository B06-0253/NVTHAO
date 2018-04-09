using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Model;
using BMS.Utils;
using BMS.Business;
using System.IO;
using System.Diagnostics;
using DevExpress.XtraGrid.Localization;

namespace BMS
{
    public partial class frmModule : _Forms
    {
        #region Variables
        public ModulesModel Module = new ModulesModel();
        public int CatID = 0;
        public bool IsCopy = false;
        bool _isSaved = false;

        public delegate void LoadDataChangeHandler(object sender, EventArgs e);
        public event LoadDataChangeHandler LoadDataChange;

        #endregion

        #region Constructors and Loads
        public frmModule()
        {
            InitializeComponent();
        }

        private void frmModule_Load(object sender, EventArgs e)
        {
            GridLocalizer.Active = new MyGridLocalizer();
            loadCombo();
            loadPK();

            cboHMI.SelectedIndex = 0;
            cboPLC.SelectedIndex = 0;

            if (Module.ID != 0)
            {
                txtName.Text = Module.Name;
                txtCode.Text = Module.Code;
                txtNote.Text = Module.Note;
                cboStatus.SelectedIndex = Module.Status;
                leParentCat.EditValue = Module.ModuleGroupID;
                chkCoKhi.Checked = TextUtils.ToBoolean(Module.FileMechanics);
                chkDien.Checked = TextUtils.ToBoolean(Module.FileElectric);
                chkDienTu.Checked = TextUtils.ToBoolean(Module.FileElectronic);
                txtTSKT.Text = Module.Specifications.Replace("\n", "\r\n");

                chkStop.Checked = Module.StopStatus == 1;
                chkIsUpdatedFilm1.Checked = Module.IsUpdatedFilm == 1;

                cboHMI.SelectedIndex = Module.IsHMI;
                cboPLC.SelectedIndex = Module.IsPLC;

                btnModuleHistory.Visible = true;
                
                this.Text = this.Text + ": " + Module.Code + "-" + Module.Name;
                loadGridError();
                //\\SERVER\Thietke\Luutru\PHANMEM\MaterialImage\FH204 AC-25)0.03.png
                string imagePath = @"\\server\Company\Share\PHANMEM\ModuleImage\" + Module.Code + ".jpg";

                if (File.Exists(imagePath))
                {
                    pictureBox1.ImageLocation = imagePath;
                }
            }
            else
            {
                if (IsCopy)
                {
                    this.Text = this.Text + " đang COPY từ: " + Module.Code + "-" + Module.Name;
                }
                leParentCat.EditValue = CatID;
                groupControlError.Enabled = false;
                cboStatus.SelectedIndex = 0;
            }
        }
        #endregion

        #region Functions
        void loadCombo()
        {
            DataTable tbl = TextUtils.Select(@"SELECT ID,Code FROM ModuleGroup WITH(NOLOCK) ORDER BY Code");
            if (tbl == null)
            {
                return;
            }
            TextUtils.PopulateCombo(leParentCat, tbl.Copy(), "Code", "ID", "");
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
                if (!txtCode.Text.Trim().StartsWith(leParentCat.Text))
                {                    
                    MessageBox.Show("Mã không đúng định dạng!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
                else
                {
                    if (txtCode.Text.Trim().StartsWith("TPAD"))
                    {
                        if (txtCode.Text.Trim().Length != 10)
                        {
                            MessageBox.Show("Mã không đúng định dạng!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return false;
                        }
                        int number = TextUtils.ToInt(txtCode.Text.Trim().Substring(6, 4));
                        if (number==0)
                        {
                             MessageBox.Show("Mã không đúng định dạng!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                             return false;
                        }
                        if (txtCode.Text.Trim().Substring(0, 6) != leParentCat.Text)
                        {
                            MessageBox.Show("Mã không đúng định dạng!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return false;
                        }
                    }
                    if (txtCode.Text.Trim().StartsWith("PCB"))
                    {
                        if (txtCode.Text.Trim().Length != 11)
                        {
                            MessageBox.Show("Mã không đúng định dạng!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return false;
                        }
                        int number = TextUtils.ToInt(txtCode.Text.Trim().Substring(5, 6));
                        if (number == 0)
                        {
                            MessageBox.Show("Mã không đúng định dạng!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return false;
                        }
                        if (txtCode.Text.Trim().Substring(0,5) != leParentCat.Text)
                        {
                            MessageBox.Show("Mã không đúng định dạng!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return false;
                        }
                    }                    
                }              

                DataTable dt;
                if (Module.ID > 0 && !IsCopy)
                {
                    dt = TextUtils.Select("select Code from Modules where Code = '" + txtCode.Text.Trim() + "' and ID <> " + Module.ID);
                }
                else
                {
                    dt = TextUtils.Select("select Code from Modules where Code = '" + txtCode.Text.Trim() + "'");
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

            if (cboStatus.SelectedIndex<0)
            {
                MessageBox.Show("Xin hãy trạng thái.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            return true;
        }

        void loadGridError()
        {
            try
            {
                DataTable dt = TextUtils.Select("select *,(SELECT STUFF((SELECT '+ ' + [FullName] FROM [vModuleErrorUser] where [ModuleErrorID]= vModuleError.ID order by [FullName] FOR XML PATH ('')) , 1, 2, '') ) as ErrorUser from vModuleError where ModuleID = " + Module.ID + "  order by CreatedDate desc");

                grdDataError.DataSource = dt;
                grvDataError.BestFitColumns();
            }
            catch 
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

                #region Module
                if (Module == null)
                {
                    Module = new ModulesModel();
                }

                Module.Name = txtName.Text.Trim().ToUpper();
                Module.Code = txtCode.Text.Trim().ToUpper();
                Module.Status = cboStatus.SelectedIndex;
                Module.ModuleGroupID = leParentCat.EditValue != null ? TextUtils.ToInt(leParentCat.EditValue) : 0;
                Module.Note = txtNote.Text.Trim();
                Module.Specifications = txtTSKT.Text.Trim();

                Module.FileElectronic = TextUtils.ToInt(chkDienTu.Checked);
                Module.FileElectric = TextUtils.ToInt(chkDien.Checked);
                Module.FileMechanics = TextUtils.ToInt(chkCoKhi.Checked);

                Module.StopStatus = chkStop.Checked ? 1 : 0;
                Module.IsUpdatedFilm = chkIsUpdatedFilm1.Checked ? 1 : 0;

                Module.IsPLC = cboPLC.SelectedIndex;
                Module.IsHMI = cboHMI.SelectedIndex;

                if (Module.ID == 0 || IsCopy)
                {
                    Module.ID = (int)pt.Insert(Module);
                }
                else
                {
                    pt.Update(Module);
                }
                #endregion

                #region Phụ kiện đi kèm
                grvPK.FocusedRowHandle = -1;
                for (int i = 0; i < grvPK.RowCount; i++)
                {
                    string code = TextUtils.ToString(grvPK.GetRowCellValue(i, colCodePK));
                    string name = TextUtils.ToString(grvPK.GetRowCellValue(i, colNamePK));
                    int qty = TextUtils.ToInt(grvPK.GetRowCellValue(i, colQtyPK));
                    int id = TextUtils.ToInt(grvPK.GetRowCellValue(i, colIDPK));
                    
                    ModulePartModel part = new ModulePartModel();
                    if (id > 0)
                    {
                        part = (ModulePartModel)ModulePartBO.Instance.FindByPK(id);
                    }
                    part.Code = code;
                    part.Name = name;
                    part.ModuleID = Module.ID;
                    part.Qty = qty;

                    if (id > 0)
                    {
                        pt.Update(part);
                    }
                    else
                    {
                        pt.Insert(part);
                    }
                }
                #endregion

                pt.CommitTransaction();
                loadPK();

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

        #region Buttons Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsCopy)
            {
                save(false);
            }
            else
            {
                save(true);
            }
            
            if (_isSaved)
            {
                groupControlError.Enabled = true;
            }            
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            save(true);
            if (_isSaved)
            {
                this.Close();
            }
        }
        #endregion       

        #region Events

        private void leParentCat_EditValueChanged(object sender, EventArgs e)
        {
            if (leParentCat.EditValue != null)
            {
                if (Module.ID==0 && TextUtils.ToInt(leParentCat.EditValue) != 0)
                {
                    txtCode.Text = leParentCat.Text;
                }

                //if (TextUtils.ToInt(leParentCat.EditValue) > 0)
                //{
                //    ModuleGroupModel gModel = (ModuleGroupModel)ModuleGroupBO.Instance.FindByPK(TextUtils.ToInt(leParentCat.EditValue));
                //    if (!gModel.Code.ToUpper().StartsWith("TPAD"))
                //    {
                //        groupControl2.Visible = false;
                //        this.Width -= groupControl2.Width;
                //    }
                //    else
                //    {
                //        grdData.DataSource = TextUtils.Select("ModuleFilm", new Expression("ModuleID", Model.ID));
                //    }
                //}      
            }
        }

        private void txtCode_EditValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    string code = txtCode.Text.Substring(0, 6);
            //    int id = ((ModuleGroupModel)ModuleGroupBO.Instance.FindByAttribute("Code", code)[0]).ID;
            //    leParentCat.EditValue = id;
            //}
            //catch (Exception)
            //{
                
            //}
        }                

        private void btnModuleHistory_Click(object sender, EventArgs e)
        {
            if (Module.ID > 0)
            {
                frmModuleHistory frm = new frmModuleHistory();
                frm.Module = Module;
                frm.ShowDialog();
            }
        }
       
        #region Error
        private void btnNew_Click(object sender, EventArgs e)
        {
            frmError frm = new frmError();
            frm.ModuleID = Module.ID;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                loadGridError();
                _isSaved = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvDataError.GetFocusedRowCellValue(colErrorID));
            if (id <= 0) return;
            frmError frm = new frmError();
            frm.ErrorModel = (ModuleErrorModel)ModuleErrorBO.Instance.FindByPK(id);
            frm.ModuleID = Module.ID;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                loadGridError();
                _isSaved = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvDataError.GetFocusedRowCellValue(colErrorID));
            if (id < 0) return;
            DialogResult result = MessageBox.Show("Bạn có thật sự muốn xóa lỗi này!", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ModuleErrorBO.Instance.Delete(id);
                loadGridError();
                _isSaved = true;
            }
        }
        #endregion        

        private void frmModule_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_isSaved)
            {
                if (this.LoadDataChange != null)
                {
                    this.LoadDataChange(null, null);
                }
                DialogResult = DialogResult.OK;
            }
        }
        #endregion

        private void grvDataError_DoubleClick(object sender, EventArgs e)
        {            
            btnEdit_Click(null, null);
        }

        DataTable dtPK;
        void loadPK()
        {
            dtPK = TextUtils.Select("Select * from ModulePart with(nolock) where ModuleID = " + Module.ID);
            grdPK.DataSource = dtPK;
        }

        private void btnAddPK_Click(object sender, EventArgs e)
        {
            frmListMaterial frm = new frmListMaterial();            
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //dtMaterial = frm.dtAll;
                //grdVT.DataSource = dtMaterial;
                foreach (DataRow r in frm.dtAll.Rows)
                {
                    string code = TextUtils.ToString(r["Code"]);
                    if (code == "") continue;
                    DataRow[] drs = dtPK.Select("Code = '" + code + "'");
                    if (drs.Length > 0) continue;

                    DataRow dr = dtPK.NewRow();
                    dr["Code"] = r["Code"].ToString();
                    dr["Name"] = r["Name"].ToString();
                    dr["Qty"] = 1;
                    dtPK.Rows.Add(dr);
                }
            }
        }

        private void btnDeletePK_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvPK.GetFocusedRowCellValue(colIDPK));
            string code = TextUtils.ToString(grvPK.GetFocusedRowCellValue(colCodePK));
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa phụ kiện [" + code + "]?", TextUtils.Caption, 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (id > 0)
                {
                    ModulePartBO.Instance.Delete(id);
                }
                grvPK.DeleteSelectedRows();
            }
        }

    }
}
