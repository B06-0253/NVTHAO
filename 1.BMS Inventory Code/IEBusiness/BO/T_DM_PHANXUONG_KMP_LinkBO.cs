
using System;
using System.Collections;
using IE.Facade;
using IE.Model;
namespace IE.Business
{
	
	public class T_DM_PHANXUONG_KMP_LinkBO : BaseBO
	{
		private T_DM_PHANXUONG_KMP_LinkFacade facade = T_DM_PHANXUONG_KMP_LinkFacade.Instance;
		protected static T_DM_PHANXUONG_KMP_LinkBO instance = new T_DM_PHANXUONG_KMP_LinkBO();

		protected T_DM_PHANXUONG_KMP_LinkBO()
		{
			this.baseFacade = facade;
		}

		public static T_DM_PHANXUONG_KMP_LinkBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	