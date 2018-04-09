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
    public partial class frmReportShow : _Forms
    {
        public string HtmlText = "";

        public frmReportShow()
        {
            InitializeComponent();
        }        

        private void frmReportShow_Load(System.Object sender, System.EventArgs e)
        {
            WebBrowser1.DocumentText = HtmlText;
        }
    }
}
