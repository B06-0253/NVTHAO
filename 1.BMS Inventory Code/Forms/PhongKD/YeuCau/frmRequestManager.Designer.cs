namespace BMS
{
    partial class frmRequestManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRequestManager));
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.mnuMenu = new System.Windows.Forms.ToolStrip();
            this.btnNewGroup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEditGroup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDeleteGroup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnImport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnListError = new System.Windows.Forms.ToolStripButton();
            this.grvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPath = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUpdatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReportMAT = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSendModuleContentByMail = new System.Windows.Forms.ToolStripMenuItem();
            this.btnShowDMVT = new System.Windows.Forms.ToolStripMenuItem();
            this.danhSachNgươiThiêtKêToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xemTaiLiêuThiêtKêToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnShowFilm = new System.Windows.Forms.ToolStripMenuItem();
            this.btnShowTem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUpdateModuleVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.btnModulePrice = new System.Windows.Forms.ToolStripMenuItem();
            this.danhSáchVersionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xemDanhSáchDựÁnChứaModuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colCodeTree = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colNameTree = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colIDTree = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.btnFindAll = new DevExpress.XtraEditors.SimpleButton();
            this.txtName = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.treeData = new DevExpress.XtraTreeList.TreeList();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            this.mnuMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeData)).BeginInit();
            this.SuspendLayout();
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
            this.colName.Caption = "Tên YC";
            this.colName.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.OptionsColumn.AllowSize = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 235;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Appearance.Options.UseTextOptions = true;
            this.repositoryItemMemoEdit1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // mnuMenu
            // 
            this.mnuMenu.AutoSize = false;
            this.mnuMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.mnuMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewGroup,
            this.toolStripSeparator9,
            this.btnEditGroup,
            this.toolStripSeparator8,
            this.btnDeleteGroup,
            this.toolStripSeparator7,
            this.btnAdd,
            this.toolStripSeparator6,
            this.btnEdit,
            this.toolStripSeparator4,
            this.btnDel,
            this.toolStripSeparator2,
            this.btnImport,
            this.toolStripSeparator5,
            this.btnCopy,
            this.toolStripSeparator1,
            this.btnExcel,
            this.toolStripSeparator3,
            this.btnListError});
            this.mnuMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuMenu.Size = new System.Drawing.Size(1020, 42);
            this.mnuMenu.TabIndex = 20;
            this.mnuMenu.Text = "toolStrip2";
            // 
            // btnNewGroup
            // 
            this.btnNewGroup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnNewGroup.Image")));
            this.btnNewGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewGroup.Name = "btnNewGroup";
            this.btnNewGroup.Size = new System.Drawing.Size(112, 33);
            this.btnNewGroup.Tag = "ModuleGroup_Add";
            this.btnNewGroup.Text = "&Tạo nhóm module";
            this.btnNewGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNewGroup.Visible = false;
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 23);
            this.toolStripSeparator9.Visible = false;
            // 
            // btnEditGroup
            // 
            this.btnEditGroup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnEditGroup.Image")));
            this.btnEditGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditGroup.Name = "btnEditGroup";
            this.btnEditGroup.Size = new System.Drawing.Size(113, 33);
            this.btnEditGroup.Tag = "ModuleGroup_Edit";
            this.btnEditGroup.Text = "Sửa nhóm module";
            this.btnEditGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEditGroup.Visible = false;
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 23);
            this.toolStripSeparator8.Visible = false;
            // 
            // btnDeleteGroup
            // 
            this.btnDeleteGroup.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteGroup.Image")));
            this.btnDeleteGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteGroup.Name = "btnDeleteGroup";
            this.btnDeleteGroup.Size = new System.Drawing.Size(112, 33);
            this.btnDeleteGroup.Tag = "ModuleGroup_Del";
            this.btnDeleteGroup.Text = "Xóa nhóm module";
            this.btnDeleteGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDeleteGroup.Visible = false;
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 23);
            this.toolStripSeparator7.Visible = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(49, 33);
            this.btnAdd.Tag = "";
            this.btnAdd.Text = "Tạo YC";
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 23);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(50, 33);
            this.btnEdit.Tag = "";
            this.btnEdit.Text = "Sửa YC";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 23);
            // 
            // btnDel
            // 
            this.btnDel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
            this.btnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(49, 33);
            this.btnDel.Tag = "";
            this.btnDel.Text = "Xóa YC";
            this.btnDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AutoSize = false;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 40);
            // 
            // btnImport
            // 
            this.btnImport.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Image = ((System.Drawing.Image)(resources.GetObject("btnImport.Image")));
            this.btnImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(71, 33);
            this.btnImport.Tag = "Module_ImportExcel";
            this.btnImport.Text = "Nhập Excel";
            this.btnImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnImport.Visible = false;
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.AutoSize = false;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 40);
            this.toolStripSeparator5.Visible = false;
            // 
            // btnCopy
            // 
            this.btnCopy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.btnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(39, 33);
            this.btnCopy.Tag = "Module_Add";
            this.btnCopy.Text = "Copy";
            this.btnCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // btnExcel
            // 
            this.btnExcel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(69, 33);
            this.btnExcel.Tag = "Module_ExportExcel";
            this.btnExcel.Text = "Xuất Excel";
            this.btnExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.AutoSize = false;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 40);
            this.toolStripSeparator3.Visible = false;
            // 
            // btnListError
            // 
            this.btnListError.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListError.Image = ((System.Drawing.Image)(resources.GetObject("btnListError.Image")));
            this.btnListError.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnListError.Name = "btnListError";
            this.btnListError.Size = new System.Drawing.Size(85, 33);
            this.btnListError.Tag = "frmErrorManager_ViewError";
            this.btnListError.Text = "Danh sách lỗi";
            this.btnListError.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnListError.Visible = false;
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
            this.colGroup,
            this.colID,
            this.colDes,
            this.colPath,
            this.colNote,
            this.colS,
            this.colUpdatedDate,
            this.colStatus});
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
            this.grvData.OptionsView.ShowAutoFilterRow = true;
            this.grvData.OptionsView.ShowFooter = true;
            this.grvData.OptionsView.ShowGroupPanel = false;
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
            this.colCode.Caption = "Mã YC";
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.OptionsColumn.AllowEdit = false;
            this.colCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            this.colCode.Width = 101;
            // 
            // colGroup
            // 
            this.colGroup.AppearanceCell.Options.UseTextOptions = true;
            this.colGroup.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colGroup.AppearanceHeader.Options.UseTextOptions = true;
            this.colGroup.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colGroup.Caption = "Nhóm";
            this.colGroup.FieldName = "ModuleGroupID";
            this.colGroup.Name = "colGroup";
            // 
            // colID
            // 
            this.colID.AppearanceCell.Options.UseTextOptions = true;
            this.colID.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colID.AppearanceHeader.Options.UseTextOptions = true;
            this.colID.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colDes
            // 
            this.colDes.AppearanceCell.Options.UseTextOptions = true;
            this.colDes.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDes.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colDes.AppearanceHeader.Options.UseFont = true;
            this.colDes.AppearanceHeader.Options.UseTextOptions = true;
            this.colDes.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDes.Caption = "Mô tả";
            this.colDes.FieldName = "Description";
            this.colDes.Name = "colDes";
            this.colDes.OptionsColumn.AllowEdit = false;
            this.colDes.OptionsColumn.AllowFocus = false;
            this.colDes.Width = 141;
            // 
            // colPath
            // 
            this.colPath.AppearanceCell.Options.UseTextOptions = true;
            this.colPath.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPath.AppearanceHeader.Options.UseTextOptions = true;
            this.colPath.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPath.Caption = "Đường dẫn";
            this.colPath.FieldName = "Path";
            this.colPath.Name = "colPath";
            this.colPath.Width = 104;
            // 
            // colNote
            // 
            this.colNote.AppearanceCell.Options.UseTextOptions = true;
            this.colNote.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colNote.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNote.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colNote.AppearanceHeader.Options.UseFont = true;
            this.colNote.AppearanceHeader.Options.UseTextOptions = true;
            this.colNote.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNote.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNote.Caption = "Mô tả";
            this.colNote.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colNote.FieldName = "Note";
            this.colNote.Name = "colNote";
            this.colNote.OptionsColumn.AllowEdit = false;
            this.colNote.OptionsColumn.AllowSize = false;
            this.colNote.Visible = true;
            this.colNote.VisibleIndex = 2;
            this.colNote.Width = 170;
            // 
            // colS
            // 
            this.colS.AppearanceCell.Options.UseTextOptions = true;
            this.colS.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colS.AppearanceHeader.Options.UseTextOptions = true;
            this.colS.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colS.Caption = "Trạng thái";
            this.colS.FieldName = "Status";
            this.colS.Name = "colS";
            // 
            // colUpdatedDate
            // 
            this.colUpdatedDate.AppearanceCell.Options.UseTextOptions = true;
            this.colUpdatedDate.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colUpdatedDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colUpdatedDate.AppearanceHeader.Options.UseFont = true;
            this.colUpdatedDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colUpdatedDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUpdatedDate.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colUpdatedDate.Caption = "Ngày sửa";
            this.colUpdatedDate.FieldName = "UpdatedDate";
            this.colUpdatedDate.Name = "colUpdatedDate";
            // 
            // colStatus
            // 
            this.colStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colStatus.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colStatus.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colStatus.AppearanceHeader.Options.UseFont = true;
            this.colStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.colStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStatus.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colStatus.Caption = "Trạng thái";
            this.colStatus.FieldName = "StatusText";
            this.colStatus.Name = "colStatus";
            this.colStatus.OptionsColumn.AllowEdit = false;
            this.colStatus.OptionsColumn.AllowFocus = false;
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 3;
            this.colStatus.Width = 87;
            // 
            // grdData
            // 
            this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdData.ContextMenuStrip = this.contextMenuStrip1;
            this.grdData.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdData.Location = new System.Drawing.Point(6, 61);
            this.grdData.MainView = this.grvData;
            this.grdData.Name = "grdData";
            this.grdData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemMemoEdit1});
            this.grdData.Size = new System.Drawing.Size(621, 368);
            this.grdData.TabIndex = 16;
            this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvData});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showHistoryToolStripMenuItem,
            this.btnReportMAT,
            this.btnSendModuleContentByMail,
            this.btnShowDMVT,
            this.danhSachNgươiThiêtKêToolStripMenuItem,
            this.xemTaiLiêuThiêtKêToolStripMenuItem,
            this.btnShowFilm,
            this.btnShowTem,
            this.btnUpdateModuleVersion,
            this.btnModulePrice,
            this.danhSáchVersionToolStripMenuItem,
            this.xemDanhSáchDựÁnChứaModuleToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(262, 268);
            // 
            // showHistoryToolStripMenuItem
            // 
            this.showHistoryToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showHistoryToolStripMenuItem.Image")));
            this.showHistoryToolStripMenuItem.Name = "showHistoryToolStripMenuItem";
            this.showHistoryToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.showHistoryToolStripMenuItem.Text = "Tình trạng thay đổi sản phẩm";
            // 
            // btnReportMAT
            // 
            this.btnReportMAT.Name = "btnReportMAT";
            this.btnReportMAT.Size = new System.Drawing.Size(261, 22);
            this.btnReportMAT.Tag = "Module_ViewTLKT";
            this.btnReportMAT.Text = "Tài liệu kiểm tra mặt module";
            // 
            // btnSendModuleContentByMail
            // 
            this.btnSendModuleContentByMail.Name = "btnSendModuleContentByMail";
            this.btnSendModuleContentByMail.Size = new System.Drawing.Size(261, 22);
            this.btnSendModuleContentByMail.Tag = "Module_SendMail";
            this.btnSendModuleContentByMail.Text = "Gửi mail";
            // 
            // btnShowDMVT
            // 
            this.btnShowDMVT.Name = "btnShowDMVT";
            this.btnShowDMVT.Size = new System.Drawing.Size(261, 22);
            this.btnShowDMVT.Tag = "Module_ViewDMVT";
            this.btnShowDMVT.Text = "Xem danh mục vật tư";
            // 
            // danhSachNgươiThiêtKêToolStripMenuItem
            // 
            this.danhSachNgươiThiêtKêToolStripMenuItem.Name = "danhSachNgươiThiêtKêToolStripMenuItem";
            this.danhSachNgươiThiêtKêToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.danhSachNgươiThiêtKêToolStripMenuItem.Text = "Danh sách người thiết kế";
            // 
            // xemTaiLiêuThiêtKêToolStripMenuItem
            // 
            this.xemTaiLiêuThiêtKêToolStripMenuItem.Name = "xemTaiLiêuThiêtKêToolStripMenuItem";
            this.xemTaiLiêuThiêtKêToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.xemTaiLiêuThiêtKêToolStripMenuItem.Tag = "Module_TLTK";
            this.xemTaiLiêuThiêtKêToolStripMenuItem.Text = "Tài liệu thiết kế";
            // 
            // btnShowFilm
            // 
            this.btnShowFilm.Name = "btnShowFilm";
            this.btnShowFilm.Size = new System.Drawing.Size(261, 22);
            this.btnShowFilm.Tag = "Module_Film";
            this.btnShowFilm.Text = "Xem danh sách Film in";
            // 
            // btnShowTem
            // 
            this.btnShowTem.Name = "btnShowTem";
            this.btnShowTem.Size = new System.Drawing.Size(261, 22);
            this.btnShowTem.Tag = "Module_Tem";
            this.btnShowTem.Text = "Xem danh sách Tem";
            // 
            // btnUpdateModuleVersion
            // 
            this.btnUpdateModuleVersion.Name = "btnUpdateModuleVersion";
            this.btnUpdateModuleVersion.Size = new System.Drawing.Size(261, 22);
            this.btnUpdateModuleVersion.Tag = "Module_UpdateVersion";
            this.btnUpdateModuleVersion.Text = "Gửi mail cập nhật thiết kế";
            // 
            // btnModulePrice
            // 
            this.btnModulePrice.Name = "btnModulePrice";
            this.btnModulePrice.Size = new System.Drawing.Size(261, 22);
            this.btnModulePrice.Tag = "frmModuleManager_ModulePrice";
            this.btnModulePrice.Text = "Cập nhật giá";
            // 
            // danhSáchVersionToolStripMenuItem
            // 
            this.danhSáchVersionToolStripMenuItem.Name = "danhSáchVersionToolStripMenuItem";
            this.danhSáchVersionToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.danhSáchVersionToolStripMenuItem.Text = "Danh sách version";
            // 
            // xemDanhSáchDựÁnChứaModuleToolStripMenuItem
            // 
            this.xemDanhSáchDựÁnChứaModuleToolStripMenuItem.Name = "xemDanhSáchDựÁnChứaModuleToolStripMenuItem";
            this.xemDanhSáchDựÁnChứaModuleToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.xemDanhSáchDựÁnChứaModuleToolStripMenuItem.Text = "Xem danh sách dự án chứa module";
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
            // colCodeTree
            // 
            this.colCodeTree.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCodeTree.AppearanceHeader.Options.UseFont = true;
            this.colCodeTree.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodeTree.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodeTree.Caption = "Mã KH";
            this.colCodeTree.FieldName = "Code";
            this.colCodeTree.Name = "colCodeTree";
            this.colCodeTree.OptionsColumn.AllowEdit = false;
            this.colCodeTree.OptionsColumn.AllowFocus = false;
            this.colCodeTree.Visible = true;
            this.colCodeTree.VisibleIndex = 0;
            this.colCodeTree.Width = 105;
            // 
            // repositoryItemMemoEdit2
            // 
            this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
            // 
            // colNameTree
            // 
            this.colNameTree.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colNameTree.AppearanceHeader.Options.UseFont = true;
            this.colNameTree.AppearanceHeader.Options.UseTextOptions = true;
            this.colNameTree.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNameTree.Caption = "Tên KH";
            this.colNameTree.ColumnEdit = this.repositoryItemMemoEdit2;
            this.colNameTree.FieldName = "Name";
            this.colNameTree.Name = "colNameTree";
            this.colNameTree.OptionsColumn.AllowEdit = false;
            this.colNameTree.OptionsColumn.AllowFocus = false;
            this.colNameTree.Visible = true;
            this.colNameTree.VisibleIndex = 1;
            this.colNameTree.Width = 186;
            // 
            // colIDTree
            // 
            this.colIDTree.Caption = "Mã nhóm";
            this.colIDTree.FieldName = "ID";
            this.colIDTree.Name = "colIDTree";
            // 
            // btnFindAll
            // 
            this.btnFindAll.Location = new System.Drawing.Point(539, 12);
            this.btnFindAll.Name = "btnFindAll";
            this.btnFindAll.Size = new System.Drawing.Size(75, 23);
            this.btnFindAll.TabIndex = 21;
            this.btnFindAll.Text = "Tìm kiếm";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(243, 13);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(290, 20);
            this.txtName.TabIndex = 20;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(0, 47);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainer1.Panel1.Controls.Add(this.treeData);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnFindAll);
            this.splitContainer1.Panel2.Controls.Add(this.txtName);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.txtCode);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.labelControl2);
            this.splitContainer1.Panel2.Controls.Add(this.grdData);
            this.splitContainer1.Size = new System.Drawing.Size(1020, 436);
            this.splitContainer1.SplitterDistance = 383;
            this.splitContainer1.TabIndex = 21;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(10, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(108, 13);
            this.labelControl1.TabIndex = 18;
            this.labelControl1.Text = "Danh sách khách hàng";
            // 
            // treeData
            // 
            this.treeData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeData.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.treeData.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.treeData.Appearance.FocusedRow.Options.UseBackColor = true;
            this.treeData.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.treeData.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.treeData.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.treeData.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colIDTree,
            this.colNameTree,
            this.colCodeTree});
            this.treeData.Location = new System.Drawing.Point(8, 23);
            this.treeData.Name = "treeData";
            this.treeData.OptionsBehavior.AllowExpandOnDblClick = false;
            this.treeData.OptionsBehavior.DragNodes = true;
            this.treeData.OptionsBehavior.Editable = false;
            this.treeData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit2});
            this.treeData.Size = new System.Drawing.Size(366, 406);
            this.treeData.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Tên YC:";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(59, 13);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(123, 20);
            this.txtCode.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Mã YC:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(10, 43);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(91, 13);
            this.labelControl2.TabIndex = 18;
            this.labelControl2.Text = "Danh sách yêu cầu";
            // 
            // RequestManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 484);
            this.Controls.Add(this.mnuMenu);
            this.Controls.Add(this.splitContainer1);
            this.Name = "RequestManager";
            this.Text = "DANH SÁCH YÊU CẦU";
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private System.Windows.Forms.ToolStrip mnuMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnCopy;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnDel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnImport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnListError;
        private DevExpress.XtraGrid.Views.Grid.GridView grvData;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colDes;
        private DevExpress.XtraGrid.Columns.GridColumn colPath;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
        private DevExpress.XtraGrid.Columns.GridColumn colS;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.GridControl grdData;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnReportMAT;
        private System.Windows.Forms.ToolStripMenuItem btnSendModuleContentByMail;
        private System.Windows.Forms.ToolStripMenuItem btnShowDMVT;
        private System.Windows.Forms.ToolStripMenuItem danhSachNgươiThiêtKêToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xemTaiLiêuThiêtKêToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnShowFilm;
        private System.Windows.Forms.ToolStripMenuItem btnShowTem;
        private System.Windows.Forms.ToolStripMenuItem btnUpdateModuleVersion;
        private System.Windows.Forms.ToolStripMenuItem btnModulePrice;
        private System.Windows.Forms.ToolStripMenuItem danhSáchVersionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xemDanhSáchDựÁnChứaModuleToolStripMenuItem;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCodeTree;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colNameTree;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIDTree;
        private DevExpress.XtraEditors.SimpleButton btnFindAll;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraTreeList.TreeList treeData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.ToolStripButton btnNewGroup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton btnEditGroup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton btnDeleteGroup;
    }
}