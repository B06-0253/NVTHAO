
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class ProjectDesignDateBO : BaseBO
	{
		private ProjectDesignDateFacade facade = ProjectDesignDateFacade.Instance;
		protected static ProjectDesignDateBO instance = new ProjectDesignDateBO();

		protected ProjectDesignDateBO()
		{
			this.baseFacade = facade;
		}

		public static ProjectDesignDateBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	