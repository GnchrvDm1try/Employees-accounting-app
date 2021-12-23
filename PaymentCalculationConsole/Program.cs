using System;
using System.Collections.Generic;
using PaymentCalculation.Model;
using PaymentCalculation.Resources;

namespace PaymentCalculation.PaymentCalculationConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Enter your name: ");
            //string currentUserName = Console.ReadLine();
            Supervisor w = new Supervisor("Victor Stepov", "Supervisor", 200000);
            //Supervisor d = new Supervisor("Ivan Ivanov", "Supervisor", 210000);
            FileStorage storage = new FileStorage();
            List<WorkingSession> sessions = storage.GetWorkingSessions(w.FullName, new DateTime(2021, 11, 24));
            foreach(var item in sessions)
            {
                Console.WriteLine(item.ToString());
            }
            //WorkingSession session = new WorkingSession(w.FullName, new DateTime(2021, 11, 28), 11, "Some stuff2");
            //storage.AddWorkingSession(session);
            //storage.AddWorker(d);
            //storage.GetWorkingSessions
        }
    }
}
