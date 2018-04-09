using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IE.Model;
using IE.Business;
using IE.Utils;
using DevExpress.Utils;

namespace BMS
{
    public partial class frmFCMdetail : _Forms
    {
        public T_DM_FCMModel FCM = new T_DM_FCMModel();
        public delegate void LoadDataChangeHandler(object sender, EventArgs e);
        public event LoadDataChangeHandler LoadDataChange;
        bool _isSaved = false;

        public frmFCMdetail()
        {
            InitializeComponent();
        }

        private void frmFCMdetail_Load(object sender, EventArgs e)
        {
            loadYear();
            loadDepartment();
            if (FCM.ID > 0)
            {
                txtProjectCode.Text = FCM.C_CODE;
                txtHopDong.Text = FCM.C_SOHOADON;
                cboMonth.SelectedIndex = FCM.C_MONTH;
                cboYear.SelectedItem = FCM.C_YEAR;

                txtTotalBX.EditValue = FCM.TotalBX;
                txtTotalHD.EditValue = FCM.TotalHD;
                txtTotalNC.EditValue = FCM.TotalNC;
                txtTotalPB.EditValue = FCM.TotalPB;
                txtTotalProfit.EditValue = FCM.TotalProfit;
                txtTotalReal.EditValue = FCM.TotalReal;
                txtTotalTPA.EditValue = FCM.TotalTPA;
                txtTotalTrienKhai.EditValue = FCM.TotalTrienKhai;
                txtTotalVAT.EditValue = FCM.TotalVAT;
                txtTotalVT.EditValue = FCM.TotalVT;               

                DataTable dt = LibIE.Select("select * from V_DM_FCM_DETAIL where FK_FCM = " + FCM.ID);
                grdData.DataSource = dt;
            }
            this.Text += ": " + FCM.C_CODE;
        }

        void loadYear()
        {
            cboYear.Items.Add("Tất cả");
            for (int i = 2013; i <= DateTime.Now.Year; i++)
            {
                cboYear.Items.Add(i);
            }
            cboYear.SelectedItem = DateTime.Now.Year;
        }

        void loadDepartment()
        {
            DataTable dt = LibIE.Select("SELECT [PK_ID],[C_MA],[C_MOTA] FROM [tanphat].[dbo].[T_DM_PHANXUONG]");
            repositoryItemSearchLookUpEdit1.DataSource = dt;
            repositoryItemSearchLookUpEdit1.ValueMember = "PK_ID";
            repositoryItemSearchLookUpEdit1.DisplayMember = "C_MOTA";

            //DataTable dt1 = LibIE.Select("SELECT [PK_ID],[C_MA],[C_MOTA] FROM [tanphat].[dbo].[T_DM_PHANXUONG] where PK_ID = 40 or PK_ID = 71");
            //DataRow row = dt1.NewRow();
            //dt1.Rows.InsertAt(row, 0);
            //cboPhongBan.DataSource = dt1;
            //cboPhongBan.DisplayMember = "C_MOTA";
            //cboPhongBan.ValueMember = "PK_ID";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang lưu trữ dữ liệu..."))
            {
                ProcessTransaction pt = new ProcessTransaction();
                pt.OpenConnection();
                pt.BeginTransaction();

                try
                {
                    //if (!ValidateForm())
                    //    return;

                    #region FCM
                    //fcm.FK_DTCP = TextUtils.ToInt(LibIE.ExcuteScalar("SELECT TOP 1 [PK_ID] FROM [T_DM_DTCP] where C_MA = '" + txtProjectCode.Text.Trim() + "'"));
                    //fcm.C_CODE = txtProjectCode.Text.Trim();
                    FCM.C_MONTH = cboMonth.SelectedIndex;
                    FCM.C_YEAR = TextUtils.ToInt(cboYear.SelectedItem);
                    //fcm.C_SOHOADON = txtHopDong.Text.Trim();
                    //fcm.C_TYPE = chkIsGiaoDucFCM.Checked ? 1 : 2;
                    //fcm.C_TYPE = TextUtils.ToInt(cboPhongBan.SelectedValue) == 40 ? 1 : 2;
                    //fcm.TotalBX = TextUtils.ToDecimal(txtTotalBX.EditValue);
                    //fcm.TotalTrienKhai = TextUtils.ToDecimal(txtTotalTrienKhai.EditValue);
                    //fcm.TotalHD = TextUtils.ToDecimal(txtTotalHD.EditValue);
                    //fcm.TotalNC = TextUtils.ToDecimal(txtTotalNC.EditValue);
                    //fcm.TotalPB = TextUtils.ToDecimal(txtTotalPB.EditValue);
                    //fcm.TotalProfit = TextUtils.ToDecimal(txtTotalProfit.EditValue);
                    //fcm.TotalReal = TextUtils.ToDecimal(txtTotalReal.EditValue);
                    //fcm.TotalTPA = TextUtils.ToDecimal(txtTotalTPA.EditValue);
                    //fcm.TotalVAT = TextUtils.ToDecimal(txtTotalVAT.EditValue);
                    //fcm.TotalBanHang = TextUtils.ToDecimal(txtTotalBanHang.EditValue);

                    pt.Update(FCM);
                    #endregion

                    #region Detail
                    grvData.FocusedRowHandle = -1;
                    for (int i = 0; i < grvData.RowCount; i++)
                    {
                        T_DM_FCM_DETAILModel detail = (T_DM_FCM_DETAILModel)T_DM_FCM_DETAILBO.Instance.FindByPK(TextUtils.ToInt(grvData.GetRowCellValue(i, colID)));
                        detail.FK_FCM = FCM.ID;
                        detail.FK_PHANXUONG = TextUtils.ToInt(grvData.GetRowCellValue(i, colDepartmentID));
                        detail.FK_KMP = TextUtils.ToInt(grvData.GetRowCellValue(i, colFK_KMP));
                        detail.C_PRICE = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colValue));
                        pt.Update(detail);
                    }
                    #endregion

                    pt.CommitTransaction();

                    if (this.LoadDataChange != null)
                    {
                        this.LoadDataChange(null, null);
                    }

                    MessageBox.Show("Lưu trữ thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    pt.CloseConnection();
                }
            }
        }
    }
}
