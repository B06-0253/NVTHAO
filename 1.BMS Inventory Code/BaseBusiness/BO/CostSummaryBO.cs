
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class CostSummaryBO : BaseBO
	{
		private CostSummaryFacade facade = CostSummaryFacade.Instance;
		protected static CostSummaryBO instance = new CostSummaryBO();

		protected CostSummaryBO()
		{
			this.baseFacade = facade;
		}

		public static CostSummaryBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	