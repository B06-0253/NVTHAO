namespace BMS
{
    partial class frmQuotationManagementKD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuotationManagementKD));
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.colStatusText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colIsApproved = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.mnuMenu = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnQuotationDetailKD = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReportKD = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNewSX = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReportSX = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnApprovedKD = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnApprovedSX = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReportProductGroup = new System.Windows.Forms.ToolStripButton();
            this.colDeliveryTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.btnLoadData = new DevExpress.XtraEditors.SimpleButton();
            this.colDName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.hủyDuyệtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hủyDuyệtSXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProjectCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerCodeF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerNameF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalVAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalTPA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalHD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalReal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalProfitTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalProfitQD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalPB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalNC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalNC_KD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalXL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalCustomer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalDP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.mnuMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            this.SuspendLayout();
            // 
            // cboYear
            // 
            this.cboYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(533, 54);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(134, 28);
            this.cboYear.TabIndex = 253;
            // 
            // colStatusText
            // 
            this.colStatusText.AppearanceCell.Options.UseTextOptions = true;
            this.colStatusText.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colStatusText.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colStatusText.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colStatusText.AppearanceHeader.Options.UseFont = true;
            this.colStatusText.AppearanceHeader.Options.UseTextOptions = true;
            this.colStatusText.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStatusText.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colStatusText.Caption = "Trạng thái";
            this.colStatusText.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colStatusText.FieldName = "StatusText";
            this.colStatusText.Name = "colStatusText";
            this.colStatusText.OptionsColumn.AllowEdit = false;
            this.colStatusText.Visible = true;
            this.colStatusText.VisibleIndex = 1;
            this.colStatusText.Width = 172;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Appearance.Options.UseTextOptions = true;
            this.repositoryItemMemoEdit1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // colIsApproved
            // 
            this.colIsApproved.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colIsApproved.AppearanceHeader.Options.UseFont = true;
            this.colIsApproved.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsApproved.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsApproved.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colIsApproved.Caption = "Duyệt";
            this.colIsApproved.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colIsApproved.FieldName = "IsApproved";
            this.colIsApproved.Name = "colIsApproved";
            this.colIsApproved.OptionsColumn.AllowEdit = false;
            this.colIsApproved.Visible = true;
            this.colIsApproved.VisibleIndex = 0;
            this.colIsApproved.Width = 56;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // mnuMenu
            // 
            this.mnuMenu.AutoSize = false;
            this.mnuMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.mnuMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.toolStripSeparator9,
            this.btnEdit,
            this.toolStripSeparator8,
            this.btnDelete,
            this.toolStripSeparator6,
            this.btnQuotationDetailKD,
            this.toolStripSeparator4,
            this.btnReportKD,
            this.toolStripSeparator2,
            this.btnNewSX,
            this.toolStripSeparator5,
            this.btnReportSX,
            this.toolStripSeparator1,
            this.btnApprovedKD,
            this.toolStripSeparator7,
            this.btnApprovedSX,
            this.toolStripSeparator3,
            this.btnReportProductGroup});
            this.mnuMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuMenu.Size = new System.Drawing.Size(1545, 42);
            this.mnuMenu.TabIndex = 250;
            this.mnuMenu.Text = "toolStrip2";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(76, 33);
            this.btnAdd.Tag = "frmQuotationManagement_Add";
            this.btnAdd.Text = "&Tạo báo giá";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 23);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(77, 33);
            this.btnEdit.Tag = "frmQuotationManagement_Edit";
            this.btnEdit.Text = "Sửa báo giá";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 23);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(76, 33);
            this.btnDelete.Tag = "frmQuotationManagement_Delete";
            this.btnDelete.Text = "Xóa báo giá";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.AutoSize = false;
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 40);
            // 
            // btnQuotationDetailKD
            // 
            this.btnQuotationDetailKD.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuotationDetailKD.Image = ((System.Drawing.Image)(resources.GetObject("btnQuotationDetailKD.Image")));
            this.btnQuotationDetailKD.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnQuotationDetailKD.Name = "btnQuotationDetailKD";
            this.btnQuotationDetailKD.Size = new System.Drawing.Size(130, 33);
            this.btnQuotationDetailKD.Tag = "frmQuotationManagementKD_ListModuleKD";
            this.btnQuotationDetailKD.Text = "Danh sách thiết bị KD";
            this.btnQuotationDetailKD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnQuotationDetailKD.Click += new System.EventHandler(this.btnQuotationDetailKD_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
            // 
            // btnReportKD
            // 
            this.btnReportKD.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportKD.Image = ((System.Drawing.Image)(resources.GetObject("btnReportKD.Image")));
            this.btnReportKD.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReportKD.Name = "btnReportKD";
            this.btnReportKD.Size = new System.Drawing.Size(73, 33);
            this.btnReportKD.Tag = "frmQuotationManagementKD_ReportKD";
            this.btnReportKD.Text = "Báo cáo KD";
            this.btnReportKD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnReportKD.Click += new System.EventHandler(this.btnReportKD_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AutoSize = false;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 40);
            // 
            // btnNewSX
            // 
            this.btnNewSX.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewSX.Image = ((System.Drawing.Image)(resources.GetObject("btnNewSX.Image")));
            this.btnNewSX.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewSX.Name = "btnNewSX";
            this.btnNewSX.Size = new System.Drawing.Size(129, 33);
            this.btnNewSX.Tag = "frmQuotationManagementKD_ListModuleSX";
            this.btnNewSX.Text = "Danh sách thiết bị SX";
            this.btnNewSX.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNewSX.Click += new System.EventHandler(this.btnNewSX_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 23);
            // 
            // btnReportSX
            // 
            this.btnReportSX.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportSX.Image = ((System.Drawing.Image)(resources.GetObject("btnReportSX.Image")));
            this.btnReportSX.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReportSX.Name = "btnReportSX";
            this.btnReportSX.Size = new System.Drawing.Size(72, 33);
            this.btnReportSX.Tag = "frmQuotationManagementKD_ReportSX";
            this.btnReportSX.Text = "Báo cáo SX";
            this.btnReportSX.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnReportSX.Click += new System.EventHandler(this.btnReportSX_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // btnApprovedKD
            // 
            this.btnApprovedKD.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApprovedKD.Image = ((System.Drawing.Image)(resources.GetObject("btnApprovedKD.Image")));
            this.btnApprovedKD.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnApprovedKD.Name = "btnApprovedKD";
            this.btnApprovedKD.Size = new System.Drawing.Size(63, 33);
            this.btnApprovedKD.Tag = "frmQuotationManagementKD_ApprovedKD";
            this.btnApprovedKD.Text = "Duyệt KD";
            this.btnApprovedKD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnApprovedKD.Click += new System.EventHandler(this.btnApprovedKD_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 23);
            // 
            // btnApprovedSX
            // 
            this.btnApprovedSX.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApprovedSX.Image = ((System.Drawing.Image)(resources.GetObject("btnApprovedSX.Image")));
            this.btnApprovedSX.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnApprovedSX.Name = "btnApprovedSX";
            this.btnApprovedSX.Size = new System.Drawing.Size(62, 33);
            this.btnApprovedSX.Tag = "frmQuotationManagementKD_ApprovedSX";
            this.btnApprovedSX.Text = "Duyệt SX";
            this.btnApprovedSX.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnApprovedSX.Click += new System.EventHandler(this.btnApprovedSX_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
            // 
            // btnReportProductGroup
            // 
            this.btnReportProductGroup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportProductGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnReportProductGroup.Image")));
            this.btnReportProductGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReportProductGroup.Name = "btnReportProductGroup";
            this.btnReportProductGroup.Size = new System.Drawing.Size(171, 33);
            this.btnReportProductGroup.Tag = "";
            this.btnReportProductGroup.Text = "Báo cáo theo ngành hàng KD";
            this.btnReportProductGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnReportProductGroup.Visible = false;
            // 
            // colDeliveryTime
            // 
            this.colDeliveryTime.AppearanceCell.Options.UseTextOptions = true;
            this.colDeliveryTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDeliveryTime.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDeliveryTime.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colDeliveryTime.AppearanceHeader.Options.UseFont = true;
            this.colDeliveryTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colDeliveryTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDeliveryTime.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDeliveryTime.Caption = "Thời gian giao hàng";
            this.colDeliveryTime.FieldName = "DeliveryTime";
            this.colDeliveryTime.Name = "colDeliveryTime";
            this.colDeliveryTime.OptionsColumn.AllowEdit = false;
            this.colDeliveryTime.Visible = true;
            this.colDeliveryTime.VisibleIndex = 9;
            this.colDeliveryTime.Width = 70;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(500, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 254;
            this.label7.Text = "Năm";
            // 
            // btnLoadData
            // 
            this.btnLoadData.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnLoadData.Appearance.Options.UseFont = true;
            this.btnLoadData.Location = new System.Drawing.Point(673, 54);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(75, 28);
            this.btnLoadData.TabIndex = 252;
            this.btnLoadData.Text = "Tải dữ liệu";
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // colDName
            // 
            this.colDName.AppearanceCell.Options.UseTextOptions = true;
            this.colDName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colDName.AppearanceHeader.Options.UseFont = true;
            this.colDName.AppearanceHeader.Options.UseTextOptions = true;
            this.colDName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDName.Caption = "Phòng phụ trách";
            this.colDName.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colDName.FieldName = "DName";
            this.colDName.Name = "colDName";
            this.colDName.OptionsColumn.AllowEdit = false;
            this.colDName.Visible = true;
            this.colDName.VisibleIndex = 8;
            this.colDName.Width = 161;
            // 
            // grdData
            // 
            this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdData.ContextMenuStrip = this.contextMenuStrip1;
            this.grdData.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdData.Location = new System.Drawing.Point(0, 45);
            this.grdData.MainView = this.grvData;
            this.grdData.Name = "grdData";
            this.grdData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1,
            this.repositoryItemCheckEdit1});
            this.grdData.Size = new System.Drawing.Size(1545, 542);
            this.grdData.TabIndex = 251;
            this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvData});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hủyDuyệtToolStripMenuItem,
            this.hủyDuyệtSXToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(148, 48);
            // 
            // hủyDuyệtToolStripMenuItem
            // 
            this.hủyDuyệtToolStripMenuItem.Name = "hủyDuyệtToolStripMenuItem";
            this.hủyDuyệtToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.hủyDuyệtToolStripMenuItem.Tag = "frmQuotationManagementKD_ApprovedKD";
            this.hủyDuyệtToolStripMenuItem.Text = "Hủy duyệt KD";
            this.hủyDuyệtToolStripMenuItem.Click += new System.EventHandler(this.hủyDuyệtToolStripMenuItem_Click);
            // 
            // hủyDuyệtSXToolStripMenuItem
            // 
            this.hủyDuyệtSXToolStripMenuItem.Name = "hủyDuyệtSXToolStripMenuItem";
            this.hủyDuyệtSXToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.hủyDuyệtSXToolStripMenuItem.Tag = "frmQuotationManagementKD_ApprovedSX";
            this.hủyDuyệtSXToolStripMenuItem.Text = "Hủy duyệt SX";
            // 
            // grvData
            // 
            this.grvData.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvData.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvData.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvData.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvData.ColumnPanelRowHeight = 40;
            this.grvData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode,
            this.colID,
            this.colProjectCode,
            this.colProjectName,
            this.colCustomerCode,
            this.colCustomerName,
            this.colDeliveryTime,
            this.colCustomerCodeF,
            this.colCustomerNameF,
            this.colTotalVAT,
            this.colTotalVT,
            this.colTotalTPA,
            this.colTotalHD,
            this.colTotalReal,
            this.colTotalProfitTT,
            this.colTotalProfitQD,
            this.colTotalPB,
            this.colTotalNC,
            this.colTotalNC_KD,
            this.colTotalXL,
            this.colTotalCustomer,
            this.colTotalDP,
            this.colDName,
            this.colStatusText,
            this.colIsApproved,
            this.colCreatedBy});
            this.grvData.GridControl = this.grdData;
            this.grvData.HorzScrollStep = 5;
            this.grvData.Name = "grvData";
            this.grvData.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvData.OptionsCustomization.AllowRowSizing = true;
            this.grvData.OptionsFind.AlwaysVisible = true;
            this.grvData.OptionsFind.ShowCloseButton = false;
            this.grvData.OptionsView.ColumnAutoWidth = false;
            this.grvData.OptionsView.RowAutoHeight = true;
            this.grvData.OptionsView.ShowFooter = true;
            this.grvData.OptionsView.ShowGroupPanel = false;
            this.grvData.DoubleClick += new System.EventHandler(this.grvData_DoubleClick);
            // 
            // colCode
            // 
            this.colCode.AppearanceCell.Options.UseTextOptions = true;
            this.colCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCode.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCode.AppearanceHeader.Options.UseFont = true;
            this.colCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCode.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCode.Caption = "Mã";
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.OptionsColumn.AllowEdit = false;
            this.colCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 2;
            this.colCode.Width = 130;
            // 
            // colID
            // 
            this.colID.AppearanceCell.Options.UseTextOptions = true;
            this.colID.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colID.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colID.AppearanceHeader.Options.UseTextOptions = true;
            this.colID.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colProjectCode
            // 
            this.colProjectCode.AppearanceCell.Options.UseTextOptions = true;
            this.colProjectCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colProjectCode.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colProjectCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colProjectCode.AppearanceHeader.Options.UseFont = true;
            this.colProjectCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colProjectCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProjectCode.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colProjectCode.Caption = "Mã dự án";
            this.colProjectCode.FieldName = "ProjectCode";
            this.colProjectCode.Name = "colProjectCode";
            this.colProjectCode.OptionsColumn.AllowEdit = false;
            this.colProjectCode.Visible = true;
            this.colProjectCode.VisibleIndex = 4;
            this.colProjectCode.Width = 127;
            // 
            // colProjectName
            // 
            this.colProjectName.AppearanceCell.Options.UseTextOptions = true;
            this.colProjectName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colProjectName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colProjectName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colProjectName.AppearanceHeader.Options.UseFont = true;
            this.colProjectName.AppearanceHeader.Options.UseTextOptions = true;
            this.colProjectName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProjectName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colProjectName.Caption = "Tên dự án";
            this.colProjectName.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colProjectName.FieldName = "ProjectName";
            this.colProjectName.Name = "colProjectName";
            this.colProjectName.OptionsColumn.AllowEdit = false;
            this.colProjectName.Visible = true;
            this.colProjectName.VisibleIndex = 5;
            this.colProjectName.Width = 293;
            // 
            // colCustomerCode
            // 
            this.colCustomerCode.AppearanceCell.Options.UseTextOptions = true;
            this.colCustomerCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCustomerCode.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCustomerCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCustomerCode.AppearanceHeader.Options.UseFont = true;
            this.colCustomerCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colCustomerCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCustomerCode.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCustomerCode.Caption = "Mã khách hàng";
            this.colCustomerCode.FieldName = "CustomerCode";
            this.colCustomerCode.Name = "colCustomerCode";
            this.colCustomerCode.OptionsColumn.AllowEdit = false;
            this.colCustomerCode.Visible = true;
            this.colCustomerCode.VisibleIndex = 6;
            this.colCustomerCode.Width = 125;
            // 
            // colCustomerName
            // 
            this.colCustomerName.AppearanceCell.Options.UseTextOptions = true;
            this.colCustomerName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCustomerName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCustomerName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCustomerName.AppearanceHeader.Options.UseFont = true;
            this.colCustomerName.AppearanceHeader.Options.UseTextOptions = true;
            this.colCustomerName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCustomerName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCustomerName.Caption = "Tên khách hàng";
            this.colCustomerName.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.OptionsColumn.AllowEdit = false;
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 7;
            this.colCustomerName.Width = 265;
            // 
            // colCustomerCodeF
            // 
            this.colCustomerCodeF.AppearanceCell.Options.UseTextOptions = true;
            this.colCustomerCodeF.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCustomerCodeF.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCustomerCodeF.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCustomerCodeF.AppearanceHeader.Options.UseFont = true;
            this.colCustomerCodeF.AppearanceHeader.Options.UseTextOptions = true;
            this.colCustomerCodeF.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCustomerCodeF.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCustomerCodeF.Caption = "Mã KH cuối";
            this.colCustomerCodeF.FieldName = "CustomerCodeF";
            this.colCustomerCodeF.Name = "colCustomerCodeF";
            this.colCustomerCodeF.OptionsColumn.AllowEdit = false;
            // 
            // colCustomerNameF
            // 
            this.colCustomerNameF.AppearanceCell.Options.UseTextOptions = true;
            this.colCustomerNameF.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCustomerNameF.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCustomerNameF.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCustomerNameF.AppearanceHeader.Options.UseFont = true;
            this.colCustomerNameF.AppearanceHeader.Options.UseTextOptions = true;
            this.colCustomerNameF.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCustomerNameF.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCustomerNameF.Caption = "Tên KH cuối";
            this.colCustomerNameF.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colCustomerNameF.FieldName = "CustomerNameF";
            this.colCustomerNameF.Name = "colCustomerNameF";
            this.colCustomerNameF.OptionsColumn.AllowEdit = false;
            this.colCustomerNameF.Width = 134;
            // 
            // colTotalVAT
            // 
            this.colTotalVAT.AppearanceCell.Options.UseTextOptions = true;
            this.colTotalVAT.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTotalVAT.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalVAT.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTotalVAT.AppearanceHeader.Options.UseFont = true;
            this.colTotalVAT.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotalVAT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotalVAT.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalVAT.Caption = "Thuế GTGT";
            this.colTotalVAT.DisplayFormat.FormatString = "n2";
            this.colTotalVAT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalVAT.FieldName = "TotalVAT";
            this.colTotalVAT.Name = "colTotalVAT";
            this.colTotalVAT.OptionsColumn.AllowEdit = false;
            this.colTotalVAT.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CustomerCash", "{0:n0}")});
            this.colTotalVAT.Width = 100;
            // 
            // colTotalVT
            // 
            this.colTotalVT.AppearanceCell.Options.UseTextOptions = true;
            this.colTotalVT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colTotalVT.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTotalVT.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalVT.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTotalVT.AppearanceHeader.Options.UseFont = true;
            this.colTotalVT.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotalVT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotalVT.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalVT.Caption = "Tổng vật tư";
            this.colTotalVT.DisplayFormat.FormatString = "n0";
            this.colTotalVT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalVT.FieldName = "TotalVT";
            this.colTotalVT.Name = "colTotalVT";
            this.colTotalVT.OptionsColumn.AllowEdit = false;
            this.colTotalVT.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalVT", "{0:n0}")});
            this.colTotalVT.Width = 100;
            // 
            // colTotalTPA
            // 
            this.colTotalTPA.AppearanceCell.Options.UseTextOptions = true;
            this.colTotalTPA.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTotalTPA.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalTPA.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTotalTPA.AppearanceHeader.Options.UseFont = true;
            this.colTotalTPA.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotalTPA.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotalTPA.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalTPA.Caption = "Tổng theo TPA";
            this.colTotalTPA.DisplayFormat.FormatString = "n2";
            this.colTotalTPA.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalTPA.FieldName = "TotalTPA";
            this.colTotalTPA.Name = "colTotalTPA";
            this.colTotalTPA.OptionsColumn.AllowEdit = false;
            this.colTotalTPA.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalTPA", "{0:n0}")});
            this.colTotalTPA.Width = 100;
            // 
            // colTotalHD
            // 
            this.colTotalHD.AppearanceCell.Options.UseTextOptions = true;
            this.colTotalHD.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTotalHD.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalHD.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTotalHD.AppearanceHeader.Options.UseFont = true;
            this.colTotalHD.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotalHD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotalHD.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalHD.Caption = "Tổng HĐ";
            this.colTotalHD.DisplayFormat.FormatString = "n2";
            this.colTotalHD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalHD.FieldName = "TotalHD";
            this.colTotalHD.Name = "colTotalHD";
            this.colTotalHD.OptionsColumn.AllowEdit = false;
            this.colTotalHD.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalHD", "{0:n0}")});
            this.colTotalHD.Width = 100;
            // 
            // colTotalReal
            // 
            this.colTotalReal.AppearanceCell.Options.UseTextOptions = true;
            this.colTotalReal.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTotalReal.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalReal.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTotalReal.AppearanceHeader.Options.UseFont = true;
            this.colTotalReal.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotalReal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotalReal.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalReal.Caption = "Tổng thực thu";
            this.colTotalReal.DisplayFormat.FormatString = "n2";
            this.colTotalReal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalReal.FieldName = "TotalReal";
            this.colTotalReal.Name = "colTotalReal";
            this.colTotalReal.OptionsColumn.AllowEdit = false;
            this.colTotalReal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalReal", "{0:n0}")});
            this.colTotalReal.Width = 100;
            // 
            // colTotalProfitTT
            // 
            this.colTotalProfitTT.AppearanceCell.Options.UseTextOptions = true;
            this.colTotalProfitTT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colTotalProfitTT.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTotalProfitTT.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalProfitTT.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTotalProfitTT.AppearanceHeader.Options.UseFont = true;
            this.colTotalProfitTT.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotalProfitTT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotalProfitTT.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalProfitTT.Caption = "Lợi nhuận thực tế";
            this.colTotalProfitTT.DisplayFormat.FormatString = "n2";
            this.colTotalProfitTT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalProfitTT.FieldName = "TotalProfitTT";
            this.colTotalProfitTT.Name = "colTotalProfitTT";
            this.colTotalProfitTT.OptionsColumn.AllowEdit = false;
            this.colTotalProfitTT.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPhatSinh", "{0:n0}")});
            this.colTotalProfitTT.Width = 100;
            // 
            // colTotalProfitQD
            // 
            this.colTotalProfitQD.AppearanceCell.Options.UseTextOptions = true;
            this.colTotalProfitQD.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTotalProfitQD.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalProfitQD.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTotalProfitQD.AppearanceHeader.Options.UseFont = true;
            this.colTotalProfitQD.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotalProfitQD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotalProfitQD.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalProfitQD.Caption = "Lợi nhuận QD";
            this.colTotalProfitQD.DisplayFormat.FormatString = "n2";
            this.colTotalProfitQD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalProfitQD.FieldName = "TotalProfitQD";
            this.colTotalProfitQD.Name = "colTotalProfitQD";
            this.colTotalProfitQD.OptionsColumn.AllowEdit = false;
            // 
            // colTotalPB
            // 
            this.colTotalPB.AppearanceCell.Options.UseTextOptions = true;
            this.colTotalPB.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTotalPB.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalPB.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTotalPB.AppearanceHeader.Options.UseFont = true;
            this.colTotalPB.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotalPB.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotalPB.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalPB.Caption = "Tổng CP PB";
            this.colTotalPB.DisplayFormat.FormatString = "n2";
            this.colTotalPB.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalPB.FieldName = "TotalPB";
            this.colTotalPB.Name = "colTotalPB";
            this.colTotalPB.OptionsColumn.AllowEdit = false;
            // 
            // colTotalNC
            // 
            this.colTotalNC.AppearanceCell.Options.UseTextOptions = true;
            this.colTotalNC.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTotalNC.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalNC.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTotalNC.AppearanceHeader.Options.UseFont = true;
            this.colTotalNC.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotalNC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotalNC.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalNC.Caption = "CP Nhân công";
            this.colTotalNC.DisplayFormat.FormatString = "n2";
            this.colTotalNC.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalNC.FieldName = "TotalNC";
            this.colTotalNC.Name = "colTotalNC";
            this.colTotalNC.OptionsColumn.AllowEdit = false;
            // 
            // colTotalNC_KD
            // 
            this.colTotalNC_KD.AppearanceCell.Options.UseTextOptions = true;
            this.colTotalNC_KD.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTotalNC_KD.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalNC_KD.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTotalNC_KD.AppearanceHeader.Options.UseFont = true;
            this.colTotalNC_KD.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotalNC_KD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotalNC_KD.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalNC_KD.Caption = "CP nhân công KD";
            this.colTotalNC_KD.DisplayFormat.FormatString = "n2";
            this.colTotalNC_KD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalNC_KD.FieldName = "TotalNC_KD";
            this.colTotalNC_KD.Name = "colTotalNC_KD";
            this.colTotalNC_KD.OptionsColumn.AllowEdit = false;
            // 
            // colTotalXL
            // 
            this.colTotalXL.AppearanceCell.Options.UseTextOptions = true;
            this.colTotalXL.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTotalXL.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalXL.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTotalXL.AppearanceHeader.Options.UseFont = true;
            this.colTotalXL.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotalXL.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotalXL.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalXL.Caption = "Xử lý phần gửi";
            this.colTotalXL.DisplayFormat.FormatString = "n2";
            this.colTotalXL.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalXL.FieldName = "TotalXL";
            this.colTotalXL.Name = "colTotalXL";
            this.colTotalXL.OptionsColumn.AllowEdit = false;
            // 
            // colTotalCustomer
            // 
            this.colTotalCustomer.AppearanceCell.Options.UseTextOptions = true;
            this.colTotalCustomer.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTotalCustomer.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalCustomer.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTotalCustomer.AppearanceHeader.Options.UseFont = true;
            this.colTotalCustomer.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotalCustomer.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotalCustomer.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalCustomer.Caption = "Khách hàng gửi";
            this.colTotalCustomer.DisplayFormat.FormatString = "n2";
            this.colTotalCustomer.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalCustomer.FieldName = "CustomerCash";
            this.colTotalCustomer.Name = "colTotalCustomer";
            this.colTotalCustomer.OptionsColumn.AllowEdit = false;
            // 
            // colTotalDP
            // 
            this.colTotalDP.AppearanceCell.Options.UseTextOptions = true;
            this.colTotalDP.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTotalDP.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalDP.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTotalDP.AppearanceHeader.Options.UseFont = true;
            this.colTotalDP.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotalDP.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotalDP.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalDP.Caption = "Dự phòng";
            this.colTotalDP.DisplayFormat.FormatString = "n2";
            this.colTotalDP.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalDP.FieldName = "TotalDP";
            this.colTotalDP.Name = "colTotalDP";
            this.colTotalDP.OptionsColumn.AllowEdit = false;
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCreatedBy.AppearanceHeader.Options.UseFont = true;
            this.colCreatedBy.AppearanceHeader.Options.UseTextOptions = true;
            this.colCreatedBy.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCreatedBy.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCreatedBy.Caption = "Người tạo";
            this.colCreatedBy.FieldName = "CreatedBy";
            this.colCreatedBy.Name = "colCreatedBy";
            this.colCreatedBy.OptionsColumn.AllowEdit = false;
            this.colCreatedBy.Visible = true;
            this.colCreatedBy.VisibleIndex = 3;
            this.colCreatedBy.Width = 118;
            // 
            // frmQuotationManagementKD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1545, 587);
            this.Controls.Add(this.cboYear);
            this.Controls.Add(this.mnuMenu);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.grdData);
            this.Name = "frmQuotationManagementKD";
            this.Text = "QUẢN LÝ BÁO GIÁ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmQuotationManagementKD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboYear;
        private DevExpress.XtraGrid.Columns.GridColumn colStatusText;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colIsApproved;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private System.Windows.Forms.ToolStrip mnuMenu;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnQuotationDetailKD;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnReportKD;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnReportProductGroup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnApprovedKD;
        private DevExpress.XtraGrid.Columns.GridColumn colDeliveryTime;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.SimpleButton btnLoadData;
        private DevExpress.XtraGrid.Columns.GridColumn colDName;
        private DevExpress.XtraGrid.GridControl grdData;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hủyDuyệtToolStripMenuItem;
        private DevExpress.XtraGrid.Views.Grid.GridView grvData;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectCode;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectName;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerCodeF;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerNameF;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalVAT;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalVT;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalTPA;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalReal;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalHD;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalProfitTT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnNewSX;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnReportSX;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton btnApprovedSX;
        private System.Windows.Forms.ToolStripMenuItem hủyDuyệtSXToolStripMenuItem;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalProfitQD;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalPB;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalNC;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalNC_KD;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalXL;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalDP;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedBy;
    }
}