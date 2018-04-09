
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class SolutionTechnologyBO : BaseBO
	{
		private SolutionTechnologyFacade facade = SolutionTechnologyFacade.Instance;
		protected static SolutionTechnologyBO instance = new SolutionTechnologyBO();

		protected SolutionTechnologyBO()
		{
			this.baseFacade = facade;
		}

		public static SolutionTechnologyBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	