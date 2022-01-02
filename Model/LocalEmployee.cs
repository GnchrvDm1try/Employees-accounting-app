using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentCalculation.Model
{
    public class LocalEmployee : Worker
    {
        public decimal Salary { get; set; }
        
        public LocalEmployee(string login, string firstName, string lastName, decimal? salary = null) : base(login, firstName, lastName)
        {
            if (salary != null)
                Salary = (decimal)salary;
            else
                Salary = Config.LOCAL_EMPLOYEE_MONTH_SALARY;
            Position = Position.LocalEmployee;
        }

        public override decimal CalculatePayment(List<WorkingSession> sessions)
        {
            decimal totalPayment = 0;
            decimal totalHours = 0;
            decimal paymentPerHour = Salary / Config.MONTH_WORKING_HOURS_ALLOWED;
            try 
            {
                foreach(WorkingSession session in sessions)
                {
                    if(session.Login == Login)
                    {
                        totalHours += session.Gap;
                    }
                }
                if(totalHours <= Config.MONTH_WORKING_HOURS_ALLOWED)
                {
                    totalPayment = totalHours * paymentPerHour;
                }
                else
                {
                    totalPayment = Config.MONTH_WORKING_HOURS_ALLOWED * paymentPerHour + (totalHours - Config.MONTH_WORKING_HOURS_ALLOWED) * paymentPerHour * 2;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Не удалось посчитать выплату. " + ex.Message);
            }
            return totalPayment;
        }
    }
}
