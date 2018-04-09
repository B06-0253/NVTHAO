
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class SolutionFileTypeBO : BaseBO
	{
		private SolutionFileTypeFacade facade = SolutionFileTypeFacade.Instance;
		protected static SolutionFileTypeBO instance = new SolutionFileTypeBO();

		protected SolutionFileTypeBO()
		{
			this.baseFacade = facade;
		}

		public static SolutionFileTypeBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	