namespace BMS
{
    partial class frmListContract
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListContract));
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.grvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colContractName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSign = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOutDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSupplier = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.btnExeclGroup = new DevExpress.XtraEditors.SimpleButton();
            this.colIsReceived = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnIsReceived = new DevExpress.XtraEditors.SimpleButton();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsOut = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.SuspendLayout();
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Appearance.Options.UseTextOptions = true;
            this.repositoryItemMemoEdit1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
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
            this.grvData.ColumnPanelRowHeight = 60;
            this.grvData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colContractName,
            this.colSign,
            this.colOutDate,
            this.colSupplier,
            this.colUserName,
            this.colIsReceived,
            this.colID,
            this.colIsOut});
            this.grvData.GridControl = this.grdData;
            this.grvData.GroupCount = 1;
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
            this.grvData.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colSupplier, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grvData.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grvData_CustomDrawCell);
            // 
            // colContractName
            // 
            this.colContractName.AppearanceCell.Options.UseTextOptions = true;
            this.colContractName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colContractName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colContractName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colContractName.AppearanceHeader.Options.UseFont = true;
            this.colContractName.AppearanceHeader.Options.UseTextOptions = true;
            this.colContractName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colContractName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colContractName.Caption = "Hợp đồng";
            this.colContractName.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colContractName.FieldName = "ContractName";
            this.colContractName.Name = "colContractName";
            this.colContractName.OptionsColumn.AllowEdit = false;
            this.colContractName.OptionsColumn.AllowSize = false;
            this.colContractName.Visible = true;
            this.colContractName.VisibleIndex = 0;
            this.colContractName.Width = 384;
            // 
            // colSign
            // 
            this.colSign.AppearanceCell.Options.UseTextOptions = true;
            this.colSign.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colSign.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colSign.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colSign.AppearanceHeader.Options.UseFont = true;
            this.colSign.AppearanceHeader.Options.UseTextOptions = true;
            this.colSign.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSign.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colSign.Caption = "Ngày ký";
            this.colSign.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colSign.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colSign.FieldName = "SignDate";
            this.colSign.Name = "colSign";
            this.colSign.OptionsColumn.AllowEdit = false;
            this.colSign.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colSign.Visible = true;
            this.colSign.VisibleIndex = 1;
            this.colSign.Width = 153;
            // 
            // colOutDate
            // 
            this.colOutDate.AppearanceCell.Options.UseTextOptions = true;
            this.colOutDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colOutDate.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colOutDate.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colOutDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colOutDate.AppearanceHeader.Options.UseFont = true;
            this.colOutDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colOutDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colOutDate.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colOutDate.Caption = "Ngày hết hạn";
            this.colOutDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colOutDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colOutDate.FieldName = "OutDate";
            this.colOutDate.Name = "colOutDate";
            this.colOutDate.OptionsColumn.AllowEdit = false;
            this.colOutDate.Visible = true;
            this.colOutDate.VisibleIndex = 2;
            this.colOutDate.Width = 161;
            // 
            // colSupplier
            // 
            this.colSupplier.AppearanceCell.Options.UseTextOptions = true;
            this.colSupplier.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colSupplier.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colSupplier.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colSupplier.AppearanceHeader.Options.UseFont = true;
            this.colSupplier.AppearanceHeader.Options.UseTextOptions = true;
            this.colSupplier.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSupplier.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colSupplier.Caption = "Nhà CC";
            this.colSupplier.FieldName = "Supplier";
            this.colSupplier.Name = "colSupplier";
            this.colSupplier.OptionsColumn.AllowEdit = false;
            this.colSupplier.Width = 329;
            // 
            // colUserName
            // 
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
            this.colUserName.VisibleIndex = 3;
            this.colUserName.Width = 150;
            // 
            // grdData
            // 
            this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdData.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdData.Location = new System.Drawing.Point(3, 3);
            this.grdData.MainView = this.grvData;
            this.grdData.Name = "grdData";
            this.grdData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemMemoEdit1});
            this.grdData.Size = new System.Drawing.Size(1095, 631);
            this.grdData.TabIndex = 19;
            this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvData});
            // 
            // btnExeclGroup
            // 
            this.btnExeclGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExeclGroup.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnExeclGroup.Appearance.Options.UseFont = true;
            this.btnExeclGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnExeclGroup.Image")));
            this.btnExeclGroup.Location = new System.Drawing.Point(976, 9);
            this.btnExeclGroup.Name = "btnExeclGroup";
            this.btnExeclGroup.Size = new System.Drawing.Size(104, 32);
            this.btnExeclGroup.TabIndex = 28;
            this.btnExeclGroup.Text = "Xuất excel";
            this.btnExeclGroup.Click += new System.EventHandler(this.btnExeclGroup_Click);
            // 
            // colIsReceived
            // 
            this.colIsReceived.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colIsReceived.AppearanceHeader.Options.UseFont = true;
            this.colIsReceived.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsReceived.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsReceived.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colIsReceived.Caption = "KT xác nhận";
            this.colIsReceived.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colIsReceived.FieldName = "IsReceived";
            this.colIsReceived.Name = "colIsReceived";
            this.colIsReceived.OptionsColumn.AllowEdit = false;
            this.colIsReceived.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.colIsReceived.Visible = true;
            this.colIsReceived.VisibleIndex = 4;
            // 
            // btnIsReceived
            // 
            this.btnIsReceived.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIsReceived.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnIsReceived.Appearance.Options.UseFont = true;
            this.btnIsReceived.Location = new System.Drawing.Point(866, 9);
            this.btnIsReceived.Name = "btnIsReceived";
            this.btnIsReceived.Size = new System.Drawing.Size(104, 32);
            this.btnIsReceived.TabIndex = 28;
            this.btnIsReceived.Tag = "frmListContract_IsReceived";
            this.btnIsReceived.Text = "Xác nhận";
            this.btnIsReceived.Click += new System.EventHandler(this.btnIsReceived_Click);
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colIsOut
            // 
            this.colIsOut.Caption = "IsOut";
            this.colIsOut.FieldName = "IsOut";
            this.colIsOut.Name = "colIsOut";
            // 
            // frmListContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 635);
            this.Controls.Add(this.btnIsReceived);
            this.Controls.Add(this.btnExeclGroup);
            this.Controls.Add(this.grdData);
            this.Name = "frmListContract";
            this.Text = "Danh sách hợp đồng";
            this.Load += new System.EventHandler(this.frmListContract_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView grvData;
        private DevExpress.XtraGrid.Columns.GridColumn colContractName;
        private DevExpress.XtraGrid.Columns.GridColumn colSign;
        private DevExpress.XtraGrid.Columns.GridColumn colOutDate;
        private DevExpress.XtraGrid.Columns.GridColumn colSupplier;
        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraEditors.SimpleButton btnExeclGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colIsReceived;
        private DevExpress.XtraEditors.SimpleButton btnIsReceived;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colIsOut;

    }
}