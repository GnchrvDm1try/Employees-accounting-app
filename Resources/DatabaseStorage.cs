using System;
using System.Collections.Generic;
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
            connection.Open();
        }

        ~DatabaseStorage()
        {
            connection.Close();
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
            string sqlCommand = $"INSERT INTO workers(login, first_name, last_name, position_id, payment) " +
                $"values('{worker.Login}', '{worker.FirstName}', '{worker.LastName}', {(int)worker.Position}, {payment})";
            NpgsqlCommand command = new NpgsqlCommand(sqlCommand, connection);
            command.ExecuteNonQuery();
        }

        public void AddWorkingSession(WorkingSession session)
        {
            string sqlCommand = $"INSERT INTO workingsessions(worker_login, date, gap, comment) " +
                $"values('{session.Login}', '{session.Date}', {session.Gap}, '{session.Comment}')";
            using NpgsqlCommand command = new NpgsqlCommand(sqlCommand, connection);
            command.ExecuteNonQuery();
        }

        public Worker FindWorkerByLogin(string login, bool nullable)
        {
            Worker worker = null;
            string sqlCommand = $"SELECT * FROM workers WHERE login = '{login}'";
            using NpgsqlCommand command = new NpgsqlCommand(sqlCommand, connection);
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
            List<WorkingSession> workingSessions = new List<WorkingSession>();
            string sqlCommand = "SELECT * FROM workingsessions";
            if(fromDate != null)
            {
                sqlCommand += $" WHERE date >= '{fromDate}'";
                if (toDate != null)
                    sqlCommand += $" AND date <= '{toDate}'";
            }
            using var command = new NpgsqlCommand(sqlCommand, connection);
            using var reader = command.ExecuteReader();
            while(reader.Read())
            {
                workingSessions.Add(new WorkingSession(reader.GetString(0), reader.GetDateTime(1), reader.GetByte(2), reader.GetString(3)));
            }
            return workingSessions;
        }

        public List<WorkingSession> GetWorkingSessionsByLogin(string login, DateTime? fromDate, DateTime? toDate)
        {
            List<WorkingSession> workingSessions = new List<WorkingSession>();
            string sqlCommand = $"SELECT * FROM workingsessions WHERE worker_login = '{login}'";
            if (fromDate != null)
            {
                sqlCommand += $" AND date >= '{fromDate}'";
                if (toDate != null)
                    sqlCommand += $" AND date <= '{toDate}'";
            }
            using var command = new NpgsqlCommand(sqlCommand, connection);
            using var reader = command.ExecuteReader();
            while(reader.Read())
            {
                workingSessions.Add(new WorkingSession(reader.GetString(1), reader.GetDateTime(2), reader.GetByte(3), reader.GetString(4)));
            }
            return workingSessions;
        }
    }
}
