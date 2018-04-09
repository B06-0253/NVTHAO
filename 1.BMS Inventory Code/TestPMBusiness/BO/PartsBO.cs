
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class PartsBO : BaseBO
	{
		private PartsFacade facade = PartsFacade.Instance;
		protected static PartsBO instance = new PartsBO();

		protected PartsBO()
		{
			this.baseFacade = facade;
		}

		public static PartsBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	