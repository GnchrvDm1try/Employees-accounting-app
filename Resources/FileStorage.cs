using PaymentCalculation.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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

        public void AddWorker(Worker worker)
        {
            switch(worker.Position)
            {
                case "Supervisor":
                    StreamWriter supervisorsWriter = new StreamWriter(supervisorsFilePath, true);
                    Supervisor supervisor = (Supervisor)worker;
                    supervisorsWriter.WriteLine(supervisor.FullName + "," + supervisor.Salary);
                    supervisorsWriter.Close();
                    break;
                case "LocalEmployee":
                    StreamWriter localEmployeesWriter = new StreamWriter(localEmployeeFilePath, true);
                    LocalEmployee localEmployee = (LocalEmployee)worker;
                    localEmployeesWriter.WriteLine(localEmployee.FullName + "," + localEmployee.Salary);
                    localEmployeesWriter.Close();
                    break;
                case "Freelancer":
                    StreamWriter freelancersWriter = new StreamWriter(freelancerFilePath, true);
                    Freelancer freelancer = (Freelancer)worker;
                    freelancersWriter.WriteLine(freelancer.FullName + "," + freelancer.PaymentPerHour);
                    freelancersWriter.Close();
                    break;
                default:
                    throw new Exception("Wrong type of user!");
            }
        }

        public void AddWorkingSession(WorkingSession session)
        {
            using (StreamWriter sessionWriter = new StreamWriter(workingSessionsFilePath, true))
            {
                sessionWriter.WriteLine(session.Name + "," + session.Date.Date + "," + session.Gap + "," + session.Comment);//???????????????????????????????????????
            }
        }

        public List<WorkingSession> GetWorkingSessions(string name, DateTime? fromDate = null, DateTime? toDate = null)
        {
            List<WorkingSession> workingSessions = new List<WorkingSession>();
            try
            {
                if (fromDate != null && toDate != null)
                {
                    using (StreamReader sessionsReader = new StreamReader(workingSessionsFilePath))
                    {
                        string line;
                        string[] parameters;

                        while ((line = sessionsReader.ReadLine()) != null)
                        {
                            parameters = line.Split(',');

                            string fullName = parameters[0];
                            DateTime date = Convert.ToDateTime(parameters[1]);
                            byte gap = Convert.ToByte(parameters[2]);
                            string comment = parameters[3];

                            if (fullName == name && fromDate <= date.Date && date.Date <= toDate)
                            {
                                WorkingSession session = new WorkingSession(fullName, date, gap, comment);
                                workingSessions.Add(session);
                            }
                        }
                    }
                }
                else if (fromDate != null && toDate == null)
                {
                    using (StreamReader sessionReader = new StreamReader(workingSessionsFilePath))
                    {
                        string line;
                        string[] parameters;

                        while ((line = sessionReader.ReadLine()) != null)
                        {
                            parameters = line.Split(',');

                            string fullName = parameters[0];
                            DateTime date = Convert.ToDateTime(parameters[1]);
                            byte gap = Convert.ToByte(parameters[2]);
                            string comment = parameters[3];

                            if (fullName == name && fromDate <= date.Date && date.Date <= DateTime.Now.Date)
                            {
                                WorkingSession session = new WorkingSession(fullName, date, gap, comment);
                                workingSessions.Add(session);
                            }
                        }
                    }
                }
                else
                {
                    using (StreamReader sessionReader = new StreamReader(workingSessionsFilePath))
                    {
                        string line;
                        string[] parameters;

                        while ((line = sessionReader.ReadLine()) != null)
                        {
                            parameters = line.Split(',');

                            string fullName = parameters[0];
                            if (fullName == name)
                            {
                                DateTime date = Convert.ToDateTime(parameters[1]);
                                byte gap = Convert.ToByte(parameters[2]);
                                string comment = parameters[3];

                                WorkingSession session = new WorkingSession(fullName, date, gap, comment);
                                workingSessions.Add(session);
                            }
                        }
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
