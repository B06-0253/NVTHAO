
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class YeuCauVatTuBO : BaseBO
	{
		private YeuCauVatTuFacade facade = YeuCauVatTuFacade.Instance;
		protected static YeuCauVatTuBO instance = new YeuCauVatTuBO();

		protected YeuCauVatTuBO()
		{
			this.baseFacade = facade;
		}

		public static YeuCauVatTuBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	