
using System.Collections;
using TPA.Model;
namespace TPA.Facade
{
	
	public class C_CostQuotationLinkFacade : BaseFacade
	{
		protected static C_CostQuotationLinkFacade instance = new C_CostQuotationLinkFacade(new C_CostQuotationLinkModel());
		protected C_CostQuotationLinkFacade(C_CostQuotationLinkModel model) : base(model)
		{
		}
		public static C_CostQuotationLinkFacade Instance
		{
			get { return instance; }
		}
		protected C_CostQuotationLinkFacade():base() 
		{ 
		} 
	
	}
}
	