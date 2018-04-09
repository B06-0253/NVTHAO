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

namespace BMS
{
    public partial class frmShowListVersion : _Forms
    {
        public BaiThucHanhModel BaiThucHanh = new BaiThucHanhModel();
        public ProductsModel Product = new ProductsModel();

        public frmShowListVersion()
        {
            InitializeComponent();
        }

        private void frmShowListVersion_Load(object sender, EventArgs e)
        {
            if (BaiThucHanh.ID>0)
            {
                this.Text = "Danh sách phiên bản bài thực hành: " + BaiThucHanh.Code + " - " + BaiThucHanh.Name;
            }
            else
            {
                this.Text = "Danh sách phiên bản sản phẩm: " + Product.Code + " - " + Product.Name;
            }
            loadGrid();
        }

        void loadGrid()
        {
            DataTable dt = null;
            if (BaiThucHanh.ID>0)
            {
                dt = TextUtils.Select("select * from vBaiThucHanhVersion with(nolock) where BaiThucHanhID = " + BaiThucHanh.ID);
                colObjectID.FieldName = "BaiThucHanhID";
            }
            else
            {
                dt = TextUtils.Select("select * from ProductVersion with(nolock) where ProductID = " + Product.ID);
                colObjectID.FieldName = "ProductID";
            }
            grdData.DataSource = dt;
        }

        private void xemChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colObjectID));
            if (id == 0) return;

            if (BaiThucHanh.ID > 0)
            {
                BaiThucHanhModel model = (BaiThucHanhModel)BaiThucHanhBO.Instance.FindByPK(id);
                int version = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colVersion));

                frmBaiTHDetail frm = new frmBaiTHDetail();
                frm.BaiThucHanh = model;
                frm.IsShowVersion = true;
                frm.Version = version;
                TextUtils.OpenForm(frm);
            }
            else
            {
                ProductsModel model = (ProductsModel)ProductsBO.Instance.FindByPK(id);
                int version = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colVersion));

                frmProduct frm = new frmProduct();
                frm.Product = model;
                frm.IsShowVersion = true;
                frm.Version = version;
                TextUtils.OpenForm(frm);
            }
        }

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            xemChiTiếtToolStripMenuItem_Click(null, null);
        }
    }
}
