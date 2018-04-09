namespace BMS
{
    partial class frmCostGroupDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCostGroupDetail));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddCostDetail = new DevExpress.XtraEditors.SimpleButton();
            this.btnRemoveCostDetail = new DevExpress.XtraEditors.SimpleButton();
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.grvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colCostDetailID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCostGroupID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPercent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsFix = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.txtDividedRate = new DevExpress.XtraEditors.TextEdit();
            this.txtPercentVat = new DevExpress.XtraEditors.TextEdit();
            this.txtProfitTM = new DevExpress.XtraEditors.TextEdit();
            this.txtPercentUser = new DevExpress.XtraEditors.TextEdit();
            this.txtProfitSX = new DevExpress.XtraEditors.TextEdit();
            this.txtPercentTrade = new DevExpress.XtraEditors.TextEdit();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mnuMenu = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSaveAndClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnModuleHistory = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDividedRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPercentVat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProfitTM.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPercentUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProfitSX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPercentTrade.Properties)).BeginInit();
            this.mnuMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.groupBox1.Controls.Add(this.btnAddCostDetail);
            this.groupBox1.Controls.Add(this.btnRemoveCostDetail);
            this.groupBox1.Controls.Add(this.grdData);
            this.groupBox1.Controls.Add(this.txtDividedRate);
            this.groupBox1.Controls.Add(this.txtPercentVat);
            this.groupBox1.Controls.Add(this.txtProfitTM);
            this.groupBox1.Controls.Add(this.txtPercentUser);
            this.groupBox1.Controls.Add(this.txtProfitSX);
            this.groupBox1.Controls.Add(this.txtPercentTrade);
            this.groupBox1.Controls.Add(this.txtCode);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(2, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(783, 409);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // btnAddCostDetail
            // 
            this.btnAddCostDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddCostDetail.Location = new System.Drawing.Point(703, 13);
            this.btnAddCostDetail.Name = "btnAddCostDetail";
            this.btnAddCostDetail.Size = new System.Drawing.Size(75, 23);
            this.btnAddCostDetail.TabIndex = 27;
            this.btnAddCostDetail.Tag = "frmCostGroupDetail_AddCost";
            this.btnAddCostDetail.Text = "Thêm chi phí";
            this.btnAddCostDetail.Click += new System.EventHandler(this.btnAddCostDetail_Click);
            // 
            // btnRemoveCostDetail
            // 
            this.btnRemoveCostDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveCostDetail.Location = new System.Drawing.Point(622, 13);
            this.btnRemoveCostDetail.Name = "btnRemoveCostDetail";
            this.btnRemoveCostDetail.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveCostDetail.TabIndex = 27;
            this.btnRemoveCostDetail.Tag = "frmCostGroupDetail_RemoveCost";
            this.btnRemoveCostDetail.Text = "Xóa chi phí";
            this.btnRemoveCostDetail.Click += new System.EventHandler(this.btnRemoveCostDetail_Click);
            // 
            // grdData
            // 
            this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdData.Location = new System.Drawing.Point(356, 42);
            this.grdData.MainView = this.grvData;
            this.grdData.Name = "grdData";
            this.grdData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1,
            this.repositoryItemCheckEdit1});
            this.grdData.Size = new System.Drawing.Size(422, 361);
            this.grdData.TabIndex = 26;
            this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvData});
            // 
            // grvData
            // 
            this.grvData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colName,
            this.colCostDetailID,
            this.colCostGroupID,
            this.colPercent,
            this.colTypeName,
            this.colIsFix});
            this.grvData.GridControl = this.grdData;
            this.grvData.GroupCount = 1;
            this.grvData.Name = "grvData";
            this.grvData.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvData.OptionsView.ShowGroupPanel = false;
            this.grvData.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colTypeName, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colName
            // 
            this.colName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colName.AppearanceHeader.Options.UseFont = true;
            this.colName.AppearanceHeader.Options.UseTextOptions = true;
            this.colName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colName.Caption = "Chi phí";
            this.colName.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.OptionsColumn.AllowFocus = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 197;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
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
            this.colPercent.Caption = "Phần trăm(%)";
            this.colPercent.FieldName = "CostPercent";
            this.colPercent.Name = "colPercent";
            this.colPercent.Visible = true;
            this.colPercent.VisibleIndex = 1;
            this.colPercent.Width = 85;
            // 
            // colTypeName
            // 
            this.colTypeName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTypeName.AppearanceHeader.Options.UseFont = true;
            this.colTypeName.AppearanceHeader.Options.UseTextOptions = true;
            this.colTypeName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTypeName.Caption = "Loại chi phí";
            this.colTypeName.FieldName = "TypeName";
            this.colTypeName.Name = "colTypeName";
            this.colTypeName.Visible = true;
            this.colTypeName.VisibleIndex = 2;
            // 
            // colIsFix
            // 
            this.colIsFix.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colIsFix.AppearanceHeader.Options.UseFont = true;
            this.colIsFix.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsFix.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsFix.Caption = "CP cố định";
            this.colIsFix.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colIsFix.FieldName = "IsFix";
            this.colIsFix.Name = "colIsFix";
            this.colIsFix.Visible = true;
            this.colIsFix.VisibleIndex = 2;
            this.colIsFix.Width = 68;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // txtDividedRate
            // 
            this.txtDividedRate.Location = new System.Drawing.Point(139, 358);
            this.txtDividedRate.Name = "txtDividedRate";
            this.txtDividedRate.Properties.Mask.EditMask = "n0";
            this.txtDividedRate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDividedRate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDividedRate.Size = new System.Drawing.Size(102, 20);
            this.txtDividedRate.TabIndex = 2;
            // 
            // txtPercentVat
            // 
            this.txtPercentVat.Location = new System.Drawing.Point(139, 265);
            this.txtPercentVat.Name = "txtPercentVat";
            this.txtPercentVat.Properties.Mask.EditMask = "n0";
            this.txtPercentVat.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPercentVat.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPercentVat.Size = new System.Drawing.Size(102, 20);
            this.txtPercentVat.TabIndex = 2;
            // 
            // txtProfitTM
            // 
            this.txtProfitTM.Location = new System.Drawing.Point(139, 332);
            this.txtProfitTM.Name = "txtProfitTM";
            this.txtProfitTM.Properties.Mask.EditMask = "n0";
            this.txtProfitTM.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtProfitTM.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtProfitTM.Size = new System.Drawing.Size(102, 20);
            this.txtProfitTM.TabIndex = 2;
            // 
            // txtPercentUser
            // 
            this.txtPercentUser.Location = new System.Drawing.Point(139, 239);
            this.txtPercentUser.Name = "txtPercentUser";
            this.txtPercentUser.Properties.Mask.EditMask = "n0";
            this.txtPercentUser.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPercentUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPercentUser.Size = new System.Drawing.Size(102, 20);
            this.txtPercentUser.TabIndex = 2;
            // 
            // txtProfitSX
            // 
            this.txtProfitSX.Location = new System.Drawing.Point(139, 306);
            this.txtProfitSX.Name = "txtProfitSX";
            this.txtProfitSX.Properties.Mask.EditMask = "n0";
            this.txtProfitSX.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtProfitSX.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtProfitSX.Size = new System.Drawing.Size(102, 20);
            this.txtProfitSX.TabIndex = 2;
            // 
            // txtPercentTrade
            // 
            this.txtPercentTrade.Location = new System.Drawing.Point(139, 213);
            this.txtPercentTrade.Name = "txtPercentTrade";
            this.txtPercentTrade.Properties.Mask.EditMask = "n0";
            this.txtPercentTrade.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPercentTrade.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPercentTrade.Size = new System.Drawing.Size(102, 20);
            this.txtPercentTrade.TabIndex = 2;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(44, 42);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(127, 20);
            this.txtCode.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(247, 361);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "(%)";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(44, 146);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(306, 40);
            this.txtDescription.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(247, 336);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "(%)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(247, 268);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "(%)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(247, 309);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(21, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "(%)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(247, 243);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(21, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "(%)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(83, 361);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Tỉ lệ chia";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(247, 216);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "(%)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(105, 268);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "VAT";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(60, 336);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Lợi nhuận TM";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mô tả";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(66, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Giá NSDụng";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(62, 308);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Lợi nhuận SX";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(44, 81);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtName.Size = new System.Drawing.Size(306, 47);
            this.txtName.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Giá thương mại";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã";
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
            this.toolStripSeparator1,
            this.btnModuleHistory});
            this.mnuMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuMenu.Size = new System.Drawing.Size(788, 42);
            this.mnuMenu.TabIndex = 25;
            this.mnuMenu.Text = "toolStrip2";
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = false;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(55, 40);
            this.btnSave.Tag = "frmCostGroupDetail_Save";
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
            this.btnSaveAndClose.AutoSize = false;
            this.btnSaveAndClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAndClose.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveAndClose.Image")));
            this.btnSaveAndClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(77, 40);
            this.btnSaveAndClose.Tag = "frmCostGroupDetail_Save";
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
            // btnModuleHistory
            // 
            this.btnModuleHistory.AutoSize = false;
            this.btnModuleHistory.Image = ((System.Drawing.Image)(resources.GetObject("btnModuleHistory.Image")));
            this.btnModuleHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModuleHistory.Name = "btnModuleHistory";
            this.btnModuleHistory.Size = new System.Drawing.Size(55, 40);
            this.btnModuleHistory.Text = "Lịch sử";
            this.btnModuleHistory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnModuleHistory.Visible = false;
            // 
            // frmCostGroupDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 455);
            this.Controls.Add(this.mnuMenu);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCostGroupDetail";
            this.Text = "NHÓM CHI PHÍ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCostGroupDetail_FormClosed);
            this.Load += new System.EventHandler(this.frmCostGroupDetail_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDividedRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPercentVat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProfitTM.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPercentUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProfitSX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPercentTrade.Properties)).EndInit();
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.TextEdit txtPercentVat;
        private DevExpress.XtraEditors.TextEdit txtPercentUser;
        private DevExpress.XtraEditors.TextEdit txtPercentTrade;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip mnuMenu;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnSaveAndClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnModuleHistory;
        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.Grid.GridView grvData;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colCostDetailID;
        private DevExpress.XtraGrid.Columns.GridColumn colCostGroupID;
        private DevExpress.XtraGrid.Columns.GridColumn colPercent;
        private DevExpress.XtraEditors.SimpleButton btnAddCostDetail;
        private DevExpress.XtraEditors.SimpleButton btnRemoveCostDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colTypeName;
        private DevExpress.XtraGrid.Columns.GridColumn colIsFix;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.TextEdit txtDividedRate;
        private DevExpress.XtraEditors.TextEdit txtProfitTM;
        private DevExpress.XtraEditors.TextEdit txtProfitSX;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
    }
}