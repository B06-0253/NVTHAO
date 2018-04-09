namespace BMS
{
    partial class frmConvertModule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConvertModule));
            this.label1 = new System.Windows.Forms.Label();
            this.txtOldModule = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNewModule = new System.Windows.Forms.TextBox();
            this.mnuMenu = new System.Windows.Forms.ToolStrip();
            this.btnConvert = new System.Windows.Forms.ToolStripButton();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.mnuMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã cũ";
            // 
            // txtOldModule
            // 
            this.txtOldModule.Location = new System.Drawing.Point(104, 51);
            this.txtOldModule.Name = "txtOldModule";
            this.txtOldModule.Size = new System.Drawing.Size(154, 20);
            this.txtOldModule.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã mới";
            // 
            // txtNewModule
            // 
            this.txtNewModule.Location = new System.Drawing.Point(104, 89);
            this.txtNewModule.Name = "txtNewModule";
            this.txtNewModule.Size = new System.Drawing.Size(154, 20);
            this.txtNewModule.TabIndex = 1;
            // 
            // mnuMenu
            // 
            this.mnuMenu.AutoSize = false;
            this.mnuMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.mnuMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnConvert});
            this.mnuMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mnuMenu.Size = new System.Drawing.Size(371, 37);
            this.mnuMenu.TabIndex = 2;
            this.mnuMenu.Text = "toolStrip2";
            // 
            // btnConvert
            // 
            this.btnConvert.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvert.Image = ((System.Drawing.Image)(resources.GetObject("btnConvert.Image")));
            this.btnConvert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(73, 33);
            this.btnConvert.Tag = "";
            this.btnConvert.Text = "Chuyển đổi";
            this.btnConvert.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnConvert.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnBrowser
            // 
            this.btnBrowser.Location = new System.Drawing.Point(261, 49);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(25, 23);
            this.btnBrowser.TabIndex = 3;
            this.btnBrowser.Text = "...";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // frmConvertModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 131);
            this.Controls.Add(this.btnBrowser);
            this.Controls.Add(this.mnuMenu);
            this.Controls.Add(this.txtNewModule);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOldModule);
            this.Controls.Add(this.label1);
            this.Name = "frmConvertModule";
            this.Text = "Chuyển module cũ sang module mới";
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOldModule;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNewModule;
        private System.Windows.Forms.ToolStrip mnuMenu;
        private System.Windows.Forms.ToolStripButton btnConvert;
        private System.Windows.Forms.Button btnBrowser;
    }
}