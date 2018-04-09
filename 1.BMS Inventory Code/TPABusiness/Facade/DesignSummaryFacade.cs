
using System.Collections;
using TPA.Model;
namespace TPA.Facade
{
	
	public class DesignSummaryFacade : BaseFacade
	{
		protected static DesignSummaryFacade instance = new DesignSummaryFacade(new DesignSummaryModel());
		protected DesignSummaryFacade(DesignSummaryModel model) : base(model)
		{
		}
		public static DesignSummaryFacade Instance
		{
			get { return instance; }
		}
		protected DesignSummaryFacade():base() 
		{ 
		} 
	
	}
}
	