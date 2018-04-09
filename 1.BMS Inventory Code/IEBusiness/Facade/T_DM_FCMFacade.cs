
using System.Collections;
using IE.Model;
namespace IE.Facade
{
	
	public class T_DM_FCMFacade : BaseFacade
	{
		protected static T_DM_FCMFacade instance = new T_DM_FCMFacade(new T_DM_FCMModel());
		protected T_DM_FCMFacade(T_DM_FCMModel model) : base(model)
		{
		}
		public static T_DM_FCMFacade Instance
		{
			get { return instance; }
		}
		protected T_DM_FCMFacade():base() 
		{ 
		} 
	
	}
}
	