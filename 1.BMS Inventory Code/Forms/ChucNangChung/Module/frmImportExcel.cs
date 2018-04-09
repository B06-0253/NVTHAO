using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Xml;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;
using BMS.Model;
using BMS.Utils;
using BMS.Business;
using DevExpress.XtraGrid.Views.Grid;

namespace BMS
{
    public partial class frmImportExcel : _Forms
    {
        public frmImportExcel()
        {
            InitializeComponent();
        }

        DataTable ExcelToDatatable(string filename, string sheetName)
        {
            DataTable dt = new DataTable();
            string connString = "";
            connString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 12.0;", filename);
            OleDbConnection conn1 = new OleDbConnection();
            conn1.ConnectionString = connString;
            try
            {
                conn1.Open();
                OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM [" + sheetName + "$]", conn1);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];                
            }
            catch (Exception)
            {
            }
            finally
            {
                conn1.Close();
            }

            return dt;
        }

        private void btnBrowse_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog()==DialogResult.OK)
            {
                btnBrowse.Text = ofd.FileName;
                cboStatus.DataSource = null;
                cboStatus.DataSource = TextUtils.ListSheetInExcel(ofd.FileName);
            }
        }

        private void cboStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (btnBrowse.Text == "") return;
            grdData.DataSource = null;

            try
            {
                DataTable dt = ExcelToDatatable(btnBrowse.Text, cboStatus.SelectedValue.ToString());

                if (dt.Rows.Count <= 0) return;

                dt.Columns[0].ColumnName = "STT";
                dt.Columns[1].ColumnName = "Code";
                dt.Columns[2].ColumnName = "Name";
                dt.Columns[3].ColumnName = "Path";
                dt.Columns[4].ColumnName = "Note";
                dt.Columns[5].ColumnName = "Description";
                dt.Columns[6].ColumnName = "Status";
                dt.Columns[7].ColumnName = "Status1";
                dt.Rows.RemoveAt(0);

                //linq lấy các dòng mà code khác rỗng và khác null
                dt = (from order in dt.AsEnumerable()
                      where order.Field<string>("Code") != "" && order.Field<string>("Code") != null
                      select order).CopyToDataTable();
                grdData.DataSource = dt;
                grvData.BestFitColumns();
                grdData.Focus();
            }
            catch (Exception ex)
            {
                TextUtils.ShowError(ex);
            }           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (grvData.RowCount == 0) return;
            bool isSuccess = true;
            for (int i = 0; i < grvData.RowCount; i++)
            {
                string code = grvData.GetRowCellValue(i, colCode).ToString();
                if (code == "") continue;
                string moduleFilm = grvData.GetRowCellValue(i, colFilm).ToString();
                if (ModulesBO.Instance.CheckExist("Code", code))
                {
                    if (moduleFilm != "" && code.ToUpper().StartsWith("TPAD"))
                    {
                        string[] listFilm = moduleFilm.Replace("\n", ",").Split(',');
                        foreach (string item in listFilm)
                        {
                            if (ModuleFilmBO.Instance.CheckExist("Code", code)) continue;
                            ModuleFilmModel fModel = new ModuleFilmModel();
                            fModel.LastTimeChange = 0;
                            fModel.LastDateChange = DateTime.Now;
                            fModel.Code = item;
                            fModel.ModuleID = ((ModulesModel)ModulesBO.Instance.FindByAttribute("Code", code)[0]).ID;
                            fModel.CreatedDate = TextUtils.GetSystemDate();
                            fModel.CreatedBy = Global.AppUserName;
                            fModel.UpdatedDate = fModel.CreatedDate;
                            fModel.UpdatedBy = Global.AppUserName;
                            ModuleFilmBO.Instance.Insert(fModel);
                        }
                    }
                    continue;
                }

                ModulesModel model = new ModulesModel();
                model.Code = grvData.GetRowCellValue(i, colCode).ToString();
                model.Name = grvData.GetRowCellValue(i, colName).ToString();
                model.Path = ""; 
                model.Description = "";
                model.Note = grvData.GetRowCellValue(i, colNote).ToString();

                model.Status = TextUtils.ToInt(grvData.GetRowCellValue(i, colStatus1));
                model.FileElectric = 0;
                model.FileElectronic = 0;
                model.FileMechanics = 0;

                try
                {
                    ModuleGroupModel gmodel = new ModuleGroupModel();
                    if (code.ToUpper().StartsWith("TPAD"))
                    {
                        gmodel = (ModuleGroupModel)ModuleGroupBO.Instance.FindByAttribute("Code", code.Substring(0, 6))[0];
                    }
                    else if (code.ToUpper().StartsWith("PCB"))
                    {
                        gmodel = (ModuleGroupModel)ModuleGroupBO.Instance.FindByAttribute("Code", code.Substring(0, 5))[0];
                        model.FileElectronic = 1;
                        model.Status = 0;
                    }
                    else
                    {
                        MessageBox.Show("Nhóm module này chưa được khởi tạo.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        isSuccess = false;
                        break;
                    }

                    model.ModuleGroupID = gmodel.ID;
                }
                catch (Exception)
                {
                    MessageBox.Show("Nhóm module này chưa được khởi tạo.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isSuccess = false;
                    break;
                }

                model.CreatedDate = TextUtils.GetSystemDate();
                model.CreatedBy = Global.AppUserName;
                model.UpdatedDate = model.CreatedDate;
                model.UpdatedBy = Global.AppUserName;
                model.ID = (int)ModulesBO.Instance.Insert(model);

                if (moduleFilm != "" && code.ToUpper().StartsWith("TPAD"))
                {
                    string[] listFilm = moduleFilm.Replace("\n", ",").Split(',');
                    foreach (string item in listFilm)
                    {
                        ModuleFilmModel fModel = new ModuleFilmModel();
                        fModel.LastTimeChange = 0;
                        fModel.LastDateChange = DateTime.Now;
                        fModel.Code = item;
                        fModel.ModuleID = model.ID;
                        fModel.CreatedDate = TextUtils.GetSystemDate();
                        fModel.CreatedBy = Global.AppUserName;
                        fModel.UpdatedDate = fModel.CreatedDate;
                        fModel.UpdatedBy = Global.AppUserName;
                        ModuleFilmBO.Instance.Insert(fModel);
                    }
                }
                
            }
            if (isSuccess)
            {
                MessageBox.Show("Lưu trữ thành công", "Thông báo");
            }            
        }

        private void grvData_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            //if (e.RowHandle < 0) return;
            //GridView View = sender as GridView;
            //string code = View.GetRowCellValue(e.RowHandle, colCode).ToString();
            //if (ModulesBO.Instance.CheckExist("Code", code))
            //{
            //    e.Appearance.BackColor = Color.Yellow;
            //}
        }        

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBrowse_EditValueChanged(object sender, EventArgs e)
        {
            grdData.DataSource = null;
        }
    }
}
