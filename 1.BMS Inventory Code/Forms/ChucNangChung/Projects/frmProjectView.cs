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

namespace BMS
{
    public partial class frmProjectView : _Forms
    {
        #region Variables
        public ProjectInfoModel Model = new ProjectInfoModel();
        #endregion

        public frmProjectView()
        {
            InitializeComponent();
        }

        private void frmProjectView_Load(object sender, EventArgs e)
        {
            if (Model.ID != 0)
            {
                btnImport.Visible = false;
                txtProjectName.Text = Model.ProjectName;
                txtProjectCode.Text = Model.ProjectCode;
                txtContractCode.Text = Model.ContractCode;
                txtContractName.Text = Model.ContractName;
                txtCurator.Text = Model.Curator;
                txtCustomerName.Text = Model.CustomerName;
                txtDescription.Text = Model.Description;
                txtLastCustomerName.Text = Model.LastCustomerName;
                txtReception.Text = Model.Reception;
                txtRequirement.Text = Model.Requirement;
                txtDescription.Text = Model.Description;

                txtPriority.Text = Model.Priority;
                cboStatus.SelectedIndex = Model.Status;
            }
            else
            {
                
            }
        }

        #region Functions

        private bool ValidateForm()
        {
            if (txtProjectCode.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền Mã dự án.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
            {
                DataTable dt;
                if (Model.ID > 0)
                {
                    dt = TextUtils.Select("select ProjectCode from ProjectInfo where ProjectCode = '" + txtProjectCode.Text.Trim() + "' and ID <> " + Model.ID);
                }
                else
                {
                    dt = TextUtils.Select("select ProjectCode from ProjectInfo where ProjectCode = '" + txtProjectCode.Text.Trim() + "'");
                }
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Mã dự án này đã được sử dụng!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }
                }
            }
           
            if (txtProjectName.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền Tên dự án.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

                Model.ProjectCode = txtProjectCode.Text.Trim();
                Model.ProjectName = txtProjectName.Text.Trim();
                Model.ContractCode = txtContractCode.Text.Trim();
                Model.ContractName = txtContractName.Text.Trim();
                Model.Curator = txtCurator.Text.Trim();
                Model.Reception = txtReception.Text.Trim();
                Model.Requirement = txtRequirement.Text.Trim();
                Model.Status = cboStatus.SelectedIndex;
                Model.CustomerName = txtCustomerName.Text.Trim();
                Model.LastCustomerName = txtLastCustomerName.Text.Trim();
                Model.Priority = txtPriority.Text.Trim();
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

                if (_listProducts.Count > 0)
                {
                    foreach (ProductsModel item in _listProducts)
                    {
                        item.CreatedBy = Global.AppUserName;
                        item.CreatedDate = TextUtils.GetSystemDate();
                        item.UpdatedDate = item.CreatedDate;
                        item.UpdatedBy = Global.AppUserName;
                        item.ProjectInfoID = Model.ID;                        
                        pt.Insert(item);
                    }
                }                
                //MessageBox.Show("Lưu trữ thành công!", "Thông báo");
                pt.CommitTransaction();
                this.DialogResult = DialogResult.OK;
                
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        List<ProductsModel> _listProducts = new List<ProductsModel>();

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();

                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    dt = TextUtils.ExcelToDatatable(ofd.FileName);
                }

                if (dt.Rows.Count <= 0) return;
                if (dt.Rows[6][2].ToString() == "") return;//check mã dự án

                txtProjectCode.Text = dt.Rows[6][2].ToString();
                txtProjectName.Text = dt.Rows[6][5].ToString();
                txtContractCode.Text = dt.Rows[7][2].ToString();
                txtContractName.Text = txtContractCode.Text.Trim() != "" ? "Hợp đồng kinh tế số " + dt.Rows[7][2].ToString() : "";
                txtCurator.Text = dt.Rows[5][5].ToString();
                txtCustomerName.Text = dt.Rows[9][2].ToString();
                txtLastCustomerName.Text = dt.Rows[9][5].ToString();
                txtReception.Text = dt.Rows[8][5].ToString();

                txtRequirement.Text = dt.Rows[8][2].ToString();
                txtPriority.Text = dt.Rows[5][2].ToString();

                cboStatus.SelectedIndex = 0;

                for (int i = 13; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][3].ToString() == "" || dt.Rows[i][1].ToString() == "") continue;
                    ProductsModel model = new ProductsModel();
                    model.PjCode = dt.Rows[i][3].ToString();
                    model.PjName = dt.Rows[i][1].ToString();
                    model.Quantity = TextUtils.ToInt(dt.Rows[i][5]);
                    model.Unit = dt.Rows[i][4].ToString();
                    _listProducts.Add(model);
                }
            }
            catch (Exception ex)
            {
                TextUtils.ShowError(ex);
            }
           
        }
        #endregion       
    }
}
