using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BMS.Model;
using BMS.Business;

namespace BMS
{
    public partial class frmShowHistory : _Forms
    {
        public int ID = 0;
        public string Code = "";
        int _type = 0;
        string _hu = "";
        //public bool IsDownload = false;
        public frmShowHistory(int type)
        {
            InitializeComponent();
            _type = type;
        }
        /// <summary>
        /// frmModuleFilmHistory_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmModuleFilmHistory_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            //lịch sử in film
            if (_type == 1)
            {
                dt = TextUtils.Select("SELECT *,Case when Action ='I' then N'Thêm mới' else N'Sửa đổi' end ActionText FROM ActivityLog with(nolock) where TableName='ModuleFilm' and KeyID=" + ID);
                this.Text = "Lịch sử mã in film: " + Code;
                colLink.Visible = false;
            }

            //lịch sử model-module
            if (_type == 2)
            {
                dt = TextUtils.Select("SELECT *,Case when Action ='I' then N'Thêm mới' else N'Sửa đổi' end ActionText FROM ActivityLog with(nolock) where TableName='Modules' and KeyID=" + ID);
                this.Text = "Lịch sử module: " + Code;
                colLink.Visible = false;
            }

            //lịch sử file
            if (_type == 3)
            {
                dt = TextUtils.Select("SELECT *,Case when Action ='I' then N'Thêm mới' else N'Sửa đổi' end ActionText FROM ActivityLog with(nolock) where TableName='File3D' and KeyID=" + ID);
                this.Text = "Lịch sử file: " + Code;
            }

            grdData.DataSource = null;
            grdData.DataSource = dt;
        }

        private void repositoryItemHyperLinkEdit1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string action = grvData.GetFocusedRowCellValue(colAction).ToString();
                string path = "";

                File3DModel model = (File3DModel)File3DBO.Instance.FindByPK(ID);
                DateTime date = TextUtils.ToDate(grvData.GetFocusedRowCellValue(colDate).ToString());

                if (action == "Thêm mới")
                {
                    path = model.Path;
                }
                else
                {
                    path = model.Path.Replace(model.Name, date.ToString("dd-MM-yyyy") + @"\" + model.Name).Trim();
                }

                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.Description = "Chọn nơi lưu trữ";
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    _hu = fbd.SelectedPath + @"\" + Path.GetFileName(path);
                    File.Copy(path, _hu, true);
                    MessageBox.Show("Tải file xuống thành công!");
                }
            }
            catch (Exception ex)
            {
                TextUtils.ShowError(ex);
            }           
        }

    }
}
