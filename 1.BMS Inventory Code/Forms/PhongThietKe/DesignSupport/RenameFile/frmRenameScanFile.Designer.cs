namespace BMS
{
    partial class frmRenameScanFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRenameScanFile));
            this.colFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.colFilePath = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.colTreeName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTreeParentID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTreeFilelPath = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTreeID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnDeleteFile = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdScan = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xoaFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đôiTênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diChuyênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grvScan = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.ImgCollection = new System.Windows.Forms.ImageList(this.components);
            this.mnuMenu = new System.Windows.Forms.ToolStrip();
            this.btnScanAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnConfig = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rdbCokhi = new System.Windows.Forms.RadioButton();
            this.rdbDien = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdScan)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvScan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            this.mnuMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // colFileName
            // 
            this.colFileName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colFileName.AppearanceHeader.Options.UseFont = true;
            this.colFileName.AppearanceHeader.Options.UseTextOptions = true;
            this.colFileName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFileName.Caption = "Danh sách file";
            this.colFileName.FieldName = "FileName";
            this.colFileName.Name = "colFileName";
            this.colFileName.Visible = true;
            this.colFileName.VisibleIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(736, 497);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // colFilePath
            // 
            this.colFilePath.Caption = "FilePath";
            this.colFilePath.FieldName = "FilePath";
            this.colFilePath.Name = "colFilePath";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 45);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainerControl1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1157, 501);
            this.splitContainerControl1.SplitterPosition = 412;
            this.splitContainerControl1.TabIndex = 3;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.treeList1);
            this.groupBox3.Location = new System.Drawing.Point(1, 231);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(412, 263);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "File thư mục";
            // 
            // treeList1
            // 
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colTreeName,
            this.colTreeParentID,
            this.colTreeFilelPath,
            this.colTreeID});
            this.treeList1.ContextMenuStrip = this.contextMenuStrip2;
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(3, 16);
            this.treeList1.Name = "treeList1";
            this.treeList1.Size = new System.Drawing.Size(406, 244);
            this.treeList1.TabIndex = 5;
            this.treeList1.DoubleClick += new System.EventHandler(this.treeList1_DoubleClick);
            // 
            // colTreeName
            // 
            this.colTreeName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTreeName.AppearanceHeader.Options.UseFont = true;
            this.colTreeName.AppearanceHeader.Options.UseTextOptions = true;
            this.colTreeName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTreeName.Caption = "Danh sách file";
            this.colTreeName.FieldName = "FileName";
            this.colTreeName.Name = "colTreeName";
            this.colTreeName.OptionsColumn.AllowEdit = false;
            this.colTreeName.OptionsColumn.AllowFocus = false;
            this.colTreeName.Visible = true;
            this.colTreeName.VisibleIndex = 0;
            this.colTreeName.Width = 210;
            // 
            // colTreeParentID
            // 
            this.colTreeParentID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTreeParentID.AppearanceHeader.Options.UseFont = true;
            this.colTreeParentID.AppearanceHeader.Options.UseTextOptions = true;
            this.colTreeParentID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTreeParentID.Caption = "ParentID";
            this.colTreeParentID.FieldName = "ParentID";
            this.colTreeParentID.Name = "colTreeParentID";
            this.colTreeParentID.OptionsColumn.AllowEdit = false;
            this.colTreeParentID.OptionsColumn.AllowFocus = false;
            this.colTreeParentID.Width = 141;
            // 
            // colTreeFilelPath
            // 
            this.colTreeFilelPath.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTreeFilelPath.AppearanceHeader.Options.UseFont = true;
            this.colTreeFilelPath.AppearanceHeader.Options.UseTextOptions = true;
            this.colTreeFilelPath.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTreeFilelPath.Caption = "FilePath";
            this.colTreeFilelPath.FieldName = "FilePath";
            this.colTreeFilelPath.Name = "colTreeFilelPath";
            // 
            // colTreeID
            // 
            this.colTreeID.Caption = "ID";
            this.colTreeID.FieldName = "ID";
            this.colTreeID.Name = "colTreeID";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDeleteFile});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(114, 26);
            // 
            // btnDeleteFile
            // 
            this.btnDeleteFile.Name = "btnDeleteFile";
            this.btnDeleteFile.Size = new System.Drawing.Size(113, 22);
            this.btnDeleteFile.Text = "Xóa file";
            this.btnDeleteFile.Click += new System.EventHandler(this.btnDeleteFile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.grdScan);
            this.groupBox1.Location = new System.Drawing.Point(1, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 225);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách file Scan";
            // 
            // grdScan
            // 
            this.grdScan.AllowDrop = true;
            this.grdScan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdScan.ContextMenuStrip = this.contextMenuStrip1;
            this.grdScan.Location = new System.Drawing.Point(3, 16);
            this.grdScan.MainView = this.grvScan;
            this.grdScan.Name = "grdScan";
            this.grdScan.Size = new System.Drawing.Size(403, 203);
            this.grdScan.TabIndex = 0;
            this.grdScan.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvScan});
            this.grdScan.DoubleClick += new System.EventHandler(this.grdScan_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xoaFileToolStripMenuItem,
            this.đôiTênToolStripMenuItem,
            this.diChuyênToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(128, 70);
            // 
            // xoaFileToolStripMenuItem
            // 
            this.xoaFileToolStripMenuItem.Name = "xoaFileToolStripMenuItem";
            this.xoaFileToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.xoaFileToolStripMenuItem.Text = "Xóa file";
            this.xoaFileToolStripMenuItem.Click += new System.EventHandler(this.xoaFileToolStripMenuItem_Click);
            // 
            // đôiTênToolStripMenuItem
            // 
            this.đôiTênToolStripMenuItem.Name = "đôiTênToolStripMenuItem";
            this.đôiTênToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.đôiTênToolStripMenuItem.Text = "Đổi tên";
            this.đôiTênToolStripMenuItem.Click += new System.EventHandler(this.đôiTênToolStripMenuItem_Click);
            // 
            // diChuyênToolStripMenuItem
            // 
            this.diChuyênToolStripMenuItem.Name = "diChuyênToolStripMenuItem";
            this.diChuyênToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.diChuyênToolStripMenuItem.Text = "Di chuyển";
            this.diChuyênToolStripMenuItem.Click += new System.EventHandler(this.diChuyênToolStripMenuItem_Click);
            // 
            // grvScan
            // 
            this.grvScan.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFileName,
            this.colFilePath});
            this.grvScan.GridControl = this.grdScan;
            this.grvScan.Name = "grvScan";
            this.grvScan.OptionsBehavior.Editable = false;
            this.grvScan.OptionsView.ShowGroupPanel = false;
            this.grvScan.DoubleClick += new System.EventHandler(this.grvScan_DoubleClick);
            // 
            // txtCode
            // 
            this.txtCode.EditValue = "";
            this.txtCode.Location = new System.Drawing.Point(450, 12);
            this.txtCode.Name = "txtCode";
            this.txtCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtCode.Properties.Appearance.Options.UseFont = true;
            this.txtCode.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCode.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtCode.Size = new System.Drawing.Size(343, 20);
            this.txtCode.TabIndex = 0;
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // ImgCollection
            // 
            this.ImgCollection.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImgCollection.ImageStream")));
            this.ImgCollection.TransparentColor = System.Drawing.Color.Transparent;
            this.ImgCollection.Images.SetKeyName(0, "1408539678_message_edit.png");
            this.ImgCollection.Images.SetKeyName(1, "1408602301_stock_folder-move.png");
            // 
            // mnuMenu
            // 
            this.mnuMenu.AutoSize = false;
            this.mnuMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.mnuMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnScanAll,
            this.toolStripSeparator2,
            this.btnRefresh,
            this.toolStripSeparator3,
            this.btnConfig,
            this.toolStripSeparator1,
            this.btnClose});
            this.mnuMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuMenu.Size = new System.Drawing.Size(1157, 42);
            this.mnuMenu.TabIndex = 29;
            this.mnuMenu.Text = "toolStrip2";
            // 
            // btnScanAll
            // 
            this.btnScanAll.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScanAll.Image = ((System.Drawing.Image)(resources.GetObject("btnScanAll.Image")));
            this.btnScanAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnScanAll.Name = "btnScanAll";
            this.btnScanAll.Size = new System.Drawing.Size(72, 33);
            this.btnScanAll.Tag = "";
            this.btnScanAll.Text = "&Đổi tên file";
            this.btnScanAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnScanAll.Click += new System.EventHandler(this.btnScanAll_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AutoSize = false;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 40);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(109, 33);
            this.btnRefresh.Tag = "";
            this.btnRefresh.Text = "Làm mới thư mục";
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.AutoSize = false;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 40);
            // 
            // btnConfig
            // 
            this.btnConfig.Image = ((System.Drawing.Image)(resources.GetObject("btnConfig.Image")));
            this.btnConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(53, 33);
            this.btnConfig.Tag = "";
            this.btnConfig.Text = "Cấu hình";
            this.btnConfig.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
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
            this.btnClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(44, 33);
            this.btnClose.Text = "Thoát";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(359, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Mã sản phẩm:";
            // 
            // rdbCokhi
            // 
            this.rdbCokhi.AutoSize = true;
            this.rdbCokhi.Checked = true;
            this.rdbCokhi.Location = new System.Drawing.Point(811, 15);
            this.rdbCokhi.Name = "rdbCokhi";
            this.rdbCokhi.Size = new System.Drawing.Size(57, 17);
            this.rdbCokhi.TabIndex = 31;
            this.rdbCokhi.TabStop = true;
            this.rdbCokhi.Text = "Cơ khí";
            this.rdbCokhi.UseVisualStyleBackColor = true;
            // 
            // rdbDien
            // 
            this.rdbDien.AutoSize = true;
            this.rdbDien.Location = new System.Drawing.Point(877, 15);
            this.rdbDien.Name = "rdbDien";
            this.rdbDien.Size = new System.Drawing.Size(47, 17);
            this.rdbDien.TabIndex = 31;
            this.rdbDien.Text = "Điện";
            this.rdbDien.UseVisualStyleBackColor = true;
            // 
            // frmRenameScanFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 546);
            this.Controls.Add(this.rdbCokhi);
            this.Controls.Add(this.rdbDien);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.mnuMenu);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frmRenameScanFile";
            this.Text = "Đổi tên file";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRenameScanFile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdScan)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvScan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn colFileName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraGrid.Columns.GridColumn colFilePath;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraGrid.GridControl grdScan;
        private DevExpress.XtraGrid.Views.Grid.GridView grvScan;
        private DevExpress.XtraEditors.TextEdit txtCode;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ImageList ImgCollection;
        private System.Windows.Forms.ToolStrip mnuMenu;
        private System.Windows.Forms.ToolStripButton btnScanAll;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTreeName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTreeParentID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTreeFilelPath;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTreeID;
        private System.Windows.Forms.ToolStripMenuItem xoaFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đôiTênToolStripMenuItem;
        private System.Windows.Forms.RadioButton rdbCokhi;
        private System.Windows.Forms.RadioButton rdbDien;
        private System.Windows.Forms.ToolStripMenuItem diChuyênToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem btnDeleteFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnConfig;

    }
}