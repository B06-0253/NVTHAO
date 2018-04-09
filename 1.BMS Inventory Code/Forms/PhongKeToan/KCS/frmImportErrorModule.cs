using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPA.Model;
using TPA.Business;
using TPA.Utils;
using System.Collections;
using System.IO;

namespace BMS
{
    public partial class frmImportErrorModule : _Forms
    {
        public int ProductImportType = 1;
        public decimal Qty = 0;
        public string PartsCode = "";
        public string DNNK = "";
        bool _isNew = false;
        public int ImportStatus = 0;
        public ProjectProductImportModel ProjectProductImport = new ProjectProductImportModel();
        bool _isSaved = false;

        string _projectCode = "";
        int _moduleID = 0;

        public delegate void LoadDataChangeHandler(object sender, EventArgs e);
        public event LoadDataChangeHandler LoadDataChange;

        public frmImportErrorModule()
        {
            InitializeComponent();
        }

        public frmImportErrorModule(string projectCode, int moduleID)
        {
            InitializeComponent();

            _projectCode = projectCode;
            _moduleID = moduleID;
        }

        private void frmImportErrorModule_Load(object sender, EventArgs e)
        {
            this.Text += "- Module: " + PartsCode + " - " + DNNK;
            btnSave.Enabled = ImportStatus == 2;
            loadGrid();
        }

        void loadGrid()
        {
            DataTable dt = LibQLSX.Select("select *,case when Status = 1 then cast(1 as bit) else cast(0 as bit) end as Status1, N'Báo lỗi' as Error from CriteriaImport with(nolock) where ProductPartsImportId = '" 
                + ProjectProductImport.ProjectProductImportId + "' order by CriteriaIndex");

            if (ProjectProductImport.UserId == "" || ProjectProductImport.UserId == null)
            {
                if (dt.Rows.Count == 0)
                {
                    for (int i = 1; i <= Qty; i++)
                    {
                        DataRow row = dt.NewRow();
                        row["CriteriaIndex"] = i;
                        row["ValueResult"] = "ok";
                        row["ProductPartsImportId"] = ProjectProductImport.ProjectProductImportId;
                        //row["CriteriaImportId"] = "";
                        row["Status"] = 1;
                        row["Status1"] = true;
                        row["IsHalf"] = false;
                        row["Error"] = "Báo lỗi";
                        dt.Rows.Add(row);
                    }
                }
                else
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        r["ValueResult"] = "ok";
                        r["Status"] = 1;
                        r["Status1"] = true;
                    }
                }
            }
            grdData.DataSource = dt;
        }

        bool ValidateForm()
        {
            DataTable dt = (DataTable)grdData.DataSource;
            DataRow[] drs = dt.Select("ValueResult = '' or ValueResult is null");

            if (drs.Length > 0)
            {
                MessageBox.Show("Xin hãy điền nội dung kết quả kiểm tra.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dtUserKCS = LibQLSX.Select("select top 1 * from Users where Account = '" + Global.AppUserName + "'");
            if (dtUserKCS.Rows.Count == 0)
            {
                MessageBox.Show("Tài khoản đăng nhập không có trên QLSX", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            int OK = 0;
            int NG = 0;

            //ProcessTransaction pt = new ProcessTransaction();
            //pt.OpenConnection();
            //pt.BeginTransaction();

            if (!ValidateForm())
            {
                //pt.CloseConnection();
                return;
            }
            grvData.FocusedRowHandle = -1;

            try
            {
                for (int i = 0; i < grvData.RowCount; i++)
                {
                    string criteriaImportId = TextUtils.ToString(grvData.GetRowCellValue(i, colCriteriaImportId));

                    CriteriaImportModel model = new CriteriaImportModel();
                    if (criteriaImportId != "")
                    {
                        ArrayList arr = CriteriaImportBO.Instance.FindByAttribute("CriteriaImportId", criteriaImportId);
                        model = (CriteriaImportModel)arr[0];
                    }

                    model.CriteriaName = "Đúng thông số, kích thước kỹ thuật.";
                    model.ValueRequest = "Vật tư, thiết bị đảm bảo chất lượng.";
                    model.CriteriaIndex = TextUtils.ToInt(grvData.GetRowCellValue(i, colSTT));
                    model.IsHalf = TextUtils.ToBoolean(grvData.GetRowCellValue(i, colIsHalf));
                    model.ProductPartsImportId = ProjectProductImport.ProjectProductImportId;

                    bool status = TextUtils.ToBoolean(grvData.GetRowCellValue(i, colStatus));
                    model.Status = status ? 1 : 0;

                    model.ValueResult = TextUtils.ToString(grvData.GetRowCellValue(i, colValueResult));

                    if (criteriaImportId != "")
                    {
                        CriteriaImportBO.Instance.UpdateQLSX(model);
                    }
                    else
                    {
                        DataTable dt = LibQLSX.Select("SELECT top 1 CriteriaImportId FROM CriteriaImport order by CriteriaImportId desc");
                        if (dt.Rows.Count > 0)
                        {
                            criteriaImportId = TextUtils.ToString(dt.Rows[0]["CriteriaImportId"]);
                            string number = criteriaImportId.Substring(2, 8);
                            criteriaImportId = "CI" + string.Format("{0:00000000}", TextUtils.ToInt(number) + 1);
                        }
                        model.CriteriaImportId = criteriaImportId;
                        CriteriaImportBO.Instance.InsertQLSX(model);
                    }
                    if (model.Status == 1)
                    {
                        OK++;
                    }
                    else
                    {
                        NG++;
                    }
                }

                ProjectProductImport.UserId = TextUtils.ToString(dtUserKCS.Rows[0]["UserId"]);
                ProjectProductImport.TotalOK = OK;
                ProjectProductImport.TotalNG = NG;
                ProjectProductImportBO.Instance.UpdateQLSX(ProjectProductImport);

                //pt.CommitTransaction();

                loadGrid();

                _isSaved = true;

                MessageBox.Show("Tác vụ thành công!", TextUtils.Caption,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tác vụ không thành công!" + Environment.NewLine + ex.Message, TextUtils.Caption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //pt.CloseConnection();
            }

            if (_isSaved)
            {
                if (this.LoadDataChange != null)
                {
                    this.LoadDataChange(null, null);
                }
            }
        }

        private void repositoryItemHyperLinkEdit1_DoubleClick(object sender, EventArgs e)
        {
            string des = TextUtils.ToString(grvData.GetFocusedRowCellValue(colValueResult));
            frmBCLError frm = new frmBCLError(des, _projectCode, _moduleID);
            frm.Show();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                for (int i = 0; i < grvData.RowCount; i++)
                {
                    grvData.SetRowCellValue(i, colStatus, true);
                }
            }
            else
            {
                for (int i = 0; i < grvData.RowCount; i++)
                {
                    grvData.SetRowCellValue(i, colStatus, false);
                }
            }
        }

        private void chkBanThanhPham_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBanThanhPham.Checked)
            {
                for (int i = 0; i < grvData.RowCount; i++)
                {
                    grvData.SetRowCellValue(i, colIsHalf, true);
                }
            }
            else
            {
                for (int i = 0; i < grvData.RowCount; i++)
                {
                    grvData.SetRowCellValue(i, colIsHalf, false);
                }
            }
        }
    }
}
