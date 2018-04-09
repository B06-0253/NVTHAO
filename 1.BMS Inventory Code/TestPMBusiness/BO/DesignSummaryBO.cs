
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
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
	