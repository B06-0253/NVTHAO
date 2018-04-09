namespace BMS
{
    partial class frmTLTKCoCau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTLTKCoCau));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.colTreePath = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTreeNumber = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTreeFileNumber = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTreeFullPath = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTreeID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colFullFilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDownloadFile = new DevExpress.XtraEditors.SimpleButton();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.mnuMenu = new System.Windows.Forms.ToolStrip();
            this.btnDownloadAll = new System.Windows.Forms.ToolStripButton();
            this.colSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grvCoCau = new System.Windows.Forms.DataGridView();
            this.colMaCoCau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenCoCau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImagePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsSaved = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddCoCau = new DevExpress.XtraEditors.SimpleButton();
            this.btnCreateCoCau = new DevExpress.XtraEditors.SimpleButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grvData = new System.Windows.Forms.DataGridView();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboModule = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.grvCboModule = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCboID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCboModuleCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCboModuleName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.mnuMenu.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvCoCau)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboModule.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCboModule)).BeginInit();
            this.SuspendLayout();
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(15, 8);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(81, 17);
            this.chkSelectAll.TabIndex = 6;
            this.chkSelectAll.Text = "Chọn tất cả";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            // 
            // treeList1
            // 
            this.treeList1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeList1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.treeList1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.treeList1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.treeList1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.treeList1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.treeList1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colTreePath,
            this.colTreeNumber,
            this.colTreeFileNumber,
            this.colTreeFullPath,
            this.colTreeID});
            this.treeList1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeList1.Location = new System.Drawing.Point(5, 5);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsView.ShowCheckBoxes = true;
            this.treeList1.Size = new System.Drawing.Size(538, 261);
            this.treeList1.TabIndex = 0;
            this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            // 
            // colTreePath
            // 
            this.colTreePath.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTreePath.AppearanceHeader.Options.UseFont = true;
            this.colTreePath.AppearanceHeader.Options.UseTextOptions = true;
            this.colTreePath.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTreePath.Caption = "Thư mục";
            this.colTreePath.FieldName = "PathName";
            this.colTreePath.MinWidth = 32;
            this.colTreePath.Name = "colTreePath";
            this.colTreePath.OptionsColumn.AllowEdit = false;
            this.colTreePath.OptionsColumn.AllowFocus = false;
            this.colTreePath.Visible = true;
            this.colTreePath.VisibleIndex = 0;
            this.colTreePath.Width = 210;
            // 
            // colTreeNumber
            // 
            this.colTreeNumber.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTreeNumber.AppearanceHeader.Options.UseFont = true;
            this.colTreeNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.colTreeNumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTreeNumber.Caption = "Tổng thư mục con";
            this.colTreeNumber.FieldName = "FolderNumber";
            this.colTreeNumber.Name = "colTreeNumber";
            this.colTreeNumber.OptionsColumn.AllowEdit = false;
            this.colTreeNumber.OptionsColumn.AllowFocus = false;
            this.colTreeNumber.Width = 141;
            // 
            // colTreeFileNumber
            // 
            this.colTreeFileNumber.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTreeFileNumber.AppearanceHeader.Options.UseFont = true;
            this.colTreeFileNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.colTreeFileNumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTreeFileNumber.Caption = "Tổng file";
            this.colTreeFileNumber.FieldName = "FileNumber";
            this.colTreeFileNumber.Name = "colTreeFileNumber";
            this.colTreeFileNumber.OptionsColumn.AllowEdit = false;
            this.colTreeFileNumber.OptionsColumn.AllowFocus = false;
            this.colTreeFileNumber.Visible = true;
            this.colTreeFileNumber.VisibleIndex = 1;
            // 
            // colTreeFullPath
            // 
            this.colTreeFullPath.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTreeFullPath.AppearanceHeader.Options.UseFont = true;
            this.colTreeFullPath.AppearanceHeader.Options.UseTextOptions = true;
            this.colTreeFullPath.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTreeFullPath.Caption = "FullPath";
            this.colTreeFullPath.FieldName = "FullPathName";
            this.colTreeFullPath.Name = "colTreeFullPath";
            // 
            // colTreeID
            // 
            this.colTreeID.Caption = "ID";
            this.colTreeID.FieldName = "ID";
            this.colTreeID.Name = "colTreeID";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(129, 26);
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.downloadToolStripMenuItem.Text = "Download";
            this.downloadToolStripMenuItem.Click += new System.EventHandler(this.downloadToolStripMenuItem_Click);
            // 
            // colFullFilePath
            // 
            this.colFullFilePath.DataPropertyName = "FullPath";
            this.colFullFilePath.HeaderText = "Đường dẫn";
            this.colFullFilePath.Name = "colFullFilePath";
            this.colFullFilePath.Visible = false;
            // 
            // btnDownloadFile
            // 
            this.btnDownloadFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownloadFile.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownloadFile.Appearance.Options.UseFont = true;
            this.btnDownloadFile.Location = new System.Drawing.Point(441, 3);
            this.btnDownloadFile.Name = "btnDownloadFile";
            this.btnDownloadFile.Size = new System.Drawing.Size(76, 23);
            this.btnDownloadFile.TabIndex = 8;
            this.btnDownloadFile.Text = "Download";
            this.btnDownloadFile.Click += new System.EventHandler(this.btnDownloadFile_Click);
            // 
            // colDate
            // 
            this.colDate.DataPropertyName = "CreatedDate";
            this.colDate.FillWeight = 19.11159F;
            this.colDate.HeaderText = "Ngày tạo";
            this.colDate.Name = "colDate";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(702, 9);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(379, 23);
            this.progressBar1.TabIndex = 166;
            this.progressBar1.Visible = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(44, 33);
            this.btnClose.Text = "Thoát";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // mnuMenu
            // 
            this.mnuMenu.AutoSize = false;
            this.mnuMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.mnuMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDownloadAll,
            this.toolStripSeparator1,
            this.btnClose});
            this.mnuMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuMenu.Size = new System.Drawing.Size(1083, 42);
            this.mnuMenu.TabIndex = 167;
            this.mnuMenu.Text = "toolStrip2";
            // 
            // btnDownloadAll
            // 
            this.btnDownloadAll.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownloadAll.Image = ((System.Drawing.Image)(resources.GetObject("btnDownloadAll.Image")));
            this.btnDownloadAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDownloadAll.Name = "btnDownloadAll";
            this.btnDownloadAll.Size = new System.Drawing.Size(116, 33);
            this.btnDownloadAll.Tag = "";
            this.btnDownloadAll.Text = "Download thư mục";
            this.btnDownloadAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDownloadAll.Click += new System.EventHandler(this.btnDownloadAll_Click);
            // 
            // colSize
            // 
            this.colSize.DataPropertyName = "Size";
            this.colSize.FillWeight = 24.30181F;
            this.colSize.HeaderText = "Size";
            this.colSize.Name = "colSize";
            this.colSize.ReadOnly = true;
            this.colSize.Width = 73;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(4, 74);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeList1);
            this.splitContainer1.Panel1.Controls.Add(this.grvCoCau);
            this.splitContainer1.Panel1.Controls.Add(this.btnAddCoCau);
            this.splitContainer1.Panel1.Controls.Add(this.btnCreateCoCau);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer1.Panel2.Controls.Add(this.chkSelectAll);
            this.splitContainer1.Panel2.Controls.Add(this.grvData);
            this.splitContainer1.Panel2.Controls.Add(this.btnDownloadFile);
            this.splitContainer1.Size = new System.Drawing.Size(1076, 489);
            this.splitContainer1.SplitterDistance = 550;
            this.splitContainer1.TabIndex = 165;
            // 
            // grvCoCau
            // 
            this.grvCoCau.AllowUserToAddRows = false;
            this.grvCoCau.AllowUserToDeleteRows = false;
            this.grvCoCau.AllowUserToResizeRows = false;
            this.grvCoCau.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grvCoCau.BackgroundColor = System.Drawing.Color.White;
            this.grvCoCau.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvCoCau.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaCoCau,
            this.colTenCoCau,
            this.colImagePath,
            this.colIsSaved});
            this.grvCoCau.ContextMenuStrip = this.contextMenuStrip2;
            this.grvCoCau.Location = new System.Drawing.Point(5, 301);
            this.grvCoCau.MultiSelect = false;
            this.grvCoCau.Name = "grvCoCau";
            this.grvCoCau.ReadOnly = true;
            this.grvCoCau.RowHeadersVisible = false;
            this.grvCoCau.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grvCoCau.Size = new System.Drawing.Size(538, 183);
            this.grvCoCau.TabIndex = 5;
            // 
            // colMaCoCau
            // 
            this.colMaCoCau.DataPropertyName = "MaCoCau";
            this.colMaCoCau.HeaderText = "Mã cơ cấu";
            this.colMaCoCau.Name = "colMaCoCau";
            this.colMaCoCau.ReadOnly = true;
            // 
            // colTenCoCau
            // 
            this.colTenCoCau.DataPropertyName = "TenCoCau";
            this.colTenCoCau.FillWeight = 24.30181F;
            this.colTenCoCau.HeaderText = "Tên cơ cấu";
            this.colTenCoCau.Name = "colTenCoCau";
            this.colTenCoCau.ReadOnly = true;
            this.colTenCoCau.Width = 150;
            // 
            // colImagePath
            // 
            this.colImagePath.DataPropertyName = "LocalPath";
            this.colImagePath.HeaderText = "Đường dẫn";
            this.colImagePath.Name = "colImagePath";
            this.colImagePath.ReadOnly = true;
            this.colImagePath.Visible = false;
            // 
            // colIsSaved
            // 
            this.colIsSaved.DataPropertyName = "IsSaved";
            this.colIsSaved.HeaderText = "IsSaved";
            this.colIsSaved.Name = "colIsSaved";
            this.colIsSaved.ReadOnly = true;
            this.colIsSaved.Visible = false;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xóaToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(95, 26);
            // 
            // xóaToolStripMenuItem
            // 
            this.xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
            this.xóaToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.xóaToolStripMenuItem.Text = "Xóa";
            this.xóaToolStripMenuItem.Click += new System.EventHandler(this.xóaToolStripMenuItem_Click);
            // 
            // btnAddCoCau
            // 
            this.btnAddCoCau.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCoCau.Appearance.Options.UseFont = true;
            this.btnAddCoCau.Location = new System.Drawing.Point(5, 267);
            this.btnAddCoCau.Name = "btnAddCoCau";
            this.btnAddCoCau.Size = new System.Drawing.Size(117, 32);
            this.btnAddCoCau.TabIndex = 8;
            this.btnAddCoCau.Text = "↓Thêm cơ cấu";
            this.btnAddCoCau.Click += new System.EventHandler(this.btnAddCoCau_Click);
            // 
            // btnCreateCoCau
            // 
            this.btnCreateCoCau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateCoCau.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateCoCau.Appearance.Options.UseFont = true;
            this.btnCreateCoCau.Location = new System.Drawing.Point(442, 267);
            this.btnCreateCoCau.Name = "btnCreateCoCau";
            this.btnCreateCoCau.Size = new System.Drawing.Size(101, 32);
            this.btnCreateCoCau.TabIndex = 8;
            this.btnCreateCoCau.Text = "Tạo cơ cấu";
            this.btnCreateCoCau.Click += new System.EventHandler(this.btnCreateCoCau_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(4, 196);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(513, 288);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // grvData
            // 
            this.grvData.AllowUserToAddRows = false;
            this.grvData.AllowUserToDeleteRows = false;
            this.grvData.AllowUserToResizeRows = false;
            this.grvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grvData.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheck,
            this.colFileName,
            this.colName,
            this.colSize,
            this.colDate,
            this.colFullFilePath});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grvData.DefaultCellStyle = dataGridViewCellStyle2;
            this.grvData.Location = new System.Drawing.Point(3, 29);
            this.grvData.Name = "grvData";
            this.grvData.RowHeadersVisible = false;
            this.grvData.Size = new System.Drawing.Size(514, 161);
            this.grvData.TabIndex = 5;
            // 
            // colCheck
            // 
            this.colCheck.DataPropertyName = "check";
            this.colCheck.FillWeight = 5.733478F;
            this.colCheck.HeaderText = "";
            this.colCheck.Name = "colCheck";
            this.colCheck.Width = 50;
            // 
            // colFileName
            // 
            this.colFileName.DataPropertyName = "FileName";
            this.colFileName.FillWeight = 24.30181F;
            this.colFileName.HeaderText = "Tên file";
            this.colFileName.Name = "colFileName";
            this.colFileName.ReadOnly = true;
            this.colFileName.Width = 150;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.FillWeight = 75.72031F;
            this.colName.HeaderText = "Tên vật tư";
            this.colName.Name = "colName";
            this.colName.Visible = false;
            this.colName.Width = 228;
            // 
            // cboModule
            // 
            this.cboModule.Location = new System.Drawing.Point(50, 47);
            this.cboModule.Name = "cboModule";
            this.cboModule.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboModule.Properties.NullText = "";
            this.cboModule.Properties.View = this.grvCboModule;
            this.cboModule.Size = new System.Drawing.Size(498, 20);
            this.cboModule.TabIndex = 181;
            this.cboModule.EditValueChanged += new System.EventHandler(this.cboModule_EditValueChanged);
            // 
            // grvCboModule
            // 
            this.grvCboModule.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCboID,
            this.colCboModuleCode,
            this.colCboModuleName});
            this.grvCboModule.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboModule.Name = "grvCboModule";
            this.grvCboModule.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboModule.OptionsView.ShowGroupPanel = false;
            // 
            // colCboID
            // 
            this.colCboID.Caption = "ID";
            this.colCboID.FieldName = "ID";
            this.colCboID.Name = "colCboID";
            // 
            // colCboModuleCode
            // 
            this.colCboModuleCode.Caption = "Mã";
            this.colCboModuleCode.FieldName = "Code";
            this.colCboModuleCode.Name = "colCboModuleCode";
            this.colCboModuleCode.Visible = true;
            this.colCboModuleCode.VisibleIndex = 0;
            // 
            // colCboModuleName
            // 
            this.colCboModuleName.Caption = "Tên";
            this.colCboModuleName.FieldName = "Name";
            this.colCboModuleName.Name = "colCboModuleName";
            this.colCboModuleName.Visible = true;
            this.colCboModuleName.VisibleIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 180;
            this.label8.Text = "Module";
            // 
            // frmTLTKCoCau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 564);
            this.Controls.Add(this.cboModule);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.mnuMenu);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmTLTKCoCau";
            this.Text = "Tài liệu thiết kế";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmTLTKCoCau_Load);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvCoCau)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboModule.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCboModule)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkSelectAll;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTreePath;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTreeNumber;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTreeFileNumber;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTreeFullPath;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTreeID;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullFilePath;
        private DevExpress.XtraEditors.SimpleButton btnDownloadFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStrip mnuMenu;
        private System.Windows.Forms.ToolStripButton btnDownloadAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSize;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView grvData;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private DevExpress.XtraEditors.SearchLookUpEdit cboModule;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCboModule;
        private DevExpress.XtraGrid.Columns.GridColumn colCboID;
        private DevExpress.XtraGrid.Columns.GridColumn colCboModuleCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCboModuleName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView grvCoCau;
        private DevExpress.XtraEditors.SimpleButton btnCreateCoCau;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaCoCau;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenCoCau;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImagePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIsSaved;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
        private DevExpress.XtraEditors.SimpleButton btnAddCoCau;
    }
}