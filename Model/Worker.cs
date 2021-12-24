using System;

namespace PaymentCalculation.Model
{

    public abstract class Worker
    {
        public string FullName { get; set; }
        public Position Position { get; set; }

        public Worker(string fullName)
        {
            FullName = fullName;
            //Position = position;
        }
    }
}
