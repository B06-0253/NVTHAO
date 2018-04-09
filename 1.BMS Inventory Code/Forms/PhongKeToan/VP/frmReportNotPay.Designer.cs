namespace BMS
{
    partial class frmReportNotPay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportNotPay));
            this.mnuMenu = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.grvData = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colCheck = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colNumber = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colCode = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colContent = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colTarget = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.Sốtiền = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colIsTM = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colPercentPay = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colTotal = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colTM = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colCK = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colIsPaid = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colIsApproved = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colContentCheck = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colNote = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colUserName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colDeliveryCost = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colDiffCost = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colTotalTH = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemGridLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.mnuMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuMenu
            // 
            this.mnuMenu.AutoSize = false;
            this.mnuMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.mnuMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd});
            this.mnuMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuMenu.Size = new System.Drawing.Size(1028, 42);
            this.mnuMenu.TabIndex = 23;
            this.mnuMenu.Text = "toolStrip2";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(112, 34);
            this.btnAdd.Tag = "frmPaymentTableManager_New";
            this.btnAdd.Text = "Tạo bảng kê mới";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // grdData
            // 
            this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdData.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdData.Location = new System.Drawing.Point(0, 45);
            this.grdData.MainView = this.grvData;
            this.grdData.Name = "grdData";
            this.grdData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1,
            this.repositoryItemTextEdit1,
            this.repositoryItemCheckEdit1,
            this.repositoryItemGridLookUpEdit1});
            this.grdData.Size = new System.Drawing.Size(1028, 439);
            this.grdData.TabIndex = 25;
            this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvData});
            // 
            // grvData
            // 
            this.grvData.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvData.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvData.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvData.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grvData.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvData.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvData.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.Sốtiền,
            this.gridBand3});
            this.grvData.ColumnPanelRowHeight = 40;
            this.grvData.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colID,
            this.colName,
            this.colContent,
            this.colCode,
            this.colTarget,
            this.colTM,
            this.colCK,
            this.colContentCheck,
            this.colNote,
            this.colPercentPay,
            this.colTotal,
            this.colIsTM,
            this.colDeliveryCost,
            this.colDiffCost,
            this.colTotalTH,
            this.colUserName,
            this.colIsPaid,
            this.colIsApproved,
            this.colNumber,
            this.colCheck});
            this.grvData.GridControl = this.grdData;
            this.grvData.Name = "grvData";
            this.grvData.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvData.OptionsCustomization.AllowRowSizing = true;
            this.grvData.OptionsFind.AlwaysVisible = true;
            this.grvData.OptionsSelection.MultiSelect = true;
            this.grvData.OptionsView.AllowHtmlDrawHeaders = true;
            this.grvData.OptionsView.ColumnAutoWidth = false;
            this.grvData.OptionsView.RowAutoHeight = true;
            this.grvData.OptionsView.ShowFooter = true;
            this.grvData.OptionsView.ShowGroupPanel = false;
            // 
            // gridBand1
            // 
            this.gridBand1.Columns.Add(this.colID);
            this.gridBand1.Columns.Add(this.colCheck);
            this.gridBand1.Columns.Add(this.colNumber);
            this.gridBand1.Columns.Add(this.colCode);
            this.gridBand1.Columns.Add(this.colName);
            this.gridBand1.Columns.Add(this.colContent);
            this.gridBand1.Columns.Add(this.colTarget);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.Width = 900;
            // 
            // colID
            // 
            this.colID.AppearanceCell.Options.UseTextOptions = true;
            this.colID.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colID.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colID.AppearanceHeader.Options.UseFont = true;
            this.colID.AppearanceHeader.Options.UseTextOptions = true;
            this.colID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.AllowEdit = false;
            this.colID.Width = 51;
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
            this.colCheck.FieldName = "IsCheck";
            this.colCheck.Name = "colCheck";
            this.colCheck.Visible = true;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // colNumber
            // 
            this.colNumber.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colNumber.AppearanceHeader.Options.UseFont = true;
            this.colNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.colNumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNumber.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNumber.Caption = "Mã bảng kê";
            this.colNumber.FieldName = "Number";
            this.colNumber.Name = "colNumber";
            this.colNumber.OptionsColumn.AllowEdit = false;
            this.colNumber.Visible = true;
            this.colNumber.Width = 110;
            // 
            // colCode
            // 
            this.colCode.AppearanceCell.Options.UseTextOptions = true;
            this.colCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCode.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCode.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCode.AppearanceHeader.Options.UseFont = true;
            this.colCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCode.Caption = "Mã vụ việc";
            this.colCode.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.OptionsColumn.AllowEdit = false;
            this.colCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalCK", "{0:n0}")});
            this.colCode.Visible = true;
            this.colCode.Width = 142;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // colName
            // 
            this.colName.AppearanceCell.Options.UseTextOptions = true;
            this.colName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colName.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colName.AppearanceHeader.Options.UseFont = true;
            this.colName.AppearanceHeader.Options.UseTextOptions = true;
            this.colName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colName.Caption = "Tên công ty/Cá nhân";
            this.colName.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.Visible = true;
            this.colName.Width = 202;
            // 
            // colContent
            // 
            this.colContent.AppearanceCell.Options.UseTextOptions = true;
            this.colContent.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colContent.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colContent.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colContent.AppearanceHeader.Options.UseFont = true;
            this.colContent.AppearanceHeader.Options.UseTextOptions = true;
            this.colContent.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colContent.Caption = "Nội dung thanh toán";
            this.colContent.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colContent.FieldName = "Content";
            this.colContent.Name = "colContent";
            this.colContent.OptionsColumn.AllowEdit = false;
            this.colContent.Visible = true;
            this.colContent.Width = 161;
            // 
            // colTarget
            // 
            this.colTarget.AppearanceCell.Options.UseTextOptions = true;
            this.colTarget.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTarget.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTarget.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTarget.AppearanceHeader.Options.UseFont = true;
            this.colTarget.AppearanceHeader.Options.UseTextOptions = true;
            this.colTarget.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTarget.Caption = "Mục đính";
            this.colTarget.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colTarget.FieldName = "Target";
            this.colTarget.Name = "colTarget";
            this.colTarget.OptionsColumn.AllowEdit = false;
            this.colTarget.Visible = true;
            this.colTarget.Width = 210;
            // 
            // Sốtiền
            // 
            this.Sốtiền.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.Sốtiền.AppearanceHeader.Options.UseFont = true;
            this.Sốtiền.AppearanceHeader.Options.UseTextOptions = true;
            this.Sốtiền.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Sốtiền.Caption = "Số tiền";
            this.Sốtiền.Columns.Add(this.colIsTM);
            this.Sốtiền.Columns.Add(this.colPercentPay);
            this.Sốtiền.Columns.Add(this.colTotal);
            this.Sốtiền.Columns.Add(this.colTM);
            this.Sốtiền.Columns.Add(this.colCK);
            this.Sốtiền.Name = "Sốtiền";
            this.Sốtiền.Width = 393;
            // 
            // colIsTM
            // 
            this.colIsTM.AppearanceCell.Options.UseTextOptions = true;
            this.colIsTM.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colIsTM.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colIsTM.AppearanceHeader.Options.UseFont = true;
            this.colIsTM.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsTM.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsTM.Caption = "Trả TM";
            this.colIsTM.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colIsTM.FieldName = "IsCash";
            this.colIsTM.Name = "colIsTM";
            this.colIsTM.OptionsColumn.AllowEdit = false;
            this.colIsTM.Visible = true;
            this.colIsTM.Width = 47;
            // 
            // colPercentPay
            // 
            this.colPercentPay.AppearanceCell.Options.UseTextOptions = true;
            this.colPercentPay.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPercentPay.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colPercentPay.AppearanceHeader.Options.UseFont = true;
            this.colPercentPay.AppearanceHeader.Options.UseTextOptions = true;
            this.colPercentPay.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPercentPay.Caption = "%";
            this.colPercentPay.ColumnEdit = this.repositoryItemTextEdit1;
            this.colPercentPay.DisplayFormat.FormatString = "n0";
            this.colPercentPay.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPercentPay.FieldName = "PercentPay";
            this.colPercentPay.Name = "colPercentPay";
            this.colPercentPay.OptionsColumn.AllowEdit = false;
            this.colPercentPay.Visible = true;
            this.colPercentPay.Width = 44;
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
            // colTotal
            // 
            this.colTotal.AppearanceCell.Options.UseTextOptions = true;
            this.colTotal.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTotal.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTotal.AppearanceHeader.Options.UseFont = true;
            this.colTotal.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotal.Caption = "Tổng tiền";
            this.colTotal.ColumnEdit = this.repositoryItemTextEdit1;
            this.colTotal.FieldName = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.OptionsColumn.AllowEdit = false;
            this.colTotal.Visible = true;
            this.colTotal.Width = 110;
            // 
            // colTM
            // 
            this.colTM.AppearanceCell.Options.UseTextOptions = true;
            this.colTM.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTM.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colTM.AppearanceHeader.Options.UseFont = true;
            this.colTM.AppearanceHeader.Options.UseTextOptions = true;
            this.colTM.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTM.Caption = "TM";
            this.colTM.DisplayFormat.FormatString = "n2";
            this.colTM.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTM.FieldName = "TotalCash";
            this.colTM.Name = "colTM";
            this.colTM.OptionsColumn.AllowEdit = false;
            this.colTM.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalCash", "{0:n0}")});
            this.colTM.Visible = true;
            this.colTM.Width = 95;
            // 
            // colCK
            // 
            this.colCK.AppearanceCell.Options.UseTextOptions = true;
            this.colCK.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCK.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colCK.AppearanceHeader.Options.UseFont = true;
            this.colCK.AppearanceHeader.Options.UseTextOptions = true;
            this.colCK.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCK.Caption = "CK";
            this.colCK.DisplayFormat.FormatString = "n2";
            this.colCK.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCK.FieldName = "TotalCK";
            this.colCK.Name = "colCK";
            this.colCK.OptionsColumn.AllowEdit = false;
            this.colCK.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalCK", "{0:n0}")});
            this.colCK.Visible = true;
            this.colCK.Width = 97;
            // 
            // gridBand3
            // 
            this.gridBand3.Columns.Add(this.colIsPaid);
            this.gridBand3.Columns.Add(this.colIsApproved);
            this.gridBand3.Columns.Add(this.colContentCheck);
            this.gridBand3.Columns.Add(this.colNote);
            this.gridBand3.Columns.Add(this.colUserName);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.Width = 497;
            // 
            // colIsPaid
            // 
            this.colIsPaid.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colIsPaid.AppearanceHeader.Options.UseFont = true;
            this.colIsPaid.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsPaid.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsPaid.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colIsPaid.Caption = "Đã thanh toán";
            this.colIsPaid.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colIsPaid.FieldName = "IsPaid";
            this.colIsPaid.Name = "colIsPaid";
            this.colIsPaid.OptionsColumn.AllowEdit = false;
            this.colIsPaid.Visible = true;
            // 
            // colIsApproved
            // 
            this.colIsApproved.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colIsApproved.AppearanceHeader.Options.UseFont = true;
            this.colIsApproved.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsApproved.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsApproved.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colIsApproved.Caption = "Đã duyệt";
            this.colIsApproved.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colIsApproved.FieldName = "IsApproved";
            this.colIsApproved.Name = "colIsApproved";
            this.colIsApproved.OptionsColumn.AllowEdit = false;
            this.colIsApproved.Visible = true;
            this.colIsApproved.Width = 47;
            // 
            // colContentCheck
            // 
            this.colContentCheck.AppearanceCell.Options.UseTextOptions = true;
            this.colContentCheck.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colContentCheck.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colContentCheck.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colContentCheck.AppearanceHeader.Options.UseFont = true;
            this.colContentCheck.AppearanceHeader.Options.UseTextOptions = true;
            this.colContentCheck.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colContentCheck.Caption = "Kiểm tra";
            this.colContentCheck.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colContentCheck.FieldName = "ContentCheck";
            this.colContentCheck.Name = "colContentCheck";
            this.colContentCheck.OptionsColumn.AllowEdit = false;
            this.colContentCheck.Visible = true;
            this.colContentCheck.Width = 91;
            // 
            // colNote
            // 
            this.colNote.AppearanceCell.Options.UseTextOptions = true;
            this.colNote.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colNote.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNote.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colNote.AppearanceHeader.Options.UseFont = true;
            this.colNote.AppearanceHeader.Options.UseTextOptions = true;
            this.colNote.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNote.Caption = "Ghi chú";
            this.colNote.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colNote.FieldName = "Note";
            this.colNote.Name = "colNote";
            this.colNote.OptionsColumn.AllowEdit = false;
            this.colNote.Visible = true;
            this.colNote.Width = 164;
            // 
            // colUserName
            // 
            this.colUserName.AppearanceCell.Options.UseTextOptions = true;
            this.colUserName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colUserName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colUserName.AppearanceHeader.Options.UseFont = true;
            this.colUserName.AppearanceHeader.Options.UseTextOptions = true;
            this.colUserName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUserName.Caption = "Người phụ trách";
            this.colUserName.FieldName = "UserName";
            this.colUserName.Name = "colUserName";
            this.colUserName.OptionsColumn.AllowEdit = false;
            this.colUserName.Visible = true;
            this.colUserName.Width = 120;
            // 
            // colDeliveryCost
            // 
            this.colDeliveryCost.Caption = "DeliveryCost";
            this.colDeliveryCost.FieldName = "DeliveryCost";
            this.colDeliveryCost.Name = "colDeliveryCost";
            this.colDeliveryCost.OptionsColumn.AllowEdit = false;
            // 
            // colDiffCost
            // 
            this.colDiffCost.Caption = "DiffCost";
            this.colDiffCost.FieldName = "DiffCost";
            this.colDiffCost.Name = "colDiffCost";
            this.colDiffCost.OptionsColumn.AllowEdit = false;
            // 
            // colTotalTH
            // 
            this.colTotalTH.Caption = "TotalTH";
            this.colTotalTH.FieldName = "TotalTH";
            this.colTotalTH.Name = "colTotalTH";
            this.colTotalTH.OptionsColumn.AllowEdit = false;
            // 
            // repositoryItemGridLookUpEdit1
            // 
            this.repositoryItemGridLookUpEdit1.AutoHeight = false;
            this.repositoryItemGridLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit1.Name = "repositoryItemGridLookUpEdit1";
            this.repositoryItemGridLookUpEdit1.NullText = "";
            this.repositoryItemGridLookUpEdit1.View = this.gridView1;
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // frmReportNotPay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 485);
            this.Controls.Add(this.grdData);
            this.Controls.Add(this.mnuMenu);
            this.Name = "frmReportNotPay";
            this.Text = "BÁO CÁO VỤ VIỆC CHƯA THANH TOÁN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReportNotPay_Load);
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip mnuMenu;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView grvData;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colID;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colContent;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTarget;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colIsTM;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colPercentPay;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTotal;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTM;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCK;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colIsPaid;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colIsApproved;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colContentCheck;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colNote;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colUserName;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colDeliveryCost;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colDiffCost;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTotalTH;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colNumber;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCheck;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand Sốtiền;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
    }
}