
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
{
	
	public class WorkingDiariesLocationBO : BaseBO
	{
		private WorkingDiariesLocationFacade facade = WorkingDiariesLocationFacade.Instance;
		protected static WorkingDiariesLocationBO instance = new WorkingDiariesLocationBO();

		protected WorkingDiariesLocationBO()
		{
			this.baseFacade = facade;
		}

		public static WorkingDiariesLocationBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	