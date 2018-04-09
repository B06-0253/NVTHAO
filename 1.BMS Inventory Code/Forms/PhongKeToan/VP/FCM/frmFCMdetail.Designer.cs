namespace BMS
{
    partial class frmFCMdetail
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
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtHopDong = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtProjectCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.grvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartmentID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSearchLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFK_KMP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.txtTotalReal = new DevExpress.XtraEditors.TextEdit();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTotalProfit = new DevExpress.XtraEditors.TextEdit();
            this.label18 = new System.Windows.Forms.Label();
            this.txtTotalBX = new DevExpress.XtraEditors.TextEdit();
            this.txtTotalNC = new DevExpress.XtraEditors.TextEdit();
            this.txtTotalPB = new DevExpress.XtraEditors.TextEdit();
            this.txtTotalBanHang = new DevExpress.XtraEditors.TextEdit();
            this.label17 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtTotalTrienKhai = new DevExpress.XtraEditors.TextEdit();
            this.label13 = new System.Windows.Forms.Label();
            this.txtTotalVT = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTotalHD = new DevExpress.XtraEditors.TextEdit();
            this.txtTotalVAT = new DevExpress.XtraEditors.TextEdit();
            this.txtTotalTPA = new DevExpress.XtraEditors.TextEdit();
            this.label15 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalReal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalProfit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalBX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalNC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalBanHang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalTrienKhai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalVT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalHD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalVAT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalTPA.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(667, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 258;
            this.label7.Text = "Năm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(809, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 257;
            this.label2.Text = "Tháng";
            // 
            // cboYear
            // 
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(700, 13);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(99, 21);
            this.cboYear.TabIndex = 256;
            // 
            // cboMonth
            // 
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Items.AddRange(new object[] {
            "Tất cả",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cboMonth.Location = new System.Drawing.Point(850, 12);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(99, 21);
            this.cboMonth.TabIndex = 255;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(1082, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(103, 34);
            this.btnSave.TabIndex = 254;
            this.btnSave.Tag = "frmFCMmanagement_Add";
            this.btnSave.Text = "Lưu dữ liệu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtHopDong
            // 
            this.txtHopDong.Location = new System.Drawing.Point(375, 13);
            this.txtHopDong.Name = "txtHopDong";
            this.txtHopDong.ReadOnly = true;
            this.txtHopDong.Size = new System.Drawing.Size(273, 20);
            this.txtHopDong.TabIndex = 253;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(298, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 250;
            this.label5.Text = "Hợp đồng/PO";
            // 
            // txtProjectCode
            // 
            this.txtProjectCode.Location = new System.Drawing.Point(109, 13);
            this.txtProjectCode.Name = "txtProjectCode";
            this.txtProjectCode.ReadOnly = true;
            this.txtProjectCode.Size = new System.Drawing.Size(180, 20);
            this.txtProjectCode.TabIndex = 252;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 251;
            this.label1.Text = "Dự án";
            // 
            // grdData
            // 
            this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdData.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdData.Location = new System.Drawing.Point(328, 47);
            this.grdData.MainView = this.grvData;
            this.grdData.Name = "grdData";
            this.grdData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemMemoEdit1,
            this.repositoryItemCheckEdit2,
            this.repositoryItemSearchLookUpEdit1});
            this.grdData.Size = new System.Drawing.Size(857, 685);
            this.grdData.TabIndex = 249;
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
            this.colID,
            this.colValue,
            this.gridColumn2,
            this.colDepartmentID,
            this.colFK_KMP});
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
            this.colName.FieldName = "C_KMP_TEN";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 289;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Appearance.Options.UseTextOptions = true;
            this.repositoryItemMemoEdit1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
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
            this.colCode.FieldName = "C_KMP_MA";
            this.colCode.Name = "colCode";
            this.colCode.OptionsColumn.AllowEdit = false;
            this.colCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            this.colCode.Width = 108;
            // 
            // colID
            // 
            this.colID.AppearanceCell.Options.UseTextOptions = true;
            this.colID.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colID.AppearanceHeader.Options.UseTextOptions = true;
            this.colID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colID.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.AllowEdit = false;
            // 
            // colValue
            // 
            this.colValue.AppearanceCell.Options.UseTextOptions = true;
            this.colValue.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colValue.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colValue.AppearanceHeader.Options.UseFont = true;
            this.colValue.AppearanceHeader.Options.UseTextOptions = true;
            this.colValue.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colValue.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colValue.Caption = "Giá trị";
            this.colValue.DisplayFormat.FormatString = "n0";
            this.colValue.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colValue.FieldName = "C_PRICE";
            this.colValue.Name = "colValue";
            this.colValue.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "F7", "{0:n0}")});
            this.colValue.Visible = true;
            this.colValue.VisibleIndex = 2;
            this.colValue.Width = 128;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn2.Caption = "Số lượng";
            this.gridColumn2.DisplayFormat.FormatString = "n0";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn2.FieldName = "F6";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            // 
            // colDepartmentID
            // 
            this.colDepartmentID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colDepartmentID.AppearanceHeader.Options.UseFont = true;
            this.colDepartmentID.AppearanceHeader.Options.UseTextOptions = true;
            this.colDepartmentID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDepartmentID.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDepartmentID.Caption = "Thuộc phòng ban";
            this.colDepartmentID.ColumnEdit = this.repositoryItemSearchLookUpEdit1;
            this.colDepartmentID.FieldName = "FK_PHANXUONG";
            this.colDepartmentID.Name = "colDepartmentID";
            this.colDepartmentID.Tag = "";
            this.colDepartmentID.Visible = true;
            this.colDepartmentID.VisibleIndex = 3;
            this.colDepartmentID.Width = 307;
            // 
            // repositoryItemSearchLookUpEdit1
            // 
            this.repositoryItemSearchLookUpEdit1.AutoHeight = false;
            this.repositoryItemSearchLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSearchLookUpEdit1.Name = "repositoryItemSearchLookUpEdit1";
            this.repositoryItemSearchLookUpEdit1.NullText = "";
            this.repositoryItemSearchLookUpEdit1.View = this.gridView1;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn5});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn3, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "PK_ID";
            this.gridColumn1.FieldName = "PK_ID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Width = 50;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Mã";
            this.gridColumn3.FieldName = "C_MA";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 80;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Mô tả";
            this.gridColumn5.FieldName = "C_MOTA";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 304;
            // 
            // colFK_KMP
            // 
            this.colFK_KMP.Caption = "FK_KMP";
            this.colFK_KMP.FieldName = "FK_KMP";
            this.colFK_KMP.Name = "colFK_KMP";
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
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            this.repositoryItemCheckEdit2.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // txtTotalReal
            // 
            this.txtTotalReal.EditValue = "";
            this.txtTotalReal.Location = new System.Drawing.Point(176, 140);
            this.txtTotalReal.Name = "txtTotalReal";
            this.txtTotalReal.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtTotalReal.Properties.Appearance.Options.UseFont = true;
            this.txtTotalReal.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTotalReal.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTotalReal.Properties.DisplayFormat.FormatString = "n0";
            this.txtTotalReal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalReal.Properties.EditFormat.FormatString = "n0";
            this.txtTotalReal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalReal.Properties.Mask.EditMask = "n0";
            this.txtTotalReal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalReal.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTotalReal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTotalReal.Size = new System.Drawing.Size(145, 21);
            this.txtTotalReal.TabIndex = 280;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(107, 143);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 13);
            this.label12.TabIndex = 279;
            this.label12.Text = "Giá thực thu";
            // 
            // txtTotalProfit
            // 
            this.txtTotalProfit.EditValue = "";
            this.txtTotalProfit.Location = new System.Drawing.Point(176, 367);
            this.txtTotalProfit.Name = "txtTotalProfit";
            this.txtTotalProfit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtTotalProfit.Properties.Appearance.Options.UseFont = true;
            this.txtTotalProfit.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTotalProfit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTotalProfit.Properties.DisplayFormat.FormatString = "n0";
            this.txtTotalProfit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalProfit.Properties.EditFormat.FormatString = "n0";
            this.txtTotalProfit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalProfit.Properties.Mask.EditMask = "n0";
            this.txtTotalProfit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalProfit.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTotalProfit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTotalProfit.Size = new System.Drawing.Size(146, 21);
            this.txtTotalProfit.TabIndex = 278;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(118, 371);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(54, 13);
            this.label18.TabIndex = 277;
            this.label18.Text = "Lợi nhuận";
            // 
            // txtTotalBX
            // 
            this.txtTotalBX.EditValue = "";
            this.txtTotalBX.Location = new System.Drawing.Point(176, 270);
            this.txtTotalBX.Name = "txtTotalBX";
            this.txtTotalBX.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtTotalBX.Properties.Appearance.Options.UseFont = true;
            this.txtTotalBX.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTotalBX.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTotalBX.Properties.DisplayFormat.FormatString = "n0";
            this.txtTotalBX.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalBX.Properties.EditFormat.FormatString = "n0";
            this.txtTotalBX.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalBX.Properties.Mask.EditMask = "n0";
            this.txtTotalBX.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalBX.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTotalBX.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTotalBX.Size = new System.Drawing.Size(146, 21);
            this.txtTotalBX.TabIndex = 273;
            // 
            // txtTotalNC
            // 
            this.txtTotalNC.EditValue = "";
            this.txtTotalNC.Location = new System.Drawing.Point(176, 205);
            this.txtTotalNC.Name = "txtTotalNC";
            this.txtTotalNC.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtTotalNC.Properties.Appearance.Options.UseFont = true;
            this.txtTotalNC.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTotalNC.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTotalNC.Properties.DisplayFormat.FormatString = "n0";
            this.txtTotalNC.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalNC.Properties.EditFormat.FormatString = "n0";
            this.txtTotalNC.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalNC.Properties.Mask.EditMask = "n0";
            this.txtTotalNC.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalNC.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTotalNC.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTotalNC.Size = new System.Drawing.Size(146, 21);
            this.txtTotalNC.TabIndex = 274;
            // 
            // txtTotalPB
            // 
            this.txtTotalPB.EditValue = "";
            this.txtTotalPB.Location = new System.Drawing.Point(176, 237);
            this.txtTotalPB.Name = "txtTotalPB";
            this.txtTotalPB.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtTotalPB.Properties.Appearance.Options.UseFont = true;
            this.txtTotalPB.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTotalPB.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTotalPB.Properties.DisplayFormat.FormatString = "n0";
            this.txtTotalPB.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalPB.Properties.EditFormat.FormatString = "n0";
            this.txtTotalPB.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalPB.Properties.Mask.EditMask = "n0";
            this.txtTotalPB.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalPB.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTotalPB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTotalPB.Size = new System.Drawing.Size(146, 21);
            this.txtTotalPB.TabIndex = 275;
            // 
            // txtTotalBanHang
            // 
            this.txtTotalBanHang.EditValue = "";
            this.txtTotalBanHang.Location = new System.Drawing.Point(176, 305);
            this.txtTotalBanHang.Name = "txtTotalBanHang";
            this.txtTotalBanHang.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtTotalBanHang.Properties.Appearance.Options.UseFont = true;
            this.txtTotalBanHang.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTotalBanHang.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTotalBanHang.Properties.DisplayFormat.FormatString = "n0";
            this.txtTotalBanHang.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalBanHang.Properties.EditFormat.FormatString = "n0";
            this.txtTotalBanHang.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalBanHang.Properties.Mask.EditMask = "n0";
            this.txtTotalBanHang.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalBanHang.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTotalBanHang.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTotalBanHang.Size = new System.Drawing.Size(146, 21);
            this.txtTotalBanHang.TabIndex = 276;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(90, 273);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(82, 13);
            this.label17.TabIndex = 269;
            this.label17.Text = "Chi phí bổ xung";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(9, 208);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(163, 13);
            this.label19.TabIndex = 270;
            this.label19.Text = "Tổng chi phí nhân công trực tiếp";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 308);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 272;
            this.label3.Text = "Chi phí xử lý bán hàng";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(26, 240);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(146, 13);
            this.label16.TabIndex = 271;
            this.label16.Text = "Tổng chi phí quản lí phân bổ";
            // 
            // txtTotalTrienKhai
            // 
            this.txtTotalTrienKhai.EditValue = "";
            this.txtTotalTrienKhai.Location = new System.Drawing.Point(176, 338);
            this.txtTotalTrienKhai.Name = "txtTotalTrienKhai";
            this.txtTotalTrienKhai.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtTotalTrienKhai.Properties.Appearance.Options.UseFont = true;
            this.txtTotalTrienKhai.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTotalTrienKhai.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTotalTrienKhai.Properties.DisplayFormat.FormatString = "n0";
            this.txtTotalTrienKhai.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalTrienKhai.Properties.EditFormat.FormatString = "n0";
            this.txtTotalTrienKhai.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalTrienKhai.Properties.Mask.EditMask = "n0";
            this.txtTotalTrienKhai.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalTrienKhai.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTotalTrienKhai.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTotalTrienKhai.Size = new System.Drawing.Size(146, 21);
            this.txtTotalTrienKhai.TabIndex = 268;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(55, 333);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(117, 26);
            this.label13.TabIndex = 267;
            this.label13.Text = "Tổng chi phí triển khai \r\nDA tại Khách Hàng";
            // 
            // txtTotalVT
            // 
            this.txtTotalVT.EditValue = "";
            this.txtTotalVT.Location = new System.Drawing.Point(176, 172);
            this.txtTotalVT.Name = "txtTotalVT";
            this.txtTotalVT.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtTotalVT.Properties.Appearance.Options.UseFont = true;
            this.txtTotalVT.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTotalVT.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTotalVT.Properties.DisplayFormat.FormatString = "n0";
            this.txtTotalVT.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalVT.Properties.EditFormat.FormatString = "n0";
            this.txtTotalVT.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalVT.Properties.Mask.EditMask = "n0";
            this.txtTotalVT.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalVT.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTotalVT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTotalVT.Size = new System.Drawing.Size(146, 21);
            this.txtTotalVT.TabIndex = 266;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(137, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 265;
            this.label4.Text = "Vật tư";
            // 
            // txtTotalHD
            // 
            this.txtTotalHD.EditValue = "";
            this.txtTotalHD.Location = new System.Drawing.Point(176, 48);
            this.txtTotalHD.Name = "txtTotalHD";
            this.txtTotalHD.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtTotalHD.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.txtTotalHD.Properties.Appearance.Options.UseFont = true;
            this.txtTotalHD.Properties.Appearance.Options.UseForeColor = true;
            this.txtTotalHD.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTotalHD.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTotalHD.Properties.DisplayFormat.FormatString = "n0";
            this.txtTotalHD.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalHD.Properties.EditFormat.FormatString = "n0";
            this.txtTotalHD.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalHD.Properties.Mask.EditMask = "n0";
            this.txtTotalHD.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalHD.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTotalHD.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTotalHD.Size = new System.Drawing.Size(146, 21);
            this.txtTotalHD.TabIndex = 262;
            // 
            // txtTotalVAT
            // 
            this.txtTotalVAT.EditValue = "";
            this.txtTotalVAT.Location = new System.Drawing.Point(176, 109);
            this.txtTotalVAT.Name = "txtTotalVAT";
            this.txtTotalVAT.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtTotalVAT.Properties.Appearance.Options.UseFont = true;
            this.txtTotalVAT.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTotalVAT.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTotalVAT.Properties.DisplayFormat.FormatString = "n0";
            this.txtTotalVAT.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalVAT.Properties.EditFormat.FormatString = "n0";
            this.txtTotalVAT.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalVAT.Properties.Mask.EditMask = "n0";
            this.txtTotalVAT.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalVAT.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTotalVAT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTotalVAT.Size = new System.Drawing.Size(146, 21);
            this.txtTotalVAT.TabIndex = 263;
            // 
            // txtTotalTPA
            // 
            this.txtTotalTPA.EditValue = "";
            this.txtTotalTPA.Location = new System.Drawing.Point(176, 80);
            this.txtTotalTPA.Name = "txtTotalTPA";
            this.txtTotalTPA.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtTotalTPA.Properties.Appearance.Options.UseFont = true;
            this.txtTotalTPA.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTotalTPA.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTotalTPA.Properties.DisplayFormat.FormatString = "n0";
            this.txtTotalTPA.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalTPA.Properties.EditFormat.FormatString = "n0";
            this.txtTotalTPA.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalTPA.Properties.Mask.EditMask = "n0";
            this.txtTotalTPA.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalTPA.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTotalTPA.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTotalTPA.Size = new System.Drawing.Size(146, 21);
            this.txtTotalTPA.TabIndex = 264;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(107, 112);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 13);
            this.label15.TabIndex = 259;
            this.label15.Text = "Thuế GTGT";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(88, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 13);
            this.label10.TabIndex = 260;
            this.label10.Text = "Giá bán trên HĐ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(36, 83);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(136, 13);
            this.label11.TabIndex = 261;
            this.label11.Text = "Giá bán theo quy định TPA";
            // 
            // frmFCMdetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 734);
            this.Controls.Add(this.txtTotalReal);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtTotalProfit);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtTotalBX);
            this.Controls.Add(this.txtTotalNC);
            this.Controls.Add(this.txtTotalPB);
            this.Controls.Add(this.txtTotalBanHang);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtTotalTrienKhai);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtTotalVT);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTotalHD);
            this.Controls.Add(this.txtTotalVAT);
            this.Controls.Add(this.txtTotalTPA);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboYear);
            this.Controls.Add(this.cboMonth);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtHopDong);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtProjectCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grdData);
            this.Name = "frmFCMdetail";
            this.Text = "FCM";
            this.Load += new System.EventHandler(this.frmFCMdetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalReal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalProfit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalBX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalNC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPB.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalBanHang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalTrienKhai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalVT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalHD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalVAT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalTPA.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.ComboBox cboMonth;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtHopDong;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtProjectCode;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.Grid.GridView grvData;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colValue;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartmentID;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit repositoryItemSearchLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn colFK_KMP;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraEditors.TextEdit txtTotalReal;
        private System.Windows.Forms.Label label12;
        private DevExpress.XtraEditors.TextEdit txtTotalProfit;
        private System.Windows.Forms.Label label18;
        private DevExpress.XtraEditors.TextEdit txtTotalBX;
        private DevExpress.XtraEditors.TextEdit txtTotalNC;
        private DevExpress.XtraEditors.TextEdit txtTotalPB;
        private DevExpress.XtraEditors.TextEdit txtTotalBanHang;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label16;
        private DevExpress.XtraEditors.TextEdit txtTotalTrienKhai;
        private System.Windows.Forms.Label label13;
        private DevExpress.XtraEditors.TextEdit txtTotalVT;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txtTotalHD;
        private DevExpress.XtraEditors.TextEdit txtTotalVAT;
        private DevExpress.XtraEditors.TextEdit txtTotalTPA;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}