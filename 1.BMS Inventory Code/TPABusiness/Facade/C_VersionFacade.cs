
using System.Collections;
using TPA.Model;
namespace TPA.Facade
{
	
	public class C_VersionFacade : BaseFacade
	{
		protected static C_VersionFacade instance = new C_VersionFacade(new C_VersionModel());
		protected C_VersionFacade(C_VersionModel model) : base(model)
		{
		}
		public static C_VersionFacade Instance
		{
			get { return instance; }
		}
		protected C_VersionFacade():base() 
		{ 
		} 
	
	}
}
	