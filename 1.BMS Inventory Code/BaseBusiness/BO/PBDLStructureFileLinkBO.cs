
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class PBDLStructureFileLinkBO : BaseBO
	{
		private PBDLStructureFileLinkFacade facade = PBDLStructureFileLinkFacade.Instance;
		protected static PBDLStructureFileLinkBO instance = new PBDLStructureFileLinkBO();

		protected PBDLStructureFileLinkBO()
		{
			this.baseFacade = facade;
		}

		public static PBDLStructureFileLinkBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	