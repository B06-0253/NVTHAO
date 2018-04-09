
using System;
using System.Collections;
using DevExpress.XtraGrid.Views.Grid;
using BMS.Facade;
using BMS.Model;
using System.Data;
namespace BMS.Business
{
	public class HangMucCongViecBO : BaseBO
	{
		private HangMucCongViecFacade facade = HangMucCongViecFacade.Instance;
		protected static HangMucCongViecBO instance = new HangMucCongViecBO();

		protected HangMucCongViecBO()
		{
			this.baseFacade = facade;
		}

		public static HangMucCongViecBO Instance
		{
			get { return instance; }
		}
	
		public static DataTable KhoiTaoGrid()
        {
			DataTable dt = new DataTable();
			
			dt.Columns.Add("ID", typeof(int ));
			dt.Columns.Add("TenHangMuc", typeof(string ));
			dt.Columns.Add("ThoiGianTK", typeof(int ));
			dt.Columns.Add("ThoiGianBDDuKien", typeof(DateTime ));
			dt.Columns.Add("ThoiGianKTDuKien", typeof(DateTime ));
			dt.Columns.Add("ThoiGianBDThucTe", typeof(string ));
			dt.Columns.Add("ThoiGianKTThucTe", typeof(string ));
			dt.Columns.Add("NguoiThietKe", typeof(string ));
			dt.Columns.Add("MucDoUuTien", typeof(string ));
			dt.Columns.Add("TinhTrang", typeof(string ));
			dt.Columns.Add("KieuCongViec", typeof(string ));
			dt.Columns.Add("Loi", typeof(string ));
			dt.Columns.Add("SanPhamDAID", typeof(int ));
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
					HangMucCongViecModel model = new HangMucCongViecModel();
					 
					model.ID =item["ID"].ToString(); 
					model.TenHangMuc =item["TenHangMuc"].ToString(); 
					model.ThoiGianTK =item["ThoiGianTK"].ToString(); 
					model.ThoiGianBDDuKien =item["ThoiGianBDDuKien"].ToString(); 
					model.ThoiGianKTDuKien =item["ThoiGianKTDuKien"].ToString(); 
					model.ThoiGianBDThucTe =item["ThoiGianBDThucTe"].ToString(); 
					model.ThoiGianKTThucTe =item["ThoiGianKTThucTe"].ToString(); 
					model.NguoiThietKe =item["NguoiThietKe"].ToString(); 
					model.MucDoUuTien =item["MucDoUuTien"].ToString(); 
					model.TinhTrang =item["TinhTrang"].ToString(); 
					model.KieuCongViec =item["KieuCongViec"].ToString(); 
					model.Loi =item["Loi"].ToString(); 
					model.SanPhamDAID =item["SanPhamDAID"].ToString();
					if (item["ID"] == DBNull.Value) //add new)
					{
						HangMucCongViecBO.Instance.Insert(model);
					}
					else
					{
						model.ID = Convert.ToInt32(item["ID"].ToString());
						HangMucCongViecBO.Instance.Update(model);
					}
				}
			}
		}
		
		*/
	}
}
	