
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class PartAccessoriesBO : BaseBO
	{
		private PartAccessoriesFacade facade = PartAccessoriesFacade.Instance;
		protected static PartAccessoriesBO instance = new PartAccessoriesBO();

		protected PartAccessoriesBO()
		{
			this.baseFacade = facade;
		}

		public static PartAccessoriesBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	