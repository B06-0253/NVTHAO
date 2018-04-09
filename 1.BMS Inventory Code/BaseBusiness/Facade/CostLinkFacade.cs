
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class CostLinkFacade : BaseFacade
	{
		protected static CostLinkFacade instance = new CostLinkFacade(new CostLinkModel());
		protected CostLinkFacade(CostLinkModel model) : base(model)
		{
		}
		public static CostLinkFacade Instance
		{
			get { return instance; }
		}
		protected CostLinkFacade():base() 
		{ 
		} 
	
	}
}
	