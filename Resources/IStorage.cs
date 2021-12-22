using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentCalculation.Model;
using PaymentCalculation.Resources;

namespace PaymentCalculation.Resources
{
    interface IStorage
    {
        void AddWorkingSession(WorkingSession session);
        void AddWorker(Worker worker, decimal salary);
        List<WorkingSession> GetWorkingSessions(string? name, DateTime? fromDate, DateTime? toDate);
    }
}
