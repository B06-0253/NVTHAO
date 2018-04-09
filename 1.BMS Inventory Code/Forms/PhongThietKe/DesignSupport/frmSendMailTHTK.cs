using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using BMS.Model;
using BMS.Business;
using System.IO;

namespace BMS
{
    public partial class frmSendMailTHTK : _Forms
    {
        DataTable dtProject = new DataTable();

        public frmSendMailTHTK()
        {
            InitializeComponent();
        }

        private void frmSendMailTHTK_Load(object sender, EventArgs e)
        {
            DocUtils.InitFTPQLSX();
            loadProject();

            dtProject.Columns.Add("ProjectCode");
            grvProject.AutoGenerateColumns = false;
            grvProject.DataSource = dtProject;
        }

        void loadProject()
        {
            try
            {
                DataTable tbl = LibQLSX.Select("exec spGetAllProject");
                TextUtils.PopulateCombo(cboProject, tbl, "ProjectName", "ProjectCode", "");
            }
            catch (Exception ex)
            {
            }
        }

        string _muc = "";
        string _productName = "";
        string _projectCode = "";

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtDMVTPath.Text = ofd.FileName;
                DataTable dtModule = TextUtils.ExcelToDatatableNoHeader(ofd.FileName, "3");
                if (dtModule.Rows[5]["F12"].ToString().Contains(":"))
                    _muc = dtModule.Rows[5]["F12"].ToString().Split(':')[1].Trim();
                _productName = dtModule.Rows[5]["F1"].ToString().Split(':')[1].Trim();
                _projectCode = dtModule.Rows[2]["F8"].ToString().Trim();

                dtProject.Rows.Clear();
                dtProject.Rows.Add(_projectCode);

                dtModule = dtModule.Select("F5 like 'TPAD%'").CopyToDataTable();

                dtModule.Columns.Add("check", typeof(bool));

