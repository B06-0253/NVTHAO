namespace BMS
{
    partial class frmDNNK
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDNNK));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grdModule = new DevExpress.XtraGrid.GridControl();
            this.grvModule = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMError = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMKPH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMHang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMNameHD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMCodeHD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMCVersion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMUnit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMPriceHD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mnuMenu = new System.Windows.Forms.ToolStrip();
            this.btnExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdModule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvModule)).BeginInit();
            this.mnuMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(2, 43);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grdModule);
            this.splitContainer1.Size = new System.Drawing.Size(927, 433);
            this.splitContainer1.SplitterDistance = 636;
            this.splitContainer1.TabIndex = 0;
            // 
            // grdModule
            // 
            this.grdModule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdModule.Location = new System.Drawing.Point(3, 3);
            this.grdModule.MainView = this.grvModule;
            this.grdModule.Name = "grdModule";
            this.grdModule.Size = new System.Drawing.Size(630, 427);
            this.grdModule.TabIndex = 1;
            this.grdModule.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvModule});
            // 
            // grvModule
            // 
            this.grvModule.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMID,
            this.colMCode,
            this.colMName,
            this.colMError,
            this.colMKPH,
            this.colMHang,
            this.colMQty,
            this.colMNameHD,
            this.colMCodeHD,
            this.colMStatus,
            this.colMType,
            this.colMCVersion,
            this.colMUnit,
            this.colMPriceHD});
            this.grvModule.GridControl = this.grdModule;
            this.grvModule.Name = "grvModule";
            this.grvModule.OptionsView.ColumnAutoWidth = false;
            this.grvModule.OptionsView.ShowGroupPanel = false;
            // 
            // colMID
            // 
            this.colMID.Caption = "ID";
            this.colMID.FieldName = "ID";
            this.colMID.Name = "colMID";
            // 
            // colMCode
            // 
            this.colMCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMCode.AppearanceHeader.Options.UseFont = true;
            this.colMCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colMCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMCode.Caption = "Mã";
            this.colMCode.FieldName = "Code";
            this.colMCode.Name = "colMCode";
            this.colMCode.OptionsColumn.AllowEdit = false;
            this.colMCode.Visible = true;
            this.colMCode.VisibleIndex = 2;
            this.colMCode.Width = 77;
            // 
            // colMName
            // 
            this.colMName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMName.AppearanceHeader.Options.UseFont = true;
            this.colMName.AppearanceHeader.Options.UseTextOptions = true;
            this.colMName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMName.Caption = "Tên module";
            this.colMName.FieldName = "Name";
            this.colMName.Name = "colMName";
            this.colMName.OptionsColumn.AllowEdit = false;
            this.colMName.Visible = true;
            this.colMName.VisibleIndex = 3;
            this.colMName.Width = 248;
            // 
            // colMError
            // 
            this.colMError.AppearanceCell.Options.UseTextOptions = true;
            this.colMError.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colMError.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMError.AppearanceHeader.Options.UseFont = true;
            this.colMError.AppearanceHeader.Options.UseTextOptions = true;
            this.colMError.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMError.Caption = "Lỗi";
            this.colMError.FieldName = "QtyError";
            this.colMError.Name = "colMError";
            this.colMError.OptionsColumn.AllowEdit = false;
            this.colMError.Visible = true;
            this.colMError.VisibleIndex = 6;
            this.colMError.Width = 47;
            // 
            // colMKPH
            // 
            this.colMKPH.AppearanceCell.Options.UseTextOptions = true;
            this.colMKPH.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colMKPH.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMKPH.AppearanceHeader.Options.UseFont = true;
            this.colMKPH.AppearanceHeader.Options.UseTextOptions = true;
            this.colMKPH.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMKPH.Caption = "Không phù hợp";
            this.colMKPH.FieldName = "QtyKPH";
            this.colMKPH.Name = "colMKPH";
            this.colMKPH.OptionsColumn.AllowEdit = false;
            this.colMKPH.Visible = true;
            this.colMKPH.VisibleIndex = 7;
            this.colMKPH.Width = 110;
            // 
            // colMHang
            // 
            this.colMHang.AppearanceCell.Options.UseTextOptions = true;
            this.colMHang.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMHang.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMHang.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMHang.AppearanceHeader.Options.UseFont = true;
            this.colMHang.AppearanceHeader.Options.UseTextOptions = true;
            this.colMHang.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMHang.Caption = "Hãng";
            this.colMHang.FieldName = "Hang";
            this.colMHang.Name = "colMHang";
            this.colMHang.OptionsColumn.AllowEdit = false;
            this.colMHang.Visible = true;
            this.colMHang.VisibleIndex = 4;
            this.colMHang.Width = 53;
            // 
            // colMQty
            // 
            this.colMQty.AppearanceCell.Options.UseTextOptions = true;
            this.colMQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colMQty.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.colMQty.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMQty.AppearanceHeader.Options.UseFont = true;
            this.colMQty.AppearanceHeader.Options.UseTextOptions = true;
            this.colMQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMQty.Caption = "Số lượng";
            this.colMQty.FieldName = "Qty";
            this.colMQty.Name = "colMQty";
            this.colMQty.Visible = true;
            this.colMQty.VisibleIndex = 5;
            this.colMQty.Width = 65;
            // 
            // colMNameHD
            // 
            this.colMNameHD.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMNameHD.AppearanceHeader.Options.UseFont = true;
            this.colMNameHD.AppearanceHeader.Options.UseTextOptions = true;
            this.colMNameHD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMNameHD.Caption = "Tên theo HĐ";
            this.colMNameHD.FieldName = "NameHD";
            this.colMNameHD.Name = "colMNameHD";
            this.colMNameHD.Visible = true;
            this.colMNameHD.VisibleIndex = 0;
            this.colMNameHD.Width = 194;
            // 
            // colMCodeHD
            // 
            this.colMCodeHD.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMCodeHD.AppearanceHeader.Options.UseFont = true;
            this.colMCodeHD.AppearanceHeader.Options.UseTextOptions = true;
            this.colMCodeHD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMCodeHD.Caption = "Mã theo HĐ";
            this.colMCodeHD.FieldName = "CodeHD";
            this.colMCodeHD.Name = "colMCodeHD";
            this.colMCodeHD.Visible = true;
            this.colMCodeHD.VisibleIndex = 1;
            this.colMCodeHD.Width = 94;
            // 
            // colMStatus
            // 
            this.colMStatus.Caption = "Status";
            this.colMStatus.FieldName = "Status";
            this.colMStatus.Name = "colMStatus";
            // 
            // colMType
            // 
            this.colMType.Caption = "Type";
            this.colMType.FieldName = "Type";
            this.colMType.Name = "colMType";
            // 
            // colMCVersion
            // 
            this.colMCVersion.Caption = "CVersion";
            this.colMCVersion.FieldName = "CVersion";
            this.colMCVersion.Name = "colMCVersion";
            // 
            // colMUnit
            // 
            this.colMUnit.Caption = "Unit";
            this.colMUnit.FieldName = "Unit";
            this.colMUnit.Name = "colMUnit";
            // 
            // colMPriceHD
            // 
            this.colMPriceHD.AppearanceCell.Options.UseTextOptions = true;
            this.colMPriceHD.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colMPriceHD.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colMPriceHD.AppearanceHeader.Options.UseFont = true;
            this.colMPriceHD.AppearanceHeader.Options.UseTextOptions = true;
            this.colMPriceHD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colMPriceHD.Caption = "Giá theo HĐ";
            this.colMPriceHD.DisplayFormat.FormatString = "n2";
            this.colMPriceHD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMPriceHD.FieldName = "PriceHD";
            this.colMPriceHD.Name = "colMPriceHD";
            this.colMPriceHD.OptionsColumn.AllowEdit = false;
            this.colMPriceHD.Visible = true;
            this.colMPriceHD.VisibleIndex = 8;
            this.colMPriceHD.Width = 88;
            // 
            // mnuMenu
            // 
            this.mnuMenu.AutoSize = false;
            this.mnuMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.mnuMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnExcel,
            this.toolStripSeparator1});
            this.mnuMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuMenu.Size = new System.Drawing.Size(933, 41);
            this.mnuMenu.TabIndex = 222;
            this.mnuMenu.Text = "toolStrip2";
            // 
            // btnExcel
            // 
            this.btnExcel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(69, 33);
            this.btnExcel.Tag = "";
            this.btnExcel.Text = "Xuất Excel";
            this.btnExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // frmDNNK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 479);
            this.Controls.Add(this.mnuMenu);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmDNNK";
            this.Text = "ĐỀ NGHỊ NHẬP KHO";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDNNK_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdModule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvModule)).EndInit();
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraGrid.GridControl grdModule;
        private DevExpress.XtraGrid.Views.Grid.GridView grvModule;
        private DevExpress.XtraGrid.Columns.GridColumn colMID;
        private DevExpress.XtraGrid.Columns.GridColumn colMCode;
        private DevExpress.XtraGrid.Columns.GridColumn colMName;
        private DevExpress.XtraGrid.Columns.GridColumn colMError;
        private DevExpress.XtraGrid.Columns.GridColumn colMKPH;
        private DevExpress.XtraGrid.Columns.GridColumn colMHang;
        private DevExpress.XtraGrid.Columns.GridColumn colMQty;
        private DevExpress.XtraGrid.Columns.GridColumn colMNameHD;
        private DevExpress.XtraGrid.Columns.GridColumn colMCodeHD;
        private DevExpress.XtraGrid.Columns.GridColumn colMStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colMType;
        private DevExpress.XtraGrid.Columns.GridColumn colMCVersion;
        private DevExpress.XtraGrid.Columns.GridColumn colMUnit;
        private DevExpress.XtraGrid.Columns.GridColumn colMPriceHD;
        private System.Windows.Forms.ToolStrip mnuMenu;
        private System.Windows.Forms.ToolStripButton btnExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}