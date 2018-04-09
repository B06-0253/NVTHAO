namespace BMS
{
    partial class frmCompareIPT
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
            this.txtOldValue = new System.Windows.Forms.TextBox();
            this.txtIPTValue = new System.Windows.Forms.TextBox();
            this.txtRightValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtOldValue
            // 
            this.txtOldValue.Location = new System.Drawing.Point(28, 58);
            this.txtOldValue.Multiline = true;
            this.txtOldValue.Name = "txtOldValue";
            this.txtOldValue.ReadOnly = true;
            this.txtOldValue.Size = new System.Drawing.Size(283, 31);
            this.txtOldValue.TabIndex = 0;
            // 
            // txtIPTValue
            // 
            this.txtIPTValue.Location = new System.Drawing.Point(343, 58);
            this.txtIPTValue.Multiline = true;
            this.txtIPTValue.Name = "txtIPTValue";
            this.txtIPTValue.ReadOnly = true;
            this.txtIPTValue.Size = new System.Drawing.Size(283, 31);
            this.txtIPTValue.TabIndex = 0;
            // 
            // txtRightValue
            // 
            this.txtRightValue.Location = new System.Drawing.Point(28, 118);
            this.txtRightValue.Multiline = true;
            this.txtRightValue.Name = "txtRightValue";
            this.txtRightValue.Size = new System.Drawing.Size(598, 44);
            this.txtRightValue.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(297, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Giá trị trong cơ sở dữ liệu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(349, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Giá trị trong IProperties của file ipt";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Giá trị đúng";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(263, 168);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(103, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Ghi";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmCompareIPT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 199);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIPTValue);
            this.Controls.Add(this.txtRightValue);
            this.Controls.Add(this.txtOldValue);
            this.Name = "frmCompareIPT";
            this.Text = "Sai khác";
            this.Load += new System.EventHandler(this.frmCompareIPT_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOldValue;
        private System.Windows.Forms.TextBox txtIPTValue;
        private System.Windows.Forms.TextBox txtRightValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
    }
}