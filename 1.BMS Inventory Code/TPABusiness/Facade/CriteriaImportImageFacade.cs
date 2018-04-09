
using System.Collections;
using TPA.Model;
namespace TPA.Facade
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
	