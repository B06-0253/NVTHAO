
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class MaterialNSFacade : BaseFacade
	{
		protected static MaterialNSFacade instance = new MaterialNSFacade(new MaterialNSModel());
		protected MaterialNSFacade(MaterialNSModel model) : base(model)
		{
		}
		public static MaterialNSFacade Instance
		{
			get { return instance; }
		}
		protected MaterialNSFacade():base() 
		{ 
		} 
	
	}
}
	