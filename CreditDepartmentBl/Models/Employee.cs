using System;
using System.Collections.Generic;

#nullable disable

namespace CreditDepartment.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Contracts = new HashSet<Contract>();
        }

        public decimal EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeePost { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
