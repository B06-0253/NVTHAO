
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class MaterialFileLinkFacade : BaseFacade
	{
		protected static MaterialFileLinkFacade instance = new MaterialFileLinkFacade(new MaterialFileLinkModel());
		protected MaterialFileLinkFacade(MaterialFileLinkModel model) : base(model)
		{
		}
		public static MaterialFileLinkFacade Instance
		{
			get { return instance; }
		}
		protected MaterialFileLinkFacade():base() 
		{ 
		} 
	
	}
}
	