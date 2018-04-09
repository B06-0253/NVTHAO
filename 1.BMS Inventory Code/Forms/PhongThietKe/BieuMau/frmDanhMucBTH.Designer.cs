namespace BMS
{
    partial class frmDanhMucBTH
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
            this.cboBoPhanTH = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboBoPhanYC = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProductCodeTK = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cboProduct = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.grvProduct = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaThietBi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenThietBi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.cboProject = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.grvProject = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProjectID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProjectCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.searchLookUpEdit1 = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label15 = new System.Windows.Forms.Label();
            this.btnAddModule = new System.Windows.Forms.Button();
            this.btnDeleteModule = new System.Windows.Forms.Button();
            this.grdModule = new DevExpress.XtraGrid.GridControl();
            this.grvModule = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMError = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMKPH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMNameHD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMCodeHD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label16 = new System.Windows.Forms.Label();
            this.grdVT = new DevExpress.XtraGrid.GridControl();
            this.grvVT = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaError = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaKPH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaTonKho = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnDeleteVT = new System.Windows.Forms.Button();
            this.btnAddVT = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cboProduct.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdModule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvModule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVT)).BeginInit();
            this.SuspendLayout();
            // 
            // cboBoPhanTH
            // 
            this.cboBoPhanTH.FormattingEnabled = true;
            this.cboBoPhanTH.Items.AddRange(new object[] {
            "Chưa khắc phục",
            "Đã khắc phục"});
            this.cboBoPhanTH.Location = new System.Drawing.Point(459, 39);
            this.cboBoPhanTH.Name = "cboBoPhanTH";
            this.cboBoPhanTH.Size = new System.Drawing.Size(278, 21);
            this.cboBoPhanTH.TabIndex = 213;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(389, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 215;
            this.label4.Text = "Bộ phận TH";
            // 
            // cboBoPhanYC
            // 
            this.cboBoPhanYC.FormattingEnabled = true;
            this.cboBoPhanYC.Items.AddRange(new object[] {
            "Chưa khắc phục",
            "Đã khắc phục"});
            this.cboBoPhanYC.Location = new System.Drawing.Point(98, 39);
            this.cboBoPhanYC.Name = "cboBoPhanYC";
            this.cboBoPhanYC.Size = new System.Drawing.Size(278, 21);
            this.cboBoPhanYC.TabIndex = 212;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 214;
            this.label3.Text = "Bộ phận YC";
            // 
            // txtProductCodeTK
            // 
            this.txtProductCodeTK.Location = new System.Drawing.Point(643, 66);
            this.txtProductCodeTK.Name = "txtProductCodeTK";
            this.txtProductCodeTK.Size = new System.Drawing.Size(94, 20);
            this.txtProductCodeTK.TabIndex = 217;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(557, 69);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 13);
            this.label14.TabIndex = 219;
            this.label14.Text = "Mã SP theo TK";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 69);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 13);
            this.label13.TabIndex = 218;
            this.label13.Text = "Tên SP theo TK";
            // 
            // cboProduct
            // 
            this.cboProduct.Location = new System.Drawing.Point(98, 92);
            this.cboProduct.Name = "cboProduct";
            this.cboProduct.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProduct.Properties.NullText = "";
            this.cboProduct.Properties.View = this.grvProduct;
            this.cboProduct.Size = new System.Drawing.Size(373, 20);
            this.cboProduct.TabIndex = 220;
            // 
            // grvProduct
            // 
            this.grvProduct.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProductID,
            this.colMaThietBi,
            this.colTenThietBi});
            this.grvProduct.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvProduct.Name = "grvProduct";
            this.grvProduct.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvProduct.OptionsView.ShowGroupPanel = false;
            // 
            // colProductID
            // 
            this.colProductID.Caption = "ID";
            this.colProductID.FieldName = "PProductId";
            this.colProductID.Name = "colProductID";
            // 
            // colMaThietBi
            // 
            this.colMaThietBi.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMaThietBi.AppearanceHeader.Options.UseFont = true;
            this.colMaThietBi.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaThietBi.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaThietBi.Caption = "Mã sản phẩm";
            this.colMaThietBi.FieldName = "MaThietBi";
            this.colMaThietBi.Name = "colMaThietBi";
            this.colMaThietBi.OptionsColumn.AllowSize = false;
            this.colMaThietBi.Visible = true;
            this.colMaThietBi.VisibleIndex = 0;
            this.colMaThietBi.Width = 90;
            // 
            // colTenThietBi
            // 
            this.colTenThietBi.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTenThietBi.AppearanceHeader.Options.UseFont = true;
            this.colTenThietBi.AppearanceHeader.Options.UseTextOptions = true;
            this.colTenThietBi.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTenThietBi.Caption = "Tên sản phẩm";
            this.colTenThietBi.FieldName = "TenThietBi";
            this.colTenThietBi.Name = "colTenThietBi";
            this.colTenThietBi.Visible = true;
            this.colTenThietBi.VisibleIndex = 1;
            this.colTenThietBi.Width = 294;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 221;
            this.label8.Text = "Tên SP theo HĐ";
            // 
            // cboProject
            // 
            this.cboProject.Location = new System.Drawing.Point(98, 12);
            this.cboProject.Name = "cboProject";
            this.cboProject.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProject.Properties.NullText = "";
            this.cboProject.Properties.View = this.grvProject;
            this.cboProject.Size = new System.Drawing.Size(403, 20);
            this.cboProject.TabIndex = 223;
            // 
            // grvProject
            // 
            this.grvProject.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProjectID,
            this.colProjectCode,
            this.colProjectName,
            this.colYear,
            this.colCustomerName,
            this.colUserName});
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 222;
            this.label6.Text = "Dự án";
            // 
            // searchLookUpEdit1
            // 
            this.searchLookUpEdit1.Location = new System.Drawing.Point(98, 66);
            this.searchLookUpEdit1.Name = "searchLookUpEdit1";
            this.searchLookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpEdit1.Properties.NullText = "";
            this.searchLookUpEdit1.Properties.View = this.gridView1;
            this.searchLookUpEdit1.Size = new System.Drawing.Size(373, 20);
            this.searchLookUpEdit1.TabIndex = 220;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ID";
            this.gridColumn1.FieldName = "PProductId";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Mã sản phẩm";
            this.gridColumn2.FieldName = "MaThietBi";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowSize = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 90;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Tên sản phẩm";
            this.gridColumn3.FieldName = "TenThietBi";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 294;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(1, 118);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label15);
            this.splitContainer1.Panel1.Controls.Add(this.btnDeleteVT);
            this.splitContainer1.Panel1.Controls.Add(this.btnAddVT);
            this.splitContainer1.Panel1.Controls.Add(this.grdModule);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label16);
            this.splitContainer1.Panel2.Controls.Add(this.btnAddModule);
            this.splitContainer1.Panel2.Controls.Add(this.grdVT);
            this.splitContainer1.Panel2.Controls.Add(this.btnDeleteModule);
            this.splitContainer1.Size = new System.Drawing.Size(984, 359);
            this.splitContainer1.SplitterDistance = 206;
            this.splitContainer1.TabIndex = 224;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(11, 13);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(180, 13);
            this.label15.TabIndex = 2;
            this.label15.Text = "DANH SÁCH BÀI THỰC HÀNH";
            // 
            // btnAddModule
            // 
            this.btnAddModule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddModule.Location = new System.Drawing.Point(890, 11);
            this.btnAddModule.Name = "btnAddModule";
            this.btnAddModule.Size = new System.Drawing.Size(86, 23);
            this.btnAddModule.TabIndex = 0;
            this.btnAddModule.Text = "Thêm module";
            this.btnAddModule.UseVisualStyleBackColor = true;
            // 
            // btnDeleteModule
            // 
            this.btnDeleteModule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteModule.Location = new System.Drawing.Point(813, 11);
            this.btnDeleteModule.Name = "btnDeleteModule";
            this.btnDeleteModule.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteModule.TabIndex = 1;
            this.btnDeleteModule.Text = "Xóa module";
            this.btnDeleteModule.UseVisualStyleBackColor = true;
            // 
            // grdModule
            // 
            this.grdModule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdModule.Location = new System.Drawing.Point(3, 40);
            this.grdModule.MainView = this.grvModule;
            this.grdModule.Name = "grdModule";
            this.grdModule.Size = new System.Drawing.Size(978, 163);
            this.grdModule.TabIndex = 0;
            this.grdModule.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvModule});
            // 
            // grvModule
            // 
            this.grvModule.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMID,
            this.colMCode,
            this.colMName,
            this.colMError,
            this.colMKPH,
            this.colMHang,
            this.colMQty,
            this.colMNameHD,
            this.colMCodeHD,
            this.colMStatus});
            this.grvModule.GridControl = this.grdModule;
            this.grvModule.Name = "grvModule";
            this.grvModule.OptionsView.ColumnAutoWidth = false;
            this.grvModule.OptionsView.ShowGroupPanel = false;
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
            this.colMCode.FieldName = "Code";
            this.colMCode.Name = "colMCode";
            this.colMCode.OptionsColumn.AllowEdit = false;
            this.colMCode.OptionsColumn.AllowFocus = false;
            this.colMCode.Visible = true;
            this.colMCode.VisibleIndex = 2;
            this.colMCode.Width = 77;
            // 
            // colMName
            // 
            this.colMName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMName.AppearanceHeader.Options.UseFont = true;
            this.colMName.AppearanceHeader.Options.UseTextOptions = true;
            this.colMName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMName.Caption = "Tên module";
            this.colMName.FieldName = "Name";
            this.colMName.Name = "colMName";
            this.colMName.OptionsColumn.AllowEdit = false;
            this.colMName.OptionsColumn.AllowFocus = false;
            this.colMName.Visible = true;
            this.colMName.VisibleIndex = 3;
            this.colMName.Width = 248;
            // 
            // colMError
            // 
            this.colMError.AppearanceCell.Options.UseTextOptions = true;
            this.colMError.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colMError.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMError.AppearanceHeader.Options.UseFont = true;
            this.colMError.AppearanceHeader.Options.UseTextOptions = true;
            this.colMError.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMError.Caption = "Lỗi";
            this.colMError.FieldName = "Error";
            this.colMError.Name = "colMError";
            this.colMError.OptionsColumn.AllowEdit = false;
            this.colMError.OptionsColumn.AllowFocus = false;
            this.colMError.Visible = true;
            this.colMError.VisibleIndex = 6;
            this.colMError.Width = 47;
            // 
            // colMKPH
            // 
            this.colMKPH.AppearanceCell.Options.UseTextOptions = true;
            this.colMKPH.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colMKPH.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMKPH.AppearanceHeader.Options.UseFont = true;
            this.colMKPH.AppearanceHeader.Options.UseTextOptions = true;
            this.colMKPH.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMKPH.Caption = "Không phù hợp";
            this.colMKPH.FieldName = "KPH";
            this.colMKPH.Name = "colMKPH";
            this.colMKPH.OptionsColumn.AllowEdit = false;
            this.colMKPH.OptionsColumn.AllowFocus = false;
            this.colMKPH.Visible = true;
            this.colMKPH.VisibleIndex = 7;
            this.colMKPH.Width = 110;
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
            this.colMHang.VisibleIndex = 4;
            this.colMHang.Width = 53;
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
            this.colMQty.Caption = "Số lượng";
            this.colMQty.FieldName = "Qty";
            this.colMQty.Name = "colMQty";
            this.colMQty.Visible = true;
            this.colMQty.VisibleIndex = 5;
            this.colMQty.Width = 65;
            // 
            // colMNameHD
            // 
            this.colMNameHD.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMNameHD.AppearanceHeader.Options.UseFont = true;
            this.colMNameHD.AppearanceHeader.Options.UseTextOptions = true;
            this.colMNameHD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMNameHD.Caption = "Tên theo HĐ";
            this.colMNameHD.FieldName = "NameHD";
            this.colMNameHD.Name = "colMNameHD";
            this.colMNameHD.Visible = true;
            this.colMNameHD.VisibleIndex = 0;
            this.colMNameHD.Width = 194;
            // 
            // colMCodeHD
            // 
            this.colMCodeHD.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMCodeHD.AppearanceHeader.Options.UseFont = true;
            this.colMCodeHD.AppearanceHeader.Options.UseTextOptions = true;
            this.colMCodeHD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMCodeHD.Caption = "Mã theo HĐ";
            this.colMCodeHD.FieldName = "CodeHD";
            this.colMCodeHD.Name = "colMCodeHD";
            this.colMCodeHD.Visible = true;
            this.colMCodeHD.VisibleIndex = 1;
            this.colMCodeHD.Width = 94;
            // 
            // colMStatus
            // 
            this.colMStatus.Caption = "Status";
            this.colMStatus.FieldName = "Status";
            this.colMStatus.Name = "colMStatus";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(11, 13);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(135, 13);
            this.label16.TabIndex = 6;
            this.label16.Text = "DANH SÁCH MODULE";
            // 
            // grdVT
            // 
            this.grdVT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdVT.Location = new System.Drawing.Point(3, 40);
            this.grdVT.MainView = this.grvVT;
            this.grdVT.Name = "grdVT";
            this.grdVT.Size = new System.Drawing.Size(978, 106);
            this.grdVT.TabIndex = 2;
            this.grdVT.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVT});
            // 
            // grvVT
            // 
            this.grvVT.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaID,
            this.colMaCode,
            this.colMaName,
            this.colMaHang,
            this.colMaQty,
            this.colMaError,
            this.colMaKPH,
            this.colMaStatus,
            this.colMaTonKho});
            this.grvVT.GridControl = this.grdVT;
            this.grvVT.Name = "grvVT";
            this.grvVT.OptionsView.ColumnAutoWidth = false;
            this.grvVT.OptionsView.ShowGroupPanel = false;
            // 
            // colMaID
            // 
            this.colMaID.Caption = "ID";
            this.colMaID.FieldName = "ID";
            this.colMaID.Name = "colMaID";
            // 
            // colMaCode
            // 
            this.colMaCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMaCode.AppearanceHeader.Options.UseFont = true;
            this.colMaCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaCode.Caption = "Mã";
            this.colMaCode.FieldName = "Code";
            this.colMaCode.Name = "colMaCode";
            this.colMaCode.OptionsColumn.AllowEdit = false;
            this.colMaCode.OptionsColumn.AllowFocus = false;
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
            this.colMaName.FieldName = "Name";
            this.colMaName.Name = "colMaName";
            this.colMaName.OptionsColumn.AllowEdit = false;
            this.colMaName.OptionsColumn.AllowFocus = false;
            this.colMaName.Visible = true;
            this.colMaName.VisibleIndex = 1;
            this.colMaName.Width = 396;
            // 
            // colMaHang
            // 
            this.colMaHang.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMaHang.AppearanceHeader.Options.UseFont = true;
            this.colMaHang.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaHang.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaHang.Caption = "Hãng";
            this.colMaHang.FieldName = "Hang";
            this.colMaHang.Name = "colMaHang";
            this.colMaHang.OptionsColumn.AllowEdit = false;
            this.colMaHang.OptionsColumn.AllowFocus = false;
            this.colMaHang.Visible = true;
            this.colMaHang.VisibleIndex = 2;
            this.colMaHang.Width = 106;
            // 
            // colMaQty
            // 
            this.colMaQty.AppearanceCell.Options.UseTextOptions = true;
            this.colMaQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaQty.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMaQty.AppearanceHeader.Options.UseFont = true;
            this.colMaQty.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaQty.Caption = "Số lượng";
            this.colMaQty.FieldName = "Qty";
            this.colMaQty.Name = "colMaQty";
            this.colMaQty.Visible = true;
            this.colMaQty.VisibleIndex = 3;
            this.colMaQty.Width = 101;
            // 
            // colMaError
            // 
            this.colMaError.AppearanceCell.Options.UseTextOptions = true;
            this.colMaError.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaError.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMaError.AppearanceHeader.Options.UseFont = true;
            this.colMaError.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaError.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaError.Caption = "Lỗi";
            this.colMaError.FieldName = "Error";
            this.colMaError.Name = "colMaError";
            this.colMaError.OptionsColumn.AllowEdit = false;
            this.colMaError.OptionsColumn.AllowFocus = false;
            this.colMaError.Visible = true;
            this.colMaError.VisibleIndex = 4;
            // 
            // colMaKPH
            // 
            this.colMaKPH.AppearanceCell.Options.UseTextOptions = true;
            this.colMaKPH.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaKPH.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMaKPH.AppearanceHeader.Options.UseFont = true;
            this.colMaKPH.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaKPH.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaKPH.Caption = "Không phù hợp";
            this.colMaKPH.FieldName = "KPH";
            this.colMaKPH.Name = "colMaKPH";
            this.colMaKPH.OptionsColumn.AllowEdit = false;
            this.colMaKPH.OptionsColumn.AllowFocus = false;
            this.colMaKPH.Visible = true;
            this.colMaKPH.VisibleIndex = 5;
            this.colMaKPH.Width = 97;
            // 
            // colMaStatus
            // 
            this.colMaStatus.Caption = "Status";
            this.colMaStatus.FieldName = "Status";
            this.colMaStatus.Name = "colMaStatus";
            // 
            // colMaTonKho
            // 
            this.colMaTonKho.AppearanceCell.Options.UseTextOptions = true;
            this.colMaTonKho.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colMaTonKho.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMaTonKho.AppearanceHeader.Options.UseFont = true;
            this.colMaTonKho.AppearanceHeader.Options.UseTextOptions = true;
            this.colMaTonKho.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMaTonKho.Caption = "Tồn kho";
            this.colMaTonKho.DisplayFormat.FormatString = "n0";
            this.colMaTonKho.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMaTonKho.FieldName = "TonKho";
            this.colMaTonKho.Name = "colMaTonKho";
            this.colMaTonKho.Visible = true;
            this.colMaTonKho.VisibleIndex = 6;
            // 
            // btnDeleteVT
            // 
            this.btnDeleteVT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteVT.Location = new System.Drawing.Point(813, 8);
            this.btnDeleteVT.Name = "btnDeleteVT";
            this.btnDeleteVT.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteVT.TabIndex = 5;
            this.btnDeleteVT.Text = "Xóa BTH";
            this.btnDeleteVT.UseVisualStyleBackColor = true;
            // 
            // btnAddVT
            // 
            this.btnAddVT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddVT.Location = new System.Drawing.Point(890, 8);
            this.btnAddVT.Name = "btnAddVT";
            this.btnAddVT.Size = new System.Drawing.Size(86, 23);
            this.btnAddVT.TabIndex = 0;
            this.btnAddVT.Text = "Thêm BTH";
            this.btnAddVT.UseVisualStyleBackColor = true;
            // 
            // frmDanhMucBTH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 478);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.cboProject);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.searchLookUpEdit1);
            this.Controls.Add(this.cboProduct);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtProductCodeTK);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cboBoPhanTH);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboBoPhanYC);
            this.Controls.Add(this.label3);
            this.Name = "frmDanhMucBTH";
            this.Text = "Danh mục bài thực hành";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.cboProduct.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdModule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvModule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboBoPhanTH;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboBoPhanYC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProductCodeTK;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private DevExpress.XtraEditors.SearchLookUpEdit cboProduct;
        private DevExpress.XtraGrid.Views.Grid.GridView grvProduct;
        private DevExpress.XtraGrid.Columns.GridColumn colProductID;
        private DevExpress.XtraGrid.Columns.GridColumn colMaThietBi;
        private DevExpress.XtraGrid.Columns.GridColumn colTenThietBi;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.SearchLookUpEdit cboProject;
        private DevExpress.XtraGrid.Views.Grid.GridView grvProject;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectID;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectCode;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectName;
        private DevExpress.XtraGrid.Columns.GridColumn colYear;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnAddModule;
        private System.Windows.Forms.Button btnDeleteModule;
        private DevExpress.XtraGrid.GridControl grdModule;
        private DevExpress.XtraGrid.Views.Grid.GridView grvModule;
        private DevExpress.XtraGrid.Columns.GridColumn colMID;
        private DevExpress.XtraGrid.Columns.GridColumn colMCode;
        private DevExpress.XtraGrid.Columns.GridColumn colMName;
        private DevExpress.XtraGrid.Columns.GridColumn colMError;
        private DevExpress.XtraGrid.Columns.GridColumn colMKPH;
        private DevExpress.XtraGrid.Columns.GridColumn colMHang;
        private DevExpress.XtraGrid.Columns.GridColumn colMQty;
        private DevExpress.XtraGrid.Columns.GridColumn colMNameHD;
        private DevExpress.XtraGrid.Columns.GridColumn colMCodeHD;
        private DevExpress.XtraGrid.Columns.GridColumn colMStatus;
        private System.Windows.Forms.Label label16;
        private DevExpress.XtraGrid.GridControl grdVT;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVT;
        private DevExpress.XtraGrid.Columns.GridColumn colMaID;
        private DevExpress.XtraGrid.Columns.GridColumn colMaCode;
        private DevExpress.XtraGrid.Columns.GridColumn colMaName;
        private DevExpress.XtraGrid.Columns.GridColumn colMaHang;
        private DevExpress.XtraGrid.Columns.GridColumn colMaQty;
        private DevExpress.XtraGrid.Columns.GridColumn colMaError;
        private DevExpress.XtraGrid.Columns.GridColumn colMaKPH;
        private DevExpress.XtraGrid.Columns.GridColumn colMaStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colMaTonKho;
        private System.Windows.Forms.Button btnDeleteVT;
        private System.Windows.Forms.Button btnAddVT;
    }
}