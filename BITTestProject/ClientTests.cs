using BITDesktopApp.Models;
using BITDesktopApp.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BITTestProject
{
    [TestClass]
    public class ClientTests
    {
        //[TestInitialize]
        //public void TestInit()
        //{
        //    Console.WriteLine("hi");

        //}
        [TestMethod]
        public void TestClientFirstname()
        {
            Client c = new Client();
            c.Firstname = "Test";
            Assert.AreEqual("Test", c.Firstname);
        }
        [TestMethod]
        public void TestClientLastname()
        {
            Client c1 = new Client();
            c1.Lastname = "Test";
            Assert.AreEqual("Test", c1.Lastname);
        }
        [TestMethod]
        public void TestClientEmail()
        {
            Client c2 = new Client();
            c2.Email = "Test";
            Assert.AreEqual("Test", c2.Email);
        }
        //Integration Testing - Two or more components/layers of the application when tested using any test platform is called Automated Integraion Testing
        [TestMethod]
        public void TestClientCollection()
        {
            ClientManagementViewModel clientVM = new ClientManagementViewModel();
            int count = clientVM.Clients.Count;
            Assert.AreEqual(8, count);
        }
    }
}
