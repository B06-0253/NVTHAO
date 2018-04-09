namespace BMS
{
    partial class frmGetPriceForYCMVT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGetPriceForYCMVT));
            this.cboUser = new System.Windows.Forms.ComboBox();
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.grvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProjectCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPriceGN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChenhLech = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeliveryTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDeliveryTime1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModuleCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProposalCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalBuy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalChenhLech = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHsCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTonKho = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRequestCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.grdYCMVT = new DevExpress.XtraGrid.GridControl();
            this.grvYCMVT = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCodeYC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCheck = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.colSupplierCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnExeclGroup = new DevExpress.XtraEditors.SimpleButton();
            this.btnLoadPrice = new System.Windows.Forms.Button();
            this.btnImportPrice = new System.Windows.Forms.Button();
            this.btnExportYCMVT = new DevExpress.XtraEditors.SimpleButton();
            this.btnExportCK = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdYCMVT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvYCMVT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // cboUser
            // 
            this.cboUser.FormattingEnabled = true;
            this.cboUser.Location = new System.Drawing.Point(61, 10);
            this.cboUser.Name = "cboUser";
            this.cboUser.Size = new System.Drawing.Size(203, 21);
            this.cboUser.TabIndex = 0;
            this.cboUser.SelectionChangeCommitted += new System.EventHandler(this.cboUser_SelectionChangeCommitted);
            // 
            // grdData
            // 
            this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdData.Location = new System.Drawing.Point(351, 40);
            this.grdData.MainView = this.grvData;
            this.grdData.Name = "grdData";
            this.grdData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1,
            this.repositoryItemTextEdit1});
            this.grdData.Size = new System.Drawing.Size(980, 382);
            this.grdData.TabIndex = 193;
            this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvData});
            // 
            // grvData
            // 
            this.grvData.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvData.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvData.ColumnPanelRowHeight = 40;
            this.grvData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProjectCode,
            this.colCode,
            this.colName,
            this.colPrice,
            this.colPriceGN,
            this.colChenhLech,
            this.colDeliveryTime,
            this.colDeliveryTime1,
            this.colModuleCode,
            this.colProposalCode,
            this.colTotalBuy,
            this.colTotalChenhLech,
            this.colDescription,
            this.colHsCode,
            this.colTax,
            this.colTonKho,
            this.colTotal,
            this.colRequestCode});
            this.grvData.GridControl = this.grdData;
            this.grvData.Name = "grvData";
            this.grvData.OptionsView.ColumnAutoWidth = false;
            this.grvData.OptionsView.RowAutoHeight = true;
            this.grvData.OptionsView.ShowFooter = true;
            this.grvData.OptionsView.ShowGroupPanel = false;
            this.grvData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvData_KeyDown);
            // 
            // colProjectCode
            // 
            this.colProjectCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colProjectCode.AppearanceHeader.Options.UseFont = true;
            this.colProjectCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colProjectCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProjectCode.Caption = "Dự án";
            this.colProjectCode.FieldName = "ProjectCode";
            this.colProjectCode.Name = "colProjectCode";
            this.colProjectCode.OptionsColumn.AllowEdit = false;
            this.colProjectCode.Visible = true;
            this.colProjectCode.VisibleIndex = 2;
            // 
            // colCode
            // 
            this.colCode.AppearanceCell.Options.UseTextOptions = true;
            this.colCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCode.AppearanceHeader.Options.UseFont = true;
            this.colCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCode.Caption = "Mã vật tư";
            this.colCode.FieldName = "PartsCode";
            this.colCode.Name = "colCode";
            this.colCode.OptionsColumn.AllowEdit = false;
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            this.colCode.Width = 131;
            // 
            // colName
            // 
            this.colName.AppearanceCell.Options.UseTextOptions = true;
            this.colName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colName.AppearanceHeader.Options.UseFont = true;
            this.colName.AppearanceHeader.Options.UseTextOptions = true;
            this.colName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colName.Caption = "Tên vật tư";
            this.colName.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colName.FieldName = "PartsName";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 223;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // colPrice
            // 
            this.colPrice.AppearanceCell.Options.UseTextOptions = true;
            this.colPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colPrice.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPrice.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colPrice.AppearanceHeader.Options.UseFont = true;
            this.colPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.colPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPrice.Caption = "Giá";
            this.colPrice.DisplayFormat.FormatString = "n2";
            this.colPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrice.FieldName = "Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.OptionsColumn.AllowEdit = false;
            this.colPrice.Visible = true;
            this.colPrice.VisibleIndex = 5;
            this.colPrice.Width = 95;
            // 
            // colPriceGN
            // 
            this.colPriceGN.AppearanceCell.Options.UseTextOptions = true;
            this.colPriceGN.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPriceGN.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colPriceGN.AppearanceHeader.Options.UseFont = true;
            this.colPriceGN.AppearanceHeader.Options.UseTextOptions = true;
            this.colPriceGN.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPriceGN.Caption = "Giá định mức";
            this.colPriceGN.DisplayFormat.FormatString = "n2";
            this.colPriceGN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPriceGN.FieldName = "PriceDM";
            this.colPriceGN.Name = "colPriceGN";
            this.colPriceGN.OptionsColumn.AllowEdit = false;
            this.colPriceGN.Visible = true;
            this.colPriceGN.VisibleIndex = 6;
            this.colPriceGN.Width = 96;
            // 
            // colChenhLech
            // 
            this.colChenhLech.AppearanceCell.Options.UseTextOptions = true;
            this.colChenhLech.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colChenhLech.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colChenhLech.AppearanceHeader.Options.UseFont = true;
            this.colChenhLech.AppearanceHeader.Options.UseTextOptions = true;
            this.colChenhLech.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colChenhLech.Caption = "Chênh lệch";
            this.colChenhLech.DisplayFormat.FormatString = "n2";
            this.colChenhLech.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colChenhLech.FieldName = "ChenhLech";
            this.colChenhLech.Name = "colChenhLech";
            this.colChenhLech.OptionsColumn.AllowEdit = false;
            this.colChenhLech.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ChenhLech", "{0:n2}")});
            this.colChenhLech.Visible = true;
            this.colChenhLech.VisibleIndex = 7;
            this.colChenhLech.Width = 90;
            // 
            // colDeliveryTime
            // 
            this.colDeliveryTime.AppearanceCell.Options.UseTextOptions = true;
            this.colDeliveryTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDeliveryTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDeliveryTime.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colDeliveryTime.AppearanceHeader.Options.UseFont = true;
            this.colDeliveryTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colDeliveryTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDeliveryTime.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDeliveryTime.Caption = "Ngày giao hàng";
            this.colDeliveryTime.DisplayFormat.FormatString = "n0";
            this.colDeliveryTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDeliveryTime.FieldName = "DeliveryTime";
            this.colDeliveryTime.Name = "colDeliveryTime";
            this.colDeliveryTime.OptionsColumn.AllowEdit = false;
            this.colDeliveryTime.Visible = true;
            this.colDeliveryTime.VisibleIndex = 9;
            this.colDeliveryTime.Width = 105;
            // 
            // colDeliveryTime1
            // 
            this.colDeliveryTime1.AppearanceCell.Options.UseTextOptions = true;
            this.colDeliveryTime1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDeliveryTime1.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDeliveryTime1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colDeliveryTime1.AppearanceHeader.Options.UseFont = true;
            this.colDeliveryTime1.AppearanceHeader.Options.UseTextOptions = true;
            this.colDeliveryTime1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDeliveryTime1.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDeliveryTime1.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDeliveryTime1.Caption = "Ngày giao hàng gần nhất";
            this.colDeliveryTime1.DisplayFormat.FormatString = "n0";
            this.colDeliveryTime1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDeliveryTime1.FieldName = "DeliveryTimeDM";
            this.colDeliveryTime1.Name = "colDeliveryTime1";
            this.colDeliveryTime1.OptionsColumn.AllowEdit = false;
            this.colDeliveryTime1.Visible = true;
            this.colDeliveryTime1.VisibleIndex = 10;
            this.colDeliveryTime1.Width = 101;
            // 
            // colModuleCode
            // 
            this.colModuleCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colModuleCode.AppearanceHeader.Options.UseFont = true;
            this.colModuleCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colModuleCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colModuleCode.Caption = "Module";
            this.colModuleCode.FieldName = "ModuleCode";
            this.colModuleCode.Name = "colModuleCode";
            this.colModuleCode.OptionsColumn.AllowEdit = false;
            this.colModuleCode.Visible = true;
            this.colModuleCode.VisibleIndex = 4;
            // 
            // colProposalCode
            // 
            this.colProposalCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colProposalCode.AppearanceHeader.Options.UseFont = true;
            this.colProposalCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colProposalCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProposalCode.Caption = "YCMVT";
            this.colProposalCode.FieldName = "ProposalCode";
            this.colProposalCode.Name = "colProposalCode";
            this.colProposalCode.OptionsColumn.AllowEdit = false;
            this.colProposalCode.Visible = true;
            this.colProposalCode.VisibleIndex = 11;
            this.colProposalCode.Width = 110;
            // 
            // colTotalBuy
            // 
            this.colTotalBuy.AppearanceCell.Options.UseTextOptions = true;
            this.colTotalBuy.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colTotalBuy.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTotalBuy.AppearanceHeader.Options.UseFont = true;
            this.colTotalBuy.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotalBuy.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotalBuy.Caption = "SL";
            this.colTotalBuy.DisplayFormat.FormatString = "n2";
            this.colTotalBuy.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalBuy.FieldName = "TotalBuy";
            this.colTotalBuy.Name = "colTotalBuy";
            this.colTotalBuy.Visible = true;
            this.colTotalBuy.VisibleIndex = 3;
            this.colTotalBuy.Width = 56;
            // 
            // colTotalChenhLech
            // 
            this.colTotalChenhLech.AppearanceCell.Options.UseTextOptions = true;
            this.colTotalChenhLech.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colTotalChenhLech.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTotalChenhLech.AppearanceHeader.Options.UseFont = true;
            this.colTotalChenhLech.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotalChenhLech.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotalChenhLech.Caption = "Tổng chênh lệch";
            this.colTotalChenhLech.DisplayFormat.FormatString = "n2";
            this.colTotalChenhLech.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalChenhLech.FieldName = "TotalChenhLech";
            this.colTotalChenhLech.Name = "colTotalChenhLech";
            this.colTotalChenhLech.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalChenhLech", "{0:n2}")});
            this.colTotalChenhLech.Visible = true;
            this.colTotalChenhLech.VisibleIndex = 8;
            this.colTotalChenhLech.Width = 100;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Diễn giải";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            // 
            // colHsCode
            // 
            this.colHsCode.Caption = "HS code";
            this.colHsCode.FieldName = "HsCode";
            this.colHsCode.Name = "colHsCode";
            // 
            // colTax
            // 
            this.colTax.Caption = "Thuế";
            this.colTax.FieldName = "ImportTax";
            this.colTax.Name = "colTax";
            // 
            // colTonKho
            // 
            this.colTonKho.Caption = "Tồn kho";
            this.colTonKho.FieldName = "TotalInventory";
            this.colTonKho.Name = "colTonKho";
            // 
            // colTotal
            // 
            this.colTotal.Caption = "Sl yêu cầu";
            this.colTotal.FieldName = "Total";
            this.colTotal.Name = "colTotal";
            // 
            // colRequestCode
            // 
            this.colRequestCode.Caption = "YCVT";
            this.colRequestCode.FieldName = "RequestCode";
            this.colRequestCode.Name = "colRequestCode";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.DisplayFormat.FormatString = "n0";
            this.repositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit1.EditFormat.FormatString = "n0";
            this.repositoryItemTextEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit1.Mask.EditMask = "n0";
            this.repositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTextEdit1.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // grdYCMVT
            // 
            this.grdYCMVT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdYCMVT.Location = new System.Drawing.Point(2, 40);
            this.grdYCMVT.MainView = this.grvYCMVT;
            this.grdYCMVT.Name = "grdYCMVT";
            this.grdYCMVT.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit2,
            this.repositoryItemTextEdit2,
            this.repositoryItemCheckEdit1});
            this.grdYCMVT.Size = new System.Drawing.Size(343, 382);
            this.grdYCMVT.TabIndex = 193;
            this.grdYCMVT.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvYCMVT});
            // 
            // grvYCMVT
            // 
            this.grvYCMVT.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvYCMVT.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvYCMVT.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvYCMVT.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvYCMVT.ColumnPanelRowHeight = 40;
            this.grvYCMVT.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCodeYC,
            this.colYear,
            this.colMonth,
            this.colCheck});
            this.grvYCMVT.GridControl = this.grdYCMVT;
            this.grvYCMVT.GroupCount = 2;
            this.grvYCMVT.Name = "grvYCMVT";
            this.grvYCMVT.OptionsFind.AlwaysVisible = true;
            this.grvYCMVT.OptionsView.ColumnAutoWidth = false;
            this.grvYCMVT.OptionsView.RowAutoHeight = true;
            this.grvYCMVT.OptionsView.ShowGroupPanel = false;
            this.grvYCMVT.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colYear, DevExpress.Data.ColumnSortOrder.Descending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colMonth, DevExpress.Data.ColumnSortOrder.Descending)});
            this.grvYCMVT.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvYCMVT_FocusedRowChanged);
            this.grvYCMVT.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvYCMVT_CellValueChanged);
            this.grvYCMVT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvYCMVT_KeyDown);
            // 
            // colCodeYC
            // 
            this.colCodeYC.AppearanceCell.Options.UseTextOptions = true;
            this.colCodeYC.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCodeYC.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCodeYC.AppearanceHeader.Options.UseFont = true;
            this.colCodeYC.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodeYC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodeYC.Caption = "YCMVT";
            this.colCodeYC.FieldName = "ProposalCode";
            this.colCodeYC.Name = "colCodeYC";
            this.colCodeYC.OptionsColumn.AllowEdit = false;
            this.colCodeYC.Visible = true;
            this.colCodeYC.VisibleIndex = 1;
            this.colCodeYC.Width = 233;
            // 
            // colYear
            // 
            this.colYear.AppearanceCell.Options.UseTextOptions = true;
            this.colYear.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colYear.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colYear.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colYear.AppearanceHeader.Options.UseFont = true;
            this.colYear.AppearanceHeader.Options.UseTextOptions = true;
            this.colYear.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colYear.Caption = "Năm";
            this.colYear.FieldName = "Year";
            this.colYear.Name = "colYear";
            this.colYear.OptionsColumn.AllowEdit = false;
            this.colYear.Width = 95;
            // 
            // colMonth
            // 
            this.colMonth.AppearanceCell.Options.UseTextOptions = true;
            this.colMonth.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colMonth.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMonth.AppearanceHeader.Options.UseFont = true;
            this.colMonth.AppearanceHeader.Options.UseTextOptions = true;
            this.colMonth.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMonth.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colMonth.Caption = "Tháng";
            this.colMonth.FieldName = "Month";
            this.colMonth.Name = "colMonth";
            this.colMonth.OptionsColumn.AllowEdit = false;
            this.colMonth.OptionsColumn.AllowFocus = false;
            this.colMonth.Width = 97;
            // 
            // colCheck
            // 
            this.colCheck.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCheck.AppearanceHeader.Options.UseFont = true;
            this.colCheck.AppearanceHeader.Options.UseTextOptions = true;
            this.colCheck.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCheck.Caption = "Chọn";
            this.colCheck.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colCheck.FieldName = "check";
            this.colCheck.Name = "colCheck";
            this.colCheck.Visible = true;
            this.colCheck.VisibleIndex = 0;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.EditValueChanged += new System.EventHandler(this.repositoryItemCheckEdit1_EditValueChanged);
            // 
            // repositoryItemMemoEdit2
            // 
            this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.DisplayFormat.FormatString = "n0";
            this.repositoryItemTextEdit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit2.EditFormat.FormatString = "n0";
            this.repositoryItemTextEdit2.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit2.Mask.EditMask = "n0";
            this.repositoryItemTextEdit2.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTextEdit2.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 194;
            this.label1.Text = "Nhân viên";
            // 
            // colSupplierCode
            // 
            this.colSupplierCode.AppearanceCell.Options.UseTextOptions = true;
            this.colSupplierCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colSupplierCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colSupplierCode.AppearanceHeader.Options.UseFont = true;
            this.colSupplierCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colSupplierCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSupplierCode.Caption = "Mã nhà CC";
            this.colSupplierCode.FieldName = "F4";
            this.colSupplierCode.Name = "colSupplierCode";
            this.colSupplierCode.Visible = true;
            this.colSupplierCode.VisibleIndex = 2;
            this.colSupplierCode.Width = 110;
            // 
            // btnExeclGroup
            // 
            this.btnExeclGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExeclGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnExeclGroup.Image")));
            this.btnExeclGroup.Location = new System.Drawing.Point(1227, 8);
            this.btnExeclGroup.Name = "btnExeclGroup";
            this.btnExeclGroup.Size = new System.Drawing.Size(104, 23);
            this.btnExeclGroup.TabIndex = 195;
            this.btnExeclGroup.Text = "Xuất excel";
            this.btnExeclGroup.Click += new System.EventHandler(this.btnExeclGroup_Click);
            // 
            // btnLoadPrice
            // 
            this.btnLoadPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadPrice.Location = new System.Drawing.Point(1005, 8);
            this.btnLoadPrice.Name = "btnLoadPrice";
            this.btnLoadPrice.Size = new System.Drawing.Size(113, 23);
            this.btnLoadPrice.TabIndex = 196;
            this.btnLoadPrice.Text = "Load giá định mức";
            this.btnLoadPrice.UseVisualStyleBackColor = true;
            this.btnLoadPrice.Click += new System.EventHandler(this.btnLoadPrice_Click);
            // 
            // btnImportPrice
            // 
            this.btnImportPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportPrice.Location = new System.Drawing.Point(1119, 8);
            this.btnImportPrice.Name = "btnImportPrice";
            this.btnImportPrice.Size = new System.Drawing.Size(102, 23);
            this.btnImportPrice.TabIndex = 196;
            this.btnImportPrice.Text = "Import giá NCC";
            this.btnImportPrice.UseVisualStyleBackColor = true;
            this.btnImportPrice.Click += new System.EventHandler(this.btnImportPrice_Click);
            // 
            // btnExportYCMVT
            // 
            this.btnExportYCMVT.Image = ((System.Drawing.Image)(resources.GetObject("btnExportYCMVT.Image")));
            this.btnExportYCMVT.Location = new System.Drawing.Point(270, 8);
            this.btnExportYCMVT.Name = "btnExportYCMVT";
            this.btnExportYCMVT.Size = new System.Drawing.Size(93, 23);
            this.btnExportYCMVT.TabIndex = 195;
            this.btnExportYCMVT.Text = "Xuất YCMVT";
            this.btnExportYCMVT.Click += new System.EventHandler(this.btnExportYCMVT_Click);
            // 
            // btnExportCK
            // 
            this.btnExportCK.Image = ((System.Drawing.Image)(resources.GetObject("btnExportCK.Image")));
            this.btnExportCK.Location = new System.Drawing.Point(369, 8);
            this.btnExportCK.Name = "btnExportCK";
            this.btnExportCK.Size = new System.Drawing.Size(123, 23);
            this.btnExportCK.TabIndex = 195;
            this.btnExportCK.Text = "Xuất YCMVT cơ khí";
            this.btnExportCK.Click += new System.EventHandler(this.btnExportCK_Click);
            // 
            // frmGetPriceForYCMVT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1333, 427);
            this.Controls.Add(this.btnImportPrice);
            this.Controls.Add(this.btnLoadPrice);
            this.Controls.Add(this.btnExportCK);
            this.Controls.Add(this.btnExportYCMVT);
            this.Controls.Add(this.btnExeclGroup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grdYCMVT);
            this.Controls.Add(this.grdData);
            this.Controls.Add(this.cboUser);
            this.Name = "frmGetPriceForYCMVT";
            this.Text = "LẤY GIÁ GẦN NHẤT CỦA VẬT TƯ TRONG YCMVT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmGetPriceForYCMVT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdYCMVT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvYCMVT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboUser;
        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.Grid.GridView grvData;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.GridControl grdYCMVT;
        private DevExpress.XtraGrid.Views.Grid.GridView grvYCMVT;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeYC;
        private DevExpress.XtraGrid.Columns.GridColumn colYear;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colMonth;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplierCode;
        private DevExpress.XtraEditors.SimpleButton btnExeclGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colPriceGN;
        private DevExpress.XtraGrid.Columns.GridColumn colChenhLech;
        private DevExpress.XtraGrid.Columns.GridColumn colDeliveryTime;
        private DevExpress.XtraGrid.Columns.GridColumn colDeliveryTime1;
        private DevExpress.XtraGrid.Columns.GridColumn colCheck;
        private System.Windows.Forms.Button btnLoadPrice;
        private System.Windows.Forms.Button btnImportPrice;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectCode;
        private DevExpress.XtraGrid.Columns.GridColumn colModuleCode;
        private DevExpress.XtraGrid.Columns.GridColumn colProposalCode;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalBuy;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalChenhLech;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colHsCode;
        private DevExpress.XtraGrid.Columns.GridColumn colTax;
        private DevExpress.XtraGrid.Columns.GridColumn colTonKho;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colRequestCode;
        private DevExpress.XtraEditors.SimpleButton btnExportYCMVT;
        private DevExpress.XtraEditors.SimpleButton btnExportCK;
    }
}