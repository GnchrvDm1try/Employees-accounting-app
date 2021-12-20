using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCalculation.Model
{
    public class Freelancer : Person
    {
        public Freelancer(string fullName, string position, decimal salary) : base(fullName, position, salary)
        {

        }
    }
}
