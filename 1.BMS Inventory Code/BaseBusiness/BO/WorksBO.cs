
using System;
using System.Collections;
using BMS.Utils;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class WorksBO : BaseBO
	{
		private WorksFacade facade = WorksFacade.Instance;
		protected static WorksBO instance = new WorksBO();

		protected WorksBO()
		{
			this.baseFacade = facade;
		}

		public static WorksBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	