using System;
using TPA.Utils;
using TPA.Facade;
using TPA.Exceptions;
using TPA.Business;
using TPA.Model;
namespace TPA.Exceptions
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