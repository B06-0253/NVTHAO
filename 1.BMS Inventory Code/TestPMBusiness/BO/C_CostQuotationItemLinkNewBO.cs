
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class C_CostQuotationItemLinkNewBO : BaseBO
	{
		private C_CostQuotationItemLinkNewFacade facade = C_CostQuotationItemLinkNewFacade.Instance;
		protected static C_CostQuotationItemLinkNewBO instance = new C_CostQuotationItemLinkNewBO();

		protected C_CostQuotationItemLinkNewBO()
		{
			this.baseFacade = facade;
		}

		public static C_CostQuotationItemLinkNewBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	