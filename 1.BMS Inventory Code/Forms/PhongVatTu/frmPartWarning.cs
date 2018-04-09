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
using BMS.Model;
using BMS.Business;

namespace BMS
{
    public partial class frmPartWarning : _Forms
    {
        int count = 0;
        DataTable dtData = new DataTable();

        public frmPartWarning()
        {
            InitializeComponent();
        }

        private void frmPartWarning_Load(object sender, EventArgs e)
        {            
            loadData();
        }

        void loadData()
        {
            ConfigSystemModel model = (ConfigSystemModel)ConfigSystemBO.Instance.FindByAttribute("KeyName", "CanhBaoHanVeVT_period")[0];

            string sqlPart = "SELECT * FROM [vRequireBuyPart] with(nolock) where (status = 2) and [DateAboutE] is not null and ([DateAboutF] is null or [DateAboutF] = '')"
                        + " and datediff(dd,getdate(),DateAboutE)<= " + model.KeyValue;
            if (Global.AppUserName != "khoi.pd")
            {
                sqlPart += " and Account = '" + Global.AppUserName + "'";
            }
            
            dtData = LibQLSX.Select(sqlPart);

            string sqlOut = "SELECT * FROM [vRequestOut] with(nolock) where ([ProposalStatus] = 2) and [DateAboutE] is not null and ([DateAboutF] is null or [DateAboutF] = '')"
                        + " and datediff(dd,getdate(),DateAboutE)<= " + model.KeyValue;
            if (Global.AppUserName != "khoi.pd")
            {
                sqlOut += " and Account = '" + Global.AppUserName + "'";
            }
            DataTable dtOut = LibQLSX.Select(sqlOut);

            string sqlMaterial = "SELECT * FROM [vRequestMaterial] with(nolock) where ([ProposalStatus] = 2) and [DateAboutE] is not null and ([DateAboutF] is null or [DateAboutF] = '')"
                        + " and datediff(dd,getdate(),DateAboutE)<= " + model.KeyValue;
            if (Global.AppUserName != "khoi.pd")
            {
                sqlMaterial += " and Account = '" + Global.AppUserName + "'";
            }
            DataTable dtMaterial = LibQLSX.Select(sqlMaterial);

            if (dtMaterial.Rows.Count > 0)
            {
                dtData.Merge(dtMaterial);
            }
            if (dtOut.Rows.Count > 0)
            {
                dtData.Merge(dtOut);
            }

            count = dtData.Rows.Count;
            grdMaterial.DataSource = dtData;
        }

        private void grvMaterial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == (Keys.C))
            {
                try
                {
                    string text = TextUtils.ToString(grvMaterial.GetFocusedRowCellValue(grvMaterial.FocusedColumn));
                    Clipboard.SetText(text);
                }
                catch (Exception)
                {                   
                }               
            }
        }
    }
}
