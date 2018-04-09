
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class MisMatchBO : BaseBO
	{
		private MisMatchFacade facade = MisMatchFacade.Instance;
		protected static MisMatchBO instance = new MisMatchBO();

		protected MisMatchBO()
		{
			this.baseFacade = facade;
		}

		public static MisMatchBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	