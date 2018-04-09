
using System.Collections;
using TEST.Model;
namespace TEST.Facade
{
	
	public class CriteriaImportImageFacade : BaseFacade
	{
		protected static CriteriaImportImageFacade instance = new CriteriaImportImageFacade(new CriteriaImportImageModel());
		protected CriteriaImportImageFacade(CriteriaImportImageModel model) : base(model)
		{
		}
		public static CriteriaImportImageFacade Instance
		{
			get { return instance; }
		}
		protected CriteriaImportImageFacade():base() 
		{ 
		} 
	
	}
}
	