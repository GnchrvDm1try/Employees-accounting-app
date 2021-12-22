using PaymentCalculation.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace PaymentCalculation.Resources
{
    public class FileStorage : IStorage
    {
        static readonly string SupervisorsFilePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName + "\\Resources\\Storage\\Supervisors.csv";
        static readonly string WorkingSessionsFilePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName + "\\Resources\\Storage\\WorkingSession.csv";
        static FileStorage()
        {
            if(!File.Exists(SupervisorsFilePath))
            {
                File.Create(SupervisorsFilePath);
            }
            if(!File.Exists(WorkingSessionsFilePath))
            {
                File.Create(WorkingSessionsFilePath);
            }
        }

        public void AddWorker(Worker worker, decimal salary)
        {
            
        }

        public void AddWorkingSession(WorkingSession session)
        {
            throw new NotImplementedException();
        }

        public List<WorkingSession> GetWorkingSessions(string name, DateTime? fromDate, DateTime? toDate)
        {
            throw new NotImplementedException();
        }
    }
}
