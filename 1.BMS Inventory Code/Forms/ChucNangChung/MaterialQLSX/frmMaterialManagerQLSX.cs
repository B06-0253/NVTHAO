using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using TPA.Business;
using TPA.Model;
using System.Collections;

namespace BMS
{
    public partial class frmMaterialManagerQLSX : _Forms
    {
        private int _RecordPerPage = 100;
        private int _PageIndex = 1;
        private int _TotalPage = 1;
        int _rownIndex = 0;
        DataTable _dtMaterial = new DataTable();

        public frmMaterialManagerQLSX()
        {
            InitializeComponent();
        }

        private void frmMaterialQLSX_Load(object sender, EventArgs e)
        {
            loadGroup();
            //loadData();
        }

        void loadData(int type = 0)
        {
            try
            {
                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load dữ liệu..."))
                {
                    string[] paraName = new string[2];
                    object[] paraValue = new object[2];

                    //paraName[0] = "@RecordPerPage"; paraValue[0] = _RecordPerPage;
                    //paraName[1] = "@PageIndex"; paraValue[1] = 1;
                    paraName[0] = "@TextFind"; paraValue[0] = txtName.Text.Trim();
                    if (type == 0)
                    {
                        paraName[1] = "@GroupId"; paraValue[1] = TextUtils.ToString(grvGroup.GetFocusedRowCellValue(colGroupId));
                    }
                    else
                    {
                        paraName[1] = "@GroupId"; paraValue[1] = "";
                    }                    

                    //_dtMaterial = SuppliersBO.Instance.LoadDataFromSP("spGetMaterialQLSX1", "Source", paraName, paraValue);
                    _dtMaterial = LibQLSX.LoadDataFromSP("spGetMaterialQLSX1","t", paraName, paraValue);
                    grdData.DataSource = _dtMaterial;

                    if (_rownIndex >= grvData.RowCount)
                        _rownIndex = 0;
                    if (_rownIndex > 0)
                        grvData.FocusedRowHandle = _rownIndex;
                    grvData.SelectRow(_rownIndex);
                }
            }
            catch
            {
            }
        }

        void loadGroup()
        {
            DataTable dt = LibQLSX.Select("select * from [Groups] with(nolock) where [GroupsType] = 2 and [StatusDisable] = 0");
            grdGroup.DataSource = dt;
        }

        void main_LoadDataChange(object sender, EventArgs e)
        {
            loadData(1);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void xemLịchSửNCCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string partsCode = TextUtils.ToString(grvData.GetFocusedRowCellValue(colCode));
            frmSupplierHistory frm = new frmSupplierHistory();
            frm.TextFind = partsCode;
            frm.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string id = TextUtils.ToString(grvData.GetFocusedRowCellValue(colParstId));
            ArrayList array = PartsBO.Instance.FindByAttribute("PartsId", id);
            PartsModel part = (PartsModel)array[0];

            _rownIndex = grvData.FocusedRowHandle;

            frmMaterialQLSX frm = new frmMaterialQLSX();
            frm.Part = part;
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                TextUtils.ExportExcel(grvData);
            }
            catch
            {
            }
        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadData(1);
                ((TextBox)sender).Focus();
            }
        }

        private void btnFindAll_Click(object sender, EventArgs e)
        {
            loadData(1);
        }

        private void grvGroup_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            loadData();
        }

        private void grvData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C)
            {
                try
                {
                    string text = TextUtils.ToString(grvData.GetFocusedRowCellValue(grvData.FocusedColumn));
                    Clipboard.SetText(text);
                }
                catch
                {
                }
            }
        }

        private void btnSupplierOfGroup_Click(object sender, EventArgs e)
        {
            string groupCode = TextUtils.ToString(grvGroup.GetFocusedRowCellValue(colGroupCode1));
            frmSupplierHistory frm = new frmSupplierHistory();
            frm.TypeFind = 1;
            frm.TextFind = groupCode;
            frm.Show();
        }

        private void xemLịchSửĐNXKToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void xemLịchSửĐNNKToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        void updatePart()
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
            
            DataTable dt = TextUtils.ExcelToDatatableNoHeader(filePath, "Sheet2");
            dt = dt.Select("F2 is not null and F2 <> ''").CopyToDataTable();

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Bạn đã chọn sai biểu mẫu dữ liệu.",TextUtils.Caption,MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }

            DataTable dtPart = LibQLSX.Select("select * from Parts with(nolock)");

            int count = 0;
            foreach (DataRow row in dt.Rows)
            {
                string partsCode = TextUtils.ToString(row["F2"]);
                if (partsCode == "") continue;
                string des = TextUtils.ToString(row["F3"]);
                string hsCode = TextUtils.ToString(row["F4"]);
                decimal importTax = TextUtils.ToDecimal(row["F5"]);

                DataRow[] drs = dtPart.Select("PartsCode = '" + partsCode.Trim() + "'");
                if (drs.Length > 0)
                {
                    string partsId = TextUtils.ToString(drs[0]["PartsId"]);

                    PartsModel part = (PartsModel)PartsBO.Instance.FindByAttribute("PartsId", partsId)[0];
                    part.Description = des;
                    part.HsCode = hsCode;
                    part.ImportTax = importTax;

                    PartsBO.Instance.UpdateQLSX(part);
                    count++;
                }
            }
            MessageBox.Show(count.ToString());
            loadData(1);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            updatePart();            
        }
    }
}
