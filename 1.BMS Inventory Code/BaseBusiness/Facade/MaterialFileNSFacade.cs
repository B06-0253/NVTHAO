
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class MaterialFileNSFacade : BaseFacade
	{
		protected static MaterialFileNSFacade instance = new MaterialFileNSFacade(new MaterialFileNSModel());
		protected MaterialFileNSFacade(MaterialFileNSModel model) : base(model)
		{
		}
		public static MaterialFileNSFacade Instance
		{
			get { return instance; }
		}
		protected MaterialFileNSFacade():base() 
		{ 
		} 
	
	}
}
	