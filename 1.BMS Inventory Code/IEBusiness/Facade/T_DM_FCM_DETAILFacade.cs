
using System.Collections;
using IE.Model;
namespace IE.Facade
{
	
	public class T_DM_FCM_DETAILFacade : BaseFacade
	{
		protected static T_DM_FCM_DETAILFacade instance = new T_DM_FCM_DETAILFacade(new T_DM_FCM_DETAILModel());
		protected T_DM_FCM_DETAILFacade(T_DM_FCM_DETAILModel model) : base(model)
		{
		}
		public static T_DM_FCM_DETAILFacade Instance
		{
			get { return instance; }
		}
		protected T_DM_FCM_DETAILFacade():base() 
		{ 
		} 
	
	}
}
	