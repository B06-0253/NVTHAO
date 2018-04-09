
using System.Collections;
using TPA.Model;
namespace TPA.Facade
{
	
	public class C_CostQuotationItemLinkFacade : BaseFacade
	{
		protected static C_CostQuotationItemLinkFacade instance = new C_CostQuotationItemLinkFacade(new C_CostQuotationItemLinkModel());
		protected C_CostQuotationItemLinkFacade(C_CostQuotationItemLinkModel model) : base(model)
		{
		}
		public static C_CostQuotationItemLinkFacade Instance
		{
			get { return instance; }
		}
		protected C_CostQuotationItemLinkFacade():base() 
		{ 
		} 
	
	}
}
	