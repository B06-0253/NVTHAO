using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BMS.Utils;

namespace BMS
{
    public partial class frmGenSearchSelect : _Forms
    {
        #region Khai báo biến.

        public int mode;       
        public int ContractTypeID = 0;
        /// <summary>
        /// 0: Print          
        /// </summary>
        public int ID = 0;
        /// <summary>
        /// 0: Royal 
        /// 1: Times 
        /// </summary>
        public int _Project = 0;

        #endregion

        #region Load form

        public frmGenSearchSelect(int _mode)
        {
            mode = _mode;
            InitializeComponent();
        }
        private void frmGenSearchSelect_Load(object sender, EventArgs e)
        {
            //datdp, 19/05/2010
            if (mode == 0)
                LoadInfoSearch();
        }
        #endregion

        #region Chức năng cơ bản .

        private void btnOK_Click(object sender, EventArgs e)
        {
            //datdp, 19/05/2010
            if (ID > 0)
                this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //datdp, 19/05/2010
            ID = 0;
            this.Close();
        }

        #endregion

        #region Nhóm sự kiện hệ thống 
        
        private void grvData_Click(object sender, EventArgs e)
        {
            if (grvData.RowCount > 0)
                ID =(int)grvData.GetRowCellValue(grvData.FocusedRowHandle,"ID");
        }

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            if (ID > 0)
                this.Close();
        }

        private void frmGenSearchSelect_FormClosed(object sender, FormClosedEventArgs e)
        {
            //ID = 0;
            //this.Close();
        }

        #endregion

        #region Hàm dùng chung 

        /// <summary>
        /// Load dữ liệu lên Grid
        /// -- datdp, 19/05/2010
        /// </summary>
        private void LoadInfoSearch()
        {
            //Combine FIT, Contact
            if (mode == 0)
            {
                DataTable dtP = null;
                if(_Project==0)
                    dtP = TextUtils.Select("SELECT ID,ContractTypeText, Name AS TempName, FileName FROM dbo.DesignStructureFile WHERE ContractTypeID =" + ContractTypeID + " AND ProjectID =2 ");
                else
                    dtP = TextUtils.Select("SELECT ID,ContractTypeText, Name AS TempName, FileName  FROM dbo.DesignStructureFile WHERE ContractTypeID =" + ContractTypeID + " AND ProjectID =1 ORDER BY FileName");
                
                grdData.DataSource = dtP;
                this.Text = "Danh sách mẫu in";
            }           
        }

        #endregion
    }
}