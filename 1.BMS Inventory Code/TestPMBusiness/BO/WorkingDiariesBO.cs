
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
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
	