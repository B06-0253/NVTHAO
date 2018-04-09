
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class CostDetailFacade : BaseFacade
	{
		protected static CostDetailFacade instance = new CostDetailFacade(new CostDetailModel());
		protected CostDetailFacade(CostDetailModel model) : base(model)
		{
		}
		public static CostDetailFacade Instance
		{
			get { return instance; }
		}
		protected CostDetailFacade():base() 
		{ 
		} 
	
	}
}
	