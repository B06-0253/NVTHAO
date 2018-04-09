
using System;
using System.Collections;
using BMS.Utils;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class vUserInfoBO : BaseBO
	{
		private vUserInfoFacade facade = vUserInfoFacade.Instance;
		protected static vUserInfoBO instance = new vUserInfoBO();

		protected vUserInfoBO()
		{
			this.baseFacade = facade;
		}

		public static vUserInfoBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	