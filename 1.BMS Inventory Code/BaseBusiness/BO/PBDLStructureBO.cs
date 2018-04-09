
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class PBDLStructureBO : BaseBO
	{
		private PBDLStructureFacade facade = PBDLStructureFacade.Instance;
		protected static PBDLStructureBO instance = new PBDLStructureBO();

		protected PBDLStructureBO()
		{
			this.baseFacade = facade;
		}

		public static PBDLStructureBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	