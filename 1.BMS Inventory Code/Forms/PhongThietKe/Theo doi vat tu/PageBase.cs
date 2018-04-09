using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Configuration;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;

namespace BMS
{
   public class PageBase
   {
      public static void StateButton(bool sStateButton,DevExpress.XtraBars.BarButtonItem sAddNew,DevExpress.XtraBars.BarButtonItem sEdit,DevExpress.XtraBars.BarButtonItem sSave,DevExpress.XtraBars.BarButtonItem sCancel,DevExpress.XtraBars.BarButtonItem sDelete)
      {
         if(sStateButton == true)
         {
            sAddNew.Enabled = false;
            sEdit.Enabled = false;
            sSave.Enabled = true;
            sCancel.Enabled = true;
            sDelete.Enabled = false;
         }
         else
         {
            sAddNew.Enabled = true;
            sEdit.Enabled = true;
            sSave.Enabled = false;
            sCancel.Enabled = false;
            sDelete.Enabled = true;
         }
      }
      public static void StateButton(bool sStateButton, System.Windows.Forms.ToolStripButton sAddNew, System.Windows.Forms.ToolStripButton sEdit, System.Windows.Forms.ToolStripButton sSave, System.Windows.Forms.ToolStripButton sCancel, System.Windows.Forms.ToolStripButton sDelete)
      {
          if (sStateButton == true)
          {
              sAddNew.Visible = false;
              sEdit.Visible = false;
              sSave.Visible = true;
              sCancel.Visible = true;
              sDelete.Visible = false;
          }
          else
          {
              sAddNew.Visible = true;
              sEdit.Visible = true;
              sSave.Visible = false;
              sCancel.Visible = false;
              sDelete.Visible = true;
          }
      }
      public static void VisibleColumnInGrid(DevExpress.XtraGrid.Views.Grid.GridView grv,bool bValue)
      {
         foreach(DevExpress.XtraGrid.Columns.GridColumn col in grv.Columns)
         {
            if(bValue == true)
            {
               col.OptionsColumn.AllowEdit = true;
            }
            else
            {
               col.OptionsColumn.AllowEdit = false;
            }
         }
      }
   }
}
