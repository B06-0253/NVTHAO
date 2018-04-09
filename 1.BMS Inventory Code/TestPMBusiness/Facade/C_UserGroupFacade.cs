
using System.Collections;
using TEST.Model;
namespace TEST.Facade
{
	
	public class C_UserGroupFacade : BaseFacade
	{
		protected static C_UserGroupFacade instance = new C_UserGroupFacade(new C_UserGroupModel());
		protected C_UserGroupFacade(C_UserGroupModel model) : base(model)
		{
		}
		public static C_UserGroupFacade Instance
		{
			get { return instance; }
		}
		protected C_UserGroupFacade():base() 
		{ 
		} 
	
	}
}
	