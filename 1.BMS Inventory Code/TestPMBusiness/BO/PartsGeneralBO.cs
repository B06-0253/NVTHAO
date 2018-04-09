
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class PartsGeneralBO : BaseBO
	{
		private PartsGeneralFacade facade = PartsGeneralFacade.Instance;
		protected static PartsGeneralBO instance = new PartsGeneralBO();

		protected PartsGeneralBO()
		{
			this.baseFacade = facade;
		}

		public static PartsGeneralBO Instance
		{
			get { return instance; }
		}
		
	
        //public ArrayList FindBypartsId(string partsId)
        //{
        //    return facade.FindByPartsId(partsId);
        //}

		
	}
}
	