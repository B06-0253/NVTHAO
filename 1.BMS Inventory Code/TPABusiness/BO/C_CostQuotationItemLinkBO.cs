
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
{
	
	public class C_CostQuotationItemLinkBO : BaseBO
	{
		private C_CostQuotationItemLinkFacade facade = C_CostQuotationItemLinkFacade.Instance;
		protected static C_CostQuotationItemLinkBO instance = new C_CostQuotationItemLinkBO();

		protected C_CostQuotationItemLinkBO()
		{
			this.baseFacade = facade;
		}

		public static C_CostQuotationItemLinkBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	