using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using System.IO;

namespace BMS
{
    public partial class rptCauTruc : DevExpress.XtraReports.UI.XtraReport
    {
        public List<string> Hang = new List<string>();
        public List<int> so = new List<int>();
        public string sModel, sPath,pathCAD;
        public rptCauTruc()
        {
           InitializeComponent();
        }
        private void rptCauTruc_BeforePrint(object sender,System.Drawing.Printing.PrintEventArgs e)
        {
           this.DisplayName="Báo cáo cấu trúc thiết thế "+sModel;
           xrTableCell2.Text = "hunugung\n hung";
           xrTableCell2.Multiline = true;
           xrTableCell2.WordWrap = true;
           xrTableCell46.Multiline=true;
           xrTableCell46.Text="";
           xrTableCell47.Text="";
           xrTableCell47.Multiline=true;
           try
           {
              #region Gon
              if(Hang.Count > 0)
              {
                 bool j = true;
                 string thongbao = "";
                 for(int i = 0;i < Hang.Count;i++)
                 {
                    xrTableCell46.Text+=Hang[i]+"\n";

                    pathCAD = sPath + "\\" + "3D." + sModel + "\\" + "COM." + sModel + "\\" + Hang[i];
                    if(!Directory.Exists(pathCAD))
                    {
                       xrTableCell47.Text="Không tồn tại thư mục hãng " + Hang[i] + "\n";

                       thongbao += ("Không tồn tại thư mục hãng " + Hang[i] + "\n");
                       j = false;
                    }
                    else
                       xrTableCell47.Text+="Tồn tại thư mục hãng " + Hang[i] + "\n";
                 }

                 //if (j == false)
                 //{
                 //    MessageBox.Show(thongbao, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 //    return;
                 //}
                 for(int i = 0;i < Hang.Count;i++)
                 {
                    pathCAD = sPath + "\\" + "3D." + sModel + "\\" + "COM." + sModel + "\\" + Hang[i];
                    int im = 0;
                    im = Directory.GetFiles(pathCAD,"*.ipt",SearchOption.TopDirectoryOnly).GetLength(0);
                    //if (im > so[i])
                    //{
                    //    thongba0 += "Số file lớn hơn yêu cầu trong thư mục " + Hang[i] + " là " + (im - so[i]) + " file\n";
                    //}
                    //if (im < so[i])
                    //{
                    //    thongba0 += "Số file ít hơn yêu cầu trong thư mục " + Hang[i] + " là " + (im - so[i]) + " file\n";
                    //}
                 }

              }
              #endregion

              xrTableCell15.Text = "3D." + sModel;
              if(Directory.Exists(sPath + "\\" + xrTableCell15.Text))
              {
                 xrTableCell16.Text = "Tồn tại";
              }
              else
                 xrTableCell41.Text = "Không tồn tại thư mục " + xrTableCell15.Text;
              xrTableCell17.Text = "CAD." + sModel;
              if(Directory.Exists(sPath + "\\" + xrTableCell17.Text))
              {
                 xrTableCell18.Text = "Tồn tại";
              }
              else
                 xrTableCell41.Text = "Không tồn tại thư mục " + xrTableCell17.Text;
              xrTableCell28.Text = "DAT." + sModel;
              if(Directory.Exists(sPath + "\\" + xrTableCell28.Text))
              {
                 xrTableCell29.Text = "Tồn tại";
              }
              else
                 xrTableCell41.Text = "Không tồn tại thư mục " + xrTableCell28.Text;
              xrTableCell31.Text = "DOC." + sModel;
              if(Directory.Exists(sPath + "\\" + xrTableCell31.Text))
              {
                 xrTableCell32.Text = "Tồn tại";
              }
              else
                 xrTableCell41.Text = "Không tồn tại thư mục " + xrTableCell31.Text;
              xrTableCell34.Text = "FIM." + sModel;
              if(Directory.Exists(sPath + "\\" + xrTableCell34.Text))
              {
                 xrTableCell35.Text = "Tồn tại";
              }
              else
                 xrTableCell41.Text = "Không tồn tại thư mục " + xrTableCell34.Text;
              xrTableCell37.Text = "IGS." + sModel;
              if(Directory.Exists(sPath + "\\" + xrTableCell37.Text))
              {
                 xrTableCell38.Text = "Tồn tại";
              }
              else
                 xrTableCell41.Text = "Không tồn tại thư mục " + xrTableCell37.Text;
              xrTableCell40.Text = "LRP." + sModel;
              if(Directory.Exists(sPath + "\\" + xrTableCell40.Text))
              {
                 xrTableCell41.Text = "Tồn tại";
              }
              else
                 xrTableCell41.Text = "Không tồn tại thư mục " + xrTableCell40.Text;
              xrTableCell43.Text = "MAT." + sModel;
              if(Directory.Exists(sPath + "\\" + xrTableCell43.Text))
              {
                 xrTableCell44.Text = "Tồn tại";
              }
              else
                 xrTableCell44.Text = "Không tồn tại thư mục " + xrTableCell43.Text;
           }
           catch(Exception ex)
           {
               throw;
           }
        }

    }
}
