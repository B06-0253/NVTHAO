namespace BMS
{
    partial class frmReportVoucher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportVoucher));
            this.cboUser = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.grvCboUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAccount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartmentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.hủyĐãTrảToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVoucherName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserId_G = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonth = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompletedDateDK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompletedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaymentTableItemID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaymentTableID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReason = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colPayVoucherID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChenhLech = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemGridLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnExeclReport = new DevExpress.XtraEditors.SimpleButton();
            this.dtpDateOut = new DevExpress.XtraEditors.DateEdit();
            this.lblDateOut = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.lblReason = new System.Windows.Forms.Label();
            this.btnSaveHistory = new System.Windows.Forms.Button();
            this.btnDateOut = new DevExpress.XtraEditors.SimpleButton();
            this.btnDaTra = new System.Windows.Forms.Button();
            this.btnCheckHoaDon = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cboUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCboUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateOut.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateOut.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cboUser
            // 
            this.cboUser.Location = new System.Drawing.Point(110, 11);
            this.cboUser.Name = "cboUser";
            this.cboUser.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7F);
            this.cboUser.Properties.Appearance.Options.UseFont = true;
            this.cboUser.Properties.AutoHeight = false;
            this.cboUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboUser.Properties.NullText = "";
            this.cboUser.Properties.View = this.grvCboUser;
            this.cboUser.Size = new System.Drawing.Size(187, 20);
            this.cboUser.TabIndex = 197;
            this.cboUser.EditValueChanged += new System.EventHandler(this.cboUser_EditValueChanged);
            // 
            // grvCboUser
            // 
            this.grvCboUser.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUserID,
            this.colFullName,
            this.colAccount,
            this.colDepartmentName,
            this.colUserCode});
            this.grvCboUser.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboUser.GroupCount = 1;
            this.grvCboUser.Name = "grvCboUser";
            this.grvCboUser.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvCboUser.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboUser.OptionsView.ShowGroupedColumns = true;
            this.grvCboUser.OptionsView.ShowGroupPanel = false;
            this.grvCboUser.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDepartmentName, DevExpress.Data.ColumnSortOrder.Ascending)});
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
            this.colFullName.VisibleIndex = 1;
            // 
            // colAccount
            // 
            this.colAccount.Caption = "Tên đăng nhập";
            this.colAccount.FieldName = "Account";
            this.colAccount.Name = "colAccount";
            this.colAccount.Visible = true;
            this.colAccount.VisibleIndex = 2;
            // 
            // colDepartmentName
            // 
            this.colDepartmentName.Caption = "Phòng ban";
            this.colDepartmentName.FieldName = "DName";
            this.colDepartmentName.Name = "colDepartmentName";
            this.colDepartmentName.Visible = true;
            this.colDepartmentName.VisibleIndex = 0;
            // 
            // colUserCode
            // 
            this.colUserCode.Caption = "Mã nhân viên";
            this.colUserCode.FieldName = "SupplierCode";
            this.colUserCode.Name = "colUserCode";
            // 
            // cboType
            // 
            this.cboType.FormattingEnabled = true;
            this.cboType.Items.AddRange(new object[] {
            "Chứng từ còn nợ",
            "Chứng từ đã trả",
            "Tất cả"});
            this.cboType.Location = new System.Drawing.Point(388, 11);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(160, 21);
            this.cboType.TabIndex = 201;
            this.cboType.SelectionChangeCommitted += new System.EventHandler(this.cboType_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(307, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 202;
            this.label1.Text = "Loại hiển thị";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(8, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 13);
            this.label11.TabIndex = 198;
            this.label11.Text = "Người phụ trách";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // grdData
            // 
            this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdData.ContextMenuStrip = this.contextMenuStrip1;
            this.grdData.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdData.Location = new System.Drawing.Point(2, 47);
            this.grdData.MainView = this.grvData;
            this.grdData.Name = "grdData";
            this.grdData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1,
            this.repositoryItemTextEdit1,
            this.repositoryItemCheckEdit1,
            this.repositoryItemGridLookUpEdit1});
            this.grdData.Size = new System.Drawing.Size(1056, 561);
            this.grdData.TabIndex = 199;
            this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvData});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hủyĐãTrảToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(130, 26);
            // 
            // hủyĐãTrảToolStripMenuItem
            // 
            this.hủyĐãTrảToolStripMenuItem.Name = "hủyĐãTrảToolStripMenuItem";
            this.hủyĐãTrảToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.hủyĐãTrảToolStripMenuItem.Text = "Hủy đã trả";
            this.hủyĐãTrảToolStripMenuItem.Click += new System.EventHandler(this.hủyĐãTrảToolStripMenuItem_Click);
            // 
            // grvData
            // 
            this.grvData.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvData.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvData.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvData.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grvData.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvData.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvData.ColumnPanelRowHeight = 40;
            this.grvData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colUserName,
            this.colItemCode,
            this.colNumber,
            this.colVoucherName,
            this.colUserId_G,
            this.colItemName,
            this.colMonth,
            this.colYear,
            this.colItem,
            this.colCreatedDate,
            this.colCompletedDateDK,
            this.colCompletedDate,
            this.colPaymentTableItemID,
            this.colPaymentTableID,
            this.colReason,
            this.colPayVoucherID,
            this.colChenhLech});
            this.grvData.GridControl = this.grdData;
            this.grvData.GroupCount = 2;
            this.grvData.Name = "grvData";
            this.grvData.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvData.OptionsCustomization.AllowRowSizing = true;
            this.grvData.OptionsView.AllowHtmlDrawHeaders = true;
            this.grvData.OptionsView.ColumnAutoWidth = false;
            this.grvData.OptionsView.RowAutoHeight = true;
            this.grvData.OptionsView.ShowFooter = true;
            this.grvData.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colYear, DevExpress.Data.ColumnSortOrder.Descending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colMonth, DevExpress.Data.ColumnSortOrder.Descending)});
            this.grvData.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grvData_RowCellStyle);
            this.grvData.DoubleClick += new System.EventHandler(this.grvData_DoubleClick);
            // 
            // colID
            // 
            this.colID.AppearanceCell.Options.UseTextOptions = true;
            this.colID.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colID.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.colID.AppearanceHeader.Options.UseFont = true;
            this.colID.AppearanceHeader.Options.UseTextOptions = true;
            this.colID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.Width = 51;
            // 
            // colUserName
            // 
            this.colUserName.AppearanceCell.Options.UseTextOptions = true;
            this.colUserName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colUserName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colUserName.AppearanceHeader.Options.UseFont = true;
            this.colUserName.AppearanceHeader.Options.UseTextOptions = true;
            this.colUserName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUserName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colUserName.Caption = "Người phụ trách";
            this.colUserName.FieldName = "UserName";
            this.colUserName.Name = "colUserName";
            this.colUserName.OptionsColumn.AllowEdit = false;
            this.colUserName.Visible = true;
            this.colUserName.VisibleIndex = 2;
            this.colUserName.Width = 120;
            // 
            // colItemCode
            // 
            this.colItemCode.AppearanceCell.Options.UseTextOptions = true;
            this.colItemCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colItemCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colItemCode.AppearanceHeader.Options.UseFont = true;
            this.colItemCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colItemCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colItemCode.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colItemCode.Caption = "Mã vụ việc";
            this.colItemCode.FieldName = "Code";
            this.colItemCode.Name = "colItemCode";
            this.colItemCode.OptionsColumn.AllowEdit = false;
            this.colItemCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colItemCode.Visible = true;
            this.colItemCode.VisibleIndex = 0;
            this.colItemCode.Width = 80;
            // 
            // colNumber
            // 
            this.colNumber.AppearanceCell.Options.UseTextOptions = true;
            this.colNumber.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colNumber.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colNumber.AppearanceHeader.Options.UseFont = true;
            this.colNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.colNumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNumber.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNumber.Caption = "Số bảng kê";
            this.colNumber.FieldName = "Number";
            this.colNumber.Name = "colNumber";
            this.colNumber.OptionsColumn.AllowEdit = false;
            // 
            // colVoucherName
            // 
            this.colVoucherName.AppearanceCell.Options.UseTextOptions = true;
            this.colVoucherName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colVoucherName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colVoucherName.AppearanceHeader.Options.UseFont = true;
            this.colVoucherName.AppearanceHeader.Options.UseTextOptions = true;
            this.colVoucherName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVoucherName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colVoucherName.Caption = "Tên chứng từ";
            this.colVoucherName.FieldName = "Name";
            this.colVoucherName.Name = "colVoucherName";
            this.colVoucherName.OptionsColumn.AllowEdit = false;
            this.colVoucherName.Visible = true;
            this.colVoucherName.VisibleIndex = 3;
            this.colVoucherName.Width = 106;
            // 
            // colUserId_G
            // 
            this.colUserId_G.Caption = "UserId";
            this.colUserId_G.FieldName = "UserId";
            this.colUserId_G.Name = "colUserId_G";
            // 
            // colItemName
            // 
            this.colItemName.AppearanceCell.Options.UseTextOptions = true;
            this.colItemName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colItemName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colItemName.AppearanceHeader.Options.UseFont = true;
            this.colItemName.AppearanceHeader.Options.UseTextOptions = true;
            this.colItemName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colItemName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colItemName.Caption = "Tên vụ việc";
            this.colItemName.FieldName = "CaseName";
            this.colItemName.Name = "colItemName";
            this.colItemName.OptionsColumn.AllowEdit = false;
            this.colItemName.Visible = true;
            this.colItemName.VisibleIndex = 1;
            // 
            // colMonth
            // 
            this.colMonth.AppearanceCell.Options.UseTextOptions = true;
            this.colMonth.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMonth.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colMonth.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMonth.AppearanceHeader.Options.UseFont = true;
            this.colMonth.AppearanceHeader.Options.UseTextOptions = true;
            this.colMonth.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMonth.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colMonth.Caption = "Tháng";
            this.colMonth.FieldName = "Month";
            this.colMonth.Name = "colMonth";
            this.colMonth.OptionsColumn.AllowEdit = false;
            // 
            // colYear
            // 
            this.colYear.AppearanceCell.Options.UseTextOptions = true;
            this.colYear.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colYear.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colYear.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colYear.AppearanceHeader.Options.UseFont = true;
            this.colYear.AppearanceHeader.Options.UseTextOptions = true;
            this.colYear.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colYear.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colYear.Caption = "Năm";
            this.colYear.FieldName = "Year";
            this.colYear.Name = "colYear";
            this.colYear.OptionsColumn.AllowEdit = false;
            // 
            // colItem
            // 
            this.colItem.AppearanceCell.Options.UseTextOptions = true;
            this.colItem.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colItem.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colItem.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colItem.AppearanceHeader.Options.UseFont = true;
            this.colItem.AppearanceHeader.Options.UseTextOptions = true;
            this.colItem.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colItem.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colItem.Caption = "Vụ việc";
            this.colItem.FieldName = "Item";
            this.colItem.Name = "colItem";
            // 
            // colCreatedDate
            // 
            this.colCreatedDate.AppearanceCell.Options.UseTextOptions = true;
            this.colCreatedDate.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCreatedDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCreatedDate.AppearanceHeader.Options.UseFont = true;
            this.colCreatedDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colCreatedDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCreatedDate.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCreatedDate.Caption = "Ngày nợ";
            this.colCreatedDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colCreatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCreatedDate.FieldName = "CreatedDate";
            this.colCreatedDate.Name = "colCreatedDate";
            this.colCreatedDate.OptionsColumn.AllowEdit = false;
            // 
            // colCompletedDateDK
            // 
            this.colCompletedDateDK.AppearanceCell.Options.UseTextOptions = true;
            this.colCompletedDateDK.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCompletedDateDK.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCompletedDateDK.AppearanceHeader.Options.UseFont = true;
            this.colCompletedDateDK.AppearanceHeader.Options.UseTextOptions = true;
            this.colCompletedDateDK.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCompletedDateDK.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCompletedDateDK.Caption = "Ngày trả dự kiến";
            this.colCompletedDateDK.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colCompletedDateDK.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCompletedDateDK.FieldName = "CompletedDateDK";
            this.colCompletedDateDK.Name = "colCompletedDateDK";
            this.colCompletedDateDK.OptionsColumn.AllowEdit = false;
            this.colCompletedDateDK.Visible = true;
            this.colCompletedDateDK.VisibleIndex = 4;
            // 
            // colCompletedDate
            // 
            this.colCompletedDate.AppearanceCell.Options.UseTextOptions = true;
            this.colCompletedDate.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCompletedDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCompletedDate.AppearanceHeader.Options.UseFont = true;
            this.colCompletedDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colCompletedDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCompletedDate.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCompletedDate.Caption = "Ngày trả thực tế";
            this.colCompletedDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colCompletedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCompletedDate.FieldName = "CompletedDate";
            this.colCompletedDate.Name = "colCompletedDate";
            this.colCompletedDate.OptionsColumn.AllowEdit = false;
            this.colCompletedDate.Visible = true;
            this.colCompletedDate.VisibleIndex = 5;
            // 
            // colPaymentTableItemID
            // 
            this.colPaymentTableItemID.Caption = "PaymentTableItemID";
            this.colPaymentTableItemID.FieldName = "PaymentTableItemID";
            this.colPaymentTableItemID.Name = "colPaymentTableItemID";
            // 
            // colPaymentTableID
            // 
            this.colPaymentTableID.Caption = "PaymentTableID";
            this.colPaymentTableID.FieldName = "PaymentTableID";
            this.colPaymentTableID.Name = "colPaymentTableID";
            // 
            // colReason
            // 
            this.colReason.AppearanceCell.Options.UseTextOptions = true;
            this.colReason.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colReason.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colReason.AppearanceHeader.Options.UseFont = true;
            this.colReason.AppearanceHeader.Options.UseTextOptions = true;
            this.colReason.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colReason.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colReason.Caption = "Lí do gia hạn";
            this.colReason.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colReason.FieldName = "Reason";
            this.colReason.Name = "colReason";
            this.colReason.Visible = true;
            this.colReason.VisibleIndex = 6;
            this.colReason.Width = 247;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // colPayVoucherID
            // 
            this.colPayVoucherID.Caption = "PayVoucherID";
            this.colPayVoucherID.FieldName = "PayVoucherID";
            this.colPayVoucherID.Name = "colPayVoucherID";
            // 
            // colChenhLech
            // 
            this.colChenhLech.Caption = "Chênh lệch";
            this.colChenhLech.FieldName = "TotalDiff";
            this.colChenhLech.Name = "colChenhLech";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.DisplayFormat.FormatString = "n0";
            this.repositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit1.EditFormat.FormatString = "n0";
            this.repositoryItemTextEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit1.Mask.EditMask = "n0";
            this.repositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTextEdit1.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // repositoryItemGridLookUpEdit1
            // 
            this.repositoryItemGridLookUpEdit1.AutoHeight = false;
            this.repositoryItemGridLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit1.Name = "repositoryItemGridLookUpEdit1";
            this.repositoryItemGridLookUpEdit1.NullText = "";
            this.repositoryItemGridLookUpEdit1.View = this.gridView1;
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // btnExeclReport
            // 
            this.btnExeclReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExeclReport.Appearance.BackColor = System.Drawing.Color.White;
            this.btnExeclReport.Appearance.BackColor2 = System.Drawing.Color.White;
            this.btnExeclReport.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnExeclReport.Appearance.Options.UseBackColor = true;
            this.btnExeclReport.Appearance.Options.UseFont = true;
            this.btnExeclReport.Image = ((System.Drawing.Image)(resources.GetObject("btnExeclReport.Image")));
            this.btnExeclReport.Location = new System.Drawing.Point(939, 6);
            this.btnExeclReport.Name = "btnExeclReport";
            this.btnExeclReport.Size = new System.Drawing.Size(118, 28);
            this.btnExeclReport.TabIndex = 200;
            this.btnExeclReport.Text = "Xuất báo cáo";
            this.btnExeclReport.Click += new System.EventHandler(this.btnExeclReport_Click);
            // 
            // dtpDateOut
            // 
            this.dtpDateOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDateOut.EditValue = null;
            this.dtpDateOut.Location = new System.Drawing.Point(567, 73);
            this.dtpDateOut.Name = "dtpDateOut";
            this.dtpDateOut.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtpDateOut.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpDateOut.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtpDateOut.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpDateOut.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtpDateOut.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtpDateOut.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtpDateOut.Size = new System.Drawing.Size(118, 20);
            this.dtpDateOut.TabIndex = 214;
            // 
            // lblDateOut
            // 
            this.lblDateOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDateOut.AutoSize = true;
            this.lblDateOut.ForeColor = System.Drawing.Color.Black;
            this.lblDateOut.Location = new System.Drawing.Point(476, 76);
            this.lblDateOut.Name = "lblDateOut";
            this.lblDateOut.Size = new System.Drawing.Size(85, 13);
            this.lblDateOut.TabIndex = 213;
            this.lblDateOut.Text = "Ngày trả dự kiến";
            // 
            // txtReason
            // 
            this.txtReason.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReason.Location = new System.Drawing.Point(735, 58);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(222, 58);
            this.txtReason.TabIndex = 215;
            // 
            // lblReason
            // 
            this.lblReason.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReason.AutoSize = true;
            this.lblReason.ForeColor = System.Drawing.Color.Black;
            this.lblReason.Location = new System.Drawing.Point(696, 76);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(33, 13);
            this.lblReason.TabIndex = 213;
            this.lblReason.Text = "Lý do";
            // 
            // btnSaveHistory
            // 
            this.btnSaveHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveHistory.ForeColor = System.Drawing.Color.Black;
            this.btnSaveHistory.Location = new System.Drawing.Point(960, 71);
            this.btnSaveHistory.Name = "btnSaveHistory";
            this.btnSaveHistory.Size = new System.Drawing.Size(64, 32);
            this.btnSaveHistory.TabIndex = 216;
            this.btnSaveHistory.Text = "Ghi";
            this.btnSaveHistory.UseVisualStyleBackColor = true;
            this.btnSaveHistory.Click += new System.EventHandler(this.btnSaveHistory_Click);
            // 
            // btnDateOut
            // 
            this.btnDateOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDateOut.Appearance.BackColor = System.Drawing.Color.White;
            this.btnDateOut.Appearance.BackColor2 = System.Drawing.Color.White;
            this.btnDateOut.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnDateOut.Appearance.Options.UseBackColor = true;
            this.btnDateOut.Appearance.Options.UseFont = true;
            this.btnDateOut.Location = new System.Drawing.Point(849, 6);
            this.btnDateOut.Name = "btnDateOut";
            this.btnDateOut.Size = new System.Drawing.Size(87, 28);
            this.btnDateOut.TabIndex = 200;
            this.btnDateOut.Text = "Gia hạn";
            this.btnDateOut.Click += new System.EventHandler(this.btnDateOut_Click);
            // 
            // btnDaTra
            // 
            this.btnDaTra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDaTra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDaTra.Location = new System.Drawing.Point(760, 6);
            this.btnDaTra.Name = "btnDaTra";
            this.btnDaTra.Size = new System.Drawing.Size(87, 28);
            this.btnDaTra.TabIndex = 217;
            this.btnDaTra.Text = "Đã trả";
            this.btnDaTra.UseVisualStyleBackColor = true;
            this.btnDaTra.Click += new System.EventHandler(this.btnDaTra_Click);
            // 
            // btnCheckHoaDon
            // 
            this.btnCheckHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckHoaDon.Location = new System.Drawing.Point(564, 6);
            this.btnCheckHoaDon.Name = "btnCheckHoaDon";
            this.btnCheckHoaDon.Size = new System.Drawing.Size(195, 28);
            this.btnCheckHoaDon.TabIndex = 218;
            this.btnCheckHoaDon.Text = "Check báo giá, hóa đơn";
            this.btnCheckHoaDon.UseVisualStyleBackColor = true;
            this.btnCheckHoaDon.Click += new System.EventHandler(this.btnCheckHoaDon_Click);
            // 
            // frmReportVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 611);
            this.Controls.Add(this.btnCheckHoaDon);
            this.Controls.Add(this.btnDaTra);
            this.Controls.Add(this.btnSaveHistory);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.dtpDateOut);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.lblDateOut);
            this.Controls.Add(this.cboUser);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.btnDateOut);
            this.Controls.Add(this.btnExeclReport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.grdData);
            this.Name = "frmReportVoucher";
            this.Text = "BÁO CÁO NỢ CHỨNG TỪ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReportVoucher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCboUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateOut.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateOut.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn colCompletedDate;
        private DevExpress.XtraEditors.SearchLookUpEdit cboUser;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCboUser;
        private DevExpress.XtraGrid.Columns.GridColumn colUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colFullName;
        private DevExpress.XtraGrid.Columns.GridColumn colAccount;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartmentName;
        private DevExpress.XtraGrid.Columns.GridColumn colUserCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCompletedDateDK;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentTableItemID;
        private DevExpress.XtraGrid.Columns.GridColumn colYear;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentTableID;
        private DevExpress.XtraGrid.Columns.GridColumn colItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private System.Windows.Forms.ComboBox cboType;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton btnExeclReport;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colMonth;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colItemName;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.Columns.GridColumn colUserId_G;
        private DevExpress.XtraGrid.Columns.GridColumn colItemCode;
        private System.Windows.Forms.Label label11;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colNumber;
        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.Grid.GridView grvData;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colVoucherName;
        private DevExpress.XtraEditors.DateEdit dtpDateOut;
        private System.Windows.Forms.Label lblDateOut;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.Button btnSaveHistory;
        private DevExpress.XtraEditors.SimpleButton btnDateOut;
        private DevExpress.XtraGrid.Columns.GridColumn colReason;
        private System.Windows.Forms.Button btnDaTra;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hủyĐãTrảToolStripMenuItem;
        private System.Windows.Forms.Button btnCheckHoaDon;
        private DevExpress.XtraGrid.Columns.GridColumn colPayVoucherID;
        private DevExpress.XtraGrid.Columns.GridColumn colChenhLech;
    }
}