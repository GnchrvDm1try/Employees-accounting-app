using System;

namespace PaymentCalculation.Model
{
    public abstract class Person
    {
        public string fullName { get; set; }
        public string position { get; set; }
        public decimal salary { get; set; }

        public Person(string fullName, string position, decimal salary)
        {
            this.fullName = fullName;
            this.position = position;
            this.salary = salary;
        }
    }
}
