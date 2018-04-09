
using System;
namespace TEST.Model
{
	public class CriteriaImportModel : BaseModel
	{
		private string criteriaImportId;
		private string productPartsImportId;
		private string criteriaName;
		private string valueRequest;
		private string valueResult;
		private int status;
		private int criteriaIndex;
		private bool isHalf;
		public string CriteriaImportId
		{
			get { return criteriaImportId; }
			set { criteriaImportId = value; }
		}
	
		public string ProductPartsImportId
		{
			get { return productPartsImportId; }
			set { productPartsImportId = value; }
		}
	
		public string CriteriaName
		{
			get { return criteriaName; }
			set { criteriaName = value; }
		}
	
		public string ValueRequest
		{
			get { return valueRequest; }
			set { valueRequest = value; }
		}
	
		public string ValueResult
		{
			get { return valueResult; }
			set { valueResult = value; }
		}
	
		public int Status
		{
			get { return status; }
			set { status = value; }
		}
	
		public int CriteriaIndex
		{
			get { return criteriaIndex; }
			set { criteriaIndex = value; }
		}
	
		public bool IsHalf
		{
			get { return isHalf; }
			set { isHalf = value; }
		}
	
	}
}
	