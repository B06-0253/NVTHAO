namespace BMS
{
    partial class frmSendMailTHTK
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSendMailTHTK));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtDMVTPath = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.grvModule = new System.Windows.Forms.DataGridView();
            this.cboProject = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProjectID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProjectCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDateEnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYear = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.grvProject = new System.Windows.Forms.DataGridView();
            this.colPCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mnuMenu = new System.Windows.Forms.ToolStrip();
            this.btnSend = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteProject = new System.Windows.Forms.Button();
            this.btnAddProject = new System.Windows.Forms.Button();
            this.colCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colModuleCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModuleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModuleStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grvModule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProject)).BeginInit();
            this.mnuMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(620, 46);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(24, 23);
            this.btnBrowse.TabIndex = 36;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtDMVTPath
            // 
            this.txtDMVTPath.Enabled = false;
            this.txtDMVTPath.Location = new System.Drawing.Point(72, 48);
            this.txtDMVTPath.Name = "txtDMVTPath";
            this.txtDMVTPath.Size = new System.Drawing.Size(547, 20);
            this.txtDMVTPath.TabIndex = 35;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(8, 50);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(60, 13);
            this.Label6.TabIndex = 34;
            this.Label6.Text = "Đường dẫn";
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(14, 74);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(81, 17);
            this.chkSelectAll.TabIndex = 38;
            this.chkSelectAll.Text = "Chọn tất cả";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // grvModule
            // 
            this.grvModule.AllowUserToAddRows = false;
            this.grvModule.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvModule.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grvModule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grvModule.BackgroundColor = System.Drawing.Color.White;
            this.grvModule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvModule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheck,
            this.colModuleCode,
            this.colModuleName,
            this.colModuleStatus});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvModule.DefaultCellStyle = dataGridViewCellStyle3;
            this.grvModule.Location = new System.Drawing.Point(5, 97);
            this.grvModule.Name = "grvModule";
            this.grvModule.RowHeadersVisible = false;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvModule.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grvModule.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvModule.Size = new System.Drawing.Size(491, 372);
            this.grvModule.TabIndex = 37;
            // 
            // cboProject
            // 
            this.cboProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboProject.Location = new System.Drawing.Point(427, 74);
            this.cboProject.Name = "cboProject";
            this.cboProject.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProject.Properties.NullText = "";
            this.cboProject.Properties.View = this.gridView4;
            this.cboProject.Size = new System.Drawing.Size(181, 20);
            this.cboProject.TabIndex = 180;
            this.cboProject.Visible = false;
            // 
            // gridView4
            // 
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProjectID,
            this.colProjectCode,
            this.colProjectName,
            this.colDateEnd,
            this.colYear});
            this.gridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView4.GroupCount = 1;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView4.OptionsView.ShowGroupedColumns = true;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            this.gridView4.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
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
            this.colProjectCode.Caption = "Mã";
            this.colProjectCode.FieldName = "ProjectCode";
            this.colProjectCode.Name = "colProjectCode";
            this.colProjectCode.Visible = true;
            this.colProjectCode.VisibleIndex = 0;
            // 
            // colProjectName
            // 
            this.colProjectName.Caption = "Tên";
            this.colProjectName.FieldName = "ProjectName";
            this.colProjectName.Name = "colProjectName";
            this.colProjectName.Visible = true;
            this.colProjectName.VisibleIndex = 1;
            // 
            // colDateEnd
            // 
            this.colDateEnd.Caption = "Ngày kết thúc";
            this.colDateEnd.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colDateEnd.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDateEnd.FieldName = "DateFinishE";
            this.colDateEnd.Name = "colDateEnd";
            // 
            // colYear
            // 
            this.colYear.Caption = "Năm";
            this.colYear.FieldName = "Year";
            this.colYear.Name = "colYear";
            this.colYear.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(382, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 179;
            this.label1.Text = "Dự án";
            this.label1.Visible = false;
            // 
            // grvProject
            // 
            this.grvProject.AllowUserToAddRows = false;
            this.grvProject.AllowUserToDeleteRows = false;
            this.grvProject.AllowUserToResizeRows = false;
            this.grvProject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grvProject.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grvProject.BackgroundColor = System.Drawing.Color.White;
            this.grvProject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvProject.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPCode,
            this.colPName});
            this.grvProject.Location = new System.Drawing.Point(502, 97);
            this.grvProject.Name = "grvProject";
            this.grvProject.ReadOnly = true;
            this.grvProject.RowHeadersVisible = false;
            this.grvProject.Size = new System.Drawing.Size(197, 372);
            this.grvProject.TabIndex = 37;
            // 
            // colPCode
            // 
            this.colPCode.DataPropertyName = "ProjectCode";
            this.colPCode.FillWeight = 59.39036F;
            this.colPCode.HeaderText = "Mã dự án";
            this.colPCode.Name = "colPCode";
            this.colPCode.ReadOnly = true;
            // 
            // colPName
            // 
            this.colPName.DataPropertyName = "ProjectName";
            this.colPName.FillWeight = 174.6077F;
            this.colPName.HeaderText = "Tên dự án";
            this.colPName.Name = "colPName";
            this.colPName.ReadOnly = true;
            this.colPName.Visible = false;
            // 
            // mnuMenu
            // 
            this.mnuMenu.AutoSize = false;
            this.mnuMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.mnuMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSend});
            this.mnuMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mnuMenu.Size = new System.Drawing.Size(702, 42);
            this.mnuMenu.TabIndex = 181;
            this.mnuMenu.Text = "toolStrip2";
            // 
            // btnSend
            // 
            this.btnSend.AutoSize = false;
            this.btnSend.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSend.Image = ((System.Drawing.Image)(resources.GetObject("btnSend.Image")));
            this.btnSend.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(55, 40);
            this.btnSend.Text = "Gửi";
            this.btnSend.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSend.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnDeleteProject
            // 
            this.btnDeleteProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteProject.Location = new System.Drawing.Point(655, 74);
            this.btnDeleteProject.Name = "btnDeleteProject";
            this.btnDeleteProject.Size = new System.Drawing.Size(43, 23);
            this.btnDeleteProject.TabIndex = 183;
            this.btnDeleteProject.Text = "Xóa";
            this.btnDeleteProject.UseVisualStyleBackColor = true;
            this.btnDeleteProject.Visible = false;
            this.btnDeleteProject.Click += new System.EventHandler(this.btnDeleteProject_Click);
            // 
            // btnAddProject
            // 
            this.btnAddProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddProject.Location = new System.Drawing.Point(611, 74);
            this.btnAddProject.Name = "btnAddProject";
            this.btnAddProject.Size = new System.Drawing.Size(43, 23);
            this.btnAddProject.TabIndex = 182;
            this.btnAddProject.Text = "Thêm";
            this.btnAddProject.UseVisualStyleBackColor = true;
            this.btnAddProject.Visible = false;
            this.btnAddProject.Click += new System.EventHandler(this.btnAddProject_Click);
            // 
            // colCheck
            // 
            this.colCheck.DataPropertyName = "check";
            this.colCheck.FillWeight = 26.94745F;
            this.colCheck.HeaderText = "";
            this.colCheck.Name = "colCheck";
            this.colCheck.Width = 28;
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
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colModuleName.DefaultCellStyle = dataGridViewCellStyle2;
            this.colModuleName.FillWeight = 151.8879F;
            this.colModuleName.HeaderText = "Tên module";
            this.colModuleName.Name = "colModuleName";
            this.colModuleName.Width = 280;
            // 
            // colModuleStatus
            // 
            this.colModuleStatus.DataPropertyName = "F10";
            this.colModuleStatus.HeaderText = "Trạng thái";
            this.colModuleStatus.Name = "colModuleStatus";
            this.colModuleStatus.Width = 102;
            // 
            // frmSendMailTHTK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 471);
            this.Controls.Add(this.btnDeleteProject);
            this.Controls.Add(this.btnAddProject);
            this.Controls.Add(this.mnuMenu);
            this.Controls.Add(this.cboProject);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.grvProject);
            this.Controls.Add(this.grvModule);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtDMVTPath);
            this.Controls.Add(this.Label6);
            this.Name = "frmSendMailTHTK";
            this.Text = "Gửi mail tổng hợp thiết kế";
            this.Load += new System.EventHandler(this.frmSendMailTHTK_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grvModule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProject)).EndInit();
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse;
        internal System.Windows.Forms.TextBox txtDMVTPath;
        internal System.Windows.Forms.Label Label6;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.DataGridView grvModule;
        private DevExpress.XtraEditors.SearchLookUpEdit cboProject;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectID;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectCode;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectName;
        private DevExpress.XtraGrid.Columns.GridColumn colDateEnd;
        private DevExpress.XtraGrid.Columns.GridColumn colYear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grvProject;
        private System.Windows.Forms.ToolStrip mnuMenu;
        private System.Windows.Forms.ToolStripButton btnSend;
        private System.Windows.Forms.Button btnDeleteProject;
        private System.Windows.Forms.Button btnAddProject;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModuleCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModuleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModuleStatus;
    }
}