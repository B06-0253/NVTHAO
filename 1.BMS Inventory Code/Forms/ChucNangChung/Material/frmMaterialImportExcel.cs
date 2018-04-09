
using Excel = Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.OleDb;
using BMS.Business;
using BMS.Model;
using BMS.Utils;
using System.IO;
using System.Collections;
using DevExpress.Utils;

namespace BMS
{
    public partial class frmMaterialImportExcel : _Forms
    {
        private MaterialGroupModel Model = new MaterialGroupModel();
        DataTable dtReport = new DataTable();
        string CodeExist = "";

        public frmMaterialImportExcel()
        {
            InitializeComponent();
            dtReport.Columns.Add("Code");
        }

        #region Funcitions
        void Save()
        {
            //ProcessTransaction pt = new ProcessTransaction();
            //pt.OpenConnection();
            //pt.BeginTransaction();
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát", "Đang tạo thông số vật tư"))
            {
                try
                {
                    string parentGroupCode = Path.GetFileNameWithoutExtension(btnBrowse.Text);
                    ArrayList listGroup = MaterialGroupBO.Instance.FindByAttribute("Code", parentGroupCode);
                    MaterialGroupModel parentGroup = (MaterialGroupModel)listGroup[0];
                    string currentGroup = "TPAVT." + cboSheet.SelectedValue.ToString().Split('-')[0].Trim();

                    #region Material Group
                    MaterialGroupModel thisGroup;
                    if (!MaterialGroupBO.Instance.CheckExist("Code", currentGroup))
                    {
                        thisGroup = new MaterialGroupModel();
                        thisGroup.Code = currentGroup;
                        thisGroup.Name = cboSheet.SelectedValue.ToString().Split('-')[1].Trim();
                        thisGroup.CreatedDate = TextUtils.GetSystemDate();
                        thisGroup.CreatedBy = Global.AppUserName;
                        thisGroup.UpdatedDate = thisGroup.CreatedDate;
                        thisGroup.UpdatedBy = Global.AppUserName;
                        //thisGroup.ID = (int)pt.Insert(thisGroup);
                        thisGroup.ID = (int)MaterialGroupBO.Instance.Insert(thisGroup);
                    }
                    else
                    {
                        thisGroup = (MaterialGroupModel)MaterialGroupBO.Instance.FindByAttribute("Code", currentGroup)[0];
                    }
                    #endregion Material Group

                    //List<MaterialParameterValueModel> listTemParaValue = new List<MaterialParameterValueModel>();

                    for (int i = 0; i < grvData.RowCount; i++)
                    {
                        if (i == 0)
                        {
                            for (int j = 4; j < grvData.Columns.Count; j++)
                            {
                                #region Thêm thông số kỹ thuật
                                if (grvData.GetRowCellValue(i, "F" + (j + 1)) == null) continue;
                                string thisNameTS = grvData.GetRowCellValue(i, "F" + (j + 1)).ToString().Trim();
                                if (thisNameTS == "") continue;

                                DataTable dtTS = TextUtils.Select(string.Format("Select * from MaterialParameters with(nolock) where Name=N'{0}' and MaterialGroupID ={1}", thisNameTS, thisGroup.ID));
                                MaterialParametersModel modelTSVT = null;
                                if (dtTS.Rows.Count == 0)
                                {
                                    modelTSVT = new MaterialParametersModel();
                                    modelTSVT.Name = thisNameTS;
                                    modelTSVT.MaterialGroupID = thisGroup.ID;
                                    //modelTSVT.ID = (int)pt.Insert(modelTSVT);
                                    modelTSVT.ID = (int)MaterialParametersBO.Instance.Insert(modelTSVT);
                                }
                                #endregion Thông số kỹ thuật
                            }
                        }
                        else
                        {
                            if (grvData.GetRowCellValue(i, "F2") == null) continue;
                            string materialCode = grvData.GetRowCellValue(i, "F2").ToString().Trim();
                            if (materialCode == "") continue;

                            #region Check Customer
                            string customerCode = grvData.GetRowCellValue(i, "F4").ToString().Trim();
                            CustomerModel thisCustomer = null;
                            if (!CustomerBO.Instance.CheckExist("Code", customerCode))
                            {
                                thisCustomer = new CustomerModel();
                                thisCustomer.Code = customerCode.ToUpper();
                                thisCustomer.Name = customerCode.ToUpper();
                                //thisCustomer.ID = (int)pt.Insert(thisCustomer);
                                thisCustomer.ID = (int)CustomerBO.Instance.Insert(thisCustomer);
                                if (!DocUtils.CheckExits("Datasheet" + "/" + customerCode.ToUpper()))
                                {
                                    DocUtils.MakeDir("Datasheet" + "/" + customerCode.ToUpper());
                                }
                            }
                            else
                            {
                                thisCustomer = (CustomerModel)CustomerBO.Instance.FindByAttribute("Code", customerCode)[0];
                            }
                            #endregion Check Customer

                            #region Check Material
                            MaterialModel thisMaterial;
                            string materialName = grvData.GetRowCellValue(i, "F3").ToString().Trim();
                            if (!MaterialBO.Instance.CheckExist("Code", materialCode))
                            {
                                thisMaterial = new MaterialModel();
                                thisMaterial.Code = materialCode;
                                thisMaterial.Name = materialName;
                                thisMaterial.CustomerID = thisCustomer.ID;
                                thisMaterial.MaterialGroupID = thisGroup.ID;
                                //thisMaterial.ID = (int)pt.Insert(thisMaterial);
                                thisMaterial.ID = (int)MaterialBO.Instance.Insert(thisMaterial);
                            }
                            else
                            {
                                thisMaterial = (MaterialModel)MaterialBO.Instance.FindByAttribute("Code", materialCode)[0];
                            }
                            #endregion Check Material

                            for (int j = 4; j < grvData.Columns.Count; j++)
                            {
                                if (grvData.GetRowCellValue(i, "F" + (j + 1)) == null) continue;
                                string thisTSName = grvData.GetRowCellValue(0, "F" + (j + 1)).ToString().Trim();
                                if (thisTSName == "") continue;

                                //MaterialParametersModel modelTSVT = (MaterialParametersModel)MaterialParametersBO.Instance.
                                //    FindByExpression(new Expression("Name", thisTSName).And(new Expression("MaterialGroupID", thisGroup.ID)))[0];
                                DataTable dtTSKT = TextUtils.Select(string.Format("select * from  MaterialParameters where Name = N'{0}' and MaterialGroupID = {1}", thisTSName, thisGroup.ID));
                                if (dtTSKT.Rows.Count == 0) continue;
                                #region MaterialParameterLink
                                MaterialParameterLinkModel link = null;
                                DataTable dtlink = TextUtils.Select(string.
                                    Format("Select * from MaterialParameterLink with(nolock) where MaterialParameterID={0} and MaterialID ={1}", TextUtils.ToInt(dtTSKT.Rows[0]["ID"]), thisMaterial.ID));
                                if (dtlink.Rows.Count == 0)
                                {
                                    link = new MaterialParameterLinkModel();
                                    link.MaterialID = thisMaterial.ID;
                                    link.MaterialParameterID = TextUtils.ToInt(dtTSKT.Rows[0]["ID"]);//modelTSVT.ID;
                                    //link.ID = (int)pt.Insert(link);
                                    link.ID = (int)MaterialParameterLinkBO.Instance.Insert(link);
                                }
                                else
                                {
                                    //link = (MaterialParameterLinkModel)MaterialParameterLinkBO.Instance.FindByPK(TextUtils.ToInt(dtlink.Rows[0]["ID"]));
                                }
                                #endregion MaterialParameterLink

                                string value = grvData.GetRowCellValue(i, "F" + (j + 1)) == null ? "" : grvData.GetRowCellValue(i, "F" + (j + 1)).ToString().Trim();
                                value = value.Trim().Replace("\n", ",").Replace("_", "-");
                                if (value != "")
                                {
                                    #region MaterialParameterValue
                                    MaterialParameterValueModel paraValue = null;
                                    DataTable dtParameterValue = TextUtils.Select(string.
                                    Format("Select * from MaterialParameterValue with(nolock) where MaterialParameterID={0} and REPLACE(ParaValue,' ','') =N'{1}'",
                                    TextUtils.ToInt(dtTSKT.Rows[0]["ID"]), value.Replace(" ", "")));
                                    if (dtParameterValue.Rows.Count == 0)
                                    {
                                        paraValue = new MaterialParameterValueModel();
                                        paraValue.MaterialParameterID = TextUtils.ToInt(dtTSKT.Rows[0]["ID"]);//modelTSVT.ID;
                                        paraValue.ParaValue = value;
                                        //paraValue.ID = (int)pt.Insert(paraValue);
                                        paraValue.ID = (int)MaterialParameterValueBO.Instance.Insert(paraValue);
                                    }
                                    else
                                    {
                                        paraValue = (MaterialParameterValueModel)MaterialParameterValueBO.Instance.FindByPK(TextUtils.ToInt(dtParameterValue.Rows[0]["ID"]));
                                    }

                                    #endregion MaterialParameterValue

                                    #region MaterialConnect
                                    MaterialConnectModel connect = null;
                                    DataTable dtConnect = TextUtils.Select(string.
                                       Format("Select * from MaterialConnect with(nolock) where MaterialParameterID={0} and MaterialID ={1} and MaterialParameterValueID={2}",
                                       TextUtils.ToInt(dtTSKT.Rows[0]["ID"]), thisMaterial.ID, paraValue.ID));
                                    if (dtConnect.Rows.Count == 0)
                                    {
                                        connect = new MaterialConnectModel();
                                        connect.MaterialParameterID = TextUtils.ToInt(dtTSKT.Rows[0]["ID"]);//modelTSVT.ID;
                                        connect.MaterialID = thisMaterial.ID;
                                        connect.MaterialParameterValueID = paraValue.ID;
                                        //connect.ID = (int)pt.Insert(connect);
                                        connect.ID = (int)MaterialConnectBO.Instance.Insert(connect);
                                    }

                                    #endregion MaterialConnect
                                }
                            }
                        }
                    }

                    //pt.CommitTransaction();
                    MessageBox.Show("Thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                    //pt.CloseConnection();
                }
            }
        }

        void insertHang()
        {
            for (int i = 0; i < grvData.RowCount; i++)
            {
                string groupCode = grvData.GetRowCellValue(i, "F1").ToString().Trim();
                if (groupCode == "") continue;
                MaterialGroupModel group = (MaterialGroupModel)MaterialGroupBO.Instance.FindByAttribute("Code", groupCode)[0];
                for (int j = 2; j < grvData.Columns.Count; j++)
                {
                    try
                    {
                        string columnName = "F" + (j + 1);
                        if (grvData.GetRowCellValue(i, columnName) == null) continue;
                        if (grvData.GetRowCellValue(i, columnName).ToString() == "") continue;
                        string customerCode = grvData.GetRowCellValue(i, columnName).ToString();

                        CustomerModel customer = (CustomerModel)CustomerBO.Instance.FindByAttribute("Code", customerCode)[0];

                        DataTable dtLink = TextUtils.Select(string.Format("Select * from MaterialGroupCustomerLink with(nolock) where CustomerID={0} and MaterialGroupID ={1}", customer.ID, group.ID));

                        if (dtLink.Rows.Count==0)
                        {
                            MaterialGroupCustomerLinkModel link = new MaterialGroupCustomerLinkModel();
                            link.MaterialGroupID = group.ID;
                            link.CustomerID = customer.ID;
                            MaterialGroupCustomerLinkBO.Instance.Insert(link);
                        }
                    }
                    catch (Exception ex)
                    {
                        TextUtils.ShowError(ex);
                    }                    
                }
            }
            MessageBox.Show("OK");
        }

        void GhiGia()
        {
            for (int i = 0; i < grvData.RowCount; i++)
            {
                if (i == 0) continue;
                if (grvData.GetRowCellValue(i, "F1") == null) continue;
                string code = grvData.GetRowCellValue(i, "F1").ToString();
                if (code == "") continue;
                try
                {
                    MaterialModel material = (MaterialModel)MaterialBO.Instance.FindByAttribute("Code", code)[0];
                    material.PriceTemp = TextUtils.ToDecimal(grvData.GetRowCellValue(i, "F5") == null ? "0" : grvData.GetRowCellValue(i, "F5"));
                    material.DeliveryPeriodTemp = grvData.GetRowCellValue(i, "F6") == null ? "" : grvData.GetRowCellValue(i, "F6").ToString();
                    MaterialBO.Instance.Update(material);
                }
                catch (Exception)
                {

                }
            }
            MessageBox.Show("Thành công!");
        }

        void AddModule()
        {
            ModuleGroupModel moduleGroup = (ModuleGroupModel)ModuleGroupBO.Instance.FindByAttribute("Code", cboSheet.SelectedValue.ToString())[0];
            for (int i = 0; i < grvData.RowCount; i++)
            {
                bool isAdd = true;
                if (grvData.GetRowCellValue(i, "F3") == null) continue;

                string codeNew = grvData.GetRowCellValue(i, "F3").ToString().Trim();

                if (codeNew == "") continue;
                if (!codeNew.StartsWith("TPAD.")) continue;

                DataTable dtModuleChuan = TextUtils.Select("Select * from Modules where Status = 2 and Code ='" + codeNew + "'");

                if (dtModuleChuan.Rows.Count > 0)
                {
                    CodeExist += codeNew + Environment.NewLine;
                    continue;
                }
                else
                {
                    DataTable dtModuleKchuan = TextUtils.Select("Select * from Modules where Status <> 2 and Code ='" + codeNew + "'");
                    if (dtModuleKchuan.Rows.Count > 0)
                    {
                        isAdd = false;
                    }
                }

                string nameNew = grvData.GetRowCellValue(i, "F6") == null ? "" : grvData.GetRowCellValue(i, "F6").ToString();
                string nameOld = grvData.GetRowCellValue(i, "F5") == null ? "" : grvData.GetRowCellValue(i, "F5").ToString();
                string codeOld = grvData.GetRowCellValue(i, "F4") == null ? "" : grvData.GetRowCellValue(i, "F4").ToString();

                ModulesModel module;
                if (isAdd)
                {
                    module = new ModulesModel();
                    module.ModuleGroupID = moduleGroup.ID;
                    module.Status = 0;
                }
                else
                {
                    module = (ModulesModel)ModulesBO.Instance.FindByAttribute("Code", codeNew)[0];
                }

                module.Code = codeNew;
                module.Name = nameNew == "" ? nameOld : nameNew;
                module.Note = "Mã đã có version";
                module.Description = codeOld;

                if (isAdd)
                {
                    ModulesBO.Instance.Insert(module);
                }
                else
                {
                    ModulesBO.Instance.Update(module);
                }
            }

            MessageBox.Show(CodeExist);
            CodeExist = "";
        }

        void UpdateLoi()
        {
            List<string> listErrorCode = new List<string>();
            for (int i = 0; i < grvData.RowCount; i++)
            {
                if (i == 0) continue;
                if (grvData.GetRowCellValue(i, "F1") == null) continue;
                string code = grvData.GetRowCellValue(i, "F1").ToString();
                if (code == "") continue;
                try
                {
                    ModuleErrorModel errror = (ModuleErrorModel)ModuleErrorBO.Instance.FindByAttribute("Code", code)[0];
                    errror.Status = TextUtils.ToInt(grvData.GetRowCellValue(i, "F2").ToString().ToLower() == "ok" ? 1 : 0);
                    //errror.StatusTK = TextUtils.ToInt(grvData.GetRowCellValue(i, "F20").ToString().ToLower() == "ok" ? 1 : 0);
                    if (errror.Status == 1)
                    {
                        ModuleErrorBO.Instance.Update(errror);
                    }
                }
                catch (Exception)
                {
                    listErrorCode.Add(code);
                }
            }
            string path = "D:\\Debug.txt";
            foreach (string item in listErrorCode)
            {
                File.AppendAllText(path, item + Environment.NewLine);
            }

            MessageBox.Show("Thành công!");
        }
        #endregion

        #region Event Controls
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnBrowse_EditValueChanged(object sender, EventArgs e)
        {
            grdData.DataSource = null;
        }        

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            //UpdateLoi();
            //insertHang();
        }

        private void cboStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {                
                DataTable dt = TextUtils.ExcelToDatatableNoHeader(btnBrowse.Text, cboSheet.SelectedValue.ToString());
               
                grdData.DataSource = dt;
                grvData.PopulateColumns();
                grvData.BestFitColumns();
            }
            catch (Exception ex)
            {
                TextUtils.ShowError(ex);
                grdData.DataSource = null;
            }
        }

        private void btnBrowse_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                btnBrowse.Text = ofd.FileName;
                cboSheet.DataSource = null;
                cboSheet.DataSource = TextUtils.ListSheetInExcel(ofd.FileName);
            }
        }
        
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AddModule();
        }
        #endregion
    }
}