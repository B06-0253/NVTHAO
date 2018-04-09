
using System.Collections;
using BMS.Model;
namespace BMS.Facade
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
	