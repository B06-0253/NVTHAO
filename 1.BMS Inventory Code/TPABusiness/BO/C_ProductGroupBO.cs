
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
{
	
	public class C_ProductGroupBO : BaseBO
	{
		private C_ProductGroupFacade facade = C_ProductGroupFacade.Instance;
		protected static C_ProductGroupBO instance = new C_ProductGroupBO();

		protected C_ProductGroupBO()
		{
			this.baseFacade = facade;
		}

		public static C_ProductGroupBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	