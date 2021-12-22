using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCalculation.Model
{
    public class Freelancer : Worker
    {
        decimal PaymentPerHour { get; set; }
        public Freelancer(string fullName, string position, decimal paymentPerHour) : base(fullName, position)
        {
            PaymentPerHour = paymentPerHour;
        }
    }
}
