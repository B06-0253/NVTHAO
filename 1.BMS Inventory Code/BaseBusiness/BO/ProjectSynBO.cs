
using System;
using System.Collections;
using DevExpress.XtraGrid.Views.Grid;
using BMS.Facade;
using BMS.Model;
using System.Data;
namespace BMS.Business
{
	public class ProjectSynBO : BaseBO
	{
		private ProjectSynFacade facade = ProjectSynFacade.Instance;
		protected static ProjectSynBO instance = new ProjectSynBO();

		protected ProjectSynBO()
		{
			this.baseFacade = facade;
		}

		public static ProjectSynBO Instance
		{
			get { return instance; }
		}
	
		public static DataTable KhoiTaoGrid()
        {
			DataTable dt = new DataTable();
			
			dt.Columns.Add("ProjectId", typeof(string ));
			dt.Columns.Add("CustomerId", typeof(string ));
			dt.Columns.Add("ProjectName", typeof(string ));
			dt.Columns.Add("ProjectCode", typeof(string ));
			dt.Columns.Add("TimeMake", typeof(int ));
			dt.Columns.Add("DateFinishE", typeof(DateTime ));
			dt.Columns.Add("DateFinishF", typeof(DateTime ));
			dt.Columns.Add("Note", typeof(string ));
			dt.Columns.Add("Status", typeof(int ));
			dt.Columns.Add("ProjectType", typeof(int ));
			dt.Columns.Add("DateCreate", typeof(DateTime ));
			dt.Columns.Add("StatusDisable", typeof(int ));
			dt.Columns.Add("UserId", typeof(string ));
			dt.Columns.Add("DateSingingContract", typeof(DateTime ));
			dt.Columns.Add("ID", typeof(int ));
			dt.Columns.Add("TenKhachHangDau", typeof(string ));
			dt.Columns.Add("TenKhachHangCuoi", typeof(string ));
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
					ProjectSynModel model = new ProjectSynModel();
					 
					model.ProjectId =item["ProjectId"].ToString(); 
					model.CustomerId =item["CustomerId"].ToString(); 
					model.ProjectName =item["ProjectName"].ToString(); 
					model.ProjectCode =item["ProjectCode"].ToString(); 
					model.TimeMake =item["TimeMake"].ToString(); 
					model.DateFinishE =item["DateFinishE"].ToString(); 
					model.DateFinishF =item["DateFinishF"].ToString(); 
					model.Note =item["Note"].ToString(); 
					model.Status =item["Status"].ToString(); 
					model.ProjectType =item["ProjectType"].ToString(); 
					model.DateCreate =item["DateCreate"].ToString(); 
					model.StatusDisable =item["StatusDisable"].ToString(); 
					model.UserId =item["UserId"].ToString(); 
					model.DateSingingContract =item["DateSingingContract"].ToString(); 
					model.ID =item["ID"].ToString(); 
					model.TenKhachHangDau =item["TenKhachHangDau"].ToString(); 
					model.TenKhachHangCuoi =item["TenKhachHangCuoi"].ToString();
					if (item["ID"] == DBNull.Value) //add new)
					{
						ProjectSynBO.Instance.Insert(model);
					}
					else
					{
						model.ID = Convert.ToInt32(item["ID"].ToString());
						ProjectSynBO.Instance.Update(model);
					}
				}
			}
		}
		
		*/
	}
}
	