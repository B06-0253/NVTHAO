
using System;
using System.Collections;
using DevExpress.XtraGrid.Views.Grid;
using BMS.Facade;
using BMS.Model;
using System.Data;
namespace BMS.Business
{
	public class SanPhamDABO : BaseBO
	{
		private SanPhamDAFacade facade = SanPhamDAFacade.Instance;
		protected static SanPhamDABO instance = new SanPhamDABO();

		protected SanPhamDABO()
		{
			this.baseFacade = facade;
		}

		public static SanPhamDABO Instance
		{
			get { return instance; }
		}
	
		public static DataTable KhoiTaoGrid()
        {
			DataTable dt = new DataTable();
			
			dt.Columns.Add("ID", typeof(int ));
			dt.Columns.Add("ProjectsID", typeof(string ));
			dt.Columns.Add("TenTheoHopDong", typeof(string ));
			dt.Columns.Add("MaTheoHopDong", typeof(string ));
			dt.Columns.Add("TenTheoThietKe", typeof(string ));
			dt.Columns.Add("MaTheoThietKe", typeof(string ));
			dt.Columns.Add("ThoiGianThietKe", typeof(int ));
			dt.Columns.Add("ThoiGianBDDuKien", typeof(DateTime ));
			dt.Columns.Add("ThoiGianKTDuKien", typeof(DateTime ));
			dt.Columns.Add("ThoiGianBDThucTe", typeof(string ));
			dt.Columns.Add("ThoiGianKTThucTe", typeof(string ));
			dt.Columns.Add("TinhTrang", typeof(string ));
			dt.Columns.Add("NhomPhuTrach", typeof(string ));
			dt.Columns.Add("MucDoUuTien", typeof(string ));
			dt.Columns.Add("LoaiCongViec", typeof(string ));
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
					SanPhamDAModel model = new SanPhamDAModel();
					 
					model.ID =item["ID"].ToString(); 
					model.ProjectsID =item["ProjectsID"].ToString(); 
					model.TenTheoHopDong =item["TenTheoHopDong"].ToString(); 
					model.MaTheoHopDong =item["MaTheoHopDong"].ToString(); 
					model.TenTheoThietKe =item["TenTheoThietKe"].ToString(); 
					model.MaTheoThietKe =item["MaTheoThietKe"].ToString(); 
					model.ThoiGianThietKe =item["ThoiGianThietKe"].ToString(); 
					model.ThoiGianBDDuKien =item["ThoiGianBDDuKien"].ToString(); 
					model.ThoiGianKTDuKien =item["ThoiGianKTDuKien"].ToString(); 
					model.ThoiGianBDThucTe =item["ThoiGianBDThucTe"].ToString(); 
					model.ThoiGianKTThucTe =item["ThoiGianKTThucTe"].ToString(); 
					model.TinhTrang =item["TinhTrang"].ToString(); 
					model.NhomPhuTrach =item["NhomPhuTrach"].ToString(); 
					model.MucDoUuTien =item["MucDoUuTien"].ToString(); 
					model.LoaiCongViec =item["LoaiCongViec"].ToString();
					if (item["ID"] == DBNull.Value) //add new)
					{
						SanPhamDABO.Instance.Insert(model);
					}
					else
					{
						model.ID = Convert.ToInt32(item["ID"].ToString());
						SanPhamDABO.Instance.Update(model);
					}
				}
			}
		}
		
		*/
	}
}
	