
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class MisMatchUserBO : BaseBO
	{
		private MisMatchUserFacade facade = MisMatchUserFacade.Instance;
		protected static MisMatchUserBO instance = new MisMatchUserBO();

		protected MisMatchUserBO()
		{
			this.baseFacade = facade;
		}

		public static MisMatchUserBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	