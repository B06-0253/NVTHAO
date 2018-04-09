
using System.Collections;
using TEST.Model;
namespace TEST.Facade
{
	
	public class C_CostFacade : BaseFacade
	{
		protected static C_CostFacade instance = new C_CostFacade(new C_CostModel());
		protected C_CostFacade(C_CostModel model) : base(model)
		{
		}
		public static C_CostFacade Instance
		{
			get { return instance; }
		}
		protected C_CostFacade():base() 
		{ 
		} 
	
	}
}
	