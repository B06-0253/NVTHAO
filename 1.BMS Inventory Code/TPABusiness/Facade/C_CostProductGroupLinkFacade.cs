
using System.Collections;
using TPA.Model;
namespace TPA.Facade
{
	
	public class C_CostProductGroupLinkFacade : BaseFacade
	{
		protected static C_CostProductGroupLinkFacade instance = new C_CostProductGroupLinkFacade(new C_CostProductGroupLinkModel());
		protected C_CostProductGroupLinkFacade(C_CostProductGroupLinkModel model) : base(model)
		{
		}
		public static C_CostProductGroupLinkFacade Instance
		{
			get { return instance; }
		}
		protected C_CostProductGroupLinkFacade():base() 
		{ 
		} 
	
	}
}
	