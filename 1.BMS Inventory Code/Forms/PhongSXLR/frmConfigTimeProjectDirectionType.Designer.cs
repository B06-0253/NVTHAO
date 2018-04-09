namespace BMS
{
    partial class frmConfigTimeProjectDirectionType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfigTimeProjectDirectionType));
            DevExpress.XtraTreeList.FilterCondition filterCondition1 = new DevExpress.XtraTreeList.FilterCondition();
            DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.mnuMenu = new System.Windows.Forms.ToolStrip();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboParent = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.grvCboKhachHang = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCboCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCboName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCboID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTimeDK = new DevExpress.XtraEditors.TextEdit();
            this.txtQty = new DevExpress.XtraEditors.TextEdit();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.treeData = new DevExpress.XtraTreeList.TreeList();
            this.colIDTree = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTimeDK = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colPercentExport = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colProjectModuleId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colQty = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTotalDateAboutENull = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            this.mnuMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboParent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCboKhachHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeDK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeData)).BeginInit();
            this.SuspendLayout();
            // 
            // colName
            // 
            this.colName.AppearanceCell.Options.UseTextOptions = true;
            this.colName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colName.AppearanceHeader.Options.UseFont = true;
            this.colName.AppearanceHeader.Options.UseTextOptions = true;
            this.colName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colName.Caption = "Tên";
            this.colName.ColumnEdit = this.repositoryItemMemoEdit2;
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.OptionsColumn.AllowSort = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 330;
            // 
            // repositoryItemMemoEdit2
            // 
            this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
            // 
            // colCode
            // 
            this.colCode.AppearanceCell.Options.UseTextOptions = true;
            this.colCode.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCode.AppearanceHeader.Options.UseFont = true;
            this.colCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCode.Caption = "Mã";
            this.colCode.ColumnEdit = this.repositoryItemMemoEdit2;
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.OptionsColumn.AllowEdit = false;
            this.colCode.OptionsColumn.AllowSort = false;
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            this.colCode.Width = 86;
            // 
            // mnuMenu
            // 
            this.mnuMenu.AutoSize = false;
            this.mnuMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.mnuMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.btnEdit,
            this.btnDelete,
            this.btnSave,
            this.btnCancel,
            this.toolStripSeparator1,
            this.btnClose});
            this.mnuMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuMenu.Size = new System.Drawing.Size(646, 42);
            this.mnuMenu.TabIndex = 20;
            this.mnuMenu.Text = "toolStrip2";
            // 
            // btnNew
            // 
            this.btnNew.AutoSize = false;
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(55, 40);
            this.btnNew.Tag = "Form_Department_Add";
            this.btnNew.Text = "&Thêm";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.AutoSize = false;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(55, 40);
            this.btnEdit.Tag = "Form_Department_Edit";
            this.btnEdit.Text = "Sửa";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = false;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(55, 40);
            this.btnDelete.Tag = "Form_Department_Del";
            this.btnDelete.Text = "Xóa";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = false;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(55, 40);
            this.btnSave.Text = "Ghi";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCancel.AutoSize = false;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(55, 40);
            this.btnCancel.Text = "Hủy";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = false;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(55, 40);
            this.btnClose.Text = "Thoát";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.groupBox1.Controls.Add(this.cboParent);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTimeDK);
            this.groupBox1.Controls.Add(this.txtQty);
            this.groupBox1.Controls.Add(this.txtCode);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(0, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(646, 103);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            // 
            // cboParent
            // 
            this.cboParent.Location = new System.Drawing.Point(69, 71);
            this.cboParent.Name = "cboParent";
            this.cboParent.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7F);
            this.cboParent.Properties.Appearance.Options.UseFont = true;
            this.cboParent.Properties.AutoHeight = false;
            this.cboParent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboParent.Properties.NullText = "";
            this.cboParent.Properties.View = this.grvCboKhachHang;
            this.cboParent.Size = new System.Drawing.Size(363, 20);
            this.cboParent.TabIndex = 216;
            // 
            // grvCboKhachHang
            // 
            this.grvCboKhachHang.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvCboKhachHang.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvCboKhachHang.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvCboKhachHang.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvCboKhachHang.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvCboKhachHang.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvCboKhachHang.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCboCode,
            this.colCboName,
            this.colCboID});
            this.grvCboKhachHang.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboKhachHang.Name = "grvCboKhachHang";
            this.grvCboKhachHang.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvCboKhachHang.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboKhachHang.OptionsView.ColumnAutoWidth = false;
            this.grvCboKhachHang.OptionsView.ShowGroupedColumns = true;
            this.grvCboKhachHang.OptionsView.ShowGroupPanel = false;
            // 
            // colCboCode
            // 
            this.colCboCode.AppearanceCell.Options.UseTextOptions = true;
            this.colCboCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCboCode.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCboCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCboCode.AppearanceHeader.Options.UseFont = true;
            this.colCboCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colCboCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCboCode.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCboCode.Caption = "Mã";
            this.colCboCode.FieldName = "Code";
            this.colCboCode.Name = "colCboCode";
            this.colCboCode.OptionsColumn.AllowEdit = false;
            this.colCboCode.Visible = true;
            this.colCboCode.VisibleIndex = 0;
            // 
            // colCboName
            // 
            this.colCboName.AppearanceCell.Options.UseTextOptions = true;
            this.colCboName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCboName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCboName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCboName.AppearanceHeader.Options.UseFont = true;
            this.colCboName.AppearanceHeader.Options.UseTextOptions = true;
            this.colCboName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCboName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCboName.Caption = "Tên";
            this.colCboName.FieldName = "Name";
            this.colCboName.Name = "colCboName";
            this.colCboName.OptionsColumn.AllowEdit = false;
            this.colCboName.Visible = true;
            this.colCboName.VisibleIndex = 1;
            this.colCboName.Width = 309;
            // 
            // colCboID
            // 
            this.colCboID.AppearanceCell.Options.UseTextOptions = true;
            this.colCboID.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCboID.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCboID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCboID.AppearanceHeader.Options.UseFont = true;
            this.colCboID.AppearanceHeader.Options.UseTextOptions = true;
            this.colCboID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCboID.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCboID.Caption = "ID";
            this.colCboID.FieldName = "ID";
            this.colCboID.Name = "colCboID";
            this.colCboID.OptionsColumn.AllowEdit = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 215;
            this.label3.Text = "Nhóm cha";
            // 
            // txtTimeDK
            // 
            this.txtTimeDK.EditValue = "0";
            this.txtTimeDK.Location = new System.Drawing.Point(530, 42);
            this.txtTimeDK.Name = "txtTimeDK";
            this.txtTimeDK.Properties.DisplayFormat.FormatString = "n0";
            this.txtTimeDK.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTimeDK.Properties.EditFormat.FormatString = "n0";
            this.txtTimeDK.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTimeDK.Properties.Mask.EditMask = "n1";
            this.txtTimeDK.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTimeDK.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTimeDK.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTimeDK.Size = new System.Drawing.Size(104, 20);
            this.txtTimeDK.TabIndex = 10;
            // 
            // txtQty
            // 
            this.txtQty.EditValue = "0";
            this.txtQty.Location = new System.Drawing.Point(530, 14);
            this.txtQty.Name = "txtQty";
            this.txtQty.Properties.DisplayFormat.FormatString = "n0";
            this.txtQty.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtQty.Properties.EditFormat.FormatString = "n0";
            this.txtQty.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtQty.Properties.Mask.EditMask = "n1";
            this.txtQty.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtQty.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtQty.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtQty.Size = new System.Drawing.Size(104, 20);
            this.txtQty.TabIndex = 10;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(69, 14);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(134, 20);
            this.txtCode.TabIndex = 0;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(69, 42);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(363, 20);
            this.txtName.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(461, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Thời gian (h)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(507, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "SL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã";
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
            this.treeData.ColumnPanelRowHeight = 30;
            this.treeData.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colIDTree,
            this.colName,
            this.colCode,
            this.colTimeDK,
            this.colPercentExport,
            this.colProjectModuleId,
            this.colQty,
            this.colTotalDateAboutENull});
            this.treeData.CustomizationFormBounds = new System.Drawing.Rectangle(1080, 502, 216, 323);
            filterCondition1.Column = this.colName;
            filterCondition1.Condition = DevExpress.XtraTreeList.FilterConditionEnum.Contains;
            filterCondition1.Value1 = "<Null>";
            filterCondition1.Value2 = "<Null>";
            filterCondition1.Visible = true;
            this.treeData.FilterConditions.AddRange(new DevExpress.XtraTreeList.FilterCondition[] {
            filterCondition1});
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Column = this.colCode;
            this.treeData.FormatConditions.AddRange(new DevExpress.XtraTreeList.StyleFormatConditions.StyleFormatCondition[] {
            styleFormatCondition1});
            this.treeData.Location = new System.Drawing.Point(0, 154);
            this.treeData.Name = "treeData";
            this.treeData.OptionsBehavior.Editable = false;
            this.treeData.OptionsBehavior.EnableFiltering = true;
            this.treeData.OptionsSelection.MultiSelect = true;
            this.treeData.OptionsView.AutoWidth = false;
            this.treeData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit2});
            this.treeData.Size = new System.Drawing.Size(646, 363);
            this.treeData.TabIndex = 27;
            this.treeData.DoubleClick += new System.EventHandler(this.treeData_DoubleClick);
            // 
            // colIDTree
            // 
            this.colIDTree.Caption = "Mã nhóm";
            this.colIDTree.FieldName = "ID";
            this.colIDTree.Name = "colIDTree";
            this.colIDTree.OptionsColumn.AllowEdit = false;
            // 
            // colTimeDK
            // 
            this.colTimeDK.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTimeDK.AppearanceCell.Options.UseFont = true;
            this.colTimeDK.AppearanceCell.Options.UseTextOptions = true;
            this.colTimeDK.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTimeDK.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTimeDK.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTimeDK.AppearanceHeader.Options.UseFont = true;
            this.colTimeDK.AppearanceHeader.Options.UseTextOptions = true;
            this.colTimeDK.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTimeDK.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTimeDK.Caption = "Thời gian (h)";
            this.colTimeDK.FieldName = "TimeDK";
            this.colTimeDK.Format.FormatString = "n1";
            this.colTimeDK.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTimeDK.Name = "colTimeDK";
            this.colTimeDK.OptionsColumn.AllowEdit = false;
            this.colTimeDK.OptionsColumn.AllowSort = false;
            this.colTimeDK.Visible = true;
            this.colTimeDK.VisibleIndex = 3;
            this.colTimeDK.Width = 93;
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
            this.colQty.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colQty.AppearanceHeader.Options.UseFont = true;
            this.colQty.AppearanceHeader.Options.UseTextOptions = true;
            this.colQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colQty.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colQty.Caption = "Số lượng";
            this.colQty.FieldName = "Qty";
            this.colQty.Format.FormatString = "n1";
            this.colQty.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQty.Name = "colQty";
            this.colQty.Visible = true;
            this.colQty.VisibleIndex = 2;
            this.colQty.Width = 91;
            // 
            // colTotalDateAboutENull
            // 
            this.colTotalDateAboutENull.Caption = "TotalDateAboutENull";
            this.colTotalDateAboutENull.FieldName = "TotalDateAboutENull";
            this.colTotalDateAboutENull.Format.FormatString = "n0";
            this.colTotalDateAboutENull.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalDateAboutENull.Name = "colTotalDateAboutENull";
            // 
            // frmConfigTimeProjectDirectionType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 521);
            this.Controls.Add(this.treeData);
            this.Controls.Add(this.mnuMenu);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmConfigTimeProjectDirectionType";
            this.Text = "Cấu hình thời gian cho loại chỉ thị";
            this.Load += new System.EventHandler(this.frmConfigTimeProjectDirectionType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboParent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCboKhachHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimeDK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip mnuMenu;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtTimeDK;
        private DevExpress.XtraEditors.TextEdit txtQty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.SearchLookUpEdit cboParent;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCboKhachHang;
        private DevExpress.XtraGrid.Columns.GridColumn colCboCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCboName;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraGrid.Columns.GridColumn colCboID;
        private DevExpress.XtraTreeList.TreeList treeData;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIDTree;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCode;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTimeDK;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colPercentExport;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colProjectModuleId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colQty;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTotalDateAboutENull;
    }
}