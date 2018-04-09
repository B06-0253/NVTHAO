namespace BMS
{
    partial class frmPhanXuong_KMP_Link
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
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grdLink = new DevExpress.XtraGrid.GridControl();
            this.grvLink = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colLinkName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLinkCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLinkID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdPhongBan = new DevExpress.XtraGrid.GridControl();
            this.grvPhongBan = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPBID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPBCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPBName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnPush = new System.Windows.Forms.Button();
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.grvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPhongBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPhongBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            this.SuspendLayout();
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Appearance.Options.UseTextOptions = true;
            this.repositoryItemMemoEdit1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // repositoryItemMemoEdit2
            // 
            this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grdLink);
            this.splitContainer1.Panel1.Controls.Add(this.grdPhongBan);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnPush);
            this.splitContainer1.Panel2.Controls.Add(this.grdData);
            this.splitContainer1.Size = new System.Drawing.Size(1207, 714);
            this.splitContainer1.SplitterDistance = 550;
            this.splitContainer1.TabIndex = 20;
            // 
            // grdLink
            // 
            this.grdLink.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdLink.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdLink.Location = new System.Drawing.Point(3, 406);
            this.grdLink.MainView = this.grvLink;
            this.grdLink.Name = "grdLink";
            this.grdLink.Size = new System.Drawing.Size(544, 305);
            this.grdLink.TabIndex = 17;
            this.grdLink.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvLink});
            // 
            // grvLink
            // 
            this.grvLink.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvLink.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvLink.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvLink.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvLink.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvLink.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvLink.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvLink.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvLink.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvLink.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvLink.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvLink.ColumnPanelRowHeight = 40;
            this.grvLink.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colLinkName,
            this.colLinkCode,
            this.colLinkID});
            this.grvLink.GridControl = this.grdLink;
            this.grvLink.HorzScrollStep = 5;
            this.grvLink.Name = "grvLink";
            this.grvLink.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvLink.OptionsCustomization.AllowRowSizing = true;
            this.grvLink.OptionsFind.AlwaysVisible = true;
            this.grvLink.OptionsFind.ShowCloseButton = false;
            this.grvLink.OptionsSelection.MultiSelect = true;
            this.grvLink.OptionsView.ColumnAutoWidth = false;
            this.grvLink.OptionsView.RowAutoHeight = true;
            this.grvLink.OptionsView.ShowFooter = true;
            this.grvLink.OptionsView.ShowGroupPanel = false;
            this.grvLink.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvLink_KeyDown);
            // 
            // colLinkName
            // 
            this.colLinkName.AppearanceCell.Options.UseTextOptions = true;
            this.colLinkName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colLinkName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colLinkName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colLinkName.AppearanceHeader.Options.UseFont = true;
            this.colLinkName.AppearanceHeader.Options.UseTextOptions = true;
            this.colLinkName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLinkName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colLinkName.Caption = "Tên CP";
            this.colLinkName.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colLinkName.FieldName = "C_MOTA";
            this.colLinkName.Name = "colLinkName";
            this.colLinkName.OptionsColumn.AllowEdit = false;
            this.colLinkName.Visible = true;
            this.colLinkName.VisibleIndex = 1;
            this.colLinkName.Width = 370;
            // 
            // colLinkCode
            // 
            this.colLinkCode.AppearanceCell.Options.UseTextOptions = true;
            this.colLinkCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colLinkCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colLinkCode.AppearanceHeader.Options.UseFont = true;
            this.colLinkCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colLinkCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLinkCode.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colLinkCode.Caption = "Mã CP";
            this.colLinkCode.FieldName = "C_MA";
            this.colLinkCode.Name = "colLinkCode";
            this.colLinkCode.OptionsColumn.AllowEdit = false;
            this.colLinkCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colLinkCode.Visible = true;
            this.colLinkCode.VisibleIndex = 0;
            this.colLinkCode.Width = 129;
            // 
            // colLinkID
            // 
            this.colLinkID.AppearanceCell.Options.UseTextOptions = true;
            this.colLinkID.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colLinkID.AppearanceHeader.Options.UseTextOptions = true;
            this.colLinkID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLinkID.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colLinkID.Caption = "ID";
            this.colLinkID.FieldName = "ID";
            this.colLinkID.Name = "colLinkID";
            this.colLinkID.OptionsColumn.AllowEdit = false;
            // 
            // grdPhongBan
            // 
            this.grdPhongBan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdPhongBan.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdPhongBan.Location = new System.Drawing.Point(3, 5);
            this.grdPhongBan.MainView = this.grvPhongBan;
            this.grdPhongBan.Name = "grdPhongBan";
            this.grdPhongBan.Size = new System.Drawing.Size(544, 395);
            this.grdPhongBan.TabIndex = 186;
            this.grdPhongBan.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPhongBan});
            // 
            // grvPhongBan
            // 
            this.grvPhongBan.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvPhongBan.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvPhongBan.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvPhongBan.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvPhongBan.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvPhongBan.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grvPhongBan.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvPhongBan.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvPhongBan.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvPhongBan.ColumnPanelRowHeight = 40;
            this.grvPhongBan.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPBID,
            this.colPBCode,
            this.colPBName});
            this.grvPhongBan.GridControl = this.grdPhongBan;
            this.grvPhongBan.Name = "grvPhongBan";
            this.grvPhongBan.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvPhongBan.OptionsCustomization.AllowRowSizing = true;
            this.grvPhongBan.OptionsView.AllowHtmlDrawHeaders = true;
            this.grvPhongBan.OptionsView.ColumnAutoWidth = false;
            this.grvPhongBan.OptionsView.RowAutoHeight = true;
            this.grvPhongBan.OptionsView.ShowFooter = true;
            this.grvPhongBan.OptionsView.ShowGroupPanel = false;
            this.grvPhongBan.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvPhongBan_FocusedRowChanged);
            // 
            // colPBID
            // 
            this.colPBID.AppearanceCell.Options.UseTextOptions = true;
            this.colPBID.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPBID.Caption = "ID";
            this.colPBID.FieldName = "PK_ID";
            this.colPBID.Name = "colPBID";
            // 
            // colPBCode
            // 
            this.colPBCode.AppearanceCell.Options.UseTextOptions = true;
            this.colPBCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPBCode.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPBCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colPBCode.AppearanceHeader.Options.UseFont = true;
            this.colPBCode.Caption = "Mã phòng ban";
            this.colPBCode.FieldName = "C_MA";
            this.colPBCode.Name = "colPBCode";
            this.colPBCode.OptionsColumn.AllowEdit = false;
            this.colPBCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colPBCode.Visible = true;
            this.colPBCode.VisibleIndex = 0;
            this.colPBCode.Width = 126;
            // 
            // colPBName
            // 
            this.colPBName.AppearanceCell.Options.UseTextOptions = true;
            this.colPBName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPBName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPBName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colPBName.AppearanceHeader.Options.UseFont = true;
            this.colPBName.Caption = "Tên phòng ban";
            this.colPBName.ColumnEdit = this.repositoryItemMemoEdit2;
            this.colPBName.FieldName = "C_MOTA";
            this.colPBName.Name = "colPBName";
            this.colPBName.OptionsColumn.AllowEdit = false;
            this.colPBName.Visible = true;
            this.colPBName.VisibleIndex = 1;
            this.colPBName.Width = 369;
            // 
            // btnPush
            // 
            this.btnPush.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnPush.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPush.Location = new System.Drawing.Point(5, 331);
            this.btnPush.Name = "btnPush";
            this.btnPush.Size = new System.Drawing.Size(48, 52);
            this.btnPush.TabIndex = 18;
            this.btnPush.Text = "<--";
            this.btnPush.UseVisualStyleBackColor = true;
            this.btnPush.Click += new System.EventHandler(this.btnPush_Click);
            // 
            // grdData
            // 
            this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdData.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdData.Location = new System.Drawing.Point(57, 5);
            this.grdData.MainView = this.grvData;
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(593, 706);
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
            this.grvData.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvData.ColumnPanelRowHeight = 40;
            this.grvData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colCode,
            this.colID});
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
            this.grvData.OptionsView.ShowFooter = true;
            this.grvData.OptionsView.ShowGroupPanel = false;
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
            this.colName.Caption = "Tên CP";
            this.colName.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colName.FieldName = "C_MOTA";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 378;
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
            this.colCode.Caption = "Mã CP";
            this.colCode.FieldName = "C_MA";
            this.colCode.Name = "colCode";
            this.colCode.OptionsColumn.AllowEdit = false;
            this.colCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            this.colCode.Width = 171;
            // 
            // colID
            // 
            this.colID.AppearanceCell.Options.UseTextOptions = true;
            this.colID.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colID.AppearanceHeader.Options.UseTextOptions = true;
            this.colID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colID.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colID.Caption = "ID";
            this.colID.FieldName = "PK_ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.AllowEdit = false;
            // 
            // frmPhanXuong_KMP_Link
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 717);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmPhanXuong_KMP_Link";
            this.Text = "CẤU HÌNH CHI PHÍ THUỘC PHÒNG BAN";
            this.Load += new System.EventHandler(this.frmPhanXuong_KMP_Link_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvLink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPhongBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPhongBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraGrid.GridControl grdLink;
        private DevExpress.XtraGrid.Views.Grid.GridView grvLink;
        private DevExpress.XtraGrid.Columns.GridColumn colLinkName;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colLinkCode;
        private DevExpress.XtraGrid.Columns.GridColumn colLinkID;
        private DevExpress.XtraGrid.GridControl grdPhongBan;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPhongBan;
        private DevExpress.XtraGrid.Columns.GridColumn colPBID;
        private DevExpress.XtraGrid.Columns.GridColumn colPBCode;
        private DevExpress.XtraGrid.Columns.GridColumn colPBName;
        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.Grid.GridView grvData;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private System.Windows.Forms.Button btnPush;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
    }
}