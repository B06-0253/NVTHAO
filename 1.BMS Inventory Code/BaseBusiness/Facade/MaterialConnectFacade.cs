//---------------------------------------------------------------------------
// Author : CanhHungIT
// Created Date : Wednesday, July 16, 2014
//---------------------------------------------------------------------------


// Khai bao lop
using System;
using System.Collections;
using BMS.Model;

namespace BMS.Facade
{
	public class MaterialConnectFacade : BaseFacade
	{
		protected static MaterialConnectFacade instance = new MaterialConnectFacade(new MaterialConnectModel());
		protected MaterialConnectFacade(MaterialConnectModel model) : base(model)
		{
		}
		public static MaterialConnectFacade Instance
		{
			get { return instance; }
		}
		protected MaterialConnectFacade() : base()
		{
		}
	}
}

