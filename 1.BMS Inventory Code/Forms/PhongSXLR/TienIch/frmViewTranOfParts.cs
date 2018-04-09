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
using DevExpress.Utils;

namespace BMS
{
    public partial class frmViewTranOfParts : _Forms
    {
        private int _RecordPerPage = 100;
        private int _PageIndex = 1;
        private int _TotalPage = 1;
        DataTable _dtMaterial = new DataTable();

        public frmViewTranOfParts()
        {
            InitializeComponent();
        }

        private void frmViewTranOfParts_Load(object sender, EventArgs e)
        {
        }

        void loadData(int pageIndex)
        {
            try
            {
                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load dữ liệu..."))
                {
                    string[] paraName = new string[3];
                    object[] paraValue = new object[3];

                    paraName[0] = "@RecordPerPage"; paraValue[0] = _RecordPerPage;
                    paraName[1] = "@PageIndex"; paraValue[1] = pageIndex;
                    paraName[2] = "@TextFind"; paraValue[2] = txtTextFind.Text.Trim();

                    _dtMaterial = SuppliersBO.Instance.LoadDataFromSP("spGetMaterialQLSX1", "Source", paraName, paraValue);
                    
                    //string sqlSum = "";
                    //sqlSum = "select PartsId from [dbo].[Parts] where ([PartType] = 1 or [PartType] = 2) and [PartsUse] = 1 ";
                    //if (txtTextFind.Text.Trim() != "")
                    //{
                    //    sqlSum += " and (PartsCode like N'%" + txtTextFind.Text.Trim() + "%' or PartsName like N'%" + txtTextFind.Text.Trim() + "%')";
                    //}
                    //DataTable dt = LibQLSX.Select(sqlSum);

                    var query = from c in _dtMaterial.AsEnumerable()
                        .Skip(_RecordPerPage * pageIndex - _RecordPerPage).Take(_RecordPerPage)
                                select c;

                    int rowCount = _dtMaterial.Rows.Count;
                    _TotalPage = rowCount / _RecordPerPage;
                    if (rowCount % _RecordPerPage > 0 || _TotalPage == 0)
                    {
                        _TotalPage += 1;
                        txtTotalPage.Text = _TotalPage.ToString();
                    }
                    
                    grvDataMaterial.AutoGenerateColumns = false;
                    grvDataMaterial.DataSource = query.CopyToDataTable();
                }
            }
            catch
            {
            }        
        }

        #region Paging
        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            _PageIndex = 1;
            txtPageIndex.Text = 1.ToString();
            loadData(1);
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (_PageIndex == 1) return;
            _PageIndex--;
            txtPageIndex.Text = _PageIndex.ToString();
            loadData(_PageIndex);
        }

        private void btnNxtPage_Click(object sender, EventArgs e)
        {
            if (_PageIndex == _TotalPage) return;
            _PageIndex++;
            txtPageIndex.Text = _PageIndex.ToString();
            loadData(_PageIndex);
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            _PageIndex = _TotalPage;
            txtPageIndex.Text = _TotalPage.ToString();
            loadData(_TotalPage);
        }

        private void txtTextFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _PageIndex = 1;
                txtPageIndex.Text = 1.ToString();
                loadData(1);
            }
        }
        #endregion

        private void btnFindAll_Click(object sender, EventArgs e)
        {            
            _PageIndex = 1;
            txtPageIndex.Text = 1.ToString();
            loadData(1);        
        }

        private void grvDataMaterial_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                string partsCode = TextUtils.ToString(grvDataMaterial.SelectedRows[0].Cells["colMaCode"].Value);
                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load dữ liệu..."))
                {
                    DataTable dt = LibQLSX.Select("select * from [vDeliveryOrderPart] with(nolock) where replace(replace([PartsCode],'/','#'),')','#') = '"
                        + partsCode.Replace(" ", "").Replace("/", "#").Replace(")", "#") + "' order by [DateCreate] desc");
                    grvDNXK.AutoGenerateColumns = false;
                    grvDNXK.DataSource = dt;
                }
            }
            catch
            {
                grvDNXK.Rows.Clear();
            }
        }

        private void grvDNXK_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == (Keys.C))
            //{
            //    try
            //    {
            //        string text = TextUtils.ToString(grvDNXK.GetFocusedRowCellValue(grvDNXK.FocusedColumn));
            //        Clipboard.SetText(text);
            //    }
            //    catch
            //    {
            //    }
            //}
        }

    }
}
