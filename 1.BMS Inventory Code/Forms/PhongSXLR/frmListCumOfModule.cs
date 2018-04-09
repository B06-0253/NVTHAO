using DevExpress.Utils;
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
    public partial class frmListCumOfModule : _Forms
    {
        public string ModuleCode = "";
        public decimal ModuleQty = 0;
        public string ProjectId = "";
        public string ProjectModuleId = "";
        public frmListCumOfModule()
        {
            InitializeComponent();
        }

        private void frmListCumOfModule_Load(object sender, EventArgs e)
        {
            this.Text += ": " + ModuleCode;
            loadTree();
        }

        void loadTree()
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load danh sách tình trạng cụm..."))
            {
                DataTable dtDMVT = LibQLSX.Select("select [ID],[ModuleCode],[STT],[Name],[ThongSo],[Code],[Unit],[Qty],[QtyReal] from MaterialModuleLink "
                + " where ThongSo = N'TPA' and [Unit] = N'BỘ' and ModuleCode = '" + ModuleCode + "' order by STT");
                dtDMVT.Columns.Add("ParentID", typeof(long));
                dtDMVT.Columns.Add("PercentVT", typeof(decimal));
                dtDMVT.Columns.Add("PercentExport", typeof(decimal));
                foreach (DataRow row in dtDMVT.Rows)
                {
                    string stt = TextUtils.ToString(row["STT"]);
                    row["QtyReal"] = TextUtils.ToDecimal(row["QtyReal"]) * ModuleQty;
                    row["ParentID"] = 0;
                    string[] array = stt.Split('.');
                    if (array.Length > 1)
                    {
                        string sttParent = "";
                        for (int i = 0; i < array.Length; i++)
                        {
                            if (i == array.Length - 1) continue;
                            if (i == 0)
                            {
                                sttParent += array[i];
                            }
                            else
                            {
                                sttParent += "." + array[i];
                            }

                            DataRow[] drsParent = dtDMVT.Select("STT = '" + sttParent + "'");
                            if (drsParent.Length > 0)
                            {
                                row["ParentID"] = TextUtils.ToInt(drsParent[0]["ID"]);
                            }
                        }
                    }

                    DataTable dt = LibQLSX.Select("SELECT SUM(TotalReceived) / SUM(TotalRequest) * 100 AS PercentVT, "
                                                + " SUM(TotalRequestExport + TotalDelivery) / SUM(TotalRequest) * 100 AS PercentExport"
                                                + " FROM  vSummaryRequireParts "
                                                + " WHERE  (TotalRequest > 0) and (Total > 0) and isnull(Specifications,'') not like 'TPA'"
                                                + " and  IndexPart like '" + stt + ".%' and ProjectModuleId = '" + ProjectModuleId + "'");
                    if (dt.Rows.Count > 0)
                    {
                        row["PercentVT"] = TextUtils.ToDecimal(dt.Rows[0]["PercentVT"]);
                        row["PercentExport"] = TextUtils.ToDecimal(dt.Rows[0]["PercentExport"]);
                    }
                }

                treeData.KeyFieldName = "ID";
                //treeData.ParentFieldName = "ParentID";
                treeData.PreviewFieldName = "Code";
                treeData.DataSource = dtDMVT;

                treeData.ExpandAll();
            }
        }

        private void treeData_CustomDrawNodeCell(object sender, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {
            decimal percentVT = TextUtils.ToDecimal(e.Node.GetValue(colPercentVT));
            decimal qty = TextUtils.ToDecimal(e.Node.GetValue(colQty));

            if (e.Column == colPercentExport || e.Column == colPercentVT)
            {
                decimal percentExport = TextUtils.ToDecimal(e.Node.GetValue(colPercentExport));
                if (percentVT >= 100 && percentExport >= 100)
                {
                    e.Appearance.BackColor = Color.GreenYellow;
                }
                if (percentVT >= 100 && percentExport < 100)
                {
                    e.Appearance.BackColor = Color.Yellow;
                }
                //if (percentVT == 0 && qty == 0 )
                //{
                //    e.Appearance.BackColor = Color.MediumTurquoise;
                //}
            }

            //if (e.Column == colDateAboutE && percentVT < 100)
            //{
            //    if (qty == 0) return;

            //    if (TextUtils.ToDate3(e.Node.GetValue(colDateAboutE)).Date > TextUtils.ToDate3(dtpSXLRDeadline.EditValue).Date)
            //    {
            //        e.Appearance.BackColor = Color.Red;
            //    }
            //    else
            //    {
            //        if (TextUtils.ToInt(e.Node.GetValue(colTotalDateAboutENull)) > 0)
            //        {
            //            e.Appearance.BackColor = Color.Orange;
            //        }
            //    }
            //}
        }

        private void treeData_DoubleClick(object sender, EventArgs e)
        {
            string stt = TextUtils.ToString(treeData.FocusedNode.GetValue(colSTT));
            frmListPartOfModule frm = new frmListPartOfModule();
            frm.ProjectModuleId = ProjectModuleId;
            frm.ModuleCode = TextUtils.ToString(treeData.FocusedNode.GetValue(colCodeTK));
            frm.TotalReal = TextUtils.ToDecimal(treeData.FocusedNode.GetValue(colQty));
            frm.ProjectId = ProjectId;
            frm.STT = stt;
            frm.Show();   
        }
    }
}
