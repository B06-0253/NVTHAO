using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPA.Business;
using TPA.Model;
using TPA.Utils;
using System.IO;
using DevExpress.Utils;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Collections;
using Forms.Properties;
using DevExpress.XtraGrid.Views.Grid;

namespace BMS
{
    public partial class frmListOrder : _Forms
    {
        DataTable _dtFile = new DataTable();
        bool _isSaved = false;
        int _rowIndex = 0;

        public frmListOrder()
        {
            InitializeComponent();
        }

        private void frmCreatePO_Load(object sender, EventArgs e)
        {
            loadOrder();
            //loadOrderFile();
            //loadInvoice();
            loadProject();
        }

        void loadOrder()
        {
            DataTable dt = LibQLSX.Select("Select *,Balance = (TotalPrice + TotalPrice*VAT/100 - TotalInvoice)" +
                ",TienThanhToan = ((TotalPrice + DeliveryCost + DiffCost) + (TotalPrice + DeliveryCost + DiffCost) * VAT / 100)" +
                ",CASE WHEN TotalTransfer >= TotalPrice THEN N'Đã thanh toán' WHEN StatusTT = 1 THEN N'Yêu cầu thành toán' WHEN StatusTT = 2 THEN N'Đã có trên bảng kê' ELSE '' END as StatusText "+
                ",Stuff((SELECT distinct N', ' + [ProjectCode] FROM [vGetProjectWithOrder] where [OrderCode] = a.OrderCode FOR XML PATH(''),TYPE).value('text()[1]','nvarchar(max)'),1,2,N'') as Project" +
            " from vOrder a with(nolock)");
            grdOrder.DataSource = dt;
            if (_rowIndex >= grvOrder.RowCount)
                _rowIndex = 0;
            if (_rowIndex > 0)
                grvOrder.FocusedRowHandle = _rowIndex;
            grvOrder.SelectRow(_rowIndex);
        }

        void loadInvoice()
        {
            string orderId = TextUtils.ToString(grvOrder.GetFocusedRowCellValue(colOrderId));
            DataTable dt = LibQLSX.Select("Select * from OrderInvoice with(nolock) where OrderId = '" + orderId + "'");
            grdHD.DataSource = dt;
        }

        void loadDNNK()
        {
            string orderCode = TextUtils.ToString(grvOrder.GetFocusedRowCellValue(colSoDonHang));
            DataTable dt = LibQLSX.Select("select [ImportCode],Sum(TotalOK*Price) as TotalPrice" +
                                    " FROM [vImportMaterial]" +
                                    " where [OrderCode]= '" + orderCode + "'" +
                                    " group by [ImportCode]");
            grdDNNK.DataSource = dt;
        }

