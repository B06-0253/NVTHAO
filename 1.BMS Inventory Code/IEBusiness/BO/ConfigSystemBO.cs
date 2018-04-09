//---------------------------------------------------------------------------
// Author : CanhHungIT
// Created Date : Monday, July 28, 2014
//---------------------------------------------------------------------------


// Khai bao lop
using System;
using System.Collections;
using IE.Facade;
using IE.Model;

namespace IE.Business
{
	public class ConfigSystemBO : BaseBO
	{
		private ConfigSystemFacade facade = ConfigSystemFacade.Instance;
		protected static ConfigSystemBO instance = new ConfigSystemBO();
		protected ConfigSystemBO()
		{
			this.baseFacade = facade;
		}
		public static ConfigSystemBO Instance
		{
			get { return instance; }
		}
	}
}

