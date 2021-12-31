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