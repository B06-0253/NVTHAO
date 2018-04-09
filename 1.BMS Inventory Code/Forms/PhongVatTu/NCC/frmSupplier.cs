using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPA.Business;
using TPA.Model;
using TPA.Utils;

namespace BMS
{
    public partial class frmSupplier : _Forms
    {
        #region Variables
        bool _isSaved = false;
        string _supplierId;
        public bool IsNew = false;

        DataTable _dtUser = new DataTable();
        DataTable _dtHang = new DataTable();
        DataTable _dtContract = new DataTable();

        public delegate void LoadDataChangeHandler(object sender, EventArgs e);
        public event LoadDataChangeHandler LoadDataChange;

        public SuppliersModel Supplier = new SuppliersModel();
        #endregion

        #region Constructor and Load
        public frmSupplier()
        {
            InitializeComponent();
        }
        
        private void frmSupplier_Load(object sender, EventArgs e)
        {
            loadUserFind();
            loadHangFind();
            loadMaterialGroup();
            if (Supplier.SupplierId != null)
            {
                txtAddress.Text = Supplier.Address;
                txtAgency.Text = Supplier.Agency;
                txtBankAccount.Text = Supplier.BankAcount;
                txtBankAccountName.Text = Supplier.BankAcountName;
                txtBankName.Text = Supplier.BankName;
                txtCode.Text = Supplier.SupplierCode;
                txtContactPerson.Text = Supplier.ContactPerson;
                txtContactPhone.Text = Supplier.ContactPhone;
                txtDiscount.Text = Supplier.Discount.ToString("n2");
                txtEmail.Text = Supplier.Email;
                txtMST.Text = Supplier.MST;
                txtName.Text = Supplier.SupplierName;
                txtNote.Text = Supplier.Note;
                txtOffice.Text = Supplier.Office;
                txtPaymentTerm.Text = Supplier.PaymentTerm;
                txtPhone.Text = Supplier.Phone;
                txtProductProvided.Text = Supplier.ProductProvided;

                cboMaterialGroup.SelectedIndex = Supplier.MaterialGroup;
                cboStatus.SelectedIndex = Supplier.StatusDisable;
                //cboUser.EditValue = Supplier.UserId;

                _supplierId = Supplier.SupplierId;
            }
            else
            {
                cboStatus.SelectedIndex = 0;

                DataTable dt = LibQLSX.Select(" SELECT top 1 SupplierId ,SupplierCode FROM Suppliers where SupplierCode like 'ncc%' and SupplierCode not like '%-%' order by SupplierId desc");
                string id = dt.Rows[0]["SupplierId"].ToString();
                string code = dt.Rows[0]["SupplierCode"].ToString();

                id = id.Substring(1, id.Length - 1);
                code = code.Substring(3, code.Length - 3);

                id = "S" + string.Format("{0:000000000}", TextUtils.ToInt(id) + 1);
                code = "NCC" + string.Format("{0:0000}", TextUtils.ToInt(code) + 1);

                txtCode.Text = code;
                _supplierId = id;
            }
            loadUserGrid();
            loadHangGrid();
            loadContractGrid();
            loadMaterialGroupGrid();
        }
        #endregion

        #region Methods
        void loadUserFind()
        {
            //try
            //{
            //    DataTable dt = TextUtils.Select("Select * from vUserInfo WITH(NOLOCK)");
            //    cboUser.Properties.DataSource = dt;
            //    cboUser.Properties.DisplayMember = "FullName";
            //    cboUser.Properties.ValueMember = "ID";
            //}
            //catch (Exception)
            //{
            //}           
            DataTable dt = LibQLSX.Select("Select * from [vUser] WITH(NOLOCK)");
            cboUser.Properties.DataSource = dt;
            cboUser.Properties.DisplayMember = "UserName";
            cboUser.Properties.ValueMember = "UserId";
        }

        void loadHangFind()
        {
            DataTable dt = LibQLSX.Select("Select * from [Manufacturer] WITH(NOLOCK)");
            cboHang.Properties.DataSource = dt;
            cboHang.Properties.DisplayMember = "MName";
            cboHang.Properties.ValueMember = "ManufacturerId";
        }      

        void loadUserGrid()
        {
            _dtUser = LibQLSX.Select("select * from vSuppliersUserLink WITH(NOLOCK) where SupplierId = '" + TextUtils.ToString(Supplier.SupplierId) + "'");
            grvUser.AutoGenerateColumns = false;
            grvUser.DataSource = _dtUser;
        }

