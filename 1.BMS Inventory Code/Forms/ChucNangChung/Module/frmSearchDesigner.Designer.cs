namespace BMS
{
    partial class frmSearchDesigner
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
            this.label6 = new System.Windows.Forms.Label();
            this.txtThietKeCoKhi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtThietKeDienTu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtThietKeDien = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 164;
            this.label6.Text = "Thiết kế cơ khí:";
            // 
            // txtThietKeCoKhi
            // 
            this.txtThietKeCoKhi.Location = new System.Drawing.Point(106, 12);
            this.txtThietKeCoKhi.Name = "txtThietKeCoKhi";
            this.txtThietKeCoKhi.ReadOnly = true;
            this.txtThietKeCoKhi.Size = new System.Drawing.Size(460, 20);
            this.txtThietKeCoKhi.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 164;
            this.label1.Text = "Thiết kế điện tử:";
            // 
            // txtThietKeDienTu
            // 
            this.txtThietKeDienTu.Location = new System.Drawing.Point(106, 69);
            this.txtThietKeDienTu.Multiline = true;
            this.txtThietKeDienTu.Name = "txtThietKeDienTu";
            this.txtThietKeDienTu.ReadOnly = true;
            this.txtThietKeDienTu.Size = new System.Drawing.Size(460, 149);
            this.txtThietKeDienTu.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 164;
            this.label2.Text = "Thiết kế điện:";
            // 
            // txtThietKeDien
            // 
            this.txtThietKeDien.Location = new System.Drawing.Point(106, 39);
            this.txtThietKeDien.Name = "txtThietKeDien";
            this.txtThietKeDien.ReadOnly = true;
            this.txtThietKeDien.Size = new System.Drawing.Size(460, 20);
            this.txtThietKeDien.TabIndex = 4;
            // 
            // frmSearchDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 228);
            this.Controls.Add(this.txtThietKeDienTu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtThietKeDien);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtThietKeCoKhi);
            this.Controls.Add(this.label6);
            this.Name = "frmSearchDesigner";
            this.Text = "Danh sách nhân viên thiết kế";
            this.Load += new System.EventHandler(this.frmSearchModule_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtThietKeCoKhi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtThietKeDienTu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtThietKeDien;
    }
}