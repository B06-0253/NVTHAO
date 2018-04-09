namespace BMS
{
    partial class frmContractType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmContractType));
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.grvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IsOTL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsBook = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContractTypeIDs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.STT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDebitDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDueDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colARDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContractTypeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUpdatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUpdatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTransactionID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repoLookUpNVLienhe = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repoLookUpContactRelate = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.rep1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.btnTransactionCode_C = new System.Windows.Forms.Button();
            this.btnContractTypeCode = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.txtTransactionCode = new System.Windows.Forms.TextBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mnuMenu = new System.Windows.Forms.ToolStrip();
            this.btnNew = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.chkIsOTL = new System.Windows.Forms.CheckBox();
            this.chkIsBook = new System.Windows.Forms.CheckBox();
            this.txtARDate = new System.Windows.Forms.TextBox();
            this.txtDueDate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDebitDate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblCreatedBy = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCreatedDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUpdatedBy = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUpdatedDate = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoLookUpNVLienhe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoLookUpContactRelate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep1)).BeginInit();
            this.mnuMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // colStatus
            // 
            this.colStatus.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colStatus.AppearanceHeader.Options.UseFont = true;
            this.colStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.colStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStatus.Caption = "Trạng thái";
            this.colStatus.FieldName = "StatusText";
            this.colStatus.Name = "colStatus";
            this.colStatus.OptionsColumn.AllowEdit = false;
            this.colStatus.OptionsColumn.AllowFocus = false;
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 8;
            this.colStatus.Width = 121;
            // 
            // grdData
            // 
            this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdData.Location = new System.Drawing.Point(-2, 166);
            this.grdData.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grdData.MainView = this.grvData;
            this.grdData.Name = "grdData";
            this.grdData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoLookUpNVLienhe,
            this.repoLookUpContactRelate,
            this.repositoryItemCheckEdit1,
            this.rep1});
            this.grdData.Size = new System.Drawing.Size(961, 358);
            this.grdData.TabIndex = 2;
            this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvData});
            this.grdData.Click += new System.EventHandler(this.grdData_Click);
            // 
            // grvData
            // 
            this.grvData.ColumnPanelRowHeight = 20;
            this.grvData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IsOTL,
            this.colIsBook,
            this.colContractTypeIDs,
            this.STT,
            this.colDebitDate,
            this.colDueDate,
            this.colARDate,
            this.colName,
            this.colContractTypeCode,
            this.colStatus,
            this.colID,
            this.gridColumn1,
            this.colCreatedBy,
            this.colCreatedDate,
            this.colUpdatedBy,
            this.colUpdatedDate,
            this.colTransactionID});
            this.grvData.GridControl = this.grdData;
            this.grvData.Name = "grvData";
            this.grvData.OptionsView.ColumnAutoWidth = false;
            this.grvData.OptionsView.ShowAutoFilterRow = true;
            this.grvData.OptionsView.ShowGroupPanel = false;
            this.grvData.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grcDetail_CustomDrawCell);
            this.grvData.Click += new System.EventHandler(this.grvData_Click);
            this.grvData.DoubleClick += new System.EventHandler(this.grvData_DoubleClick);
            // 
            // IsOTL
            // 
            this.IsOTL.AppearanceCell.Options.UseTextOptions = true;
            this.IsOTL.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.IsOTL.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.IsOTL.AppearanceHeader.Options.UseFont = true;
            this.IsOTL.AppearanceHeader.Options.UseTextOptions = true;
            this.IsOTL.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.IsOTL.Caption = "IsOTL";
            this.IsOTL.FieldName = "IsOTL";
            this.IsOTL.Name = "IsOTL";
            this.IsOTL.OptionsColumn.AllowEdit = false;
            this.IsOTL.OptionsColumn.AllowFocus = false;
            this.IsOTL.Visible = true;
            this.IsOTL.VisibleIndex = 7;
            this.IsOTL.Width = 57;
            // 
            // colIsBook
            // 
            this.colIsBook.AppearanceCell.Options.UseTextOptions = true;
            this.colIsBook.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsBook.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colIsBook.AppearanceHeader.Options.UseFont = true;
            this.colIsBook.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsBook.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsBook.Caption = "IsBook";
            this.colIsBook.FieldName = "IsBook";
            this.colIsBook.Name = "colIsBook";
            this.colIsBook.OptionsColumn.AllowEdit = false;
            this.colIsBook.OptionsColumn.AllowFocus = false;
            this.colIsBook.Visible = true;
            this.colIsBook.VisibleIndex = 6;
            this.colIsBook.Width = 50;
            // 
            // colContractTypeIDs
            // 
            this.colContractTypeIDs.AppearanceCell.Options.UseTextOptions = true;
            this.colContractTypeIDs.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colContractTypeIDs.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colContractTypeIDs.AppearanceHeader.Options.UseFont = true;
            this.colContractTypeIDs.AppearanceHeader.Options.UseTextOptions = true;
            this.colContractTypeIDs.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colContractTypeIDs.Caption = "Loại HD ";
            this.colContractTypeIDs.FieldName = "ContractTypeIDs";
            this.colContractTypeIDs.Name = "colContractTypeIDs";
            this.colContractTypeIDs.OptionsColumn.AllowEdit = false;
            this.colContractTypeIDs.OptionsColumn.AllowFocus = false;
            this.colContractTypeIDs.Visible = true;
            this.colContractTypeIDs.VisibleIndex = 2;
            this.colContractTypeIDs.Width = 97;
            // 
            // STT
            // 
            this.STT.AppearanceCell.Options.UseTextOptions = true;
            this.STT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.STT.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.STT.AppearanceHeader.Options.UseFont = true;
            this.STT.AppearanceHeader.Options.UseTextOptions = true;
            this.STT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.STT.Caption = "STT";
            this.STT.FieldName = "STT";
            this.STT.Name = "STT";
            this.STT.OptionsColumn.AllowEdit = false;
            this.STT.OptionsColumn.AllowFocus = false;
            this.STT.Visible = true;
            this.STT.VisibleIndex = 0;
            // 
            // colDebitDate
            // 
            this.colDebitDate.AppearanceCell.Options.UseTextOptions = true;
            this.colDebitDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDebitDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colDebitDate.AppearanceHeader.Options.UseFont = true;
            this.colDebitDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colDebitDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDebitDate.Caption = "Ngày lập sau";
            this.colDebitDate.FieldName = "DebitDate";
            this.colDebitDate.Name = "colDebitDate";
            this.colDebitDate.OptionsColumn.AllowEdit = false;
            this.colDebitDate.OptionsColumn.AllowFocus = false;
            this.colDebitDate.Visible = true;
            this.colDebitDate.VisibleIndex = 3;
            this.colDebitDate.Width = 105;
            // 
            // colDueDate
            // 
            this.colDueDate.AppearanceCell.Options.UseTextOptions = true;
            this.colDueDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDueDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colDueDate.AppearanceHeader.Options.UseFont = true;
            this.colDueDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colDueDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDueDate.Caption = "Ngày nộp sau";
            this.colDueDate.FieldName = "DueDate";
            this.colDueDate.Name = "colDueDate";
            this.colDueDate.OptionsColumn.AllowEdit = false;
            this.colDueDate.OptionsColumn.AllowFocus = false;
            this.colDueDate.Visible = true;
            this.colDueDate.VisibleIndex = 4;
            this.colDueDate.Width = 108;
            // 
            // colARDate
            // 
            this.colARDate.AppearanceCell.Options.UseTextOptions = true;
            this.colARDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colARDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colARDate.AppearanceHeader.Options.UseFont = true;
            this.colARDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colARDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colARDate.Caption = "Ngày tính lãi sau";
            this.colARDate.FieldName = "ARDate";
            this.colARDate.Name = "colARDate";
            this.colARDate.OptionsColumn.AllowEdit = false;
            this.colARDate.OptionsColumn.AllowFocus = false;
            this.colARDate.Visible = true;
            this.colARDate.VisibleIndex = 5;
            this.colARDate.Width = 116;
            // 
            // colName
            // 
            this.colName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colName.AppearanceHeader.Options.UseFont = true;
            this.colName.AppearanceHeader.Options.UseTextOptions = true;
            this.colName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colName.Caption = "Tên";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.OptionsColumn.AllowFocus = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 215;
            // 
            // colContractTypeCode
            // 
            this.colContractTypeCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colContractTypeCode.AppearanceHeader.Options.UseFont = true;
            this.colContractTypeCode.Caption = "Mã code";
            this.colContractTypeCode.FieldName = "ContractTypeIDs";
            this.colContractTypeCode.Name = "colContractTypeCode";
            this.colContractTypeCode.OptionsColumn.AllowEdit = false;
            this.colContractTypeCode.OptionsColumn.AllowFocus = false;
            this.colContractTypeCode.Width = 249;
            // 
            // colID
            // 
            this.colID.Caption = "gridColumn4";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Status";
            this.gridColumn1.FieldName = "Status";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.AllowFocus = false;
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.Caption = "gridColumn5";
            this.colCreatedBy.FieldName = "CreatedBy";
            this.colCreatedBy.Name = "colCreatedBy";
            // 
            // colCreatedDate
            // 
            this.colCreatedDate.Caption = "gridColumn6";
            this.colCreatedDate.FieldName = "CreatedDate";
            this.colCreatedDate.Name = "colCreatedDate";
            // 
            // colUpdatedBy
            // 
            this.colUpdatedBy.Caption = "gridColumn7";
            this.colUpdatedBy.FieldName = "UpdatedBy";
            this.colUpdatedBy.Name = "colUpdatedBy";
            // 
            // colUpdatedDate
            // 
            this.colUpdatedDate.Caption = "gridColumn8";
            this.colUpdatedDate.FieldName = "UpdatedDate";
            this.colUpdatedDate.Name = "colUpdatedDate";
            // 
            // colTransactionID
            // 
            this.colTransactionID.Caption = "TransactionID";
            this.colTransactionID.FieldName = "TransactionID";
            this.colTransactionID.Name = "colTransactionID";
            // 
            // repoLookUpNVLienhe
            // 
            this.repoLookUpNVLienhe.AutoHeight = false;
            this.repoLookUpNVLienhe.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repoLookUpNVLienhe.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("LoginName", "Tên đăng nhập")});
            this.repoLookUpNVLienhe.Name = "repoLookUpNVLienhe";
            // 
            // repoLookUpContactRelate
            // 
            this.repoLookUpContactRelate.AutoHeight = false;
            this.repoLookUpContactRelate.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repoLookUpContactRelate.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.repoLookUpContactRelate.Name = "repoLookUpContactRelate";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // rep1
            // 
            this.rep1.AutoHeight = false;
            this.rep1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rep1.DisplayMember = "Name";
            this.rep1.Name = "rep1";
            this.rep1.ValueMember = "ID";
            // 
            // btnTransactionCode_C
            // 
            this.btnTransactionCode_C.BackColor = System.Drawing.Color.Transparent;
            this.btnTransactionCode_C.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTransactionCode_C.BackgroundImage")));
            this.btnTransactionCode_C.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnTransactionCode_C.Enabled = false;
            this.btnTransactionCode_C.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransactionCode_C.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransactionCode_C.Location = new System.Drawing.Point(254, 60);
            this.btnTransactionCode_C.Name = "btnTransactionCode_C";
            this.btnTransactionCode_C.Size = new System.Drawing.Size(25, 22);
            this.btnTransactionCode_C.TabIndex = 341;
            this.btnTransactionCode_C.UseVisualStyleBackColor = true;
            this.btnTransactionCode_C.Click += new System.EventHandler(this.btnTransactionCode_C_Click);
            // 
            // btnContractTypeCode
            // 
            this.btnContractTypeCode.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnContractTypeCode.BackgroundImage")));
            this.btnContractTypeCode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnContractTypeCode.Enabled = false;
            this.btnContractTypeCode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnContractTypeCode.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContractTypeCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnContractTypeCode.ImageIndex = 17;
            this.btnContractTypeCode.Location = new System.Drawing.Point(223, 60);
            this.btnContractTypeCode.Name = "btnContractTypeCode";
            this.btnContractTypeCode.Size = new System.Drawing.Size(25, 22);
            this.btnContractTypeCode.TabIndex = 340;
            this.btnContractTypeCode.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnContractTypeCode.Click += new System.EventHandler(this.btnContractTypeCode_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(24, 62);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(47, 14);
            this.label24.TabIndex = 339;
            this.label24.Text = "Loại HD:";
            // 
            // txtTransactionCode
            // 
            this.txtTransactionCode.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransactionCode.Location = new System.Drawing.Point(81, 59);
            this.txtTransactionCode.Name = "txtTransactionCode";
            this.txtTransactionCode.ReadOnly = true;
            this.txtTransactionCode.Size = new System.Drawing.Size(136, 20);
            this.txtTransactionCode.TabIndex = 338;
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.Enabled = false;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "Ngừng hoạt động",
            "Hoạt động"});
            this.cboStatus.Location = new System.Drawing.Point(81, 88);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(136, 22);
            this.cboStatus.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(81, 32);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(202, 21);
            this.txtName.TabIndex = 0;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(24, 35);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(25, 14);
            this.lbl.TabIndex = 145;
            this.lbl.Text = "Tên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 143;
            this.label1.Text = "Trạng thái";
            // 
            // mnuMenu
            // 
            this.mnuMenu.AutoSize = false;
            this.mnuMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.mnuMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNew,
            this.btnEdit,
            this.btnDelete,
            this.btnSave,
            this.btnCancel,
            this.toolStripSeparator1,
            this.btnClose});
            this.mnuMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuMenu.Size = new System.Drawing.Size(959, 45);
            this.mnuMenu.TabIndex = 0;
            this.mnuMenu.Text = "toolStrip2";
            // 
            // btnNew
            // 
            this.btnNew.AutoSize = false;
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(55, 40);
            this.btnNew.Tag = "ct_ContractType_New";
            this.btnNew.Text = "Thêm";
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
            this.btnEdit.Tag = "ct_ContractType_Edit";
            this.btnEdit.Text = "&Sửa";
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
            this.btnDelete.Tag = "ct_ContractType_Delete";
            this.btnDelete.Text = "&Xóa";
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
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.Maroon;
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl1.Controls.Add(this.chkIsOTL);
            this.groupControl1.Controls.Add(this.chkIsBook);
            this.groupControl1.Controls.Add(this.txtARDate);
            this.groupControl1.Controls.Add(this.txtDueDate);
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.txtDebitDate);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.btnTransactionCode_C);
            this.groupControl1.Controls.Add(this.cboStatus);
            this.groupControl1.Controls.Add(this.btnContractTypeCode);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.label24);
            this.groupControl1.Controls.Add(this.lbl);
            this.groupControl1.Controls.Add(this.txtTransactionCode);
            this.groupControl1.Controls.Add(this.txtName);
            this.groupControl1.Location = new System.Drawing.Point(-1, 45);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(960, 124);
            this.groupControl1.TabIndex = 204;
            this.groupControl1.Text = "Thông tin loại hợp đồng";
            // 
            // chkIsOTL
            // 
            this.chkIsOTL.AutoSize = true;
            this.chkIsOTL.Enabled = false;
            this.chkIsOTL.Location = new System.Drawing.Point(597, 65);
            this.chkIsOTL.Name = "chkIsOTL";
            this.chkIsOTL.Size = new System.Drawing.Size(118, 18);
            this.chkIsOTL.TabIndex = 351;
            this.chkIsOTL.Text = "Loại hợp đồng OTL";
            this.chkIsOTL.UseVisualStyleBackColor = true;
            this.chkIsOTL.CheckedChanged += new System.EventHandler(this.chkIsOTL_CheckedChanged);
            // 
            // chkIsBook
            // 
            this.chkIsBook.AutoSize = true;
            this.chkIsBook.Enabled = false;
            this.chkIsBook.Location = new System.Drawing.Point(597, 39);
            this.chkIsBook.Name = "chkIsBook";
            this.chkIsBook.Size = new System.Drawing.Size(58, 18);
            this.chkIsBook.TabIndex = 350;
            this.chkIsBook.Text = "IsBook";
            this.chkIsBook.UseVisualStyleBackColor = true;
            this.chkIsBook.CheckedChanged += new System.EventHandler(this.chkIsBook_CheckedChanged);
            // 
            // txtARDate
            // 
            this.txtARDate.Enabled = false;
            this.txtARDate.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtARDate.Location = new System.Drawing.Point(485, 88);
            this.txtARDate.Name = "txtARDate";
            this.txtARDate.Size = new System.Drawing.Size(38, 20);
            this.txtARDate.TabIndex = 347;
            this.txtARDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtARDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDebitDate_KeyPress);
            // 
            // txtDueDate
            // 
            this.txtDueDate.Enabled = false;
            this.txtDueDate.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDueDate.Location = new System.Drawing.Point(485, 63);
            this.txtDueDate.Name = "txtDueDate";
            this.txtDueDate.Size = new System.Drawing.Size(38, 20);
            this.txtDueDate.TabIndex = 346;
            this.txtDueDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDueDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDebitDate_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(378, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 14);
            this.label5.TabIndex = 345;
            this.label5.Text = "Ngày nộp sau";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(378, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 14);
            this.label2.TabIndex = 344;
            this.label2.Text = "Ngày tính lãi sau";
            // 
            // txtDebitDate
            // 
            this.txtDebitDate.Enabled = false;
            this.txtDebitDate.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDebitDate.Location = new System.Drawing.Point(485, 37);
            this.txtDebitDate.Name = "txtDebitDate";
            this.txtDebitDate.Size = new System.Drawing.Size(38, 20);
            this.txtDebitDate.TabIndex = 343;
            this.txtDebitDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDebitDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDebitDate_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(378, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 342;
            this.label3.Text = "Ngày lập sau";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblCreatedBy,
            this.lblCreatedDate,
            this.lblUpdatedBy,
            this.lblUpdatedDate});
            this.statusStrip1.Location = new System.Drawing.Point(0, 524);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(959, 24);
            this.statusStrip1.TabIndex = 273;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.BackColor = System.Drawing.Color.Transparent;
            this.lblCreatedBy.ForeColor = System.Drawing.Color.Blue;
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(72, 19);
            this.lblCreatedBy.Text = "Người tạo:...";
            // 
            // lblCreatedDate
            // 
            this.lblCreatedDate.BackColor = System.Drawing.Color.Transparent;
            this.lblCreatedDate.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lblCreatedDate.ForeColor = System.Drawing.Color.Blue;
            this.lblCreatedDate.Name = "lblCreatedDate";
            this.lblCreatedDate.Size = new System.Drawing.Size(71, 19);
            this.lblCreatedDate.Text = "Ngày tạo:...";
            // 
            // lblUpdatedBy
            // 
            this.lblUpdatedBy.BackColor = System.Drawing.Color.Transparent;
            this.lblUpdatedBy.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lblUpdatedBy.ForeColor = System.Drawing.Color.Blue;
            this.lblUpdatedBy.Name = "lblUpdatedBy";
            this.lblUpdatedBy.Size = new System.Drawing.Size(77, 19);
            this.lblUpdatedBy.Text = "Người sửa:...";
            // 
            // lblUpdatedDate
            // 
            this.lblUpdatedDate.BackColor = System.Drawing.Color.Transparent;
            this.lblUpdatedDate.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.lblUpdatedDate.ForeColor = System.Drawing.Color.Blue;
            this.lblUpdatedDate.Name = "lblUpdatedDate";
            this.lblUpdatedDate.Size = new System.Drawing.Size(72, 19);
            this.lblUpdatedDate.Text = "Ngày sửa:...";
            // 
            // frmContractType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 548);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.grdData);
            this.Controls.Add(this.mnuMenu);
            this.Name = "frmContractType";
            this.Tag = "ct_ContractType_View";
            this.Text = "Danh sách loại hợp đồng";
            this.Load += new System.EventHandler(this.frmContractType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoLookUpNVLienhe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoLookUpContactRelate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rep1)).EndInit();
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.Grid.GridView grvData;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit rep1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repoLookUpNVLienhe;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repoLookUpContactRelate;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.ToolStrip mnuMenu;
        private System.Windows.Forms.ToolStripButton btnNew;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private System.Windows.Forms.ToolStripButton btnClose;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdatedDate;
        private System.Windows.Forms.Button btnTransactionCode_C;
        private System.Windows.Forms.Button btnContractTypeCode;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtTransactionCode;
        private DevExpress.XtraGrid.Columns.GridColumn colContractTypeCode;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblCreatedBy;
        private System.Windows.Forms.ToolStripStatusLabel lblCreatedDate;
        private System.Windows.Forms.ToolStripStatusLabel lblUpdatedBy;
        private System.Windows.Forms.ToolStripStatusLabel lblUpdatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colTransactionID;
        private System.Windows.Forms.TextBox txtARDate;
        private System.Windows.Forms.TextBox txtDueDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDebitDate;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraGrid.Columns.GridColumn STT;
        private DevExpress.XtraGrid.Columns.GridColumn colDebitDate;
        private DevExpress.XtraGrid.Columns.GridColumn colDueDate;
        private DevExpress.XtraGrid.Columns.GridColumn colARDate;
        private DevExpress.XtraGrid.Columns.GridColumn colContractTypeIDs;
        private System.Windows.Forms.CheckBox chkIsOTL;
        private System.Windows.Forms.CheckBox chkIsBook;
        private DevExpress.XtraGrid.Columns.GridColumn IsOTL;
        private DevExpress.XtraGrid.Columns.GridColumn colIsBook;
    }
}