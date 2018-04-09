using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Model;
using BMS.Business;
using DevExpress.Utils;

namespace BMS
{
    public partial class frmBaiThucHanhPrice : _Forms
    {
        public BaiThucHanhModel BaiThucHanh = new BaiThucHanhModel();

        public frmBaiThucHanhPrice()
        {
            InitializeComponent();
        }

        private void frmBaiThucHanhPrice_Load(object sender, EventArgs e)
        {
            DocUtils.InitFTPQLSX();
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load giá..."))
            {
                loadGrid();
            }
        }

        void loadGrid()
        {
            DataTable dt = TextUtils.Select("Select *,0 as Price,0 as TotalPrice,0 as PriceType from vBaiThucHanhModule with(nolock) where BaiThucHanhID = " + BaiThucHanh.ID);
            foreach (DataRow row in dt.Rows)
            {
                string code = row["Code"].ToString();
                try
                {
                    if (code.StartsWith("TPAD."))
                    {
                        DataTable dtPrice = TextUtils.LoadModulePriceTPAD(code,false);
                        row["Price"] = TextUtils.ToInt(dtPrice.Compute("Sum(TotalPrice)", ""));
                        row["TotalPrice"] = TextUtils.ToInt(row["Qty"]) * TextUtils.ToInt(row["Price"]);
                        row["PriceType"] = TextUtils.ToInt(dtPrice.Rows[0]["PriceType"]);
                    }
                    else
                    {
                        string sql = "select top 1 Price from [Parts] with(nolock) where Replace(PartsCode,' ','') = '" + code.Replace(" ", "") + "'";
                        DataTable dtPrice = LibQLSX.Select(sql);
                        row["Price"] = TextUtils.ToInt(dtPrice.Rows[0][0]);
                        row["TotalPrice"] = TextUtils.ToInt(row["Qty"]) * TextUtils.ToInt(row["Price"]);
                        row["PriceType"] = 1;
                    }
                }
                catch (Exception)
                {
                   
                }                
            }
            grdModule.DataSource = dt;
        }

        private void grvModule_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            int priceType = TextUtils.ToInt(grvModule.GetRowCellValue(e.RowHandle, colPriceType));
            if (priceType==0)
            {
                if (e.Column==colTotalPrice)
                {
                    e.Appearance.BackColor = Color.Yellow;
                }
            }            
        }

        private void xemChiTiếtGiáModuleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string moduleCode = grvModule.GetFocusedRowCellValue(colMCode).ToString();
            if (moduleCode.StartsWith("TPAD."))
            {
                frmModulePrice frm = new frmModulePrice();
                ModulesModel model = (ModulesModel)ModulesBO.Instance.FindByAttribute("Code", moduleCode)[0];
                frm.Module = model;
                TextUtils.OpenForm(frm);
            }
        }
    }
}
