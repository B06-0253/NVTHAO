using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Model;
using BMS.Utils;
using BMS.Business;
using TPA.Model;
using TPA.Business;

namespace BMS
{
    public partial class frmViewDMVT : _Forms
    {
        public DataTable DtDMVT = new DataTable();
        public string Code = "";
        public string Name = "";
        public int ProjectDirectionID = 0;
        //ProjectDirectionModel _projectDirection;

        public frmViewDMVT()
        {
            InitializeComponent();
        }

        void loadGrid()
        {
            grdData.DataSource = DtDMVT;
            grvData.BestFitColumns();
            //if (ProjectDirectionID>0)
            //{
            //    _projectDirection = (ProjectDirectionModel)ProjectDirectionBO.Instance.FindByPK(ProjectDirectionID);
            //}
        }

        private void frmViewDMVT_Load(object sender, EventArgs e)
        {
            this.Text += ": " + Code + " - " + Name;
            loadGrid();
        }

        private void grvData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == (Keys.C))
            {
                try
                {
                    string text = TextUtils.ToString(grvData.GetFocusedRowCellValue(grvData.FocusedColumn));
                    Clipboard.SetText(text);
                }
                catch (Exception)
                {
                }
            }
        }

        private void btnAddChiThi_Click(object sender, EventArgs e)
        {

        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            TextUtils.ExportExcel(grvData);
        }
    }
}
