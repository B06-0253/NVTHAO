using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IE.Business;
using IE.Model;
using IE.Utils;
using DevExpress.Utils;

namespace BMS
{
    public partial class frmImportInfoFCM : _Forms
    {
        public delegate void LoadDataChangeHandler(object sender, EventArgs e);
        public event LoadDataChangeHandler LoadDataChange;
        T_DM_FCMModel fcm = new T_DM_FCMModel();
        public frmImportInfoFCM()
        {
            InitializeComponent();
        }

        private void frmImportInfoFCM_Load(object sender, EventArgs e)
        {
            loadYear();
            loadDepartment();
            //cboMonth.SelectedIndex = DateTime.Now.Month - 1;
        }

        void loadYear()
        {
            cboYear.Items.Add("Tất cả");
            for (int i = 2013; i <= DateTime.Now.Year; i++)
            {
                cboYear.Items.Add(i);
            }
            //cboYear.SelectedItem = DateTime.Now.Year;
        }

        void loadDepartment()
        {
            DataTable dt = LibIE.Select("SELECT [PK_ID],[C_MA],[C_MOTA] FROM [tanphat].[dbo].[T_DM_PHANXUONG]");
            repositoryItemSearchLookUpEdit1.DataSource = dt;
            repositoryItemSearchLookUpEdit1.ValueMember = "PK_ID";
            repositoryItemSearchLookUpEdit1.DisplayMember = "C_MOTA";

            DataTable dt1 = LibIE.Select("SELECT [PK_ID],[C_MA],[C_MOTA] FROM [tanphat].[dbo].[T_DM_PHANXUONG] where PK_ID = 40 or PK_ID = 71");
            DataRow row = dt1.NewRow();
            dt1.Rows.InsertAt(row, 0);
            cboPhongBan.DataSource = dt1;
            cboPhongBan.DisplayMember = "C_MOTA";
            cboPhongBan.ValueMember = "PK_ID";
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (TextUtils.ToInt(cboPhongBan.SelectedValue)==0)
            {
                MessageBox.Show("Bạn phải chọn một phòng phụ trách.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo load dữ liệu..."))
                {
                    fcm = new T_DM_FCMModel();
                    DataTable dt = new DataTable();
                    DataRow[] drs = null;
                    txtDMVTPath.Text = ofd.FileName;
                    if (TextUtils.ToInt(cboPhongBan.SelectedValue) == 40)
                    {
                        dt = TextUtils.ExcelToDatatableNoHeader(txtDMVTPath.Text, "Sheet1");
                        if (dt.Rows.Count == 0) return;

                        txtProjectCode.Text = TextUtils.ToString(dt.Rows[3]["F4"]);
                        txtHopDong.Text = TextUtils.ToString(dt.Rows[7]["F7"]);
                        txtTotalBanHang.EditValue = TextUtils.ToDecimal(dt.Rows[19]["F7"]);
                        txtTotalBX.EditValue = TextUtils.ToDecimal(dt.Rows[18]["F7"]);
                        txtTotalHD.EditValue = TextUtils.ToDecimal(dt.Rows[11]["F7"]);
                        txtTotalNC.EditValue = TextUtils.ToDecimal(dt.Rows[16]["F7"]);
                        txtTotalPB.EditValue = TextUtils.ToDecimal(dt.Rows[17]["F7"]);
                        txtTotalProfit.EditValue = TextUtils.ToDecimal(dt.Rows[20]["F7"]);
                        txtTotalReal.EditValue = TextUtils.ToDecimal(dt.Rows[14]["F7"]);
                        txtTotalTPA.EditValue = TextUtils.ToDecimal(dt.Rows[12]["F7"]);
                        txtTotalTrienKhai.EditValue = TextUtils.ToDecimal(dt.Rows[15]["F7"]);
                        txtTotalVAT.EditValue = TextUtils.ToDecimal(dt.Rows[13]["F7"]);
                        txtTotalVT.EditValue = TextUtils.ToDecimal(dt.Rows[24]["F7"]);

                        drs = dt.Select("F2 is null and F3 is not null and F3 like 'C%'");
                        colCode.FieldName = "F3";
                    }
                    else
                    {
                        dt = TextUtils.ExcelToDatatableNoHeader(txtDMVTPath.Text, "INPUT");
                        if (dt.Rows.Count == 0) return;

                        txtProjectCode.Text = TextUtils.ToString(dt.Rows[4]["F4"]);
                        txtHopDong.Text = TextUtils.ToString(dt.Rows[8]["F7"]);
                        txtTotalBanHang.EditValue = TextUtils.ToDecimal(dt.Rows[48]["F7"]);
                        txtTotalBX.EditValue = TextUtils.ToDecimal(dt.Rows[19]["F7"]);
                        txtTotalHD.EditValue = TextUtils.ToDecimal(dt.Rows[12]["F7"]);
                        txtTotalNC.EditValue = TextUtils.ToDecimal(dt.Rows[17]["F7"]);
                        txtTotalPB.EditValue = TextUtils.ToDecimal(dt.Rows[18]["F7"]);
                        txtTotalProfit.EditValue = TextUtils.ToDecimal(dt.Rows[20]["F7"]);
                        txtTotalReal.EditValue = TextUtils.ToDecimal(dt.Rows[15]["F7"]);
                        txtTotalTPA.EditValue = TextUtils.ToDecimal(dt.Rows[13]["F7"]);
                        txtTotalTrienKhai.EditValue = TextUtils.ToDecimal(dt.Rows[16]["F7"]);
                        txtTotalVAT.EditValue = TextUtils.ToDecimal(dt.Rows[14]["F7"]);
                        txtTotalVT.EditValue = TextUtils.ToDecimal(dt.Rows[22]["F7"]);

                        drs = dt.Select("F2 is not null and F2 like 'C%'");
                        colCode.FieldName = "F2";
                    }

                    if (drs.Length > 0)
                        dt = drs.CopyToDataTable();

                    dt.Columns.Add("DepartmentID", typeof(int));
                    foreach (DataRow row in dt.Rows)
                    {
                        string kmpCode = "";
                        if (TextUtils.ToInt(cboPhongBan.SelectedValue) == 40)
                        {
                            kmpCode = TextUtils.ToString(row["F3"]);
                        }
                        else
                        {
                            kmpCode = TextUtils.ToString(row["F2"]);
                        }
                        DataTable dtKMP = LibIE.Select("select top 1 [PK_ID],[C_ISKD] from T_DM_KMP where C_MA = '" + kmpCode + "'");
                        if (dtKMP.Rows.Count == 0) continue;

                        int isKD = TextUtils.ToInt(dtKMP.Rows[0]["C_ISKD"]);
                        int pk_KMP = TextUtils.ToInt(dtKMP.Rows[0]["PK_ID"]);
                        if (isKD == 1)
                        {
                            row["DepartmentID"] = TextUtils.ToInt(cboPhongBan.SelectedValue);
                        }
                        else
                        {
                            int pk_PhanXuong = TextUtils.ToInt(LibIE.ExcuteScalar("select top 1 [PK_PHANXUONG] from T_DM_PHANXUONG_KMP_Link where [PK_KMP] = " + pk_KMP));
                            if (pk_PhanXuong == 0) continue;
                            row["DepartmentID"] = pk_PhanXuong;
                        }
                    }
                    grdData.DataSource = dt;
                }
            }
        }

