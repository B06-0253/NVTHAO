
using System.Collections;
using TEST.Model;
namespace TEST.Facade
{
	
	public class CasePaidFacade : BaseFacade
	{
		protected static CasePaidFacade instance = new CasePaidFacade(new CasePaidModel());
		protected CasePaidFacade(CasePaidModel model) : base(model)
		{
		}
		public static CasePaidFacade Instance
		{
			get { return instance; }
		}
		protected CasePaidFacade():base() 
		{ 
		} 
	
	}
}
	