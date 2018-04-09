
using System.Collections;
using TPA.Model;
namespace TPA.Facade
{
	
	public class DesignSummaryItemFacade : BaseFacade
	{
		protected static DesignSummaryItemFacade instance = new DesignSummaryItemFacade(new DesignSummaryItemModel());
		protected DesignSummaryItemFacade(DesignSummaryItemModel model) : base(model)
		{
		}
		public static DesignSummaryItemFacade Instance
		{
			get { return instance; }
		}
		protected DesignSummaryItemFacade():base() 
		{ 
		} 
	
	}
}
	