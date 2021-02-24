using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace CreditDepartment.Models
{
    public class ModelController
    {
        public ModelContext context;
        public ModelController() {}
        public bool Initialize(string Login, string Password)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ModelContext>();
            var constring = ConfigurationManager.ConnectionStrings["BankDatabase"].ConnectionString;
            constring = String.Format(constring, Login, Password);
            var options = optionsBuilder
                    .UseOracle()
                    .Options;

            context = new ModelContext(options);
            if(context is null)
            { 
                return false;
            }
                return true;
        }
    }
}
