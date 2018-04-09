
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class TemplateBO : BaseBO
	{
		private TemplateFacade facade = TemplateFacade.Instance;
		protected static TemplateBO instance = new TemplateBO();

		protected TemplateBO()
		{
			this.baseFacade = facade;
		}

		public static TemplateBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	