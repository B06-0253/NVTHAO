using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Business;
using BMS.Model;
using DevExpress.Utils;
using System.IO;

namespace BMS
{
    public partial class frmUpdateModuleVersion : _Forms
    {
        public ModulesModel Module = new ModulesModel();
        string projectCodeSelect = "";
        List<string> listProject;

        public frmUpdateModuleVersion()
        {
            InitializeComponent();
        }

        private void frmUpdateModule_Load(object sender, EventArgs e)
        {
            this.Text = "Gửi mail cập nhật module: " + Module.Code;
            loadProject();
        }

        string loadProduct(string projectCode)
        {
            DataTable dtAll = LibQLSX.Select("spGetProductOfProjectNew '" + projectCode + "'");
            DataRow[] drs = dtAll.Select("MaThietBi = '" + Module.Code + "'");
            if (drs.Count() == 0) return "";
            DataTable dtThisModule = drs.CopyToDataTable();
            List<string> parentString = new List<string>();

            foreach (DataRow item in dtThisModule.Rows)
            {
                if (item["ManageId"] == null) continue;
                if (item["ManageId"].ToString() == "") continue;
                parentString.Add("'" + item["ManageId"].ToString() + "'");
            }

            string content = "<br>Dự án: <b>" + projectCode + "</b><br>Các hạng mục:<br>";

            if (parentString.Count>0)
            {
                DataTable dtProduct = dtAll.Select("PProductId in (" + string.Join(",", parentString.ToArray()) + ")")
                .CopyToDataTable();

                foreach (DataRow r in dtProduct.Rows)
                {
                    content += "  * " + r["ThietBi"].ToString() + "<br>";
                }
            }
            else
            {
                content += "  * " + Module.Code + " - " + Module.Name + "<br>";
            }
            return content;
        }

        bool ValidateForm()
        {
            if (grvProject.Rows.Count == 0)
            {
                MessageBox.Show("Không tồn tại dự án cho thiết kế này!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;            
            }

            int count = 0;
            foreach (DataGridViewRow itemRow in grvProject.Rows)
            {
                if (TextUtils.ToBoolean(itemRow.Cells[colCheck.Index].EditedFormattedValue))
                {
                    count++;
                }
            }

            if (count == 0)
            {
                MessageBox.Show("Không có dự án nào được chọn!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;     
            }

            return true;
        }

        void loadProject()
        {
            try
            {
                DataTable tbl = TextUtils.Select("exec spGetModuleOfProject '','" + Module.Code + "'");
                tbl.Columns.Add("check", typeof(bool));
                grvProject.AutoGenerateColumns = false;
                grvProject.DataSource = tbl;
            }
            catch (Exception ex)
            {
                grvProject.DataSource = null;
            }
        }
        
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            listProject = new List<string>();
            string hangmuc = "";
            foreach (DataGridViewRow itemRow in grvProject.Rows)
            {
                if (!TextUtils.ToBoolean(itemRow.Cells[colCheck.Index].EditedFormattedValue))
                {
                    continue;
                }
                listProject.Add(itemRow.Cells[colProjectCode.Index].Value.ToString());
                hangmuc += loadProduct(itemRow.Cells[colProjectCode.Index].Value.ToString());
            }

            string projectString = string.Join(", ", listProject.ToArray());

            string mailContent = "Gửi BP Dự án! <br>"
                                + "Thiết kế <b>" + Module.Code + " </b>vừa được update lại dự án: <br>"
                                + hangmuc
                                + "<br>Đề nghị Dự án vào xác nhận và YCVT!<br>";                              
                                
            frmSendEmailAttach frm = new frmSendEmailAttach();
            frm.Content = mailContent;
            frm.To = //"info@tpa.com.vn"; 
            "vt@tpa.com.vn;tk1@tpa.com.vn;tk2@tpa.com.vn;khsx@tpa.com.vn;kd1@tpa.com.vn;kd2@tpa.com.vn;";
            frm.Subject = "(" + projectString + ") - Update " + Module.Code;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                #region Update Version 
                //using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát", "Đang tạo phiên bản thiết kế"))
                //{
                //    try
                //    {
                //        string moduleCode = Module.Code;
                //        string ftpPathCk = string.Format("/Thietke.Ck/{0}/{1}.Ck", moduleCode.Substring(0, 6), moduleCode);
                //        string path = "";
                //        if (DocUtils.CheckExits(ftpPathCk))
                //        {                            
                //            path = TextUtils.DownloadAll(moduleCode);
                //        }
                //        if (path != "")
                //        {
                //            foreach (string projectCode in listProject)
                //            {
                //                ModuleVersionModel model = new ModuleVersionModel();
                //                model.ProjectCode = projectCode;
                //                model.ModuleCode = moduleCode;
                //                model.Version = TextUtils.ToInt(Path.GetFileName(path));
                //                model.Path = path;
                //                model.Description = frm.Description;
                //                model.Reason = frm.Description;
                //                ModuleVersionBO.Instance.Insert(model);  
                //            }                              
                //        }                             
                //    }
                //    catch (Exception ex)
                //    {
                //        TextUtils.ShowError(ex);
                //        return;
                //    }
                //}
                #endregion

                #region Update MaterialModuleLink
                try
                {
                    int id = Module.ID;
                    if (id == 0) return;

                    using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo danh mục vật tư..."))
                    {
                        string _serverPathCK = string.Format("Thietke.Ck/{0}/{1}.Ck/VT.{1}.xlsm",
                            Module.Code.Substring(0, 6), Module.Code);
                        DocUtils.InitFTPQLSX();
                        if (DocUtils.CheckExits(_serverPathCK))
                        {
                            DocUtils.DownloadFile("D:/", "VT." + Module.Code + ".xlsm", _serverPathCK);
                            DataTable dtDMVT = TextUtils.ExcelToDatatableNoHeader("D:/VT." + Module.Code + ".xlsm", "DMVT");
                            TextUtils.AddDMVTfromModule("D:/VT." + Module.Code + ".xlsm");
                            File.Delete("D:/VT." + Module.Code + ".xlsm");
                        }                       
                    }

                    MessageBox.Show("Cập nhật danh mục vật tư thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Cập nhật danh mục vật tư không thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion
            }
            this.Close();
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (grvProject.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in grvProject.Rows)
                {
                    row.Cells[0].Value = chkSelectAll.Checked;
                }
            }
        }

    }
}
