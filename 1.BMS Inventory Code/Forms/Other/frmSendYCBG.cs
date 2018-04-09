using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace BMS
{
    public partial class frmSendYCBG : _Forms
    {
        public DataTable DtFile = new DataTable();
        int _i = 0;
        string _content = "";
        public bool IsSent = false;
        public string SentTo = "";

        public frmSendYCBG()
        {
            InitializeComponent();
        }

        private void frmSendYCBG_Load(object sender, EventArgs e)
        {
            loadSupplier();
            txtSubject.Text = "Yêu cầu báo giá";

            grvData.AutoGenerateColumns = false;
            grvData.DataSource = null;
            grvData.DataSource = DtFile;

            DataTable dtEmailContent = TextUtils.Select("select KeyValue from [ConfigSystem] with(nolock) where [KeyName] = 'Ycbg_Email'");
            _content = dtEmailContent.Rows[0][0].ToString();
            txtContent.Text = _content;
        }

        void loadSupplier() 
        {
            DataTable dt = LibQLSX.Select("select * from Suppliers where SupplierCode like '%NCC%' order by SupplierCode");
            cboSupplier.Properties.DataSource = dt;
            cboSupplier.Properties.DisplayMember = "SupplierName";
            cboSupplier.Properties.ValueMember = "SupplierCode";
        }

        private void cboSupplier_EditValueChanged(object sender, EventArgs e)
        {
            string email = TextUtils.ToString(grvSupplier.GetFocusedRowCellValue(colEmail));
            string contactPerson = TextUtils.ToString(grvSupplier.GetFocusedRowCellValue(colContactPerson));
            txtTo.Text = email;
            txtContent.Text = _content.Replace("<ContactPerson>", contactPerson);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtTo.Text.Trim() == "")
            {
                MessageBox.Show("Bạn hãy nhập địa chỉ mail đến!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            #region Mở outlook
            int count = Process.GetProcesses().Where(o => o.ProcessName.Contains("OUTLOOK")).Count();
            if (count == 0)
            {
                try
                {
                    Process.Start("outlook.exe");
                }
                catch (Exception)
                {
                }
            }
            #endregion Mở outlook

            List<string> at = new List<string>();

            if (DtFile.Rows.Count > 0)
            {
                foreach (DataRow row in DtFile.Rows)
                {
                    at.Add(row["Path"].ToString());
                }
            }

            bool success = TextUtils.SetEmailSendHasAttach(txtSubject.Text.Trim(), txtContent.Text.Trim().Replace("\r\n","<br>"), txtTo.Text.Trim(), txtCC.Text.Trim(), at);

            if (success)
            {
                MessageBox.Show("Đã gửi mail thành công!", TextUtils.Caption);
                IsSent = true;
                SentTo = txtTo.Text.Trim();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Gửi không thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (string item in ofd.FileNames)
                {
                    _i++;
                    DtFile.Rows.Add(_i.ToString(), Path.GetFileName(item), item);
                }
                grvData.AutoGenerateColumns = false;
                grvData.DataSource = null;
                grvData.DataSource = DtFile;
            }
        }

        private void xóaFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grvData.SelectedRows.Count == 0) return;
            int id = TextUtils.ToInt(grvData.SelectedRows[0].Cells[colID.Name].Value);
            if (id == 0) return;
            try
            {
                DtFile = DtFile.Select("ID <> '" + id + "'").CopyToDataTable();
            }
            catch (Exception)
            {
                DtFile.Rows.Clear();
            }
            grvData.AutoGenerateColumns = false;
            grvData.DataSource = null;
            grvData.DataSource = DtFile;
        }
    }
}
