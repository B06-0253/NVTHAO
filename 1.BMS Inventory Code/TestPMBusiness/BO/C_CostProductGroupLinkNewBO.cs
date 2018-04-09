
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class C_CostProductGroupLinkNewBO : BaseBO
	{
		private C_CostProductGroupLinkNewFacade facade = C_CostProductGroupLinkNewFacade.Instance;
		protected static C_CostProductGroupLinkNewBO instance = new C_CostProductGroupLinkNewBO();

		protected C_CostProductGroupLinkNewBO()
		{
			this.baseFacade = facade;
		}

		public static C_CostProductGroupLinkNewBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	