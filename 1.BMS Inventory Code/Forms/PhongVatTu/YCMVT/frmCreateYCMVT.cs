using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using TPA.Business;
using TPA.Model;
using TPA.Utils;

namespace BMS
{
    public partial class frmCreateYCMVT : _Forms
    {
        DataTable dtR = new DataTable();
        DataTable dtRI = new DataTable();
        bool _active = true;

        #region Constuctor and Load
        public frmCreateYCMVT()
        {
            InitializeComponent();
        }

        private void frmCreateYCMVT_Load(object sender, EventArgs e)
        {
            loadUserFind();
            loadDepartment();

            cboProductType.SelectedIndex = 1;
            cboDepartment.SelectedIndex = 1;

            repositoryItemCheckEdit1.EditValueChanged += OnProjectPostEditor;
            repositoryItemCheckEdit2.EditValueChanged += OnRequestPostEditor;

            string sql = "select *, cast(0 as bit) as [check] from vRequest with(nolock) where RequestId ='' ";
            dtR = LibQLSX.Select(sql);
            grdYCVT.DataSource = dtR;

            string sql1 = "select *, cast(0 as bit) as [check] from vRequestPart with(nolock) where RequestId =''";
            dtRI = LibQLSX.Select(sql1);
            grdParts.DataSource = dtRI;
        }
        #endregion

        #region Methods
        void loadUserFind()
        {
            //load danh sach nhan vien phong vat tu
            DataTable dt = LibQLSX.Select("Select * from [Users] WITH(NOLOCK) where StatusDisable = 0 and DepartmentId ='D004'");
            cboUser.Properties.DataSource = dt;
            cboUser.Properties.DisplayMember = "UserName";
            cboUser.Properties.ValueMember = "UserId";
        }

        void loadDepartment()
        {
            DataTable dtD = LibQLSX.Select("select DepartmentId, DName from Departments with(nolock)");
            cboDepartment.DataSource = dtD;
            cboDepartment.DisplayMember = "DName";
            cboDepartment.ValueMember = "DepartmentId";
        }

        void loadProject()
        {
            string sql = "";
            if (cboProductType.SelectedIndex == 0)
            {
                sql = "select distinct [ProjectId], [ProjectCode], [ProjectName], [Year], cast(0 as bit) as [check] from [vRequest] with(nolock) "
                        + " where ([TotalOut] > 0) "
                        + " and [ProductType] = 1"
                        + " and [DepartmentId] = '" + TextUtils.ToString(cboDepartment.SelectedValue) + "'"
                        + " order by [ProjectCode]";
            }
            if (cboProductType.SelectedIndex == 1)
            {
                sql = "select distinct [ProjectId], [ProjectCode], [ProjectName], [Year], cast(0 as bit) as [check] from [vRequest] with(nolock) "
                        + " where ([TotalPart] > 0) "
                        + " and [ProductType] = 2"
                        + " and [DepartmentId] = '" + TextUtils.ToString(cboDepartment.SelectedValue) + "'"
                        + " order by [ProjectCode]";
            }
            if (cboProductType.SelectedIndex == 2)
            {
                //sql = "select distinct [ProjectId], [ProjectCode], [ProjectName], [Year], cast(0 as bit) as [check] from [vRequest] with(nolock) "
                //        + " where ([TotalMaterial] > 0) "
                //        + " and [ProductType] = 3" 
                //        + " and [DepartmentId] = '" + TextUtils.ToString(cboDepartment.SelectedValue) + "'"
                //        + " order by [ProjectCode]";
            }
            if (sql == "")
                return;
            DataTable dtP = LibQLSX.Select(sql);
            grdProject.DataSource = dtP;
        }

        void addYCVT()
        {
            string sql = "";
            if (cboProductType.SelectedIndex == 0)
            {
                sql = "select [RequestId], [RequestCode], [RequestContent], [ProjectCode], cast(0 as bit) as [check] from [vRequest] with(nolock) "
                        + " where ([TotalOut] > 0) and [StatusConfirm] = 5 "
                        + " and [ProductType] = 1"
                        + " and [ProjectCode] = '" + TextUtils.ToString(grvProject.GetFocusedRowCellValue(colPCode)) + "'"
                        + " and [DepartmentId] = '" + TextUtils.ToString(cboDepartment.SelectedValue)
                        + "' order by [RequestCode]";
            }
            if (cboProductType.SelectedIndex == 1)
            {
                sql = "select [RequestId], [RequestCode], [RequestContent], [ProjectCode], cast(0 as bit) as [check] from [vRequest] with(nolock) "
                        + " where ([TotalPart] > 0 ) and [StatusConfirm] = 5 "
                        + " and [ProductType] = 2"
                        + " and [ProjectCode] = '" + TextUtils.ToString(grvProject.GetFocusedRowCellValue(colPCode))
                        + "' and [DepartmentId] = '" + TextUtils.ToString(cboDepartment.SelectedValue)
                        + "' order by [RequestCode]";
            }
            if (cboProductType.SelectedIndex == 2)
            {
                sql = "select [RequestId], [RequestCode], [RequestContent], [ProjectCode], cast(0 as bit) as [check] from [vRequest] with(nolock) "
                        + " where ([TotalMaterial] > 0) and [StatusConfirm] = 5 "
                        + " and [ProjectCode] is null"
                        + " and [DepartmentId] = '" + TextUtils.ToString(cboDepartment.SelectedValue)
                        + "' order by [RequestCode]";
            }
            if (sql == "")
                return;
            DataTable dtR1 = LibQLSX.Select(sql);
            dtR.Merge(dtR1);
        }

