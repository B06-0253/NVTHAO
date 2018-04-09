
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{

    public class WorksFacade : BaseFacade
	{
		protected static WorksFacade instance = new WorksFacade(new WorksModel());
		protected WorksFacade(WorksModel model) : base(model)
		{
		}
		public static WorksFacade Instance
		{
			get { return instance; }
		}
		protected WorksFacade():base() 
		{ 
		} 
	
	}
}
	