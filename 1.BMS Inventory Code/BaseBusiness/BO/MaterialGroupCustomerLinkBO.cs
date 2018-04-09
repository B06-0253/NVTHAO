
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class MaterialGroupCustomerLinkBO : BaseBO
	{
		private MaterialGroupCustomerLinkFacade facade = MaterialGroupCustomerLinkFacade.Instance;
		protected static MaterialGroupCustomerLinkBO instance = new MaterialGroupCustomerLinkBO();

		protected MaterialGroupCustomerLinkBO()
		{
			this.baseFacade = facade;
		}

		public static MaterialGroupCustomerLinkBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	