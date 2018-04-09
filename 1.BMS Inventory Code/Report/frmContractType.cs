using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using System.IO;
using System.Text.RegularExpressions;
using BMS.Utils;
using BMS.Model;
using BMS.Business;

namespace BMS
{
    public partial class frmContractType : _Forms
    {
        ContractTypeModel _Model;

        ContractTypeModel _objContractTypeMode = null;

        public ContractTypeModel ObjContractTypeMode
        {
            get { return _objContractTypeMode; }
            set { _objContractTypeMode = value; }
        }

        #region Khai báo các biến
        private bool isAdd = false;
        int _ContractTypeIDs = 0;
        #endregion

        #region LoadForm
       
        public frmContractType()
        {
             _Model = new ContractTypeModel();
            InitializeComponent();
        }
        private void frmContractType_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Các sự kiện hệ thống
        private void btnNew_Click(object sender, EventArgs e)
        {
            SetInterface(true);
            cboStatus.SelectedIndex = 1;
            isAdd = true;
        }
        private void grcDetail_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0)
                return;
            if (e.Column.Caption.Equals("STT"))
                e.DisplayText = e.RowHandle + 1 + "";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (grvData.FocusedRowHandle > -1)
            {
                SetInterface(true);
                isAdd = false;
                int ID = Convert.ToInt16(grvData.GetRowCellValue(grvData.FocusedRowHandle, "ID").ToString());
                ObjContractTypeMode = (ContractTypeModel)ContractTypeBO.Instance.FindByPK(ID);
                cboStatus.SelectedIndex = Convert.ToInt16(grvData.GetRowCellValue(grvData.FocusedRowHandle, "Status"));
                txtName.Text = grvData.GetRowCellValue(grvData.FocusedRowHandle, "Name").ToString();
                txtDebitDate.Text = grvData.GetRowCellValue(grvData.FocusedRowHandle, "DebitDate").ToString();
                txtDueDate.Text = grvData.GetRowCellValue(grvData.FocusedRowHandle, "DueDate").ToString();
                txtARDate.Text = grvData.GetRowCellValue(grvData.FocusedRowHandle, "ARDate").ToString();
                txtTransactionCode.Text = grvData.GetRowCellValue(grvData.FocusedRowHandle, "ContractTypeIDs").ToString();
                
                byte _isBook = Convert.ToByte(grvData.GetRowCellValue(grvData.FocusedRowHandle, "IsBook"));
                if (_isBook == 1) chkIsBook.Checked = true;
                else chkIsBook.Checked = false;

                byte _isOTL= Convert.ToByte(grvData.GetRowCellValue(grvData.FocusedRowHandle, "IsOTL"));
                if (_isOTL == 1) chkIsOTL.Checked = true;
                else chkIsOTL.Checked = false;


            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(grvData.FocusedRowHandle > -1)
            {
                string strID = grvData.GetRowCellValue(grvData.FocusedRowHandle, "ID").ToString();
                if (ContractBO.Instance.CheckExist("ContractTypeID", strID))
                {
                    MessageBox.Show("loại hợp đồng này đã được sử dụng, bạn không thể xóa", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                else
                {
                    string strName = grvData.GetRowCellValue(grvData.FocusedRowHandle, "Name").ToString();
                    if (MessageBox.Show(String.Format("Bạn có chắc chắn xóa loại hợp đồng {0} ?", strName), "Xác nhận thao tác", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            ContractTypeBO.Instance.DeleteByAttribute("ID", strID);
                            LoadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Thao tác xóa bị lỗi\n\n" + ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        ProcessTransaction pt = new ProcessTransaction();
        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                //SqlConnection con = new SqlConnection(DBUtils.GetDBConnectionString());   
                if (CheckValid())
                {
                    if (isAdd)//thêm
                    {
                        ContractTypeModel _model = new ContractTypeModel();
                        _model.Name = txtName.Text.Trim();
                        if (txtTransactionCode.Text.Trim() == "")
                            _model.ContractTypeIDs = "0";
                        else
                            _model.ContractTypeIDs = TextUtils.ToString(txtTransactionCode.Text);

                        if (txtDebitDate.Text.Trim() == "")
                            _model.DebitDate = 0;
                        else
                            _model.DebitDate = TextUtils.ToInt(txtDebitDate.Text);
                        if (txtDueDate.Text.Trim() == "")
                            _model.DueDate = 0;
                        else
                            _model.DueDate = TextUtils.ToInt(txtDueDate.Text);
                        if (txtARDate.Text.Trim() == "")
                            _model.ARDate = 0;
                        else
                            _model.ARDate = TextUtils.ToInt(txtARDate.Text);

                        _model.IsBook = chkIsBook.Checked;
                        _model.IsOTL = chkIsOTL.Checked;
                        
                        
                        _model.Status = cboStatus.SelectedIndex;
                        _model.CreatedBy = Global.AppUserName;
                        _model.CreatedDate = TextUtils.GetSystemDate();
                        _model.UpdatedBy = Global.AppUserName;
                        _model.UpdatedDate = TextUtils.GetSystemDate();
                        //_model.ContractTypeID = ContractTypeID;
                        ContractTypeBO.Instance.Insert(_model);
                    }
                    else//sửa
                    {
                        int ID = Convert.ToInt16(grvData.GetRowCellValue(grvData.FocusedRowHandle, "ID").ToString());

                        //ContractTypeModel _model = (ContractTypeModel)ContractTypeBO.Instance.FindByPK(ID);
                        if (this.ObjContractTypeMode != null)
                        {
                            ContractTypeModel _model = ObjContractTypeMode;
                            _model.Status = cboStatus.SelectedIndex;
                            _model.Name = txtName.Text.Trim();
                            if (txtTransactionCode.Text.Trim() == "")
                                _model.ContractTypeIDs = "0";
                            else
                                _model.ContractTypeIDs = TextUtils.ToString(txtTransactionCode.Text);
                            if (txtDebitDate.Text.Trim() == "")
                                _model.DebitDate = 0;
                            else
                                _model.DebitDate = TextUtils.ToInt(txtDebitDate.Text);
                            if (txtDueDate.Text.Trim() == "")
                                _model.DueDate = 0;
                            else
                                _model.DueDate = TextUtils.ToInt(txtDueDate.Text);

                            _model.IsBook = chkIsBook.Checked;
                            _model.IsOTL = chkIsOTL.Checked;

                            if (txtARDate.Text.Trim() == "")
                                _model.ARDate = 0;
                            else
                                _model.ARDate = TextUtils.ToInt(txtARDate.Text);

                            _model.UpdatedBy = Global.AppUserName;
                            _model.UpdatedDate = TextUtils.GetSystemDate();

                            ContractTypeBO.Instance.Update(_model);
                        }
                    }
                    LoadData();
                    SetInterface(false);
                    ClearInterface();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Thêm/Sửa bị lỗi, hãy thử lại\n\n"+ex.Message, TextUtils.Caption);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetInterface(false);
            ClearInterface();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grvData_Click(object sender, EventArgs e)
        {
            if (grvData.FocusedRowHandle > -1)
            {
                //History
                lblCreatedBy.Text = "Người tạo: " + grvData.GetRowCellValue(grvData.FocusedRowHandle, "CreatedBy").ToString();
                lblCreatedDate.Text = "Ngày tạo: " + ((DateTime)grvData.GetRowCellValue(grvData.FocusedRowHandle, "CreatedDate")).ToString("dd/MM/yyyy HH:mm");
                lblUpdatedBy.Text = "Người sửa: " + grvData.GetRowCellValue(grvData.FocusedRowHandle, "UpdatedBy").ToString();
                lblUpdatedDate.Text = "Ngày sửa: " + ((DateTime)grvData.GetRowCellValue(grvData.FocusedRowHandle, "UpdatedDate")).ToString("dd/MM/yyyy HH:mm");
            }
            else
            {
                lblCreatedBy.Text = "Người tạo:...";
                lblCreatedDate.Text = "Ngày tạo:...";
                lblUpdatedBy.Text = "Người sửa:...";
                lblUpdatedDate.Text = "Ngày sửa:...";
            }
        }
        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            if (grvData.FocusedRowHandle > -1 && btnEdit.Enabled == true)
            {
                btnEdit_Click(null, null);
            }
        }
        #endregion

        #region Các hàm viết thêm

        private void SetInterface(bool isEdit)
        {
            txtName.ReadOnly = !isEdit;
            txtTransactionCode.Enabled = isEdit;    
            txtARDate.Enabled = isEdit;
            txtDebitDate.Enabled = isEdit;
            txtDueDate.Enabled = isEdit;
            cboStatus.Enabled = isEdit;
            chkIsBook.Enabled = isEdit;
            chkIsOTL.Enabled = isEdit;
            btnContractTypeCode.Enabled = isEdit;
       
            grdData.Enabled = !isEdit;

            btnSave.Visible = isEdit;
            btnCancel.Visible = isEdit;

            btnNew.Visible = !isEdit;
            btnEdit.Visible = !isEdit;
            btnDelete.Visible = !isEdit;
        }
        private void ClearInterface()
        {
            txtName.Text = "";
            txtDebitDate.Text = "";
            txtDueDate.Text = "";
            txtARDate.Text = "";
            cboStatus.SelectedIndex = -1;
            txtTransactionCode.Text = "";
            chkIsBook.Checked = false;
            chkIsOTL.Checked = false;
        }
        private void LoadData()
        {
            DataTable tblData = TextUtils.Select(@"SELECT a.*, CASE a.[Status] WHEN 0 THEN N'Ngừng hoạt động' WHEN 1 THEN N'Hoạt động' END AS StatusText " +
                                                "FROM ContractType a WITH (NOLOCK) ");
            

            grdData.DataSource = tblData;

        }
        private bool CheckValid()
        {
            if (txtName.Text.Trim().Equals(""))
            {
                MessageBox.Show("Hãy điền tên loại hợp đồng.\n", TextUtils.Caption);
                return false;
            }

            if (cboStatus.SelectedIndex < 0)
            {
                MessageBox.Show("Hãy điền trạng thái của loại hợp đồng.\n", TextUtils.Caption);
                return false;
            }
           
            return true;
        }
        #endregion

        private void btnContractTypeCode_Click(object sender, EventArgs e)
        {
            try
            {
                frmGenSelect frm = new frmGenSelect("Danh sách hợp đồng", "ContractType", "ID", "Name");
                frm.IsMultipleSelect = true;
                frm.ShowDialog();
                string temp = "";
                if (frm.getArrModel != null)
                {
                    for (int i = 0; i < frm.getArrModel.Length; i++)
                    {
                        ContractTypeModel _model = (ContractTypeModel)frm.getArrModel[i];
                       
                        _ContractTypeIDs = _model.ID;
                        temp += ((ContractTypeModel)_model).ID+",";
                       


                    }
                    txtTransactionCode.Text = temp.Substring(0, temp.Length - 1);
                    LoadData();
                }
            }
           
            catch (Exception ex)
            {
                frmGenMessageBox frm = new frmGenMessageBox("_SystemMessage", "frmGenSearch", "GetData", TextUtils.Caption, MessageLibrary._SystemMessage, ex.Message, MessageBoxIcon.Error);
                frm.ShowDialog();
                return;
            }
        }

        private void btnContractTypeCode_C_Click(object sender, EventArgs e)
        {
            //txtContractTypeCode.Text = "";
            //ContractTypeID = 0;
        }

        private void txtDebitDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = TextUtils.CheckInterger(e);
        }

        private void grdData_Click(object sender, EventArgs e)
        {

        }

        private void btnTransactionCode_C_Click(object sender, EventArgs e)
        {
            txtTransactionCode.Text = "";
            _ContractTypeIDs  =0;
            LoadData();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
       // int _chk = 0;
        private void chkIsBook_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkIsBook.Checked == true)
            //    _chk = 1;
            //else _chk = 0; ;

        }

        private void chkIsOTL_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkIsOTL.Checked == true)
            //    _chk = 1;
            //else _chk = 0; ;
        }

       

    }
}