
using System;
namespace BMS.Model
{
	public class SolutionMeetingModel : BaseModel
	{
		private long iD;
		private string code;
		private string name;
		private DateTime? meetingTime;
		private string meetingLocation;
		private string participants;
		private string meetingContent;
		private string preliminarySolution;
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
	
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
	
		public DateTime? MeetingTime
		{
			get { return meetingTime; }
			set { meetingTime = value; }
		}
	
		public string MeetingLocation
		{
			get { return meetingLocation; }
			set { meetingLocation = value; }
		}
	
		public string Participants
		{
			get { return participants; }
			set { participants = value; }
		}
	
		public string MeetingContent
		{
			get { return meetingContent; }
			set { meetingContent = value; }
		}
	
		public string PreliminarySolution
		{
			get { return preliminarySolution; }
			set { preliminarySolution = value; }
		}
	
	}
}
	