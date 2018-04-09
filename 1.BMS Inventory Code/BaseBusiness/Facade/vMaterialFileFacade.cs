
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class vMaterialFileFacade : BaseFacade
	{
		protected static vMaterialFileFacade instance = new vMaterialFileFacade(new vMaterialFileModel());
		protected vMaterialFileFacade(vMaterialFileModel model) : base(model)
		{
		}
		public static vMaterialFileFacade Instance
		{
			get { return instance; }
		}
		protected vMaterialFileFacade():base() 
		{ 
		} 
	
	}
}
	