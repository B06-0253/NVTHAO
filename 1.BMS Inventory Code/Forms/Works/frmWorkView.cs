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

namespace BMS
{
    public partial class frmWorkView : _Forms
    {
        #region Variables
        public WorksModel Model = new WorksModel();
        #endregion

        public frmWorkView()
        {
            InitializeComponent();
            loadProduct();
        }

        private void frmWorkView_Load(object sender, EventArgs e)
        {
            if (Model.ID != 0)
            {
                cboStatus.SelectedIndex = Model.WorkStatusID;
                cboType.SelectedIndex = Model.Type;
                cboWorkType.SelectedIndex = Model.WorkTypeID;
                leProducts.EditValue = Model.ProductID;
                txtName.Text = Model.Name;
                txtCode.Text = Model.Code;
                txtTotalTime.Value =(decimal) Model.TotalTime;
                txtTotalScore.Value = (decimal)Model.TotalScore;
                txtPriority.Value = (decimal)Model.Priority;
                txtDescription.Text = Model.Description;
            }
            else
            {
                cboStatus.SelectedIndex = 0;
            }
        }

        #region Functions

        void loadProduct()
        {
            DataTable dt = TextUtils.Select("Select a.* from vProducts a with(nolock)");
            leProducts.Properties.DataSource = dt;
            leProducts.Properties.DisplayMember = "Name";
            leProducts.Properties.ValueMember = "ID";
        }

        private bool ValidateForm()
        {
            if (txtCode.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền Mã công việc.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
            {
                DataTable dt;
                if (Model.ID > 0)
                {
                    dt = TextUtils.Select("select Code from Works where Code = '" + txtCode.Text.Trim() + "' and ID <> " + Model.ID);
                }
                else
                {
                    dt = TextUtils.Select("select Code from Works where Code = '" + txtCode.Text.Trim() + "'");
                }
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Mã công việc này đã được sử dụng!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }
                }
            }
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền Tên công việc.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (txtPriority.Text.Trim() == "" || txtPriority.Text.Trim() == "0")
            {
                MessageBox.Show("Xin hãy điền Mức độ ưu tiên của công việc.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            return true;
        }
        #endregion

        #region Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();

            try
            {
                if (!ValidateForm())
                    return;
               
                Model.Code = txtCode.Text.Trim();
                Model.Name = txtName.Text.Trim();
                Model.TotalTime = (double)txtTotalTime.Value;
                Model.ProductID = TextUtils.ToInt(leProducts.EditValue);
                Model.WorkStatusID = cboStatus.SelectedIndex;
                Model.WorkTypeID = cboWorkType.SelectedIndex;
                Model.Type = cboType.SelectedIndex;
                Model.TotalScore = TextUtils.ToDouble(txtTotalScore.Value);
                Model.Priority = TextUtils.ToInt(txtPriority.Value);
                Model.Description = txtDescription.Text.Trim();

                if (Model.ID == 0)
                {
                    Model.CreatedDate = TextUtils.GetSystemDate();
                    Model.CreatedBy = Global.AppUserName;
                    Model.UpdatedDate = Model.CreatedDate;
                    Model.UpdatedBy = Global.AppUserName;
                    Model.ID = (int)pt.Insert(Model);
                }
                else
                {
                    Model.UpdatedDate = TextUtils.GetSystemDate();
                    Model.UpdatedBy = Global.AppUserName;
                    pt.Update(Model);
                }

                pt.CommitTransaction();

                MessageBox.Show("Lưu trữ thành công!", "Thông báo");
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            { pt.CloseConnection(); }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion       
    }
}
