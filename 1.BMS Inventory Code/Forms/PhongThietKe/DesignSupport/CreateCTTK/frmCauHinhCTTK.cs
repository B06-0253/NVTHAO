using BMS.Model;
using BMS.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BMS.Utils;

namespace BMS
{
    public partial class frmCauHinhCTTK : _Forms
    {
        private int _ID;

        public frmCauHinhCTTK()
        {
            InitializeComponent();
        }

        private void frmCauHinhCTTK_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigSystemModel model = (ConfigSystemModel)ConfigSystemBO.Instance.FindByAttribute("KeyName", "CTTK")[0];
                mmeText.Text = model.KeyValue;
                _ID = TextUtils.ToInt(model.ID);
            }
            catch (Exception ex)
            {
                TextUtils.ShowError(ex);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNewGroup_Click(object sender, EventArgs e)
        {
            try
            {
                ConfigSystemModel model = new ConfigSystemModel();
                model.KeyValue = mmeText.Text;
                model.KeyName = "CTTK";
                model.ID = _ID;
                ConfigSystemBO.Instance.Update(model);
                MessageBox.Show("OK");
                this.Close();
            }
            catch (Exception ex)
            {
                TextUtils.ShowError(ex);
            }

        }
    }
}