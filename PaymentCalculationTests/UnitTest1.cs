using System;
using NUnit.Framework;
using PaymentCalculation.Model;
using System.Collections.Generic;
using System.Linq;

namespace PaymentCalculationTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetReportsTest()
        {
            DateTime fromDate = new DateTime(2020, 1, 1);
            DateTime toDate = new DateTime(2020, 12, 31);
            List<WorkingSession> sessions = new List<WorkingSession> 
            {
                new WorkingSession("11", new DateTime(2020,10,11),5,""),
                //new WorkingSession("22", new DateTime(2020,11,12),7,""),
                new WorkingSession("11", new DateTime(2021,4,1),8,"233"),
                new WorkingSession("11", new DateTime(2020,10,11),5,""),
                //new WorkingSession("33", new DateTime(2020,10,11),5,""),
                //new WorkingSession("44", new DateTime(2020,10,11),5,""),
            };
            bool contains = false;

            List<WorkingSession> reports = new List<WorkingSession>();
            foreach (WorkingSession session in sessions)
            {
                if (fromDate < session.Date && session.Date < toDate)
                {
                    if (reports.FirstOrDefault(x => x.Name == session.Name) == null)
                    {
                        reports.Add(session);
                    }
                    else
                    {
                        contains = true;

                    }
                }
            }
            Assert.IsTrue(contains);
        }
    }
}