                grvModule.DataSource = null;
                grvModule.AutoGenerateColumns = false;
                grvModule.DataSource = dtModule;
            }
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (grvModule.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in grvModule.Rows)
                {
                    row.Cells[0].Value = chkSelectAll.Checked;
                }
            }
        }

        private void btnAddProject_Click(object sender, EventArgs e)
        {
            string projectCode = cboProject.EditValue.ToString();
            if (projectCode != "")
            {
                DataRow[] drs = dtProject.Select("ProjectCode = '" + projectCode + "'");
                if (drs.Count()==0)
                {
                    dtProject.Rows.Add(projectCode);
                }                
            }
            grvProject.AutoGenerateColumns = false;
            grvProject.DataSource = dtProject;
        }

        private void btnDeleteProject_Click(object sender, EventArgs e)
        {
             string projectCode = grvProject.SelectedRows[0].Cells[0].Value.ToString();
             if (projectCode != "")
             {
                 DataRow[] drs = dtProject.Select("ProjectCode = '" + projectCode + "'");
                 if (drs.Count() > 0)
                 {
                     dtProject = drs.CopyToDataTable();
                 }
                 else
                 {
                     dtProject.Rows.Clear();
                 }
             }
             grvProject.AutoGenerateColumns = false;
             grvProject.DataSource = dtProject;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (grvProject.Rows.Count == 0)
            {
                MessageBox.Show("Không có thông tin dự án dự án!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                string pCode = TextUtils.ToString(grvProject.Rows[0].Cells[0].Value);
                if (pCode == " ")
                {
                    MessageBox.Show("Không có thông tin dự án dự án!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }
            
            if (grvModule.Rows.Count == 0)
            {
                MessageBox.Show("Không tồn tại module trong tổng hợp thiết kế!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            int count = 0;
            foreach (DataGridViewRow itemRow in grvModule.Rows)
            {
                if (TextUtils.ToBoolean(itemRow.Cells[colCheck.Index].EditedFormattedValue))
                {
                    count++;
                }
            }

            if (count == 0)
            {
                MessageBox.Show("Không có module nào được chọn!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            List<string> listProject = new List<string>();
            foreach (DataGridViewRow itemRow in grvProject.Rows)
            {
                listProject.Add(itemRow.Cells[colPCode.Index].Value.ToString());
            }

            string mailContent = "";
            mailContent = ((ConfigSystemModel)ConfigSystemBO.Instance.FindByAttribute("KeyName", "MailTHTK")[0]).KeyValue;
            mailContent = mailContent.Replace("<Project>", listProject[0]);
            mailContent = mailContent.Replace("<HangMuc>", _muc + " - " + _productName);           

            string listModules = "";
            string moduleItem = ((ConfigSystemModel)ConfigSystemBO.Instance.FindByAttribute("KeyName", "MailTHTK.Item")[0]).KeyValue;
            int stt = 0;
            
            foreach (DataGridViewRow itemRow in grvModule.Rows)
            {
                if (!TextUtils.ToBoolean(itemRow.Cells[colCheck.Index].EditedFormattedValue))
                {
                    continue;
                }
                stt++;
                string moduleCode = TextUtils.ToString(itemRow.Cells[colModuleCode.Index].Value);
                listModules += moduleItem.Replace("<STT>", stt.ToString())
                    .Replace("<ModuleCode>", moduleCode)
                    .Replace("<ModuleName>", itemRow.Cells[colModuleName.Index].Value.ToString());
                
                DataTable dtItems = LibQLSX.Select("select ID from vDesignSummaryItem where ProjectCode = '" + listProject[0] + "' and Code = '" + moduleCode + "'");
                foreach (DataRow r in dtItems.Rows)
                {
                    int id = TextUtils.ToInt(r["ID"]);
                    TPA.Model.DesignSummaryItemModel m = (TPA.Model.DesignSummaryItemModel)TPA.Business.DesignSummaryItemBO.Instance.FindByPK(id);
                    m.IsTHTK = 1;
                    TPA.Business.DesignSummaryItemBO.Instance.Update(m);
                }
            }

            mailContent = mailContent.Replace("<listModule>", listModules);

            frmSendEmailAttach frm = new frmSendEmailAttach();
            frm.Content = mailContent;
            frm.To = "khsx@tpa.com.vn";
            frm.CC = //"info@tpa.com.vn";
                "vt@tpa.com.vn;tk1@tpa.com.vn;tk2@tpa.com.vn;kd1@tpa.com.vn;kd2@tpa.com.vn;";
            frm.Subject = "(" + string.Join(", ", listProject.ToArray()) + ") - " + Path.GetFileNameWithoutExtension(txtDMVTPath.Text);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát", "Đang tạo phiên bản thiết kế"))
                {
                    DocUtils.InitFTPQLSX();
                    //Tạo version cho module
                    foreach (DataGridViewRow itemRow in grvModule.Rows)
                    {
                        if (!TextUtils.ToBoolean(itemRow.Cells[colCheck.Index].EditedFormattedValue))
                        {
                            continue;
                        }
                        try
                        {
                            string moduleCode = itemRow.Cells[colModuleCode.Index].Value.ToString();
                            string ftpPathCk = string.Format("/Thietke.Ck/{0}/{1}.Ck", moduleCode.Substring(0, 6), moduleCode);
                           
                            DataTable dt = TextUtils.Select("select * from ModuleVersion where ModuleCode = '" + moduleCode + "'");
                            if (dt.Rows.Count == 0)
                            {
                                if (DocUtils.CheckExits(ftpPathCk))
                                {
                                    string path = TextUtils.DownloadAll(moduleCode);

                                    ModuleVersionModel model = new ModuleVersionModel();
                                    model.ModuleCode = moduleCode;
                                    model.ProjectCode = listProject[0];
                                    model.Version = 0;
                                    model.Path = path;
                                    model.Description = "Tạo phiên bản đầu tiên của module";
                                    model.Reason = "Tạo phiên bản đầu tiên của module";
                                    ModuleVersionBO.Instance.Insert(model);
                                }
                            }
                        }
                        catch (Exception)
                        {                           
                        }
                    }
                }
            }
            this.Close();
        }
        
    }
}
