
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
{
	
	public class RequestImportWarehouseBO : BaseBO
	{
		private RequestImportWarehouseFacade facade = RequestImportWarehouseFacade.Instance;
		protected static RequestImportWarehouseBO instance = new RequestImportWarehouseBO();

		protected RequestImportWarehouseBO()
		{
			this.baseFacade = facade;
		}

		public static RequestImportWarehouseBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	