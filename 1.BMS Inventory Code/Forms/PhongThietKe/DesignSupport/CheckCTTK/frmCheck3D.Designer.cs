namespace BMS
{
    partial class frmCheck3D
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.grvData = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtName = new System.Windows.Forms.TextBox();
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Label2 = new System.Windows.Forms.Label();
            this.grvDataNeedCompare = new System.Windows.Forms.DataGridView();
            this.btnChooseMat = new System.Windows.Forms.Button();
            this.Label7 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvDataNeedCompare)).BeginInit();
            this.SuspendLayout();
            // 
            // Label5
            // 
            this.Label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label5.BackColor = System.Drawing.Color.Yellow;
            this.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label5.Location = new System.Drawing.Point(134, 45);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(28, 15);
            this.Label5.TabIndex = 30;
            // 
            // Label4
            // 
            this.Label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label4.BackColor = System.Drawing.Color.GreenYellow;
            this.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label4.Location = new System.Drawing.Point(8, 45);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(28, 15);
            this.Label4.TabIndex = 29;
            // 
            // Label8
            // 
            this.Label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(162, 47);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(61, 13);
            this.Label8.TabIndex = 32;
            this.Label8.Text = "Chênh lệch";
            // 
            // btnCheck
            // 
            this.btnCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheck.BackColor = System.Drawing.Color.White;
            this.btnCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheck.Location = new System.Drawing.Point(930, 4);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(122, 60);
            this.btnCheck.TabIndex = 28;
            this.btnCheck.Text = "Kiểm tra";
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(7, 11);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(174, 20);
            this.txtDate.TabIndex = 0;
            this.txtDate.Visible = false;
            this.txtDate.Leave += new System.EventHandler(this.txtDate_Leave);
            // 
            // txtCode
            // 
            this.txtCode.Enabled = false;
            this.txtCode.Location = new System.Drawing.Point(128, 13);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(605, 20);
            this.txtCode.TabIndex = 26;
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(192, 11);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(181, 20);
            this.txtSize.TabIndex = 0;
            this.txtSize.Visible = false;
            this.txtSize.Leave += new System.EventHandler(this.txtSize_Leave);
            // 
            // grvData
            // 
            this.grvData.AllowUserToAddRows = false;
            this.grvData.AllowUserToResizeRows = false;
            this.grvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grvData.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.grvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colIValue,
            this.colWValue,
            this.colDate1});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grvData.DefaultCellStyle = dataGridViewCellStyle1;
            this.grvData.Location = new System.Drawing.Point(7, 37);
            this.grvData.MultiSelect = false;
            this.grvData.Name = "grvData";
            this.grvData.ReadOnly = true;
            this.grvData.RowHeadersVisible = false;
            this.grvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grvData.Size = new System.Drawing.Size(461, 262);
            this.grvData.TabIndex = 4;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Tên file";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            // 
            // colIValue
            // 
            this.colIValue.DataPropertyName = "IValue";
            this.colIValue.FillWeight = 60F;
            this.colIValue.HeaderText = "Size";
            this.colIValue.Name = "colIValue";
            this.colIValue.ReadOnly = true;
            // 
            // colWValue
            // 
            this.colWValue.DataPropertyName = "WValue";
            this.colWValue.FillWeight = 70F;
            this.colWValue.HeaderText = "Date modified";
            this.colWValue.Name = "colWValue";
            this.colWValue.ReadOnly = true;
            // 
            // colDate1
            // 
            this.colDate1.DataPropertyName = "Date";
            this.colDate1.HeaderText = "Ngày";
            this.colDate1.Name = "colDate1";
            this.colDate1.ReadOnly = true;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(387, 11);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(173, 20);
            this.txtName.TabIndex = 0;
            this.txtName.Visible = false;
            this.txtName.Leave += new System.EventHandler(this.txtName_Leave);
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SplitContainer1.Location = new System.Drawing.Point(7, 70);
            this.SplitContainer1.Name = "SplitContainer1";
            // 
            // SplitContainer1.Panel1
            // 
            this.SplitContainer1.Panel1.Controls.Add(this.grvData);
            this.SplitContainer1.Panel1.Controls.Add(this.Label2);
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.Controls.Add(this.txtDate);
            this.SplitContainer1.Panel2.Controls.Add(this.txtSize);
            this.SplitContainer1.Panel2.Controls.Add(this.txtName);
            this.SplitContainer1.Panel2.Controls.Add(this.grvDataNeedCompare);
            this.SplitContainer1.Size = new System.Drawing.Size(1045, 308);
            this.SplitContainer1.SplitterDistance = 474;
            this.SplitContainer1.SplitterWidth = 2;
            this.SplitContainer1.TabIndex = 27;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(6, 19);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(96, 13);
            this.Label2.TabIndex = 7;
            this.Label2.Text = "Nội dung bản mềm";
            // 
            // grvDataNeedCompare
            // 
            this.grvDataNeedCompare.AllowUserToResizeRows = false;
            this.grvDataNeedCompare.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grvDataNeedCompare.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grvDataNeedCompare.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grvDataNeedCompare.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grvDataNeedCompare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvDataNeedCompare.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.DataGridViewTextBoxColumn2,
            this.DataGridViewTextBoxColumn1,
            this.colDate});
            this.grvDataNeedCompare.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grvDataNeedCompare.Location = new System.Drawing.Point(7, 37);
            this.grvDataNeedCompare.MultiSelect = false;
            this.grvDataNeedCompare.Name = "grvDataNeedCompare";
            this.grvDataNeedCompare.RowHeadersVisible = false;
            this.grvDataNeedCompare.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grvDataNeedCompare.Size = new System.Drawing.Size(555, 262);
            this.grvDataNeedCompare.TabIndex = 6;
            // 
            // btnChooseMat
            // 
            this.btnChooseMat.BackColor = System.Drawing.Color.White;
            this.btnChooseMat.Location = new System.Drawing.Point(12, 11);
            this.btnChooseMat.Name = "btnChooseMat";
            this.btnChooseMat.Size = new System.Drawing.Size(110, 23);
            this.btnChooseMat.TabIndex = 25;
            this.btnChooseMat.Text = "Chọn bản thiết kế";
            this.btnChooseMat.UseVisualStyleBackColor = false;
            this.btnChooseMat.Click += new System.EventHandler(this.btnChooseMat_Click);
            // 
            // Label7
            // 
            this.Label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(36, 47);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(93, 13);
            this.Label7.TabIndex = 31;
            this.Label7.Text = "Thay đổi nội dung";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Tên file";
            this.Column1.Name = "Column1";
            // 
            // DataGridViewTextBoxColumn2
            // 
            this.DataGridViewTextBoxColumn2.HeaderText = "Size";
            this.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2";
            // 
            // DataGridViewTextBoxColumn1
            // 
            this.DataGridViewTextBoxColumn1.HeaderText = "Date modified";
            this.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1";
            // 
            // colDate
            // 
            this.colDate.HeaderText = "Ngày";
            this.colDate.Name = "colDate";
            this.colDate.Visible = false;
            // 
            // frmCheck3D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 382);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.SplitContainer1);
            this.Controls.Add(this.btnChooseMat);
            this.Controls.Add(this.Label7);
            this.Name = "frmCheck3D";
            this.Text = "KIỂM TRA DỮ LIỆU 3D";
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel1.PerformLayout();
            this.SplitContainer1.Panel2.ResumeLayout(false);
            this.SplitContainer1.Panel2.PerformLayout();
            this.SplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvDataNeedCompare)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Button btnCheck;
        internal System.Windows.Forms.TextBox txtDate;
        internal System.Windows.Forms.TextBox txtCode;
        internal System.Windows.Forms.TextBox txtSize;
        internal System.Windows.Forms.DataGridView grvData;
        internal System.Windows.Forms.DataGridViewTextBoxColumn colName;
        internal System.Windows.Forms.DataGridViewTextBoxColumn colIValue;
        internal System.Windows.Forms.DataGridViewTextBoxColumn colWValue;
        internal System.Windows.Forms.DataGridViewTextBoxColumn colDate1;
        internal System.Windows.Forms.TextBox txtName;
        internal System.Windows.Forms.SplitContainer SplitContainer1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.DataGridView grvDataNeedCompare;
        internal System.Windows.Forms.Button btnChooseMat;
        internal System.Windows.Forms.Label Label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
    }
}