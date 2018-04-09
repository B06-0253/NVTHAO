
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{

    public class WorkStatusFacade : BaseFacade
	{
		protected static WorkStatusFacade instance = new WorkStatusFacade(new WorkStatusModel());
		protected WorkStatusFacade(WorkStatusModel model) : base(model)
		{
		}
		public static WorkStatusFacade Instance
		{
			get { return instance; }
		}
		protected WorkStatusFacade():base() 
		{ 
		} 
	
	}
}
	