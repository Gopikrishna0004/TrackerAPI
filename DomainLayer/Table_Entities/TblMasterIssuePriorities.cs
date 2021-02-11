using System;
using System.Collections.Generic;

namespace DomainLayer.Table_Entities
{
    public partial class TblMasterIssuePriorities
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