        string getYCMVT(string orderCode)
        {
            //string ycmvtCode = "";
            List<string> listYCMVT = new List<string>();
            DataTable dt = LibQLSX.Select("Select Distinct ProposalCode from vGetYCMVTwithOrder with(nolock) where OrderCode = '" + orderCode + "'");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    //ycmvtCode += TextUtils.ToString(r[0]) + ",";
                    if (!listYCMVT.Contains(TextUtils.ToString(r[0])))
                    {
                        listYCMVT.Add(TextUtils.ToString(r[0]));
                    }
                }
            }
            //return ycmvtCode;
            return string.Join(", ", listYCMVT.ToArray());
        }
        
        void loadOrderFile()
        {
            string orderId = TextUtils.ToString(grvOrder.GetFocusedRowCellValue(colOrderId));
            _dtFile = LibQLSX.Select("Select * from OrdersFile with(nolock) where OrderId = '" + orderId + "'");
            grdFile.DataSource = _dtFile;
        }

        void loadProject()
        {
            DataTable dt = LibQLSX.Select("SELECT  * from Project with(nolock)");
            cboProject.Properties.DataSource = dt;
            cboProject.Properties.DisplayMember = "ProjectCode";
            cboProject.Properties.ValueMember = "ProjectId";
        }

        private void SetInterface(bool isEdit)
        {
            btnSave.Visible = isEdit;
            btnCancel.Visible = isEdit;

            btnNew.Visible = !isEdit;
            //btnEdit.Visible = !isEdit;
            btnDelete.Visible = !isEdit;
        }

        DataTable loadPartOfOrder(string orderCode)
        {
            string[] paraName = new string[1];
            object[] paraValue = new object[1];
            paraName[0] = "@OrderCode"; paraValue[0] = orderCode;
            DataTable Source = SuppliersBO.Instance.LoadDataFromSP("spGetPartWithOrder", "Source", paraName, paraValue);
            DataTable dt = Source.Copy();
            dt.Rows.Clear();
            foreach (DataRow row in Source.Rows)
            {
                string code = TextUtils.ToString(row["PartsCode"]);
                decimal price = TextUtils.ToDecimal(row["Price"]);
                decimal qty = TextUtils.ToDecimal(row["TotalBuy"]);
                string projectCode = TextUtils.ToString(row["ProjectCode"]);

                DataRow[] drs = dt.Select("PartsCode = '" + code + "' and Price = " + price);
                if (drs.Length == 0)
                {
                    dt.ImportRow(row);
                }
                else
                {
                    drs[0]["TotalBuy"] = TextUtils.ToDecimal(drs[0]["TotalBuy"]) + qty;
                    drs[0]["TotalPrice"] = TextUtils.ToDecimal(drs[0]["TotalBuy"]) * TextUtils.ToDecimal(drs[0]["Price"]);
                    if (TextUtils.ToString(drs[0]["ProjectCode"]) != projectCode)
                    {
                        drs[0]["ProjectCode"] = TextUtils.ToString(drs[0]["ProjectCode"]) + ", " + projectCode;
                    }                    
                }
            }
            return dt;
        }

        void main_LoadDataChange(object sender, EventArgs e)
        {
            loadOrder();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string orderCode = TextUtils.ToString(grvOrder.GetFocusedRowCellValue(colSoDonHang));
            if (orderCode == "") return;

            string orderid = TextUtils.ToString(grvOrder.GetFocusedRowCellValue(colOrderId));
            if (orderid == "") return;
            
            if (Global.DepartmentID == 6)
            {
                DataTable dt1 = LibQLSX.Select("select top 1 OrderId from Orders where (VAT is null or VAT < 0) and OrderCode = '" + orderCode + "'");
                if (dt1.Rows.Count > 0)
                {
                    MessageBox.Show("Bạn hãy điền VAT cho PO.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }

            ArrayList listOrder = OrdersBO.Instance.FindByAttribute("OrderId", orderid);
            OrdersModel order = (OrdersModel)listOrder[0];

            //if (order.VAT < 0)
            //{
            //    MessageBox.Show("Bạn hãy hoàn thành các thông tin cần thiết của PO", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}

            string localPath = "";

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = Settings.Default.POPath;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                localPath = fbd.SelectedPath + "\\" + orderCode + ".xlsx";
                Settings.Default.CheckCMPath = localPath;
                Settings.Default.Save();
            }
            else
            {
                return;
            }

            string filePath = Application.StartupPath + "\\Templates\\PO.xlsx";

            try
            {
                File.Copy(filePath, localPath, true);
            }
            catch
            {
                MessageBox.Show("Lỗi: File excel đang được mở.");
                return;
            }

            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo biểu mẫu..."))
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                Excel.Application app = default(Excel.Application);
                Excel.Workbook workBoook = default(Excel.Workbook);
                Excel.Worksheet workSheet = default(Excel.Worksheet);
                try
                {
                    app = new Excel.Application();
                    app.Workbooks.Open(localPath);
                    workBoook = app.Workbooks[1];
                    workSheet = (Excel.Worksheet)workBoook.Worksheets[1];

                    workSheet.Cells[8, 1] = TextUtils.ToString(grvOrder.GetFocusedRowCellDisplayText(colDateCreated));
                    //workSheet.Cells[8, 3] = DateTime.Now.ToString("dd/MM/yyyy");
                    workSheet.Cells[8, 7] = orderCode+"/"+TextUtils.ToString(grvOrder.GetFocusedRowCellValue(colAccount));

                    //string[] yc = getYCMVT(orderCode).Split(',');
                    //workSheet.Cells[8, 8] = yc[0];
                    workSheet.Cells[9, 1] = "No/Số YCMVT: " + getYCMVT(orderCode);

                    workSheet.Cells[10, 3] = TextUtils.ToString(grvOrder.GetFocusedRowCellValue(colSupplierName));
                    workSheet.Cells[11, 3] = TextUtils.ToString(grvOrder.GetFocusedRowCellValue(colSupplierCode));
                    workSheet.Cells[12, 3] = TextUtils.ToString(grvOrder.GetFocusedRowCellValue(colSupplierAddress));
                    workSheet.Cells[13, 3] = TextUtils.ToString(grvOrder.GetFocusedRowCellValue(colContactPerson));
                    workSheet.Cells[14, 3] = TextUtils.ToString(grvOrder.GetFocusedRowCellValue(colOrderNumber)).ToUpper();

                    string delivery = TextUtils.ToString(grvOrder.GetFocusedRowCellValue(colDeliveryCost));
                    string diff = TextUtils.ToString(grvOrder.GetFocusedRowCellValue(colDiffCost));
                    workSheet.Cells[21, 8] = delivery == "" ? "0" : delivery;
                    workSheet.Cells[24, 8] = diff == "" ? "0" : diff;

                    workSheet.Cells[31, 4] = TextUtils.ToString(grvOrder.GetFocusedRowCellValue(colTermsPaid));
                    workSheet.Cells[32, 4] = TextUtils.ToString(grvOrder.GetFocusedRowCellValue(colBankAccount)) + " - "
                        + TextUtils.ToString(grvOrder.GetFocusedRowCellValue(colBankName));

                    decimal vat = TextUtils.ToInt(grvOrder.GetFocusedRowCellValue(colVAT));
                    workSheet.Cells[26, 1] = "Tax/VAT (" + vat.ToString("n0") + "%)";
                    ((Excel.Range)workSheet.Cells[26, 8]).Formula = "=+H25*" + TextUtils.ToDecimal(vat / 100);

                    DataTable dtListPart = loadPartOfOrder(orderCode);
                    for (int i = dtListPart.Rows.Count - 1; i >= 0; i--)
                    {
                        workSheet.Cells[20, 1] = i + 1;
                        workSheet.Cells[20, 2] = TextUtils.ToString(dtListPart.Rows[i]["PartsName"]);
                        workSheet.Cells[20, 3] = TextUtils.ToString(dtListPart.Rows[i]["PartsCode"]);
                        workSheet.Cells[20, 4] = TextUtils.ToString(dtListPart.Rows[i]["ManufacturerCode"]);
                        workSheet.Cells[20, 5] = TextUtils.ToString(dtListPart.Rows[i]["Unit"]);
                        workSheet.Cells[20, 6] = TextUtils.ToDecimal(dtListPart.Rows[i]["TotalBuy"]).ToString("n2");
                        workSheet.Cells[20, 7] = TextUtils.ToDecimal(dtListPart.Rows[i]["Price"]).ToString("n2");
                        workSheet.Cells[20, 8] = TextUtils.ToDecimal(dtListPart.Rows[i]["TotalPrice"]).ToString("n2");
                        workSheet.Cells[20, 9] = TextUtils.ToDecimal(dtListPart.Rows[i]["DeliveryTime"]).ToString("n2");
                        workSheet.Cells[20, 10] = TextUtils.ToString(dtListPart.Rows[i]["ProjectCode"]);

                        ((Excel.Range)workSheet.Rows[20]).Insert();
                    }

                    ((Excel.Range)workSheet.Rows[19]).Delete();
                    ((Excel.Range)workSheet.Rows[19]).Delete();
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

            if (File.Exists(localPath))
            {
                if (Global.DepartmentID == 6)
                {
                    DialogResult result = MessageBox.Show("Tạo PO thành công!\nBạn có chắc muốn gửi mail đến nhà cung cấp?", TextUtils.Caption,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        string email = TextUtils.ToString(grvOrder.GetFocusedRowCellValue(colSupplierMail));
                        string person = TextUtils.ToString(grvOrder.GetFocusedRowCellValue(colContactPerson));
                        string subject = "Xác nhận đơn hàng";
                        string content = "Dear Anh/chị,<br>Tôi gửi xác nhận đơn hàng trên file đính kèm.<br>Thanks!";
                        if (email == "")
                        {
                            MessageBox.Show("Nhà cung cấp không tồn tại email!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        List<string> at = new List<string>();
                        at.Add(localPath);
                        bool success = TextUtils.SetEmailSendHasAttach(subject, content, email, "", at);
                        if (success)
                        {
                            //ArrayList arr = OrdersBO.Instance.FindByAttribute("OrderCode", orderCode);
                            //OrdersModel order = (OrdersModel)arr[0];
                            order.IsSent = true;
                            OrdersBO.Instance.UpdateQLSX(order);

                            ArrayList arr1 = SuppliersBO.Instance.FindByAttribute("SupplierId", order.SupplierId);
                            SuppliersModel supplier = (SuppliersModel)arr1[0];
                            supplier.Email = email;
                            SuppliersBO.Instance.UpdateQLSX(supplier);

                            loadOrder();
                            MessageBox.Show("Đã gửi mail thành công!", TextUtils.Caption);
                        }
                        else
                        {
                            MessageBox.Show("Gửi không thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        Process.Start(localPath);
                    }
                }
                else
                {
                    Process.Start(localPath);
                }
            }
        }

        private void grvOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == (Keys.C))
            {
                try
                {
                    string text = TextUtils.ToString(grvOrder.GetFocusedRowCellValue(grvOrder.FocusedColumn));
                    Clipboard.SetText(text);
                }
                catch (Exception)
                {
                }
            }
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            string orderId = TextUtils.ToString(grvOrder.GetFocusedRowCellValue(colOrderId));
            string orderCode = TextUtils.ToString(grvOrder.GetFocusedRowCellValue(colSoDonHang));

            if (orderCode == "" || orderId == "") return;

            DocUtils.InitFTPTK();

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (string filePath in ofd.FileNames)
                {
                    FileInfo fInfo = new FileInfo(filePath);
                    //if (Path.GetFileNameWithoutExtension(fInfo.FullName).ToUpper() != orderCode.ToUpper()) continue;
                    //DataTable dt = TextUtils.Select("select * from OrdersFile with(nolock) where FileName = '" + fInfo.Name + "'");
                    //if (dt.Rows.Count > 0) continue;

                    ProcessTransaction pt = new ProcessTransaction();
                    pt.OpenConnection();
                    pt.BeginTransaction();

                    try
                    {
                        OrdersFileModel model = new OrdersFileModel();
                        model.OrderId = orderId;
                        model.FileName = fInfo.Name;
                        model.FileLocalPath = fInfo.FullName;
                        model.FilePath = "PO\\" + orderCode + "\\" + fInfo.Name;
                        model.Size = fInfo.Length;
                        model.DateCreated = TextUtils.GetSystemDate();
                        pt.Insert(model);
                        if (!DocUtils.CheckExits("PO\\" + orderCode))
                        {
                            DocUtils.MakeDir("PO\\" + orderCode);
                        }
                        bool status = DocUtils.UploadFileWithStatus(model.FileLocalPath, "PO\\" + orderCode);
                        if (status)
                            pt.CommitTransaction();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        pt.CloseConnection();
                    }

                    loadOrderFile();
                }
            }
        }

        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            if (grvFile.SelectedRowsCount > 0)
            {
                int id = TextUtils.ToInt(grvFile.GetFocusedRowCellValue(colFileID));
                string ftpFilePath = TextUtils.ToString(grvFile.GetFocusedRowCellValue(colFilePath));
                if (id == 0) return;
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa file này?", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DocUtils.InitFTPTK();
                    OrdersFileBO.Instance.Delete(id);
                    if (DocUtils.CheckExits(ftpFilePath))
                    {
                        DocUtils.DeleteFile(ftpFilePath);
                    }
                    grvFile.DeleteSelectedRows();
                }
            }
        }        

        private void grvOrder_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //loadOrderFile();
            loadInvoice();
            loadDNNK();
        }

        private void grvFile_DoubleClick(object sender, EventArgs e)
        {
            if (grvFile.SelectedRowsCount > 0)
            {
                string ftpFilePath = TextUtils.ToString(grvFile.GetFocusedRowCellValue(colFilePath));
                DocUtils.InitFTPTK();
                string desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                DocUtils.DownloadFile(desktopFolder, Path.GetFileName(ftpFilePath), ftpFilePath);
                Process.Start(desktopFolder + "/" + Path.GetFileName(ftpFilePath));
            }
        }      

        private void btnUpdateCost_Click(object sender, EventArgs e)
        {
            if (TextUtils.ToString(grvOrder.GetFocusedRowCellValue(colAccount)) != Global.AppUserName)
            {
                MessageBox.Show("PO này không phải quyền phụ trách của bạn!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            _rowIndex = grvOrder.FocusedRowHandle;
            string orderid = TextUtils.ToString(grvOrder.GetFocusedRowCellValue(colOrderId));
            if (orderid == "")
            {
                return;
            }

            ArrayList listOrder = OrdersBO.Instance.FindByAttribute("OrderId", orderid);
            OrdersModel order = (OrdersModel)listOrder[0];
            
            frmPOUpdateCost frm = new frmPOUpdateCost();
            frm.Order = order;
            frm.TotalOrder = TextUtils.ToDecimal(grvOrder.GetFocusedRowCellValue(colTienThanhToan));
            frm.TotalPrice = TextUtils.ToDecimal(grvOrder.GetFocusedRowCellValue(colTotal));
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void grvOrder_DoubleClick(object sender, EventArgs e)
        {
            btnUpdateCost_Click(null, null);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvOrder.RowCount > 0)
                {
                    TextUtils.ExportExcel(grvOrder);
                }
            }
            catch
            {
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //string email = TextUtils.ToString(grvOrder.GetFocusedRowCellValue(colSupplierMail));
            //string person = TextUtils.ToString(grvOrder.GetFocusedRowCellValue(colContactPerson));
            //string subject = "Xác nhận đơn hàng";
            //string content = "Dear Anh/chị,<br>Tôi gửi xác nhận đơn hàng trên file đính kèm.<br>Thanks!";
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
            //List<string> at = new List<string>();
            //at.Add(@"C:\Users\thao.nv\Desktop\PO1.xlsx");
            //TextUtils.SetEmailSendHasAttach1(subject, content, email, "", at);

            //FolderBrowserDialog fbd = new FolderBrowserDialog();
            //if (fbd.ShowDialog()==DialogResult.OK)
            //{//TPAD.M3401.05
            //    string file3D = string.Format("/Thietke.Ck/{0}/{1}.Ck/3D.{1}/TPAD.M3401.05", "TPAD.M3401".Substring(0, 6), "TPAD.M3401");
            //    TextUtils.DownloadFtpFolder(file3D, fbd.SelectedPath + "/" + "TPAD.M3401");
            //}
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (TextUtils.ToString(grvOrder.GetFocusedRowCellValue(colAccount)) != Global.AppUserName)
            {
                MessageBox.Show("PO này không phải quyền phụ trách của bạn!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            SetInterface(true);
            grvHD.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (TextUtils.ToString(grvOrder.GetFocusedRowCellValue(colAccount)) != Global.AppUserName)
            {
                MessageBox.Show("PO này không phải quyền phụ trách của bạn!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            string orderid = TextUtils.ToString(grvOrder.GetFocusedRowCellValue(colOrderId));
            if (orderid == "")
            {
                return;
            }

            ArrayList listOrder = OrdersBO.Instance.FindByAttribute("OrderId", orderid);
            OrdersModel order = (OrdersModel)listOrder[0];

            if (grvHD.SelectedRowsCount > 0)
            {
                int id = TextUtils.ToInt(grvHD.GetFocusedRowCellValue(colInvoiceID));
                string code = TextUtils.ToString(grvHD.GetFocusedRowCellValue(colInvoiceCode));
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa hợp đồng ["+code+"] ?", 
                    TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (id > 0)
                        OrderInvoiceBO.Instance.Delete(id);
                    grvHD.DeleteSelectedRows();
                    if (grvHD.RowCount > 0)
                    {
                        order.TotalInvoice = TextUtils.ToDecimal(colInvoiceTotal.SummaryItem.SummaryValue);
                        OrdersBO.Instance.UpdateQLSX(order);
                        grvOrder.SetFocusedRowCellValue(colTotalInvoice, order.TotalInvoice);
                        decimal total = TextUtils.ToDecimal(grvHD.GetFocusedRowCellValue(colTotalTransfer));
                        grvOrder.SetFocusedRowCellValue(colBalance, total - order.TotalInvoice);
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (TextUtils.ToString(grvOrder.GetFocusedRowCellValue(colAccount)) != Global.AppUserName)
            {
                MessageBox.Show("PO này không phải quyền phụ trách của bạn!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            //string orderId = TextUtils.ToString(grvOrder.GetFocusedRowCellValue(colOrderId));
            //if (orderId == "") return;

            string orderid = TextUtils.ToString(grvOrder.GetFocusedRowCellValue(colOrderId));
            if (orderid == "")
            {
                return;
            }

            ArrayList listOrder = OrdersBO.Instance.FindByAttribute("OrderId", orderid);
            OrdersModel order = (OrdersModel)listOrder[0];

            //grvHD.OptionsView.NewItemRowPosition = NewItemRowPosition.None;

            grvHD.FocusedRowHandle = -1;
           
            for (int i = 0; i < grvHD.RowCount; i++)
            {
                ProcessTransaction pt = new ProcessTransaction();
                pt.OpenConnection();
                pt.BeginTransaction();

                try
                {
                    int id = TextUtils.ToInt(grvHD.GetRowCellValue(i, colInvoiceID));
                    OrderInvoiceModel invoice = new OrderInvoiceModel();
                    if (id > 0)
                    {
                        invoice = (OrderInvoiceModel) OrderInvoiceBO.Instance.FindByPK(id);
                    }
                    invoice.Code = TextUtils.ToString(grvHD.GetRowCellValue(i, colInvoiceCode));
                    invoice.Total = TextUtils.ToDecimal(grvHD.GetRowCellValue(i, colInvoiceTotal));
                    invoice.OrderId = orderid;
                    if (id > 0)
                    {
                        pt.Update(invoice);
                    }
                    else
                    {
                        pt.Insert(invoice);
                    }                    

                    pt.CommitTransaction();
                }
                catch
                {
                }
                finally
                {
                    pt.CloseConnection();
                }
            }

            loadInvoice();
            
            //SetInterface(false);

            order.TotalInvoice = TextUtils.ToDecimal(colInvoiceTotal.SummaryItem.SummaryValue);
            OrderInvoiceBO.Instance.UpdateQLSX(order);

            grvOrder.SetFocusedRowCellValue(colTotalInvoice, order.TotalInvoice);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            loadInvoice();
            SetInterface(false);
        }

        private void btnExportKH_Click(object sender, EventArgs e)
        {
            //string orderCode = TextUtils.ToString(grvOrder.GetFocusedRowCellValue(colSoDonHang));
            //if (orderCode == "") return;
            string localPath = "";

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            //fbd.SelectedPath = Settings.Default.POPath;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                localPath = fbd.SelectedPath + "\\KeHoachThanhToan-" + DateTime.Now.ToString("ddMMyyyy") + ".xlsx";
                //Settings.Default.CheckCMPath = localPath;
                //Settings.Default.Save();
            }
            else
            {
                return;
            }

            string filePath = Application.StartupPath + "\\Templates\\PhongVT\\KeHoachThanhToan.xlsx";

            try
            {
                File.Copy(filePath, localPath, true);
            }
            catch
            {
                MessageBox.Show("Lỗi: File excel đang được mở.");
                return;
            }

            grvOrder.ExpandAllGroups();

            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo biểu mẫu..."))
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                Excel.Application app = default(Excel.Application);
                Excel.Workbook workBoook = default(Excel.Workbook);
                Excel.Worksheet workSheet = default(Excel.Worksheet);
                try
                {
                    app = new Excel.Application();
                    app.Workbooks.Open(localPath);
                    workBoook = app.Workbooks[1];
                    workSheet = (Excel.Worksheet)workBoook.Worksheets[1];

                    for (int i = grvOrder.RowCount - 1; i >= 0; i--)
                    {
                        string orderId = TextUtils.ToString(grvOrder.GetRowCellValue(i, colOrderId));
                        if (orderId == "") continue;

                        workSheet.Cells[5, 1] = i + 1;
                        workSheet.Cells[5, 2] = TextUtils.ToString(grvOrder.GetRowCellDisplayText(i, colSupplierCode));
                        workSheet.Cells[5, 3] = TextUtils.ToString(grvOrder.GetRowCellDisplayText(i, colSupplierName));
                        workSheet.Cells[5, 4] = TextUtils.ToString(grvOrder.GetRowCellDisplayText(i, colSoDonHang));
                        workSheet.Cells[5, 5] = TextUtils.ToDecimal(grvOrder.GetRowCellValue(i, colTotal));
                        workSheet.Cells[5, 6] = TextUtils.ToDecimal(grvOrder.GetRowCellValue(i, colVAT))
                            * TextUtils.ToDecimal(grvOrder.GetRowCellValue(i, colTotal)) / 100;
                        workSheet.Cells[5, 7] = TextUtils.ToDecimal(grvOrder.GetRowCellValue(i, colVAT)) * TextUtils.ToDecimal(grvOrder.GetRowCellValue(i, colTotal))
                            + TextUtils.ToDecimal(grvOrder.GetRowCellValue(i, colTotal));
                        workSheet.Cells[5, 8] = TextUtils.ToDecimal(grvOrder.GetRowCellValue(i, colPayPercent));
                        workSheet.Cells[5, 9] = TextUtils.ToDecimal(grvOrder.GetRowCellValue(i, colPayPercent)) * TextUtils.ToDecimal(grvOrder.GetRowCellValue(i, colTotal));
                        workSheet.Cells[5, 10] = TextUtils.ToString(grvOrder.GetRowCellDisplayText(i, colRequirePaymentDate));
                        workSheet.Cells[5, 11] = TextUtils.ToString(grvOrder.GetRowCellDisplayText(i, colPaymentType));

                        workSheet.Cells[5, 22] = TextUtils.ToDecimal(grvOrder.GetRowCellValue(i, colBalance));
                        workSheet.Cells[5, 23] = TextUtils.ToString(grvOrder.GetRowCellDisplayText(i, colUsername));

                        DataTable dt = LibQLSX.Select("Select Code,Total from OrderInvoice with(nolock) where OrderId = '" + orderId + "'");
                        if (dt.Rows.Count > 0)
                        {
                            int count = 0;
                            for (int j = 0; j < 5; j++)
                            {
                                try
                                {
                                    workSheet.Cells[5, 12 + count] = TextUtils.ToString(dt.Rows[j]["Total"]);
                                    workSheet.Cells[5, 13 + count] = TextUtils.ToString(dt.Rows[j]["Code"]);
                                    count = count + 2;
                                }
                                catch
                                {                                    
                                }                                
                            }
                        }
                        
                        ((Excel.Range)workSheet.Rows[5]).Insert();
                    }

                    ((Excel.Range)workSheet.Rows[4]).Delete();
                    ((Excel.Range)workSheet.Rows[4]).Delete();
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

                if (File.Exists(localPath))
                {
                    Process.Start(localPath);
                }
            }
        }

        private void grvHD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == (Keys.C))
            {
                try
                {
                    string text = TextUtils.ToString(grvHD.GetFocusedRowCellValue(grvHD.FocusedColumn));
                    Clipboard.SetText(text);
                }
                catch (Exception)
                {
                }
            }
        }

        private void grvDNNK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == (Keys.C))
            {
                try
                {
                    string text = TextUtils.ToString(grvDNNK.GetFocusedRowCellValue(grvDNNK.FocusedColumn));
                    Clipboard.SetText(text);
                }
                catch (Exception)
                {
                }
            }
        }

        private void btnReportOrderReduce_Click(object sender, EventArgs e)
        {
            //string orderCode = TextUtils.ToString(grvOrder.GetFocusedRowCellValue(colSoDonHang));
            //if (orderCode == "") return;
            string localPath = "";

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            //fbd.SelectedPath = Settings.Default.POPath;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                localPath = fbd.SelectedPath + "\\Báo cáo giảm chi phí -" + DateTime.Now.ToString("ddMMyyyy") + ".xlsx";
                //Settings.Default.CheckCMPath = localPath;
                //Settings.Default.Save();
            }
            else
            {
                return;
            }

            string filePath = Application.StartupPath + "\\Templates\\PhongVT\\ReportOrderReduce.xlsx";

            try
            {
                File.Copy(filePath, localPath, true);
            }
            catch
            {
                MessageBox.Show("Lỗi: File excel đang được mở.");
                return;
            }

            grvOrder.ExpandAllGroups();

            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo biểu mẫu..."))
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                Excel.Application app = default(Excel.Application);
                Excel.Workbook workBoook = default(Excel.Workbook);
                Excel.Worksheet workSheet = default(Excel.Worksheet);
                try
                {
                    app = new Excel.Application();
                    app.Workbooks.Open(localPath);
                    workBoook = app.Workbooks[1];
                    workSheet = (Excel.Worksheet)workBoook.Worksheets[1];
                    int stt = 0;
                    for (int i = grvOrder.RowCount - 1; i >= 0; i--)
                    {
                        string orderCode = TextUtils.ToString(grvOrder.GetRowCellDisplayText(i, colSoDonHang));
                        string orderId = TextUtils.ToString(grvOrder.GetRowCellDisplayText(i, colOrderId));
                        if (orderCode == "")
                        {
                            continue;
                        }
                        decimal totalPrice = TextUtils.ToDecimal(grvOrder.GetRowCellDisplayText(i, colTotal));
                        decimal totalNCC = TextUtils.ToDecimal(grvOrder.GetRowCellDisplayText(i, colTotalNCC)) > 0 
                            ? TextUtils.ToDecimal(grvOrder.GetRowCellDisplayText(i, colTotalNCC)) : totalPrice;
                        decimal totalDinhMuc = 0;
                        //DataTable dt = LibQLSX.Select("Select sum([TotalBuy]*[PriceGN]) from [vGetPartWithOrder_PriceGN] with(nolock) where [OrderCode] = '" + orderCode + "'");
                        DataTable dt = LibQLSX.Select("Select sum(Price) from [OrderPartsBuyDM] with(nolock) where [OrderId] = '" + orderId + "'");                        
                        totalDinhMuc = dt.Rows.Count > 0 ? TextUtils.ToDecimal(dt.Rows[0][0]) : 0;

                        workSheet.Cells[5, 1] = i + 1;
                        workSheet.Cells[5, 2] = orderCode;
                        workSheet.Cells[5, 3] = TextUtils.ToString(grvOrder.GetRowCellDisplayText(i, colSupplierName));
                        workSheet.Cells[5, 4] = totalDinhMuc;
                        workSheet.Cells[5, 5] = totalNCC;
                        workSheet.Cells[5, 6] = totalPrice;

                        workSheet.Cells[5, 7] = totalDinhMuc - totalNCC;
                        workSheet.Cells[5, 8] = totalNCC - totalPrice;
                        workSheet.Cells[5, 9] = totalDinhMuc - totalNCC + totalNCC - totalPrice;
                        workSheet.Cells[5, 10] = totalDinhMuc > 0 ? (totalDinhMuc - totalNCC) / totalDinhMuc * 100 : 0;
                        workSheet.Cells[5, 11] = totalNCC > 0 ? (totalNCC - totalPrice) / totalNCC * 100 : 0;
                        workSheet.Cells[5, 12] = totalDinhMuc > 0 ? (totalDinhMuc - totalNCC + totalNCC - totalPrice) / totalDinhMuc * 100 : 0;
                       
                        workSheet.Cells[5, 13] = TextUtils.ToString(grvOrder.GetRowCellDisplayText(i, colUsername));
                        workSheet.Cells[5, 14] = TextUtils.ToString(grvOrder.GetRowCellValue(i, colDateCreated));                       
                        
                        ((Excel.Range)workSheet.Rows[5]).Insert();
                    }

                    ((Excel.Range)workSheet.Rows[4]).Delete();
                    ((Excel.Range)workSheet.Rows[4]).Delete();
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

                if (File.Exists(localPath))
                {
                    Process.Start(localPath);
                }
            }
        }

        private void btnExportOrderInvoice_Click(object sender, EventArgs e)
        {
            string projectId = TextUtils.ToString(cboProject.EditValue);
            if (projectId == "") return;

            //string orderCode = TextUtils.ToString(grvOrder.GetFocusedRowCellValue(colSoDonHang));
            //if (orderCode == "") return;

            string localPath = "";

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                localPath = fbd.SelectedPath + "\\OrderInvoice-" + TextUtils.ToString(grvCboProject.GetFocusedRowCellValue(colProjectCode)) + ".xlsx";
            }
            else
            {
                return;
            }

            string filePath = Application.StartupPath + "\\Templates\\PhongVT\\OrderInvoice.xlsx";

            try
            {
                File.Copy(filePath, localPath, true);
            }
            catch
            {
                MessageBox.Show("Lỗi: File excel đang được mở.");
                return;
            }

            //grvOrder.ExpandAllGroups();

            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang tạo biểu mẫu..."))
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                Excel.Application app = default(Excel.Application);
                Excel.Workbook workBoook = default(Excel.Workbook);
                Excel.Worksheet workSheet = default(Excel.Worksheet);
                try
                {
                    app = new Excel.Application();
                    app.Workbooks.Open(localPath);
                    workBoook = app.Workbooks[1];
                    workSheet = (Excel.Worksheet)workBoook.Worksheets[1];

                    string sql = "select distinct OrderId, OrderCode, OrderInvoiceList = stuff((SELECT ', '+ code FROM OrderInvoice where OrderId=a.OrderId FOR XML PATH('')),1,1,'')  from vGetProjectWithOrder a where ProjectId = '" + projectId + "'";
                    DataTable dt = LibQLSX.Select(sql);

                    for (int i = dt.Rows.Count - 1; i >= 0; i--)
                    {
                        workSheet.Cells[5, 1] = i + 1;
                        workSheet.Cells[5, 2] = TextUtils.ToString(dt.Rows[i]["OrderCode"]);
                        workSheet.Cells[5, 3] = TextUtils.ToString(dt.Rows[i]["OrderInvoiceList"]);

                        ((Excel.Range)workSheet.Rows[5]).Insert();
                    }

                    ((Excel.Range)workSheet.Rows[4]).Delete();
                    ((Excel.Range)workSheet.Rows[4]).Delete();
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

                if (File.Exists(localPath))
                {
                    Process.Start(localPath);
                }
            }
        }

        private void btnYCTT_Click(object sender, EventArgs e)
        {
            if (TextUtils.ToString(grvOrder.GetFocusedRowCellValue(colAccount)) != Global.AppUserName)
            {
                MessageBox.Show("PO này không phải quyền phụ trách của bạn!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            string orderid = TextUtils.ToString(grvOrder.GetFocusedRowCellValue(colOrderId));
            if (orderid == "") return;
            int statusTT = TextUtils.ToInt1(grvOrder.GetFocusedRowCellValue(colStatusTT));

            if (statusTT > 0)
            {
                MessageBox.Show("PO này không thể yêu cầu thanh toán!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            _rowIndex = grvOrder.FocusedRowHandle;

            ArrayList listOrder = OrdersBO.Instance.FindByAttribute("OrderId", orderid);
            OrdersModel order = (OrdersModel)listOrder[0];
            order.StatusTT = 1;
            OrdersBO.Instance.UpdateQLSX(order);
            loadOrder();            
        }

        private void hủyYêuCầuTTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TextUtils.ToString(grvOrder.GetFocusedRowCellValue(colAccount)) != Global.AppUserName)
            {
                MessageBox.Show("PO này không phải quyền phụ trách của bạn!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            string orderid = TextUtils.ToString(grvOrder.GetFocusedRowCellValue(colOrderId));
            if (orderid == "") return;
            int statusTT = TextUtils.ToInt1(grvOrder.GetFocusedRowCellValue(colStatusTT));

            if (statusTT > 1)
            {
                MessageBox.Show("PO này không thể hủy yêu cầu thanh toán!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            _rowIndex = grvOrder.FocusedRowHandle;

            ArrayList listOrder = OrdersBO.Instance.FindByAttribute("OrderId", orderid);
            OrdersModel order = (OrdersModel)listOrder[0];
            order.StatusTT = 0;
            OrdersBO.Instance.UpdateQLSX(order);
            loadOrder();      
        }

        string loadNumber(PaymentTableModel paymentTable)
        {
            string numberPT = "";
            if (paymentTable.ID == 0)
            {
                string current = "BKTT." + DateTime.Now.ToString("ddMMyy");
                DataTable dt = LibQLSX.Select("select * from PaymentTable with(nolock) where Number like '%" + current + "%' order by ID desc");
                if (dt.Rows.Count > 0)
                {
                    string number = TextUtils.ToString(dt.Rows[0]["Number"]);
                    int index = TextUtils.ToInt(number.Split('.')[2]);
                    numberPT = current + "." + string.Format("{0:00}", index + 1);
                }
                else
                {
                    numberPT = current + ".01";
                }
            }
            else
            {
                numberPT = paymentTable.Number;
            }
            return numberPT;
        }
        private void btnCreateBKTT_Click(object sender, EventArgs e)
        {
            //grvOrder.FocusedRowHandle = -1;
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();
            try
            {
                PaymentTableModel PaymentTable = new PaymentTableModel();
                PaymentTable.IsDeleted = false;
                PaymentTable.Note = "";
                PaymentTable.Number = loadNumber(PaymentTable);
                //PaymentTable.TotalTM = TextUtils.ToDecimal(colTM.SummaryItem.SummaryValue);
                //PaymentTable.TotalCK = TextUtils.ToDecimal(colCK.SummaryItem.SummaryValue);
                PaymentTable.UpdatedBy = Global.AppUserName;
                PaymentTable.UpdatedDate = DateTime.Now;
                PaymentTable.CreatedBy = Global.AppUserName;
                PaymentTable.CreatedDate = DateTime.Now;
                PaymentTable.ID = (long)pt.Insert(PaymentTable);
                int count = 0;
                foreach (int i in grvOrder.GetSelectedRows())
                {
                    string id = TextUtils.ToString(grvOrder.GetRowCellValue(i, colOrderId));
                    if (id == "") continue;
                    int statusTT = TextUtils.ToInt(grvOrder.GetRowCellValue(i, colStatusTT));
                    if (statusTT != 1) continue;
                    PaymentTableItemModel item = new PaymentTableItemModel();
                    item.Code = TextUtils.ToString(grvOrder.GetRowCellValue(i, colSoDonHang));
                    item.Content = "";
                    item.ContentCheck = "";
                    item.Target = TextUtils.ToString(grvOrder.GetRowCellValue(i, colProject));
                    item.Name = TextUtils.ToString(grvOrder.GetRowCellValue(i, colSupplierName));
                    //item.Note = TextUtils.ToString(grvOrder.GetRowCellValue(i, colNote));

                    item.PaymentTableID = PaymentTable.ID;

                    item.IsCash = true;

                    item.Total = TextUtils.ToDecimal(grvOrder.GetRowCellValue(i, colTienThanhToan));
                    item.TotalTH = TextUtils.ToDecimal(grvOrder.GetRowCellValue(i, colTotal));
                    item.DeliveryCost = TextUtils.ToDecimal(grvOrder.GetRowCellValue(i, colDeliveryCost));
                    item.DiffCost = TextUtils.ToDecimal(grvOrder.GetRowCellValue(i, colDiffCost));

                    item.PercentPay = 100;
                    item.TotalCash = 0;
                    item.TotalCK = item.Total;

                    item.UserId = TextUtils.ToString(grvOrder.GetRowCellValue(i, colUserId));

                    //item.CompanyID = TextUtils.ToInt(grvOrder.GetRowCellValue(i, colCompany));
                    //item.DepartmentId = TextUtils.ToString(grvOrder.GetRowCellValue(i, colDepartment));
                    item.ProjectId = TextUtils.ToString(grvOrder.GetRowCellValue(i, colProject));
                    //item.CostID = TextUtils.ToInt(grvOrder.GetRowCellValue(i, colCost));
                    //item.CountProject = TextUtils.ToInt(grvOrder.GetRowCellValue(i, colCountProject));
                    item.VAT = TextUtils.ToDecimal(grvOrder.GetRowCellValue(i, colVAT));

                    //item.ContractStatus = TextUtils.ToInt1(grvData.GetRowCellValue(i, colContractStatus));
                    //item.InvoiceStatus = TextUtils.ToInt1(grvData.GetRowCellValue(i, colInvoiceStatus));
                    //item.IsPO = TextUtils.ToBoolean(grvData.GetRowCellValue(i, colIsPO));
                    //item.IsCongNo = TextUtils.ToBoolean(grvData.GetRowCellValue(i, colIsCongNo));
                    //item.IsCuongVe = TextUtils.ToBoolean(grvData.GetRowCellValue(i, colIsCuongVe));
                    //item.IsGDD = TextUtils.ToBoolean(grvData.GetRowCellValue(i, colIsGĐĐ));
                    //item.IsTTGH = TextUtils.ToBoolean(grvData.GetRowCellValue(i, colIsTTGH));
                    //item.IsVV_DA_NCC = TextUtils.ToBoolean(grvData.GetRowCellValue(i, colIsVV_DA_NCC));
                                        
                    pt.Insert(item);

                    OrdersModel order = (OrdersModel)OrdersBO.Instance.FindByAttribute("OrderId", id)[0];
                    order.StatusTT = 2;
                    pt.UpdateQLSX(order);

                    count++;
                }
                if (count > 0)
                {
                    pt.CommitTransaction();
                    MessageBox.Show("Lưu trữ thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadOrder();
                    PaymentTableModel model = (PaymentTableModel)PaymentTableBO.Instance.FindByAttribute("Number", PaymentTable.Number)[0];
                    frmPaymentTableItem frm = new frmPaymentTableItem();
                    frm.PaymentTable = model;
                    frm.Show();
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lưu trữ không thành công!" + Environment.NewLine + ex.Message, TextUtils.Caption,
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                pt.CloseConnection(); 
            }            
        }
    }
}
