
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class PartsNotDMVTBO : BaseBO
	{
		private PartsNotDMVTFacade facade = PartsNotDMVTFacade.Instance;
		protected static PartsNotDMVTBO instance = new PartsNotDMVTBO();

		protected PartsNotDMVTBO()
		{
			this.baseFacade = facade;
		}

		public static PartsNotDMVTBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	