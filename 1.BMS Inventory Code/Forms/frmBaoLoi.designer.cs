namespace BMS
{
    partial class frmBaoLoi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaoLoi));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.grvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVanDe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHangMuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMucDoUuTien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYeuCau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNguoiPhatHien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayYeuCau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTinhTrangLoi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFileDinhKem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnFileDinhKem = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colTinhTrangKhacPhuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNguoiKhacPhuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnXem = new System.Windows.Forms.ToolStripMenuItem();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFileDinhKem)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.btnEdit,
            this.btnDelete,
            this.btnSave,
            this.btnCancel,
            this.toolStripSeparator2,
            this.toolStripButton1});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(838, 42);
            this.toolStrip1.TabIndex = 41;
            this.toolStrip1.Text = "toolStrip2";
            // 
            // btnNew
            // 
            this.btnNew.AutoSize = false;
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(55, 40);
            this.btnNew.Tag = "";
            this.btnNew.Text = "&Thêm";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.AutoSize = false;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(55, 40);
            this.btnEdit.Tag = "";
            this.btnEdit.Text = "Sửa";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = false;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(55, 40);
            this.btnDelete.Tag = "";
            this.btnDelete.Text = "Xóa";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = false;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(55, 40);
            this.btnSave.Text = "Ghi";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCancel.AutoSize = false;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(55, 40);
            this.btnCancel.Text = "Hủy";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AutoSize = false;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 40);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(55, 40);
            this.toolStripButton1.Text = "Thoát";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // grdData
            // 
            this.grdData.ContextMenuStrip = this.contextMenuStrip1;
            this.grdData.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdData.Location = new System.Drawing.Point(0, 42);
            this.grdData.MainView = this.grvData;
            this.grdData.Name = "grdData";
            this.grdData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnFileDinhKem,
            this.repositoryItemImageComboBox1});
            this.grdData.Size = new System.Drawing.Size(838, 363);
            this.grdData.TabIndex = 42;
            this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvData});
            // 
            // grvData
            // 
            this.grvData.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grvData.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvData.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvData.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvData.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grvData.Appearance.Row.Options.UseTextOptions = true;
            this.grvData.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.grvData.ColumnPanelRowHeight = 40;
            this.grvData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colVanDe,
            this.colHangMuc,
            this.colMucDoUuTien,
            this.colYeuCau,
            this.colNguoiPhatHien,
            this.colNgayYeuCau,
            this.colTinhTrangLoi,
            this.colFileDinhKem,
            this.colTinhTrangKhacPhuc,
            this.colNguoiKhacPhuc});
            this.grvData.CustomizationFormBounds = new System.Drawing.Rectangle(683, 284, 210, 312);
            this.grvData.GridControl = this.grdData;
            this.grvData.Name = "grvData";
            this.grvData.OptionsView.AllowHtmlDrawHeaders = true;
            this.grvData.OptionsView.ShowGroupPanel = false;
            this.grvData.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.grvData_ValidatingEditor);
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.Width = 52;
            // 
            // colVanDe
            // 
            this.colVanDe.Caption = "Vấn đề";
            this.colVanDe.FieldName = "VanDe";
            this.colVanDe.Name = "colVanDe";
            this.colVanDe.Visible = true;
            this.colVanDe.VisibleIndex = 0;
            this.colVanDe.Width = 53;
            // 
            // colHangMuc
            // 
            this.colHangMuc.Caption = "Hạng Mục";
            this.colHangMuc.FieldName = "HangMuc";
            this.colHangMuc.Name = "colHangMuc";
            this.colHangMuc.Visible = true;
            this.colHangMuc.VisibleIndex = 1;
            this.colHangMuc.Width = 53;
            // 
            // colMucDoUuTien
            // 
            this.colMucDoUuTien.Caption = "Mức độ ưu tiên";
            this.colMucDoUuTien.FieldName = "MucDoUuTien";
            this.colMucDoUuTien.Name = "colMucDoUuTien";
            this.colMucDoUuTien.Visible = true;
            this.colMucDoUuTien.VisibleIndex = 4;
            this.colMucDoUuTien.Width = 54;
            // 
            // colYeuCau
            // 
            this.colYeuCau.AppearanceCell.Options.UseTextOptions = true;
            this.colYeuCau.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colYeuCau.Caption = "Nội dung yêu cầu";
            this.colYeuCau.FieldName = "YeuCau";
            this.colYeuCau.Name = "colYeuCau";
            this.colYeuCau.Visible = true;
            this.colYeuCau.VisibleIndex = 2;
            this.colYeuCau.Width = 53;
            // 
            // colNguoiPhatHien
            // 
            this.colNguoiPhatHien.Caption = "Người yêu cầu";
            this.colNguoiPhatHien.FieldName = "NguoiPhatHien";
            this.colNguoiPhatHien.Name = "colNguoiPhatHien";
            this.colNguoiPhatHien.OptionsColumn.AllowEdit = false;
            this.colNguoiPhatHien.OptionsColumn.AllowFocus = false;
            this.colNguoiPhatHien.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colNguoiPhatHien.OptionsColumn.AllowIncrementalSearch = false;
            this.colNguoiPhatHien.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colNguoiPhatHien.OptionsColumn.AllowMove = false;
            this.colNguoiPhatHien.OptionsColumn.AllowShowHide = false;
            this.colNguoiPhatHien.OptionsColumn.AllowSize = false;
            this.colNguoiPhatHien.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colNguoiPhatHien.OptionsColumn.FixedWidth = true;
            //////this.gridColumn30.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.colNguoiPhatHien.Visible = true;
            this.colNguoiPhatHien.VisibleIndex = 6;
            this.colNguoiPhatHien.Width = 100;
            // 
            // colNgayYeuCau
            // 
            this.colNgayYeuCau.AppearanceCell.Options.UseTextOptions = true;
            this.colNgayYeuCau.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNgayYeuCau.Caption = "Ngày yêu cầu";
            this.colNgayYeuCau.FieldName = "NgayYeuCau";
            this.colNgayYeuCau.Name = "colNgayYeuCau";
            this.colNgayYeuCau.OptionsColumn.AllowEdit = false;
            this.colNgayYeuCau.OptionsColumn.AllowFocus = false;
            this.colNgayYeuCau.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colNgayYeuCau.OptionsColumn.AllowIncrementalSearch = false;
            this.colNgayYeuCau.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colNgayYeuCau.OptionsColumn.AllowMove = false;
            this.colNgayYeuCau.OptionsColumn.AllowShowHide = false;
            this.colNgayYeuCau.OptionsColumn.AllowSize = false;
            this.colNgayYeuCau.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colNgayYeuCau.OptionsColumn.FixedWidth = true;
            //////this.gridColumn30.OptionsColumn.Printable = DevExpress.Utils.DefaultBoolean.False;
            this.colNgayYeuCau.Visible = true;
            this.colNgayYeuCau.VisibleIndex = 7;
            this.colNgayYeuCau.Width = 90;
            // 
            // colTinhTrangLoi
            // 
            this.colTinhTrangLoi.Caption = "Tình trạng lỗi, yêu cầu";
            this.colTinhTrangLoi.FieldName = "TinhTrangLoi";
            this.colTinhTrangLoi.Name = "colTinhTrangLoi";
            this.colTinhTrangLoi.Visible = true;
            this.colTinhTrangLoi.VisibleIndex = 3;
            this.colTinhTrangLoi.Width = 49;
            // 
            // colFileDinhKem
            // 
            this.colFileDinhKem.Caption = "Tệp đính kèm";
            this.colFileDinhKem.ColumnEdit = this.btnFileDinhKem;
            this.colFileDinhKem.FieldName = "FileDinhKem";
            this.colFileDinhKem.Name = "colFileDinhKem";
            this.colFileDinhKem.Visible = true;
            this.colFileDinhKem.VisibleIndex = 5;
            this.colFileDinhKem.Width = 54;
            // 
            // btnFileDinhKem
            // 
            this.btnFileDinhKem.AutoHeight = false;
            this.btnFileDinhKem.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnFileDinhKem.Name = "btnFileDinhKem";
            this.btnFileDinhKem.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnFileDinhKem_ButtonClick);
            // 
            // colTinhTrangKhacPhuc
            // 
            this.colTinhTrangKhacPhuc.AppearanceCell.Options.UseTextOptions = true;
            this.colTinhTrangKhacPhuc.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTinhTrangKhacPhuc.Caption = "Tình trạng khắc phục";
            this.colTinhTrangKhacPhuc.ColumnEdit = this.repositoryItemImageComboBox1;
            this.colTinhTrangKhacPhuc.FieldName = "TinhTrangKhacPhuc";
            this.colTinhTrangKhacPhuc.Name = "colTinhTrangKhacPhuc";
            this.colTinhTrangKhacPhuc.OptionsColumn.FixedWidth = true;
            this.colTinhTrangKhacPhuc.Visible = true;
            this.colTinhTrangKhacPhuc.VisibleIndex = 8;
            this.colTinhTrangKhacPhuc.Width = 70;
            // 
            // colNguoiKhacPhuc
            // 
            this.colNguoiKhacPhuc.Caption = "Người khắc phục";
            this.colNguoiKhacPhuc.FieldName = "NguoiKhacPhuc";
            this.colNguoiKhacPhuc.Name = "colNguoiKhacPhuc";
            this.colNguoiKhacPhuc.OptionsColumn.FixedWidth = true;
            this.colNguoiKhacPhuc.Visible = true;
            this.colNguoiKhacPhuc.VisibleIndex = 9;
            this.colNguoiKhacPhuc.Width = 110;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnXem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(120, 26);
            // 
            // btnXem
            // 
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(119, 22);
            this.btnXem.Text = "Xem File";
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "0", 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", "1", 1)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            this.repositoryItemImageComboBox1.SmallImages = this.imageList1;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "no.png");
            this.imageList1.Images.SetKeyName(1, "symbol_check.png");
            // 
            // frmBaoLoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 405);
            this.Controls.Add(this.grdData);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmBaoLoi";
            this.Text = "Báo lỗi & Yêu cầu phần mềm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBaoLoi_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFileDinhKem)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.Grid.GridView grvData;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colVanDe;
        private DevExpress.XtraGrid.Columns.GridColumn colHangMuc;
        private DevExpress.XtraGrid.Columns.GridColumn colYeuCau;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoiPhatHien;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayYeuCau;
        private DevExpress.XtraGrid.Columns.GridColumn colTinhTrangLoi;
        private DevExpress.XtraGrid.Columns.GridColumn colFileDinhKem;
        private DevExpress.XtraGrid.Columns.GridColumn colTinhTrangKhacPhuc;
        private DevExpress.XtraGrid.Columns.GridColumn colNguoiKhacPhuc;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnFileDinhKem;
        private DevExpress.XtraGrid.Columns.GridColumn colMucDoUuTien;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnXem;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private System.Windows.Forms.ImageList imageList1;
    }
}