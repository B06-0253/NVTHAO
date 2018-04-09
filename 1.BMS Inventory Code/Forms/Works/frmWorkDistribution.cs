using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Utils;
using BMS.Model;
using BMS.Business;

namespace BMS
{
    public partial class frmWorkDistribution : _Forms
    {
        public frmWorkDistribution()
        {
            InitializeComponent();
        }

        private void frmWorkDistribution_Load(object sender, EventArgs e)
        {
            ProgressBar1.Minimum = 0;
            ProgressBar1.Maximum = 48;
            ProgressBar1.ShowTitle = true;
            loadYear();
            loadStaff();
            //loadData();
        }

        #region Methods

        void loadYear()
        {
            List<int> listYear = new List<int>();

            for (int i = 0; i < 30; i++)
            {
                listYear.Add(2014 + i);
            }

            leYear.Properties.DataSource = listYear;
        }

        void loadWeek(int Year)
        {
            leWeek.Properties.DataSource = TextUtils.LoadAllWeekOfYear(Year);
        }

        void loadStaff()
        {
            DataTable dt = TextUtils.Select(" Select * from Users with(nolock)");
            leStaff.Properties.DataSource = dt;
            leStaff.Properties.ValueMember = "ID";
            leStaff.Properties.DisplayMember = "FullName";
        }

        void getSEDate(string WeekInfo)
        {
            string[] str = WeekInfo.Split(':');
            txtStartDate.Text = (str[1].Split('-')[0]).Trim();
            txtEndDate.Text = (str[1].Split('-')[1]).Trim();
        }

        void loadData()
        {
            if (txtEndDate.Text == "" || txtStartDate.Text == "")
            {
                MessageBox.Show("Hãy chọn một tuần trong năm!", TextUtils.Caption);
                return;
            }

            grdData.DataSource = null;

            try
            {
                string[] paraName = new string[2];
                object[] paraValue = new object[2];
                paraName[0] = "@FromDate"; paraValue[0] = TextUtils.ToDate(txtStartDate.Text).ToString("yyyy/MM/dd");
                paraName[1] = "@ToDate"; paraValue[1] = TextUtils.ToDate(txtEndDate.Text).ToString("yyyy/MM/dd");

                DataTable Source = WorksBO.Instance.LoadDataFromSP("spGetAllTimeOfUserInWeek", "Source", paraName, paraValue);

                grdData.DataSource = Source;
            }
            catch (Exception ex)
            {
                TextUtils.ShowError(ex);
            }
        }

        #endregion

        private void leWeek_EditValueChanged(object sender, EventArgs e)
        {
            if (leWeek.EditValue == null) return;
            getSEDate(leWeek.EditValue.ToString());
            loadData();
        }

        private void leYear_EditValueChanged(object sender, EventArgs e)
        {
            if (leYear.EditValue == null) return;
           
            loadWeek(TextUtils.ToInt(leYear.EditValue));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
