
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class TheoDoiBO : BaseBO
	{
		private TheoDoiFacade facade = TheoDoiFacade.Instance;
		protected static TheoDoiBO instance = new TheoDoiBO();

		protected TheoDoiBO()
		{
			this.baseFacade = facade;
		}

		public static TheoDoiBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	