
using System.Collections;
using TPA.Model;
namespace TPA.Facade
{
	
	public class DepartmentsFacade : BaseFacade
	{
		protected static DepartmentsFacade instance = new DepartmentsFacade(new DepartmentsModel());
		protected DepartmentsFacade(DepartmentsModel model) : base(model)
		{
		}
		public static DepartmentsFacade Instance
		{
			get { return instance; }
		}
		protected DepartmentsFacade():base() 
		{ 
		} 
	
	}
}
	