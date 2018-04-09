
using System.Collections;
using TPA.Model;
namespace TPA.Facade
{
	
	public class C_UserFacade : BaseFacade
	{
		protected static C_UserFacade instance = new C_UserFacade(new C_UserModel());
		protected C_UserFacade(C_UserModel model) : base(model)
		{
		}
		public static C_UserFacade Instance
		{
			get { return instance; }
		}
		protected C_UserFacade():base() 
		{ 
		} 
	
	}
}
	