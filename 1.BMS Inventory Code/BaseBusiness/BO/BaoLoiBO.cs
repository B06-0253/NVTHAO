
using System;
using System.Collections;
using DevExpress.XtraGrid.Views.Grid;
using BMS.Facade;
using BMS.Model;
using System.Data;
namespace BMS.Business
{
	public class BaoLoiBO : BaseBO
	{
		private BaoLoiFacade facade = BaoLoiFacade.Instance;
		protected static BaoLoiBO instance = new BaoLoiBO();

		protected BaoLoiBO()
		{
			this.baseFacade = facade;
		}

		public static BaoLoiBO Instance
		{
			get { return instance; }
		}
	
		public static DataTable KhoiTaoGrid()
        {
			DataTable dt = new DataTable();
			
			dt.Columns.Add("ID", typeof(int ));
			dt.Columns.Add("VanDe", typeof(string ));
			dt.Columns.Add("HangMuc", typeof(string ));
			dt.Columns.Add("YeuCau", typeof(string ));
			dt.Columns.Add("NguoiPhatHien", typeof(string ));
			dt.Columns.Add("NgayYeuCau", typeof(DateTime ));
			dt.Columns.Add("TinhTrangLoi", typeof(string ));
			dt.Columns.Add("FileDinhKem", typeof(string ));
			dt.Columns.Add("TinhTrangKhacPhuc", typeof(string ));
			dt.Columns.Add("NguoiKhacPhuc", typeof(string ));
			dt.Columns.Add("NgayKhacPhucXong", typeof(string ));
			dt.Columns.Add("MucDoUuTien", typeof(string ));
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
					BaoLoiModel model = new BaoLoiModel();
					 
					model.ID =item["ID"].ToString(); 
					model.VanDe =item["VanDe"].ToString(); 
					model.HangMuc =item["HangMuc"].ToString(); 
					model.YeuCau =item["YeuCau"].ToString(); 
					model.NguoiPhatHien =item["NguoiPhatHien"].ToString(); 
					model.NgayYeuCau =item["NgayYeuCau"].ToString(); 
					model.TinhTrangLoi =item["TinhTrangLoi"].ToString(); 
					model.FileDinhKem =item["FileDinhKem"].ToString(); 
					model.TinhTrangKhacPhuc =item["TinhTrangKhacPhuc"].ToString(); 
					model.NguoiKhacPhuc =item["NguoiKhacPhuc"].ToString(); 
					model.NgayKhacPhucXong =item["NgayKhacPhucXong"].ToString(); 
					model.MucDoUuTien =item["MucDoUuTien"].ToString();
					if (item["ID"] == DBNull.Value) //add new)
					{
						BaoLoiBO.Instance.Insert(model);
					}
					else
					{
						model.ID = Convert.ToInt32(item["ID"].ToString());
						BaoLoiBO.Instance.Update(model);
					}
				}
			}
		}
		
		*/
	}
}
	