namespace BMS
{
    partial class frmMainVatTu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainVatTu));
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.grvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTenVatTu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colMaVatTu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaSP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenDuAn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaDuAn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayYeuCau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colNgayVeDuKien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayThucTe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThoiGianDatHangTHucTe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNguyenNhanCham = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNguoiYeuCau = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayVeDuKien2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayVeDuKien3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.popupNotifier1 = new NotificationWindow.PopupNotifier();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mởGiaoDiệnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMenu = new System.Windows.Forms.ToolStrip();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSua = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnXoa = new System.Windows.Forms.ToolStripButton();
            this.btnGhi = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnHuy = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnMoi = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colNguoiYeuCau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.mnuMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdData
            // 
            this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdData.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdData.Location = new System.Drawing.Point(0, 45);
            this.grdData.MainView = this.grvData;
            this.grdData.Name = "grdData";
            this.grdData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.repositoryItemTextEdit1,
            this.colNguoiYeuCau,
            this.repositoryItemMemoEdit1});
            this.grdData.Size = new System.Drawing.Size(1028, 341);
            this.grdData.TabIndex = 15;
            this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvData});
            this.grdData.DataSourceChanged += new System.EventHandler(this.grdData_DataSourceChanged);
            this.grdData.Click += new System.EventHandler(this.grdData_Click);
            // 
            // grvData
            // 
            this.grvData.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvData.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvData.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvData.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grvData.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvData.Appearance.Row.Options.UseTextOptions = true;
            this.grvData.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grvData.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvData.ColumnPanelRowHeight = 50;
            this.grvData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTenVatTu,
            this.colMaVatTu,
            this.colHang,
            this.colMaSP,
            this.colTenDuAn,
            this.colMaDuAn,
            this.colSoLuong,
            this.colNgayYeuCau,
            this.colNgayVeDuKien,
            this.colNgayThucTe,
            this.colThoiGianDatHangTHucTe,
            this.colNguyenNhanCham,
            this.colGhiChu,
            this.colID,
            this.colUserID,
            this.colSTT,
            this.colStatus,
            this.colNgayVeDuKien2,
            this.colNgayVeDuKien3,
            this.colYear,
            this.colMonth});
            this.grvData.GridControl = this.grdData;
            this.grvData.GroupCount = 2;
            this.grvData.Name = "grvData";
            this.grvData.OptionsFind.AlwaysVisible = true;
            this.grvData.OptionsView.AllowHtmlDrawHeaders = true;
            this.grvData.OptionsView.ColumnAutoWidth = false;
            this.grvData.OptionsView.RowAutoHeight = true;
            this.grvData.OptionsView.ShowGroupPanel = false;
            this.grvData.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colYear, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colMonth, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvData.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grvData_CustomDrawCell);
            this.grvData.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvData_FocusedRowChanged);
            this.grvData.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvData_CellValueChanged);
            this.grvData.Click += new System.EventHandler(this.grvData_Click);
            this.grvData.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.grvData_ValidatingEditor);
            // 
            // colTenVatTu
            // 
            this.colTenVatTu.AppearanceCell.Options.UseTextOptions = true;
            this.colTenVatTu.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTenVatTu.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTenVatTu.AppearanceHeader.Options.UseFont = true;
            this.colTenVatTu.AppearanceHeader.Options.UseTextOptions = true;
            this.colTenVatTu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTenVatTu.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTenVatTu.Caption = "Tên vật tư";
            this.colTenVatTu.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colTenVatTu.FieldName = "TenVatTu";
            this.colTenVatTu.Name = "colTenVatTu";
            this.colTenVatTu.Visible = true;
            this.colTenVatTu.VisibleIndex = 2;
            this.colTenVatTu.Width = 58;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // colMaVatTu
            // 
            this.colMaVatTu.AppearanceCell.Options.UseTextOptions = true;
            this.colMaVatTu.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMaVatTu.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMaVatTu.AppearanceHeader.Options.UseFont = true;
            this.colMaVatTu.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaVatTu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaVatTu.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colMaVatTu.Caption = "Mã vật tư";
            this.colMaVatTu.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colMaVatTu.FieldName = "MaVatTu";
            this.colMaVatTu.Name = "colMaVatTu";
            this.colMaVatTu.Visible = true;
            this.colMaVatTu.VisibleIndex = 1;
            this.colMaVatTu.Width = 73;
            // 
            // colHang
            // 
            this.colHang.AppearanceCell.Options.UseTextOptions = true;
            this.colHang.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHang.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colHang.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colHang.AppearanceHeader.Options.UseFont = true;
            this.colHang.AppearanceHeader.Options.UseTextOptions = true;
            this.colHang.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHang.Caption = "Hãng";
            this.colHang.FieldName = "Hang";
            this.colHang.Name = "colHang";
            this.colHang.Visible = true;
            this.colHang.VisibleIndex = 3;
            this.colHang.Width = 58;
            // 
            // colMaSP
            // 
            this.colMaSP.AppearanceCell.Options.UseTextOptions = true;
            this.colMaSP.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaSP.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMaSP.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMaSP.AppearanceHeader.Options.UseFont = true;
            this.colMaSP.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaSP.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaSP.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colMaSP.Caption = "Mã sản phẩm";
            this.colMaSP.FieldName = "MaSP";
            this.colMaSP.Name = "colMaSP";
            this.colMaSP.Visible = true;
            this.colMaSP.VisibleIndex = 4;
            this.colMaSP.Width = 58;
            // 
            // colTenDuAn
            // 
            this.colTenDuAn.AppearanceCell.Options.UseTextOptions = true;
            this.colTenDuAn.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTenDuAn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTenDuAn.AppearanceHeader.Options.UseFont = true;
            this.colTenDuAn.AppearanceHeader.Options.UseTextOptions = true;
            this.colTenDuAn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTenDuAn.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTenDuAn.Caption = "Tên dự án";
            this.colTenDuAn.FieldName = "TenDuAn";
            this.colTenDuAn.Name = "colTenDuAn";
            this.colTenDuAn.Visible = true;
            this.colTenDuAn.VisibleIndex = 5;
            this.colTenDuAn.Width = 58;
            // 
            // colMaDuAn
            // 
            this.colMaDuAn.AppearanceCell.Options.UseTextOptions = true;
            this.colMaDuAn.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMaDuAn.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMaDuAn.AppearanceHeader.Options.UseFont = true;
            this.colMaDuAn.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaDuAn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaDuAn.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colMaDuAn.Caption = "Mã dự án";
            this.colMaDuAn.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colMaDuAn.FieldName = "MaDuAn";
            this.colMaDuAn.Name = "colMaDuAn";
            this.colMaDuAn.Visible = true;
            this.colMaDuAn.VisibleIndex = 6;
            this.colMaDuAn.Width = 58;
            // 
            // colSoLuong
            // 
            this.colSoLuong.AppearanceCell.Options.UseTextOptions = true;
            this.colSoLuong.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSoLuong.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colSoLuong.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colSoLuong.AppearanceHeader.Options.UseFont = true;
            this.colSoLuong.AppearanceHeader.Options.UseTextOptions = true;
            this.colSoLuong.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSoLuong.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colSoLuong.Caption = "Số lượng";
            this.colSoLuong.DisplayFormat.FormatString = "{0:0.##}";
            this.colSoLuong.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSoLuong.FieldName = "SoLuong";
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.OptionsColumn.FixedWidth = true;
            this.colSoLuong.Visible = true;
            this.colSoLuong.VisibleIndex = 7;
            this.colSoLuong.Width = 40;
            // 
            // colNgayYeuCau
            // 
            this.colNgayYeuCau.AppearanceCell.Options.UseTextOptions = true;
            this.colNgayYeuCau.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNgayYeuCau.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colNgayYeuCau.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colNgayYeuCau.AppearanceHeader.Options.UseFont = true;
            this.colNgayYeuCau.AppearanceHeader.Options.UseTextOptions = true;
            this.colNgayYeuCau.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNgayYeuCau.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNgayYeuCau.Caption = "Ngày yêu cầu";
            this.colNgayYeuCau.ColumnEdit = this.repositoryItemDateEdit1;
            this.colNgayYeuCau.DisplayFormat.FormatString = "dd/M/yyyy";
            this.colNgayYeuCau.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgayYeuCau.FieldName = "NgayYeuCau";
            this.colNgayYeuCau.Name = "colNgayYeuCau";
            this.colNgayYeuCau.OptionsColumn.FixedWidth = true;
            this.colNgayYeuCau.Visible = true;
            this.colNgayYeuCau.VisibleIndex = 8;
            this.colNgayYeuCau.Width = 70;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.DisplayFormat.FormatString = "dd/M/yyyy";
            this.repositoryItemDateEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit1.EditFormat.FormatString = "dd/M/yyyy";
            this.repositoryItemDateEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repositoryItemDateEdit1.Mask.EditMask = "dd/M/yyyy";
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            this.repositoryItemDateEdit1.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // colNgayVeDuKien
            // 
            this.colNgayVeDuKien.AppearanceCell.Options.UseTextOptions = true;
            this.colNgayVeDuKien.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNgayVeDuKien.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colNgayVeDuKien.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colNgayVeDuKien.AppearanceHeader.Options.UseFont = true;
            this.colNgayVeDuKien.AppearanceHeader.Options.UseTextOptions = true;
            this.colNgayVeDuKien.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNgayVeDuKien.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNgayVeDuKien.Caption = "Ngày về dự kiến";
            this.colNgayVeDuKien.ColumnEdit = this.repositoryItemDateEdit1;
            this.colNgayVeDuKien.DisplayFormat.FormatString = "d";
            this.colNgayVeDuKien.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgayVeDuKien.FieldName = "NgayVeDuKien";
            this.colNgayVeDuKien.Name = "colNgayVeDuKien";
            this.colNgayVeDuKien.OptionsColumn.FixedWidth = true;
            this.colNgayVeDuKien.Visible = true;
            this.colNgayVeDuKien.VisibleIndex = 9;
            this.colNgayVeDuKien.Width = 70;
            // 
            // colNgayThucTe
            // 
            this.colNgayThucTe.AppearanceCell.Options.UseTextOptions = true;
            this.colNgayThucTe.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNgayThucTe.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colNgayThucTe.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colNgayThucTe.AppearanceHeader.Options.UseFont = true;
            this.colNgayThucTe.AppearanceHeader.Options.UseTextOptions = true;
            this.colNgayThucTe.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNgayThucTe.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNgayThucTe.Caption = "Ngày thực tế";
            this.colNgayThucTe.ColumnEdit = this.repositoryItemDateEdit1;
            this.colNgayThucTe.DisplayFormat.FormatString = "dd/M/yyyy";
            this.colNgayThucTe.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgayThucTe.FieldName = "NgayThucTe";
            this.colNgayThucTe.Name = "colNgayThucTe";
            this.colNgayThucTe.OptionsColumn.FixedWidth = true;
            this.colNgayThucTe.Visible = true;
            this.colNgayThucTe.VisibleIndex = 12;
            this.colNgayThucTe.Width = 70;
            // 
            // colThoiGianDatHangTHucTe
            // 
            this.colThoiGianDatHangTHucTe.AppearanceCell.Options.UseTextOptions = true;
            this.colThoiGianDatHangTHucTe.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colThoiGianDatHangTHucTe.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colThoiGianDatHangTHucTe.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colThoiGianDatHangTHucTe.AppearanceHeader.Options.UseFont = true;
            this.colThoiGianDatHangTHucTe.AppearanceHeader.Options.UseTextOptions = true;
            this.colThoiGianDatHangTHucTe.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colThoiGianDatHangTHucTe.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colThoiGianDatHangTHucTe.Caption = "Thời gian về thực tế (ngày)";
            this.colThoiGianDatHangTHucTe.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colThoiGianDatHangTHucTe.FieldName = "ThoiGianDatHangThucTe";
            this.colThoiGianDatHangTHucTe.Name = "colThoiGianDatHangTHucTe";
            this.colThoiGianDatHangTHucTe.OptionsColumn.AllowEdit = false;
            this.colThoiGianDatHangTHucTe.OptionsColumn.AllowFocus = false;
            this.colThoiGianDatHangTHucTe.OptionsColumn.FixedWidth = true;
            this.colThoiGianDatHangTHucTe.Visible = true;
            this.colThoiGianDatHangTHucTe.VisibleIndex = 13;
            this.colThoiGianDatHangTHucTe.Width = 99;
            // 
            // colNguyenNhanCham
            // 
            this.colNguyenNhanCham.AppearanceCell.Options.UseTextOptions = true;
            this.colNguyenNhanCham.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colNguyenNhanCham.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colNguyenNhanCham.AppearanceHeader.Options.UseFont = true;
            this.colNguyenNhanCham.AppearanceHeader.Options.UseTextOptions = true;
            this.colNguyenNhanCham.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNguyenNhanCham.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNguyenNhanCham.Caption = "Nguyên nhân chậm";
            this.colNguyenNhanCham.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colNguyenNhanCham.FieldName = "NguyenNhanCham";
            this.colNguyenNhanCham.Name = "colNguyenNhanCham";
            this.colNguyenNhanCham.Visible = true;
            this.colNguyenNhanCham.VisibleIndex = 14;
            this.colNguyenNhanCham.Width = 80;
            // 
            // colGhiChu
            // 
            this.colGhiChu.AppearanceCell.Options.UseTextOptions = true;
            this.colGhiChu.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colGhiChu.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colGhiChu.AppearanceHeader.Options.UseFont = true;
            this.colGhiChu.AppearanceHeader.Options.UseTextOptions = true;
            this.colGhiChu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGhiChu.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colGhiChu.Caption = "Ghi chú";
            this.colGhiChu.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colGhiChu.FieldName = "GhiChu";
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.Visible = true;
            this.colGhiChu.VisibleIndex = 15;
            this.colGhiChu.Width = 46;
            // 
            // colID
            // 
            this.colID.AppearanceCell.Options.UseTextOptions = true;
            this.colID.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colUserID
            // 
            this.colUserID.AppearanceCell.Options.UseTextOptions = true;
            this.colUserID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUserID.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colUserID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colUserID.AppearanceHeader.Options.UseFont = true;
            this.colUserID.AppearanceHeader.Options.UseTextOptions = true;
            this.colUserID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUserID.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colUserID.Caption = "Người yêu cầu";
            this.colUserID.ColumnEdit = this.colNguoiYeuCau;
            this.colUserID.FieldName = "UserID";
            this.colUserID.Name = "colUserID";
            this.colUserID.OptionsColumn.AllowEdit = false;
            this.colUserID.OptionsColumn.AllowFocus = false;
            this.colUserID.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colUserID.OptionsColumn.AllowIncrementalSearch = false;
            this.colUserID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colUserID.OptionsColumn.AllowMove = false;
            this.colUserID.OptionsColumn.AllowShowHide = false;
            this.colUserID.OptionsColumn.FixedWidth = true;
            this.colUserID.OptionsColumn.ReadOnly = true;
            this.colUserID.Visible = true;
            this.colUserID.VisibleIndex = 16;
            this.colUserID.Width = 95;
            // 
            // colNguoiYeuCau
            // 
            this.colNguoiYeuCau.AutoHeight = false;
            this.colNguoiYeuCau.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colNguoiYeuCau.Name = "colNguoiYeuCau";
            // 
            // colSTT
            // 
            this.colSTT.AppearanceCell.Options.UseTextOptions = true;
            this.colSTT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSTT.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colSTT.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colSTT.AppearanceHeader.Options.UseFont = true;
            this.colSTT.AppearanceHeader.Options.UseTextOptions = true;
            this.colSTT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSTT.Caption = "STT";
            this.colSTT.FieldName = "STT";
            this.colSTT.Name = "colSTT";
            this.colSTT.OptionsColumn.AllowEdit = false;
            this.colSTT.OptionsColumn.AllowFocus = false;
            this.colSTT.OptionsColumn.FixedWidth = true;
            this.colSTT.Visible = true;
            this.colSTT.VisibleIndex = 0;
            this.colSTT.Width = 30;
            // 
            // colStatus
            // 
            this.colStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colStatus.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colStatus.Caption = "Status";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            // 
            // colNgayVeDuKien2
            // 
            this.colNgayVeDuKien2.AppearanceCell.Options.UseTextOptions = true;
            this.colNgayVeDuKien2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNgayVeDuKien2.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colNgayVeDuKien2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colNgayVeDuKien2.AppearanceHeader.Options.UseFont = true;
            this.colNgayVeDuKien2.AppearanceHeader.Options.UseTextOptions = true;
            this.colNgayVeDuKien2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNgayVeDuKien2.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNgayVeDuKien2.Caption = "Ngày về dự kiến lần 2";
            this.colNgayVeDuKien2.ColumnEdit = this.repositoryItemDateEdit1;
            this.colNgayVeDuKien2.FieldName = "NgayVeDuKien2";
            this.colNgayVeDuKien2.Name = "colNgayVeDuKien2";
            this.colNgayVeDuKien2.OptionsColumn.FixedWidth = true;
            this.colNgayVeDuKien2.Visible = true;
            this.colNgayVeDuKien2.VisibleIndex = 10;
            this.colNgayVeDuKien2.Width = 70;
            // 
            // colNgayVeDuKien3
            // 
            this.colNgayVeDuKien3.AppearanceCell.Options.UseTextOptions = true;
            this.colNgayVeDuKien3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNgayVeDuKien3.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colNgayVeDuKien3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colNgayVeDuKien3.AppearanceHeader.Options.UseFont = true;
            this.colNgayVeDuKien3.AppearanceHeader.Options.UseTextOptions = true;
            this.colNgayVeDuKien3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNgayVeDuKien3.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNgayVeDuKien3.Caption = "Ngày về dự kiến lần 3";
            this.colNgayVeDuKien3.ColumnEdit = this.repositoryItemDateEdit1;
            this.colNgayVeDuKien3.FieldName = "NgayVeDuKien3";
            this.colNgayVeDuKien3.Name = "colNgayVeDuKien3";
            this.colNgayVeDuKien3.OptionsColumn.FixedWidth = true;
            this.colNgayVeDuKien3.Visible = true;
            this.colNgayVeDuKien3.VisibleIndex = 11;
            this.colNgayVeDuKien3.Width = 70;
            // 
            // colYear
            // 
            this.colYear.AppearanceCell.Options.UseTextOptions = true;
            this.colYear.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colYear.Caption = "Năm";
            this.colYear.FieldName = "Year";
            this.colYear.Name = "colYear";
            // 
            // colMonth
            // 
            this.colMonth.AppearanceCell.Options.UseTextOptions = true;
            this.colMonth.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMonth.Caption = "Tháng";
            this.colMonth.FieldName = "Month";
            this.colMonth.Name = "colMonth";
            this.colMonth.Visible = true;
            this.colMonth.VisibleIndex = 17;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.DisplayFormat.FormatString = "n0";
            this.repositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit1.EditFormat.FormatString = "n0";
            this.repositoryItemTextEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "alert.png");
            // 
            // popupNotifier1
            // 
            this.popupNotifier1.BodyColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.popupNotifier1.ContentFont = new System.Drawing.Font("Tahoma", 8F);
            this.popupNotifier1.ContentText = null;
            this.popupNotifier1.GradientPower = 300;
            this.popupNotifier1.HeaderHeight = 20;
            this.popupNotifier1.Image = null;
            this.popupNotifier1.OptionsMenu = null;
            this.popupNotifier1.Size = new System.Drawing.Size(400, 100);
            this.popupNotifier1.TitleFont = new System.Drawing.Font("Segoe UI", 9F);
            this.popupNotifier1.TitleText = null;
            this.popupNotifier1.Click += new System.EventHandler(this.popupNotifier1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Theo dõi tiến độ vật tư";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mởGiaoDiệnToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(145, 26);
            // 
            // mởGiaoDiệnToolStripMenuItem
            // 
            this.mởGiaoDiệnToolStripMenuItem.Name = "mởGiaoDiệnToolStripMenuItem";
            this.mởGiaoDiệnToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.mởGiaoDiệnToolStripMenuItem.Text = "Mở giao diện";
            this.mởGiaoDiệnToolStripMenuItem.Click += new System.EventHandler(this.mởGiaoDiệnToolStripMenuItem_Click);
            // 
            // mnuMenu
            // 
            this.mnuMenu.AutoSize = false;
            this.mnuMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.mnuMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.toolStripSeparator8,
            this.btnSua,
            this.toolStripSeparator7,
            this.btnXoa,
            this.btnGhi,
            this.toolStripSeparator5,
            this.btnHuy,
            this.toolStripSeparator1,
            this.btnExcel,
            this.toolStripSeparator4,
            this.toolStripButton2,
            this.toolStripSeparator3,
            this.btnMoi,
            this.toolStripSeparator2,
            this.btnClose,
            this.toolStripLabel1});
            this.mnuMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuMenu.Size = new System.Drawing.Size(1028, 42);
            this.mnuMenu.TabIndex = 22;
            this.mnuMenu.Text = "toolStrip2";
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(43, 33);
            this.btnNew.Tag = "";
            this.btnNew.Text = "&Thêm";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 23);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.Image")));
            this.btnSua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(33, 33);
            this.btnSua.Tag = "";
            this.btnSua.Text = "Sửa";
            this.btnSua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 23);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(32, 33);
            this.btnXoa.Tag = "";
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnGhi
            // 
            this.btnGhi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGhi.Image = ((System.Drawing.Image)(resources.GetObject("btnGhi.Image")));
            this.btnGhi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGhi.Name = "btnGhi";
            this.btnGhi.Size = new System.Drawing.Size(29, 33);
            this.btnGhi.Text = "Ghi";
            this.btnGhi.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGhi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGhi.Visible = false;
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 23);
            // 
            // btnHuy
            // 
            this.btnHuy.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnHuy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Image = ((System.Drawing.Image)(resources.GetObject("btnHuy.Image")));
            this.btnHuy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(33, 33);
            this.btnHuy.Text = "Hủy";
            this.btnHuy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnHuy.Visible = false;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // btnExcel
            // 
            this.btnExcel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(87, 33);
            this.btnExcel.Text = "Nhập từ Excel";
            this.btnExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(205, 33);
            this.toolStripButton2.Text = "Danh sách vật tư chưa hoàn thành";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
            // 
            // btnMoi
            // 
            this.btnMoi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoi.Image = ((System.Drawing.Image)(resources.GetObject("btnMoi.Image")));
            this.btnMoi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMoi.Name = "btnMoi";
            this.btnMoi.Size = new System.Drawing.Size(58, 33);
            this.btnMoi.Text = "Làm Mới";
            this.btnMoi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnMoi.Click += new System.EventHandler(this.btnMoi_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AutoSize = false;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 40);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(44, 33);
            this.btnClose.Text = "Thoát";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(137, 13);
            this.toolStripLabel1.Text = "Số vật tư chưa hoàn thành";
            // 
            // frmMainVatTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 386);
            this.Controls.Add(this.mnuMenu);
            this.Controls.Add(this.grdData);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMainVatTu";
            this.Text = "Theo dõi tiến độ vật tư";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colNguoiYeuCau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.Grid.GridView grvData;
        private DevExpress.XtraGrid.Columns.GridColumn colTenVatTu;
        private DevExpress.XtraGrid.Columns.GridColumn colMaVatTu;
        private DevExpress.XtraGrid.Columns.GridColumn colHang;
        private DevExpress.XtraGrid.Columns.GridColumn colMaSP;
        private DevExpress.XtraGrid.Columns.GridColumn colTenDuAn;
        private DevExpress.XtraGrid.Columns.GridColumn colMaDuAn;
        private DevExpress.XtraGrid.Columns.GridColumn colSoLuong;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayYeuCau;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayVeDuKien;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayThucTe;
        private DevExpress.XtraGrid.Columns.GridColumn colThoiGianDatHangTHucTe;
        private DevExpress.XtraGrid.Columns.GridColumn colNguyenNhanCham;
        private DevExpress.XtraGrid.Columns.GridColumn colGhiChu;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private System.Windows.Forms.ImageList imageList1;
        private NotificationWindow.PopupNotifier popupNotifier1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mởGiaoDiệnToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn colUserID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit colNguoiYeuCau;
        private DevExpress.XtraGrid.Columns.GridColumn colSTT;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayVeDuKien2;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayVeDuKien3;
        private System.Windows.Forms.ToolStrip mnuMenu;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripButton btnSua;
        private System.Windows.Forms.ToolStripButton btnXoa;
        private System.Windows.Forms.ToolStripButton btnGhi;
        private System.Windows.Forms.ToolStripButton btnHuy;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripButton btnExcel;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton btnMoi;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private DevExpress.XtraGrid.Columns.GridColumn colYear;
        private DevExpress.XtraGrid.Columns.GridColumn colMonth;
    }
}

