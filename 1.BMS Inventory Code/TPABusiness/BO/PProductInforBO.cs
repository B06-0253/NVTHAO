
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
{
	
	public class PProductInforBO : BaseBO
	{
		private PProductInforFacade facade = PProductInforFacade.Instance;
		protected static PProductInforBO instance = new PProductInforBO();

		protected PProductInforBO()
		{
			this.baseFacade = facade;
		}

		public static PProductInforBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	