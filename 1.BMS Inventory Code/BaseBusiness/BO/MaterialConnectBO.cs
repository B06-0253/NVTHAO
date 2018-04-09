//---------------------------------------------------------------------------
// Author : CanhHungIT
// Created Date : Wednesday, July 16, 2014
//---------------------------------------------------------------------------


// Khai bao lop
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;

namespace BMS.Business
{
	public class MaterialConnectBO : BaseBO
	{
		private MaterialConnectFacade facade = MaterialConnectFacade.Instance;
		protected static MaterialConnectBO instance = new MaterialConnectBO();
		protected MaterialConnectBO()
		{
			this.baseFacade = facade;
		}
		public static MaterialConnectBO Instance
		{
			get { return instance; }
		}
	}
}

