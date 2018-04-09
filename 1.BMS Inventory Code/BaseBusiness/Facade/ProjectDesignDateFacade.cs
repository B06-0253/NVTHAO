
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class ProjectDesignDateFacade : BaseFacade
	{
		protected static ProjectDesignDateFacade instance = new ProjectDesignDateFacade(new ProjectDesignDateModel());
		protected ProjectDesignDateFacade(ProjectDesignDateModel model) : base(model)
		{
		}
		public static ProjectDesignDateFacade Instance
		{
			get { return instance; }
		}
		protected ProjectDesignDateFacade():base() 
		{ 
		} 
	
	}
}
	