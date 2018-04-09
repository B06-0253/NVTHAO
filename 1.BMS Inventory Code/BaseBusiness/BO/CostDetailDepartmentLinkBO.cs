
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class CostDetailDepartmentLinkBO : BaseBO
	{
		private CostDetailDepartmentLinkFacade facade = CostDetailDepartmentLinkFacade.Instance;
		protected static CostDetailDepartmentLinkBO instance = new CostDetailDepartmentLinkBO();

		protected CostDetailDepartmentLinkBO()
		{
			this.baseFacade = facade;
		}

		public static CostDetailDepartmentLinkBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	