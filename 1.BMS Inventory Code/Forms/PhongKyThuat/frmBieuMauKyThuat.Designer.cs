namespace BMS
{
    partial class frmBieuMauKyThuat
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
            this.btnHuongDanSuDung = new System.Windows.Forms.Button();
            this.cboModule = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.grvCboModule = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colModuleCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModuleName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSpecifications = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.cboVersion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTSKT = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnHDTH = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnCreateTHTL = new System.Windows.Forms.Button();
            this.txtFilePathTHTK = new System.Windows.Forms.TextBox();
            this.btnChooseFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cboModule.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCboModule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTSKT.Properties)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnHuongDanSuDung
            // 
            this.btnHuongDanSuDung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHuongDanSuDung.Location = new System.Drawing.Point(873, 60);
            this.btnHuongDanSuDung.Name = "btnHuongDanSuDung";
            this.btnHuongDanSuDung.Size = new System.Drawing.Size(130, 23);
            this.btnHuongDanSuDung.TabIndex = 0;
            this.btnHuongDanSuDung.Text = "Hướng dẫn sử dụng";
            this.btnHuongDanSuDung.UseVisualStyleBackColor = true;
            this.btnHuongDanSuDung.Click += new System.EventHandler(this.btnHuongDanSuDung_Click);
            // 
            // cboModule
            // 
            this.cboModule.Location = new System.Drawing.Point(76, 16);
            this.cboModule.Name = "cboModule";
            this.cboModule.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboModule.Properties.NullText = "";
            this.cboModule.Properties.View = this.grvCboModule;
            this.cboModule.Size = new System.Drawing.Size(521, 20);
            this.cboModule.TabIndex = 181;
            this.cboModule.EditValueChanged += new System.EventHandler(this.cboModule_EditValueChanged);
            // 
            // grvCboModule
            // 
            this.grvCboModule.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colModuleCode,
            this.colModuleName,
            this.colSpecifications});
            this.grvCboModule.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvCboModule.Name = "grvCboModule";
            this.grvCboModule.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvCboModule.OptionsView.ColumnAutoWidth = false;
            this.grvCboModule.OptionsView.ShowGroupPanel = false;
            // 
            // colModuleCode
            // 
            this.colModuleCode.Caption = "Mã";
            this.colModuleCode.FieldName = "Code";
            this.colModuleCode.Name = "colModuleCode";
            this.colModuleCode.Visible = true;
            this.colModuleCode.VisibleIndex = 0;
            this.colModuleCode.Width = 192;
            // 
            // colModuleName
            // 
            this.colModuleName.Caption = "Tên";
            this.colModuleName.FieldName = "Name";
            this.colModuleName.Name = "colModuleName";
            this.colModuleName.Visible = true;
            this.colModuleName.VisibleIndex = 1;
            this.colModuleName.Width = 275;
            // 
            // colSpecifications
            // 
            this.colSpecifications.Caption = "Specifications";
            this.colSpecifications.FieldName = "Specifications";
            this.colSpecifications.Name = "colSpecifications";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 180;
            this.label8.Text = "Module";
            // 
            // cboVersion
            // 
            this.cboVersion.FormattingEnabled = true;
            this.cboVersion.Location = new System.Drawing.Point(76, 43);
            this.cboVersion.Name = "cboVersion";
            this.cboVersion.Size = new System.Drawing.Size(121, 21);
            this.cboVersion.TabIndex = 182;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 180;
            this.label1.Text = "Phiên bản";
            // 
            // txtTSKT
            // 
            this.txtTSKT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTSKT.Location = new System.Drawing.Point(6, 89);
            this.txtTSKT.Name = "txtTSKT";
            this.txtTSKT.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTSKT.Size = new System.Drawing.Size(997, 352);
            this.txtTSKT.TabIndex = 184;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(21, 70);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(87, 13);
            this.labelControl7.TabIndex = 183;
            this.labelControl7.Text = "Thông số kỹ thuật";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(2, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1017, 473);
            this.tabControl1.TabIndex = 185;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtTSKT);
            this.tabPage1.Controls.Add(this.btnHuongDanSuDung);
            this.tabPage1.Controls.Add(this.cboVersion);
            this.tabPage1.Controls.Add(this.labelControl7);
            this.tabPage1.Controls.Add(this.cboModule);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1009, 447);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Hướng dẫn sử dụng";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnHDTH);
            this.tabPage2.Controls.Add(this.txtName);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.txtCode);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1009, 447);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Hướng dẫn thực hành";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnHDTH
            // 
            this.btnHDTH.Location = new System.Drawing.Point(670, 14);
            this.btnHDTH.Name = "btnHDTH";
            this.btnHDTH.Size = new System.Drawing.Size(95, 23);
            this.btnHDTH.TabIndex = 2;
            this.btnHDTH.Text = "Tạo";
            this.btnHDTH.UseVisualStyleBackColor = true;
            this.btnHDTH.Click += new System.EventHandler(this.btnHDTH_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(77, 42);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(574, 113);
            this.txtName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tên";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(77, 16);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(574, 20);
            this.txtCode.TabIndex = 1;
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnCreateTHTL);
            this.tabPage3.Controls.Add(this.txtFilePathTHTK);
            this.tabPage3.Controls.Add(this.btnChooseFile);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1009, 447);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Tổng hợp tài liệu";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnCreateTHTL
            // 
            this.btnCreateTHTL.Location = new System.Drawing.Point(18, 46);
            this.btnCreateTHTL.Name = "btnCreateTHTL";
            this.btnCreateTHTL.Size = new System.Drawing.Size(110, 23);
            this.btnCreateTHTL.TabIndex = 23;
            this.btnCreateTHTL.Text = "Tạo";
            this.btnCreateTHTL.UseVisualStyleBackColor = true;
            this.btnCreateTHTL.Click += new System.EventHandler(this.btnCreateTHTL_Click);
            // 
            // txtFilePathTHTK
            // 
            this.txtFilePathTHTK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilePathTHTK.Location = new System.Drawing.Point(135, 19);
            this.txtFilePathTHTK.Name = "txtFilePathTHTK";
            this.txtFilePathTHTK.Size = new System.Drawing.Size(853, 20);
            this.txtFilePathTHTK.TabIndex = 22;
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.BackColor = System.Drawing.Color.White;
            this.btnChooseFile.Location = new System.Drawing.Point(18, 17);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(110, 23);
            this.btnChooseFile.TabIndex = 21;
            this.btnChooseFile.Text = "Chọn bản thiết kế";
            this.btnChooseFile.UseVisualStyleBackColor = false;
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // frmBieuMauKyThuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 480);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmBieuMauKyThuat";
            this.Text = "TẠO BIỂU MẪU";
            this.Load += new System.EventHandler(this.frmBieuMauKyThuat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboModule.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCboModule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTSKT.Properties)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHuongDanSuDung;
        private DevExpress.XtraEditors.SearchLookUpEdit cboModule;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCboModule;
        private DevExpress.XtraGrid.Columns.GridColumn colModuleCode;
        private DevExpress.XtraGrid.Columns.GridColumn colModuleName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboVersion;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.Columns.GridColumn colSpecifications;
        private DevExpress.XtraEditors.MemoEdit txtTSKT;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnHDTH;
        private System.Windows.Forms.TabPage tabPage3;
        internal System.Windows.Forms.TextBox txtFilePathTHTK;
        internal System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.Button btnCreateTHTL;
    }
}