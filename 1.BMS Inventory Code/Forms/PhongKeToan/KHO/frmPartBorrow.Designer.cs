namespace BMS
{
    partial class frmPartBorrow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPartBorrow));
            this.mnuMenu = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnSaveAndClose = new System.Windows.Forms.ToolStripButton();
            this.dtpDateReturnExpected = new DevExpress.XtraEditors.DateEdit();
            this.dtpDateBorrow = new DevExpress.XtraEditors.DateEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDateReturn = new DevExpress.XtraEditors.DateEdit();
            this.cboPart = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.grvCboKhachHang = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCboCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCboName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCboId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtQtyBorrow = new DevExpress.XtraEditors.TextEdit();
            this.txtQtyReturn = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtQty = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtPrice = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtTotal = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cboUnit = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboUser = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.grvCboUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAccount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartmentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.mnuMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateReturnExpected.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateReturnExpected.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateBorrow.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateBorrow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateReturn.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateReturn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCboKhachHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQtyBorrow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQtyReturn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCboUser)).BeginInit();
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
            this.btnSaveAndClose});
            this.mnuMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuMenu.Size = new System.Drawing.Size(665, 42);
            this.mnuMenu.TabIndex = 12;
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
            this.btnSave.Tag = "frmPartBorrowManager_Save";
            this.btnSave.Text = "Ghi";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSaveAndClose
            // 
            this.btnSaveAndClose.AutoSize = false;
            this.btnSaveAndClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAndClose.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveAndClose.Image")));
            this.btnSaveAndClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(77, 40);
            this.btnSaveAndClose.Tag = "frmPartBorrowManager_Save";
            this.btnSaveAndClose.Text = "Ghi && Thoát";
            this.btnSaveAndClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSaveAndClose.Visible = false;
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // dtpDateReturnExpected
            // 
            this.dtpDateReturnExpected.EditValue = null;
            this.dtpDateReturnExpected.Location = new System.Drawing.Point(414, 132);
            this.dtpDateReturnExpected.Name = "dtpDateReturnExpected";
            this.dtpDateReturnExpected.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.dtpDateReturnExpected.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtpDateReturnExpected.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpDateReturnExpected.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtpDateReturnExpected.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpDateReturnExpected.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtpDateReturnExpected.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtpDateReturnExpected.Properties.NullValuePromptShowForEmptyValue = true;
            this.dtpDateReturnExpected.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtpDateReturnExpected.Size = new System.Drawing.Size(221, 20);
            this.dtpDateReturnExpected.TabIndex = 8;
            // 
            // dtpDateBorrow
            // 
            this.dtpDateBorrow.EditValue = null;
            this.dtpDateBorrow.Location = new System.Drawing.Point(414, 105);
            this.dtpDateBorrow.Name = "dtpDateBorrow";
            this.dtpDateBorrow.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtpDateBorrow.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpDateBorrow.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtpDateBorrow.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpDateBorrow.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtpDateBorrow.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtpDateBorrow.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtpDateBorrow.Size = new System.Drawing.Size(221, 20);
            this.dtpDateBorrow.TabIndex = 7;
            this.dtpDateBorrow.EditValueChanged += new System.EventHandler(this.dtpDateBorrow_EditValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(325, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 214;
            this.label4.Text = "Ngày trả dự kiến";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(349, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 215;
            this.label3.Text = "Ngày mượn";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(327, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 215;
            this.label1.Text = "Ngày trả thực tế";
            // 
            // dtpDateReturn
            // 
            this.dtpDateReturn.EditValue = null;
            this.dtpDateReturn.Location = new System.Drawing.Point(414, 158);
            this.dtpDateReturn.Name = "dtpDateReturn";
            this.dtpDateReturn.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtpDateReturn.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpDateReturn.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtpDateReturn.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpDateReturn.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtpDateReturn.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.dtpDateReturn.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtpDateReturn.Size = new System.Drawing.Size(221, 20);
            this.dtpDateReturn.TabIndex = 9;
            // 
            // cboPart
            // 
            this.cboPart.Location = new System.Drawing.Point(103, 52);
            this.cboPart.Name = "cboPart";
            this.cboPart.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7F);
            this.cboPart.Properties.Appearance.Options.UseFont = true;
            this.cboPart.Properties.AutoHeight = false;
            this.cboPart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPart.Properties.NullText = "";
            this.cboPart.Properties.View = this.grvCboKhachHang;
            this.cboPart.Size = new System.Drawing.Size(532, 20);
            this.cboPart.TabIndex = 0;
            this.cboPart.EditValueChanged += new System.EventHandler(this.cboPart_EditValueChanged);
            // 
            // grvCboKhachHang
            // 
            this.grvCboKhachHang.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvCboKhachHang.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvCboKhachHang.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvCboKhachHang.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvCboKhachHang.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.grvCboKhachHang.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvCboKhachHang.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCboCode,
            this.colCboName,
            this.colCboId});
            this.grvCboKhachHang.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboKhachHang.Name = "grvCboKhachHang";
            this.grvCboKhachHang.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvCboKhachHang.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboKhachHang.OptionsView.ShowGroupedColumns = true;
            this.grvCboKhachHang.OptionsView.ShowGroupPanel = false;
            // 
            // colCboCode
            // 
            this.colCboCode.Caption = "Mã vật tư";
            this.colCboCode.FieldName = "PartsCode";
            this.colCboCode.Name = "colCboCode";
            this.colCboCode.OptionsColumn.AllowEdit = false;
            this.colCboCode.OptionsColumn.AllowFocus = false;
            this.colCboCode.Visible = true;
            this.colCboCode.VisibleIndex = 0;
            // 
            // colCboName
            // 
            this.colCboName.Caption = "Tên vật tư";
            this.colCboName.FieldName = "PartsName";
            this.colCboName.Name = "colCboName";
            this.colCboName.OptionsColumn.AllowEdit = false;
            this.colCboName.OptionsColumn.AllowFocus = false;
            this.colCboName.Visible = true;
            this.colCboName.VisibleIndex = 1;
            this.colCboName.Width = 309;
            // 
            // colCboId
            // 
            this.colCboId.Caption = "ID";
            this.colCboId.FieldName = "PartsId";
            this.colCboId.Name = "colCboId";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(62, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 218;
            this.label5.Text = "Vật tư";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(10, 109);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(87, 13);
            this.labelControl6.TabIndex = 221;
            this.labelControl6.Text = "Số lượng đã mượn";
            // 
            // txtQtyBorrow
            // 
            this.txtQtyBorrow.EditValue = "1";
            this.txtQtyBorrow.Location = new System.Drawing.Point(103, 106);
            this.txtQtyBorrow.Name = "txtQtyBorrow";
            this.txtQtyBorrow.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txtQtyBorrow.Properties.Appearance.Options.UseFont = true;
            this.txtQtyBorrow.Properties.Appearance.Options.UseTextOptions = true;
            this.txtQtyBorrow.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtQtyBorrow.Properties.DisplayFormat.FormatString = "n0";
            this.txtQtyBorrow.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtQtyBorrow.Properties.EditFormat.FormatString = "n0";
            this.txtQtyBorrow.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtQtyBorrow.Properties.Mask.EditMask = "n0";
            this.txtQtyBorrow.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtQtyBorrow.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtQtyBorrow.Size = new System.Drawing.Size(147, 23);
            this.txtQtyBorrow.TabIndex = 2;
            this.txtQtyBorrow.EditValueChanged += new System.EventHandler(this.txtQtyBorrow_EditValueChanged);
            // 
            // txtQtyReturn
            // 
            this.txtQtyReturn.EditValue = "0";
            this.txtQtyReturn.Location = new System.Drawing.Point(103, 132);
            this.txtQtyReturn.Name = "txtQtyReturn";
            this.txtQtyReturn.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txtQtyReturn.Properties.Appearance.Options.UseFont = true;
            this.txtQtyReturn.Properties.Appearance.Options.UseTextOptions = true;
            this.txtQtyReturn.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtQtyReturn.Properties.DisplayFormat.FormatString = "n0";
            this.txtQtyReturn.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtQtyReturn.Properties.EditFormat.FormatString = "n0";
            this.txtQtyReturn.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtQtyReturn.Properties.Mask.EditMask = "n0";
            this.txtQtyReturn.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtQtyReturn.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtQtyReturn.Size = new System.Drawing.Size(147, 23);
            this.txtQtyReturn.TabIndex = 3;
            this.txtQtyReturn.EditValueChanged += new System.EventHandler(this.txtQtyReturn_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(23, 135);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(74, 13);
            this.labelControl1.TabIndex = 221;
            this.labelControl1.Text = "Số lượng đã trả";
            // 
            // txtQty
            // 
            this.txtQty.EditValue = "1";
            this.txtQty.Location = new System.Drawing.Point(103, 158);
            this.txtQty.Name = "txtQty";
            this.txtQty.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txtQty.Properties.Appearance.Options.UseFont = true;
            this.txtQty.Properties.Appearance.Options.UseTextOptions = true;
            this.txtQty.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtQty.Properties.DisplayFormat.FormatString = "n0";
            this.txtQty.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtQty.Properties.EditFormat.FormatString = "n0";
            this.txtQty.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtQty.Properties.Mask.EditMask = "n0";
            this.txtQty.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtQty.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtQty.Size = new System.Drawing.Size(147, 23);
            this.txtQty.TabIndex = 4;
            this.txtQty.EditValueChanged += new System.EventHandler(this.txtQty_EditValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(22, 161);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(75, 13);
            this.labelControl2.TabIndex = 221;
            this.labelControl2.Text = "Số lượng còn lại";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(103, 186);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txtPrice.Properties.Appearance.Options.UseFont = true;
            this.txtPrice.Properties.Appearance.Options.UseTextOptions = true;
            this.txtPrice.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtPrice.Properties.DisplayFormat.FormatString = "n0";
            this.txtPrice.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPrice.Properties.EditFormat.FormatString = "n0";
            this.txtPrice.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtPrice.Properties.Mask.EditMask = "n0";
            this.txtPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPrice.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtPrice.Size = new System.Drawing.Size(147, 23);
            this.txtPrice.TabIndex = 5;
            this.txtPrice.EditValueChanged += new System.EventHandler(this.txtPrice_EditValueChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(60, 189);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(37, 13);
            this.labelControl3.TabIndex = 221;
            this.labelControl3.Text = "Đơn giá";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(103, 212);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txtTotal.Properties.Appearance.Options.UseFont = true;
            this.txtTotal.Properties.Appearance.Options.UseTextOptions = true;
            this.txtTotal.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtTotal.Properties.DisplayFormat.FormatString = "n0";
            this.txtTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotal.Properties.EditFormat.FormatString = "n0";
            this.txtTotal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtTotal.Properties.Mask.EditMask = "n0";
            this.txtTotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtTotal.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtTotal.Size = new System.Drawing.Size(147, 23);
            this.txtTotal.TabIndex = 6;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(52, 215);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(45, 13);
            this.labelControl4.TabIndex = 221;
            this.labelControl4.Text = "Tổng tiền";
            // 
            // cboUnit
            // 
            this.cboUnit.FormattingEnabled = true;
            this.cboUnit.Location = new System.Drawing.Point(103, 79);
            this.cboUnit.Name = "cboUnit";
            this.cboUnit.Size = new System.Drawing.Size(148, 21);
            this.cboUnit.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(59, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 222;
            this.label6.Text = "Đơn vị";
            // 
            // cboUser
            // 
            this.cboUser.Location = new System.Drawing.Point(414, 80);
            this.cboUser.Name = "cboUser";
            this.cboUser.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 7F);
            this.cboUser.Properties.Appearance.Options.UseFont = true;
            this.cboUser.Properties.AutoHeight = false;
            this.cboUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboUser.Properties.NullText = "";
            this.cboUser.Properties.View = this.grvCboUser;
            this.cboUser.Size = new System.Drawing.Size(221, 20);
            this.cboUser.TabIndex = 10;
            // 
            // grvCboUser
            // 
            this.grvCboUser.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUserID,
            this.colUserCode,
            this.colFullName,
            this.colAccount,
            this.colDepartmentName});
            this.grvCboUser.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboUser.GroupCount = 1;
            this.grvCboUser.Name = "grvCboUser";
            this.grvCboUser.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboUser.OptionsView.ShowGroupedColumns = true;
            this.grvCboUser.OptionsView.ShowGroupPanel = false;
            this.grvCboUser.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colDepartmentName, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colUserID
            // 
            this.colUserID.Caption = "ID";
            this.colUserID.FieldName = "UserId";
            this.colUserID.Name = "colUserID";
            // 
            // colUserCode
            // 
            this.colUserCode.Caption = "Mã nhân viên";
            this.colUserCode.FieldName = "SupplierCode";
            this.colUserCode.Name = "colUserCode";
            this.colUserCode.Visible = true;
            this.colUserCode.VisibleIndex = 0;
            // 
            // colFullName
            // 
            this.colFullName.Caption = "Tên đầy đủ";
            this.colFullName.FieldName = "UserName";
            this.colFullName.Name = "colFullName";
            this.colFullName.Visible = true;
            this.colFullName.VisibleIndex = 2;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(346, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 222;
            this.label2.Text = "Người mượn";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(414, 189);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(221, 43);
            this.txtDescription.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(366, 195);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 222;
            this.label7.Text = "Ghi chú";
            // 
            // frmPartBorrow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 243);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.cboUser);
            this.Controls.Add(this.cboUnit);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.txtQtyReturn);
            this.Controls.Add(this.txtQtyBorrow);
            this.Controls.Add(this.cboPart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpDateReturn);
            this.Controls.Add(this.dtpDateReturnExpected);
            this.Controls.Add(this.dtpDateBorrow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mnuMenu);
            this.Name = "frmPartBorrow";
            this.Text = "MƯỢN HÀNG";
            this.Load += new System.EventHandler(this.frmPartBorrow_Load);
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateReturnExpected.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateReturnExpected.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateBorrow.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateBorrow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateReturn.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDateReturn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCboKhachHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQtyBorrow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQtyReturn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCboUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip mnuMenu;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnSaveAndClose;
        private DevExpress.XtraEditors.DateEdit dtpDateReturnExpected;
        private DevExpress.XtraEditors.DateEdit dtpDateBorrow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DateEdit dtpDateReturn;
        private DevExpress.XtraEditors.SearchLookUpEdit cboPart;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCboKhachHang;
        private DevExpress.XtraGrid.Columns.GridColumn colCboCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCboName;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtQtyBorrow;
        private DevExpress.XtraEditors.TextEdit txtQtyReturn;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtQty;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtPrice;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtTotal;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.ComboBox cboUnit;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.SearchLookUpEdit cboUser;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCboUser;
        private DevExpress.XtraGrid.Columns.GridColumn colUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colUserCode;
        private DevExpress.XtraGrid.Columns.GridColumn colFullName;
        private DevExpress.XtraGrid.Columns.GridColumn colAccount;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartmentName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraGrid.Columns.GridColumn colCboId;
    }
}