        bool ValidateForm()
        {
            if (txtProjectCode.Text.Trim() == "")
            {
                MessageBox.Show("Không tìm thấy mã dự án.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
            {
                int id = TextUtils.ToInt(LibIE.ExcuteScalar("select top 1 ID from T_DM_FCM where [C_CODE] = '" + txtProjectCode.Text.Trim() + "'"));
                if (id > 0)
                {
                    MessageBox.Show("FCM này đã được tồn tại trong cơ sở dữ liệu.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
            }

            if (TextUtils.ToInt(cboPhongBan.SelectedValue) == 0)
            {
                MessageBox.Show("Bạn phải chọn một phòng ban phụ trách.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (TextUtils.ToInt(cboYear.SelectedItem) == 0)
            {
                MessageBox.Show("Bạn phải chọn một năm.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (cboMonth.SelectedIndex < 1)
            {
                MessageBox.Show("Bạn phải chọn một tháng trong năm.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (TextUtils.ToDecimal(txtTotalHD.EditValue) == 0 || TextUtils.ToDecimal(txtTotalProfit.EditValue) == 0)
            {
                MessageBox.Show("Đây không phải là dữ liệu FCM.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (TextUtils.ToDecimal(txtTotalVT.EditValue)==0)
            {
                MessageBox.Show("Đây không phải là dữ liệu FCM.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            int dtcp = TextUtils.ToInt(LibIE.ExcuteScalar("SELECT TOP 1 [PK_ID] FROM [T_DM_DTCP] where C_MA = '" + txtProjectCode.Text.Trim() + "'"));
            if (dtcp <= 0)
            {
                MessageBox.Show("Dự án này chưa có trên IEnter.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;  
            }
            return true;
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
                    if (!ValidateForm())
                        return;

                    #region FCM
                    fcm.FK_DTCP = TextUtils.ToInt(LibIE.ExcuteScalar("SELECT TOP 1 [PK_ID] FROM [T_DM_DTCP] where C_MA = '" + txtProjectCode.Text.Trim() + "'"));
                    fcm.C_CODE = txtProjectCode.Text.Trim();
                    fcm.C_MONTH = cboMonth.SelectedIndex;
                    fcm.C_YEAR = TextUtils.ToInt(cboYear.SelectedItem);
                    fcm.C_SOHOADON = txtHopDong.Text.Trim();
                    //fcm.C_TYPE = chkIsGiaoDucFCM.Checked ? 1 : 2;
                    fcm.C_TYPE = TextUtils.ToInt(cboPhongBan.SelectedValue) == 40 ? 1 : 2;
                    fcm.TotalBX = TextUtils.ToDecimal(txtTotalBX.EditValue);
                    fcm.TotalTrienKhai = TextUtils.ToDecimal(txtTotalTrienKhai.EditValue);
                    fcm.TotalHD = TextUtils.ToDecimal(txtTotalHD.EditValue);
                    fcm.TotalNC = TextUtils.ToDecimal(txtTotalNC.EditValue);
                    fcm.TotalPB = TextUtils.ToDecimal(txtTotalPB.EditValue);
                    fcm.TotalProfit = TextUtils.ToDecimal(txtTotalProfit.EditValue);
                    fcm.TotalReal = TextUtils.ToDecimal(txtTotalReal.EditValue);
                    fcm.TotalTPA = TextUtils.ToDecimal(txtTotalTPA.EditValue);
                    fcm.TotalVAT = TextUtils.ToDecimal(txtTotalVAT.EditValue);
                    fcm.TotalBanHang = TextUtils.ToDecimal(txtTotalBanHang.EditValue);
                    fcm.TotalVT = TextUtils.ToDecimal(txtTotalVT.EditValue);

                    fcm.ID = (int)pt.Insert(fcm);
                    #endregion

                    #region Detail
                    grvData.FocusedRowHandle = -1;
                    for (int i = 0; i < grvData.RowCount; i++)
                    {
                        decimal c_Price = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colValue));
                        //if (c_Price == 0) continue;
                        string kmpCode = TextUtils.ToString(grvData.GetRowCellValue(i, colCode));
                        int departmentID  = TextUtils.ToInt(grvData.GetRowCellValue(i, colDepartmentID));
                        int pk_KMP = TextUtils.ToInt(LibIE.ExcuteScalar("select top 1 PK_ID from T_DM_KMP where C_MA = '" + kmpCode + "'"));
                        if (pk_KMP == 0) continue;

                        if (departmentID == 81)
                        {
                            DataTable dtLink = LibIE.Select("SELECT [ID],[PK_PHANXUONG],[PK_KMP],[TYLE],[C_MA],[C_MOTA] FROM " +
                                "[V_DM_PHANXUONG_KMP] where PK_KMP = " + pk_KMP + " and TYLE > 0");
                            if (dtLink.Rows.Count > 0)
                            {
                                foreach (DataRow row in dtLink.Rows)
                                {
                                    T_DM_FCM_DETAILModel detail = new T_DM_FCM_DETAILModel();
                                    detail.FK_FCM = fcm.ID;
                                    detail.FK_PHANXUONG = TextUtils.ToInt(row["PK_PHANXUONG"]);
                                    detail.FK_KMP = pk_KMP;
                                    detail.C_PRICE = TextUtils.ToDecimal(row["TYLE"]) * c_Price / 100;
                                    pt.Insert(detail);
                                }
                            }
                        }
                        else
                        {
                            T_DM_FCM_DETAILModel detail = new T_DM_FCM_DETAILModel();
                            detail.FK_FCM = fcm.ID;
                            detail.FK_PHANXUONG = TextUtils.ToInt(grvData.GetRowCellValue(i, colDepartmentID));
                            detail.FK_KMP = pk_KMP;
                            detail.C_PRICE = c_Price;
                            pt.Insert(detail);
                        }
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
