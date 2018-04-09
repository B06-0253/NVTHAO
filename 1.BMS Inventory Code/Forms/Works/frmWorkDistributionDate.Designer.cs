namespace Forms.Works
{
    partial class frmWorkDistributionDate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWorkDistributionDate));
            DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.leYear = new DevExpress.XtraEditors.LookUpEdit();
            this.leStaff = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit2 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.mnuMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.grdData = new DevExpress.XtraGrid.GridControl();
            this.grvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtEndDate = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtStartDate = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.leWeek = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.colWorkerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSumTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPercent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leStaff.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).BeginInit();
            this.mnuMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leWeek.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(repositoryItemProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(54, 73);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(126, 20);
            this.textEdit1.TabIndex = 170;
            // 
            // leYear
            // 
            this.leYear.Location = new System.Drawing.Point(50, 120);
            this.leYear.Name = "leYear";
            this.leYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.leYear.Properties.NullText = "";
            this.leYear.Size = new System.Drawing.Size(83, 20);
            this.leYear.TabIndex = 174;
            // 
            // leStaff
            // 
            this.leStaff.Location = new System.Drawing.Point(683, 73);
            this.leStaff.Name = "leStaff";
            this.leStaff.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.leStaff.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", "Mã"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FullName", "Tên")});
            this.leStaff.Properties.NullText = "";
            this.leStaff.Size = new System.Drawing.Size(210, 20);
            this.leStaff.TabIndex = 173;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(14, 76);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(34, 13);
            this.labelControl6.TabIndex = 166;
            this.labelControl6.Text = "Mã CV:";
            // 
            // textEdit2
            // 
            this.textEdit2.EditValue = "T";
            this.textEdit2.Location = new System.Drawing.Point(292, 73);
            this.textEdit2.Name = "textEdit2";
            this.textEdit2.Size = new System.Drawing.Size(285, 20);
            this.textEdit2.TabIndex = 169;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(216, 76);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(70, 13);
            this.labelControl7.TabIndex = 167;
            this.labelControl7.Text = "Tên công việc:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(627, 76);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(52, 13);
            this.labelControl5.TabIndex = 161;
            this.labelControl5.Text = "Nhân viên:";
            // 
            // mnuMenu
            // 
            this.mnuMenu.AutoSize = false;
            this.mnuMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.mnuMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.toolStripSeparator1,
            this.btnClose});
            this.mnuMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.mnuMenu.Size = new System.Drawing.Size(926, 42);
            this.mnuMenu.TabIndex = 158;
            this.mnuMenu.Text = "toolStrip2";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // grdData
            // 
            this.grdData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdData.Location = new System.Drawing.Point(3, 146);
            this.grdData.MainView = this.grvData;
            this.grdData.Name = "grdData";
            this.grdData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ProgressBar1});
            this.grdData.Size = new System.Drawing.Size(919, 337);
            this.grdData.TabIndex = 172;
            this.grdData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvData});
            // 
            // grvData
            // 
            this.grvData.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colWorkerName,
            this.colSumTime,
            this.colPercent,
            this.colID});
            this.grvData.GridControl = this.grdData;
            this.grvData.Name = "grvData";
            this.grvData.OptionsBehavior.AutoExpandAllGroups = true;
            this.grvData.OptionsBehavior.Editable = false;
            this.grvData.OptionsFind.AlwaysVisible = true;
            this.grvData.OptionsView.ShowAutoFilterRow = true;
            this.grvData.OptionsView.ShowFooter = true;
            // 
            // txtEndDate
            // 
            this.txtEndDate.Location = new System.Drawing.Point(673, 120);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Size = new System.Drawing.Size(96, 20);
            this.txtEndDate.TabIndex = 171;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(599, 123);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(71, 13);
            this.labelControl4.TabIndex = 164;
            this.labelControl4.Text = "Ngày kết thúc:";
            // 
            // txtStartDate
            // 
            this.txtStartDate.Location = new System.Drawing.Point(491, 120);
            this.txtStartDate.Name = "txtStartDate";
            this.txtStartDate.Size = new System.Drawing.Size(96, 20);
            this.txtStartDate.TabIndex = 168;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(419, 123);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(69, 13);
            this.labelControl3.TabIndex = 165;
            this.labelControl3.Text = "Ngày bắt đầu:";
            // 
            // leWeek
            // 
            this.leWeek.Location = new System.Drawing.Point(193, 120);
            this.leWeek.Name = "leWeek";
            this.leWeek.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.leWeek.Properties.NullText = "";
            this.leWeek.Size = new System.Drawing.Size(210, 20);
            this.leWeek.TabIndex = 163;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(161, 123);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(28, 13);
            this.labelControl2.TabIndex = 162;
            this.labelControl2.Text = "Tuần:";
            // 
            // labelControl8
            // 
            this.labelControl8.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl8.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.labelControl8.Location = new System.Drawing.Point(0, 106);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(922, 1);
            this.labelControl8.TabIndex = 160;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(19, 123);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(25, 13);
            this.labelControl1.TabIndex = 159;
            this.labelControl1.Text = "Năm:";
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = false;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(55, 40);
            this.btnSave.Text = "Ghi";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = false;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(55, 40);
            this.btnClose.Text = "Thoát";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // colWorkerName
            // 
            this.colWorkerName.Caption = "NGÀY";
            this.colWorkerName.FieldName = "FullName";
            this.colWorkerName.Name = "colWorkerName";
            this.colWorkerName.Visible = true;
            this.colWorkerName.VisibleIndex = 0;
            this.colWorkerName.Width = 165;
            // 
            // colSumTime
            // 
            this.colSumTime.Caption = "Tổng thời gian";
            this.colSumTime.FieldName = "SumTime";
            this.colSumTime.Name = "colSumTime";
            this.colSumTime.Visible = true;
            this.colSumTime.VisibleIndex = 1;
            this.colSumTime.Width = 80;
            // 
            // colPercent
            // 
            this.colPercent.Caption = "Lượng công việc";
            repositoryItemProgressBar1.Maximum = 48;
            repositoryItemProgressBar1.Name = "ProgressBar1";
            repositoryItemProgressBar1.Step = 1;
            this.colPercent.ColumnEdit = repositoryItemProgressBar1;
            this.colPercent.FieldName = "SumTime";
            this.colPercent.Name = "colPercent";
            this.colPercent.Visible = true;
            this.colPercent.VisibleIndex = 2;
            this.colPercent.Width = 656;
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Maximum = 48;
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Step = 1;
            // 
            // frmWorkDistributionDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 487);
            this.Controls.Add(this.textEdit1);
            this.Controls.Add(this.leYear);
            this.Controls.Add(this.leStaff);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.textEdit2);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.mnuMenu);
            this.Controls.Add(this.grdData);
            this.Controls.Add(this.txtEndDate);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtStartDate);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.leWeek);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl1);
            this.Name = "frmWorkDistributionDate";
            this.Text = "PHÂN BỔ NGÀY GIỜ HOÀN THÀNH DỰ KIẾN";
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leStaff.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit2.Properties)).EndInit();
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leWeek.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(repositoryItemProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProgressBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colSumTime;
        private DevExpress.XtraGrid.Columns.GridColumn colPercent;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar ProgressBar1;
        private DevExpress.XtraEditors.LookUpEdit leYear;
        private DevExpress.XtraEditors.LookUpEdit leStaff;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraGrid.Columns.GridColumn colWorkerName;
        private System.Windows.Forms.ToolStrip mnuMenu;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnClose;
        private DevExpress.XtraGrid.GridControl grdData;
        private DevExpress.XtraGrid.Views.Grid.GridView grvData;
        private DevExpress.XtraEditors.TextEdit txtEndDate;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtStartDate;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LookUpEdit leWeek;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}