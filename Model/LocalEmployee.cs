using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCalculation.Model
{
    class LocalEmployee : Worker
    {
        public decimal Salary { get; set; }
        public LocalEmployee(string fullName, string position, decimal salary) : base(fullName, position)
        {
            Salary = salary;
        }
    }
}
