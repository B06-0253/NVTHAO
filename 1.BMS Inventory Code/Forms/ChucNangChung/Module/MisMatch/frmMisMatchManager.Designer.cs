namespace BMS
{
    partial class frmMisMatchManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMisMatchManager));
            this.colProjectCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mnuMenu = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTK_XacNhan = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnKCS_XacNhan = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnConfirmTemp = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnConfirm = new System.Windows.Forms.ToolStripButton();
            this.colDateCreated = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colModule = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYearCreate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMisMatchUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompleteTimeKCS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatusTKText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.gửiMailBáoKhôngPhùHợpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gửiMailKhiĐãKhắcPhụcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kCSBỏXácNhậnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thiếtKếBỏXácNhậnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hủyXácNhậnTạmThờiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnShowImage = new System.Windows.Forms.ToolStripMenuItem();
            this.grvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConfirm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserFind = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserFindText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModuleCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConfirmSendMailTK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConfirmSendMailKCS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatusKCS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConfirmTemp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatusText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            this.SuspendLayout();
            // 
            // colProjectCode
            // 
            this.colProjectCode.AppearanceCell.Options.UseTextOptions = true;
            this.colProjectCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colProjectCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colProjectCode.AppearanceHeader.Options.UseFont = true;
            this.colProjectCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colProjectCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProjectCode.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colProjectCode.Caption = "Mã dự án";
            this.colProjectCode.FieldName = "ProjectCode";
            this.colProjectCode.Name = "colProjectCode";
            this.colProjectCode.OptionsColumn.AllowEdit = false;
            this.colProjectCode.OptionsColumn.AllowSize = false;
            this.colProjectCode.Visible = true;
            this.colProjectCode.VisibleIndex = 4;
            this.colProjectCode.Width = 72;
            // 
            // mnuMenu
            // 
            this.mnuMenu.AutoSize = false;
            this.mnuMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.mnuMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.toolStripSeparator5,
            this.btnEdit,
            this.toolStripSeparator6,
            this.btnDelete,
            this.toolStripSeparator1,
            this.btnTK_XacNhan,
            this.toolStripSeparator2,
            this.btnKCS_XacNhan,
            this.toolStripSeparator3,
            this.btnConfirmTemp,
            this.toolStripSeparator4,
            this.btnConfirm});
            this.mnuMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuMenu.Size = new System.Drawing.Size(1020, 42);
            this.mnuMenu.TabIndex = 20;
            this.mnuMenu.Text = "toolStrip2";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(29, 33);
            this.btnAdd.Tag = "frmMisMatchManager_Add";
            this.btnAdd.Text = "Tạo";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(30, 33);
            this.btnEdit.Tag = "frmMisMatchManager_Edit";
            this.btnEdit.Text = "Sửa";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(29, 33);
            this.btnDelete.Tag = "frmMisMatchManager_Delete";
            this.btnDelete.Text = "Xóa";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // btnTK_XacNhan
            // 
            this.btnTK_XacNhan.Image = ((System.Drawing.Image)(resources.GetObject("btnTK_XacNhan.Image")));
            this.btnTK_XacNhan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTK_XacNhan.Name = "btnTK_XacNhan";
            this.btnTK_XacNhan.Size = new System.Drawing.Size(70, 33);
            this.btnTK_XacNhan.Tag = "frmMisMatchManager_TKConfirm";
            this.btnTK_XacNhan.Text = "TK Xác nhận";
            this.btnTK_XacNhan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnTK_XacNhan.Click += new System.EventHandler(this.btnTK_XacNhan_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AutoSize = false;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 40);
            // 
            // btnKCS_XacNhan
            // 
            this.btnKCS_XacNhan.Image = ((System.Drawing.Image)(resources.GetObject("btnKCS_XacNhan.Image")));
            this.btnKCS_XacNhan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnKCS_XacNhan.Name = "btnKCS_XacNhan";
            this.btnKCS_XacNhan.Size = new System.Drawing.Size(77, 33);
            this.btnKCS_XacNhan.Tag = "frmMisMatchManager_KCSConfirm";
            this.btnKCS_XacNhan.Text = "KCS xác nhận";
            this.btnKCS_XacNhan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnKCS_XacNhan.Click += new System.EventHandler(this.btnKCS_XacNhan_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.AutoSize = false;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 40);
            // 
            // btnConfirmTemp
            // 
            this.btnConfirmTemp.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirmTemp.Image")));
            this.btnConfirmTemp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConfirmTemp.Name = "btnConfirmTemp";
            this.btnConfirmTemp.Size = new System.Drawing.Size(97, 33);
            this.btnConfirmTemp.Tag = "frmMisMatchManager_ConfirmTemp";
            this.btnConfirmTemp.Text = "Xác nhận tạm thời";
            this.btnConfirmTemp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnConfirmTemp.Click += new System.EventHandler(this.btnConfirmTemp_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.AutoSize = false;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 40);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirm.Image")));
            this.btnConfirm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(106, 33);
            this.btnConfirm.Tag = "frmMisMatchManager_ConfirmUser";
            this.btnConfirm.Text = "Xác nhận khắc phục";
            this.btnConfirm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // colDateCreated
            // 
            this.colDateCreated.AppearanceCell.Options.UseTextOptions = true;
            this.colDateCreated.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDateCreated.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colDateCreated.AppearanceHeader.Options.UseFont = true;
            this.colDateCreated.AppearanceHeader.Options.UseTextOptions = true;
            this.colDateCreated.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDateCreated.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDateCreated.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDateCreated.Caption = "Ngày cập nhật";
            this.colDateCreated.FieldName = "CreatedDate";
            this.colDateCreated.Name = "colDateCreated";
            this.colDateCreated.OptionsColumn.AllowEdit = false;
            this.colDateCreated.OptionsColumn.AllowSize = false;
            this.colDateCreated.Visible = true;
            this.colDateCreated.VisibleIndex = 1;
            this.colDateCreated.Width = 63;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Appearance.Options.UseTextOptions = true;
            this.repositoryItemMemoEdit1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // colModule
            // 
            this.colModule.AppearanceCell.Options.UseTextOptions = true;
            this.colModule.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colModule.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colModule.AppearanceHeader.Options.UseFont = true;
            this.colModule.AppearanceHeader.Options.UseTextOptions = true;
            this.colModule.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colModule.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colModule.Caption = "Module";
            this.colModule.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colModule.FieldName = "Module";
            this.colModule.Name = "colModule";
            this.colModule.OptionsColumn.AllowEdit = false;
            this.colModule.OptionsColumn.AllowSize = false;
            this.colModule.Visible = true;
            this.colModule.VisibleIndex = 5;
            this.colModule.Width = 228;
            // 
            // colYearCreate
            // 
            this.colYearCreate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colYearCreate.AppearanceHeader.Options.UseFont = true;
            this.colYearCreate.AppearanceHeader.Options.UseTextOptions = true;
            this.colYearCreate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colYearCreate.Caption = "Năm";
            this.colYearCreate.FieldName = "YearCreate";
            this.colYearCreate.Name = "colYearCreate";
            this.colYearCreate.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "ID", "")});
            // 
            // colMisMatchUser
            // 
            this.colMisMatchUser.AppearanceCell.Options.UseTextOptions = true;
            this.colMisMatchUser.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMisMatchUser.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMisMatchUser.AppearanceHeader.Options.UseFont = true;
            this.colMisMatchUser.AppearanceHeader.Options.UseTextOptions = true;
            this.colMisMatchUser.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMisMatchUser.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colMisMatchUser.Caption = "Người khắc phục";
            this.colMisMatchUser.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colMisMatchUser.FieldName = "MisMatchUser";
            this.colMisMatchUser.Name = "colMisMatchUser";
            this.colMisMatchUser.OptionsColumn.AllowEdit = false;
            this.colMisMatchUser.OptionsColumn.AllowSize = false;
            this.colMisMatchUser.Visible = true;
            this.colMisMatchUser.VisibleIndex = 7;
            this.colMisMatchUser.Width = 113;
            // 
            // colCompleteTimeKCS
            // 
            this.colCompleteTimeKCS.AppearanceCell.Options.UseTextOptions = true;
            this.colCompleteTimeKCS.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCompleteTimeKCS.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCompleteTimeKCS.AppearanceHeader.Options.UseFont = true;
            this.colCompleteTimeKCS.AppearanceHeader.Options.UseTextOptions = true;
            this.colCompleteTimeKCS.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCompleteTimeKCS.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCompleteTimeKCS.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCompleteTimeKCS.Caption = "Thời gian hoàn thành";
            this.colCompleteTimeKCS.FieldName = "CompleteTime";
            this.colCompleteTimeKCS.Name = "colCompleteTimeKCS";
            this.colCompleteTimeKCS.OptionsColumn.AllowEdit = false;
            this.colCompleteTimeKCS.OptionsColumn.AllowSize = false;
            this.colCompleteTimeKCS.Visible = true;
            this.colCompleteTimeKCS.VisibleIndex = 3;
            // 
            // colStatusTKText
            // 
            this.colStatusTKText.AppearanceCell.Options.UseTextOptions = true;
            this.colStatusTKText.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStatusTKText.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colStatusTKText.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colStatusTKText.AppearanceHeader.Options.UseFont = true;
            this.colStatusTKText.AppearanceHeader.Options.UseTextOptions = true;
            this.colStatusTKText.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStatusTKText.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colStatusTKText.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colStatusTKText.Caption = "Tình trạng khắc phục";
            this.colStatusTKText.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colStatusTKText.FieldName = "StatusTK";
            this.colStatusTKText.Name = "colStatusTKText";
            this.colStatusTKText.OptionsColumn.AllowEdit = false;
            this.colStatusTKText.OptionsColumn.AllowSize = false;
            this.colStatusTKText.Visible = true;
            this.colStatusTKText.VisibleIndex = 9;
            this.colStatusTKText.Width = 68;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.DisplayValueChecked = "\"1\"";
            this.repositoryItemCheckEdit1.DisplayValueUnchecked = "\"0\"";
            this.repositoryItemCheckEdit1.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // grdData
            // 
            this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdData.ContextMenuStrip = this.contextMenuStrip1;
            this.grdData.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdData.Location = new System.Drawing.Point(0, 44);
            this.grdData.MainView = this.grvData;
            this.grdData.Name = "grdData";
            this.grdData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemMemoEdit1});
            this.grdData.Size = new System.Drawing.Size(1020, 421);
            this.grdData.TabIndex = 21;
            this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvData});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gửiMailBáoKhôngPhùHợpToolStripMenuItem,
            this.gửiMailKhiĐãKhắcPhụcToolStripMenuItem,
            this.kCSBỏXácNhậnToolStripMenuItem,
            this.thiếtKếBỏXácNhậnToolStripMenuItem,
            this.hủyXácNhậnTạmThờiToolStripMenuItem,
            this.btnShowImage});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(227, 158);
            // 
            // gửiMailBáoKhôngPhùHợpToolStripMenuItem
            // 
            this.gửiMailBáoKhôngPhùHợpToolStripMenuItem.Name = "gửiMailBáoKhôngPhùHợpToolStripMenuItem";
            this.gửiMailBáoKhôngPhùHợpToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.gửiMailBáoKhôngPhùHợpToolStripMenuItem.Tag = "frmMisMatchManager_MailReport";
            this.gửiMailBáoKhôngPhùHợpToolStripMenuItem.Text = "Gửi mail báo không phù hợp";
            this.gửiMailBáoKhôngPhùHợpToolStripMenuItem.Click += new System.EventHandler(this.gửiMailBáoKhôngPhùHợpToolStripMenuItem_Click);
            // 
            // gửiMailKhiĐãKhắcPhụcToolStripMenuItem
            // 
            this.gửiMailKhiĐãKhắcPhụcToolStripMenuItem.Name = "gửiMailKhiĐãKhắcPhụcToolStripMenuItem";
            this.gửiMailKhiĐãKhắcPhụcToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.gửiMailKhiĐãKhắcPhụcToolStripMenuItem.Tag = "frmMisMatchManager_MailKP";
            this.gửiMailKhiĐãKhắcPhụcToolStripMenuItem.Text = "Gửi mail khi đã khắc phục";
            this.gửiMailKhiĐãKhắcPhụcToolStripMenuItem.Click += new System.EventHandler(this.gửiMailKhiĐãKhắcPhụcToolStripMenuItem_Click);
            // 
            // kCSBỏXácNhậnToolStripMenuItem
            // 
            this.kCSBỏXácNhậnToolStripMenuItem.Name = "kCSBỏXácNhậnToolStripMenuItem";
            this.kCSBỏXácNhậnToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.kCSBỏXácNhậnToolStripMenuItem.Tag = "frmMisMatchManager_KCSConfirm";
            this.kCSBỏXácNhậnToolStripMenuItem.Text = "KCS hủy xác nhận";
            this.kCSBỏXácNhậnToolStripMenuItem.Click += new System.EventHandler(this.kCSBỏXácNhậnToolStripMenuItem_Click);
            // 
            // thiếtKếBỏXácNhậnToolStripMenuItem
            // 
            this.thiếtKếBỏXácNhậnToolStripMenuItem.Name = "thiếtKếBỏXácNhậnToolStripMenuItem";
            this.thiếtKếBỏXácNhậnToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.thiếtKếBỏXácNhậnToolStripMenuItem.Tag = "frmMisMatchManager_TKConfirm";
            this.thiếtKếBỏXácNhậnToolStripMenuItem.Text = "Thiết kế hủy xác nhận";
            this.thiếtKếBỏXácNhậnToolStripMenuItem.Click += new System.EventHandler(this.thiếtKếBỏXácNhậnToolStripMenuItem_Click);
            // 
            // hủyXácNhậnTạmThờiToolStripMenuItem
            // 
            this.hủyXácNhậnTạmThờiToolStripMenuItem.Name = "hủyXácNhậnTạmThờiToolStripMenuItem";
            this.hủyXácNhậnTạmThờiToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.hủyXácNhậnTạmThờiToolStripMenuItem.Tag = "frmMisMatchManager_ConfirmTemp";
            this.hủyXácNhậnTạmThờiToolStripMenuItem.Text = "Hủy xác nhận tạm thời";
            this.hủyXácNhậnTạmThờiToolStripMenuItem.Click += new System.EventHandler(this.hủyXácNhậnTạmThờiToolStripMenuItem_Click);
            // 
            // btnShowImage
            // 
            this.btnShowImage.Name = "btnShowImage";
            this.btnShowImage.Size = new System.Drawing.Size(226, 22);
            this.btnShowImage.Text = "Xem ảnh";
            this.btnShowImage.Click += new System.EventHandler(this.btnShowImage_Click);
            // 
            // grvData
            // 
            this.grvData.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvData.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvData.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvData.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grvData.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvData.ColumnPanelRowHeight = 50;
            this.grvData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colCode,
            this.colDes,
            this.colModule,
            this.colDateCreated,
            this.colProjectCode,
            this.colCompleteTimeKCS,
            this.colStatusTKText,
            this.colYearCreate,
            this.colMisMatchUser,
            this.colCost,
            this.colConfirm,
            this.colCreatedBy,
            this.colUserFind,
            this.colUserFindText,
            this.colModuleCode,
            this.colConfirmSendMailTK,
            this.colConfirmSendMailKCS,
            this.colStatusKCS,
            this.colConfirmTemp});
            this.grvData.GridControl = this.grdData;
            this.grvData.GroupCount = 1;
            this.grvData.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "Code", null, "")});
            this.grvData.Name = "grvData";
            this.grvData.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvData.OptionsCustomization.AllowRowSizing = true;
            this.grvData.OptionsFind.AlwaysVisible = true;
            this.grvData.OptionsFind.ShowCloseButton = false;
            this.grvData.OptionsSelection.MultiSelect = true;
            this.grvData.OptionsView.ColumnAutoWidth = false;
            this.grvData.OptionsView.RowAutoHeight = true;
            this.grvData.OptionsView.ShowAutoFilterRow = true;
            this.grvData.OptionsView.ShowFooter = true;
            this.grvData.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colYearCreate, DevExpress.Data.ColumnSortOrder.Descending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colID, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            // 
            // colCode
            // 
            this.colCode.AppearanceCell.Options.UseTextOptions = true;
            this.colCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCode.AppearanceHeader.Options.UseFont = true;
            this.colCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCode.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCode.Caption = "Mã";
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.OptionsColumn.AllowEdit = false;
            this.colCode.OptionsColumn.AllowSize = false;
            this.colCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            this.colCode.Width = 100;
            // 
            // colDes
            // 
            this.colDes.AppearanceCell.Options.UseTextOptions = true;
            this.colDes.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDes.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colDes.AppearanceHeader.Options.UseFont = true;
            this.colDes.AppearanceHeader.Options.UseTextOptions = true;
            this.colDes.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDes.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDes.Caption = "Mô tả";
            this.colDes.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colDes.FieldName = "Description";
            this.colDes.Name = "colDes";
            this.colDes.OptionsColumn.AllowEdit = false;
            this.colDes.OptionsColumn.AllowSize = false;
            this.colDes.Visible = true;
            this.colDes.VisibleIndex = 6;
            this.colDes.Width = 201;
            // 
            // colCost
            // 
            this.colCost.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCost.AppearanceHeader.Options.UseFont = true;
            this.colCost.AppearanceHeader.Options.UseTextOptions = true;
            this.colCost.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCost.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCost.Caption = "Chi phí";
            this.colCost.FieldName = "Cost";
            this.colCost.Name = "colCost";
            this.colCost.OptionsColumn.AllowEdit = false;
            this.colCost.OptionsColumn.AllowSize = false;
            this.colCost.Visible = true;
            this.colCost.VisibleIndex = 12;
            // 
            // colConfirm
            // 
            this.colConfirm.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colConfirm.AppearanceHeader.Options.UseFont = true;
            this.colConfirm.AppearanceHeader.Options.UseTextOptions = true;
            this.colConfirm.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colConfirm.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colConfirm.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colConfirm.Caption = "Thiết kế Xác nhận";
            this.colConfirm.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colConfirm.FieldName = "ConfirmTK";
            this.colConfirm.Name = "colConfirm";
            this.colConfirm.OptionsColumn.AllowEdit = false;
            this.colConfirm.OptionsColumn.AllowSize = false;
            this.colConfirm.Visible = true;
            this.colConfirm.VisibleIndex = 8;
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.AppearanceCell.Options.UseTextOptions = true;
            this.colCreatedBy.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCreatedBy.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCreatedBy.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCreatedBy.AppearanceHeader.Options.UseFont = true;
            this.colCreatedBy.Caption = "Người tạo";
            this.colCreatedBy.FieldName = "CreatedBy";
            this.colCreatedBy.Name = "colCreatedBy";
            this.colCreatedBy.OptionsColumn.AllowEdit = false;
            this.colCreatedBy.Visible = true;
            this.colCreatedBy.VisibleIndex = 2;
            // 
            // colUserFind
            // 
            this.colUserFind.Caption = "UserFind";
            this.colUserFind.FieldName = "UserFind";
            this.colUserFind.Name = "colUserFind";
            // 
            // colUserFindText
            // 
            this.colUserFindText.AppearanceCell.Options.UseTextOptions = true;
            this.colUserFindText.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colUserFindText.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colUserFindText.AppearanceHeader.Options.UseFont = true;
            this.colUserFindText.AppearanceHeader.Options.UseTextOptions = true;
            this.colUserFindText.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUserFindText.Caption = "Người phát hiện";
            this.colUserFindText.FieldName = "FullName";
            this.colUserFindText.Name = "colUserFindText";
            this.colUserFindText.OptionsColumn.AllowEdit = false;
            this.colUserFindText.Visible = true;
            this.colUserFindText.VisibleIndex = 13;
            // 
            // colModuleCode
            // 
            this.colModuleCode.Caption = "ModuleCode";
            this.colModuleCode.FieldName = "ModuleCode";
            this.colModuleCode.Name = "colModuleCode";
            // 
            // colConfirmSendMailTK
            // 
            this.colConfirmSendMailTK.AppearanceCell.Options.UseTextOptions = true;
            this.colConfirmSendMailTK.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colConfirmSendMailTK.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colConfirmSendMailTK.AppearanceHeader.Options.UseFont = true;
            this.colConfirmSendMailTK.Caption = "Thiết kế xác nhận";
            this.colConfirmSendMailTK.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colConfirmSendMailTK.FieldName = "ConfirmSendMailTK";
            this.colConfirmSendMailTK.Name = "colConfirmSendMailTK";
            this.colConfirmSendMailTK.OptionsColumn.AllowEdit = false;
            this.colConfirmSendMailTK.Visible = true;
            this.colConfirmSendMailTK.VisibleIndex = 14;
            // 
            // colConfirmSendMailKCS
            // 
            this.colConfirmSendMailKCS.AppearanceCell.Options.UseTextOptions = true;
            this.colConfirmSendMailKCS.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colConfirmSendMailKCS.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colConfirmSendMailKCS.AppearanceHeader.Options.UseFont = true;
            this.colConfirmSendMailKCS.Caption = "Người tạo xác nhận";
            this.colConfirmSendMailKCS.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colConfirmSendMailKCS.FieldName = "ConfirmSendMailKCS";
            this.colConfirmSendMailKCS.Name = "colConfirmSendMailKCS";
            this.colConfirmSendMailKCS.OptionsColumn.AllowEdit = false;
            this.colConfirmSendMailKCS.Visible = true;
            this.colConfirmSendMailKCS.VisibleIndex = 15;
            // 
            // colStatusKCS
            // 
            this.colStatusKCS.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colStatusKCS.AppearanceHeader.Options.UseFont = true;
            this.colStatusKCS.AppearanceHeader.Options.UseTextOptions = true;
            this.colStatusKCS.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStatusKCS.Caption = "KCS";
            this.colStatusKCS.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colStatusKCS.FieldName = "StatusKCS";
            this.colStatusKCS.Name = "colStatusKCS";
            this.colStatusKCS.OptionsColumn.AllowEdit = false;
            this.colStatusKCS.Visible = true;
            this.colStatusKCS.VisibleIndex = 10;
            // 
            // colConfirmTemp
            // 
            this.colConfirmTemp.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colConfirmTemp.AppearanceHeader.Options.UseFont = true;
            this.colConfirmTemp.AppearanceHeader.Options.UseTextOptions = true;
            this.colConfirmTemp.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colConfirmTemp.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colConfirmTemp.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colConfirmTemp.Caption = "Xác nhận tạm thời";
            this.colConfirmTemp.FieldName = "ConfirmTemp";
            this.colConfirmTemp.Name = "colConfirmTemp";
            this.colConfirmTemp.OptionsColumn.AllowEdit = false;
            this.colConfirmTemp.Visible = true;
            this.colConfirmTemp.VisibleIndex = 11;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn1.Caption = "Tình trạng khắc phục";
            this.gridColumn1.FieldName = "StatusText";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 6;
            // 
            // colStatusText
            // 
            this.colStatusText.AppearanceCell.Options.UseTextOptions = true;
            this.colStatusText.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStatusText.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colStatusText.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colStatusText.AppearanceHeader.Options.UseFont = true;
            this.colStatusText.AppearanceHeader.Options.UseTextOptions = true;
            this.colStatusText.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStatusText.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colStatusText.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colStatusText.Caption = "KCS";
            this.colStatusText.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colStatusText.FieldName = "Status";
            this.colStatusText.Name = "colStatusText";
            this.colStatusText.OptionsColumn.AllowEdit = false;
            this.colStatusText.OptionsColumn.AllowSize = false;
            this.colStatusText.Visible = true;
            this.colStatusText.VisibleIndex = 7;
            this.colStatusText.Width = 59;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn2.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn2.Caption = "KCS";
            this.gridColumn2.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn2.FieldName = "Status";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowSize = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 9;
            this.gridColumn2.Width = 59;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn3.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn3.Caption = "KCS";
            this.gridColumn3.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumn3.FieldName = "Status";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowSize = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 9;
            this.gridColumn3.Width = 59;
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 23);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 23);
            // 
            // frmMisMatchManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 467);
            this.Controls.Add(this.mnuMenu);
            this.Controls.Add(this.grdData);
            this.Name = "frmMisMatchManager";
            this.Text = "BÁO CÁO SỰ KHÔNG PHÙ HỢP";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMisMatchManager_Load);
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn colProjectCode;
        private System.Windows.Forms.ToolStrip mnuMenu;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private DevExpress.XtraGrid.Columns.GridColumn colDateCreated;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colModule;
        private DevExpress.XtraGrid.Columns.GridColumn colYearCreate;
        private DevExpress.XtraGrid.Columns.GridColumn colMisMatchUser;
        private DevExpress.XtraGrid.Columns.GridColumn colCompleteTimeKCS;
        private DevExpress.XtraGrid.Columns.GridColumn colStatusTKText;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.GridControl grdData;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private DevExpress.XtraGrid.Views.Grid.GridView grvData;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDes;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn colStatusText;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn colCost;
        private DevExpress.XtraGrid.Columns.GridColumn colConfirm;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnTK_XacNhan;
        private System.Windows.Forms.ToolStripMenuItem gửiMailBáoKhôngPhùHợpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gửiMailKhiĐãKhắcPhụcToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colUserFind;
        private DevExpress.XtraGrid.Columns.GridColumn colUserFindText;
        private DevExpress.XtraGrid.Columns.GridColumn colModuleCode;
        private DevExpress.XtraGrid.Columns.GridColumn colConfirmSendMailTK;
        private DevExpress.XtraGrid.Columns.GridColumn colConfirmSendMailKCS;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnKCS_XacNhan;
        private DevExpress.XtraGrid.Columns.GridColumn colStatusKCS;
        private System.Windows.Forms.ToolStripMenuItem kCSBỏXácNhậnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thiếtKếBỏXácNhậnToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnConfirmTemp;
        private System.Windows.Forms.ToolStripMenuItem hủyXácNhậnTạmThờiToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn colConfirmTemp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnConfirm;
        private System.Windows.Forms.ToolStripMenuItem btnShowImage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    }
}