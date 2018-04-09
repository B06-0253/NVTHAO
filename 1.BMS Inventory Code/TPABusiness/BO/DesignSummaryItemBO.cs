
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
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
	