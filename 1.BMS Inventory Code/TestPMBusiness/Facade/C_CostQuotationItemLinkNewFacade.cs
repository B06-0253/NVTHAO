
using System.Collections;
using TEST.Model;
namespace TEST.Facade
{
	
	public class C_CostQuotationItemLinkNewFacade : BaseFacade
	{
		protected static C_CostQuotationItemLinkNewFacade instance = new C_CostQuotationItemLinkNewFacade(new C_CostQuotationItemLinkNewModel());
		protected C_CostQuotationItemLinkNewFacade(C_CostQuotationItemLinkNewModel model) : base(model)
		{
		}
		public static C_CostQuotationItemLinkNewFacade Instance
		{
			get { return instance; }
		}
		protected C_CostQuotationItemLinkNewFacade():base() 
		{ 
		} 
	
	}
}
	