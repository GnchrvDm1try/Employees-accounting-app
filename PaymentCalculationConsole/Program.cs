using System;
using System.Collections.Generic;
using PaymentCalculation.Model;
using PaymentCalculation.Resources;

namespace PaymentCalculation.PaymentCalculationConsole
{
    class Program
    {
        static FileStorage storage = new FileStorage();
        static Worker currentWorker = null;

        static void Login()
        {
            Console.Write("Enter your login: ");
            currentWorker = storage.FindWorkerByLogin(Console.ReadLine());
            if (currentWorker != null)
                Console.WriteLine(currentWorker.FirstName + " " + currentWorker.LastName + " - " + currentWorker.Position);
            else
                Login();
        }

        static void AvailableActions()
        {
            Console.WriteLine("(0) Exit");
            switch(currentWorker.Position)
            {
                case Position.Supervisor:
                    Console.WriteLine("(1) Add new worker");
                    Console.WriteLine("(2) Add working session");
                    Console.WriteLine("(3) View report for all employees");
                    Console.WriteLine("(4) View report for a specific employee");
                    string option = Console.ReadLine();
                    if (option == "0")
                        Environment.Exit(0);
                    else if (option == "1")
                        AddWorker();
                    else if(option == "2")
                    {
                        Console.Write("Enter worker's login: ");
                        string login = Console.ReadLine();
                        AddWorkingSession(login);
                    }
                    else
                    {
                        Console.WriteLine("Enter correct number!");
                        goto case Position.Supervisor;
                    }    
                    break;
                case Position.LocalEmployee:
                    Console.WriteLine("(1) Add working session");
                    Console.WriteLine("(2) View my sessions");
                    Console.ReadKey();
                    break;
                case Position.Freelancer:
                    Console.WriteLine("(1) Add working session");
                    Console.WriteLine("(2) View my sessions");
                    Console.ReadKey();
                    break;
            }
        }

        static void AddWorker()
        {
            try
            {
                Console.Write("Enter worker's login: ");
                string login = Console.ReadLine();
                Console.Write("Enter worker's first name: ");
                string firstName = Console.ReadLine();
                Console.Write("Enter worker's last name: ");
                string lastName = Console.ReadLine();

                PositionChoose:
                Console.WriteLine("Choose worker's position:" +
                    "\n(1) Supervisor" +
                    "\n(2) Local employee" +
                    "\n(3) Freelancer");
                string option = Console.ReadLine();
                Position position;
                if (option == "1")
                    position = Position.Supervisor;
                else if (option == "2")
                    position = Position.LocalEmployee;
                else if (option == "3")
                    position = Position.Freelancer;
                else
                {
                    Console.WriteLine("Enter correct number!");
                    goto PositionChoose;
                }

                Console.WriteLine("Enter worker's salary(not required): ");
                decimal? salary = null;
                string stringSalary = Console.ReadLine();
                if (!string.IsNullOrEmpty(stringSalary))
                    salary = Convert.ToDecimal(stringSalary);

                Worker worker = null;
                switch(position)
                {
                    case Position.Supervisor:
                        worker = new Supervisor(login,firstName,lastName,salary);
                        break;
                    case Position.LocalEmployee:
                        worker = new LocalEmployee(login,firstName,lastName,salary);
                        break;
                    case Position.Freelancer:
                        worker = new Freelancer(login, firstName, lastName, salary);
                        break;
                }
                storage.AddWorker(worker);
                Console.WriteLine("Added new worker.");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Failed to add user: {ex.Message}");
            }
            finally
            {
                AvailableActions();
            }
        }

        static void AddWorkingSession(string login)
        {
            try
            {
                if(storage.FindWorkerByLogin(login) != null)
                {
                    Console.Write("Enter session's date: ");
                    DateTime date = Convert.ToDateTime(Console.ReadLine());
                    Console.Write("Enter session's time gap: ");
                    byte gap = Convert.ToByte(Console.ReadLine());
                    Console.Write("Enter session's comment: ");
                    string comment = Console.ReadLine();
                    WorkingSession session = new WorkingSession(login, date, gap, comment);
                    storage.AddWorkingSession(session);
                    Console.WriteLine("Added new session.");
                }
                else
                {
                    throw new Exception("There is no worker with this login.");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Failed to add working session: {ex.Message}");
            }
            finally
            {
                AvailableActions();
            }
        }

        static void Main(string[] args)
        {
            Login();
            AvailableActions();
        }
    }
}
