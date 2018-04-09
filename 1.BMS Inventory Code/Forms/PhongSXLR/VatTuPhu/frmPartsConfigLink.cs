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

namespace BMS
{
    public partial class frmPartsConfigLink : _Forms
    {
        DataTable _dtPartsGeneral = new DataTable();
        DataTable _dtListVT = new DataTable();
        public frmPartsConfigLink()
        {
            InitializeComponent();
        }

        private void frmPartsConfigLink_Load(object sender, EventArgs e)
        {
            _dtPartsGeneral = LibQLSX.Select("select *,Cast(0 as bit) as [Check] from vPartsGeneral");
            _dtListVT = LibQLSX.Select("select [PartsId],[PartsCode],[PartsName],[Unit],ManufacturerCode from [vParts] where PartsCode is not null or PartsCode <> ''");
            loadVT();
            _dtListVT.Columns.Add("Qty", typeof(decimal));
            _dtListVT.Columns.Add("Check", typeof(bool));
            loadVT1();
            loadVTP1(_dtPartsGeneral);
            loadVTP2(_dtPartsGeneral);
            loadVTP3(_dtPartsGeneral);
            loadModule();
            loadGroupModule();
        }

        void loadVTP1(DataTable dt)
        {
            grdVTP1.DataSource = dt.Copy();
        }
        void loadVTP2(DataTable dt)
        {
            grdVTP2.DataSource = dt.Copy();
        }
        void loadVTP3(DataTable dt)
        {
            grdVTP3.DataSource = dt.Copy();
        }
        
        void loadVT()
        {
            grdVT.DataSource = _dtListVT.Copy();
        }
        void loadVT1()
        {            
            grdVTofM.DataSource = _dtListVT.Copy();
        }
        void loadModule()
        {
            DataTable dt = LibQLSX.Select("select * from SourceCode with(nolock) where FolderCode like 'tpad.%' order by FolderCode");
            grdModule.DataSource = dt;
            grdModule1.DataSource = dt;
        }
        void loadGroupModule()
        {
            DataTable dt = LibQLSX.Select("select * from Groups with(nolock) where groupcode like '%tpad.%' order by GroupCode");
            grdGroup.DataSource = dt;
        }
        
        void loadVTLink()
        {
            string partsId = TextUtils.ToString(grvVT.GetFocusedRowCellValue("PartsId"));
            DataTable dtlink = LibQLSX.Select("select * from vPartsConfigLink where Type = 1 and PartsId = '" + partsId + "'");
            grdVTLink.DataSource = dtlink;
        }
        void loadModuleLink()
        {
            string moduleCode = TextUtils.ToString(grvModule.GetFocusedRowCellValue("FolderCode"));
            DataTable dtlink = LibQLSX.Select("select * from vPartsConfigLink where Type = 2 and ModuleCode = '" + moduleCode + "'");
            grdModuleLink.DataSource = dtlink;
        }
        void loadGroupLink()
        {
            string groupCode = TextUtils.ToString(grvGroup.GetFocusedRowCellValue("GroupCode"));
            DataTable dtlink = LibQLSX.Select("select * from vPartsConfigLink where Type = 3 and GroupCode = '" + groupCode + "'");
            grdGroupLink.DataSource = dtlink;
        }
        void loadPartsNotDMVT()
        {
            string moduleCode = TextUtils.ToString(grvModule1.GetFocusedRowCellValue("FolderCode"));
            DataTable dtlink = LibQLSX.Select("select * from vPartsNotDMVT where ModuleCode = '" + moduleCode + "'");
            grdLink.DataSource = dtlink;
        }

        private void grvVT_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            loadVTLink();
        }

