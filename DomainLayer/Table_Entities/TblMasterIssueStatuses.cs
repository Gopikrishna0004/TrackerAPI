using System;
using System.Collections.Generic;

namespace DomainLayer.Table_Entities
{
    public partial class TblMasterIssueStatuses
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
}
