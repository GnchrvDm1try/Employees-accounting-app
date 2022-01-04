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
        void AddWorker(Worker worker);

        void AddWorkingSession(WorkingSession session);

        Worker FindWorkerByLogin(string login);

        List<WorkingSession> GetWorkingSessionsByLogin(string name, DateTime? fromDate, DateTime? toDate);

        List<WorkingSession> GetAllWorkingSessions(DateTime? fromDate, DateTime? toDate);
    }
}
