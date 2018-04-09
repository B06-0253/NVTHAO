namespace BMS
{
    partial class frmDatasheet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDatasheet));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblDuongDan = new DevExpress.XtraEditors.LabelControl();
            this.mnuMenu = new System.Windows.Forms.ToolStrip();
            this.btnChoose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUpDatasheet = new System.Windows.Forms.ToolStripButton();
            this.grdCustomer = new DevExpress.XtraGrid.GridControl();
            this.grvCustomer = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.grvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPath = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLength = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatemodified = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDownload = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnDownload = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colUpdatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.linkDownload = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gbHang = new System.Windows.Forms.GroupBox();
            this.gbFile = new System.Windows.Forms.GroupBox();
            this.mnuMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDownload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkDownload)).BeginInit();
            this.gbHang.SuspendLayout();
            this.gbFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDuongDan
            // 
            this.lblDuongDan.Location = new System.Drawing.Point(127, 12);
            this.lblDuongDan.Name = "lblDuongDan";
            this.lblDuongDan.Size = new System.Drawing.Size(0, 13);
            this.lblDuongDan.TabIndex = 18;
            // 
            // mnuMenu
            // 
            this.mnuMenu.AutoSize = false;
            this.mnuMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.mnuMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnChoose,
            this.toolStripSeparator1,
            this.btnDelete,
            this.toolStripSeparator2,
            this.btnUpDatasheet});
            this.mnuMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mnuMenu.Size = new System.Drawing.Size(1028, 42);
            this.mnuMenu.TabIndex = 169;
            this.mnuMenu.Text = "toolStrip2";
            // 
            // btnChoose
            // 
            this.btnChoose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChoose.Image = ((System.Drawing.Image)(resources.GetObject("btnChoose.Image")));
            this.btnChoose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(39, 33);
            this.btnChoose.Tag = "";
            this.btnChoose.Text = "Chọn";
            this.btnChoose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(32, 33);
            this.btnDelete.Tag = "frmMaterial_Deletefile";
            this.btnDelete.Text = "Xóa";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelete.ToolTipText = "Xóa";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 23);
            // 
            // btnUpDatasheet
            // 
            this.btnUpDatasheet.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpDatasheet.Image = ((System.Drawing.Image)(resources.GetObject("btnUpDatasheet.Image")));
            this.btnUpDatasheet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpDatasheet.Name = "btnUpDatasheet";
            this.btnUpDatasheet.Size = new System.Drawing.Size(48, 33);
            this.btnUpDatasheet.Tag = "frmMaterial_Upfile";
            this.btnUpDatasheet.Text = "Tải lên";
            this.btnUpDatasheet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnUpDatasheet.Click += new System.EventHandler(this.btnUpDatasheet_Click);
            // 
            // grdCustomer
            // 
            this.grdCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdCustomer.Location = new System.Drawing.Point(6, 19);
            this.grdCustomer.MainView = this.grvCustomer;
            this.grdCustomer.Name = "grdCustomer";
            this.grdCustomer.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemHyperLinkEdit1,
            this.repositoryItemButtonEdit1});
            this.grdCustomer.Size = new System.Drawing.Size(305, 333);
            this.grdCustomer.TabIndex = 170;
            this.grdCustomer.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCustomer});
            // 
            // grvCustomer
            // 
            this.grvCustomer.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvCustomer.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCustomer.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode,
            this.colCustomerID});
            this.grvCustomer.GridControl = this.grdCustomer;
            this.grvCustomer.Name = "grvCustomer";
            this.grvCustomer.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvCustomer.OptionsBehavior.Editable = false;
            this.grvCustomer.OptionsView.ShowFooter = true;
            this.grvCustomer.OptionsView.ShowGroupPanel = false;
            this.grvCustomer.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvCustomer_FocusedRowChanged);
            // 
            // colCode
            // 
            this.colCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCode.AppearanceHeader.Options.UseFont = true;
            this.colCode.Caption = "HÃNG";
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.OptionsColumn.AllowEdit = false;
            this.colCode.OptionsColumn.AllowFocus = false;
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            this.colCode.Width = 110;
            // 
            // colCustomerID
            // 
            this.colCustomerID.Caption = "ID";
            this.colCustomerID.FieldName = "ID";
            this.colCustomerID.Name = "colCustomerID";
            // 
            // repositoryItemHyperLinkEdit1
            // 
            this.repositoryItemHyperLinkEdit1.Caption = "Download";
            this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("repositoryItemButtonEdit1.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // grdData
            // 
            this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdData.Location = new System.Drawing.Point(6, 19);
            this.grdData.MainView = this.grvData;
            this.grdData.Name = "grdData";
            this.grdData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.linkDownload,
            this.btnDownload});
            this.grdData.Size = new System.Drawing.Size(699, 333);
            this.grdData.TabIndex = 171;
            this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvData});
            // 
            // grvData
            // 
            this.grvData.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvData.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colFileName,
            this.colPath,
            this.colLength,
            this.colDatemodified,
            this.colDownload,
            this.colUpdatedBy});
            this.grvData.GridControl = this.grdData;
            this.grvData.Name = "grvData";
            this.grvData.OptionsSelection.MultiSelect = true;
            this.grvData.OptionsView.ShowGroupPanel = false;
            this.grvData.DoubleClick += new System.EventHandler(this.grvData_DoubleClick);
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colFileName
            // 
            this.colFileName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colFileName.AppearanceHeader.Options.UseFont = true;
            this.colFileName.Caption = "Tên File";
            this.colFileName.FieldName = "Name";
            this.colFileName.Name = "colFileName";
            this.colFileName.OptionsColumn.AllowEdit = false;
            this.colFileName.OptionsColumn.AllowFocus = false;
            this.colFileName.Visible = true;
            this.colFileName.VisibleIndex = 0;
            this.colFileName.Width = 362;
            // 
            // colPath
            // 
            this.colPath.Caption = "Đường dẫn";
            this.colPath.FieldName = "Path";
            this.colPath.Name = "colPath";
            this.colPath.OptionsColumn.AllowEdit = false;
            this.colPath.OptionsColumn.AllowFocus = false;
            this.colPath.Width = 241;
            // 
            // colLength
            // 
            this.colLength.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colLength.AppearanceHeader.Options.UseFont = true;
            this.colLength.Caption = "Dung lượng";
            this.colLength.FieldName = "Length";
            this.colLength.Name = "colLength";
            this.colLength.OptionsColumn.AllowEdit = false;
            this.colLength.OptionsColumn.AllowFocus = false;
            this.colLength.Visible = true;
            this.colLength.VisibleIndex = 1;
            this.colLength.Width = 141;
            // 
            // colDatemodified
            // 
            this.colDatemodified.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colDatemodified.AppearanceHeader.Options.UseFont = true;
            this.colDatemodified.Caption = "Ngày sửa mới nhất";
            this.colDatemodified.FieldName = "Datemodified";
            this.colDatemodified.Name = "colDatemodified";
            this.colDatemodified.OptionsColumn.AllowEdit = false;
            this.colDatemodified.OptionsColumn.AllowFocus = false;
            this.colDatemodified.Visible = true;
            this.colDatemodified.VisibleIndex = 2;
            this.colDatemodified.Width = 146;
            // 
            // colDownload
            // 
            this.colDownload.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colDownload.AppearanceHeader.Options.UseFont = true;
            this.colDownload.Caption = "Tải về";
            this.colDownload.ColumnEdit = this.btnDownload;
            this.colDownload.Name = "colDownload";
            this.colDownload.Width = 85;
            // 
            // btnDownload
            // 
            this.btnDownload.AutoHeight = false;
            this.btnDownload.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("btnDownload.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // colUpdatedBy
            // 
            this.colUpdatedBy.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colUpdatedBy.AppearanceHeader.Options.UseFont = true;
            this.colUpdatedBy.Caption = "Người tải lên";
            this.colUpdatedBy.FieldName = "UpdatedBy";
            this.colUpdatedBy.Name = "colUpdatedBy";
            this.colUpdatedBy.Visible = true;
            this.colUpdatedBy.VisibleIndex = 3;
            this.colUpdatedBy.Width = 108;
            // 
            // linkDownload
            // 
            this.linkDownload.Caption = "Download";
            this.linkDownload.Name = "linkDownload";
            // 
            // gbHang
            // 
            this.gbHang.Controls.Add(this.grdCustomer);
            this.gbHang.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbHang.Location = new System.Drawing.Point(0, 42);
            this.gbHang.Name = "gbHang";
            this.gbHang.Size = new System.Drawing.Size(317, 358);
            this.gbHang.TabIndex = 172;
            this.gbHang.TabStop = false;
            this.gbHang.Text = "Danh sách hãng";
            // 
            // gbFile
            // 
            this.gbFile.Controls.Add(this.grdData);
            this.gbFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbFile.Location = new System.Drawing.Point(317, 42);
            this.gbFile.Name = "gbFile";
            this.gbFile.Size = new System.Drawing.Size(711, 358);
            this.gbFile.TabIndex = 173;
            this.gbFile.TabStop = false;
            this.gbFile.Text = "Danh sách file datasheet";
            // 
            // frmDatasheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 400);
            this.Controls.Add(this.gbFile);
            this.Controls.Add(this.gbHang);
            this.Controls.Add(this.mnuMenu);
            this.Controls.Add(this.lblDuongDan);
            this.Name = "frmDatasheet";
            this.Text = "Danh sách file Datasheet";
            this.Load += new System.EventHandler(this.frmDatasheet_Load);
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDownload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkDownload)).EndInit();
            this.gbHang.ResumeLayout(false);
            this.gbFile.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblDuongDan;
        private System.Windows.Forms.ToolStrip mnuMenu;
        private System.Windows.Forms.ToolStripButton btnChoose;
        private DevExpress.XtraGrid.GridControl grdCustomer;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCustomer;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerID;
        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.Grid.GridView grvData;
        private DevExpress.XtraGrid.Columns.GridColumn colFileName;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colPath;
        private DevExpress.XtraGrid.Columns.GridColumn colLength;
        private DevExpress.XtraGrid.Columns.GridColumn colDatemodified;
        private DevExpress.XtraGrid.Columns.GridColumn colDownload;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnDownload;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdatedBy;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit linkDownload;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnUpDatasheet;
        private System.Windows.Forms.GroupBox gbHang;
        private System.Windows.Forms.GroupBox gbFile;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;

    }
}