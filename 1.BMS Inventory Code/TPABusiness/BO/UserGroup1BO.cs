
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
{
	
	public class UserGroup1BO : BaseBO
	{
		private UserGroup1Facade facade = UserGroup1Facade.Instance;
		protected static UserGroup1BO instance = new UserGroup1BO();

		protected UserGroup1BO()
		{
			this.baseFacade = facade;
		}

		public static UserGroup1BO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	