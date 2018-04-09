
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class File3DBO : BaseBO
	{
		private File3DFacade facade = File3DFacade.Instance;
		protected static File3DBO instance = new File3DBO();

		protected File3DBO()
		{
			this.baseFacade = facade;
		}

		public static File3DBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	