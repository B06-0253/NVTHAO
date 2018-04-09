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

namespace BMS
{
    public partial class frmPartsGeneral : _Forms
    {
        public PartsGeneralModel PartA = new PartsGeneralModel();
        bool _isSaved = false;
        public delegate void LoadDataChangeHandler(object sender, EventArgs e);
        public event LoadDataChangeHandler LoadDataChange;

        public frmPartsGeneral()
        {
            InitializeComponent();
        }

        private void frmPartAccessories_Load(object sender, EventArgs e)
        {
            if (PartA.PartsId != "")
            {
                DataTable dt = LibQLSX.Select("select * from vPartsGeneral where PartsId = '" + PartA.PartsId + "'");
                txtCode.Text = TextUtils.ToString(dt.Rows[0]["PartsCode"]);
                txtHang.Text = TextUtils.ToString(dt.Rows[0]["ManufacturerCode"]);
                txtName.Text = TextUtils.ToString(dt.Rows[0]["PartsName"]);
                txtPrice.EditValue = TextUtils.ToDecimal(dt.Rows[0]["Price"]);
                txtUnit.Text = TextUtils.ToString(dt.Rows[0]["Unit"]);

                txtProjectPercent.EditValue = PartA.ProjectPercent;
                txtQtyDM.EditValue = PartA.QtyDM;
                txtQtyMin.EditValue = PartA.QtyMin;
                

                cboType.SelectedIndex = PartA.Type;

                this.Text += ": " + txtCode.Text.Trim();
            }
        }
        bool ValidateForm()
        {
            //if (txtCode.Text.Trim() == "")
            //{
            //    MessageBox.Show("Xin hãy điền Mã.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return false;
            //}
            //else
            //{
            //    DataTable dt;
            //    if (PartA.ID > 0)
            //    {
            //        dt = TextUtils.Select("select Code from PartAccessories where Code = '" + txtCode.Text.Trim() + "' and ID <> " + PartA.ID);
            //    }
            //    else
            //    {
            //        dt = TextUtils.Select("select Code from PartAccessories where Code = '" + txtCode.Text.Trim() + "'");
            //    }
            //    if (dt != null)
            //    {
            //        if (dt.Rows.Count > 0)
            //        {
            //            MessageBox.Show("Mã này đã tồn tại!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //            return false;
            //        }
            //    }
            //}
            //if (txtName.Text.Trim() == "")
            //{
            //    MessageBox.Show("Xin hãy điền Tên.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return false;
            //}

            if (cboType.SelectedIndex < 0)
            {
                MessageBox.Show("Xin hãy loại vật tư.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

                //PartA.Name = txtName.Text.Trim().ToUpper();
                //PartA.Code = txtCode.Text.Trim().ToUpper();
                //PartA.Type = cboType.SelectedIndex;
                //PartA.Unit = txtUnit.Text.Trim();
                PartA.QtyMin = TextUtils.ToDecimal(txtQtyMin.EditValue);
                PartA.QtyDM = TextUtils.ToDecimal(txtQtyDM.EditValue);

                PartA.ProjectPercent = TextUtils.ToDecimal(txtProjectPercent.EditValue);
                //PartA.Price = TextUtils.ToDecimal(txtPrice.EditValue);
                PartA.IsProject = PartA.ProjectPercent > 0 ? 1 : 0;
                PartA.Qty = TextUtils.ToDecimal(txtQty.EditValue);
                //PartA.Hang = txtHang.Text.Trim();

                //if (PartA.ID == 0)
                //{
                //    PartA.ID = (int)pt.Insert(PartA);
                //}
                //else
                //{
                    pt.UpdateQLSX(PartA);
                //}

                pt.CommitTransaction();

                _isSaved = true;

                MessageBox.Show("Lưu trữ thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            save();
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            save();
            if (_isSaved)
            {
                if (this.LoadDataChange != null)
                {
                    this.LoadDataChange(null, null);
                }
            }
        }
    }
}
