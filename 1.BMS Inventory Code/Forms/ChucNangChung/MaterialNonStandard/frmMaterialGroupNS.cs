using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Model;
using BMS.Business;
using BMS.Utils;
using System.IO;
using System.Diagnostics;

namespace BMS
{
    public partial class frmMaterialGroupNS : _Forms
    {
        public MaterialNSModel MaterialNS = new MaterialNSModel();
        public delegate void LoadDataChangeHandler(object sender, int node);
        public event LoadDataChangeHandler LoadDataChange;
        bool _isSaved = false;
        public int CurentNode = 0;
        DataTable dtFile = new DataTable();
        DataTable dtPara;

        #region Constructor and Load
        public frmMaterialGroupNS()
        {
            InitializeComponent();
        }

        private void frmMaterialGroupNS_Load(object sender, EventArgs e)
        {
            //loadCombo();
            loadGridFile();
            loadGridPara();
            loadHang();

            if (MaterialNS.ID > 0)
            {
                txtCode.Text = MaterialNS.Code;
                txtName.Text = MaterialNS.Name;
                cboHang.EditValue = MaterialNS.CustomerID;
                cboType.SelectedIndex = MaterialNS.Type;
                txtDescription.Text = MaterialNS.Description;
                txtSL.EditValue = MaterialNS.NumberTS;

                this.Text += ": " + MaterialNS.Code;
            }
        }
        #endregion

        #region Methods
        void loadHang()
        {
            try
            {
                DataTable dt = TextUtils.Select("Customer", new Expression("Type", 0));
                TextUtils.PopulateCombo(cboHang, dt, "Name", "ID", "");
            }
            catch (Exception)
            {
                MessageBox.Show("Không load được hãng vào combo");
            }
        }

        void loadGridFile()
        {
            dtFile = TextUtils.Select("SELECT * FROM MaterialFileNS WITH(NOLOCK) where MaterialNSID = " + MaterialNS.ID);
            grvData.AutoGenerateColumns = false;
            grvData.DataSource = dtFile;
        }

        void loadGridPara()
        {
            dtPara = TextUtils.Select("SELECT * FROM MaterialParamNS WITH(NOLOCK) where MaterialNSID = " + MaterialNS.ID + " Order by Code");
            grdThongSo.DataSource = dtPara;
        }

        private bool ValidateForm()
        {
            txtCode.Text = txtCode.Text.Trim().Replace(" ", "");

            if (txtCode.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền Mã.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
            {
                DataTable dt;
                if (MaterialNS.ID > 0)
                {
                    dt = TextUtils.Select("select Code from MaterialNS where upper(Replace(Code,' ','')) = '"
                        + txtCode.Text.Trim().ToUpper() + "' and ID <> " + MaterialNS.ID);
                }
                else
                {
                    dt = TextUtils.Select("select Code from MaterialNS where upper(Replace(Code,' ','')) = '"
                        + txtCode.Text.Trim().ToUpper() + "'");
                }
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Mã này đã tồn tại!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }
                }
            }

            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền Tên.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            //if (leParentCat.EditValue== null)
            //{
            //    MessageBox.Show("Xin hãy chọn một nhóm!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return false;
            //}

