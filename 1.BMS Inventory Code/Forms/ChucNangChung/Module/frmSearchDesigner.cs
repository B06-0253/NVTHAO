using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using System.IO;
using DevExpress.Utils;
using iTextSharp.text.pdf;

namespace BMS
{
    public partial class frmSearchDesigner : _Forms
    {
        public string ProductCode;

        public frmSearchDesigner()
        {
            InitializeComponent();
        }      

        private void frmSearchModule_Load(object sender, EventArgs e)
        {
            this.Text = ProductCode;

            DocUtils.InitFTPQLSX();
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load dữ liệu..."))
            {
                try
                {
                    string fdfFileName = string.Format("Thietke.Dn\\{0}\\{1}.Dn\\PRD.{1}\\{1}.Dn.pdf", ProductCode.Substring(0, 6), ProductCode);
                    if (DocUtils.CheckExits(fdfFileName))
                    {
                        DocUtils.DownloadFile("D:/", Path.GetFileName(fdfFileName), fdfFileName);
                        PdfReader reader1 = new PdfReader("D:/" + Path.GetFileName(fdfFileName));
                        txtThietKeDien.Text = reader1.Info["Author"];
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
                            txtThietKeDien.Text = reader1.Info["Author"];
                            reader1.Close();
                            File.Delete("D:/" + Path.GetFileName(fdfFileName));
                        }
                    }
                }
                catch (Exception)
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
                        txtThietKeCoKhi.Text = dtDMVT.Rows[2]["F3"].ToString();

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

                                                txtThietKeDienTu.Text += code + " : " + dtDMVT_DT.Rows[2]["F3"].ToString() + Environment.NewLine;
                                            }
                                            catch (Exception)
                                            {
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
                }
                catch
                {
                }
            }
        }       
      
    }
}
