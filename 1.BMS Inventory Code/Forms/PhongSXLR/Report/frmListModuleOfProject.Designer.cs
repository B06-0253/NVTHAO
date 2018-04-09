namespace BMS
{
    partial class frmListModuleOfProject
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
            DevExpress.XtraTreeList.FilterCondition filterCondition1 = new DevExpress.XtraTreeList.FilterCondition();
            DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListModuleOfProject));
            this.colNameHD = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colCodeHD = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.btnReloadData = new System.Windows.Forms.Button();
            this.cboProject = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.grvProject = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProjectID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProjectCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAssemblyDeadline = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.treeData = new DevExpress.XtraTreeList.TreeList();
            this.colPProductId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colCodeTK = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colNameTK = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colPercentVT = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colStatus = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colPercentExport = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colProjectModuleId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colQty = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDateAboutE = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTotalDateAboutENull = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colCNC = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colIN = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colGCAL = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colPCB = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colLR = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn6 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colIsTHTK = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colIsYCVT = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xemChiTiếtVậtTưToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đãYCVTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chưaYCVTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dtpSXLRDeadline = new DevExpress.XtraEditors.DateEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnExecl = new DevExpress.XtraEditors.SimpleButton();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTienDo = new DevExpress.XtraEditors.TextEdit();
            this.btnDeadlineSXLR = new System.Windows.Forms.Button();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colIsProjectProblem = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.xemVấnĐềDựÁnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpSXLRDeadline.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpSXLRDeadline.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTienDo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // colNameHD
            // 
            this.colNameHD.AppearanceCell.Options.UseTextOptions = true;
            this.colNameHD.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNameHD.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colNameHD.AppearanceHeader.Options.UseFont = true;
            this.colNameHD.AppearanceHeader.Options.UseTextOptions = true;
            this.colNameHD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNameHD.Caption = "Tên HD";
            this.colNameHD.ColumnEdit = this.repositoryItemMemoEdit2;
            this.colNameHD.FieldName = "PPName";
            this.colNameHD.Name = "colNameHD";
            this.colNameHD.OptionsColumn.AllowEdit = false;
            this.colNameHD.OptionsColumn.AllowSort = false;
            this.colNameHD.Visible = true;
            this.colNameHD.VisibleIndex = 1;
            this.colNameHD.Width = 191;
            // 
            // repositoryItemMemoEdit2
            // 
            this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
            // 
            // colCodeHD
            // 
            this.colCodeHD.AppearanceCell.Options.UseTextOptions = true;
            this.colCodeHD.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCodeHD.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCodeHD.AppearanceHeader.Options.UseFont = true;
            this.colCodeHD.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodeHD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodeHD.Caption = "Mã HD";
            this.colCodeHD.ColumnEdit = this.repositoryItemMemoEdit2;
            this.colCodeHD.FieldName = "PPCode";
            this.colCodeHD.Name = "colCodeHD";
            this.colCodeHD.OptionsColumn.AllowEdit = false;
            this.colCodeHD.OptionsColumn.AllowSort = false;
            this.colCodeHD.Visible = true;
            this.colCodeHD.VisibleIndex = 0;
            this.colCodeHD.Width = 176;
            // 
            // btnReloadData
            // 
            this.btnReloadData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReloadData.Location = new System.Drawing.Point(199, 10);
            this.btnReloadData.Name = "btnReloadData";
            this.btnReloadData.Size = new System.Drawing.Size(91, 23);
            this.btnReloadData.TabIndex = 25;
            this.btnReloadData.Text = "Tải dữ liệu";
            this.btnReloadData.UseVisualStyleBackColor = true;
            this.btnReloadData.Click += new System.EventHandler(this.btnReloadData_Click);
            // 
            // cboProject
            // 
            this.cboProject.Location = new System.Drawing.Point(53, 12);
            this.cboProject.Name = "cboProject";
            this.cboProject.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProject.Properties.NullText = "";
            this.cboProject.Properties.View = this.grvProject;
            this.cboProject.Size = new System.Drawing.Size(138, 20);
            this.cboProject.TabIndex = 24;
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
            this.colAssemblyDeadline});
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Dự án";
            // 
            // treeData
            // 
            this.treeData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeData.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.treeData.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.treeData.Appearance.FocusedRow.Options.UseBackColor = true;
            this.treeData.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.treeData.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.treeData.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.treeData.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.treeData.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.treeData.Appearance.SelectedRow.Options.UseBackColor = true;
            this.treeData.ColumnPanelRowHeight = 40;
            this.treeData.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colPProductId,
            this.colNameHD,
            this.colCodeHD,
            this.colCodeTK,
            this.colNameTK,
            this.colPercentVT,
            this.colStatus,
            this.colPercentExport,
            this.colProjectModuleId,
            this.colQty,
            this.colDateAboutE,
            this.colTotalDateAboutENull,
            this.colCNC,
            this.colIN,
            this.colGCAL,
            this.colPCB,
            this.colLR,
            this.treeListColumn6,
            this.colIsTHTK,
            this.colIsYCVT,
            this.treeListColumn1,
            this.treeListColumn2,
            this.treeListColumn3,
            this.colIsProjectProblem});
            this.treeData.ContextMenuStrip = this.contextMenuStrip1;
            this.treeData.CustomizationFormBounds = new System.Drawing.Rectangle(1080, 179, 216, 323);
            filterCondition1.Column = this.colNameHD;
            filterCondition1.Condition = DevExpress.XtraTreeList.FilterConditionEnum.Contains;
            filterCondition1.Value1 = "<Null>";
            filterCondition1.Value2 = "<Null>";
            filterCondition1.Visible = true;
            this.treeData.FilterConditions.AddRange(new DevExpress.XtraTreeList.FilterCondition[] {
            filterCondition1});
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.colCodeHD;
            this.treeData.FormatConditions.AddRange(new DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition[] {
            styleFormatCondition1});
            this.treeData.Location = new System.Drawing.Point(3, 48);
            this.treeData.Name = "treeData";
            this.treeData.OptionsBehavior.AllowExpandOnDblClick = false;
            this.treeData.OptionsBehavior.AllowIncrementalSearch = true;
            this.treeData.OptionsBehavior.EnableFiltering = true;
            this.treeData.OptionsBehavior.ExpandNodesOnIncrementalSearch = true;
            this.treeData.OptionsSelection.MultiSelect = true;
            this.treeData.OptionsView.AutoWidth = false;
            this.treeData.OptionsView.ShowButtons = false;
            this.treeData.ParentFieldName = "ManageId";
            this.treeData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit2,
            this.repositoryItemCheckEdit1});
            this.treeData.Size = new System.Drawing.Size(1350, 624);
            this.treeData.TabIndex = 26;
            this.treeData.NodeCellStyle += new DevExpress.XtraTreeList.GetCustomNodeCellStyleEventHandler(this.treeData_NodeCellStyle);
            this.treeData.DoubleClick += new System.EventHandler(this.treeData_DoubleClick);
            this.treeData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeData_KeyDown);
            // 
            // colPProductId
            // 
            this.colPProductId.Caption = "Mã";
            this.colPProductId.FieldName = "PProductId";
            this.colPProductId.Name = "colPProductId";
            this.colPProductId.OptionsColumn.AllowEdit = false;
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
            this.colCodeTK.FieldName = "ProjectModuleCode";
            this.colCodeTK.Name = "colCodeTK";
            this.colCodeTK.OptionsColumn.AllowEdit = false;
            this.colCodeTK.OptionsColumn.AllowSort = false;
            this.colCodeTK.Visible = true;
            this.colCodeTK.VisibleIndex = 2;
            this.colCodeTK.Width = 92;
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
            this.colNameTK.ColumnEdit = this.repositoryItemMemoEdit2;
            this.colNameTK.FieldName = "ProjectModuleName";
            this.colNameTK.Name = "colNameTK";
            this.colNameTK.OptionsColumn.AllowEdit = false;
            this.colNameTK.OptionsColumn.AllowSort = false;
            this.colNameTK.Visible = true;
            this.colNameTK.VisibleIndex = 3;
            this.colNameTK.Width = 202;
            // 
            // colPercentVT
            // 
            this.colPercentVT.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colPercentVT.AppearanceCell.Options.UseFont = true;
            this.colPercentVT.AppearanceCell.Options.UseTextOptions = true;
            this.colPercentVT.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPercentVT.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPercentVT.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colPercentVT.AppearanceHeader.Options.UseFont = true;
            this.colPercentVT.AppearanceHeader.Options.UseTextOptions = true;
            this.colPercentVT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPercentVT.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPercentVT.Caption = "% vật tư về";
            this.colPercentVT.FieldName = "PercentVT";
            this.colPercentVT.Format.FormatString = "n0";
            this.colPercentVT.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPercentVT.Name = "colPercentVT";
            this.colPercentVT.OptionsColumn.AllowEdit = false;
            this.colPercentVT.OptionsColumn.AllowSort = false;
            this.colPercentVT.Visible = true;
            this.colPercentVT.VisibleIndex = 5;
            this.colPercentVT.Width = 51;
            // 
            // colStatus
            // 
            this.colStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colStatus.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colStatus.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colStatus.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colStatus.AppearanceHeader.Options.UseFont = true;
            this.colStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.colStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStatus.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colStatus.Caption = "Trạng thái";
            this.colStatus.FieldName = "StatusText";
            this.colStatus.Name = "colStatus";
            this.colStatus.OptionsColumn.AllowEdit = false;
            this.colStatus.OptionsColumn.AllowSort = false;
            this.colStatus.Width = 119;
            // 
            // colPercentExport
            // 
            this.colPercentExport.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colPercentExport.AppearanceCell.Options.UseFont = true;
            this.colPercentExport.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colPercentExport.AppearanceHeader.Options.UseFont = true;
            this.colPercentExport.AppearanceHeader.Options.UseTextOptions = true;
            this.colPercentExport.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPercentExport.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPercentExport.Caption = "% đã xuất";
            this.colPercentExport.FieldName = "PercentExport";
            this.colPercentExport.Format.FormatString = "n0";
            this.colPercentExport.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPercentExport.Name = "colPercentExport";
            this.colPercentExport.OptionsColumn.AllowEdit = false;
            this.colPercentExport.OptionsColumn.AllowSort = false;
            this.colPercentExport.Visible = true;
            this.colPercentExport.VisibleIndex = 6;
            this.colPercentExport.Width = 58;
            // 
            // colProjectModuleId
            // 
            this.colProjectModuleId.Caption = "ProjectModuleId";
            this.colProjectModuleId.FieldName = "ProjectModuleId";
            this.colProjectModuleId.Name = "colProjectModuleId";
            this.colProjectModuleId.OptionsColumn.AllowEdit = false;
            // 
            // colQty
            // 
            this.colQty.AppearanceCell.Options.UseTextOptions = true;
            this.colQty.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colQty.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colQty.AppearanceHeader.Options.UseFont = true;
            this.colQty.AppearanceHeader.Options.UseTextOptions = true;
            this.colQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colQty.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colQty.Caption = "Số lượng";
            this.colQty.FieldName = "TotalReal";
            this.colQty.Name = "colQty";
            this.colQty.OptionsColumn.AllowEdit = false;
            this.colQty.Visible = true;
            this.colQty.VisibleIndex = 4;
            this.colQty.Width = 56;
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
            this.colDateAboutE.Caption = "Ngày về DK";
            this.colDateAboutE.FieldName = "DateAboutE";
            this.colDateAboutE.Format.FormatString = "dd/MM/yyyy";
            this.colDateAboutE.Format.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDateAboutE.Name = "colDateAboutE";
            this.colDateAboutE.OptionsColumn.AllowEdit = false;
            this.colDateAboutE.Visible = true;
            this.colDateAboutE.VisibleIndex = 16;
            this.colDateAboutE.Width = 91;
            // 
            // colTotalDateAboutENull
            // 
            this.colTotalDateAboutENull.Caption = "TotalDateAboutENull";
            this.colTotalDateAboutENull.FieldName = "TotalDateAboutENull";
            this.colTotalDateAboutENull.Format.FormatString = "n0";
            this.colTotalDateAboutENull.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalDateAboutENull.Name = "colTotalDateAboutENull";
            this.colTotalDateAboutENull.OptionsColumn.AllowEdit = false;
            // 
            // colCNC
            // 
            this.colCNC.AppearanceCell.Options.UseTextOptions = true;
            this.colCNC.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCNC.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCNC.AppearanceHeader.Options.UseFont = true;
            this.colCNC.AppearanceHeader.Options.UseTextOptions = true;
            this.colCNC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCNC.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCNC.Caption = "CNC";
            this.colCNC.FieldName = "PercentCNC";
            this.colCNC.Name = "colCNC";
            this.colCNC.OptionsColumn.AllowEdit = false;
            this.colCNC.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Average;
            this.colCNC.SummaryFooterStrFormat = "{0:n2}";
            this.colCNC.Visible = true;
            this.colCNC.VisibleIndex = 7;
            // 
            // colIN
            // 
            this.colIN.AppearanceCell.Options.UseTextOptions = true;
            this.colIN.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIN.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colIN.AppearanceHeader.Options.UseFont = true;
            this.colIN.AppearanceHeader.Options.UseTextOptions = true;
            this.colIN.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIN.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colIN.Caption = "IN";
            this.colIN.FieldName = "PercentIN";
            this.colIN.Name = "colIN";
            this.colIN.OptionsColumn.AllowEdit = false;
            this.colIN.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Average;
            this.colIN.SummaryFooterStrFormat = "{0:n2}";
            this.colIN.Visible = true;
            this.colIN.VisibleIndex = 8;
            // 
            // colGCAL
            // 
            this.colGCAL.AppearanceCell.Options.UseTextOptions = true;
            this.colGCAL.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGCAL.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colGCAL.AppearanceHeader.Options.UseFont = true;
            this.colGCAL.AppearanceHeader.Options.UseTextOptions = true;
            this.colGCAL.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGCAL.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colGCAL.Caption = "Gia công";
            this.colGCAL.FieldName = "PerrcentGCAL";
            this.colGCAL.Name = "colGCAL";
            this.colGCAL.OptionsColumn.AllowEdit = false;
            this.colGCAL.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Average;
            this.colGCAL.SummaryFooterStrFormat = "{0:n2}";
            this.colGCAL.Visible = true;
            this.colGCAL.VisibleIndex = 9;
            // 
            // colPCB
            // 
            this.colPCB.AppearanceCell.Options.UseTextOptions = true;
            this.colPCB.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPCB.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colPCB.AppearanceHeader.Options.UseFont = true;
            this.colPCB.AppearanceHeader.Options.UseTextOptions = true;
            this.colPCB.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPCB.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPCB.Caption = "Mạch điện tử";
            this.colPCB.FieldName = "PercentPCB";
            this.colPCB.Name = "colPCB";
            this.colPCB.OptionsColumn.AllowEdit = false;
            this.colPCB.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Average;
            this.colPCB.SummaryFooterStrFormat = "{0:n2}";
            this.colPCB.Visible = true;
            this.colPCB.VisibleIndex = 10;
            // 
            // colLR
            // 
            this.colLR.AppearanceCell.Options.UseTextOptions = true;
            this.colLR.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLR.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colLR.AppearanceHeader.Options.UseFont = true;
            this.colLR.AppearanceHeader.Options.UseTextOptions = true;
            this.colLR.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLR.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colLR.Caption = "Lắp ráp";
            this.colLR.FieldName = "PercentLR";
            this.colLR.Name = "colLR";
            this.colLR.OptionsColumn.AllowEdit = false;
            this.colLR.RowFooterSummary = DevExpress.XtraTreeList.SummaryItemType.Average;
            this.colLR.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Average;
            this.colLR.SummaryFooterStrFormat = "{0:n2}";
            this.colLR.Visible = true;
            this.colLR.VisibleIndex = 11;
            // 
            // treeListColumn6
            // 
            this.treeListColumn6.AppearanceCell.Options.UseTextOptions = true;
            this.treeListColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn6.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.treeListColumn6.AppearanceHeader.Options.UseFont = true;
            this.treeListColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn6.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.treeListColumn6.Caption = "ĐNNK";
            this.treeListColumn6.FieldName = "ImportCode";
            this.treeListColumn6.Name = "treeListColumn6";
            this.treeListColumn6.OptionsColumn.AllowEdit = false;
            this.treeListColumn6.Visible = true;
            this.treeListColumn6.VisibleIndex = 12;
            this.treeListColumn6.Width = 132;
            // 
            // colIsTHTK
            // 
            this.colIsTHTK.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colIsTHTK.AppearanceHeader.Options.UseFont = true;
            this.colIsTHTK.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsTHTK.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsTHTK.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colIsTHTK.Caption = "Tổng hợp thiết kế";
            this.colIsTHTK.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colIsTHTK.FieldName = "IsTHTK";
            this.colIsTHTK.Name = "colIsTHTK";
            this.colIsTHTK.OptionsColumn.AllowEdit = false;
            this.colIsTHTK.Visible = true;
            this.colIsTHTK.VisibleIndex = 14;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // colIsYCVT
            // 
            this.colIsYCVT.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colIsYCVT.AppearanceHeader.Options.UseFont = true;
            this.colIsYCVT.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsYCVT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsYCVT.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colIsYCVT.Caption = "Đã YCVT";
            this.colIsYCVT.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colIsYCVT.FieldName = "IsYCVT";
            this.colIsYCVT.Name = "colIsYCVT";
            this.colIsYCVT.OptionsColumn.AllowEdit = false;
            this.colIsYCVT.Visible = true;
            this.colIsYCVT.VisibleIndex = 15;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.treeListColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn1.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.treeListColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.treeListColumn1.AppearanceHeader.Options.UseFont = true;
            this.treeListColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn1.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.treeListColumn1.Caption = "Số chỉ thị";
            this.treeListColumn1.FieldName = "ProjectDirectionID";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.AllowEdit = false;
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 17;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.treeListColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn2.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.treeListColumn2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.treeListColumn2.AppearanceHeader.Options.UseFont = true;
            this.treeListColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn2.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.treeListColumn2.Caption = "KCS";
            this.treeListColumn2.ColumnEdit = this.repositoryItemCheckEdit1;
            this.treeListColumn2.FieldName = "IsKCS";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.OptionsColumn.AllowEdit = false;
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 18;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xemChiTiếtVậtTưToolStripMenuItem,
            this.đãYCVTToolStripMenuItem,
            this.chưaYCVTToolStripMenuItem,
            this.xemVấnĐềDựÁnToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(171, 92);
            // 
            // xemChiTiếtVậtTưToolStripMenuItem
            // 
            this.xemChiTiếtVậtTưToolStripMenuItem.Name = "xemChiTiếtVậtTưToolStripMenuItem";
            this.xemChiTiếtVậtTưToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.xemChiTiếtVậtTưToolStripMenuItem.Text = "Xem chi tiết vật tư";
            this.xemChiTiếtVậtTưToolStripMenuItem.Click += new System.EventHandler(this.xemChiTiếtVậtTưToolStripMenuItem_Click);
            // 
            // đãYCVTToolStripMenuItem
            // 
            this.đãYCVTToolStripMenuItem.Name = "đãYCVTToolStripMenuItem";
            this.đãYCVTToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.đãYCVTToolStripMenuItem.Text = "Đã YCVT";
            this.đãYCVTToolStripMenuItem.Click += new System.EventHandler(this.đãYCVTToolStripMenuItem_Click);
            // 
            // chưaYCVTToolStripMenuItem
            // 
            this.chưaYCVTToolStripMenuItem.Name = "chưaYCVTToolStripMenuItem";
            this.chưaYCVTToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.chưaYCVTToolStripMenuItem.Text = "Chưa YCVT";
            this.chưaYCVTToolStripMenuItem.Click += new System.EventHandler(this.chưaYCVTToolStripMenuItem_Click);
            // 
            // dtpSXLRDeadline
            // 
            this.dtpSXLRDeadline.EditValue = null;
            this.dtpSXLRDeadline.Location = new System.Drawing.Point(390, 12);
            this.dtpSXLRDeadline.Name = "dtpSXLRDeadline";
            this.dtpSXLRDeadline.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtpSXLRDeadline.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpSXLRDeadline.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtpSXLRDeadline.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpSXLRDeadline.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtpSXLRDeadline.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtpSXLRDeadline.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtpSXLRDeadline.Size = new System.Drawing.Size(102, 20);
            this.dtpSXLRDeadline.TabIndex = 216;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(878, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 225;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.Lime;
            this.label3.Location = new System.Drawing.Point(878, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 226;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(1129, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 227;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(1129, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 228;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1170, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(173, 13);
            this.label8.TabIndex = 221;
            this.label8.Text = "Vât tư về 100%. vật tư xuất < 100%";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(919, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(196, 13);
            this.label7.TabIndex = 222;
            this.label7.Text = "Vât tư đã về 100%. vật tư đã xuất 100%";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(919, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(191, 13);
            this.label9.TabIndex = 223;
            this.label9.Text = "Tồn tại vật tư chưa có ngày về dự kiến";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(1170, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(170, 13);
            this.label10.TabIndex = 224;
            this.label10.Text = "Ngày về dự kiến > Deadline SXLR";
            // 
            // btnExecl
            // 
            this.btnExecl.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnExecl.Appearance.Options.UseFont = true;
            this.btnExecl.Image = ((System.Drawing.Image)(resources.GetObject("btnExecl.Image")));
            this.btnExecl.Location = new System.Drawing.Point(649, 7);
            this.btnExecl.Name = "btnExecl";
            this.btnExecl.Size = new System.Drawing.Size(104, 25);
            this.btnExecl.TabIndex = 252;
            this.btnExecl.Text = "Xuất excel";
            this.btnExecl.Click += new System.EventHandler(this.btnExecl_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(498, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 253;
            this.label11.Text = "%Tiến độ";
            // 
            // txtTienDo
            // 
            this.txtTienDo.Location = new System.Drawing.Point(553, 11);
            this.txtTienDo.Name = "txtTienDo";
            this.txtTienDo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtTienDo.Properties.Appearance.Options.UseFont = true;
            this.txtTienDo.Properties.DisplayFormat.FormatString = "n2";
            this.txtTienDo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTienDo.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTienDo.Properties.ReadOnly = true;
            this.txtTienDo.Size = new System.Drawing.Size(87, 20);
            this.txtTienDo.TabIndex = 254;
            // 
            // btnDeadlineSXLR
            // 
            this.btnDeadlineSXLR.Location = new System.Drawing.Point(296, 10);
            this.btnDeadlineSXLR.Name = "btnDeadlineSXLR";
            this.btnDeadlineSXLR.Size = new System.Drawing.Size(93, 23);
            this.btnDeadlineSXLR.TabIndex = 255;
            this.btnDeadlineSXLR.Tag = "frmListModuleOfProjectTPAD_SaveDeadlineSXLR";
            this.btnDeadlineSXLR.Text = "Deadline SXLR";
            this.btnDeadlineSXLR.UseVisualStyleBackColor = true;
            this.btnDeadlineSXLR.Click += new System.EventHandler(this.btnDeadlineSXLR_Click);
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.treeListColumn3.AppearanceHeader.Options.UseFont = true;
            this.treeListColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn3.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.treeListColumn3.Caption = "Số ĐNNK";
            this.treeListColumn3.FieldName = "ImportCodeFact";
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 13;
            // 
            // colIsProjectProblem
            // 
            this.colIsProjectProblem.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colIsProjectProblem.AppearanceHeader.Options.UseFont = true;
            this.colIsProjectProblem.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsProjectProblem.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsProjectProblem.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colIsProjectProblem.Caption = "Có vấn đề";
            this.colIsProjectProblem.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colIsProjectProblem.FieldName = "IsProjectProblem";
            this.colIsProjectProblem.Name = "colIsProjectProblem";
            this.colIsProjectProblem.OptionsColumn.AllowEdit = false;
            this.colIsProjectProblem.Visible = true;
            this.colIsProjectProblem.VisibleIndex = 19;
            // 
            // xemVấnĐềDựÁnToolStripMenuItem
            // 
            this.xemVấnĐềDựÁnToolStripMenuItem.Name = "xemVấnĐềDựÁnToolStripMenuItem";
            this.xemVấnĐềDựÁnToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.xemVấnĐềDựÁnToolStripMenuItem.Text = "Xem vấn đề dự án";
            this.xemVấnĐềDựÁnToolStripMenuItem.Click += new System.EventHandler(this.xemVấnĐềDựÁnToolStripMenuItem_Click);
            // 
            // frmListModuleOfProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 673);
            this.Controls.Add(this.btnDeadlineSXLR);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnExecl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtpSXLRDeadline);
            this.Controls.Add(this.treeData);
            this.Controls.Add(this.btnReloadData);
            this.Controls.Add(this.cboProject);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTienDo);
            this.Name = "frmListModuleOfProject";
            this.Text = "Danh sách thiết bị trong dự án";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmListModuleOfProject_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpSXLRDeadline.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpSXLRDeadline.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTienDo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReloadData;
        private DevExpress.XtraEditors.SearchLookUpEdit cboProject;
        private DevExpress.XtraGrid.Views.Grid.GridView grvProject;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectID;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectCode;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectName;
        private DevExpress.XtraGrid.Columns.GridColumn colYear;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraTreeList.TreeList treeData;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colPProductId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colNameHD;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCodeHD;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCodeTK;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colNameTK;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colPercentVT;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colStatus;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colPercentExport;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xemChiTiếtVậtTưToolStripMenuItem;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colProjectModuleId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colQty;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDateAboutE;
        private DevExpress.XtraGrid.Columns.GridColumn colAssemblyDeadline;
        private DevExpress.XtraEditors.DateEdit dtpSXLRDeadline;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTotalDateAboutENull;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCNC;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIN;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colGCAL;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colPCB;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colLR;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn6;
        private DevExpress.XtraEditors.SimpleButton btnExecl;
        private System.Windows.Forms.Label label11;
        private DevExpress.XtraEditors.TextEdit txtTienDo;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIsTHTK;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIsYCVT;
        private System.Windows.Forms.ToolStripMenuItem đãYCVTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chưaYCVTToolStripMenuItem;
        private System.Windows.Forms.Button btnDeadlineSXLR;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIsProjectProblem;
        private System.Windows.Forms.ToolStripMenuItem xemVấnĐềDựÁnToolStripMenuItem;
    }
}