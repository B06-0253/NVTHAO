
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class SolutionMeetingFacade : BaseFacade
	{
		protected static SolutionMeetingFacade instance = new SolutionMeetingFacade(new SolutionMeetingModel());
		protected SolutionMeetingFacade(SolutionMeetingModel model) : base(model)
		{
		}
		public static SolutionMeetingFacade Instance
		{
			get { return instance; }
		}
		protected SolutionMeetingFacade():base() 
		{ 
		} 
	
	}
}
	