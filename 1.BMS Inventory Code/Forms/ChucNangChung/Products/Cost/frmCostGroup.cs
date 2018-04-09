using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Business;
using BMS.Model;
using BMS.Utils;

namespace BMS
{
    public partial class frmCostGroup : _Forms
    {
        int _rownIndex = 0;

        public frmCostGroup()
        {
            InitializeComponent();
        }

        private void frmCostGroup_Load(object sender, EventArgs e)
        {            
            loadData();
        }

        void loadData()
        {
            try
            {
                DataTable tbl = TextUtils.Select("Select * from CostGroup with(nolock)");
                grdData.DataSource = tbl;
                if (_rownIndex >= grvData.RowCount)
                    _rownIndex = 0;
                if (_rownIndex > 0)
                    grvData.FocusedRowHandle = _rownIndex;
                grvData.SelectRow(_rownIndex);
            }
            catch (Exception)
            {
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmCostGroupDetail frm = new frmCostGroupDetail();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                loadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            
            if (grvData.FocusedRowHandle < 0) return;
            _rownIndex = grvData.FocusedRowHandle;

            CostGroupModel model = (CostGroupModel)CostGroupBO.Instance.FindByPK(TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID)));
            frmCostGroupDetail frm = new frmCostGroupDetail();
            frm.CostGroup = model;            
            if (frm.ShowDialog() == DialogResult.OK)
            {
                loadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!grvData.IsDataRow(grvData.FocusedRowHandle))
                return;

            int strID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID).ToString());

            string strName = grvData.GetFocusedRowCellValue(colName).ToString();

            if (CostLinkBO.Instance.CheckExist("CostGroupID", strID))
            {
                MessageBox.Show("Nhóm chi phí này đang được sử dụng nên không thể xóa được!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (MessageBox.Show(String.Format("Bạn có chắc muốn xóa [{0}] không?", strName), TextUtils.Caption,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    CostGroupBO.Instance.Delete(Convert.ToInt32(strID));
                    loadData();
                }
                catch
                {
                    MessageBox.Show("Có lỗi xảy ra khi thực hiện thao tác, xin vui lòng thử lại sau.");
                }
            }
        }

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void grvData_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataTable dtCost = TextUtils.Select("vCostLink", new Expression("CostGroupID", TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID))));
            gridDetail.DataSource = dtCost;
        }

       
    }
}
