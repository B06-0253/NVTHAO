namespace BMS
{
    partial class frmConfig
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
            this.btnConfigGeneral = new System.Windows.Forms.Button();
            this.btnModulePartPrice = new System.Windows.Forms.Button();
            this.btnCreateCTTM = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnConfigGeneral
            // 
            this.btnConfigGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfigGeneral.Location = new System.Drawing.Point(46, 16);
            this.btnConfigGeneral.Name = "btnConfigGeneral";
            this.btnConfigGeneral.Size = new System.Drawing.Size(258, 40);
            this.btnConfigGeneral.TabIndex = 0;
            this.btnConfigGeneral.Text = "CẤU HÌNH CHUNG";
            this.btnConfigGeneral.UseVisualStyleBackColor = true;
            this.btnConfigGeneral.Click += new System.EventHandler(this.btnConfigGeneral_Click);
            // 
            // btnModulePartPrice
            // 
            this.btnModulePartPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModulePartPrice.Location = new System.Drawing.Point(46, 60);
            this.btnModulePartPrice.Name = "btnModulePartPrice";
            this.btnModulePartPrice.Size = new System.Drawing.Size(258, 40);
            this.btnModulePartPrice.TabIndex = 0;
            this.btnModulePartPrice.Text = "CẤU HÌNH GIÁ VẬT LIỆU";
            this.btnModulePartPrice.UseVisualStyleBackColor = true;
            this.btnModulePartPrice.Click += new System.EventHandler(this.btnModulePartPrice_Click);
            // 
            // btnCreateCTTM
            // 
            this.btnCreateCTTM.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateCTTM.Location = new System.Drawing.Point(46, 104);
            this.btnCreateCTTM.Name = "btnCreateCTTM";
            this.btnCreateCTTM.Size = new System.Drawing.Size(258, 40);
            this.btnCreateCTTM.TabIndex = 2;
            this.btnCreateCTTM.Tag = "frmTaoCTTK_Config";
            this.btnCreateCTTM.Text = "CẤU HÌNH CÂY THƯ MỤC";
            this.btnCreateCTTM.UseVisualStyleBackColor = true;
            this.btnCreateCTTM.Click += new System.EventHandler(this.btnCreateCTTM_Click);
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 157);
            this.Controls.Add(this.btnCreateCTTM);
            this.Controls.Add(this.btnModulePartPrice);
            this.Controls.Add(this.btnConfigGeneral);
            this.Name = "frmConfig";
            this.Text = "CẤU HÌNH HỆ THỐNG";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConfigGeneral;
        private System.Windows.Forms.Button btnModulePartPrice;
        private System.Windows.Forms.Button btnCreateCTTM;
    }
}