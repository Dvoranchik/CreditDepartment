using System;
using System.Collections.Generic;

#nullable disable

namespace CreditDepartment.Models
{
    public partial class LogonAudit
    {
        public string UserId { get; set; }
        public int? SessId { get; set; }
        public DateTime? LogonTime { get; set; }
        public DateTime? LogoffTime { get; set; }
        public string Host { get; set; }
    }
}
