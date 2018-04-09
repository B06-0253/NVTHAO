
using System.Collections;
using TEST.Model;
namespace TEST.Facade
{
	
	public class C_ProductGroupFacade : BaseFacade
	{
		protected static C_ProductGroupFacade instance = new C_ProductGroupFacade(new C_ProductGroupModel());
		protected C_ProductGroupFacade(C_ProductGroupModel model) : base(model)
		{
		}
		public static C_ProductGroupFacade Instance
		{
			get { return instance; }
		}
		protected C_ProductGroupFacade():base() 
		{ 
		} 
	
	}
}
	