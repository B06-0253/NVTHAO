using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPA.Model;
using TPA.Business;

namespace BMS
{
    public partial class frmMaterialQLSX : _Forms
    {
        public PartsModel Part = new PartsModel();

        public delegate void LoadDataChangeHandler(object sender, EventArgs e);
        public event LoadDataChangeHandler LoadDataChange;

        decimal _priceOld = 0;

        public frmMaterialQLSX()
        {
            InitializeComponent();
        }

        private void frmMaterialQLSX_Load(object sender, EventArgs e)
        {
            txtHScode.Text = Part.HsCode;           
            txtPrice.EditValue = Part.Price;
            txtDescription.Text = Part.Description;
            txtImportTax.EditValue = Part.ImportTax;

            _priceOld = Part.Price;
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            Part.HsCode = txtHScode.Text.Trim();
            Part.Description = txtDescription.Text.Trim();
            Part.ImportTax = TextUtils.ToDecimal(txtImportTax.EditValue);
            Part.Price = TextUtils.ToDecimal(txtPrice.EditValue);
            if (_priceOld != Part.Price)
            {
                Part.UpdatedPriceDate = DateTime.Now;

                TPA.Model.PartsPriceAuditModel p = new TPA.Model.PartsPriceAuditModel();
                p.Price = Part.Price;
                p.PartsCode = Part.PartsCode;
                p.ProjectCode = "";
                p.PType = 4;
                p.PartsID = p.PartsID;
                p.UpdatedDate = DateTime.Now;
                p.CreatedDate = DateTime.Now;
                p.DeliveryTime = 1;
                TPA.Business.PartsPriceAuditBO.Instance.Insert(p);
            }
            PartsBO.Instance.UpdateQLSX(Part);

            if (this.LoadDataChange != null)
            {
                this.LoadDataChange(null, null);
            }

            this.Close();
        }
    }
}
