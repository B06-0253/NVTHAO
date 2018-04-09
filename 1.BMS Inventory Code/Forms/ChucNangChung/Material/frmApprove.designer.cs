namespace BMS
{
    partial class frmApprove
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmApprove));
            this.mnuMenu = new System.Windows.Forms.ToolStrip();
            this.btnApprove = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.btnNoApprove = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.grdGrid = new DevExpress.XtraGrid.GridControl();
            this.grvGrid = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaterialCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaterialName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFileType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCauseDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaterialID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaterialFileID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFileTypeText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.colPath = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mnuMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuMenu
            // 
            this.mnuMenu.AutoSize = false;
            this.mnuMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.mnuMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnApprove,
            this.toolStripSeparator11,
            this.btnNoApprove,
            this.toolStripSeparator1,
            this.btnClose});
            this.mnuMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuMenu.Size = new System.Drawing.Size(1040, 42);
            this.mnuMenu.TabIndex = 23;
            this.mnuMenu.Text = "toolStrip2";
            // 
            // btnApprove
            // 
            this.btnApprove.AutoSize = false;
            this.btnApprove.Image = ((System.Drawing.Image)(resources.GetObject("btnApprove.Image")));
            this.btnApprove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(82, 40);
            this.btnApprove.Tag = "frm3DManager_ApproveDelete";
            this.btnApprove.Text = "Duyệt";
            this.btnApprove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.AutoSize = false;
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 40);
            // 
            // btnNoApprove
            // 
            this.btnNoApprove.AutoSize = false;
            this.btnNoApprove.Image = ((System.Drawing.Image)(resources.GetObject("btnNoApprove.Image")));
            this.btnNoApprove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNoApprove.Name = "btnNoApprove";
            this.btnNoApprove.Size = new System.Drawing.Size(82, 40);
            this.btnNoApprove.Tag = "";
            this.btnNoApprove.Text = "Bỏ duyệt";
            this.btnNoApprove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNoApprove.Click += new System.EventHandler(this.btnNoApprove_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = false;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(55, 40);
            this.btnClose.Text = "Đóng";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grdGrid
            // 
            this.grdGrid.Location = new System.Drawing.Point(0, 61);
            this.grdGrid.MainView = this.grvGrid;
            this.grdGrid.Name = "grdGrid";
            this.grdGrid.Size = new System.Drawing.Size(1040, 344);
            this.grdGrid.TabIndex = 25;
            this.grdGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvGrid});
            // 
            // grvGrid
            // 
            this.grvGrid.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFileName,
            this.colMaterialCode,
            this.colMaterialName,
            this.colFileType,
            this.colID,
            this.colCauseDelete,
            this.colMaterialID,
            this.colMaterialFileID,
            this.colFileTypeText,
            this.colPath});
            this.grvGrid.GridControl = this.grdGrid;
            this.grvGrid.Name = "grvGrid";
            this.grvGrid.OptionsView.ColumnAutoWidth = false;
            this.grvGrid.OptionsView.RowAutoHeight = true;
            this.grvGrid.OptionsView.ShowAutoFilterRow = true;
            // 
            // colFileName
            // 
            this.colFileName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colFileName.AppearanceHeader.Options.UseFont = true;
            this.colFileName.AppearanceHeader.Options.UseTextOptions = true;
            this.colFileName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFileName.Caption = "Tên file";
            this.colFileName.FieldName = "Name";
            this.colFileName.Name = "colFileName";
            this.colFileName.OptionsColumn.AllowEdit = false;
            this.colFileName.OptionsColumn.AllowFocus = false;
            this.colFileName.Visible = true;
            this.colFileName.VisibleIndex = 0;
            this.colFileName.Width = 161;
            // 
            // colMaterialCode
            // 
            this.colMaterialCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMaterialCode.AppearanceHeader.Options.UseFont = true;
            this.colMaterialCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaterialCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaterialCode.Caption = "Mã vật tư";
            this.colMaterialCode.FieldName = "MaterialCode";
            this.colMaterialCode.Name = "colMaterialCode";
            this.colMaterialCode.OptionsColumn.AllowEdit = false;
            this.colMaterialCode.OptionsColumn.AllowFocus = false;
            this.colMaterialCode.Visible = true;
            this.colMaterialCode.VisibleIndex = 3;
            this.colMaterialCode.Width = 174;
            // 
            // colMaterialName
            // 
            this.colMaterialName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMaterialName.AppearanceHeader.Options.UseFont = true;
            this.colMaterialName.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaterialName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaterialName.Caption = "Tên vật tư";
            this.colMaterialName.FieldName = "MaterialName";
            this.colMaterialName.Name = "colMaterialName";
            this.colMaterialName.OptionsColumn.AllowEdit = false;
            this.colMaterialName.OptionsColumn.AllowFocus = false;
            this.colMaterialName.Visible = true;
            this.colMaterialName.VisibleIndex = 4;
            this.colMaterialName.Width = 200;
            // 
            // colFileType
            // 
            this.colFileType.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colFileType.AppearanceHeader.Options.UseFont = true;
            this.colFileType.AppearanceHeader.Options.UseTextOptions = true;
            this.colFileType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFileType.Caption = "Loại file";
            this.colFileType.FieldName = "FileTypeText";
            this.colFileType.Name = "colFileType";
            this.colFileType.OptionsColumn.AllowEdit = false;
            this.colFileType.OptionsColumn.AllowFocus = false;
            this.colFileType.Visible = true;
            this.colFileType.VisibleIndex = 1;
            this.colFileType.Width = 100;
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colCauseDelete
            // 
            this.colCauseDelete.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCauseDelete.AppearanceHeader.Options.UseFont = true;
            this.colCauseDelete.AppearanceHeader.Options.UseTextOptions = true;
            this.colCauseDelete.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCauseDelete.Caption = "Lý do";
            this.colCauseDelete.FieldName = "CauseDelete";
            this.colCauseDelete.Name = "colCauseDelete";
            this.colCauseDelete.Visible = true;
            this.colCauseDelete.VisibleIndex = 2;
            this.colCauseDelete.Width = 358;
            // 
            // colMaterialID
            // 
            this.colMaterialID.Caption = "MaterialID";
            this.colMaterialID.FieldName = "MaterialID";
            this.colMaterialID.Name = "colMaterialID";
            // 
            // colMaterialFileID
            // 
            this.colMaterialFileID.Caption = "MaterialFileID";
            this.colMaterialFileID.FieldName = "MaterialFileID";
            this.colMaterialFileID.Name = "colMaterialFileID";
            // 
            // colFileTypeText
            // 
            this.colFileTypeText.Caption = "Loại file";
            this.colFileTypeText.FieldName = "FileType";
            this.colFileTypeText.Name = "colFileTypeText";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Danh sách file cần duyệt xóa";
            // 
            // colPath
            // 
            this.colPath.Caption = "Đường dẫn";
            this.colPath.FieldName = "Path";
            this.colPath.Name = "colPath";
            // 
            // frmApprove
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 405);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grdGrid);
            this.Controls.Add(this.mnuMenu);
            this.Name = "frmApprove";
            this.Text = "Duyệt xóa";
            this.Load += new System.EventHandler(this.frmApprove_Load);
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip mnuMenu;
        private System.Windows.Forms.ToolStripButton btnClose;
        private DevExpress.XtraGrid.GridControl grdGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView grvGrid;
        private DevExpress.XtraGrid.Columns.GridColumn colMaterialCode;
        private DevExpress.XtraGrid.Columns.GridColumn colFileType;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colFileName;
        private DevExpress.XtraGrid.Columns.GridColumn colMaterialName;
        private System.Windows.Forms.ToolStripButton btnApprove;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripButton btnNoApprove;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.Columns.GridColumn colCauseDelete;
        private DevExpress.XtraGrid.Columns.GridColumn colMaterialID;
        private DevExpress.XtraGrid.Columns.GridColumn colMaterialFileID;
        private DevExpress.XtraGrid.Columns.GridColumn colFileTypeText;
        private DevExpress.XtraGrid.Columns.GridColumn colPath;
    }
}