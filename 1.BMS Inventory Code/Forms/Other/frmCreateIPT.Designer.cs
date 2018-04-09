namespace BMS
{
    partial class frmCreateIPT
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.btnChooseMat = new System.Windows.Forms.Button();
            this.txtDMVTPath = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.grvDMVTchuan = new System.Windows.Forms.DataGridView();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colF3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colF5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colF6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colF7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colF8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colF9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colF11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Label9 = new System.Windows.Forms.Label();
            this.btnCreateIPT = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grvDMVTchuan)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(138, 14);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(314, 20);
            this.txtCode.TabIndex = 20;
            // 
            // btnChooseMat
            // 
            this.btnChooseMat.BackColor = System.Drawing.Color.White;
            this.btnChooseMat.Location = new System.Drawing.Point(21, 12);
            this.btnChooseMat.Name = "btnChooseMat";
            this.btnChooseMat.Size = new System.Drawing.Size(110, 23);
            this.btnChooseMat.TabIndex = 19;
            this.btnChooseMat.Text = "Chọn bản thiết kế";
            this.btnChooseMat.UseVisualStyleBackColor = false;
            this.btnChooseMat.Click += new System.EventHandler(this.btnChooseMat_Click);
            // 
            // txtDMVTPath
            // 
            this.txtDMVTPath.Location = new System.Drawing.Point(49, 43);
            this.txtDMVTPath.Name = "txtDMVTPath";
            this.txtDMVTPath.ReadOnly = true;
            this.txtDMVTPath.Size = new System.Drawing.Size(682, 20);
            this.txtDMVTPath.TabIndex = 32;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(4, 46);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(38, 13);
            this.Label6.TabIndex = 31;
            this.Label6.Text = "DMVT";
            // 
            // grvDMVTchuan
            // 
            this.grvDMVTchuan.AllowUserToAddRows = false;
            this.grvDMVTchuan.AllowUserToResizeRows = false;
            this.grvDMVTchuan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grvDMVTchuan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grvDMVTchuan.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvDMVTchuan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grvDMVTchuan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvDMVTchuan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.DataGridViewTextBoxColumn3,
            this.colF3,
            this.DataGridViewTextBoxColumn6,
            this.colF5,
            this.colF6,
            this.colF7,
            this.colF8,
            this.colF9,
            this.DataGridViewTextBoxColumn7,
            this.colF11});
            this.grvDMVTchuan.Location = new System.Drawing.Point(7, 101);
            this.grvDMVTchuan.Name = "grvDMVTchuan";
            this.grvDMVTchuan.ReadOnly = true;
            this.grvDMVTchuan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grvDMVTchuan.Size = new System.Drawing.Size(860, 378);
            this.grvDMVTchuan.TabIndex = 34;
            // 
            // colSTT
            // 
            this.colSTT.DataPropertyName = "F1";
            this.colSTT.HeaderText = "STT";
            this.colSTT.Name = "colSTT";
            this.colSTT.ReadOnly = true;
            this.colSTT.Width = 53;
            // 
            // DataGridViewTextBoxColumn3
            // 
            this.DataGridViewTextBoxColumn3.DataPropertyName = "F2";
            this.DataGridViewTextBoxColumn3.HeaderText = "Tên vật tư";
            this.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3";
            this.DataGridViewTextBoxColumn3.ReadOnly = true;
            this.DataGridViewTextBoxColumn3.Width = 81;
            // 
            // colF3
            // 
            this.colF3.DataPropertyName = "F3";
            this.colF3.HeaderText = "Thông số";
            this.colF3.Name = "colF3";
            this.colF3.ReadOnly = true;
            this.colF3.Width = 77;
            // 
            // DataGridViewTextBoxColumn6
            // 
            this.DataGridViewTextBoxColumn6.DataPropertyName = "F4";
            this.DataGridViewTextBoxColumn6.HeaderText = "Mã vật tư";
            this.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6";
            this.DataGridViewTextBoxColumn6.ReadOnly = true;
            this.DataGridViewTextBoxColumn6.Width = 77;
            // 
            // colF5
            // 
            this.colF5.DataPropertyName = "F5";
            this.colF5.HeaderText = "Mã vật liệu";
            this.colF5.Name = "colF5";
            this.colF5.ReadOnly = true;
            this.colF5.Width = 84;
            // 
            // colF6
            // 
            this.colF6.DataPropertyName = "F6";
            this.colF6.HeaderText = "ĐV";
            this.colF6.Name = "colF6";
            this.colF6.ReadOnly = true;
            this.colF6.Width = 47;
            // 
            // colF7
            // 
            this.colF7.DataPropertyName = "F7";
            this.colF7.HeaderText = "SL";
            this.colF7.Name = "colF7";
            this.colF7.ReadOnly = true;
            this.colF7.Width = 45;
            // 
            // colF8
            // 
            this.colF8.DataPropertyName = "F8";
            this.colF8.HeaderText = "VL";
            this.colF8.Name = "colF8";
            this.colF8.ReadOnly = true;
            this.colF8.Width = 45;
            // 
            // colF9
            // 
            this.colF9.DataPropertyName = "F9";
            this.colF9.HeaderText = "KL";
            this.colF9.Name = "colF9";
            this.colF9.ReadOnly = true;
            this.colF9.Width = 45;
            // 
            // DataGridViewTextBoxColumn7
            // 
            this.DataGridViewTextBoxColumn7.DataPropertyName = "F10";
            this.DataGridViewTextBoxColumn7.HeaderText = "Hãng sản xuất";
            this.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7";
            this.DataGridViewTextBoxColumn7.ReadOnly = true;
            this.DataGridViewTextBoxColumn7.Width = 101;
            // 
            // colF11
            // 
            this.colF11.DataPropertyName = "F11";
            this.colF11.HeaderText = "Ghi chú";
            this.colF11.Name = "colF11";
            this.colF11.ReadOnly = true;
            this.colF11.Width = 69;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(8, 82);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(89, 13);
            this.Label9.TabIndex = 33;
            this.Label9.Text = "Danh sách vật tư";
            // 
            // btnCreateIPT
            // 
            this.btnCreateIPT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateIPT.BackColor = System.Drawing.Color.White;
            this.btnCreateIPT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateIPT.Location = new System.Drawing.Point(776, 69);
            this.btnCreateIPT.Name = "btnCreateIPT";
            this.btnCreateIPT.Size = new System.Drawing.Size(91, 29);
            this.btnCreateIPT.TabIndex = 35;
            this.btnCreateIPT.Text = "Tạo IPT";
            this.btnCreateIPT.UseVisualStyleBackColor = false;
            this.btnCreateIPT.Click += new System.EventHandler(this.btnCreateIPT_Click);
            // 
            // frmCreateIPT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 483);
            this.Controls.Add(this.btnCreateIPT);
            this.Controls.Add(this.grvDMVTchuan);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.txtDMVTPath);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.btnChooseMat);
            this.Name = "frmCreateIPT";
            this.Text = "Tạo file ipt";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHelp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grvDMVTchuan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txtCode;
        internal System.Windows.Forms.Button btnChooseMat;
        internal System.Windows.Forms.TextBox txtDMVTPath;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.DataGridView grvDMVTchuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colF3;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn colF5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colF6;
        private System.Windows.Forms.DataGridViewTextBoxColumn colF7;
        private System.Windows.Forms.DataGridViewTextBoxColumn colF8;
        private System.Windows.Forms.DataGridViewTextBoxColumn colF9;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn colF11;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Button btnCreateIPT;

    }
}