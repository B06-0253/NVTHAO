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
	public class MaterialParametersFacade : BaseFacade
	{
		protected static MaterialParametersFacade instance = new MaterialParametersFacade(new MaterialParametersModel());
		protected MaterialParametersFacade(MaterialParametersModel model) : base(model)
		{
		}
		public static MaterialParametersFacade Instance
		{
			get { return instance; }
		}
		protected MaterialParametersFacade() : base()
		{
		}
	}
}

