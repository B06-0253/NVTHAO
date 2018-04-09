
using System.Collections;
using TEST.Model;
namespace TEST.Facade
{
	
	public class ManufacturerFacade : BaseFacade
	{
		protected static ManufacturerFacade instance = new ManufacturerFacade(new ManufacturerModel());
		protected ManufacturerFacade(ManufacturerModel model) : base(model)
		{
		}
		public static ManufacturerFacade Instance
		{
			get { return instance; }
		}
		protected ManufacturerFacade():base() 
		{ 
		} 
	
	}
}
	