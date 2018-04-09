using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BMS
{
    public partial class frmShowInventory : _Forms
    {
        public string MaterialCode = "";
        public string MaterialName = "";

        public frmShowInventory()
        {
            InitializeComponent();
        }

        private void frmShowInventory_Load(object sender, EventArgs e)
        {
            this.Text += ": " + MaterialCode;
            textBox2.Text = "\n" + MaterialCode + " - " + MaterialName + Environment.NewLine + Environment.NewLine + "SL tồn kho: ";
            DataTable dt = LibQLSX.Select("select dbo.fMaterialInventory('" + MaterialCode + "')");
            string inv = "0.00";
            try
            {
                textBox2.Text += dt.Rows[0][0].ToString().Remove(dt.Rows[0][0].ToString().Length - 2, 2);
            }
            catch (Exception)
            {
                textBox2.Text += inv;
            }
        }
    }
}
