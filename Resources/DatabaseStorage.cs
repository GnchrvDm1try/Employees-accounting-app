using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Configuration;
using PaymentCalculation.Model;
using Npgsql;

namespace PaymentCalculation.Resources
{
    public class DatabaseStorage : IStorage
    {
        static readonly string connectionString = "Server = localhost; Database = EmployeesAccounting; User Id = postgres; Password = admin";
        static readonly NpgsqlConnection connection = new NpgsqlConnection();

        public DatabaseStorage()
        {
            connection.ConnectionString = connectionString;
            try
            {
                connection.Open();
            }
            catch
            {
                Console.WriteLine("Failed to connect to the db");
            }
        }

        ~DatabaseStorage()
        {
            try
            {
                connection.Close();
            }
            catch
            {
                Console.WriteLine("Failed to disconnect from the db");
            }
        }

        public async void Op()
        {
            try
            {
                await using var command = new NpgsqlCommand($"SELECT * FROM workers", connection);
                await using var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    Console.Write(reader.GetString(0) + " ");
                    Console.Write(reader.GetString(1) + " ");
                    Console.Write(reader.GetString(2) + " ");
                    Console.Write((Position)reader.GetInt16(3) + " ");
                    Console.WriteLine(reader.GetDecimal(4));
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void AddWorker(Worker worker)
        {
            string payment;
            switch (worker.Position)
            {
                case Position.Supervisor:
                    Supervisor supervisor = (Supervisor)worker;
                    payment = supervisor.Salary.ToString();
                    break;
                case Position.LocalEmployee:
                    LocalEmployee localEmployee = (LocalEmployee)worker;
                    payment = localEmployee.Salary.ToString();
                    break;
                case Position.Freelancer:
                    Freelancer freelancer = (Freelancer)worker;
                    payment = freelancer.PaymentPerHour.ToString();
                    break;
                default:
                    throw new Exception("Wrong type of user!");
            }
            NpgsqlCommand command = new NpgsqlCommand($"INSERT INTO workers(login, first_name, last_name, position_id, payment) " +
                $"values(\'{worker.Login}\', \'{worker.FirstName}\', \'{worker.LastName}\', {(int)worker.Position}, {payment})", connection);
            command.ExecuteNonQuery();
        }

        public void AddWorkingSession(WorkingSession session)
        {
            throw new NotImplementedException();
        }

        public Worker FindWorkerByLogin(string login, bool nullable)
        {
            Worker worker = null;
            using NpgsqlCommand command = new NpgsqlCommand($"SELECT * FROM workers WHERE login = '{login}'", connection);
            using NpgsqlDataReader reader = command.ExecuteReader();
            reader.Read();
            if (reader.IsOnRow)
            {
                if (reader.GetInt16(3) == (int)Position.Supervisor)
                    worker = new Supervisor(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetDecimal(4));
                else if (reader.GetInt16(3) == (int)Position.LocalEmployee)
                    worker = new LocalEmployee(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetDecimal(4));
                else if(reader.GetInt16(3) == (int)Position.Freelancer)
                    worker = new Freelancer(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetDecimal(4));
                return worker;
            }
            if (nullable == true)
                return worker;
            else
                throw new Exception("There is no worker with this login.");
        }

        public List<WorkingSession> GetAllWorkingSessions(DateTime? fromDate, DateTime? toDate)
        {
            throw new NotImplementedException();
        }

        public List<WorkingSession> GetWorkingSessionsByLogin(string name, DateTime? fromDate, DateTime? toDate)
        {
            using var command = new NpgsqlCommand("SELECT * FROM workers", connection);
            using var reader = command.ExecuteReader();
            while(reader.Read())
            {

            }
            throw new NotImplementedException();
        }
    }
}
