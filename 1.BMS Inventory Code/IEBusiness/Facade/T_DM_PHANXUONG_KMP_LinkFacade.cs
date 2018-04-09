
using System.Collections;
using IE.Model;
namespace IE.Facade
{
	
	public class T_DM_PHANXUONG_KMP_LinkFacade : BaseFacade
	{
		protected static T_DM_PHANXUONG_KMP_LinkFacade instance = new T_DM_PHANXUONG_KMP_LinkFacade(new T_DM_PHANXUONG_KMP_LinkModel());
		protected T_DM_PHANXUONG_KMP_LinkFacade(T_DM_PHANXUONG_KMP_LinkModel model) : base(model)
		{
		}
		public static T_DM_PHANXUONG_KMP_LinkFacade Instance
		{
			get { return instance; }
		}
		protected T_DM_PHANXUONG_KMP_LinkFacade():base() 
		{ 
		} 
	
	}
}
	