namespace BMS
{
    partial class frmListCumOfModule
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
            DevExpress.XtraTreeList.FilterCondition filterCondition1 = new DevExpress.XtraTreeList.FilterCondition();
            this.colNameHD = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colCodeHD = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.treeData = new DevExpress.XtraTreeList.TreeList();
            this.colCodeTK = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colNameTK = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colPercentVT = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colStatus = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colPercentExport = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colProjectModuleId = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colQty = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDateAboutE = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTotalDateAboutENull = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSTT = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colParentID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeData)).BeginInit();
            this.SuspendLayout();
            // 
            // colNameHD
            // 
            this.colNameHD.AppearanceCell.Options.UseTextOptions = true;
            this.colNameHD.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNameHD.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colNameHD.AppearanceHeader.Options.UseFont = true;
            this.colNameHD.AppearanceHeader.Options.UseTextOptions = true;
            this.colNameHD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNameHD.Caption = "Tên HD";
            this.colNameHD.ColumnEdit = this.repositoryItemMemoEdit2;
            this.colNameHD.FieldName = "PPName";
            this.colNameHD.Name = "colNameHD";
            this.colNameHD.OptionsColumn.AllowEdit = false;
            this.colNameHD.OptionsColumn.AllowSort = false;
            this.colNameHD.Width = 222;
            // 
            // repositoryItemMemoEdit2
            // 
            this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
            // 
            // colCodeHD
            // 
            this.colCodeHD.AppearanceCell.Options.UseTextOptions = true;
            this.colCodeHD.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCodeHD.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCodeHD.AppearanceHeader.Options.UseFont = true;
            this.colCodeHD.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodeHD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodeHD.Caption = "Mã HD";
            this.colCodeHD.ColumnEdit = this.repositoryItemMemoEdit2;
            this.colCodeHD.FieldName = "PPCode";
            this.colCodeHD.Name = "colCodeHD";
            this.colCodeHD.OptionsColumn.AllowEdit = false;
            this.colCodeHD.OptionsColumn.AllowSort = false;
            this.colCodeHD.Width = 201;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(8, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 234;
            this.label4.Visible = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.Lime;
            this.label3.Location = new System.Drawing.Point(481, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 235;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(732, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 236;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(259, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 237;
            this.label1.Visible = false;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(773, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(173, 13);
            this.label8.TabIndex = 230;
            this.label8.Text = "Vât tư về 100%. vật tư xuất < 100%";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(522, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(196, 13);
            this.label7.TabIndex = 231;
            this.label7.Text = "Vât tư đã về 100%. vật tư đã xuất 100%";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(49, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(191, 13);
            this.label9.TabIndex = 232;
            this.label9.Text = "Tồn tại vật tư chưa có ngày về dự kiến";
            this.label9.Visible = false;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(300, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(170, 13);
            this.label10.TabIndex = 233;
            this.label10.Text = "Ngày về dự kiến > Deadline SXLR";
            this.label10.Visible = false;
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
            this.treeData.ColumnPanelRowHeight = 40;
            this.treeData.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colNameHD,
            this.colCodeHD,
            this.colCodeTK,
            this.colNameTK,
            this.colPercentVT,
            this.colStatus,
            this.colPercentExport,
            this.colProjectModuleId,
            this.colQty,
            this.colDateAboutE,
            this.colTotalDateAboutENull,
            this.colSTT,
            this.colID,
            this.colParentID});
            this.treeData.CustomizationFormBounds = new System.Drawing.Rectangle(1080, 502, 216, 323);
            filterCondition1.Column = this.colNameHD;
            filterCondition1.Condition = DevExpress.XtraTreeList.FilterConditionEnum.Contains;
            filterCondition1.Value1 = "<Null>";
            filterCondition1.Value2 = "<Null>";
            filterCondition1.Visible = true;
            this.treeData.FilterConditions.AddRange(new DevExpress.XtraTreeList.FilterCondition[] {
            filterCondition1});
            this.treeData.Location = new System.Drawing.Point(2, 28);
            this.treeData.Name = "treeData";
            this.treeData.OptionsBehavior.Editable = false;
            this.treeData.OptionsBehavior.EnableFiltering = true;
            this.treeData.OptionsPrint.PrintAllNodes = true;
            this.treeData.OptionsSelection.MultiSelect = true;
            this.treeData.OptionsView.AutoWidth = false;
            this.treeData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit2});
            this.treeData.Size = new System.Drawing.Size(957, 642);
            this.treeData.TabIndex = 229;
            this.treeData.CustomDrawNodeCell += new DevExpress.XtraTreeList.CustomDrawNodeCellEventHandler(this.treeData_CustomDrawNodeCell);
            this.treeData.DoubleClick += new System.EventHandler(this.treeData_DoubleClick);
            // 
            // colCodeTK
            // 
            this.colCodeTK.AppearanceCell.Options.UseTextOptions = true;
            this.colCodeTK.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colCodeTK.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCodeTK.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colCodeTK.AppearanceHeader.Options.UseFont = true;
            this.colCodeTK.AppearanceHeader.Options.UseTextOptions = true;
            this.colCodeTK.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCodeTK.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colCodeTK.Caption = "Mã";
            this.colCodeTK.FieldName = "Code";
            this.colCodeTK.Name = "colCodeTK";
            this.colCodeTK.OptionsColumn.AllowEdit = false;
            this.colCodeTK.OptionsColumn.AllowSort = false;
            this.colCodeTK.Visible = true;
            this.colCodeTK.VisibleIndex = 1;
            this.colCodeTK.Width = 199;
            // 
            // colNameTK
            // 
            this.colNameTK.AppearanceCell.Options.UseTextOptions = true;
            this.colNameTK.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colNameTK.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNameTK.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colNameTK.AppearanceHeader.Options.UseFont = true;
            this.colNameTK.AppearanceHeader.Options.UseTextOptions = true;
            this.colNameTK.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNameTK.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colNameTK.Caption = "Tên";
            this.colNameTK.ColumnEdit = this.repositoryItemMemoEdit2;
            this.colNameTK.FieldName = "Name";
            this.colNameTK.Name = "colNameTK";
            this.colNameTK.OptionsColumn.AllowEdit = false;
            this.colNameTK.OptionsColumn.AllowSort = false;
            this.colNameTK.Visible = true;
            this.colNameTK.VisibleIndex = 2;
            this.colNameTK.Width = 337;
            // 
            // colPercentVT
            // 
            this.colPercentVT.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colPercentVT.AppearanceCell.Options.UseFont = true;
            this.colPercentVT.AppearanceCell.Options.UseTextOptions = true;
            this.colPercentVT.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPercentVT.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPercentVT.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colPercentVT.AppearanceHeader.Options.UseFont = true;
            this.colPercentVT.AppearanceHeader.Options.UseTextOptions = true;
            this.colPercentVT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPercentVT.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPercentVT.Caption = "% vật tư về";
            this.colPercentVT.FieldName = "PercentVT";
            this.colPercentVT.Format.FormatString = "n0";
            this.colPercentVT.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPercentVT.Name = "colPercentVT";
            this.colPercentVT.OptionsColumn.AllowEdit = false;
            this.colPercentVT.OptionsColumn.AllowSort = false;
            this.colPercentVT.Visible = true;
            this.colPercentVT.VisibleIndex = 4;
            this.colPercentVT.Width = 51;
            // 
            // colStatus
            // 
            this.colStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colStatus.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colStatus.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colStatus.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colStatus.AppearanceHeader.Options.UseFont = true;
            this.colStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.colStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStatus.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colStatus.Caption = "Trạng thái";
            this.colStatus.FieldName = "StatusText";
            this.colStatus.Name = "colStatus";
            this.colStatus.OptionsColumn.AllowEdit = false;
            this.colStatus.OptionsColumn.AllowSort = false;
            this.colStatus.Width = 119;
            // 
            // colPercentExport
            // 
            this.colPercentExport.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colPercentExport.AppearanceCell.Options.UseFont = true;
            this.colPercentExport.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colPercentExport.AppearanceHeader.Options.UseFont = true;
            this.colPercentExport.AppearanceHeader.Options.UseTextOptions = true;
            this.colPercentExport.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPercentExport.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPercentExport.Caption = "% đã xuất";
            this.colPercentExport.FieldName = "PercentExport";
            this.colPercentExport.Format.FormatString = "n0";
            this.colPercentExport.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPercentExport.Name = "colPercentExport";
            this.colPercentExport.OptionsColumn.AllowEdit = false;
            this.colPercentExport.OptionsColumn.AllowSort = false;
            this.colPercentExport.Visible = true;
            this.colPercentExport.VisibleIndex = 5;
            // 
            // colProjectModuleId
            // 
            this.colProjectModuleId.Caption = "ProjectModuleId";
            this.colProjectModuleId.FieldName = "ProjectModuleId";
            this.colProjectModuleId.Name = "colProjectModuleId";
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
            this.colQty.Caption = "Số lượng";
            this.colQty.FieldName = "QtyReal";
            this.colQty.Name = "colQty";
            this.colQty.Visible = true;
            this.colQty.VisibleIndex = 3;
            // 
            // colDateAboutE
            // 
            this.colDateAboutE.AppearanceCell.Options.UseTextOptions = true;
            this.colDateAboutE.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDateAboutE.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colDateAboutE.AppearanceHeader.Options.UseFont = true;
            this.colDateAboutE.AppearanceHeader.Options.UseTextOptions = true;
            this.colDateAboutE.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDateAboutE.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDateAboutE.Caption = "Ngày về DK";
            this.colDateAboutE.FieldName = "DateAboutE";
            this.colDateAboutE.Format.FormatString = "dd/MM/yyyy";
            this.colDateAboutE.Format.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDateAboutE.Name = "colDateAboutE";
            this.colDateAboutE.OptionsColumn.AllowEdit = false;
            this.colDateAboutE.Width = 91;
            // 
            // colTotalDateAboutENull
            // 
            this.colTotalDateAboutENull.Caption = "TotalDateAboutENull";
            this.colTotalDateAboutENull.FieldName = "TotalDateAboutENull";
            this.colTotalDateAboutENull.Format.FormatString = "n0";
            this.colTotalDateAboutENull.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalDateAboutENull.Name = "colTotalDateAboutENull";
            // 
            // colSTT
            // 
            this.colSTT.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colSTT.AppearanceHeader.Options.UseFont = true;
            this.colSTT.AppearanceHeader.Options.UseTextOptions = true;
            this.colSTT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSTT.Caption = "STT";
            this.colSTT.FieldName = "STT";
            this.colSTT.Name = "colSTT";
            this.colSTT.Visible = true;
            this.colSTT.VisibleIndex = 0;
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colParentID
            // 
            this.colParentID.Caption = "ParentID";
            this.colParentID.FieldName = "ParentID";
            this.colParentID.Name = "colParentID";
            // 
            // frmListCumOfModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 673);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.treeData);
            this.Name = "frmListCumOfModule";
            this.Text = "Danh sách Cụm";
            this.Load += new System.EventHandler(this.frmListCumOfModule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraTreeList.TreeList treeData;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colNameHD;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCodeHD;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCodeTK;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colNameTK;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colPercentVT;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colStatus;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colPercentExport;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colProjectModuleId;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colQty;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDateAboutE;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTotalDateAboutENull;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSTT;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colParentID;
    }
}