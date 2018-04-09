
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
{
	
	public class CasePaidBO : BaseBO
	{
		private CasePaidFacade facade = CasePaidFacade.Instance;
		protected static CasePaidBO instance = new CasePaidBO();

		protected CasePaidBO()
		{
			this.baseFacade = facade;
		}

		public static CasePaidBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	