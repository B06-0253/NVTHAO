
using System;
namespace BMS.Model
{
	public class CheckCTTKHistoryModel : BaseModel
	{
		private long iD;
		private string code;
		private string fileName;
		private string size;
		private string dateModified;
		private string date;
		public long ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string Code
		{
			get { return code; }
			set { code = value; }
		}
	
		public string FileName
		{
			get { return fileName; }
			set { fileName = value; }
		}
	
		public string Size
		{
			get { return size; }
			set { size = value; }
		}
	
		public string DateModified
		{
			get { return dateModified; }
			set { dateModified = value; }
		}
	
		public string Date
		{
			get { return date; }
			set { date = value; }
		}
	
	}
}
	