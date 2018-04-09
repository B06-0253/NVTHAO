using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPA.Model;
using TPA.Business;
using System.Collections;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using DevExpress.Utils;

namespace BMS
{
    public partial class frmYCMVTwarning : _Forms
    {
        int _rownIndex = 0;

        public frmYCMVTwarning()
        {
            InitializeComponent();
        }

        private void frmYCMVTwarning_Load(object sender, EventArgs e)
        {
            cboIsCompleted.SelectedIndex = 2;
            //this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            //this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width/2, 0);        
            loadData();
        }

        void loadData()
        {
            string[] _paraName = new string[4];
            object[] _paraValue = new object[4];

            _paraName[0] = "@Period"; _paraValue[0] = 3;
            _paraName[1] = "@Status"; _paraValue[1] = 1;

            DataTable dt = new DataTable();
            if (Global.AppUserName == "khoi.pd" || Global.AppUserName == "thao.nv")
            {
                _paraName[2] = "@Account"; _paraValue[2] = "";
            }
            else
            {
                _paraName[2] = "@Account"; _paraValue[2] =  Global.AppUserName; 
            }

            _paraName[3] = "@IsCompleted"; _paraValue[3] = cboIsCompleted.SelectedIndex;

            dt = LibQLSX.LoadDataFromSP("spGetProposalProblem", "PP", _paraName, _paraValue);

            grdYCMVT.DataSource = dt;
            if (_rownIndex >= grvYCMVT.RowCount)
                _rownIndex = 0;
            if (_rownIndex > 0)
                grvYCMVT.FocusedRowHandle = _rownIndex;
            grvYCMVT.SelectRow(_rownIndex);
        }

        void loadGrid()
        {
            int id = TextUtils.ToInt(grvYCMVT.GetFocusedRowCellValue(colProposalProblemID));
            if (id == 0)
            {
                grdData.DataSource = null;
            }
            else
            {
                DataTable _dtAction = LibQLSX.Select("select * from vProposalProblemAction with(nolock) where ProposalProblemID = " + id);
                grdData.DataSource = _dtAction;
            }
        }

        void loadVT()
        {
            string YCMVTCode = TextUtils.ToString(grvYCMVT.GetFocusedRowCellValue(colProposalCode));
            if (YCMVTCode == "")
            {
                grdVT.DataSource = null;
            }
            else
            {
                DataTable dtVT = LibQLSX.Select("spGetPartWithYCMVT_All '" + YCMVTCode + "'");
                grdVT.DataSource = dtVT;
            }
        }

        void main_LoadDataChange(object sender, EventArgs e)
        {
            loadData();
        }

