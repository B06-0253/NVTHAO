namespace BMS
{
    partial class frmVatTuThayThe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVatTuThayThe));
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.grvData = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colSTT = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colNgay = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colNameTK = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colCodeTK = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colHangTK = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colNameTT = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colCodeTT = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colHangTT = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colThuocThietBi = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colChiTietLienQuan = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colStatus = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colCodeAfter = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colNote = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.mnuMenu = new System.Windows.Forms.ToolStrip();
            this.btnDeleteGroup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.cboBang = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            this.mnuMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdData
            // 
            this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdData.Location = new System.Drawing.Point(0, 79);
            this.grdData.MainView = this.grvData;
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(1119, 395);
            this.grdData.TabIndex = 169;
            this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvData});
            // 
            // grvData
            // 
            this.grvData.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvData.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvData.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand2,
            this.gridBand3,
            this.gridBand4});
            this.grvData.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colNameTK,
            this.colCodeTK,
            this.colHangTK,
            this.colNameTT,
            this.colCodeTT,
            this.colNote,
            this.colCodeAfter,
            this.colStatus,
            this.colChiTietLienQuan,
            this.colThuocThietBi,
            this.colHangTT,
            this.colSTT,
            this.colNgay,
            this.colID});
            this.grvData.GridControl = this.grdData;
            this.grvData.Name = "grvData";
            this.grvData.NewItemRowText = "Thêm Vật Tư Mới Tại Đây";
            this.grvData.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvData.OptionsBehavior.Editable = false;
            this.grvData.OptionsFind.AlwaysVisible = true;
            this.grvData.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.grvData.OptionsView.ShowAutoFilterRow = true;
            this.grvData.OptionsView.ShowGroupPanel = false;
            this.grvData.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.grvData_ValidateRow);
            // 
            // gridBand1
            // 
            this.gridBand1.Columns.Add(this.colSTT);
            this.gridBand1.Columns.Add(this.colNgay);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.Width = 119;
            // 
            // colSTT
            // 
            this.colSTT.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colSTT.AppearanceHeader.Options.UseFont = true;
            this.colSTT.AppearanceHeader.Options.UseTextOptions = true;
            this.colSTT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSTT.Caption = "STT";
            this.colSTT.FieldName = "STT";
            this.colSTT.Name = "colSTT";
            this.colSTT.Visible = true;
            this.colSTT.Width = 24;
            // 
            // colNgay
            // 
            this.colNgay.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colNgay.AppearanceHeader.Options.UseFont = true;
            this.colNgay.AppearanceHeader.Options.UseTextOptions = true;
            this.colNgay.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNgay.Caption = "NGÀY";
            this.colNgay.DisplayFormat.FormatString = "d";
            this.colNgay.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgay.FieldName = "Ngay";
            this.colNgay.Name = "colNgay";
            this.colNgay.Visible = true;
            this.colNgay.Width = 95;
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand2.Caption = "CHI TIẾT THIẾT KẾ\t\t\r\n";
            this.gridBand2.Columns.Add(this.colNameTK);
            this.gridBand2.Columns.Add(this.colCodeTK);
            this.gridBand2.Columns.Add(this.colHangTK);
            this.gridBand2.MinWidth = 20;
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.Width = 223;
            // 
            // colNameTK
            // 
            this.colNameTK.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colNameTK.AppearanceHeader.Options.UseFont = true;
            this.colNameTK.AppearanceHeader.Options.UseTextOptions = true;
            this.colNameTK.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNameTK.Caption = "TÊN VẬT TƯ\r\n";
            this.colNameTK.FieldName = "NameTK";
            this.colNameTK.Name = "colNameTK";
            this.colNameTK.Visible = true;
            this.colNameTK.Width = 71;
            // 
            // colCodeTK
            // 
            this.colCodeTK.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCodeTK.AppearanceHeader.Options.UseFont = true;
            this.colCodeTK.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodeTK.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodeTK.Caption = "MÃ VẬT TƯ\r\n";
            this.colCodeTK.FieldName = "CodeTK";
            this.colCodeTK.Name = "colCodeTK";
            this.colCodeTK.Visible = true;
            this.colCodeTK.Width = 71;
            // 
            // colHangTK
            // 
            this.colHangTK.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colHangTK.AppearanceHeader.Options.UseFont = true;
            this.colHangTK.AppearanceHeader.Options.UseTextOptions = true;
            this.colHangTK.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHangTK.Caption = "HÃNG\r\n";
            this.colHangTK.FieldName = "HangTK";
            this.colHangTK.Name = "colHangTK";
            this.colHangTK.Visible = true;
            this.colHangTK.Width = 81;
            // 
            // gridBand3
            // 
            this.gridBand3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand3.Caption = "CHI TIẾT CÓ THỂ THAY THẾ\t\t\r\n";
            this.gridBand3.Columns.Add(this.colNameTT);
            this.gridBand3.Columns.Add(this.colCodeTT);
            this.gridBand3.Columns.Add(this.colHangTT);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.Width = 223;
            // 
            // colNameTT
            // 
            this.colNameTT.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colNameTT.AppearanceHeader.Options.UseFont = true;
            this.colNameTT.AppearanceHeader.Options.UseTextOptions = true;
            this.colNameTT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNameTT.Caption = "TÊN VẬT TƯ\r\n";
            this.colNameTT.FieldName = "NameTT";
            this.colNameTT.Name = "colNameTT";
            this.colNameTT.Visible = true;
            this.colNameTT.Width = 71;
            // 
            // colCodeTT
            // 
            this.colCodeTT.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCodeTT.AppearanceHeader.Options.UseFont = true;
            this.colCodeTT.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodeTT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodeTT.Caption = "MÃ VẬT TƯ\r\n";
            this.colCodeTT.FieldName = "CodeTT";
            this.colCodeTT.Name = "colCodeTT";
            this.colCodeTT.Visible = true;
            this.colCodeTT.Width = 71;
            // 
            // colHangTT
            // 
            this.colHangTT.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colHangTT.AppearanceHeader.Options.UseFont = true;
            this.colHangTT.AppearanceHeader.Options.UseTextOptions = true;
            this.colHangTT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHangTT.Caption = "HÃNG\r\n";
            this.colHangTT.FieldName = "HangTT";
            this.colHangTT.Name = "colHangTT";
            this.colHangTT.Visible = true;
            this.colHangTT.Width = 81;
            // 
            // gridBand4
            // 
            this.gridBand4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand4.Columns.Add(this.colThuocThietBi);
            this.gridBand4.Columns.Add(this.colChiTietLienQuan);
            this.gridBand4.Columns.Add(this.colStatus);
            this.gridBand4.Columns.Add(this.colCodeAfter);
            this.gridBand4.Columns.Add(this.colNote);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.Width = 445;
            // 
            // colThuocThietBi
            // 
            this.colThuocThietBi.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colThuocThietBi.AppearanceHeader.Options.UseFont = true;
            this.colThuocThietBi.AppearanceHeader.Options.UseTextOptions = true;
            this.colThuocThietBi.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colThuocThietBi.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colThuocThietBi.Caption = "MÃ THIẾT BỊ/ CỤM THIẾT BỊ\r\n\r\n";
            this.colThuocThietBi.FieldName = "ThuocThietBi";
            this.colThuocThietBi.Name = "colThuocThietBi";
            this.colThuocThietBi.Visible = true;
            this.colThuocThietBi.Width = 172;
            // 
            // colChiTietLienQuan
            // 
            this.colChiTietLienQuan.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colChiTietLienQuan.AppearanceHeader.Options.UseFont = true;
            this.colChiTietLienQuan.AppearanceHeader.Options.UseTextOptions = true;
            this.colChiTietLienQuan.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colChiTietLienQuan.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colChiTietLienQuan.Caption = "CÁC CỤM CHI TIẾT LIÊN QUAN\r\n\r\n";
            this.colChiTietLienQuan.FieldName = "ChiTietLienQuan";
            this.colChiTietLienQuan.Name = "colChiTietLienQuan";
            this.colChiTietLienQuan.Visible = true;
            this.colChiTietLienQuan.Width = 83;
            // 
            // colStatus
            // 
            this.colStatus.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colStatus.AppearanceHeader.Options.UseFont = true;
            this.colStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.colStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStatus.Caption = "TÌNH TRẠNG SAU KHI THAY THẾ";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.Width = 83;
            // 
            // colCodeAfter
            // 
            this.colCodeAfter.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCodeAfter.AppearanceHeader.Options.UseFont = true;
            this.colCodeAfter.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodeAfter.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodeAfter.Caption = "MÃ THIẾT BỊ SAU KHI THAY THẾ";
            this.colCodeAfter.FieldName = "CodeAfter";
            this.colCodeAfter.Name = "colCodeAfter";
            this.colCodeAfter.Visible = true;
            this.colCodeAfter.Width = 83;
            // 
            // colNote
            // 
            this.colNote.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colNote.AppearanceHeader.Options.UseFont = true;
            this.colNote.AppearanceHeader.Options.UseTextOptions = true;
            this.colNote.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNote.Caption = "GHI CHÚ\r\n\r\n";
            this.colNote.FieldName = "Note";
            this.colNote.Name = "colNote";
            this.colNote.Visible = true;
            this.colNote.Width = 24;
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // mnuMenu
            // 
            this.mnuMenu.AutoSize = false;
            this.mnuMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.mnuMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDeleteGroup,
            this.toolStripSeparator1,
            this.btnExcel,
            this.toolStripSeparator3,
            this.btnClose});
            this.mnuMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuMenu.Size = new System.Drawing.Size(1119, 42);
            this.mnuMenu.TabIndex = 170;
            this.mnuMenu.Text = "toolStrip2";
            // 
            // btnDeleteGroup
            // 
            this.btnDeleteGroup.AutoSize = false;
            this.btnDeleteGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteGroup.Image")));
            this.btnDeleteGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteGroup.Name = "btnDeleteGroup";
            this.btnDeleteGroup.Size = new System.Drawing.Size(95, 40);
            this.btnDeleteGroup.Tag = "frmVatTuThayThe_Delete";
            this.btnDeleteGroup.Text = "Xóa nhóm vật tư";
            this.btnDeleteGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDeleteGroup.Click += new System.EventHandler(this.btnDeleteGroup_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // btnExcel
            // 
            this.btnExcel.AutoSize = false;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(61, 40);
            this.btnExcel.Tag = "frmVatTuThayThe_ExportExcel";
            this.btnExcel.Text = "Xuất Excel";
            this.btnExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.AutoSize = false;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 40);
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = false;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(55, 40);
            this.btnClose.Text = "Thoát";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cboBang
            // 
            this.cboBang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBang.FormattingEnabled = true;
            this.cboBang.Items.AddRange(new object[] {
            "Vật tư ngừng sản xuất",
            "Vật tư thay thế theo tiến độ"});
            this.cboBang.Location = new System.Drawing.Point(5, 45);
            this.cboBang.Name = "cboBang";
            this.cboBang.Size = new System.Drawing.Size(306, 28);
            this.cboBang.TabIndex = 171;
            this.cboBang.SelectedIndexChanged += new System.EventHandler(this.cboBang_SelectedIndexChanged);
            // 
            // frmVatTuThayThe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 474);
            this.Controls.Add(this.cboBang);
            this.Controls.Add(this.mnuMenu);
            this.Controls.Add(this.grdData);
            this.Name = "frmVatTuThayThe";
            this.Text = "DANH MỤC MÃ VẬT TƯ THAY THẾ TRONG THIẾT KẾ\t\t\t\t\t\t\t\t\t\t\t\t\r\n";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmVatTuThayThe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView grvData;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colNameTK;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCodeTK;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colHangTK;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colNameTT;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCodeTT;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colHangTT;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colThuocThietBi;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colChiTietLienQuan;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colStatus;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCodeAfter;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colNote;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSTT;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colNgay;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private System.Windows.Forms.ToolStrip mnuMenu;
        private System.Windows.Forms.ToolStripButton btnDeleteGroup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnClose;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colID;
        private System.Windows.Forms.ComboBox cboBang;
    }
}