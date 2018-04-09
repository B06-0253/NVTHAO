
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class MaterialFileNSBO : BaseBO
	{
		private MaterialFileNSFacade facade = MaterialFileNSFacade.Instance;
		protected static MaterialFileNSBO instance = new MaterialFileNSBO();

		protected MaterialFileNSBO()
		{
			this.baseFacade = facade;
		}

		public static MaterialFileNSBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	