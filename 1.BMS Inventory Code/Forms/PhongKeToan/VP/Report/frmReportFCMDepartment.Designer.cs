namespace BMS
{
    partial class frmReportFCMDepartment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportFCMDepartment));
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.btnLoadData = new DevExpress.XtraEditors.SimpleButton();
            this.cboPhongBan = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.grvCboProject = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPhanXuongCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhanXuongName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label20 = new System.Windows.Forms.Label();
            this.colProjectName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnExecl = new DevExpress.XtraEditors.SimpleButton();
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.grvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPhongBan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCboProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Appearance.Options.UseTextOptions = true;
            this.repositoryItemMemoEdit1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(359, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 236;
            this.label7.Text = "Năm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(501, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 237;
            this.label2.Text = "Tháng";
            // 
            // cboYear
            // 
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(392, 10);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(99, 21);
            this.cboYear.TabIndex = 234;
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
            this.cboMonth.Location = new System.Drawing.Point(542, 9);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(99, 21);
            this.cboMonth.TabIndex = 235;
            // 
            // btnLoadData
            // 
            this.btnLoadData.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnLoadData.Appearance.Options.UseFont = true;
            this.btnLoadData.Location = new System.Drawing.Point(652, 8);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(75, 23);
            this.btnLoadData.TabIndex = 233;
            this.btnLoadData.Text = "Tải dữ liệu";
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // cboPhongBan
            // 
            this.cboPhongBan.Location = new System.Drawing.Point(66, 11);
            this.cboPhongBan.Name = "cboPhongBan";
            this.cboPhongBan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPhongBan.Properties.NullText = "";
            this.cboPhongBan.Properties.View = this.grvCboProject;
            this.cboPhongBan.Size = new System.Drawing.Size(287, 20);
            this.cboPhongBan.TabIndex = 239;
            // 
            // grvCboProject
            // 
            this.grvCboProject.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPhanXuongCode,
            this.colPhanXuongName});
            this.grvCboProject.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboProject.Name = "grvCboProject";
            this.grvCboProject.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboProject.OptionsView.ShowGroupPanel = false;
            // 
            // colPhanXuongCode
            // 
            this.colPhanXuongCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colPhanXuongCode.AppearanceHeader.Options.UseFont = true;
            this.colPhanXuongCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colPhanXuongCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPhanXuongCode.Caption = "Mã";
            this.colPhanXuongCode.FieldName = "C_MA";
            this.colPhanXuongCode.Name = "colPhanXuongCode";
            this.colPhanXuongCode.OptionsColumn.AllowSize = false;
            this.colPhanXuongCode.Visible = true;
            this.colPhanXuongCode.VisibleIndex = 0;
            this.colPhanXuongCode.Width = 90;
            // 
            // colPhanXuongName
            // 
            this.colPhanXuongName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colPhanXuongName.AppearanceHeader.Options.UseFont = true;
            this.colPhanXuongName.AppearanceHeader.Options.UseTextOptions = true;
            this.colPhanXuongName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPhanXuongName.Caption = "Tên";
            this.colPhanXuongName.FieldName = "C_MOTA";
            this.colPhanXuongName.Name = "colPhanXuongName";
            this.colPhanXuongName.Visible = true;
            this.colPhanXuongName.VisibleIndex = 1;
            this.colPhanXuongName.Width = 294;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(4, 14);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(59, 13);
            this.label20.TabIndex = 238;
            this.label20.Text = "Phòng ban";
            // 
            // colProjectName
            // 
            this.colProjectName.AppearanceCell.Options.UseTextOptions = true;
            this.colProjectName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colProjectName.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colProjectName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colProjectName.AppearanceHeader.Options.UseFont = true;
            this.colProjectName.AppearanceHeader.Options.UseTextOptions = true;
            this.colProjectName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProjectName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colProjectName.Caption = "Tên dự án";
            this.colProjectName.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colProjectName.FieldName = "C_TEN";
            this.colProjectName.Name = "colProjectName";
            this.colProjectName.OptionsColumn.AllowEdit = false;
            this.colProjectName.Visible = true;
            this.colProjectName.VisibleIndex = 1;
            this.colProjectName.Width = 345;
            // 
            // btnExecl
            // 
            this.btnExecl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecl.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnExecl.Appearance.Options.UseFont = true;
            this.btnExecl.Image = ((System.Drawing.Image)(resources.GetObject("btnExecl.Image")));
            this.btnExecl.Location = new System.Drawing.Point(1080, 2);
            this.btnExecl.Name = "btnExecl";
            this.btnExecl.Size = new System.Drawing.Size(104, 30);
            this.btnExecl.TabIndex = 241;
            this.btnExecl.Text = "Xuất excel";
            this.btnExecl.Click += new System.EventHandler(this.btnExecl_Click);
            // 
            // grdData
            // 
            this.grdData.AllowDrop = true;
            this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdData.Location = new System.Drawing.Point(3, 36);
            this.grdData.MainView = this.grvData;
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(1181, 733);
            this.grdData.TabIndex = 242;
            this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvData,
            this.gridView2});
            // 
            // grvData
            // 
            this.grvData.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.grvData.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grvData.GridControl = this.grdData;
            this.grvData.Name = "grvData";
            this.grvData.OptionsBehavior.AutoPopulateColumns = false;
            this.grvData.OptionsBehavior.Editable = false;
            this.grvData.OptionsView.ColumnAutoWidth = false;
            this.grvData.OptionsView.ShowGroupPanel = false;
            this.grvData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvData_KeyDown);
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.grdData;
            this.gridView2.Name = "gridView2";
            // 
            // frmReportFCMDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 769);
            this.Controls.Add(this.grdData);
            this.Controls.Add(this.btnExecl);
            this.Controls.Add(this.cboPhongBan);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboYear);
            this.Controls.Add(this.cboMonth);
            this.Controls.Add(this.btnLoadData);
            this.Name = "frmReportFCMDepartment";
            this.Text = "CHI TIẾT DOANH THU PHÒNG BAN THEO THÁNG, FCM";
            this.Load += new System.EventHandler(this.frmReportFCMDepartment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPhongBan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCboProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.ComboBox cboMonth;
        private DevExpress.XtraEditors.SimpleButton btnLoadData;
        private DevExpress.XtraEditors.SearchLookUpEdit cboPhongBan;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCboProject;
        private DevExpress.XtraGrid.Columns.GridColumn colPhanXuongCode;
        private DevExpress.XtraGrid.Columns.GridColumn colPhanXuongName;
        private System.Windows.Forms.Label label20;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectName;
        private DevExpress.XtraEditors.SimpleButton btnExecl;
        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.Grid.GridView grvData;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
    }
}