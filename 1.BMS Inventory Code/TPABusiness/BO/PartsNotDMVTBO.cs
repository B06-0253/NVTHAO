
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
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
	