using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Model;
using BMS.Business;
using System.IO;
using iTextSharp.text.pdf;
using System.Diagnostics;
using DevExpress.Utils;
using System.Collections;

namespace BMS
{
    public partial class frmBaoCaoLoi : _Forms
    {
        string NVCoKhi;
        string NVDien;
        string NVDT;
        int _rownIndex = 0;

        #region Constructors and Load
        public frmBaoCaoLoi()
        {
            InitializeComponent();
        }

        private void frmBaoCaoLoi_Load(object sender, EventArgs e)
        {
            loadYear();
            repositoryItemCheckEdit1.ValueChecked = 1;
            repositoryItemCheckEdit1.ValueUnchecked = 0;
            //loadGrid();
        }
        #endregion

        #region Methods
        void loadYear()
        {
            cboYear.Items.Add("Tất cả");
            for (int i = 2013; i <= DateTime.Now.Year; i++)
            {
                cboYear.Items.Add(i);
            }
            cboYear.SelectedItem = DateTime.Now.Year;
        }

        void loadGrid()
        {
            try
            {
                string[] paraName = new string[2];
                object[] paraValue = new object[2];
                paraName[0] = "@TextFind";paraValue[0] = txtTextFind.Text.Trim();
                paraName[1] = "@Year";paraValue[1] = TextUtils.ToInt(cboYear.SelectedItem);

                DataTable Source = MaterialBO.Instance.LoadDataFromSP("spGetFilterError", "Source", paraName, paraValue);
                
                //if (!TextUtils.HasPermission("frmBaoCaoLoi_ViewAll_TK"))
                //{
                //    Source = Source.Select("ConfirmManager = 1 or CreatedBy = '" + Global.AppUserName + "'").CopyToDataTable();
                //}
                //else
                //{
                //    Source = Source.Select("ConfirmManager = 1 or (ConfirmManager = 0 and DepartmentIDCreated = " + Global.DepartmentID + ")").CopyToDataTable();
                //}

                grdData.DataSource = Source;

                if (_rownIndex >= grvData.RowCount)
                    _rownIndex = 0;
                if (_rownIndex > 0)
                    grvData.FocusedRowHandle = _rownIndex;
                grvData.SelectRow(_rownIndex);
            }
            catch (Exception ex)
            {
                TextUtils.ShowError(ex);
            }
        }

        string getAddressMail(string personName)
        {
            if (personName != "")
            {
                DataTable dt = TextUtils.Select(string.Format("select * from dbo.Users where LoginName =N'{0}' or FullName=N'{0}'", personName));
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["LoginName"].ToString();
                }
                else
                {
                    return personName.Trim();
                }                
            }
            else
            {
                return "tpa";
            }            
        }

