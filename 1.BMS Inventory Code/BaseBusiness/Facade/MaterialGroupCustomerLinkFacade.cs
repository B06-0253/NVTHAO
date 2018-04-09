
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class MaterialGroupCustomerLinkFacade : BaseFacade
	{
		protected static MaterialGroupCustomerLinkFacade instance = new MaterialGroupCustomerLinkFacade(new MaterialGroupCustomerLinkModel());
		protected MaterialGroupCustomerLinkFacade(MaterialGroupCustomerLinkModel model) : base(model)
		{
		}
		public static MaterialGroupCustomerLinkFacade Instance
		{
			get { return instance; }
		}
		protected MaterialGroupCustomerLinkFacade():base() 
		{ 
		} 
	
	}
}
	