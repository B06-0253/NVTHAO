
using System;
using System.Collections;
using IE.Facade;
using IE.Model;
namespace IE.Business
{
	
	public class T_DM_PHANXUONG_KMPBO : BaseBO
	{
		private T_DM_PHANXUONG_KMPFacade facade = T_DM_PHANXUONG_KMPFacade.Instance;
		protected static T_DM_PHANXUONG_KMPBO instance = new T_DM_PHANXUONG_KMPBO();

		protected T_DM_PHANXUONG_KMPBO()
		{
			this.baseFacade = facade;
		}

		public static T_DM_PHANXUONG_KMPBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	