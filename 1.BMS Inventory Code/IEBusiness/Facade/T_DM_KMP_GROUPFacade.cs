
using System.Collections;
using IE.Model;
namespace IE.Facade
{
	
	public class T_DM_KMP_GROUPFacade : BaseFacade
	{
		protected static T_DM_KMP_GROUPFacade instance = new T_DM_KMP_GROUPFacade(new T_DM_KMP_GROUPModel());
		protected T_DM_KMP_GROUPFacade(T_DM_KMP_GROUPModel model) : base(model)
		{
		}
		public static T_DM_KMP_GROUPFacade Instance
		{
			get { return instance; }
		}
		protected T_DM_KMP_GROUPFacade():base() 
		{ 
		} 
	
	}
}
	