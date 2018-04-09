
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
{
	
	public class WorkingDiariesBO : BaseBO
	{
		private WorkingDiariesFacade facade = WorkingDiariesFacade.Instance;
		protected static WorkingDiariesBO instance = new WorkingDiariesBO();

		protected WorkingDiariesBO()
		{
			this.baseFacade = facade;
		}

		public static WorkingDiariesBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	