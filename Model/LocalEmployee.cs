using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCalculation.Model
{
    public class LocalEmployee : Worker
    {
        public decimal Salary { get; set; }
        
        public LocalEmployee(string login, string firstName, string lastName, decimal salary) : base(login, firstName, lastName)
        {
            Salary = salary;
            Position = Position.LocalEmployee;
        }
    }
}
