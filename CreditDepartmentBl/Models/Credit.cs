using System;
using System.Collections.Generic;

#nullable disable

namespace CreditDepartment.Models
{
    public partial class Credit
    {
        public Credit()
        {
            Contracts = new HashSet<Contract>();
        }

        public decimal CreditId { get; set; }
        public string CreditType { get; set; }
        public decimal CreditProcent { get; set; }
        public string CreditAdditionalServices { get; set; }
        public string CreditLoanProgram { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
