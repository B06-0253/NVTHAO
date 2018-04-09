
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class CostSummaryModuleFacade : BaseFacade
	{
		protected static CostSummaryModuleFacade instance = new CostSummaryModuleFacade(new CostSummaryModuleModel());
		protected CostSummaryModuleFacade(CostSummaryModuleModel model) : base(model)
		{
		}
		public static CostSummaryModuleFacade Instance
		{
			get { return instance; }
		}
		protected CostSummaryModuleFacade():base() 
		{ 
		} 
	
	}
}
	