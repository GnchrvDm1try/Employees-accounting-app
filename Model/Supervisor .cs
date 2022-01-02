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
        
        public Supervisor(string login, string firstName, string lastName, decimal? salary = null) : base(login, firstName, lastName)
        {
            if (salary != null)
                Salary = (decimal)salary;
            else
                Salary = Config.SUPERVISOR_MONTH_SALARY;
            Position = Position.Supervisor;
        }

        public override decimal CalculatePayment(List<WorkingSession> sessions)
        {
            decimal totalPayment = 0;
            decimal paymentPerHour = Salary / Config.MONTH_WORKING_HOURS_ALLOWED;
            decimal overworkingBonus = Config.SUPERVISOR_MONTH_BONUS / Config.MONTH_WORKING_HOURS_ALLOWED * Config.DAY_WORKING_HOURS_ALLOWED;
            try
            {
                foreach(WorkingSession session in sessions)
                {
                    if(session.Login == Login)
                    {
                        if (session.Gap <= Config.DAY_WORKING_HOURS_ALLOWED)
                            totalPayment += paymentPerHour * session.Gap;
                        else
                            totalPayment += paymentPerHour * Config.DAY_WORKING_HOURS_ALLOWED + overworkingBonus;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Не удалось посчитать выплату. " + ex.Message);
            }
            return totalPayment;
        }

        //public string[] GetListOfReports(List<WorkingSession> sessions, DateTime fromDate, DateTime toDate)
        //{
        //    //List<WorkingSession> reports = new List<WorkingSession>();
        //    string[] reports;
        //    int i = 0;
        //    foreach (WorkingSession session in sessions)
        //    {
        //        if (fromDate < session.Date && session.Date < toDate)
        //        {
        //            string[] parameters = session.ToString().Split(',');
        //            string name = parameters[0];
        //            byte gap = Convert.ToByte(parameters[0]);
        //            if (reports.FirstOrDefault(x => x.))//reports.FirstOrDefault(x => x.Name == session.Name) == null)
        //            {
        //                //reports.Add(new WorkingSession(session.Name, session.Date, session.Gap));
        //            }
        //            else
        //            {
        //                //reports[reports.FindIndex(x => x.Name == session.Name)].Gap += session.Gap;
        //            }
        //        }
        //    }
        //    return reports;
        //}
    }
}
