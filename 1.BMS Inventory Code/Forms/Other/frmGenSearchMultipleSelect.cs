using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BMS.Utils;
using BMS.Business;
using BMS.Model;
using System.Collections;
namespace BMS
{
    public partial class frmGenSearchMultipleSelect : _Forms
    {
        #region Khai báo biến 
        public int[] ID= null;
        public string[] _User = null;
        public int mode;
        public int _DepartmentID;
        #endregion

        #region Load form 
        public frmGenSearchMultipleSelect( int _mode)
        {
            mode = _mode;
            InitializeComponent();
        }
        private void frmGenSearchMultipleSelect_Load(object sender, EventArgs e)
        {
            //datdp, 15/05/2010
            if(mode == 0)
                LoadInfoSearch();            
        }
        #endregion               

        #region Chức năng cơ bản 
        private void btnOK_Click(object sender, EventArgs e)
        {
            //datdp, 15/05/2010            

            CountItem();
            if (ID != null && ID.Length != 0)
                this.Close();
            else
            {
                if (mode == 0)
                    MessageBox.Show("Chọn users trước");
            }

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            //datdp, 15/05/2010
            ID = new int[0];
            this.Close();
        }
        #endregion       

        #region Nhóm sự kiện hệ thống 
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            //datdp, 15/05/2010
            if (grdGrid.RowCount > 0)
            {
                if (btnSelectAll.Text.Substring(0, 1).Equals("C"))
                {
                    btnSelectAll.Text = "&Bỏ chọn";
                    if (grdGrid.Rows.Count > 0)
                    {
                        for (int i = 0; i < grdGrid.Rows.Count; i++)
                        {
                            grdGrid.Rows[i].Cells[0].Value = "X";
                        }
                    }
                }
                else
                {
                    btnSelectAll.Text = "Chọn tất";
                    if (grdGrid.Rows.Count > 0)
                    {
                        for (int i = 0; i < grdGrid.Rows.Count; i++)
                        {
                            grdGrid.Rows[i].Cells[0].Value = "";
                        }
                    }
                }
            }
        }       
        private void grdGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //datdp, 15/05/2010
            if (grdGrid.Rows.Count > 0)
            {               
                if (grdGrid.CurrentRow.Index != -1)
                {                   
                    if (grdGrid.CurrentCell.ColumnIndex == 0)
                    {
                        if (grdGrid.CurrentRow.Cells[0].FormattedValue.ToString() == "")
                        {                            
                            grdGrid.CurrentRow.Cells[0].Value = "X";                           
                        }
                        else
                        {                                                     
                            grdGrid.CurrentRow.Cells[0].Value = "";                            
                        }
                    }
                }
            }
        }
        #endregion
        
        #region Hàm viết thêm        
        private void LoadInfoSearch()
        {           
            if (mode == 0)
            {
                DataTable dtZ = null;
                if(_DepartmentID > 0)
                    dtZ = TextUtils.Select("SELECT ID, LoginName, FirstName + ' ' + MiddleName + ' ' + LastName [FullName] FROM Users WITH (NOLOCK) WHERE DepartmentID = " + _DepartmentID + " ");
                else
                    dtZ = TextUtils.Select("SELECT ID, LoginName, FirstName + ' ' + MiddleName + ' ' + LastName [FullName] FROM Users WITH (NOLOCK)");
                grdGrid.DataSource = dtZ;
                grdGrid.Columns["ID"].Visible = false;
                grdGrid.Columns["LoginName"].Width = 100;
                grdGrid.Columns["LoginName"].HeaderText = "Tên truy nhập";
                grdGrid.Columns["FullName"].Width = 200;
                grdGrid.Columns["FullName"].HeaderText = "Tên đầy đủ";
                this.Width = 498;
                this.Height = 336;
                this.Text = "Danh sách Users";
            }
        }        

        /// <summary>
        /// Đếm xem có bao nhiêu Item được chọn
        /// -- datdp, datdp, 15/05/2010
        /// </summary>
        private void CountItem()
        {
            //Đếm số phòng được chọn
            int CountRow = 0;
            for (int i = 0; i < grdGrid.Rows.Count; i++)
            {
                if(grdGrid[0, i].Value != null)
                    if (grdGrid[0, i].Value.ToString() == "X")
                        CountRow = CountRow + 1;
            }
            //Khởi tạo mảng để gán giá tri chọn được
            ID = new int[CountRow];           
            //User
            if (mode == 0)
                _User = new string[CountRow];

            //Gán giá tri vào mảng
            int j = 0;
            for (int i = 0; i < grdGrid.Rows.Count; i++)
            {
                if (grdGrid[0, i].Value != null)
                {
                    if (grdGrid[0, i].Value.ToString() == "X")
                    {
                        ID[j] = Convert.ToInt32(grdGrid.Rows[i].Cells["ID"].FormattedValue.ToString());                        
                        //User
                        if (mode == 0)
                            _User[j] = grdGrid.Rows[i].Cells["LoginName"].Value.ToString();

                        j = j + 1;
                    }
                }
            }
        }
        
        /// <summary>
        /// Tạo phím nóng trên form
        /// -- datdp, 01/01/2011
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    ID = new int[0];
                    this.Close();
                    return true;
                    break;
                // some more cases...    
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }        
        #endregion

    }
}