        private void grvMaterial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == (Keys.C))
            {
                try
                {
                    string text = TextUtils.ToString(grvYCMVT.GetFocusedRowCellValue(grvYCMVT.FocusedColumn));
                    Clipboard.SetText(text);
                }
                catch
                {
                }
            }
        }

        private void btnDNNKthanhPham_Click(object sender, EventArgs e)
        {
            try
            {
                TextUtils.ExportExcel(grvYCMVT);
            }
            catch
            {
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmProposalProblemAction frm = new frmProposalProblemAction();
            //frmProjectProblem frm = new frmProjectProblem();
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void grvYCMVT_DoubleClick(object sender, EventArgs e)
        {
            string proposalId = TextUtils.ToString(grvYCMVT.GetFocusedRowCellValue(colProposalId));
            if (proposalId == "") return;

            ArrayList arr = ProposalBuyBO.Instance.FindByAttribute("ProposalId", proposalId);
            ProposalBuyModel proposal = (ProposalBuyModel)arr[0];

            int id = TextUtils.ToInt(grvYCMVT.GetFocusedRowCellValue(colProposalProblemID));
            ProposalProblemModel model;
            if (id == 0)
            {
                model = new ProposalProblemModel();
            }
            else
	        {
                model = (ProposalProblemModel)ProposalProblemBO.Instance.FindByPK(id);
	        }            

            _rownIndex = grvYCMVT.FocusedRowHandle;
            frmProposalProblemAction frm = new frmProposalProblemAction(); 
            frm.ProposalProblem = model;
            frm.Proposal = proposal;
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void grvYCMVT_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            loadGrid();
            loadVT();
        }

        private void btnIsCompleted_Click(object sender, EventArgs e)
        {
            //colProposalProblemID
            int proposalProblemID = TextUtils.ToInt(grvYCMVT.GetFocusedRowCellValue(colProposalProblemID));
            if (proposalProblemID == 0)
            {
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn hoàn thành những hành động phương án này?", TextUtils.Caption,
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (int i in grvData.GetSelectedRows())
                {
                    int id = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                    if (id == 0) continue;
                    ProposalProblemActionModel model = (ProposalProblemActionModel)ProposalProblemActionBO.Instance.FindByPK(id);
                    model.IsCompleted = true;
                    ProposalProblemActionBO.Instance.Update(model);
                }

                DataTable dt = (DataTable)grvData.DataSource;
                DataRow[] drs = dt.Select("IsCompleted = 0 or IsCompleted is null");
                
                if (drs.Length == 0)
                {
                    ProposalProblemModel proposalProblem = (ProposalProblemModel)ProposalProblemBO.Instance.FindByPK(proposalProblemID);
                    proposalProblem.IsCompleted = 1;
                    ProposalProblemBO.Instance.Update(proposalProblem);
                }
                
                loadGrid();
            }
        }

        private void hủyHoànThànhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn hủy hoàn thành những hành động/phương án này?", TextUtils.Caption,
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (int i in grvData.GetSelectedRows())
                {
                    int id = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                    if (id == 0) continue;
                    ProposalProblemActionModel model = (ProposalProblemActionModel)ProposalProblemActionBO.Instance.FindByPK(id);
                    model.IsCompleted = false;
                    ProposalProblemActionBO.Instance.Update(model);
                }
                loadGrid();
            }
        }

        private void cboIsCompleted_SelectionChangeCommitted(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnExcelDetail_Click(object sender, EventArgs e)
        {
            if (grvYCMVT.RowCount == 0) return;

            string path = "";

            //bool isQtyTotal = false;

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path = fbd.SelectedPath;
            }
            else
            {
                return;
            }

            string filePath = Application.StartupPath + "\\Templates\\PhongVT\\VanDeVatTu.xls";
            string currentPath = path + "\\VanDeVatTu-" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" +
                                 DateTime.Now.Year + ".xls";

            try
            {
                File.Copy(filePath, currentPath, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi tạo biểu mẫu!" + Environment.NewLine + ex.Message,
                    TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            grvYCMVT.ExpandAllGroups();

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

                    for (int i = grvYCMVT.RowCount - 1; i >= 0; i--)
                    {
                        string proposalCode = TextUtils.ToString(grvYCMVT.GetRowCellValue(i, colMProposalCode));
                        if (proposalCode == "") continue;
                        //string sql = "select *,DATEDIFF(day, DateAboutE, DateAboutF) as Period from [dbo].[vRequirePartFull_Order] " +
                        //    "where ProposalCode = '" + proposalCode + "'";
                        //DataTable dt = LibQLSX.Select(sql);
                        DataTable dt = LibQLSX.Select("spGetPartWithYCMVT_All '" + proposalCode + "'");
                        for (int j = dt.Rows.Count - 1; j >= 0; j--)
                        {
                            string partsCode = TextUtils.ToString(dt.Rows[j]["PartsCode"]);
                            string partsName = TextUtils.ToString(dt.Rows[j]["PartsName"]);
                            string module = TextUtils.ToString(dt.Rows[j]["ModuleCode"]);
                            string sl = TextUtils.ToString(dt.Rows[j]["TotalBuy"]);
                            //string dateE = TextUtils.ToDate1(dt.Rows[j]["DateAboutE"].ToString()).ToString("dd/MM/yyyy");
                            //string dateF = TextUtils.ToDate1(dt.Rows[j]["DateAboutF"].ToString()).ToString("dd/MM/yyyy");
                            //string period = TextUtils.ToString(dt.Rows[j]["Period"]);

                            workSheet.Cells[12, 1] = "";
                            workSheet.Cells[12, 2] = j + 1;
                            workSheet.Cells[12, 3] = partsCode;
                            workSheet.Cells[12, 4] = partsName;
                            workSheet.Cells[12, 5] = module;
                            workSheet.Cells[12, 6] = sl;
                            workSheet.Cells[12, 7] = TextUtils.ToString(dt.Rows[j]["ManufacturerCode"]);
                            //workSheet.Cells[12, 8] = dateE;
                            //workSheet.Cells[12, 9] = dateF;
                            //workSheet.Cells[12, 10] = period;
                            workSheet.Cells[12, 8] = TextUtils.ToString(grvYCMVT.GetRowCellValue(i, colAccount));
                            workSheet.Cells[12, 9] = proposalCode;
                            workSheet.Cells[12, 10] = TextUtils.ToInt(grvYCMVT.GetRowCellValue(i, colIsHT));
                            workSheet.Cells[12, 11] = TextUtils.ToInt(grvYCMVT.GetRowCellValue(i, colIsCreatedPO));

                            ((Excel.Range)workSheet.Rows[12]).Insert();
                        }

                        workSheet.Cells[12, 1] = i + 1;
                        workSheet.Cells[12, 2] = "";
                        workSheet.Cells[12, 3] = proposalCode;
                        //workSheet.Cells[12, 4] = TextUtils.ToString(grvYCMVT.GetRowCellValue(i, colAccount));
                        workSheet.Cells[12, 5] = TextUtils.ToString(grvYCMVT.GetRowCellValue(i, colOrderCode));
                        workSheet.Cells[12, 6] = TextUtils.ToInt(grvYCMVT.GetRowCellValue(i, colIsHT));
                        workSheet.Cells[12, 7] = TextUtils.ToInt(grvYCMVT.GetRowCellValue(i, colIsCreatedPO));
                        workSheet.Cells[12, 8] = TextUtils.ToString(grvYCMVT.GetRowCellValue(i, colAccount));

                        ((Excel.Range)workSheet.Rows[12]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.GreenYellow);// Color.Yellow;
                        ((Excel.Range)workSheet.Rows[12]).Font.Bold = true;
                        ((Excel.Range)workSheet.Rows[12]).Insert();

                    }
                    ((Excel.Range)workSheet.Rows[11]).Delete();
                    ((Excel.Range)workSheet.Rows[11]).Delete();
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
    }
}
