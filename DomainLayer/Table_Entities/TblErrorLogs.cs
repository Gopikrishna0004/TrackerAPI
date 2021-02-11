using System;
using System.Collections.Generic;

namespace DomainLayer.Table_Entities
{
    public partial class TblErrorLogs
    {
        public int ErrorId { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime ErrorDate { get; set; }
    }
}
