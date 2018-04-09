namespace BMS
{
    partial class frmBaiThucHanhPrice
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
            this.grdModule = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xemChiTiếtGiáModuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grvModule = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colMName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMCVersion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMNVersion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTypeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPriceType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdModule)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvModule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // grdModule
            // 
            this.grdModule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdModule.ContextMenuStrip = this.contextMenuStrip1;
            this.grdModule.Location = new System.Drawing.Point(1, 28);
            this.grdModule.MainView = this.grvModule;
            this.grdModule.Name = "grdModule";
            this.grdModule.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit2});
            this.grdModule.Size = new System.Drawing.Size(586, 461);
            this.grdModule.TabIndex = 18;
            this.grdModule.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvModule});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xemChiTiếtGiáModuleToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(201, 26);
            // 
            // xemChiTiếtGiáModuleToolStripMenuItem
            // 
            this.xemChiTiếtGiáModuleToolStripMenuItem.Name = "xemChiTiếtGiáModuleToolStripMenuItem";
            this.xemChiTiếtGiáModuleToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.xemChiTiếtGiáModuleToolStripMenuItem.Text = "Xem chi tiết giá module";
            this.xemChiTiếtGiáModuleToolStripMenuItem.Click += new System.EventHandler(this.xemChiTiếtGiáModuleToolStripMenuItem_Click);
            // 
            // grvModule
            // 
            this.grvModule.ColumnPanelRowHeight = 40;
            this.grvModule.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMID,
            this.colMCode,
            this.colMName,
            this.colMHang,
            this.colMQty,
            this.colMType,
            this.colMCVersion,
            this.colMNVersion,
            this.colTypeName,
            this.colPrice,
            this.colTotalPrice,
            this.colPriceType});
            this.grvModule.GridControl = this.grdModule;
            this.grvModule.GroupCount = 1;
            this.grvModule.Name = "grvModule";
            this.grvModule.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvModule.OptionsView.ColumnAutoWidth = false;
            this.grvModule.OptionsView.RowAutoHeight = true;
            this.grvModule.OptionsView.ShowFooter = true;
            this.grvModule.OptionsView.ShowGroupPanel = false;
            this.grvModule.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colTypeName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvModule.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grvModule_CustomDrawCell);
            // 
            // colMID
            // 
            this.colMID.Caption = "ID";
            this.colMID.FieldName = "ID";
            this.colMID.Name = "colMID";
            // 
            // colMCode
            // 
            this.colMCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMCode.AppearanceHeader.Options.UseFont = true;
            this.colMCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colMCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMCode.Caption = "Mã";
            this.colMCode.ColumnEdit = this.repositoryItemMemoEdit2;
            this.colMCode.FieldName = "Code";
            this.colMCode.Name = "colMCode";
            this.colMCode.OptionsColumn.AllowEdit = false;
            this.colMCode.OptionsColumn.AllowFocus = false;
            this.colMCode.Visible = true;
            this.colMCode.VisibleIndex = 0;
            this.colMCode.Width = 112;
            // 
            // repositoryItemMemoEdit2
            // 
            this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
            // 
            // colMName
            // 
            this.colMName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMName.AppearanceHeader.Options.UseFont = true;
            this.colMName.AppearanceHeader.Options.UseTextOptions = true;
            this.colMName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMName.Caption = "Tên module";
            this.colMName.ColumnEdit = this.repositoryItemMemoEdit2;
            this.colMName.FieldName = "Name";
            this.colMName.Name = "colMName";
            this.colMName.OptionsColumn.AllowEdit = false;
            this.colMName.OptionsColumn.AllowFocus = false;
            this.colMName.Visible = true;
            this.colMName.VisibleIndex = 1;
            this.colMName.Width = 166;
            // 
            // colMHang
            // 
            this.colMHang.AppearanceCell.Options.UseTextOptions = true;
            this.colMHang.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMHang.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMHang.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMHang.AppearanceHeader.Options.UseFont = true;
            this.colMHang.AppearanceHeader.Options.UseTextOptions = true;
            this.colMHang.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMHang.Caption = "Hãng";
            this.colMHang.FieldName = "Hang";
            this.colMHang.Name = "colMHang";
            this.colMHang.OptionsColumn.AllowEdit = false;
            this.colMHang.OptionsColumn.AllowFocus = false;
            this.colMHang.Visible = true;
            this.colMHang.VisibleIndex = 5;
            this.colMHang.Width = 82;
            // 
            // colMQty
            // 
            this.colMQty.AppearanceCell.Options.UseTextOptions = true;
            this.colMQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colMQty.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMQty.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMQty.AppearanceHeader.Options.UseFont = true;
            this.colMQty.AppearanceHeader.Options.UseTextOptions = true;
            this.colMQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMQty.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colMQty.Caption = "Số lượng";
            this.colMQty.FieldName = "Qty";
            this.colMQty.Name = "colMQty";
            this.colMQty.OptionsColumn.AllowEdit = false;
            this.colMQty.OptionsColumn.AllowFocus = false;
            this.colMQty.Visible = true;
            this.colMQty.VisibleIndex = 2;
            this.colMQty.Width = 44;
            // 
            // colMType
            // 
            this.colMType.Caption = "Type";
            this.colMType.FieldName = "Type";
            this.colMType.Name = "colMType";
            // 
            // colMCVersion
            // 
            this.colMCVersion.AppearanceCell.Options.UseTextOptions = true;
            this.colMCVersion.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMCVersion.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMCVersion.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMCVersion.AppearanceHeader.Options.UseFont = true;
            this.colMCVersion.AppearanceHeader.Options.UseTextOptions = true;
            this.colMCVersion.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMCVersion.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colMCVersion.Caption = "Phiên bản hiện tại";
            this.colMCVersion.DisplayFormat.FormatString = "n0";
            this.colMCVersion.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMCVersion.FieldName = "CVersion";
            this.colMCVersion.Name = "colMCVersion";
            this.colMCVersion.OptionsColumn.AllowEdit = false;
            this.colMCVersion.Width = 64;
            // 
            // colMNVersion
            // 
            this.colMNVersion.AppearanceCell.Options.UseTextOptions = true;
            this.colMNVersion.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMNVersion.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMNVersion.AppearanceHeader.Options.UseFont = true;
            this.colMNVersion.AppearanceHeader.Options.UseTextOptions = true;
            this.colMNVersion.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMNVersion.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colMNVersion.Caption = "Phiên bản mới nhất";
            this.colMNVersion.DisplayFormat.FormatString = "n0";
            this.colMNVersion.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMNVersion.FieldName = "NVersion";
            this.colMNVersion.Name = "colMNVersion";
            this.colMNVersion.OptionsColumn.AllowEdit = false;
            this.colMNVersion.Width = 64;
            // 
            // colTypeName
            // 
            this.colTypeName.Caption = "Loại";
            this.colTypeName.FieldName = "TypeName";
            this.colTypeName.Name = "colTypeName";
            // 
            // colPrice
            // 
            this.colPrice.AppearanceCell.Options.UseTextOptions = true;
            this.colPrice.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPrice.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colPrice.AppearanceHeader.Options.UseFont = true;
            this.colPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.colPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPrice.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPrice.Caption = "Đơn giá (VND)";
            this.colPrice.DisplayFormat.FormatString = "n0";
            this.colPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrice.FieldName = "Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.OptionsColumn.AllowEdit = false;
            this.colPrice.Visible = true;
            this.colPrice.VisibleIndex = 3;
            this.colPrice.Width = 104;
            // 
            // colTotalPrice
            // 
            this.colTotalPrice.AppearanceCell.Options.UseTextOptions = true;
            this.colTotalPrice.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTotalPrice.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTotalPrice.AppearanceHeader.Options.UseFont = true;
            this.colTotalPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotalPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotalPrice.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTotalPrice.Caption = "Tổng (VND)";
            this.colTotalPrice.DisplayFormat.FormatString = "n0";
            this.colTotalPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalPrice.FieldName = "TotalPrice";
            this.colTotalPrice.Name = "colTotalPrice";
            this.colTotalPrice.OptionsColumn.ReadOnly = true;
            this.colTotalPrice.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPrice", "{0:n0}")});
            this.colTotalPrice.Visible = true;
            this.colTotalPrice.VisibleIndex = 4;
            this.colTotalPrice.Width = 136;
            // 
            // colPriceType
            // 
            this.colPriceType.AppearanceCell.Options.UseTextOptions = true;
            this.colPriceType.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPriceType.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colPriceType.AppearanceHeader.Options.UseFont = true;
            this.colPriceType.AppearanceHeader.Options.UseTextOptions = true;
            this.colPriceType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPriceType.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPriceType.Caption = "PriceType";
            this.colPriceType.FieldName = "PriceType";
            this.colPriceType.Name = "colPriceType";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Yellow;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(461, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 15);
            this.label1.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(500, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Giá chưa đầy đủ";
            // 
            // frmBaiThucHanhPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 489);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grdModule);
            this.Name = "frmBaiThucHanhPrice";
            this.Text = "Xem giá bài thực hành";
            this.Load += new System.EventHandler(this.frmBaiThucHanhPrice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdModule)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvModule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdModule;
        private DevExpress.XtraGrid.Views.Grid.GridView grvModule;
        private DevExpress.XtraGrid.Columns.GridColumn colMID;
        private DevExpress.XtraGrid.Columns.GridColumn colMCode;
        private DevExpress.XtraGrid.Columns.GridColumn colMName;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colMHang;
        private DevExpress.XtraGrid.Columns.GridColumn colMQty;
        private DevExpress.XtraGrid.Columns.GridColumn colMType;
        private DevExpress.XtraGrid.Columns.GridColumn colMCVersion;
        private DevExpress.XtraGrid.Columns.GridColumn colMNVersion;
        private DevExpress.XtraGrid.Columns.GridColumn colTypeName;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colPriceType;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xemChiTiếtGiáModuleToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}