        void loadHangGrid()
        {
            _dtHang = LibQLSX.Select("select * from vSupplierManufacturerLink WITH(NOLOCK) " +
                                     "where SupplierId = '" + TextUtils.ToString(Supplier.SupplierId) + "'");
            grvHang.AutoGenerateColumns = false;
            grvHang.DataSource = _dtHang;
        }

        void loadContractGrid()
        {
            _dtContract = LibQLSX.Select("select *,Case when ContractType = 0 then N'Hợp đồng nguyên tắc' " +
                                         "else N'Hợp đồng kinh tế' end as ContractName " +
                                         "from SupplierContract WITH(NOLOCK) " +
                                         "where SupplierId = '" + TextUtils.ToString(Supplier.SupplierId) + "'");
            grvContract.AutoGenerateColumns = false;
            grvContract.DataSource = _dtContract;
        }

        bool ValidateForm()
        {
            if (txtCode.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền Mã.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền Tên.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            DataTable dt = LibQLSX.Select("select SupplierName from [Suppliers] with(nolock) where LTRIM(RTRIM([SupplierName])) = N'" + txtName.Text.Trim() + "'");
            if (dt.Rows.Count > 0 && IsNew)
            {
                MessageBox.Show("Tên nhà cung cấp đã tồn tại.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }           

            if (txtAddress.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền Địa chỉ ncc.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (txtOffice.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền Văn phòng đại diện.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (txtContactPerson.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền Người đại diện.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền Email liên hệ.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (cboStatus.SelectedIndex < 0)
            {
                MessageBox.Show("Xin hãy chọn trạng thái.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
                  
            if (cboMaterialGroup.SelectedIndex < 0)
            {
                MessageBox.Show("Xin hãy chọn nhóm vật tư.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (grvHang.Rows.Count == 0)
            {
                MessageBox.Show("Xin hãy thêm hãng cung cấp tại tab Hãng cung cấp.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (grvMaterialGroup.Rows.Count == 0)
            {
                MessageBox.Show("Xin hãy thêm nhóm sản phẩm tại tab Nhóm VT cung cấp.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return true;
        }       

        void save()
        {
            if (IsNew)
            {
                MessageBox.Show("Bạn không thể tạo mới nhà cung cấp!", TextUtils.Caption,MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();

            try
            {
                if (!ValidateForm())
                    return;

                #region NCC
                if (IsNew)
                {
                    Supplier = new SuppliersModel();
                }

                Supplier.Address = txtAddress.Text;
                Supplier.Agency = txtAgency.Text;
                Supplier.BangDanhGia = chkBangDanhGia.Checked;
                Supplier.BankAcount = txtBankAccount.Text;
                Supplier.BankAcountName = txtBankAccountName.Text;
                Supplier.BankName = txtBankName.Text;
                Supplier.ContactPerson = txtContactPerson.Text;
                Supplier.ContactPhone = txtContactPhone.Text;
                Supplier.Discount = TextUtils.ToDecimal(txtDiscount.Text);
                Supplier.DKKD = chkDKKD.Checked;
                Supplier.Email = txtEmail.Text;
                Supplier.HopDongNguyenTac = chkHopDongNguyenTac.Checked;
                Supplier.MaterialGroup = cboMaterialGroup.SelectedIndex;
                Supplier.MST = txtMST.Text;
                //Supplier.NhanTinStatus = 0;
                Supplier.Note = txtNote.Text;
                Supplier.Office = txtOffice.Text;
                Supplier.PaymentTerm = txtPaymentTerm.Text;
                Supplier.Phone = txtPhone.Text;
                Supplier.ProductProvided = txtProductProvided.Text;
                Supplier.StatusDisable = cboStatus.SelectedIndex;
                Supplier.SupplierCode = txtCode.Text;
                //Supplier.SupplierERPId = _supplierId;
                //Supplier.SupplierId = _supplierId;
                Supplier.SupplierName = txtName.Text;
                //Supplier.UserId = TextUtils.ToString(cboUser.EditValue);
                Supplier.UyQuyenHang = chkUyQuyenHang.Checked;
                Supplier.UpdatedDate = DateTime.Now;

                if (IsNew)
                {
                    Supplier.DateArising = DateTime.Now;                    
                    pt.InsertQLSX(Supplier);
                }
                else
                {
                    pt.UpdateQLSX(Supplier);
                }
                #endregion

                #region Nguoi phu trach
                foreach (DataGridViewRow row in grvUser.Rows)
                {
                    int id = TextUtils.ToInt(row.Cells["colULinkId"].Value);
                    SuppliersUserLinkModel linkModel = new SuppliersUserLinkModel();
                    if (id > 0)
                    {
                        linkModel = (SuppliersUserLinkModel)SuppliersUserLinkBO.Instance.FindByPK(id);
                    }

                    linkModel.SupplierId = Supplier.SupplierId;
                    linkModel.UserId = TextUtils.ToString(row.Cells["colUId"].Value);

                    if (id > 0)
                    {
                        pt.Update(linkModel);
                    }
                    else
                    {
                        pt.Insert(linkModel);
                    }
                }
                #endregion

                #region Hang cung cap
                foreach (DataGridViewRow row in grvHang.Rows)
                {
                    int id = TextUtils.ToInt(row.Cells["colHLinkID"].Value);
                    SuppliersManufacturerLinkModel linkModel = new SuppliersManufacturerLinkModel();
                    if (id > 0)
                    {
                        linkModel = (SuppliersManufacturerLinkModel)SuppliersManufacturerLinkBO.Instance.FindByPK(id);
                    }

                    linkModel.SupplierId = Supplier.SupplierId;
                    linkModel.ManufacturerId = TextUtils.ToString(row.Cells["colHid"].Value);

                    if (id > 0)
                    {
                        pt.Update(linkModel);
                    }
                    else
                    {
                        pt.Insert(linkModel);
                    }
                }
                #endregion

                #region Hợp đồng
                foreach (DataGridViewRow row in grvContract.Rows)
                {
                    int id = TextUtils.ToInt(row.Cells["colContractID"].Value);
                    SupplierContractModel model = new SupplierContractModel();
                    if (id > 0)
                    {
                        model = (SupplierContractModel)SupplierContractBO.Instance.FindByPK(id);
                    }
                    
                    model.SupplierId = Supplier.SupplierId;
                    model.ContractType = TextUtils.ToInt(row.Cells["colContractType"].Value);
                    model.SignDate = TextUtils.ToDate2(row.Cells["colSignDate"].Value);
                    model.OutDate = TextUtils.ToDate2(row.Cells["colOutDate"].Value);

                    if (id > 0)
                    {
                        pt.Update(model);
                    }
                    else
                    {
                        pt.Insert(model);
                    }
                }
                #endregion

                #region Nhóm vật tư
                foreach (DataGridViewRow row in grvMaterialGroup.Rows)
                {
                    int id = TextUtils.ToInt(row.Cells["colGroupLinkID"].Value);
                    SupplierMaterialGroupLinkModel model = new SupplierMaterialGroupLinkModel();
                    if (id > 0)
                    {
                        model = (SupplierMaterialGroupLinkModel)SupplierMaterialGroupLinkBO.Instance.FindByPK(id);
                    }

                    model.SupplierId = Supplier.SupplierId;
                    model.MaterialGroupID = TextUtils.ToInt(row.Cells["colMaterialGroupID"].Value);

                    if (id > 0)
                    {
                        pt.Update(model);
                    }
                    else
                    {
                        pt.Insert(model);
                    }
                }
                #endregion

                pt.CommitTransaction();

                IsNew = false;
                _isSaved = true;

                loadHangGrid();
                loadUserGrid();
                loadContractGrid();
                loadMaterialGroupGrid();

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
        #endregion

        #region Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            save();
        }

        private void frmSupplier_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_isSaved)
            {
                if (this.LoadDataChange != null)
                {
                    this.LoadDataChange(null, null);
                }
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if(grvUser.Rows.Count > 0) return;
            
            string userID = TextUtils.ToString(cboUser.EditValue);
            if (userID == "")
            {
                return;
            }
            string account = TextUtils.ToString(grvCboUser.GetFocusedRowCellValue(colAccount));
            string fullName = TextUtils.ToString(grvCboUser.GetFocusedRowCellValue(colFullName));
            DataRow[] drs = _dtUser.Select("UserId = '" + userID + "'");
            if (drs.Length == 0)
            {
                if (userID != "")
                {
                    DataRow dr = _dtUser.NewRow();
                    dr["Account"] = account;
                    dr["UserName"] = fullName;
                    dr["UserId"] = userID;
                    _dtUser.Rows.Add(dr);
                }
            }            
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            int linkID = TextUtils.ToInt(grvUser.SelectedRows[0].Cells["colULinkId"].Value);
            string mName = TextUtils.ToString(grvUser.SelectedRows[0].Cells["colUname"].Value);
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa nhân viên [" + mName + "]?", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (linkID > 0)
                {
                    SuppliersUserLinkBO.Instance.Delete(linkID);
                }

                grvUser.Rows.Remove(grvUser.SelectedRows[0]);
            }
        }

        private void btnAddHang_Click(object sender, EventArgs e)
        {
            string mID = TextUtils.ToString(cboHang.EditValue);
            string mcode = TextUtils.ToString(grvCboHang.GetFocusedRowCellValue(colMCode));
            string mname = TextUtils.ToString(grvCboHang.GetFocusedRowCellValue(colMName));
            DataRow[] drs = _dtHang.Select("ManufacturerId = '" + mID + "'");
            if (drs.Length == 0)
            {
                if (mID != "")
                {
                    DataRow dr = _dtHang.NewRow();
                    dr["ManufacturerCode"] = mcode;
                    dr["MName"] = mname;
                    dr["ManufacturerId"] = mID;
                    _dtHang.Rows.Add(dr);
                }
            }
        }

        private void btnDeleteHang_Click(object sender, EventArgs e)
        {
            int linkID = TextUtils.ToInt(grvHang.SelectedRows[0].Cells["colHLinkID"].Value);
            string mName = TextUtils.ToString(grvHang.SelectedRows[0].Cells["colHname"].Value);
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa hãng [" + mName + "]?", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (linkID > 0)
                {
                    SuppliersManufacturerLinkBO.Instance.Delete(linkID);
                }

                grvHang.Rows.Remove(grvHang.SelectedRows[0]);
            }
        }
        #endregion

        private void btnAddContract_Click(object sender, EventArgs e)
        {
            int type = cboContractType.SelectedIndex;
            DateTime signDate = dtpSign.Value;
            DateTime outDate = dtpOut.Value;
            
            if (type != -1)
            {
                DataRow dr = _dtContract.NewRow();
                dr["ContractType"] = type;
                dr["SignDate"] = signDate;
                dr["OutDate"] = outDate;
                dr["ContractName"] = type == 0 ? "Hợp đồng nguyên tắc" : "Hợp đồng kinh tế";
                dr["ID"] = 0;
                _dtContract.Rows.Add(dr);
            }
        }

        private void btnDeleteContract_Click(object sender, EventArgs e)
        {
            if(grvContract.SelectedRows.Count ==0)return;
            
            int ID = TextUtils.ToInt(grvContract.SelectedRows[0].Cells["colContractID"].Value);
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa hợp đồng này?", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (ID > 0)
                {
                    SupplierContractBO.Instance.Delete(ID);
                }

                grvContract.Rows.Remove(grvContract.SelectedRows[0]);
            }
        }

        void loadMaterialGroup()
        {
            DataTable dt = LibQLSX.Select("select ID,Code +' - '+Name as GroupName from MaterialGroup");
            cboMaterialGroup1.DataSource = dt;
            cboMaterialGroup1.ValueMember = "ID";
            cboMaterialGroup1.DisplayMember = "GroupName";
        }

        DataTable _dtGroupLink = new DataTable();
        void loadMaterialGroupGrid()
        {
            _dtGroupLink = LibQLSX.Select("select * from vSupplierMaterialGroupLink where SupplierId = '" + Supplier.SupplierId + "'");
            grvMaterialGroup.AutoGenerateColumns = false;
            grvMaterialGroup.DataSource = _dtGroupLink;
        }

        private void btnAddMaterialGroup_Click(object sender, EventArgs e)
        {
            int groupID = TextUtils.ToInt(cboMaterialGroup1.SelectedValue);
            DataRow[] drs = _dtGroupLink.Select("MaterialGroupID = " + groupID);
            if (drs.Length > 0) return;

            if (groupID > 0)
            {
                DataRow dr = _dtGroupLink.NewRow();
                dr["MaterialGroupID"] = groupID;
                dr["GroupName"] = cboMaterialGroup1.Text;
                dr["ID"] = 0;
                _dtGroupLink.Rows.Add(dr);
            }
        }

        private void btnDeleteMaterialGroup_Click(object sender, EventArgs e)
        {
            if (grvMaterialGroup.SelectedRows.Count == 0) return;

            int ID = TextUtils.ToInt(grvMaterialGroup.SelectedRows[0].Cells["colGroupLinkID"].Value);
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa nhóm này?", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (ID > 0)
                {
                    SupplierMaterialGroupLinkBO.Instance.Delete(ID);
                }

                grvMaterialGroup.Rows.Remove(grvMaterialGroup.SelectedRows[0]);
            }
        }
    }
}
