using DevExpress.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace BMS
{
    public partial class frmTongHopChucNangKeToan : _Forms
    {
        public frmTongHopChucNangKeToan()
        {
            InitializeComponent();
        }

        private void frmTongHopChucNangKeToan_Load(object sender, EventArgs e)
        {

        }

        private void btnExportSalary_Click(object sender, EventArgs e)
        {
            string filePath = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
            }
            else
            {
                return;
            }
            DataTable dtItem = TextUtils.ExcelToDatatableNoHeader(filePath, "LUONG");
            DataTable dtCheck = TextUtils.ExcelToDatatableNoHeader(filePath, "CheckDTCP");
            DataRow[] drs = dtItem.Select("F2 like 'NV%' or F2 like 'M%'");
            if (drs.Length == 0) return;
            dtItem = drs.CopyToDataTable();

            string path = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path = fbd.SelectedPath;
            }
            else
            {
                return;
            }

            string filePathS = Application.StartupPath + "\\Templates\\PhongKeToan\\MauChungTu.xlsx";
            string currentPath = path + "\\ChungTu-LUONG.xlsx";

            try
            {
                File.Copy(filePathS, currentPath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi tạo bảng kê thanh toán chi tiết!" + Environment.NewLine + ex.Message,
                    TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            //List<string> listDuAn = new List<string>(new string[]{ "BAOHANH2016"
            //,"kl"
            //,"nghỉ lễ"
            //,"nghỉ lễ"
            //,"nghỉ phép"
            //,"nghỉ phép"
            //,"TEST.TK"
            //,"TPA"
            //,"TPA.1609"
            //,"TPM" });

            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo biểu mẫu..."))
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                Excel.Application app = default(Excel.Application);
                Excel.Workbook workBoook = default(Excel.Workbook);
                Excel.Worksheet workSheet = default(Excel.Worksheet);
                try
                {
                    app = new Excel.Application();
                    app.Workbooks.Open(currentPath);
                    workBoook = app.Workbooks[1];
                    workSheet = (Excel.Worksheet)workBoook.Worksheets[1];

                    for (int i = 0; i < dtItem.Rows.Count; i++)
                    {
                        if (i < 4) continue;

                        string maNhanVien = TextUtils.ToString(dtItem.Rows[i]["F2"]);
                        string maPhongBan = TextUtils.ToString(dtItem.Rows[i]["F4"]);
                        string phanXuong = TextUtils.ToString(dtItem.Rows[i]["F5"]);

                        for (int j = 0; j < dtItem.Columns.Count; j++)
                        {
                            if (j < 5) continue;

                            decimal tien = TextUtils.ToDecimal(dtItem.Rows[i][j]);
                            if (tien == 0) continue;

                            string projectCode = TextUtils.ToString(dtItem.Rows[0][j]);
                            string nganhHang = TextUtils.ToString(dtItem.Rows[1][j]);
                            string chiPhiCT = TextUtils.ToString(dtItem.Rows[2][j]);
                            string tkNo = TextUtils.ToString(dtItem.Rows[3][j]);

                            DataRow[] drsCheck = dtCheck.Select("F1 = '" + projectCode + "'");
                            if (drsCheck.Length > 0)
                                projectCode = phanXuong;

                            workSheet.Cells[8, 5] = maNhanVien;
                            workSheet.Cells[8, 6] = maNhanVien;
                            workSheet.Cells[8, 10] = tkNo;
                            workSheet.Cells[8, 16] = tien;//tien
                            workSheet.Cells[8, 19] = tien;//tien
                            workSheet.Cells[8, 20] = maPhongBan;
                            workSheet.Cells[8, 22] = projectCode;//du an
                            workSheet.Cells[8, 28] = phanXuong;
                            workSheet.Cells[8, 29] = nganhHang;
                            workSheet.Cells[8, 30] = chiPhiCT;

                            ((Excel.Range)workSheet.Rows[8]).Insert();
                        }
                    }

                    ((Excel.Range)workSheet.Rows[7]).Delete();
                    ((Excel.Range)workSheet.Rows[7]).Delete();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (app != null)
                    {
                        app.ActiveWorkbook.Save();
                        app.Workbooks.Close();
                        app.Quit();
                    }
                }
                Process.Start(currentPath);
            }
        }

        private void btnExportFormBank_Click(object sender, EventArgs e)
        {
            bool isTrongNuoc = true;
            DialogResult result = MessageBox.Show("Bạn muốn xuất các biểu mẫu loại trong nước?",TextUtils.Caption,MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                isTrongNuoc = true;
            }
            else if(result == DialogResult.No)
            {
                isTrongNuoc = false;
            }
            else
            {
                return;
            }

            string filePath = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
            }
            else
            {
                return;
            }

            DataTable dtItem = TextUtils.ExcelToDatatableNoHeader(filePath, "Sheet1");

            for (int i = 0; i < 3; i++)
            {
                dtItem.Rows.RemoveAt(0);
            }

            DataTable dtDistinctItem = TextUtils.GetDistinctDatatable(dtItem, "F4");

            string path = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path = fbd.SelectedPath;
            }
            else
            {
                return;
            }

            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo mẫu lệnh chi..."))
            {
                #region Mẫu lệnh chi
                for (int i = 0; i < dtDistinctItem.Rows.Count; i++)
                //for (int i = 0; i < 1; i++)
                {
                    string stt = TextUtils.ToString(dtDistinctItem.Rows[i]["F1"]);
                    if (stt == "") continue;
                    
                    string filePathS = Application.StartupPath + "\\Templates\\PhongKeToan\\NganHang\\Mau lenh chi.xls";
                    string currentPath = path + "\\Mau lenh chi-" + TextUtils.ToString(dtDistinctItem.Rows[i]["F2"]) + ".xls";

                    try
                    {
                        File.Copy(filePathS, currentPath, true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi khi tạo biểu mẫu lệnh chi!" + Environment.NewLine + ex.Message,
                            TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        continue;
                    }

                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                    Excel.Application app = default(Excel.Application);
                    Excel.Workbook workBoook = default(Excel.Workbook);
                    Excel.Worksheet workSheet = default(Excel.Worksheet);

                    try
                    {
                        app = new Excel.Application();
                        app.Workbooks.Open(currentPath);
                        workBoook = app.Workbooks[1];
                        workSheet = (Excel.Worksheet)workBoook.Worksheets[1];

                        string loaiTienTe = TextUtils.ToString(dtDistinctItem.Rows[i]["F13"]);
                        string percentThanhToan = TextUtils.ToString(dtDistinctItem.Rows[i]["F14"]);
                        string soTaiKhoan = TextUtils.ToString(dtDistinctItem.Rows[i]["F4"]);

                        string soHoaDonHopDong = "";
                        double tienNhanNo = 0;
                        DataRow[] drs = dtItem.Select("F4 = '" + soTaiKhoan + "'");
                        foreach (DataRow item in drs)
                        {
                            tienNhanNo += TextUtils.ToDouble(item["F9"]);
                            soHoaDonHopDong += TextUtils.ToString(item["F5"]) + ",";
                        }

                        workSheet.Cells[7, 1] = "                                                                                            Số No………Ngày Date ……/"
                            + string.Format("{0:00}", DateTime.Now.Month) + "/" + DateTime.Now.Year;
                        workSheet.Cells[12, 3] = TextUtils.ToString(dtDistinctItem.Rows[i]["F2"]);//Bên thụ hưởng
                        workSheet.Cells[15, 4] = TextUtils.ToString(dtDistinctItem.Rows[i]["F12"]);//địa chỉ bên thụ hưởng
                        if (isTrongNuoc)
                        {
                            workSheet.Cells[13, 3] = "'" + soTaiKhoan;
                            workSheet.Cells[16, 4] = tienNhanNo.ToString("n2") + " " + loaiTienTe;//Số tiền nhận nợ
                            workSheet.Cells[17, 4] = TextUtils.NumericToString(tienNhanNo, loaiTienTe);//tiền nhận nợ bẳng chữ
                        }

                        workSheet.Cells[21, 3] = "Công ty cp tự động hóa Tân phát thanh toán " + tienNhanNo + " " + (loaiTienTe == "" ? "VNĐ" : loaiTienTe)
                            + " tiền hợp đồng " + soHoaDonHopDong.Substring(0, soHoaDonHopDong.Length - 1);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        if (app != null)
                        {
                            app.ActiveWorkbook.Save();
                            app.Workbooks.Close();
                            app.Quit();
                        }
                    }
                }
                #endregion Mẫu lệnh chi
            }

            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo Giấy nhận nợ..."))
            {
                #region Giấy nhận nợ
                Word.Application word = new Word.Application();
                Word.Document doc = new Word.Document();
                try
                {
                    string localFilePath = "";
                    if (isTrongNuoc)
                    {
                        localFilePath = Application.StartupPath + "\\Templates\\PhongKeToan\\NganHang\\GiayNhanNo_VND.docx";
                    }
                    else
                    {
                        localFilePath = Application.StartupPath + "\\Templates\\PhongKeToan\\NganHang\\GiayNhanNo_USD.docx";
                    }

                    string currentFilePath = path + "\\GiayNhanNo-" + DateTime.Now.ToString("ddMMyyyy") + ".docx";
                    try
                    {
                        File.Copy(localFilePath, currentFilePath, true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi khi tạo biểu Giấy nhận nợ!" + Environment.NewLine + ex.Message,
                            TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    doc = word.Documents.Open(currentFilePath);
                    doc.Activate();

                    decimal tong1 = 0;
                    decimal tong2 = 0;

                    for (int i = 0; i < dtItem.Rows.Count; i++)
                    {
                        int stt = TextUtils.ToInt(dtItem.Rows[i]["F1"]);

                        decimal tienHoaDon = TextUtils.ToDecimal(dtItem.Rows[i]["F8"]);
                        decimal tienNhanNo = TextUtils.ToDecimal(dtItem.Rows[i]["F9"]);

                        string loaiTienTe = TextUtils.ToString(dtItem.Rows[i]["F13"]);

                        tong1 += tienHoaDon;
                        tong2 += tienNhanNo;

                        TextUtils.RepalaceText(doc, "<thuHuong" + stt + ">", TextUtils.ToString(dtItem.Rows[i]["F2"]));
                        TextUtils.RepalaceText(doc, "<nganHang" + stt + ">", TextUtils.ToString(dtItem.Rows[i]["F3"]));
                        TextUtils.RepalaceText(doc, "<soTaiKhoan" + stt + ">", TextUtils.ToString(dtItem.Rows[i]["F4"]));
                        TextUtils.RepalaceText(doc, "<soHoaDon" + stt + ">", TextUtils.ToString(dtItem.Rows[i]["F5"]));
                        //TextUtils.RepalaceText(doc, "<ngay" + stt + ">", TextUtils.ToDate3(dtItem.Rows[i]["F6"]).ToString("dd/MM/yyyy"));
                        TextUtils.RepalaceText(doc, "<ngay" + stt + ">", TextUtils.ToString(dtItem.Rows[i]["F6"]));
                        TextUtils.RepalaceText(doc, "<matHang" + stt + ">", TextUtils.ToString(dtItem.Rows[i]["F7"]));
                        TextUtils.RepalaceText(doc, "<tienHoaDon" + stt + ">", tienHoaDon.ToString("n2"));
                        TextUtils.RepalaceText(doc, "<tienNhanNo" + stt + ">", tienNhanNo.ToString("n2"));
                    }

                    TextUtils.RepalaceText(doc, "<tong1>", tong1.ToString("n2"));
                    TextUtils.RepalaceText(doc, "<tong2>", tong2.ToString("n2"));

                    TextUtils.RepalaceText(doc, "<bangchu>", TextUtils.NumericToString((double)tong2, isTrongNuoc ? "" : "USD"));

                    TextUtils.RepalaceText(doc, "<month>", string.Format("{0:00}", DateTime.Now.Month));
                    TextUtils.RepalaceText(doc, "<year>", DateTime.Now.Year.ToString());

                    doc.Save();
                    doc.Close();
                    word.Quit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Tân Phát", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    TextUtils.ReleaseComObject(doc);
                    TextUtils.ReleaseComObject(word);
                }
                #endregion Giấy nhận nợ
            }

            if (isTrongNuoc) return;
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo Hợp đồng ngoại tệ..."))
            {
                #region Hợp đồng ngoại tệ
                Word.Application word = new Word.Application();
                Word.Document doc = new Word.Document();
                try
                {
                    string localFilePath = Application.StartupPath + "\\Templates\\PhongKeToan\\NganHang\\HopDongMuaBanNgoaiTe.docx";

                    string currentFilePath = path + "\\HopDongMuaBanNgoaiTe-" + DateTime.Now.ToString("ddMMyyyy") + ".docx";
                    try
                    {
                        File.Copy(localFilePath, currentFilePath, true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi khi tạo biểu Hợp đồng mua bán ngoại tệ!" + Environment.NewLine + ex.Message,
                            TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    doc = word.Documents.Open(currentFilePath);
                    doc.Activate();

                    for (int i = 0; i < dtDistinctItem.Rows.Count; i++)
                    {
                        int f1 = TextUtils.ToInt(dtDistinctItem.Rows[i]["F1"]);
                        if (f1 == 0) continue;

                        int stt = f1; //i + 1;

                        string loaiTienTe = TextUtils.ToString(dtDistinctItem.Rows[i]["F13"]);
                        string soTaiKhoan = TextUtils.ToString(dtDistinctItem.Rows[i]["F4"]);

                        double tienNhanNo = 0;
                        string noiDung = "";
                        DataRow[] drs = dtItem.Select("F4 = '" + soTaiKhoan + "'");
                        if (drs.Length > 1)
                        {
                            foreach (DataRow item in drs)
                            {
                                tienNhanNo += TextUtils.ToDouble(item["F9"]);
                                string soHoaDonHopDong = TextUtils.ToString(item["F5"]);
                                string ngay = TextUtils.ToDate3(item["F6"]).ToString("dd/MM/yyyy");
                                string percentThanhToan = TextUtils.ToString(item["F14"]);
                                if (percentThanhToan != "")
                                {
                                    noiDung += "Thanh toán trả trước nốt " + percentThanhToan + "% hợp đồng số " + soHoaDonHopDong + " ngày " + ngay + Environment.NewLine;
                                }
                                else
                                {
                                    noiDung += "Thanh toán tiền hàng hợp đồng số " + soHoaDonHopDong + " ngày " + ngay + Environment.NewLine;
                                }
                            }
                        }
                        else
                        {
                            tienNhanNo = TextUtils.ToDouble(drs[0]["F9"]);
                            string soHoaDonHopDong = TextUtils.ToString(drs[0]["F5"]);
                            string ngay = TextUtils.ToDate3(drs[0]["F6"]).ToString("dd/MM/yyyy");
                            string percentThanhToan = TextUtils.ToString(drs[0]["F14"]);
                            if (percentThanhToan != "")
                            {
                                noiDung = "Thanh toán trả trước  nốt " + percentThanhToan + "% hợp đồng số " + soHoaDonHopDong + " ngày " + ngay;
                            }
                            else
                            {
                                noiDung = "Thanh toán tiền hàng  hợp đồng số " + soHoaDonHopDong + " ngày " + ngay;
                            }
                        }

                        int length = noiDung.Length;
                        if (length <= 200)
                        {
                            TextUtils.RepalaceText(doc, "<noiDung" + stt + ">", noiDung);
                        }                        

                        TextUtils.RepalaceText(doc, "<benThuHuong" + stt + ">", TextUtils.ToString(dtDistinctItem.Rows[i]["F2"]));
                        TextUtils.RepalaceText(doc, "<NganHang" + stt + ">", TextUtils.ToString(dtDistinctItem.Rows[i]["F3"]));
                        TextUtils.RepalaceText(doc, "<soTaiKhoan" + stt + ">", TextUtils.ToString(dtDistinctItem.Rows[i]["F4"]));                        
                        TextUtils.RepalaceText(doc, "<tienNhanNo" + stt + ">", tienNhanNo.ToString("n2"));
                        TextUtils.RepalaceText(doc, "<bangChu" + stt + ">", TextUtils.NumericToString(tienNhanNo, "USD"));
                        TextUtils.RepalaceText(doc, "<swiftCode" + stt + ">", TextUtils.ToString(dtDistinctItem.Rows[i]["F10"]));

                        TextUtils.RepalaceText(doc, "<diaChiNganHang" + stt + ">", TextUtils.ToString(dtDistinctItem.Rows[i]["F11"]));
                        TextUtils.RepalaceText(doc, "<diaChiBenThuHuong" + stt + ">", TextUtils.ToString(dtDistinctItem.Rows[i]["F12"]));
                    }

                    TextUtils.RepalaceText(doc, "<month>", string.Format("{0:00}", DateTime.Now.Month));
                    TextUtils.RepalaceText(doc, "<year>", DateTime.Now.Year.ToString());

                    doc.Save();
                    doc.Close();
                    word.Quit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Tân Phát", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    TextUtils.ReleaseComObject(doc);
                    TextUtils.ReleaseComObject(word);
                }
                #endregion Hợp đồng ngoại tệ
            }
        }
    }
}
