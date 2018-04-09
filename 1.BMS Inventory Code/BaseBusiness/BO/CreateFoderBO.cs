//---------------------------------------------------------------------------
// Author : CanhHungIT
// Created Date : Thursday, July 24, 2014
//---------------------------------------------------------------------------


// Khai bao lop
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;

namespace BMS.Business
{
	public class DesignStructureBO : BaseBO
	{
		private DesignStructureFacade facade = DesignStructureFacade.Instance;
		protected static DesignStructureBO instance = new DesignStructureBO();
		protected DesignStructureBO()
		{
			this.baseFacade = facade;
		}
		public static DesignStructureBO Instance
		{
			get { return instance; }
		}
	}
}

