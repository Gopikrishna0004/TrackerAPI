using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.Application_View_Entities.Master_View_Entities
{
	public class MasterIssueStatuses
	{
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public string StatusDescription { get; set; }
        public bool? StatusActiveOrNot { get; set; }
        public DateTime StatusCreatedOn { get; set; }
        public string StatusCreatedBy { get; set; }
        public DateTime? StatusUpdatedOn { get; set; }
        public string StatusUpdatedBy { get; set; }
    }

    public class MasterIssuesPriorities
    {
        public int PriorityId { get; set; }
        public string PriorityName { get; set; }
        public string PriorityDescription { get; set; }
        public bool? PriorityActiveOrNot { get; set; }
        public DateTime PriorityCreatedOn { get; set; }
        public string PriorityCreatedBy { get; set; }
        public DateTime? PriorityUpdatedOn { get; set; }
        public string PriorityUpdatedBy { get; set; }
    }
}
