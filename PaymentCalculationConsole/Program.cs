using System;
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
            Supervisor d = new Supervisor("Ivan Ivanov", "Supervisor", 210000);
            FileStorage storage = new FileStorage();
            storage.AddWorker(w);
            storage.AddWorker(d);
            //storage.GetWorkingSessions
        }
    }
}
