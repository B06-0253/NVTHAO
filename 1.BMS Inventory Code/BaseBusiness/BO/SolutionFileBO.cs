
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class SolutionFileBO : BaseBO
	{
		private SolutionFileFacade facade = SolutionFileFacade.Instance;
		protected static SolutionFileBO instance = new SolutionFileBO();

		protected SolutionFileBO()
		{
			this.baseFacade = facade;
		}

		public static SolutionFileBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	