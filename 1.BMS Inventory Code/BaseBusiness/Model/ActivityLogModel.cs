
using System;
namespace BMS.Model
{
	public class ActivityLogModel : BaseModel
	{
		private string tableName;
		private string subTableName;
		private int keyID;
		private int subKeyID;
		private string action;
		private string userProcess;
		private DateTime? dateProcess;
		private string columnChange;
		private string oldValue;
		private string newValue;
		private string dataType;
		private long iD;
		private int status;
		public string TableName
		{
			get { return tableName; }
			set { tableName = value; }
		}
	
		public string SubTableName
		{
			get { return subTableName; }
			set { subTableName = value; }
		}
	
		public int KeyID
		{
			get { return keyID; }
			set { keyID = value; }
		}
	
		public int SubKeyID
		{
			get { return subKeyID; }
			set { subKeyID = value; }
		}
	
		public string Action
		{
			get { return action; }
			set { action = value; }
		}
	
		public string UserProcess
		{
			get { return userProcess; }
			set { userProcess = value; }
		}
	
		public DateTime? DateProcess
		{
			get { return dateProcess; }
			set { dateProcess = value; }
		}
	
		public string ColumnChange
		{
			get { return columnChange; }
			set { columnChange = value; }
		}
	
		public string OldValue
		{
			get { return oldValue; }
			set { oldValue = value; }
		}
	
		public string NewValue
		{
			get { return newValue; }
			set { newValue = value; }
		}
	
		public string DataType
		{
			get { return dataType; }
			set { dataType = value; }
		}
	
		public long ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int Status
		{
			get { return status; }
			set { status = value; }
		}
	
	}
}
	