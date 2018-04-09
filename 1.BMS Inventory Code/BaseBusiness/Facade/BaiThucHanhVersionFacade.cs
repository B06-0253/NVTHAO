
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class BaiThucHanhVersionFacade : BaseFacade
	{
		protected static BaiThucHanhVersionFacade instance = new BaiThucHanhVersionFacade(new BaiThucHanhVersionModel());
		protected BaiThucHanhVersionFacade(BaiThucHanhVersionModel model) : base(model)
		{
		}
		public static BaiThucHanhVersionFacade Instance
		{
			get { return instance; }
		}
		protected BaiThucHanhVersionFacade():base() 
		{ 
		} 
	
	}
}
	