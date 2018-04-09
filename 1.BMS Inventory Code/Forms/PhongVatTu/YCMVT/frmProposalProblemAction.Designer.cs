namespace BMS
{
    partial class frmProposalProblemAction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProposalProblemAction));
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.colAccount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartmentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.grvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUAcount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAction = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colDeadline = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsCompleted = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.colCboFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dtpDeadline = new DevExpress.XtraEditors.DateEdit();
            this.mnuMenu = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSaveAndClose = new System.Windows.Forms.ToolStripButton();
            this.colUserCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboUser = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.grvCboUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.btnIsCompleted = new System.Windows.Forms.Button();
            this.txtAction = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkIsCompleted = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSolution = new System.Windows.Forms.TextBox();
            this.txtYCMVT = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDeadline.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDeadline.Properties)).BeginInit();
            this.mnuMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCboUser)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteUser.Location = new System.Drawing.Point(856, 67);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(43, 23);
            this.btnDeleteUser.TabIndex = 2;
            this.btnDeleteUser.Text = "Xóa";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // colAccount
            // 
            this.colAccount.Caption = "Tên đăng nhập";
            this.colAccount.FieldName = "Account";
            this.colAccount.Name = "colAccount";
            this.colAccount.Visible = true;
            this.colAccount.VisibleIndex = 1;
            // 
            // colDepartmentName
            // 
            this.colDepartmentName.Caption = "Phòng ban";
            this.colDepartmentName.FieldName = "DName";
            this.colDepartmentName.Name = "colDepartmentName";
            this.colDepartmentName.Visible = true;
            this.colDepartmentName.VisibleIndex = 3;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUser.Location = new System.Drawing.Point(796, 67);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(57, 23);
            this.btnAddUser.TabIndex = 1;
            this.btnAddUser.Text = "Thêm";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // grdData
            // 
            this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdData.Location = new System.Drawing.Point(1, 96);
            this.grdData.MainView = this.grvData;
            this.grdData.Name = "grdData";
            this.grdData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.repositoryItemMemoEdit1});
            this.grdData.Size = new System.Drawing.Size(899, 226);
            this.grdData.TabIndex = 266;
            this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvData});
            // 
            // grvData
            // 
            this.grvData.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvData.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvData.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvData.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colUserId,
            this.colUAcount,
            this.colUserName,
            this.colAction,
            this.colDeadline,
            this.colIsCompleted});
            this.grvData.GridControl = this.grdData;
            this.grvData.Name = "grvData";
            this.grvData.OptionsBehavior.Editable = false;
            this.grvData.OptionsMenu.EnableFooterMenu = false;
            this.grvData.OptionsMenu.EnableGroupPanelMenu = false;
            this.grvData.OptionsSelection.MultiSelect = true;
            this.grvData.OptionsView.ColumnAutoWidth = false;
            this.grvData.OptionsView.ShowGroupPanel = false;
            // 
            // colID
            // 
            this.colID.AppearanceCell.Options.UseTextOptions = true;
            this.colID.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colID.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colID.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colID.AppearanceHeader.Options.UseFont = true;
            this.colID.AppearanceHeader.Options.UseTextOptions = true;
            this.colID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colID.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.AllowEdit = false;
            // 
            // colUserId
            // 
            this.colUserId.AppearanceCell.Options.UseTextOptions = true;
            this.colUserId.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colUserId.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colUserId.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colUserId.AppearanceHeader.Options.UseFont = true;
            this.colUserId.AppearanceHeader.Options.UseTextOptions = true;
            this.colUserId.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUserId.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colUserId.Caption = "UserId";
            this.colUserId.FieldName = "UserId";
            this.colUserId.Name = "colUserId";
            this.colUserId.OptionsColumn.AllowEdit = false;
            this.colUserId.Width = 132;
            // 
            // colUAcount
            // 
            this.colUAcount.AppearanceCell.Options.UseTextOptions = true;
            this.colUAcount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUAcount.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colUAcount.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colUAcount.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colUAcount.AppearanceHeader.Options.UseFont = true;
            this.colUAcount.AppearanceHeader.Options.UseTextOptions = true;
            this.colUAcount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUAcount.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colUAcount.Caption = "Tên đăng nhập";
            this.colUAcount.FieldName = "Account";
            this.colUAcount.Name = "colUAcount";
            this.colUAcount.OptionsColumn.AllowEdit = false;
            this.colUAcount.Width = 104;
            // 
            // colUserName
            // 
            this.colUserName.AppearanceCell.Options.UseTextOptions = true;
            this.colUserName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colUserName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colUserName.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colUserName.AppearanceHeader.Options.UseFont = true;
            this.colUserName.AppearanceHeader.Options.UseTextOptions = true;
            this.colUserName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUserName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colUserName.Caption = "Người phụ trách";
            this.colUserName.FieldName = "UserName";
            this.colUserName.Name = "colUserName";
            this.colUserName.OptionsColumn.AllowEdit = false;
            this.colUserName.Visible = true;
            this.colUserName.VisibleIndex = 1;
            this.colUserName.Width = 174;
            // 
            // colAction
            // 
            this.colAction.AppearanceCell.Options.UseTextOptions = true;
            this.colAction.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colAction.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colAction.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colAction.AppearanceHeader.Options.UseFont = true;
            this.colAction.AppearanceHeader.Options.UseTextOptions = true;
            this.colAction.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAction.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colAction.Caption = "Hành động/phương án";
            this.colAction.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colAction.FieldName = "Action";
            this.colAction.Name = "colAction";
            this.colAction.OptionsColumn.AllowEdit = false;
            this.colAction.Visible = true;
            this.colAction.VisibleIndex = 0;
            this.colAction.Width = 451;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // colDeadline
            // 
            this.colDeadline.AppearanceCell.Options.UseTextOptions = true;
            this.colDeadline.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDeadline.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDeadline.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDeadline.AppearanceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colDeadline.AppearanceHeader.Options.UseFont = true;
            this.colDeadline.AppearanceHeader.Options.UseTextOptions = true;
            this.colDeadline.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDeadline.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDeadline.Caption = "Hạn hoàn thành";
            this.colDeadline.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colDeadline.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDeadline.FieldName = "Deadline";
            this.colDeadline.Name = "colDeadline";
            this.colDeadline.OptionsColumn.AllowEdit = false;
            this.colDeadline.Visible = true;
            this.colDeadline.VisibleIndex = 2;
            this.colDeadline.Width = 113;
            // 
            // colIsCompleted
            // 
            this.colIsCompleted.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colIsCompleted.AppearanceHeader.Options.UseFont = true;
            this.colIsCompleted.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsCompleted.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsCompleted.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colIsCompleted.Caption = "Hoàn thành";
            this.colIsCompleted.FieldName = "IsCompleted";
            this.colIsCompleted.Name = "colIsCompleted";
            this.colIsCompleted.OptionsColumn.AllowEdit = false;
            this.colIsCompleted.Visible = true;
            this.colIsCompleted.VisibleIndex = 3;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            this.repositoryItemDateEdit1.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Người phụ trách";
            // 
            // colCboFullName
            // 
            this.colCboFullName.Caption = "Tên đầy đủ";
            this.colCboFullName.FieldName = "UserName";
            this.colCboFullName.Name = "colCboFullName";
            this.colCboFullName.Visible = true;
            this.colCboFullName.VisibleIndex = 2;
            // 
            // dtpDeadline
            // 
            this.dtpDeadline.EditValue = null;
            this.dtpDeadline.Location = new System.Drawing.Point(506, 23);
            this.dtpDeadline.Name = "dtpDeadline";
            this.dtpDeadline.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dtpDeadline.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtpDeadline.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpDeadline.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtpDeadline.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpDeadline.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtpDeadline.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtpDeadline.Properties.NullValuePromptShowForEmptyValue = true;
            this.dtpDeadline.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtpDeadline.Size = new System.Drawing.Size(139, 20);
            this.dtpDeadline.TabIndex = 259;
            // 
            // mnuMenu
            // 
            this.mnuMenu.AutoSize = false;
            this.mnuMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.mnuMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.toolStripSeparator3,
            this.btnSaveAndClose});
            this.mnuMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuMenu.Size = new System.Drawing.Size(905, 42);
            this.mnuMenu.TabIndex = 262;
            this.mnuMenu.Text = "toolStrip2";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(29, 33);
            this.btnSave.Tag = "frmBCLError_Save";
            this.btnSave.Text = "Ghi";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.AutoSize = false;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 40);
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAndClose.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveAndClose.Image")));
            this.btnSaveAndClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(77, 33);
            this.btnSaveAndClose.Tag = "frmBCLError_Save";
            this.btnSaveAndClose.Text = "Ghi && Thoát";
            this.btnSaveAndClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // colUserCode
            // 
            this.colUserCode.Caption = "Mã nhân viên";
            this.colUserCode.FieldName = "SupplierCode";
            this.colUserCode.Name = "colUserCode";
            this.colUserCode.Visible = true;
            this.colUserCode.VisibleIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dtpDeadline);
            this.groupBox1.Controls.Add(this.grdData);
            this.groupBox1.Controls.Add(this.cboUser);
            this.groupBox1.Controls.Add(this.btnDeleteUser);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnIsCompleted);
            this.groupBox1.Controls.Add(this.btnAddUser);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtAction);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(0, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(905, 331);
            this.groupBox1.TabIndex = 261;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách hành động/phương án";
            // 
            // cboUser
            // 
            this.cboUser.Location = new System.Drawing.Point(96, 23);
            this.cboUser.Name = "cboUser";
            this.cboUser.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7F);
            this.cboUser.Properties.Appearance.Options.UseFont = true;
            this.cboUser.Properties.AutoHeight = false;
            this.cboUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboUser.Properties.NullText = "";
            this.cboUser.Properties.View = this.grvCboUser;
            this.cboUser.Size = new System.Drawing.Size(275, 20);
            this.cboUser.TabIndex = 0;
            // 
            // grvCboUser
            // 
            this.grvCboUser.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.colUserCode,
            this.colCboFullName,
            this.colAccount,
            this.colDepartmentName});
            this.grvCboUser.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboUser.GroupCount = 1;
            this.grvCboUser.Name = "grvCboUser";
            this.grvCboUser.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvCboUser.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboUser.OptionsView.ShowGroupedColumns = true;
            this.grvCboUser.OptionsView.ShowGroupPanel = false;
            this.grvCboUser.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDepartmentName, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ID";
            this.gridColumn1.FieldName = "UserId";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(418, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 263;
            this.label2.Text = "Hạn hoàn thành";
            // 
            // btnIsCompleted
            // 
            this.btnIsCompleted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIsCompleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIsCompleted.Location = new System.Drawing.Point(706, 67);
            this.btnIsCompleted.Name = "btnIsCompleted";
            this.btnIsCompleted.Size = new System.Drawing.Size(87, 23);
            this.btnIsCompleted.TabIndex = 1;
            this.btnIsCompleted.Text = "Hoàn thành";
            this.btnIsCompleted.UseVisualStyleBackColor = true;
            this.btnIsCompleted.Visible = false;
            this.btnIsCompleted.Click += new System.EventHandler(this.btnIsCompleted_Click);
            // 
            // txtAction
            // 
            this.txtAction.Location = new System.Drawing.Point(96, 52);
            this.txtAction.Multiline = true;
            this.txtAction.Name = "txtAction";
            this.txtAction.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAction.Size = new System.Drawing.Size(549, 38);
            this.txtAction.TabIndex = 258;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 26);
            this.label1.TabIndex = 264;
            this.label1.Text = "Hành động/\r\nphương án";
            // 
            // chkIsCompleted
            // 
            this.chkIsCompleted.AutoSize = true;
            this.chkIsCompleted.Location = new System.Drawing.Point(796, 60);
            this.chkIsCompleted.Name = "chkIsCompleted";
            this.chkIsCompleted.Size = new System.Drawing.Size(97, 17);
            this.chkIsCompleted.TabIndex = 257;
            this.chkIsCompleted.Text = "Đã hoàn thành";
            this.chkIsCompleted.UseVisualStyleBackColor = true;
            this.chkIsCompleted.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 264;
            this.label5.Text = "Nguyên nhân";
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(100, 51);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtReason.Size = new System.Drawing.Size(275, 38);
            this.txtReason.TabIndex = 258;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(450, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 264;
            this.label6.Text = "Giải pháp";
            // 
            // txtSolution
            // 
            this.txtSolution.Location = new System.Drawing.Point(506, 51);
            this.txtSolution.Multiline = true;
            this.txtSolution.Name = "txtSolution";
            this.txtSolution.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSolution.Size = new System.Drawing.Size(263, 38);
            this.txtSolution.TabIndex = 258;
            // 
            // txtYCMVT
            // 
            this.txtYCMVT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtYCMVT.Location = new System.Drawing.Point(373, 10);
            this.txtYCMVT.Name = "txtYCMVT";
            this.txtYCMVT.ReadOnly = true;
            this.txtYCMVT.Size = new System.Drawing.Size(164, 21);
            this.txtYCMVT.TabIndex = 265;
            this.txtYCMVT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmProposalProblemAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 437);
            this.Controls.Add(this.txtYCMVT);
            this.Controls.Add(this.mnuMenu);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkIsCompleted);
            this.Controls.Add(this.txtSolution);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.label5);
            this.Name = "frmProposalProblemAction";
            this.Text = "PHƯƠNG ÁN/HÀNH ĐỘNG";
            this.Load += new System.EventHandler(this.frmProposalProblemAction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDeadline.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDeadline.Properties)).EndInit();
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCboUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDeleteUser;
        private DevExpress.XtraGrid.Columns.GridColumn colAccount;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartmentName;
        private System.Windows.Forms.Button btnAddUser;
        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.Grid.GridView grvData;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colUserId;
        private DevExpress.XtraGrid.Columns.GridColumn colUAcount;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraGrid.Columns.GridColumn colCboFullName;
        private DevExpress.XtraEditors.DateEdit dtpDeadline;
        private System.Windows.Forms.ToolStrip mnuMenu;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnSaveAndClose;
        private DevExpress.XtraGrid.Columns.GridColumn colUserCode;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SearchLookUpEdit cboUser;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCboUser;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private System.Windows.Forms.CheckBox chkIsCompleted;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAction;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSolution;
        private System.Windows.Forms.TextBox txtYCMVT;
        private DevExpress.XtraGrid.Columns.GridColumn colAction;
        private DevExpress.XtraGrid.Columns.GridColumn colDeadline;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colIsCompleted;
        private System.Windows.Forms.Button btnIsCompleted;
    }
}