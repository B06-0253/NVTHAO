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
using System.Drawing.Imaging;
using DevExpress.Utils;

namespace BMS
{
    public partial class frmCoCauMau : _Forms
    {
        #region Variables
        public CoCauMauModel CoCau = new CoCauMauModel();
        public int GroupID = 0;
        bool _isSaved = false;

        public delegate void LoadDataChangeHandler(object sender, EventArgs e);
        public event LoadDataChangeHandler LoadDataChange;
        #endregion

        public frmCoCauMau()
        {
            InitializeComponent();
        }

        private void frmCoCauMau_Load(object sender, EventArgs e)
        {
            GridLocalizer.Active = new MyGridLocalizer();
            loadCombo();
            if (CoCau.ID != 0)
            {
                txtName.Text = CoCau.Name;
                txtCode.Text = CoCau.Code;
                txtDescription.Text = CoCau.Note;
                //cboStatus.SelectedIndex = CoCau.Status;
                cboGroup.EditValue = CoCau.CoCauGroupID;               
                txtTSKT.Text = CoCau.Specifications.Replace("\n", "\r\n");
              
                this.Text = this.Text + ": " + CoCau.Code + "-" + CoCau.Name;

                string imagePath = CoCau.ImagePath;
                if (File.Exists(imagePath))
                {
                    pictureBox1.ImageLocation = imagePath;
                }
            }
        }

        void loadCombo()
        {
            DataTable tbl = TextUtils.Select(@"SELECT ID,Code +'-'+Name as Code FROM CoCauGroup WITH(NOLOCK) ORDER BY Code");
            if (tbl == null)
            {
                return;
            }
            TextUtils.PopulateCombo(cboGroup, tbl.Copy(), "Code", "ID", "");
        }

        bool ValidateForm()
        {
            if (cboGroup.EditValue == null)
            {
                MessageBox.Show("Xin hãy chọn nhóm cơ cấu.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (txtCode.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền Mã.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
            {
                DataTable dt;
                if (CoCau.ID > 0)
                {
                    dt = TextUtils.Select("select Code from CoCauMau where Code = '" + txtCode.Text.Trim() + "' and ID <> " + CoCau.ID);
                }
                else
                {
                    dt = TextUtils.Select("select Code from CoCauMau where Code = '" + txtCode.Text.Trim() + "'");
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

                if (CoCau.ID == 0)
                {
                    CoCau = new CoCauMauModel();
                }

                CoCau.Name = txtName.Text.Trim().ToUpper();
                CoCau.Code = txtCode.Text.Trim().ToUpper();
                CoCau.CoCauGroupID = TextUtils.ToInt(cboGroup.EditValue);
                //CoCau.Note = txtDescription.Text.Trim();
                CoCau.Description = txtDescription.Text.Trim();
                CoCau.Specifications = txtTSKT.Text.Trim();
                CoCau.ImagePath = pictureBox1.ImageLocation;

                if (CoCau.ID == 0)
                {
                    CoCau.ID = (int)pt.Insert(CoCau);
                }
                else
                {
                    pt.Update(CoCau);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            save(false);
            if (_isSaved)
            {
                if (this.LoadDataChange != null)
                {
                    this.LoadDataChange(null, null);
                }
            }
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            save(true);
            if (_isSaved)
            {
                if (this.LoadDataChange != null)
                {
                    this.LoadDataChange(null, null);
                }
                this.Close();
            }
        }

        private void frmCoCauMau_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "File .iam|*iam|All File|*.*";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load ảnh..."))
                {
                    IPTDetail.LoadData(ofd.FileName);
                    string imagePath = TextUtils.GetConfigValue("CoCauPath") + "\\" + CoCau.Code.Trim() + ".png";
                    Bitmap bit = new Bitmap(IPTDetail.Image, IPTDetail.Image.Width / 3, IPTDetail.Image.Height / 3);
                    bit.Save(imagePath, ImageFormat.Png);
                    pictureBox1.ImageLocation = imagePath;
                }
            }
        }

        private void cboGroup_EditValueChanged(object sender, EventArgs e)
        {
            int groupID = TextUtils.ToInt(cboGroup.EditValue);
            if (groupID == 0) return;
            if (CoCau.ID > 0)
            {
                if (groupID != CoCau.CoCauGroupID)
                {                 
                    CoCauGroupModel model = (CoCauGroupModel)CoCauGroupBO.Instance.FindByPK(groupID);
                    txtDescription.Text = model.Description;
                }
                else
                {
                    txtDescription.Text = CoCau.Description;
                }
            }
            else
            {
                CoCauGroupModel model = (CoCauGroupModel)CoCauGroupBO.Instance.FindByPK(groupID);
                txtDescription.Text = model.Description;
            }            
        }
    }
}
