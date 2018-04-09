
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class CostLinkBO : BaseBO
	{
		private CostLinkFacade facade = CostLinkFacade.Instance;
		protected static CostLinkBO instance = new CostLinkBO();

		protected CostLinkBO()
		{
			this.baseFacade = facade;
		}

		public static CostLinkBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	