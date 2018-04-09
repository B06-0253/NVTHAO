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
using TPA.Utils;
using System.Collections;
using DevExpress.Utils;

namespace BMS
{
    public partial class frmGetVTPofProject : _Forms
    {
        public frmGetVTPofProject()
        {
            InitializeComponent();
        }

        private void frmGetVTPofProject_Load(object sender, EventArgs e)
        {
            loadProject();
        }
        void loadProject()
        {
            try
            {
                //DataTable tbl = LibQLSX.Select("exec spGetAllProject");
                DataTable tbl = LibQLSX.Select("select * from Project");
                TextUtils.PopulateCombo(cboProject, tbl, "ProjectCode", "ProjectId", "");
            }
            catch (Exception ex)
            {
            }
        }

        private void cboProject_EditValueChanged(object sender, EventArgs e)
        {
            if (cboProject.EditValue == null) return;
            string sql = "select sum(TotalReal*Price) from vGetProductOfProject1 where ProjectId = '" + TextUtils.ToString(cboProject.EditValue) + "'";
            txtPrice.EditValue = LibQLSX.ExcuteScalar(sql);            
        }

        private void btnReloadData_Click(object sender, EventArgs e)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang xử lý..."))
            {
                string projectId = TextUtils.ToString(cboProject.EditValue);
                if (projectId == "")
                {
                    MessageBox.Show("Bạn phải chọn một dự án.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (TextUtils.ToDecimal(txtPrice.EditValue) == 0)
                {
                    MessageBox.Show("Bạn chưa điền giá trị hợp đồng.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                DataTable dtData = new DataTable();
                dtData.Columns.Add("PartsId", typeof(string));
                dtData.Columns.Add("PartsCode", typeof(string));
                dtData.Columns.Add("PartsName", typeof(string));
                dtData.Columns.Add("Unit", typeof(string));
                dtData.Columns.Add("ManufacturerCode", typeof(string));
                dtData.Columns.Add("Type", typeof(int));
                //dtData.Columns.Add("Price", typeof(decimal));
                dtData.Columns.Add("Qty", typeof(decimal));

                dtData.Columns.Add("QtyTT", typeof(decimal));
                dtData.Columns.Add("QtyBuyDA", typeof(decimal));
                dtData.Columns.Add("QtyBuyKho", typeof(decimal));
                dtData.Columns.Add("QtyXuat", typeof(decimal));

                #region Vật tư phụ cho dự án
                string sqlP = "SELECT PartsId, PartsCode, PartsName, Unit, Price, ManufacturerCode, QtyP =(case when Price = 0 then 0 else CEILING(ProjectPercent*"
                    + TextUtils.ToDecimal(txtPrice.EditValue) + "/Price) end) FROM vPartsGeneral WHERE (IsProject = 1)";
                DataTable dtPartOP = LibQLSX.Select(sqlP);
                foreach (DataRow row in dtPartOP.Rows)
                {
                    string partsId = TextUtils.ToString(row["PartsId"]);
                    DataRow[] drs = dtData.Select("PartsId = '" + partsId + "'");
                    if (drs.Length > 0)
                    {
                        drs[0]["Qty"] = TextUtils.ToDecimal(drs[0]["Qty"]) + TextUtils.ToDecimal(row["QtyP"]);
                    }
                    else
                    {
                        DataRow nR = dtData.NewRow();
                        nR["PartsId"] = partsId;
                        nR["PartsCode"] = TextUtils.ToString(row["PartsCode"]);
                        nR["PartsName"] = TextUtils.ToString(row["PartsName"]);
                        nR["Unit"] = TextUtils.ToString(row["Unit"]);
                        nR["ManufacturerCode"] = TextUtils.ToString(row["ManufacturerCode"]);
                        nR["Type"] = 4;
                        nR["Qty"] = TextUtils.ToDecimal(row["QtyP"]);
                        dtData.Rows.Add(nR);
                    }
                }
                #endregion

                #region Vật tư phụ cho vật tư của module trong dự án
                string sqlVTPofPart = "SELECT PartsGeneralId,PartsId, PartsCode, PartsName, Unit, Price, ManufacturerCode,Qty FROM [vGetVTPofParts]" +
                " WHERE ProjectModuleCode is not null and ProjectModuleCode like 'tpad.%' and ProjectId = '" + projectId + "'";
                DataTable dtVtpOPart = LibQLSX.Select(sqlVTPofPart);
                foreach (DataRow row in dtVtpOPart.Rows)
                {
                    string partsId = TextUtils.ToString(row["PartsGeneralId"]);
                    DataRow[] drs = dtData.Select("PartsId = '" + partsId + "'");
                    if (drs.Length > 0)
                    {
                        drs[0]["Qty"] = TextUtils.ToDecimal(drs[0]["Qty"]) + TextUtils.ToDecimal(row["Qty"]);
                    }
                    else
                    {
                        DataRow nR = dtData.NewRow();
                        nR["PartsId"] = TextUtils.ToString(row["PartsGeneralId"]);
                        nR["PartsCode"] = TextUtils.ToString(row["PartsCode"]);
                        nR["PartsName"] = TextUtils.ToString(row["PartsName"]);
                        nR["Unit"] = TextUtils.ToString(row["Unit"]);
                        nR["ManufacturerCode"] = TextUtils.ToString(row["ManufacturerCode"]);
                        nR["Type"] = 1;
                        nR["Qty"] = TextUtils.ToDecimal(row["Qty"]);
                        dtData.Rows.Add(nR);
                    }
                }
                #endregion

                #region Vật tư phụ cho module trong dự án
                string sql = "SELECT * FROM [vGetProductOfProject1] where [ProjectId]='" + projectId
                    + "' and [ProjectModuleCode] is not null and ProjectModuleCode like 'tpad.%'";
                DataTable dtListModule = LibQLSX.Select(sql);
                for (int i = 0; i < dtListModule.Rows.Count; i++)
                {
                    string moduleCode = TextUtils.ToString(dtListModule.Rows[i]["ProjectModuleCode"]);
                    string group = moduleCode.Substring(0, 6);

                    #region Vật tư phụ của module
                    decimal qtyM = TextUtils.ToDecimal(dtListModule.Rows[i]["TotalReal"]);
                    string sql1 = "SELECT * FROM vPartsConfigLink where ModuleCode = '" + moduleCode + "'";
                    DataTable dtPartOfModule = LibQLSX.Select(sql1);
                    if (dtPartOfModule.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtPartOfModule.Rows)
                        {
                            string partsId = TextUtils.ToString(row["PartsGeneralId"]);
                            DataRow[] drs = dtData.Select("PartsId = '" + partsId + "'");
                            if (drs.Length > 0)
                            {
                                drs[0]["Qty"] = TextUtils.ToDecimal(drs[0]["Qty"]) + qtyM * TextUtils.ToDecimal(row["Qty"]);
                            }
                            else
                            {
                                DataRow nR = dtData.NewRow();
                                nR["PartsId"] = TextUtils.ToString(row["PartsGeneralId"]);
                                nR["PartsCode"] = TextUtils.ToString(row["PartsCode"]);
                                nR["PartsName"] = TextUtils.ToString(row["PartsName"]);
                                nR["Unit"] = TextUtils.ToString(row["Unit"]);
                                nR["ManufacturerCode"] = TextUtils.ToString(row["ManufacturerCode"]);
                                nR["Type"] = 2;
                                nR["Qty"] = qtyM * TextUtils.ToDecimal(row["Qty"]);
                                dtData.Rows.Add(nR);
                            }
                        }
                    }
                    else
                    {
                        string sqlGroup = "SELECT * FROM vPartsConfigLink where GroupCode = '" + group + "'";
                        DataTable dtPartOfGroup = LibQLSX.Select(sqlGroup);
                        foreach (DataRow row in dtPartOfGroup.Rows)
                        {
                            string partsId = TextUtils.ToString(row["PartsGeneralId"]);
                            DataRow[] drs = dtData.Select("PartsId = '" + partsId + "'");
                            if (drs.Length > 0)
                            {
                                drs[0]["Qty"] = TextUtils.ToDecimal(drs[0]["Qty"]) + qtyM * TextUtils.ToDecimal(row["Qty"]);
                            }
                            else
                            {
                                DataRow nR = dtData.NewRow();
                                nR["PartsId"] = TextUtils.ToString(row["PartsGeneralId"]);
                                nR["PartsCode"] = TextUtils.ToString(row["PartsCode"]);
                                nR["PartsName"] = TextUtils.ToString(row["PartsName"]);
                                nR["Unit"] = TextUtils.ToString(row["Unit"]);
                                nR["ManufacturerCode"] = TextUtils.ToString(row["ManufacturerCode"]);
                                nR["Type"] = 3;
                                nR["Qty"] = qtyM * TextUtils.ToDecimal(row["Qty"]);
                                dtData.Rows.Add(nR);
                            }
                        }
                    }
                    #endregion

                    #region Vật tư phụ cho vật tư không có trong danh mục vật tư thiết kế của module
                    DataTable dtlink = LibQLSX.Select("select * from vPartsNotDMVT where ModuleCode = '" + moduleCode + "'");
                    foreach (DataRow row in dtlink.Rows)
                    {
                        string partsId = TextUtils.ToString(row["PartsId"]);
                        DataRow[] drs = dtData.Select("PartsId = '" + partsId + "'");
                        if (drs.Length > 0)
                        {
                            drs[0]["Qty"] = TextUtils.ToDecimal(drs[0]["Qty"]) + qtyM * TextUtils.ToDecimal(row["Qty"]);
                        }
                        else
                        {
                            DataRow nR = dtData.NewRow();
                            nR["PartsId"] = TextUtils.ToString(row["PartsId"]);
                            nR["PartsCode"] = TextUtils.ToString(row["PartsCode"]);
                            nR["PartsName"] = TextUtils.ToString(row["PartsName"]);
                            nR["Unit"] = TextUtils.ToString(row["Unit"]);
                            nR["ManufacturerCode"] = TextUtils.ToString(row["ManufacturerCode"]);
                            nR["Type"] = 5;
                            nR["Qty"] = qtyM * TextUtils.ToDecimal(row["Qty"]);
                            dtData.Rows.Add(nR);
                        }
                    }
                    #endregion
                }
                #endregion

                foreach (DataRow r in dtData.Rows)
                {
                    string partsId = TextUtils.ToString(r["PartsId"]);
                    decimal qtyYC = TextUtils.ToDecimal(r["Qty"]);
                    DataTable dt = LibQLSX.Select("select top 1 * from PartsGeneral where PartsId = '" + partsId + "'");
                    decimal TonKhoTT = TextUtils.ToDecimal(dt.Rows[0]["Qty"]);
                    decimal SlHanMuc = TextUtils.ToDecimal(dt.Rows[0]["QtyDM"]);
                    decimal SlToiThieu = TextUtils.ToDecimal(dt.Rows[0]["QtyMin"]);

                    decimal SLxuat = TonKhoTT >= qtyYC ? qtyYC : TonKhoTT;

                    r["QtyTT"] = TonKhoTT;
                    r["QtyBuyKho"] = SLxuat < qtyYC ? SlToiThieu : ((TonKhoTT - SLxuat) > SlHanMuc ? 0 : SlToiThieu);
                    r["QtyBuyDA"] = SLxuat < qtyYC ? qtyYC - SLxuat : 0;
                    r["QtyXuat"] = SLxuat; 
                }

                grdData.DataSource = dtData;
            }
        }

        private void btnSetVTPtoProject_Click(object sender, EventArgs e)
        {
            string projectId = TextUtils.ToString(cboProject.EditValue);
            if (projectId == "")
            {
                MessageBox.Show("Bạn phải chọn một dự án.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            DataTable dtlink = LibQLSX.Select("select top 1 ID from PartsGeneralProjectLink where ProjectId = '" + projectId + "'");
            if (dtlink.Rows.Count > 0)
            {
                MessageBox.Show("Dự án này đã được phân bổ vật tư phụ.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (grvData.RowCount == 0)
            {
                MessageBox.Show("Khổng có vật tư phụ nào để chuyển cho dự án.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            for (int i = 0; i < grvData.RowCount; i++)
            {
                string partsId = TextUtils.ToString(grvData.GetRowCellValue(i, colPartsId));
                decimal qty = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colQty));

                PartsGeneralProjectLinkModel model = new PartsGeneralProjectLinkModel();
                model.ProjectId = projectId;
                model.PartsId = partsId;
                model.Qty = qty;
                model.QtyBuyDA = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colQtyBuyDA));
                model.QtyBuyKho = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colQtyBuyKho));
                model.QtyXuat = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colQtyXuat));
                PartsGeneralProjectLinkBO.Instance.Insert(model);

                //PartsGeneralModel g = (PartsGeneralModel)PartsGeneralBO.Instance.FindByAttribute("PartsId", partsId)[0];
                //g.Qty -= qty;
                //PartsGeneralBO.Instance.UpdateQLSX(g);
            }

            MessageBox.Show("Xác nhận vật tư phụ cho dự án thành công.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("CustID", typeof(int));
            dt1.Columns.Add("ColX", typeof(int));
            dt1.Columns.Add("ColY", typeof(int));

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("CustID", typeof(int));
            dt2.Columns.Add("ColZ", typeof(int));

            for (int i = 1; i <= 5; i++)
            {
                DataRow row = dt1.NewRow();
                row["CustID"] = i;
                row["ColX"] = 10 + i;
                row["ColY"] = 20 + i;
                dt1.Rows.Add(row);

                row = dt2.NewRow();
                row["CustID"] = i;
                row["ColZ"] = 30 + i;
                dt2.Rows.Add(row);
            }

            var results = from table1 in dt1.AsEnumerable()
                          join table2 in dt2.AsEnumerable() on (int)table1["CustID"] equals (int)table2["CustID"]
                          select new
                          {
                              CustID = (int)table1["CustID"],
                              ColX = (int)table1["ColX"] + 1,
                              ColY = (int)table1["ColY"] + 2,
                              ColZ = (int)table2["ColZ"] + 3
                          };    
            //DataTable dt = results.co
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
    }
}
