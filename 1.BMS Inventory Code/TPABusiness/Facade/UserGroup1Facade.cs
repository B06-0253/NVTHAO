
using System.Collections;
using TPA.Model;
namespace TPA.Facade
{
	
	public class UserGroup1Facade : BaseFacade
	{
		protected static UserGroup1Facade instance = new UserGroup1Facade(new UserGroup1Model());
		protected UserGroup1Facade(UserGroup1Model model) : base(model)
		{
		}
		public static UserGroup1Facade Instance
		{
			get { return instance; }
		}
		protected UserGroup1Facade():base() 
		{ 
		} 
	
	}
}
	