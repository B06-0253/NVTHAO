
using System;
using System.Collections;
using IE.Facade;
using IE.Model;
namespace IE.Business
{
	
	public class T_DM_FCMBO : BaseBO
	{
		private T_DM_FCMFacade facade = T_DM_FCMFacade.Instance;
		protected static T_DM_FCMBO instance = new T_DM_FCMBO();

		protected T_DM_FCMBO()
		{
			this.baseFacade = facade;
		}

		public static T_DM_FCMBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	