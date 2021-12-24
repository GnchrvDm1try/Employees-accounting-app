using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCalculation.Model
{
    public class Freelancer : Worker
    {
        public decimal PaymentPerHour { get; set; }
        public Freelancer(string fullName, decimal paymentPerHour) : base(fullName)
        {
            PaymentPerHour = paymentPerHour;
            Position = Position.Freelancer;
        }
    }
}
