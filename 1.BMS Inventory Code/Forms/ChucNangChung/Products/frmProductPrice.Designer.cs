namespace BMS
{
    partial class frmProductPrice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductPrice));
            this.mnuMenu = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSaveAndClose = new System.Windows.Forms.ToolStripButton();
            this.cboCostGroup = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.grvCostGroup = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPercentTrade = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPercentUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblVAT = new System.Windows.Forms.Label();
            this.lblUserPercent = new System.Windows.Forms.Label();
            this.lblTradePercent = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtVAT = new DevExpress.XtraEditors.TextEdit();
            this.txtUserPrice = new DevExpress.XtraEditors.TextEdit();
            this.txtTradePrice = new DevExpress.XtraEditors.TextEdit();
            this.txtRealPrice = new DevExpress.XtraEditors.TextEdit();
            this.txtPrice = new DevExpress.XtraEditors.TextEdit();
            this.grdCost = new DevExpress.XtraGrid.GridControl();
            this.grvCost = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCostLinkID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCostName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colCostDetailID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCostGroupID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPercent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.grdModule = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xemChiTiếtGiáModuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grvModule = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colMName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaiThucHanh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPriceType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.mnuMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCostGroup.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCostGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVAT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTradePrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRealPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdModule)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvModule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
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
            this.btnSaveAndClose});
            this.mnuMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuMenu.Size = new System.Drawing.Size(923, 42);
            this.mnuMenu.TabIndex = 195;
            this.mnuMenu.Text = "toolStrip2";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(29, 33);
            this.btnSave.Tag = "frmProduct_Save";
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
            this.btnSaveAndClose.Tag = "frmProduct_Save";
            this.btnSaveAndClose.Text = "Ghi && Thoát";
            this.btnSaveAndClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // cboCostGroup
            // 
            this.cboCostGroup.Location = new System.Drawing.Point(69, 141);
            this.cboCostGroup.Name = "cboCostGroup";
            this.cboCostGroup.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCostGroup.Properties.NullText = "";
            this.cboCostGroup.Properties.View = this.grvCostGroup;
            this.cboCostGroup.Size = new System.Drawing.Size(350, 20);
            this.cboCostGroup.TabIndex = 224;
            this.cboCostGroup.EditValueChanged += new System.EventHandler(this.cboCostGroup_EditValueChanged);
            // 
            // grvCostGroup
            // 
            this.grvCostGroup.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvCostGroup.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvCostGroup.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvCostGroup.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.grvCostGroup.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvCostGroup.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvCostGroup.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCostGroup.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvCostGroup.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvCostGroup.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvCostGroup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colName,
            this.colPercentTrade,
            this.colPercentUser,
            this.colVAT,
            this.colCode});
            this.grvCostGroup.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCostGroup.Name = "grvCostGroup";
            this.grvCostGroup.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCostGroup.OptionsView.ShowGroupPanel = false;
            // 
            // colID
            // 
            this.colID.Caption = "gridColumn1";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colName
            // 
            this.colName.Caption = "Tên";
            this.colName.FieldName = "Name1";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            // 
            // colPercentTrade
            // 
            this.colPercentTrade.Caption = "gridColumn3";
            this.colPercentTrade.FieldName = "PercentTrade";
            this.colPercentTrade.Name = "colPercentTrade";
            // 
            // colPercentUser
            // 
            this.colPercentUser.Caption = "gridColumn4";
            this.colPercentUser.FieldName = "PercentUser";
            this.colPercentUser.Name = "colPercentUser";
            // 
            // colVAT
            // 
            this.colVAT.Caption = "VAT";
            this.colVAT.FieldName = "VAT";
            this.colVAT.Name = "colVAT";
            // 
            // colCode
            // 
            this.colCode.Caption = "Mã";
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            // 
            // lblVAT
            // 
            this.lblVAT.AutoSize = true;
            this.lblVAT.Location = new System.Drawing.Point(382, 109);
            this.lblVAT.Name = "lblVAT";
            this.lblVAT.Size = new System.Drawing.Size(21, 13);
            this.lblVAT.TabIndex = 221;
            this.lblVAT.Text = "0%";
            this.lblVAT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUserPercent
            // 
            this.lblUserPercent.AutoSize = true;
            this.lblUserPercent.Location = new System.Drawing.Point(382, 83);
            this.lblUserPercent.Name = "lblUserPercent";
            this.lblUserPercent.Size = new System.Drawing.Size(21, 13);
            this.lblUserPercent.TabIndex = 222;
            this.lblUserPercent.Text = "0%";
            this.lblUserPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTradePercent
            // 
            this.lblTradePercent.AutoSize = true;
            this.lblTradePercent.Location = new System.Drawing.Point(382, 56);
            this.lblTradePercent.Name = "lblTradePercent";
            this.lblTradePercent.Size = new System.Drawing.Size(21, 13);
            this.lblTradePercent.TabIndex = 223;
            this.lblTradePercent.Text = "0%";
            this.lblTradePercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(255, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 218;
            this.label5.Text = "VAT";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(216, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 219;
            this.label4.Text = "Giá NSDụng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(205, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 220;
            this.label3.Text = "Giá thương mại";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 217;
            this.label2.Text = "Giá SX";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 216;
            this.label1.Text = "Giá gốc";
            // 
            // txtVAT
            // 
            this.txtVAT.Location = new System.Drawing.Point(286, 105);
            this.txtVAT.Name = "txtVAT";
            this.txtVAT.Properties.DisplayFormat.FormatString = "n2";
            this.txtVAT.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtVAT.Properties.Mask.EditMask = "n2";
            this.txtVAT.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtVAT.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtVAT.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtVAT.Size = new System.Drawing.Size(93, 20);
            this.txtVAT.TabIndex = 212;
            // 
            // txtUserPrice
            // 
            this.txtUserPrice.Location = new System.Drawing.Point(286, 79);
            this.txtUserPrice.Name = "txtUserPrice";
            this.txtUserPrice.Properties.DisplayFormat.FormatString = "n2";
            this.txtUserPrice.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtUserPrice.Properties.Mask.EditMask = "n2";
            this.txtUserPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtUserPrice.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtUserPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtUserPrice.Size = new System.Drawing.Size(93, 20);
            this.txtUserPrice.TabIndex = 211;
            // 
            // txtTradePrice
            // 
            this.txtTradePrice.Location = new System.Drawing.Point(286, 53);
            this.txtTradePrice.Name = "txtTradePrice";
            this.txtTradePrice.Properties.DisplayFormat.FormatString = "n2";
            this.txtTradePrice.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTradePrice.Properties.Mask.EditMask = "n2";
            this.txtTradePrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTradePrice.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTradePrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTradePrice.Size = new System.Drawing.Size(93, 20);
            this.txtTradePrice.TabIndex = 213;
            // 
            // txtRealPrice
            // 
            this.txtRealPrice.Location = new System.Drawing.Point(55, 105);
            this.txtRealPrice.Name = "txtRealPrice";
            this.txtRealPrice.Properties.DisplayFormat.FormatString = "n2";
            this.txtRealPrice.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtRealPrice.Properties.Mask.EditMask = "n2";
            this.txtRealPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtRealPrice.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtRealPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtRealPrice.Size = new System.Drawing.Size(105, 20);
            this.txtRealPrice.TabIndex = 215;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(55, 79);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Properties.DisplayFormat.FormatString = "{0:n2}";
            this.txtPrice.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPrice.Properties.Mask.EditMask = "n2";
            this.txtPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPrice.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPrice.Size = new System.Drawing.Size(105, 20);
            this.txtPrice.TabIndex = 214;
            this.txtPrice.EditValueChanged += new System.EventHandler(this.txtPrice_EditValueChanged);
            // 
            // grdCost
            // 
            this.grdCost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdCost.Location = new System.Drawing.Point(3, 171);
            this.grdCost.MainView = this.grvCost;
            this.grdCost.Name = "grdCost";
            this.grdCost.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit3});
            this.grdCost.Size = new System.Drawing.Size(416, 273);
            this.grdCost.TabIndex = 210;
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
            this.colCostLinkID,
            this.colCostName,
            this.colCostDetailID,
            this.colCostGroupID,
            this.colPercent,
            this.colTotal});
            this.grvCost.GridControl = this.grdCost;
            this.grvCost.Name = "grvCost";
            this.grvCost.OptionsView.RowAutoHeight = true;
            this.grvCost.OptionsView.ShowFooter = true;
            this.grvCost.OptionsView.ShowGroupPanel = false;
            // 
            // colCostLinkID
            // 
            this.colCostLinkID.Caption = "ID";
            this.colCostLinkID.FieldName = "ID";
            this.colCostLinkID.Name = "colCostLinkID";
            // 
            // colCostName
            // 
            this.colCostName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCostName.AppearanceHeader.Options.UseFont = true;
            this.colCostName.AppearanceHeader.Options.UseTextOptions = true;
            this.colCostName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCostName.Caption = "Chi phí";
            this.colCostName.ColumnEdit = this.repositoryItemMemoEdit3;
            this.colCostName.FieldName = "Name";
            this.colCostName.Name = "colCostName";
            this.colCostName.OptionsColumn.AllowEdit = false;
            this.colCostName.OptionsColumn.AllowFocus = false;
            this.colCostName.Visible = true;
            this.colCostName.VisibleIndex = 0;
            this.colCostName.Width = 171;
            // 
            // repositoryItemMemoEdit3
            // 
            this.repositoryItemMemoEdit3.Name = "repositoryItemMemoEdit3";
            // 
            // colCostDetailID
            // 
            this.colCostDetailID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCostDetailID.AppearanceHeader.Options.UseFont = true;
            this.colCostDetailID.AppearanceHeader.Options.UseTextOptions = true;
            this.colCostDetailID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCostDetailID.Caption = "CostDetailID";
            this.colCostDetailID.FieldName = "CostDetailID";
            this.colCostDetailID.Name = "colCostDetailID";
            this.colCostDetailID.Width = 70;
            // 
            // colCostGroupID
            // 
            this.colCostGroupID.Caption = "CostGroupID";
            this.colCostGroupID.FieldName = "CostGroupID";
            this.colCostGroupID.Name = "colCostGroupID";
            this.colCostGroupID.Width = 110;
            // 
            // colPercent
            // 
            this.colPercent.AppearanceCell.Options.UseTextOptions = true;
            this.colPercent.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colPercent.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colPercent.AppearanceHeader.Options.UseFont = true;
            this.colPercent.AppearanceHeader.Options.UseTextOptions = true;
            this.colPercent.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPercent.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPercent.Caption = "Phần trăm(%)";
            this.colPercent.FieldName = "CostPercent";
            this.colPercent.Name = "colPercent";
            this.colPercent.OptionsColumn.AllowEdit = false;
            this.colPercent.Visible = true;
            this.colPercent.VisibleIndex = 1;
            this.colPercent.Width = 59;
            // 
            // colTotal
            // 
            this.colTotal.AppearanceCell.Options.UseTextOptions = true;
            this.colTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colTotal.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTotal.AppearanceHeader.Options.UseFont = true;
            this.colTotal.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotal.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotal.Caption = "Thành tiền";
            this.colTotal.DisplayFormat.FormatString = "n2";
            this.colTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotal.FieldName = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.OptionsColumn.AllowEdit = false;
            this.colTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 2;
            this.colTotal.Width = 120;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(6, 144);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(60, 13);
            this.labelControl5.TabIndex = 209;
            this.labelControl5.Text = "Nhóm chi phí";
            // 
            // grdModule
            // 
            this.grdModule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdModule.ContextMenuStrip = this.contextMenuStrip1;
            this.grdModule.Location = new System.Drawing.Point(424, 45);
            this.grdModule.MainView = this.grvModule;
            this.grdModule.Name = "grdModule";
            this.grdModule.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit2});
            this.grdModule.Size = new System.Drawing.Size(498, 399);
            this.grdModule.TabIndex = 225;
            this.grdModule.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvModule});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xemChiTiếtGiáModuleToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(201, 26);
            // 
            // xemChiTiếtGiáModuleToolStripMenuItem
            // 
            this.xemChiTiếtGiáModuleToolStripMenuItem.Name = "xemChiTiếtGiáModuleToolStripMenuItem";
            this.xemChiTiếtGiáModuleToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.xemChiTiếtGiáModuleToolStripMenuItem.Text = "Xem chi tiết giá module";
            this.xemChiTiếtGiáModuleToolStripMenuItem.Click += new System.EventHandler(this.xemChiTiếtGiáModuleToolStripMenuItem_Click);
            // 
            // grvModule
            // 
            this.grvModule.ColumnPanelRowHeight = 40;
            this.grvModule.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMID,
            this.colMCode,
            this.colMName,
            this.colMQty,
            this.colBaiThucHanh,
            this.colPrice,
            this.colTotalPrice,
            this.colPriceType,
            this.colTypeName});
            this.grvModule.GridControl = this.grdModule;
            this.grvModule.GroupCount = 2;
            this.grvModule.Name = "grvModule";
            this.grvModule.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvModule.OptionsView.ColumnAutoWidth = false;
            this.grvModule.OptionsView.RowAutoHeight = true;
            this.grvModule.OptionsView.ShowFooter = true;
            this.grvModule.OptionsView.ShowGroupPanel = false;
            this.grvModule.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colBaiThucHanh, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colTypeName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvModule.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grvModule_CustomDrawCell);
            // 
            // colMID
            // 
            this.colMID.Caption = "ID";
            this.colMID.FieldName = "ID";
            this.colMID.Name = "colMID";
            // 
            // colMCode
            // 
            this.colMCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMCode.AppearanceHeader.Options.UseFont = true;
            this.colMCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colMCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMCode.Caption = "Mã";
            this.colMCode.ColumnEdit = this.repositoryItemMemoEdit2;
            this.colMCode.FieldName = "Code";
            this.colMCode.Name = "colMCode";
            this.colMCode.OptionsColumn.AllowEdit = false;
            this.colMCode.OptionsColumn.AllowFocus = false;
            this.colMCode.Visible = true;
            this.colMCode.VisibleIndex = 0;
            this.colMCode.Width = 102;
            // 
            // repositoryItemMemoEdit2
            // 
            this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
            // 
            // colMName
            // 
            this.colMName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMName.AppearanceHeader.Options.UseFont = true;
            this.colMName.AppearanceHeader.Options.UseTextOptions = true;
            this.colMName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMName.Caption = "Tên module";
            this.colMName.ColumnEdit = this.repositoryItemMemoEdit2;
            this.colMName.FieldName = "Name";
            this.colMName.Name = "colMName";
            this.colMName.OptionsColumn.AllowEdit = false;
            this.colMName.OptionsColumn.AllowFocus = false;
            this.colMName.Visible = true;
            this.colMName.VisibleIndex = 1;
            this.colMName.Width = 139;
            // 
            // colMQty
            // 
            this.colMQty.AppearanceCell.Options.UseTextOptions = true;
            this.colMQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colMQty.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMQty.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMQty.AppearanceHeader.Options.UseFont = true;
            this.colMQty.AppearanceHeader.Options.UseTextOptions = true;
            this.colMQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMQty.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colMQty.Caption = "Số lượng";
            this.colMQty.FieldName = "Qty";
            this.colMQty.Name = "colMQty";
            this.colMQty.OptionsColumn.AllowEdit = false;
            this.colMQty.OptionsColumn.AllowFocus = false;
            this.colMQty.Visible = true;
            this.colMQty.VisibleIndex = 2;
            this.colMQty.Width = 40;
            // 
            // colBaiThucHanh
            // 
            this.colBaiThucHanh.Caption = "Bài thực hành";
            this.colBaiThucHanh.FieldName = "BaiThucHanhName";
            this.colBaiThucHanh.Name = "colBaiThucHanh";
            // 
            // colPrice
            // 
            this.colPrice.AppearanceCell.Options.UseTextOptions = true;
            this.colPrice.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPrice.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colPrice.AppearanceHeader.Options.UseFont = true;
            this.colPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.colPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPrice.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPrice.Caption = "Đơn giá (VND)";
            this.colPrice.DisplayFormat.FormatString = "n0";
            this.colPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrice.FieldName = "Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.OptionsColumn.AllowEdit = false;
            this.colPrice.Visible = true;
            this.colPrice.VisibleIndex = 3;
            this.colPrice.Width = 93;
            // 
            // colTotalPrice
            // 
            this.colTotalPrice.AppearanceCell.Options.UseTextOptions = true;
            this.colTotalPrice.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTotalPrice.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTotalPrice.AppearanceHeader.Options.UseFont = true;
            this.colTotalPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotalPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotalPrice.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalPrice.Caption = "Tổng (VND)";
            this.colTotalPrice.DisplayFormat.FormatString = "n0";
            this.colTotalPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalPrice.FieldName = "TotalPrice";
            this.colTotalPrice.Name = "colTotalPrice";
            this.colTotalPrice.OptionsColumn.ReadOnly = true;
            this.colTotalPrice.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPrice", "{0:n0}")});
            this.colTotalPrice.Visible = true;
            this.colTotalPrice.VisibleIndex = 4;
            this.colTotalPrice.Width = 104;
            // 
            // colPriceType
            // 
            this.colPriceType.AppearanceCell.Options.UseTextOptions = true;
            this.colPriceType.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPriceType.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colPriceType.AppearanceHeader.Options.UseFont = true;
            this.colPriceType.AppearanceHeader.Options.UseTextOptions = true;
            this.colPriceType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPriceType.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPriceType.Caption = "PriceType";
            this.colPriceType.FieldName = "PriceType";
            this.colPriceType.Name = "colPriceType";
            // 
            // colTypeName
            // 
            this.colTypeName.Caption = "Loại";
            this.colTypeName.FieldName = "TypeName";
            this.colTypeName.Name = "colTypeName";
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(164, 83);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(29, 13);
            this.labelControl11.TabIndex = 226;
            this.labelControl11.Text = "(VNĐ)";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(164, 109);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(29, 13);
            this.labelControl1.TabIndex = 226;
            this.labelControl1.Text = "(VNĐ)";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(832, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 228;
            this.label6.Text = "Giá chưa đầy đủ";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.BackColor = System.Drawing.Color.Yellow;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Location = new System.Drawing.Point(793, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 15);
            this.label7.TabIndex = 227;
            // 
            // frmProductPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 446);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.grdModule);
            this.Controls.Add(this.cboCostGroup);
            this.Controls.Add(this.lblVAT);
            this.Controls.Add(this.lblUserPercent);
            this.Controls.Add(this.lblTradePercent);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtVAT);
            this.Controls.Add(this.txtUserPrice);
            this.Controls.Add(this.txtTradePrice);
            this.Controls.Add(this.txtRealPrice);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.grdCost);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.mnuMenu);
            this.Name = "frmProductPrice";
            this.Text = "Hiển thị giá sản phẩm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmProductPrice_Load);
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboCostGroup.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCostGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVAT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTradePrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRealPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdModule)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvModule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip mnuMenu;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnSaveAndClose;
        private DevExpress.XtraEditors.SearchLookUpEdit cboCostGroup;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCostGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colPercentTrade;
        private DevExpress.XtraGrid.Columns.GridColumn colPercentUser;
        private DevExpress.XtraGrid.Columns.GridColumn colVAT;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private System.Windows.Forms.Label lblVAT;
        private System.Windows.Forms.Label lblUserPercent;
        private System.Windows.Forms.Label lblTradePercent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtVAT;
        private DevExpress.XtraEditors.TextEdit txtUserPrice;
        private DevExpress.XtraEditors.TextEdit txtTradePrice;
        private DevExpress.XtraEditors.TextEdit txtRealPrice;
        private DevExpress.XtraEditors.TextEdit txtPrice;
        private DevExpress.XtraGrid.GridControl grdCost;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCost;
        private DevExpress.XtraGrid.Columns.GridColumn colCostLinkID;
        private DevExpress.XtraGrid.Columns.GridColumn colCostName;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit3;
        private DevExpress.XtraGrid.Columns.GridColumn colCostDetailID;
        private DevExpress.XtraGrid.Columns.GridColumn colCostGroupID;
        private DevExpress.XtraGrid.Columns.GridColumn colPercent;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraGrid.GridControl grdModule;
        private DevExpress.XtraGrid.Views.Grid.GridView grvModule;
        private DevExpress.XtraGrid.Columns.GridColumn colMID;
        private DevExpress.XtraGrid.Columns.GridColumn colMCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colMName;
        private DevExpress.XtraGrid.Columns.GridColumn colMQty;
        private DevExpress.XtraGrid.Columns.GridColumn colBaiThucHanh;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colPriceType;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xemChiTiếtGiáModuleToolStripMenuItem;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraGrid.Columns.GridColumn colTypeName;
    }
}