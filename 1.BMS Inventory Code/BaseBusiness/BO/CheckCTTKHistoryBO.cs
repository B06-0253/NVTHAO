
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class CheckCTTKHistoryBO : BaseBO
	{
		private CheckCTTKHistoryFacade facade = CheckCTTKHistoryFacade.Instance;
		protected static CheckCTTKHistoryBO instance = new CheckCTTKHistoryBO();

		protected CheckCTTKHistoryBO()
		{
			this.baseFacade = facade;
		}

		public static CheckCTTKHistoryBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	