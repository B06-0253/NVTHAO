//---------------------------------------------------------------------------
// Author : CanhHungIT
// Created Date : Thursday, July 24, 2014
//---------------------------------------------------------------------------


// Khai bao lop
using System;
using System.Collections;
using BMS.Model;

namespace BMS.Facade
{
	public class DesignStructureFacade : BaseFacade
	{
		protected static DesignStructureFacade instance = new DesignStructureFacade(new DesignStructureModel());
		protected DesignStructureFacade(DesignStructureModel model) : base(model)
		{
		}
		public static DesignStructureFacade Instance
		{
			get { return instance; }
		}
		protected DesignStructureFacade() : base()
		{
		}
	}
}

