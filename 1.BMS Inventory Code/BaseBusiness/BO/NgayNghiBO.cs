
using System;
using System.Collections;
using DevExpress.XtraGrid.Views.Grid;
using BMS.Facade;
using BMS.Model;
using System.Data;
namespace BMS.Business
{
	public class NgayNghiBO : BaseBO
	{
		private NgayNghiFacade facade = NgayNghiFacade.Instance;
		protected static NgayNghiBO instance = new NgayNghiBO();

		protected NgayNghiBO()
		{
			this.baseFacade = facade;
		}

		public static NgayNghiBO Instance
		{
			get { return instance; }
		}
	
		public static DataTable KhoiTaoGrid()
        {
			DataTable dt = new DataTable();
			
			dt.Columns.Add("ID", typeof(int ));
			dt.Columns.Add("NgayNghi", typeof(DateTime ));
			return dt;
		}
		
		/*
		public static void SaveToTable(DataTable dt)
		{
			DataTable dtRemine;
			dtRemine = dt.GetChanges();
			if (dtRemine != null)
			{
				foreach (DataRow item in dtRemine.Rows)
				{
					NgayNghiModel model = new NgayNghiModel();
					 
					model.ID =item["ID"].ToString(); 
					model.NgayNghi =item["NgayNghi"].ToString();
					if (item["ID"] == DBNull.Value) //add new)
					{
						NgayNghiBO.Instance.Insert(model);
					}
					else
					{
						model.ID = Convert.ToInt32(item["ID"].ToString());
						NgayNghiBO.Instance.Update(model);
					}
				}
			}
		}
		
		*/
	}
}
	