
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
{
	
	public class DesignSummaryBO : BaseBO
	{
		private DesignSummaryFacade facade = DesignSummaryFacade.Instance;
		protected static DesignSummaryBO instance = new DesignSummaryBO();

		protected DesignSummaryBO()
		{
			this.baseFacade = facade;
		}

		public static DesignSummaryBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	