
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class RequireSolutionBO : BaseBO
	{
		private RequireSolutionFacade facade = RequireSolutionFacade.Instance;
		protected static RequireSolutionBO instance = new RequireSolutionBO();

		protected RequireSolutionBO()
		{
			this.baseFacade = facade;
		}

		public static RequireSolutionBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	