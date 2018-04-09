
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class vDMVTCBO : BaseBO
	{
		private vDMVTCFacade facade = vDMVTCFacade.Instance;
		protected static vDMVTCBO instance = new vDMVTCBO();

		protected vDMVTCBO()
		{
			this.baseFacade = facade;
		}

		public static vDMVTCBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	