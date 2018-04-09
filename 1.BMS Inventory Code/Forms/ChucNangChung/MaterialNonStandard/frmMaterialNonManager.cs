using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using BMS.Business;
using BMS.Model;
using System.Collections;
using BMS.Utils;

namespace BMS
{
    public partial class frmMaterialNonManager : _Forms
    {
        int _curentNode = 0;
        int _rownIndex = 0;

        public frmMaterialNonManager()
        {
            InitializeComponent();
        }

        private void frmMaterialNonManager_Load(object sender, EventArgs e)
        {
            LoadInfoSearch();
        }

        void LoadInfoSearch()
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load nhóm vật tư phi tiêu chuẩn..."))
            {
                try
                {
                    string[] paraName = new string[1];
                    object[] paraValue = new object[1];
                    paraName[0] = "@Text"; paraValue[0] = "";

                    DataTable Source = MaterialNSBO.Instance.LoadDataFromSP("spGetFilterMaterialNS", "Source", paraName, paraValue);
                    grdGroup.DataSource = Source;
                    if (_rownIndex >= grvData.RowCount)
                        _rownIndex = 0;
                    if (_rownIndex > 0)
                        grvGroup.FocusedRowHandle = _rownIndex;
                    grvGroup.SelectRow(_rownIndex);
                }
                catch (Exception ex)
                {
                    return;
                }
            }
        }

        void main_LoadDataChange(object sender, int node)
        {
            _curentNode = node;
            LoadInfoSearch();
        }

        private void btnFindAll_Click(object sender, EventArgs e)
        {
            LoadInfoSearch();
        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadInfoSearch();
                ((TextBox)sender).Focus();
            }
        }

        private void btnNewGroup_Click(object sender, EventArgs e)
        {
            frmMaterialGroupNS frm = new frmMaterialGroupNS();
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnEditGroup_Click(object sender, EventArgs e)
        {
            try
            {
                int id = TextUtils.ToInt(grvGroup.GetFocusedRowCellValue(colGroupID));
                if (id == 0) return;
                _rownIndex = grvGroup.FocusedRowHandle;
                MaterialNSModel model = (MaterialNSModel)MaterialNSBO.Instance.FindByPK(id);

                frmMaterialGroupNS frm = new frmMaterialGroupNS();
                frm.MaterialNS = model;
                frm.LoadDataChange += main_LoadDataChange;
                frm.Show();
            }
            catch (Exception)
            {               
            }            
        }

        private void btnDeleteGroup_Click(object sender, EventArgs e)
        {
            try
            {
                int id = TextUtils.ToInt(grvGroup.GetFocusedRowCellValue(colGroupID));
                if (id == 0) return;

                //if (MaterialParamNSBO.Instance.CheckExist("MaterialParamNS", id))
                //{
                //    MessageBox.Show("Nhóm Vật tư này đang chứa thông số nên không thể xóa được.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //    return;
                //}

                if (MessageBox.Show("Bạn có chắc muốn xóa nhóm [" + TextUtils.ToString(grvGroup.GetFocusedRowCellValue(colGroupName)) + "] không?",
                      TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                MaterialNSBO.Instance.Delete(id);
                MaterialParamNSBO.Instance.DeleteByExpression(new Expression("MaterialNSID", id));
                LoadInfoSearch();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (grvData.RowCount == 0)
            {
                MessageBox.Show("Nhóm vật tư không có thông số!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int id = TextUtils.ToInt(grvGroup.GetFocusedRowCellValue(colGroupID));
            if (id == 0) return;
            MaterialNSModel model = (MaterialNSModel)MaterialNSBO.Instance.FindByPK(id);

            frmCreateVTNS frm = new frmCreateVTNS();
            frm.MaterialNS = model;
            TextUtils.OpenForm(frm);
        }

        private void grvGroup_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                int id = TextUtils.ToInt(grvGroup.GetFocusedRowCellValue(colGroupID));
                if (id == 0) return;
                ArrayList model = MaterialParamNSBO.Instance.FindByAttribute("MaterialNSID", id);

                grdData.DataSource = model;

                string filePath = TextUtils.ToString(grvGroup.GetFocusedRowCellValue(colFilePath));
                if (filePath != "")
                {
                    pictureBox1.ImageLocation = filePath;
                }
                else
                {
                    pictureBox1.Image = null;
                }
            }
            catch (Exception)
            {
            }     
        }

        private void grvGroup_DoubleClick(object sender, EventArgs e)
        {
            btnEditGroup_Click(null, null);
        }

        private void grvGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == (Keys.C))
            {
                try
                {
                    string text = TextUtils.ToString(grvGroup.GetFocusedRowCellValue(grvGroup.FocusedColumn));
                    Clipboard.SetText(text);
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
