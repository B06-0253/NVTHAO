
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class CostSummaryModuleBO : BaseBO
	{
		private CostSummaryModuleFacade facade = CostSummaryModuleFacade.Instance;
		protected static CostSummaryModuleBO instance = new CostSummaryModuleBO();

		protected CostSummaryModuleBO()
		{
			this.baseFacade = facade;
		}

		public static CostSummaryModuleBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	