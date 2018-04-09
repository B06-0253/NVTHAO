namespace BMS
{
    partial class frmDuToanSoBo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDuToanSoBo));
            this.cboModule = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.grvModuleM = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodeM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNameM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDateP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDateM = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.mnuMenu = new System.Windows.Forms.ToolStrip();
            this.btnCreate = new System.Windows.Forms.ToolStripButton();
            this.label16 = new System.Windows.Forms.Label();
            this.grdVT = new DevExpress.XtraGrid.GridControl();
            this.grvVT = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colMaHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colMaVatLieu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaDes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaTonKho = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaDeliveryTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnDeleteVT = new System.Windows.Forms.Button();
            this.btnAddVT = new System.Windows.Forms.Button();
            this.cboProject = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.grvProject = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProjectID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProjectCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateFinishE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.cboModuleP = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.grvModuleP = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCodeP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNameP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPriceP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtTotalP = new DevExpress.XtraEditors.TextEdit();
            this.txtTotalM = new DevExpress.XtraEditors.TextEdit();
            this.btnAddModule = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cboModule.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvModuleM)).BeginInit();
            this.mnuMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboModuleP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvModuleP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalM.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cboModule
            // 
            this.cboModule.Location = new System.Drawing.Point(633, 51);
            this.cboModule.Name = "cboModule";
            this.cboModule.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboModule.Properties.NullText = "";
            this.cboModule.Properties.View = this.grvModuleM;
            this.cboModule.Size = new System.Drawing.Size(363, 20);
            this.cboModule.TabIndex = 183;
            // 
            // grvModuleM
            // 
            this.grvModuleM.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colCodeM,
            this.colNameM});
            this.grvModuleM.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvModuleM.Name = "grvModuleM";
            this.grvModuleM.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvModuleM.OptionsView.ShowGroupPanel = false;
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colCodeM
            // 
            this.colCodeM.Caption = "Mã";
            this.colCodeM.FieldName = "Code";
            this.colCodeM.Name = "colCodeM";
            this.colCodeM.Visible = true;
            this.colCodeM.VisibleIndex = 0;
            // 
            // colNameM
            // 
            this.colNameM.Caption = "Tên";
            this.colNameM.FieldName = "Name";
            this.colNameM.Name = "colNameM";
            this.colNameM.Visible = true;
            this.colNameM.VisibleIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 180;
            this.label6.Text = "Dự án";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(548, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 181;
            this.label8.Text = "Module thiết kế";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 184;
            this.label1.Text = "Thời gian GH dự án:";
            // 
            // txtDateP
            // 
            this.txtDateP.Location = new System.Drawing.Point(177, 110);
            this.txtDateP.Name = "txtDateP";
            this.txtDateP.Size = new System.Drawing.Size(194, 20);
            this.txtDateP.TabIndex = 185;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(413, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 184;
            this.label2.Text = "Giá module theo dự án:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 13);
            this.label3.TabIndex = 184;
            this.label3.Text = "Thời gian GH thiết kế (Ngày):";
            // 
            // txtDateM
            // 
            this.txtDateM.Location = new System.Drawing.Point(177, 138);
            this.txtDateM.Name = "txtDateM";
            this.txtDateM.ReadOnly = true;
            this.txtDateM.Size = new System.Drawing.Size(194, 20);
            this.txtDateM.TabIndex = 185;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(405, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 13);
            this.label4.TabIndex = 184;
            this.label4.Text = "Giá module theo thiết kế:";
            // 
            // mnuMenu
            // 
            this.mnuMenu.AutoSize = false;
            this.mnuMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.mnuMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCreate});
            this.mnuMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuMenu.Size = new System.Drawing.Size(1164, 42);
            this.mnuMenu.TabIndex = 186;
            this.mnuMenu.Text = "toolStrip2";
            // 
            // btnCreate
            // 
            this.btnCreate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Image = ((System.Drawing.Image)(resources.GetObject("btnCreate.Image")));
            this.btnCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(87, 33);
            this.btnCreate.Tag = "";
            this.btnCreate.Text = "Tạo biểu mẫu";
            this.btnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(5, 169);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(128, 13);
            this.label16.TabIndex = 190;
            this.label16.Text = "DANH SÁCH VẬT TƯ";
            // 
            // grdVT
            // 
            this.grdVT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdVT.Location = new System.Drawing.Point(0, 186);
            this.grdVT.MainView = this.grvVT;
            this.grdVT.Name = "grdVT";
            this.grdVT.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1,
            this.repositoryItemTextEdit1});
            this.grdVT.Size = new System.Drawing.Size(1164, 281);
            this.grdVT.TabIndex = 188;
            this.grdVT.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVT});
            // 
            // grvVT
            // 
            this.grvVT.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvVT.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvVT.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvVT.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvVT.ColumnPanelRowHeight = 40;
            this.grvVT.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaCode,
            this.colMaName,
            this.colMaHang,
            this.colMaQty,
            this.colMaVatLieu,
            this.colMaUnit,
            this.colMaStatus,
            this.colMaTime,
            this.colMaPrice,
            this.colMaTotal,
            this.colMaDes,
            this.colMaTonKho,
            this.colMaDeliveryTime});
            this.grvVT.GridControl = this.grdVT;
            this.grvVT.Name = "grvVT";
            this.grvVT.OptionsView.ColumnAutoWidth = false;
            this.grvVT.OptionsView.ShowFooter = true;
            this.grvVT.OptionsView.ShowGroupPanel = false;
            this.grvVT.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvVT_CellValueChanged);
            // 
            // colMaCode
            // 
            this.colMaCode.AppearanceCell.Options.UseTextOptions = true;
            this.colMaCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMaCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMaCode.AppearanceHeader.Options.UseFont = true;
            this.colMaCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaCode.Caption = "Mã";
            this.colMaCode.FieldName = "Code";
            this.colMaCode.Name = "colMaCode";
            this.colMaCode.OptionsColumn.AllowEdit = false;
            this.colMaCode.Visible = true;
            this.colMaCode.VisibleIndex = 0;
            this.colMaCode.Width = 110;
            // 
            // colMaName
            // 
            this.colMaName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMaName.AppearanceHeader.Options.UseFont = true;
            this.colMaName.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaName.Caption = "Tên";
            this.colMaName.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colMaName.FieldName = "Name";
            this.colMaName.Name = "colMaName";
            this.colMaName.OptionsColumn.AllowEdit = false;
            this.colMaName.Visible = true;
            this.colMaName.VisibleIndex = 1;
            this.colMaName.Width = 234;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // colMaHang
            // 
            this.colMaHang.AppearanceCell.Options.UseTextOptions = true;
            this.colMaHang.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMaHang.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMaHang.AppearanceHeader.Options.UseFont = true;
            this.colMaHang.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaHang.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaHang.Caption = "Hãng";
            this.colMaHang.FieldName = "Hang";
            this.colMaHang.Name = "colMaHang";
            this.colMaHang.OptionsColumn.AllowEdit = false;
            this.colMaHang.Visible = true;
            this.colMaHang.VisibleIndex = 3;
            this.colMaHang.Width = 106;
            // 
            // colMaQty
            // 
            this.colMaQty.AppearanceCell.Options.UseTextOptions = true;
            this.colMaQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colMaQty.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMaQty.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMaQty.AppearanceHeader.Options.UseFont = true;
            this.colMaQty.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaQty.Caption = "SL";
            this.colMaQty.ColumnEdit = this.repositoryItemTextEdit1;
            this.colMaQty.FieldName = "Qty";
            this.colMaQty.Name = "colMaQty";
            this.colMaQty.Visible = true;
            this.colMaQty.VisibleIndex = 7;
            this.colMaQty.Width = 53;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.DisplayFormat.FormatString = "n2";
            this.repositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit1.EditFormat.FormatString = "n2";
            this.repositoryItemTextEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit1.Mask.EditMask = "n2";
            this.repositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTextEdit1.Mask.UseMaskAsDisplayFormat = true;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // colMaVatLieu
            // 
            this.colMaVatLieu.AppearanceCell.Options.UseTextOptions = true;
            this.colMaVatLieu.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMaVatLieu.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMaVatLieu.AppearanceHeader.Options.UseFont = true;
            this.colMaVatLieu.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaVatLieu.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaVatLieu.Caption = "Vật liệu";
            this.colMaVatLieu.FieldName = "VatLieu";
            this.colMaVatLieu.Name = "colMaVatLieu";
            this.colMaVatLieu.OptionsColumn.AllowEdit = false;
            this.colMaVatLieu.Visible = true;
            this.colMaVatLieu.VisibleIndex = 2;
            this.colMaVatLieu.Width = 102;
            // 
            // colMaUnit
            // 
            this.colMaUnit.AppearanceCell.Options.UseTextOptions = true;
            this.colMaUnit.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaUnit.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMaUnit.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMaUnit.AppearanceHeader.Options.UseFont = true;
            this.colMaUnit.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaUnit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaUnit.Caption = "ĐV";
            this.colMaUnit.FieldName = "Unit";
            this.colMaUnit.Name = "colMaUnit";
            this.colMaUnit.OptionsColumn.AllowEdit = false;
            this.colMaUnit.Visible = true;
            this.colMaUnit.VisibleIndex = 6;
            this.colMaUnit.Width = 57;
            // 
            // colMaStatus
            // 
            this.colMaStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colMaStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaStatus.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMaStatus.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMaStatus.AppearanceHeader.Options.UseFont = true;
            this.colMaStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaStatus.Caption = "Đạt tiến độ";
            this.colMaStatus.FieldName = "Status";
            this.colMaStatus.Name = "colMaStatus";
            this.colMaStatus.OptionsColumn.AllowEdit = false;
            this.colMaStatus.Visible = true;
            this.colMaStatus.VisibleIndex = 5;
            // 
            // colMaTime
            // 
            this.colMaTime.AppearanceCell.Options.UseTextOptions = true;
            this.colMaTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colMaTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMaTime.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMaTime.AppearanceHeader.Options.UseFont = true;
            this.colMaTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaTime.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colMaTime.Caption = "Thời gian GH (ngày)";
            this.colMaTime.ColumnEdit = this.repositoryItemTextEdit1;
            this.colMaTime.DisplayFormat.FormatString = "n0";
            this.colMaTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMaTime.FieldName = "Time";
            this.colMaTime.Name = "colMaTime";
            this.colMaTime.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Max, "Time", "{0:n0}")});
            this.colMaTime.Visible = true;
            this.colMaTime.VisibleIndex = 4;
            // 
            // colMaPrice
            // 
            this.colMaPrice.AppearanceCell.Options.UseTextOptions = true;
            this.colMaPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colMaPrice.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMaPrice.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMaPrice.AppearanceHeader.Options.UseFont = true;
            this.colMaPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaPrice.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colMaPrice.Caption = "Đơn giá (VNĐ)";
            this.colMaPrice.DisplayFormat.FormatString = "n0";
            this.colMaPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMaPrice.FieldName = "Price";
            this.colMaPrice.Name = "colMaPrice";
            this.colMaPrice.OptionsColumn.AllowEdit = false;
            this.colMaPrice.Visible = true;
            this.colMaPrice.VisibleIndex = 8;
            this.colMaPrice.Width = 82;
            // 
            // colMaTotal
            // 
            this.colMaTotal.AppearanceCell.Options.UseTextOptions = true;
            this.colMaTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colMaTotal.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMaTotal.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMaTotal.AppearanceHeader.Options.UseFont = true;
            this.colMaTotal.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaTotal.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colMaTotal.Caption = "Thành tiền (VNĐ)";
            this.colMaTotal.DisplayFormat.FormatString = "n0";
            this.colMaTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMaTotal.FieldName = "Total";
            this.colMaTotal.Name = "colMaTotal";
            this.colMaTotal.OptionsColumn.AllowEdit = false;
            this.colMaTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total", "{0:n0}")});
            this.colMaTotal.Visible = true;
            this.colMaTotal.VisibleIndex = 9;
            this.colMaTotal.Width = 99;
            // 
            // colMaDes
            // 
            this.colMaDes.AppearanceCell.Options.UseTextOptions = true;
            this.colMaDes.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colMaDes.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMaDes.AppearanceHeader.Options.UseFont = true;
            this.colMaDes.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaDes.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaDes.Caption = "Ghi chú";
            this.colMaDes.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colMaDes.FieldName = "Description";
            this.colMaDes.Name = "colMaDes";
            this.colMaDes.OptionsColumn.AllowEdit = false;
            this.colMaDes.Visible = true;
            this.colMaDes.VisibleIndex = 10;
            this.colMaDes.Width = 200;
            // 
            // colMaTonKho
            // 
            this.colMaTonKho.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMaTonKho.AppearanceHeader.Options.UseFont = true;
            this.colMaTonKho.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaTonKho.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaTonKho.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colMaTonKho.Caption = "Tồn kho";
            this.colMaTonKho.DisplayFormat.FormatString = "n2";
            this.colMaTonKho.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMaTonKho.FieldName = "TonKho";
            this.colMaTonKho.Name = "colMaTonKho";
            this.colMaTonKho.Visible = true;
            this.colMaTonKho.VisibleIndex = 11;
            // 
            // colMaDeliveryTime
            // 
            this.colMaDeliveryTime.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMaDeliveryTime.AppearanceHeader.Options.UseFont = true;
            this.colMaDeliveryTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaDeliveryTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaDeliveryTime.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colMaDeliveryTime.Caption = "Ngày GH gần nhất";
            this.colMaDeliveryTime.DisplayFormat.FormatString = "n0";
            this.colMaDeliveryTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMaDeliveryTime.FieldName = "DeliveryTime";
            this.colMaDeliveryTime.Name = "colMaDeliveryTime";
            this.colMaDeliveryTime.Visible = true;
            this.colMaDeliveryTime.VisibleIndex = 12;
            // 
            // btnDeleteVT
            // 
            this.btnDeleteVT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteVT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteVT.Location = new System.Drawing.Point(888, 153);
            this.btnDeleteVT.Name = "btnDeleteVT";
            this.btnDeleteVT.Size = new System.Drawing.Size(75, 29);
            this.btnDeleteVT.TabIndex = 189;
            this.btnDeleteVT.Text = "Xóa VT";
            this.btnDeleteVT.UseVisualStyleBackColor = true;
            this.btnDeleteVT.Click += new System.EventHandler(this.btnDeleteVT_Click);
            // 
            // btnAddVT
            // 
            this.btnAddVT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddVT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddVT.Location = new System.Drawing.Point(969, 153);
            this.btnAddVT.Name = "btnAddVT";
            this.btnAddVT.Size = new System.Drawing.Size(86, 29);
            this.btnAddVT.TabIndex = 187;
            this.btnAddVT.Text = "Thêm VT";
            this.btnAddVT.UseVisualStyleBackColor = true;
            this.btnAddVT.Click += new System.EventHandler(this.btnAddVT_Click);
            // 
            // cboProject
            // 
            this.cboProject.Location = new System.Drawing.Point(57, 51);
            this.cboProject.Name = "cboProject";
            this.cboProject.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProject.Properties.NullText = "";
            this.cboProject.Properties.View = this.grvProject;
            this.cboProject.Size = new System.Drawing.Size(468, 20);
            this.cboProject.TabIndex = 191;
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
            this.colDateFinishE});
            this.grvProject.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvProject.GroupCount = 1;
            this.grvProject.Name = "grvProject";
            this.grvProject.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvProject.OptionsView.ShowGroupPanel = false;
            this.grvProject.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colYear, DevExpress.Data.ColumnSortOrder.Ascending)});
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
            // colDateFinishE
            // 
            this.colDateFinishE.Caption = "Ngày kết thúc dự kiến";
            this.colDateFinishE.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colDateFinishE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDateFinishE.FieldName = "DateFinishE";
            this.colDateFinishE.Name = "colDateFinishE";
            this.colDateFinishE.Visible = true;
            this.colDateFinishE.VisibleIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(556, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 181;
            this.label5.Text = "Module dự án";
            // 
            // cboModuleP
            // 
            this.cboModuleP.Location = new System.Drawing.Point(633, 79);
            this.cboModuleP.Name = "cboModuleP";
            this.cboModuleP.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboModuleP.Properties.NullText = "";
            this.cboModuleP.Properties.View = this.grvModuleP;
            this.cboModuleP.Size = new System.Drawing.Size(363, 20);
            this.cboModuleP.TabIndex = 183;
            this.cboModuleP.EditValueChanged += new System.EventHandler(this.cboModuleP_EditValueChanged);
            // 
            // grvModuleP
            // 
            this.grvModuleP.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCodeP,
            this.colNameP,
            this.colPriceP,
            this.colDateP});
            this.grvModuleP.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvModuleP.Name = "grvModuleP";
            this.grvModuleP.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvModuleP.OptionsView.ShowGroupPanel = false;
            // 
            // colCodeP
            // 
            this.colCodeP.Caption = "Mã";
            this.colCodeP.FieldName = "F3";
            this.colCodeP.Name = "colCodeP";
            this.colCodeP.Visible = true;
            this.colCodeP.VisibleIndex = 0;
            this.colCodeP.Width = 128;
            // 
            // colNameP
            // 
            this.colNameP.Caption = "Tên";
            this.colNameP.FieldName = "F2";
            this.colNameP.Name = "colNameP";
            this.colNameP.Visible = true;
            this.colNameP.VisibleIndex = 1;
            this.colNameP.Width = 150;
            // 
            // colPriceP
            // 
            this.colPriceP.Caption = "Giá";
            this.colPriceP.DisplayFormat.FormatString = "n0";
            this.colPriceP.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPriceP.FieldName = "F6";
            this.colPriceP.Name = "colPriceP";
            this.colPriceP.Visible = true;
            this.colPriceP.VisibleIndex = 2;
            this.colPriceP.Width = 106;
            // 
            // colDateP
            // 
            this.colDateP.Caption = "Ngày GH";
            this.colDateP.FieldName = "F9";
            this.colDateP.Name = "colDateP";
            this.colDateP.Visible = true;
            this.colDateP.VisibleIndex = 3;
            // 
            // txtTotalP
            // 
            this.txtTotalP.Location = new System.Drawing.Point(536, 110);
            this.txtTotalP.Name = "txtTotalP";
            this.txtTotalP.Properties.DisplayFormat.FormatString = "n0";
            this.txtTotalP.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotalP.Properties.Mask.EditMask = "n0";
            this.txtTotalP.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotalP.Size = new System.Drawing.Size(142, 20);
            this.txtTotalP.TabIndex = 192;
            // 
            // txtTotalM
            // 
            this.txtTotalM.Location = new System.Drawing.Point(536, 138);
            this.txtTotalM.Name = "txtTotalM";
            this.txtTotalM.Properties.ReadOnly = true;
            this.txtTotalM.Size = new System.Drawing.Size(142, 20);
            this.txtTotalM.TabIndex = 192;
            // 
            // btnAddModule
            // 
            this.btnAddModule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddModule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddModule.Location = new System.Drawing.Point(1061, 153);
            this.btnAddModule.Name = "btnAddModule";
            this.btnAddModule.Size = new System.Drawing.Size(101, 29);
            this.btnAddModule.TabIndex = 187;
            this.btnAddModule.Text = "Thêm Module";
            this.btnAddModule.UseVisualStyleBackColor = true;
            this.btnAddModule.Click += new System.EventHandler(this.btnAddModule_Click);
            // 
            // frmDuToanSoBo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 470);
            this.Controls.Add(this.txtTotalM);
            this.Controls.Add(this.txtTotalP);
            this.Controls.Add(this.cboProject);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.grdVT);
            this.Controls.Add(this.btnDeleteVT);
            this.Controls.Add(this.btnAddModule);
            this.Controls.Add(this.btnAddVT);
            this.Controls.Add(this.mnuMenu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDateM);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDateP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboModuleP);
            this.Controls.Add(this.cboModule);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Name = "frmDuToanSoBo";
            this.Text = "DỰ TOÁN SƠ BỘ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDuToanSoBo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboModule.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvModuleM)).EndInit();
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboModuleP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvModuleP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalM.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SearchLookUpEdit cboModule;
        private DevExpress.XtraGrid.Views.Grid.GridView grvModuleM;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeM;
        private DevExpress.XtraGrid.Columns.GridColumn colNameM;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDateP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDateM;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStrip mnuMenu;
        private System.Windows.Forms.ToolStripButton btnCreate;
        private System.Windows.Forms.Label label16;
        private DevExpress.XtraGrid.GridControl grdVT;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVT;
        private DevExpress.XtraGrid.Columns.GridColumn colMaCode;
        private DevExpress.XtraGrid.Columns.GridColumn colMaName;
        private DevExpress.XtraGrid.Columns.GridColumn colMaHang;
        private DevExpress.XtraGrid.Columns.GridColumn colMaQty;
        private DevExpress.XtraGrid.Columns.GridColumn colMaVatLieu;
        private DevExpress.XtraGrid.Columns.GridColumn colMaUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colMaStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colMaTime;
        private System.Windows.Forms.Button btnDeleteVT;
        private System.Windows.Forms.Button btnAddVT;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colMaPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colMaTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colMaDes;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.SearchLookUpEdit cboProject;
        private DevExpress.XtraGrid.Views.Grid.GridView grvProject;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectID;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectCode;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectName;
        private DevExpress.XtraGrid.Columns.GridColumn colYear;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.SearchLookUpEdit cboModuleP;
        private DevExpress.XtraGrid.Views.Grid.GridView grvModuleP;
        private DevExpress.XtraGrid.Columns.GridColumn colCodeP;
        private DevExpress.XtraGrid.Columns.GridColumn colNameP;
        private DevExpress.XtraGrid.Columns.GridColumn colPriceP;
        private DevExpress.XtraGrid.Columns.GridColumn colDateP;
        private DevExpress.XtraEditors.TextEdit txtTotalP;
        private DevExpress.XtraEditors.TextEdit txtTotalM;
        private System.Windows.Forms.Button btnAddModule;
        private DevExpress.XtraGrid.Columns.GridColumn colDateFinishE;
        private DevExpress.XtraGrid.Columns.GridColumn colMaTonKho;
        private DevExpress.XtraGrid.Columns.GridColumn colMaDeliveryTime;
    }
}