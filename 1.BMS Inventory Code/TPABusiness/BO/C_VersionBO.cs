
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
{
	
	public class C_VersionBO : BaseBO
	{
		private C_VersionFacade facade = C_VersionFacade.Instance;
		protected static C_VersionBO instance = new C_VersionBO();

		protected C_VersionBO()
		{
			this.baseFacade = facade;
		}

		public static C_VersionBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	