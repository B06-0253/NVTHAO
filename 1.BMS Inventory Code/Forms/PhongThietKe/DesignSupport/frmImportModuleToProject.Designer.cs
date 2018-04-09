namespace BMS
{
    partial class frmImportModuleToProject
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.treeData = new DevExpress.XtraTreeList.TreeList();
            this.colIDTree = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colNameTree = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colCodeTree = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.cboProject = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.grvProject = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProjectID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProjectCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.grvModule = new System.Windows.Forms.DataGridView();
            this.colModuleCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModuleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModuleCodeHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnReloadData = new System.Windows.Forms.Button();
            this.btnAddModule = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.treeData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvModule)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeData
            // 
            this.treeData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeData.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.treeData.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.treeData.Appearance.FocusedRow.Options.UseBackColor = true;
            this.treeData.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.treeData.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.treeData.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.treeData.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.treeData.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.treeData.Appearance.SelectedRow.Options.UseBackColor = true;
            this.treeData.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colIDTree,
            this.colNameTree,
            this.colCodeTree});
            this.treeData.Location = new System.Drawing.Point(8, 36);
            this.treeData.Name = "treeData";
            this.treeData.OptionsBehavior.AllowExpandOnDblClick = false;
            this.treeData.OptionsBehavior.DragNodes = true;
            this.treeData.OptionsBehavior.Editable = false;
            this.treeData.OptionsSelection.MultiSelect = true;
            this.treeData.ParentFieldName = "ManageId";
            this.treeData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit2});
            this.treeData.Size = new System.Drawing.Size(526, 416);
            this.treeData.TabIndex = 19;
            // 
            // colIDTree
            // 
            this.colIDTree.Caption = "Mã nhóm";
            this.colIDTree.FieldName = "PProductId";
            this.colIDTree.Name = "colIDTree";
            // 
            // colNameTree
            // 
            this.colNameTree.AppearanceCell.Options.UseTextOptions = true;
            this.colNameTree.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNameTree.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colNameTree.AppearanceHeader.Options.UseFont = true;
            this.colNameTree.AppearanceHeader.Options.UseTextOptions = true;
            this.colNameTree.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNameTree.Caption = "Tên nhóm";
            this.colNameTree.ColumnEdit = this.repositoryItemMemoEdit2;
            this.colNameTree.FieldName = "TenThietBi";
            this.colNameTree.Name = "colNameTree";
            this.colNameTree.OptionsColumn.AllowEdit = false;
            this.colNameTree.OptionsColumn.AllowFocus = false;
            this.colNameTree.Visible = true;
            this.colNameTree.VisibleIndex = 1;
            this.colNameTree.Width = 307;
            // 
            // repositoryItemMemoEdit2
            // 
            this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
            // 
            // colCodeTree
            // 
            this.colCodeTree.AppearanceCell.Options.UseTextOptions = true;
            this.colCodeTree.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCodeTree.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCodeTree.AppearanceHeader.Options.UseFont = true;
            this.colCodeTree.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodeTree.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodeTree.Caption = "Mã nhóm";
            this.colCodeTree.ColumnEdit = this.repositoryItemMemoEdit2;
            this.colCodeTree.FieldName = "MaThietBi";
            this.colCodeTree.Name = "colCodeTree";
            this.colCodeTree.OptionsColumn.AllowEdit = false;
            this.colCodeTree.OptionsColumn.AllowFocus = false;
            this.colCodeTree.Visible = true;
            this.colCodeTree.VisibleIndex = 0;
            this.colCodeTree.Width = 193;
            // 
            // cboProject
            // 
            this.cboProject.Location = new System.Drawing.Point(47, 8);
            this.cboProject.Name = "cboProject";
            this.cboProject.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProject.Properties.NullText = "";
            this.cboProject.Properties.View = this.grvProject;
            this.cboProject.Size = new System.Drawing.Size(467, 20);
            this.cboProject.TabIndex = 21;
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
            this.label6.Location = new System.Drawing.Point(7, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Dự án";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(441, 8);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(144, 23);
            this.btnBrowse.TabIndex = 39;
            this.btnBrowse.Text = "Chọn đường dẫn file THTK";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // grvModule
            // 
            this.grvModule.AllowUserToAddRows = false;
            this.grvModule.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvModule.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.grvModule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grvModule.BackgroundColor = System.Drawing.Color.White;
            this.grvModule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvModule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colModuleCode,
            this.colModuleName,
            this.colModuleCodeHD,
            this.colQty,
            this.colID,
            this.colParentID});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvModule.DefaultCellStyle = dataGridViewCellStyle7;
            this.grvModule.Location = new System.Drawing.Point(8, 36);
            this.grvModule.MultiSelect = false;
            this.grvModule.Name = "grvModule";
            this.grvModule.RowHeadersVisible = false;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvModule.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.grvModule.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvModule.RowTemplate.Height = 30;
            this.grvModule.Size = new System.Drawing.Size(577, 416);
            this.grvModule.TabIndex = 40;
            this.grvModule.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvModule_KeyDown);
            // 
            // colModuleCode
            // 
            this.colModuleCode.DataPropertyName = "F5";
            this.colModuleCode.FillWeight = 78.32205F;
            this.colModuleCode.HeaderText = "Mã module";
            this.colModuleCode.Name = "colModuleCode";
            this.colModuleCode.ReadOnly = true;
            this.colModuleCode.Width = 80;
            // 
            // colModuleName
            // 
            this.colModuleName.DataPropertyName = "F3";
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colModuleName.DefaultCellStyle = dataGridViewCellStyle6;
            this.colModuleName.FillWeight = 151.8879F;
            this.colModuleName.HeaderText = "Tên module";
            this.colModuleName.Name = "colModuleName";
            this.colModuleName.Width = 156;
            // 
            // colModuleCodeHD
            // 
            this.colModuleCodeHD.DataPropertyName = "F4";
            this.colModuleCodeHD.HeaderText = "Mã module HĐ";
            this.colModuleCodeHD.Name = "colModuleCodeHD";
            // 
            // colQty
            // 
            this.colQty.DataPropertyName = "F7";
            this.colQty.HeaderText = "SL";
            this.colQty.Name = "colQty";
            // 
            // colID
            // 
            this.colID.DataPropertyName = "ID";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.Width = 50;
            // 
            // colParentID
            // 
            this.colParentID.DataPropertyName = "ParentID";
            this.colParentID.HeaderText = "ParentID";
            this.colParentID.Name = "colParentID";
            this.colParentID.Width = 50;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(2, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnReloadData);
            this.splitContainer1.Panel1.Controls.Add(this.treeData);
            this.splitContainer1.Panel1.Controls.Add(this.cboProject);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnAddModule);
            this.splitContainer1.Panel2.Controls.Add(this.grvModule);
            this.splitContainer1.Panel2.Controls.Add(this.btnBrowse);
            this.splitContainer1.Size = new System.Drawing.Size(1139, 455);
            this.splitContainer1.SplitterDistance = 542;
            this.splitContainer1.TabIndex = 41;
            // 
            // btnReloadData
            // 
            this.btnReloadData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReloadData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReloadData.Location = new System.Drawing.Point(613, 6);
            this.btnReloadData.Name = "btnReloadData";
            this.btnReloadData.Size = new System.Drawing.Size(75, 23);
            this.btnReloadData.TabIndex = 22;
            this.btnReloadData.Text = "Tải lại";
            this.btnReloadData.UseVisualStyleBackColor = true;
            this.btnReloadData.Click += new System.EventHandler(this.btnReloadData_Click);
            // 
            // btnAddModule
            // 
            this.btnAddModule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddModule.Location = new System.Drawing.Point(8, 8);
            this.btnAddModule.Name = "btnAddModule";
            this.btnAddModule.Size = new System.Drawing.Size(113, 23);
            this.btnAddModule.TabIndex = 41;
            this.btnAddModule.Tag = "frmImportModuleToProject_AddModuleToProject";
            this.btnAddModule.Text = "Thêm vào dự án";
            this.btnAddModule.UseVisualStyleBackColor = true;
            this.btnAddModule.Click += new System.EventHandler(this.btnAddModule_Click);
            // 
            // frmImportModuleToProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 460);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmImportModuleToProject";
            this.Text = "NHẬP MODULE VÀO DỰ ÁN DỰA VÀO TỔNG HỢP THIẾT KẾ";
            this.Load += new System.EventHandler(this.frmImportModuleToProject_Load);
            ((System.ComponentModel.ISupportInitialize)(this.treeData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvModule)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeData;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIDTree;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colNameTree;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCodeTree;
        private DevExpress.XtraEditors.SearchLookUpEdit cboProject;
        private DevExpress.XtraGrid.Views.Grid.GridView grvProject;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectID;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectCode;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectName;
        private DevExpress.XtraGrid.Columns.GridColumn colYear;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.DataGridView grvModule;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnAddModule;
        private System.Windows.Forms.Button btnReloadData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModuleCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModuleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModuleCodeHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParentID;
    }
}