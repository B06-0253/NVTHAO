
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class CostDetailDepartmentLinkFacade : BaseFacade
	{
		protected static CostDetailDepartmentLinkFacade instance = new CostDetailDepartmentLinkFacade(new CostDetailDepartmentLinkModel());
		protected CostDetailDepartmentLinkFacade(CostDetailDepartmentLinkModel model) : base(model)
		{
		}
		public static CostDetailDepartmentLinkFacade Instance
		{
			get { return instance; }
		}
		protected CostDetailDepartmentLinkFacade():base() 
		{ 
		} 
	
	}
}
	