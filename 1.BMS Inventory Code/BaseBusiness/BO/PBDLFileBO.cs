
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class PBDLFileBO : BaseBO
	{
		private PBDLFileFacade facade = PBDLFileFacade.Instance;
		protected static PBDLFileBO instance = new PBDLFileBO();

		protected PBDLFileBO()
		{
			this.baseFacade = facade;
		}

		public static PBDLFileBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	