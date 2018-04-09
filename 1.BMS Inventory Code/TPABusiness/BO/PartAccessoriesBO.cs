
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
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
	