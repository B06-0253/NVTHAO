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
using System.Collections;

namespace BMS
{
    public partial class frmConfigManufacturerUser : _Forms
    {
        private int _PageIndex = 1;
        private int _TotalPage = 1;
        DataTable _dtMaterial = new DataTable();

        #region Constuctor and Load
        public frmConfigManufacturerUser()
        {
            InitializeComponent();
        }
      
        private void frmConfigManufacturerUser_Load(object sender, EventArgs e)
        {
            loadUserFind();
            txtRecordPerPage.Text = "100";
            //loadData();
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

        void loadData(int pageIndex)
        {
            try
            {
                string[] paraName = new string[3];
                object[] paraValue = new object[3];

                paraName[0] = "@RecordPerPage"; paraValue[0] = TextUtils.ToInt(txtRecordPerPage.EditValue);
                paraName[1] = "@PageIndex"; paraValue[1] = pageIndex;
                paraName[2] = "@TextFind"; paraValue[2] = txtTextFind.Text.Trim();

                _dtMaterial = BMS.Business.ModulesBO.Instance.LoadDataFromSP("spGetMaterialQLSXwithGroup", "Source", paraName, paraValue);
                if (pageIndex == 1)
                {
                    string sqlSum = "";
                    sqlSum = "select PartsId from [dbo].[Parts] where ([PartType] = 1 or [PartType] = 2) and [PartsUse] = 1 ";
                    if (txtTextFind.Text.Trim() != "")
                    {
                        sqlSum += " and (PartsCode like N'%" + txtTextFind.Text.Trim() + "%' or PartsName like N'%" + txtTextFind.Text.Trim() + "%')";
                    }
                    DataTable dt = LibQLSX.Select(sqlSum);
                    int rowCount = dt.Rows.Count;
                    _TotalPage = rowCount / TextUtils.ToInt(txtRecordPerPage.EditValue);
                    if (rowCount % TextUtils.ToInt(txtRecordPerPage.EditValue) > 0 || _TotalPage == 0)
                    {
                        _TotalPage += 1;
                        txtTotalPage.Text = _TotalPage.ToString();
                    }
                }
                grdM.DataSource = _dtMaterial;
            }
            catch
            {
            }
        }

        void loadData()
        {
            DataTable dt = LibQLSX.Select("Select * from [vManufacturerUserLink] WITH(NOLOCK)");
            grdM.DataSource = dt;
        }
        #endregion

        #region Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            string userID = TextUtils.ToString(cboUser.EditValue);
            if (userID == "")
            {
                return;
            }
            string userName = TextUtils.ToString(grvCboUser.GetFocusedRowCellValue(colFullName));
            int[] listHandle = grvM.GetSelectedRows();
            int count = 0;
            foreach (int i in listHandle)
            {
                long linkID = TextUtils.ToInt64(grvM.GetRowCellValue(i, colMLinkID));
                PartUserLinkModel linkModel = new PartUserLinkModel();
                if (linkID>0)
                {
                    linkModel = (PartUserLinkModel)PartUserLinkBO.Instance.FindByPK(linkID);
                }
                linkModel.UserId = userID;
                linkModel.PartsId = TextUtils.ToString(grvM.GetRowCellValue(i,colMPartsId));
                if (linkID > 0)
                {
                    PartUserLinkBO.Instance.Update(linkModel);
                }
                else
                {
                    PartUserLinkBO.Instance.Insert(linkModel);
                }

                grvM.SetRowCellValue(i, colMLinkID, linkID);
                grvM.SetRowCellValue(i, colMUserId, userID);
                grvM.SetRowCellValue(i, colMUserName, userName);
                count++;
            }
            if (count > 0)
            {
                MessageBox.Show("Lưu trữ thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            _PageIndex = 1;
            txtPageIndex.Text = 1.ToString();
            loadData(1);
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (_PageIndex == 1) return;
            _PageIndex--;
            txtPageIndex.Text = _PageIndex.ToString();
            loadData(_PageIndex);
        }

        private void btnNxtPage_Click(object sender, EventArgs e)
        {
            if (_PageIndex == _TotalPage) return;
            _PageIndex++;
            txtPageIndex.Text = _PageIndex.ToString();
            loadData(_PageIndex);
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            _PageIndex = _TotalPage;
            txtPageIndex.Text = _TotalPage.ToString();
            loadData(_TotalPage);
        }

        private void btnFindAll_Click(object sender, EventArgs e)
        {
            _PageIndex = 1;
            txtPageIndex.Text = 1.ToString();
            loadData(1);
        }
        #endregion
    }
}
