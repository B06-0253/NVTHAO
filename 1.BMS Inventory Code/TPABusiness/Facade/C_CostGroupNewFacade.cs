
using System.Collections;
using TPA.Model;
namespace TPA.Facade
{
	
	public class C_CostGroupNewFacade : BaseFacade
	{
		protected static C_CostGroupNewFacade instance = new C_CostGroupNewFacade(new C_CostGroupNewModel());
		protected C_CostGroupNewFacade(C_CostGroupNewModel model) : base(model)
		{
		}
		public static C_CostGroupNewFacade Instance
		{
			get { return instance; }
		}
		protected C_CostGroupNewFacade():base() 
		{ 
		} 
	
	}
}
	