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
    public partial class frmSetPriceYCMVT : _Forms
    {
        DataTable _dtMaterial = new DataTable();

        public frmSetPriceYCMVT()
        {
            InitializeComponent();
        }

        private void frmSetPriceYCMVT_Load(object sender, EventArgs e)
        {
            loadYCMVT();
        }

        void loadYCMVT()
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ giây lát...", "Đang load dữ liệu..."))
            {
                if (Global.DepartmentID == 6) //phòng vật tư
                {
                    //DataTable dtYC = LibQLSX.Select("SELECT ProposalCode FROM vGetYCMVT where account = '" + Global.AppUserName + "' and status = 1 ORDER BY ProposalId desc");
                    DataTable dtYC = LibQLSX.Select("SELECT Distinct ProposalId, ProposalCode FROM vGetYCMVT where status = 1 ORDER BY ProposalId");
                    treePermission.DataSource = dtYC;
                    treePermission.KeyFieldName = "ProposalId";
                    treePermission.PreviewFieldName = "ProposalCode";
                }
            }
        }
        
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel|*.xlsx";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = ofd.FileName;
                _dtMaterial = TextUtils.ExcelToDatatableNoHeader(ofd.FileName, "Sheet1");
                _dtMaterial.Rows.RemoveAt(0);
                grdData.DataSource = _dtMaterial;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string listYCMVT = "";
            for (int i = 0; i < treePermission.Nodes.Count; i++)
            {
                if (treePermission.GetNodeByVisibleIndex(i).Checked)
                {                    
                    listYCMVT += TextUtils.ToString(treePermission.GetNodeByVisibleIndex(i).GetValue(colProposalCode)) + ",";
                }
            }

            listYCMVT = listYCMVT.Substring(0, listYCMVT.Length - 1);

            if (listYCMVT == "")
            {
                MessageBox.Show("Bạn phải chọn một ycmvt!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            string[] paraName = new string[1];
            object[] paraValue = new object[1];
            paraName[0] = "@ListYCMVT"; paraValue[0] = listYCMVT;
            
            DataTable Source1 = SuppliersBO.Instance.LoadDataFromSP("spGetPartWithYCMVT1", "Source1", paraName, paraValue);
            DataTable Source2 = SuppliersBO.Instance.LoadDataFromSP("spGetPartWithYCMVT2", "Source2", paraName, paraValue);
            DataTable Source3 = SuppliersBO.Instance.LoadDataFromSP("spGetPartWithYCMVT3", "Source3", paraName, paraValue);

            int rowCount = Source1.Rows.Count + Source2.Rows.Count + Source3.Rows.Count;
            int updateCount = 0;

            //Update cho yêu cầu mua vật tư của phòng thiết kế (có mã module)
            foreach (DataRow row in Source1.Rows)
            {
                string partCode = TextUtils.ToString(row["PartsCode"]);
                string requirePartsId = TextUtils.ToString(row["RequirePartsId"]);
                DataRow[] drs = _dtMaterial.Select("F1 = '" + partCode + "'");
                if (drs.Length > 0)
                {
                    string supplierId = "";
                    string supplierCode = TextUtils.ToString(drs[0]["F4"]);
                    if (supplierCode != "")
                    {
                        DataTable dtS = LibQLSX.Select("select top 1 [SupplierId] from [Suppliers] with(nolock) where [SupplierCode] = '" + supplierCode + "'");
                        if (dtS.Rows.Count > 0)
                        {
                            supplierId = TextUtils.ToString(dtS.Rows[0][0]);
                        }
                    }
                    RequirePartsModel re = (RequirePartsModel)RequirePartsBO.Instance.FindByPKStringID("RequirePartsId", requirePartsId);
                    re.Price = TextUtils.ToDecimal(drs[0]["F2"]);
                    re.DeliveryTime = TextUtils.ToInt(drs[0]["F3"]);
                    re.SupplierId = supplierId;
                    re.DateAboutE = DateTime.Now.AddDays(re.DeliveryTime);
                    RequirePartsBO.Instance.UpdateQLSX(re);
                    updateCount++;
                }
            }

            //Update cho các vật tư mua cho sản xuất chung không có mã module
            foreach (DataRow row in Source2.Rows)
            {
                string partCode = TextUtils.ToString(row["PartsCode"]);
                string requireMaterialId = TextUtils.ToString(row["RequireMaterialId"]);
                DataRow[] drs = _dtMaterial.Select("F1 = '" + partCode + "'");
                if (drs.Length > 0)
                {
                    string supplierId = "";
                    string supplierCode = TextUtils.ToString(drs[0]["F4"]);
                    if (supplierCode != "")
                    {
                        DataTable dtS = LibQLSX.Select("select top 1 [SupplierId] from [Suppliers] with(nolock) where [SupplierCode] = '" + supplierCode + "'");
                        if (dtS.Rows.Count > 0)
                        {
                            supplierId = TextUtils.ToString(dtS.Rows[0][0]);
                        }
                    }
                    RequireMaterialModel re = (RequireMaterialModel)RequireMaterialBO.Instance.FindByPKStringID("RequireMaterialId", requireMaterialId);
                    re.Price = TextUtils.ToDecimal(drs[0]["F2"]);
                    re.DeliveryTime = TextUtils.ToInt(drs[0]["F3"]);
                    re.SupplierId = supplierId;
                    re.DateAboutE = DateTime.Now.AddDays(re.DeliveryTime);
                    RequireMaterialBO.Instance.UpdateQLSX(re);
                    updateCount++;
                }
            }

            //update cho các vật tư xuất nhập thẳng
            foreach (DataRow row in Source3.Rows)
            {
                string partCode = TextUtils.ToString(row["PartsCode"]);
                string requireProductOutId = TextUtils.ToString(row["RequireProductOutId"]);
                DataRow[] drs = _dtMaterial.Select("F1 = '" + partCode + "'");
                if (drs.Length > 0)
                {
                    string supplierId = "";
                    string supplierCode = TextUtils.ToString(drs[0]["F4"]);
                    if (supplierCode != "")
                    {
                        DataTable dtS = LibQLSX.Select("select top 1 [SupplierId] from [Suppliers] with(nolock) where [SupplierCode] = '" + supplierCode + "'");
                        if (dtS.Rows.Count > 0)
                        {
                            supplierId = TextUtils.ToString(dtS.Rows[0][0]);
                        }
                    }

                    RequireProductOutModel re = (RequireProductOutModel)RequireProductOutBO.Instance.FindByPKStringID("RequireProductOutId", requireProductOutId);
                    re.Price = TextUtils.ToDecimal(drs[0]["F2"]);
                    re.DeliveryTime = TextUtils.ToInt(drs[0]["F3"]);
                    re.SupplierId = supplierId;
                    re.DateAboutE = DateTime.Now.AddDays(re.DeliveryTime);
                    RequireProductOutBO.Instance.UpdateQLSX(re);
                    updateCount++;
                }
            }

            MessageBox.Show("Đã hoàn thành update: " + updateCount + " trong tổng số: " + rowCount + " vật tư trong các YCMVT", 
                TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
