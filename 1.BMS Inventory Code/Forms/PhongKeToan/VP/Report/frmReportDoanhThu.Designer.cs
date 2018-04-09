namespace BMS
{
    partial class frmReportDoanhThu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportDoanhThu));
            this.btnReloadData = new System.Windows.Forms.Button();
            this.colT5 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colT6 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colT7 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colT8 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colT9 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colT10 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colT11 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colT12 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.cboPhongBan = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.grvProject = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPhanXuongCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhanXuongName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.grvData = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colCode = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colT1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand13 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colT2 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colT3 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colT4 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand7 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand8 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand9 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand10 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand11 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand12 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand14 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colTotal = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colGroup = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.label20 = new System.Windows.Forms.Label();
            this.btnExecl = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cboPhongBan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReloadData
            // 
            this.btnReloadData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReloadData.Location = new System.Drawing.Point(627, 3);
            this.btnReloadData.Name = "btnReloadData";
            this.btnReloadData.Size = new System.Drawing.Size(91, 23);
            this.btnReloadData.TabIndex = 232;
            this.btnReloadData.Text = "Tải dữ liệu";
            this.btnReloadData.UseVisualStyleBackColor = true;
            this.btnReloadData.Click += new System.EventHandler(this.btnReloadData_Click);
            // 
            // colT5
            // 
            this.colT5.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colT5.AppearanceHeader.Options.UseFont = true;
            this.colT5.AppearanceHeader.Options.UseTextOptions = true;
            this.colT5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colT5.Caption = "T5";
            this.colT5.DisplayFormat.FormatString = "n0";
            this.colT5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colT5.FieldName = "T5";
            this.colT5.Name = "colT5";
            this.colT5.OptionsColumn.AllowEdit = false;
            this.colT5.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "T5", "{0:n0}")});
            this.colT5.Visible = true;
            this.colT5.Width = 90;
            // 
            // colT6
            // 
            this.colT6.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colT6.AppearanceHeader.Options.UseFont = true;
            this.colT6.AppearanceHeader.Options.UseTextOptions = true;
            this.colT6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colT6.Caption = "T6";
            this.colT6.DisplayFormat.FormatString = "n0";
            this.colT6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colT6.FieldName = "T6";
            this.colT6.Name = "colT6";
            this.colT6.OptionsColumn.AllowEdit = false;
            this.colT6.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "T6", "{0:n0}")});
            this.colT6.Visible = true;
            this.colT6.Width = 90;
            // 
            // colT7
            // 
            this.colT7.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colT7.AppearanceHeader.Options.UseFont = true;
            this.colT7.AppearanceHeader.Options.UseTextOptions = true;
            this.colT7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colT7.Caption = "T7";
            this.colT7.DisplayFormat.FormatString = "n0";
            this.colT7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colT7.FieldName = "T7";
            this.colT7.Name = "colT7";
            this.colT7.OptionsColumn.AllowEdit = false;
            this.colT7.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "T7", "{0:n0}")});
            this.colT7.Visible = true;
            this.colT7.Width = 90;
            // 
            // colT8
            // 
            this.colT8.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colT8.AppearanceHeader.Options.UseFont = true;
            this.colT8.AppearanceHeader.Options.UseTextOptions = true;
            this.colT8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colT8.Caption = "T8";
            this.colT8.DisplayFormat.FormatString = "n0";
            this.colT8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colT8.FieldName = "T8";
            this.colT8.Name = "colT8";
            this.colT8.OptionsColumn.AllowEdit = false;
            this.colT8.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "T8", "{0:n0}")});
            this.colT8.Visible = true;
            this.colT8.Width = 90;
            // 
            // colT9
            // 
            this.colT9.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colT9.AppearanceHeader.Options.UseFont = true;
            this.colT9.AppearanceHeader.Options.UseTextOptions = true;
            this.colT9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colT9.Caption = "T9";
            this.colT9.DisplayFormat.FormatString = "n0";
            this.colT9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colT9.FieldName = "T9";
            this.colT9.Name = "colT9";
            this.colT9.OptionsColumn.AllowEdit = false;
            this.colT9.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "T9", "{0:n0}")});
            this.colT9.Visible = true;
            this.colT9.Width = 90;
            // 
            // colT10
            // 
            this.colT10.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colT10.AppearanceHeader.Options.UseFont = true;
            this.colT10.AppearanceHeader.Options.UseTextOptions = true;
            this.colT10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colT10.Caption = "T10";
            this.colT10.DisplayFormat.FormatString = "n0";
            this.colT10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colT10.FieldName = "T10";
            this.colT10.Name = "colT10";
            this.colT10.OptionsColumn.AllowEdit = false;
            this.colT10.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "T10", "{0:n0}")});
            this.colT10.Visible = true;
            this.colT10.Width = 90;
            // 
            // colT11
            // 
            this.colT11.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colT11.AppearanceHeader.Options.UseFont = true;
            this.colT11.AppearanceHeader.Options.UseTextOptions = true;
            this.colT11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colT11.Caption = "T11";
            this.colT11.DisplayFormat.FormatString = "n0";
            this.colT11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colT11.FieldName = "T11";
            this.colT11.Name = "colT11";
            this.colT11.OptionsColumn.AllowEdit = false;
            this.colT11.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "T11", "{0:n0}")});
            this.colT11.Visible = true;
            this.colT11.Width = 90;
            // 
            // colT12
            // 
            this.colT12.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colT12.AppearanceHeader.Options.UseFont = true;
            this.colT12.AppearanceHeader.Options.UseTextOptions = true;
            this.colT12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colT12.Caption = "T12";
            this.colT12.DisplayFormat.FormatString = "n0";
            this.colT12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colT12.FieldName = "T12";
            this.colT12.Name = "colT12";
            this.colT12.OptionsColumn.AllowEdit = false;
            this.colT12.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "T12", "{0:n0}")});
            this.colT12.Visible = true;
            this.colT12.Width = 90;
            // 
            // cboPhongBan
            // 
            this.cboPhongBan.Location = new System.Drawing.Point(250, 6);
            this.cboPhongBan.Name = "cboPhongBan";
            this.cboPhongBan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPhongBan.Properties.NullText = "";
            this.cboPhongBan.Properties.View = this.grvProject;
            this.cboPhongBan.Size = new System.Drawing.Size(361, 20);
            this.cboPhongBan.TabIndex = 230;
            // 
            // grvProject
            // 
            this.grvProject.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPhanXuongCode,
            this.colPhanXuongName});
            this.grvProject.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvProject.Name = "grvProject";
            this.grvProject.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvProject.OptionsView.ShowGroupPanel = false;
            // 
            // colPhanXuongCode
            // 
            this.colPhanXuongCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colPhanXuongCode.AppearanceHeader.Options.UseFont = true;
            this.colPhanXuongCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colPhanXuongCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPhanXuongCode.Caption = "Mã";
            this.colPhanXuongCode.FieldName = "C_MA";
            this.colPhanXuongCode.Name = "colPhanXuongCode";
            this.colPhanXuongCode.OptionsColumn.AllowSize = false;
            this.colPhanXuongCode.Visible = true;
            this.colPhanXuongCode.VisibleIndex = 0;
            this.colPhanXuongCode.Width = 90;
            // 
            // colPhanXuongName
            // 
            this.colPhanXuongName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colPhanXuongName.AppearanceHeader.Options.UseFont = true;
            this.colPhanXuongName.AppearanceHeader.Options.UseTextOptions = true;
            this.colPhanXuongName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPhanXuongName.Caption = "Tên";
            this.colPhanXuongName.FieldName = "C_MOTA";
            this.colPhanXuongName.Name = "colPhanXuongName";
            this.colPhanXuongName.Visible = true;
            this.colPhanXuongName.VisibleIndex = 1;
            this.colPhanXuongName.Width = 294;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 228;
            this.label1.Text = "Năm";
            // 
            // cboYear
            // 
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(53, 5);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(121, 21);
            this.cboYear.TabIndex = 226;
            // 
            // grdData
            // 
            this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdData.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdData.Location = new System.Drawing.Point(3, 36);
            this.grdData.MainView = this.grvData;
            this.grdData.Name = "grdData";
            this.grdData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1});
            this.grdData.Size = new System.Drawing.Size(1471, 645);
            this.grdData.TabIndex = 231;
            this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvData});
            // 
            // grvData
            // 
            this.grvData.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvData.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grvData.Appearance.GroupPanel.Options.UseFont = true;
            this.grvData.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvData.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvData.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvData.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvData.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand2,
            this.gridBand13,
            this.gridBand3,
            this.gridBand4,
            this.gridBand5,
            this.gridBand6,
            this.gridBand7,
            this.gridBand8,
            this.gridBand9,
            this.gridBand10,
            this.gridBand11,
            this.gridBand12,
            this.gridBand14});
            this.grvData.ColumnPanelRowHeight = 40;
            this.grvData.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colID,
            this.colName,
            this.colCode,
            this.colT1,
            this.colT2,
            this.colT3,
            this.colT4,
            this.colT5,
            this.colT6,
            this.colT7,
            this.colT8,
            this.colT9,
            this.colT10,
            this.colT11,
            this.colT12,
            this.colTotal,
            this.colGroup});
            this.grvData.GridControl = this.grdData;
            this.grvData.GroupCount = 1;
            this.grvData.HorzScrollStep = 5;
            this.grvData.Name = "grvData";
            this.grvData.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvData.OptionsCustomization.AllowRowSizing = true;
            this.grvData.OptionsFind.ShowCloseButton = false;
            this.grvData.OptionsSelection.MultiSelect = true;
            this.grvData.OptionsView.ColumnAutoWidth = false;
            this.grvData.OptionsView.RowAutoHeight = true;
            this.grvData.OptionsView.ShowFooter = true;
            this.grvData.OptionsView.ShowGroupPanel = false;
            this.grvData.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colGroup, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCode, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvData_KeyDown);
            // 
            // gridBand1
            // 
            this.gridBand1.Columns.Add(this.colCode);
            this.gridBand1.Columns.Add(this.colName);
            this.gridBand1.Columns.Add(this.colID);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.Width = 371;
            // 
            // colCode
            // 
            this.colCode.AppearanceCell.Options.UseTextOptions = true;
            this.colCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCode.AppearanceHeader.Options.UseFont = true;
            this.colCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCode.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCode.Caption = "Mã CP";
            this.colCode.FieldName = "C_MA";
            this.colCode.Name = "colCode";
            this.colCode.OptionsColumn.AllowEdit = false;
            this.colCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colCode.Visible = true;
            this.colCode.Width = 95;
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
            this.colName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colName.Caption = "Tên CP";
            this.colName.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colName.FieldName = "C_MOTA";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.Visible = true;
            this.colName.Width = 276;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // colID
            // 
            this.colID.AppearanceCell.Options.UseTextOptions = true;
            this.colID.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colID.AppearanceHeader.Options.UseTextOptions = true;
            this.colID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colID.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colID.Caption = "ID";
            this.colID.FieldName = "PK_ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.AllowEdit = false;
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand2.AppearanceHeader.Options.UseFont = true;
            this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand2.Caption = "Tháng 1";
            this.gridBand2.Columns.Add(this.colT1);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.Width = 90;
            // 
            // colT1
            // 
            this.colT1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colT1.AppearanceHeader.Options.UseFont = true;
            this.colT1.AppearanceHeader.Options.UseTextOptions = true;
            this.colT1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colT1.Caption = "T1";
            this.colT1.DisplayFormat.FormatString = "n0";
            this.colT1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colT1.FieldName = "T1";
            this.colT1.Name = "colT1";
            this.colT1.OptionsColumn.AllowEdit = false;
            this.colT1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "T1", "{0:n0}")});
            this.colT1.Visible = true;
            this.colT1.Width = 90;
            // 
            // gridBand13
            // 
            this.gridBand13.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand13.AppearanceHeader.Options.UseFont = true;
            this.gridBand13.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand13.Caption = "Tháng 2";
            this.gridBand13.Columns.Add(this.colT2);
            this.gridBand13.Name = "gridBand13";
            this.gridBand13.Width = 90;
            // 
            // colT2
            // 
            this.colT2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colT2.AppearanceHeader.Options.UseFont = true;
            this.colT2.AppearanceHeader.Options.UseTextOptions = true;
            this.colT2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colT2.Caption = "T2";
            this.colT2.DisplayFormat.FormatString = "n0";
            this.colT2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colT2.FieldName = "T2";
            this.colT2.Name = "colT2";
            this.colT2.OptionsColumn.AllowEdit = false;
            this.colT2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "T2", "{0:n0}")});
            this.colT2.Visible = true;
            this.colT2.Width = 90;
            // 
            // gridBand3
            // 
            this.gridBand3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand3.AppearanceHeader.Options.UseFont = true;
            this.gridBand3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand3.Caption = "Tháng 3";
            this.gridBand3.Columns.Add(this.colT3);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.Width = 90;
            // 
            // colT3
            // 
            this.colT3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colT3.AppearanceHeader.Options.UseFont = true;
            this.colT3.AppearanceHeader.Options.UseTextOptions = true;
            this.colT3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colT3.Caption = "T3";
            this.colT3.DisplayFormat.FormatString = "n0";
            this.colT3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colT3.FieldName = "T3";
            this.colT3.Name = "colT3";
            this.colT3.OptionsColumn.AllowEdit = false;
            this.colT3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "T3", "{0:n0}")});
            this.colT3.Visible = true;
            this.colT3.Width = 90;
            // 
            // gridBand4
            // 
            this.gridBand4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand4.AppearanceHeader.Options.UseFont = true;
            this.gridBand4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand4.Caption = "Tháng 4";
            this.gridBand4.Columns.Add(this.colT4);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.Width = 90;
            // 
            // colT4
            // 
            this.colT4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colT4.AppearanceHeader.Options.UseFont = true;
            this.colT4.AppearanceHeader.Options.UseTextOptions = true;
            this.colT4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colT4.Caption = "T4";
            this.colT4.DisplayFormat.FormatString = "n0";
            this.colT4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colT4.FieldName = "T4";
            this.colT4.Name = "colT4";
            this.colT4.OptionsColumn.AllowEdit = false;
            this.colT4.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "T4", "{0:n0}")});
            this.colT4.Visible = true;
            this.colT4.Width = 90;
            // 
            // gridBand5
            // 
            this.gridBand5.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand5.AppearanceHeader.Options.UseFont = true;
            this.gridBand5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand5.Caption = "Tháng 5";
            this.gridBand5.Columns.Add(this.colT5);
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.Width = 90;
            // 
            // gridBand6
            // 
            this.gridBand6.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand6.AppearanceHeader.Options.UseFont = true;
            this.gridBand6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand6.Caption = "Tháng 6";
            this.gridBand6.Columns.Add(this.colT6);
            this.gridBand6.Name = "gridBand6";
            this.gridBand6.Width = 90;
            // 
            // gridBand7
            // 
            this.gridBand7.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand7.AppearanceHeader.Options.UseFont = true;
            this.gridBand7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand7.Caption = "Tháng 7";
            this.gridBand7.Columns.Add(this.colT7);
            this.gridBand7.Name = "gridBand7";
            this.gridBand7.Width = 90;
            // 
            // gridBand8
            // 
            this.gridBand8.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand8.AppearanceHeader.Options.UseFont = true;
            this.gridBand8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand8.Caption = "Tháng 8";
            this.gridBand8.Columns.Add(this.colT8);
            this.gridBand8.Name = "gridBand8";
            this.gridBand8.Width = 90;
            // 
            // gridBand9
            // 
            this.gridBand9.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand9.AppearanceHeader.Options.UseFont = true;
            this.gridBand9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand9.Caption = "Tháng 9";
            this.gridBand9.Columns.Add(this.colT9);
            this.gridBand9.Name = "gridBand9";
            this.gridBand9.Width = 90;
            // 
            // gridBand10
            // 
            this.gridBand10.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand10.AppearanceHeader.Options.UseFont = true;
            this.gridBand10.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand10.Caption = "Tháng 10";
            this.gridBand10.Columns.Add(this.colT10);
            this.gridBand10.Name = "gridBand10";
            this.gridBand10.Width = 90;
            // 
            // gridBand11
            // 
            this.gridBand11.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand11.AppearanceHeader.Options.UseFont = true;
            this.gridBand11.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand11.Caption = "Tháng 11";
            this.gridBand11.Columns.Add(this.colT11);
            this.gridBand11.Name = "gridBand11";
            this.gridBand11.Width = 90;
            // 
            // gridBand12
            // 
            this.gridBand12.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand12.AppearanceHeader.Options.UseFont = true;
            this.gridBand12.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand12.Caption = "Tháng 12";
            this.gridBand12.Columns.Add(this.colT12);
            this.gridBand12.Name = "gridBand12";
            this.gridBand12.Width = 90;
            // 
            // gridBand14
            // 
            this.gridBand14.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand14.AppearanceHeader.Options.UseFont = true;
            this.gridBand14.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand14.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand14.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridBand14.Caption = "Tổng";
            this.gridBand14.Columns.Add(this.colTotal);
            this.gridBand14.Name = "gridBand14";
            this.gridBand14.Width = 110;
            // 
            // colTotal
            // 
            this.colTotal.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTotal.AppearanceHeader.Options.UseFont = true;
            this.colTotal.DisplayFormat.FormatString = "n0";
            this.colTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotal.FieldName = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.OptionsColumn.AllowEdit = false;
            this.colTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total", "{0:n0}")});
            this.colTotal.Visible = true;
            this.colTotal.Width = 110;
            // 
            // colGroup
            // 
            this.colGroup.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colGroup.AppearanceCell.Options.UseFont = true;
            this.colGroup.Caption = "Nhóm";
            this.colGroup.FieldName = "GroupCode";
            this.colGroup.Name = "colGroup";
            this.colGroup.OptionsColumn.AllowEdit = false;
            this.colGroup.Visible = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(188, 9);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(59, 13);
            this.label20.TabIndex = 229;
            this.label20.Text = "Phòng ban";
            // 
            // btnExecl
            // 
            this.btnExecl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecl.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnExecl.Appearance.Options.UseFont = true;
            this.btnExecl.Image = ((System.Drawing.Image)(resources.GetObject("btnExecl.Image")));
            this.btnExecl.Location = new System.Drawing.Point(1369, 2);
            this.btnExecl.Name = "btnExecl";
            this.btnExecl.Size = new System.Drawing.Size(104, 30);
            this.btnExecl.TabIndex = 233;
            this.btnExecl.Text = "Xuất excel";
            this.btnExecl.Click += new System.EventHandler(this.btnExecl_Click);
            // 
            // frmReportDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1476, 685);
            this.Controls.Add(this.btnExecl);
            this.Controls.Add(this.btnReloadData);
            this.Controls.Add(this.cboPhongBan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboYear);
            this.Controls.Add(this.grdData);
            this.Controls.Add(this.label20);
            this.Name = "frmReportDoanhThu";
            this.Text = "BÁO CÁO DOANH THU";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReportDoanhThu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboPhongBan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReloadData;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colT5;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colT6;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colT7;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colT8;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colT9;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colT10;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colT11;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colT12;
        private DevExpress.XtraEditors.SearchLookUpEdit cboPhongBan;
        private DevExpress.XtraGrid.Views.Grid.GridView grvProject;
        private DevExpress.XtraGrid.Columns.GridColumn colPhanXuongCode;
        private DevExpress.XtraGrid.Columns.GridColumn colPhanXuongName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboYear;
        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView grvData;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCode;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colName;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colID;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colT1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colT2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colT3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colT4;
        private System.Windows.Forms.Label label20;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand13;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand6;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand7;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand8;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand9;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand10;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand11;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand12;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand14;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTotal;
        private DevExpress.XtraEditors.SimpleButton btnExecl;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colGroup;
    }
}