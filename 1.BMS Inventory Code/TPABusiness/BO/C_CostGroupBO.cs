
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
{
	
	public class C_CostGroupBO : BaseBO
	{
		private C_CostGroupFacade facade = C_CostGroupFacade.Instance;
		protected static C_CostGroupBO instance = new C_CostGroupBO();

		protected C_CostGroupBO()
		{
			this.baseFacade = facade;
		}

		public static C_CostGroupBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	