using System;
using System.Collections.Generic;

#nullable disable

namespace CreditDepartment.Models
{
    public partial class Contract
    {
        public decimal ContractId { get; set; }
        public DateTime ContractData { get; set; }
        public string ContractType { get; set; }
        public decimal EmployeeId { get; set; }
        public decimal ClientId { get; set; }
        public decimal CreditId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Credit Credit { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
