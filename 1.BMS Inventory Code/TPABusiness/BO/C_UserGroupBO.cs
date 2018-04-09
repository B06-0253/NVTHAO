
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
{
	
	public class C_UserGroupBO : BaseBO
	{
		private C_UserGroupFacade facade = C_UserGroupFacade.Instance;
		protected static C_UserGroupBO instance = new C_UserGroupBO();

		protected C_UserGroupBO()
		{
			this.baseFacade = facade;
		}

		public static C_UserGroupBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	