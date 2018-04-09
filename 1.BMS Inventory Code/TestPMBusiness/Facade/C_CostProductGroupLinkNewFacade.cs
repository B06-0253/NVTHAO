
using System.Collections;
using TEST.Model;
namespace TEST.Facade
{
	
	public class C_CostProductGroupLinkNewFacade : BaseFacade
	{
		protected static C_CostProductGroupLinkNewFacade instance = new C_CostProductGroupLinkNewFacade(new C_CostProductGroupLinkNewModel());
		protected C_CostProductGroupLinkNewFacade(C_CostProductGroupLinkNewModel model) : base(model)
		{
		}
		public static C_CostProductGroupLinkNewFacade Instance
		{
			get { return instance; }
		}
		protected C_CostProductGroupLinkNewFacade():base() 
		{ 
		} 
	
	}
}
	