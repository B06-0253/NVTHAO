
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class CostGroupFacade : BaseFacade
	{
		protected static CostGroupFacade instance = new CostGroupFacade(new CostGroupModel());
		protected CostGroupFacade(CostGroupModel model) : base(model)
		{
		}
		public static CostGroupFacade Instance
		{
			get { return instance; }
		}
		protected CostGroupFacade():base() 
		{ 
		} 
	
	}
}
	