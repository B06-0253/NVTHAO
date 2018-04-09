using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Business;
using BMS.BO;
using BMS.Model;
using BMS.Utils;

namespace BMS
{
    public partial class frmErrorReport : _Forms
    {
        string[] paraName = new string[2];
        object[] paraValue = new object[2];
        DataTable _dtData = new DataTable();

        public frmErrorReport()
        {
            InitializeComponent();
        }

        private void frmErrorReport_Load(object sender, EventArgs e)
        {
            loadCombo();
            //loadGrid();
        }

        void loadCombo()
        {
            try
            {
                //DataTable tblUser = TextUtils.Select("Users", new Expression("ID", 0, ">").And(new Expression("LoginName", "", "<>")));
                //TextUtils.PopulateCombo(cboUsers, tblUser.Copy(), "FullName", "ID", "");

                try
                {
                    DataTable dt = TextUtils.Select("Select * from vUserInfo WITH(NOLOCK)");
                    cboUser.Properties.DataSource = dt;
                    cboUser.Properties.DisplayMember = "FullName";
                    cboUser.Properties.ValueMember = "ID";
                }
                catch (Exception)
                {
                }      
            }
            catch (Exception)
            {
            }
        }
       
        void loadGrid(int userID)
        {
            _loginName = ((UsersModel)UsersBO.Instance.FindByPK(userID)).LoginName;
            if (_loginName != "")
            {
                //DataTable dt = TextUtils.Select("vModuleError", new Expression("ErrorLoginName", _loginName));

                string[] paraName = new string[2];
                object[] paraValue = new object[2];
                paraName[0] = "@TextFind"; paraValue[0] = _loginName;
                paraName[1] = "@Year"; paraValue[1] = "";

                _dtData = MaterialBO.Instance.LoadDataFromSP("spGetFilterError", "Source", paraName, paraValue);
                
                grdData.DataSource = _dtData;
                grvData.BestFitColumns();
            }
            else
            {
                grdData.DataSource = null;
                grdData0.DataSource = null;
                grdData1.DataSource = null;
                grdData2.DataSource = null;
            }            
        }        

        void loadSumGrid(int userID)
        {
            try
            {
                if (userID == 0) return;
                paraName[0] = "@Type"; paraValue[0] = 0;
                paraName[1] = "@LoginName"; paraValue[1] = _loginName;
                DataTable dt0 = MaterialBO.Instance.LoadDataFromSP("spGetReportWithType", "Source", paraName, paraValue);
                if (dt0.Rows.Count > 0)
                {
                    grdData0.DataSource = dt0;
                }
                else
                {
                    grdData0.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                grdData0.DataSource = null;
            }
            try
            {
                if (userID == 0) return;
                paraName[0] = "@Type"; paraValue[0] = 1;
                paraName[1] = "@LoginName"; paraValue[1] = _loginName;
                DataTable dt1 = MaterialBO.Instance.LoadDataFromSP("spGetReportWithType", "Source", paraName, paraValue);
                if (dt1.Rows.Count > 0)
                {
                    grdData1.DataSource = dt1;
                }
                else
                {
                    grdData1.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                grdData1.DataSource = null;
            }
            try
            {
                if (userID == 0) return;
                paraName[0] = "@Type"; paraValue[0] = 2;
                paraName[1] = "@LoginName"; paraValue[1] = _loginName;
                DataTable dt2 = MaterialBO.Instance.LoadDataFromSP("spGetReportWithType", "Source", paraName, paraValue);
                if (dt2.Rows.Count > 0)
                {
                    grdData2.DataSource = dt2;
                }
                else
                {
                    grdData2.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                grdData2.DataSource = null;
            }
        }

        void loadText(int userID)
        {
            //DataTable dtSum = TextUtils.Select("Select count(*) from ModuleError where UserID = " + userID + " or Author like '%" + _loginName + "%'");
            txtSum.Text = _dtData.Rows.Count.ToString();//dtSum.Rows[0][0].ToString();

            //DataTable dtKP = TextUtils.Select("Select count(*) from ModuleError where StatusTK = 1 and (UserID= " + userID + " or Author like '%" + _loginName + "%')");
            DataRow[] drs = _dtData.Select("StatusTK = 1");//.Length
            txtKP.Text = drs.Length.ToString();

            txtChuaKP.Text = (_dtData.Rows.Count - drs.Length).ToString();
        }

        string _loginName;

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cboType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboType.SelectedIndex == -1) return;
            int type = cboType.SelectedIndex;
            
            try
            {
                DataTable dtSum = TextUtils.Select("Select count(*) from vModuleError where Type" + type + " = " + type);
                txtTypeSum.Text = dtSum.Rows[0][0].ToString();

                DataTable dtKP = TextUtils.Select("Select count(*) from vModuleError where Status = 1 and Type" + type + "= " + type);
                txtTypeKP.Text = dtKP.Rows[0][0].ToString();

                txtTypeChua.Text = (TextUtils.ToInt(txtTypeSum.Text) - TextUtils.ToInt(txtTypeKP.Text)).ToString();
            }
            catch (Exception)
            {               
               
            }
           

            try
            {
                DataTable dt = TextUtils.Select("Select * from vModuleError where Type" + type + " = " + type);
                grdDataType.DataSource = dt;
            }
            catch (Exception)
            {
              
            }
        }

        private void cboUser_EditValueChanged(object sender, EventArgs e)
        {
            int userID = TextUtils.ToInt(cboUser.EditValue);
            _loginName = ((UsersModel)UsersBO.Instance.FindByPK(userID)).LoginName;
            loadGrid(userID);
            loadSumGrid(userID);
            loadText(userID);
        }
    }
}
