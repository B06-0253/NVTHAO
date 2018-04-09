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
    public partial class frmSolutionManagement : _Forms
    {
        int _rownIndex = 0;

        public frmSolutionManagement()
        {
            InitializeComponent();
        }

        private void SolutionManagement_Load(object sender, EventArgs e)
        {
            loadKhachHang();
        }

        void loadKhachHang()
        {
            DataTable dt = LibQLSX.Select("Select * from Customers with(nolock)");
            cboKH.Properties.DataSource = dt;
            cboKH.Properties.ValueMember = "CustomerCode";
            cboKH.Properties.DisplayMember = "CustomerName";
        }

        void loadYC()
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load dữ liệu..."))
            {
                try
                {
                    string[] paraName = new string[2];
                    object[] paraValue = new object[2];

                    paraName[0] = "@CustomerCode";                    
                    paraValue[0] = TextUtils.ToString(cboKH.EditValue);
                    paraName[1] = "@TextFind"; paraValue[1] = txtName.Text.Trim();
                    DataTable Source = RequireSolutionBO.Instance.LoadDataFromSP("spGetFilterRequire", "Source", paraName, paraValue);

                    grdYC.DataSource = Source;
                    
                }
                catch (Exception ex)
                {
                    grdYC.DataSource = null; ;
                }
            }
        }

        void LoadInfoSearch(int type = 0)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load dữ liệu..."))
            {
                try
                {
                    string[] paraName = new string[2];
                    object[] paraValue = new object[2];

                    paraName[0] = "@RequireID";
                    if (type == 0)
                    {
                        paraValue[0] = TextUtils.ToInt(grvYC.GetFocusedRowCellValue(colYCID));
                    }
                    else
                    {
                        paraValue[0] = 0;
                    }

                    paraName[1] = "@TextFind"; paraValue[1] = txtName.Text.Trim();

                    DataTable Source = SolutionBO.Instance.LoadDataFromSP("spGetFilterSolution", "Source", paraName, paraValue);

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
            string cusCode = TextUtils.ToString(cboKH.EditValue);
            long ycID = TextUtils.ToInt64(grvYC.GetFocusedRowCellValue(colYCID));
            if (cusCode == "")
            {
                MessageBox.Show("Bạn phải chọn một khách hàng!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (ycID == 0)
            {
                MessageBox.Show("Bạn phải chọn một yêu cầu!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            frmSolution frm = new frmSolution();
            frm.CustomerCode = cusCode;
            frm.RequireID = ycID;
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            SolutionModel model = (SolutionModel)SolutionBO.Instance.FindByPK(id);
            _rownIndex = grvData.FocusedRowHandle;
            frmSolution frm = new frmSolution();
            frm.Solution = model;
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            if (MessageBox.Show("Bạn có chắc muốn xóa giải pháp [" + grvData.GetFocusedRowCellValue(colCode).ToString() + "] không?",
                      TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            SolutionModel model = (SolutionModel)SolutionBO.Instance.FindByPK(id);
            model.IsDeleted = true;
            SolutionBO.Instance.Update(model);
            LoadInfoSearch();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (grvData.RowCount > 0)
            {
                TextUtils.ExportExcel(grvData);
            }
        }

        private void cboKH_EditValueChanged(object sender, EventArgs e)
        {
            loadYC();
        }

        private void grvYC_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadInfoSearch();
        }

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
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

        private void btnFindAll_Click(object sender, EventArgs e)
        {
            LoadInfoSearch(1);
        }

        private void btnCheckCTGP_Click(object sender, EventArgs e)
        {
            frmCheckCTGP frm = new frmCheckCTGP();
            TextUtils.OpenForm(frm);
        }
    }
}
