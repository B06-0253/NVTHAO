namespace BMS
{
    partial class ucDetailTS
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cboValue = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.grvValue = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtParaCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtParaName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.cboValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvValue)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thông số:";
            // 
            // cboValue
            // 
            this.cboValue.Location = new System.Drawing.Point(523, 8);
            this.cboValue.Name = "cboValue";
            this.cboValue.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboValue.Properties.NullText = "";
            this.cboValue.Properties.View = this.grvValue;
            this.cboValue.Size = new System.Drawing.Size(278, 20);
            this.cboValue.TabIndex = 18;
            this.cboValue.EditValueChanged += new System.EventHandler(this.cboValue_EditValueChanged);
            // 
            // grvValue
            // 
            this.grvValue.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colValue,
            this.colDes,
            this.colID});
            this.grvValue.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.grvValue.Name = "grvValue";
            this.grvValue.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvValue.OptionsView.ShowGroupPanel = false;
            // 
            // colValue
            // 
            this.colValue.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colValue.AppearanceHeader.Options.UseFont = true;
            this.colValue.AppearanceHeader.Options.UseTextOptions = true;
            this.colValue.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colValue.Caption = "Giá trị";
            this.colValue.FieldName = "ValueTS";
            this.colValue.Name = "colValue";
            this.colValue.Visible = true;
            this.colValue.VisibleIndex = 0;
            this.colValue.Width = 315;
            // 
            // colDes
            // 
            this.colDes.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.colDes.AppearanceHeader.Options.UseFont = true;
            this.colDes.AppearanceHeader.Options.UseTextOptions = true;
            this.colDes.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDes.Caption = "Mô tả";
            this.colDes.FieldName = "Description";
            this.colDes.Name = "colDes";
            this.colDes.Visible = true;
            this.colDes.VisibleIndex = 1;
            this.colDes.Width = 865;
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(485, 11);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(32, 13);
            this.labelControl5.TabIndex = 17;
            this.labelControl5.Text = "Giá trị:";
            // 
            // txtParaCode
            // 
            this.txtParaCode.Location = new System.Drawing.Point(61, 7);
            this.txtParaCode.Name = "txtParaCode";
            this.txtParaCode.ReadOnly = true;
            this.txtParaCode.Size = new System.Drawing.Size(50, 20);
            this.txtParaCode.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên thông số:";
            // 
            // txtParaName
            // 
            this.txtParaName.Location = new System.Drawing.Point(191, 0);
            this.txtParaName.Multiline = true;
            this.txtParaName.Name = "txtParaName";
            this.txtParaName.ReadOnly = true;
            this.txtParaName.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtParaName.Size = new System.Drawing.Size(280, 33);
            this.txtParaName.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(813, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Đơn vị:";
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(854, 8);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.ReadOnly = true;
            this.txtUnit.Size = new System.Drawing.Size(65, 20);
            this.txtUnit.TabIndex = 19;
            // 
            // ucDetailTS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtParaName);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.txtParaCode);
            this.Controls.Add(this.cboValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.label1);
            this.Name = "ucDetailTS";
            this.Size = new System.Drawing.Size(922, 35);
            this.Load += new System.EventHandler(this.ucDetailTS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SearchLookUpEdit cboValue;
        private DevExpress.XtraGrid.Views.Grid.GridView grvValue;
        private DevExpress.XtraGrid.Columns.GridColumn colValue;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.TextBox txtParaCode;
        private DevExpress.XtraGrid.Columns.GridColumn colDes;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtParaName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUnit;
    }
}
