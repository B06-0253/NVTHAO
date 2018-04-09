
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class BaiThucHanhFileFacade : BaseFacade
	{
		protected static BaiThucHanhFileFacade instance = new BaiThucHanhFileFacade(new BaiThucHanhFileModel());
		protected BaiThucHanhFileFacade(BaiThucHanhFileModel model) : base(model)
		{
		}
		public static BaiThucHanhFileFacade Instance
		{
			get { return instance; }
		}
		protected BaiThucHanhFileFacade():base() 
		{ 
		} 
	
	}
}
	