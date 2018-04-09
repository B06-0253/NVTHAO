
using System;
using System.Collections;
using IE.Facade;
using IE.Model;
namespace IE.Business
{
	
	public class T_DM_FCM_DETAILBO : BaseBO
	{
		private T_DM_FCM_DETAILFacade facade = T_DM_FCM_DETAILFacade.Instance;
		protected static T_DM_FCM_DETAILBO instance = new T_DM_FCM_DETAILBO();

		protected T_DM_FCM_DETAILBO()
		{
			this.baseFacade = facade;
		}

		public static T_DM_FCM_DETAILBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	