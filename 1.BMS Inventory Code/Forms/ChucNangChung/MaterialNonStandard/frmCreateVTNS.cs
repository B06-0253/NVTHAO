using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Model;
using System.Collections;
using BMS.Business;

namespace BMS
{
    public partial class frmCreateVTNS : _Forms
    {
        public MaterialNSModel MaterialNS = new MaterialNSModel();
        string _materialCode = "";
        string _materialName = "";

        public frmCreateVTNS()
        {
            InitializeComponent();
        }

        private void frmCreateVTNS_Load(object sender, EventArgs e)
        {
            this.Text += " của nhóm: " + MaterialNS.Code;
            _materialCode = MaterialNS.Code;
            loadUserControl();
        }

        void loadUserControl()
        {
            ArrayList listPara = MaterialParamNSBO.Instance.FindByAttribute("MaterialNSID", MaterialNS.ID);
            foreach (var para in listPara)
            {
                MaterialParamNSModel param = (MaterialParamNSModel)para;
                ucDetailTS uc = new ucDetailTS();
                uc.ParamNS = param;
                flpThongSo.Controls.Add(uc);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (flpThongSo.Controls.Count == 0) return;
                _materialCode = MaterialNS.Code;
                _materialName = MaterialNS.Code;

                DataTable dtPart = TextUtils.Select("SELECT top 1 [PartsCode] FROM [ProductionManagement].[dbo].[Parts] where Replace(PartsCode,' ','') = '"
                    + MaterialNS.Code + "'");
                if (dtPart.Rows.Count > 0)
                {
                    MessageBox.Show("Mã vật tư đã có trên quản lý sản xuất!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                bool error = false;
                foreach (Control control in flpThongSo.Controls)
                {
                    ucDetailTS uc = (ucDetailTS)control;
                    if (uc.Value == "")
                    {
                        error = true;
                        break;
                    }
                    _materialCode = _materialCode.Replace("[" + uc.ParamNS.Code + "]", uc.Value);
                    _materialName = _materialName.Replace("[" + uc.ParamNS.Code + "]", uc.ParamNS.Name + ":" + uc.Value
                        + uc.ParamNS.Unit + (uc.Des == "" ? "" : "(" + uc.Des + ")"));
                }
                if (error)
                {
                    //txtCode.Text = "";
                    txtFull.Text = "";
                    MessageBox.Show("Không thể tạo được vật tư phi tiêu chuẩn.\n Chưa điền đầy đủ giá trị cho các thông số",
                        TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int i = _materialName.IndexOf('-');
                txtFull.Text = "Mã vật tư: " + _materialCode + Environment.NewLine + "Tên vật tư: " + _materialName.Replace(_materialName.Substring(0, i), MaterialNS.Name);
                txtCode.Text = _materialCode;
                txtName.Text = _materialName.Replace(_materialName.Substring(0, i), MaterialNS.Name);
                txtFull.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tạo mã không thành công!\n Có thể mã vật tư phi tiêu chuẩn không đúng định dạng!" + Environment.NewLine + ex.Message);
            }            
        }

        private void btnCopyCode_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtCode.Text);
        }

        private void btnCopyName_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtName.Text);
        }

        private void btnCopyFull_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtFull.Text);
        }
    }
}
