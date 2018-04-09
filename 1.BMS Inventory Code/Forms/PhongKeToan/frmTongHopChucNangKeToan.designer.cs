namespace BMS
{
    partial class frmTongHopChucNangKeToan
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
            this.btnExportSalary = new System.Windows.Forms.Button();
            this.btnExportFormBank = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExportSalary
            // 
            this.btnExportSalary.Location = new System.Drawing.Point(12, 12);
            this.btnExportSalary.Name = "btnExportSalary";
            this.btnExportSalary.Size = new System.Drawing.Size(178, 23);
            this.btnExportSalary.TabIndex = 0;
            this.btnExportSalary.Text = "XUẤT LƯƠNG NHÂN VIÊN";
            this.btnExportSalary.UseVisualStyleBackColor = true;
            this.btnExportSalary.Click += new System.EventHandler(this.btnExportSalary_Click);
            // 
            // btnExportFormBank
            // 
            this.btnExportFormBank.Location = new System.Drawing.Point(12, 52);
            this.btnExportFormBank.Name = "btnExportFormBank";
            this.btnExportFormBank.Size = new System.Drawing.Size(178, 23);
            this.btnExportFormBank.TabIndex = 0;
            this.btnExportFormBank.Text = "XUẤT BIỂU MẪU NGÂN HÀNG";
            this.btnExportFormBank.UseVisualStyleBackColor = true;
            this.btnExportFormBank.Click += new System.EventHandler(this.btnExportFormBank_Click);
            // 
            // frmTongHopChucNangKeToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 282);
            this.Controls.Add(this.btnExportFormBank);
            this.Controls.Add(this.btnExportSalary);
            this.Name = "frmTongHopChucNangKeToan";
            this.Text = "TỔNG HỢP CÁC CHỨC NĂNG KẾ TOÁN ";
            this.Load += new System.EventHandler(this.frmTongHopChucNangKeToan_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExportSalary;
        private System.Windows.Forms.Button btnExportFormBank;
    }
}