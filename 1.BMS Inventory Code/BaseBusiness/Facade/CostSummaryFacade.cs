
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class CostSummaryFacade : BaseFacade
	{
		protected static CostSummaryFacade instance = new CostSummaryFacade(new CostSummaryModel());
		protected CostSummaryFacade(CostSummaryModel model) : base(model)
		{
		}
		public static CostSummaryFacade Instance
		{
			get { return instance; }
		}
		protected CostSummaryFacade():base() 
		{ 
		} 
	
	}
}
	