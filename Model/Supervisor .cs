using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCalculation.Model
{
    public class Supervisor : Person
    {
        public Supervisor(string fullName, string position, decimal salary) : base(fullName, position, salary)
        {
            this.fullName = base.fullName;
            this.position = base.position;
            this.salary = base.salary;
        }

        public void AddEmployee()
        {

        }
    }
}
