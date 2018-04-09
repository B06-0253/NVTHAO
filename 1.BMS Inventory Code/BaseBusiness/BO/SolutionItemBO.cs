
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class SolutionItemBO : BaseBO
	{
		private SolutionItemFacade facade = SolutionItemFacade.Instance;
		protected static SolutionItemBO instance = new SolutionItemBO();

		protected SolutionItemBO()
		{
			this.baseFacade = facade;
		}

		public static SolutionItemBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	