using System;
using System.Collections.Generic;

#nullable disable

namespace CreditDepartment.Models
{
    public partial class Client
    {
        public Client()
        {
            Contracts = new HashSet<Contract>();
        }

        public decimal ClientId { get; set; }
        public string ClientName { get; set; }
        public decimal ClientPasswordNumber { get; set; }
        public string ClientAddress { get; set; }
        public string ClientTelephone { get; set; }
        public string ClientPlaceOfWork { get; set; }
        public decimal ClientPayment { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
