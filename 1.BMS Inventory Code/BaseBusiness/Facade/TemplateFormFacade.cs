
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class DesignStructureFileFacade : BaseFacade
	{
		protected static DesignStructureFileFacade instance = new DesignStructureFileFacade(new DesignStructureFileModel());
		protected DesignStructureFileFacade(DesignStructureFileModel model) : base(model)
		{
		}
		public static DesignStructureFileFacade Instance
		{
			get { return instance; }
		}
		protected DesignStructureFileFacade():base() 
		{ 
		} 
	
	}
}
	