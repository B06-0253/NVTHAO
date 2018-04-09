namespace BMS
{
    partial class frmPartsGeneral
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPartsGeneral));
            this.mnuMenu = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSaveAndClose = new System.Windows.Forms.ToolStripButton();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtQtyMin = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.txtPrice = new DevExpress.XtraEditors.TextEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtName = new DevExpress.XtraEditors.MemoEdit();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.txtUnit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtHang = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtQtyDM = new DevExpress.XtraEditors.TextEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.txtProjectPercent = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtQty = new DevExpress.XtraEditors.TextEdit();
            this.mnuMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQtyMin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQtyDM.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjectPercent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty.Properties)).BeginInit();
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
            this.mnuMenu.Size = new System.Drawing.Size(630, 41);
            this.mnuMenu.TabIndex = 1;
            this.mnuMenu.Text = "toolStrip2";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(29, 33);
            this.btnSave.Tag = "frmPartAccessories_Save";
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
            this.btnSaveAndClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAndClose.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveAndClose.Image")));
            this.btnSaveAndClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.Size = new System.Drawing.Size(77, 33);
            this.btnSaveAndClose.Tag = "frmPartAccessories_Save";
            this.btnSaveAndClose.Text = "Ghi && Thoát";
            this.btnSaveAndClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSaveAndClose.Click += new System.EventHandler(this.btnSaveAndClose_Click);
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(54, 52);
            this.txtCode.Name = "txtCode";
            this.txtCode.Properties.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(295, 20);
            this.txtCode.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(34, 55);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(14, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Mã";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(30, 96);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(18, 13);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Tên";
            // 
            // txtQtyMin
            // 
            this.txtQtyMin.Location = new System.Drawing.Point(294, 140);
            this.txtQtyMin.Name = "txtQtyMin";
            this.txtQtyMin.Properties.Mask.EditMask = "n2";
            this.txtQtyMin.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtQtyMin.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtQtyMin.Size = new System.Drawing.Size(116, 20);
            this.txtQtyMin.TabIndex = 15;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(204, 143);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(84, 13);
            this.labelControl8.TabIndex = 10;
            this.labelControl8.Text = "Số lượng tối thiểu";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(54, 140);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Properties.Mask.EditMask = "n0";
            this.txtPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtPrice.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtPrice.Properties.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(105, 20);
            this.txtPrice.TabIndex = 14;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(165, 143);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(21, 13);
            this.labelControl9.TabIndex = 12;
            this.labelControl9.Text = "VNĐ";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(33, 143);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(15, 13);
            this.labelControl5.TabIndex = 13;
            this.labelControl5.Text = "Giá";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(54, 87);
            this.txtName.Name = "txtName";
            this.txtName.Properties.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(564, 40);
            this.txtName.TabIndex = 17;
            // 
            // cboType
            // 
            this.cboType.FormattingEnabled = true;
            this.cboType.Items.AddRange(new object[] {
            "Vật tư tiêu hao",
            "Vật tư phụ"});
            this.cboType.Location = new System.Drawing.Point(380, 51);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(238, 21);
            this.cboType.TabIndex = 156;
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(357, 55);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(19, 13);
            this.labelControl12.TabIndex = 155;
            this.labelControl12.Text = "Loại";
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(513, 140);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Properties.ReadOnly = true;
            this.txtUnit.Size = new System.Drawing.Size(105, 20);
            this.txtUnit.TabIndex = 157;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(477, 143);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(31, 13);
            this.labelControl3.TabIndex = 158;
            this.labelControl3.Text = "Đơn vị";
            // 
            // txtHang
            // 
            this.txtHang.Location = new System.Drawing.Point(54, 220);
            this.txtHang.Name = "txtHang";
            this.txtHang.Properties.ReadOnly = true;
            this.txtHang.Size = new System.Drawing.Size(374, 20);
            this.txtHang.TabIndex = 159;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(23, 223);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(25, 13);
            this.labelControl4.TabIndex = 160;
            this.labelControl4.Text = "Hãng";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(200, 184);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(88, 13);
            this.labelControl7.TabIndex = 10;
            this.labelControl7.Text = "Số lượng định mức";
            // 
            // txtQtyDM
            // 
            this.txtQtyDM.Location = new System.Drawing.Point(294, 181);
            this.txtQtyDM.Name = "txtQtyDM";
            this.txtQtyDM.Properties.Mask.EditMask = "n2";
            this.txtQtyDM.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtQtyDM.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtQtyDM.Size = new System.Drawing.Size(116, 20);
            this.txtQtyDM.TabIndex = 15;
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(6, 184);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(42, 13);
            this.labelControl11.TabIndex = 10;
            this.labelControl11.Text = "% dự án";
            // 
            // txtProjectPercent
            // 
            this.txtProjectPercent.Location = new System.Drawing.Point(54, 181);
            this.txtProjectPercent.Name = "txtProjectPercent";
            this.txtProjectPercent.Properties.Mask.EditMask = "n4";
            this.txtProjectPercent.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtProjectPercent.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtProjectPercent.Size = new System.Drawing.Size(105, 20);
            this.txtProjectPercent.TabIndex = 15;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(440, 184);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(68, 13);
            this.labelControl6.TabIndex = 10;
            this.labelControl6.Text = "SL tồn thực tế";
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(513, 181);
            this.txtQty.Name = "txtQty";
            this.txtQty.Properties.Mask.EditMask = "n2";
            this.txtQty.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtQty.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.txtQty.Size = new System.Drawing.Size(105, 20);
            this.txtQty.TabIndex = 15;
            // 
            // frmPartsGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 263);
            this.Controls.Add(this.txtHang);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtProjectPercent);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.txtQtyDM);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.txtQtyMin);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.mnuMenu);
            this.Name = "frmPartsGeneral";
            this.Text = "VẬT TƯ PHỤ";
            this.Load += new System.EventHandler(this.frmPartAccessories_Load);
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQtyMin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQtyDM.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjectPercent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtQty.Properties)).EndInit();
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
        private DevExpress.XtraEditors.TextEdit txtQtyMin;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit txtPrice;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.MemoEdit txtName;
        private System.Windows.Forms.ComboBox cboType;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.TextEdit txtUnit;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtHang;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtQtyDM;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.TextEdit txtProjectPercent;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtQty;
    }
}