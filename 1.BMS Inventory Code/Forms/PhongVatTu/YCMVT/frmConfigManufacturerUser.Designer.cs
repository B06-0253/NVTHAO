namespace BMS
{
    partial class frmConfigManufacturerUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigManufacturerUser));
            this.mnuMenu = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.grdM = new DevExpress.XtraGrid.GridControl();
            this.grvM = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMManufacturerId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colMUserId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMPartsCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMPartsName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMPartsId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMLinkID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.cboUser = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.grvCboUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAccount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label11 = new System.Windows.Forms.Label();
            this.btnFindAll = new DevExpress.XtraEditors.SimpleButton();
            this.txtTextFind = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotalPage = new System.Windows.Forms.TextBox();
            this.txtPageIndex = new System.Windows.Forms.TextBox();
            this.btnNxtPage = new System.Windows.Forms.Button();
            this.btnPrevPage = new System.Windows.Forms.Button();
            this.btnFirstPage = new System.Windows.Forms.Button();
            this.btnLastPage = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRecordPerPage = new DevExpress.XtraEditors.TextEdit();
            this.mnuMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCboUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRecordPerPage.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuMenu
            // 
            this.mnuMenu.AutoSize = false;
            this.mnuMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.mnuMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave});
            this.mnuMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mnuMenu.Size = new System.Drawing.Size(1014, 36);
            this.mnuMenu.TabIndex = 23;
            this.mnuMenu.Text = "toolStrip2";
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(33, 33);
            this.btnSave.Text = "Add";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grdM
            // 
            this.grdM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdM.Location = new System.Drawing.Point(2, 70);
            this.grdM.MainView = this.grvM;
            this.grdM.Name = "grdM";
            this.grdM.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1,
            this.repositoryItemCheckEdit1});
            this.grdM.Size = new System.Drawing.Size(1012, 385);
            this.grdM.TabIndex = 24;
            this.grdM.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvM});
            // 
            // grvM
            // 
            this.grvM.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvM.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvM.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvM.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvM.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvM.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvM.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMManufacturerId,
            this.colMCode,
            this.colMName,
            this.colMUserId,
            this.colMUserName,
            this.colMPartsCode,
            this.colMPartsName,
            this.colMPartsId,
            this.colMGroup,
            this.colMLinkID});
            this.grvM.GridControl = this.grdM;
            this.grvM.GroupCount = 1;
            this.grvM.Name = "grvM";
            this.grvM.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvM.OptionsFind.AlwaysVisible = true;
            this.grvM.OptionsSelection.MultiSelect = true;
            this.grvM.OptionsView.ColumnAutoWidth = false;
            this.grvM.OptionsView.RowAutoHeight = true;
            this.grvM.OptionsView.ShowFooter = true;
            this.grvM.OptionsView.ShowGroupPanel = false;
            this.grvM.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colMGroup, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colMManufacturerId
            // 
            this.colMManufacturerId.AppearanceHeader.Options.UseTextOptions = true;
            this.colMManufacturerId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMManufacturerId.Caption = "ID";
            this.colMManufacturerId.FieldName = "ManufacturerId";
            this.colMManufacturerId.Name = "colMManufacturerId";
            // 
            // colMCode
            // 
            this.colMCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMCode.AppearanceHeader.Options.UseFont = true;
            this.colMCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colMCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMCode.Caption = "Hãng";
            this.colMCode.FieldName = "ManufacturerCode";
            this.colMCode.Name = "colMCode";
            this.colMCode.OptionsColumn.AllowEdit = false;
            this.colMCode.Visible = true;
            this.colMCode.VisibleIndex = 2;
            this.colMCode.Width = 159;
            // 
            // colMName
            // 
            this.colMName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMName.AppearanceHeader.Options.UseFont = true;
            this.colMName.AppearanceHeader.Options.UseTextOptions = true;
            this.colMName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMName.Caption = "Tên hãng";
            this.colMName.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colMName.FieldName = "MName";
            this.colMName.Name = "colMName";
            this.colMName.OptionsColumn.AllowEdit = false;
            this.colMName.OptionsColumn.AllowFocus = false;
            this.colMName.Width = 296;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // colMUserId
            // 
            this.colMUserId.Caption = "UserId";
            this.colMUserId.FieldName = "UserId";
            this.colMUserId.Name = "colMUserId";
            // 
            // colMUserName
            // 
            this.colMUserName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMUserName.AppearanceHeader.Options.UseFont = true;
            this.colMUserName.AppearanceHeader.Options.UseTextOptions = true;
            this.colMUserName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMUserName.Caption = "Người phụ trách";
            this.colMUserName.FieldName = "UserName";
            this.colMUserName.Name = "colMUserName";
            this.colMUserName.OptionsColumn.AllowEdit = false;
            this.colMUserName.Visible = true;
            this.colMUserName.VisibleIndex = 3;
            this.colMUserName.Width = 167;
            // 
            // colMPartsCode
            // 
            this.colMPartsCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMPartsCode.AppearanceHeader.Options.UseFont = true;
            this.colMPartsCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colMPartsCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMPartsCode.Caption = "Mã vật tư";
            this.colMPartsCode.FieldName = "PartsCode";
            this.colMPartsCode.Name = "colMPartsCode";
            this.colMPartsCode.OptionsColumn.AllowEdit = false;
            this.colMPartsCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "PartsCode", "{0:n0}")});
            this.colMPartsCode.Visible = true;
            this.colMPartsCode.VisibleIndex = 0;
            this.colMPartsCode.Width = 178;
            // 
            // colMPartsName
            // 
            this.colMPartsName.AppearanceCell.Options.UseTextOptions = true;
            this.colMPartsName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMPartsName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colMPartsName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMPartsName.AppearanceHeader.Options.UseFont = true;
            this.colMPartsName.AppearanceHeader.Options.UseTextOptions = true;
            this.colMPartsName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMPartsName.Caption = "Tên vật tư";
            this.colMPartsName.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colMPartsName.FieldName = "PartsName";
            this.colMPartsName.Name = "colMPartsName";
            this.colMPartsName.OptionsColumn.AllowEdit = false;
            this.colMPartsName.Visible = true;
            this.colMPartsName.VisibleIndex = 1;
            this.colMPartsName.Width = 395;
            // 
            // colMPartsId
            // 
            this.colMPartsId.Caption = "PartsId";
            this.colMPartsId.FieldName = "PartsId";
            this.colMPartsId.Name = "colMPartsId";
            // 
            // colMGroup
            // 
            this.colMGroup.Caption = "Nhóm vật tư";
            this.colMGroup.FieldName = "MaterialGroup";
            this.colMGroup.Name = "colMGroup";
            // 
            // colMLinkID
            // 
            this.colMLinkID.Caption = "ID";
            this.colMLinkID.FieldName = "ID";
            this.colMLinkID.Name = "colMLinkID";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // cboUser
            // 
            this.cboUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboUser.Location = new System.Drawing.Point(692, 7);
            this.cboUser.Name = "cboUser";
            this.cboUser.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7F);
            this.cboUser.Properties.Appearance.Options.UseFont = true;
            this.cboUser.Properties.AutoHeight = false;
            this.cboUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboUser.Properties.NullText = "";
            this.cboUser.Properties.View = this.grvCboUser;
            this.cboUser.Size = new System.Drawing.Size(287, 20);
            this.cboUser.TabIndex = 184;
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
            this.label11.Location = new System.Drawing.Point(604, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 13);
            this.label11.TabIndex = 185;
            this.label11.Text = "Người phụ trách";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnFindAll
            // 
            this.btnFindAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFindAll.Location = new System.Drawing.Point(754, 41);
            this.btnFindAll.Name = "btnFindAll";
            this.btnFindAll.Size = new System.Drawing.Size(51, 23);
            this.btnFindAll.TabIndex = 194;
            this.btnFindAll.Text = "Tìm kiếm";
            this.btnFindAll.Click += new System.EventHandler(this.btnFindAll_Click);
            // 
            // txtTextFind
            // 
            this.txtTextFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTextFind.Location = new System.Drawing.Point(315, 43);
            this.txtTextFind.Name = "txtTextFind";
            this.txtTextFind.Size = new System.Drawing.Size(435, 20);
            this.txtTextFind.TabIndex = 193;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(904, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 192;
            this.label2.Text = "/";
            // 
            // txtTotalPage
            // 
            this.txtTotalPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotalPage.Enabled = false;
            this.txtTotalPage.Location = new System.Drawing.Point(918, 43);
            this.txtTotalPage.Name = "txtTotalPage";
            this.txtTotalPage.Size = new System.Drawing.Size(33, 20);
            this.txtTotalPage.TabIndex = 191;
            this.txtTotalPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPageIndex
            // 
            this.txtPageIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPageIndex.Enabled = false;
            this.txtPageIndex.Location = new System.Drawing.Point(870, 43);
            this.txtPageIndex.Name = "txtPageIndex";
            this.txtPageIndex.Size = new System.Drawing.Size(33, 20);
            this.txtPageIndex.TabIndex = 190;
            this.txtPageIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnNxtPage
            // 
            this.btnNxtPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNxtPage.Location = new System.Drawing.Point(953, 41);
            this.btnNxtPage.Name = "btnNxtPage";
            this.btnNxtPage.Size = new System.Drawing.Size(29, 23);
            this.btnNxtPage.TabIndex = 187;
            this.btnNxtPage.Text = ">";
            this.btnNxtPage.UseVisualStyleBackColor = true;
            this.btnNxtPage.Click += new System.EventHandler(this.btnNxtPage_Click);
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevPage.Location = new System.Drawing.Point(838, 41);
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.Size = new System.Drawing.Size(29, 23);
            this.btnPrevPage.TabIndex = 188;
            this.btnPrevPage.Text = "<";
            this.btnPrevPage.UseVisualStyleBackColor = true;
            this.btnPrevPage.Click += new System.EventHandler(this.btnPrevPage_Click);
            // 
            // btnFirstPage
            // 
            this.btnFirstPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFirstPage.Location = new System.Drawing.Point(810, 41);
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.Size = new System.Drawing.Size(29, 23);
            this.btnFirstPage.TabIndex = 189;
            this.btnFirstPage.Text = "<<";
            this.btnFirstPage.UseVisualStyleBackColor = true;
            this.btnFirstPage.Click += new System.EventHandler(this.btnFirstPage_Click);
            // 
            // btnLastPage
            // 
            this.btnLastPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLastPage.Location = new System.Drawing.Point(981, 41);
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.Size = new System.Drawing.Size(29, 23);
            this.btnLastPage.TabIndex = 195;
            this.btnLastPage.Text = ">>";
            this.btnLastPage.UseVisualStyleBackColor = true;
            this.btnLastPage.Click += new System.EventHandler(this.btnLastPage_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 13);
            this.label8.TabIndex = 202;
            this.label8.Text = "Số lượng vật tư cần xem";
            // 
            // txtRecordPerPage
            // 
            this.txtRecordPerPage.EditValue = "100";
            this.txtRecordPerPage.Location = new System.Drawing.Point(140, 7);
            this.txtRecordPerPage.Name = "txtRecordPerPage";
            this.txtRecordPerPage.Properties.DisplayFormat.FormatString = "n0";
            this.txtRecordPerPage.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtRecordPerPage.Properties.EditFormat.FormatString = "n0";
            this.txtRecordPerPage.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtRecordPerPage.Properties.Mask.EditMask = "n0";
            this.txtRecordPerPage.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtRecordPerPage.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtRecordPerPage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtRecordPerPage.Size = new System.Drawing.Size(45, 20);
            this.txtRecordPerPage.TabIndex = 201;
            // 
            // frmConfigManufacturerUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 457);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtRecordPerPage);
            this.Controls.Add(this.btnLastPage);
            this.Controls.Add(this.btnFindAll);
            this.Controls.Add(this.txtTextFind);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTotalPage);
            this.Controls.Add(this.txtPageIndex);
            this.Controls.Add(this.btnNxtPage);
            this.Controls.Add(this.btnPrevPage);
            this.Controls.Add(this.btnFirstPage);
            this.Controls.Add(this.cboUser);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.grdM);
            this.Controls.Add(this.mnuMenu);
            this.Name = "frmConfigManufacturerUser";
            this.Text = "Cấu hình nhân viên phụ trách mua vật tư";
            this.Load += new System.EventHandler(this.frmConfigManufacturerUser_Load);
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCboUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRecordPerPage.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip mnuMenu;
        private System.Windows.Forms.ToolStripButton btnSave;
        private DevExpress.XtraGrid.GridControl grdM;
        private DevExpress.XtraGrid.Views.Grid.GridView grvM;
        private DevExpress.XtraGrid.Columns.GridColumn colMManufacturerId;
        private DevExpress.XtraGrid.Columns.GridColumn colMCode;
        private DevExpress.XtraGrid.Columns.GridColumn colMName;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colMUserId;
        private DevExpress.XtraGrid.Columns.GridColumn colMUserName;
        private DevExpress.XtraEditors.SearchLookUpEdit cboUser;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCboUser;
        private DevExpress.XtraGrid.Columns.GridColumn colUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colFullName;
        private DevExpress.XtraGrid.Columns.GridColumn colAccount;
        private System.Windows.Forms.Label label11;
        private DevExpress.XtraEditors.SimpleButton btnFindAll;
        private System.Windows.Forms.TextBox txtTextFind;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotalPage;
        private System.Windows.Forms.TextBox txtPageIndex;
        private System.Windows.Forms.Button btnNxtPage;
        private System.Windows.Forms.Button btnPrevPage;
        private System.Windows.Forms.Button btnFirstPage;
        private System.Windows.Forms.Button btnLastPage;
        private DevExpress.XtraGrid.Columns.GridColumn colMPartsCode;
        private DevExpress.XtraGrid.Columns.GridColumn colMPartsName;
        private DevExpress.XtraGrid.Columns.GridColumn colMPartsId;
        private DevExpress.XtraGrid.Columns.GridColumn colMGroup;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.TextEdit txtRecordPerPage;
        private DevExpress.XtraGrid.Columns.GridColumn colMLinkID;
    }
}