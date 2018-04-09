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
    public partial class frmSolutionTechnology : _Forms
    {
        public int ID;
        int _type = 1;        

        public frmSolutionTechnology(int type)
        {
            InitializeComponent();
            _type = type;
        }

        private void frmSolutionTechnology_Load(object sender, EventArgs e)
        {
            loadData();
            if (_type == 1)
            {
                this.Text = "CÔNG NGHỆ SỬ DỤNG";
            }
            else
            {
                this.Text = "LĨNH VỰC ỨNG DỤNG";
            }
        }

        void loadData()
        {            
            DataTable dt = TextUtils.Select("select * from SolutionTechnology with(nolock) where Type = " + _type);
            grdCN.DataSource = dt;                                  
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            grvCN.FocusedRowHandle = -1;
            if (grvCN.RowCount == 0) return;            

            for (int i = 0; i < grvCN.RowCount; i++)
            {
                int id = TextUtils.ToInt(grvCN.GetRowCellValue(i, colID));
                SolutionTechnologyModel cN = new SolutionTechnologyModel();
                if (id > 0)
                {
                    cN = (SolutionTechnologyModel)SolutionTechnologyBO.Instance.FindByPK(id);
                }

                cN.Name = TextUtils.ToString(grvCN.GetRowCellValue(i, colName));
                cN.Description = TextUtils.ToString(grvCN.GetRowCellValue(i, colDes));
                cN.Type = _type;

                if (cN.Name == "") continue;

                if (id > 0)
                {
                    SolutionTechnologyBO.Instance.Update(cN);
                }
                else
                {
                    SolutionTechnologyBO.Instance.Insert(cN);
                }
            }
            loadData();
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
                        SolutionTechnologyBO.Instance.Delete(id);
                    }
                    grvCN.DeleteSelectedRows();
                }
            }
            catch (Exception ex)
            {
                TextUtils.ShowError(ex);
            }
        }

        private void frmSolutionTechnology_FormClosed(object sender, FormClosedEventArgs e)
        {            
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            ID = TextUtils.ToInt(grvCN.GetFocusedRowCellValue(colID));
            DialogResult = DialogResult.OK;
        }       
    }
}
