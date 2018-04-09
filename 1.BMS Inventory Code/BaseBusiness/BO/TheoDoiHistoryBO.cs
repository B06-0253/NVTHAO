
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class TheoDoiHistoryBO : BaseBO
	{
		private TheoDoiHistoryFacade facade = TheoDoiHistoryFacade.Instance;
		protected static TheoDoiHistoryBO instance = new TheoDoiHistoryBO();

		protected TheoDoiHistoryBO()
		{
			this.baseFacade = facade;
		}

		public static TheoDoiHistoryBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	