namespace BMS
{
    partial class frmYCMVTwarningNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmYCMVTwarningNew));
            this.mnuMenu = new System.Windows.Forms.ToolStrip();
            this.btnDNNKthanhPham = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExcelDetail = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.grdYCMVT = new DevExpress.XtraGrid.GridControl();
            this.grvYCMVT = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMProposalCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateCreate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAccount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colIsCreatedPO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colNguoiPT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHanHoanThanh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProposalProblemID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProposalId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProject = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.btnLoadData = new DevExpress.XtraEditors.SimpleButton();
            this.mnuMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdYCMVT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvYCMVT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuMenu
            // 
            this.mnuMenu.AutoSize = false;
            this.mnuMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.mnuMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDNNKthanhPham,
            this.toolStripSeparator1,
            this.btnExcelDetail,
            this.toolStripSeparator2});
            this.mnuMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuMenu.Size = new System.Drawing.Size(1243, 42);
            this.mnuMenu.TabIndex = 22;
            this.mnuMenu.Text = "toolStrip2";
            // 
            // btnDNNKthanhPham
            // 
            this.btnDNNKthanhPham.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDNNKthanhPham.Image = ((System.Drawing.Image)(resources.GetObject("btnDNNKthanhPham.Image")));
            this.btnDNNKthanhPham.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDNNKthanhPham.Name = "btnDNNKthanhPham";
            this.btnDNNKthanhPham.Size = new System.Drawing.Size(69, 33);
            this.btnDNNKthanhPham.Tag = "";
            this.btnDNNKthanhPham.Text = "Xuất Excel";
            this.btnDNNKthanhPham.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDNNKthanhPham.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // btnExcelDetail
            // 
            this.btnExcelDetail.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcelDetail.Image = ((System.Drawing.Image)(resources.GetObject("btnExcelDetail.Image")));
            this.btnExcelDetail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcelDetail.Name = "btnExcelDetail";
            this.btnExcelDetail.Size = new System.Drawing.Size(111, 33);
            this.btnExcelDetail.Tag = "";
            this.btnExcelDetail.Text = "Xuất Excel chi tiết";
            this.btnExcelDetail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExcelDetail.Click += new System.EventHandler(this.btnExcelDetail_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
            // 
            // grdYCMVT
            // 
            this.grdYCMVT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdYCMVT.Location = new System.Drawing.Point(0, 45);
            this.grdYCMVT.MainView = this.grvYCMVT;
            this.grdYCMVT.Name = "grdYCMVT";
            this.grdYCMVT.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit2,
            this.repositoryItemCheckEdit2});
            this.grdYCMVT.Size = new System.Drawing.Size(1243, 658);
            this.grdYCMVT.TabIndex = 23;
            this.grdYCMVT.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvYCMVT});
            // 
            // grvYCMVT
            // 
            this.grvYCMVT.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvYCMVT.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvYCMVT.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvYCMVT.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvYCMVT.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvYCMVT.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvYCMVT.ColumnPanelRowHeight = 60;
            this.grvYCMVT.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMID,
            this.colMProposalCode,
            this.colDateCreate,
            this.colAccount,
            this.colIsCreatedPO,
            this.colNguoiPT,
            this.colDepartment,
            this.colHanHoanThanh,
            this.colProposalProblemID,
            this.colProposalId,
            this.colYear,
            this.colProject});
            this.grvYCMVT.GridControl = this.grdYCMVT;
            this.grvYCMVT.GroupCount = 2;
            this.grvYCMVT.Name = "grvYCMVT";
            this.grvYCMVT.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvYCMVT.OptionsFind.AlwaysVisible = true;
            this.grvYCMVT.OptionsView.ColumnAutoWidth = false;
            this.grvYCMVT.OptionsView.RowAutoHeight = true;
            this.grvYCMVT.OptionsView.ShowFooter = true;
            this.grvYCMVT.OptionsView.ShowGroupPanel = false;
            this.grvYCMVT.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colYear, DevExpress.Data.ColumnSortOrder.Descending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colAccount, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDateCreate, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // colMID
            // 
            this.colMID.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMID.AppearanceHeader.Options.UseFont = true;
            this.colMID.AppearanceHeader.Options.UseTextOptions = true;
            this.colMID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMID.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colMID.Caption = "ID";
            this.colMID.FieldName = "ID";
            this.colMID.Name = "colMID";
            this.colMID.OptionsColumn.AllowEdit = false;
            // 
            // colMProposalCode
            // 
            this.colMProposalCode.AppearanceCell.Options.UseTextOptions = true;
            this.colMProposalCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMProposalCode.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colMProposalCode.AppearanceHeader.Options.UseFont = true;
            this.colMProposalCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colMProposalCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMProposalCode.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colMProposalCode.Caption = "YCMVT";
            this.colMProposalCode.FieldName = "ProposalCode";
            this.colMProposalCode.Name = "colMProposalCode";
            this.colMProposalCode.OptionsColumn.AllowEdit = false;
            this.colMProposalCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colMProposalCode.Visible = true;
            this.colMProposalCode.VisibleIndex = 0;
            this.colMProposalCode.Width = 264;
            // 
            // colDateCreate
            // 
            this.colDateCreate.AppearanceCell.Options.UseTextOptions = true;
            this.colDateCreate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDateCreate.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDateCreate.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDateCreate.AppearanceHeader.Options.UseFont = true;
            this.colDateCreate.AppearanceHeader.Options.UseTextOptions = true;
            this.colDateCreate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDateCreate.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDateCreate.Caption = "Ngày tạo";
            this.colDateCreate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colDateCreate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDateCreate.FieldName = "DateCreate";
            this.colDateCreate.Name = "colDateCreate";
            this.colDateCreate.OptionsColumn.AllowEdit = false;
            this.colDateCreate.Visible = true;
            this.colDateCreate.VisibleIndex = 1;
            this.colDateCreate.Width = 173;
            // 
            // colAccount
            // 
            this.colAccount.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colAccount.AppearanceHeader.Options.UseFont = true;
            this.colAccount.AppearanceHeader.Options.UseTextOptions = true;
            this.colAccount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAccount.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colAccount.Caption = "Người phụ trách";
            this.colAccount.ColumnEdit = this.repositoryItemMemoEdit2;
            this.colAccount.FieldName = "Account";
            this.colAccount.Name = "colAccount";
            this.colAccount.OptionsColumn.AllowEdit = false;
            this.colAccount.Width = 101;
            // 
            // repositoryItemMemoEdit2
            // 
            this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
            // 
            // colIsCreatedPO
            // 
            this.colIsCreatedPO.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colIsCreatedPO.AppearanceHeader.Options.UseFont = true;
            this.colIsCreatedPO.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsCreatedPO.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsCreatedPO.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colIsCreatedPO.Caption = "Quá thời gian tạo PO (3-5 ngày)";
            this.colIsCreatedPO.ColumnEdit = this.repositoryItemCheckEdit2;
            this.colIsCreatedPO.FieldName = "IsCreatedPO";
            this.colIsCreatedPO.Name = "colIsCreatedPO";
            this.colIsCreatedPO.OptionsColumn.AllowEdit = false;
            this.colIsCreatedPO.Visible = true;
            this.colIsCreatedPO.VisibleIndex = 2;
            this.colIsCreatedPO.Width = 160;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // colNguoiPT
            // 
            this.colNguoiPT.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colNguoiPT.AppearanceHeader.Options.UseFont = true;
            this.colNguoiPT.AppearanceHeader.Options.UseTextOptions = true;
            this.colNguoiPT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNguoiPT.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNguoiPT.Caption = "Người phụ trách";
            this.colNguoiPT.Name = "colNguoiPT";
            this.colNguoiPT.OptionsColumn.AllowEdit = false;
            this.colNguoiPT.Width = 107;
            // 
            // colDepartment
            // 
            this.colDepartment.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDepartment.AppearanceHeader.Options.UseFont = true;
            this.colDepartment.AppearanceHeader.Options.UseTextOptions = true;
            this.colDepartment.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDepartment.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDepartment.Caption = "Phòng ban";
            this.colDepartment.Name = "colDepartment";
            this.colDepartment.OptionsColumn.AllowEdit = false;
            this.colDepartment.Width = 93;
            // 
            // colHanHoanThanh
            // 
            this.colHanHoanThanh.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colHanHoanThanh.AppearanceHeader.Options.UseFont = true;
            this.colHanHoanThanh.AppearanceHeader.Options.UseTextOptions = true;
            this.colHanHoanThanh.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHanHoanThanh.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colHanHoanThanh.Caption = "Hạn hoàn thành";
            this.colHanHoanThanh.Name = "colHanHoanThanh";
            this.colHanHoanThanh.OptionsColumn.AllowEdit = false;
            this.colHanHoanThanh.Width = 90;
            // 
            // colProposalProblemID
            // 
            this.colProposalProblemID.Caption = "ProposalProblemID";
            this.colProposalProblemID.FieldName = "ProposalProblemID";
            this.colProposalProblemID.Name = "colProposalProblemID";
            this.colProposalProblemID.OptionsColumn.AllowEdit = false;
            // 
            // colProposalId
            // 
            this.colProposalId.Caption = "ProposalId";
            this.colProposalId.FieldName = "ProposalId";
            this.colProposalId.Name = "colProposalId";
            this.colProposalId.OptionsColumn.AllowEdit = false;
            // 
            // colYear
            // 
            this.colYear.Caption = "Năm";
            this.colYear.FieldName = "Year";
            this.colYear.Name = "colYear";
            // 
            // colProject
            // 
            this.colProject.AppearanceCell.Options.UseTextOptions = true;
            this.colProject.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colProject.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colProject.AppearanceHeader.Options.UseFont = true;
            this.colProject.AppearanceHeader.Options.UseTextOptions = true;
            this.colProject.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProject.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colProject.Caption = "Dự án";
            this.colProject.FieldName = "Project";
            this.colProject.Name = "colProject";
            this.colProject.OptionsColumn.AllowEdit = false;
            this.colProject.Visible = true;
            this.colProject.VisibleIndex = 3;
            this.colProject.Width = 284;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(498, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 240;
            this.label7.Text = "Năm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(640, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 241;
            this.label2.Text = "Tháng";
            // 
            // cboYear
            // 
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(531, 59);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(99, 21);
            this.cboYear.TabIndex = 238;
            // 
            // cboMonth
            // 
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Items.AddRange(new object[] {
            "Tất cả",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cboMonth.Location = new System.Drawing.Point(681, 58);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(99, 21);
            this.cboMonth.TabIndex = 239;
            // 
            // btnLoadData
            // 
            this.btnLoadData.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnLoadData.Appearance.Options.UseFont = true;
            this.btnLoadData.Location = new System.Drawing.Point(788, 57);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(75, 23);
            this.btnLoadData.TabIndex = 242;
            this.btnLoadData.Text = "Tải dữ liệu";
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // frmYCMVTwarningNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1243, 703);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboYear);
            this.Controls.Add(this.cboMonth);
            this.Controls.Add(this.grdYCMVT);
            this.Controls.Add(this.mnuMenu);
            this.Name = "frmYCMVTwarningNew";
            this.Text = "NHỮNG VẤN ĐỀ VỀ YCMVT";
            this.Load += new System.EventHandler(this.frmYCMVTwarningNew_Load);
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdYCMVT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvYCMVT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip mnuMenu;
        private System.Windows.Forms.ToolStripButton btnDNNKthanhPham;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnExcelDetail;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private DevExpress.XtraGrid.GridControl grdYCMVT;
        private DevExpress.XtraGrid.Views.Grid.GridView grvYCMVT;
        private DevExpress.XtraGrid.Columns.GridColumn colMID;
        private DevExpress.XtraGrid.Columns.GridColumn colMProposalCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDateCreate;
        private DevExpress.XtraGrid.Columns.GridColumn colAccount;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colIsCreatedPO;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoiPT;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartment;
        private DevExpress.XtraGrid.Columns.GridColumn colHanHoanThanh;
        private DevExpress.XtraGrid.Columns.GridColumn colProposalProblemID;
        private DevExpress.XtraGrid.Columns.GridColumn colProposalId;
        private DevExpress.XtraGrid.Columns.GridColumn colYear;
        private DevExpress.XtraGrid.Columns.GridColumn colProject;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.ComboBox cboMonth;
        private DevExpress.XtraEditors.SimpleButton btnLoadData;
    }
}