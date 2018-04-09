namespace BMS
{
    partial class frmCustomerManagerKD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerManagerKD));
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.grvData = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colCode = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colSupplierId = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colAddress = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colOffice = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colMST = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colContactPhone = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colCreatedDate = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colUpdatedDate = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colStatus = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colBankAcount = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colBankAcountName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colBankName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colPaymentTerm = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colProductProvided = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colAgency = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colDiscount = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colContactPerson = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colPhone = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colEmail = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colUserName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colHopDongNguyenTac = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colBangDanhGia = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colDKKD = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colUyQuyenHang = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colDateChecked = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colDateCheckedNext = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.mnuMenu = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.mnuMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdData
            // 
            this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdData.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdData.Location = new System.Drawing.Point(0, 45);
            this.grdData.MainView = this.grvData;
            this.grdData.Name = "grdData";
            this.grdData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemMemoEdit1});
            this.grdData.Size = new System.Drawing.Size(1236, 434);
            this.grdData.TabIndex = 20;
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
            this.grvData.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand2,
            this.gridBand3,
            this.gridBand4,
            this.gridBand5});
            this.grvData.ColumnPanelRowHeight = 60;
            this.grvData.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colName,
            this.colCode,
            this.colSupplierId,
            this.colContactPerson,
            this.colPhone,
            this.colEmail,
            this.colCreatedDate,
            this.colStatus,
            this.colUyQuyenHang,
            this.colDKKD,
            this.colBangDanhGia,
            this.colHopDongNguyenTac,
            this.colUserName,
            this.colAddress,
            this.colOffice,
            this.colMST,
            this.colContactPhone,
            this.colBankAcount,
            this.colBankAcountName,
            this.colBankName,
            this.colPaymentTerm,
            this.colProductProvided,
            this.colAgency,
            this.colDiscount,
            this.colUpdatedDate,
            this.colDateChecked,
            this.colDateCheckedNext});
            this.grvData.GridControl = this.grdData;
            this.grvData.HorzScrollStep = 5;
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
            this.grvData.OptionsView.ShowGroupPanel = false;
            // 
            // gridBand1
            // 
            this.gridBand1.Columns.Add(this.colCode);
            this.gridBand1.Columns.Add(this.colName);
            this.gridBand1.Columns.Add(this.colSupplierId);
            this.gridBand1.Columns.Add(this.colAddress);
            this.gridBand1.Columns.Add(this.colOffice);
            this.gridBand1.Columns.Add(this.colMST);
            this.gridBand1.Columns.Add(this.colContactPhone);
            this.gridBand1.Columns.Add(this.colCreatedDate);
            this.gridBand1.Columns.Add(this.colUpdatedDate);
            this.gridBand1.Columns.Add(this.colStatus);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.Width = 1283;
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
            this.colCode.Caption = "Mã KH";
            this.colCode.FieldName = "SupplierCode";
            this.colCode.Name = "colCode";
            this.colCode.OptionsColumn.AllowEdit = false;
            this.colCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colCode.Visible = true;
            this.colCode.Width = 116;
            // 
            // colName
            // 
            this.colName.AppearanceCell.Options.UseTextOptions = true;
            this.colName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colName.AppearanceHeader.Options.UseFont = true;
            this.colName.AppearanceHeader.Options.UseTextOptions = true;
            this.colName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colName.Caption = "Tên KH";
            this.colName.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colName.FieldName = "SupplierName";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.OptionsColumn.AllowSize = false;
            this.colName.Visible = true;
            this.colName.Width = 240;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Appearance.Options.UseTextOptions = true;
            this.repositoryItemMemoEdit1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // colSupplierId
            // 
            this.colSupplierId.AppearanceCell.Options.UseTextOptions = true;
            this.colSupplierId.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colSupplierId.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colSupplierId.AppearanceHeader.Options.UseTextOptions = true;
            this.colSupplierId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSupplierId.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colSupplierId.Caption = "ID";
            this.colSupplierId.FieldName = "SupplierId";
            this.colSupplierId.Name = "colSupplierId";
            this.colSupplierId.OptionsColumn.AllowEdit = false;
            // 
            // colAddress
            // 
            this.colAddress.AppearanceCell.Options.UseTextOptions = true;
            this.colAddress.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colAddress.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colAddress.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colAddress.AppearanceHeader.Options.UseFont = true;
            this.colAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.colAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAddress.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colAddress.Caption = "Địa chỉ";
            this.colAddress.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colAddress.FieldName = "Address";
            this.colAddress.Name = "colAddress";
            this.colAddress.OptionsColumn.AllowEdit = false;
            this.colAddress.Visible = true;
            this.colAddress.Width = 240;
            // 
            // colOffice
            // 
            this.colOffice.AppearanceCell.Options.UseTextOptions = true;
            this.colOffice.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colOffice.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colOffice.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colOffice.AppearanceHeader.Options.UseFont = true;
            this.colOffice.AppearanceHeader.Options.UseTextOptions = true;
            this.colOffice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colOffice.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colOffice.Caption = "Văn phòng đại diện";
            this.colOffice.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colOffice.FieldName = "Office";
            this.colOffice.Name = "colOffice";
            this.colOffice.OptionsColumn.AllowEdit = false;
            this.colOffice.Visible = true;
            this.colOffice.Width = 240;
            // 
            // colMST
            // 
            this.colMST.AppearanceCell.Options.UseTextOptions = true;
            this.colMST.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMST.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colMST.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMST.AppearanceHeader.Options.UseFont = true;
            this.colMST.AppearanceHeader.Options.UseTextOptions = true;
            this.colMST.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMST.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colMST.Caption = "MST";
            this.colMST.FieldName = "MST";
            this.colMST.Name = "colMST";
            this.colMST.OptionsColumn.AllowEdit = false;
            this.colMST.Visible = true;
            this.colMST.Width = 112;
            // 
            // colContactPhone
            // 
            this.colContactPhone.AppearanceCell.Options.UseTextOptions = true;
            this.colContactPhone.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colContactPhone.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colContactPhone.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colContactPhone.AppearanceHeader.Options.UseFont = true;
            this.colContactPhone.AppearanceHeader.Options.UseTextOptions = true;
            this.colContactPhone.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colContactPhone.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colContactPhone.Caption = "Điện thoại";
            this.colContactPhone.FieldName = "ContactPhone";
            this.colContactPhone.Name = "colContactPhone";
            this.colContactPhone.OptionsColumn.AllowEdit = false;
            this.colContactPhone.Visible = true;
            this.colContactPhone.Width = 91;
            // 
            // colCreatedDate
            // 
            this.colCreatedDate.AppearanceCell.Options.UseTextOptions = true;
            this.colCreatedDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCreatedDate.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCreatedDate.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCreatedDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCreatedDate.AppearanceHeader.Options.UseFont = true;
            this.colCreatedDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colCreatedDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCreatedDate.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCreatedDate.Caption = "Ngày tạo";
            this.colCreatedDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colCreatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCreatedDate.FieldName = "DateArising";
            this.colCreatedDate.Name = "colCreatedDate";
            this.colCreatedDate.OptionsColumn.AllowEdit = false;
            this.colCreatedDate.Visible = true;
            this.colCreatedDate.Width = 82;
            // 
            // colUpdatedDate
            // 
            this.colUpdatedDate.AppearanceCell.Options.UseTextOptions = true;
            this.colUpdatedDate.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colUpdatedDate.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colUpdatedDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colUpdatedDate.AppearanceHeader.Options.UseFont = true;
            this.colUpdatedDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colUpdatedDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUpdatedDate.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colUpdatedDate.Caption = "Ngày cập nhật";
            this.colUpdatedDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colUpdatedDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colUpdatedDate.FieldName = "UpdatedDate";
            this.colUpdatedDate.Name = "colUpdatedDate";
            this.colUpdatedDate.OptionsColumn.AllowEdit = false;
            this.colUpdatedDate.Visible = true;
            // 
            // colStatus
            // 
            this.colStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colStatus.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colStatus.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colStatus.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colStatus.AppearanceHeader.Options.UseFont = true;
            this.colStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.colStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStatus.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colStatus.Caption = "Trạng thái";
            this.colStatus.FieldName = "StatusDisable";
            this.colStatus.Name = "colStatus";
            this.colStatus.OptionsColumn.AllowEdit = false;
            this.colStatus.Visible = true;
            this.colStatus.Width = 87;
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand2.AppearanceHeader.Options.UseFont = true;
            this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand2.Caption = "THÔNG TIN THANH TOÁN";
            this.gridBand2.Columns.Add(this.colBankAcount);
            this.gridBand2.Columns.Add(this.colBankAcountName);
            this.gridBand2.Columns.Add(this.colBankName);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.Width = 555;
            // 
            // colBankAcount
            // 
            this.colBankAcount.AppearanceCell.Options.UseTextOptions = true;
            this.colBankAcount.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colBankAcount.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colBankAcount.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colBankAcount.AppearanceHeader.Options.UseFont = true;
            this.colBankAcount.AppearanceHeader.Options.UseTextOptions = true;
            this.colBankAcount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBankAcount.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colBankAcount.Caption = "Số tài khoản";
            this.colBankAcount.FieldName = "BankAcount";
            this.colBankAcount.Name = "colBankAcount";
            this.colBankAcount.OptionsColumn.AllowEdit = false;
            this.colBankAcount.Visible = true;
            // 
            // colBankAcountName
            // 
            this.colBankAcountName.AppearanceCell.Options.UseTextOptions = true;
            this.colBankAcountName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colBankAcountName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colBankAcountName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colBankAcountName.AppearanceHeader.Options.UseFont = true;
            this.colBankAcountName.AppearanceHeader.Options.UseTextOptions = true;
            this.colBankAcountName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBankAcountName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colBankAcountName.Caption = "Tên TK-Tên công ty";
            this.colBankAcountName.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colBankAcountName.FieldName = "BankAcountName";
            this.colBankAcountName.Name = "colBankAcountName";
            this.colBankAcountName.OptionsColumn.AllowEdit = false;
            this.colBankAcountName.Visible = true;
            this.colBankAcountName.Width = 240;
            // 
            // colBankName
            // 
            this.colBankName.AppearanceCell.Options.UseTextOptions = true;
            this.colBankName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colBankName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colBankName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colBankName.AppearanceHeader.Options.UseFont = true;
            this.colBankName.AppearanceHeader.Options.UseTextOptions = true;
            this.colBankName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBankName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colBankName.Caption = "Địa chỉ tài khoản";
            this.colBankName.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colBankName.FieldName = "BankName";
            this.colBankName.Name = "colBankName";
            this.colBankName.OptionsColumn.AllowEdit = false;
            this.colBankName.Visible = true;
            this.colBankName.Width = 240;
            // 
            // gridBand3
            // 
            this.gridBand3.Columns.Add(this.colPaymentTerm);
            this.gridBand3.Columns.Add(this.colProductProvided);
            this.gridBand3.Columns.Add(this.colAgency);
            this.gridBand3.Columns.Add(this.colDiscount);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.Width = 465;
            // 
            // colPaymentTerm
            // 
            this.colPaymentTerm.AppearanceCell.Options.UseTextOptions = true;
            this.colPaymentTerm.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPaymentTerm.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPaymentTerm.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colPaymentTerm.AppearanceHeader.Options.UseFont = true;
            this.colPaymentTerm.AppearanceHeader.Options.UseTextOptions = true;
            this.colPaymentTerm.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPaymentTerm.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPaymentTerm.Caption = "Điều khoản thanh toán";
            this.colPaymentTerm.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colPaymentTerm.FieldName = "PaymentTerm";
            this.colPaymentTerm.Name = "colPaymentTerm";
            this.colPaymentTerm.OptionsColumn.AllowEdit = false;
            this.colPaymentTerm.Visible = true;
            this.colPaymentTerm.Width = 240;
            // 
            // colProductProvided
            // 
            this.colProductProvided.AppearanceCell.Options.UseTextOptions = true;
            this.colProductProvided.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colProductProvided.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colProductProvided.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colProductProvided.AppearanceHeader.Options.UseFont = true;
            this.colProductProvided.AppearanceHeader.Options.UseTextOptions = true;
            this.colProductProvided.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProductProvided.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colProductProvided.Caption = "Sản phẩm dịch vụ cung cấp";
            this.colProductProvided.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colProductProvided.FieldName = "ProductProvided";
            this.colProductProvided.Name = "colProductProvided";
            this.colProductProvided.OptionsColumn.AllowEdit = false;
            this.colProductProvided.Visible = true;
            // 
            // colAgency
            // 
            this.colAgency.AppearanceCell.Options.UseTextOptions = true;
            this.colAgency.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colAgency.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colAgency.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colAgency.AppearanceHeader.Options.UseFont = true;
            this.colAgency.AppearanceHeader.Options.UseTextOptions = true;
            this.colAgency.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAgency.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colAgency.Caption = "Đại lý";
            this.colAgency.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colAgency.FieldName = "Agency";
            this.colAgency.Name = "colAgency";
            this.colAgency.OptionsColumn.AllowEdit = false;
            this.colAgency.Visible = true;
            // 
            // colDiscount
            // 
            this.colDiscount.AppearanceCell.Options.UseTextOptions = true;
            this.colDiscount.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDiscount.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDiscount.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colDiscount.AppearanceHeader.Options.UseFont = true;
            this.colDiscount.AppearanceHeader.Options.UseTextOptions = true;
            this.colDiscount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDiscount.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDiscount.Caption = "% Chiết khấu";
            this.colDiscount.FieldName = "Discount";
            this.colDiscount.Name = "colDiscount";
            this.colDiscount.OptionsColumn.AllowEdit = false;
            this.colDiscount.Visible = true;
            // 
            // gridBand4
            // 
            this.gridBand4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand4.AppearanceHeader.Options.UseFont = true;
            this.gridBand4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand4.Caption = "LIÊN HỆ";
            this.gridBand4.Columns.Add(this.colContactPerson);
            this.gridBand4.Columns.Add(this.colPhone);
            this.gridBand4.Columns.Add(this.colEmail);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.Width = 369;
            // 
            // colContactPerson
            // 
            this.colContactPerson.AppearanceCell.Options.UseTextOptions = true;
            this.colContactPerson.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colContactPerson.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colContactPerson.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colContactPerson.AppearanceHeader.Options.UseFont = true;
            this.colContactPerson.AppearanceHeader.Options.UseTextOptions = true;
            this.colContactPerson.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colContactPerson.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colContactPerson.Caption = "Người đại diện";
            this.colContactPerson.FieldName = "ContactPerson";
            this.colContactPerson.Name = "colContactPerson";
            this.colContactPerson.OptionsColumn.AllowEdit = false;
            this.colContactPerson.OptionsColumn.AllowSize = false;
            this.colContactPerson.Visible = true;
            this.colContactPerson.Width = 120;
            // 
            // colPhone
            // 
            this.colPhone.AppearanceCell.Options.UseTextOptions = true;
            this.colPhone.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPhone.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPhone.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colPhone.AppearanceHeader.Options.UseFont = true;
            this.colPhone.AppearanceHeader.Options.UseTextOptions = true;
            this.colPhone.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPhone.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPhone.Caption = "Số ĐT";
            this.colPhone.FieldName = "Phone";
            this.colPhone.Name = "colPhone";
            this.colPhone.OptionsColumn.AllowEdit = false;
            this.colPhone.Visible = true;
            this.colPhone.Width = 100;
            // 
            // colEmail
            // 
            this.colEmail.AppearanceCell.Options.UseTextOptions = true;
            this.colEmail.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colEmail.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colEmail.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colEmail.AppearanceHeader.Options.UseFont = true;
            this.colEmail.AppearanceHeader.Options.UseTextOptions = true;
            this.colEmail.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colEmail.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colEmail.Caption = "Email";
            this.colEmail.FieldName = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.OptionsColumn.AllowEdit = false;
            this.colEmail.Visible = true;
            this.colEmail.Width = 149;
            // 
            // gridBand5
            // 
            this.gridBand5.Columns.Add(this.colUserName);
            this.gridBand5.Columns.Add(this.colHopDongNguyenTac);
            this.gridBand5.Columns.Add(this.colBangDanhGia);
            this.gridBand5.Columns.Add(this.colDKKD);
            this.gridBand5.Columns.Add(this.colUyQuyenHang);
            this.gridBand5.Columns.Add(this.colDateChecked);
            this.gridBand5.Columns.Add(this.colDateCheckedNext);
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.Width = 566;
            // 
            // colUserName
            // 
            this.colUserName.AppearanceCell.Options.UseTextOptions = true;
            this.colUserName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colUserName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
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
            this.colUserName.Width = 118;
            // 
            // colHopDongNguyenTac
            // 
            this.colHopDongNguyenTac.AppearanceCell.Options.UseTextOptions = true;
            this.colHopDongNguyenTac.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colHopDongNguyenTac.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colHopDongNguyenTac.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colHopDongNguyenTac.AppearanceHeader.Options.UseFont = true;
            this.colHopDongNguyenTac.AppearanceHeader.Options.UseTextOptions = true;
            this.colHopDongNguyenTac.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHopDongNguyenTac.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colHopDongNguyenTac.Caption = "Hợp đồng nguyên tắc";
            this.colHopDongNguyenTac.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colHopDongNguyenTac.FieldName = "HopDongNguyenTac";
            this.colHopDongNguyenTac.Name = "colHopDongNguyenTac";
            this.colHopDongNguyenTac.OptionsColumn.AllowEdit = false;
            this.colHopDongNguyenTac.OptionsColumn.AllowSize = false;
            this.colHopDongNguyenTac.Visible = true;
            this.colHopDongNguyenTac.Width = 60;
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
            // colBangDanhGia
            // 
            this.colBangDanhGia.AppearanceCell.Options.UseTextOptions = true;
            this.colBangDanhGia.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colBangDanhGia.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colBangDanhGia.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colBangDanhGia.AppearanceHeader.Options.UseFont = true;
            this.colBangDanhGia.AppearanceHeader.Options.UseTextOptions = true;
            this.colBangDanhGia.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colBangDanhGia.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colBangDanhGia.Caption = "Bảng đánh giá NCC";
            this.colBangDanhGia.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colBangDanhGia.FieldName = "BangDanhGia";
            this.colBangDanhGia.Name = "colBangDanhGia";
            this.colBangDanhGia.OptionsColumn.AllowEdit = false;
            this.colBangDanhGia.OptionsColumn.AllowSize = false;
            this.colBangDanhGia.Visible = true;
            this.colBangDanhGia.Width = 74;
            // 
            // colDKKD
            // 
            this.colDKKD.AppearanceCell.Options.UseTextOptions = true;
            this.colDKKD.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDKKD.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDKKD.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colDKKD.AppearanceHeader.Options.UseFont = true;
            this.colDKKD.AppearanceHeader.Options.UseTextOptions = true;
            this.colDKKD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDKKD.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDKKD.Caption = "Giấy phép ĐKKD";
            this.colDKKD.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colDKKD.FieldName = "DKKD";
            this.colDKKD.Name = "colDKKD";
            this.colDKKD.OptionsColumn.AllowEdit = false;
            this.colDKKD.OptionsColumn.AllowSize = false;
            this.colDKKD.Visible = true;
            this.colDKKD.Width = 82;
            // 
            // colUyQuyenHang
            // 
            this.colUyQuyenHang.AppearanceCell.Options.UseTextOptions = true;
            this.colUyQuyenHang.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colUyQuyenHang.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colUyQuyenHang.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colUyQuyenHang.AppearanceHeader.Options.UseFont = true;
            this.colUyQuyenHang.AppearanceHeader.Options.UseTextOptions = true;
            this.colUyQuyenHang.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUyQuyenHang.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colUyQuyenHang.Caption = "Giấy ủy quyền của hãng cho đại lý";
            this.colUyQuyenHang.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colUyQuyenHang.FieldName = "UyQuyenHang";
            this.colUyQuyenHang.Name = "colUyQuyenHang";
            this.colUyQuyenHang.OptionsColumn.AllowEdit = false;
            this.colUyQuyenHang.OptionsColumn.AllowSize = false;
            this.colUyQuyenHang.Visible = true;
            this.colUyQuyenHang.Width = 82;
            // 
            // colDateChecked
            // 
            this.colDateChecked.AppearanceCell.Options.UseTextOptions = true;
            this.colDateChecked.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDateChecked.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDateChecked.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colDateChecked.AppearanceHeader.Options.UseFont = true;
            this.colDateChecked.AppearanceHeader.Options.UseTextOptions = true;
            this.colDateChecked.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDateChecked.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDateChecked.Caption = "Ngày đánh giá";
            this.colDateChecked.FieldName = "DateChecked";
            this.colDateChecked.Name = "colDateChecked";
            this.colDateChecked.OptionsColumn.AllowEdit = false;
            this.colDateChecked.Visible = true;
            // 
            // colDateCheckedNext
            // 
            this.colDateCheckedNext.AppearanceCell.Options.UseTextOptions = true;
            this.colDateCheckedNext.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDateCheckedNext.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDateCheckedNext.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colDateCheckedNext.AppearanceHeader.Options.UseFont = true;
            this.colDateCheckedNext.AppearanceHeader.Options.UseTextOptions = true;
            this.colDateCheckedNext.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDateCheckedNext.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDateCheckedNext.Caption = "Ngày đánh giá tiếp";
            this.colDateCheckedNext.FieldName = "DateCheckedNext";
            this.colDateCheckedNext.Name = "colDateCheckedNext";
            this.colDateCheckedNext.OptionsColumn.AllowEdit = false;
            this.colDateCheckedNext.Visible = true;
            // 
            // mnuMenu
            // 
            this.mnuMenu.AutoSize = false;
            this.mnuMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.mnuMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.toolStripSeparator6,
            this.btnEdit,
            this.toolStripSeparator4,
            this.btnDel,
            this.toolStripSeparator2,
            this.btnExcel,
            this.toolStripSeparator1,
            this.toolStripButton1});
            this.mnuMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuMenu.Size = new System.Drawing.Size(1236, 42);
            this.mnuMenu.TabIndex = 19;
            this.mnuMenu.Text = "toolStrip2";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(50, 33);
            this.btnAdd.Tag = "";
            this.btnAdd.Text = "Tạo KH";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 23);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(51, 33);
            this.btnEdit.Tag = "";
            this.btnEdit.Text = "Sửa KH";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
            // 
            // btnDel
            // 
            this.btnDel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
            this.btnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(50, 33);
            this.btnDel.Tag = "";
            this.btnDel.Text = "Xóa KH";
            this.btnDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AutoSize = false;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 40);
            // 
            // btnExcel
            // 
            this.btnExcel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(69, 33);
            this.btnExcel.Tag = "";
            this.btnExcel.Text = "Xuất Excel";
            this.btnExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(99, 33);
            this.toolStripButton1.Tag = "frmBaoGiaManagement_Report";
            this.toolStripButton1.Text = "Báo cáo báo giá";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // frmCustomerManagerKD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 479);
            this.Controls.Add(this.grdData);
            this.Controls.Add(this.mnuMenu);
            this.Name = "frmCustomerManagerKD";
            this.Text = "DANH SÁCH KHÁCH HÀNG";
            this.Load += new System.EventHandler(this.frmCustomerManagerKD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView grvData;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colName;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCode;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSupplierId;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colAddress;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colOffice;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colMST;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colContactPhone;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colCreatedDate;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colUpdatedDate;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colStatus;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colBankAcount;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colBankAcountName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colBankName;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colPaymentTerm;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colProductProvided;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colAgency;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colDiscount;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colContactPerson;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colPhone;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colEmail;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colUserName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colHopDongNguyenTac;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colBangDanhGia;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colDKKD;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colUyQuyenHang;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colDateChecked;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colDateCheckedNext;
        private System.Windows.Forms.ToolStrip mnuMenu;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnDel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}