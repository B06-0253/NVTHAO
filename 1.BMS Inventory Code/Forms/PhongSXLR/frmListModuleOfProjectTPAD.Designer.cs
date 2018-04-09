namespace BMS
{
    partial class frmListModuleOfProjectTPAD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListModuleOfProjectTPAD));
            this.btnReloadData = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnShowDMVT = new System.Windows.Forms.ToolStripMenuItem();
            this.xemDanhSáchCácCụmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPercentVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colPercentExport = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodeHD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodeTK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNameTK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNameHD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPProductId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProjectModuleId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateAboutE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalDateAboutENull = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCheck = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colProjectDirectionID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.dtpSXLRDeadline = new DevExpress.XtraEditors.DateEdit();
            this.cboProject = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.grvProject = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProjectID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProjectCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAssemblyDeadline = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateFinishE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnCreateDirection = new System.Windows.Forms.Button();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.btnCreateChiThiCN = new System.Windows.Forms.Button();
            this.btnExecl = new DevExpress.XtraEditors.SimpleButton();
            this.btnDeadlineSXLR = new System.Windows.Forms.Button();
            this.btnCancelChiThi = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpSXLRDeadline.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpSXLRDeadline.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProject)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReloadData
            // 
            this.btnReloadData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReloadData.Location = new System.Drawing.Point(312, 12);
            this.btnReloadData.Name = "btnReloadData";
            this.btnReloadData.Size = new System.Drawing.Size(91, 23);
            this.btnReloadData.TabIndex = 28;
            this.btnReloadData.Text = "Tải dữ liệu";
            this.btnReloadData.UseVisualStyleBackColor = true;
            this.btnReloadData.Click += new System.EventHandler(this.btnReloadData_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Dự án";
            // 
            // grdData
            // 
            this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdData.ContextMenuStrip = this.contextMenuStrip1;
            this.grdData.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdData.Location = new System.Drawing.Point(2, 49);
            this.grdData.MainView = this.grvData;
            this.grdData.Name = "grdData";
            this.grdData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemMemoEdit1,
            this.repositoryItemLookUpEdit1});
            this.grdData.Size = new System.Drawing.Size(1090, 538);
            this.grdData.TabIndex = 183;
            this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvData});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnShowDMVT,
            this.xemDanhSáchCácCụmToolStripMenuItem,
            this.btnCancelChiThi});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(204, 92);
            // 
            // btnShowDMVT
            // 
            this.btnShowDMVT.Name = "btnShowDMVT";
            this.btnShowDMVT.Size = new System.Drawing.Size(203, 22);
            this.btnShowDMVT.Text = "Danh mục vật tư";
            this.btnShowDMVT.Click += new System.EventHandler(this.btnShowDMVT_Click);
            // 
            // xemDanhSáchCácCụmToolStripMenuItem
            // 
            this.xemDanhSáchCácCụmToolStripMenuItem.Name = "xemDanhSáchCácCụmToolStripMenuItem";
            this.xemDanhSáchCácCụmToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.xemDanhSáchCácCụmToolStripMenuItem.Text = "Xem danh sách các cụm";
            this.xemDanhSáchCácCụmToolStripMenuItem.Click += new System.EventHandler(this.xemDanhSáchCácCụmToolStripMenuItem_Click);
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
            this.grvData.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvData.ColumnPanelRowHeight = 40;
            this.grvData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPercentVT,
            this.colStatus,
            this.colPercentExport,
            this.colCodeHD,
            this.colCodeTK,
            this.colNameTK,
            this.colNameHD,
            this.colPProductId,
            this.colProjectModuleId,
            this.colQty,
            this.colDateAboutE,
            this.colTotalDateAboutENull,
            this.colCheck,
            this.colProjectDirectionID,
            this.colNote});
            this.grvData.CustomizationFormBounds = new System.Drawing.Rectangle(60, 130, 216, 323);
            this.grvData.GridControl = this.grdData;
            this.grvData.HorzScrollStep = 5;
            this.grvData.Name = "grvData";
            this.grvData.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvData.OptionsCustomization.AllowRowSizing = true;
            this.grvData.OptionsFind.AlwaysVisible = true;
            this.grvData.OptionsFind.ShowCloseButton = false;
            this.grvData.OptionsSelection.MultiSelect = true;
            this.grvData.OptionsView.ColumnAutoWidth = false;
            this.grvData.OptionsView.RowAutoHeight = true;
            this.grvData.OptionsView.ShowFooter = true;
            this.grvData.OptionsView.ShowGroupPanel = false;
            this.grvData.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCodeTK, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvData.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grvData_RowCellStyle);
            this.grvData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvData_KeyDown);
            this.grvData.DoubleClick += new System.EventHandler(this.grvData_DoubleClick);
            // 
            // colPercentVT
            // 
            this.colPercentVT.AppearanceCell.Options.UseTextOptions = true;
            this.colPercentVT.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPercentVT.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPercentVT.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colPercentVT.AppearanceHeader.Options.UseFont = true;
            this.colPercentVT.AppearanceHeader.Options.UseTextOptions = true;
            this.colPercentVT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPercentVT.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPercentVT.Caption = "% vật tư về";
            this.colPercentVT.DisplayFormat.FormatString = "n0";
            this.colPercentVT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPercentVT.FieldName = "PercentVT";
            this.colPercentVT.Name = "colPercentVT";
            this.colPercentVT.OptionsColumn.AllowEdit = false;
            this.colPercentVT.Visible = true;
            this.colPercentVT.VisibleIndex = 4;
            this.colPercentVT.Width = 82;
            // 
            // colStatus
            // 
            this.colStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStatus.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colStatus.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colStatus.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colStatus.AppearanceHeader.Options.UseFont = true;
            this.colStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.colStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStatus.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colStatus.Caption = "Trạng thái";
            this.colStatus.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colStatus.FieldName = "StatusText";
            this.colStatus.Name = "colStatus";
            this.colStatus.OptionsColumn.AllowEdit = false;
            this.colStatus.Width = 155;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Appearance.Options.UseTextOptions = true;
            this.repositoryItemMemoEdit1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // colPercentExport
            // 
            this.colPercentExport.AppearanceCell.Options.UseTextOptions = true;
            this.colPercentExport.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPercentExport.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPercentExport.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colPercentExport.AppearanceHeader.Options.UseFont = true;
            this.colPercentExport.AppearanceHeader.Options.UseTextOptions = true;
            this.colPercentExport.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPercentExport.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPercentExport.Caption = "% đã xuất";
            this.colPercentExport.DisplayFormat.FormatString = "n0";
            this.colPercentExport.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPercentExport.FieldName = "PercentExport";
            this.colPercentExport.Name = "colPercentExport";
            this.colPercentExport.OptionsColumn.AllowEdit = false;
            this.colPercentExport.Visible = true;
            this.colPercentExport.VisibleIndex = 5;
            this.colPercentExport.Width = 94;
            // 
            // colCodeHD
            // 
            this.colCodeHD.AppearanceCell.Options.UseTextOptions = true;
            this.colCodeHD.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCodeHD.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCodeHD.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCodeHD.AppearanceHeader.Options.UseFont = true;
            this.colCodeHD.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodeHD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodeHD.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCodeHD.Caption = "Mã HD";
            this.colCodeHD.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colCodeHD.FieldName = "PPCode";
            this.colCodeHD.Name = "colCodeHD";
            this.colCodeHD.OptionsColumn.AllowEdit = false;
            this.colCodeHD.Width = 196;
            // 
            // colCodeTK
            // 
            this.colCodeTK.AppearanceCell.Options.UseTextOptions = true;
            this.colCodeTK.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCodeTK.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCodeTK.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCodeTK.AppearanceHeader.Options.UseFont = true;
            this.colCodeTK.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodeTK.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodeTK.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCodeTK.Caption = "Mã TK";
            this.colCodeTK.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colCodeTK.FieldName = "ProjectModuleCode";
            this.colCodeTK.Name = "colCodeTK";
            this.colCodeTK.OptionsColumn.AllowEdit = false;
            this.colCodeTK.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colCodeTK.Visible = true;
            this.colCodeTK.VisibleIndex = 1;
            this.colCodeTK.Width = 143;
            // 
            // colNameTK
            // 
            this.colNameTK.AppearanceCell.Options.UseTextOptions = true;
            this.colNameTK.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colNameTK.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNameTK.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colNameTK.AppearanceHeader.Options.UseFont = true;
            this.colNameTK.AppearanceHeader.Options.UseTextOptions = true;
            this.colNameTK.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNameTK.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNameTK.Caption = "Tên TK";
            this.colNameTK.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colNameTK.FieldName = "ProjectModuleName";
            this.colNameTK.Name = "colNameTK";
            this.colNameTK.OptionsColumn.AllowEdit = false;
            this.colNameTK.Visible = true;
            this.colNameTK.VisibleIndex = 2;
            this.colNameTK.Width = 311;
            // 
            // colNameHD
            // 
            this.colNameHD.AppearanceCell.Options.UseTextOptions = true;
            this.colNameHD.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colNameHD.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNameHD.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colNameHD.AppearanceHeader.Options.UseFont = true;
            this.colNameHD.AppearanceHeader.Options.UseTextOptions = true;
            this.colNameHD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNameHD.Caption = "Tên HD";
            this.colNameHD.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colNameHD.FieldName = "PPName";
            this.colNameHD.Name = "colNameHD";
            this.colNameHD.OptionsColumn.AllowEdit = false;
            this.colNameHD.Width = 218;
            // 
            // colPProductId
            // 
            this.colPProductId.Caption = "PProductId";
            this.colPProductId.FieldName = "PProductId";
            this.colPProductId.Name = "colPProductId";
            // 
            // colProjectModuleId
            // 
            this.colProjectModuleId.Caption = "ProjectModuleId";
            this.colProjectModuleId.FieldName = "ProjectModuleId";
            this.colProjectModuleId.Name = "colProjectModuleId";
            // 
            // colQty
            // 
            this.colQty.AppearanceCell.Options.UseTextOptions = true;
            this.colQty.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colQty.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colQty.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colQty.AppearanceHeader.Options.UseFont = true;
            this.colQty.AppearanceHeader.Options.UseTextOptions = true;
            this.colQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colQty.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colQty.Caption = "Số lượng";
            this.colQty.DisplayFormat.FormatString = "n0";
            this.colQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQty.FieldName = "TotalReal";
            this.colQty.Name = "colQty";
            this.colQty.OptionsColumn.AllowEdit = false;
            this.colQty.Visible = true;
            this.colQty.VisibleIndex = 3;
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
            this.colDateAboutE.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colDateAboutE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDateAboutE.FieldName = "DateAboutE";
            this.colDateAboutE.Name = "colDateAboutE";
            this.colDateAboutE.OptionsColumn.AllowEdit = false;
            this.colDateAboutE.Visible = true;
            this.colDateAboutE.VisibleIndex = 6;
            // 
            // colTotalDateAboutENull
            // 
            this.colTotalDateAboutENull.Caption = "TotalDateAboutENull";
            this.colTotalDateAboutENull.FieldName = "TotalDateAboutENull";
            this.colTotalDateAboutENull.Name = "colTotalDateAboutENull";
            // 
            // colCheck
            // 
            this.colCheck.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCheck.AppearanceHeader.Options.UseFont = true;
            this.colCheck.AppearanceHeader.Options.UseTextOptions = true;
            this.colCheck.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCheck.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCheck.Caption = "Check";
            this.colCheck.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colCheck.FieldName = "Check";
            this.colCheck.Name = "colCheck";
            this.colCheck.Visible = true;
            this.colCheck.VisibleIndex = 0;
            this.colCheck.Width = 52;
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
            // colProjectDirectionID
            // 
            this.colProjectDirectionID.AppearanceCell.Options.UseTextOptions = true;
            this.colProjectDirectionID.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colProjectDirectionID.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colProjectDirectionID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colProjectDirectionID.AppearanceHeader.Options.UseFont = true;
            this.colProjectDirectionID.AppearanceHeader.Options.UseTextOptions = true;
            this.colProjectDirectionID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProjectDirectionID.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colProjectDirectionID.Caption = "Chỉ thị";
            this.colProjectDirectionID.FieldName = "ProjectDirectionID";
            this.colProjectDirectionID.Name = "colProjectDirectionID";
            this.colProjectDirectionID.OptionsColumn.AllowEdit = false;
            this.colProjectDirectionID.Visible = true;
            this.colProjectDirectionID.VisibleIndex = 7;
            // 
            // colNote
            // 
            this.colNote.AppearanceCell.Options.UseTextOptions = true;
            this.colNote.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colNote.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNote.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colNote.AppearanceHeader.Options.UseFont = true;
            this.colNote.AppearanceHeader.Options.UseTextOptions = true;
            this.colNote.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNote.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNote.Caption = "Ghi chú";
            this.colNote.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colNote.FieldName = "Note";
            this.colNote.Name = "colNote";
            this.colNote.OptionsColumn.AllowEdit = false;
            this.colNote.Visible = true;
            this.colNote.VisibleIndex = 8;
            this.colNote.Width = 214;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.NullText = "";
            // 
            // dtpSXLRDeadline
            // 
            this.dtpSXLRDeadline.EditValue = null;
            this.dtpSXLRDeadline.Location = new System.Drawing.Point(509, 13);
            this.dtpSXLRDeadline.Name = "dtpSXLRDeadline";
            this.dtpSXLRDeadline.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtpSXLRDeadline.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpSXLRDeadline.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtpSXLRDeadline.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpSXLRDeadline.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtpSXLRDeadline.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtpSXLRDeadline.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtpSXLRDeadline.Size = new System.Drawing.Size(142, 20);
            this.dtpSXLRDeadline.TabIndex = 218;
            // 
            // cboProject
            // 
            this.cboProject.Location = new System.Drawing.Point(61, 13);
            this.cboProject.Name = "cboProject";
            this.cboProject.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProject.Properties.NullText = "";
            this.cboProject.Properties.View = this.grvProject;
            this.cboProject.Size = new System.Drawing.Size(247, 20);
            this.cboProject.TabIndex = 219;
            this.cboProject.EditValueChanged += new System.EventHandler(this.cboProject_EditValueChanged);
            // 
            // grvProject
            // 
            this.grvProject.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProjectID,
            this.colProjectCode,
            this.colProjectName,
            this.colYear,
            this.colCustomerName,
            this.colUserName,
            this.colAssemblyDeadline,
            this.colDateFinishE});
            this.grvProject.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvProject.Name = "grvProject";
            this.grvProject.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvProject.OptionsView.ShowGroupPanel = false;
            // 
            // colProjectID
            // 
            this.colProjectID.Caption = "ID";
            this.colProjectID.FieldName = "ProjectId";
            this.colProjectID.Name = "colProjectID";
            // 
            // colProjectCode
            // 
            this.colProjectCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colProjectCode.AppearanceHeader.Options.UseFont = true;
            this.colProjectCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colProjectCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProjectCode.Caption = "Mã";
            this.colProjectCode.FieldName = "ProjectCode";
            this.colProjectCode.Name = "colProjectCode";
            this.colProjectCode.OptionsColumn.AllowSize = false;
            this.colProjectCode.Visible = true;
            this.colProjectCode.VisibleIndex = 0;
            this.colProjectCode.Width = 90;
            // 
            // colProjectName
            // 
            this.colProjectName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colProjectName.AppearanceHeader.Options.UseFont = true;
            this.colProjectName.AppearanceHeader.Options.UseTextOptions = true;
            this.colProjectName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProjectName.Caption = "Tên";
            this.colProjectName.FieldName = "ProjectName";
            this.colProjectName.Name = "colProjectName";
            this.colProjectName.Visible = true;
            this.colProjectName.VisibleIndex = 1;
            this.colProjectName.Width = 294;
            // 
            // colYear
            // 
            this.colYear.Caption = "Năm";
            this.colYear.FieldName = "Year";
            this.colYear.Name = "colYear";
            // 
            // colCustomerName
            // 
            this.colCustomerName.Caption = "CustomerName";
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.Name = "colCustomerName";
            // 
            // colUserName
            // 
            this.colUserName.Caption = "UserName";
            this.colUserName.FieldName = "UserName";
            this.colUserName.Name = "colUserName";
            // 
            // colAssemblyDeadline
            // 
            this.colAssemblyDeadline.Caption = "Deadline SXLR";
            this.colAssemblyDeadline.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colAssemblyDeadline.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAssemblyDeadline.FieldName = "AssemblyDeadline";
            this.colAssemblyDeadline.Name = "colAssemblyDeadline";
            this.colAssemblyDeadline.Visible = true;
            this.colAssemblyDeadline.VisibleIndex = 2;
            // 
            // colDateFinishE
            // 
            this.colDateFinishE.Caption = "Ngày kết thúc DK";
            this.colDateFinishE.FieldName = "DateFinishE";
            this.colDateFinishE.Name = "colDateFinishE";
            this.colDateFinishE.Visible = true;
            this.colDateFinishE.VisibleIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(852, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 220;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(852, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 220;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.Lime;
            this.label3.Location = new System.Drawing.Point(601, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 220;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(601, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 220;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(642, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(196, 13);
            this.label7.TabIndex = 217;
            this.label7.Text = "Vât tư đã về 100%. vật tư đã xuất 100%";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(893, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(173, 13);
            this.label8.TabIndex = 217;
            this.label8.Text = "Vât tư về 100%. vật tư xuất < 100%";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(642, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(191, 13);
            this.label9.TabIndex = 217;
            this.label9.Text = "Tồn tại vật tư chưa có ngày về dự kiến";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(893, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(170, 13);
            this.label10.TabIndex = 217;
            this.label10.Text = "Ngày về dự kiến > Deadline SXLR";
            // 
            // btnCreateDirection
            // 
            this.btnCreateDirection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateDirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateDirection.Location = new System.Drawing.Point(955, 8);
            this.btnCreateDirection.Name = "btnCreateDirection";
            this.btnCreateDirection.Size = new System.Drawing.Size(126, 32);
            this.btnCreateDirection.TabIndex = 28;
            this.btnCreateDirection.Tag = "frmListModuleOfProjectTPAD_TaoChiThiCN";
            this.btnCreateDirection.Text = "Tạo chỉ thị GD";
            this.btnCreateDirection.UseVisualStyleBackColor = true;
            this.btnCreateDirection.Click += new System.EventHandler(this.btnCreateDirection_Click);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(496, 64);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(81, 17);
            this.chkAll.TabIndex = 221;
            this.chkAll.Text = "Chọn tất cả";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // btnCreateChiThiCN
            // 
            this.btnCreateChiThiCN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateChiThiCN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateChiThiCN.Location = new System.Drawing.Point(811, 8);
            this.btnCreateChiThiCN.Name = "btnCreateChiThiCN";
            this.btnCreateChiThiCN.Size = new System.Drawing.Size(138, 32);
            this.btnCreateChiThiCN.TabIndex = 28;
            this.btnCreateChiThiCN.Tag = "frmListModuleOfProjectTPAD_TaoChiThiCN";
            this.btnCreateChiThiCN.Text = "Tạo chỉ thị CN";
            this.btnCreateChiThiCN.UseVisualStyleBackColor = true;
            this.btnCreateChiThiCN.Click += new System.EventHandler(this.btnCreateChiThiCN_Click);
            // 
            // btnExecl
            // 
            this.btnExecl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecl.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnExecl.Appearance.Options.UseFont = true;
            this.btnExecl.Image = ((System.Drawing.Image)(resources.GetObject("btnExecl.Image")));
            this.btnExecl.Location = new System.Drawing.Point(701, 9);
            this.btnExecl.Name = "btnExecl";
            this.btnExecl.Size = new System.Drawing.Size(104, 30);
            this.btnExecl.TabIndex = 251;
            this.btnExecl.Text = "Xuất excel";
            this.btnExecl.Click += new System.EventHandler(this.btnExecl_Click);
            // 
            // btnDeadlineSXLR
            // 
            this.btnDeadlineSXLR.Location = new System.Drawing.Point(413, 12);
            this.btnDeadlineSXLR.Name = "btnDeadlineSXLR";
            this.btnDeadlineSXLR.Size = new System.Drawing.Size(93, 23);
            this.btnDeadlineSXLR.TabIndex = 252;
            this.btnDeadlineSXLR.Tag = "frmListModuleOfProjectTPAD_SaveDeadlineSXLR";
            this.btnDeadlineSXLR.Text = "Deadline SXLR";
            this.btnDeadlineSXLR.UseVisualStyleBackColor = true;
            this.btnDeadlineSXLR.Click += new System.EventHandler(this.btnDeadlineSXLR_Click);
            // 
            // btnCancelChiThi
            // 
            this.btnCancelChiThi.Name = "btnCancelChiThi";
            this.btnCancelChiThi.Size = new System.Drawing.Size(203, 22);
            this.btnCancelChiThi.Text = "Hủy chỉ thị của module";
            this.btnCancelChiThi.Click += new System.EventHandler(this.btnCancelChiThi_Click);
            // 
            // frmListModuleOfProjectTPAD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 590);
            this.Controls.Add(this.btnDeadlineSXLR);
            this.Controls.Add(this.btnExecl);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboProject);
            this.Controls.Add(this.dtpSXLRDeadline);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.grdData);
            this.Controls.Add(this.btnCreateChiThiCN);
            this.Controls.Add(this.btnCreateDirection);
            this.Controls.Add(this.btnReloadData);
            this.Controls.Add(this.label6);
            this.Name = "frmListModuleOfProjectTPAD";
            this.Text = "Danh sách module của dự án";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmListPartOfModule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpSXLRDeadline.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpSXLRDeadline.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProject)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReloadData;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.Grid.GridView grvData;
        private DevExpress.XtraGrid.Columns.GridColumn colPercentVT;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colPercentExport;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeHD;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeTK;
        private DevExpress.XtraGrid.Columns.GridColumn colNameTK;
        private DevExpress.XtraGrid.Columns.GridColumn colNameHD;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colPProductId;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectModuleId;
        private DevExpress.XtraGrid.Columns.GridColumn colQty;
        private DevExpress.XtraGrid.Columns.GridColumn colDateAboutE;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalDateAboutENull;
        private DevExpress.XtraEditors.DateEdit dtpSXLRDeadline;
        private DevExpress.XtraEditors.SearchLookUpEdit cboProject;
        private DevExpress.XtraGrid.Views.Grid.GridView grvProject;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectID;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectCode;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectName;
        private DevExpress.XtraGrid.Columns.GridColumn colYear;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colAssemblyDeadline;
        private DevExpress.XtraGrid.Columns.GridColumn colCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraGrid.Columns.GridColumn colDateFinishE;
        private System.Windows.Forms.Button btnCreateDirection;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectDirectionID;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnShowDMVT;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Button btnCreateChiThiCN;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
        private System.Windows.Forms.ToolStripMenuItem xemDanhSáchCácCụmToolStripMenuItem;
        private DevExpress.XtraEditors.SimpleButton btnExecl;
        private System.Windows.Forms.Button btnDeadlineSXLR;
        private System.Windows.Forms.ToolStripMenuItem btnCancelChiThi;
    }
}