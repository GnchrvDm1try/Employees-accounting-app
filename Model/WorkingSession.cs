using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCalculation.Model
{
    public class WorkingSession
    {
        public string Login { get; }
        public DateTime Date { get; }
        public byte Gap { get; set; }
        public string Comment { get; set; }

        public WorkingSession(string login, DateTime date, byte gap, string comment)
        {
            Login = login;
            Date = date;
            Gap = gap;
            Comment = comment;
        }

        public override string ToString()
        {
            return $"Login: {Login}\tDate: {Date.ToString("dd.MM.yyyy")}\tGap: {Gap}\tComment: {Comment}";
        }
    }
}
