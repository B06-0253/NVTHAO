using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using BMS.Business;
using BMS.Model;
using DevExpress.Utils;
using System.Diagnostics;

namespace BMS
{
    public partial class frmSolutionCTTM : _Forms
    {
        int _type;
        string _initPath;
        string _duongDanChinh;

        public frmSolutionCTTM()
        {
            InitializeComponent();
        }

        private bool validateForm()
        {
            string model = txtModel.Text.Trim().ToUpper();
            if (model == "")
            {
                MessageBox.Show("Xin hãy điền mã giải pháp.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
            {
                if (model.Length != 8 || !model.Contains("."))
                {
                    MessageBox.Show("Mã không đúng định dạng!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validateForm()) return;
                string productCode = txtModel.Text.ToUpper();
                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo cây thư mục..."))
                {
                    if (Directory.Exists(@"D:\"))
                    {
                        _initPath = "D:\\Thietke.Gp\\";
                        Directory.CreateDirectory(_initPath);
                    }
                    else
                    {
                        if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                        {
                            _initPath = folderBrowserDialog1.SelectedPath;
                        }
                        else
                            return;
                    }

                    ArrayList list = DesignStructureBO.Instance.FindByAttribute("Type", 3);

                    for (int i = 0; i < list.Count; i++)
                    {
                        DesignStructureModel model = (DesignStructureModel)list[i];
                        string directtion = "";
                        if (model.Path.Contains("code"))
                        {
                            directtion = (_initPath + @"\" + model.Path).Replace("code", productCode);
                        }
                        else
                            directtion = (_initPath + @"\" + model.Path);
                        if (i == 0)
                        {
                            _duongDanChinh = directtion;
                        }
                        Directory.CreateDirectory(directtion);
                    }
                }
                MessageBox.Show("Tạo cấu trúc thiết kế thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start(_duongDanChinh);
            }
            catch (System.Exception ex)
            {
                TextUtils.ShowError(ex);
            }
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            frmConfigDirectories frm = new frmConfigDirectories();
            frm.ComboIndex = 3;
            frm.ShowDialog();
        }
    }
}
