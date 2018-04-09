using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DevExpress.Utils;

namespace BMS
{
    public partial class frmCheckVT : _Forms
    {
        DataTable dtLocal;

        public frmCheckVT()
        {
            InitializeComponent();
        }

        public DataTable GetDMVT(string filePath)
        {
            try
            {
                DataTable dtDMVT = TextUtils.ExcelToDatatableNoHeader(filePath, "Sheet");
                dtDMVT = dtDMVT.Select("F1 <> ''").CopyToDataTable();
                DataTable dtDMVT1 = dtDMVT.Copy();
                dtDMVT1.Rows.Clear();
                for (int i = 0; i < dtDMVT.Rows.Count; i++)
                {
                    try
                    {
                        if (dtDMVT.Rows[i][0] == null)
                        {
                            continue;
                        }
                        if (dtDMVT.Rows[i][0].ToString().Trim() == "")
                        {
                            continue;
                        }
                        string STT = dtDMVT.Rows[i][0].ToString().Trim();
                        if (TextUtils.ToDecimal(STT.Substring(0, 1)) > 0)
                        {
                            dtDMVT1.ImportRow(dtDMVT.Rows[i]);
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                return dtDMVT1;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void frmCheckVT_Load(object sender, EventArgs e)
        {
            dtLocal = new DataTable();
            dtLocal.Columns.Add("STT", typeof(string));
            dtLocal.Columns.Add("Name", typeof(string));
            dtLocal.Columns.Add("Size", typeof(string));
            dtLocal.Columns.Add("Type", typeof(string));
            dtLocal.Columns.Add("Hang", typeof(string));
            dtLocal.Columns.Add("PathLocal", typeof(string));
            dtLocal.Columns.Add("Path3D", typeof(string));
            //grvDataCT.DataSource = dtLocal;
            grdCheck.DataSource = dtLocal;
        }

        public DataTable GetDMVTHang1(string filePath)
        {
            try
            {
                DataTable dt1 = TextUtils.ExcelToDatatable(filePath, "Sheet");
                DataTable dt = dt1.Copy();
                for (int i = 0; i <= 4; i++)
                {
                    dt.Rows.RemoveAt(0);
                }
                return dt;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtDMVTPath.Text = ofd.FileName;
                DataTable dt = GetDMVT(ofd.FileName);
                dt.Columns.Add("Type");
                grdDMVTC.DataSource = dt;
            }
        }

        private void btnCheckCT_Click(object sender, EventArgs e)
        {
            if (txtDMVTPath.Text.Trim() == "") return;
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang kiểm tra danh mục vật tư..."))
            {
                dtLocal.Rows.Clear();

                DataTable dtDMVT = GetDMVT(txtDMVTPath.Text);

                for (int i = 0; i <= dtDMVT.Rows.Count - 1; i++)
                {
                    string nameDMVT = dtDMVT.Rows[i][3].ToString();
                    string hang = dtDMVT.Rows[i][7].ToString();

                    if (nameDMVT == "") continue;

                    if (!nameDMVT.StartsWith("TPAD") && !nameDMVT.StartsWith("PCB"))
                    {
                        //Kiem tra xem vat tu co trong kho chua
                        DataTable dtMaterialQLSX = LibQLSX.Select("SELECT top 1 p.PartsCode,m.ManufacturerCode"
                            + " FROM Manufacturer m RIGHT OUTER JOIN"
                            + " PartsManufacturer pm ON m.ManufacturerId = pm.ManufacturerId RIGHT OUTER JOIN"
                            + " Parts p ON pm.PartsId = p.PartsId"
                            + " where p.PartsCode = '" + nameDMVT.Replace(" ", "").Replace("(", "/") + "'");
                        if (dtMaterialQLSX.Rows.Count == 0)
                        {
                            DataRow row = dtLocal.NewRow();
                            row["STT"] = dtDMVT.Rows[i][0].ToString();
                            row["Name"] = nameDMVT;
                            row["Type"] = "Vật tư không tồn tại";
                            row["Hang"] = "";
                            dtLocal.Rows.Add(row);
                        }
                        else
                        {
                            if (dtMaterialQLSX.Rows[0]["ManufacturerCode"].ToString() != hang)
                            {
                                DataRow row = dtLocal.NewRow();
                                row["STT"] = dtDMVT.Rows[i][0].ToString();
                                row["Name"] = nameDMVT;
                                row["Type"] = "Vật tư không đúng hãng";
                                row["Hang"] = hang;
                                row["Size"] = dtMaterialQLSX.Rows[0]["ManufacturerCode"].ToString();
                                dtLocal.Rows.Add(row);
                            }
                        }

                        //Kiểm tra vật tư dừng sử dụng
                        DataTable dtViewMaterial = TextUtils.Select("SELECT MaterialGroupCode FROM [vMaterial] with (nolock) where replace(Code,' ','') = '" 
                            + nameDMVT.Replace(" ", "").Replace(")", "/") + "'");
                        if (dtViewMaterial.Rows.Count > 0)
                        {
                            string materialGroupCode = dtViewMaterial.Rows[0][0].ToString();
                            if (materialGroupCode == "TPAVT.Z01")
                            {
                                decimal currentQty = TextUtils.ToDecimal(dtDMVT.Rows[i][6]);
                                DataTable dtTonKho = LibQLSX.Select("select dbo.fMaterialInventory('" 
                                    + nameDMVT.Replace(" ", "").Replace(")", "/") + "')");
                                decimal inventoryQty = TextUtils.ToDecimal(dtTonKho.Rows[0][0]);
                                if (currentQty > inventoryQty)
                                {
                                    DataRow row = dtLocal.NewRow();
                                    row["STT"] = dtDMVT.Rows[i][0].ToString();
                                    row["Name"] = nameDMVT;
                                    row["Type"] = "Vật tư ngừng sử dụng";
                                    row["Hang"] = hang;
                                    dtLocal.Rows.Add(row);
                                }
                            }
                        }

                        //Kiểm tra sự tạm dừng của vật tư
                        DataTable dtMaterialCSDL = TextUtils.Select("SELECT * FROM [Material] with (nolock) where [StopStatus] = 1 and replace(Code,' ','') = '" 
                            + nameDMVT.Replace(" ", "").Replace(")", "/") + "'");
                        if (dtMaterialCSDL.Rows.Count > 0)
                        {
                            DataRow row = dtLocal.NewRow();
                            row["STT"] = dtDMVT.Rows[i][0].ToString();
                            row["Name"] = nameDMVT;
                            row["Type"] = "Vật tư tạm dừng sử dụng";
                            row["Hang"] = hang;
                            dtLocal.Rows.Add(row);
                        }

                        #region Kiem tra hang co hop le
                        DataTable dtGroup = TextUtils.Select("select CustomerCode from vMaterialCustomer a where replace(a.Code,' ','') ='" 
                            + nameDMVT.Replace(" ", "").Replace("(", "/") + "'");
                        if (dtGroup.Rows.Count > 0)
                        {
                            DataRow[] drs = dtGroup.Select("CustomerCode = '" + hang + "'");
                            if (drs.Count() == 0)
                            {
                                DataRow row = dtLocal.NewRow();
                                row["STT"] = dtDMVT.Rows[i][0].ToString();
                                row["Name"] = nameDMVT;
                                row["Type"] = "Hãng không được sử dụng";
                                row["Hang"] = hang;
                                dtLocal.Rows.Add(row);
                            }
                        }
                        #endregion
                    }
                }
            }
            if (dtLocal.Rows.Count == 0)
            {
                MessageBox.Show("Đã chuẩn!");
            }
            else
            {
                MessageBox.Show("Chưa chuẩn!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dtLocal.Rows.Count>0)
            {
                TextUtils.ExportExcel(grvCheck);
            }            
        }

        private void btnDownload3D_Click(object sender, EventArgs e)
        {
            if (grvDMVTC.RowCount==0)
            {
                return;
            }
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang download file 3D"))
            {
                DocUtils.InitFTPTK();
                string moduleCode = Path.GetFileNameWithoutExtension(txtDMVTPath.Text).Substring(5, 10);
                string localFolder = string.Format(@"D:\Thietke.Ck\{0}\{1}.Ck\3D.{1}\COM.{1}", moduleCode.Substring(0, 6), moduleCode);
                if (!Directory.Exists(localFolder))
                {
                    Directory.CreateDirectory(localFolder);
                }
                for (int i = 0; i < grvDMVTC.RowCount; i++)
                {
                    string code = TextUtils.ToString(grvDMVTC.GetRowCellValue(i, colCode3));
                    string hang = TextUtils.ToString(grvDMVTC.GetRowCellValue(i, colHang3));

                    if (code == "") continue;
                    if (hang == "") continue;

                    Directory.CreateDirectory(localFolder + "//" + hang);

                    DataTable dtMaterialFile = TextUtils.Select("select * from [MaterialFile] with(nolock) where FileType = 0 and replace(Name,' ','') = '"
                        + code.Replace(" ", "") + ".ipt'");

                    if (dtMaterialFile.Rows.Count == 0)
                    {
                        grvDMVTC.SetRowCellValue(i, colType3, "Không có file trên nguồn");
                        continue;
                    }

                    foreach (DataRow row in dtMaterialFile.Rows)
                    {
                        string serverFilePath = TextUtils.ToString(row["Path"]);
                        if (!DocUtils.CheckExits(serverFilePath)) continue;
                        DocUtils.DownloadFile(localFolder + "//" + hang, Path.GetFileName(serverFilePath), serverFilePath);
                    }
                }
            }
            MessageBox.Show("Đã hoàn thành download file 3D!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
