
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class CostDetailBO : BaseBO
	{
		private CostDetailFacade facade = CostDetailFacade.Instance;
		protected static CostDetailBO instance = new CostDetailBO();

		protected CostDetailBO()
		{
			this.baseFacade = facade;
		}

		public static CostDetailBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	