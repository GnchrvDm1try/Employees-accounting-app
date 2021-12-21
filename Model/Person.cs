using System;

namespace PaymentCalculation.Model
{

    public abstract class Person
    {
        public string FullName { get; set; }
        public string Position { get; set; }

        public Person(string fullName, string position)
        {
            FullName = fullName;
            Position = position;
        }
    }
}
