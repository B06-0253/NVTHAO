//---------------------------------------------------------------------------
// Author : CanhHungIT
// Created Date : Monday, July 28, 2014
//---------------------------------------------------------------------------


// Khai bao lop
using System;
using System.Collections;
using IE.Model;

namespace IE.Facade
{
	public class ConfigSystemFacade : BaseFacade
	{
		protected static ConfigSystemFacade instance = new ConfigSystemFacade(new ConfigSystemModel());
		protected ConfigSystemFacade(ConfigSystemModel model) : base(model)
		{
		}
		public static ConfigSystemFacade Instance
		{
			get { return instance; }
		}
		protected ConfigSystemFacade() : base()
		{
		}
	}
}

