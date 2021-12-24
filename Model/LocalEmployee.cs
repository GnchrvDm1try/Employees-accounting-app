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
        public LocalEmployee(string fullName, decimal salary) : base(fullName)
        {
            Salary = salary;
            Position = Position.LocalEmployee;
        }
    }
}
