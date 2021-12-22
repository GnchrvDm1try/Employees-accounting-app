using System;

namespace PaymentCalculation.Model
{

    public abstract class Worker
    {
        public string FullName { get; set; }
        public string Position { get; set; }

        public Worker(string fullName, string position)
        {
            FullName = fullName;
            Position = position;
        }
    }
}
