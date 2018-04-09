
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{	
	public class WorkDistributionBO : BaseBO
	{
		private WorkDistributionFacade facade = WorkDistributionFacade.Instance;
		protected static WorkDistributionBO instance = new WorkDistributionBO();

		protected WorkDistributionBO()
		{
			this.baseFacade = facade;
		}

		public static WorkDistributionBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	