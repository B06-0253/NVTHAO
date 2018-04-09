namespace BMS
{
    partial class frmGetVTPofProject
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
            this.cboProject = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.grvProject = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProjectID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProjectCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAssemblyDeadline = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateFinishE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnReloadData = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrice = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.grvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPartsId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPartsName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colPartsCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQtyTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQtyBuyDA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQtyBuyKho = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQtyXuat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSetVTPtoProject = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cboProject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit3)).BeginInit();
            this.SuspendLayout();
            // 
            // cboProject
            // 
            this.cboProject.Location = new System.Drawing.Point(56, 12);
            this.cboProject.Name = "cboProject";
            this.cboProject.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProject.Properties.NullText = "";
            this.cboProject.Properties.View = this.grvProject;
            this.cboProject.Size = new System.Drawing.Size(247, 20);
            this.cboProject.TabIndex = 222;
            this.cboProject.EditValueChanged += new System.EventHandler(this.cboProject_EditValueChanged);
            // 
            // grvProject
            // 
            this.grvProject.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProjectID,
            this.colProjectCode,
            this.colProjectName,
            this.colYear,
            this.colCustomerName,
            this.colUserName,
            this.colAssemblyDeadline,
            this.colDateFinishE});
            this.grvProject.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvProject.Name = "grvProject";
            this.grvProject.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvProject.OptionsView.ShowGroupPanel = false;
            // 
            // colProjectID
            // 
            this.colProjectID.Caption = "ID";
            this.colProjectID.FieldName = "ProjectId";
            this.colProjectID.Name = "colProjectID";
            // 
            // colProjectCode
            // 
            this.colProjectCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colProjectCode.AppearanceHeader.Options.UseFont = true;
            this.colProjectCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colProjectCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProjectCode.Caption = "Mã";
            this.colProjectCode.FieldName = "ProjectCode";
            this.colProjectCode.Name = "colProjectCode";
            this.colProjectCode.OptionsColumn.AllowSize = false;
            this.colProjectCode.Visible = true;
            this.colProjectCode.VisibleIndex = 0;
            this.colProjectCode.Width = 90;
            // 
            // colProjectName
            // 
            this.colProjectName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colProjectName.AppearanceHeader.Options.UseFont = true;
            this.colProjectName.AppearanceHeader.Options.UseTextOptions = true;
            this.colProjectName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProjectName.Caption = "Tên";
            this.colProjectName.FieldName = "ProjectName";
            this.colProjectName.Name = "colProjectName";
            this.colProjectName.Visible = true;
            this.colProjectName.VisibleIndex = 1;
            this.colProjectName.Width = 294;
            // 
            // colYear
            // 
            this.colYear.Caption = "Năm";
            this.colYear.FieldName = "Year";
            this.colYear.Name = "colYear";
            // 
            // colCustomerName
            // 
            this.colCustomerName.Caption = "CustomerName";
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.Name = "colCustomerName";
            // 
            // colUserName
            // 
            this.colUserName.Caption = "UserName";
            this.colUserName.FieldName = "UserName";
            this.colUserName.Name = "colUserName";
            // 
            // colAssemblyDeadline
            // 
            this.colAssemblyDeadline.Caption = "Deadline SXLR";
            this.colAssemblyDeadline.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colAssemblyDeadline.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAssemblyDeadline.FieldName = "AssemblyDeadline";
            this.colAssemblyDeadline.Name = "colAssemblyDeadline";
            this.colAssemblyDeadline.Visible = true;
            this.colAssemblyDeadline.VisibleIndex = 2;
            // 
            // colDateFinishE
            // 
            this.colDateFinishE.Caption = "Ngày kết thúc DK";
            this.colDateFinishE.FieldName = "DateFinishE";
            this.colDateFinishE.Name = "colDateFinishE";
            this.colDateFinishE.Visible = true;
            this.colDateFinishE.VisibleIndex = 3;
            // 
            // btnReloadData
            // 
            this.btnReloadData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReloadData.Location = new System.Drawing.Point(483, 10);
            this.btnReloadData.Name = "btnReloadData";
            this.btnReloadData.Size = new System.Drawing.Size(91, 23);
            this.btnReloadData.TabIndex = 221;
            this.btnReloadData.Text = "Tải dữ liệu";
            this.btnReloadData.UseVisualStyleBackColor = true;
            this.btnReloadData.Click += new System.EventHandler(this.btnReloadData_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 220;
            this.label6.Text = "Dự án";
            // 
            // txtPrice
            // 
            this.txtPrice.EditValue = "0";
            this.txtPrice.Location = new System.Drawing.Point(345, 12);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Properties.Mask.EditMask = "n0";
            this.txtPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPrice.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPrice.Size = new System.Drawing.Size(105, 20);
            this.txtPrice.TabIndex = 225;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(456, 15);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(21, 13);
            this.labelControl9.TabIndex = 223;
            this.labelControl9.Text = "VNĐ";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(311, 15);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(28, 13);
            this.labelControl5.TabIndex = 224;
            this.labelControl5.Text = "Giá trị";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 13);
            this.label1.TabIndex = 227;
            this.label1.Text = "Danh sách vật tư phụ của dự án";
            // 
            // grdData
            // 
            this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdData.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdData.Location = new System.Drawing.Point(2, 62);
            this.grdData.MainView = this.grvData;
            this.grdData.Name = "grdData";
            this.grdData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit3,
            this.repositoryItemLookUpEdit3});
            this.grdData.Size = new System.Drawing.Size(1077, 586);
            this.grdData.TabIndex = 226;
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
            this.colPartsId,
            this.colPartsName,
            this.colPartsCode,
            this.gridColumn12,
            this.colQty,
            this.gridColumn15,
            this.gridColumn16,
            this.colQtyTT,
            this.colQtyBuyDA,
            this.colQtyBuyKho,
            this.colQtyXuat});
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
            this.grvData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvData_KeyDown);
            // 
            // colPartsId
            // 
            this.colPartsId.AppearanceCell.Options.UseTextOptions = true;
            this.colPartsId.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPartsId.AppearanceHeader.Options.UseTextOptions = true;
            this.colPartsId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPartsId.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPartsId.Caption = "PartsId";
            this.colPartsId.FieldName = "PartsId";
            this.colPartsId.Name = "colPartsId";
            this.colPartsId.OptionsColumn.AllowEdit = false;
            // 
            // colPartsName
            // 
            this.colPartsName.AppearanceCell.Options.UseTextOptions = true;
            this.colPartsName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPartsName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPartsName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colPartsName.AppearanceHeader.Options.UseFont = true;
            this.colPartsName.AppearanceHeader.Options.UseTextOptions = true;
            this.colPartsName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPartsName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPartsName.Caption = "Tên";
            this.colPartsName.ColumnEdit = this.repositoryItemMemoEdit3;
            this.colPartsName.FieldName = "PartsName";
            this.colPartsName.Name = "colPartsName";
            this.colPartsName.OptionsColumn.AllowEdit = false;
            this.colPartsName.Visible = true;
            this.colPartsName.VisibleIndex = 1;
            this.colPartsName.Width = 269;
            // 
            // repositoryItemMemoEdit3
            // 
            this.repositoryItemMemoEdit3.Appearance.Options.UseTextOptions = true;
            this.repositoryItemMemoEdit3.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.repositoryItemMemoEdit3.Name = "repositoryItemMemoEdit3";
            // 
            // colPartsCode
            // 
            this.colPartsCode.AppearanceCell.Options.UseTextOptions = true;
            this.colPartsCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPartsCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colPartsCode.AppearanceHeader.Options.UseFont = true;
            this.colPartsCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colPartsCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPartsCode.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPartsCode.Caption = "Mã";
            this.colPartsCode.FieldName = "PartsCode";
            this.colPartsCode.Name = "colPartsCode";
            this.colPartsCode.OptionsColumn.AllowEdit = false;
            this.colPartsCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colPartsCode.Visible = true;
            this.colPartsCode.VisibleIndex = 0;
            this.colPartsCode.Width = 198;
            // 
            // gridColumn12
            // 
            this.gridColumn12.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn12.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn12.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn12.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn12.AppearanceHeader.Options.UseFont = true;
            this.gridColumn12.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn12.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn12.Caption = "Loại";
            this.gridColumn12.ColumnEdit = this.repositoryItemLookUpEdit3;
            this.gridColumn12.FieldName = "Type";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.Width = 112;
            // 
            // repositoryItemLookUpEdit3
            // 
            this.repositoryItemLookUpEdit3.AutoHeight = false;
            this.repositoryItemLookUpEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit3.Name = "repositoryItemLookUpEdit3";
            this.repositoryItemLookUpEdit3.NullText = "";
            // 
            // colQty
            // 
            this.colQty.AppearanceCell.Options.UseTextOptions = true;
            this.colQty.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colQty.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colQty.AppearanceHeader.Options.UseFont = true;
            this.colQty.AppearanceHeader.Options.UseTextOptions = true;
            this.colQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colQty.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colQty.Caption = "Số lượng YC";
            this.colQty.DisplayFormat.FormatString = "n0";
            this.colQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQty.FieldName = "Qty";
            this.colQty.Name = "colQty";
            this.colQty.OptionsColumn.AllowEdit = false;
            this.colQty.Visible = true;
            this.colQty.VisibleIndex = 4;
            this.colQty.Width = 64;
            // 
            // gridColumn15
            // 
            this.gridColumn15.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn15.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn15.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn15.AppearanceHeader.Options.UseFont = true;
            this.gridColumn15.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn15.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn15.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn15.Caption = "Đơn vị";
            this.gridColumn15.FieldName = "Unit";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 3;
            this.gridColumn15.Width = 52;
            // 
            // gridColumn16
            // 
            this.gridColumn16.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn16.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridColumn16.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn16.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn16.AppearanceHeader.Options.UseFont = true;
            this.gridColumn16.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn16.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn16.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridColumn16.Caption = "Hãng";
            this.gridColumn16.ColumnEdit = this.repositoryItemMemoEdit3;
            this.gridColumn16.FieldName = "ManufacturerCode";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.AllowEdit = false;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 2;
            this.gridColumn16.Width = 100;
            // 
            // colQtyTT
            // 
            this.colQtyTT.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colQtyTT.AppearanceHeader.Options.UseFont = true;
            this.colQtyTT.AppearanceHeader.Options.UseTextOptions = true;
            this.colQtyTT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colQtyTT.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colQtyTT.Caption = "Tồn kho TT";
            this.colQtyTT.DisplayFormat.FormatString = "n0";
            this.colQtyTT.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQtyTT.FieldName = "QtyTT";
            this.colQtyTT.Name = "colQtyTT";
            this.colQtyTT.OptionsColumn.AllowEdit = false;
            this.colQtyTT.Visible = true;
            this.colQtyTT.VisibleIndex = 5;
            // 
            // colQtyBuyDA
            // 
            this.colQtyBuyDA.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colQtyBuyDA.AppearanceHeader.Options.UseFont = true;
            this.colQtyBuyDA.AppearanceHeader.Options.UseTextOptions = true;
            this.colQtyBuyDA.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colQtyBuyDA.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colQtyBuyDA.Caption = "SL mua cho DA";
            this.colQtyBuyDA.DisplayFormat.FormatString = "n0";
            this.colQtyBuyDA.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQtyBuyDA.FieldName = "QtyBuyDA";
            this.colQtyBuyDA.Name = "colQtyBuyDA";
            this.colQtyBuyDA.OptionsColumn.AllowEdit = false;
            this.colQtyBuyDA.Visible = true;
            this.colQtyBuyDA.VisibleIndex = 6;
            this.colQtyBuyDA.Width = 73;
            // 
            // colQtyBuyKho
            // 
            this.colQtyBuyKho.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colQtyBuyKho.AppearanceHeader.Options.UseFont = true;
            this.colQtyBuyKho.AppearanceHeader.Options.UseTextOptions = true;
            this.colQtyBuyKho.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colQtyBuyKho.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colQtyBuyKho.Caption = "SL mua cho kho";
            this.colQtyBuyKho.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQtyBuyKho.FieldName = "QtyBuyKho";
            this.colQtyBuyKho.Name = "colQtyBuyKho";
            this.colQtyBuyKho.OptionsColumn.AllowEdit = false;
            this.colQtyBuyKho.Visible = true;
            this.colQtyBuyKho.VisibleIndex = 7;
            this.colQtyBuyKho.Width = 84;
            // 
            // colQtyXuat
            // 
            this.colQtyXuat.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colQtyXuat.AppearanceHeader.Options.UseFont = true;
            this.colQtyXuat.AppearanceHeader.Options.UseTextOptions = true;
            this.colQtyXuat.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colQtyXuat.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colQtyXuat.Caption = "SL xuất kho";
            this.colQtyXuat.DisplayFormat.FormatString = "n0";
            this.colQtyXuat.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQtyXuat.FieldName = "QtyXuat";
            this.colQtyXuat.Name = "colQtyXuat";
            this.colQtyXuat.OptionsColumn.AllowEdit = false;
            this.colQtyXuat.Visible = true;
            this.colQtyXuat.VisibleIndex = 8;
            // 
            // btnSetVTPtoProject
            // 
            this.btnSetVTPtoProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetVTPtoProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetVTPtoProject.Location = new System.Drawing.Point(867, 6);
            this.btnSetVTPtoProject.Name = "btnSetVTPtoProject";
            this.btnSetVTPtoProject.Size = new System.Drawing.Size(212, 47);
            this.btnSetVTPtoProject.TabIndex = 228;
            this.btnSetVTPtoProject.Text = "Xác nhận VTP cho dự án";
            this.btnSetVTPtoProject.UseVisualStyleBackColor = true;
            this.btnSetVTPtoProject.Click += new System.EventHandler(this.btnSetVTPtoProject_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(777, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 229;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmGetVTPofProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 650);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSetVTPtoProject);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grdData);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.cboProject);
            this.Controls.Add(this.btnReloadData);
            this.Controls.Add(this.label6);
            this.Name = "frmGetVTPofProject";
            this.Text = "DANH SÁCH VẬT TƯ PHỤ CHO DỰ ÁN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmGetVTPofProject_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboProject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SearchLookUpEdit cboProject;
        private DevExpress.XtraGrid.Views.Grid.GridView grvProject;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectID;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectCode;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectName;
        private DevExpress.XtraGrid.Columns.GridColumn colYear;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colAssemblyDeadline;
        private DevExpress.XtraGrid.Columns.GridColumn colDateFinishE;
        private System.Windows.Forms.Button btnReloadData;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.TextEdit txtPrice;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.Grid.GridView grvData;
        private DevExpress.XtraGrid.Columns.GridColumn colPartsId;
        private DevExpress.XtraGrid.Columns.GridColumn colPartsName;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit3;
        private DevExpress.XtraGrid.Columns.GridColumn colPartsCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit3;
        private DevExpress.XtraGrid.Columns.GridColumn colQty;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private System.Windows.Forms.Button btnSetVTPtoProject;
        private DevExpress.XtraGrid.Columns.GridColumn colQtyTT;
        private DevExpress.XtraGrid.Columns.GridColumn colQtyBuyDA;
        private DevExpress.XtraGrid.Columns.GridColumn colQtyBuyKho;
        private DevExpress.XtraGrid.Columns.GridColumn colQtyXuat;
        private System.Windows.Forms.Button button1;
    }
}