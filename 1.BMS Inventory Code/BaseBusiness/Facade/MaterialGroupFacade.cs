//---------------------------------------------------------------------------
// Author : CanhHungIT
// Created Date : Tuesday, July 15, 2014
//---------------------------------------------------------------------------


// Khai bao lop
using System;
using System.Collections;
using BMS.Model;

namespace BMS.Facade
{
	public class MaterialGroupFacade : BaseFacade
	{
		protected static MaterialGroupFacade instance = new MaterialGroupFacade(new MaterialGroupModel());
		protected MaterialGroupFacade(MaterialGroupModel model) : base(model)
		{
		}
		public static MaterialGroupFacade Instance
		{
			get { return instance; }
		}
		protected MaterialGroupFacade() : base()
		{
		}
	}
}

