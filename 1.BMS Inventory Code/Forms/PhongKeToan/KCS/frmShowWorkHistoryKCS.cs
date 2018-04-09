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

namespace BMS
{
    public partial class frmShowWorkHistoryKCS : _Forms
    {
        public frmShowWorkHistoryKCS()
        {
            InitializeComponent();
        }

        private void frmShowWorkHistoryKCS_Load(object sender, EventArgs e)
        {
            loadUser();
        }

        void loadUser()
        {
            DataTable dt = LibQLSX.Select("Select * from [vUser] WITH(NOLOCK)");
            cboUser.Properties.DataSource = dt;
            cboUser.Properties.DisplayMember = "UserName";
            cboUser.Properties.ValueMember = "UserId";
            grvCboUser.BestFitColumns();
        }

        void loadData()
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load nhật ký công việc..."))
            {
                try
                {
                    string[] paraName = new string[3];
                    object[] paraValue = new object[3];

                    paraName[0] = "@StartDate"; paraValue[0] = TextUtils.ToDate(dtpStartDate.EditValue.ToString()).ToString("yyyy/MM/dd");
                    paraName[1] = "@EndDate"; paraValue[1] = TextUtils.ToDate(dtpEndDate.EditValue.ToString()).ToString("yyyy/MM/dd"); 
                    paraName[2] = "@UserId"; paraValue[2] = TextUtils.ToString(cboUser.EditValue);

                    DataTable Source = OrdersBO.Instance.LoadDataFromSP("spGetWorkHistoryKCS", "Source", paraName, paraValue);
                    
                    grdData.DataSource = Source;
                    //if (_rownIndex >= grvData.RowCount)
                    //    _rownIndex = 0;
                    //if (_rownIndex > 0)
                    //    grvData.FocusedRowHandle = _rownIndex;
                    //grvData.SelectRow(_rownIndex);
                    //grvData.BestFitColumns();
                }
                catch
                {
                    return;
                }
            }
        }

        private void dtpStartDate_EditValueChanged(object sender, EventArgs e)
        {
            //loadData();
        }

        private void dtpEndDate_EditValueChanged(object sender, EventArgs e)
        {
            //loadData();
        }

        private void cboUser_EditValueChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void xemChiTiếtVậtTưToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
    }
}