            if (TextUtils.ToInt(cboHang.EditValue) == 0)
            {
                MessageBox.Show("Xin hãy chọn một hãng!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (cboType.SelectedIndex < 0)
            {
                MessageBox.Show("Xin hãy chọn một loại vật tư!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (grvData.Rows.Count > 1)
            {
                MessageBox.Show("Vật tư chỉ cho phép có một hình ảnh!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (TextUtils.ToInt(txtSL.Text.Trim()) != grvThongSo.RowCount)
            {
                MessageBox.Show("Số lượng thông số không đúng!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return true;
        }

        void save(bool close)
        {
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();
            try
            {
                if (!ValidateForm())
                    return;

                grvThongSo.FocusedRowHandle = -1;

                MaterialNS.Name = txtName.Text.Trim().ToUpper();
                MaterialNS.Code = txtCode.Text.Trim().Replace(" ", "");
                MaterialNS.CustomerID = TextUtils.ToInt(cboHang.EditValue);
                MaterialNS.Description = txtDescription.Text.Trim();
                MaterialNS.Type = cboType.SelectedIndex;
                MaterialNS.NumberTS = TextUtils.ToInt(txtSL.Text);

                if (MaterialNS.ID <= 0)
                {
                    MaterialNS.ID = (int)pt.Insert(MaterialNS);
                }
                else
                {
                    pt.Update(MaterialNS);
                }

                #region Lưu trữ thông số
                for (int i = 0; i < grvThongSo.RowCount; i++)
                {
                    int id = TextUtils.ToInt(grvThongSo.GetRowCellValue(i, colIDThongSo));
                    string code = TextUtils.ToString(grvThongSo.GetRowCellValue(i, colCodeThongSo));
                    string name = TextUtils.ToString(grvThongSo.GetRowCellValue(i, colNameThongSo));
                    if (code == "" || name == "") continue;

                    MaterialParamNSModel para = new MaterialParamNSModel();
                    if (id > 0)
                    {
                        para = (MaterialParamNSModel)MaterialParamNSBO.Instance.FindByPK(id);
                    }

                    para.Code = code.ToUpper().Trim().Replace(" ", "");
                    para.Name = name.Trim();
                    para.MaterialNSID = MaterialNS.ID;
                    para.Unit = TextUtils.ToString(grvThongSo.GetRowCellValue(i, colUnitThongSo));

                    if (para.ID <= 0)
                    {
                        pt.Insert(para);
                    }
                    else
                    {
                        if (i >= TextUtils.ToInt(txtSL.Text))
                        {
                            pt.Delete("MaterialParamNS", para.ID);
                        }
                        else
                        {
                            pt.Update(para);
                        }
                        
                    }
                }
                #endregion

                #region Lưu trữ file
                for (int i = 0; i < grvData.RowCount; i++)
                {
                    int iD = TextUtils.ToInt(grvData.Rows[i].Cells["colID"].Value);
                    MaterialFileNSModel fileModel = new MaterialFileNSModel();

                    if (iD > 0)
                    {
                        fileModel = (MaterialFileNSModel)MaterialFileNSBO.Instance.FindByPK(iD);
                    }

                    fileModel.FilePath = grvData.Rows[i].Cells["colFilePath"].Value.ToString();
                    fileModel.Length = TextUtils.ToDecimal(grvData.Rows[i].Cells["colSize"].Value);
                    fileModel.MaterialNSID = MaterialNS.ID;
                    fileModel.Name = grvData.Rows[i].Cells["colFileName"].Value.ToString();
                    fileModel.LocalFilePath = grvData.Rows[i].Cells["colLocalPath"].Value.ToString();

                    if (iD == 0)
                    {
                        pt.Insert(fileModel);
                        File.Copy(fileModel.LocalFilePath, fileModel.FilePath, true);
                    }
                }
                #endregion

                pt.CommitTransaction();
                if (grvData.Rows.Count > 0)
                {
                    MaterialNS.FilePath = TextUtils.ToString(grvData.Rows[0].Cells["colFilePath"].Value);
                    MaterialNSBO.Instance.Update(MaterialNS);
                }
                loadGridFile();
                loadGridPara();

                _isSaved = true;
                if (close)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Lưu trữ thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi lưu trữ!" + Environment.NewLine + ex.Message, TextUtils.Caption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                pt.CloseConnection();
            }
        }
        #endregion

        #region Events
        private void frmMaterialGroupNS_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_isSaved)
            {
                if (this.LoadDataChange != null)
                {
                    this.LoadDataChange(null, CurentNode);
                }
                DialogResult = DialogResult.OK;
            }
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            if (grvData.Rows.Count > 0)
            {
                MessageBox.Show("Mỗi vật tư chỉ có một hình ảnh.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files (*.jpg, *.jpeg, *.png,*.gif) | *.jpg; *.jpeg; *.png; *.gif";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string folderPath = @"\\SERVER\data2\Dulieu_TPA\PHANMEM\MaterialNS\";
                foreach (string filePath in ofd.FileNames)
                {
                    DataRow dr = dtFile.NewRow();
                    dr["ID"] = 0;
                    dr["MaterialNSID"] = 0;
                    dr["Name"] = Path.GetFileName(filePath);
                    dr["Length"] = new FileInfo(filePath).Length;
                    dr["FilePath"] = folderPath + "\\" + Path.GetFileName(filePath);
                    dr["LocalFilePath"] = filePath;
                    dtFile.Rows.Add(dr);
                }
            }
        }

        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            int iD = TextUtils.ToInt(grvData.SelectedRows[0].Cells["colID"].Value);
            string name = grvData.SelectedRows[0].Cells["colFileName"].Value.ToString();

            if (MessageBox.Show("Bạn có chắc muốn xóa file [" + name + "] này không?", TextUtils.Caption,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (iD > 0)
                    {
                        MaterialFileNSBO.Instance.Delete(iD);
                        try
                        {
                            File.Delete(grvData.SelectedRows[0].Cells["colFilePath"].Value.ToString());
                            MaterialNS.FilePath = "";
                            MaterialNSBO.Instance.Update(MaterialNS);
                        }
                        catch
                        {
                        }
                    }

                    grvData.Rows.RemoveAt(grvData.SelectedRows[0].Index);
                }
                catch
                {
                    MessageBox.Show("Có lỗi xảy ra khi thực hiện thao tác, xin vui lòng thử lại sau.");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save(false);
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            save(true);
            if (_isSaved)
            {
                this.Close();
            }
        }

        private void grvThongSo_KeyDown(object sender, KeyEventArgs e)
        {
            if (grvThongSo.SelectedRowsCount < 1)
            {
                return;
            }
            if (e.KeyCode == (Keys.Delete))
            //if (e.KeyData == (Keys.Control | Keys.Delete))
            {
                try
                {
                    string code = grvThongSo.GetFocusedRowCellValue(colCodeThongSo).ToString();
                    int id = TextUtils.ToInt(grvThongSo.GetFocusedRowCellValue(colIDThongSo));
                    if (MessageBox.Show("Bạn có chắc muốn xóa thông số [" + code + "]?", TextUtils.Caption,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (id > 0)
                        {
                            MaterialParamNSBO.Instance.Delete(id);
                        }
                        grvThongSo.DeleteSelectedRows();
                        //loadGridPara();
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void btnCreateValue_Click(object sender, EventArgs e)
        {
            int paraID = TextUtils.ToInt(grvThongSo.GetFocusedRowCellValue(colIDThongSo));            
            if (paraID == 0)
            {
                MessageBox.Show("Thông số phải được ghi lại trước khi tạo giá trị cho nó!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            string paraCode = TextUtils.ToString(grvThongSo.GetFocusedRowCellValue(colCodeThongSo));
            string paraName = TextUtils.ToString(grvThongSo.GetFocusedRowCellValue(colNameThongSo));

            frmParaValue frm = new frmParaValue();
            frm.MaterialParamNSID = paraID;
            frm.MaterialNSCode = MaterialNS.Code;
            frm.ParamCode = paraCode;
            frm.ParamName = paraName;
            frm.Show();
        }
        #endregion

        private void grvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string filePath = TextUtils.ToString(grvData.SelectedRows[0].Cells[colFilePath.Index].Value);
            if (filePath != "")
            {
                Process.Start(filePath);
            }
        }

        private void txtSL_EditValueChanged(object sender, EventArgs e)
        {
            int count = TextUtils.ToInt(txtSL.EditValue);
            //int count = txtCode.Text.Split(new char[] { '-', 'x' }).Length;
            if (count == 0)
            {
                flpCode.Controls.Clear();
                return;
            }
            flpCode.Controls.Clear();
            DataTable dt = TextUtils.Select("Select [Char] from ListChar");

            TextBox text = new TextBox();
            text.Width = 200;
            if (MaterialNS.ID > 0)
            {
                text.Text = txtCode.Text.Split('-')[0];
            }
            flpCode.Controls.Add(text);
            TextBox text1 = new TextBox();
            text1.Width = 20;
            text1.Text = "-";
            text1.Enabled = false;
            flpCode.Controls.Add(text1);

            for (int i = 0; i < count; i++)
            {
                TextBox txt = new TextBox();
                txt.Width = 20;
                txt.Enabled = false;
                txt.Text = dt.Rows[i][0].ToString();
                flpCode.Controls.Add(txt);
                if (i != count - 1)
                {
                    ComboBox cbo = new ComboBox();
                    cbo.Items.Add("-");
                    cbo.Items.Add("x");
                    cbo.Width = 40;
                    flpCode.Controls.Add(cbo);
                }
            }
        }

        private void btnCreateCode_Click(object sender, EventArgs e)
        {
            string code = "";
            bool error = false;
            for (int i = 0; i < flpCode.Controls.Count; i++)
            {
                Control control = flpCode.Controls[i];
                if (control.Text == "")
                {
                    error = true;
                    break;
                }
                
                if (control.Text != "-" && control.Text != "x" && i != 0)
                {
                    code += "[" + control.Text + "]";
                    DataRow[] drs = dtPara.Select("Code = '" + control.Text + "'");
                    if (drs.Length == 0)
                    {
                        DataRow dr = dtPara.NewRow();
                        dr["Code"] = control.Text;
                        dtPara.Rows.Add(dr);
                    }
                }
                else
                {
                    if (i == 0)
                    {
                        code += control.Text.ToUpper();
                    }
                    else
                    
                    code += control.Text;
                }
            }
            if (error)
            {
                MessageBox.Show("Mã không đúng định dạng!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                txtCode.Text = code.Replace(" ", "");
            }
        }
    }
}
