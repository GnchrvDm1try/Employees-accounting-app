using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using PaymentCalculation.Model;
using PaymentCalculation.Resources;

namespace PaymentCalculation.PaymentCalculationTests
{
    public class WorkerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        //Test that checks if the payment for a worker is considered correct 
        //Pick the worker's type (Supervisor / LocalEmployee / Freelancer)
        //Expected result is already calculated for these working sessions
        [Test]
        public void PaymentCalculateTest()
        {
            Worker worker = new Supervisor("test", "testname", "testlastname", 2500); //Pick worker's position here
            List<WorkingSession> workingSessions = new List<WorkingSession>
            {
                //Session payment is 101,25 (Supervisor)
                new WorkingSession("test", new DateTime(2021,11,15), 6, "Some staff #1"),
                //Session payment is 135 (Supervisor)
                new WorkingSession("test", new DateTime(2021,11,16), 8, "Some staff #2"),
                //Login of another user - it won't be counted  
                new WorkingSession("test1", new DateTime(2021,11,15), 5, "Some staff #5"),
                //Session payment is 135 + bonus(13,5) = 148,5 (Supervisor)
                new WorkingSession("test", new DateTime(2021,11,20), 9, "Some staff #3"),
                //Session payment is 67,5 (Supervisor)
                new WorkingSession("test", new DateTime(2021,11,22), 4, "Some staff #4")
            };
            decimal expected = 452.25m;// - expected Supervisor's payment
            //decimal expected = 351m;// - expected Freelancer's payment
            //decimal expected = 253.125m;// - expected Local Employee's payment
            decimal actual = worker.CalculatePayment(workingSessions);
            Assert.AreEqual(expected, actual);
        }
    }
}