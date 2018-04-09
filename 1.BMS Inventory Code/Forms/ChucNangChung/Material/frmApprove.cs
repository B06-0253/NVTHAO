using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Utils;
using BMS.Business;
using BMS.Model;

namespace BMS
{
    public partial class frmApprove : _Forms
    {
        bool isAdd = false;

        public frmApprove()
        {
            InitializeComponent();
        }

        private void frmApprove_Load(object sender, EventArgs e)
        {
            DocUtils.InitFTPTK();
            loadGrid();
        }

        void loadGrid()
        {
            try
            {
                DataTable dt = TextUtils.Select("vMaterialFile", null);
                grdGrid.DataSource = dt;
                grvGrid.BestFitColumns();
            }
            catch (Exception)
            {                
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa hoàn toàn những file này không?",
                      TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            foreach (int item in grvGrid.GetSelectedRows())
            {
                int mID = TextUtils.ToInt(grvGrid.GetRowCellValue(item, colMaterialFileID));
                ProcessTransaction pt = new ProcessTransaction();
                pt.OpenConnection();
                pt.BeginTransaction();
                try
                {
                    //Delete file in ftp
                    DocUtils.DeleteFile(grvGrid.GetRowCellValue(item, colPath).ToString());
                    //
                    pt.Delete("MaterialFile", mID);
                    pt.DeleteByAttribute("MaterialFileLink", "MaterialFileID", mID.ToString());
                    pt.CommitTransaction();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    pt.CloseConnection();
                }                
            }            
        }

        private void btnNoApprove_Click(object sender, EventArgs e)
        {
            foreach (int item in grvGrid.GetSelectedRows())
            {
                int mID = TextUtils.ToInt(grvGrid.GetRowCellValue(item, colMaterialFileID));
                MaterialFileModel model = (MaterialFileModel)MaterialFileBO.Instance.FindByPK(mID);
                //model.CauseDelete = "";
                model.IsDeleted = false;
                MaterialFileBO.Instance.Update(model);
            }            
        }      

    }
}
