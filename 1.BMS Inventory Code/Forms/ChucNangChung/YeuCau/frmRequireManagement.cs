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

namespace BMS
{
    public partial class frmRequireManagement : _Forms
    {
        int _rownIndex = 0;

        public frmRequireManagement()
        {
            InitializeComponent();
        }

        private void frmRequireManagement_Load(object sender, EventArgs e)
        {
            loadKhachHang();
            LoadInfoSearch();
        }

        void loadKhachHang()
        {
            DataTable dt = LibQLSX.Select("Select * from Customers with(nolock)");
            grdKH.DataSource = dt;
        }

        void LoadInfoSearch(int type = 0)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load dữ liệu..."))
            {
                try
                {
                    string[] paraName = new string[2];
                    object[] paraValue = new object[2];

                    paraName[0] = "@CustomerCode";
                    if (type == 0)
                    {
                         paraValue[0] = TextUtils.ToString(grvKH.GetFocusedRowCellValue(colKHCode));
                    }
                    else
                    {
                        paraValue[0] = "";
                    }
                    
                    paraName[1] = "@TextFind"; paraValue[1] = txtName.Text.Trim();

                    DataTable Source = RequireSolutionBO.Instance.LoadDataFromSP("spGetFilterRequire", "Source", paraName, paraValue);

                    grdData.DataSource = Source;
                    if (_rownIndex >= grvData.RowCount)
                        _rownIndex = 0;
                    if (_rownIndex > 0)
                        grvData.FocusedRowHandle = _rownIndex;
                    grvData.SelectRow(_rownIndex);
                    grvData.BestFitColumns();
                }
                catch (Exception ex)
                {
                    return;
                }
            }
        }

        void main_LoadDataChange(object sender, EventArgs e)
        {
            LoadInfoSearch();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string customerCode = TextUtils.ToString(grvKH.GetFocusedRowCellValue(colKHCode));

            frmRequire frm = new frmRequire();
            frm.CustomerCode = customerCode;            
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            RequireSolutionModel model = (RequireSolutionModel)RequireSolutionBO.Instance.FindByPK(id);
            _rownIndex = grvData.FocusedRowHandle;
            frmRequire frm = new frmRequire();
            frm.Require = model;
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            if (MessageBox.Show("Bạn có chắc muốn xóa yêu cầu [" + grvData.GetFocusedRowCellValue(colName).ToString() + "] không?",
                      TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            RequireSolutionModel model = (RequireSolutionModel)RequireSolutionBO.Instance.FindByPK(id);
            model.IsDeleted = true;
            RequireSolutionBO.Instance.Update(model);
            LoadInfoSearch();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (grvData.RowCount > 0)
            {
                TextUtils.ExportExcel(grvData);
            }
        }

        private void grvKH_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadInfoSearch();
        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadInfoSearch(1);
                ((TextBox)sender).Focus();
            }
        }

        private void grvData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C)
            {
                try
                {
                    string text = TextUtils.ToString(grvData.GetFocusedRowCellValue(grvData.FocusedColumn));
                    Clipboard.SetText(text);
                }
                catch
                {
                }
            }
        }

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }
    }
}
