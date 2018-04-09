
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class PBDLStructureFileLinkFacade : BaseFacade
	{
		protected static PBDLStructureFileLinkFacade instance = new PBDLStructureFileLinkFacade(new PBDLStructureFileLinkModel());
		protected PBDLStructureFileLinkFacade(PBDLStructureFileLinkModel model) : base(model)
		{
		}
		public static PBDLStructureFileLinkFacade Instance
		{
			get { return instance; }
		}
		protected PBDLStructureFileLinkFacade():base() 
		{ 
		} 
	
	}
}
	