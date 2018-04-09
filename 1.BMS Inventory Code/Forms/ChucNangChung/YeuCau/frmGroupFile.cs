using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Business;
using BMS.Model;

namespace BMS
{
    public partial class frmGroupFile : _Forms
    {
        public frmGroupFile()
        {
            InitializeComponent();
        }

        private void frmGroupFile_Load(object sender, EventArgs e)
        {
            loadGroupFile();
        }

        void loadGroupFile()
        {
            DataTable dt = TextUtils.Select("select * from SolutionFileType with(nolock)");
            grdCN.DataSource = dt;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (grvCN.RowCount == 0) return;
            grvCN.FocusedRowHandle = -1;

            for (int i = 0; i < grvCN.RowCount; i++)
            {
                int id = TextUtils.ToInt(grvCN.GetRowCellValue(i, colID));
                SolutionFileTypeModel cN = new SolutionFileTypeModel();
                if (id > 0)
                {
                    cN = (SolutionFileTypeModel)SolutionFileTypeBO.Instance.FindByPK(id);
                }

                cN.TypeName = TextUtils.ToString(grvCN.GetRowCellValue(i, colName));
                //cN.Description = TextUtils.ToString(grvCN.GetRowCellValue(i, colDes));

                if (cN.TypeName == "") continue;

                if (id > 0)
                {
                    SolutionFileTypeBO.Instance.Update(cN);
                }
                else
                {
                    SolutionFileTypeBO.Instance.Insert(cN);
                }
            }
            loadGroupFile();
            MessageBox.Show("Lưu trữ thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = TextUtils.ToInt(grvCN.GetFocusedRowCellValue(colID));
                //string code = grvVL.GetFocusedRowCellValue(colCode).ToString();
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa công nghệ này?", TextUtils.Caption,
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    if (id > 0)
                    {
                        SolutionFileTypeBO.Instance.Delete(id);
                    }
                    grvCN.DeleteSelectedRows();
                }
            }
            catch (Exception)
            {
            }
        }

        private void frmGroupFile_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }        
    }
}
