
using System;
using System.Collections;
using IE.Facade;
using IE.Model;
namespace IE.Business
{
	
	public class T_DM_KMP_GROUPBO : BaseBO
	{
		private T_DM_KMP_GROUPFacade facade = T_DM_KMP_GROUPFacade.Instance;
		protected static T_DM_KMP_GROUPBO instance = new T_DM_KMP_GROUPBO();

		protected T_DM_KMP_GROUPBO()
		{
			this.baseFacade = facade;
		}

		public static T_DM_KMP_GROUPBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	