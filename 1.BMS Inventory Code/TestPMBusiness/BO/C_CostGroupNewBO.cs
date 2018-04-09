
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class C_CostGroupNewBO : BaseBO
	{
		private C_CostGroupNewFacade facade = C_CostGroupNewFacade.Instance;
		protected static C_CostGroupNewBO instance = new C_CostGroupNewBO();

		protected C_CostGroupNewBO()
		{
			this.baseFacade = facade;
		}

		public static C_CostGroupNewBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	