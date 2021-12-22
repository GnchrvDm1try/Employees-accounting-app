using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCalculation.Model
{
    public class Supervisor : Worker
    {
        decimal Salary { get; set; }
        public Supervisor(string fullName, string position, decimal salary) : base(fullName, position)
        {
            Salary = salary;
        }

        public void AddEmployee()
        {

        }

        public void AddEmployeeTime()
        {

        }

        public void GetListOfEmployees()
        {

        }
    }
}
