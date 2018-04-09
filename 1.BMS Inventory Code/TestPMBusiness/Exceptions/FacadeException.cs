using System;
using TEST.Utils;
using TEST.Facade;
using TEST.Exceptions;
using TEST.Business;
using TEST.Model;
namespace TEST.Exceptions
{
	public class FacadeException : Exception
	{
		public FacadeException(String message) : base(message)
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public FacadeException(Exception e)
		{			
		}
	}
}