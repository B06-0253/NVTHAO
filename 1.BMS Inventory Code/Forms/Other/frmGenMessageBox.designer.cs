namespace BMS
{
    partial class frmGenMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGenMessageBox));
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtSysMessage = new System.Windows.Forms.TextBox();
            this.picDetail = new System.Windows.Forms.PictureBox();
            this.lblUserMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // picIcon
            // 
            this.picIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picIcon.Location = new System.Drawing.Point(8, 9);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(32, 34);
            this.picIcon.TabIndex = 0;
            this.picIcon.TabStop = false;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.SystemColors.Control;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.Location = new System.Drawing.Point(113, 81);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtSysMessage
            // 
            this.txtSysMessage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSysMessage.Location = new System.Drawing.Point(3, 125);
            this.txtSysMessage.Multiline = true;
            this.txtSysMessage.Name = "txtSysMessage";
            this.txtSysMessage.ReadOnly = true;
            this.txtSysMessage.Size = new System.Drawing.Size(289, 197);
            this.txtSysMessage.TabIndex = 3;
            // 
            // picDetail
            // 
            this.picDetail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picDetail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDetail.ErrorImage = ((System.Drawing.Image)(resources.GetObject("picDetail.ErrorImage")));
            this.picDetail.Image = ((System.Drawing.Image)(resources.GetObject("picDetail.Image")));
            this.picDetail.Location = new System.Drawing.Point(3, 108);
            this.picDetail.Name = "picDetail";
            this.picDetail.Size = new System.Drawing.Size(16, 16);
            this.picDetail.TabIndex = 4;
            this.picDetail.TabStop = false;
            this.picDetail.Click += new System.EventHandler(this.picDetail_Click);
            // 
            // lblUserMessage
            // 
            this.lblUserMessage.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserMessage.Location = new System.Drawing.Point(48, 12);
            this.lblUserMessage.Name = "lblUserMessage";
            this.lblUserMessage.Size = new System.Drawing.Size(235, 56);
            this.lblUserMessage.TabIndex = 5;
            this.lblUserMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmGenMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(294, 125);
            this.Controls.Add(this.lblUserMessage);
            this.Controls.Add(this.picDetail);
            this.Controls.Add(this.txtSysMessage);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.picIcon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmGenMessageBox";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MessageBox";
            this.Load += new System.EventHandler(this.frmGenMessageBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox txtSysMessage;
        private System.Windows.Forms.PictureBox picDetail;
        private System.Windows.Forms.Label lblUserMessage;

    }
}