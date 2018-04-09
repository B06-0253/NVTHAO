
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class ManufacturerBO : BaseBO
	{
		private ManufacturerFacade facade = ManufacturerFacade.Instance;
		protected static ManufacturerBO instance = new ManufacturerBO();

		protected ManufacturerBO()
		{
			this.baseFacade = facade;
		}

		public static ManufacturerBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	