        private void grvModule_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            loadModuleLink();
        }

        private void grvGroup_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            loadGroupLink();
        }

        private void grvModule1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            loadPartsNotDMVT();
        }       

        private void btnAddVtLink_Click(object sender, EventArgs e)
        {
            grvVTP1.FocusedRowHandle = -1;
            string partsId = TextUtils.ToString(grvVT.GetFocusedRowCellValue("PartsId"));
            if (partsId == "") return;
            DataTable dt = (DataTable)grdVTP1.DataSource;
            DataRow[] drsQty = dt.Select("Check = 1 and (Qty = 0 or Qty is null)");
            if (drsQty.Length > 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng vật tư phụ",TextUtils.Caption,MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return;
            }
            DataRow[] drs = dt.Select("Check = 1");
            for (int i = 0; i < drs.Length; i++)
            {
                decimal qty = TextUtils.ToDecimal(drs[i]["Qty"]);
                if (qty == 0) continue;
                string partsGeneralId = TextUtils.ToString(drs[i]["PartsId"]);
                DataTable dtLink = LibQLSX.Select("select top 1 ID from PartsConfigLink where PartsGeneralId='" + partsGeneralId + "' and PartsId='" + partsId + "'");
                if (dtLink.Rows.Count > 0) continue;
                PartsConfigLinkModel pcl = new PartsConfigLinkModel();
                pcl.PartsGeneralId = partsGeneralId;
                pcl.PartsId = partsId;
                pcl.Qty = qty;
                pcl.Type = 1;
                PartsConfigLinkBO.Instance.Insert(pcl);
            }
            loadVTLink();
            loadVTP1(_dtPartsGeneral);
        }

        private void btnAddModuleLink_Click(object sender, EventArgs e)
        {
            grvVTP2.FocusedRowHandle = -1;
            string folderCode = TextUtils.ToString(grvModule.GetFocusedRowCellValue("FolderCode"));
            if (folderCode == "") return;
            DataTable dt = (DataTable)grdVTP2.DataSource;
            DataRow[] drsQty = dt.Select("Check = 1 and (Qty = 0 or Qty is null)");
            if (drsQty.Length > 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng vật tư phụ", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            DataRow[] drs = dt.Select("Check = 1");
            for (int i = 0; i < drs.Length; i++)
            {
                decimal qty = TextUtils.ToDecimal(drs[i]["Qty"]);
                if (qty == 0) continue;
                string partsGeneralId = TextUtils.ToString(drs[i]["PartsId"]);
                DataTable dtLink = LibQLSX.Select("select top 1 ID from PartsConfigLink where PartsGeneralId='" + partsGeneralId + "' and ModuleCode='" + folderCode + "'");
                if (dtLink.Rows.Count > 0) continue;
                PartsConfigLinkModel pcl = new PartsConfigLinkModel();
                pcl.PartsGeneralId = partsGeneralId;
                pcl.ModuleCode = folderCode;
                pcl.Qty = qty;
                pcl.Type = 2;
                PartsConfigLinkBO.Instance.Insert(pcl);
            }
            loadModuleLink();
            loadVTP2(_dtPartsGeneral);
        }

        private void btnAddGroupLink_Click(object sender, EventArgs e)
        {
            grvVTP3.FocusedRowHandle = -1;
            string groupCode = TextUtils.ToString(grvGroup.GetFocusedRowCellValue("GroupCode"));
            if (groupCode == "") return;
            DataTable dt = (DataTable)grdVTP3.DataSource;
            DataRow[] drsQty = dt.Select("Check = 1 and (Qty = 0 or Qty is null)");
            if (drsQty.Length > 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng vật tư phụ", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            DataRow[] drs = dt.Select("Check = 1");
            for (int i = 0; i < drs.Length; i++)
            {
                decimal qty = TextUtils.ToDecimal(drs[i]["Qty"]);
                if (qty == 0) continue;
                string partsGeneralId = TextUtils.ToString(drs[i]["PartsId"]);
                DataTable dtLink = LibQLSX.Select("select top 1 ID from PartsConfigLink where PartsGeneralId='" + partsGeneralId + "' and GroupCode ='" + groupCode + "'");
                if (dtLink.Rows.Count > 0) continue;
                PartsConfigLinkModel pcl = new PartsConfigLinkModel();
                pcl.PartsGeneralId = partsGeneralId;
                pcl.GroupCode = groupCode;
                pcl.Qty = qty;
                pcl.Type = 3;
                PartsConfigLinkBO.Instance.Insert(pcl);
            }
            loadGroupLink();
            loadVTP3(_dtPartsGeneral);
        }

        private void btnAddVTofM_Click(object sender, EventArgs e)
        {
            grvVTofM.FocusedRowHandle = -1;
            string folderCode = TextUtils.ToString(grvModule1.GetFocusedRowCellValue("FolderCode"));
            if (folderCode == "") return;
            DataTable dt = (DataTable)grdVTofM.DataSource;
            DataRow[] drsQty = dt.Select("Check = 1 and (Qty = 0 or Qty is null)");
            if (drsQty.Length > 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng vật tư", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            DataRow[] drs = dt.Select("Check = 1");
            for (int i = 0; i < drs.Length; i++)
            {
                decimal qty = TextUtils.ToDecimal(drs[i]["Qty"]);
                if (qty == 0) continue;
                string partsId = TextUtils.ToString(drs[i]["PartsId"]);
                DataTable dtLink = LibQLSX.Select("select top 1 ID from PartsNotDMVT where PartsId='" + partsId + "' and ModuleCode='" + folderCode + "'");
                if (dtLink.Rows.Count > 0) continue;
                PartsNotDMVTModel pcl = new PartsNotDMVTModel();
                pcl.PartsId = partsId;
                pcl.ModuleCode = folderCode;
                pcl.Qty = qty;
                PartsNotDMVTBO.Instance.Insert(pcl);
            }
            loadPartsNotDMVT();
            loadVT1();
        }

        private void btnDeleteVT_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvVTLink.GetFocusedRowCellValue("ID"));
            if (id == 0) return;
            string code = TextUtils.ToString(grvVTLink.GetFocusedRowCellValue("PartsCode"));
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa vật tư '" + code + "'", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;
            PartsConfigLinkBO.Instance.Delete(id);
            loadVTLink();
        }

        private void btnDeleteModule_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvModuleLink.GetFocusedRowCellValue("ID"));
            if (id == 0) return;
            string code = TextUtils.ToString(grvModuleLink.GetFocusedRowCellValue("PartsCode"));
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa vật tư '" + code + "'", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;
            PartsConfigLinkBO.Instance.Delete(id);
            loadModuleLink();
        }

        private void btnDeleteGroup_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvGroupLink.GetFocusedRowCellValue("ID"));
            if (id == 0) return;
            string code = TextUtils.ToString(grvGroupLink.GetFocusedRowCellValue("PartsCode"));
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa vật tư '" + code + "'", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;
            PartsConfigLinkBO.Instance.Delete(id);
            loadGroupLink();
        }

        private void btnDeleteNotDMVT_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvLink.GetFocusedRowCellValue("ID"));
            if (id == 0) return;
            string code = TextUtils.ToString(grvGroupLink.GetFocusedRowCellValue("PartsCode"));
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa vật tư '" + code + "'", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;
            PartsNotDMVTBO.Instance.Delete(id);
            loadPartsNotDMVT();
        }
    }
}
