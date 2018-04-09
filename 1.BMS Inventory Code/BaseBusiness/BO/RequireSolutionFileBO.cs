
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class RequireSolutionFileBO : BaseBO
	{
		private RequireSolutionFileFacade facade = RequireSolutionFileFacade.Instance;
		protected static RequireSolutionFileBO instance = new RequireSolutionFileBO();

		protected RequireSolutionFileBO()
		{
			this.baseFacade = facade;
		}

		public static RequireSolutionFileBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	