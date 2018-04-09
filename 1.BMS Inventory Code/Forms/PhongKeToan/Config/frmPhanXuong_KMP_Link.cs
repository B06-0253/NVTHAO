using IE.Business;
using IE.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BMS
{
    public partial class frmPhanXuong_KMP_Link : _Forms
    {
        public frmPhanXuong_KMP_Link()
        {
            InitializeComponent();
        }

        private void frmPhanXuong_KMP_Link_Load(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Location = new Point(this.Location.X, 0);
            loadKMP();
            loadPhongBan();
        }

        void loadPhongBan()
        {
            string sql = "SELECT [PK_ID],[C_MA],[C_MOTA] FROM [tanphat].[dbo].[T_DM_PHANXUONG] order by [C_MA]";
            DataTable dt = LibIE.Select(sql);
            grdPhongBan.DataSource = dt;
        }

        void loadKMP()
        {
            string sql = "SELECT [PK_ID],[C_MA],[C_MOTA] FROM [tanphat].[dbo].[T_DM_KMP] order by [C_MA]";
            DataTable dt = LibIE.Select(sql);
            grdData.DataSource = dt;
        }

        void loadLink()
        {
            int phongBanID = TextUtils.ToInt(grvPhongBan.GetFocusedRowCellValue(colPBID));
            string sql = "SELECT [ID],[C_MA],[C_MOTA] from V_DM_PHANXUONG_KMP_LINK where PK_PHANXUONG = " + phongBanID + " order by [C_MA]";
            DataTable dt = LibIE.Select(sql);
            grdLink.DataSource = dt;
        }

        private void grvPhongBan_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            loadLink();
        }

        private void btnPush_Click(object sender, EventArgs e)
        {
            string kmpCode = TextUtils.ToString(grvData.GetFocusedRowCellValue(colCode));
            string phongbanCode = TextUtils.ToString(grvPhongBan.GetFocusedRowCellValue(colPBCode));
            if (kmpCode == "" || phongbanCode == "") return;

            string sql = "SELECT top 1 * from V_DM_PHANXUONG_KMP_LINK where C_MA = '" + kmpCode + "' order by [C_MA]";
            DataTable dt = LibIE.Select(sql);
            if (dt.Rows.Count > 0)
            {
                //MessageBox.Show("Khoản mục phí này đã được gán cho phòng (" + TextUtils.ToString(dt.Rows[0]["PHANXUONG_MA"]) + " - " + TextUtils.ToString(dt.Rows[0]["PHANXUONG_TEN"]) + ")"
                //    , TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //return;
                int id = TextUtils.ToInt(dt.Rows[0]["ID"]);
                T_DM_PHANXUONG_KMP_LinkModel link = (T_DM_PHANXUONG_KMP_LinkModel)T_DM_PHANXUONG_KMP_LinkBO.Instance.FindByPK(id);
                link.PK_KMP = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
                link.PK_PHANXUONG = TextUtils.ToInt(grvPhongBan.GetFocusedRowCellValue(colPBID));
                T_DM_PHANXUONG_KMP_LinkBO.Instance.Update(link);
            }
            else
            {
                T_DM_PHANXUONG_KMP_LinkModel link = new T_DM_PHANXUONG_KMP_LinkModel();
                link.PK_KMP = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
                link.PK_PHANXUONG = TextUtils.ToInt(grvPhongBan.GetFocusedRowCellValue(colPBID));
                T_DM_PHANXUONG_KMP_LinkBO.Instance.Insert(link);
            }

            loadLink();
        }

        private void grvLink_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn bỏ chi phí này?", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No) return;
                int id = TextUtils.ToInt(grvLink.GetFocusedRowCellValue(colLinkID));
                T_DM_PHANXUONG_KMP_LinkBO.Instance.Delete(id);

                loadLink();
            }
        }
    }
}
