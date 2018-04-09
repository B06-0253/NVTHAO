namespace BMS
{
    partial class frmReportMains
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportMains));
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navGroupKho = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBCTongHopTonKho = new DevExpress.XtraNavBar.NavBarItem();
            this.navBCTheoDoiMuaHang = new DevExpress.XtraNavBar.NavBarItem();
            this.navBangKePhieuNhap = new DevExpress.XtraNavBar.NavBarItem();
            this.navBangKePhieuXuat = new DevExpress.XtraNavBar.NavBarItem();
            this.navBangKePhieuLuuChuyen = new DevExpress.XtraNavBar.NavBarItem();
            this.navBaoCaoVatTuThayThe = new DevExpress.XtraNavBar.NavBarItem();
            this.navBaoCaoTonKhoToiThieu = new DevExpress.XtraNavBar.NavBarItem();
            this.navMaterialHistory = new DevExpress.XtraNavBar.NavBarItem();
            this.navExport_Transfer_Inv = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem5 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem6 = new DevExpress.XtraNavBar.NavBarItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lnk_DanhSachHopDong = new DevExpress.XtraNavBar.NavBarItem();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.navInventoryWarning = new DevExpress.XtraNavBar.NavBarItem();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navGroupKho;
            this.navBarControl1.ContentButtonHint = null;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navGroupKho});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBCTongHopTonKho,
            this.navBCTheoDoiMuaHang,
            this.navBangKePhieuNhap,
            this.navBangKePhieuXuat,
            this.navBangKePhieuLuuChuyen,
            this.navBaoCaoVatTuThayThe,
            this.navBaoCaoTonKhoToiThieu,
            this.navMaterialHistory,
            this.navExport_Transfer_Inv,
            this.navBarItem5,
            this.navBarItem6,
            this.navInventoryWarning});
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.LookAndFeel.SkinName = "Black";
            this.navBarControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 268;
            this.navBarControl1.Size = new System.Drawing.Size(212, 713);
            this.navBarControl1.TabIndex = 113;
            this.navBarControl1.Text = "navBarControl1";
            this.navBarControl1.View = new DevExpress.XtraNavBar.ViewInfo.StandardSkinNavigationPaneViewInfoRegistrator("DevExpress Style");
            // 
            // navGroupKho
            // 
            this.navGroupKho.Caption = "Báo cáo quản lý kho";
            this.navGroupKho.Expanded = true;
            this.navGroupKho.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBCTongHopTonKho),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBCTheoDoiMuaHang),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBangKePhieuNhap),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBangKePhieuXuat),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBangKePhieuLuuChuyen),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBaoCaoVatTuThayThe),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBaoCaoTonKhoToiThieu),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navMaterialHistory),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navExport_Transfer_Inv),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem5),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem6),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navInventoryWarning)});
            this.navGroupKho.LargeImage = ((System.Drawing.Image)(resources.GetObject("navGroupKho.LargeImage")));
            this.navGroupKho.Name = "navGroupKho";
            // 
            // navBCTongHopTonKho
            // 
            this.navBCTongHopTonKho.Caption = "Báo cáo tổng hợp tồn kho";
            this.navBCTongHopTonKho.Name = "navBCTongHopTonKho";
            this.navBCTongHopTonKho.Tag = "Rpt_BaoCaoTonKho";
            this.navBCTongHopTonKho.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBCTongHopTonKho_LinkClicked);
            // 
            // navBCTheoDoiMuaHang
            // 
            this.navBCTheoDoiMuaHang.Caption = "Báo cáo theo dõi mua hàng";
            this.navBCTheoDoiMuaHang.Name = "navBCTheoDoiMuaHang";
            this.navBCTheoDoiMuaHang.Tag = "Rpt_BaoCaoTheoDoiMuaHang";
            this.navBCTheoDoiMuaHang.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBCTheoDoiMuaHang_LinkClicked);
            // 
            // navBangKePhieuNhap
            // 
            this.navBangKePhieuNhap.Caption = "Bảng kê phiếu nhập";
            this.navBangKePhieuNhap.Name = "navBangKePhieuNhap";
            this.navBangKePhieuNhap.Tag = "Rpt_BangKePhieuNhap";
            this.navBangKePhieuNhap.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBangKePhieuNhap_LinkClicked);
            // 
            // navBangKePhieuXuat
            // 
            this.navBangKePhieuXuat.Caption = "Bảng kê phiếu xuất";
            this.navBangKePhieuXuat.Name = "navBangKePhieuXuat";
            this.navBangKePhieuXuat.Tag = "Rpt_BangKePhieuXuat";
            this.navBangKePhieuXuat.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBangKePhieuXuat_LinkClicked);
            // 
            // navBangKePhieuLuuChuyen
            // 
            this.navBangKePhieuLuuChuyen.Caption = "Bảng kê phiếu lưu chuyển";
            this.navBangKePhieuLuuChuyen.Name = "navBangKePhieuLuuChuyen";
            this.navBangKePhieuLuuChuyen.Tag = "Rpt_BangKeLuuChuyen";
            this.navBangKePhieuLuuChuyen.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBangKePhieuLuuChuyen_LinkClicked);
            // 
            // navBaoCaoVatTuThayThe
            // 
            this.navBaoCaoVatTuThayThe.Caption = "Báo cáo vật tư thay thế";
            this.navBaoCaoVatTuThayThe.Name = "navBaoCaoVatTuThayThe";
            this.navBaoCaoVatTuThayThe.Tag = "Rpt_BaoCaoVatTuThayThe";
            this.navBaoCaoVatTuThayThe.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBaoCaoVatTuThayThe_LinkClicked);
            // 
            // navBaoCaoTonKhoToiThieu
            // 
            this.navBaoCaoTonKhoToiThieu.Caption = "Báo cáo tồn kho tối thiểu, tốn đa";
            this.navBaoCaoTonKhoToiThieu.Name = "navBaoCaoTonKhoToiThieu";
            this.navBaoCaoTonKhoToiThieu.Tag = "Rpt_BaoCaoTonKhoToiThieu";
            this.navBaoCaoTonKhoToiThieu.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBaoCaoTonKhoToiThieu_LinkClicked);
            // 
            // navMaterialHistory
            // 
            this.navMaterialHistory.Caption = "Tra cứu lịch sử vật tư";
            this.navMaterialHistory.Name = "navMaterialHistory";
            this.navMaterialHistory.Tag = "Rpt_TraCuuLichSuVatTu";
            this.navMaterialHistory.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navMaterialHistory_LinkClicked);
            // 
            // navExport_Transfer_Inv
            // 
            this.navExport_Transfer_Inv.Caption = "Bảng kê phiếu xuất, lưu chuyển";
            this.navExport_Transfer_Inv.Name = "navExport_Transfer_Inv";
            this.navExport_Transfer_Inv.Tag = "Rpt_BangKePhieuXuat_LuuChuyen";
            this.navExport_Transfer_Inv.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navExport_Transfer_Inv_LinkClicked);
            // 
            // navBarItem5
            // 
            this.navBarItem5.Caption = "Tổng hợp cấp vật tư";
            this.navBarItem5.Name = "navBarItem5";
            this.navBarItem5.Tag = "Rpt_TongHopCapVatTu";
            this.navBarItem5.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem5_LinkClicked);
            // 
            // navBarItem6
            // 
            this.navBarItem6.Caption = "Tổng hợp nhập vật tư";
            this.navBarItem6.Name = "navBarItem6";
            this.navBarItem6.Tag = "Rpt_TongHopNhapVatTu";
            this.navBarItem6.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem6_LinkClicked);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 713);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(967, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 115;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lnk_DanhSachHopDong
            // 
            this.lnk_DanhSachHopDong.Caption = "Danh sách hợp đồng";
            this.lnk_DanhSachHopDong.Name = "lnk_DanhSachHopDong";
            this.lnk_DanhSachHopDong.Tag = "";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageHeader;
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(751, 713);
            this.xtraTabControl1.TabIndex = 116;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1});
            this.xtraTabControl1.CloseButtonClick += new System.EventHandler(this.xtraTabControl1_CloseButtonClick);
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(745, 687);
            this.xtraTabPage1.Text = " ";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.navBarControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.xtraTabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(967, 713);
            this.splitContainer1.SplitterDistance = 212;
            this.splitContainer1.TabIndex = 117;
            // 
            // navInventoryWarning
            // 
            this.navInventoryWarning.Caption = "Cảnh báo tồn kho";
            this.navInventoryWarning.Name = "navInventoryWarning";
            this.navInventoryWarning.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navInventoryWarning_LinkClicked);
            // 
            // frmReportMains
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 735);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReportMains";
            this.Text = "Báo cáo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReportMains_Load);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private DevExpress.XtraNavBar.NavBarItem lnk_DanhSachHopDong;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraNavBar.NavBarGroup navGroupKho;
        private DevExpress.XtraNavBar.NavBarItem navBCTongHopTonKho;
        private DevExpress.XtraNavBar.NavBarItem navBCTheoDoiMuaHang;
        private DevExpress.XtraNavBar.NavBarItem navBangKePhieuNhap;
        private DevExpress.XtraNavBar.NavBarItem navBangKePhieuXuat;
        private DevExpress.XtraNavBar.NavBarItem navBangKePhieuLuuChuyen;
        private DevExpress.XtraNavBar.NavBarItem navBaoCaoVatTuThayThe;
        private DevExpress.XtraNavBar.NavBarItem navBaoCaoTonKhoToiThieu;
        private DevExpress.XtraNavBar.NavBarItem navMaterialHistory;
        private DevExpress.XtraNavBar.NavBarItem navExport_Transfer_Inv;
        private DevExpress.XtraNavBar.NavBarItem navBarItem5;
        private DevExpress.XtraNavBar.NavBarItem navBarItem6;
        private DevExpress.XtraNavBar.NavBarItem navInventoryWarning;
    }
}