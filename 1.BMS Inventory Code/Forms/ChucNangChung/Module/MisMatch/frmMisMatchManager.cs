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
using System.Diagnostics;
using System.IO;
using iTextSharp.text.pdf;
using DevExpress.Utils;

namespace BMS
{
    public partial class frmMisMatchManager : _Forms
    {
        string NVCoKhi;
        string NVDien;
        string NVDT;
        int _rownIndex = 0;

        #region Constructor and Load
        public frmMisMatchManager()
        {
            InitializeComponent();
        }

        private void frmMisMatchManager_Load(object sender, EventArgs e)
        {
            repositoryItemCheckEdit1.ValueChecked = 1;
            repositoryItemCheckEdit1.ValueUnchecked = 0;
            loadGrid();
        }
        #endregion

        #region Methods
        void loadGrid()
        {
            DataTable dt = TextUtils.Select("select *,(SELECT STUFF((SELECT '+ ' + [FullName] FROM [vMisMatchUser] where [MisMatchID]= vMisMatch.ID order by [FullName] FOR XML PATH ('')) , 1, 2, '') ) as MisMatchUser from vMisMatch order by ID desc");
            grdData.DataSource = dt;
            grvData.BestFitColumns();

            if (_rownIndex >= grvData.RowCount)
                _rownIndex = 0;
            if (_rownIndex > 0)
                grvData.FocusedRowHandle = _rownIndex;
            grvData.SelectRow(_rownIndex);
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

                string _serverPathCK = "Thietke.Ck/" + ProductCode.Substring(0, 6) + "/" + ProductCode + ".Ck/" + "/VT." + ProductCode + ".xlsm";

                try
                {
                    if (DocUtils.CheckExits(_serverPathCK))
                    {
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

                        try
                        {
                            DataTable dtDT = dtDMVT.Select("F4 like '%PCB%'").CopyToDataTable();
                            if (dtDT.Rows.Count > 0)
                            {
                                string dienTuPath = "Thietke.Dt/PCB/";
                                foreach (DataRow item in dtDT.Rows)
                                {
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
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            ModulesModel product = (ModulesModel)ModulesBO.Instance.FindByAttribute("Code", grvData.GetFocusedRowCellValue(colModule).ToString())[0];
            string productCode = product.Code;
            string projectCode = grvData.GetFocusedRowCellValue(colProjectCode).ToString();
            List<string> listEmail = getListMail(productCode);

            #region Mở outlook
            //int count = Process.GetProcesses().Where(o => o.ProcessName.Contains("OUTLOOK")).Count();
            //if (count == 0)
            //{
            //    try
            //    {
            //        Process.Start("outlook.exe");
            //    }
            //    catch (Exception)
            //    {
            //    }
            //}
            #endregion Mở outlook

            string subject = string.Format("Không phù hợp - {0} - {1}", grvData.GetFocusedRowCellValue(colCode).ToString(), productCode);

            DataTable dtProjectUser = LibQLSX.Select("SELECT p.ProjectCode, u.UserName FROM Project p INNER JOIN Users u ON p.UserId = u.UserId where p.ProjectCode='" + projectCode + "'");
            string projectUser = dtProjectUser.Rows[0][1] != null ? dtProjectUser.Rows[0][1].ToString() : "";

            DataTable dtConfig = TextUtils.Select("select KeyValue from [ConfigSystem] where [KeyName]='KPH_To_TK_Email'");
            string content = dtConfig.Rows[0][0].ToString();
            content = content.Replace("<ErrorCode>", "<b>" + grvData.GetFocusedRowCellValue(colCode).ToString() + "</b>")
                .Replace("<ProjectCode>", "<b>" + projectCode + "</b>")
                .Replace("<ProjectUser>", "<b>" + projectUser == "" ? "Không tìm thấy" : projectUser + "</b>")
                .Replace("<ProductCode>", "<b>" + productCode + "</b>")
                .Replace("<ProductName>", product.Name)
                .Replace("<UserFind>", grvData.GetFocusedRowCellValue(colUserFindText).ToString())
                .Replace("<Description>", grvData.GetFocusedRowCellValue(colDes).ToString())
                .Replace("<Ck>", NVCoKhi == "" ? "Không tìm thấy" : NVCoKhi)
                .Replace("<Dn>", NVDien == "" ? "Không tìm thấy" : NVDien)
                .Replace("<Dt>", NVDT == "" ? "Không tìm thấy" : NVDT);

            string to = "";
            foreach (string item in listEmail)
            {
                to += item.ToLower() + ";";
            }

            frmSendEmailAttach frm = new frmSendEmailAttach();
            frm.Subject = subject;
            frm.CC = //"info@tpa.com.vn";
            "vt@tpa.com.vn;tk1@tpa.com.vn;tk2@tpa.com.vn;sxlr@tpa.com.vn;";
            frm.To = to;
            frm.Content = content;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ModuleErrorModel errorModel = (ModuleErrorModel)ModuleErrorBO.Instance.FindByPK(TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID)));
                errorModel.CreateMailContent = Global.AppFullName + " đã gửi mail vào ngày: " + DateTime.Now;
                ModuleErrorBO.Instance.Update(errorModel);
            }
        }
        #endregion

        #region Events
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmMisMatch frm = new frmMisMatch();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                loadGrid();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (grvData.FocusedRowHandle < 0) return;
            MisMatchModel model = (MisMatchModel)MisMatchBO.Instance.FindByPK(TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID)));
            if (model.CreatedBy != Global.LoginName)
            {
                MessageBox.Show("Bạn không có quyền sửa sự không phù hợp này!", TextUtils.Caption,MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }

            if (model.ConfirmTK==1)
            {
                MessageBox.Show("Bạn không thể sửa sự không phù hợp này.\nDo sự không phù hợp này đã được thiết kế xác nhận.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            frmMisMatch frm = new frmMisMatch();
            frm.MisMatch = (MisMatchModel)MisMatchBO.Instance.FindByPK(TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID)));            

            if (frm.ShowDialog() == DialogResult.OK)
            {
                _rownIndex = grvData.FocusedRowHandle;
                loadGrid();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (grvData.FocusedRowHandle < 0) return;
            MisMatchModel model = (MisMatchModel)MisMatchBO.Instance.FindByPK(TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID)));
            if (model.CreatedBy != Global.LoginName)
            {
                MessageBox.Show("Bạn không có quyền xóa sự không phù hợp này!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            int confirm = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colConfirm));
            if (confirm == 1)
            {
                MessageBox.Show("Bạn không thể xóa [" + grvData.GetFocusedRowCellValue(colCode).ToString() + "], vì nó đã được xác nhận!",
                TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa [" + grvData.GetFocusedRowCellValue(colCode).ToString() + "] ?",
                TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MisMatchBO.Instance.Delete(TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID)));
                _rownIndex = grvData.FocusedRowHandle - 1;
                loadGrid();
            }
        }

