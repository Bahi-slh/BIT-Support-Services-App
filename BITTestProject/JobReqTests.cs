using BITDesktopApp.Models;
using BITDesktopApp.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BITTestProject
{
    [TestClass]
    public class JobRequestTests
    {
        //[TestInitialize]
        //public void TestInit()
        //{
        //    Console.WriteLine("hi");

        //}
        [TestMethod]
        public void TestJobRequestFirstname()
        {
            JobRequest j = new JobRequest();
            j.Address = "Test";
            Assert.AreEqual("Test", j.Address);
        }
        [TestMethod]
        public void TestJobRequestLastname()
        {
            JobRequest j = new JobRequest();
            j.State = "Test";
            Assert.AreEqual("Test", j.State);
        }
        [TestMethod]
        public void TestJobRequestEmail()
        {
            JobRequest j = new JobRequest();
            j.Suburb = "Test";
            Assert.AreEqual("Test", j.Suburb);
        }
        //Integration Testing - Two or more components/layers of the application when tested using any test platform is called Automated Integraion Testing
        [TestMethod]
        public void TestJobRequestCollection()
        {
            JobManagementViewModel jobVM = new JobManagementViewModel();
            int count = jobVM.CompletedJobs.Count;
            Assert.AreEqual(2, count);
        }
    }
}
