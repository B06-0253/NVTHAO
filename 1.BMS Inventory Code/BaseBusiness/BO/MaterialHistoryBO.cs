
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class MaterialHistoryBO : BaseBO
	{
		private MaterialHistoryFacade facade = MaterialHistoryFacade.Instance;
		protected static MaterialHistoryBO instance = new MaterialHistoryBO();

		protected MaterialHistoryBO()
		{
			this.baseFacade = facade;
		}

		public static MaterialHistoryBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	