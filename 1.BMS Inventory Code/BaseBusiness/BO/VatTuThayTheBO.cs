//---------------------------------------------------------------------------
// Author : CanhHungIT
// Created Date : Thursday, July 17, 2014
//---------------------------------------------------------------------------


// Khai bao lop
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;

namespace BMS.Business
{
	public class VatTuThayTheBO : BaseBO
	{
		private VatTuThayTheFacade facade = VatTuThayTheFacade.Instance;
		protected static VatTuThayTheBO instance = new VatTuThayTheBO();
		protected VatTuThayTheBO()
		{
			this.baseFacade = facade;
		}
		public static VatTuThayTheBO Instance
		{
			get { return instance; }
		}
	}
}

