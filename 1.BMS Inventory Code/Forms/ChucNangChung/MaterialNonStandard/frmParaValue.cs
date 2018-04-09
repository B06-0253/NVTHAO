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
using BMS.Utils;

namespace BMS
{
    public partial class frmParaValue : _Forms
    {
        public string ParamCode = "";
        public string ParamName = "";
        public string MaterialNSCode = "";
        public int MaterialParamNSID = 0;

        public frmParaValue()
        {
            InitializeComponent();
        }

        private void frmParaValue_Load(object sender, EventArgs e)
        {
            this.Text = "Danh sách giá trị thông số: [" + ParamCode + "]-[" + ParamName + "] của: " + MaterialNSCode;
            loadGrid();
        }

        void loadGrid()
        {
            DataTable dt = TextUtils.Select("select * from MaterialParamValueNS with(nolock) where MaterialParamNSID = " + MaterialParamNSID);
            grdThongSo.DataSource = dt;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (grvThongSo.RowCount > 0)
            {
                grvThongSo.FocusedRowHandle = -1;
                for (int i = 0; i < grvThongSo.RowCount; i++)
                {
                    int id = TextUtils.ToInt(grvThongSo.GetRowCellValue(i,colID));
                    MaterialParamValueNSModel model = new MaterialParamValueNSModel();

                    if (id > 0)
                    {
                        model = (MaterialParamValueNSModel)MaterialParamValueNSBO.Instance.FindByPK(id);
                    }

                    model.Description = TextUtils.ToString(grvThongSo.GetRowCellValue(i, colDes));
                    model.ValueTS = TextUtils.ToString(grvThongSo.GetRowCellValue(i, colValue));
                    model.MaterialParamNSID = MaterialParamNSID;

                    if (model.ValueTS == "") continue;

                    if (id > 0)
                    {
                        MaterialParamValueNSBO.Instance.Update(model);
                    }
                    else
                    {
                        MaterialParamValueNSBO.Instance.Insert(model);
                    }
                }

                MessageBox.Show("Lưu trữ thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadGrid();
            }
        }
    }
}
