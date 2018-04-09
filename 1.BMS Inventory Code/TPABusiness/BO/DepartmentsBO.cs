
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
{
	
	public class DepartmentsBO : BaseBO
	{
		private DepartmentsFacade facade = DepartmentsFacade.Instance;
		protected static DepartmentsBO instance = new DepartmentsBO();

		protected DepartmentsBO()
		{
			this.baseFacade = facade;
		}

		public static DepartmentsBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	