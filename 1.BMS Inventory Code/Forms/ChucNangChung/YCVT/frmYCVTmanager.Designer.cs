namespace BMS
{
    partial class frmYCVTmanager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmYCVTmanager));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grdYCVT = new DevExpress.XtraGrid.GridControl();
            this.grvYCVT = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colRcheck = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colRProjectCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdParts = new DevExpress.XtraGrid.GridControl();
            this.grvParts = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRiID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRiProjectCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRiProductCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colRiPartCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRiPartsName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRiManufacturerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRiOrigin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRiRequestCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRiSpecifications = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRiUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRiUserId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRiUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRiQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRiPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRiTotalPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboProductType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mnuMenu = new System.Windows.Forms.ToolStrip();
            this.btnExcel = new System.Windows.Forms.ToolStripButton();
            this.colRDateExpected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRDateCreate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdYCVT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvYCVT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdParts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvParts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).BeginInit();
            this.mnuMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 45);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grdParts);
            this.splitContainer1.Size = new System.Drawing.Size(1189, 446);
            this.splitContainer1.SplitterDistance = 409;
            this.splitContainer1.TabIndex = 189;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.cboDepartment);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.grdYCVT);
            this.splitContainer2.Size = new System.Drawing.Size(409, 446);
            this.splitContainer2.SplitterDistance = 32;
            this.splitContainer2.TabIndex = 0;
            // 
            // cboDepartment
            // 
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(77, 6);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(326, 21);
            this.cboDepartment.TabIndex = 1;
            this.cboDepartment.SelectedIndexChanged += new System.EventHandler(this.cboDepartment_SelectedIndexChanged);
            this.cboDepartment.SelectionChangeCommitted += new System.EventHandler(this.cboDepartment_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Phòng ban";
            // 
            // grdYCVT
            // 
            this.grdYCVT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdYCVT.Location = new System.Drawing.Point(7, 3);
            this.grdYCVT.MainView = this.grvYCVT;
            this.grdYCVT.Name = "grdYCVT";
            this.grdYCVT.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit2,
            this.repositoryItemCheckEdit2});
            this.grdYCVT.Size = new System.Drawing.Size(396, 404);
            this.grdYCVT.TabIndex = 18;
            this.grdYCVT.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvYCVT});
            // 
            // grvYCVT
            // 
            this.grvYCVT.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvYCVT.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvYCVT.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvYCVT.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvYCVT.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvYCVT.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvYCVT.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRID,
            this.colRCode,
            this.colRName,
            this.colRcheck,
            this.colRProjectCode,
            this.colRYear,
            this.colRDateExpected,
            this.colRDateCreate});
            this.grvYCVT.GridControl = this.grdYCVT;
            this.grvYCVT.GroupCount = 1;
            this.grvYCVT.Name = "grvYCVT";
            this.grvYCVT.OptionsFind.AlwaysVisible = true;
            this.grvYCVT.OptionsView.RowAutoHeight = true;
            this.grvYCVT.OptionsView.ShowFooter = true;
            this.grvYCVT.OptionsView.ShowGroupPanel = false;
            this.grvYCVT.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colRYear, DevExpress.Data.ColumnSortOrder.Descending)});
            this.grvYCVT.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvYCVT_FocusedRowChanged);
            this.grvYCVT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvYCVT_KeyDown);
            // 
            // colRID
            // 
            this.colRID.AppearanceHeader.Options.UseTextOptions = true;
            this.colRID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRID.Caption = "ID";
            this.colRID.FieldName = "ID";
            this.colRID.Name = "colRID";
            // 
            // colRCode
            // 
            this.colRCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colRCode.AppearanceHeader.Options.UseFont = true;
            this.colRCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colRCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRCode.Caption = "YCVT";
            this.colRCode.FieldName = "RequestCode";
            this.colRCode.Name = "colRCode";
            this.colRCode.OptionsColumn.AllowEdit = false;
            this.colRCode.OptionsColumn.AllowFocus = false;
            this.colRCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colRCode.Visible = true;
            this.colRCode.VisibleIndex = 0;
            this.colRCode.Width = 144;
            // 
            // colRName
            // 
            this.colRName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colRName.AppearanceHeader.Options.UseFont = true;
            this.colRName.AppearanceHeader.Options.UseTextOptions = true;
            this.colRName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRName.Caption = "Nội dung";
            this.colRName.ColumnEdit = this.repositoryItemMemoEdit2;
            this.colRName.FieldName = "RequestContent";
            this.colRName.Name = "colRName";
            this.colRName.OptionsColumn.AllowEdit = false;
            this.colRName.OptionsColumn.AllowFocus = false;
            this.colRName.Visible = true;
            this.colRName.VisibleIndex = 1;
            this.colRName.Width = 234;
            // 
            // repositoryItemMemoEdit2
            // 
            this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
            // 
            // colRcheck
            // 
            this.colRcheck.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colRcheck.AppearanceHeader.Options.UseFont = true;
            this.colRcheck.AppearanceHeader.Options.UseTextOptions = true;
            this.colRcheck.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRcheck.Caption = "Chọn";
            this.colRcheck.ColumnEdit = this.repositoryItemCheckEdit2;
            this.colRcheck.FieldName = "check";
            this.colRcheck.Name = "colRcheck";
            this.colRcheck.Width = 40;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // colRProjectCode
            // 
            this.colRProjectCode.Caption = "Mã dự án";
            this.colRProjectCode.FieldName = "ProjectCode";
            this.colRProjectCode.Name = "colRProjectCode";
            // 
            // colRYear
            // 
            this.colRYear.Caption = "Năm";
            this.colRYear.FieldName = "Year";
            this.colRYear.Name = "colRYear";
            this.colRYear.OptionsColumn.AllowEdit = false;
            // 
            // grdParts
            // 
            this.grdParts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdParts.Location = new System.Drawing.Point(5, 6);
            this.grdParts.MainView = this.grvParts;
            this.grdParts.Name = "grdParts";
            this.grdParts.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit3});
            this.grdParts.Size = new System.Drawing.Size(767, 437);
            this.grdParts.TabIndex = 17;
            this.grdParts.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvParts});
            // 
            // grvParts
            // 
            this.grvParts.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvParts.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvParts.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvParts.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvParts.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvParts.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvParts.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvParts.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvParts.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvParts.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRiID,
            this.colRiProjectCode,
            this.colRiProductCode,
            this.colRiPartCode,
            this.colRiPartsName,
            this.colRiManufacturerCode,
            this.colRiOrigin,
            this.colRiRequestCode,
            this.colRiSpecifications,
            this.colRiUserName,
            this.colRiUserId,
            this.colRiUnit,
            this.colRiQty,
            this.colRiPrice,
            this.colRiTotalPrice});
            this.grvParts.GridControl = this.grdParts;
            this.grvParts.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "RequirePartsId", null, "")});
            this.grvParts.Name = "grvParts";
            this.grvParts.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvParts.OptionsFind.AlwaysVisible = true;
            this.grvParts.OptionsSelection.MultiSelect = true;
            this.grvParts.OptionsView.ColumnAutoWidth = false;
            this.grvParts.OptionsView.RowAutoHeight = true;
            this.grvParts.OptionsView.ShowFooter = true;
            this.grvParts.OptionsView.ShowGroupPanel = false;
            this.grvParts.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grvParts_CustomDrawCell);
            this.grvParts.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvParts_CellValueChanged);
            this.grvParts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvParts_KeyDown);
            // 
            // colRiID
            // 
            this.colRiID.AppearanceHeader.Options.UseTextOptions = true;
            this.colRiID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRiID.Caption = "ID";
            this.colRiID.FieldName = "RID";
            this.colRiID.Name = "colRiID";
            this.colRiID.OptionsColumn.AllowEdit = false;
            // 
            // colRiProjectCode
            // 
            this.colRiProjectCode.AppearanceCell.Options.UseTextOptions = true;
            this.colRiProjectCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colRiProjectCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colRiProjectCode.AppearanceHeader.Options.UseFont = true;
            this.colRiProjectCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colRiProjectCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRiProjectCode.Caption = "Mã dự án";
            this.colRiProjectCode.FieldName = "ProjectCode";
            this.colRiProjectCode.Name = "colRiProjectCode";
            this.colRiProjectCode.OptionsColumn.AllowEdit = false;
            this.colRiProjectCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colRiProjectCode.Width = 93;
            // 
            // colRiProductCode
            // 
            this.colRiProductCode.AppearanceCell.Options.UseTextOptions = true;
            this.colRiProductCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colRiProductCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colRiProductCode.AppearanceHeader.Options.UseFont = true;
            this.colRiProductCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colRiProductCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRiProductCode.Caption = "Mã thiết bị";
            this.colRiProductCode.ColumnEdit = this.repositoryItemMemoEdit3;
            this.colRiProductCode.FieldName = "ProjectModuleCode";
            this.colRiProductCode.Name = "colRiProductCode";
            this.colRiProductCode.OptionsColumn.AllowEdit = false;
            this.colRiProductCode.Width = 76;
            // 
            // repositoryItemMemoEdit3
            // 
            this.repositoryItemMemoEdit3.Name = "repositoryItemMemoEdit3";
            // 
            // colRiPartCode
            // 
            this.colRiPartCode.AppearanceCell.Options.UseTextOptions = true;
            this.colRiPartCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colRiPartCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colRiPartCode.AppearanceHeader.Options.UseFont = true;
            this.colRiPartCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colRiPartCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRiPartCode.Caption = "Mã vật tư";
            this.colRiPartCode.FieldName = "PartsCode";
            this.colRiPartCode.Name = "colRiPartCode";
            this.colRiPartCode.OptionsColumn.AllowEdit = false;
            this.colRiPartCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colRiPartCode.Visible = true;
            this.colRiPartCode.VisibleIndex = 0;
            this.colRiPartCode.Width = 128;
            // 
            // colRiPartsName
            // 
            this.colRiPartsName.AppearanceCell.Options.UseTextOptions = true;
            this.colRiPartsName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colRiPartsName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colRiPartsName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colRiPartsName.AppearanceHeader.Options.UseFont = true;
            this.colRiPartsName.AppearanceHeader.Options.UseTextOptions = true;
            this.colRiPartsName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRiPartsName.Caption = "Tên vật tư";
            this.colRiPartsName.ColumnEdit = this.repositoryItemMemoEdit3;
            this.colRiPartsName.FieldName = "PartsName";
            this.colRiPartsName.Name = "colRiPartsName";
            this.colRiPartsName.OptionsColumn.AllowEdit = false;
            this.colRiPartsName.Visible = true;
            this.colRiPartsName.VisibleIndex = 1;
            this.colRiPartsName.Width = 218;
            // 
            // colRiManufacturerCode
            // 
            this.colRiManufacturerCode.AppearanceCell.Options.UseTextOptions = true;
            this.colRiManufacturerCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colRiManufacturerCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colRiManufacturerCode.AppearanceHeader.Options.UseFont = true;
            this.colRiManufacturerCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colRiManufacturerCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRiManufacturerCode.Caption = "Mã HSX";
            this.colRiManufacturerCode.FieldName = "ManufacturerCode";
            this.colRiManufacturerCode.Name = "colRiManufacturerCode";
            this.colRiManufacturerCode.OptionsColumn.AllowEdit = false;
            this.colRiManufacturerCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colRiManufacturerCode.Width = 91;
            // 
            // colRiOrigin
            // 
            this.colRiOrigin.AppearanceCell.Options.UseTextOptions = true;
            this.colRiOrigin.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colRiOrigin.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colRiOrigin.AppearanceHeader.Options.UseFont = true;
            this.colRiOrigin.AppearanceHeader.Options.UseTextOptions = true;
            this.colRiOrigin.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRiOrigin.Caption = "Xuất xứ";
            this.colRiOrigin.FieldName = "Origin";
            this.colRiOrigin.Name = "colRiOrigin";
            this.colRiOrigin.OptionsColumn.AllowEdit = false;
            this.colRiOrigin.Visible = true;
            this.colRiOrigin.VisibleIndex = 2;
            this.colRiOrigin.Width = 70;
            // 
            // colRiRequestCode
            // 
            this.colRiRequestCode.AppearanceCell.Options.UseTextOptions = true;
            this.colRiRequestCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colRiRequestCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colRiRequestCode.AppearanceHeader.Options.UseFont = true;
            this.colRiRequestCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colRiRequestCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRiRequestCode.Caption = "Số YCVT";
            this.colRiRequestCode.FieldName = "RequestCode";
            this.colRiRequestCode.Name = "colRiRequestCode";
            this.colRiRequestCode.OptionsColumn.AllowEdit = false;
            this.colRiRequestCode.Width = 92;
            // 
            // colRiSpecifications
            // 
            this.colRiSpecifications.AppearanceCell.Options.UseTextOptions = true;
            this.colRiSpecifications.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colRiSpecifications.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colRiSpecifications.AppearanceHeader.Options.UseFont = true;
            this.colRiSpecifications.AppearanceHeader.Options.UseTextOptions = true;
            this.colRiSpecifications.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRiSpecifications.Caption = "Thông số";
            this.colRiSpecifications.FieldName = "Specifications";
            this.colRiSpecifications.Name = "colRiSpecifications";
            this.colRiSpecifications.OptionsColumn.AllowEdit = false;
            this.colRiSpecifications.Width = 77;
            // 
            // colRiUserName
            // 
            this.colRiUserName.AppearanceCell.Options.UseTextOptions = true;
            this.colRiUserName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colRiUserName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colRiUserName.AppearanceHeader.Options.UseFont = true;
            this.colRiUserName.AppearanceHeader.Options.UseTextOptions = true;
            this.colRiUserName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRiUserName.Caption = "Người phụ trách";
            this.colRiUserName.FieldName = "UserName";
            this.colRiUserName.Name = "colRiUserName";
            this.colRiUserName.OptionsColumn.AllowEdit = false;
            this.colRiUserName.Width = 100;
            // 
            // colRiUserId
            // 
            this.colRiUserId.Caption = "UserId";
            this.colRiUserId.FieldName = "UserId";
            this.colRiUserId.Name = "colRiUserId";
            this.colRiUserId.OptionsColumn.AllowEdit = false;
            // 
            // colRiUnit
            // 
            this.colRiUnit.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colRiUnit.AppearanceHeader.Options.UseFont = true;
            this.colRiUnit.AppearanceHeader.Options.UseTextOptions = true;
            this.colRiUnit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRiUnit.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colRiUnit.Caption = "Đơn vị";
            this.colRiUnit.FieldName = "Unit";
            this.colRiUnit.Name = "colRiUnit";
            this.colRiUnit.OptionsColumn.AllowEdit = false;
            this.colRiUnit.Visible = true;
            this.colRiUnit.VisibleIndex = 3;
            // 
            // colRiQty
            // 
            this.colRiQty.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colRiQty.AppearanceHeader.Options.UseFont = true;
            this.colRiQty.AppearanceHeader.Options.UseTextOptions = true;
            this.colRiQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRiQty.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colRiQty.Caption = "SL";
            this.colRiQty.DisplayFormat.FormatString = "n0";
            this.colRiQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRiQty.FieldName = "TotalBuy";
            this.colRiQty.Name = "colRiQty";
            this.colRiQty.OptionsColumn.AllowEdit = false;
            this.colRiQty.Visible = true;
            this.colRiQty.VisibleIndex = 4;
            // 
            // colRiPrice
            // 
            this.colRiPrice.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colRiPrice.AppearanceHeader.Options.UseFont = true;
            this.colRiPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.colRiPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRiPrice.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colRiPrice.Caption = "Giá DK";
            this.colRiPrice.DisplayFormat.FormatString = "n0";
            this.colRiPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRiPrice.FieldName = "Price";
            this.colRiPrice.Name = "colRiPrice";
            this.colRiPrice.Visible = true;
            this.colRiPrice.VisibleIndex = 5;
            this.colRiPrice.Width = 101;
            // 
            // colRiTotalPrice
            // 
            this.colRiTotalPrice.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colRiTotalPrice.AppearanceHeader.Options.UseFont = true;
            this.colRiTotalPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.colRiTotalPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colRiTotalPrice.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colRiTotalPrice.Caption = "Tổng tiền";
            this.colRiTotalPrice.DisplayFormat.FormatString = "n0";
            this.colRiTotalPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRiTotalPrice.FieldName = "TotalPrice";
            this.colRiTotalPrice.Name = "colRiTotalPrice";
            this.colRiTotalPrice.OptionsColumn.AllowEdit = false;
            this.colRiTotalPrice.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPrice", "{0:n0}")});
            this.colRiTotalPrice.Visible = true;
            this.colRiTotalPrice.VisibleIndex = 6;
            this.colRiTotalPrice.Width = 117;
            // 
            // cboProductType
            // 
            this.cboProductType.FormattingEnabled = true;
            this.cboProductType.Items.AddRange(new object[] {
            "Thiêt bị mua ngoài",
            "Vật tư",
            "Vật tư tự do"});
            this.cboProductType.Location = new System.Drawing.Point(960, 12);
            this.cboProductType.Name = "cboProductType";
            this.cboProductType.Size = new System.Drawing.Size(185, 21);
            this.cboProductType.TabIndex = 1;
            this.cboProductType.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(930, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loại";
            this.label1.Visible = false;
            // 
            // mnuMenu
            // 
            this.mnuMenu.AutoSize = false;
            this.mnuMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.mnuMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExcel});
            this.mnuMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuMenu.Size = new System.Drawing.Size(1189, 42);
            this.mnuMenu.TabIndex = 190;
            this.mnuMenu.Text = "toolStrip2";
            // 
            // btnExcel
            // 
            this.btnExcel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(67, 34);
            this.btnExcel.Tag = "";
            this.btnExcel.Text = "Tạo YCVT";
            this.btnExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // colRDateExpected
            // 
            this.colRDateExpected.Caption = "Ngày dự kiến";
            this.colRDateExpected.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colRDateExpected.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colRDateExpected.FieldName = "DateExpected";
            this.colRDateExpected.Name = "colRDateExpected";
            // 
            // colRDateCreate
            // 
            this.colRDateCreate.Caption = "Ngày tạo";
            this.colRDateCreate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colRDateCreate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colRDateCreate.FieldName = "DateCreate";
            this.colRDateCreate.Name = "colRDateCreate";
            // 
            // frmYCVTmanager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 491);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.mnuMenu);
            this.Controls.Add(this.cboProductType);
            this.Controls.Add(this.label1);
            this.Name = "frmYCVTmanager";
            this.Text = "YÊU CẦU VẬT TƯ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmYCVTmanager_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdYCVT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvYCVT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdParts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvParts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).EndInit();
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboProductType;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl grdYCVT;
        private DevExpress.XtraGrid.Views.Grid.GridView grvYCVT;
        private DevExpress.XtraGrid.Columns.GridColumn colRID;
        private DevExpress.XtraGrid.Columns.GridColumn colRCode;
        private DevExpress.XtraGrid.Columns.GridColumn colRName;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colRcheck;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colRProjectCode;
        private DevExpress.XtraGrid.GridControl grdParts;
        private DevExpress.XtraGrid.Views.Grid.GridView grvParts;
        private DevExpress.XtraGrid.Columns.GridColumn colRiID;
        private DevExpress.XtraGrid.Columns.GridColumn colRiProjectCode;
        private DevExpress.XtraGrid.Columns.GridColumn colRiProductCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit3;
        private DevExpress.XtraGrid.Columns.GridColumn colRiPartCode;
        private DevExpress.XtraGrid.Columns.GridColumn colRiPartsName;
        private DevExpress.XtraGrid.Columns.GridColumn colRiManufacturerCode;
        private DevExpress.XtraGrid.Columns.GridColumn colRiOrigin;
        private DevExpress.XtraGrid.Columns.GridColumn colRiRequestCode;
        private DevExpress.XtraGrid.Columns.GridColumn colRiSpecifications;
        private DevExpress.XtraGrid.Columns.GridColumn colRiUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colRiUserId;
        private System.Windows.Forms.ToolStrip mnuMenu;
        private DevExpress.XtraGrid.Columns.GridColumn colRiUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colRiQty;
        private DevExpress.XtraGrid.Columns.GridColumn colRiPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colRiTotalPrice;
        private System.Windows.Forms.ToolStripButton btnExcel;
        private DevExpress.XtraGrid.Columns.GridColumn colRYear;
        private DevExpress.XtraGrid.Columns.GridColumn colRDateExpected;
        private DevExpress.XtraGrid.Columns.GridColumn colRDateCreate;
    }
}