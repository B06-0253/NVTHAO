
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class PartsNormBO : BaseBO
	{
		private PartsNormFacade facade = PartsNormFacade.Instance;
		protected static PartsNormBO instance = new PartsNormBO();

		protected PartsNormBO()
		{
			this.baseFacade = facade;
		}

		public static PartsNormBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	