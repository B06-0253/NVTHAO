namespace BMS
{
    partial class frmCCost
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCCost));
            this.mnuMenu = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSaveAndClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cboCostType = new System.Windows.Forms.ComboBox();
            this.chkIsProfit = new System.Windows.Forms.CheckBox();
            this.chkIsWithProject = new System.Windows.Forms.CheckBox();
            this.txtNote = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.leParentCat = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtPercentProfit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtUnit = new DevExpress.XtraEditors.TextEdit();
            this.txtPrice = new DevExpress.XtraEditors.TextEdit();
            this.grdLink = new DevExpress.XtraGrid.GridControl();
            this.grvLink = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValuePercentKD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colPersonNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVtuPercent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumberDay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsFix = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.chkIsDeliveryTime = new System.Windows.Forms.CheckBox();
            this.chkIsDirectCost = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gb1 = new System.Windows.Forms.GroupBox();
            this.gbIsSP = new System.Windows.Forms.GroupBox();
            this.rdoCPSX = new System.Windows.Forms.RadioButton();
            this.rdoIsDirectCost = new System.Windows.Forms.RadioButton();
            this.rdoIsWithProject = new System.Windows.Forms.RadioButton();
            this.rdoSP = new System.Windows.Forms.RadioButton();
            this.colValuePercentSX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mnuMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leParentCat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPercentProfit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gb1.SuspendLayout();
            this.gbIsSP.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMenu
            // 
            this.mnuMenu.AutoSize = false;
            this.mnuMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.mnuMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.toolStripSeparator3,
            this.btnSaveAndClose,
            this.toolStripSeparator1});
            this.mnuMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuMenu.Size = new System.Drawing.Size(1166, 41);
            this.mnuMenu.TabIndex = 1;
            this.mnuMenu.Text = "toolStrip2";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(29, 33);
            this.btnSave.Tag = "frmCCost_Save";
            this.btnSave.Text = "Ghi";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.AutoSize = false;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 40);
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAndClose.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveAndClose.Image")));
            this.btnSaveAndClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(77, 33);
            this.btnSaveAndClose.Tag = "frmCCost_Save";
            this.btnSaveAndClose.Text = "Ghi && Thoát";
            this.btnSaveAndClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // cboCostType
            // 
            this.cboCostType.FormattingEnabled = true;
            this.cboCostType.Items.AddRange(new object[] {
            "THU",
            "PHÂN BỔ"});
            this.cboCostType.Location = new System.Drawing.Point(78, 484);
            this.cboCostType.Name = "cboCostType";
            this.cboCostType.Size = new System.Drawing.Size(121, 21);
            this.cboCostType.TabIndex = 179;
            this.cboCostType.Visible = false;
            // 
            // chkIsProfit
            // 
            this.chkIsProfit.AutoSize = true;
            this.chkIsProfit.Location = new System.Drawing.Point(216, 465);
            this.chkIsProfit.Name = "chkIsProfit";
            this.chkIsProfit.Size = new System.Drawing.Size(121, 17);
            this.chkIsProfit.TabIndex = 170;
            this.chkIsProfit.Text = "Chi phí có lợi nhuận";
            this.chkIsProfit.UseVisualStyleBackColor = true;
            this.chkIsProfit.Visible = false;
            // 
            // chkIsWithProject
            // 
            this.chkIsWithProject.AutoSize = true;
            this.chkIsWithProject.Location = new System.Drawing.Point(21, 365);
            this.chkIsWithProject.Name = "chkIsWithProject";
            this.chkIsWithProject.Size = new System.Drawing.Size(176, 17);
            this.chkIsWithProject.TabIndex = 168;
            this.chkIsWithProject.Text = "Chi phí theo báo giá/ hợp đồng";
            this.chkIsWithProject.UseVisualStyleBackColor = true;
            this.chkIsWithProject.Visible = false;
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(78, 439);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(318, 17);
            this.txtNote.TabIndex = 177;
            this.txtNote.Visible = false;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(32, 441);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(35, 13);
            this.labelControl6.TabIndex = 173;
            this.labelControl6.Text = "Ghi chú";
            this.labelControl6.Visible = false;
            // 
            // leParentCat
            // 
            this.leParentCat.Location = new System.Drawing.Point(249, 85);
            this.leParentCat.Name = "leParentCat";
            this.leParentCat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.leParentCat.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", 50, "Mã"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", 200, "Tên")});
            this.leParentCat.Properties.NullText = "";
            this.leParentCat.Size = new System.Drawing.Size(147, 20);
            this.leParentCat.TabIndex = 156;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(216, 88);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(27, 13);
            this.labelControl3.TabIndex = 167;
            this.labelControl3.Text = "Nhóm";
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(15, 487);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(52, 13);
            this.labelControl12.TabIndex = 160;
            this.labelControl12.Text = "Loại chi phí";
            this.labelControl12.Visible = false;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(45, 85);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(154, 20);
            this.txtCode.TabIndex = 155;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(24, 88);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(14, 13);
            this.labelControl1.TabIndex = 157;
            this.labelControl1.Text = "Mã";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(45, 120);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(351, 20);
            this.txtName.TabIndex = 164;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(20, 123);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(18, 13);
            this.labelControl2.TabIndex = 165;
            this.labelControl2.Text = "Tên";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(10, 465);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(57, 13);
            this.labelControl4.TabIndex = 157;
            this.labelControl4.Text = "% lợi nhuận";
            this.labelControl4.Visible = false;
            // 
            // txtPercentProfit
            // 
            this.txtPercentProfit.Location = new System.Drawing.Point(78, 462);
            this.txtPercentProfit.Name = "txtPercentProfit";
            this.txtPercentProfit.Properties.DisplayFormat.FormatString = "n0";
            this.txtPercentProfit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPercentProfit.Properties.EditFormat.FormatString = "n0";
            this.txtPercentProfit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPercentProfit.Properties.Mask.EditMask = "n0";
            this.txtPercentProfit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPercentProfit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtPercentProfit.Size = new System.Drawing.Size(121, 20);
            this.txtPercentProfit.TabIndex = 155;
            this.txtPercentProfit.Visible = false;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(215, 161);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(28, 13);
            this.labelControl5.TabIndex = 157;
            this.labelControl5.Text = "Giá trị";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(7, 161);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(31, 13);
            this.labelControl7.TabIndex = 157;
            this.labelControl7.Text = "Đơn vị";
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(45, 158);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(154, 20);
            this.txtUnit.TabIndex = 155;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(249, 158);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Properties.DisplayFormat.FormatString = "n0";
            this.txtPrice.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPrice.Properties.EditFormat.FormatString = "n0";
            this.txtPrice.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPrice.Properties.Mask.EditMask = "n0";
            this.txtPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPrice.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtPrice.Size = new System.Drawing.Size(147, 20);
            this.txtPrice.TabIndex = 155;
            // 
            // grdLink
            // 
            this.grdLink.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdLink.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdLink.Location = new System.Drawing.Point(419, 44);
            this.grdLink.MainView = this.grvLink;
            this.grdLink.Name = "grdLink";
            this.grdLink.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1,
            this.repositoryItemTextEdit1,
            this.repositoryItemCheckEdit1});
            this.grdLink.Size = new System.Drawing.Size(747, 462);
            this.grdLink.TabIndex = 185;
            this.grdLink.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvLink});
            // 
            // grvLink
            // 
            this.grvLink.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvLink.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvLink.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvLink.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvLink.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvLink.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grvLink.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvLink.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvLink.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvLink.ColumnPanelRowHeight = 40;
            this.grvLink.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colCode,
            this.colName,
            this.colValuePercentKD,
            this.colPersonNumber,
            this.colVtuPercent,
            this.colNumberDay,
            this.colIsFix,
            this.colValuePercentSX});
            this.grvLink.GridControl = this.grdLink;
            this.grvLink.Name = "grvLink";
            this.grvLink.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvLink.OptionsCustomization.AllowRowSizing = true;
            this.grvLink.OptionsView.AllowHtmlDrawHeaders = true;
            this.grvLink.OptionsView.ColumnAutoWidth = false;
            this.grvLink.OptionsView.RowAutoHeight = true;
            this.grvLink.OptionsView.ShowFooter = true;
            this.grvLink.OptionsView.ShowGroupPanel = false;
            // 
            // colID
            // 
            this.colID.AppearanceCell.Options.UseTextOptions = true;
            this.colID.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colCode
            // 
            this.colCode.AppearanceCell.Options.UseTextOptions = true;
            this.colCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCode.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCode.AppearanceHeader.Options.UseFont = true;
            this.colCode.Caption = "Nhóm sản phẩm";
            this.colCode.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.OptionsColumn.AllowEdit = false;
            this.colCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            this.colCode.Width = 78;
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
            this.colName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colName.AppearanceHeader.Options.UseFont = true;
            this.colName.Caption = "Tên";
            this.colName.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 228;
            // 
            // colValuePercentKD
            // 
            this.colValuePercentKD.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colValuePercentKD.AppearanceHeader.Options.UseFont = true;
            this.colValuePercentKD.AppearanceHeader.Options.UseTextOptions = true;
            this.colValuePercentKD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colValuePercentKD.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colValuePercentKD.Caption = "Tỉ lệ % KD";
            this.colValuePercentKD.ColumnEdit = this.repositoryItemTextEdit1;
            this.colValuePercentKD.DisplayFormat.FormatString = "n2";
            this.colValuePercentKD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colValuePercentKD.FieldName = "ValuePercentKD";
            this.colValuePercentKD.Name = "colValuePercentKD";
            this.colValuePercentKD.Visible = true;
            this.colValuePercentKD.VisibleIndex = 2;
            this.colValuePercentKD.Width = 66;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.DisplayFormat.FormatString = "n4";
            this.repositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit1.EditFormat.FormatString = "n4";
            this.repositoryItemTextEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit1.Mask.EditMask = "n4";
            this.repositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTextEdit1.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            this.repositoryItemTextEdit1.Spin += new DevExpress.XtraEditors.Controls.SpinEventHandler(this.repositoryItemTextEdit1_Spin);
            // 
            // colPersonNumber
            // 
            this.colPersonNumber.AppearanceCell.Options.UseTextOptions = true;
            this.colPersonNumber.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPersonNumber.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colPersonNumber.AppearanceHeader.Options.UseFont = true;
            this.colPersonNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.colPersonNumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPersonNumber.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPersonNumber.Caption = "Số người";
            this.colPersonNumber.ColumnEdit = this.repositoryItemTextEdit1;
            this.colPersonNumber.FieldName = "PersonNumber";
            this.colPersonNumber.Name = "colPersonNumber";
            this.colPersonNumber.Visible = true;
            this.colPersonNumber.VisibleIndex = 5;
            // 
            // colVtuPercent
            // 
            this.colVtuPercent.AppearanceCell.Options.UseTextOptions = true;
            this.colVtuPercent.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colVtuPercent.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colVtuPercent.AppearanceHeader.Options.UseFont = true;
            this.colVtuPercent.AppearanceHeader.Options.UseTextOptions = true;
            this.colVtuPercent.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVtuPercent.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colVtuPercent.Caption = "% VTU";
            this.colVtuPercent.ColumnEdit = this.repositoryItemTextEdit1;
            this.colVtuPercent.FieldName = "VtuPercent";
            this.colVtuPercent.Name = "colVtuPercent";
            this.colVtuPercent.Visible = true;
            this.colVtuPercent.VisibleIndex = 4;
            // 
            // colNumberDay
            // 
            this.colNumberDay.AppearanceCell.Options.UseTextOptions = true;
            this.colNumberDay.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colNumberDay.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colNumberDay.AppearanceHeader.Options.UseFont = true;
            this.colNumberDay.AppearanceHeader.Options.UseTextOptions = true;
            this.colNumberDay.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNumberDay.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNumberDay.Caption = "Số ngày";
            this.colNumberDay.ColumnEdit = this.repositoryItemTextEdit1;
            this.colNumberDay.FieldName = "NumberDay";
            this.colNumberDay.Name = "colNumberDay";
            this.colNumberDay.Visible = true;
            this.colNumberDay.VisibleIndex = 6;
            // 
            // colIsFix
            // 
            this.colIsFix.AppearanceCell.Options.UseTextOptions = true;
            this.colIsFix.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colIsFix.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colIsFix.AppearanceHeader.Options.UseFont = true;
            this.colIsFix.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsFix.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsFix.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colIsFix.Caption = "Cố định";
            this.colIsFix.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colIsFix.FieldName = "IsFix";
            this.colIsFix.Name = "colIsFix";
            this.colIsFix.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
            this.colIsFix.Visible = true;
            this.colIsFix.VisibleIndex = 7;
            this.colIsFix.Width = 54;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // chkIsDeliveryTime
            // 
            this.chkIsDeliveryTime.AutoSize = true;
            this.chkIsDeliveryTime.Location = new System.Drawing.Point(22, 24);
            this.chkIsDeliveryTime.Name = "chkIsDeliveryTime";
            this.chkIsDeliveryTime.Size = new System.Drawing.Size(135, 30);
            this.chkIsDeliveryTime.TabIndex = 170;
            this.chkIsDeliveryTime.Text = "Chi phí phụ thuộc vào \r\nthời gian giao hàng";
            this.chkIsDeliveryTime.UseVisualStyleBackColor = true;
            // 
            // chkIsDirectCost
            // 
            this.chkIsDirectCost.AutoSize = true;
            this.chkIsDirectCost.Location = new System.Drawing.Point(21, 388);
            this.chkIsDirectCost.Name = "chkIsDirectCost";
            this.chkIsDirectCost.Size = new System.Drawing.Size(155, 17);
            this.chkIsDirectCost.TabIndex = 170;
            this.chkIsDirectCost.Text = "Chi phí nhân công trực tiếp";
            this.chkIsDirectCost.UseVisualStyleBackColor = true;
            this.chkIsDirectCost.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gb1);
            this.groupBox1.Controls.Add(this.gbIsSP);
            this.groupBox1.Controls.Add(this.rdoIsWithProject);
            this.groupBox1.Controls.Add(this.rdoSP);
            this.groupBox1.Location = new System.Drawing.Point(15, 198);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 147);
            this.groupBox1.TabIndex = 186;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Loại chi phí";
            // 
            // gb1
            // 
            this.gb1.Controls.Add(this.chkIsDeliveryTime);
            this.gb1.Location = new System.Drawing.Point(189, 57);
            this.gb1.Name = "gb1";
            this.gb1.Size = new System.Drawing.Size(177, 75);
            this.gb1.TabIndex = 171;
            this.gb1.TabStop = false;
            // 
            // gbIsSP
            // 
            this.gbIsSP.Controls.Add(this.rdoCPSX);
            this.gbIsSP.Controls.Add(this.rdoIsDirectCost);
            this.gbIsSP.Location = new System.Drawing.Point(6, 57);
            this.gbIsSP.Name = "gbIsSP";
            this.gbIsSP.Size = new System.Drawing.Size(160, 75);
            this.gbIsSP.TabIndex = 171;
            this.gbIsSP.TabStop = false;
            // 
            // rdoCPSX
            // 
            this.rdoCPSX.AutoSize = true;
            this.rdoCPSX.Location = new System.Drawing.Point(6, 21);
            this.rdoCPSX.Name = "rdoCPSX";
            this.rdoCPSX.Size = new System.Drawing.Size(149, 17);
            this.rdoCPSX.TabIndex = 0;
            this.rdoCPSX.TabStop = true;
            this.rdoCPSX.Text = "Phân bổ theo CP sản xuất";
            this.rdoCPSX.UseVisualStyleBackColor = true;
            this.rdoCPSX.CheckedChanged += new System.EventHandler(this.rdoCPSX_CheckedChanged);
            // 
            // rdoIsDirectCost
            // 
            this.rdoIsDirectCost.AutoSize = true;
            this.rdoIsDirectCost.Location = new System.Drawing.Point(6, 44);
            this.rdoIsDirectCost.Name = "rdoIsDirectCost";
            this.rdoIsDirectCost.Size = new System.Drawing.Size(143, 17);
            this.rdoIsDirectCost.TabIndex = 0;
            this.rdoIsDirectCost.TabStop = true;
            this.rdoIsDirectCost.Text = "Phân bổ theo nhân công";
            this.rdoIsDirectCost.UseVisualStyleBackColor = true;
            this.rdoIsDirectCost.CheckedChanged += new System.EventHandler(this.rdoIsDirectCost_CheckedChanged);
            // 
            // rdoIsWithProject
            // 
            this.rdoIsWithProject.AutoSize = true;
            this.rdoIsWithProject.Location = new System.Drawing.Point(34, 27);
            this.rdoIsWithProject.Name = "rdoIsWithProject";
            this.rdoIsWithProject.Size = new System.Drawing.Size(132, 17);
            this.rdoIsWithProject.TabIndex = 0;
            this.rdoIsWithProject.Text = "Chi phí theo hợp đồng";
            this.rdoIsWithProject.UseVisualStyleBackColor = true;
            this.rdoIsWithProject.CheckedChanged += new System.EventHandler(this.rdoIsWithProject_CheckedChanged);
            // 
            // rdoSP
            // 
            this.rdoSP.AutoSize = true;
            this.rdoSP.Location = new System.Drawing.Point(202, 27);
            this.rdoSP.Name = "rdoSP";
            this.rdoSP.Size = new System.Drawing.Size(132, 17);
            this.rdoSP.TabIndex = 0;
            this.rdoSP.Text = "Chi phí theo sản phẩm";
            this.rdoSP.UseVisualStyleBackColor = true;
            this.rdoSP.CheckedChanged += new System.EventHandler(this.rdoSP_CheckedChanged);
            // 
            // colValuePercentSX
            // 
            this.colValuePercentSX.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colValuePercentSX.AppearanceHeader.Options.UseFont = true;
            this.colValuePercentSX.AppearanceHeader.Options.UseTextOptions = true;
            this.colValuePercentSX.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colValuePercentSX.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colValuePercentSX.Caption = "Tỉ lệ % SX";
            this.colValuePercentSX.ColumnEdit = this.repositoryItemTextEdit1;
            this.colValuePercentSX.FieldName = "ValuePercentSX";
            this.colValuePercentSX.Name = "colValuePercentSX";
            this.colValuePercentSX.Visible = true;
            this.colValuePercentSX.VisibleIndex = 3;
            // 
            // frmCCost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 508);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grdLink);
            this.Controls.Add(this.cboCostType);
            this.Controls.Add(this.chkIsDirectCost);
            this.Controls.Add(this.chkIsProfit);
            this.Controls.Add(this.chkIsWithProject);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.leParentCat);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtPercentProfit);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.mnuMenu);
            this.Name = "frmCCost";
            this.Text = "DANH SÁCH CHI PHÍ";
            this.Load += new System.EventHandler(this.frmCost_Load);
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leParentCat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPercentProfit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb1.ResumeLayout(false);
            this.gb1.PerformLayout();
            this.gbIsSP.ResumeLayout(false);
            this.gbIsSP.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip mnuMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnSaveAndClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ComboBox cboCostType;
        private System.Windows.Forms.CheckBox chkIsProfit;
        private System.Windows.Forms.CheckBox chkIsWithProject;
        private DevExpress.XtraEditors.MemoEdit txtNote;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LookUpEdit leParentCat;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.ToolStripButton btnSave;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtPercentProfit;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtUnit;
        private DevExpress.XtraEditors.TextEdit txtPrice;
        private DevExpress.XtraGrid.GridControl grdLink;
        private DevExpress.XtraGrid.Views.Grid.GridView grvLink;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colValuePercentKD;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private System.Windows.Forms.CheckBox chkIsDeliveryTime;
        private System.Windows.Forms.CheckBox chkIsDirectCost;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colVtuPercent;
        private DevExpress.XtraGrid.Columns.GridColumn colNumberDay;
        private DevExpress.XtraGrid.Columns.GridColumn colIsFix;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoIsWithProject;
        private System.Windows.Forms.RadioButton rdoSP;
        private System.Windows.Forms.GroupBox gbIsSP;
        private System.Windows.Forms.RadioButton rdoCPSX;
        private System.Windows.Forms.RadioButton rdoIsDirectCost;
        private System.Windows.Forms.GroupBox gb1;
        private DevExpress.XtraGrid.Columns.GridColumn colValuePercentSX;
    }
}