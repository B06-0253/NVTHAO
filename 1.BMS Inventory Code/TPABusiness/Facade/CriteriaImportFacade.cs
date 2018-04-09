
using System.Collections;
using TPA.Model;
namespace TPA.Facade
{
	
	public class CriteriaImportFacade : BaseFacade
	{
		protected static CriteriaImportFacade instance = new CriteriaImportFacade(new CriteriaImportModel());
		protected CriteriaImportFacade(CriteriaImportModel model) : base(model)
		{
		}
		public static CriteriaImportFacade Instance
		{
			get { return instance; }
		}
		protected CriteriaImportFacade():base() 
		{ 
		} 
	
	}
}
	