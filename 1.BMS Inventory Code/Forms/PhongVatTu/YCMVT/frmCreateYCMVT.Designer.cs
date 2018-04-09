namespace BMS
{
    partial class frmCreateYCMVT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreateYCMVT));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.grdProject = new DevExpress.XtraGrid.GridControl();
            this.grvProject = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colPYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPCheck = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboProductType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkRAll = new System.Windows.Forms.CheckBox();
            this.grdYCVT = new DevExpress.XtraGrid.GridControl();
            this.grvYCVT = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colRcheck = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colRProjectCode = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.mnuMenu = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnConfig = new System.Windows.Forms.ToolStripButton();
            this.cboUser = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.grvCboUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAccount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label11 = new System.Windows.Forms.Label();
            this.btnSet = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdYCVT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvYCVT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdParts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvParts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).BeginInit();
            this.mnuMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCboUser)).BeginInit();
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
            this.splitContainer1.SplitterDistance = 367;
            this.splitContainer1.TabIndex = 0;
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
            this.splitContainer2.Panel1.Controls.Add(this.grdProject);
            this.splitContainer2.Panel1.Controls.Add(this.cboDepartment);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.cboProductType);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.chkRAll);
            this.splitContainer2.Panel2.Controls.Add(this.grdYCVT);
            this.splitContainer2.Size = new System.Drawing.Size(367, 446);
            this.splitContainer2.SplitterDistance = 204;
            this.splitContainer2.TabIndex = 0;
            // 
            // grdProject
            // 
            this.grdProject.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdProject.Location = new System.Drawing.Point(7, 64);
            this.grdProject.MainView = this.grvProject;
            this.grdProject.Name = "grdProject";
            this.grdProject.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1,
            this.repositoryItemCheckEdit1});
            this.grdProject.Size = new System.Drawing.Size(354, 137);
            this.grdProject.TabIndex = 17;
            this.grdProject.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvProject});
            // 
            // grvProject
            // 
            this.grvProject.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvProject.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvProject.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvProject.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvProject.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvProject.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvProject.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colPCode,
            this.colPName,
            this.colPYear,
            this.colPCheck});
            this.grvProject.GridControl = this.grdProject;
            this.grvProject.GroupCount = 1;
            this.grvProject.Name = "grvProject";
            this.grvProject.OptionsFind.AlwaysVisible = true;
            this.grvProject.OptionsSelection.MultiSelect = true;
            this.grvProject.OptionsView.RowAutoHeight = true;
            this.grvProject.OptionsView.ShowFooter = true;
            this.grvProject.OptionsView.ShowGroupPanel = false;
            this.grvProject.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colPYear, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvProject.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvProject_CellValueChanged);
            // 
            // colID
            // 
            this.colID.AppearanceHeader.Options.UseTextOptions = true;
            this.colID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colID.Caption = "ID";
            this.colID.FieldName = "ProjectId";
            this.colID.Name = "colID";
            // 
            // colPCode
            // 
            this.colPCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colPCode.AppearanceHeader.Options.UseFont = true;
            this.colPCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colPCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPCode.Caption = "Mã dự án";
            this.colPCode.FieldName = "ProjectCode";
            this.colPCode.Name = "colPCode";
            this.colPCode.OptionsColumn.AllowEdit = false;
            this.colPCode.OptionsColumn.AllowFocus = false;
            this.colPCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colPCode.Visible = true;
            this.colPCode.VisibleIndex = 1;
            this.colPCode.Width = 111;
            // 
            // colPName
            // 
            this.colPName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colPName.AppearanceHeader.Options.UseFont = true;
            this.colPName.AppearanceHeader.Options.UseTextOptions = true;
            this.colPName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPName.Caption = "Tên dự án";
            this.colPName.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colPName.FieldName = "ProjectName";
            this.colPName.Name = "colPName";
            this.colPName.OptionsColumn.AllowEdit = false;
            this.colPName.OptionsColumn.AllowFocus = false;
            this.colPName.Visible = true;
            this.colPName.VisibleIndex = 2;
            this.colPName.Width = 185;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // colPYear
            // 
            this.colPYear.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colPYear.AppearanceHeader.Options.UseFont = true;
            this.colPYear.AppearanceHeader.Options.UseTextOptions = true;
            this.colPYear.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPYear.Caption = "Năm";
            this.colPYear.FieldName = "Year";
            this.colPYear.Name = "colPYear";
            // 
            // colPCheck
            // 
            this.colPCheck.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colPCheck.AppearanceHeader.Options.UseFont = true;
            this.colPCheck.AppearanceHeader.Options.UseTextOptions = true;
            this.colPCheck.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPCheck.Caption = "Chọn";
            this.colPCheck.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colPCheck.FieldName = "check";
            this.colPCheck.Name = "colPCheck";
            this.colPCheck.Visible = true;
            this.colPCheck.VisibleIndex = 0;
            this.colPCheck.Width = 41;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // cboDepartment
            // 
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(100, 37);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(185, 21);
            this.cboDepartment.TabIndex = 1;
            this.cboDepartment.SelectionChangeCommitted += new System.EventHandler(this.cboDepartment_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Phòng ban";
            // 
            // cboProductType
            // 
            this.cboProductType.FormattingEnabled = true;
            this.cboProductType.Items.AddRange(new object[] {
            "Thiêt bị mua ngoài",
            "Vật tư",
            "Vật tư tự do"});
            this.cboProductType.Location = new System.Drawing.Point(100, 10);
            this.cboProductType.Name = "cboProductType";
            this.cboProductType.Size = new System.Drawing.Size(185, 21);
            this.cboProductType.TabIndex = 1;
            this.cboProductType.SelectionChangeCommitted += new System.EventHandler(this.cboProductType_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loại";
            // 
            // chkRAll
            // 
            this.chkRAll.AutoSize = true;
            this.chkRAll.Location = new System.Drawing.Point(7, 3);
            this.chkRAll.Name = "chkRAll";
            this.chkRAll.Size = new System.Drawing.Size(81, 17);
            this.chkRAll.TabIndex = 19;
            this.chkRAll.Text = "Chọn tất cả";
            this.chkRAll.UseVisualStyleBackColor = true;
            this.chkRAll.CheckedChanged += new System.EventHandler(this.chkAllYCVT_CheckedChanged);
            // 
            // grdYCVT
            // 
            this.grdYCVT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdYCVT.Location = new System.Drawing.Point(7, 24);
            this.grdYCVT.MainView = this.grvYCVT;
            this.grdYCVT.Name = "grdYCVT";
            this.grdYCVT.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit2,
            this.repositoryItemCheckEdit2});
            this.grdYCVT.Size = new System.Drawing.Size(354, 211);
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
            this.colRProjectCode});
            this.grvYCVT.GridControl = this.grdYCVT;
            this.grvYCVT.Name = "grvYCVT";
            this.grvYCVT.OptionsFind.AlwaysVisible = true;
            this.grvYCVT.OptionsView.RowAutoHeight = true;
            this.grvYCVT.OptionsView.ShowFooter = true;
            this.grvYCVT.OptionsView.ShowGroupPanel = false;
            this.grvYCVT.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvYCVT_CellValueChanged);
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
            this.colRCode.VisibleIndex = 1;
            this.colRCode.Width = 91;
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
            this.colRName.VisibleIndex = 2;
            this.colRName.Width = 206;
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
            this.colRcheck.Visible = true;
            this.colRcheck.VisibleIndex = 0;
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
            this.grdParts.Size = new System.Drawing.Size(809, 437);
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
            this.colRiUserId});
            this.grvParts.GridControl = this.grdParts;
            this.grvParts.GroupCount = 1;
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
            this.grvParts.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colRiManufacturerCode, DevExpress.Data.ColumnSortOrder.Ascending)});
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
            this.colRiProjectCode.Visible = true;
            this.colRiProjectCode.VisibleIndex = 0;
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
            this.colRiProductCode.Visible = true;
            this.colRiProductCode.VisibleIndex = 1;
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
            this.colRiPartCode.Visible = true;
            this.colRiPartCode.VisibleIndex = 2;
            this.colRiPartCode.Width = 111;
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
            this.colRiPartsName.VisibleIndex = 3;
            this.colRiPartsName.Width = 154;
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
            this.colRiOrigin.VisibleIndex = 4;
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
            this.colRiRequestCode.Visible = true;
            this.colRiRequestCode.VisibleIndex = 5;
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
            this.colRiSpecifications.Visible = true;
            this.colRiSpecifications.VisibleIndex = 6;
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
            this.colRiUserName.Visible = true;
            this.colRiUserName.VisibleIndex = 7;
            this.colRiUserName.Width = 100;
            // 
            // colRiUserId
            // 
            this.colRiUserId.Caption = "UserId";
            this.colRiUserId.FieldName = "UserId";
            this.colRiUserId.Name = "colRiUserId";
            // 
            // mnuMenu
            // 
            this.mnuMenu.AutoSize = false;
            this.mnuMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.mnuMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.toolStripSeparator2,
            this.btnConfig});
            this.mnuMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuMenu.Size = new System.Drawing.Size(1189, 42);
            this.mnuMenu.TabIndex = 22;
            this.mnuMenu.Text = "toolStrip2";
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(32, 33);
            this.btnSave.Text = "Tạo";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AutoSize = false;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 40);
            // 
            // btnConfig
            // 
            this.btnConfig.Image = ((System.Drawing.Image)(resources.GetObject("btnConfig.Image")));
            this.btnConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(59, 33);
            this.btnConfig.Tag = "";
            this.btnConfig.Text = "Cấu hình";
            this.btnConfig.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // cboUser
            // 
            this.cboUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboUser.Location = new System.Drawing.Point(773, 12);
            this.cboUser.Name = "cboUser";
            this.cboUser.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7F);
            this.cboUser.Properties.Appearance.Options.UseFont = true;
            this.cboUser.Properties.AutoHeight = false;
            this.cboUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboUser.Properties.NullText = "";
            this.cboUser.Properties.View = this.grvCboUser;
            this.cboUser.Size = new System.Drawing.Size(358, 20);
            this.cboUser.TabIndex = 186;
            // 
            // grvCboUser
            // 
            this.grvCboUser.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUserID,
            this.colFullName,
            this.colAccount});
            this.grvCboUser.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboUser.Name = "grvCboUser";
            this.grvCboUser.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvCboUser.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboUser.OptionsView.ShowGroupedColumns = true;
            this.grvCboUser.OptionsView.ShowGroupPanel = false;
            // 
            // colUserID
            // 
            this.colUserID.Caption = "ID";
            this.colUserID.FieldName = "UserId";
            this.colUserID.Name = "colUserID";
            // 
            // colFullName
            // 
            this.colFullName.Caption = "Tên đầy đủ";
            this.colFullName.FieldName = "UserName";
            this.colFullName.Name = "colFullName";
            this.colFullName.Visible = true;
            this.colFullName.VisibleIndex = 0;
            // 
            // colAccount
            // 
            this.colAccount.Caption = "Tên đăng nhập";
            this.colAccount.FieldName = "Account";
            this.colAccount.Name = "colAccount";
            this.colAccount.Visible = true;
            this.colAccount.VisibleIndex = 1;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(685, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 13);
            this.label11.TabIndex = 187;
            this.label11.Text = "Người phụ trách";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnSet
            // 
            this.btnSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSet.Location = new System.Drawing.Point(1137, 10);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(40, 23);
            this.btnSet.TabIndex = 188;
            this.btnSet.Text = "Gán";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // frmCreateYCMVT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 491);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.cboUser);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.mnuMenu);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmCreateYCMVT";
            this.Text = "TẠO YÊU CẦU MUA VẬT TƯ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCreateYCMVT_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdYCVT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvYCVT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdParts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvParts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).EndInit();
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCboUser)).EndInit();
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
        private DevExpress.XtraGrid.GridControl grdProject;
        private DevExpress.XtraGrid.Views.Grid.GridView grvProject;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colPCode;
        private DevExpress.XtraGrid.Columns.GridColumn colPName;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colPYear;
        private DevExpress.XtraGrid.GridControl grdYCVT;
        private DevExpress.XtraGrid.Views.Grid.GridView grvYCVT;
        private DevExpress.XtraGrid.Columns.GridColumn colRID;
        private DevExpress.XtraGrid.Columns.GridColumn colRCode;
        private DevExpress.XtraGrid.Columns.GridColumn colRName;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private DevExpress.XtraGrid.GridControl grdParts;
        private DevExpress.XtraGrid.Views.Grid.GridView grvParts;
        private DevExpress.XtraGrid.Columns.GridColumn colRiID;
        private DevExpress.XtraGrid.Columns.GridColumn colRiProjectCode;
        private DevExpress.XtraGrid.Columns.GridColumn colRiProductCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit3;
        private DevExpress.XtraGrid.Columns.GridColumn colPCheck;
        private System.Windows.Forms.ToolStrip mnuMenu;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnConfig;
        private DevExpress.XtraGrid.Columns.GridColumn colRcheck;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colRProjectCode;
        private DevExpress.XtraGrid.Columns.GridColumn colRiPartCode;
        private DevExpress.XtraGrid.Columns.GridColumn colRiPartsName;
        private DevExpress.XtraGrid.Columns.GridColumn colRiManufacturerCode;
        private DevExpress.XtraGrid.Columns.GridColumn colRiOrigin;
        private DevExpress.XtraGrid.Columns.GridColumn colRiRequestCode;
        private DevExpress.XtraGrid.Columns.GridColumn colRiSpecifications;
        private System.Windows.Forms.CheckBox chkRAll;
        private DevExpress.XtraGrid.Columns.GridColumn colRiUserName;
        private DevExpress.XtraEditors.SearchLookUpEdit cboUser;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCboUser;
        private DevExpress.XtraGrid.Columns.GridColumn colUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colFullName;
        private DevExpress.XtraGrid.Columns.GridColumn colAccount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnSet;
        private DevExpress.XtraGrid.Columns.GridColumn colRiUserId;
    }
}