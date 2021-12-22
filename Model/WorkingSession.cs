using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCalculation.Model
{
    public class WorkingSession
    {
        public string Name { get; }
        public DateTime Date { get; }
        public byte Gap { get; }
        public string Comment { get; set; }

        public WorkingSession(string name, DateTime date, byte gap, string comment)
        {
            Name = name;
            Date = date;
            Gap = gap;
            Comment = comment;
        }
    }
}
