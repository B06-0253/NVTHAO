
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class DesignStructureFileBO : BaseBO
	{
		private DesignStructureFileFacade facade = DesignStructureFileFacade.Instance;
		protected static DesignStructureFileBO instance = new DesignStructureFileBO();

		protected DesignStructureFileBO()
		{
			this.baseFacade = facade;
		}

		public static DesignStructureFileBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	