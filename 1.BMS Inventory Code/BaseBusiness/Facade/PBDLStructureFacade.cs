
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class PBDLStructureFacade : BaseFacade
	{
		protected static PBDLStructureFacade instance = new PBDLStructureFacade(new PBDLStructureModel());
		protected PBDLStructureFacade(PBDLStructureModel model) : base(model)
		{
		}
		public static PBDLStructureFacade Instance
		{
			get { return instance; }
		}
		protected PBDLStructureFacade():base() 
		{ 
		} 
	
	}
}
	