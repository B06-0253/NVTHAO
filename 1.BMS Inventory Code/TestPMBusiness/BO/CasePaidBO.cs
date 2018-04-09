
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
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
	