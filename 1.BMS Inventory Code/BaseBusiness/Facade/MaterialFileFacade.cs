
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class MaterialFileFacade : BaseFacade
	{
		protected static MaterialFileFacade instance = new MaterialFileFacade(new MaterialFileModel());
		protected MaterialFileFacade(MaterialFileModel model) : base(model)
		{
		}
		public static MaterialFileFacade Instance
		{
			get { return instance; }
		}
		protected MaterialFileFacade():base() 
		{ 
		} 
	
	}
}
	