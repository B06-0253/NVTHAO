
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class SolutionMeetingBO : BaseBO
	{
		private SolutionMeetingFacade facade = SolutionMeetingFacade.Instance;
		protected static SolutionMeetingBO instance = new SolutionMeetingBO();

		protected SolutionMeetingBO()
		{
			this.baseFacade = facade;
		}

		public static SolutionMeetingBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	