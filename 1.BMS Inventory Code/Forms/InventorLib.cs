using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Data;

namespace BMS
{
    public static class InventorLib
    {
        public static void GetUserDefProperties(string mPath, ref string[] mName, ref string[] mVal)
        {
            Inventor.Property oProp;
            Inventor.PropertySet oPropSet;
            int mArrIndex = 0;
            Inventor.ApprenticeServerComponent oApprenticeApp = new Inventor.ApprenticeServerComponent();
            Inventor.ApprenticeServerDocument oApprenticeServerDoc;
            oApprenticeServerDoc = oApprenticeApp.Open(mPath);
            if (oApprenticeServerDoc == null)
            {
                MessageBox.Show("File không hợp lệ");
                return;
            }
            foreach (Inventor.PropertySet tempLoopVar_oPropSet in oApprenticeServerDoc.PropertySets)
            {
                oPropSet = tempLoopVar_oPropSet;
                if (oPropSet.DisplayName == "User Defined Properties")
                {
                    mArrIndex = 0;
                    mName = new string[oPropSet.Count + 1];
                    mVal = new string[oPropSet.Count + 1];
                    foreach (Inventor.Property tempLoopVar_oProp in oPropSet)
                    {
                        oProp = tempLoopVar_oProp;

                        if (oProp.Name.ToLower().StartsWith("plot"))
                        {
                            continue;
                        }

                        if (Information.VarType(oProp.Value) != Constants.vbDate)
                        {
                            mName[mArrIndex] = (string)oProp.Name;
                            mVal[mArrIndex] = (string)oProp.Value;
                            mArrIndex++;
                        }
                    }
                    break;
                }
            }
        }

        public static DataTable GetIDWFiles(string idwFilePath)
        {
            DataTable dtDataMEM = new DataTable();
            try
            {                
                dtDataMEM.Columns.Add("Name", typeof(string));
                dtDataMEM.Columns.Add("ISize", typeof(string));
                dtDataMEM.Columns.Add("IDate", typeof(string));
                dtDataMEM.Columns.Add("Date", typeof(string));
                string[] mName = null;
                string[] mVal = null;
                GetUserDefProperties(idwFilePath, ref mName, ref mVal);
                int M = mName.Length;
                try
                {
                    for (int i = 0; i <= M - 2; i += 2)
                    {
                        DataRow newRow = dtDataMEM.NewRow();
                        newRow["Name"] = mName[i].Replace("Size.", "");
                        newRow["ISize"] = mVal[i];
                        newRow["IDate"] = mVal[i + 1];
                        newRow["Date"] = DateString(mVal[i + 1]);
                        if (mName[i] != "")
                        {
                            dtDataMEM.Rows.Add(newRow);
                        }
                    }
                }
                catch (Exception)
                {
                }

                DataRow newRow1 = dtDataMEM.NewRow();
                newRow1["Name"] = "";
                newRow1["ISize"] = "";
                newRow1["IDate"] = "";
                newRow1["Date"] = "";
                dtDataMEM.Rows.Add(newRow1);
            }
            catch (Exception)
            {
                
            }
            return dtDataMEM;
        }

        public static string DateString(string ToFileName)
        {
            long mVal = System.Convert.ToInt64(Convert.ToInt64(ToFileName));
            TimeSpan a1 = TimeSpan.FromSeconds(mVal);
            DateTime mDate = default(DateTime);
            mDate = DateTime.MinValue;
            mDate = mDate.AddDays(System.Convert.ToDouble(a1.TotalDays));
            return mDate.ToString();
        }
    }
}
