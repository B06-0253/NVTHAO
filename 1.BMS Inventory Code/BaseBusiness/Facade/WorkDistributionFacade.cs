
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class WorkDistributionFacade : BaseFacade
	{
		protected static WorkDistributionFacade instance = new WorkDistributionFacade(new WorkDistributionModel());
		protected WorkDistributionFacade(WorkDistributionModel model) : base(model)
		{
		}
		public static WorkDistributionFacade Instance
		{
			get { return instance; }
		}
		protected WorkDistributionFacade():base() 
		{ 
		} 
	
	}
}
	