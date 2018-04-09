namespace BMS
{
    partial class frmElectronicMaterial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmElectronicMaterial));
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.mnuMenu = new System.Windows.Forms.ToolStrip();
            this.btnDownloadFolder = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grvData = new System.Windows.Forms.DataGridView();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.mnuMenu.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
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
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // treeList1
            // 
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colTreePath,
            this.colTreeNumber,
            this.colTreeFileNumber,
            this.colTreeFullPath,
            this.colTreeID});
            this.treeList1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(0, 0);
            this.treeList1.Name = "treeList1";
            this.treeList1.Size = new System.Drawing.Size(387, 516);
            this.treeList1.TabIndex = 4;
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
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
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
            this.btnDownloadFile.Location = new System.Drawing.Point(380, 3);
            this.btnDownloadFile.Name = "btnDownloadFile";
            this.btnDownloadFile.Size = new System.Drawing.Size(76, 23);
            this.btnDownloadFile.TabIndex = 8;
            this.btnDownloadFile.Text = "Download";
            this.btnDownloadFile.Click += new System.EventHandler(this.btnDownloadFile_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(480, 9);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(379, 23);
            this.progressBar1.TabIndex = 166;
            this.progressBar1.Visible = false;
            // 
            // mnuMenu
            // 
            this.mnuMenu.AutoSize = false;
            this.mnuMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.mnuMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDownloadFolder,
            this.toolStripSeparator1,
            this.btnClose});
            this.mnuMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuMenu.Size = new System.Drawing.Size(861, 42);
            this.mnuMenu.TabIndex = 167;
            this.mnuMenu.Text = "toolStrip2";
            // 
            // btnDownloadFolder
            // 
            this.btnDownloadFolder.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownloadFolder.Image = ((System.Drawing.Image)(resources.GetObject("btnDownloadFolder.Image")));
            this.btnDownloadFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDownloadFolder.Name = "btnDownloadFolder";
            this.btnDownloadFolder.Size = new System.Drawing.Size(116, 33);
            this.btnDownloadFolder.Tag = "";
            this.btnDownloadFolder.Text = "Download thư mục";
            this.btnDownloadFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDownloadFolder.Click += new System.EventHandler(this.btnDownloadFolder_Click);
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
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(4, 45);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeList1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chkSelectAll);
            this.splitContainer1.Panel2.Controls.Add(this.grvData);
            this.splitContainer1.Panel2.Controls.Add(this.btnDownloadFile);
            this.splitContainer1.Size = new System.Drawing.Size(854, 518);
            this.splitContainer1.SplitterDistance = 389;
            this.splitContainer1.TabIndex = 165;
            // 
            // grvData
            // 
            this.grvData.AllowUserToAddRows = false;
            this.grvData.AllowUserToDeleteRows = false;
            this.grvData.AllowUserToResizeRows = false;
            this.grvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grvData.BackgroundColor = System.Drawing.Color.White;
            this.grvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheck,
            this.colFileName,
            this.colSize,
            this.colDate,
            this.colFullFilePath});
            this.grvData.Location = new System.Drawing.Point(3, 29);
            this.grvData.Name = "grvData";
            this.grvData.RowHeadersVisible = false;
            this.grvData.Size = new System.Drawing.Size(453, 484);
            this.grvData.TabIndex = 5;
            // 
            // colCheck
            // 
            this.colCheck.DataPropertyName = "check";
            this.colCheck.FillWeight = 30F;
            this.colCheck.HeaderText = "";
            this.colCheck.Name = "colCheck";
            // 
            // colFileName
            // 
            this.colFileName.DataPropertyName = "FileName";
            this.colFileName.FillWeight = 127.1574F;
            this.colFileName.HeaderText = "Tên file";
            this.colFileName.Name = "colFileName";
            this.colFileName.ReadOnly = true;
            // 
            // colSize
            // 
            this.colSize.DataPropertyName = "Size";
            this.colSize.FillWeight = 127.1574F;
            this.colSize.HeaderText = "Size";
            this.colSize.Name = "colSize";
            this.colSize.ReadOnly = true;
            // 
            // colDate
            // 
            this.colDate.DataPropertyName = "CreatedDate";
            this.colDate.HeaderText = "Ngày tạo";
            this.colDate.Name = "colDate";
            // 
            // frmElectronicMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 564);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.mnuMenu);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmElectronicMaterial";
            this.Text = "TÀI LIỆU ĐIỆN TỬ";
            this.Load += new System.EventHandler(this.frmElectronicMaterial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ToolStrip mnuMenu;
        private System.Windows.Forms.ToolStripButton btnDownloadFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView grvData;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
    }
}