using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCalculation.Model
{
    public class Supervisor : Worker
    {
        public decimal Salary { get; set; }
        public Supervisor(string fullName, decimal salary) : base(fullName)
        {
            Salary = salary;
            Position = Position.Supervisor;
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
