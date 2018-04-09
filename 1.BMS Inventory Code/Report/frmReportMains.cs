using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BaseBusiness;
using BMS;
using BMS.Utils;
using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;
namespace BMS
{
    public partial class frmReportMains : _Forms
    {
        public frmReportMains()
        {
            InitializeComponent();
        }

        private void frmReportMains_Load(object sender, EventArgs e)
        {
            //BMS.Permissions.LoadFormPermission(this);
            //nbgSPBH.Expanded = true;
            //nbgTTHD.Expanded = true;
            //nbgKTHD.Expanded = true;
            //navBarGroup1.Expanded = true;
            SetMainView();
        }

        #region Các sụ kiện liên quan đến phím tắt.
        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
            //bool handled = false;
            //ShortcutKey.LoadFormShortcutKey(this, keyData.ToString(), ref handled);
            ////return base.ProcessCmdKey(ref msg, keyData);
            //return (handled || base.ProcessCmdKey(ref msg, keyData)); 
        //}
        #endregion

        private void SetMainView()
        {
            switch (TextUtils.ToInt(Global.MainViewID))
            {
                //case 2:
                //    NavGroupKeToan.Expanded = true;
                //    break;
                //case 4:
                //    navGroupKho.Expanded = true;
                //    break;
                default:
                    navGroupKho.Expanded = true;
                    break;
            }
        }
        private void CallReport(UserControl ucBC, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //SetLinkFontToBold(e.Link.ItemName);
            //this.Text = e.Link.Item.Caption;
            //Cursor = Cursors.WaitCursor;
            //pnReports.Controls.Clear();
            //pnReports.Controls.Add(ucBC); 
            //ucBC.Dock = DockStyle.Fill;

            //Cursor = Cursors.Default;

            Cursor = Cursors.WaitCursor;
            //pnReports.Controls.Clear();
            //pnReports.Controls.Add(ucBC); 
            //ucBC.Dock = DockStyle.Fill;
            string Text =  e.Link.Item.Caption.Replace("Báo cáo ", "").Trim();
            Text= TextUtils.ToUpperFC(Text);
            TabCreating(xtraTabControl1,Text, e.Link.ItemName, ucBC, e);

            Cursor = Cursors.Default;
        }
        private void TabCreating(DevExpress.XtraTab.XtraTabControl tabControl, string Text, string Name, UserControl uc, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            int index = CheckTabExits(tabControl, Name);
            if (index >= 0)
            {
                tabControl.TabPages[index].PageVisible = true;
                tabControl.SelectedTabPage = tabControl.TabPages[index];
                tabControl.SelectedTabPage.Text = Text;
                uc.Dispose();
                uc = null;
            }
            else
            {
                DevExpress.XtraTab.XtraTabPage tabpage = new DevExpress.XtraTab.XtraTabPage { Text = Text, Name = Name, ImageIndex = 0 };
                tabpage.Image = e.Link.Item.SmallImage;
                tabControl.TabPages.Add(tabpage);
                tabControl.SelectedTabPage = tabpage;

                //uc.TopLevel = false;
                uc.Parent = tabpage;
                uc.Show();
                uc.Dock = DockStyle.Fill;
            }
        }

        static int CheckTabExits(DevExpress.XtraTab.XtraTabControl tabControlName, string tabName)
        {
            int re = -1;
            for (int i = 0; i < tabControlName.TabPages.Count; i++)
            {
                if (tabControlName.TabPages[i].Name == tabName)
                {
                    re = i;
                    break;
                }
            }
            return re;
        }
         private void SetLinkFontToBold(string strLinkName)
        {
            foreach (DevExpress.XtraNavBar.NavBarGroup _navBarGroup in navBarControl1.Groups)
            {
                foreach (DevExpress.XtraNavBar.NavBarItemLink item in _navBarGroup.ItemLinks)
                {
                    if (item.Item.Name.ToString().Equals(strLinkName))
                    {
                        item.Item.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
                        item.Item.Appearance.Options.UseFont = true;
                    }
                    else
                    {
                        item.Item.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular);
                        item.Item.Appearance.Options.UseFont = false;
                    }
                }
            }
        }

         private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
         {
             //DevExpress.XtraTab.XtraTabControl xtab = (DevExpress.XtraTab.XtraTabControl)sender;
             //int i = xtab.SelectedTabPageIndex;

             XtraTabControl tabControl = sender as XtraTabControl;
             ClosePageButtonEventArgs arg = e as ClosePageButtonEventArgs;
             XtraTabPage tabPage = arg.Page as XtraTabPage;
             int i = tabControl.SelectedTabPageIndex;
             if (tabControl.SelectedTabPage == tabPage)
                 tabControl.SelectedTabPageIndex = i - 1;
             tabPage.PageVisible = false;
             //xtab.SelectedTabPageIndex = i - 1;

         }

         private void lnk_DanhSachHopDong_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
         {
             //CallReport(new Report.ucBC_TongHopDoanhSoTheoLoaiMH(), e);
         }

         private void navBCTongHopTonKho_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
         {
             //CallReport(new frmReportInventorySummary(), e);
         }

         private void navBCTheoDoiMuaHang_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
         {
             //CallReport(new frmReportImportOrderMonitor(), e);
         }

         private void navBangKePhieuNhap_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
         {
             //CallReport(new Uc_rpt_ImportInvMaterial(), e);
         }

         private void navBangKePhieuXuat_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
         {
             //CallReport(new Uc_rpt_ExportInv(), e);
         }

         private void navBangKePhieuLuuChuyen_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
         {
             //CallReport(new Uc_rpt_TransferInv(), e);
         }

         private void navBaoCaoVatTuThayThe_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
         {
             //CallReport(new Uc_rpt_ReuseQuantity(), e);
         }

         private void navBaoCaoTonKhoToiThieu_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
         {
             //CallReport(new Uc_rpt_CompareInvMaxMin(), e);
         }

         private void navMaterialHistory_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
         {
             //CallReport(new Uc_rpt_InvMaterialHistory(), e);
         }

         private void navExport_Transfer_Inv_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
         {
             //CallReport(new Uc_rpt_Export_Transfer_Inv(), e);
         }

         private void navBarItem5_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
         {
             //CallReport(new Uc_rpt_ImportMaterialSummary(), e);
         }

         private void navBarItem6_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
         {
             //CallReport(new Uc_rpt_ExportMaterialSummary(), e);
         }

         private void navInventoryWarning_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
         {
             //CallReport(new UC_Rpt_InventoryWarning(), e);
         }
       
    }
}