namespace BMS
{
    partial class frmPartWarning
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
            this.grdMaterial = new DevExpress.XtraGrid.GridControl();
            this.grvMaterial = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMProposalCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMPartsName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colMcheck = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colMProjectCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMDateAboutE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMPartsCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMSupplierName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupplierCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdMaterial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMaterial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // grdMaterial
            // 
            this.grdMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdMaterial.Location = new System.Drawing.Point(3, 2);
            this.grdMaterial.MainView = this.grvMaterial;
            this.grdMaterial.Name = "grdMaterial";
            this.grdMaterial.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit2,
            this.repositoryItemCheckEdit2});
            this.grdMaterial.Size = new System.Drawing.Size(1188, 462);
            this.grdMaterial.TabIndex = 19;
            this.grdMaterial.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvMaterial});
            // 
            // grvMaterial
            // 
            this.grvMaterial.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvMaterial.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvMaterial.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvMaterial.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvMaterial.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvMaterial.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvMaterial.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMID,
            this.colMProposalCode,
            this.colMPartsName,
            this.colMcheck,
            this.colMProjectCode,
            this.colMDateAboutE,
            this.colMPartsCode,
            this.colMPrice,
            this.colMSupplierName,
            this.colSupplierCode,
            this.colMQty,
            this.colMUserName});
            this.grvMaterial.GridControl = this.grdMaterial;
            this.grvMaterial.GroupCount = 2;
            this.grvMaterial.Name = "grvMaterial";
            this.grvMaterial.OptionsFind.AlwaysVisible = true;
            this.grvMaterial.OptionsView.ColumnAutoWidth = false;
            this.grvMaterial.OptionsView.RowAutoHeight = true;
            this.grvMaterial.OptionsView.ShowFooter = true;
            this.grvMaterial.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colMUserName, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colMProjectCode, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvMaterial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvMaterial_KeyDown);
            // 
            // colMID
            // 
            this.colMID.AppearanceHeader.Options.UseTextOptions = true;
            this.colMID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMID.Caption = "ID";
            this.colMID.FieldName = "ID";
            this.colMID.Name = "colMID";
            // 
            // colMProposalCode
            // 
            this.colMProposalCode.AppearanceCell.Options.UseTextOptions = true;
            this.colMProposalCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMProposalCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMProposalCode.AppearanceHeader.Options.UseFont = true;
            this.colMProposalCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colMProposalCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMProposalCode.Caption = "YCMVT";
            this.colMProposalCode.FieldName = "ProposalCode";
            this.colMProposalCode.Name = "colMProposalCode";
            this.colMProposalCode.OptionsColumn.AllowEdit = false;
            this.colMProposalCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colMProposalCode.Visible = true;
            this.colMProposalCode.VisibleIndex = 1;
            this.colMProposalCode.Width = 123;
            // 
            // colMPartsName
            // 
            this.colMPartsName.AppearanceCell.Options.UseTextOptions = true;
            this.colMPartsName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMPartsName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMPartsName.AppearanceHeader.Options.UseFont = true;
            this.colMPartsName.AppearanceHeader.Options.UseTextOptions = true;
            this.colMPartsName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMPartsName.Caption = "Tên vật tư";
            this.colMPartsName.ColumnEdit = this.repositoryItemMemoEdit2;
            this.colMPartsName.FieldName = "PartsName";
            this.colMPartsName.Name = "colMPartsName";
            this.colMPartsName.OptionsColumn.AllowEdit = false;
            this.colMPartsName.Visible = true;
            this.colMPartsName.VisibleIndex = 3;
            this.colMPartsName.Width = 226;
            // 
            // repositoryItemMemoEdit2
            // 
            this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
            // 
            // colMcheck
            // 
            this.colMcheck.AppearanceCell.Options.UseTextOptions = true;
            this.colMcheck.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMcheck.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMcheck.AppearanceHeader.Options.UseFont = true;
            this.colMcheck.AppearanceHeader.Options.UseTextOptions = true;
            this.colMcheck.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMcheck.Caption = "Chọn";
            this.colMcheck.ColumnEdit = this.repositoryItemCheckEdit2;
            this.colMcheck.FieldName = "check";
            this.colMcheck.Name = "colMcheck";
            this.colMcheck.Visible = true;
            this.colMcheck.VisibleIndex = 0;
            this.colMcheck.Width = 70;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // colMProjectCode
            // 
            this.colMProjectCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMProjectCode.AppearanceHeader.Options.UseFont = true;
            this.colMProjectCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colMProjectCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMProjectCode.Caption = "Mã dự án";
            this.colMProjectCode.FieldName = "ProjectCode";
            this.colMProjectCode.Name = "colMProjectCode";
            // 
            // colMDateAboutE
            // 
            this.colMDateAboutE.AppearanceCell.Options.UseTextOptions = true;
            this.colMDateAboutE.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMDateAboutE.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMDateAboutE.AppearanceHeader.Options.UseFont = true;
            this.colMDateAboutE.AppearanceHeader.Options.UseTextOptions = true;
            this.colMDateAboutE.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMDateAboutE.Caption = "Ngày về dự kiến";
            this.colMDateAboutE.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colMDateAboutE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colMDateAboutE.FieldName = "DateAboutE";
            this.colMDateAboutE.Name = "colMDateAboutE";
            this.colMDateAboutE.OptionsColumn.AllowEdit = false;
            this.colMDateAboutE.Visible = true;
            this.colMDateAboutE.VisibleIndex = 4;
            this.colMDateAboutE.Width = 106;
            // 
            // colMPartsCode
            // 
            this.colMPartsCode.AppearanceCell.Options.UseTextOptions = true;
            this.colMPartsCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMPartsCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMPartsCode.AppearanceHeader.Options.UseFont = true;
            this.colMPartsCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colMPartsCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMPartsCode.Caption = "Mã vật tư";
            this.colMPartsCode.FieldName = "PartsCode";
            this.colMPartsCode.Name = "colMPartsCode";
            this.colMPartsCode.OptionsColumn.AllowEdit = false;
            this.colMPartsCode.Visible = true;
            this.colMPartsCode.VisibleIndex = 2;
            this.colMPartsCode.Width = 139;
            // 
            // colMPrice
            // 
            this.colMPrice.AppearanceCell.Options.UseTextOptions = true;
            this.colMPrice.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMPrice.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMPrice.AppearanceHeader.Options.UseFont = true;
            this.colMPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.colMPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMPrice.Caption = "Giá";
            this.colMPrice.DisplayFormat.FormatString = "n0";
            this.colMPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMPrice.FieldName = "Price";
            this.colMPrice.Name = "colMPrice";
            this.colMPrice.OptionsColumn.AllowEdit = false;
            this.colMPrice.Visible = true;
            this.colMPrice.VisibleIndex = 6;
            this.colMPrice.Width = 114;
            // 
            // colMSupplierName
            // 
            this.colMSupplierName.AppearanceCell.Options.UseTextOptions = true;
            this.colMSupplierName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMSupplierName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colMSupplierName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMSupplierName.AppearanceHeader.Options.UseFont = true;
            this.colMSupplierName.AppearanceHeader.Options.UseTextOptions = true;
            this.colMSupplierName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMSupplierName.Caption = "Nhà cung cấp";
            this.colMSupplierName.ColumnEdit = this.repositoryItemMemoEdit2;
            this.colMSupplierName.FieldName = "SupplierName";
            this.colMSupplierName.Name = "colMSupplierName";
            this.colMSupplierName.OptionsColumn.AllowEdit = false;
            this.colMSupplierName.Visible = true;
            this.colMSupplierName.VisibleIndex = 7;
            this.colMSupplierName.Width = 209;
            // 
            // colSupplierCode
            // 
            this.colSupplierCode.AppearanceCell.Options.UseTextOptions = true;
            this.colSupplierCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.colSupplierCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colSupplierCode.AppearanceHeader.Options.UseFont = true;
            this.colSupplierCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colSupplierCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSupplierCode.Caption = "Mã nhà cung cấp";
            this.colSupplierCode.FieldName = "SupplierCode";
            this.colSupplierCode.Name = "colSupplierCode";
            this.colSupplierCode.Visible = true;
            this.colSupplierCode.VisibleIndex = 8;
            this.colSupplierCode.Width = 111;
            // 
            // colMQty
            // 
            this.colMQty.AppearanceCell.Options.UseTextOptions = true;
            this.colMQty.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMQty.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMQty.AppearanceHeader.Options.UseFont = true;
            this.colMQty.AppearanceHeader.Options.UseTextOptions = true;
            this.colMQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMQty.Caption = "SL";
            this.colMQty.DisplayFormat.FormatString = "n0";
            this.colMQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMQty.FieldName = "TotalBuy";
            this.colMQty.Name = "colMQty";
            this.colMQty.OptionsColumn.AllowEdit = false;
            this.colMQty.Visible = true;
            this.colMQty.VisibleIndex = 5;
            this.colMQty.Width = 50;
            // 
            // colMUserName
            // 
            this.colMUserName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMUserName.AppearanceHeader.Options.UseFont = true;
            this.colMUserName.AppearanceHeader.Options.UseTextOptions = true;
            this.colMUserName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMUserName.Caption = "Người phụ trách";
            this.colMUserName.FieldName = "UserName";
            this.colMUserName.Name = "colMUserName";
            this.colMUserName.Visible = true;
            this.colMUserName.VisibleIndex = 9;
            // 
            // frmPartWarning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1195, 467);
            this.Controls.Add(this.grdMaterial);
            this.Name = "frmPartWarning";
            this.Text = "CẢNH BÁO VẬT TƯ GẦN ĐẾN HẠN VỀ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPartWarning_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdMaterial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMaterial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdMaterial;
        private DevExpress.XtraGrid.Views.Grid.GridView grvMaterial;
        private DevExpress.XtraGrid.Columns.GridColumn colMID;
        private DevExpress.XtraGrid.Columns.GridColumn colMProposalCode;
        private DevExpress.XtraGrid.Columns.GridColumn colMPartsName;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colMcheck;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colMProjectCode;
        private DevExpress.XtraGrid.Columns.GridColumn colMDateAboutE;
        private DevExpress.XtraGrid.Columns.GridColumn colMPartsCode;
        private DevExpress.XtraGrid.Columns.GridColumn colMPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colMSupplierName;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplierCode;
        private DevExpress.XtraGrid.Columns.GridColumn colMQty;
        private DevExpress.XtraGrid.Columns.GridColumn colMUserName;
    }
}