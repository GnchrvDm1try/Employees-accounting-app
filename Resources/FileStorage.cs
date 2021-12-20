using System;
using System.IO;

namespace PaymentCalculation.Resources
{
    public static class FileStorage
    {
        static readonly string filePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName + "\\Employees";
        static FileStorage()
        {
            if(!File.Exists(filePath))
            {
                File.Create(filePath);
            }
        }

        static void AddEmployee()
        {

        }
    }
}
