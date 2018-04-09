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
	public class MaterialParametersBO : BaseBO
	{
		private MaterialParametersFacade facade = MaterialParametersFacade.Instance;
		protected static MaterialParametersBO instance = new MaterialParametersBO();
		protected MaterialParametersBO()
		{
			this.baseFacade = facade;
		}
		public static MaterialParametersBO Instance
		{
			get { return instance; }
		}
	}
}

