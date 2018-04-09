using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Business;
using BMS.Utils;
using BMS.Model;
using DevExpress.XtraGrid.Localization;

namespace BMS
{
    public partial class frmModuleHistory : _Forms
    {
        public int ID = 0;
        public string Code = "";
        public ModulesModel Module = new ModulesModel();
        public frmModuleHistory()
        {
            InitializeComponent();
        }

        private void frmModuleHistory_Load(object sender, EventArgs e)
        {
            GridLocalizer.Active = new MyGridLocalizer();
            this.Text = "Lịch sử module: " + Module.Code + " - " + Module.Name;

            DataTable dt = new DataTable();
            dt = TextUtils.Select("SELECT * FROM ActivityLog with(nolock) where ColumnChange <> N'Thông số kỹ thuật' and TableName='Modules' and KeyID=" + Module.ID + " order by DateProcess desc");
            DataTable dtTS = TextUtils.Select("SELECT * FROM ActivityLog with(nolock) where ColumnChange = N'Thông số kỹ thuật' and TableName='Modules' and KeyID=" + Module.ID + " order by DateProcess desc");

            if (dtTS.Rows.Count>0)
            {
                foreach (DataRow row in dtTS.Rows)
                {
                    string oldValue = row["OldValue"].ToString().Replace(" ", "@");
                    string newValue = row["NewValue"].ToString().Replace(" ", "@");
                    string[] arOld = oldValue.Split(new string[] { "\n" }, StringSplitOptions.None);
                    string[] arNew = newValue.Split(new string[] { "\n" }, StringSplitOptions.None);//.ToList();

                    string[] arOld1 = arOld.Where(o => !arNew.Contains(o)).ToArray();
                    string[] arNew1 = arNew.Where(o => !arOld.Contains(o)).ToArray();

                    row["OldValue"] = String.Join("\n", arOld1).Replace("@", " ");
                    row["NewValue"] = String.Join("\n", arNew1).Replace("@", " ");
                }

                dt.Merge(dtTS);
            }           

            grdData.DataSource = null;
            grdData.DataSource = dt;
        }

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView sndr =
                   sender as DevExpress.XtraGrid.Views.Grid.GridView;
            DevExpress.Utils.DXMouseEventArgs dxMouseEventArgs =
                e as DevExpress.Utils.DXMouseEventArgs;
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hitInfo =
               sndr.CalcHitInfo(dxMouseEventArgs.Location);

            if (hitInfo.InColumn)
            {
                grvData.ShowCustomFilterDialog(hitInfo.Column);
            }
        }
    }
}
