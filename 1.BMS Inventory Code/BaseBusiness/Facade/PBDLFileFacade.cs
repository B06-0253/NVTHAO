
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class PBDLFileFacade : BaseFacade
	{
		protected static PBDLFileFacade instance = new PBDLFileFacade(new PBDLFileModel());
		protected PBDLFileFacade(PBDLFileModel model) : base(model)
		{
		}
		public static PBDLFileFacade Instance
		{
			get { return instance; }
		}
		protected PBDLFileFacade():base() 
		{ 
		} 
	
	}
}
	