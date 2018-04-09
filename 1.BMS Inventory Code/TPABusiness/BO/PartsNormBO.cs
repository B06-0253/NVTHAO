
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
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
	