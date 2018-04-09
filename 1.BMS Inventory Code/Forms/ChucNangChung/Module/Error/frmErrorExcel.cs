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
using BMS.Utils;
using BMS.Business;
using System.Collections;

namespace BMS
{
    public partial class frmErrorExcel : _Forms
    {
        DataTable dt = new DataTable();
        public frmErrorExcel()
        {
            InitializeComponent();
        }

        private void btnBrowse_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Lấy dữ liệu trong file excel!"))
                {
                    btnBrowse.Text = ofd.FileName;
                    //dt = TextUtils.ExcelToDatatable(btnBrowse.Text, "Sheet1"); 
                    dt = TextUtils.ExcelToDatatable(btnBrowse.Text, "THONGKELOI");
                    grdData.DataSource = dt;
                }
            }
        }

        private void btnTrucQuan_Click(object sender, EventArgs e)
        {
            DataTable dtTrucQuan = TextUtils.GetDistinctDatatable(dt, "F131");
            dtTrucQuan.Rows.RemoveAt(0);
            dtTrucQuan.Rows.RemoveAt(0);
            foreach (DataRow r in dtTrucQuan.Rows)
            {               
                ModuleErrorTypeModel model = new ModuleErrorTypeModel();
                model.Name = r["F131"].ToString();
                model.Type = 0;
                ModuleErrorTypeBO.Instance.Insert(model);
            }            
        }

        private void btnNN_Click(object sender, EventArgs e)
        {
            DataTable dtNN = TextUtils.GetDistinctDatatable(dt, "F141");
            dtNN.Rows.RemoveAt(0);
            dtNN.Rows.RemoveAt(0);
            foreach (DataRow r in dtNN.Rows)
            {
                ModuleErrorTypeModel model = new ModuleErrorTypeModel();
                model.Name = r["F141"].ToString();
                model.Type = 1;
                ModuleErrorTypeBO.Instance.Insert(model);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < grvData.RowCount; i++)
            {                
                try
                {
                    if (grvData.GetRowCellValue(i, "1") == null) continue;
                    string code = grvData.GetRowCellValue(i, "1").ToString();
                    if (code == "") continue;

                    DepartmentModel department = null;
                    DepartmentModel departmentKP = null;
                    UsersModel userFind = null;
                    try
                    {
                        department = (DepartmentModel)DepartmentBO.Instance.FindByAttribute("Code", grvData.GetRowCellValue(i, "7").ToString())[0];
                    }
                    catch { }
                    try
                    {
                        departmentKP = (DepartmentModel)DepartmentBO.Instance.FindByAttribute("Code", grvData.GetRowCellValue(i, "10").ToString())[0];
                    }
                    catch { }
                    try
                    {
                        userFind = (UsersModel)UsersBO.Instance.FindByAttribute("LoginName", grvData.GetRowCellValue(i, "16").ToString())[0];
                    }
                    catch { }

                    ModulesModel module = null;
                    string moduleCode = "";                   
                    try
                    {
                        moduleCode = grvData.GetRowCellValue(i, "5").ToString();
                        module = (ModulesModel)ModulesBO.Instance.FindByAttribute("Code", grvData.GetRowCellValue(i, "5").ToString().Substring(0, 10))[0];
                    }
                    catch { }

                    ModuleErrorModel error;
                    if (!ModuleErrorBO.Instance.CheckExist("Code", code))
                    {
                        error = new ModuleErrorModel();
                    }
                    else
                    {
                        error = (ModuleErrorModel)ModuleErrorBO.Instance.FindByAttribute("Code", code)[0];
                    }
                    
                    //error.Description = moduleCode.Length == 10 ? grvData.GetRowCellValue(i, "6").ToString() : moduleCode + ": " 
                    //    + grvData.GetRowCellValue(i, "6").ToString();
                    //error.HuongKhacPhucTamThoi = grvData.GetRowCellValue(i, "9").ToString();                    
                    //error.Status = grvData.GetRowCellValue(i, "12").ToString().Trim().ToLower() == "ok" ? 1 : 0;
                    //error.StatusTK = grvData.GetRowCellValue(i, "12").ToString().Trim().ToLower() == "ok" ? 1 : 0;                   
                    //error.DepartmentID = department == null ? 0 : department.ID;
                    //error.DepartmentKPID = departmentKP == null ? 0 : departmentKP.ID;
                    //error.Reason = grvData.GetRowCellValue(i, "8") == null ? "" : grvData.GetRowCellValue(i, "8").ToString();                    
                    //error.UserFindID = userFind == null ? 0 : userFind.ID;
                    //error.CreatedBy = "thao.nv";

                    error.UpdatedDate = TextUtils.ToDate(grvData.GetRowCellValue(i, "2").ToString());
                    error.CreatedDate = TextUtils.ToDate(grvData.GetRowCellValue(i, "2").ToString());
                    error.CompleteTimeTK = TextUtils.ToDate(grvData.GetRowCellValue(i, "11").ToString());

                    if (error.ID == 0)
                    {
                        error.Code = code;
                        error.ModuleID = module == null ? 0 : module.ID;
                        ModuleErrorBO.Instance.Insert(error);
                    }
                    else
                    {
                        ModuleErrorBO.Instance.Update(error);
                    }
                }
                catch (Exception)
                {
                }                
            }
            MessageBox.Show("Thêm lỗi thành công!");
        }

        private void btnSave_Click1(object sender, EventArgs e)
        {
            dt.Rows.RemoveAt(0);
            dt.Rows.RemoveAt(0);
            foreach (DataRow r in dt.Rows)
            {
                int moduleID = 0;
                try
                {
                    ArrayList listModule = ModulesBO.Instance.FindByAttribute("Code", r["F5"].ToString().Trim());
                    moduleID = ((ModulesModel)listModule[0]).ID;
                }
                catch (Exception)
                {

                }
                if (moduleID == 0) continue;

                int userID = 0;
                try
                {
                    ArrayList listUser = UsersBO.Instance.FindByAttribute("LoginName", r["F81"].ToString().Trim());
                    userID = ((UsersModel)listUser[0]).ID;
                }
                catch (Exception)
                {

                }

                int tq = 0;
                try
                {
                    ArrayList listType = ModuleErrorTypeBO.Instance.FindByAttribute("Name", r["F131"].ToString().Trim());
                    tq = ((ModuleErrorTypeModel)listType[0]).ID;
                }
                catch (Exception)
                {

                }

                int nn = 0;
                try
                {
                    ArrayList listType = ModuleErrorTypeBO.Instance.FindByAttribute("Name", r["F141"].ToString().Trim());
                    nn = ((ModuleErrorTypeModel)listType[0]).ID;
                }
                catch (Exception)
                {
                }

                ModuleErrorModel error = new ModuleErrorModel();
                error.Code = r["F1"].ToString().Trim();
                error.Author = r["F81"].ToString().Trim().Replace(" ", "");
                error.Description = r["F6"].ToString().Trim();
                error.HuongKhacPhuc = r["F151"].ToString().Trim();
                error.ModuleID = moduleID;
                error.PLLTQ = tq;
                error.PLLCP = 0;
                error.PLLNN = nn;
                error.Status = r["F111"].ToString().Trim().ToLower() == "ok" ? 1 : 0;
                error.UserID = userID;
                ModuleErrorBO.Instance.Insert(error);
            }
            MessageBox.Show("Thêm lỗi thành công!");
        }

    }
}
