
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class SolutionBO : BaseBO
	{
		private SolutionFacade facade = SolutionFacade.Instance;
		protected static SolutionBO instance = new SolutionBO();

		protected SolutionBO()
		{
			this.baseFacade = facade;
		}

		public static SolutionBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	