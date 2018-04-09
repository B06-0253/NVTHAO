namespace BMS
{
    partial class frmReportMaterial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportMaterial));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.grdYC = new DevExpress.XtraGrid.GridControl();
            this.grvYC = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsSend = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCheck = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.grdYCDetail = new DevExpress.XtraGrid.GridControl();
            this.grvYCDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPartsName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colPartsCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalBuy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModuleCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateAboutE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateAboutF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPeriod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnExeclGroup = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdYC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvYC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdYCDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvYCDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(5, 6);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.grdYC);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.grdYCDetail);
            this.splitContainer1.Size = new System.Drawing.Size(1123, 547);
            this.splitContainer1.SplitterDistance = 560;
            this.splitContainer1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Yêu cầu mua vật tư";
            // 
            // grdYC
            // 
            this.grdYC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdYC.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdYC.Location = new System.Drawing.Point(6, 24);
            this.grdYC.MainView = this.grvYC;
            this.grdYC.Name = "grdYC";
            this.grdYC.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1,
            this.repositoryItemCheckEdit1});
            this.grdYC.Size = new System.Drawing.Size(551, 514);
            this.grdYC.TabIndex = 22;
            this.grdYC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvYC});
            // 
            // grvYC
            // 
            this.grvYC.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvYC.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvYC.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvYC.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvYC.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvYC.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grvYC.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvYC.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvYC.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvYC.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvYC.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvYC.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvYC.ColumnPanelRowHeight = 40;
            this.grvYC.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode,
            this.colYear,
            this.colMonth,
            this.colIsSend,
            this.colUserName,
            this.colCheck,
            this.colOrderCode});
            this.grvYC.GridControl = this.grdYC;
            this.grvYC.GroupCount = 2;
            this.grvYC.Name = "grvYC";
            this.grvYC.OptionsCustomization.AllowRowSizing = true;
            this.grvYC.OptionsFind.AlwaysVisible = true;
            this.grvYC.OptionsSelection.MultiSelect = true;
            this.grvYC.OptionsView.ColumnAutoWidth = false;
            this.grvYC.OptionsView.RowAutoHeight = true;
            this.grvYC.OptionsView.ShowFooter = true;
            this.grvYC.OptionsView.ShowGroupedColumns = true;
            this.grvYC.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colYear, DevExpress.Data.ColumnSortOrder.Descending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colMonth, DevExpress.Data.ColumnSortOrder.Descending)});
            this.grvYC.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvYC_FocusedRowChanged);
            // 
            // colCode
            // 
            this.colCode.AppearanceCell.Options.UseTextOptions = true;
            this.colCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCode.AppearanceHeader.Options.UseFont = true;
            this.colCode.Caption = "Yêu cầu mua";
            this.colCode.FieldName = "ProposalCode";
            this.colCode.Name = "colCode";
            this.colCode.OptionsColumn.AllowEdit = false;
            this.colCode.OptionsColumn.AllowFocus = false;
            this.colCode.OptionsColumn.AllowSize = false;
            this.colCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            this.colCode.Width = 266;
            // 
            // colYear
            // 
            this.colYear.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colYear.AppearanceHeader.Options.UseFont = true;
            this.colYear.AppearanceHeader.Options.UseTextOptions = true;
            this.colYear.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colYear.Caption = "Năm";
            this.colYear.FieldName = "Year";
            this.colYear.Name = "colYear";
            // 
            // colMonth
            // 
            this.colMonth.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMonth.AppearanceHeader.Options.UseFont = true;
            this.colMonth.AppearanceHeader.Options.UseTextOptions = true;
            this.colMonth.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMonth.Caption = "Tháng";
            this.colMonth.FieldName = "Month";
            this.colMonth.Name = "colMonth";
            this.colMonth.OptionsColumn.AllowEdit = false;
            this.colMonth.Width = 81;
            // 
            // colIsSend
            // 
            this.colIsSend.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colIsSend.AppearanceHeader.Options.UseFont = true;
            this.colIsSend.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsSend.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsSend.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colIsSend.Caption = "Đã gửi mail";
            this.colIsSend.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colIsSend.FieldName = "IsSendMail";
            this.colIsSend.Name = "colIsSend";
            this.colIsSend.OptionsColumn.AllowEdit = false;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // colUserName
            // 
            this.colUserName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colUserName.AppearanceHeader.Options.UseFont = true;
            this.colUserName.AppearanceHeader.Options.UseTextOptions = true;
            this.colUserName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUserName.Caption = "Người phụ trách";
            this.colUserName.FieldName = "UserName";
            this.colUserName.Name = "colUserName";
            this.colUserName.OptionsColumn.AllowEdit = false;
            this.colUserName.Visible = true;
            this.colUserName.VisibleIndex = 1;
            this.colUserName.Width = 136;
            // 
            // colCheck
            // 
            this.colCheck.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCheck.AppearanceHeader.Options.UseFont = true;
            this.colCheck.AppearanceHeader.Options.UseTextOptions = true;
            this.colCheck.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCheck.Caption = "Chọn";
            this.colCheck.FieldName = "check";
            this.colCheck.Name = "colCheck";
            // 
            // colOrderCode
            // 
            this.colOrderCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colOrderCode.AppearanceHeader.Options.UseFont = true;
            this.colOrderCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colOrderCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colOrderCode.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colOrderCode.Caption = "PO";
            this.colOrderCode.FieldName = "OrderCode";
            this.colOrderCode.Name = "colOrderCode";
            this.colOrderCode.OptionsColumn.AllowEdit = false;
            this.colOrderCode.Visible = true;
            this.colOrderCode.VisibleIndex = 2;
            this.colOrderCode.Width = 127;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Danh sách vật tư";
            // 
            // grdYCDetail
            // 
            this.grdYCDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdYCDetail.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdYCDetail.Location = new System.Drawing.Point(3, 24);
            this.grdYCDetail.MainView = this.grvYCDetail;
            this.grdYCDetail.Name = "grdYCDetail";
            this.grdYCDetail.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit2});
            this.grdYCDetail.Size = new System.Drawing.Size(553, 514);
            this.grdYCDetail.TabIndex = 22;
            this.grdYCDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvYCDetail});
            // 
            // grvYCDetail
            // 
            this.grvYCDetail.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvYCDetail.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvYCDetail.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvYCDetail.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvYCDetail.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvYCDetail.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grvYCDetail.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvYCDetail.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvYCDetail.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvYCDetail.ColumnPanelRowHeight = 40;
            this.grvYCDetail.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPartsName,
            this.colPartsCode,
            this.colTotalBuy,
            this.colModuleCode,
            this.colDateAboutE,
            this.colDateAboutF,
            this.colPeriod});
            this.grvYCDetail.GridControl = this.grdYCDetail;
            this.grvYCDetail.Name = "grvYCDetail";
            this.grvYCDetail.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvYCDetail.OptionsCustomization.AllowRowSizing = true;
            this.grvYCDetail.OptionsView.AllowHtmlDrawHeaders = true;
            this.grvYCDetail.OptionsView.ColumnAutoWidth = false;
            this.grvYCDetail.OptionsView.RowAutoHeight = true;
            this.grvYCDetail.OptionsView.ShowAutoFilterRow = true;
            this.grvYCDetail.OptionsView.ShowFooter = true;
            this.grvYCDetail.OptionsView.ShowGroupPanel = false;
            this.grvYCDetail.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colPeriod, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // colPartsName
            // 
            this.colPartsName.AppearanceCell.Options.UseTextOptions = true;
            this.colPartsName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPartsName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colPartsName.AppearanceHeader.Options.UseFont = true;
            this.colPartsName.Caption = "Tên vật tư";
            this.colPartsName.ColumnEdit = this.repositoryItemMemoEdit2;
            this.colPartsName.FieldName = "PartsName";
            this.colPartsName.Name = "colPartsName";
            this.colPartsName.OptionsColumn.AllowEdit = false;
            this.colPartsName.Visible = true;
            this.colPartsName.VisibleIndex = 1;
            this.colPartsName.Width = 188;
            // 
            // repositoryItemMemoEdit2
            // 
            this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
            // 
            // colPartsCode
            // 
            this.colPartsCode.AppearanceCell.Options.UseTextOptions = true;
            this.colPartsCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPartsCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colPartsCode.AppearanceHeader.Options.UseFont = true;
            this.colPartsCode.Caption = "Mã vật tư";
            this.colPartsCode.ColumnEdit = this.repositoryItemMemoEdit2;
            this.colPartsCode.FieldName = "PartsCode";
            this.colPartsCode.Name = "colPartsCode";
            this.colPartsCode.OptionsColumn.AllowEdit = false;
            this.colPartsCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colPartsCode.Visible = true;
            this.colPartsCode.VisibleIndex = 0;
            this.colPartsCode.Width = 136;
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
            this.colTotalBuy.OptionsColumn.AllowEdit = false;
            this.colTotalBuy.Visible = true;
            this.colTotalBuy.VisibleIndex = 2;
            this.colTotalBuy.Width = 47;
            // 
            // colModuleCode
            // 
            this.colModuleCode.AppearanceCell.Options.UseTextOptions = true;
            this.colModuleCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colModuleCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colModuleCode.AppearanceHeader.Options.UseFont = true;
            this.colModuleCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colModuleCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colModuleCode.Caption = "Mã module";
            this.colModuleCode.FieldName = "ProjectModuleCode";
            this.colModuleCode.Name = "colModuleCode";
            this.colModuleCode.OptionsColumn.AllowEdit = false;
            this.colModuleCode.Visible = true;
            this.colModuleCode.VisibleIndex = 3;
            // 
            // colDateAboutE
            // 
            this.colDateAboutE.AppearanceCell.Options.UseTextOptions = true;
            this.colDateAboutE.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDateAboutE.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colDateAboutE.AppearanceHeader.Options.UseFont = true;
            this.colDateAboutE.AppearanceHeader.Options.UseTextOptions = true;
            this.colDateAboutE.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDateAboutE.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDateAboutE.Caption = "Ngày về dự kiến";
            this.colDateAboutE.FieldName = "DateAboutE";
            this.colDateAboutE.Name = "colDateAboutE";
            this.colDateAboutE.OptionsColumn.AllowEdit = false;
            this.colDateAboutE.Visible = true;
            this.colDateAboutE.VisibleIndex = 4;
            // 
            // colDateAboutF
            // 
            this.colDateAboutF.AppearanceCell.Options.UseTextOptions = true;
            this.colDateAboutF.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDateAboutF.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colDateAboutF.AppearanceHeader.Options.UseFont = true;
            this.colDateAboutF.AppearanceHeader.Options.UseTextOptions = true;
            this.colDateAboutF.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDateAboutF.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDateAboutF.Caption = "Ngày về thực tế";
            this.colDateAboutF.FieldName = "DateAboutF";
            this.colDateAboutF.Name = "colDateAboutF";
            this.colDateAboutF.OptionsColumn.AllowEdit = false;
            this.colDateAboutF.Visible = true;
            this.colDateAboutF.VisibleIndex = 5;
            // 
            // colPeriod
            // 
            this.colPeriod.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.colPeriod.AppearanceCell.Options.UseFont = true;
            this.colPeriod.AppearanceCell.Options.UseTextOptions = true;
            this.colPeriod.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPeriod.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colPeriod.AppearanceHeader.Options.UseFont = true;
            this.colPeriod.AppearanceHeader.Options.UseTextOptions = true;
            this.colPeriod.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPeriod.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPeriod.Caption = "Chênh lệch (ngày)";
            this.colPeriod.FieldName = "Period";
            this.colPeriod.Name = "colPeriod";
            this.colPeriod.OptionsColumn.AllowEdit = false;
            this.colPeriod.Visible = true;
            this.colPeriod.VisibleIndex = 6;
            this.colPeriod.Width = 96;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(3, 37);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1142, 585);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1134, 559);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "YCMVT chậm tiến độ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnExeclGroup
            // 
            this.btnExeclGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExeclGroup.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnExeclGroup.Appearance.Options.UseFont = true;
            this.btnExeclGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnExeclGroup.Image")));
            this.btnExeclGroup.Location = new System.Drawing.Point(1037, 12);
            this.btnExeclGroup.Name = "btnExeclGroup";
            this.btnExeclGroup.Size = new System.Drawing.Size(104, 32);
            this.btnExeclGroup.TabIndex = 27;
            this.btnExeclGroup.Text = "Xuất excel";
            this.btnExeclGroup.Click += new System.EventHandler(this.btnExeclGroup_Click);
            // 
            // frmReportMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 624);
            this.Controls.Add(this.btnExeclGroup);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmReportMaterial";
            this.Text = "BÁO CÁO";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReportMaterial_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdYC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvYC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdYCDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvYCDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl grdYC;
        private DevExpress.XtraGrid.Views.Grid.GridView grvYC;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colYear;
        private DevExpress.XtraGrid.Columns.GridColumn colMonth;
        private DevExpress.XtraGrid.Columns.GridColumn colIsSend;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colCheck;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.GridControl grdYCDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView grvYCDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colPartsName;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colPartsCode;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalBuy;
        private DevExpress.XtraGrid.Columns.GridColumn colModuleCode;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private DevExpress.XtraGrid.Columns.GridColumn colDateAboutE;
        private DevExpress.XtraGrid.Columns.GridColumn colDateAboutF;
        private DevExpress.XtraGrid.Columns.GridColumn colPeriod;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderCode;
        private DevExpress.XtraEditors.SimpleButton btnExeclGroup;


    }
}