
using System.Collections;
using TEST.Model;
namespace TEST.Facade
{
	
	public class PartsGeneralFacade : BaseFacade
	{
		protected static PartsGeneralFacade instance = new PartsGeneralFacade(new PartsGeneralModel());
		protected PartsGeneralFacade(PartsGeneralModel model) : base(model)
		{
		}
		public static PartsGeneralFacade Instance
		{
			get { return instance; }
		}
		protected PartsGeneralFacade():base() 
		{ 
		} 
	
        //public ArrayList FindByPartsId(string partsId)
        //{
        //    return FindByAttribute("partsId", partsId);
        //}
		
	}
}
	