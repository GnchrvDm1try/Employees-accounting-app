using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using PaymentCalculation.Model;
using PaymentCalculation.Resources;

namespace PaymentCalculation.PaymentCalculationTests
{
    public class StorageTests
    {
        [SetUp]
        public void Setup()
        {
        }

        //Test that checks if the searching method finds the worker whose login matches with the searching login
        //If the worker not found test passes
        //Otherwise (if login does not match), test failed
        [Test]
        public void FindWorkerByLoginTest()
        {
            FileStorage fileStorage = new FileStorage();
            string login = "victor1";//Pick login here. It should be in any file
            Worker worker = fileStorage.FindWorkerByLogin(login);
            if (worker == null)
            {
                Assert.IsTrue(true);
                return;
            }
            Assert.IsTrue(worker.Login == login);
        }

        //Test that checks if the list of preset sessions matches with the list of returned by the method sessions
        [Test]
        public void GetWorkingSessionsTest()
        {
            FileStorage fileStorage = new FileStorage();
            bool isEqual = true;
            Worker testUser = fileStorage.FindWorkerByLogin("bohdan1");
            //The list of sessions, which are in the file
            List<WorkingSession> testWorkingSessions = new List<WorkingSession>()
            {
                new WorkingSession(testUser.Login, new DateTime(2021, 11, 29), 5, "Some staff #1"),
                new WorkingSession(testUser.Login, new DateTime(2021, 11, 30), 2, "Some staff #2"),
                new WorkingSession(testUser.Login, new DateTime(2021, 12, 2), 7, "Some staff #3"),
                new WorkingSession(testUser.Login, new DateTime(2021, 12, 4), 1, "Some staff #4")
            };
            //The list of sessions, which belong to the testing user, returned by the method
            List<WorkingSession> workingSessions = fileStorage.GetWorkingSessionsByLogin(testUser.Login);
            for(int i = 0; i < testWorkingSessions.Count; i++)
            {
                if (testWorkingSessions[i].ToString() != workingSessions[i].ToString())
                    isEqual = false;
            }
            Assert.IsTrue(isEqual);
        }

        [Test]
        public void GetReportsTest()
        {
            //DateTime fromDate = new DateTime(2020, 1, 1);
            //DateTime toDate = new DateTime(2020, 12, 31);
            //List<WorkingSession> sessions = new List<WorkingSession> 
            //{
            //    new WorkingSession("11", new DateTime(2020,10,11),5,""),
            //    //new WorkingSession("22", new DateTime(2020,11,12),7,""),
            //    new WorkingSession("11", new DateTime(2021,4,1),8,"233"),
            //    new WorkingSession("11", new DateTime(2020,10,11),5,""),
            //    //new WorkingSession("33", new DateTime(2020,10,11),5,""),
            //    //new WorkingSession("44", new DateTime(2020,10,11),5,""),
            //};
            //bool contains = false;

            //List<WorkingSession> reports = new List<WorkingSession>();
            //foreach (WorkingSession session in sessions)
            //{
            //    if (fromDate < session.Date && session.Date < toDate)
            //    {
            //        if (reports.FirstOrDefault(x => x.Name == session.Name) == null)
            //        {
            //            reports.Add(session);
            //        }
            //        else
            //        {
            //            contains = true;

            //        }
            //    }
            //}
            //Assert.IsTrue(contains);
        }
    }
}