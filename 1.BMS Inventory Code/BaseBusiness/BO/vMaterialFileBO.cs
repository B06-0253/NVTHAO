
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class vMaterialFileBO : BaseBO
	{
		private vMaterialFileFacade facade = vMaterialFileFacade.Instance;
		protected static vMaterialFileBO instance = new vMaterialFileBO();

		protected vMaterialFileBO()
		{
			this.baseFacade = facade;
		}

		public static vMaterialFileBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	