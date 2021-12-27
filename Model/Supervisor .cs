using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCalculation.Model
{
    public class Supervisor : Worker
    {
        public decimal Salary { get; set; }
        
        public Supervisor(string login, string firstName, string lastName, decimal salary) : base(login, firstName, lastName)
        {
            Salary = salary;
            Position = Position.Supervisor;
        }

        public void AddEmployee()
        {
            
        }

        public void AddEmployeeTime()
        {

        }

        public string[] GetListOfReports(List<WorkingSession> sessions, DateTime fromDate, DateTime toDate)
        {
            //List<WorkingSession> reports = new List<WorkingSession>();
            string[] reports;
            int i = 0;
            foreach (WorkingSession session in sessions)
            {
                if (fromDate < session.Date && session.Date < toDate)
                {
                    string[] parameters = session.ToString().Split(',');
                    string name = parameters[0];
                    byte gap = Convert.ToByte(parameters[0]);
                    if (reports.FirstOrDefault(x => x.))//reports.FirstOrDefault(x => x.Name == session.Name) == null)
                    {
                        //reports.Add(new WorkingSession(session.Name, session.Date, session.Gap));
                    }
                    else
                    {
                        //reports[reports.FindIndex(x => x.Name == session.Name)].Gap += session.Gap;
                    }
                }
            }
            return reports;
        }
    }
}
