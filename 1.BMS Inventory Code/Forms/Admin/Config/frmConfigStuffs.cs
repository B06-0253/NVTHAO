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
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;

namespace BMS
{
    public partial class frmConfigStuffs : _Forms
    {
        public frmConfigStuffs()
        {
            InitializeComponent();
        }

        private void frmConfigModulePart_Load(object sender, EventArgs e)
        {
            loadStuffs();
        }

        void loadStuffs()
        {
            DataTable dt = TextUtils.Select("select * from Stuffs with(nolock)");
            grdVL.DataSource = dt;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (grvVL.RowCount == 0) return;
            grvVL.FocusedRowHandle = -1;

            for (int i = 0; i < grvVL.RowCount; i++)
            {
                int id = TextUtils.ToInt(grvVL.GetRowCellValue(i, colID));
                StuffsModel stuff = new StuffsModel();
                if (id > 0)
                {
                    stuff = (StuffsModel)StuffsBO.Instance.FindByPK(id);
                }

                stuff.Code = TextUtils.ToString(grvVL.GetRowCellValue(i, colCode));                
                stuff.Description = TextUtils.ToString(grvVL.GetRowCellValue(i, colDes));
                stuff.Price = TextUtils.ToDecimal(grvVL.GetRowCellValue(i, colPrice));
                stuff.Hang = TextUtils.ToString(grvVL.GetRowCellValue(i, colHang));
                stuff.TypeWeight = TextUtils.ToBoolean(grvVL.GetRowCellValue(i, colWeight));

                if (stuff.Code == "" && stuff.Hang == "") continue;

                if (id > 0)
                {
                    StuffsBO.Instance.Update(stuff);
                }
                else
                {
                    StuffsBO.Instance.Insert(stuff);
                }
            }
            loadStuffs();
            MessageBox.Show("Lưu trữ thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = TextUtils.ToInt(grvVL.GetFocusedRowCellValue(colID));
                string code = grvVL.GetFocusedRowCellValue(colCode).ToString();
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa vật tư [" + code + "]?", TextUtils.Caption,
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (id > 0)
                    {
                        StuffsBO.Instance.Delete(id);
                    }
                    grvVL.DeleteSelectedRows();
                }
            }
            catch (Exception)
            {
            }
        }

        private void grvVL_KeyDown(object sender, KeyEventArgs e)
        {
            if (grvVL.SelectedRowsCount < 1)
            {
                return;
            }
            if (e.KeyCode == Keys.Delete)
            {
                btnDelete_Click(null, null);
            }
        }

        private void grvVL_ShownEditor(object sender, EventArgs e)
        {
            TextEdit edit = (sender as BaseView).ActiveEditor as TextEdit;
            if (edit != null)
                edit.Spin += new DevExpress.XtraEditors.Controls.SpinEventHandler(edit_Spin);
        }

        void edit_Spin(object sender, DevExpress.XtraEditors.Controls.SpinEventArgs e)
        {
            e.Handled = true;
        }
    }
}
