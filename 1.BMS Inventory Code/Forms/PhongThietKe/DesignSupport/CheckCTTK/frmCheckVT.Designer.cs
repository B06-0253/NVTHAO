namespace BMS
{
    partial class frmCheckVT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCheckVT));
            this.btnCheckCT = new System.Windows.Forms.Button();
            this.txtDMVTPath = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.grdCheck = new DevExpress.XtraGrid.GridControl();
            this.grvCheck = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colError = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNhang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHangchuan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnDownload3D = new System.Windows.Forms.Button();
            this.grdDMVTC = new DevExpress.XtraGrid.GridControl();
            this.grvDMVTC = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSTT3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colHang3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCode3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colType3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDMVTC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDMVTC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCheckCT
            // 
            this.btnCheckCT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckCT.BackColor = System.Drawing.Color.White;
            this.btnCheckCT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckCT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheckCT.Location = new System.Drawing.Point(872, 10);
            this.btnCheckCT.Name = "btnCheckCT";
            this.btnCheckCT.Size = new System.Drawing.Size(73, 29);
            this.btnCheckCT.TabIndex = 19;
            this.btnCheckCT.Text = "Kiểm tra";
            this.btnCheckCT.UseVisualStyleBackColor = false;
            this.btnCheckCT.Click += new System.EventHandler(this.btnCheckCT_Click);
            // 
            // txtDMVTPath
            // 
            this.txtDMVTPath.Enabled = false;
            this.txtDMVTPath.Location = new System.Drawing.Point(70, 10);
            this.txtDMVTPath.Name = "txtDMVTPath";
            this.txtDMVTPath.Size = new System.Drawing.Size(782, 20);
            this.txtDMVTPath.TabIndex = 32;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(6, 13);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(60, 13);
            this.Label6.TabIndex = 31;
            this.Label6.Text = "Đường dẫn";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(854, 8);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(24, 23);
            this.btnBrowse.TabIndex = 33;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // grdCheck
            // 
            this.grdCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdCheck.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdCheck.Location = new System.Drawing.Point(6, 44);
            this.grdCheck.MainView = this.grvCheck;
            this.grdCheck.Name = "grdCheck";
            this.grdCheck.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemMemoEdit1});
            this.grdCheck.Size = new System.Drawing.Size(1015, 371);
            this.grdCheck.TabIndex = 166;
            this.grdCheck.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCheck});
            // 
            // grvCheck
            // 
            this.grvCheck.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvCheck.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvCheck.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colNSTT,
            this.colName,
            this.colError,
            this.colNhang,
            this.colHangchuan});
            this.grvCheck.GridControl = this.grdCheck;
            this.grvCheck.HorzScrollStep = 5;
            this.grvCheck.Name = "grvCheck";
            this.grvCheck.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvCheck.OptionsCustomization.AllowRowSizing = true;
            this.grvCheck.OptionsFind.ShowCloseButton = false;
            this.grvCheck.OptionsSelection.MultiSelect = true;
            this.grvCheck.OptionsView.ColumnAutoWidth = false;
            this.grvCheck.OptionsView.RowAutoHeight = true;
            this.grvCheck.OptionsView.ShowFooter = true;
            this.grvCheck.OptionsView.ShowGroupPanel = false;
            // 
            // colID
            // 
            this.colID.AppearanceHeader.Options.UseTextOptions = true;
            this.colID.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colNSTT
            // 
            this.colNSTT.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colNSTT.AppearanceHeader.Options.UseFont = true;
            this.colNSTT.AppearanceHeader.Options.UseTextOptions = true;
            this.colNSTT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNSTT.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNSTT.Caption = "STT";
            this.colNSTT.FieldName = "STT";
            this.colNSTT.Name = "colNSTT";
            this.colNSTT.OptionsColumn.AllowSize = false;
            this.colNSTT.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colNSTT.Visible = true;
            this.colNSTT.VisibleIndex = 0;
            this.colNSTT.Width = 59;
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
            this.colName.Caption = "Vật tư";
            this.colName.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowSize = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 171;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Appearance.Options.UseTextOptions = true;
            this.repositoryItemMemoEdit1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // colError
            // 
            this.colError.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colError.AppearanceHeader.Options.UseFont = true;
            this.colError.AppearanceHeader.Options.UseTextOptions = true;
            this.colError.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colError.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colError.Caption = "Cảnh báo";
            this.colError.FieldName = "Type";
            this.colError.Name = "colError";
            this.colError.Visible = true;
            this.colError.VisibleIndex = 2;
            this.colError.Width = 133;
            // 
            // colNhang
            // 
            this.colNhang.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colNhang.AppearanceHeader.Options.UseFont = true;
            this.colNhang.AppearanceHeader.Options.UseTextOptions = true;
            this.colNhang.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNhang.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNhang.Caption = "Hãng";
            this.colNhang.FieldName = "Hang";
            this.colNhang.Name = "colNhang";
            this.colNhang.OptionsColumn.AllowEdit = false;
            this.colNhang.OptionsColumn.AllowFocus = false;
            this.colNhang.Visible = true;
            this.colNhang.VisibleIndex = 3;
            this.colNhang.Width = 87;
            // 
            // colHangchuan
            // 
            this.colHangchuan.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colHangchuan.AppearanceHeader.Options.UseFont = true;
            this.colHangchuan.AppearanceHeader.Options.UseTextOptions = true;
            this.colHangchuan.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHangchuan.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colHangchuan.Caption = "Hãng chuẩn";
            this.colHangchuan.FieldName = "Size";
            this.colHangchuan.Name = "colHangchuan";
            this.colHangchuan.OptionsColumn.AllowEdit = false;
            this.colHangchuan.OptionsColumn.AllowFocus = false;
            this.colHangchuan.Visible = true;
            this.colHangchuan.VisibleIndex = 4;
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
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.BackColor = System.Drawing.Color.White;
            this.btnExportExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExportExcel.Image")));
            this.btnExportExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportExcel.Location = new System.Drawing.Point(948, 10);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(73, 29);
            this.btnExportExcel.TabIndex = 19;
            this.btnExportExcel.Text = "Xuất lỗi";
            this.btnExportExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExportExcel.UseVisualStyleBackColor = false;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(2, 36);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1035, 447);
            this.tabControl1.TabIndex = 167;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grdCheck);
            this.tabPage1.Controls.Add(this.btnCheckCT);
            this.tabPage1.Controls.Add(this.btnExportExcel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1027, 421);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Kiểm tra dự toán sơ bộ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnDownload3D);
            this.tabPage2.Controls.Add(this.grdDMVTC);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1027, 421);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Download file 3D về thiết kế";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnDownload3D
            // 
            this.btnDownload3D.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownload3D.Location = new System.Drawing.Point(898, 6);
            this.btnDownload3D.Name = "btnDownload3D";
            this.btnDownload3D.Size = new System.Drawing.Size(123, 29);
            this.btnDownload3D.TabIndex = 168;
            this.btnDownload3D.Text = "Download";
            this.btnDownload3D.UseVisualStyleBackColor = true;
            this.btnDownload3D.Click += new System.EventHandler(this.btnDownload3D_Click);
            // 
            // grdDMVTC
            // 
            this.grdDMVTC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDMVTC.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdDMVTC.Location = new System.Drawing.Point(6, 41);
            this.grdDMVTC.MainView = this.grvDMVTC;
            this.grdDMVTC.Name = "grdDMVTC";
            this.grdDMVTC.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit2,
            this.repositoryItemMemoEdit2});
            this.grdDMVTC.Size = new System.Drawing.Size(1015, 374);
            this.grdDMVTC.TabIndex = 167;
            this.grdDMVTC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDMVTC});
            // 
            // grvDMVTC
            // 
            this.grvDMVTC.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvDMVTC.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvDMVTC.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSTT3,
            this.colName3,
            this.colHang3,
            this.colCode3,
            this.colType3});
            this.grvDMVTC.GridControl = this.grdDMVTC;
            this.grvDMVTC.HorzScrollStep = 5;
            this.grvDMVTC.Name = "grvDMVTC";
            this.grvDMVTC.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvDMVTC.OptionsCustomization.AllowRowSizing = true;
            this.grvDMVTC.OptionsFind.ShowCloseButton = false;
            this.grvDMVTC.OptionsSelection.MultiSelect = true;
            this.grvDMVTC.OptionsView.ColumnAutoWidth = false;
            this.grvDMVTC.OptionsView.RowAutoHeight = true;
            this.grvDMVTC.OptionsView.ShowFooter = true;
            this.grvDMVTC.OptionsView.ShowGroupPanel = false;
            // 
            // colSTT3
            // 
            this.colSTT3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colSTT3.AppearanceHeader.Options.UseFont = true;
            this.colSTT3.AppearanceHeader.Options.UseTextOptions = true;
            this.colSTT3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSTT3.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colSTT3.Caption = "STT";
            this.colSTT3.FieldName = "F1";
            this.colSTT3.Name = "colSTT3";
            this.colSTT3.OptionsColumn.AllowEdit = false;
            this.colSTT3.OptionsColumn.AllowFocus = false;
            this.colSTT3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colSTT3.Visible = true;
            this.colSTT3.VisibleIndex = 0;
            this.colSTT3.Width = 59;
            // 
            // colName3
            // 
            this.colName3.AppearanceCell.Options.UseTextOptions = true;
            this.colName3.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colName3.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colName3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colName3.AppearanceHeader.Options.UseFont = true;
            this.colName3.AppearanceHeader.Options.UseTextOptions = true;
            this.colName3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colName3.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colName3.Caption = "Vật tư";
            this.colName3.ColumnEdit = this.repositoryItemMemoEdit2;
            this.colName3.FieldName = "F2";
            this.colName3.Name = "colName3";
            this.colName3.Visible = true;
            this.colName3.VisibleIndex = 2;
            this.colName3.Width = 304;
            // 
            // repositoryItemMemoEdit2
            // 
            this.repositoryItemMemoEdit2.Appearance.Options.UseTextOptions = true;
            this.repositoryItemMemoEdit2.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
            // 
            // colHang3
            // 
            this.colHang3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colHang3.AppearanceHeader.Options.UseFont = true;
            this.colHang3.AppearanceHeader.Options.UseTextOptions = true;
            this.colHang3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHang3.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colHang3.Caption = "Hãng";
            this.colHang3.ColumnEdit = this.repositoryItemMemoEdit2;
            this.colHang3.FieldName = "F8";
            this.colHang3.Name = "colHang3";
            this.colHang3.OptionsColumn.AllowEdit = false;
            this.colHang3.OptionsColumn.AllowFocus = false;
            this.colHang3.Visible = true;
            this.colHang3.VisibleIndex = 3;
            this.colHang3.Width = 138;
            // 
            // colCode3
            // 
            this.colCode3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCode3.AppearanceHeader.Options.UseFont = true;
            this.colCode3.AppearanceHeader.Options.UseTextOptions = true;
            this.colCode3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCode3.Caption = "Mã vật tư";
            this.colCode3.ColumnEdit = this.repositoryItemMemoEdit2;
            this.colCode3.FieldName = "F4";
            this.colCode3.Name = "colCode3";
            this.colCode3.Visible = true;
            this.colCode3.VisibleIndex = 1;
            this.colCode3.Width = 155;
            // 
            // colType3
            // 
            this.colType3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colType3.AppearanceHeader.Options.UseFont = true;
            this.colType3.AppearanceHeader.Options.UseTextOptions = true;
            this.colType3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colType3.Caption = "Trạng thái";
            this.colType3.ColumnEdit = this.repositoryItemMemoEdit2;
            this.colType3.FieldName = "Type";
            this.colType3.Name = "colType3";
            this.colType3.Visible = true;
            this.colType3.VisibleIndex = 4;
            this.colType3.Width = 315;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.DisplayValueChecked = "\"1\"";
            this.repositoryItemCheckEdit2.DisplayValueUnchecked = "\"0\"";
            this.repositoryItemCheckEdit2.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            this.repositoryItemCheckEdit2.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // frmCheckVT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 485);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtDMVTPath);
            this.Controls.Add(this.Label6);
            this.Name = "frmCheckVT";
            this.Text = "DỰ TOÁN SƠ BỘ";
            this.Load += new System.EventHandler(this.frmCheckVT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDMVTC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDMVTC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button btnCheckCT;
        internal System.Windows.Forms.TextBox txtDMVTPath;
        internal System.Windows.Forms.Label Label6;
        private System.Windows.Forms.Button btnBrowse;
        private DevExpress.XtraGrid.GridControl grdCheck;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCheck;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colNSTT;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colError;
        private DevExpress.XtraGrid.Columns.GridColumn colNhang;
        private DevExpress.XtraGrid.Columns.GridColumn colHangchuan;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        internal System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private DevExpress.XtraGrid.GridControl grdDMVTC;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDMVTC;
        private DevExpress.XtraGrid.Columns.GridColumn colSTT3;
        private DevExpress.XtraGrid.Columns.GridColumn colName3;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colHang3;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private System.Windows.Forms.Button btnDownload3D;
        private DevExpress.XtraGrid.Columns.GridColumn colCode3;
        private DevExpress.XtraGrid.Columns.GridColumn colType3;
    }
}