using PaymentCalculation.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace PaymentCalculation.Resources
{
    public class FileStorage : IStorage
    {
        static readonly string supervisorsFilePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName + "\\Resources\\Storage\\Supervisors.csv";
        static readonly string localEmployeeFilePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName + "\\Resources\\Storage\\LocalEmployees.csv";
        static readonly string freelancerFilePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName + "\\Resources\\Storage\\Freelancers.csv";
        static readonly string workingSessionsFilePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName + "\\Resources\\Storage\\WorkingSessions.csv";
        static FileStorage()
        {
            if(!File.Exists(supervisorsFilePath))
            {
                File.Create(supervisorsFilePath);
            }
            if(!File.Exists(localEmployeeFilePath))
            {
                File.Create(localEmployeeFilePath);
            }
            if(!File.Exists(freelancerFilePath))
            {
                File.Create(freelancerFilePath);
            }
            if(!File.Exists(workingSessionsFilePath))
            {
                File.Create(workingSessionsFilePath);
            }
        }

        public void AddWorker(Worker worker, decimal salary)
        {
            switch(worker.Position)
            {
                case "Supervisor":
                    StreamWriter supervisorsWriter = new StreamWriter(supervisorsFilePath);
                    supervisorsWriter.WriteLine(worker.FullName + "," + salary);
                    break;
                case "LocalEmployee":
                    StreamWriter localEmployeesWriter = new StreamWriter(localEmployeeFilePath);
                    localEmployeesWriter.WriteLine(worker.FullName + "," + salary);
                    break;
                case "Freelancer":
                    StreamWriter freelancersWriter = new StreamWriter(freelancerFilePath);
                    freelancersWriter.WriteLine(worker.FullName + "," + salary);
                    break;
                default:
                    throw new Exception("Wrong type of user!");
            }
        }

        public void AddWorkingSession(WorkingSession session)
        {
            StreamWriter sessionWriter = new StreamWriter(workingSessionsFilePath);
            sessionWriter.WriteLine(session.Name + "," + session.Date.Date + "," + session.Gap + "," + session.Comment);//???????????????????????????????????????
        }

        public List<WorkingSession> GetWorkingSessions(string name, DateTime? fromDate, DateTime? toDate)
        {
            List<WorkingSession> workingSessions = new List<WorkingSession>();
            try
            {
                if (fromDate != null && toDate != null)
                {
                    StreamReader sessionsReader = new StreamReader(workingSessionsFilePath);

                    string line;
                    string[] parameters;

                    while ((line = sessionsReader.ReadLine()) != null)
                    {
                        parameters = line.Split(',');

                        string fullName = parameters[0];
                        DateTime date = Convert.ToDateTime(parameters[1]);
                        byte gap = Convert.ToByte(parameters[2]);
                        string comment = parameters[3];

                        if (fromDate <= date.Date && date.Date <= toDate)
                        {
                            WorkingSession session = new WorkingSession(fullName, date, gap, comment);
                            workingSessions.Add(session);
                        }
                    }
                    sessionsReader.Close();
                }
                else if (fromDate != null && toDate == null)
                {
                    StreamReader sessionReader = new StreamReader(workingSessionsFilePath);

                    string line;
                    string[] parameters;

                    while ((line = sessionReader.ReadLine()) != null)
                    {
                        parameters = line.Split(',');

                        string fullName = parameters[0];
                        DateTime date = Convert.ToDateTime(parameters[1]);
                        byte gap = Convert.ToByte(parameters[2]);
                        string comment = parameters[3];

                        if (fromDate <= date.Date && date.Date <= DateTime.Now.Date)
                        {
                            WorkingSession session = new WorkingSession(fullName, date, gap, comment);
                            workingSessions.Add(session);
                        }
                    }
                    sessionReader.Close();
                }
                else
                {
                    StreamReader sessionReader = new StreamReader(workingSessionsFilePath);

                    string line;
                    string[] parameters;

                    while ((line = sessionReader.ReadLine()) != null)
                    {
                        parameters = line.Split(',');

                        string fullName = parameters[0];
                        DateTime date = Convert.ToDateTime(parameters[1]);
                        byte gap = Convert.ToByte(parameters[2]);
                        string comment = parameters[3];

                        WorkingSession session = new WorkingSession(fullName, date, gap, comment);
                        workingSessions.Add(session);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Не удалось считать файл! " + ex.Message);
            }
            return workingSessions;
        }
    }
}
