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

namespace BMS
{
    public partial class frmErrorManager : _Forms
    {
        public frmErrorManager()
        {
            InitializeComponent();
        }

        private void frmErrorManager_Load(object sender, EventArgs e)
        {
            loadGrid();
        }

        void loadGrid()
        {
            DataTable dt = TextUtils.Select("vModuleError", null);
            grdData.DataSource = dt;
            grvData.BestFitColumns();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmError frm = new frmError();            
            if (frm.ShowDialog()==DialogResult.OK)
            {
                loadGrid();
            }
        }
       
        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id <= 0) return;
            frmError frm = new frmError();
            frm.ErrorModel = (ModuleErrorModel)ModuleErrorBO.Instance.FindByPK(id);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                loadGrid();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id <= 0) return;
            DialogResult result = MessageBox.Show("Bạn có thật sự muốn xóa lỗi này!", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ModuleErrorBO.Instance.Delete(id);
                loadGrid();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnErrorReport_Click(object sender, EventArgs e)
        {
            frmErrorReport frm = new frmErrorReport();
            TextUtils.OpenForm(frm);
        }      

    }
}
