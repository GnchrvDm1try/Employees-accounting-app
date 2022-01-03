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
        static readonly string localEmployeesFilePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName + "\\Resources\\Storage\\LocalEmployees.csv";
        static readonly string freelancersFilePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName + "\\Resources\\Storage\\Freelancers.csv";
        static readonly string workingSessionsFilePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName + "\\Resources\\Storage\\WorkingSessions.csv";
        static FileStorage()
        {
            if(!File.Exists(supervisorsFilePath))
            {
                File.Create(supervisorsFilePath);
            }
            if(!File.Exists(localEmployeesFilePath))
            {
                File.Create(localEmployeesFilePath);
            }
            if(!File.Exists(freelancersFilePath))
            {
                File.Create(freelancersFilePath);
            }
            if(!File.Exists(workingSessionsFilePath))
            {
                File.Create(workingSessionsFilePath);
            }
        }

        public void AddWorker(Worker worker)
        {
            try
            {
                if (FindWorkerByLogin(worker.Login) != null)
                    throw new Exception("User with this login already exists");
                switch (worker.Position)
                {
                    case Position.Supervisor:
                        using (StreamWriter supervisorsWriter = new StreamWriter(supervisorsFilePath, true))
                        {
                            Supervisor supervisor = (Supervisor)worker;
                            supervisorsWriter.WriteLine(supervisor.Login + "," + supervisor.FirstName + "," + supervisor.LastName + "," + supervisor.Salary);
                        }
                        break;
                    case Position.LocalEmployee:
                        using (StreamWriter localEmployeesWriter = new StreamWriter(localEmployeesFilePath, true))
                        {
                            LocalEmployee localEmployee = (LocalEmployee)worker;
                            localEmployeesWriter.WriteLine(localEmployee.Login + "," + localEmployee.FirstName + "," + localEmployee.LastName + "," + localEmployee.Salary);
                        }
                        break;
                    case Position.Freelancer:
                        using (StreamWriter freelancersWriter = new StreamWriter(freelancersFilePath, true))
                        {
                            Freelancer freelancer = (Freelancer)worker;
                            freelancersWriter.WriteLine(freelancer.Login + "," + freelancer.FirstName + "," + freelancer.LastName + "," + freelancer.PaymentPerHour);
                        }
                        break;
                    default:
                        throw new Exception("Wrong type of user!");
                }
            }
            catch(Exception ex)
            {
                
            }
        }

        public void AddWorkingSession(WorkingSession session)
        {
            using (StreamWriter sessionWriter = new StreamWriter(workingSessionsFilePath, true))
            {
                sessionWriter.WriteLine(session.Login + "," + session.Date.ToString("dd.MM.yyyy") + "," + session.Gap + "," + session.Comment);
            }
        }

        public List<WorkingSession> GetWorkingSessions(string login, DateTime? fromDate = null, DateTime? toDate = null)
        {
            List<WorkingSession> workingSessions = new List<WorkingSession>();
            try
            {
                using (StreamReader sessionsReader = new StreamReader(workingSessionsFilePath))
                {
                    string line;
                    string[] parameters;

                    while ((line = sessionsReader.ReadLine()) != null)
                    {
                        parameters = line.Split(',');

                        DateTime date = Convert.ToDateTime(parameters[1]);
                        byte gap = Convert.ToByte(parameters[2]);
                        string comment = parameters[3];

                        if (fromDate != null && toDate != null)
                        {
                            if (parameters[0] == login && fromDate <= date.Date && date.Date <= toDate)
                            {
                                WorkingSession session = new WorkingSession(login, date, gap, comment);
                                workingSessions.Add(session);
                            }
                        }
                        else if (fromDate != null && toDate == null)
                        {
                            if (parameters[0] == login && fromDate <= date.Date && date.Date <= DateTime.Now.Date)
                            {
                                WorkingSession session = new WorkingSession(login, date, gap, comment);
                                workingSessions.Add(session);
                            }
                        }
                        else
                        {
                            if(parameters[0] == login)
                            {
                                WorkingSession session = new WorkingSession(login, date, gap, comment);
                                workingSessions.Add(session);
                            }
                        }
                    }
                }

            }
            catch(Exception ex)
            {
                
            }
            return workingSessions;
        }

        public Worker FindWorkerByLogin(string login)
        {
            Worker worker = null;
            try
            {
                using (StreamReader streamReader = new StreamReader(supervisorsFilePath))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        string[] parameters = line.Split(',');
                        if (parameters[0] == login)
                        {
                            worker = new Supervisor(parameters[0], parameters[1], parameters[2], Convert.ToDecimal(parameters[3]));
                            return worker;
                        }
                    }
                }
                if (worker == null)
                {
                    using (StreamReader streamReader = new StreamReader(localEmployeesFilePath))
                    {
                        string line;
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            string[] parameters = line.Split(',');
                            if (parameters[0] == login)
                            {
                                worker = new LocalEmployee(parameters[0], parameters[1], parameters[2], Convert.ToDecimal(parameters[3]));
                                return worker;
                            }
                        }
                    }
                }
                if(worker == null)
                {
                    using (StreamReader streamReader = new StreamReader(freelancersFilePath))
                    {
                        string line;
                        while((line = streamReader.ReadLine()) != null)
                        {
                            string[] parameters = line.Split(',');
                            if(parameters[0] == login)
                            {
                                worker = new Freelancer(parameters[0], parameters[1], parameters[2], Convert.ToDecimal(parameters[3]));
                                return worker;
                            }
                        }
                    }
                }
                throw new Exception("There is no worker with this login.");
            }
            catch (Exception ex)
            {
                
            }
            return worker;
        }
    }
}
