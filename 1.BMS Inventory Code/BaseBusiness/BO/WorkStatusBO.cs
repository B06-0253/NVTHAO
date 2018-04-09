
using System;
using System.Collections;
using BMS.Utils;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class WorkStatusBO : BaseBO
	{
		private WorkStatusFacade facade = WorkStatusFacade.Instance;
		protected static WorkStatusBO instance = new WorkStatusBO();

		protected WorkStatusBO()
		{
			this.baseFacade = facade;
		}

		public static WorkStatusBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	