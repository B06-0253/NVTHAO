namespace BMS
{
   partial class frmCauHinhCTTK
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
         if(disposing && (components != null))
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
          DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
          DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
          DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
          DevExpress.Utils.ToolTipSeparatorItem toolTipSeparatorItem1 = new DevExpress.Utils.ToolTipSeparatorItem();
          DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCauHinhCTTK));
          this.mmeText = new DevExpress.XtraEditors.MemoEdit();
          this.mnuMenu = new System.Windows.Forms.ToolStrip();
          this.btnNewGroup = new System.Windows.Forms.ToolStripButton();
          this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
          this.btnClose = new System.Windows.Forms.ToolStripButton();
          ((System.ComponentModel.ISupportInitialize)(this.mmeText.Properties)).BeginInit();
          this.mnuMenu.SuspendLayout();
          this.SuspendLayout();
          // 
          // mmeText
          // 
          this.mmeText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                      | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
          this.mmeText.Location = new System.Drawing.Point(1, 45);
          this.mmeText.Name = "mmeText";
          this.mmeText.Size = new System.Drawing.Size(347, 134);
          toolTipTitleItem1.Text = "Cách nhau bởi dấu phẩy (,)";
          toolTipItem1.LeftIndent = 6;
          toolTipItem1.Text = "Cách nhau bởi dấu phẩy (,)";
          toolTipTitleItem2.LeftIndent = 6;
          toolTipTitleItem2.Text = "Cách nhau bởi dấu phẩy (,)";
          superToolTip1.Items.Add(toolTipTitleItem1);
          superToolTip1.Items.Add(toolTipItem1);
          superToolTip1.Items.Add(toolTipSeparatorItem1);
          superToolTip1.Items.Add(toolTipTitleItem2);
          this.mmeText.SuperTip = superToolTip1;
          this.mmeText.TabIndex = 0;
          this.mmeText.ToolTip = "Cách nhau bởi dấu phẩy";
          // 
          // mnuMenu
          // 
          this.mnuMenu.AutoSize = false;
          this.mnuMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
          this.mnuMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.mnuMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
          this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewGroup,
            this.toolStripSeparator1,
            this.btnClose});
          this.mnuMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
          this.mnuMenu.Location = new System.Drawing.Point(0, 0);
          this.mnuMenu.Name = "mnuMenu";
          this.mnuMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
          this.mnuMenu.Size = new System.Drawing.Size(348, 42);
          this.mnuMenu.TabIndex = 23;
          this.mnuMenu.Text = "toolStrip2";
          // 
          // btnNewGroup
          // 
          this.btnNewGroup.Image = ((System.Drawing.Image)(resources.GetObject("btnNewGroup.Image")));
          this.btnNewGroup.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.btnNewGroup.Name = "btnNewGroup";
          this.btnNewGroup.Size = new System.Drawing.Size(26, 33);
          this.btnNewGroup.Tag = "";
          this.btnNewGroup.Text = "&Ghi";
          this.btnNewGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
          this.btnNewGroup.Click += new System.EventHandler(this.btnNewGroup_Click);
          // 
          // toolStripSeparator1
          // 
          this.toolStripSeparator1.AutoSize = false;
          this.toolStripSeparator1.Name = "toolStripSeparator1";
          this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
          // 
          // btnClose
          // 
          this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
          this.btnClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
          this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.btnClose.Name = "btnClose";
          this.btnClose.Size = new System.Drawing.Size(39, 33);
          this.btnClose.Text = "Thoát";
          this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
          this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
          // 
          // frmCauHinhCTTK
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(348, 179);
          this.Controls.Add(this.mnuMenu);
          this.Controls.Add(this.mmeText);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
          this.Name = "frmCauHinhCTTK";
          this.Text = "Cấu hình cấu trúc thiết kế";
          this.Load += new System.EventHandler(this.frmCauHinhCTTK_Load);
          ((System.ComponentModel.ISupportInitialize)(this.mmeText.Properties)).EndInit();
          this.mnuMenu.ResumeLayout(false);
          this.mnuMenu.PerformLayout();
          this.ResumeLayout(false);

      }

      #endregion

      private DevExpress.XtraEditors.MemoEdit mmeText;
      private System.Windows.Forms.ToolStrip mnuMenu;
      private System.Windows.Forms.ToolStripButton btnNewGroup;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripButton btnClose;

   }
}