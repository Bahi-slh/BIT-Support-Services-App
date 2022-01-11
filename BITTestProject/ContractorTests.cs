using BITDesktopApp.Models;
using BITDesktopApp.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BITTestProject
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class ContractorTests
    {
        //[TestInitialize]
        //public void TestInit()
        //{
        //    Console.WriteLine("hi");

        //}
        [TestMethod]
        public void TestContractorFirstname()
        {
            Contractor c = new Contractor();
            c.Firstname = "Test";
            Assert.AreEqual("Test", c.Firstname);
        }
        [TestMethod]
        public void TestContractorLastname()
        {
            Contractor c1 = new Contractor();
            c1.Lastname = "Test";
            Assert.AreEqual("Test", c1.Lastname);
        }
        [TestMethod]
        public void TestContractorEmail()
        {
            Contractor c2 = new Contractor();
            c2.Email = "Test";
            Assert.AreEqual("Test", c2.Email);
        }
        //Integration Testing - Two or more components/layers of the application when tested using any test platform is called Automated Integraion Testing
        [TestMethod]
        public void TestContractorCollection()
        {
            ContractorManagementViewModel clientVM = new ContractorManagementViewModel();
            int count = clientVM.Contractors.Count;
            Assert.AreEqual(4, count);
        }
    }
}
