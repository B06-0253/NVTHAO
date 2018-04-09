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

namespace BMS
{
    public partial class frmConfigNoConvert : _Forms
    {
        public frmConfigNoConvert()
        {
            InitializeComponent();
        }

        private void frmConfigNoConvert_Load(object sender, EventArgs e)
        {
            loadData();
        }

        void loadData()
        {
            DataTable dt = TextUtils.Select("select * from ConfigNoConvertMaterial with(nolock)");
            grdVL.DataSource = dt;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (grvVL.RowCount == 0) return;
            grvVL.FocusedRowHandle = -1;

            for (int i = 0; i < grvVL.RowCount; i++)
            {
                int id = TextUtils.ToInt(grvVL.GetRowCellValue(i, colID));
                ConfigNoConvertMaterialModel model = new ConfigNoConvertMaterialModel();
                if (id > 0)
                {
                    model = (ConfigNoConvertMaterialModel)ConfigNoConvertMaterialBO.Instance.FindByPK(id);
                }

                model.MaterialCode = TextUtils.ToString(grvVL.GetRowCellValue(i, colCode));
                model.MaterialName = TextUtils.ToString(grvVL.GetRowCellValue(i, colName));
                model.UnitTK = TextUtils.ToString(grvVL.GetRowCellValue(i, colUnitTK));
                model.UnitQLSX = TextUtils.ToString(grvVL.GetRowCellValue(i, colUnitQLSX));

                if (id > 0)
                {
                    ConfigNoConvertMaterialBO.Instance.Update(model);
                }
                else
                {
                    ConfigNoConvertMaterialBO.Instance.Insert(model);
                }
            }
            loadData();
            MessageBox.Show("Lưu trữ thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = TextUtils.ToInt(grvVL.GetFocusedRowCellValue(colID));
                string code = grvVL.GetFocusedRowCellValue(colCode).ToString();
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa mã vật liệu [" + code + "]?", TextUtils.Caption,
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (id > 0)
                    {
                        ConfigNoConvertMaterialBO.Instance.Delete(id);
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
    }
}
