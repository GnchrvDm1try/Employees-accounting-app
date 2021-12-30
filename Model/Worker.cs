using System;
using System.Collections.Generic;

namespace PaymentCalculation.Model
{

    public abstract class Worker
    {
        public string Login { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Position Position { get; set; }

        public Worker(string login, string firstName, string lastName)
        {
            Login = login;
            FirstName = firstName;
            LastName = lastName;
        }

        public virtual decimal CalculatePayment(List<WorkingSession> sessions)
        {
            return 0;
        }
    }
}
