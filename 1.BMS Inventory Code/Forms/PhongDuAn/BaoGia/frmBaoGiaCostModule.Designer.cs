namespace BMS
{
    partial class frmBaoGiaCostModule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaoGiaCostModule));
            this.mnuMenu = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grdCost = new DevExpress.XtraGrid.GridControl();
            this.grvCost = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCostName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalReal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartmentID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboDepartment = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCostDetailID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.grdCostTM = new DevExpress.XtraGrid.GridControl();
            this.grvCostTM = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIDTM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCostNameTM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colTotalTM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalRealTM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartmentIDTM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboDepartmentTM = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCostDetailIDTM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDIDTM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboModule = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.grvModule = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colModuleCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModuleName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.mnuMenu.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCostTM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCostTM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartmentTM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboModule.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvModule)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuMenu
            // 
            this.mnuMenu.AutoSize = false;
            this.mnuMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.mnuMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave});
            this.mnuMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuMenu.Size = new System.Drawing.Size(751, 41);
            this.mnuMenu.TabIndex = 235;
            this.mnuMenu.Text = "toolStrip2";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(29, 33);
            this.btnSave.Tag = "frmBaoGia_Save";
            this.btnSave.Text = "Ghi";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 80);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grdCost);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grdCostTM);
            this.splitContainer1.Panel2.Controls.Add(this.labelControl2);
            this.splitContainer1.Size = new System.Drawing.Size(750, 394);
            this.splitContainer1.SplitterDistance = 240;
            this.splitContainer1.TabIndex = 234;
            // 
            // grdCost
            // 
            this.grdCost.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdCost.Location = new System.Drawing.Point(3, 23);
            this.grdCost.MainView = this.grvCost;
            this.grdCost.Name = "grdCost";
            this.grdCost.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit3,
            this.cboDepartment});
            this.grdCost.Size = new System.Drawing.Size(742, 214);
            this.grdCost.TabIndex = 190;
            this.grdCost.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCost});
            // 
            // grvCost
            // 
            this.grvCost.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvCost.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvCost.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvCost.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvCost.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvCost.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvCost.ColumnPanelRowHeight = 40;
            this.grvCost.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colCostName,
            this.colTotal,
            this.colTotalReal,
            this.colDepartmentID,
            this.colCostDetailID,
            this.colDID});
            this.grvCost.GridControl = this.grdCost;
            this.grvCost.Name = "grvCost";
            this.grvCost.OptionsView.RowAutoHeight = true;
            this.grvCost.OptionsView.ShowFooter = true;
            this.grvCost.OptionsView.ShowGroupPanel = false;
            // 
            // colID
            // 
            this.colID.Caption = "CostSummaryModuleID";
            this.colID.FieldName = "CostSummaryModuleID";
            this.colID.Name = "colID";
            // 
            // colCostName
            // 
            this.colCostName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCostName.AppearanceHeader.Options.UseFont = true;
            this.colCostName.AppearanceHeader.Options.UseTextOptions = true;
            this.colCostName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCostName.Caption = "Tên chi phí";
            this.colCostName.ColumnEdit = this.repositoryItemMemoEdit3;
            this.colCostName.FieldName = "Name";
            this.colCostName.Name = "colCostName";
            this.colCostName.OptionsColumn.AllowEdit = false;
            this.colCostName.OptionsColumn.AllowFocus = false;
            this.colCostName.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Name", "{0:n0}")});
            this.colCostName.Visible = true;
            this.colCostName.VisibleIndex = 0;
            this.colCostName.Width = 250;
            // 
            // repositoryItemMemoEdit3
            // 
            this.repositoryItemMemoEdit3.Name = "repositoryItemMemoEdit3";
            // 
            // colTotal
            // 
            this.colTotal.AppearanceCell.Options.UseTextOptions = true;
            this.colTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colTotal.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTotal.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTotal.AppearanceHeader.Options.UseFont = true;
            this.colTotal.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotal.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotal.Caption = "Chi phí dự kiến";
            this.colTotal.DisplayFormat.FormatString = "n0";
            this.colTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotal.FieldName = "TotalDK";
            this.colTotal.Name = "colTotal";
            this.colTotal.OptionsColumn.AllowEdit = false;
            this.colTotal.OptionsColumn.AllowFocus = false;
            this.colTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalDK", "{0:n0}")});
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 1;
            this.colTotal.Width = 119;
            // 
            // colTotalReal
            // 
            this.colTotalReal.AppearanceCell.Options.UseTextOptions = true;
            this.colTotalReal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colTotalReal.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTotalReal.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTotalReal.AppearanceHeader.Options.UseFont = true;
            this.colTotalReal.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotalReal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotalReal.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalReal.Caption = "Chi phí thực tế";
            this.colTotalReal.DisplayFormat.FormatString = "n0";
            this.colTotalReal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalReal.FieldName = "TotalTT";
            this.colTotalReal.Name = "colTotalReal";
            this.colTotalReal.OptionsColumn.AllowEdit = false;
            this.colTotalReal.OptionsColumn.AllowFocus = false;
            this.colTotalReal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalTT", "{0:n0}")});
            this.colTotalReal.Visible = true;
            this.colTotalReal.VisibleIndex = 2;
            this.colTotalReal.Width = 120;
            // 
            // colDepartmentID
            // 
            this.colDepartmentID.AppearanceCell.Options.UseTextOptions = true;
            this.colDepartmentID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colDepartmentID.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDepartmentID.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDepartmentID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colDepartmentID.AppearanceHeader.Options.UseFont = true;
            this.colDepartmentID.AppearanceHeader.Options.UseTextOptions = true;
            this.colDepartmentID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDepartmentID.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDepartmentID.Caption = "Phòng ban";
            this.colDepartmentID.ColumnEdit = this.cboDepartment;
            this.colDepartmentID.FieldName = "DepartmentID";
            this.colDepartmentID.Name = "colDepartmentID";
            this.colDepartmentID.Visible = true;
            this.colDepartmentID.VisibleIndex = 3;
            this.colDepartmentID.Width = 158;
            // 
            // cboDepartment
            // 
            this.cboDepartment.AutoHeight = false;
            this.cboDepartment.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.NullText = "";
            this.cboDepartment.View = this.repositoryItemSearchLookUpEdit1View;
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn6});
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "ID";
            this.gridColumn5.FieldName = "ID";
            this.gridColumn5.Name = "gridColumn5";
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn6.AppearanceHeader.Options.UseFont = true;
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.Caption = "Tên phòng ban";
            this.gridColumn6.FieldName = "Name";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            // 
            // colCostDetailID
            // 
            this.colCostDetailID.Caption = "CostDetailID";
            this.colCostDetailID.FieldName = "CostDetailID";
            this.colCostDetailID.Name = "colCostDetailID";
            // 
            // colDID
            // 
            this.colDID.Caption = "DID";
            this.colDID.FieldName = "DID";
            this.colDID.Name = "colDID";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(8, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(89, 13);
            this.labelControl1.TabIndex = 184;
            this.labelControl1.Text = "Chi phí sản xuất";
            // 
            // grdCostTM
            // 
            this.grdCostTM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdCostTM.Location = new System.Drawing.Point(3, 20);
            this.grdCostTM.MainView = this.grvCostTM;
            this.grdCostTM.Name = "grdCostTM";
            this.grdCostTM.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit2,
            this.cboDepartmentTM});
            this.grdCostTM.Size = new System.Drawing.Size(742, 127);
            this.grdCostTM.TabIndex = 190;
            this.grdCostTM.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCostTM});
            // 
            // grvCostTM
            // 
            this.grvCostTM.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvCostTM.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvCostTM.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvCostTM.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvCostTM.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvCostTM.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvCostTM.ColumnPanelRowHeight = 40;
            this.grvCostTM.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIDTM,
            this.colCostNameTM,
            this.colTotalTM,
            this.colTotalRealTM,
            this.colDepartmentIDTM,
            this.colCostDetailIDTM,
            this.colDIDTM});
            this.grvCostTM.GridControl = this.grdCostTM;
            this.grvCostTM.Name = "grvCostTM";
            this.grvCostTM.OptionsView.RowAutoHeight = true;
            this.grvCostTM.OptionsView.ShowFooter = true;
            this.grvCostTM.OptionsView.ShowGroupPanel = false;
            // 
            // colIDTM
            // 
            this.colIDTM.Caption = "CostSummaryModuleID";
            this.colIDTM.FieldName = "CostSummaryModuleID";
            this.colIDTM.Name = "colIDTM";
            // 
            // colCostNameTM
            // 
            this.colCostNameTM.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCostNameTM.AppearanceHeader.Options.UseFont = true;
            this.colCostNameTM.AppearanceHeader.Options.UseTextOptions = true;
            this.colCostNameTM.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCostNameTM.Caption = "Tên chi phí";
            this.colCostNameTM.ColumnEdit = this.repositoryItemMemoEdit2;
            this.colCostNameTM.FieldName = "Name";
            this.colCostNameTM.Name = "colCostNameTM";
            this.colCostNameTM.OptionsColumn.AllowEdit = false;
            this.colCostNameTM.OptionsColumn.AllowFocus = false;
            this.colCostNameTM.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Name", "{0:n0}")});
            this.colCostNameTM.Visible = true;
            this.colCostNameTM.VisibleIndex = 0;
            this.colCostNameTM.Width = 248;
            // 
            // repositoryItemMemoEdit2
            // 
            this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
            // 
            // colTotalTM
            // 
            this.colTotalTM.AppearanceCell.Options.UseTextOptions = true;
            this.colTotalTM.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colTotalTM.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTotalTM.AppearanceHeader.Options.UseFont = true;
            this.colTotalTM.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotalTM.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotalTM.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalTM.Caption = "Chi phí dự kiến";
            this.colTotalTM.DisplayFormat.FormatString = "n0";
            this.colTotalTM.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalTM.FieldName = "TotalDK";
            this.colTotalTM.Name = "colTotalTM";
            this.colTotalTM.OptionsColumn.AllowEdit = false;
            this.colTotalTM.OptionsColumn.AllowFocus = false;
            this.colTotalTM.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalDK", "{0:n0}")});
            this.colTotalTM.Visible = true;
            this.colTotalTM.VisibleIndex = 1;
            this.colTotalTM.Width = 117;
            // 
            // colTotalRealTM
            // 
            this.colTotalRealTM.AppearanceCell.Options.UseTextOptions = true;
            this.colTotalRealTM.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colTotalRealTM.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTotalRealTM.AppearanceHeader.Options.UseFont = true;
            this.colTotalRealTM.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotalRealTM.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotalRealTM.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalRealTM.Caption = "Chi phí thực tế";
            this.colTotalRealTM.DisplayFormat.FormatString = "n0";
            this.colTotalRealTM.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalRealTM.FieldName = "TotalTT";
            this.colTotalRealTM.Name = "colTotalRealTM";
            this.colTotalRealTM.OptionsColumn.AllowEdit = false;
            this.colTotalRealTM.OptionsColumn.AllowFocus = false;
            this.colTotalRealTM.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalTT", "{0:n0}")});
            this.colTotalRealTM.Visible = true;
            this.colTotalRealTM.VisibleIndex = 2;
            this.colTotalRealTM.Width = 120;
            // 
            // colDepartmentIDTM
            // 
            this.colDepartmentIDTM.AppearanceCell.Options.UseTextOptions = true;
            this.colDepartmentIDTM.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colDepartmentIDTM.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDepartmentIDTM.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDepartmentIDTM.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colDepartmentIDTM.AppearanceHeader.Options.UseFont = true;
            this.colDepartmentIDTM.AppearanceHeader.Options.UseTextOptions = true;
            this.colDepartmentIDTM.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDepartmentIDTM.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDepartmentIDTM.Caption = "Phòng ban";
            this.colDepartmentIDTM.ColumnEdit = this.cboDepartmentTM;
            this.colDepartmentIDTM.FieldName = "DepartmentID";
            this.colDepartmentIDTM.Name = "colDepartmentIDTM";
            this.colDepartmentIDTM.Visible = true;
            this.colDepartmentIDTM.VisibleIndex = 3;
            this.colDepartmentIDTM.Width = 182;
            // 
            // cboDepartmentTM
            // 
            this.cboDepartmentTM.AutoHeight = false;
            this.cboDepartmentTM.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDepartmentTM.Name = "cboDepartmentTM";
            this.cboDepartmentTM.NullText = "";
            this.cboDepartmentTM.View = this.gridView1;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ID";
            this.gridColumn1.FieldName = "ID";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Tên phòng ban";
            this.gridColumn2.FieldName = "Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // colCostDetailIDTM
            // 
            this.colCostDetailIDTM.Caption = "CostDetailID";
            this.colCostDetailIDTM.FieldName = "CostDetailID";
            this.colCostDetailIDTM.Name = "colCostDetailIDTM";
            // 
            // colDIDTM
            // 
            this.colDIDTM.Caption = "DID";
            this.colDIDTM.FieldName = "DID";
            this.colDIDTM.Name = "colDIDTM";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Location = new System.Drawing.Point(8, 5);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(105, 13);
            this.labelControl2.TabIndex = 184;
            this.labelControl2.Text = "Chi phí thương mại";
            // 
            // cboModule
            // 
            this.cboModule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboModule.Location = new System.Drawing.Point(55, 52);
            this.cboModule.Name = "cboModule";
            this.cboModule.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboModule.Properties.NullText = "";
            this.cboModule.Properties.View = this.grvModule;
            this.cboModule.Size = new System.Drawing.Size(684, 20);
            this.cboModule.TabIndex = 237;
            this.cboModule.EditValueChanged += new System.EventHandler(this.cboModule_EditValueChanged);
            // 
            // grvModule
            // 
            this.grvModule.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colModuleCode,
            this.colModuleName});
            this.grvModule.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvModule.Name = "grvModule";
            this.grvModule.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvModule.OptionsView.ShowGroupPanel = false;
            // 
            // colModuleCode
            // 
            this.colModuleCode.Caption = "Mã";
            this.colModuleCode.FieldName = "ModuleCode";
            this.colModuleCode.Name = "colModuleCode";
            this.colModuleCode.Visible = true;
            this.colModuleCode.VisibleIndex = 0;
            this.colModuleCode.Width = 292;
            // 
            // colModuleName
            // 
            this.colModuleName.Caption = "Tên";
            this.colModuleName.FieldName = "ModuleName";
            this.colModuleName.Name = "colModuleName";
            this.colModuleName.Visible = true;
            this.colModuleName.VisibleIndex = 1;
            this.colModuleName.Width = 888;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 236;
            this.label8.Text = "Module";
            // 
            // frmBaoGiaCostModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 474);
            this.Controls.Add(this.cboModule);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.mnuMenu);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmBaoGiaCostModule";
            this.Text = "CHÍ PHÍ THEO MODULE";
            this.Load += new System.EventHandler(this.frmBaoGiaCostModule_Load);
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCostTM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCostTM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartmentTM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboModule.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvModule)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip mnuMenu;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraGrid.GridControl grdCost;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCost;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colCostName;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit3;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalReal;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartmentID;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit cboDepartment;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn colCostDetailID;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl grdCostTM;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCostTM;
        private DevExpress.XtraGrid.Columns.GridColumn colIDTM;
        private DevExpress.XtraGrid.Columns.GridColumn colCostNameTM;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalTM;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalRealTM;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartmentIDTM;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit cboDepartmentTM;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn colCostDetailIDTM;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SearchLookUpEdit cboModule;
        private DevExpress.XtraGrid.Views.Grid.GridView grvModule;
        private DevExpress.XtraGrid.Columns.GridColumn colModuleCode;
        private DevExpress.XtraGrid.Columns.GridColumn colModuleName;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraGrid.Columns.GridColumn colDID;
        private DevExpress.XtraGrid.Columns.GridColumn colDIDTM;
    }
}