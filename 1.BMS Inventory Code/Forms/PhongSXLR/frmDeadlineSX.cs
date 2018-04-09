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
using System.IO;
using DevExpress.Utils;
using System.Diagnostics;

namespace BMS
{
    public partial class frmDeadlineSX : _Forms
    {
        
        public int ProjectDirectionID = 0;
        public frmDeadlineSX()
        {
            InitializeComponent();
        }
        private bool checkValid()
        {
            if (TextUtils.ToDate3(nbdCNC.EditValue).Date > TextUtils.ToDate3(nktCNC.EditValue).Date)
            {
                MessageBox.Show("Ngày Deadline CNC không thể lớn hơn ngày dự kiến.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else if (TextUtils.ToDate3(nbdGCN.EditValue).Date > TextUtils.ToDate3(nktGCN.EditValue).Date)
            {
                MessageBox.Show("Ngày Deadline GCN không thể lớn hơn ngày dự kiến.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else if (TextUtils.ToDate3(nbdDT.EditValue).Date > TextUtils.ToDate3(nktDT.EditValue).Date)
            {
                MessageBox.Show("Ngày Deadline Điện tử không thể lớn hơn ngày dự kiến.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else if (TextUtils.ToDate3(nbdIN.EditValue).Date > TextUtils.ToDate3(nktIN.EditValue).Date)
            {
                MessageBox.Show("Ngày Deadline In không thể lớn hơn ngày dự kiến.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else if (TextUtils.ToDate3(nbdLr.EditValue).Date > TextUtils.ToDate3(nktLr.EditValue).Date)
            {
                MessageBox.Show("Ngày Deadline Lắp ráp không thể lớn hơn ngày dự kiến.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            

            return true;
        }
        private void bntGhiDeadline_Click(object sender, EventArgs e)
        {
            if(!checkValid()) {
                return;
            }
            ProjectDirectionModel model = (ProjectDirectionModel)ProjectDirectionBO.Instance.FindByPK(ProjectDirectionID);

            model.StartDateCNC = TextUtils.ToDate2(nbdCNC.EditValue);
            model.DeadlineCNC = TextUtils.ToDate2(nktCNC.EditValue);
            //cnc
            model.StartDateGCN = TextUtils.ToDate2(nbdGCN.EditValue);
            model.DeadlineGCN = TextUtils.ToDate2(nktGCN.EditValue);
            // Gcn
            model.StartDateDT = TextUtils.ToDate2(nbdDT.EditValue);
            model.DeadlineDT = TextUtils.ToDate2(nktDT.EditValue);
            // DT
            model.StartDateIN = TextUtils.ToDate2(nbdIN.EditValue);
            model.DeadlineIN = TextUtils.ToDate2(nktIN.EditValue);
            //in
            model.StartDateLR = TextUtils.ToDate2(nbdLr.EditValue);
            model.DeadlineLR= TextUtils.ToDate2(nktLr.EditValue);
            
            ProjectDirectionBO.Instance.Update(model);
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void frmDeadlineSX_Load(object sender, EventArgs e)
        {
            ProjectDirectionModel model = (ProjectDirectionModel)ProjectDirectionBO.Instance.FindByPK(ProjectDirectionID);
            nbdCNC.EditValue = model.StartDateCNC;
            nktCNC.EditValue = model.DeadlineCNC;
            nbdGCN.EditValue = model.StartDateGCN;
            nktGCN.EditValue = model.DeadlineGCN;
            nbdDT.EditValue = model.StartDateDT;
            nktDT.EditValue = model.DeadlineDT;
            nbdIN.EditValue = model.StartDateIN;
            nktIN.EditValue = model.DeadlineIN;
            nbdLr.EditValue = model.StartDateLR;
            nktLr.EditValue = model.DeadlineLR;

        }
    }

}
