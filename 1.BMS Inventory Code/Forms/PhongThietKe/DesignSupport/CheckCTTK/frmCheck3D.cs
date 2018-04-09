using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Media;
using System.IO;

namespace BMS
{
    public partial class frmCheck3D : _Forms
    {
        public frmCheck3D()
        {
            InitializeComponent();
        }

        private DataTable dtDataMEM;
        private void GetUserDefProperties(string mPath, ref string[] mName, ref string[] mVal)
        {
	        Inventor.Property oProp = default(Inventor.Property);
	        Inventor.PropertySet oPropSet = default(Inventor.PropertySet);
	        int mArrIndex = default(int);
	        Inventor.ApprenticeServerComponent oApprenticeApp = new Inventor.ApprenticeServerComponent();
	        Inventor.ApprenticeServerDocument oApprenticeServerDoc = default(Inventor.ApprenticeServerDocument);
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
					        mName[mArrIndex] = (string) oProp.Name;
					        mVal[mArrIndex] = (string) oProp.Value;
					        mArrIndex++;
				        }
			        }
			        break;
		        }
	        }
        }

        public void FillDataInGridIDW()
        {
	        try
	        {
		        dtDataMEM = new DataTable();
		        dtDataMEM.Columns.Add("Name", typeof(string));
		        dtDataMEM.Columns.Add("IValue", typeof(string));
		        dtDataMEM.Columns.Add("WValue", typeof(string));
		        dtDataMEM.Columns.Add("Date", typeof(string));
		        int M = default(int);
		        int i = default(int);
		        string[] mName = null;
		        string[] mVal = null;
		        string mSt;
		        GetUserDefProperties((string) txtCode.Text, ref mName, ref mVal);
		        M = mName.Length;
		        try
		        {
			        for (i = 0; i <= M - 2; i += 2)
			        {
				        mSt = "";
				        DataRow newRow = dtDataMEM.NewRow();
				        newRow["Name"] = mName[i].Replace("Size.", "");
				        newRow["IValue"] = mVal[i];
				        newRow["WValue"] = mVal[i + 1];
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
		        newRow1["IValue"] = "";
		        newRow1["WValue"] = "";
		        newRow1["Date"] = "";
		        dtDataMEM.Rows.Add(newRow1);
		
		        grvData.DataSource = null;
		        grvData.Rows.Clear();
		        grvData.AutoGenerateColumns = false;
		        grvData.DataSource = dtDataMEM;
		
		        grvData.Columns[0].HeaderText = "Tên file";
		        grvData.Columns[1].HeaderText = "Size";
		        grvData.Columns[2].HeaderText = "Date modified";
		
		        if (grvData.Rows.Count == 0)
		        {
			        return ;
		        }
		        grvData.Rows[grvData.Rows.Count - 1].Selected = true;
		        txtDate.Select();
		
	        }
	        catch (Exception)
	        {
		        grvData.DataSource = null;
		        grvData.Rows.Clear();
	        }
        }

        public string DateString(string ToFileName)
        {
	        long mVal = System.Convert.ToInt64(Convert.ToInt64(ToFileName));
            TimeSpan a1 = TimeSpan.FromSeconds(mVal);
	        DateTime mDate = default(DateTime);
	        mDate = DateTime.MinValue;
	        mDate = mDate.AddDays(System.Convert.ToDouble(a1.TotalDays));
	        return mDate.ToString();
        }

        private void InitGridBeforeCheck()
        {
	
	        if (grvDataNeedCompare.Rows.Count >= 1)
	        {
		        for (int i = 0; i <= grvDataNeedCompare.Rows.Count - 1; i++)
		        {
			        grvDataNeedCompare.Rows[i].Cells[0].Style.BackColor = Color.White;
                    grvDataNeedCompare.Rows[i].Cells[1].Style.BackColor = Color.White;
                    grvDataNeedCompare.Rows[i].Cells[2].Style.BackColor = Color.White;
		        }
	        }
	
	        if (grvData.Rows.Count >= 1)
	        {
		        for (int j = 0; j <= grvData.Rows.Count - 1; j++)
		        {
			        grvData.Rows[j].DefaultCellStyle.BackColor = Color.White;
		        }
	        }
	
        }

        private void btnChooseMat_Click(System.Object sender, System.EventArgs e)
        {
	        OpenFileDialog ofd = new OpenFileDialog();
	        ofd.Filter = "IDW files (*.idw)|*.idw";
	        if (ofd.ShowDialog() == DialogResult.OK)
	        {
		        txtCode.Text = ofd.FileName;
		        FillDataInGridIDW();
	        }
        }

        private void btnCheck_Click(System.Object sender, System.EventArgs e)
        {
	        if (grvData.Rows.Count == 0)
	        {
		        MessageBox.Show("Không có dữ liệu cần kiểm tra!");
		        return ;
	        }
	        if (grvDataNeedCompare.Rows.Count == 0)
	        {
		        MessageBox.Show("Không có dữ liệu cần kiểm tra!");
		        return ;
	        }
	        InitGridBeforeCheck();
	
	        string nameM = (string) (grvData.Rows[0].Cells[0].Value.ToString());
	        string sizeM = (string) (grvData.Rows[0].Cells[1].Value.ToString());
	        string dateM = (string) (grvData.Rows[0].Cells[2].Value.ToString());
	
	        string nameC = (string) (grvDataNeedCompare.Rows[0].Cells[0].Value.ToString());
	        string sizeC = (string) (grvDataNeedCompare.Rows[0].Cells[1].Value.ToString());
	        string dateC = (string) (grvDataNeedCompare.Rows[0].Cells[2].Value.ToString());
	
	        bool success = true;
	
	        if (nameM.Replace(".ipt", "").Replace(")", "/") != nameC)
	        {
                grvDataNeedCompare.Rows[0].Cells[0].Style.BackColor = Color.Yellow;
                grvDataNeedCompare.Rows[0].Cells[1].Style.BackColor = Color.Yellow;
                grvDataNeedCompare.Rows[0].Cells[2].Style.BackColor = Color.Yellow;
		        success = false;
	        }
	        else
	        {
		
		        if (sizeM != sizeC.Replace("2.", ""))
		        {
                    grvDataNeedCompare.Rows[0].Cells[1].Style.BackColor = Color.GreenYellow;
			        success = false;
		        }
		
		        if (dateM != dateC.Replace("1.", ""))
		        {
                    grvDataNeedCompare.Rows[0].Cells[2].Style.BackColor = Color.GreenYellow;
			        success = false;
		        }
	        }
	
	        if (success)
	        {
		        MessageBox.Show("Bản cứng và bản mềm đã khớp!", "TPA-Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
	        }
	        else
	        {
		        MessageBox.Show("Bản cứng và bản mềm không khớp!", "TPA-Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
	        }
	
        }

        private void txtDate_Leave(System.Object sender, System.EventArgs e)
        {
	
            //if (txtDate.Text == "")
            //{
            //    txtDate.Text = "";
            //    txtDate.Select();
            //}
            //else if (!txtDate.Text.Trim().StartsWith("1."))
            //{
            //    if (File.Exists(Application.StartupPath + "\\TemplateDT\\Bop.wav"))
            //    {
            //        SoundPlayer a = new SoundPlayer(Application.StartupPath + "\\TemplateDT\\Bop.wav");
            //        a.Play();
            //    }
		        
            //    txtDate.Text = "";
            //    txtDate.Select();
            //}
            //else
            //{
            //    txtSize.Text = "";
            //    txtSize.Select();
            //}
	
        }

        private void txtSize_Leave(System.Object sender, System.EventArgs e)
        {
            //if (txtSize.Text == "")
            //{
            //    txtSize.Text = "";
            //    txtSize.Select();
            //}
            //else if (!txtSize.Text.Trim().StartsWith("2."))
            //{
            //    if (File.Exists(Application.StartupPath + "\\TemplateDT\\Bop.wav"))
            //    {
            //        SoundPlayer a = new SoundPlayer(Application.StartupPath + "\\TemplateDT\\Bop.wav");
            //        a.Play();
            //    }
            //    txtSize.Text = "";
            //    txtSize.Select();
            //}
            //else
            //{
            //    txtName.Text = "";
            //    txtName.Select();
            //}
        }

        private void txtName_Leave(System.Object sender, System.EventArgs e)
        {
            //if (txtName.Text == "")
            //{
            //    txtName.Text = "";
            //    txtName.Select();
            //}
            //else
            //{
            //    //Kiểm tra tại đây
            //    if (txtDate.Text != "")
            //    {
            //        if (grvDataNeedCompare.Rows.Count > 0)
            //        {
            //            try
            //            {
            //                grvDataNeedCompare.Rows.RemoveAt(0);
            //            }
            //            catch (Exception)
            //            {
            //            }
            //        }
            //        grvDataNeedCompare.Rows.Add(txtName.Text.Trim(), txtSize.Text.Trim(), txtDate.Text.Trim(), DateString((string) (txtDate.Text.Trim().Substring(2))));
            //    }
		
            //    //txtName.Text = ""
            //    txtSize.Text = "";
            //    txtDate.Text = "";
		
            //    txtDate.Select();
            //}
        }
    }
}