        List<string> getListMail(string ProductCode)
        {
            NVCoKhi = "";
            NVDien = "";
            NVDT = "";

            DocUtils.InitFTPQLSX();
            List<string> listMailAddress = new List<string>();

            if (ProductCode.StartsWith("TPAD."))
            {
                #region Get Address of Điện
                string personDien = "";
                try
                {
                    string fdfFileName = string.Format("Thietke.Dn\\{0}\\{1}.Dn\\PRD.{1}\\{1}.Dn.pdf", ProductCode.Substring(0, 6), ProductCode);
                    if (DocUtils.CheckExits(fdfFileName))
                    {
                        DocUtils.DownloadFile("D:/", Path.GetFileName(fdfFileName), fdfFileName);
                        PdfReader reader1 = new PdfReader("D:/" + Path.GetFileName(fdfFileName));
                        personDien = reader1.Info["Author"];
                        reader1.Close();
                        File.Delete("D:/" + Path.GetFileName(fdfFileName));
                    }
                    else
                    {
                        fdfFileName = string.Format("Thietke.Dn/{0}/{1}.Dn/{1}.Dn.pdf", ProductCode.Substring(0, 6), ProductCode);
                        if (DocUtils.CheckExits(fdfFileName))
                        {
                            DocUtils.DownloadFile("D:/", Path.GetFileName(fdfFileName), fdfFileName);
                            PdfReader reader1 = new PdfReader("D:/" + Path.GetFileName(fdfFileName));
                            personDien = reader1.Info["Author"];
                            reader1.Close();
                            File.Delete("D:/" + Path.GetFileName(fdfFileName));
                        }
                    }

                    if (personDien != "")
                    {
                        NVDien = personDien;
                        personDien = getAddressMail(personDien);
                        if (personDien != "")
                        {
                            listMailAddress.Add(getAddressMail(personDien) + "@tpa.com.vn");
                        }
                    }
                }
                catch
                {
                }
                #endregion

                string _serverPathCK = "Thietke.Ck/" + ProductCode.Substring(0, 6) + "/" + ProductCode + ".Ck/" + "/VT." + ProductCode + ".xlsm";

                try
                {
                    if (DocUtils.CheckExits(_serverPathCK))
                    {
                        #region Get Address of Module
                        if (File.Exists("D:/VT." + ProductCode + ".xlsm"))
                        {
                            File.Delete("D:/VT." + ProductCode + ".xlsm");
                        }
                        //Download file danh mục vật tư
                        DocUtils.DownloadFile("D:/", "VT." + ProductCode + ".xlsm", _serverPathCK);
                        DataTable dtDMVT = TextUtils.ExcelToDatatable("D:/VT." + ProductCode + ".xlsm", "DMVT");
                        File.Delete("D:/VT." + ProductCode + ".xlsm");

                        NVCoKhi = dtDMVT.Rows[2]["F3"].ToString();
                        string ck = getAddressMail(dtDMVT.Rows[2]["F3"].ToString());
                        if (ck != "")
                        {
                            if (!listMailAddress.Contains(ck + "@tpa.com.vn"))
                            {
                                listMailAddress.Add(ck + "@tpa.com.vn");
                            }
                        }
                        #endregion

                        try
                        {
                            DataTable dtDT = dtDMVT.Select("F4 like '%PCB%'").CopyToDataTable();
                            if (dtDT.Rows.Count > 0)
                            {
                                string dienTuPath = "Thietke.Dt/PCB/";
                                foreach (DataRow item in dtDT.Rows)
                                {
                                    #region Get address of PCB
                                    string code = item["F4"].ToString();
                                    if (code != "")
                                    {
                                        string pathDMVT_DT = dienTuPath + "/" + code + "/PRD." + code + "/VT." + code + ".xls";

                                        if (DocUtils.CheckExits(pathDMVT_DT))
                                        {
                                            try
                                            {
                                                DocUtils.DownloadFile("D:/", Path.GetFileName(pathDMVT_DT), pathDMVT_DT);
                                                DataTable dtDMVT_DT = TextUtils.ExcelToDatatable("D:/VT." + code + ".xls", "DMVT");
                                                File.Delete("D:/VT." + code + ".xls");
                                                NVDT += dtDMVT_DT.Rows[2]["F3"].ToString() + " - " + code + ",";
                                                string dt = getAddressMail(dtDMVT_DT.Rows[2]["F3"].ToString());
                                                if (dt != "")
                                                {
                                                    string personDT = dt + "@tpa.com.vn";
                                                    if (!listMailAddress.Contains(personDT))
                                                    {
                                                        listMailAddress.Add(personDT);
                                                    }
                                                }
                                            }
                                            catch (Exception)
                                            {
                                            }
                                        }
                                    }
                                    #endregion
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                }
                catch
                {
                }
            }

            if (ProductCode.StartsWith("PCB."))
            {
                #region Get address of PCB
                string dienTuPath = "Thietke.Dt/PCB/";
                string code = ProductCode;
                if (code != "")
                {
                    string pathDMVT_DT = dienTuPath + "/" + code + "/PRD." + code + "/VT." + code + ".xls";

                    if (DocUtils.CheckExits(pathDMVT_DT))
                    {
                        try
                        {
                            DocUtils.DownloadFile("D:/", Path.GetFileName(pathDMVT_DT), pathDMVT_DT);
                            DataTable dtDMVT_DT = TextUtils.ExcelToDatatable("D:/VT." + code + ".xls", "DMVT");
                            File.Delete("D:/VT." + code + ".xls");
                            NVDT += dtDMVT_DT.Rows[2]["F3"].ToString() + " - " + code + ",";
                            string dt = getAddressMail(dtDMVT_DT.Rows[2]["F3"].ToString());
                            if (dt != "")
                            {
                                string personDT = dt + "@tpa.com.vn";
                                if (!listMailAddress.Contains(personDT))
                                {
                                    listMailAddress.Add(personDT);
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                }
                #endregion
            }
           
            return listMailAddress;
        }

        void sendKcsMail()
        {
            string subject = "";
            string content = "";
            string to = "";
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load dữ liệu..."))
            {
                int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
                string departmentCodeGL = grvData.GetFocusedRowCellValue(colDepartmentCodeGL).ToString();
                string departmentMailGL = "";
                try
                {
                    departmentMailGL = ((DepartmentModel)DepartmentBO.Instance.FindByAttribute("Code", departmentCodeGL)[0]).Email;
                }
                catch
                {
                    //departmentMailGL = "info@tpa.com.vn";
                    departmentMailGL = "vt@tpa.com.vn;tk1@tpa.com.vn;tk2@tpa.com.vn;sxlr@tpa.com.vn;";
                }
                ModulesModel product = (ModulesModel)ModulesBO.Instance.FindByAttribute("Code", grvData.GetFocusedRowCellValue(colModuleCode).ToString())[0];
                string productCode = product.Code;
                string projectCode = TextUtils.ToString(grvData.GetFocusedRowCellValue(colProjectCode));
                List<string> listEmail = getListMail(productCode);

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

                subject = string.Format("ERROR REPORT - {0} - {1}", TextUtils.ToString(grvData.GetFocusedRowCellValue(colCode)), productCode);

                DataTable dtProjectUser = LibQLSX.Select("SELECT p.ProjectCode, u.UserName FROM Project p INNER JOIN Users u ON p.UserId = u.UserId where p.ProjectCode='" + projectCode + "'");
                string projectUser = dtProjectUser.Rows.Count > 0 ? TextUtils.ToString(dtProjectUser.Rows[0][1]) : "";

                DataTable dtConfig = TextUtils.Select("select KeyValue from [ConfigSystem] where [KeyName]='KcsToTK_Email'");
                content = dtConfig.Rows[0][0].ToString();
                content = content.Replace("<ErrorCode>", "<b>" + grvData.GetFocusedRowCellValue(colCode).ToString() + "</b>")
                    .Replace("<ProjectCode>", "<b>" + projectCode + "</b>")
                    .Replace("<ProjectUser>", "<b>" + projectUser == "" ? "Không tìm thấy" : projectUser + "</b>")
                    .Replace("<ProductCode>", "<b>" + productCode + "</b>")
                    .Replace("<ProductName>", product.Name)
                    .Replace("<UserFind>", grvData.GetFocusedRowCellValue(colUserFind) == null ? "Không tìm thấy" : grvData.GetFocusedRowCellValue(colUserFind).ToString())
                    .Replace("<TQ>", grvData.GetFocusedRowCellValue(colTQ) == null ? "Không tìm thấy" : grvData.GetFocusedRowCellValue(colTQ).ToString())
                    .Replace("<Description>", grvData.GetFocusedRowCellValue(colDes).ToString())
                    .Replace("<Ck>", NVCoKhi == "" ? "Không tìm thấy" : NVCoKhi)
                    .Replace("<Dn>", NVDien == "" ? "Không tìm thấy" : NVDien)
                    .Replace("<Dt>", NVDT == "" ? "Không tìm thấy" : NVDT);
                if (departmentCodeGL == "TK")//Phong TK
                {
                    foreach (string item in listEmail)
                    {
                        to += item.ToLower() + ";";
                    }
                }
                else
                {
                    to = departmentMailGL + ";";
                }

                string supplierId = TextUtils.ToString(grvData.GetFocusedRowCellValue(colSupplierId));
                if (!string.IsNullOrEmpty(supplierId))
                {
                    to += TextUtils.ToString(LibQLSX.ExcuteScalar("SELECT Email FROM dbo.Suppliers WHERE SupplierId = '" + supplierId + "'"));
                }
            }
            frmSendEmailAttach frm = new frmSendEmailAttach();
            frm.Subject = subject;
            //frm.CC = "info@tpa.com.vn";
            frm.To = to;
            frm.Content = content;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ModuleErrorModel errorModel = (ModuleErrorModel)ModuleErrorBO.Instance.FindByPK(TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID)));
                errorModel.CreateMailContent = Global.AppFullName + " - " + Environment.MachineName + " đã gửi mail vào ngày: " + DateTime.Now;
                ModuleErrorBO.Instance.Update(errorModel);
                loadGrid();
            }
        }

        void sendKcsMail(int index)
        {
            string subject = "";
            string content = "";
            string to = "";
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load dữ liệu..."))
            {
                int id = TextUtils.ToInt(grvData.GetRowCellValue(index, colID));
                string departmentCodeGL = grvData.GetRowCellValue(index, colDepartmentCodeGL).ToString();
                string departmentMailGL = "";
                try
                {
                    departmentMailGL = ((DepartmentModel)DepartmentBO.Instance.FindByAttribute("Code", departmentCodeGL)[0]).Email;
                }
                catch
                {
                    //departmentMailGL = "info@tpa.com.vn";
                    departmentMailGL = "vt@tpa.com.vn;tk1@tpa.com.vn;tk2@tpa.com.vn;sxlr@tpa.com.vn;";
                }
                ModulesModel product = (ModulesModel)ModulesBO.Instance.FindByAttribute("Code", grvData.GetRowCellValue(index, colModuleCode).ToString())[0];
                string productCode = product.Code;
                string projectCode = TextUtils.ToString(grvData.GetRowCellValue(index, colProjectCode));
                List<string> listEmail = getListMail(productCode);

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

                subject = string.Format("ERROR REPORT - {0} - {1}", TextUtils.ToString(grvData.GetRowCellValue(index, colCode)), productCode);

                DataTable dtProjectUser = LibQLSX.Select("SELECT p.ProjectCode, u.UserName FROM Project p INNER JOIN Users u ON p.UserId = u.UserId where p.ProjectCode='" + projectCode + "'");
                string projectUser = dtProjectUser.Rows.Count > 0 ? TextUtils.ToString(dtProjectUser.Rows[0][1]) : "";

                DataTable dtConfig = TextUtils.Select("select KeyValue from [ConfigSystem] where [KeyName]='KcsToTK_Email'");
                content = dtConfig.Rows[0][0].ToString();
                content = content.Replace("<ErrorCode>", "<b>" + grvData.GetRowCellValue(index, colCode).ToString() + "</b>")
                    .Replace("<ProjectCode>", "<b>" + projectCode + "</b>")
                    .Replace("<ProjectUser>", "<b>" + projectUser == "" ? "Không tìm thấy" : projectUser + "</b>")
                    .Replace("<ProductCode>", "<b>" + productCode + "</b>")
                    .Replace("<ProductName>", product.Name)
                    .Replace("<UserFind>", grvData.GetRowCellValue(index, colUserFind) == null ? "Không tìm thấy" : grvData.GetRowCellValue(index, colUserFind).ToString())
                    .Replace("<TQ>", grvData.GetRowCellValue(index, colTQ) == null ? "Không tìm thấy" : grvData.GetRowCellValue(index, colTQ).ToString())
                    .Replace("<Description>", grvData.GetRowCellValue(index, colDes).ToString())
                    .Replace("<Ck>", NVCoKhi == "" ? "Không tìm thấy" : NVCoKhi)
                    .Replace("<Dn>", NVDien == "" ? "Không tìm thấy" : NVDien)
                    .Replace("<Dt>", NVDT == "" ? "Không tìm thấy" : NVDT);
                if (departmentCodeGL == "TK")//Phong TK
                {
                    foreach (string item in listEmail)
                    {
                        to += item.ToLower() + ";";
                    }
                }
                else
                {
                    to = departmentMailGL + ";";
                }

                string supplierId = TextUtils.ToString(grvData.GetRowCellValue(index, colSupplierId));
                if (!string.IsNullOrEmpty(supplierId))
                {
                    to += TextUtils.ToString(LibQLSX.ExcuteScalar("SELECT Email FROM dbo.Suppliers WHERE SupplierId = '" + supplierId + "'"));
                }
            }

            frmSendEmailAttach frm = new frmSendEmailAttach();
            frm.Subject = subject;
            //frm.CC = "info@tpa.com.vn";
            frm.To = to;
            frm.Content = content;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ModuleErrorModel errorModel = (ModuleErrorModel)ModuleErrorBO.Instance.FindByPK(TextUtils.ToInt(grvData.GetRowCellValue(index, colID)));
                errorModel.CreateMailContent = Global.AppFullName + " - " + Environment.MachineName + " đã gửi mail vào ngày: " + DateTime.Now;
                ModuleErrorBO.Instance.Update(errorModel);
                loadGrid();
            }
        }
        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmBCLError frm = new frmBCLError();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                loadGrid();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (grvData.FocusedRowHandle < 0) return;
            ModuleErrorModel model = (ModuleErrorModel)ModuleErrorBO.Instance.FindByPK(TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID)));
            if (model.CreatedBy != Global.LoginName)
            {
                MessageBox.Show("Bạn không có quyền sửa lỗi này!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (model.StatusTK == 1)
            {
                MessageBox.Show("Bạn không thể sửa lỗi này.\nDo lỗi này đã được thiết kế xác nhận.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
            }

            frmBCLError frm = new frmBCLError();
            frm.ErrorModel = model;
            _rownIndex = grvData.FocusedRowHandle;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                loadGrid();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (grvData.FocusedRowHandle < 0) return;
            ModuleErrorModel model = (ModuleErrorModel)ModuleErrorBO.Instance.FindByPK(TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID)));
            if (model.CreatedBy != Global.LoginName)
            {
                MessageBox.Show("Bạn không có quyền xóa lỗi này!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (TextUtils.ToInt(grvData.GetFocusedRowCellValue(colConfirmManager)) == 1)
            {
                MessageBox.Show("Bạn không thể xóa lỗi [" + grvData.GetFocusedRowCellValue(colCode).ToString() + "] vì lỗi đã được xác nhận bởi trưởng bộ phận.",
                TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (TextUtils.ToInt(grvData.GetFocusedRowCellValue(colStatusTK))==1)
            {
                MessageBox.Show("Bạn không thể xóa lỗi [" + grvData.GetFocusedRowCellValue(colCode).ToString() + "] vì lỗi đã được xác nhận.",
                TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa lỗi [" + grvData.GetFocusedRowCellValue(colCode).ToString() + "] ?", 
                TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ModuleErrorBO.Instance.Delete(TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID)));
                loadGrid();
            }
        }

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            int count = 0;
            DataTable dt = TextUtils.ExcelToDatatable(@"D:\\123.xlsx", "Sheet1");
            DataTable tblLink = TextUtils.Select("exec spGetModuleOfProject");
            foreach (DataRow item in dt.Rows)
            {
                try
                {
                    string code = item[0].ToString();
                    ModuleErrorModel error = (ModuleErrorModel)ModuleErrorBO.Instance.FindByAttribute("Code", code)[0];
                    if (error.ProjectCode != "") continue;
                    string projectText = item["F3"].ToString();
                    ModulesModel module = (ModulesModel)ModulesBO.Instance.FindByPK(error.ModuleID);
                    DataRow[] dt1 = tblLink.Select("ProjectCode like '%" + projectText + "%' and ProductCode = '" + module.Code + "'");
                    if (dt1.Length > 0)
                    {
                        
                        error.ProjectCode = dt1[0]["ProjectCode"].ToString();
                        ModuleErrorBO.Instance.Update(error);
                        count++;
                    }
                }
                catch (Exception)
                {
                }
            }
            MessageBox.Show( count+ " OK");
        }

        private void btnTK_XacNhan_Click(object sender, EventArgs e)
        {
            _rownIndex = grvData.FocusedRowHandle;

            frmError frm = new frmError();
            frm.ErrorModel = (ModuleErrorModel)ModuleErrorBO.Instance.FindByPK(TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID)));
            
            if (frm.ShowDialog() == DialogResult.OK)
            {
                loadGrid();
            }
        }

        private void sửaLỗiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnEdit_Click(null,null);
        }

        private void xóaLỗiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDelete_Click(null,null);
        }

