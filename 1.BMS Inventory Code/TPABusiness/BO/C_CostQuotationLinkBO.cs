
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
{
	
	public class C_CostQuotationLinkBO : BaseBO
	{
		private C_CostQuotationLinkFacade facade = C_CostQuotationLinkFacade.Instance;
		protected static C_CostQuotationLinkBO instance = new C_CostQuotationLinkBO();

		protected C_CostQuotationLinkBO()
		{
			this.baseFacade = facade;
		}

		public static C_CostQuotationLinkBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	