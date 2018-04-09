namespace BMS
{
    partial class frmTheoDoiImportExcel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTheoDoiImportExcel));
            this.mnuMenu = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnBrowse = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.grvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colThongSo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colF6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colF7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colF8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colF9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTenVatTu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaVatTu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colSTT1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mnuMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBrowse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colNguoiYeuCau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuMenu
            // 
            this.mnuMenu.AutoSize = false;
            this.mnuMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.mnuMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.toolStripSeparator2,
            this.btnClose});
            this.mnuMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuMenu.Size = new System.Drawing.Size(973, 42);
            this.mnuMenu.TabIndex = 2;
            this.mnuMenu.Text = "toolStrip2";
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = false;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(55, 40);
            this.btnSave.Text = "Ghi";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AutoSize = false;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 40);
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = false;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(55, 40);
            this.btnClose.Text = "Thoát";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.cboStatus);
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.btnBrowse);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 42);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(973, 57);
            this.groupControl1.TabIndex = 3;
            this.groupControl1.Text = "Thông tin";
            // 
            // cboStatus
            // 
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(662, 23);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(157, 21);
            this.cboStatus.TabIndex = 1;
            this.cboStatus.SelectedIndexChanged += new System.EventHandler(this.cboStatus_SelectedIndexChanged);
            this.cboStatus.SelectionChangeCommitted += new System.EventHandler(this.cboStatus_SelectionChangeCommitted);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(599, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 147;
            this.label5.Text = "Tên Sheet:";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(72, 24);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnBrowse.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnBrowse.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.btnBrowse.Size = new System.Drawing.Size(511, 20);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnBrowse_ButtonClick);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(11, 27);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(54, 13);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "Đường dẫn";
            // 
            // grdData
            // 
            this.grdData.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdData.Location = new System.Drawing.Point(0, 177);
            this.grdData.MainView = this.grvData;
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(973, 72);
            this.grdData.TabIndex = 169;
            this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvData});
            this.grdData.Visible = false;
            // 
            // grvData
            // 
            this.grvData.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvData.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSTT,
            this.colName,
            this.colCode,
            this.colHang,
            this.colThongSo,
            this.colF6,
            this.colF7,
            this.colF8,
            this.colF9});
            this.grvData.GridControl = this.grdData;
            this.grvData.Name = "grvData";
            this.grvData.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvData.OptionsBehavior.Editable = false;
            this.grvData.OptionsView.ShowGroupPanel = false;
            // 
            // colSTT
            // 
            this.colSTT.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colSTT.AppearanceHeader.Options.UseFont = true;
            this.colSTT.Caption = "STT";
            this.colSTT.FieldName = "STT";
            this.colSTT.Name = "colSTT";
            this.colSTT.Visible = true;
            this.colSTT.VisibleIndex = 0;
            // 
            // colName
            // 
            this.colName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colName.AppearanceHeader.Options.UseFont = true;
            this.colName.Caption = "Tên vật tư";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            // 
            // colCode
            // 
            this.colCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCode.AppearanceHeader.Options.UseFont = true;
            this.colCode.Caption = "Mã";
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 2;
            // 
            // colHang
            // 
            this.colHang.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colHang.AppearanceHeader.Options.UseFont = true;
            this.colHang.Caption = "Hãng";
            this.colHang.FieldName = "Hang";
            this.colHang.Name = "colHang";
            this.colHang.Visible = true;
            this.colHang.VisibleIndex = 3;
            // 
            // colThongSo
            // 
            this.colThongSo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colThongSo.AppearanceHeader.Options.UseFont = true;
            this.colThongSo.Caption = "Đơn vị";
            this.colThongSo.FieldName = "ThongSo";
            this.colThongSo.Name = "colThongSo";
            this.colThongSo.Visible = true;
            this.colThongSo.VisibleIndex = 4;
            // 
            // colF6
            // 
            this.colF6.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colF6.AppearanceHeader.Options.UseFont = true;
            this.colF6.Caption = "Số lượng";
            this.colF6.FieldName = "F6";
            this.colF6.Name = "colF6";
            this.colF6.Visible = true;
            this.colF6.VisibleIndex = 5;
            // 
            // colF7
            // 
            this.colF7.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colF7.AppearanceHeader.Options.UseFont = true;
            this.colF7.Caption = "Mục đích sử dụng ( Module & Thiết bị )";
            this.colF7.FieldName = "F7";
            this.colF7.Name = "colF7";
            this.colF7.Visible = true;
            this.colF7.VisibleIndex = 6;
            // 
            // colF8
            // 
            this.colF8.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colF8.AppearanceHeader.Options.UseFont = true;
            this.colF8.Caption = "Ngày cần dự kiến";
            this.colF8.FieldName = "F8";
            this.colF8.Name = "colF8";
            this.colF8.Visible = true;
            this.colF8.VisibleIndex = 7;
            // 
            // colF9
            // 
            this.colF9.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colF9.AppearanceHeader.Options.UseFont = true;
            this.colF9.Caption = "Ghi Chú";
            this.colF9.FieldName = "F9";
            this.colF9.Name = "colF9";
            this.colF9.Visible = true;
            this.colF9.VisibleIndex = 8;
            // 
            // gridControl1
            // 
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 99);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.repositoryItemTextEdit1,
            this.colNguoiYeuCau});
            this.gridControl1.Size = new System.Drawing.Size(973, 310);
            this.gridControl1.TabIndex = 170;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTenVatTu,
            this.colMaVatTu,
            this.gridColumn1,
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
            this.colSTT1});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grvData_CustomDrawCell);
            this.gridView1.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.grvData_ValidatingEditor);
            // 
            // colTenVatTu
            // 
            this.colTenVatTu.Caption = "Tên vật tư";
            this.colTenVatTu.FieldName = "TenVatTu";
            this.colTenVatTu.Name = "colTenVatTu";
            this.colTenVatTu.Visible = true;
            this.colTenVatTu.VisibleIndex = 2;
            // 
            // colMaVatTu
            // 
            this.colMaVatTu.Caption = "Mã vật tư";
            this.colMaVatTu.FieldName = "MaVatTu";
            this.colMaVatTu.Name = "colMaVatTu";
            this.colMaVatTu.Visible = true;
            this.colMaVatTu.VisibleIndex = 1;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Hãng";
            this.gridColumn1.FieldName = "Hang";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            // 
            // colMaSP
            // 
            this.colMaSP.Caption = "Mã sản phẩm";
            this.colMaSP.FieldName = "MaSP";
            this.colMaSP.Name = "colMaSP";
            this.colMaSP.Visible = true;
            this.colMaSP.VisibleIndex = 4;
            // 
            // colTenDuAn
            // 
            this.colTenDuAn.Caption = "Tên dự án";
            this.colTenDuAn.FieldName = "TenDuAn";
            this.colTenDuAn.Name = "colTenDuAn";
            this.colTenDuAn.Visible = true;
            this.colTenDuAn.VisibleIndex = 5;
            // 
            // colMaDuAn
            // 
            this.colMaDuAn.Caption = "Mã dự án";
            this.colMaDuAn.FieldName = "MaDuAn";
            this.colMaDuAn.Name = "colMaDuAn";
            this.colMaDuAn.Visible = true;
            this.colMaDuAn.VisibleIndex = 6;
            // 
            // colSoLuong
            // 
            this.colSoLuong.Caption = "Số lượng";
            this.colSoLuong.DisplayFormat.FormatString = "{0:0.##}";
            this.colSoLuong.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSoLuong.FieldName = "SoLuong";
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.Visible = true;
            this.colSoLuong.VisibleIndex = 7;
            // 
            // colNgayYeuCau
            // 
            this.colNgayYeuCau.Caption = "Ngày yêu cầu";
            this.colNgayYeuCau.ColumnEdit = this.repositoryItemDateEdit1;
            this.colNgayYeuCau.DisplayFormat.FormatString = "dd/M/yyyy";
            this.colNgayYeuCau.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgayYeuCau.FieldName = "NgayYeuCau";
            this.colNgayYeuCau.Name = "colNgayYeuCau";
            this.colNgayYeuCau.Visible = true;
            this.colNgayYeuCau.VisibleIndex = 8;
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
            // 
            // colNgayVeDuKien
            // 
            this.colNgayVeDuKien.Caption = "Ngày về dự kiến";
            this.colNgayVeDuKien.ColumnEdit = this.repositoryItemDateEdit1;
            this.colNgayVeDuKien.DisplayFormat.FormatString = "d";
            this.colNgayVeDuKien.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgayVeDuKien.FieldName = "NgayVeDuKien";
            this.colNgayVeDuKien.Name = "colNgayVeDuKien";
            this.colNgayVeDuKien.Visible = true;
            this.colNgayVeDuKien.VisibleIndex = 9;
            // 
            // colNgayThucTe
            // 
            this.colNgayThucTe.Caption = "Ngày thực tế";
            this.colNgayThucTe.ColumnEdit = this.repositoryItemDateEdit1;
            this.colNgayThucTe.DisplayFormat.FormatString = "dd/M/yyyy";
            this.colNgayThucTe.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colNgayThucTe.FieldName = "NgayThucTe";
            this.colNgayThucTe.Name = "colNgayThucTe";
            this.colNgayThucTe.Visible = true;
            this.colNgayThucTe.VisibleIndex = 10;
            // 
            // colThoiGianDatHangTHucTe
            // 
            this.colThoiGianDatHangTHucTe.Caption = "Thời gian đặt hàng thực tế (ngày)";
            this.colThoiGianDatHangTHucTe.FieldName = "ThoiGianDatHangThucTe";
            this.colThoiGianDatHangTHucTe.Name = "colThoiGianDatHangTHucTe";
            this.colThoiGianDatHangTHucTe.OptionsColumn.AllowEdit = false;
            this.colThoiGianDatHangTHucTe.OptionsColumn.AllowFocus = false;
            this.colThoiGianDatHangTHucTe.Visible = true;
            this.colThoiGianDatHangTHucTe.VisibleIndex = 11;
            // 
            // colNguyenNhanCham
            // 
            this.colNguyenNhanCham.Caption = "Nguyên nhân chậm";
            this.colNguyenNhanCham.FieldName = "NguyenNhanCham";
            this.colNguyenNhanCham.Name = "colNguyenNhanCham";
            this.colNguyenNhanCham.Visible = true;
            this.colNguyenNhanCham.VisibleIndex = 12;
            // 
            // colGhiChu
            // 
            this.colGhiChu.Caption = "Ghi chú";
            this.colGhiChu.FieldName = "GhiChu";
            this.colGhiChu.Name = "colGhiChu";
            this.colGhiChu.Visible = true;
            this.colGhiChu.VisibleIndex = 13;
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colUserID
            // 
            this.colUserID.Caption = "Người yêu cầu";
            this.colUserID.ColumnEdit = this.colNguoiYeuCau;
            this.colUserID.FieldName = "UserID";
            this.colUserID.Name = "colUserID";
            this.colUserID.OptionsColumn.AllowEdit = false;
            this.colUserID.OptionsColumn.AllowFocus = false;
            this.colUserID.OptionsColumn.AllowSize = false;
            this.colUserID.Visible = true;
            this.colUserID.VisibleIndex = 14;
            // 
            // colNguoiYeuCau
            // 
            this.colNguoiYeuCau.AutoHeight = false;
            this.colNguoiYeuCau.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colNguoiYeuCau.Name = "colNguoiYeuCau";
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
            // colSTT1
            // 
            this.colSTT1.Caption = "STT";
            this.colSTT1.FieldName = "STT";
            this.colSTT1.Name = "colSTT1";
            this.colSTT1.Visible = true;
            this.colSTT1.VisibleIndex = 0;
            // 
            // frmTheoDoiImportExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 409);
            this.ControlBox = false;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.grdData);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.mnuMenu);
            this.Name = "frmTheoDoiImportExcel";
            this.Text = "Nhập dữ liệu từ file Excel";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnBrowse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colNguoiYeuCau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip mnuMenu;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnClose;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.ButtonEdit btnBrowse;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.Grid.GridView grvData;
        private DevExpress.XtraGrid.Columns.GridColumn colSTT;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colHang;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colThongSo;
        private DevExpress.XtraGrid.Columns.GridColumn colF6;
        private DevExpress.XtraGrid.Columns.GridColumn colF7;
        private DevExpress.XtraGrid.Columns.GridColumn colF8;
        private DevExpress.XtraGrid.Columns.GridColumn colF9;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colTenVatTu;
        private DevExpress.XtraGrid.Columns.GridColumn colMaVatTu;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
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
        private DevExpress.XtraGrid.Columns.GridColumn colUserID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit colNguoiYeuCau;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colSTT1;
    }
}