        void addRequestItem(string requestCode)
        {
            string sql = "";

            if (cboProductType.SelectedIndex == 0)
            {
                sql = "select * from vRequestOut with(nolock) where Status = 1 and ProposalId is null and RequestCode ='" + requestCode + "'";                
            }

            if (cboProductType.SelectedIndex == 1)
            {
                sql = "select * from vRequestPart with(nolock) where Status = 1 and ProposalId is null and RequestCode ='" + requestCode + "'";
            }

            if (cboProductType.SelectedIndex == 2)
            {
                sql = "select * from vRequestMaterial with(nolock) where Status = 1 and ProposalId is null and RequestCode ='" + requestCode + "'";
            }

            DataTable dtRi1 = LibQLSX.Select(sql);
            dtRI.Merge(dtRi1);
        }
        #endregion

        #region Events
        void OnProjectPostEditor(object sender, EventArgs e)
        {
            grvProject.PostEditor();
        }

        void OnRequestPostEditor(object sender, EventArgs e)
        {
            grvYCVT.PostEditor();
        }

        private void cboProductType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dtRI.Rows.Clear();
            dtR.Rows.Clear();
            if (chkRAll.Checked)
            {
                chkRAll.Checked = false;
            }
            loadProject();
            if (cboProductType.SelectedIndex==2)
            {
                addYCVT();
            }
        }

        private void cboDepartment_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dtRI.Rows.Clear();
            dtR.Rows.Clear();
            if (chkRAll.Checked)
            {
                chkRAll.Checked = false;
            }
            loadProject();
            if (cboProductType.SelectedIndex == 2)
            {
                addYCVT();
            }
        }

        private void grvProject_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colPCheck)
            {
                bool check = TextUtils.ToBoolean(grvProject.GetFocusedRowCellValue(colPCheck));
                string projectCode = TextUtils.ToString(grvProject.GetFocusedRowCellValue(colPCode));
                if (check)
                {
                    addYCVT();
                }
                else
                {
                    DataRow[] drs = dtR.Select("ProjectCode <> '" + projectCode + "'");
                    if (drs.Length > 0)
                    {
                        dtR = drs.CopyToDataTable();                        
                    }
                    else
                    {
                        dtR.Rows.Clear();
                    }
                    grdYCVT.DataSource = dtR;

                    if (dtRI.Rows.Count > 0)
                    {
                        DataRow[] drsRI = dtRI.Select("ProjectCode <> '" + projectCode + "'");
                        if (drsRI.Length > 0)
                        {
                            dtRI = drsRI.CopyToDataTable();
                        }
                        else
                        {
                            dtRI.Rows.Clear();
                        }
                        grdParts.DataSource = dtRI;
                    }
                }
            }
        }

        private void grvYCVT_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colRcheck && _active)
            {
                bool check = TextUtils.ToBoolean(grvYCVT.GetFocusedRowCellValue(colRcheck));
                string requestCode = TextUtils.ToString(grvYCVT.GetFocusedRowCellValue(colRCode));
                if (check)
                {
                    addRequestItem(requestCode);
                }
                else
                {
                    DataRow[] drs = dtRI.Select("RequestCode <> '" + requestCode + "'");
                    if (drs.Length > 0)
                    {
                        dtRI = drs.CopyToDataTable();
                    }
                    else
                    {
                        dtRI.Rows.Clear();
                        chkRAll.Checked = false;
                    }
                    grdParts.DataSource = dtRI;
                }
            }
        }
        #endregion

        private void chkAllYCVT_CheckedChanged(object sender, EventArgs e)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load vật tư..."))
            {
                _active = false;
                dtRI.Rows.Clear();
                for (int i = 0; i < grvYCVT.RowCount; i++)
                {
                    if (chkRAll.Checked)
                    {
                        string requestCode = "";
                        requestCode = TextUtils.ToString(grvYCVT.GetRowCellValue(i, colRCode));
                        grvYCVT.SetRowCellValue(i, colRcheck, true);
                        addRequestItem(requestCode);
                    }
                    else
                    {
                        grvYCVT.SetRowCellValue(i, colRcheck, false);
                    }
                }
                _active = true;
            }
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            frmConfigManufacturerUser frm = new frmConfigManufacturerUser();
            TextUtils.OpenForm(frm);
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            string userId = TextUtils.ToString(cboUser.EditValue);
            if (userId == "") return;
            string userName = TextUtils.ToString(grvCboUser.GetFocusedRowCellValue(colFullName));

            int[] listHandle = grvParts.GetSelectedRows();
            foreach (int i in listHandle)
            {
                grvParts.SetRowCellValue(i, colRiUserId, userId);
                grvParts.SetRowCellValue(i, colRiUserName, userName);
            }            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //ProcessTransaction pt = new ProcessTransaction();
            //pt.OpenConnection();
            //pt.BeginTransaction();

            //ProposalBuyModel proposal = new ProposalBuyModel();
            //proposal.DateCreate = DateTime.Now;
            //proposal.ProductType = cboProductType.SelectedIndex + 1;
            //proposal.ProposalCode = "";
            //proposal.ProposalId = "";
            //proposal.Status = 1;
            //proposal.StatusConfirm = 1;
            //proposal.UserId = "";
        }       
    }
}
