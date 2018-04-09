//---------------------------------------------------------------------------
// Author : CanhHungIT
// Created Date : Tuesday, July 15, 2014
//---------------------------------------------------------------------------


// Khai bao lop
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;

namespace BMS.Business
{
	public class MaterialGroupBO : BaseBO
	{
		private MaterialGroupFacade facade = MaterialGroupFacade.Instance;
		protected static MaterialGroupBO instance = new MaterialGroupBO();
		protected MaterialGroupBO()
		{
			this.baseFacade = facade;
		}
		public static MaterialGroupBO Instance
		{
			get { return instance; }
		}
	}
}

