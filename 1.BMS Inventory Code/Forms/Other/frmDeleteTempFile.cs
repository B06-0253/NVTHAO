using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace BMS
{
    public partial class frmDeleteTempFile : _Forms
    {
        public frmDeleteTempFile()
        {
            InitializeComponent();
        }

        private void frmDeleteTempFile_Load(object sender, EventArgs e)
        {
            DeleteTmp();
        }
        private void DeleteTmp()
        {
            try
            {
                //Path.GetTempFileName();
                //"C:\\Users\\allensamuel\\AppData\\Local\\Temp\\tmpC1D0.tmp"
                //(The output file name ends with ".tmp".)

                string path = Path.GetTempPath();
                //"C:\\Users\\allensamuel\\AppData\\Local\\Temp\\"
                //(The output path ends with the backslash character, \\.)

                string str2 = ".rpt";
                if (path != string.Empty)
                {
                    int num = 0;
                    if (path.Substring(path.Length - 1, 1) != @"\")
                    {
                        path = path + @"\";
                    }
                    DirectoryInfo info = new DirectoryInfo(path);
                    if (info.Exists)
                    {
                        FileInfo[] files = info.GetFiles();
                        foreach (FileInfo info2 in files)
                        {
                            //if (info2.Extension == str2)
                            //{
                            string strFullFileName = path + info2.Name;
                            if (!this.FileIsLocked(strFullFileName))
                            {
                                num++;
                                info2.Delete();
                                this.Refresh();
                            }
                            //}
                        }
                    }
                    this.Refresh();
                    Thread.Sleep(500);
                    this.Close();
                }
                else
                {
                    this.Refresh();
                    Thread.Sleep(500);
                }
            }
            catch
            {

            }
        }
        public bool FileIsLocked(string strFullFileName)
        {
            bool flag = false;
            try
            {
                File.Open(strFullFileName, FileMode.Open, FileAccess.ReadWrite, FileShare.None).Close();
            }
            catch
            {
                flag = true;
            }
            return flag;
        }
    }
}
