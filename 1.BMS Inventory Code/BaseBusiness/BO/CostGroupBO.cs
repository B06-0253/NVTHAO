
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class CostGroupBO : BaseBO
	{
		private CostGroupFacade facade = CostGroupFacade.Instance;
		protected static CostGroupBO instance = new CostGroupBO();

		protected CostGroupBO()
		{
			this.baseFacade = facade;
		}

		public static CostGroupBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	