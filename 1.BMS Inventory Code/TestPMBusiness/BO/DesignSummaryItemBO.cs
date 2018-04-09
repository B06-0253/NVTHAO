
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class DesignSummaryItemBO : BaseBO
	{
		private DesignSummaryItemFacade facade = DesignSummaryItemFacade.Instance;
		protected static DesignSummaryItemBO instance = new DesignSummaryItemBO();

		protected DesignSummaryItemBO()
		{
			this.baseFacade = facade;
		}

		public static DesignSummaryItemBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	