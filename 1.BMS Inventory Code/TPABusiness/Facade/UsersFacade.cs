
using System.Collections;
using TPA.Model;
namespace TPA.Facade
{
	
	public class UsersFacade : BaseFacade
	{
		protected static UsersFacade instance = new UsersFacade(new UsersModel());
		protected UsersFacade(UsersModel model) : base(model)
		{
		}
		public static UsersFacade Instance
		{
			get { return instance; }
		}
		protected UsersFacade():base() 
		{ 
		} 
	
	}
}
	