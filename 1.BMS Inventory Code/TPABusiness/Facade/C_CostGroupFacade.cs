
using System.Collections;
using TPA.Model;
namespace TPA.Facade
{
	
	public class C_CostGroupFacade : BaseFacade
	{
		protected static C_CostGroupFacade instance = new C_CostGroupFacade(new C_CostGroupModel());
		protected C_CostGroupFacade(C_CostGroupModel model) : base(model)
		{
		}
		public static C_CostGroupFacade Instance
		{
			get { return instance; }
		}
		protected C_CostGroupFacade():base() 
		{ 
		} 
	
	}
}
	