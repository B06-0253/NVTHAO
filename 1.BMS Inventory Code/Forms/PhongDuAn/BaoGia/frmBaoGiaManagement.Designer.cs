namespace BMS
{
    partial class frmBaoGiaManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaoGiaManagement));
            this.mnuMenu = new System.Windows.Forms.ToolStrip();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTongHopChiPhi = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnReport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCreateBaoGia = new System.Windows.Forms.ToolStripButton();
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.grvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProjectCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colCustomerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerCodeF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerNameF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerPercentTypeText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerPercent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerCash = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalTPA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalReal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalHD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerPercentType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalPhatSinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.mnuMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuMenu
            // 
            this.mnuMenu.AutoSize = false;
            this.mnuMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.mnuMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.toolStripSeparator2,
            this.btnEdit,
            this.toolStripSeparator3,
            this.btnDelete,
            this.toolStripSeparator1,
            this.btnTongHopChiPhi,
            this.toolStripSeparator4,
            this.btnReport,
            this.toolStripSeparator5,
            this.btnCreateBaoGia});
            this.mnuMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuMenu.Size = new System.Drawing.Size(1167, 42);
            this.mnuMenu.TabIndex = 15;
            this.mnuMenu.Text = "toolStrip2";
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(43, 33);
            this.btnNew.Tag = "frmBaoGiaManagement_New";
            this.btnNew.Text = "Thêm";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(33, 33);
            this.btnEdit.Tag = "frmBaoGiaManagement_Edit";
            this.btnEdit.Text = "Sửa";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 23);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(32, 33);
            this.btnDelete.Tag = "frmBaoGiaManagement_Delete";
            this.btnDelete.Text = "Xóa";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // btnTongHopChiPhi
            // 
            this.btnTongHopChiPhi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTongHopChiPhi.Image = ((System.Drawing.Image)(resources.GetObject("btnTongHopChiPhi.Image")));
            this.btnTongHopChiPhi.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTongHopChiPhi.Name = "btnTongHopChiPhi";
            this.btnTongHopChiPhi.Size = new System.Drawing.Size(95, 33);
            this.btnTongHopChiPhi.Tag = "frmBaoGiaManagement_TongHopChiPhi";
            this.btnTongHopChiPhi.Text = "Phân bổ chi phí";
            this.btnTongHopChiPhi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnTongHopChiPhi.Click += new System.EventHandler(this.btnTongHopChiPhi_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Image = ((System.Drawing.Image)(resources.GetObject("btnReport.Image")));
            this.btnReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(55, 33);
            this.btnReport.Tag = "frmBaoGiaManagement_Report";
            this.btnReport.Text = "Báo cáo";
            this.btnReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 23);
            // 
            // btnCreateBaoGia
            // 
            this.btnCreateBaoGia.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateBaoGia.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateBaoGia.Image")));
            this.btnCreateBaoGia.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreateBaoGia.Name = "btnCreateBaoGia";
            this.btnCreateBaoGia.Size = new System.Drawing.Size(76, 33);
            this.btnCreateBaoGia.Tag = "";
            this.btnCreateBaoGia.Text = "Tạo báo giá";
            this.btnCreateBaoGia.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCreateBaoGia.Visible = false;
            this.btnCreateBaoGia.Click += new System.EventHandler(this.btnCreateBaoGia_Click);
            // 
            // grdData
            // 
            this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdData.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdData.Location = new System.Drawing.Point(0, 44);
            this.grdData.MainView = this.grvData;
            this.grdData.Name = "grdData";
            this.grdData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemMemoEdit1});
            this.grdData.Size = new System.Drawing.Size(1167, 379);
            this.grdData.TabIndex = 17;
            this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvData});
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
            this.colCustomerCodeF,
            this.colCustomerNameF,
            this.colCustomerPercentTypeText,
            this.colCustomerPercent,
            this.colCustomerCash,
            this.colCustomerTotal,
            this.colTotalVT,
            this.colTotalTPA,
            this.colTotalReal,
            this.colTotalHD,
            this.colCustomerPercentType,
            this.colTotalPhatSinh});
            this.grvData.GridControl = this.grdData;
            this.grvData.HorzScrollStep = 5;
            this.grvData.Name = "grvData";
            this.grvData.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvData.OptionsCustomization.AllowRowSizing = true;
            this.grvData.OptionsFind.AlwaysVisible = true;
            this.grvData.OptionsFind.ShowCloseButton = false;
            this.grvData.OptionsView.ColumnAutoWidth = false;
            this.grvData.OptionsView.RowAutoHeight = true;
            this.grvData.OptionsView.ShowAutoFilterRow = true;
            this.grvData.OptionsView.ShowFooter = true;
            this.grvData.OptionsView.ShowGroupPanel = false;
            this.grvData.DoubleClick += new System.EventHandler(this.grvData_DoubleClick);
            // 
            // colCode
            // 
            this.colCode.AppearanceCell.Options.UseTextOptions = true;
            this.colCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
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
            this.colCode.VisibleIndex = 0;
            this.colCode.Width = 63;
            // 
            // colID
            // 
            this.colID.AppearanceCell.Options.UseTextOptions = true;
            this.colID.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
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
            this.colProjectCode.VisibleIndex = 1;
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
            this.colProjectName.VisibleIndex = 2;
            this.colProjectName.Width = 145;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Appearance.Options.UseTextOptions = true;
            this.repositoryItemMemoEdit1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
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
            this.colCustomerCode.VisibleIndex = 3;
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
            this.colCustomerName.VisibleIndex = 4;
            this.colCustomerName.Width = 126;
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
            this.colCustomerCodeF.Visible = true;
            this.colCustomerCodeF.VisibleIndex = 5;
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
            this.colCustomerNameF.Visible = true;
            this.colCustomerNameF.VisibleIndex = 6;
            this.colCustomerNameF.Width = 134;
            // 
            // colCustomerPercentTypeText
            // 
            this.colCustomerPercentTypeText.AppearanceCell.Options.UseTextOptions = true;
            this.colCustomerPercentTypeText.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCustomerPercentTypeText.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCustomerPercentTypeText.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCustomerPercentTypeText.AppearanceHeader.Options.UseFont = true;
            this.colCustomerPercentTypeText.AppearanceHeader.Options.UseTextOptions = true;
            this.colCustomerPercentTypeText.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCustomerPercentTypeText.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCustomerPercentTypeText.Caption = "Loại CP KH";
            this.colCustomerPercentTypeText.FieldName = "CustomerPercentTypeText";
            this.colCustomerPercentTypeText.Name = "colCustomerPercentTypeText";
            this.colCustomerPercentTypeText.OptionsColumn.AllowEdit = false;
            this.colCustomerPercentTypeText.Visible = true;
            this.colCustomerPercentTypeText.VisibleIndex = 7;
            // 
            // colCustomerPercent
            // 
            this.colCustomerPercent.AppearanceCell.Options.UseTextOptions = true;
            this.colCustomerPercent.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCustomerPercent.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCustomerPercent.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCustomerPercent.AppearanceHeader.Options.UseFont = true;
            this.colCustomerPercent.AppearanceHeader.Options.UseTextOptions = true;
            this.colCustomerPercent.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCustomerPercent.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCustomerPercent.Caption = "% Khách hàng";
            this.colCustomerPercent.DisplayFormat.FormatString = "{0:#,##0.####}";
            this.colCustomerPercent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCustomerPercent.FieldName = "CustomerPercent";
            this.colCustomerPercent.Name = "colCustomerPercent";
            this.colCustomerPercent.OptionsColumn.AllowEdit = false;
            this.colCustomerPercent.Visible = true;
            this.colCustomerPercent.VisibleIndex = 8;
            // 
            // colCustomerCash
            // 
            this.colCustomerCash.AppearanceCell.Options.UseTextOptions = true;
            this.colCustomerCash.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCustomerCash.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCustomerCash.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCustomerCash.AppearanceHeader.Options.UseFont = true;
            this.colCustomerCash.AppearanceHeader.Options.UseTextOptions = true;
            this.colCustomerCash.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCustomerCash.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCustomerCash.Caption = "Tiền mặt chi KH";
            this.colCustomerCash.DisplayFormat.FormatString = "{0:#,##0.####}";
            this.colCustomerCash.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCustomerCash.FieldName = "CustomerCash";
            this.colCustomerCash.Name = "colCustomerCash";
            this.colCustomerCash.OptionsColumn.AllowEdit = false;
            this.colCustomerCash.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CustomerCash", "{0:n0}")});
            this.colCustomerCash.Visible = true;
            this.colCustomerCash.VisibleIndex = 9;
            // 
            // colCustomerTotal
            // 
            this.colCustomerTotal.AppearanceCell.Options.UseTextOptions = true;
            this.colCustomerTotal.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCustomerTotal.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCustomerTotal.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCustomerTotal.AppearanceHeader.Options.UseFont = true;
            this.colCustomerTotal.AppearanceHeader.Options.UseTextOptions = true;
            this.colCustomerTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCustomerTotal.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCustomerTotal.Caption = "Tổng tiền chi KH";
            this.colCustomerTotal.DisplayFormat.FormatString = "{0:#,##0.####}";
            this.colCustomerTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCustomerTotal.FieldName = "CustomerTotal";
            this.colCustomerTotal.Name = "colCustomerTotal";
            this.colCustomerTotal.OptionsColumn.AllowEdit = false;
            this.colCustomerTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CustomerTotal", "{0:n0}")});
            this.colCustomerTotal.Visible = true;
            this.colCustomerTotal.VisibleIndex = 10;
            // 
            // colTotalVT
            // 
            this.colTotalVT.AppearanceCell.Options.UseTextOptions = true;
            this.colTotalVT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colTotalVT.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTotalVT.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTotalVT.AppearanceHeader.Options.UseFont = true;
            this.colTotalVT.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotalVT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotalVT.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalVT.Caption = "Tổng tiền vật tư";
            this.colTotalVT.DisplayFormat.FormatString = "{0:#,##0.####}";
            this.colTotalVT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalVT.FieldName = "TotalVT";
            this.colTotalVT.Name = "colTotalVT";
            this.colTotalVT.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalVT", "{0:n0}")});
            this.colTotalVT.Visible = true;
            this.colTotalVT.VisibleIndex = 11;
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
            this.colTotalTPA.Caption = "Tổng tiền theo TPA";
            this.colTotalTPA.DisplayFormat.FormatString = "{0:#,##0.####}";
            this.colTotalTPA.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalTPA.FieldName = "TotalTPA";
            this.colTotalTPA.Name = "colTotalTPA";
            this.colTotalTPA.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalTPA", "{0:n0}")});
            this.colTotalTPA.Visible = true;
            this.colTotalTPA.VisibleIndex = 12;
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
            this.colTotalReal.Caption = "Tổng tiền thực thu";
            this.colTotalReal.DisplayFormat.FormatString = "{0:#,##0.####}";
            this.colTotalReal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalReal.FieldName = "TotalReal";
            this.colTotalReal.Name = "colTotalReal";
            this.colTotalReal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalReal", "{0:n0}")});
            this.colTotalReal.Visible = true;
            this.colTotalReal.VisibleIndex = 13;
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
            this.colTotalHD.Caption = "Tổng tiền theo HĐ";
            this.colTotalHD.DisplayFormat.FormatString = "{0:#,##0.####}";
            this.colTotalHD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalHD.FieldName = "TotalHD";
            this.colTotalHD.Name = "colTotalHD";
            this.colTotalHD.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalHD", "{0:n0}")});
            this.colTotalHD.Visible = true;
            this.colTotalHD.VisibleIndex = 14;
            // 
            // colCustomerPercentType
            // 
            this.colCustomerPercentType.Caption = "CustomerPercentType";
            this.colCustomerPercentType.FieldName = "CustomerPercentType";
            this.colCustomerPercentType.Name = "colCustomerPercentType";
            // 
            // colTotalPhatSinh
            // 
            this.colTotalPhatSinh.AppearanceCell.Options.UseTextOptions = true;
            this.colTotalPhatSinh.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colTotalPhatSinh.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTotalPhatSinh.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTotalPhatSinh.AppearanceHeader.Options.UseFont = true;
            this.colTotalPhatSinh.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotalPhatSinh.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotalPhatSinh.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalPhatSinh.Caption = "Tổng tiền CP phát sinh";
            this.colTotalPhatSinh.DisplayFormat.FormatString = "{0:#,##0.####}";
            this.colTotalPhatSinh.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalPhatSinh.FieldName = "TotalPhatSinh";
            this.colTotalPhatSinh.Name = "colTotalPhatSinh";
            this.colTotalPhatSinh.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPhatSinh", "{0:n0}")});
            this.colTotalPhatSinh.Visible = true;
            this.colTotalPhatSinh.VisibleIndex = 15;
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
            // frmBaoGiaManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 424);
            this.Controls.Add(this.grdData);
            this.Controls.Add(this.mnuMenu);
            this.Name = "frmBaoGiaManagement";
            this.Text = "DANH SÁCH BÁO GIÁ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBaoGiaManagement_Load);
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip mnuMenu;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.Grid.GridView grvData;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectCode;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectName;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerCodeF;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerNameF;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerPercentTypeText;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerPercent;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerCash;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalTPA;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalReal;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalHD;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnTongHopChiPhi;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerPercentType;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalVT;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalPhatSinh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnReport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnCreateBaoGia;
    }
}