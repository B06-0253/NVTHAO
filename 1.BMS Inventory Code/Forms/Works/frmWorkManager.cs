using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Utils;
using BMS.Model;
using BMS.Business;

namespace BMS
{
    public partial class frmWorkManager : _Forms
    {
        public frmWorkManager()
        {
            InitializeComponent();
        }

        private void frmWorkManager_Load(object sender, EventArgs e)
        {
            loadGrid();
        }

        void loadGrid()
        {
            DataTable dt = TextUtils.Select("Select a.* from vWorks a WITH(NOLOCK) Order by Priority");
            grdData.DataSource = null;
            grdData.DataSource = dt;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                TextUtils.ExportExcel(grvData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmWorkView frm = new frmWorkView();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                loadGrid();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            WorksModel model = (WorksModel)WorksBO.Instance.FindByPK(id);

            frmWorkView frm = new frmWorkView();
            frm.Model = model;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                loadGrid();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!grvData.IsDataRow(grvData.FocusedRowHandle))
                return;

            int strID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID).ToString());

            //if (ProductsBO.Instance.CheckExist("ProjectID", strID))
            //{
            //    MessageBox.Show("Công việc này đang được sử dụng nên không thể xóa được!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}

            DialogResult result = MessageBox.Show("Bạn có thực sự muốn xóa công việc này?", TextUtils.Caption, MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                WorksBO.Instance.Delete(strID);
                loadGrid();
            }
        }

        private void grdData_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void btnDistribution_Click(object sender, EventArgs e)
        {
            frmWorkDistribution frm = new frmWorkDistribution();
            TextUtils.OpenForm(frm);
        }       
    }
}
