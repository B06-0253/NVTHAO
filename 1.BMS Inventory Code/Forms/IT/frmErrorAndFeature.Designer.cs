namespace BMS
{
    partial class frmErrorAndFeature
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmErrorAndFeature));
            this.mnuMenu = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSaveAndClose = new System.Windows.Forms.ToolStripButton();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboUser = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label15 = new System.Windows.Forms.Label();
            this.chkClosed = new System.Windows.Forms.CheckBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cboNCC = new System.Windows.Forms.ComboBox();
            this.cboPhanMem = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.txtPrice = new DevExpress.XtraEditors.TextEdit();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpRequestDate = new DevExpress.XtraEditors.DateEdit();
            this.dtpNgayBaoGia = new DevExpress.XtraEditors.DateEdit();
            this.dtpNgayBaoGiaConfirm = new DevExpress.XtraEditors.DateEdit();
            this.dtpWorkEndDateDK = new DevExpress.XtraEditors.DateEdit();
            this.dtpWorkEndDate = new DevExpress.XtraEditors.DateEdit();
            this.dtpConfirmDate = new DevExpress.XtraEditors.DateEdit();
            this.mnuMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpRequestDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpRequestDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayBaoGia.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayBaoGia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayBaoGiaConfirm.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayBaoGiaConfirm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpWorkEndDateDK.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpWorkEndDateDK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpWorkEndDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpWorkEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpConfirmDate.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpConfirmDate.Properties)).BeginInit();
            this.SuspendLayout();
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
            this.mnuMenu.Size = new System.Drawing.Size(815, 42);
            this.mnuMenu.TabIndex = 1;
            this.mnuMenu.Text = "toolStrip2";
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = false;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(55, 40);
            this.btnSave.Tag = "frmErrorAndFeature_Save";
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
            this.btnSaveAndClose.AutoSize = false;
            this.btnSaveAndClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAndClose.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveAndClose.Image")));
            this.btnSaveAndClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(77, 40);
            this.btnSaveAndClose.Tag = "frmErrorAndFeature_Save";
            this.btnSaveAndClose.Text = "Ghi && Thoát";
            this.btnSaveAndClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(96, 46);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(326, 20);
            this.txtCode.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(76, 49);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(14, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Mã";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(63, 84);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(27, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Mô tả";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(446, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 193;
            this.label2.Text = "Ngày xác nhận báo giá";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(493, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 194;
            this.label1.Text = "Ngày báo giá";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(490, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 194;
            this.label3.Text = "Ngày yêu cầu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(448, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 194;
            this.label4.Text = "Ngày cập nhật dự kiến";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(450, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 13);
            this.label5.TabIndex = 194;
            this.label5.Text = "Ngày cập nhật thực tế";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(491, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 194;
            this.label6.Text = "Ngày kiểm tra";
            // 
            // cboUser
            // 
            this.cboUser.Location = new System.Drawing.Point(96, 179);
            this.cboUser.Name = "cboUser";
            this.cboUser.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7F);
            this.cboUser.Properties.Appearance.Options.UseFont = true;
            this.cboUser.Properties.AutoHeight = false;
            this.cboUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboUser.Properties.NullText = "";
            this.cboUser.Properties.View = this.gridView1;
            this.cboUser.Size = new System.Drawing.Size(326, 20);
            this.cboUser.TabIndex = 203;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUserID,
            this.colFullName,
            this.colDepartment});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupedColumns = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDepartment, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colUserID
            // 
            this.colUserID.Caption = "ID";
            this.colUserID.FieldName = "ID";
            this.colUserID.Name = "colUserID";
            // 
            // colFullName
            // 
            this.colFullName.Caption = "Tên";
            this.colFullName.FieldName = "FullName";
            this.colFullName.Name = "colFullName";
            this.colFullName.Visible = true;
            this.colFullName.VisibleIndex = 0;
            // 
            // colDepartment
            // 
            this.colDepartment.Caption = "Phòng ban";
            this.colDepartment.FieldName = "DepartmentName";
            this.colDepartment.Name = "colDepartment";
            this.colDepartment.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(14, 182);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(76, 13);
            this.label15.TabIndex = 202;
            this.label15.Text = "Người yêu cầu";
            // 
            // chkClosed
            // 
            this.chkClosed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkClosed.AutoSize = true;
            this.chkClosed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkClosed.Location = new System.Drawing.Point(711, 12);
            this.chkClosed.Name = "chkClosed";
            this.chkClosed.Size = new System.Drawing.Size(92, 17);
            this.chkClosed.TabIndex = 204;
            this.chkClosed.Text = "Hoàn thành";
            this.chkClosed.UseVisualStyleBackColor = true;
            // 
            // cboStatus
            // 
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "Đã hoạt động",
            "Chưa hoạt động"});
            this.cboStatus.Location = new System.Drawing.Point(569, 205);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(236, 21);
            this.cboStatus.TabIndex = 205;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(450, 208);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 13);
            this.label8.TabIndex = 202;
            this.label8.Text = "Tình trạng sau kiểm tra";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 208);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 13);
            this.label9.TabIndex = 202;
            this.label9.Text = "Nhà cung cấp";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(33, 234);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 202;
            this.label10.Text = "Phần mềm";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(96, 71);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtName.Size = new System.Drawing.Size(326, 98);
            this.txtName.TabIndex = 206;
            // 
            // cboNCC
            // 
            this.cboNCC.FormattingEnabled = true;
            this.cboNCC.Location = new System.Drawing.Point(96, 205);
            this.cboNCC.Name = "cboNCC";
            this.cboNCC.Size = new System.Drawing.Size(326, 21);
            this.cboNCC.TabIndex = 205;
            // 
            // cboPhanMem
            // 
            this.cboPhanMem.FormattingEnabled = true;
            this.cboPhanMem.Location = new System.Drawing.Point(96, 230);
            this.cboPhanMem.Name = "cboPhanMem";
            this.cboPhanMem.Size = new System.Drawing.Size(326, 21);
            this.cboPhanMem.TabIndex = 205;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(508, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 13);
            this.label11.TabIndex = 202;
            this.label11.Text = "Loại";
            // 
            // cboType
            // 
            this.cboType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboType.FormattingEnabled = true;
            this.cboType.Items.AddRange(new object[] {
            "Lỗi",
            "Tính năng mới"});
            this.cboType.Location = new System.Drawing.Point(538, 10);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(148, 21);
            this.cboType.TabIndex = 205;
            // 
            // txtPrice
            // 
            this.txtPrice.EditValue = "";
            this.txtPrice.Location = new System.Drawing.Point(569, 232);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txtPrice.Properties.Appearance.Options.UseFont = true;
            this.txtPrice.Properties.DisplayFormat.FormatString = "n0";
            this.txtPrice.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPrice.Properties.EditFormat.FormatString = "n0";
            this.txtPrice.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPrice.Properties.Mask.EditMask = "n0";
            this.txtPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPrice.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPrice.Size = new System.Drawing.Size(236, 21);
            this.txtPrice.TabIndex = 208;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(514, 235);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 13);
            this.label12.TabIndex = 207;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(511, 235);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 202;
            this.label7.Text = "Tổng tiền";
            // 
            // dtpRequestDate
            // 
            this.dtpRequestDate.EditValue = null;
            this.dtpRequestDate.Location = new System.Drawing.Point(569, 46);
            this.dtpRequestDate.Name = "dtpRequestDate";
            this.dtpRequestDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtpRequestDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpRequestDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtpRequestDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpRequestDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtpRequestDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtpRequestDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtpRequestDate.Size = new System.Drawing.Size(236, 20);
            this.dtpRequestDate.TabIndex = 209;
            // 
            // dtpNgayBaoGia
            // 
            this.dtpNgayBaoGia.EditValue = null;
            this.dtpNgayBaoGia.Location = new System.Drawing.Point(569, 71);
            this.dtpNgayBaoGia.Name = "dtpNgayBaoGia";
            this.dtpNgayBaoGia.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dtpNgayBaoGia.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtpNgayBaoGia.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpNgayBaoGia.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtpNgayBaoGia.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpNgayBaoGia.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtpNgayBaoGia.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtpNgayBaoGia.Properties.NullValuePromptShowForEmptyValue = true;
            this.dtpNgayBaoGia.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtpNgayBaoGia.Size = new System.Drawing.Size(236, 20);
            this.dtpNgayBaoGia.TabIndex = 209;
            // 
            // dtpNgayBaoGiaConfirm
            // 
            this.dtpNgayBaoGiaConfirm.EditValue = null;
            this.dtpNgayBaoGiaConfirm.Location = new System.Drawing.Point(569, 100);
            this.dtpNgayBaoGiaConfirm.Name = "dtpNgayBaoGiaConfirm";
            this.dtpNgayBaoGiaConfirm.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtpNgayBaoGiaConfirm.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpNgayBaoGiaConfirm.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtpNgayBaoGiaConfirm.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpNgayBaoGiaConfirm.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtpNgayBaoGiaConfirm.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtpNgayBaoGiaConfirm.Size = new System.Drawing.Size(236, 20);
            this.dtpNgayBaoGiaConfirm.TabIndex = 209;
            // 
            // dtpWorkEndDateDK
            // 
            this.dtpWorkEndDateDK.EditValue = null;
            this.dtpWorkEndDateDK.Location = new System.Drawing.Point(569, 126);
            this.dtpWorkEndDateDK.Name = "dtpWorkEndDateDK";
            this.dtpWorkEndDateDK.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtpWorkEndDateDK.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpWorkEndDateDK.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtpWorkEndDateDK.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpWorkEndDateDK.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtpWorkEndDateDK.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtpWorkEndDateDK.Size = new System.Drawing.Size(236, 20);
            this.dtpWorkEndDateDK.TabIndex = 209;
            // 
            // dtpWorkEndDate
            // 
            this.dtpWorkEndDate.EditValue = null;
            this.dtpWorkEndDate.Location = new System.Drawing.Point(569, 152);
            this.dtpWorkEndDate.Name = "dtpWorkEndDate";
            this.dtpWorkEndDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtpWorkEndDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpWorkEndDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtpWorkEndDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpWorkEndDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtpWorkEndDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtpWorkEndDate.Size = new System.Drawing.Size(236, 20);
            this.dtpWorkEndDate.TabIndex = 209;
            // 
            // dtpConfirmDate
            // 
            this.dtpConfirmDate.EditValue = null;
            this.dtpConfirmDate.Location = new System.Drawing.Point(569, 178);
            this.dtpConfirmDate.Name = "dtpConfirmDate";
            this.dtpConfirmDate.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtpConfirmDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpConfirmDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtpConfirmDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpConfirmDate.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtpConfirmDate.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtpConfirmDate.Size = new System.Drawing.Size(236, 20);
            this.dtpConfirmDate.TabIndex = 209;
            // 
            // frmErrorAndFeature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 265);
            this.Controls.Add(this.dtpConfirmDate);
            this.Controls.Add(this.dtpWorkEndDate);
            this.Controls.Add(this.dtpWorkEndDateDK);
            this.Controls.Add(this.dtpNgayBaoGiaConfirm);
            this.Controls.Add(this.dtpNgayBaoGia);
            this.Controls.Add(this.dtpRequestDate);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.cboPhanMem);
            this.Controls.Add(this.cboNCC);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.chkClosed);
            this.Controls.Add(this.cboUser);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.mnuMenu);
            this.Name = "frmErrorAndFeature";
            this.Text = "LỖI, TÍNH NĂNG MỚI";
            this.Load += new System.EventHandler(this.frmErrorAndFeature_Load);
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpRequestDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpRequestDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayBaoGia.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayBaoGia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayBaoGiaConfirm.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayBaoGiaConfirm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpWorkEndDateDK.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpWorkEndDateDK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpWorkEndDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpWorkEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpConfirmDate.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpConfirmDate.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip mnuMenu;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnSaveAndClose;
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.SearchLookUpEdit cboUser;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colFullName;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartment;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox chkClosed;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cboNCC;
        private System.Windows.Forms.ComboBox cboPhanMem;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboType;
        private DevExpress.XtraEditors.TextEdit txtPrice;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.DateEdit dtpRequestDate;
        private DevExpress.XtraEditors.DateEdit dtpNgayBaoGia;
        private DevExpress.XtraEditors.DateEdit dtpNgayBaoGiaConfirm;
        private DevExpress.XtraEditors.DateEdit dtpWorkEndDateDK;
        private DevExpress.XtraEditors.DateEdit dtpWorkEndDate;
        private DevExpress.XtraEditors.DateEdit dtpConfirmDate;
    }
}