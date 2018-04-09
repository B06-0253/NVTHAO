
using System;
namespace TPA.Model
{
    public class ProjectDirectionModel : BaseModel
    {
        private int iD;
        private string code;
        private string name;
        private string projectCode;
        private string projectId;
        private DateTime? startDateDK;
        private DateTime? startDate;
        private DateTime? endDateDK;
        private DateTime? endDate;
        private string createdBy;
        private DateTime? createdDate;
        private string updatedBy;
        private DateTime? updatedDate;
        private DateTime? startDateCNC;
        private DateTime? deadlineCNC;
        private DateTime? startDateGCN;
        private DateTime? deadlineGCN;
        private DateTime? startDateDT;
        private DateTime? deadlineDT;
        private DateTime? startDateIN;
        private DateTime? deadlineIN;
        private DateTime? startDateLR;
        private DateTime? deadlineLR;

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

        public string ProjectCode
        {
            get { return projectCode; }
            set { projectCode = value; }
        }

        public string ProjectId
        {
            get { return projectId; }
            set { projectId = value; }
        }

        public DateTime? StartDateDK
        {
            get { return startDateDK; }
            set { startDateDK = value; }
        }

        public DateTime? StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public DateTime? EndDateDK
        {
            get { return endDateDK; }
            set { endDateDK = value; }
        }

        public DateTime? EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public string CreatedBy
        {
            get { return createdBy; }
            set { createdBy = value; }
        }

        public DateTime? CreatedDate
        {
            get { return createdDate; }
            set { createdDate = value; }
        }

        public string UpdatedBy
        {
            get { return updatedBy; }
            set { updatedBy = value; }
        }

        public DateTime? UpdatedDate
        {
            get { return updatedDate; }
            set { updatedDate = value; }
        }

        public DateTime? StartDateCNC
        {
            get { return startDateCNC; }
            set { startDateCNC = value; }
        }
        public DateTime? DeadlineCNC
        {
            get { return deadlineCNC; }
            set { deadlineCNC = value; }
        }
        public DateTime? StartDateGCN
        {
            get { return startDateGCN; }
            set { startDateGCN = value; }
        }
        public DateTime? DeadlineGCN
        {
            get { return deadlineGCN; }
            set { deadlineGCN = value; }
        }
        public DateTime? StartDateDT
        {
            get { return startDateDT; }
            set { startDateDT = value; }
        }
        public DateTime? DeadlineDT
        {
            get { return deadlineDT; }
            set { deadlineDT = value; }
        }
        public DateTime? StartDateIN
        {
            get { return startDateIN; }
            set { startDateIN = value; }
        }
        public DateTime? DeadlineIN
        {
            get { return deadlineIN; }
            set { deadlineIN = value; }
        }
        public DateTime? StartDateLR
        {
            get { return startDateLR; }
            set { startDateLR = value; }
        }
        public DateTime? DeadlineLR
        {
            get { return deadlineLR; }
            set { deadlineLR = value; }
        }
    }
}
