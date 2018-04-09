namespace BMS
{
    partial class frmQuotationManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuotationManagement));
            this.colCustomerPercentType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalHD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalReal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalTPA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerNameF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colCustomerCodeF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProjectCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.hủyDuyệtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalProfit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeliveryTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatusText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsApproved = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.mnuMenu = new System.Windows.Forms.ToolStrip();
            this.btnNewGroup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEditGroup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDeleteGroup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReportProductGroup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnApproved = new System.Windows.Forms.ToolStripButton();
            this.label7 = new System.Windows.Forms.Label();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.btnLoadData = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.mnuMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // colCustomerPercentType
            // 
            this.colCustomerPercentType.AppearanceCell.Options.UseTextOptions = true;
            this.colCustomerPercentType.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCustomerPercentType.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCustomerPercentType.Caption = "CustomerPercentType";
            this.colCustomerPercentType.FieldName = "CustomerPercentType";
            this.colCustomerPercentType.Name = "colCustomerPercentType";
            // 
            // colTotalHD
            // 
            this.colTotalHD.AppearanceCell.Options.UseTextOptions = true;
            this.colTotalHD.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTotalHD.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalHD.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTotalHD.AppearanceHeader.Options.UseFont = true;
            this.colTotalHD.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotalHD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotalHD.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalHD.Caption = "Tổng tiền theo HĐ";
            this.colTotalHD.DisplayFormat.FormatString = "{0:#,##0.####}";
            this.colTotalHD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalHD.FieldName = "TotalHD";
            this.colTotalHD.Name = "colTotalHD";
            this.colTotalHD.OptionsColumn.AllowEdit = false;
            this.colTotalHD.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalHD", "{0:n0}")});
            this.colTotalHD.Width = 100;
            // 
            // colTotalReal
            // 
            this.colTotalReal.AppearanceCell.Options.UseTextOptions = true;
            this.colTotalReal.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTotalReal.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalReal.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTotalReal.AppearanceHeader.Options.UseFont = true;
            this.colTotalReal.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotalReal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotalReal.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalReal.Caption = "Tổng tiền thực thu";
            this.colTotalReal.DisplayFormat.FormatString = "{0:#,##0.####}";
            this.colTotalReal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalReal.FieldName = "TotalReal";
            this.colTotalReal.Name = "colTotalReal";
            this.colTotalReal.OptionsColumn.AllowEdit = false;
            this.colTotalReal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalReal", "{0:n0}")});
            this.colTotalReal.Width = 100;
            // 
            // colTotalTPA
            // 
            this.colTotalTPA.AppearanceCell.Options.UseTextOptions = true;
            this.colTotalTPA.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTotalTPA.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalTPA.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTotalTPA.AppearanceHeader.Options.UseFont = true;
            this.colTotalTPA.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotalTPA.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotalTPA.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalTPA.Caption = "Tổng tiền theo TPA";
            this.colTotalTPA.DisplayFormat.FormatString = "{0:#,##0.####}";
            this.colTotalTPA.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalTPA.FieldName = "TotalTPA";
            this.colTotalTPA.Name = "colTotalTPA";
            this.colTotalTPA.OptionsColumn.AllowEdit = false;
            this.colTotalTPA.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalTPA", "{0:n0}")});
            this.colTotalTPA.Width = 100;
            // 
            // colTotalVT
            // 
            this.colTotalVT.AppearanceCell.Options.UseTextOptions = true;
            this.colTotalVT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colTotalVT.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTotalVT.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalVT.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTotalVT.AppearanceHeader.Options.UseFont = true;
            this.colTotalVT.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotalVT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotalVT.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalVT.Caption = "Tổng tiền vật tư";
            this.colTotalVT.DisplayFormat.FormatString = "{0:#,##0.####}";
            this.colTotalVT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalVT.FieldName = "TotalVT";
            this.colTotalVT.Name = "colTotalVT";
            this.colTotalVT.OptionsColumn.AllowEdit = false;
            this.colTotalVT.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalVT", "{0:n0}")});
            this.colTotalVT.Width = 100;
            // 
            // colCustomerTotal
            // 
            this.colCustomerTotal.AppearanceCell.Options.UseTextOptions = true;
            this.colCustomerTotal.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCustomerTotal.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCustomerTotal.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCustomerTotal.AppearanceHeader.Options.UseFont = true;
            this.colCustomerTotal.AppearanceHeader.Options.UseTextOptions = true;
            this.colCustomerTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCustomerTotal.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCustomerTotal.Caption = "Tổng tiền chi KH";
            this.colCustomerTotal.DisplayFormat.FormatString = "{0:#,##0.####}";
            this.colCustomerTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCustomerTotal.FieldName = "TotalCustomer";
            this.colCustomerTotal.Name = "colCustomerTotal";
            this.colCustomerTotal.OptionsColumn.AllowEdit = false;
            this.colCustomerTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CustomerTotal", "{0:n0}")});
            this.colCustomerTotal.Width = 100;
            // 
            // colTax
            // 
            this.colTax.AppearanceCell.Options.UseTextOptions = true;
            this.colTax.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTax.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTax.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTax.AppearanceHeader.Options.UseFont = true;
            this.colTax.AppearanceHeader.Options.UseTextOptions = true;
            this.colTax.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTax.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTax.Caption = "Thuế GTGT";
            this.colTax.DisplayFormat.FormatString = "{0:#,##0.####}";
            this.colTax.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTax.FieldName = "Tax";
            this.colTax.Name = "colTax";
            this.colTax.OptionsColumn.AllowEdit = false;
            this.colTax.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CustomerCash", "{0:n0}")});
            this.colTax.Width = 100;
            // 
            // colCustomerNameF
            // 
            this.colCustomerNameF.AppearanceCell.Options.UseTextOptions = true;
            this.colCustomerNameF.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCustomerNameF.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCustomerNameF.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCustomerNameF.AppearanceHeader.Options.UseFont = true;
            this.colCustomerNameF.AppearanceHeader.Options.UseTextOptions = true;
            this.colCustomerNameF.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCustomerNameF.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCustomerNameF.Caption = "Tên KH cuối";
            this.colCustomerNameF.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colCustomerNameF.FieldName = "CustomerNameF";
            this.colCustomerNameF.Name = "colCustomerNameF";
            this.colCustomerNameF.OptionsColumn.AllowEdit = false;
            this.colCustomerNameF.Visible = true;
            this.colCustomerNameF.VisibleIndex = 8;
            this.colCustomerNameF.Width = 134;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Appearance.Options.UseTextOptions = true;
            this.repositoryItemMemoEdit1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // colCustomerCodeF
            // 
            this.colCustomerCodeF.AppearanceCell.Options.UseTextOptions = true;
            this.colCustomerCodeF.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCustomerCodeF.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCustomerCodeF.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCustomerCodeF.AppearanceHeader.Options.UseFont = true;
            this.colCustomerCodeF.AppearanceHeader.Options.UseTextOptions = true;
            this.colCustomerCodeF.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCustomerCodeF.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCustomerCodeF.Caption = "Mã KH cuối";
            this.colCustomerCodeF.FieldName = "CustomerCodeF";
            this.colCustomerCodeF.Name = "colCustomerCodeF";
            this.colCustomerCodeF.OptionsColumn.AllowEdit = false;
            this.colCustomerCodeF.Visible = true;
            this.colCustomerCodeF.VisibleIndex = 7;
            // 
            // colCustomerName
            // 
            this.colCustomerName.AppearanceCell.Options.UseTextOptions = true;
            this.colCustomerName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCustomerName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCustomerName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCustomerName.AppearanceHeader.Options.UseFont = true;
            this.colCustomerName.AppearanceHeader.Options.UseTextOptions = true;
            this.colCustomerName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCustomerName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCustomerName.Caption = "Tên khách hàng";
            this.colCustomerName.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.OptionsColumn.AllowEdit = false;
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 6;
            this.colCustomerName.Width = 126;
            // 
            // colCustomerCode
            // 
            this.colCustomerCode.AppearanceCell.Options.UseTextOptions = true;
            this.colCustomerCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCustomerCode.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCustomerCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCustomerCode.AppearanceHeader.Options.UseFont = true;
            this.colCustomerCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colCustomerCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCustomerCode.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCustomerCode.Caption = "Mã khách hàng";
            this.colCustomerCode.FieldName = "CustomerCode";
            this.colCustomerCode.Name = "colCustomerCode";
            this.colCustomerCode.OptionsColumn.AllowEdit = false;
            this.colCustomerCode.Visible = true;
            this.colCustomerCode.VisibleIndex = 5;
            // 
            // colProjectName
            // 
            this.colProjectName.AppearanceCell.Options.UseTextOptions = true;
            this.colProjectName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colProjectName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colProjectName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colProjectName.AppearanceHeader.Options.UseFont = true;
            this.colProjectName.AppearanceHeader.Options.UseTextOptions = true;
            this.colProjectName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProjectName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colProjectName.Caption = "Tên dự án";
            this.colProjectName.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colProjectName.FieldName = "ProjectName";
            this.colProjectName.Name = "colProjectName";
            this.colProjectName.OptionsColumn.AllowEdit = false;
            this.colProjectName.Visible = true;
            this.colProjectName.VisibleIndex = 4;
            this.colProjectName.Width = 145;
            // 
            // colProjectCode
            // 
            this.colProjectCode.AppearanceCell.Options.UseTextOptions = true;
            this.colProjectCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colProjectCode.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colProjectCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colProjectCode.AppearanceHeader.Options.UseFont = true;
            this.colProjectCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colProjectCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProjectCode.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colProjectCode.Caption = "Mã dự án";
            this.colProjectCode.FieldName = "ProjectCode";
            this.colProjectCode.Name = "colProjectCode";
            this.colProjectCode.OptionsColumn.AllowEdit = false;
            this.colProjectCode.Visible = true;
            this.colProjectCode.VisibleIndex = 3;
            // 
            // grdData
            // 
            this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdData.ContextMenuStrip = this.contextMenuStrip1;
            this.grdData.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdData.Location = new System.Drawing.Point(0, 45);
            this.grdData.MainView = this.grvData;
            this.grdData.Name = "grdData";
            this.grdData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1,
            this.repositoryItemCheckEdit1});
            this.grdData.Size = new System.Drawing.Size(1108, 542);
            this.grdData.TabIndex = 19;
            this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvData});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hủyDuyệtToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(130, 26);
            // 
            // hủyDuyệtToolStripMenuItem
            // 
            this.hủyDuyệtToolStripMenuItem.Name = "hủyDuyệtToolStripMenuItem";
            this.hủyDuyệtToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.hủyDuyệtToolStripMenuItem.Text = "Hủy duyệt";
            this.hủyDuyệtToolStripMenuItem.Click += new System.EventHandler(this.hủyDuyệtToolStripMenuItem_Click);
            // 
            // grvData
            // 
            this.grvData.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvData.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvData.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvData.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvData.ColumnPanelRowHeight = 40;
            this.grvData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode,
            this.colID,
            this.colProjectCode,
            this.colProjectName,
            this.colCustomerCode,
            this.colCustomerName,
            this.colCustomerCodeF,
            this.colCustomerNameF,
            this.colTax,
            this.colCustomerTotal,
            this.colTotalVT,
            this.colTotalTPA,
            this.colTotalReal,
            this.colTotalHD,
            this.colCustomerPercentType,
            this.colTotalProfit,
            this.colDName,
            this.colDeliveryTime,
            this.colStatusText,
            this.colIsApproved});
            this.grvData.GridControl = this.grdData;
            this.grvData.HorzScrollStep = 5;
            this.grvData.Name = "grvData";
            this.grvData.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvData.OptionsCustomization.AllowRowSizing = true;
            this.grvData.OptionsFind.AlwaysVisible = true;
            this.grvData.OptionsFind.ShowCloseButton = false;
            this.grvData.OptionsView.ColumnAutoWidth = false;
            this.grvData.OptionsView.RowAutoHeight = true;
            this.grvData.OptionsView.ShowFooter = true;
            this.grvData.OptionsView.ShowGroupPanel = false;
            this.grvData.DoubleClick += new System.EventHandler(this.grvData_DoubleClick);
            // 
            // colCode
            // 
            this.colCode.AppearanceCell.Options.UseTextOptions = true;
            this.colCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCode.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCode.AppearanceHeader.Options.UseFont = true;
            this.colCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCode.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCode.Caption = "Mã";
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.OptionsColumn.AllowEdit = false;
            this.colCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 2;
            this.colCode.Width = 99;
            // 
            // colID
            // 
            this.colID.AppearanceCell.Options.UseTextOptions = true;
            this.colID.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colID.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colID.AppearanceHeader.Options.UseTextOptions = true;
            this.colID.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colTotalProfit
            // 
            this.colTotalProfit.AppearanceCell.Options.UseTextOptions = true;
            this.colTotalProfit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colTotalProfit.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTotalProfit.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalProfit.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTotalProfit.AppearanceHeader.Options.UseFont = true;
            this.colTotalProfit.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotalProfit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotalProfit.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalProfit.Caption = "Lợi nhuận";
            this.colTotalProfit.DisplayFormat.FormatString = "{0:#,##0.####}";
            this.colTotalProfit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalProfit.FieldName = "TotalProfit";
            this.colTotalProfit.Name = "colTotalProfit";
            this.colTotalProfit.OptionsColumn.AllowEdit = false;
            this.colTotalProfit.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPhatSinh", "{0:n0}")});
            this.colTotalProfit.Width = 100;
            // 
            // colDName
            // 
            this.colDName.AppearanceCell.Options.UseTextOptions = true;
            this.colDName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colDName.AppearanceHeader.Options.UseFont = true;
            this.colDName.AppearanceHeader.Options.UseTextOptions = true;
            this.colDName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDName.Caption = "Phòng phụ trách";
            this.colDName.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colDName.FieldName = "Name";
            this.colDName.Name = "colDName";
            this.colDName.OptionsColumn.AllowEdit = false;
            this.colDName.Visible = true;
            this.colDName.VisibleIndex = 9;
            this.colDName.Width = 100;
            // 
            // colDeliveryTime
            // 
            this.colDeliveryTime.AppearanceCell.Options.UseTextOptions = true;
            this.colDeliveryTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDeliveryTime.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDeliveryTime.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colDeliveryTime.AppearanceHeader.Options.UseFont = true;
            this.colDeliveryTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colDeliveryTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDeliveryTime.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDeliveryTime.Caption = "Thời gian giao hàng";
            this.colDeliveryTime.FieldName = "DeliveryTime";
            this.colDeliveryTime.Name = "colDeliveryTime";
            this.colDeliveryTime.OptionsColumn.AllowEdit = false;
            this.colDeliveryTime.Visible = true;
            this.colDeliveryTime.VisibleIndex = 10;
            // 
            // colStatusText
            // 
            this.colStatusText.AppearanceCell.Options.UseTextOptions = true;
            this.colStatusText.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colStatusText.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colStatusText.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colStatusText.AppearanceHeader.Options.UseFont = true;
            this.colStatusText.AppearanceHeader.Options.UseTextOptions = true;
            this.colStatusText.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStatusText.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colStatusText.Caption = "Trạng thái";
            this.colStatusText.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colStatusText.FieldName = "StatusText";
            this.colStatusText.Name = "colStatusText";
            this.colStatusText.OptionsColumn.AllowEdit = false;
            this.colStatusText.Visible = true;
            this.colStatusText.VisibleIndex = 1;
            this.colStatusText.Width = 126;
            // 
            // colIsApproved
            // 
            this.colIsApproved.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colIsApproved.AppearanceHeader.Options.UseFont = true;
            this.colIsApproved.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsApproved.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsApproved.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colIsApproved.Caption = "Duyệt";
            this.colIsApproved.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colIsApproved.FieldName = "IsApproved";
            this.colIsApproved.Name = "colIsApproved";
            this.colIsApproved.OptionsColumn.AllowEdit = false;
            this.colIsApproved.Visible = true;
            this.colIsApproved.VisibleIndex = 0;
            this.colIsApproved.Width = 51;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // mnuMenu
            // 
            this.mnuMenu.AutoSize = false;
            this.mnuMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.mnuMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewGroup,
            this.toolStripSeparator9,
            this.btnEditGroup,
            this.toolStripSeparator8,
            this.btnDeleteGroup,
            this.toolStripSeparator6,
            this.btnNew,
            this.toolStripSeparator4,
            this.btnReport,
            this.toolStripSeparator1,
            this.btnReportProductGroup,
            this.toolStripSeparator3,
            this.btnApproved});
            this.mnuMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuMenu.Size = new System.Drawing.Size(1108, 42);
            this.mnuMenu.TabIndex = 18;
            this.mnuMenu.Text = "toolStrip2";
            // 
            // btnNewGroup
            // 
            this.btnNewGroup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnNewGroup.Image")));
            this.btnNewGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewGroup.Name = "btnNewGroup";
            this.btnNewGroup.Size = new System.Drawing.Size(76, 33);
            this.btnNewGroup.Tag = "frmQuotationManagement_Add";
            this.btnNewGroup.Text = "&Tạo báo giá";
            this.btnNewGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNewGroup.Click += new System.EventHandler(this.btnNewGroup_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 23);
            // 
            // btnEditGroup
            // 
            this.btnEditGroup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnEditGroup.Image")));
            this.btnEditGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditGroup.Name = "btnEditGroup";
            this.btnEditGroup.Size = new System.Drawing.Size(77, 33);
            this.btnEditGroup.Tag = "frmQuotationManagement_Edit";
            this.btnEditGroup.Text = "Sửa báo giá";
            this.btnEditGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEditGroup.Click += new System.EventHandler(this.btnEditGroup_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 23);
            // 
            // btnDeleteGroup
            // 
            this.btnDeleteGroup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteGroup.Image")));
            this.btnDeleteGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteGroup.Name = "btnDeleteGroup";
            this.btnDeleteGroup.Size = new System.Drawing.Size(76, 33);
            this.btnDeleteGroup.Tag = "frmQuotationManagement_Delete";
            this.btnDeleteGroup.Text = "Xóa báo giá";
            this.btnDeleteGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDeleteGroup.Click += new System.EventHandler(this.btnDeleteGroup_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.AutoSize = false;
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 40);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(112, 33);
            this.btnNew.Tag = "frmQuotationManagementKD_ListModuleKD";
            this.btnNew.Text = "Danh sách thiết bị";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Image = ((System.Drawing.Image)(resources.GetObject("btnReport.Image")));
            this.btnReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(55, 33);
            this.btnReport.Tag = "frmQuotationManagementKD_ReportKD";
            this.btnReport.Text = "Báo cáo";
            this.btnReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // btnReportProductGroup
            // 
            this.btnReportProductGroup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportProductGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnReportProductGroup.Image")));
            this.btnReportProductGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReportProductGroup.Name = "btnReportProductGroup";
            this.btnReportProductGroup.Size = new System.Drawing.Size(153, 33);
            this.btnReportProductGroup.Tag = "";
            this.btnReportProductGroup.Text = "Báo cáo theo ngành hàng";
            this.btnReportProductGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnReportProductGroup.Click += new System.EventHandler(this.btnReportProductGroup_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
            // 
            // btnApproved
            // 
            this.btnApproved.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApproved.Image = ((System.Drawing.Image)(resources.GetObject("btnApproved.Image")));
            this.btnApproved.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnApproved.Name = "btnApproved";
            this.btnApproved.Size = new System.Drawing.Size(45, 33);
            this.btnApproved.Tag = "frmQuotationManagement_Approved";
            this.btnApproved.Text = "Duyệt";
            this.btnApproved.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnApproved.Click += new System.EventHandler(this.btnApproved_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(500, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 249;
            this.label7.Text = "Năm";
            // 
            // cboYear
            // 
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(533, 58);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(99, 21);
            this.cboYear.TabIndex = 248;
            // 
            // btnLoadData
            // 
            this.btnLoadData.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnLoadData.Appearance.Options.UseFont = true;
            this.btnLoadData.Location = new System.Drawing.Point(642, 56);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(75, 23);
            this.btnLoadData.TabIndex = 247;
            this.btnLoadData.Text = "Tải dữ liệu";
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // frmQuotationManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 587);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboYear);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.grdData);
            this.Controls.Add(this.mnuMenu);
            this.Name = "frmQuotationManagement";
            this.Text = "QUẢN LÝ BÁO GIÁ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.QuotationManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn colCustomerPercentType;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalHD;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalReal;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalTPA;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalVT;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colTax;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerNameF;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerCodeF;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerCode;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectName;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectCode;
        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.Grid.GridView grvData;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalProfit;
        private System.Windows.Forms.ToolStrip mnuMenu;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripButton btnNewGroup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton btnEditGroup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton btnDeleteGroup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private DevExpress.XtraGrid.Columns.GridColumn colDName;
        private DevExpress.XtraGrid.Columns.GridColumn colDeliveryTime;
        private DevExpress.XtraGrid.Columns.GridColumn colStatusText;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnReport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnReportProductGroup;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hủyDuyệtToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn colIsApproved;
        private System.Windows.Forms.ToolStripButton btnApproved;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboYear;
        private DevExpress.XtraEditors.SimpleButton btnLoadData;
    }
}