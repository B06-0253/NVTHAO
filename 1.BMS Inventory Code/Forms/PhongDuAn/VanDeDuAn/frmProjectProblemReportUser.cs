using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BMS
{
    public partial class frmProjectProblemReportUser : _Forms
    {
        public frmProjectProblemReportUser()
        {
            InitializeComponent();
        }

        private void frmProjectProblemReportUser_Load(object sender, EventArgs e)
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

        void loadGrid()
        {
            string userId = TextUtils.ToString(cboUser.EditValue);
            DataTable dtAction = LibQLSX.Select("select * from vProjectProblemActionUserLink with(nolock) where UserId = '" + userId + "'");
            grdData.DataSource = dtAction;
        }

        private void cboUser_EditValueChanged(object sender, EventArgs e)
        {
            loadGrid();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string folderPath = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                folderPath = fbd.SelectedPath;
            }
            else
            {
                return;
            }

            string fullName = TextUtils.ToString(grvCboUser.GetFocusedRowCellValue(colFullName));

            TextUtils.ExportExcel(grvData, folderPath, fullName, false);
            string filepath = folderPath + "//" + fullName + ".xls";

            DataTable dtFile = new DataTable();
            
            dtFile.Columns.Add("ID");
            dtFile.Columns.Add("FileName");
            dtFile.Columns.Add("Path");

            dtFile.Rows.Add(0, Path.GetFileName(filepath), filepath);

            string content = " Dear "+ fullName + "!<br>" + "Phòng dự án gửi anh/chị các vấn đề mà anh/chị phụ trách.<br> Đề nghị anh/chị thực hiện theo đúng kế hoạch.<br>Xin chân thành cảm ơn.";
            string subject = "VẤN ĐỀ TỒN ĐỌNG DỰ ÁN";
            frmSendEmailAttach frm = new frmSendEmailAttach();
            frm.To = TextUtils.ToString(grvCboUser.GetFocusedRowCellValue(colAccount))+"@tpa.com.vn";
            frm.Content = content;
            frm.Subject = subject;
            frm.dtFile = dtFile;
            frm.IsClosed = true;
            frm.CC = "thanh.bx@tpa.com.vn;anh.ht@tpa.com.vn;thuong.nt@tpa.com.vn;thai.qq@tpa.com.vn;trong.ph@tpa.com.vn";
            TextUtils.OpenForm(frm);
        }
    }
}
