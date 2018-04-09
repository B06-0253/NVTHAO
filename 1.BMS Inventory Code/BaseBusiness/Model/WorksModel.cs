
using System;
namespace BMS.Model
{
	public class WorksModel : BaseModel
	{
		private int iD;
		private string code;
		private string name;
		private int parentID;
		private int productID;
		private int priority;
		private double estimatedTime;
		private double totalTime;
		private double totalScore;
		private string createdBy;
		private DateTime createdDate;
		private string updatedBy;
		private DateTime updatedDate;
		private int workStatusID;
		private int workTypeID;
		private DateTime planStartDate;
		private DateTime planEndDate;
		private DateTime realStartDate;
		private DateTime realEndDate;
		private string description;

        private int type;

        public int Type
        {
            get { return type; }
            set { type = value; }
        }

		public int ID
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
	
		public int ParentID
		{
			get { return parentID; }
			set { parentID = value; }
		}
	
		public int ProductID
		{
			get { return productID; }
			set { productID = value; }
        }	
	
		public int Priority
		{
			get { return priority; }
			set { priority = value; }
		}
	
		public double EstimatedTime
		{
			get { return estimatedTime; }
			set { estimatedTime = value; }
		}
	
		public double TotalTime
		{
			get { return totalTime; }
			set { totalTime = value; }
		}
	
		public double TotalScore
		{
			get { return totalScore; }
			set { totalScore = value; }
		}
	
		public string CreatedBy
		{
			get { return createdBy; }
			set { createdBy = value; }
		}
	
		public DateTime CreatedDate
		{
			get { return createdDate; }
			set { createdDate = value; }
		}
	
		public string UpdatedBy
		{
			get { return updatedBy; }
			set { updatedBy = value; }
		}
	
		public DateTime UpdatedDate
		{
			get { return updatedDate; }
			set { updatedDate = value; }
		}
	
		public int WorkStatusID
		{
			get { return workStatusID; }
			set { workStatusID = value; }
		}
	
		public int WorkTypeID
		{
			get { return workTypeID; }
			set { workTypeID = value; }
		}
	
		public DateTime PlanStartDate
		{
			get { return planStartDate; }
			set { planStartDate = value; }
		}
	
		public DateTime PlanEndDate
		{
			get { return planEndDate; }
			set { planEndDate = value; }
		}
	
		public DateTime RealStartDate
		{
			get { return realStartDate; }
			set { realStartDate = value; }
		}
	
		public DateTime RealEndDate
		{
			get { return realEndDate; }
			set { realEndDate = value; }
		}
	
		public string Description
		{
			get { return description; }
			set { description = value; }
		}
	
	}
}
	