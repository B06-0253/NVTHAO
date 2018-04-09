using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IE.Model;
using IE.Business;
using IE.Utils;

namespace BMS
{
    public partial class frmSetRateOfPhanXuong_KMP : _Forms
    {
        public frmSetRateOfPhanXuong_KMP()
        {
            InitializeComponent();
        }

        private void frmSetRateOfPhanXuong_KMP_Load(object sender, EventArgs e)
        {
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Location = new Point(this.Location.X, 0);
            loadKMP();
        }

        void loadKMP()
        {
            string sql = "SELECT [PK_ID],[C_MA],[C_MOTA] FROM [tanphat].[dbo].[T_DM_KMP] order by [C_MA]";
            DataTable dt = LibIE.Select(sql);
            grdData.DataSource = dt;
        }

        void loadLink()
        {
            int pk_KMP = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if(pk_KMP == 0) return;
            string sql = "select * from V_DM_PHANXUONG_KMP where PK_KMP = " + pk_KMP + " order by [C_MA]";
            DataTable dtLink = LibIE.Select(sql);
            if(dtLink.Rows.Count > 0)
            {
                grdLink.DataSource = dtLink;
            }
            else
            {
                string sql1 = "select 0.00 as TYLE, 0 as ID, PK_ID as PK_PHANXUONG, C_MA, C_MOTA from T_DM_PHANXUONG order by [C_MA]";
                grdLink.DataSource = LibIE.Select(sql1);
            }
        }

        private void grvData_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            loadLink();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int pk_KMP = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (pk_KMP == 0) return;

            DataTable dt = (DataTable)grdLink.DataSource;
            DataRow[] drs = dt.Select("TYLE > 0");
            if(drs.Length == 0)
            {
                MessageBox.Show("Bạn chưa cấu hình tỷ lệ phân bổ cho chi phí này.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
                
            for (int i = 0; i < grvLink.RowCount - 1; i++)
            {
                //if (TextUtils.ToDecimal(grvLink.GetRowCellValue(i, colLinkTyLe)) == 0) continue;
                int linkID = TextUtils.ToInt(grvLink.GetRowCellValue(i, colLinkID));
                T_DM_PHANXUONG_KMPModel link = new T_DM_PHANXUONG_KMPModel();
                if (linkID > 0)
                {
                    link = (T_DM_PHANXUONG_KMPModel)T_DM_PHANXUONG_KMPBO.Instance.FindByPK(linkID);
                }

                link.PK_KMP = pk_KMP;
                link.PK_PHANXUONG = TextUtils.ToInt(grvLink.GetRowCellValue(i, colLinkPK_PHANXUONG));
                link.TYLE = TextUtils.ToDecimal(grvLink.GetRowCellValue(i, colLinkTyLe));

                if (linkID > 0)
                {
                    T_DM_PHANXUONG_KMPBO.Instance.Update(link);
                }
                else
                {
                    T_DM_PHANXUONG_KMPBO.Instance.Insert(link);
                }
            }
            MessageBox.Show("Lưu trữ thành công.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadLink();
        }

        private void grvLink_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (TextUtils.ToDecimal(grvLink.GetRowCellValue(e.RowHandle, colLinkTyLe)) > 0)
            {
                e.Appearance.BackColor = Color.GreenYellow;                
            }               
        }

        private void grvData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == (Keys.C))
            {
                try
                {
                    string text = TextUtils.ToString(grvData.GetFocusedRowCellValue(grvData.FocusedColumn));
                    Clipboard.SetText(text);
                }
                catch (Exception)
                {
                }
            }
        }

        private void grvLink_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == (Keys.C))
            {
                try
                {
                    string text = TextUtils.ToString(grvLink.GetFocusedRowCellValue(grvLink.FocusedColumn));
                    Clipboard.SetText(text);
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
