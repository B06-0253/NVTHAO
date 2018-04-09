//---------------------------------------------------------------------------
// Author : CanhHungIT
// Created Date : Thursday, July 17, 2014
//---------------------------------------------------------------------------


// Khai bao lop
using System;
using System.Collections;
using BMS.Model;

namespace BMS.Facade
{
	public class VatTuThayTheFacade : BaseFacade
	{
		protected static VatTuThayTheFacade instance = new VatTuThayTheFacade(new VatTuThayTheModel());
		protected VatTuThayTheFacade(VatTuThayTheModel model) : base(model)
		{
		}
		public static VatTuThayTheFacade Instance
		{
			get { return instance; }
		}
		protected VatTuThayTheFacade() : base()
		{
		}
	}
}

