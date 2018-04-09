namespace BMS
{
    partial class frmMaterialGroupNS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMaterialGroupNS));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtDescription = new DevExpress.XtraEditors.MemoEdit();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboHang = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.mnuMenu = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSaveAndClose = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnDeleteFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddFile = new System.Windows.Forms.ToolStripButton();
            this.grvData = new System.Windows.Forms.DataGridView();
            this.colMaterialNSID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocalPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdThongSo = new DevExpress.XtraGrid.GridControl();
            this.grvThongSo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIDThongSo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodeThongSo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colNameThongSo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDesThongSo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitThongSo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreateValue = new System.Windows.Forms.Button();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtSL = new DevExpress.XtraEditors.TextEdit();
            this.flpCode = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCreateCode = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboHang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            this.mnuMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdThongSo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvThongSo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSL.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(43, 216);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(456, 37);
            this.txtDescription.TabIndex = 13;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(43, 139);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(456, 20);
            this.txtCode.TabIndex = 7;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(21, 142);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(18, 13);
            this.labelControl1.TabIndex = 12;
            this.labelControl1.Text = "Mã:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(8, 225);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(31, 13);
            this.labelControl3.TabIndex = 9;
            this.labelControl3.Text = "Mô tả:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(43, 165);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(456, 20);
            this.txtName.TabIndex = 10;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(17, 168);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(22, 13);
            this.labelControl2.TabIndex = 11;
            this.labelControl2.Text = "Tên:";
            // 
            // cboHang
            // 
            this.cboHang.Location = new System.Drawing.Point(43, 190);
            this.cboHang.Name = "cboHang";
            this.cboHang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboHang.Properties.NullText = "";
            this.cboHang.Properties.View = this.searchLookUpEdit1View;
            this.cboHang.Size = new System.Drawing.Size(241, 20);
            this.cboHang.TabIndex = 16;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode});
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colCode
            // 
            this.colCode.Caption = "Hãng";
            this.colCode.FieldName = "Name";
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(10, 193);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(29, 13);
            this.labelControl5.TabIndex = 15;
            this.labelControl5.Text = "Hãng:";
            // 
            // mnuMenu
            // 
            this.mnuMenu.AutoSize = false;
            this.mnuMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.mnuMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.toolStripSeparator2,
            this.btnSaveAndClose});
            this.mnuMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuMenu.Size = new System.Drawing.Size(1058, 42);
            this.mnuMenu.TabIndex = 18;
            this.mnuMenu.Text = "toolStrip2";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(29, 33);
            this.btnSave.Tag = "frmMaterialNonManager_Save";
            this.btnSave.Text = "Ghi";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AutoSize = false;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 40);
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAndClose.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveAndClose.Image")));
            this.btnSaveAndClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(77, 33);
            this.btnSaveAndClose.Tag = "frmMaterialNonManager_Save";
            this.btnSaveAndClose.Text = "Ghi && Thoát";
            this.btnSaveAndClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.toolStrip1);
            this.groupBox1.Controls.Add(this.grvData);
            this.groupBox1.Location = new System.Drawing.Point(2, 261);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(517, 240);
            this.groupBox1.TabIndex = 182;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách file ảnh";
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDeleteFile,
            this.toolStripSeparator1,
            this.btnAddFile});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(3, 16);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(511, 35);
            this.toolStrip1.TabIndex = 166;
            this.toolStrip1.Text = "toolStrip2";
            // 
            // btnDeleteFile
            // 
            this.btnDeleteFile.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteFile.Image")));
            this.btnDeleteFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteFile.Name = "btnDeleteFile";
            this.btnDeleteFile.Size = new System.Drawing.Size(46, 33);
            this.btnDeleteFile.Tag = "frmMaterialNonManager_Save";
            this.btnDeleteFile.Text = "Xóa file";
            this.btnDeleteFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDeleteFile.Click += new System.EventHandler(this.btnDeleteFile_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // btnAddFile
            // 
            this.btnAddFile.Image = ((System.Drawing.Image)(resources.GetObject("btnAddFile.Image")));
            this.btnAddFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(54, 33);
            this.btnAddFile.Tag = "frmMaterialNonManager_Save";
            this.btnAddFile.Text = "Thêm file";
            this.btnAddFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // grvData
            // 
            this.grvData.AllowDrop = true;
            this.grvData.AllowUserToAddRows = false;
            this.grvData.AllowUserToDeleteRows = false;
            this.grvData.AllowUserToResizeRows = false;
            this.grvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grvData.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaterialNSID,
            this.colLocalPath,
            this.colID,
            this.colFileName,
            this.colFilePath,
            this.colSize,
            this.colCreatedDate});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grvData.DefaultCellStyle = dataGridViewCellStyle5;
            this.grvData.Location = new System.Drawing.Point(6, 54);
            this.grvData.MultiSelect = false;
            this.grvData.Name = "grvData";
            this.grvData.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvData.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.grvData.RowHeadersWidth = 10;
            this.grvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grvData.Size = new System.Drawing.Size(505, 180);
            this.grvData.TabIndex = 165;
            this.grvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grvData_CellDoubleClick);
            // 
            // colMaterialNSID
            // 
            this.colMaterialNSID.DataPropertyName = "MaterialNSID";
            this.colMaterialNSID.HeaderText = "MaterialNSID";
            this.colMaterialNSID.Name = "colMaterialNSID";
            this.colMaterialNSID.ReadOnly = true;
            this.colMaterialNSID.Visible = false;
            // 
            // colLocalPath
            // 
            this.colLocalPath.DataPropertyName = "LocalFilePath";
            this.colLocalPath.HeaderText = "LocalPath";
            this.colLocalPath.Name = "colLocalPath";
            this.colLocalPath.ReadOnly = true;
            this.colLocalPath.Visible = false;
            // 
            // colID
            // 
            this.colID.DataPropertyName = "ID";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            // 
            // colFileName
            // 
            this.colFileName.DataPropertyName = "Name";
            this.colFileName.FillWeight = 150F;
            this.colFileName.HeaderText = "Tên file";
            this.colFileName.Name = "colFileName";
            this.colFileName.ReadOnly = true;
            // 
            // colFilePath
            // 
            this.colFilePath.DataPropertyName = "FilePath";
            this.colFilePath.HeaderText = "Đường dẫn";
            this.colFilePath.Name = "colFilePath";
            this.colFilePath.ReadOnly = true;
            this.colFilePath.Visible = false;
            // 
            // colSize
            // 
            this.colSize.DataPropertyName = "Length";
            this.colSize.FillWeight = 70F;
            this.colSize.HeaderText = "Dung lượng";
            this.colSize.Name = "colSize";
            this.colSize.ReadOnly = true;
            // 
            // colCreatedDate
            // 
            this.colCreatedDate.DataPropertyName = "CreatedDate";
            this.colCreatedDate.FillWeight = 70F;
            this.colCreatedDate.HeaderText = "Ngày tạo";
            this.colCreatedDate.Name = "colCreatedDate";
            this.colCreatedDate.ReadOnly = true;
            // 
            // grdThongSo
            // 
            this.grdThongSo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdThongSo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdThongSo.Location = new System.Drawing.Point(525, 160);
            this.grdThongSo.MainView = this.grvThongSo;
            this.grdThongSo.Name = "grdThongSo";
            this.grdThongSo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1});
            this.grdThongSo.Size = new System.Drawing.Size(533, 341);
            this.grdThongSo.TabIndex = 183;
            this.grdThongSo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvThongSo});
            // 
            // grvThongSo
            // 
            this.grvThongSo.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvThongSo.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvThongSo.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvThongSo.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvThongSo.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvThongSo.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grvThongSo.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvThongSo.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvThongSo.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvThongSo.ColumnPanelRowHeight = 40;
            this.grvThongSo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIDThongSo,
            this.colCodeThongSo,
            this.colNameThongSo,
            this.colDesThongSo,
            this.colUnitThongSo});
            this.grvThongSo.GridControl = this.grdThongSo;
            this.grvThongSo.Name = "grvThongSo";
            this.grvThongSo.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvThongSo.OptionsCustomization.AllowRowSizing = true;
            this.grvThongSo.OptionsView.AllowHtmlDrawHeaders = true;
            this.grvThongSo.OptionsView.ColumnAutoWidth = false;
            this.grvThongSo.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.grvThongSo.OptionsView.RowAutoHeight = true;
            this.grvThongSo.OptionsView.ShowFooter = true;
            this.grvThongSo.OptionsView.ShowGroupPanel = false;
            this.grvThongSo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvThongSo_KeyDown);
            // 
            // colIDThongSo
            // 
            this.colIDThongSo.AppearanceCell.Options.UseTextOptions = true;
            this.colIDThongSo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colIDThongSo.Caption = "ID";
            this.colIDThongSo.FieldName = "ID";
            this.colIDThongSo.Name = "colIDThongSo";
            // 
            // colCodeThongSo
            // 
            this.colCodeThongSo.AppearanceCell.Options.UseTextOptions = true;
            this.colCodeThongSo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCodeThongSo.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCodeThongSo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCodeThongSo.AppearanceHeader.Options.UseFont = true;
            this.colCodeThongSo.Caption = "Mã thông số";
            this.colCodeThongSo.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colCodeThongSo.FieldName = "Code";
            this.colCodeThongSo.Name = "colCodeThongSo";
            this.colCodeThongSo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colCodeThongSo.Visible = true;
            this.colCodeThongSo.VisibleIndex = 0;
            this.colCodeThongSo.Width = 81;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // colNameThongSo
            // 
            this.colNameThongSo.AppearanceCell.Options.UseTextOptions = true;
            this.colNameThongSo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colNameThongSo.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNameThongSo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colNameThongSo.AppearanceHeader.Options.UseFont = true;
            this.colNameThongSo.Caption = "Tên thông số";
            this.colNameThongSo.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colNameThongSo.FieldName = "Name";
            this.colNameThongSo.Name = "colNameThongSo";
            this.colNameThongSo.Visible = true;
            this.colNameThongSo.VisibleIndex = 1;
            this.colNameThongSo.Width = 245;
            // 
            // colDesThongSo
            // 
            this.colDesThongSo.AppearanceCell.Options.UseTextOptions = true;
            this.colDesThongSo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDesThongSo.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDesThongSo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colDesThongSo.AppearanceHeader.Options.UseFont = true;
            this.colDesThongSo.AppearanceHeader.Options.UseTextOptions = true;
            this.colDesThongSo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDesThongSo.Caption = "Mô tả";
            this.colDesThongSo.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colDesThongSo.FieldName = "Description";
            this.colDesThongSo.Name = "colDesThongSo";
            this.colDesThongSo.Width = 260;
            // 
            // colUnitThongSo
            // 
            this.colUnitThongSo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colUnitThongSo.AppearanceHeader.Options.UseFont = true;
            this.colUnitThongSo.AppearanceHeader.Options.UseTextOptions = true;
            this.colUnitThongSo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUnitThongSo.Caption = "Đơn vị";
            this.colUnitThongSo.FieldName = "Unit";
            this.colUnitThongSo.Name = "colUnitThongSo";
            this.colUnitThongSo.Visible = true;
            this.colUnitThongSo.VisibleIndex = 2;
            // 
            // cboType
            // 
            this.cboType.FormattingEnabled = true;
            this.cboType.Items.AddRange(new object[] {
            "Cơ khí",
            "Điện",
            "Điện tử"});
            this.cboType.Location = new System.Drawing.Point(337, 189);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(162, 21);
            this.cboType.TabIndex = 184;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(305, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 185;
            this.label1.Text = "Loại:";
            // 
            // btnCreateValue
            // 
            this.btnCreateValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateValue.Location = new System.Drawing.Point(917, 134);
            this.btnCreateValue.Name = "btnCreateValue";
            this.btnCreateValue.Size = new System.Drawing.Size(138, 23);
            this.btnCreateValue.TabIndex = 186;
            this.btnCreateValue.Tag = "frmMaterialNonManager_Save";
            this.btnCreateValue.Text = "Tạo giá trị thông số";
            this.btnCreateValue.UseVisualStyleBackColor = true;
            this.btnCreateValue.Click += new System.EventHandler(this.btnCreateValue_Click);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(8, 60);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(58, 13);
            this.labelControl6.TabIndex = 12;
            this.labelControl6.Text = "SL Thông số";
            // 
            // txtSL
            // 
            this.txtSL.Location = new System.Drawing.Point(73, 57);
            this.txtSL.Name = "txtSL";
            this.txtSL.Properties.DisplayFormat.FormatString = "n0";
            this.txtSL.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSL.Properties.EditFormat.FormatString = "n0";
            this.txtSL.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtSL.Properties.Mask.EditMask = "n0";
            this.txtSL.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtSL.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtSL.Size = new System.Drawing.Size(54, 20);
            this.txtSL.TabIndex = 188;
            this.txtSL.EditValueChanged += new System.EventHandler(this.txtSL_EditValueChanged);
            // 
            // flpCode
            // 
            this.flpCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flpCode.AutoScroll = true;
            this.flpCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpCode.Location = new System.Drawing.Point(133, 48);
            this.flpCode.Name = "flpCode";
            this.flpCode.Size = new System.Drawing.Size(848, 72);
            this.flpCode.TabIndex = 189;
            // 
            // btnCreateCode
            // 
            this.btnCreateCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateCode.Location = new System.Drawing.Point(987, 65);
            this.btnCreateCode.Name = "btnCreateCode";
            this.btnCreateCode.Size = new System.Drawing.Size(68, 37);
            this.btnCreateCode.TabIndex = 190;
            this.btnCreateCode.Text = "Tạo mã";
            this.btnCreateCode.UseVisualStyleBackColor = true;
            this.btnCreateCode.Click += new System.EventHandler(this.btnCreateCode_Click);
            // 
            // frmMaterialGroupNS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 503);
            this.Controls.Add(this.btnCreateCode);
            this.Controls.Add(this.flpCode);
            this.Controls.Add(this.txtSL);
            this.Controls.Add(this.btnCreateValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.grdThongSo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.mnuMenu);
            this.Controls.Add(this.cboHang);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.labelControl2);
            this.Name = "frmMaterialGroupNS";
            this.Text = "NHÓM VẬT TƯ PHI TIÊU CHUẨN";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMaterialGroupNS_FormClosed);
            this.Load += new System.EventHandler(this.frmMaterialGroupNS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboHang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdThongSo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvThongSo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSL.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.MemoEdit txtDescription;
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SearchLookUpEdit cboHang;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.ToolStrip mnuMenu;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnSaveAndClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnDeleteFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnAddFile;
        private System.Windows.Forms.DataGridView grvData;
        private DevExpress.XtraGrid.GridControl grdThongSo;
        private DevExpress.XtraGrid.Views.Grid.GridView grvThongSo;
        private DevExpress.XtraGrid.Columns.GridColumn colIDThongSo;
        private DevExpress.XtraGrid.Columns.GridColumn colNameThongSo;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeThongSo;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreateValue;
        private DevExpress.XtraGrid.Columns.GridColumn colDesThongSo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaterialNSID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocalPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFilePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreatedDate;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtSL;
        private System.Windows.Forms.FlowLayoutPanel flpCode;
        private System.Windows.Forms.Button btnCreateCode;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitThongSo;
    }
}