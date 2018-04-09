namespace BMS
{
    partial class frmReportProgressProject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportProgressProject));
            this.label1 = new System.Windows.Forms.Label();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.đangSảnXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hủyĐangSảnXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompletePercent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCNC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGCAL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPCB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsAssembly = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colStatusName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
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
            this.btnReloadData = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSetStatus = new System.Windows.Forms.Button();
            this.btnManageStatus = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProject)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(461, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 235;
            this.label1.Text = "Năm";
            // 
            // cboYear
            // 
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(494, 7);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(121, 21);
            this.cboYear.TabIndex = 234;
            // 
            // grdData
            // 
            this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdData.ContextMenuStrip = this.contextMenuStrip1;
            this.grdData.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdData.Location = new System.Drawing.Point(3, 36);
            this.grdData.MainView = this.grvData;
            this.grdData.Name = "grdData";
            this.grdData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemMemoEdit1,
            this.repositoryItemLookUpEdit1});
            this.grdData.Size = new System.Drawing.Size(1065, 406);
            this.grdData.TabIndex = 233;
            this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvData});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đangSảnXuấtToolStripMenuItem,
            this.hủyĐangSảnXuấtToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(173, 48);
            // 
            // đangSảnXuấtToolStripMenuItem
            // 
            this.đangSảnXuấtToolStripMenuItem.Name = "đangSảnXuấtToolStripMenuItem";
            this.đangSảnXuấtToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.đangSảnXuấtToolStripMenuItem.Text = "Đang sản xuất";
            this.đangSảnXuấtToolStripMenuItem.Click += new System.EventHandler(this.đangSảnXuấtToolStripMenuItem_Click);
            // 
            // hủyĐangSảnXuấtToolStripMenuItem
            // 
            this.hủyĐangSảnXuấtToolStripMenuItem.Name = "hủyĐangSảnXuấtToolStripMenuItem";
            this.hủyĐangSảnXuấtToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.hủyĐangSảnXuấtToolStripMenuItem.Text = "Hủy đang sản xuất";
            this.hủyĐangSảnXuấtToolStripMenuItem.Click += new System.EventHandler(this.hủyĐangSảnXuấtToolStripMenuItem_Click);
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
            this.colID,
            this.colName,
            this.colCode,
            this.colCompletePercent,
            this.colCNC,
            this.colIN,
            this.colGCAL,
            this.colPCB,
            this.colLR,
            this.colIsAssembly,
            this.colStatusName});
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
            // 
            // colID
            // 
            this.colID.AppearanceCell.Options.UseTextOptions = true;
            this.colID.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colID.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colID.AppearanceHeader.Options.UseFont = true;
            this.colID.AppearanceHeader.Options.UseTextOptions = true;
            this.colID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colID.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colID.Caption = "Mã";
            this.colID.FieldName = "ProjectId";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.AllowEdit = false;
            this.colID.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colID.Width = 68;
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
            this.colName.Caption = "Tên dự án";
            this.colName.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colName.FieldName = "ProjectName";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            this.colName.Width = 338;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Appearance.Options.UseTextOptions = true;
            this.repositoryItemMemoEdit1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // colCode
            // 
            this.colCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCode.AppearanceHeader.Options.UseFont = true;
            this.colCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCode.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCode.Caption = "Dự án";
            this.colCode.FieldName = "ProjectCode";
            this.colCode.Name = "colCode";
            this.colCode.OptionsColumn.AllowEdit = false;
            this.colCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 1;
            this.colCode.Width = 92;
            // 
            // colCompletePercent
            // 
            this.colCompletePercent.AppearanceCell.Options.UseTextOptions = true;
            this.colCompletePercent.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCompletePercent.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCompletePercent.AppearanceHeader.Options.UseFont = true;
            this.colCompletePercent.AppearanceHeader.Options.UseTextOptions = true;
            this.colCompletePercent.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCompletePercent.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCompletePercent.Caption = "% Tổng tiến độ";
            this.colCompletePercent.DisplayFormat.FormatString = "n0";
            this.colCompletePercent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCompletePercent.FieldName = "CompletePercent";
            this.colCompletePercent.Name = "colCompletePercent";
            this.colCompletePercent.OptionsColumn.AllowEdit = false;
            this.colCompletePercent.OptionsColumn.AllowSize = false;
            this.colCompletePercent.Visible = true;
            this.colCompletePercent.VisibleIndex = 3;
            this.colCompletePercent.Width = 80;
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
            this.colCNC.Caption = "% Tiến độ CNC";
            this.colCNC.FieldName = "PercentCNC";
            this.colCNC.Name = "colCNC";
            this.colCNC.OptionsColumn.AllowEdit = false;
            this.colCNC.OptionsColumn.AllowSize = false;
            this.colCNC.Visible = true;
            this.colCNC.VisibleIndex = 4;
            this.colCNC.Width = 76;
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
            this.colIN.Caption = "% Tiến độ IN";
            this.colIN.FieldName = "PercentIN";
            this.colIN.Name = "colIN";
            this.colIN.OptionsColumn.AllowEdit = false;
            this.colIN.OptionsColumn.AllowSize = false;
            this.colIN.Visible = true;
            this.colIN.VisibleIndex = 5;
            this.colIN.Width = 72;
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
            this.colGCAL.Caption = "% Tiến độ gia công nhôm";
            this.colGCAL.FieldName = "PerrcentGCAL";
            this.colGCAL.Name = "colGCAL";
            this.colGCAL.OptionsColumn.AllowEdit = false;
            this.colGCAL.OptionsColumn.AllowSize = false;
            this.colGCAL.Visible = true;
            this.colGCAL.VisibleIndex = 6;
            this.colGCAL.Width = 85;
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
            this.colPCB.Caption = "% Tiến độ mạch điện tử";
            this.colPCB.FieldName = "PercentPCB";
            this.colPCB.Name = "colPCB";
            this.colPCB.OptionsColumn.AllowEdit = false;
            this.colPCB.OptionsColumn.AllowSize = false;
            this.colPCB.Visible = true;
            this.colPCB.VisibleIndex = 7;
            this.colPCB.Width = 100;
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
            this.colLR.Caption = "% Tiến độ lắp ráp";
            this.colLR.FieldName = "PercentLR";
            this.colLR.Name = "colLR";
            this.colLR.OptionsColumn.AllowEdit = false;
            this.colLR.OptionsColumn.AllowSize = false;
            this.colLR.Visible = true;
            this.colLR.VisibleIndex = 8;
            this.colLR.Width = 81;
            // 
            // colIsAssembly
            // 
            this.colIsAssembly.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colIsAssembly.AppearanceHeader.Options.UseFont = true;
            this.colIsAssembly.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsAssembly.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsAssembly.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colIsAssembly.Caption = "Đang sản xuất";
            this.colIsAssembly.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colIsAssembly.FieldName = "IsAssembly";
            this.colIsAssembly.Name = "colIsAssembly";
            this.colIsAssembly.Width = 61;
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
            // colStatusName
            // 
            this.colStatusName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colStatusName.AppearanceHeader.Options.UseFont = true;
            this.colStatusName.AppearanceHeader.Options.UseTextOptions = true;
            this.colStatusName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStatusName.Caption = "Tên trạng thái";
            this.colStatusName.FieldName = "StatusName";
            this.colStatusName.Name = "colStatusName";
            this.colStatusName.OptionsColumn.AllowEdit = false;
            this.colStatusName.Visible = true;
            this.colStatusName.VisibleIndex = 0;
            this.colStatusName.Width = 115;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.NullText = "";
            // 
            // cboProject
            // 
            this.cboProject.Location = new System.Drawing.Point(68, 8);
            this.cboProject.Name = "cboProject";
            this.cboProject.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProject.Properties.NullText = "";
            this.cboProject.Properties.View = this.grvProject;
            this.cboProject.Size = new System.Drawing.Size(386, 20);
            this.cboProject.TabIndex = 232;
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
            // btnReloadData
            // 
            this.btnReloadData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReloadData.Location = new System.Drawing.Point(814, 5);
            this.btnReloadData.Name = "btnReloadData";
            this.btnReloadData.Size = new System.Drawing.Size(91, 23);
            this.btnReloadData.TabIndex = 231;
            this.btnReloadData.Text = "Tải dữ liệu";
            this.btnReloadData.UseVisualStyleBackColor = true;
            this.btnReloadData.Click += new System.EventHandler(this.btnReloadData_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 230;
            this.label6.Text = "Dự án";
            // 
            // cboStatus
            // 
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(685, 6);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(121, 21);
            this.cboStatus.TabIndex = 234;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(622, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 235;
            this.label2.Text = "Trạng thái";
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnExcel.Appearance.Options.UseFont = true;
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.Location = new System.Drawing.Point(944, 46);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(104, 29);
            this.btnExcel.TabIndex = 237;
            this.btnExcel.Text = "Xuất excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnSetStatus
            // 
            this.btnSetStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetStatus.Location = new System.Drawing.Point(912, 5);
            this.btnSetStatus.Name = "btnSetStatus";
            this.btnSetStatus.Size = new System.Drawing.Size(97, 23);
            this.btnSetStatus.TabIndex = 238;
            this.btnSetStatus.Text = "Gán trạng thái";
            this.btnSetStatus.UseVisualStyleBackColor = true;
            this.btnSetStatus.Click += new System.EventHandler(this.btnSetStatus_Click);
            // 
            // btnManageStatus
            // 
            this.btnManageStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnManageStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageStatus.Location = new System.Drawing.Point(761, 48);
            this.btnManageStatus.Name = "btnManageStatus";
            this.btnManageStatus.Size = new System.Drawing.Size(174, 23);
            this.btnManageStatus.TabIndex = 239;
            this.btnManageStatus.Text = "Quản lý trạng thái dự án";
            this.btnManageStatus.UseVisualStyleBackColor = true;
            this.btnManageStatus.Click += new System.EventHandler(this.btnManageStatus_Click);
            // 
            // frmReportProgressProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 444);
            this.Controls.Add(this.btnManageStatus);
            this.Controls.Add(this.btnSetStatus);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.cboYear);
            this.Controls.Add(this.grdData);
            this.Controls.Add(this.cboProject);
            this.Controls.Add(this.btnReloadData);
            this.Controls.Add(this.label6);
            this.Name = "frmReportProgressProject";
            this.Text = "BÁO CÁO TIẾN ĐỘ DỰ ÁN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReportProgressProject_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProject)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboYear;
        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.Grid.GridView grvData;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colCompletePercent;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCNC;
        private DevExpress.XtraGrid.Columns.GridColumn colIN;
        private DevExpress.XtraGrid.Columns.GridColumn colGCAL;
        private DevExpress.XtraGrid.Columns.GridColumn colPCB;
        private DevExpress.XtraGrid.Columns.GridColumn colLR;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraEditors.SearchLookUpEdit cboProject;
        private DevExpress.XtraGrid.Views.Grid.GridView grvProject;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectID;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectCode;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectName;
        private DevExpress.XtraGrid.Columns.GridColumn colYear;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colAssemblyDeadline;
        private DevExpress.XtraGrid.Columns.GridColumn colDateFinishE;
        private System.Windows.Forms.Button btnReloadData;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraGrid.Columns.GridColumn colIsAssembly;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem đangSảnXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hủyĐangSảnXuấtToolStripMenuItem;
        private DevExpress.XtraEditors.SimpleButton btnExcel;
        private System.Windows.Forms.Button btnSetStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colStatusName;
        private System.Windows.Forms.Button btnManageStatus;

    }
}