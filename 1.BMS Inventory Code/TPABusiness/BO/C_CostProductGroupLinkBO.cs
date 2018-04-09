
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
{
	
	public class C_CostProductGroupLinkBO : BaseBO
	{
		private C_CostProductGroupLinkFacade facade = C_CostProductGroupLinkFacade.Instance;
		protected static C_CostProductGroupLinkBO instance = new C_CostProductGroupLinkBO();

		protected C_CostProductGroupLinkBO()
		{
			this.baseFacade = facade;
		}

		public static C_CostProductGroupLinkBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	