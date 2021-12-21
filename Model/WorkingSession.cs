using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCalculation.Model
{
    public class WorkingSession
    {
        DateTime Date { get; set; }
        TimeSpan Span { get; set; }
        string Name { get; set; }
        string Comment { get; set; }

        public WorkingSession(DateTime date, TimeSpan span, string name, string comment)
        {
            Date = date;
            Span = span;
            Name = name;
            Comment = comment;
        }
    }
}
