using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DevExpress.Utils;

namespace BMS
{
    public partial class frmCreateIPT : _Forms
    {
        string _selectedPath;//đường dẫn đến thiết kế (D:\Thietke.Ck\TPAD.A\TPAD.A0001.Ck)
        string _moduleCode;
        DataTable _dtDMVT = new DataTable();

        public frmCreateIPT()
        {
            InitializeComponent();
        }

        private void frmHelp_Load(object sender, EventArgs e)
        {
            //webBrowser1.Url = new Uri(Application.StartupPath + @"\TIS\index.html");
            //webBrowser1.Navigate(Application.StartupPath + @"\TIS\index.html");
            //webBrowser1.Url = Application.StartupPath 
        }

        public DataTable GetFullDMVT(string filePath)
        {
            try
            {
                DataTable dt1 = TextUtils.ExcelToDatatableNoHeader(filePath.Trim(), "DMVT");
                DataTable dt = dt1.Copy();
                dt = dt.AsEnumerable()
                            .Where(row => TextUtils.ToInt(row.Field<string>("F1") == "" ||
                                row.Field<string>("F1") == null ? "0" : row.Field<string>("F1").Substring(0, 1)) > 0)
                            .CopyToDataTable();
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }
        
        private void btnGetDMVTchuan_Click(object sender, EventArgs e)
        {
            try
            {
                _dtDMVT = GetFullDMVT(txtDMVTPath.Text.Trim());
                grvDMVTchuan.DataSource = null;
                grvDMVTchuan.AutoGenerateColumns = false;
                grvDMVTchuan.DataSource = _dtDMVT;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        void creatIPT(DataRow[] drsDMVT)
        {
            foreach (DataRow row in drsDMVT)
            {
                
            }
        }

        private void btnCreateIPT_Click(object sender, EventArgs e)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo..."))
            {
                string tkPath = string.Format(@"D:\Thietke.Ck\{0}\{1}.Ck\3D.{1}\", _moduleCode.Substring(0, 6), _moduleCode);
                string templatePath = Application.StartupPath + "\\Templates\\";
                string cadPath = string.Format(@"D:\Thietke.Ck\{0}\{1}.Ck\CAD.{1}\", _moduleCode.Substring(0, 6), _moduleCode);
                string hangPath = string.Format(tkPath + @"\COM.{0}\", _moduleCode);

                foreach (DataRow row in _dtDMVT.Rows)
                {
                    string stt = TextUtils.ToString(row["F1"]);
                    string code = TextUtils.ToString(row["F4"]).Replace("/", ")");
                    string hang = TextUtils.ToString(row["F10"]);
                    string unit = TextUtils.ToString(row["F6"]);

                    Directory.CreateDirectory(hangPath + hang);
                    if (!code.StartsWith(_moduleCode))
                    {
                        if (unit == "BỘ")
                        {
                            File.Copy(templatePath + "demo.iam", hangPath + hang + "\\" + code + ".iam", true);
                        }
                        else
                        {
                            File.Copy(templatePath + "demo.ipt", hangPath + hang + "\\" + code + ".ipt", true);                            
                        }
                    }

                    //if (code.StartsWith("TPAD."))
                    //{
                        File.Copy(templatePath + "demo.dwg", cadPath + code + ".dwg", true);
                    //}

                    if (stt.Contains("."))
                    {
                        string[] array = stt.Split('.');
                        List<string> list = array.ToList();
                        list.RemoveAt(array.Length - 1);
                        string parent = string.Join(".", list.ToArray());

                        row["Pr"] = parent;
                    }
                    else
                    {
                        row["Pr"] = "";
                    }
                }

                //DataRow[] drsBO = _dtDMVT.Select("F6 = 'BỘ'");// and Parent = ''
                //DataTable dtBO = new DataTable();
                //if (drsBO.Length > 0)
                //{
                //    dtBO = drsBO.CopyToDataTable();
                //}

                foreach (DataRow row in _dtDMVT.Rows)
                {
                    string stt = TextUtils.ToString(row["F1"]);
                    string code = TextUtils.ToString(row["F4"]);
                    string parent = TextUtils.ToString(row["Pr"]);
                    string unit = TextUtils.ToString(row["F6"]);

                    if (unit == "BỘ" )
                    {
                        if (parent == "")
                        {
                            string pathBo = tkPath + code;

                            row["Path"] = pathBo;
                            Directory.CreateDirectory(pathBo);
                            File.Copy(templatePath + "demo.iam", pathBo + "\\" + code + ".iam", true);

                            createCT(stt, pathBo, templatePath);
                        }
                    }
                    else
                    {
                        if (code.StartsWith(_moduleCode))
                        {
                            if (parent == "")
                            {
                                File.Copy(templatePath + "demo.ipt", tkPath + "\\" + code + ".ipt", true);
                            }
                            else
                            {
                                DataRow[] drs = _dtDMVT.Select("F1 = '" + parent + "'");
                                string path = TextUtils.ToString(drs[0]["Path"]);
                                File.Copy(templatePath + "demo.ipt", path + "\\" + code + ".ipt", true);
                            }
                        }                       
                    }
                }
            }
            MessageBox.Show("Xuất file thành công!");
        }

        void createCT(string stt, string pathParent, string templatePath)
        {
            DataRow[] drs = _dtDMVT.Select("Pr = '" + stt + "' and F6 = 'BỘ' and F4 like '" + _moduleCode + "%'");
            foreach (DataRow item in drs)
            {
                string stt1 = TextUtils.ToString(item["F1"]);
                string code = TextUtils.ToString(item["F4"]);
                string path = pathParent + "\\" + code;
                item["Path"] = path;

                Directory.CreateDirectory(path);
                File.Copy(templatePath + "demo.iam", path + "\\" + code + ".iam", true);

                createCT(stt1, path, templatePath);
            }
        }       

        private void btnChooseMat_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                _selectedPath = fbd.SelectedPath;
                _moduleCode = Path.GetFileNameWithoutExtension(_selectedPath);
                txtCode.Text = _moduleCode;
                txtDMVTPath.Text = _selectedPath + "\\" + "VT." + _moduleCode + ".xlsm";

                try
                {
                    _dtDMVT = GetFullDMVT(txtDMVTPath.Text.Trim());

                    _dtDMVT.Columns.Add("Pr");
                    _dtDMVT.Columns.Add("Path");

                    grvDMVTchuan.DataSource = null;
                    grvDMVTchuan.AutoGenerateColumns = false;
                    grvDMVTchuan.DataSource = _dtDMVT;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}