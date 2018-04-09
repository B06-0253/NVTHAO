
using System.Collections;
using IE.Model;
namespace IE.Facade
{
	
	public class T_DM_KMPFacade : BaseFacade
	{
		protected static T_DM_KMPFacade instance = new T_DM_KMPFacade(new T_DM_KMPModel());
		protected T_DM_KMPFacade(T_DM_KMPModel model) : base(model)
		{
		}
		public static T_DM_KMPFacade Instance
		{
			get { return instance; }
		}
		protected T_DM_KMPFacade():base() 
		{ 
		} 
	
	}
}
	