namespace BMS
{
    partial class frmRequireManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRequireManagement));
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNguoiDaiDien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRequirePerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmailNĐD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNguoiPhuTrach = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPriority = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaKhachHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRequireDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xemDanhSachNhaCungCâpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xemDanhSachSanPhâmChưaVâtTưToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnShowInventory = new System.Windows.Forms.ToolStripMenuItem();
            this.yêuCầuTạoMãVậtTưToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnFindAll = new DevExpress.XtraEditors.SimpleButton();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDel = new System.Windows.Forms.ToolStripButton();
            this.mnuMenu = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grdKH = new DevExpress.XtraGrid.GridControl();
            this.grvKH = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKHCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKHName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.mnuMenu.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdKH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.DisplayValueChecked = "\"1\"";
            this.repositoryItemCheckEdit1.DisplayValueUnchecked = "\"0\"";
            this.repositoryItemCheckEdit1.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // colID
            // 
            this.colID.AppearanceCell.Options.UseTextOptions = true;
            this.colID.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colID.Caption = "Id";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.AllowEdit = false;
            // 
            // colCode
            // 
            this.colCode.AppearanceCell.Options.UseTextOptions = true;
            this.colCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCode.AppearanceHeader.Options.UseFont = true;
            this.colCode.Caption = "Mã yêu cầu";
            this.colCode.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.OptionsColumn.AllowEdit = false;
            this.colCode.OptionsColumn.AllowSize = false;
            this.colCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            this.colCode.Width = 89;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // colName
            // 
            this.colName.AppearanceCell.Options.UseTextOptions = true;
            this.colName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colName.AppearanceHeader.Options.UseFont = true;
            this.colName.Caption = "Tên yêu cầu";
            this.colName.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.OptionsColumn.AllowSize = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 194;
            // 
            // colNguoiDaiDien
            // 
            this.colNguoiDaiDien.AppearanceCell.Options.UseTextOptions = true;
            this.colNguoiDaiDien.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colNguoiDaiDien.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colNguoiDaiDien.AppearanceHeader.Options.UseFont = true;
            this.colNguoiDaiDien.AppearanceHeader.Options.UseTextOptions = true;
            this.colNguoiDaiDien.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNguoiDaiDien.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNguoiDaiDien.Caption = "Người ĐD";
            this.colNguoiDaiDien.FieldName = "NguoiDaiDien";
            this.colNguoiDaiDien.Name = "colNguoiDaiDien";
            this.colNguoiDaiDien.OptionsColumn.AllowEdit = false;
            this.colNguoiDaiDien.OptionsColumn.AllowSize = false;
            this.colNguoiDaiDien.Visible = true;
            this.colNguoiDaiDien.VisibleIndex = 8;
            this.colNguoiDaiDien.Width = 135;
            // 
            // grvData
            // 
            this.grvData.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvData.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvData.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvData.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grvData.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvData.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvData.ColumnPanelRowHeight = 40;
            this.grvData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colCode,
            this.colName,
            this.colNguoiDaiDien,
            this.colRequirePerson,
            this.colEmailNĐD,
            this.colVL,
            this.colNguoiPhuTrach,
            this.colPhone,
            this.colPriority,
            this.colMaKhachHang,
            this.colYear,
            this.colCreatedDate,
            this.colRequireDate});
            this.grvData.GridControl = this.grdData;
            this.grvData.GroupCount = 1;
            this.grvData.Name = "grvData";
            this.grvData.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvData.OptionsCustomization.AllowRowSizing = true;
            this.grvData.OptionsFind.AlwaysVisible = true;
            this.grvData.OptionsView.AllowHtmlDrawHeaders = true;
            this.grvData.OptionsView.ColumnAutoWidth = false;
            this.grvData.OptionsView.RowAutoHeight = true;
            this.grvData.OptionsView.ShowFooter = true;
            this.grvData.OptionsView.ShowGroupPanel = false;
            this.grvData.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colYear, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvData_KeyDown);
            this.grvData.DoubleClick += new System.EventHandler(this.grvData_DoubleClick);
            // 
            // colRequirePerson
            // 
            this.colRequirePerson.AppearanceCell.Options.UseTextOptions = true;
            this.colRequirePerson.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colRequirePerson.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colRequirePerson.AppearanceHeader.Options.UseFont = true;
            this.colRequirePerson.AppearanceHeader.Options.UseTextOptions = true;
            this.colRequirePerson.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRequirePerson.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colRequirePerson.Caption = "Người YC";
            this.colRequirePerson.FieldName = "NguoiYeuCauName";
            this.colRequirePerson.Name = "colRequirePerson";
            this.colRequirePerson.OptionsColumn.AllowSize = false;
            this.colRequirePerson.Visible = true;
            this.colRequirePerson.VisibleIndex = 7;
            this.colRequirePerson.Width = 129;
            // 
            // colEmailNĐD
            // 
            this.colEmailNĐD.AppearanceCell.Options.UseTextOptions = true;
            this.colEmailNĐD.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colEmailNĐD.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colEmailNĐD.AppearanceHeader.Options.UseFont = true;
            this.colEmailNĐD.AppearanceHeader.Options.UseTextOptions = true;
            this.colEmailNĐD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colEmailNĐD.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colEmailNĐD.Caption = "Email NĐD";
            this.colEmailNĐD.FieldName = "Email";
            this.colEmailNĐD.Name = "colEmailNĐD";
            this.colEmailNĐD.OptionsColumn.AllowEdit = false;
            this.colEmailNĐD.Visible = true;
            this.colEmailNĐD.VisibleIndex = 10;
            this.colEmailNĐD.Width = 139;
            // 
            // colVL
            // 
            this.colVL.AppearanceCell.Options.UseTextOptions = true;
            this.colVL.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colVL.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colVL.AppearanceHeader.Options.UseFont = true;
            this.colVL.AppearanceHeader.Options.UseTextOptions = true;
            this.colVL.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVL.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colVL.Caption = "Định mức chi phí";
            this.colVL.DisplayFormat.FormatString = "n2";
            this.colVL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colVL.FieldName = "Cost";
            this.colVL.Name = "colVL";
            this.colVL.OptionsColumn.AllowEdit = false;
            this.colVL.Visible = true;
            this.colVL.VisibleIndex = 3;
            this.colVL.Width = 84;
            // 
            // colNguoiPhuTrach
            // 
            this.colNguoiPhuTrach.AppearanceCell.Options.UseTextOptions = true;
            this.colNguoiPhuTrach.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colNguoiPhuTrach.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colNguoiPhuTrach.AppearanceHeader.Options.UseFont = true;
            this.colNguoiPhuTrach.AppearanceHeader.Options.UseTextOptions = true;
            this.colNguoiPhuTrach.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNguoiPhuTrach.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNguoiPhuTrach.Caption = "Người phụ trách";
            this.colNguoiPhuTrach.FieldName = "NguoiPhuTrachName";
            this.colNguoiPhuTrach.Name = "colNguoiPhuTrach";
            this.colNguoiPhuTrach.OptionsColumn.AllowEdit = false;
            this.colNguoiPhuTrach.OptionsColumn.AllowSize = false;
            this.colNguoiPhuTrach.Visible = true;
            this.colNguoiPhuTrach.VisibleIndex = 5;
            this.colNguoiPhuTrach.Width = 140;
            // 
            // colPhone
            // 
            this.colPhone.AppearanceCell.Options.UseTextOptions = true;
            this.colPhone.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPhone.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colPhone.AppearanceHeader.Options.UseFont = true;
            this.colPhone.AppearanceHeader.Options.UseTextOptions = true;
            this.colPhone.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPhone.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPhone.Caption = "Điện thoại NĐD";
            this.colPhone.FieldName = "Phone";
            this.colPhone.Name = "colPhone";
            this.colPhone.OptionsColumn.AllowEdit = false;
            this.colPhone.OptionsColumn.AllowSize = false;
            this.colPhone.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.colPhone.Visible = true;
            this.colPhone.VisibleIndex = 9;
            this.colPhone.Width = 80;
            // 
            // colPriority
            // 
            this.colPriority.AppearanceCell.Options.UseTextOptions = true;
            this.colPriority.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPriority.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colPriority.AppearanceHeader.Options.UseFont = true;
            this.colPriority.AppearanceHeader.Options.UseTextOptions = true;
            this.colPriority.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPriority.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPriority.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPriority.Caption = "Mức độ ưu tiên";
            this.colPriority.FieldName = "PriorityText";
            this.colPriority.Name = "colPriority";
            this.colPriority.OptionsColumn.AllowEdit = false;
            this.colPriority.OptionsColumn.AllowSize = false;
            this.colPriority.Visible = true;
            this.colPriority.VisibleIndex = 4;
            this.colPriority.Width = 106;
            // 
            // colMaKhachHang
            // 
            this.colMaKhachHang.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMaKhachHang.AppearanceHeader.Options.UseFont = true;
            this.colMaKhachHang.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaKhachHang.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaKhachHang.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colMaKhachHang.Caption = "Khách hàng";
            this.colMaKhachHang.FieldName = "CustomerCode";
            this.colMaKhachHang.Name = "colMaKhachHang";
            this.colMaKhachHang.OptionsColumn.AllowEdit = false;
            this.colMaKhachHang.Visible = true;
            this.colMaKhachHang.VisibleIndex = 6;
            // 
            // colYear
            // 
            this.colYear.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colYear.AppearanceHeader.Options.UseFont = true;
            this.colYear.Caption = "Năm";
            this.colYear.FieldName = "Year";
            this.colYear.Name = "colYear";
            // 
            // colCreatedDate
            // 
            this.colCreatedDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCreatedDate.AppearanceHeader.Options.UseFont = true;
            this.colCreatedDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colCreatedDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCreatedDate.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCreatedDate.Caption = "Ngày tạo";
            this.colCreatedDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colCreatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCreatedDate.FieldName = "CreatedDate";
            this.colCreatedDate.Name = "colCreatedDate";
            this.colCreatedDate.Visible = true;
            this.colCreatedDate.VisibleIndex = 11;
            // 
            // colRequireDate
            // 
            this.colRequireDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colRequireDate.AppearanceHeader.Options.UseFont = true;
            this.colRequireDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colRequireDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRequireDate.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colRequireDate.Caption = "Ngày cấp giải pháp";
            this.colRequireDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colRequireDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colRequireDate.FieldName = "RequireDate";
            this.colRequireDate.Name = "colRequireDate";
            this.colRequireDate.OptionsColumn.AllowEdit = false;
            this.colRequireDate.OptionsColumn.AllowSize = false;
            this.colRequireDate.Visible = true;
            this.colRequireDate.VisibleIndex = 2;
            // 
            // grdData
            // 
            this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdData.ContextMenuStrip = this.contextMenuStrip1;
            this.grdData.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdData.Location = new System.Drawing.Point(5, 65);
            this.grdData.MainView = this.grvData;
            this.grdData.Name = "grdData";
            this.grdData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1,
            this.repositoryItemPictureEdit1,
            this.repositoryItemCheckEdit2});
            this.grdData.Size = new System.Drawing.Size(848, 367);
            this.grdData.TabIndex = 20;
            this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvData});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xemDanhSachNhaCungCâpToolStripMenuItem,
            this.xemDanhSachSanPhâmChưaVâtTưToolStripMenuItem,
            this.btnShowInventory,
            this.yêuCầuTạoMãVậtTưToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(273, 92);
            // 
            // xemDanhSachNhaCungCâpToolStripMenuItem
            // 
            this.xemDanhSachNhaCungCâpToolStripMenuItem.Name = "xemDanhSachNhaCungCâpToolStripMenuItem";
            this.xemDanhSachNhaCungCâpToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.xemDanhSachNhaCungCâpToolStripMenuItem.Text = "Xem danh sách nhà cung cấp";
            // 
            // xemDanhSachSanPhâmChưaVâtTưToolStripMenuItem
            // 
            this.xemDanhSachSanPhâmChưaVâtTưToolStripMenuItem.Name = "xemDanhSachSanPhâmChưaVâtTưToolStripMenuItem";
            this.xemDanhSachSanPhâmChưaVâtTưToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.xemDanhSachSanPhâmChưaVâtTưToolStripMenuItem.Text = "Xem danh sách sản phẩm chứa vật tư";
            // 
            // btnShowInventory
            // 
            this.btnShowInventory.Name = "btnShowInventory";
            this.btnShowInventory.Size = new System.Drawing.Size(272, 22);
            this.btnShowInventory.Text = "Xem số lượng tồn kho";
            // 
            // yêuCầuTạoMãVậtTưToolStripMenuItem
            // 
            this.yêuCầuTạoMãVậtTưToolStripMenuItem.Name = "yêuCầuTạoMãVậtTưToolStripMenuItem";
            this.yêuCầuTạoMãVậtTưToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.yêuCầuTạoMãVậtTưToolStripMenuItem.Text = "Yêu cầu tạo mã vật tư";
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            this.repositoryItemPictureEdit1.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.groupControl2.Controls.Add(this.btnFindAll);
            this.groupControl2.Controls.Add(this.txtName);
            this.groupControl2.Controls.Add(this.label2);
            this.groupControl2.Controls.Add(this.grdData);
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(855, 437);
            this.groupControl2.TabIndex = 18;
            this.groupControl2.Text = "Danh sách yêu cầu";
            // 
            // btnFindAll
            // 
            this.btnFindAll.Location = new System.Drawing.Point(583, 33);
            this.btnFindAll.Name = "btnFindAll";
            this.btnFindAll.Size = new System.Drawing.Size(55, 23);
            this.btnFindAll.TabIndex = 26;
            this.btnFindAll.Text = "Tìm kiếm";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(55, 34);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(516, 20);
            this.txtName.TabIndex = 25;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Từ khóa:";
            // 
            // btnExcel
            // 
            this.btnExcel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(74, 34);
            this.btnExcel.Tag = "";
            this.btnExcel.Text = "Xuất Excel";
            this.btnExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.AutoSize = false;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 40);
            // 
            // btnDel
            // 
            this.btnDel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
            this.btnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(85, 34);
            this.btnDel.Tag = "frmRequireManagement_Delete";
            this.btnDel.Text = "Xóa yêu cầu";
            this.btnDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // mnuMenu
            // 
            this.mnuMenu.AutoSize = false;
            this.mnuMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.mnuMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.toolStripSeparator2,
            this.btnEdit,
            this.toolStripSeparator1,
            this.btnDel,
            this.toolStripSeparator4,
            this.btnExcel});
            this.mnuMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuMenu.Size = new System.Drawing.Size(1191, 42);
            this.mnuMenu.TabIndex = 23;
            this.mnuMenu.Text = "toolStrip2";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(95, 34);
            this.btnAdd.Tag = "frmRequireManagement_Add";
            this.btnAdd.Text = "Thêm yêu cầu";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(86, 34);
            this.btnEdit.Tag = "frmRequireManagement_Edit";
            this.btnEdit.Text = "Sửa yêu cầu";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.splitContainer1.Location = new System.Drawing.Point(0, 46);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grdKH);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupControl2);
            this.splitContainer1.Size = new System.Drawing.Size(1191, 437);
            this.splitContainer1.SplitterDistance = 332;
            this.splitContainer1.TabIndex = 24;
            // 
            // grdKH
            // 
            this.grdKH.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdKH.Location = new System.Drawing.Point(3, 27);
            this.grdKH.MainView = this.grvKH;
            this.grdKH.Name = "grdKH";
            this.grdKH.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit2});
            this.grdKH.Size = new System.Drawing.Size(326, 405);
            this.grdKH.TabIndex = 19;
            this.grdKH.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKH});
            // 
            // grvKH
            // 
            this.grvKH.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvKH.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvKH.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvKH.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvKH.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvKH.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKH.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvKH.Appearance.RowSeparator.Options.UseBackColor = true;
            this.grvKH.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.colKHCode,
            this.colKHName});
            this.grvKH.GridControl = this.grdKH;
            this.grvKH.Name = "grvKH";
            this.grvKH.OptionsBehavior.Editable = false;
            this.grvKH.OptionsFind.AlwaysVisible = true;
            this.grvKH.OptionsView.RowAutoHeight = true;
            this.grvKH.OptionsView.ShowAutoFilterRow = true;
            this.grvKH.OptionsView.ShowFooter = true;
            this.grvKH.OptionsView.ShowGroupPanel = false;
            this.grvKH.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvKH_FocusedRowChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "ID";
            this.gridColumn1.FieldName = "ID";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // colKHCode
            // 
            this.colKHCode.AppearanceCell.Options.UseTextOptions = true;
            this.colKHCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colKHCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colKHCode.AppearanceHeader.Options.UseFont = true;
            this.colKHCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colKHCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKHCode.Caption = "Mã KH";
            this.colKHCode.FieldName = "CustomerCode";
            this.colKHCode.Name = "colKHCode";
            this.colKHCode.OptionsColumn.AllowEdit = false;
            this.colKHCode.OptionsColumn.AllowFocus = false;
            this.colKHCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colKHCode.Visible = true;
            this.colKHCode.VisibleIndex = 0;
            this.colKHCode.Width = 69;
            // 
            // colKHName
            // 
            this.colKHName.AppearanceCell.Options.UseTextOptions = true;
            this.colKHName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colKHName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colKHName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colKHName.AppearanceHeader.Options.UseFont = true;
            this.colKHName.AppearanceHeader.Options.UseTextOptions = true;
            this.colKHName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKHName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colKHName.Caption = "Khách hàng";
            this.colKHName.ColumnEdit = this.repositoryItemMemoEdit2;
            this.colKHName.FieldName = "CustomerName";
            this.colKHName.Name = "colKHName";
            this.colKHName.OptionsColumn.AllowEdit = false;
            this.colKHName.OptionsColumn.AllowFocus = false;
            this.colKHName.Visible = true;
            this.colKHName.VisibleIndex = 1;
            this.colKHName.Width = 239;
            // 
            // repositoryItemMemoEdit2
            // 
            this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 8);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(108, 13);
            this.labelControl1.TabIndex = 18;
            this.labelControl1.Text = "Danh sách khách hàng";
            // 
            // frmRequireManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 484);
            this.Controls.Add(this.mnuMenu);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmRequireManagement";
            this.Text = "QUẢN LÝ YÊU CẦU";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRequireManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdKH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoiDaiDien;
        private DevExpress.XtraGrid.Views.Grid.GridView grvData;
        private DevExpress.XtraGrid.Columns.GridColumn colRequirePerson;
        private DevExpress.XtraGrid.Columns.GridColumn colEmailNĐD;
        private DevExpress.XtraGrid.Columns.GridColumn colVL;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoiPhuTrach;
        private DevExpress.XtraGrid.Columns.GridColumn colPhone;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colPriority;
        private DevExpress.XtraGrid.GridControl grdData;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xemDanhSachNhaCungCâpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xemDanhSachSanPhâmChưaVâtTưToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnShowInventory;
        private System.Windows.Forms.ToolStripMenuItem yêuCầuTạoMãVậtTưToolStripMenuItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnFindAll;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripButton btnExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnDel;
        private System.Windows.Forms.ToolStrip mnuMenu;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private DevExpress.XtraGrid.GridControl grdKH;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKH;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn colKHCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colKHName;
        private DevExpress.XtraGrid.Columns.GridColumn colMaKhachHang;
        private DevExpress.XtraGrid.Columns.GridColumn colYear;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colRequireDate;
    }
}