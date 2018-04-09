namespace BMS
{
    partial class frmReport_NKCV_ForDate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReport_NKCV_ForDate));
            this.cboDepartment = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.grvCboDepartment = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCboDepartmentId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCboDepartmentCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCboDepartmentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEndDate = new DevExpress.XtraEditors.DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStartDate = new DevExpress.XtraEditors.DateEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.btnXemTatCa = new DevExpress.XtraEditors.SimpleButton();
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.grvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProjectCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInFilm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colUpdatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWorkingDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatusText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStartTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsApproved = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEndTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWorkingContent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWorkTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserId1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAccount1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.btnExecl = new DevExpress.XtraEditors.SimpleButton();
            this.txtTotalTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartment.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCboDepartment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEndDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStartDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // cboDepartment
            // 
            this.cboDepartment.Location = new System.Drawing.Point(688, 14);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDepartment.Properties.NullText = "";
            this.cboDepartment.Properties.View = this.grvCboDepartment;
            this.cboDepartment.Size = new System.Drawing.Size(278, 20);
            this.cboDepartment.TabIndex = 226;
            // 
            // grvCboDepartment
            // 
            this.grvCboDepartment.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCboDepartmentId,
            this.colCboDepartmentCode,
            this.colCboDepartmentName});
            this.grvCboDepartment.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboDepartment.Name = "grvCboDepartment";
            this.grvCboDepartment.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboDepartment.OptionsView.ShowGroupPanel = false;
            // 
            // colCboDepartmentId
            // 
            this.colCboDepartmentId.Caption = "DepartmentId";
            this.colCboDepartmentId.FieldName = "DepartmentId1";
            this.colCboDepartmentId.Name = "colCboDepartmentId";
            // 
            // colCboDepartmentCode
            // 
            this.colCboDepartmentCode.Caption = "Mã";
            this.colCboDepartmentCode.FieldName = "DCode";
            this.colCboDepartmentCode.Name = "colCboDepartmentCode";
            this.colCboDepartmentCode.Visible = true;
            this.colCboDepartmentCode.VisibleIndex = 0;
            // 
            // colCboDepartmentName
            // 
            this.colCboDepartmentName.Caption = "Tên";
            this.colCboDepartmentName.FieldName = "DName";
            this.colCboDepartmentName.Name = "colCboDepartmentName";
            this.colCboDepartmentName.Visible = true;
            this.colCboDepartmentName.VisibleIndex = 1;
            this.colCboDepartmentName.Width = 309;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(644, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 225;
            this.label2.Text = "Phòng";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.EditValue = null;
            this.dtpEndDate.Location = new System.Drawing.Point(312, 12);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtpEndDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpEndDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtpEndDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpEndDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtpEndDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtpEndDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtpEndDate.Size = new System.Drawing.Size(137, 20);
            this.dtpEndDate.TabIndex = 223;
            this.dtpEndDate.EditValueChanged += new System.EventHandler(this.dtpEndDate_EditValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(235, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 221;
            this.label1.Text = "Ngày kết thúc";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.EditValue = null;
            this.dtpStartDate.Location = new System.Drawing.Point(87, 12);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtpStartDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpStartDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtpStartDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpStartDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtpStartDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtpStartDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtpStartDate.Size = new System.Drawing.Size(137, 20);
            this.dtpStartDate.TabIndex = 224;
            this.dtpStartDate.EditValueChanged += new System.EventHandler(this.dtpStartDate_EditValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(12, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 222;
            this.label3.Text = "Ngày bắt đầu";
            // 
            // btnXemTatCa
            // 
            this.btnXemTatCa.Location = new System.Drawing.Point(977, 11);
            this.btnXemTatCa.Name = "btnXemTatCa";
            this.btnXemTatCa.Size = new System.Drawing.Size(75, 23);
            this.btnXemTatCa.TabIndex = 219;
            this.btnXemTatCa.Text = "Xem dữ liệu";
            this.btnXemTatCa.Click += new System.EventHandler(this.btnXemTatCa_Click);
            // 
            // grdData
            // 
            this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdData.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdData.Location = new System.Drawing.Point(2, 52);
            this.grdData.MainView = this.grvData;
            this.grdData.Name = "grdData";
            this.grdData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemMemoEdit1,
            this.repositoryItemCheckEdit2});
            this.grdData.Size = new System.Drawing.Size(1189, 661);
            this.grdData.TabIndex = 217;
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
            this.colName,
            this.colCode,
            this.colGroup,
            this.colID,
            this.colDes,
            this.colDName,
            this.colProjectCode,
            this.colStatus,
            this.colInFilm,
            this.colUpdatedDate,
            this.colPrice,
            this.colOrderTime,
            this.colWorkingDate,
            this.colStatusText,
            this.colStartTime,
            this.colTem,
            this.colTK,
            this.colIsApproved,
            this.colEndTime,
            this.colWorkingContent,
            this.colWorkTime,
            this.colUserId1,
            this.colAccount1});
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
            this.grvData.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grvData_RowCellStyle);
            this.grvData.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvData_KeyDown);
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
            this.colName.Caption = "Tên nhân viên";
            this.colName.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colName.FieldName = "UserName";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.OptionsColumn.AllowSize = false;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 275;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Appearance.Options.UseTextOptions = true;
            this.repositoryItemMemoEdit1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
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
            this.colCode.Caption = "Mã nhân viên";
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.OptionsColumn.AllowEdit = false;
            this.colCode.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            this.colCode.Width = 125;
            // 
            // colGroup
            // 
            this.colGroup.AppearanceCell.Options.UseTextOptions = true;
            this.colGroup.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colGroup.AppearanceHeader.Options.UseTextOptions = true;
            this.colGroup.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colGroup.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colGroup.Caption = "Nhóm";
            this.colGroup.FieldName = "ModuleGroupID";
            this.colGroup.Name = "colGroup";
            this.colGroup.OptionsColumn.AllowEdit = false;
            // 
            // colID
            // 
            this.colID.AppearanceCell.Options.UseTextOptions = true;
            this.colID.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colID.AppearanceHeader.Options.UseTextOptions = true;
            this.colID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colID.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.AllowEdit = false;
            // 
            // colDes
            // 
            this.colDes.AppearanceCell.Options.UseTextOptions = true;
            this.colDes.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDes.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colDes.AppearanceHeader.Options.UseFont = true;
            this.colDes.AppearanceHeader.Options.UseTextOptions = true;
            this.colDes.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDes.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDes.Caption = "Mô tả";
            this.colDes.FieldName = "Description";
            this.colDes.Name = "colDes";
            this.colDes.OptionsColumn.AllowEdit = false;
            this.colDes.Width = 141;
            // 
            // colDName
            // 
            this.colDName.AppearanceCell.Options.UseTextOptions = true;
            this.colDName.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colDName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colDName.AppearanceHeader.Options.UseFont = true;
            this.colDName.AppearanceHeader.Options.UseTextOptions = true;
            this.colDName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDName.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colDName.Caption = "Phòng ban";
            this.colDName.FieldName = "DName1";
            this.colDName.Name = "colDName";
            this.colDName.OptionsColumn.AllowEdit = false;
            this.colDName.Visible = true;
            this.colDName.VisibleIndex = 3;
            this.colDName.Width = 372;
            // 
            // colProjectCode
            // 
            this.colProjectCode.AppearanceCell.Options.UseTextOptions = true;
            this.colProjectCode.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colProjectCode.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colProjectCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colProjectCode.AppearanceHeader.Options.UseFont = true;
            this.colProjectCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colProjectCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProjectCode.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colProjectCode.Caption = "Dự án";
            this.colProjectCode.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colProjectCode.FieldName = "ProjectCode";
            this.colProjectCode.Name = "colProjectCode";
            this.colProjectCode.OptionsColumn.AllowEdit = false;
            this.colProjectCode.OptionsColumn.AllowSize = false;
            this.colProjectCode.Width = 113;
            // 
            // colStatus
            // 
            this.colStatus.AppearanceCell.Options.UseTextOptions = true;
            this.colStatus.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colStatus.AppearanceHeader.Options.UseTextOptions = true;
            this.colStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStatus.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colStatus.Caption = "Trạng thái";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.OptionsColumn.AllowEdit = false;
            // 
            // colInFilm
            // 
            this.colInFilm.AppearanceCell.Options.UseTextOptions = true;
            this.colInFilm.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colInFilm.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colInFilm.AppearanceHeader.Options.UseFont = true;
            this.colInFilm.AppearanceHeader.Options.UseTextOptions = true;
            this.colInFilm.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colInFilm.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colInFilm.Caption = "Film in";
            this.colInFilm.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colInFilm.FieldName = "HasFilm";
            this.colInFilm.Name = "colInFilm";
            this.colInFilm.OptionsColumn.AllowEdit = false;
            this.colInFilm.OptionsColumn.AllowSize = false;
            this.colInFilm.Width = 31;
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
            this.colUpdatedDate.OptionsColumn.AllowEdit = false;
            // 
            // colPrice
            // 
            this.colPrice.AppearanceCell.Options.UseTextOptions = true;
            this.colPrice.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colPrice.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colPrice.AppearanceHeader.Options.UseFont = true;
            this.colPrice.AppearanceHeader.Options.UseTextOptions = true;
            this.colPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPrice.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colPrice.Caption = "Giá(VND)";
            this.colPrice.DisplayFormat.FormatString = "n2";
            this.colPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPrice.FieldName = "Price";
            this.colPrice.Name = "colPrice";
            this.colPrice.OptionsColumn.AllowEdit = false;
            // 
            // colOrderTime
            // 
            this.colOrderTime.AppearanceCell.Options.UseTextOptions = true;
            this.colOrderTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colOrderTime.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colOrderTime.AppearanceHeader.Options.UseFont = true;
            this.colOrderTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colOrderTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colOrderTime.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colOrderTime.Caption = "Thời gian đặt hàng(ngày)";
            this.colOrderTime.DisplayFormat.FormatString = "n2";
            this.colOrderTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOrderTime.FieldName = "OrderTime";
            this.colOrderTime.Name = "colOrderTime";
            this.colOrderTime.OptionsColumn.AllowEdit = false;
            // 
            // colWorkingDate
            // 
            this.colWorkingDate.AppearanceCell.Options.UseTextOptions = true;
            this.colWorkingDate.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colWorkingDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colWorkingDate.AppearanceHeader.Options.UseFont = true;
            this.colWorkingDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colWorkingDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colWorkingDate.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colWorkingDate.Caption = "Ngày thực hiện";
            this.colWorkingDate.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.colWorkingDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colWorkingDate.FieldName = "WorkingDate";
            this.colWorkingDate.Name = "colWorkingDate";
            this.colWorkingDate.OptionsColumn.AllowEdit = false;
            this.colWorkingDate.Width = 117;
            // 
            // colStatusText
            // 
            this.colStatusText.AppearanceCell.Options.UseTextOptions = true;
            this.colStatusText.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colStatusText.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colStatusText.AppearanceHeader.Options.UseFont = true;
            this.colStatusText.AppearanceHeader.Options.UseTextOptions = true;
            this.colStatusText.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStatusText.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colStatusText.Caption = "Loại";
            this.colStatusText.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colStatusText.FieldName = "StatusText";
            this.colStatusText.Name = "colStatusText";
            this.colStatusText.OptionsColumn.AllowEdit = false;
            this.colStatusText.Width = 159;
            // 
            // colStartTime
            // 
            this.colStartTime.AppearanceCell.Options.UseTextOptions = true;
            this.colStartTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colStartTime.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colStartTime.AppearanceHeader.Options.UseFont = true;
            this.colStartTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colStartTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStartTime.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colStartTime.Caption = "Thời gian bắt đầu";
            this.colStartTime.DisplayFormat.FormatString = "HH:mm";
            this.colStartTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colStartTime.FieldName = "StartTime";
            this.colStartTime.Name = "colStartTime";
            this.colStartTime.OptionsColumn.AllowEdit = false;
            this.colStartTime.OptionsColumn.AllowSize = false;
            this.colStartTime.Width = 65;
            // 
            // colTem
            // 
            this.colTem.AppearanceCell.Options.UseTextOptions = true;
            this.colTem.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTem.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTem.AppearanceHeader.Options.UseFont = true;
            this.colTem.AppearanceHeader.Options.UseTextOptions = true;
            this.colTem.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTem.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colTem.Caption = "Tem";
            this.colTem.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colTem.FieldName = "HasTem";
            this.colTem.Name = "colTem";
            this.colTem.OptionsColumn.AllowEdit = false;
            this.colTem.OptionsColumn.AllowSize = false;
            this.colTem.Width = 38;
            // 
            // colTK
            // 
            this.colTK.AppearanceCell.Options.UseTextOptions = true;
            this.colTK.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colTK.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colTK.AppearanceHeader.Options.UseFont = true;
            this.colTK.AppearanceHeader.Options.UseTextOptions = true;
            this.colTK.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTK.Caption = "TK";
            this.colTK.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colTK.FieldName = "HasTK";
            this.colTK.Name = "colTK";
            this.colTK.OptionsColumn.AllowEdit = false;
            this.colTK.OptionsColumn.AllowSize = false;
            this.colTK.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.colTK.Width = 35;
            // 
            // colIsApproved
            // 
            this.colIsApproved.AppearanceCell.Options.UseTextOptions = true;
            this.colIsApproved.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colIsApproved.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colIsApproved.AppearanceHeader.Options.UseFont = true;
            this.colIsApproved.AppearanceHeader.Options.UseTextOptions = true;
            this.colIsApproved.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colIsApproved.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colIsApproved.Caption = "Duyệt";
            this.colIsApproved.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colIsApproved.FieldName = "IsApproved";
            this.colIsApproved.Name = "colIsApproved";
            this.colIsApproved.OptionsColumn.AllowEdit = false;
            this.colIsApproved.OptionsColumn.AllowSize = false;
            this.colIsApproved.Width = 58;
            // 
            // colEndTime
            // 
            this.colEndTime.AppearanceCell.Options.UseTextOptions = true;
            this.colEndTime.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colEndTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colEndTime.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colEndTime.AppearanceHeader.Options.UseFont = true;
            this.colEndTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colEndTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colEndTime.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colEndTime.Caption = "Thời gian kết thúc";
            this.colEndTime.DisplayFormat.FormatString = "HH:mm";
            this.colEndTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colEndTime.FieldName = "EndTime";
            this.colEndTime.Name = "colEndTime";
            this.colEndTime.OptionsColumn.AllowEdit = false;
            this.colEndTime.OptionsColumn.AllowSize = false;
            this.colEndTime.Width = 74;
            // 
            // colWorkingContent
            // 
            this.colWorkingContent.AppearanceCell.Options.UseTextOptions = true;
            this.colWorkingContent.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colWorkingContent.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colWorkingContent.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colWorkingContent.AppearanceHeader.Options.UseFont = true;
            this.colWorkingContent.AppearanceHeader.Options.UseTextOptions = true;
            this.colWorkingContent.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colWorkingContent.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colWorkingContent.Caption = "Nội dung công việc";
            this.colWorkingContent.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colWorkingContent.FieldName = "WorkingContent";
            this.colWorkingContent.Name = "colWorkingContent";
            this.colWorkingContent.OptionsColumn.AllowEdit = false;
            this.colWorkingContent.Width = 216;
            // 
            // colWorkTime
            // 
            this.colWorkTime.AppearanceCell.Options.UseTextOptions = true;
            this.colWorkTime.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colWorkTime.AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colWorkTime.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colWorkTime.AppearanceHeader.Options.UseFont = true;
            this.colWorkTime.AppearanceHeader.Options.UseTextOptions = true;
            this.colWorkTime.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colWorkTime.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colWorkTime.Caption = "Tổng thời gian (h)";
            this.colWorkTime.DisplayFormat.FormatString = "n2";
            this.colWorkTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colWorkTime.FieldName = "TotalTime";
            this.colWorkTime.Name = "colWorkTime";
            this.colWorkTime.OptionsColumn.AllowEdit = false;
            this.colWorkTime.Visible = true;
            this.colWorkTime.VisibleIndex = 2;
            this.colWorkTime.Width = 108;
            // 
            // colUserId1
            // 
            this.colUserId1.Caption = "UserId";
            this.colUserId1.FieldName = "UserId";
            this.colUserId1.Name = "colUserId1";
            // 
            // colAccount1
            // 
            this.colAccount1.Caption = "Account";
            this.colAccount1.FieldName = "Account";
            this.colAccount1.Name = "colAccount1";
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            this.repositoryItemCheckEdit2.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // btnExecl
            // 
            this.btnExecl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExecl.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnExecl.Appearance.Options.UseFont = true;
            this.btnExecl.Image = ((System.Drawing.Image)(resources.GetObject("btnExecl.Image")));
            this.btnExecl.Location = new System.Drawing.Point(1087, 9);
            this.btnExecl.Name = "btnExecl";
            this.btnExecl.Size = new System.Drawing.Size(104, 30);
            this.btnExecl.TabIndex = 227;
            this.btnExecl.Text = "Xuất excel";
            this.btnExecl.Click += new System.EventHandler(this.btnExecl_Click);
            // 
            // txtTotalTime
            // 
            this.txtTotalTime.Location = new System.Drawing.Point(510, 12);
            this.txtTotalTime.Name = "txtTotalTime";
            this.txtTotalTime.ReadOnly = true;
            this.txtTotalTime.Size = new System.Drawing.Size(76, 20);
            this.txtTotalTime.TabIndex = 228;
            this.txtTotalTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(469, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 229;
            this.label4.Text = "Số giờ";
            // 
            // frmReport_NKCV_ForDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1193, 713);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTotalTime);
            this.Controls.Add(this.btnExecl);
            this.Controls.Add(this.cboDepartment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnXemTatCa);
            this.Controls.Add(this.grdData);
            this.Name = "frmReport_NKCV_ForDate";
            this.Text = "Báo cáo nhật ký công việc";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReport_NKCV_ForDate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartment.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCboDepartment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEndDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStartDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SearchLookUpEdit cboDepartment;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCboDepartment;
        private DevExpress.XtraGrid.Columns.GridColumn colCboDepartmentId;
        private DevExpress.XtraGrid.Columns.GridColumn colCboDepartmentCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCboDepartmentName;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.DateEdit dtpEndDate;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DateEdit dtpStartDate;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton btnXemTatCa;
        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.Grid.GridView grvData;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colGroup;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colDes;
        private DevExpress.XtraGrid.Columns.GridColumn colDName;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectCode;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colInFilm;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colPrice;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderTime;
        private DevExpress.XtraGrid.Columns.GridColumn colWorkingDate;
        private DevExpress.XtraGrid.Columns.GridColumn colStatusText;
        private DevExpress.XtraGrid.Columns.GridColumn colStartTime;
        private DevExpress.XtraGrid.Columns.GridColumn colTem;
        private DevExpress.XtraGrid.Columns.GridColumn colTK;
        private DevExpress.XtraGrid.Columns.GridColumn colIsApproved;
        private DevExpress.XtraGrid.Columns.GridColumn colEndTime;
        private DevExpress.XtraGrid.Columns.GridColumn colWorkingContent;
        private DevExpress.XtraGrid.Columns.GridColumn colWorkTime;
        private DevExpress.XtraGrid.Columns.GridColumn colUserId1;
        private DevExpress.XtraGrid.Columns.GridColumn colAccount1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraEditors.SimpleButton btnExecl;
        private System.Windows.Forms.TextBox txtTotalTime;
        private System.Windows.Forms.Label label4;
    }
}