        private void btnTK_XacNhan_Click(object sender, EventArgs e)
        {
            int count = 0;
            if (MessageBox.Show("Bạn có chắc muốn xác nhận những sự không phù hợp này là đúng?", TextUtils.Caption, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _rownIndex = grvData.FocusedRowHandle;

                foreach (int i in grvData.GetSelectedRows())
                {
                    if (i < 0) continue;
                    int iD = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                    MisMatchModel model = (MisMatchModel)MisMatchBO.Instance.FindByPK(iD);
                    model.ConfirmTK = 1;
                    MisMatchBO.Instance.Update(model);
                    count++;
                }
            }
            if (count > 0)
            {
                loadGrid();
            }
        }

        private void thiếtKếBỏXácNhậnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = 0;
            if (MessageBox.Show("Bạn có chắc muốn bỏ xác nhận những sự không phù hợp này?", TextUtils.Caption, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _rownIndex = grvData.FocusedRowHandle;

                foreach (int i in grvData.GetSelectedRows())
                {
                    if (i < 0) continue;
                    int iD = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                    MisMatchModel model = (MisMatchModel)MisMatchBO.Instance.FindByPK(iD);
                    if (model.StatusKCS == 1) continue;
                    model.ConfirmTK = 0;
                    model.StatusTK = 0;
                    MisMatchBO.Instance.Update(model);
                    count++;
                }
            }
            if (count > 0)
            {
                loadGrid();
            }
        }

        private void gửiMailBáoKhôngPhùHợpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string subject;
            string to;
            string content;
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load dữ liệu..."))
            {
                int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
                ModulesModel product = (ModulesModel)ModulesBO.Instance.FindByAttribute("Code", grvData.GetFocusedRowCellValue(colModuleCode).ToString())[0];
                string productCode = product.Code;
                string projectCode = TextUtils.ToString(grvData.GetFocusedRowCellValue(colProjectCode));
                List<string> listEmail = getListMail(productCode);

                subject = string.Format("INVALID REPORT - {0} - {1}", grvData.GetFocusedRowCellValue(colCode).ToString(), productCode);

                DataTable dtProjectUser = LibQLSX.Select("SELECT p.ProjectCode, u.UserName FROM Project p INNER JOIN Users u ON p.UserId = u.UserId where p.ProjectCode='" + projectCode + "'");
                string projectUser = dtProjectUser.Rows.Count > 0 ? TextUtils.ToString(dtProjectUser.Rows[0][1]) : "";

                DataTable dtConfig = TextUtils.Select("select KeyValue from [ConfigSystem] where [KeyName]='KPH_To_TK_Email'");
                content = dtConfig.Rows[0][0].ToString();
                content = content.Replace("<ErrorCode>", "<b>" + grvData.GetFocusedRowCellValue(colCode).ToString() + "</b>")
                    .Replace("<ProjectCode>", "<b>" + projectCode + "</b>")
                    .Replace("<ProjectUser>", "<b>" + projectUser == "" ? "Không tìm thấy" : projectUser + "</b>")
                    .Replace("<ProductCode>", "<b>" + productCode + "</b>")
                    .Replace("<ProductName>", product.Name)
                    .Replace("<UserFind>", grvData.GetFocusedRowCellValue(colUserFindText).ToString())
                    .Replace("<Description>", grvData.GetFocusedRowCellValue(colDes).ToString())
                    .Replace("<Ck>", NVCoKhi == "" ? "Không tìm thấy" : NVCoKhi)
                    .Replace("<Dn>", NVDien == "" ? "Không tìm thấy" : NVDien)
                    .Replace("<Dt>", NVDT == "" ? "Không tìm thấy" : NVDT);
                to = "";
                foreach (string item in listEmail)
                {
                    to += item.ToLower() + ";";
                }
            }
            frmSendEmailAttach frm = new frmSendEmailAttach();
            frm.Subject = subject;
            frm.CC = //"info@tpa.com.vn";
            "vt@tpa.com.vn;tk1@tpa.com.vn;tk2@tpa.com.vn;sxlr@tpa.com.vn;";
            frm.To = to;
            frm.Content = content;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                MisMatchModel errorModel = (MisMatchModel)MisMatchBO.Instance.FindByPK(TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID)));
                errorModel.ConfirmSendMailKCS = Global.AppFullName + " - " + Environment.MachineName + " đã gửi mail vào ngày: " + DateTime.Now;
                MisMatchBO.Instance.Update(errorModel);
                loadGrid();
            }
        }

        private void gửiMailKhiĐãKhắcPhụcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MisMatchModel misMatchModel = (MisMatchModel)MisMatchBO.Instance.FindByPK(TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID)));
                if (misMatchModel.StatusTK == 0)
                {
                    MessageBox.Show("Vấn đề này chưa được khắc phục!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                ModulesModel product = (ModulesModel)ModulesBO.Instance.FindByAttribute("Code",misMatchModel.ModuleCode)[0];

                frmSendEmailAttach frm = new frmSendEmailAttach();
                frm.To = "kcs@tpa.com.vn";
                frm.CC = //"info@tpa.com.vn";
                "vt@tpa.com.vn;tk1@tpa.com.vn;tk2@tpa.com.vn;sxlr@tpa.com.vn;";
                frm.Subject = string.Format("INVALID REPORT - {0} - {1} - Đã khắc phục", misMatchModel.Code, product.Code);
                DataTable dtConfig = TextUtils.Select("select KeyValue from [ConfigSystem] where [KeyName]='TK_To_KCS_KphEmail'");
                string content = dtConfig.Rows[0][0].ToString();
                frm.Content = content.Replace("<ErrorCode>", "<b>" + misMatchModel.Code + "</b>")
                    .Replace("<ProjectCode>", "<b>" + misMatchModel.ProjectCode + "</b>")
                    .Replace("<ProductCode>", "<b>" + product.Code + "</b>")
                    .Replace("<ProductName>", product.Name)
                    .Replace("<ErrorStatus>", "<b>Đã khắc phục</b>")
                    .Replace("<Description>", grvData.GetFocusedRowCellValue(colDes).ToString());                   
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    misMatchModel.ConfirmSendMailTK = Global.AppFullName + " - " + Environment.MachineName + " đã gửi mail vào ngày: " + DateTime.Now;
                    MisMatchBO.Instance.Update(misMatchModel);
                    loadGrid();

                    if (Global.DepartmentID == 1)//phong thiet ke
                    {
                        DataTable dt = TextUtils.Select("select * from ModuleVersion where MisMatchCode = '" + misMatchModel.Code + "'");
                        if (dt.Rows.Count == 0)
                        {
                            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát", "Đang tạo phiên bản thiết kế"))
                            {
                                try
                                {
                                    string path = TextUtils.DownloadAll(product.Code);

                                    ModuleVersionModel model = new ModuleVersionModel();
                                    model.ProjectCode = misMatchModel.ProjectCode;
                                    model.ModuleCode = product.Code;
                                    model.MisMatchCode = misMatchModel.Code;
                                    model.Version = TextUtils.ToInt(Path.GetFileName(path));
                                    model.Path = path;
                                    model.Description = frm.Description;
                                    model.Reason = "Sửa không phù hợp: " + misMatchModel.Code;
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

        private void btnKCS_XacNhan_Click(object sender, EventArgs e)
        {
            int count = 0;
            if (MessageBox.Show("Bạn có chắc muốn xác nhận những sự không phù hợp này đã được khắc phục?", TextUtils.Caption, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _rownIndex = grvData.FocusedRowHandle;

                foreach (int i in grvData.GetSelectedRows())
                {
                    if (i < 0) continue;
                    int iD = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                    MisMatchModel model = (MisMatchModel)MisMatchBO.Instance.FindByPK(iD);
                    if (model.StatusTK == 1)
                    {
                        model.StatusKCS = 1;
                        model.CompleteTime = TextUtils.GetSystemDate();
                        MisMatchBO.Instance.Update(model);
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                loadGrid();
            }
        }

        private void kCSBỏXácNhậnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = 0;
            if (MessageBox.Show("Bạn có chắc muốn bỏ xác nhận những sự không phù hợp này?", TextUtils.Caption, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _rownIndex = grvData.FocusedRowHandle;

                foreach (int i in grvData.GetSelectedRows())
                {
                    if (i < 0) continue;
                    int iD = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                    MisMatchModel model = (MisMatchModel)MisMatchBO.Instance.FindByPK(iD);
                    if (model.StatusKCS == 1)
                    {
                        model.StatusKCS = 0;
                        model.CompleteTime = null;
                        MisMatchBO.Instance.Update(model);
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                loadGrid();
            }
        }

        private void hủyXácNhậnTạmThờiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = 0;
            _rownIndex = grvData.FocusedRowHandle;

            foreach (int i in grvData.GetSelectedRows())
            {
                if (i < 0) continue;
                int iD = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                MisMatchModel model = (MisMatchModel)MisMatchBO.Instance.FindByPK(iD);
                if (model.ConfirmTemp == 1)
                {
                    model.ConfirmTemp = 0;
                    MisMatchBO.Instance.Update(model);
                    count++;
                }
            }
            if (count > 0)
            {
                loadGrid();
            }
        }

        private void btnConfirmTemp_Click(object sender, EventArgs e)
        {
            int count = 0;
            if (MessageBox.Show("Bạn có chắc muốn xác nhận tạm thời bỏ qua những sự không phù hợp này?", TextUtils.Caption, MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _rownIndex = grvData.FocusedRowHandle;

                foreach (int i in grvData.GetSelectedRows())
                {
                    if (i < 0) continue;
                    int iD = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                    MisMatchModel model = (MisMatchModel)MisMatchBO.Instance.FindByPK(iD);
                    if (model.ConfirmTemp == 0)
                    {
                        model.ConfirmTemp = 1;
                        MisMatchBO.Instance.Update(model);
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                loadGrid();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (grvData.FocusedRowHandle < 0) return;
            MisMatchModel model = (MisMatchModel)MisMatchBO.Instance.FindByPK(TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID)));
            if (model.ConfirmTK == 0)
            {
                MessageBox.Show("Thiết kế chưa xác nhận sự không phù hợp này là đúng!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            frmConfirmUser frm = new frmConfirmUser();
            frm.MisMatch = model;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _rownIndex = grvData.FocusedRowHandle;
                loadGrid();
            }
        }
       
        private void btnShowImage_Click(object sender, EventArgs e)
        {
            if (grvData.FocusedRowHandle < 0) return;
            MisMatchModel model = (MisMatchModel)MisMatchBO.Instance.FindByPK(TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID)));
            frmMisMatch frm = new frmMisMatch();
            frm.MisMatch = (MisMatchModel)MisMatchBO.Instance.FindByPK(TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID)));
            frm.OnlyShowImage = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _rownIndex = grvData.FocusedRowHandle;
                loadGrid();
            }
        } 
        #endregion
    }
}
