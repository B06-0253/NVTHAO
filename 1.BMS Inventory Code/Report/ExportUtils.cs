using System;
using System.Collections.Generic;
using System.Text;

namespace BMS
{
    public class ExportUtils
    {

        /// <summary>
        /// Hàm xuất excel.
        /// </summary>
        /// <param name="grvData"></param>
        public static void ExportExcel(DevExpress.XtraGrid.Views.Grid.GridView grvData)
        {
            string filepath = System.IO.Path.GetTempFileName();
            filepath = filepath.Remove(filepath.LastIndexOf('.') + 1);
            filepath = String.Concat(filepath, "xls");

            grvData.OptionsPrint.AutoWidth = false;
            grvData.OptionsPrint.ExpandAllDetails = false;
            grvData.OptionsPrint.PrintDetails = true;

            grvData.OptionsPrint.UsePrintStyles = true;
            try
            { grvData.ExportToExcelOld(filepath); }
            catch
            { grvData.ExportToXls(filepath); }

            System.Diagnostics.ProcessStartInfo startInfo =
                 new System.Diagnostics.ProcessStartInfo("Excel.exe", String.Format("/r \"{0}\"", filepath));

            System.Diagnostics.Process.Start(startInfo);
        }
    }
}