        private void thiếtKếXácNhậnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnTK_XacNhan_Click(null,null);
        }

        private void btnKCS_XacNhan_Click(object sender, EventArgs e)
        {
            int count = 0;
            if (MessageBox.Show("Bạn có chắc muốn xác nhận những lỗi này đã được khắc phục?", TextUtils.Caption, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _rownIndex = grvData.FocusedRowHandle;

                foreach (int i in grvData.GetSelectedRows())
                {
                    if (i < 0) continue;
                    int iD = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                    ModuleErrorModel model = (ModuleErrorModel)ModuleErrorBO.Instance.FindByPK(iD);
                    if (model.StatusTK == 1)
                    {
                        model.Status = 1;
                        model.CompleteTimeKCS = TextUtils.GetSystemDate();
                        ModuleErrorBO.Instance.Update(model);
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                loadGrid();
            }
        }

        private void gửiMailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModuleErrorModel model = (ModuleErrorModel)ModuleErrorBO.Instance.FindByPK(TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID)));
            if (model.CreatedBy != Global.LoginName)
            {
                MessageBox.Show("Bạn không có quyền gửi mail báo lỗi này!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (model.ConfirmManager == 0)
            {
                MessageBox.Show("Lỗi này chưa được trưởng bộ phận xác nhận!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            sendKcsMail();
        }

        private void btnSendMailComplete_Click(object sender, EventArgs e)
        {
            try
            {
                ModuleErrorModel errorModel = (ModuleErrorModel)ModuleErrorBO.Instance.FindByPK(TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID)));
                if (errorModel.StatusTK == 0)
                {
                    MessageBox.Show("Lỗi chưa được xác nhận là đã khắc phục!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                ModulesModel product = (ModulesModel)ModulesBO.Instance.FindByPK(errorModel.ModuleID);

                frmSendEmailAttach frm = new frmSendEmailAttach();
                frm.To = "kcs@tpa.com.vn";
                //frm.CC = "info@tpa.com.vn";
                frm.CC = "vt@tpa.com.vn;tk1@tpa.com.vn;tk2@tpa.com.vn;sxlr@tpa.com.vn;";
                frm.Subject = string.Format("ERROR REPORT - {0} - {1} - Đã khắc phục", errorModel.Code, product.Code);
                DataTable dtConfig = TextUtils.Select("select KeyValue from [ConfigSystem] where [KeyName]='TKToKCS_Email'");
                string content = dtConfig.Rows[0][0].ToString();
                frm.Content = content.Replace("<ErrorCode>", "<b>" + errorModel.Code + "</b>")
                    .Replace("<ProjectCode>", "<b>" + errorModel.ProjectCode + "</b>")
                    .Replace("<ProductCode>", "<b>" + product.Code + "</b>")
                    .Replace("<ProductName>", product.Name)
                    .Replace("<ErrorStatus>", "<b>Đã khắc phục</b>")
                    .Replace("<ErrorUser>", grvData.GetFocusedRowCellValue(colErrorUser).ToString())
                    .Replace("<TamThoi>", errorModel.HuongKhacPhucTamThoi)
                    .Replace("<LauDai>", errorModel.HuongKhacPhuc == "" ? "Chưa có" : errorModel.HuongKhacPhuc)
                    .Replace("<Description>", errorModel.Description);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    errorModel.ReceiveMailContent = Global.AppFullName + " - " + Environment.MachineName + " đã gửi mail vào ngày: " + DateTime.Now;
                    ModuleErrorBO.Instance.Update(errorModel);
                    loadGrid();

                    if (Global.DepartmentID == 1)//phong thiet ke
                    {
                        DataTable dt = TextUtils.Select("select * from ModuleVersion where ModuleErrorCode = '" + errorModel.Code + "'");
                        if (dt.Rows.Count == 0)
                        {
                            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát", "Đang tạo phiên bản thiết kế"))
                            {
                                try
                                {
                                    string path = TextUtils.DownloadAll(product.Code);

                                    ModuleVersionModel model = new ModuleVersionModel();
                                    model.ProjectCode = errorModel.ProjectCode;
                                    model.ModuleCode = product.Code;
                                    model.ModuleErrorCode = errorModel.Code;
                                    model.Version = TextUtils.ToInt(Path.GetFileName(path));
                                    model.Path = path;
                                    model.Description = frm.Description;
                                    model.Reason = "Sửa lỗi: " + errorModel.Code;
                                    ModuleVersionBO.Instance.Insert(model);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Lỗi: " + ex.Message);
                                }
                            }
                        }
                    }                    
                }
            }
            catch (Exception)
            {                
            }            
        }

        private void gửiMailThôngBáoGiảiPhápTạmThờiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ModuleErrorModel errorModel = (ModuleErrorModel)ModuleErrorBO.Instance.FindByPK(TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID)));
                ModulesModel product = (ModulesModel)ModulesBO.Instance.FindByPK(errorModel.ModuleID);

                frmSendEmailAttach frm = new frmSendEmailAttach();
                frm.To = "kcs@tpa.com.vn";
                //frm.CC = "info@tpa.com.vn";
                frm.CC = "vt@tpa.com.vn;tk1@tpa.com.vn;tk2@tpa.com.vn;sxlr@tpa.com.vn;";
                frm.Subject = string.Format("ERROR REPORT - {0} - {1} - Khắc phục tạm thời", errorModel.Code, product.Code);
                DataTable dtConfig = TextUtils.Select("select KeyValue from [ConfigSystem] where [KeyName]='TKToKCS_Email'");
                string content = dtConfig.Rows[0][0].ToString();
                frm.Content = content.Replace("<ErrorCode>", "<b>" + errorModel.Code + "</b>")
                    .Replace("<ProjectCode>", "<b>" + errorModel.ProjectCode + "</b>")
                    .Replace("<ProductCode>", "<b>" + product.Code + "</b>")
                    .Replace("<ProductName>", product.Name)
                    .Replace("<ErrorStatus>", "<b>Khắc phục tạm thời</b>")
                    .Replace("<ErrorUser>", grvData.GetFocusedRowCellValue(colErrorUser).ToString())
                    .Replace("<TamThoi>", errorModel.HuongKhacPhucTamThoi)
                    .Replace("<LauDai>", errorModel.HuongKhacPhuc == "" ? "Chưa có" : errorModel.HuongKhacPhuc)
                    .Replace("<Description>", errorModel.Description);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    errorModel.ReceiveMailContent = Global.AppFullName + " - " + Environment.MachineName + " đã gửi mail vào ngày: " + DateTime.Now;
                    ModuleErrorBO.Instance.Update(errorModel);
                    loadGrid();
                }
            }
            catch (Exception)
            {

            }
        }

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            //loadGrid();
            //grvData.Focus();
        }

        private void btnConfirmTemp_Click(object sender, EventArgs e)
        {
            int count = 0;
            if (MessageBox.Show("Bạn có chắc muốn xác nhận tạm thời bỏ qua những lỗi này?", TextUtils.Caption, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _rownIndex = grvData.FocusedRowHandle;

                foreach (int i in grvData.GetSelectedRows())
                {
                    if (i < 0) continue;
                    int iD = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                    ModuleErrorModel model = (ModuleErrorModel)ModuleErrorBO.Instance.FindByPK(iD);
                    if (model.ConfirmTemp == 0)
                    {
                        model.ConfirmTemp = 1;
                        ModuleErrorBO.Instance.Update(model);
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                loadGrid();
            }
        }

        private void bỏXácNhậnTạmThờiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = 0;
           
            _rownIndex = grvData.FocusedRowHandle;

            foreach (int i in grvData.GetSelectedRows())
            {
                if (i < 0) continue;
                int iD = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                ModuleErrorModel model = (ModuleErrorModel)ModuleErrorBO.Instance.FindByPK(iD);
                if (model.ConfirmTemp == 1)
                {
                    model.ConfirmTemp = 0;
                    ModuleErrorBO.Instance.Update(model);
                    count++;
                }
            }
           
            if (count > 0)
            {
                loadGrid();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //cboYear.SelectedIndex = 0;
            loadGrid(); 
        }

        private void txtTextFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboYear.Text = "";
                loadGrid();
            }
        }

        private void kCSHủyXácNhậnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = 0;
            _rownIndex = grvData.FocusedRowHandle;

            foreach (int i in grvData.GetSelectedRows())
            {
                if (i < 0) continue;
                int iD = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                ModuleErrorModel model = (ModuleErrorModel)ModuleErrorBO.Instance.FindByPK(iD);
                if (model.Status == 1)
                {
                    model.Status = 0;
                    model.CompleteTimeKCS = TextUtils.GetSystemDate();
                    ModuleErrorBO.Instance.Update(model);
                    count++;
                }
            }
            if (count > 0)
            {
                loadGrid();
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            TextUtils.ExportExcel(grvData);
        }

        private void btnListError_Click(object sender, EventArgs e)
        {
            frmErrorReport frm = new frmErrorReport();
            TextUtils.OpenForm(frm);
        }

        private void btnConfirmManager_Click(object sender, EventArgs e)
        {
            string createdby = TextUtils.ToString(grvData.GetFocusedRowCellValue(colCreatedBy));
            int departmentCurrent = Global.DepartmentID;
            ArrayList userArray = UsersBO.Instance.FindByAttribute("LoginName", createdby);
            UsersModel user = new UsersModel();
            if (userArray != null)
            {
                if (userArray.Count > 0)
                {
                    user = (UsersModel)userArray[0];
                }
            }
            if (departmentCurrent != user.DepartmentID)
            {
                MessageBox.Show("Bạn không có quyền xác nhận lỗi này.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            int count = 0;
            if (MessageBox.Show("Bạn có chắc muốn xác nhận những lỗi này là đúng?", TextUtils.Caption, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _rownIndex = grvData.FocusedRowHandle;

                foreach (int i in grvData.GetSelectedRows())
                {
                    if (i < 0) continue;
                    int iD = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                    ModuleErrorModel model = (ModuleErrorModel)ModuleErrorBO.Instance.FindByPK(iD);
                    if (model.ConfirmManager == 0)
                    {
                        model.ConfirmManager = 1;
                        ModuleErrorBO.Instance.Update(model);
                        count++;

                        sendKcsMail(i);
                    }
                }

                if (count > 0)
                {
                    //MessageBox.Show("Trưởng bộ phận xác nhận lỗi thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadGrid();
                }
            }
        }

        private void trưởngBộPhậnHủyXácNhậnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string createdby = TextUtils.ToString(grvData.GetFocusedRowCellValue(colCreatedBy));
            int departmentCurrent = Global.DepartmentID;
            ArrayList userArray = UsersBO.Instance.FindByAttribute("LoginName", createdby);
            UsersModel user = new UsersModel();
            if (userArray != null)
            {
                if ( userArray.Count > 0)
                {
                    user = (UsersModel)userArray[0];
                }
            }
            if (departmentCurrent != user.DepartmentID)
            {
                MessageBox.Show("Bạn không có quyền hủy xác nhận lỗi này?", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            int count = 0;
            if (MessageBox.Show("Bạn có chắc muốn hủy xác nhận?", TextUtils.Caption, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _rownIndex = grvData.FocusedRowHandle;

                foreach (int i in grvData.GetSelectedRows())
                {
                    if (i < 0) continue;
                    int iD = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                    ModuleErrorModel model = (ModuleErrorModel)ModuleErrorBO.Instance.FindByPK(iD);
                    if (model.ConfirmManager == 1)
                    {
                        model.ConfirmManager = 0;
                        ModuleErrorBO.Instance.Update(model);
                        count++;
                    }
                }

                if (count > 0)
                {
                    MessageBox.Show("Trưởng bộ phận hủy xác nhận lỗi thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadGrid();
                }
            }
        }

        private void xemẢnhLỗiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModuleErrorModel model = (ModuleErrorModel)ModuleErrorBO.Instance.FindByPK(TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID)));
            frmBCLError frm = new frmBCLError(1);
            frm.ErrorModel = model;
            frm.Show();            
        }

        private void cboYear_Click(object sender, EventArgs e)
        {

        }

        private void huỷChoPhépDownloadTàiLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = 0;
            if (MessageBox.Show("Bạn có chắc muốn huỷ cho phép download tài liệu liên quan đến lỗi này?", TextUtils.Caption, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _rownIndex = grvData.FocusedRowHandle;

                foreach (int i in grvData.GetSelectedRows())
                {
                    if (i < 0) continue;
                    int iD = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                    ModuleErrorModel model = (ModuleErrorModel)ModuleErrorBO.Instance.FindByPK(iD);
                    if (model.IsDownloaded == 1)
                    {
                        model.IsDownloaded = 0;
                        ModuleErrorBO.Instance.Update(model);
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                loadGrid();
            }
        }

        private void btnIsDownloaded_Click(object sender, EventArgs e)
        {
            int count = 0;
            if (MessageBox.Show("Bạn có chắc muốn cho phép download tài liệu liên quan đến lỗi này?", TextUtils.Caption, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _rownIndex = grvData.FocusedRowHandle;

                foreach (int i in grvData.GetSelectedRows())
                {
                    if (i < 0) continue;
                    int iD = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                    ModuleErrorModel model = (ModuleErrorModel)ModuleErrorBO.Instance.FindByPK(iD);
                    if (model.IsDownloaded == 0)
                    {
                        model.IsDownloaded = 1;
                        ModuleErrorBO.Instance.Update(model);
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                loadGrid();
            }
        }
    }
}
