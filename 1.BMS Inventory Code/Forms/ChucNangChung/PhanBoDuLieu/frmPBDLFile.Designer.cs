namespace BMS
{
    partial class frmPBDLFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPBDLFile));
            this.mnuMenu = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtFolderContain = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtFileName = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.cboGetType = new System.Windows.Forms.ComboBox();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.chkMat = new DevExpress.XtraEditors.CheckEdit();
            this.chkTem = new DevExpress.XtraEditors.CheckEdit();
            this.chkMaVatLieu = new DevExpress.XtraEditors.CheckEdit();
            this.txtThongSo = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtDonVi = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtDescription = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboFileType = new System.Windows.Forms.ComboBox();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtExtension = new DevExpress.XtraEditors.MemoEdit();
            this.mnuMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFolderContain.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileName.Properties)).BeginInit();
            this.gbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkMat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMaVatLieu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThongSo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonVi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExtension.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuMenu
            // 
            this.mnuMenu.AutoSize = false;
            this.mnuMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.mnuMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave});
            this.mnuMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuMenu.Size = new System.Drawing.Size(888, 42);
            this.mnuMenu.TabIndex = 18;
            this.mnuMenu.Text = "toolStrip2";
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = false;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(55, 40);
            this.btnSave.Text = "Ghi";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(29, 171);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(101, 13);
            this.labelControl1.TabIndex = 19;
            this.labelControl1.Text = "Đường dẫn nguồn(*)";
            // 
            // txtFolderContain
            // 
            this.txtFolderContain.Location = new System.Drawing.Point(134, 167);
            this.txtFolderContain.Name = "txtFolderContain";
            this.txtFolderContain.Size = new System.Drawing.Size(708, 22);
            this.txtFolderContain.TabIndex = 20;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(95, 96);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(35, 13);
            this.labelControl3.TabIndex = 19;
            this.labelControl3.Text = "Tên file";
            // 
            // txtFileName
            // 
            this.txtFileName.Enabled = false;
            this.txtFileName.Location = new System.Drawing.Point(134, 92);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(238, 21);
            this.txtFileName.TabIndex = 20;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(57, 61);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(73, 13);
            this.labelControl5.TabIndex = 19;
            this.labelControl5.Text = "Số lượng file(*)";
            // 
            // cboGetType
            // 
            this.cboGetType.FormattingEnabled = true;
            this.cboGetType.Items.AddRange(new object[] {
            "Nhiều file",
            "Một file"});
            this.cboGetType.Location = new System.Drawing.Point(134, 58);
            this.cboGetType.Name = "cboGetType";
            this.cboGetType.Size = new System.Drawing.Size(237, 21);
            this.cboGetType.TabIndex = 21;
            this.cboGetType.SelectedIndexChanged += new System.EventHandler(this.cboGetType_SelectedIndexChanged);
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.chkMat);
            this.gbFilter.Controls.Add(this.chkTem);
            this.gbFilter.Controls.Add(this.chkMaVatLieu);
            this.gbFilter.Controls.Add(this.txtThongSo);
            this.gbFilter.Controls.Add(this.labelControl6);
            this.gbFilter.Controls.Add(this.txtDonVi);
            this.gbFilter.Controls.Add(this.labelControl8);
            this.gbFilter.Enabled = false;
            this.gbFilter.Location = new System.Drawing.Point(510, 61);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(332, 95);
            this.gbFilter.TabIndex = 22;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Chế độ lọc trong file danh mục vật tư";
            // 
            // chkMat
            // 
            this.chkMat.Location = new System.Drawing.Point(125, 63);
            this.chkMat.Name = "chkMat";
            this.chkMat.Properties.Caption = "MẶT";
            this.chkMat.Size = new System.Drawing.Size(49, 19);
            this.chkMat.TabIndex = 21;
            // 
            // chkTem
            // 
            this.chkTem.Location = new System.Drawing.Point(28, 63);
            this.chkTem.Name = "chkTem";
            this.chkTem.Properties.Caption = "TEM";
            this.chkTem.Size = new System.Drawing.Size(54, 19);
            this.chkTem.TabIndex = 21;
            // 
            // chkMaVatLieu
            // 
            this.chkMaVatLieu.Location = new System.Drawing.Point(226, 63);
            this.chkMaVatLieu.Name = "chkMaVatLieu";
            this.chkMaVatLieu.Properties.Caption = "Mã vật liệu";
            this.chkMaVatLieu.Size = new System.Drawing.Size(75, 19);
            this.chkMaVatLieu.TabIndex = 21;
            // 
            // txtThongSo
            // 
            this.txtThongSo.Location = new System.Drawing.Point(68, 32);
            this.txtThongSo.Name = "txtThongSo";
            this.txtThongSo.Size = new System.Drawing.Size(106, 21);
            this.txtThongSo.TabIndex = 20;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(17, 35);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(44, 13);
            this.labelControl6.TabIndex = 19;
            this.labelControl6.Text = "Thông số";
            // 
            // txtDonVi
            // 
            this.txtDonVi.Location = new System.Drawing.Point(239, 32);
            this.txtDonVi.Name = "txtDonVi";
            this.txtDonVi.Size = new System.Drawing.Size(73, 21);
            this.txtDonVi.TabIndex = 20;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(202, 36);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(31, 13);
            this.labelControl8.TabIndex = 19;
            this.labelControl8.Text = "Đơn vị";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(103, 207);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(27, 13);
            this.labelControl7.TabIndex = 19;
            this.labelControl7.Text = "Mô tả";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(134, 204);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(708, 37);
            this.txtDescription.TabIndex = 20;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(79, 133);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(51, 13);
            this.labelControl2.TabIndex = 19;
            this.labelControl2.Text = "Kiểu file(*)";
            // 
            // cboFileType
            // 
            this.cboFileType.FormattingEnabled = true;
            this.cboFileType.Items.AddRange(new object[] {
            "Cơ khí",
            "Điện",
            "Điện tử"});
            this.cboFileType.Location = new System.Drawing.Point(134, 130);
            this.cboFileType.Name = "cboFileType";
            this.cboFileType.Size = new System.Drawing.Size(237, 21);
            this.cboFileType.TabIndex = 21;
            this.cboFileType.SelectedIndexChanged += new System.EventHandler(this.cboGetType_SelectedIndexChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(386, 96);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(22, 13);
            this.labelControl4.TabIndex = 19;
            this.labelControl4.Text = "Đuôi";
            // 
            // txtExtension
            // 
            this.txtExtension.Location = new System.Drawing.Point(412, 92);
            this.txtExtension.Name = "txtExtension";
            this.txtExtension.Size = new System.Drawing.Size(73, 21);
            this.txtExtension.TabIndex = 20;
            // 
            // frmPBDLFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 261);
            this.Controls.Add(this.gbFilter);
            this.Controls.Add(this.cboFileType);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.cboGetType);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.txtExtension);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.txtFolderContain);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.mnuMenu);
            this.Name = "frmPBDLFile";
            this.Text = "Cấu hình phân bổ dữ liệu";
            this.Load += new System.EventHandler(this.frmPBDLFile_Load);
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFolderContain.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileName.Properties)).EndInit();
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkMat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMaVatLieu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtThongSo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonVi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExtension.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip mnuMenu;
        private System.Windows.Forms.ToolStripButton btnSave;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit txtFolderContain;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.MemoEdit txtFileName;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.ComboBox cboGetType;
        private System.Windows.Forms.GroupBox gbFilter;
        private DevExpress.XtraEditors.MemoEdit txtThongSo;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.MemoEdit txtDonVi;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.CheckEdit chkMaVatLieu;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.MemoEdit txtDescription;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.ComboBox cboFileType;
        private DevExpress.XtraEditors.CheckEdit chkMat;
        private DevExpress.XtraEditors.CheckEdit chkTem;
        private DevExpress.XtraEditors.MemoEdit txtExtension;
        private DevExpress.XtraEditors.LabelControl labelControl4;
    }
}